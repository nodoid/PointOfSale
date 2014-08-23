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
	partial class frmSelCompChk
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmSelCompChk() : base()
		{
			Load += frmSelCompChk_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdDatabase;
		public System.Windows.Forms.Button cmdDatabase {
			get { return withEventsField_cmdDatabase; }
			set {
				if (withEventsField_cmdDatabase != null) {
					withEventsField_cmdDatabase.Click -= cmdDatabase_Click;
				}
				withEventsField_cmdDatabase = value;
				if (withEventsField_cmdDatabase != null) {
					withEventsField_cmdDatabase.Click += cmdDatabase_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdCompany;
		public System.Windows.Forms.Button cmdCompany {
			get { return withEventsField_cmdCompany; }
			set {
				if (withEventsField_cmdCompany != null) {
					withEventsField_cmdCompany.Click -= cmdCompany_Click;
				}
				withEventsField_cmdCompany = value;
				if (withEventsField_cmdCompany != null) {
					withEventsField_cmdCompany.Click += cmdCompany_Click;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtKey;
		public System.Windows.Forms.TextBox txtKey {
			get { return withEventsField_txtKey; }
			set {
				if (withEventsField_txtKey != null) {
					withEventsField_txtKey.Enter -= txtKey_Enter;
				}
				withEventsField_txtKey = value;
				if (withEventsField_txtKey != null) {
					withEventsField_txtKey.Enter += txtKey_Enter;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRegistration;
		public System.Windows.Forms.Button cmdRegistration {
			get { return withEventsField_cmdRegistration; }
			set {
				if (withEventsField_cmdRegistration != null) {
					withEventsField_cmdRegistration.Click -= cmdRegistration_Click;
				}
				withEventsField_cmdRegistration = value;
				if (withEventsField_cmdRegistration != null) {
					withEventsField_cmdRegistration.Click += cmdRegistration_Click;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtCompany;
		public System.Windows.Forms.TextBox txtCompany {
			get { return withEventsField_txtCompany; }
			set {
				if (withEventsField_txtCompany != null) {
					withEventsField_txtCompany.Enter -= txtCompany_Enter;
					withEventsField_txtCompany.Leave -= txtCompany_Leave;
				}
				withEventsField_txtCompany = value;
				if (withEventsField_txtCompany != null) {
					withEventsField_txtCompany.Enter += txtCompany_Enter;
					withEventsField_txtCompany.Leave += txtCompany_Leave;
				}
			}
		}
		public System.Windows.Forms.Label _Label2_1;
		public System.Windows.Forms.Label _Label2_0;
		public System.Windows.Forms.Label lblCode;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.GroupBox frmRegister;
		private System.Windows.Forms.TextBox withEventsField_txtPassword;
		public System.Windows.Forms.TextBox txtPassword {
			get { return withEventsField_txtPassword; }
			set {
				if (withEventsField_txtPassword != null) {
					withEventsField_txtPassword.Enter -= txtPassword_Enter;
					withEventsField_txtPassword.KeyPress -= txtPassword_KeyPress;
				}
				withEventsField_txtPassword = value;
				if (withEventsField_txtPassword != null) {
					withEventsField_txtPassword.Enter += txtPassword_Enter;
					withEventsField_txtPassword.KeyPress += txtPassword_KeyPress;
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
		private System.Windows.Forms.Button withEventsField_cmdOK;
		public System.Windows.Forms.Button cmdOK {
			get { return withEventsField_cmdOK; }
			set {
				if (withEventsField_cmdOK != null) {
					withEventsField_cmdOK.Click -= cmdOK_Click;
				}
				withEventsField_cmdOK = value;
				if (withEventsField_cmdOK != null) {
					withEventsField_cmdOK.Click += cmdOK_Click;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtUserName;
		public System.Windows.Forms.TextBox txtUserName {
			get { return withEventsField_txtUserName; }
			set {
				if (withEventsField_txtUserName != null) {
					withEventsField_txtUserName.Enter -= txtUserName_Enter;
					withEventsField_txtUserName.KeyPress -= txtUserName_KeyPress;
				}
				withEventsField_txtUserName = value;
				if (withEventsField_txtUserName != null) {
					withEventsField_txtUserName.Enter += txtUserName_Enter;
					withEventsField_txtUserName.KeyPress += txtUserName_KeyPress;
				}
			}
		}
		//Public WithEvents MAPISession1 As MSMAPI.MAPISession 'MSMAPI.MAPISession
		//Public WithEvents MAPIMessages1 As MSMAPI.MAPIMessages 'MSMAPI.MAPIMessages
		public System.Windows.Forms.Timer tmrStart;
		public System.Windows.Forms.OpenFileDialog CDmasterOpen;
		private System.Windows.Forms.Button withEventsField_cmdBuild;
		public System.Windows.Forms.Button cmdBuild {
			get { return withEventsField_cmdBuild; }
			set {
				if (withEventsField_cmdBuild != null) {
					withEventsField_cmdBuild.Click -= cmdBuild_Click;
				}
				withEventsField_cmdBuild = value;
				if (withEventsField_cmdBuild != null) {
					withEventsField_cmdBuild.Click += cmdBuild_Click;
				}
			}
		}
		public System.Windows.Forms.ColumnHeader _lvLocation_ColumnHeader_1;
		public System.Windows.Forms.ColumnHeader _lvLocation_ColumnHeader_2;
		public System.Windows.Forms.ColumnHeader _lvLocation_ColumnHeader_3;
		private System.Windows.Forms.ListView withEventsField_lvLocation;
		public System.Windows.Forms.ListView lvLocation {
			get { return withEventsField_lvLocation; }
			set {
				if (withEventsField_lvLocation != null) {
					withEventsField_lvLocation.DoubleClick -= lvLocation_DoubleClick;
				}
				withEventsField_lvLocation = value;
				if (withEventsField_lvLocation != null) {
					withEventsField_lvLocation.DoubleClick += lvLocation_DoubleClick;
				}
			}
		}
		public System.Windows.Forms.ImageList ILtree;
		public System.Windows.Forms.Label _Label1_4;
		public System.Windows.Forms.Label _Label1_3;
		public System.Windows.Forms.Label _Label1_2;
		public System.Windows.Forms.Label _Label1_0;
		public System.Windows.Forms.Label _Label1_1;
		public System.Windows.Forms.Label lblDir;
		public System.Windows.Forms.Label lblPath;
		public System.Windows.Forms.Label lblCompany;
		//Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents Label2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSelCompChk));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdDatabase = new System.Windows.Forms.Button();
			this.cmdCompany = new System.Windows.Forms.Button();
			this.frmRegister = new System.Windows.Forms.GroupBox();
			this.txtKey = new System.Windows.Forms.TextBox();
			this.cmdRegistration = new System.Windows.Forms.Button();
			this.txtCompany = new System.Windows.Forms.TextBox();
			this._Label2_1 = new System.Windows.Forms.Label();
			this._Label2_0 = new System.Windows.Forms.Label();
			this.lblCode = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.txtUserName = new System.Windows.Forms.TextBox();
			//Me.MAPISession1 = New MSMAPI.MAPISession 'MSMAPI.MAPISession
			//Me.MAPIMessages1 = New MSMAPI.MAPIMessages 'MSMAPI.MAPIMessages
			this.tmrStart = new System.Windows.Forms.Timer(components);
			this.CDmasterOpen = new System.Windows.Forms.OpenFileDialog();
			this.cmdBuild = new System.Windows.Forms.Button();
			this.lvLocation = new System.Windows.Forms.ListView();
			this._lvLocation_ColumnHeader_1 = new System.Windows.Forms.ColumnHeader();
			this._lvLocation_ColumnHeader_2 = new System.Windows.Forms.ColumnHeader();
			this._lvLocation_ColumnHeader_3 = new System.Windows.Forms.ColumnHeader();
			this.ILtree = new System.Windows.Forms.ImageList();
			this._Label1_4 = new System.Windows.Forms.Label();
			this._Label1_3 = new System.Windows.Forms.Label();
			this._Label1_2 = new System.Windows.Forms.Label();
			this._Label1_0 = new System.Windows.Forms.Label();
			this._Label1_1 = new System.Windows.Forms.Label();
			this.lblDir = new System.Windows.Forms.Label();
			this.lblPath = new System.Windows.Forms.Label();
			this.lblCompany = new System.Windows.Forms.Label();
			//Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.Label2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.frmRegister.SuspendLayout();
			this.lvLocation.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.MAPISession1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.MAPIMessages1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Text = "4POS Company Loader ...";
			this.ClientSize = new System.Drawing.Size(610, 283);
			this.Location = new System.Drawing.Point(3, 29);
			this.Icon = (System.Drawing.Icon)resources.GetObject("frmSelCompChk.Icon");
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ControlBox = true;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmSelCompChk";
			this.cmdDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CancelButton = this.cmdDatabase;
			this.cmdDatabase.Text = "...";
			this.cmdDatabase.Enabled = false;
			this.cmdDatabase.Size = new System.Drawing.Size(25, 16);
			this.cmdDatabase.Location = new System.Drawing.Point(15, 309);
			this.cmdDatabase.TabIndex = 23;
			this.cmdDatabase.TabStop = false;
			this.cmdDatabase.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDatabase.CausesValidation = true;
			this.cmdDatabase.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDatabase.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDatabase.Name = "cmdDatabase";
			this.cmdCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCompany.Text = "...";
			this.cmdCompany.Enabled = false;
			this.cmdCompany.Size = new System.Drawing.Size(25, 16);
			this.cmdCompany.Location = new System.Drawing.Point(15, 288);
			this.cmdCompany.TabIndex = 22;
			this.cmdCompany.TabStop = false;
			this.cmdCompany.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCompany.CausesValidation = true;
			this.cmdCompany.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCompany.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCompany.Name = "cmdCompany";
			this.frmRegister.Text = "Unregisted Version";
			this.frmRegister.Size = new System.Drawing.Size(292, 139);
			this.frmRegister.Location = new System.Drawing.Point(288, 351);
			this.frmRegister.TabIndex = 14;
			this.frmRegister.Visible = false;
			this.frmRegister.BackColor = System.Drawing.SystemColors.Control;
			this.frmRegister.Enabled = true;
			this.frmRegister.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmRegister.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmRegister.Padding = new System.Windows.Forms.Padding(0);
			this.frmRegister.Name = "frmRegister";
			this.txtKey.AutoSize = false;
			this.txtKey.Size = new System.Drawing.Size(157, 19);
			this.txtKey.Location = new System.Drawing.Point(117, 78);
			this.txtKey.TabIndex = 19;
			this.txtKey.TabStop = false;
			this.txtKey.AcceptsReturn = true;
			this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtKey.BackColor = System.Drawing.SystemColors.Window;
			this.txtKey.CausesValidation = true;
			this.txtKey.Enabled = true;
			this.txtKey.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtKey.HideSelection = true;
			this.txtKey.ReadOnly = false;
			this.txtKey.MaxLength = 0;
			this.txtKey.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtKey.Multiline = false;
			this.txtKey.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtKey.Visible = true;
			this.txtKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtKey.Name = "txtKey";
			this.cmdRegistration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRegistration.Text = "Register";
			this.cmdRegistration.Size = new System.Drawing.Size(100, 22);
			this.cmdRegistration.Location = new System.Drawing.Point(177, 105);
			this.cmdRegistration.TabIndex = 17;
			this.cmdRegistration.TabStop = false;
			this.cmdRegistration.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRegistration.CausesValidation = true;
			this.cmdRegistration.Enabled = true;
			this.cmdRegistration.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRegistration.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRegistration.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRegistration.Name = "cmdRegistration";
			this.txtCompany.AutoSize = false;
			this.txtCompany.Size = new System.Drawing.Size(154, 19);
			this.txtCompany.Location = new System.Drawing.Point(117, 21);
			this.txtCompany.MaxLength = 50;
			this.txtCompany.TabIndex = 15;
			this.txtCompany.TabStop = false;
			this.txtCompany.AcceptsReturn = true;
			this.txtCompany.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtCompany.BackColor = System.Drawing.SystemColors.Window;
			this.txtCompany.CausesValidation = true;
			this.txtCompany.Enabled = true;
			this.txtCompany.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCompany.HideSelection = true;
			this.txtCompany.ReadOnly = false;
			this.txtCompany.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtCompany.Multiline = false;
			this.txtCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtCompany.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtCompany.Visible = true;
			this.txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtCompany.Name = "txtCompany";
			this._Label2_1.Text = "Activation key:";
			this._Label2_1.Size = new System.Drawing.Size(70, 13);
			this._Label2_1.Location = new System.Drawing.Point(39, 81);
			this._Label2_1.TabIndex = 21;
			this._Label2_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label2_1.BackColor = System.Drawing.Color.Transparent;
			this._Label2_1.Enabled = true;
			this._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label2_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label2_1.UseMnemonic = true;
			this._Label2_1.Visible = true;
			this._Label2_1.AutoSize = true;
			this._Label2_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label2_1.Name = "_Label2_1";
			this._Label2_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._Label2_0.Text = "Registration code:";
			this._Label2_0.Size = new System.Drawing.Size(93, 13);
			this._Label2_0.Location = new System.Drawing.Point(15, 51);
			this._Label2_0.TabIndex = 20;
			this._Label2_0.BackColor = System.Drawing.Color.Transparent;
			this._Label2_0.Enabled = true;
			this._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label2_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label2_0.UseMnemonic = true;
			this._Label2_0.Visible = true;
			this._Label2_0.AutoSize = false;
			this._Label2_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label2_0.Name = "_Label2_0";
			this.lblCode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblCode.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			this.lblCode.Text = "Label2";
			this.lblCode.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCode.Size = new System.Drawing.Size(156, 22);
			this.lblCode.Location = new System.Drawing.Point(117, 48);
			this.lblCode.TabIndex = 18;
			this.lblCode.Enabled = true;
			this.lblCode.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblCode.UseMnemonic = true;
			this.lblCode.Visible = true;
			this.lblCode.AutoSize = false;
			this.lblCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblCode.Name = "lblCode";
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_0.Text = "Store Name:";
			this._lbl_0.Size = new System.Drawing.Size(82, 16);
			this._lbl_0.Location = new System.Drawing.Point(24, 24);
			this._lbl_0.TabIndex = 16;
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
			this.txtPassword.AutoSize = false;
			this.txtPassword.Enabled = false;
			this.txtPassword.Size = new System.Drawing.Size(149, 16);
			this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.txtPassword.Location = new System.Drawing.Point(98, 377);
			this.txtPassword.PasswordChar = Strings.ChrW(42);
			this.txtPassword.TabIndex = 3;
			this.txtPassword.Text = "password";
			this.txtPassword.AcceptsReturn = true;
			this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
			this.txtPassword.CausesValidation = true;
			this.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPassword.HideSelection = true;
			this.txtPassword.ReadOnly = false;
			this.txtPassword.MaxLength = 0;
			this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPassword.Multiline = false;
			this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtPassword.TabStop = true;
			this.txtPassword.Visible = true;
			this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtPassword.Name = "txtPassword";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "E&xit";
			this.cmdCancel.Size = new System.Drawing.Size(76, 26);
			this.cmdCancel.Location = new System.Drawing.Point(171, 407);
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdOK.Text = "&OK";
			this.cmdOK.Enabled = false;
			this.cmdOK.Size = new System.Drawing.Size(76, 26);
			this.cmdOK.Location = new System.Drawing.Point(24, 407);
			this.cmdOK.TabIndex = 4;
			this.cmdOK.BackColor = System.Drawing.SystemColors.Control;
			this.cmdOK.CausesValidation = true;
			this.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdOK.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdOK.TabStop = true;
			this.cmdOK.Name = "cmdOK";
			this.txtUserName.AutoSize = false;
			this.txtUserName.Enabled = false;
			this.txtUserName.Size = new System.Drawing.Size(149, 16);
			this.txtUserName.Location = new System.Drawing.Point(98, 354);
			this.txtUserName.TabIndex = 1;
			this.txtUserName.Text = "default";
			this.txtUserName.AcceptsReturn = true;
			this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtUserName.BackColor = System.Drawing.SystemColors.Window;
			this.txtUserName.CausesValidation = true;
			this.txtUserName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtUserName.HideSelection = true;
			this.txtUserName.ReadOnly = false;
			this.txtUserName.MaxLength = 0;
			this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtUserName.Multiline = false;
			this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtUserName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtUserName.TabStop = true;
			this.txtUserName.Visible = true;
			this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtUserName.Name = "txtUserName";
			//MAPISession1.OcxState = CType(resources.GetObject("MAPISession1.OcxState"), System.Windows.Forms.AxHost.State)
			//Me.MAPISession1.Location = New System.Drawing.Point(606, 381)
			//Me.MAPISession1.Name = "MAPISession1"
			//MAPIMessages1.OcxState = CType(resources.GetObject("MAPIMessages1.OcxState"), System.Windows.Forms.AxHost.State)
			//Me.MAPIMessages1.Location = New System.Drawing.Point(603, 447)
			//Me.MAPIMessages1.Name = "MAPIMessages1"
			this.tmrStart.Interval = 1;
			this.tmrStart.Enabled = true;
			this.cmdBuild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBuild.Text = "Synchronize Via Email";
			this.cmdBuild.Enabled = false;
			this.cmdBuild.Size = new System.Drawing.Size(223, 46);
			this.cmdBuild.Location = new System.Drawing.Point(24, 447);
			this.cmdBuild.TabIndex = 7;
			this.cmdBuild.TabStop = false;
			this.cmdBuild.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBuild.CausesValidation = true;
			this.cmdBuild.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBuild.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBuild.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBuild.Name = "cmdBuild";
			this.lvLocation.Size = new System.Drawing.Size(592, 265);
			this.lvLocation.Location = new System.Drawing.Point(9, 9);
			this.lvLocation.TabIndex = 6;
			this.lvLocation.TabStop = 0;
			this.lvLocation.View = System.Windows.Forms.View.Details;
			this.lvLocation.LabelEdit = false;
			this.lvLocation.LabelWrap = true;
			this.lvLocation.HideSelection = true;
			this.lvLocation.SmallImageList = ILtree;
			this.lvLocation.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lvLocation.BackColor = System.Drawing.SystemColors.Window;
			this.lvLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lvLocation.Name = "lvLocation";
			this._lvLocation_ColumnHeader_1.Text = "Company";
			this._lvLocation_ColumnHeader_1.Width = 236;
			this._lvLocation_ColumnHeader_2.Text = "Location";
			this._lvLocation_ColumnHeader_2.Width = 236;
			this._lvLocation_ColumnHeader_3.Text = "Path";
			this._lvLocation_ColumnHeader_3.Width = 530;
			this.ILtree.ImageSize = new System.Drawing.Size(16, 16);
			this.ILtree.TransparentColor = System.Drawing.Color.White;
			this.ILtree.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ILtree.ImageStream");
			this.ILtree.Images.SetKeyName(0, "cm");
			this.ILtree.Images.SetKeyName(1, "");
			this._Label1_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._Label1_4.Text = "Directory:";
			this._Label1_4.Enabled = false;
			this._Label1_4.Size = new System.Drawing.Size(45, 13);
			this._Label1_4.Location = new System.Drawing.Point(48, 330);
			this._Label1_4.TabIndex = 13;
			this._Label1_4.BackColor = System.Drawing.Color.Transparent;
			this._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_4.UseMnemonic = true;
			this._Label1_4.Visible = true;
			this._Label1_4.AutoSize = true;
			this._Label1_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_4.Name = "_Label1_4";
			this._Label1_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._Label1_3.Text = "Database:";
			this._Label1_3.Enabled = false;
			this._Label1_3.Size = new System.Drawing.Size(49, 13);
			this._Label1_3.Location = new System.Drawing.Point(44, 309);
			this._Label1_3.TabIndex = 12;
			this._Label1_3.BackColor = System.Drawing.Color.Transparent;
			this._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_3.UseMnemonic = true;
			this._Label1_3.Visible = true;
			this._Label1_3.AutoSize = true;
			this._Label1_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_3.Name = "_Label1_3";
			this._Label1_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._Label1_2.Text = "Company:";
			this._Label1_2.Enabled = false;
			this._Label1_2.Size = new System.Drawing.Size(47, 13);
			this._Label1_2.Location = new System.Drawing.Point(46, 288);
			this._Label1_2.TabIndex = 11;
			this._Label1_2.BackColor = System.Drawing.Color.Transparent;
			this._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_2.UseMnemonic = true;
			this._Label1_2.Visible = true;
			this._Label1_2.AutoSize = true;
			this._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_2.Name = "_Label1_2";
			this._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._Label1_0.Text = "User ID:";
			this._Label1_0.Enabled = false;
			this._Label1_0.Size = new System.Drawing.Size(39, 13);
			this._Label1_0.Location = new System.Drawing.Point(54, 357);
			this._Label1_0.TabIndex = 0;
			this._Label1_0.BackColor = System.Drawing.Color.Transparent;
			this._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_0.UseMnemonic = true;
			this._Label1_0.Visible = true;
			this._Label1_0.AutoSize = true;
			this._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_0.Name = "_Label1_0";
			this._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._Label1_1.Text = "Password:";
			this._Label1_1.Enabled = false;
			this._Label1_1.Size = new System.Drawing.Size(49, 13);
			this._Label1_1.Location = new System.Drawing.Point(44, 381);
			this._Label1_1.TabIndex = 2;
			this._Label1_1.BackColor = System.Drawing.Color.Transparent;
			this._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_1.UseMnemonic = true;
			this._Label1_1.Visible = true;
			this._Label1_1.AutoSize = true;
			this._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_1.Name = "_Label1_1";
			this.lblDir.Text = "...";
			this.lblDir.Size = new System.Drawing.Size(9, 16);
			this.lblDir.Location = new System.Drawing.Point(96, 327);
			this.lblDir.TabIndex = 10;
			this.lblDir.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblDir.BackColor = System.Drawing.Color.Transparent;
			this.lblDir.Enabled = true;
			this.lblDir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDir.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDir.UseMnemonic = true;
			this.lblDir.Visible = true;
			this.lblDir.AutoSize = true;
			this.lblDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblDir.Name = "lblDir";
			this.lblPath.Text = "...";
			this.lblPath.Size = new System.Drawing.Size(9, 16);
			this.lblPath.Location = new System.Drawing.Point(96, 306);
			this.lblPath.TabIndex = 9;
			this.lblPath.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblPath.BackColor = System.Drawing.Color.Transparent;
			this.lblPath.Enabled = true;
			this.lblPath.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblPath.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblPath.UseMnemonic = true;
			this.lblPath.Visible = true;
			this.lblPath.AutoSize = true;
			this.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblPath.Name = "lblPath";
			this.lblCompany.Text = "...";
			this.lblCompany.Size = new System.Drawing.Size(9, 16);
			this.lblCompany.Location = new System.Drawing.Point(96, 285);
			this.lblCompany.TabIndex = 8;
			this.lblCompany.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblCompany.BackColor = System.Drawing.Color.Transparent;
			this.lblCompany.Enabled = true;
			this.lblCompany.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblCompany.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblCompany.UseMnemonic = true;
			this.lblCompany.Visible = true;
			this.lblCompany.AutoSize = true;
			this.lblCompany.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblCompany.Name = "lblCompany";
			this.Controls.Add(cmdDatabase);
			this.Controls.Add(cmdCompany);
			this.Controls.Add(frmRegister);
			this.Controls.Add(txtPassword);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdOK);
			this.Controls.Add(txtUserName);
			//Me.Controls.Add(MAPISession1)
			//Me.Controls.Add(MAPIMessages1)
			this.Controls.Add(cmdBuild);
			this.Controls.Add(lvLocation);
			this.Controls.Add(_Label1_4);
			this.Controls.Add(_Label1_3);
			this.Controls.Add(_Label1_2);
			this.Controls.Add(_Label1_0);
			this.Controls.Add(_Label1_1);
			this.Controls.Add(lblDir);
			this.Controls.Add(lblPath);
			this.Controls.Add(lblCompany);
			this.frmRegister.Controls.Add(txtKey);
			this.frmRegister.Controls.Add(cmdRegistration);
			this.frmRegister.Controls.Add(txtCompany);
			this.frmRegister.Controls.Add(_Label2_1);
			this.frmRegister.Controls.Add(_Label2_0);
			this.frmRegister.Controls.Add(lblCode);
			this.frmRegister.Controls.Add(_lbl_0);
			this.lvLocation.Columns.Add(_lvLocation_ColumnHeader_1);
			this.lvLocation.Columns.Add(_lvLocation_ColumnHeader_2);
			this.lvLocation.Columns.Add(_lvLocation_ColumnHeader_3);
			//Me.Label1.SetIndex(_Label1_4, CType(4, Short))
			//Me.Label1.SetIndex(_Label1_3, CType(3, Short))
			//Me.Label1.SetIndex(_Label1_2, CType(2, Short))
			//Me.Label1.SetIndex(_Label1_0, CType(0, Short))
			//Me.Label1.SetIndex(_Label1_1, CType(1, Short))
			//Me.Label2.SetIndex(_Label2_1, CType(1, Short))
			//Me.Label2.SetIndex(_Label2_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.MAPIMessages1, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.MAPISession1, System.ComponentModel.ISupportInitialize).EndInit()
			this.frmRegister.ResumeLayout(false);
			this.lvLocation.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
