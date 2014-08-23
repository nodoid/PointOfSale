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
	partial class frmPerson
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmPerson() : base()
		{
			FormClosed += frmPerson_FormClosed;
			KeyPress += frmPerson_KeyPress;
			Resize += frmPerson_Resize;
			Load += frmPerson_Load;
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
		public System.Windows.Forms.CheckBox chkController;
		private System.Windows.Forms.TextBox withEventsField_txtComm;
		public System.Windows.Forms.TextBox txtComm {
			get { return withEventsField_txtComm; }
			set {
				if (withEventsField_txtComm != null) {
					withEventsField_txtComm.Enter -= txtComm_Enter;
					withEventsField_txtComm.KeyPress -= txtComm_KeyPress;
					withEventsField_txtComm.Leave -= txtComm_Leave;
				}
				withEventsField_txtComm = value;
				if (withEventsField_txtComm != null) {
					withEventsField_txtComm.Enter += txtComm_Enter;
					withEventsField_txtComm.KeyPress += txtComm_KeyPress;
					withEventsField_txtComm.Leave += txtComm_Leave;
				}
			}
		}
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.GroupBox Frame1;
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
		public System.Windows.Forms.CheckBox _chkFields_2;
		public System.Windows.Forms.ComboBox cmbDraw;
		public System.Windows.Forms.TextBox _txtFields_12;
		public System.Windows.Forms.Label _lblLabels_0;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label _lblLabels_12;
		public System.Windows.Forms.GroupBox _frmSecurity_1;
		public System.Windows.Forms.TextBox _txtFields_11;
		public System.Windows.Forms.TextBox _txtFields_10;
		public System.Windows.Forms.Label _lblLabels_11;
		public System.Windows.Forms.Label _lblLabels_10;
		public System.Windows.Forms.GroupBox _frmSecurity_0;
		public System.Windows.Forms.TextBox _txtFields_1;
		public System.Windows.Forms.TextBox _txtFields_2;
		public System.Windows.Forms.TextBox _txtFields_4;
		public System.Windows.Forms.TextBox _txtFields_5;
		public System.Windows.Forms.TextBox _txtFields_7;
		public System.Windows.Forms.TextBox _txtFields_8;
		public System.Windows.Forms.TextBox _txtFields_13;
		private System.Windows.Forms.Button withEventsField_cmdFPR;
		public System.Windows.Forms.Button cmdFPR {
			get { return withEventsField_cmdFPR; }
			set {
				if (withEventsField_cmdFPR != null) {
					withEventsField_cmdFPR.Click -= cmdFPR_Click;
				}
				withEventsField_cmdFPR = value;
				if (withEventsField_cmdFPR != null) {
					withEventsField_cmdFPR.Click += cmdFPR_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdPOSsecurity;
		public System.Windows.Forms.Button cmdPOSsecurity {
			get { return withEventsField_cmdPOSsecurity; }
			set {
				if (withEventsField_cmdPOSsecurity != null) {
					withEventsField_cmdPOSsecurity.Click -= cmdPOSsecurity_Click;
				}
				withEventsField_cmdPOSsecurity = value;
				if (withEventsField_cmdPOSsecurity != null) {
					withEventsField_cmdPOSsecurity.Click += cmdPOSsecurity_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdBOsecurity;
		public System.Windows.Forms.Button cmdBOsecurity {
			get { return withEventsField_cmdBOsecurity; }
			set {
				if (withEventsField_cmdBOsecurity != null) {
					withEventsField_cmdBOsecurity.Click -= cmdBOsecurity_Click;
				}
				withEventsField_cmdBOsecurity = value;
				if (withEventsField_cmdBOsecurity != null) {
					withEventsField_cmdBOsecurity.Click += cmdBOsecurity_Click;
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
		public System.Windows.Forms.Label _lbl_1;
		public Microsoft.VisualBasic.PowerPacks.LineShape Line1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_0;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label _lblLabels_2;
		public System.Windows.Forms.Label _lblLabels_4;
		public System.Windows.Forms.Label _lblLabels_5;
		public System.Windows.Forms.Label _lblLabels_7;
		public System.Windows.Forms.Label _lblLabels_8;
		public System.Windows.Forms.Label _lblLabels_13;
		public System.Windows.Forms.Label _lbl_5;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		//Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
		//Public WithEvents frmSecurity As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPerson));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.chkController = new System.Windows.Forms.CheckBox();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.txtComm = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.cmdBuild = new System.Windows.Forms.Button();
			this._chkFields_2 = new System.Windows.Forms.CheckBox();
			this._frmSecurity_1 = new System.Windows.Forms.GroupBox();
			this.cmbDraw = new System.Windows.Forms.ComboBox();
			this._txtFields_12 = new System.Windows.Forms.TextBox();
			this._lblLabels_0 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this._lblLabels_12 = new System.Windows.Forms.Label();
			this._frmSecurity_0 = new System.Windows.Forms.GroupBox();
			this._txtFields_11 = new System.Windows.Forms.TextBox();
			this._txtFields_10 = new System.Windows.Forms.TextBox();
			this._lblLabels_11 = new System.Windows.Forms.Label();
			this._lblLabels_10 = new System.Windows.Forms.Label();
			this._txtFields_1 = new System.Windows.Forms.TextBox();
			this._txtFields_2 = new System.Windows.Forms.TextBox();
			this._txtFields_4 = new System.Windows.Forms.TextBox();
			this._txtFields_5 = new System.Windows.Forms.TextBox();
			this._txtFields_7 = new System.Windows.Forms.TextBox();
			this._txtFields_8 = new System.Windows.Forms.TextBox();
			this._txtFields_13 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdFPR = new System.Windows.Forms.Button();
			this.cmdPOSsecurity = new System.Windows.Forms.Button();
			this.cmdBOsecurity = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this._lbl_1 = new System.Windows.Forms.Label();
			this.Line1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._lblLabels_2 = new System.Windows.Forms.Label();
			this._lblLabels_4 = new System.Windows.Forms.Label();
			this._lblLabels_5 = new System.Windows.Forms.Label();
			this._lblLabels_7 = new System.Windows.Forms.Label();
			this._lblLabels_8 = new System.Windows.Forms.Label();
			this._lblLabels_13 = new System.Windows.Forms.Label();
			this._lbl_5 = new System.Windows.Forms.Label();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.chkFields = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
			//Me.frmSecurity = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.Frame1.SuspendLayout();
			this._frmSecurity_1.SuspendLayout();
			this._frmSecurity_0.SuspendLayout();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.chkFields, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.frmSecurity, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Edit Employee Details";
			this.ClientSize = new System.Drawing.Size(486, 348);
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
			this.Name = "frmPerson";
			this.chkController.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkController.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkController.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.chkController.Text = "Permit this person to terminate controller";
			this.chkController.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkController.Size = new System.Drawing.Size(229, 21);
			this.chkController.Location = new System.Drawing.Point(226, 286);
			this.chkController.TabIndex = 34;
			this.chkController.CausesValidation = true;
			this.chkController.Enabled = true;
			this.chkController.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkController.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkController.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkController.TabStop = true;
			this.chkController.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkController.Visible = true;
			this.chkController.Name = "chkController";
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.Frame1.Text = "Commission %";
			this.Frame1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Frame1.Size = new System.Drawing.Size(189, 39);
			this.Frame1.Location = new System.Drawing.Point(22, 242);
			this.Frame1.TabIndex = 31;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.txtComm.AutoSize = false;
			this.txtComm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtComm.Size = new System.Drawing.Size(61, 17);
			this.txtComm.Location = new System.Drawing.Point(116, 14);
			this.txtComm.TabIndex = 33;
			this.txtComm.AcceptsReturn = true;
			this.txtComm.BackColor = System.Drawing.SystemColors.Window;
			this.txtComm.CausesValidation = true;
			this.txtComm.Enabled = true;
			this.txtComm.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComm.HideSelection = true;
			this.txtComm.ReadOnly = false;
			this.txtComm.MaxLength = 0;
			this.txtComm.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComm.Multiline = false;
			this.txtComm.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComm.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtComm.TabStop = true;
			this.txtComm.Visible = true;
			this.txtComm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComm.Name = "txtComm";
			this.Label2.Text = "Value";
			this.Label2.Size = new System.Drawing.Size(71, 17);
			this.Label2.Location = new System.Drawing.Point(10, 16);
			this.Label2.TabIndex = 32;
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Enabled = true;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.cmdBuild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBuild.Text = "Build...";
			this.cmdBuild.Size = new System.Drawing.Size(46, 16);
			this.cmdBuild.Location = new System.Drawing.Point(402, 213);
			this.cmdBuild.TabIndex = 27;
			this.cmdBuild.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBuild.CausesValidation = true;
			this.cmdBuild.Enabled = true;
			this.cmdBuild.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBuild.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBuild.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBuild.TabStop = true;
			this.cmdBuild.Name = "cmdBuild";
			this._chkFields_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_2.Text = "Disable this person from using the application suite:";
			this._chkFields_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_2.Size = new System.Drawing.Size(262, 19);
			this._chkFields_2.Location = new System.Drawing.Point(194, 308);
			this._chkFields_2.TabIndex = 29;
			this._chkFields_2.CausesValidation = true;
			this._chkFields_2.Enabled = true;
			this._chkFields_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_2.TabStop = true;
			this._chkFields_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_2.Visible = true;
			this._chkFields_2.Name = "_chkFields_2";
			this._frmSecurity_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._frmSecurity_1.Text = "Point Of Sale Logon";
			this._frmSecurity_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmSecurity_1.Size = new System.Drawing.Size(220, 108);
			this._frmSecurity_1.Location = new System.Drawing.Point(237, 171);
			this._frmSecurity_1.TabIndex = 24;
			this._frmSecurity_1.Enabled = true;
			this._frmSecurity_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmSecurity_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmSecurity_1.Visible = true;
			this._frmSecurity_1.Padding = new System.Windows.Forms.Padding(0);
			this._frmSecurity_1.Name = "_frmSecurity_1";
			this.cmbDraw.BackColor = System.Drawing.Color.White;
			this.cmbDraw.Size = new System.Drawing.Size(105, 21);
			this.cmbDraw.Location = new System.Drawing.Point(104, 80);
			this.cmbDraw.Items.AddRange(new object[] {
				"Till / Drawer # 1",
				"Till / Drawer # 2"
			});
			this.cmbDraw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDraw.TabIndex = 37;
			this.cmbDraw.CausesValidation = true;
			this.cmbDraw.Enabled = true;
			this.cmbDraw.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbDraw.IntegralHeight = true;
			this.cmbDraw.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbDraw.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbDraw.Sorted = false;
			this.cmbDraw.TabStop = true;
			this.cmbDraw.Visible = true;
			this.cmbDraw.Name = "cmbDraw";
			this._txtFields_12.AutoSize = false;
			this._txtFields_12.Size = new System.Drawing.Size(114, 19);
			this._txtFields_12.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this._txtFields_12.Location = new System.Drawing.Point(96, 18);
			this._txtFields_12.PasswordChar = Strings.ChrW(35);
			this._txtFields_12.TabIndex = 26;
			this._txtFields_12.AcceptsReturn = true;
			this._txtFields_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_12.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_12.CausesValidation = true;
			this._txtFields_12.Enabled = true;
			this._txtFields_12.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_12.HideSelection = true;
			this._txtFields_12.ReadOnly = false;
			this._txtFields_12.MaxLength = 0;
			this._txtFields_12.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_12.Multiline = false;
			this._txtFields_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_12.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_12.TabStop = true;
			this._txtFields_12.Visible = true;
			this._txtFields_12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_12.Name = "_txtFields_12";
			this._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_0.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_0.Text = "Default Till/Drawer:";
			this._lblLabels_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_0.Size = new System.Drawing.Size(92, 13);
			this._lblLabels_0.Location = new System.Drawing.Point(8, 88);
			this._lblLabels_0.TabIndex = 36;
			this._lblLabels_0.Enabled = true;
			this._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_0.UseMnemonic = true;
			this._lblLabels_0.Visible = true;
			this._lblLabels_0.AutoSize = true;
			this._lblLabels_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_0.Name = "_lblLabels_0";
			this.Label1.Text = "This is a barcode used for log-in for the Point Of Sale device.";
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label1.Size = new System.Drawing.Size(148, 43);
			this.Label1.Location = new System.Drawing.Point(9, 39);
			this.Label1.TabIndex = 28;
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = false;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this._lblLabels_12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_12.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_12.Text = "Access Scan ID:";
			this._lblLabels_12.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_12.Size = new System.Drawing.Size(80, 13);
			this._lblLabels_12.Location = new System.Drawing.Point(9, 18);
			this._lblLabels_12.TabIndex = 25;
			this._lblLabels_12.Enabled = true;
			this._lblLabels_12.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_12.UseMnemonic = true;
			this._lblLabels_12.Visible = true;
			this._lblLabels_12.AutoSize = true;
			this._lblLabels_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_12.Name = "_lblLabels_12";
			this._frmSecurity_0.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._frmSecurity_0.Text = "Back Office Logon";
			this._frmSecurity_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmSecurity_0.Size = new System.Drawing.Size(190, 66);
			this._frmSecurity_0.Location = new System.Drawing.Point(21, 171);
			this._frmSecurity_0.TabIndex = 19;
			this._frmSecurity_0.Enabled = true;
			this._frmSecurity_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmSecurity_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmSecurity_0.Visible = true;
			this._frmSecurity_0.Padding = new System.Windows.Forms.Padding(0);
			this._frmSecurity_0.Name = "_frmSecurity_0";
			this._txtFields_11.AutoSize = false;
			this._txtFields_11.Size = new System.Drawing.Size(114, 19);
			this._txtFields_11.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this._txtFields_11.Location = new System.Drawing.Point(65, 40);
			this._txtFields_11.PasswordChar = Strings.ChrW(35);
			this._txtFields_11.TabIndex = 23;
			this._txtFields_11.AcceptsReturn = true;
			this._txtFields_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_11.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_11.CausesValidation = true;
			this._txtFields_11.Enabled = true;
			this._txtFields_11.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_11.HideSelection = true;
			this._txtFields_11.ReadOnly = false;
			this._txtFields_11.MaxLength = 0;
			this._txtFields_11.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_11.Multiline = false;
			this._txtFields_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_11.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_11.TabStop = true;
			this._txtFields_11.Visible = true;
			this._txtFields_11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_11.Name = "_txtFields_11";
			this._txtFields_10.AutoSize = false;
			this._txtFields_10.Size = new System.Drawing.Size(114, 19);
			this._txtFields_10.Location = new System.Drawing.Point(65, 18);
			this._txtFields_10.TabIndex = 21;
			this._txtFields_10.AcceptsReturn = true;
			this._txtFields_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_10.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_10.CausesValidation = true;
			this._txtFields_10.Enabled = true;
			this._txtFields_10.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_10.HideSelection = true;
			this._txtFields_10.ReadOnly = false;
			this._txtFields_10.MaxLength = 0;
			this._txtFields_10.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_10.Multiline = false;
			this._txtFields_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_10.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_10.TabStop = true;
			this._txtFields_10.Visible = true;
			this._txtFields_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_10.Name = "_txtFields_10";
			this._lblLabels_11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_11.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_11.Text = "Password:";
			this._lblLabels_11.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_11.Size = new System.Drawing.Size(49, 13);
			this._lblLabels_11.Location = new System.Drawing.Point(9, 40);
			this._lblLabels_11.TabIndex = 22;
			this._lblLabels_11.Enabled = true;
			this._lblLabels_11.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_11.UseMnemonic = true;
			this._lblLabels_11.Visible = true;
			this._lblLabels_11.AutoSize = true;
			this._lblLabels_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_11.Name = "_lblLabels_11";
			this._lblLabels_10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_10.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_10.Text = "User ID:";
			this._lblLabels_10.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_10.Size = new System.Drawing.Size(39, 13);
			this._lblLabels_10.Location = new System.Drawing.Point(19, 18);
			this._lblLabels_10.TabIndex = 20;
			this._lblLabels_10.Enabled = true;
			this._lblLabels_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_10.UseMnemonic = true;
			this._lblLabels_10.Visible = true;
			this._lblLabels_10.AutoSize = true;
			this._lblLabels_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_10.Name = "_lblLabels_10";
			this._txtFields_1.AutoSize = false;
			this._txtFields_1.Size = new System.Drawing.Size(31, 19);
			this._txtFields_1.Location = new System.Drawing.Point(87, 66);
			this._txtFields_1.TabIndex = 6;
			this._txtFields_1.Text = "Miss";
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
			this._txtFields_2.AutoSize = false;
			this._txtFields_2.Size = new System.Drawing.Size(118, 19);
			this._txtFields_2.Location = new System.Drawing.Point(120, 66);
			this._txtFields_2.TabIndex = 7;
			this._txtFields_2.AcceptsReturn = true;
			this._txtFields_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_2.CausesValidation = true;
			this._txtFields_2.Enabled = true;
			this._txtFields_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_2.HideSelection = true;
			this._txtFields_2.ReadOnly = false;
			this._txtFields_2.MaxLength = 0;
			this._txtFields_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_2.Multiline = false;
			this._txtFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_2.TabStop = true;
			this._txtFields_2.Visible = true;
			this._txtFields_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_2.Name = "_txtFields_2";
			this._txtFields_4.AutoSize = false;
			this._txtFields_4.Size = new System.Drawing.Size(151, 19);
			this._txtFields_4.Location = new System.Drawing.Point(87, 87);
			this._txtFields_4.TabIndex = 9;
			this._txtFields_4.AcceptsReturn = true;
			this._txtFields_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_4.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_4.CausesValidation = true;
			this._txtFields_4.Enabled = true;
			this._txtFields_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_4.HideSelection = true;
			this._txtFields_4.ReadOnly = false;
			this._txtFields_4.MaxLength = 0;
			this._txtFields_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_4.Multiline = false;
			this._txtFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_4.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_4.TabStop = true;
			this._txtFields_4.Visible = true;
			this._txtFields_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_4.Name = "_txtFields_4";
			this._txtFields_5.AutoSize = false;
			this._txtFields_5.Size = new System.Drawing.Size(151, 19);
			this._txtFields_5.Location = new System.Drawing.Point(318, 66);
			this._txtFields_5.TabIndex = 11;
			this._txtFields_5.AcceptsReturn = true;
			this._txtFields_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_5.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_5.CausesValidation = true;
			this._txtFields_5.Enabled = true;
			this._txtFields_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_5.HideSelection = true;
			this._txtFields_5.ReadOnly = false;
			this._txtFields_5.MaxLength = 0;
			this._txtFields_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_5.Multiline = false;
			this._txtFields_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_5.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_5.TabStop = true;
			this._txtFields_5.Visible = true;
			this._txtFields_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_5.Name = "_txtFields_5";
			this._txtFields_7.AutoSize = false;
			this._txtFields_7.Size = new System.Drawing.Size(151, 19);
			this._txtFields_7.Location = new System.Drawing.Point(87, 120);
			this._txtFields_7.TabIndex = 15;
			this._txtFields_7.AcceptsReturn = true;
			this._txtFields_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_7.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_7.CausesValidation = true;
			this._txtFields_7.Enabled = true;
			this._txtFields_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_7.HideSelection = true;
			this._txtFields_7.ReadOnly = false;
			this._txtFields_7.MaxLength = 0;
			this._txtFields_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_7.Multiline = false;
			this._txtFields_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_7.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_7.TabStop = true;
			this._txtFields_7.Visible = true;
			this._txtFields_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_7.Name = "_txtFields_7";
			this._txtFields_8.AutoSize = false;
			this._txtFields_8.Size = new System.Drawing.Size(151, 19);
			this._txtFields_8.Location = new System.Drawing.Point(318, 120);
			this._txtFields_8.TabIndex = 17;
			this._txtFields_8.AcceptsReturn = true;
			this._txtFields_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_8.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_8.CausesValidation = true;
			this._txtFields_8.Enabled = true;
			this._txtFields_8.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_8.HideSelection = true;
			this._txtFields_8.ReadOnly = false;
			this._txtFields_8.MaxLength = 0;
			this._txtFields_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_8.Multiline = false;
			this._txtFields_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_8.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_8.TabStop = true;
			this._txtFields_8.Visible = true;
			this._txtFields_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_8.Name = "_txtFields_8";
			this._txtFields_13.AutoSize = false;
			this._txtFields_13.Size = new System.Drawing.Size(151, 19);
			this._txtFields_13.Location = new System.Drawing.Point(318, 87);
			this._txtFields_13.TabIndex = 13;
			this._txtFields_13.AcceptsReturn = true;
			this._txtFields_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_13.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_13.CausesValidation = true;
			this._txtFields_13.Enabled = true;
			this._txtFields_13.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_13.HideSelection = true;
			this._txtFields_13.ReadOnly = false;
			this._txtFields_13.MaxLength = 0;
			this._txtFields_13.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_13.Multiline = false;
			this._txtFields_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_13.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_13.TabStop = true;
			this._txtFields_13.Visible = true;
			this._txtFields_13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_13.Name = "_txtFields_13";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(486, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 0;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdFPR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdFPR.Text = "&Finger Print Registration";
			this.cmdFPR.Size = new System.Drawing.Size(73, 29);
			this.cmdFPR.Location = new System.Drawing.Point(304, 3);
			this.cmdFPR.TabIndex = 35;
			this.cmdFPR.TabStop = false;
			this.cmdFPR.BackColor = System.Drawing.SystemColors.Control;
			this.cmdFPR.CausesValidation = true;
			this.cmdFPR.Enabled = true;
			this.cmdFPR.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdFPR.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdFPR.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdFPR.Name = "cmdFPR";
			this.cmdPOSsecurity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPOSsecurity.Text = "&Point Of Sale Permissions";
			this.cmdPOSsecurity.Size = new System.Drawing.Size(73, 29);
			this.cmdPOSsecurity.Location = new System.Drawing.Point(207, 3);
			this.cmdPOSsecurity.TabIndex = 2;
			this.cmdPOSsecurity.TabStop = false;
			this.cmdPOSsecurity.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPOSsecurity.CausesValidation = true;
			this.cmdPOSsecurity.Enabled = true;
			this.cmdPOSsecurity.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPOSsecurity.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPOSsecurity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPOSsecurity.Name = "cmdPOSsecurity";
			this.cmdBOsecurity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBOsecurity.Text = "&Back Office Permissions";
			this.cmdBOsecurity.Size = new System.Drawing.Size(73, 29);
			this.cmdBOsecurity.Location = new System.Drawing.Point(104, 3);
			this.cmdBOsecurity.TabIndex = 30;
			this.cmdBOsecurity.TabStop = false;
			this.cmdBOsecurity.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBOsecurity.CausesValidation = true;
			this.cmdBOsecurity.Enabled = true;
			this.cmdBOsecurity.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBOsecurity.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBOsecurity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBOsecurity.Name = "cmdBOsecurity";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.Location = new System.Drawing.Point(5, 3);
			this.cmdCancel.TabIndex = 3;
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
			this.cmdClose.Location = new System.Drawing.Point(405, 3);
			this.cmdClose.TabIndex = 1;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Text = "Employee No. ";
			this._lbl_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_1.Size = new System.Drawing.Size(77, 14);
			this._lbl_1.Location = new System.Drawing.Point(400, 44);
			this._lbl_1.TabIndex = 38;
			this._lbl_1.Enabled = true;
			this._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.UseMnemonic = true;
			this._lbl_1.Visible = true;
			this._lbl_1.AutoSize = true;
			this._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_1.Name = "_lbl_1";
			this.Line1.X1 = 16;
			this.Line1.X2 = 468;
			this.Line1.Y1 = 110;
			this.Line1.Y2 = 110;
			this.Line1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Line1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.Line1.BorderWidth = 1;
			this.Line1.Visible = true;
			this.Line1.Name = "Line1";
			this._Shape1_0.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_0.Size = new System.Drawing.Size(472, 171);
			this._Shape1_0.Location = new System.Drawing.Point(6, 166);
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_0.BorderWidth = 1;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_0.Visible = true;
			this._Shape1_0.Name = "_Shape1_0";
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Text = "&2. Security";
			this._lbl_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_0.Size = new System.Drawing.Size(64, 13);
			this._lbl_0.Location = new System.Drawing.Point(8, 150);
			this._lbl_0.TabIndex = 18;
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
			this._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_2.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_2.Text = "First Name:";
			this._lblLabels_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_2.Size = new System.Drawing.Size(55, 13);
			this._lblLabels_2.Location = new System.Drawing.Point(27, 66);
			this._lblLabels_2.TabIndex = 5;
			this._lblLabels_2.Enabled = true;
			this._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_2.UseMnemonic = true;
			this._lblLabels_2.Visible = true;
			this._lblLabels_2.AutoSize = true;
			this._lblLabels_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_2.Name = "_lblLabels_2";
			this._lblLabels_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_4.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_4.Text = "Surname:";
			this._lblLabels_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_4.Size = new System.Drawing.Size(46, 13);
			this._lblLabels_4.Location = new System.Drawing.Point(33, 87);
			this._lblLabels_4.TabIndex = 8;
			this._lblLabels_4.Enabled = true;
			this._lblLabels_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_4.UseMnemonic = true;
			this._lblLabels_4.Visible = true;
			this._lblLabels_4.AutoSize = true;
			this._lblLabels_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_4.Name = "_lblLabels_4";
			this._lblLabels_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_5.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_5.Text = "Position:";
			this._lblLabels_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_5.Size = new System.Drawing.Size(40, 13);
			this._lblLabels_5.Location = new System.Drawing.Point(258, 66);
			this._lblLabels_5.TabIndex = 10;
			this._lblLabels_5.Enabled = true;
			this._lblLabels_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_5.UseMnemonic = true;
			this._lblLabels_5.Visible = true;
			this._lblLabels_5.AutoSize = true;
			this._lblLabels_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_5.Name = "_lblLabels_5";
			this._lblLabels_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_7.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_7.Text = "Cell:";
			this._lblLabels_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_7.Size = new System.Drawing.Size(22, 13);
			this._lblLabels_7.Location = new System.Drawing.Point(60, 120);
			this._lblLabels_7.TabIndex = 14;
			this._lblLabels_7.Enabled = true;
			this._lblLabels_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_7.UseMnemonic = true;
			this._lblLabels_7.Visible = true;
			this._lblLabels_7.AutoSize = true;
			this._lblLabels_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_7.Name = "_lblLabels_7";
			this._lblLabels_8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_8.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_8.Text = "Telephone:";
			this._lblLabels_8.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_8.Size = new System.Drawing.Size(55, 13);
			this._lblLabels_8.Location = new System.Drawing.Point(243, 120);
			this._lblLabels_8.TabIndex = 16;
			this._lblLabels_8.Enabled = true;
			this._lblLabels_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_8.UseMnemonic = true;
			this._lblLabels_8.Visible = true;
			this._lblLabels_8.AutoSize = true;
			this._lblLabels_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_8.Name = "_lblLabels_8";
			this._lblLabels_13.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_13.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_13.Text = "ID Number:";
			this._lblLabels_13.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_13.Size = new System.Drawing.Size(55, 13);
			this._lblLabels_13.Location = new System.Drawing.Point(243, 87);
			this._lblLabels_13.TabIndex = 12;
			this._lblLabels_13.Enabled = true;
			this._lblLabels_13.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_13.UseMnemonic = true;
			this._lblLabels_13.Visible = true;
			this._lblLabels_13.AutoSize = true;
			this._lblLabels_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_13.Name = "_lblLabels_13";
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Text = "&1. General";
			this._lbl_5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_5.Size = new System.Drawing.Size(61, 13);
			this._lbl_5.Location = new System.Drawing.Point(8, 44);
			this._lbl_5.TabIndex = 4;
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
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(472, 85);
			this._Shape1_2.Location = new System.Drawing.Point(6, 60);
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_2.BorderWidth = 1;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_2.Visible = true;
			this._Shape1_2.Name = "_Shape1_2";
			this.Controls.Add(chkController);
			this.Controls.Add(Frame1);
			this.Controls.Add(cmdBuild);
			this.Controls.Add(_chkFields_2);
			this.Controls.Add(_frmSecurity_1);
			this.Controls.Add(_frmSecurity_0);
			this.Controls.Add(_txtFields_1);
			this.Controls.Add(_txtFields_2);
			this.Controls.Add(_txtFields_4);
			this.Controls.Add(_txtFields_5);
			this.Controls.Add(_txtFields_7);
			this.Controls.Add(_txtFields_8);
			this.Controls.Add(_txtFields_13);
			this.Controls.Add(picButtons);
			this.Controls.Add(_lbl_1);
			this.ShapeContainer1.Shapes.Add(Line1);
			this.ShapeContainer1.Shapes.Add(_Shape1_0);
			this.Controls.Add(_lbl_0);
			this.Controls.Add(_lblLabels_2);
			this.Controls.Add(_lblLabels_4);
			this.Controls.Add(_lblLabels_5);
			this.Controls.Add(_lblLabels_7);
			this.Controls.Add(_lblLabels_8);
			this.Controls.Add(_lblLabels_13);
			this.Controls.Add(_lbl_5);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.Controls.Add(ShapeContainer1);
			this.Frame1.Controls.Add(txtComm);
			this.Frame1.Controls.Add(Label2);
			this._frmSecurity_1.Controls.Add(cmbDraw);
			this._frmSecurity_1.Controls.Add(_txtFields_12);
			this._frmSecurity_1.Controls.Add(_lblLabels_0);
			this._frmSecurity_1.Controls.Add(Label1);
			this._frmSecurity_1.Controls.Add(_lblLabels_12);
			this._frmSecurity_0.Controls.Add(_txtFields_11);
			this._frmSecurity_0.Controls.Add(_txtFields_10);
			this._frmSecurity_0.Controls.Add(_lblLabels_11);
			this._frmSecurity_0.Controls.Add(_lblLabels_10);
			this.picButtons.Controls.Add(cmdFPR);
			this.picButtons.Controls.Add(cmdPOSsecurity);
			this.picButtons.Controls.Add(cmdBOsecurity);
			this.picButtons.Controls.Add(cmdCancel);
			this.picButtons.Controls.Add(cmdClose);
			//Me.chkFields.SetIndex(_chkFields_2, CType(2, Short))
			//Me.frmSecurity.SetIndex(_frmSecurity_1, CType(1, Short))
			//Me.frmSecurity.SetIndex(_frmSecurity_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			//Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
			//Me.lblLabels.SetIndex(_lblLabels_12, CType(12, Short))
			//Me.lblLabels.SetIndex(_lblLabels_11, CType(11, Short))
			//Me.lblLabels.SetIndex(_lblLabels_10, CType(10, Short))
			//Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
			//Me.lblLabels.SetIndex(_lblLabels_4, CType(4, Short))
			//M() ''e.lblLabels.SetIndex(_lblLabels_5, CType(5, Short))
			//M() 'e.lblLabels.SetIndex(_lblLabels_7, CType(7, Short))
			//M() 'e.lblLabels.SetIndex(_lblLabels_8, CType(8, Short))
			//Me.lblLabels.SetIndex(_lblLabels_13, CType(13, Short))
			//Me.txtFields.SetIndex(_txtFields_12, CType(12, Short))
			//Me.txtFields.SetIndex(_txtFields_11, CType(11, Short))
			//Me.txtFields.SetIndex(_txtFields_10, CType(10, Short))
			//Me.txtFields.SetIndex(_txtFields_1, CType(1, Short))
			//Me.txtFields.SetIndex(_txtFields_2, CType(2, Short))
			//Me.txtFields.SetIndex(_txtFields_4, CType(4, Short))
			//Me.txtFields.SetIndex(_txtFields_5, CType(5, Short))
			//Me.txtFields.SetIndex(_txtFields_7, CType(7, Short))
			//Me.txtFields.SetIndex(_txtFields_8, CType(8, Short))
			//Me.txtFields.SetIndex(_txtFields_13, CType(13, Short))
			this.Shape1.SetIndex(_Shape1_0, Convert.ToInt16(0));
			this.Shape1.SetIndex(_Shape1_2, Convert.ToInt16(2));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.frmSecurity, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.chkFields, System.ComponentModel.ISupportInitialize).EndInit()
			this.Frame1.ResumeLayout(false);
			this._frmSecurity_1.ResumeLayout(false);
			this._frmSecurity_0.ResumeLayout(false);
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
