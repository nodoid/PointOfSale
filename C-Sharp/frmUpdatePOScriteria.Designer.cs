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
	partial class frmUpdatePOScriteria
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmUpdatePOScriteria() : base()
		{
			FormClosed += frmUpdatePOScriteria_FormClosed;
			Load += frmUpdatePOScriteria_Load;
			KeyPress += frmUpdatePOScriteria_KeyPress;
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
		private System.Windows.Forms.Timer withEventsField_tmrDeposit;
		public System.Windows.Forms.Timer tmrDeposit {
			get { return withEventsField_tmrDeposit; }
			set {
				if (withEventsField_tmrDeposit != null) {
					withEventsField_tmrDeposit.Tick -= tmrDeposit_Tick;
				}
				withEventsField_tmrDeposit = value;
				if (withEventsField_tmrDeposit != null) {
					withEventsField_tmrDeposit.Tick += tmrDeposit_Tick;
				}
			}
		}
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
		private System.Windows.Forms.Button withEventsField_cmdBuildChanges;
		public System.Windows.Forms.Button cmdBuildChanges {
			get { return withEventsField_cmdBuildChanges; }
			set {
				if (withEventsField_cmdBuildChanges != null) {
					withEventsField_cmdBuildChanges.Click -= cmdBuildChanges_Click;
				}
				withEventsField_cmdBuildChanges = value;
				if (withEventsField_cmdBuildChanges != null) {
					withEventsField_cmdBuildChanges.Click += cmdBuildChanges_Click;
				}
			}
		}
		public System.Windows.Forms.Label _Label3_0;
		public System.Windows.Forms.Label _Label1_0;
		public System.Windows.Forms.GroupBox _frmType_0;
		private System.Windows.Forms.Timer withEventsField_tmrDuplicate;
		public System.Windows.Forms.Timer tmrDuplicate {
			get { return withEventsField_tmrDuplicate; }
			set {
				if (withEventsField_tmrDuplicate != null) {
					withEventsField_tmrDuplicate.Tick -= tmrDuplicate_Tick;
				}
				withEventsField_tmrDuplicate = value;
				if (withEventsField_tmrDuplicate != null) {
					withEventsField_tmrDuplicate.Tick += tmrDuplicate_Tick;
				}
			}
		}
		public System.Windows.Forms.Button _cmdType_2;
		public System.Windows.Forms.Button _cmdType_1;
		public System.Windows.Forms.Button _cmdType_0;
		private System.Windows.Forms.Button withEventsField_cmdBuildFilter;
		public System.Windows.Forms.Button cmdBuildFilter {
			get { return withEventsField_cmdBuildFilter; }
			set {
				if (withEventsField_cmdBuildFilter != null) {
					withEventsField_cmdBuildFilter.Click -= cmdBuildFilter_Click;
				}
				withEventsField_cmdBuildFilter = value;
				if (withEventsField_cmdBuildFilter != null) {
					withEventsField_cmdBuildFilter.Click += cmdBuildFilter_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdNamespace;
		public System.Windows.Forms.Button cmdNamespace {
			get { return withEventsField_cmdNamespace; }
			set {
				if (withEventsField_cmdNamespace != null) {
					withEventsField_cmdNamespace.Click -= cmdNamespace_Click;
				}
				withEventsField_cmdNamespace = value;
				if (withEventsField_cmdNamespace != null) {
					withEventsField_cmdNamespace.Click += cmdNamespace_Click;
				}
			}
		}
		public System.Windows.Forms.Label lblHeading;
		public System.Windows.Forms.GroupBox _frmType_1;
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
		private System.Windows.Forms.Button withEventsField_cmdBuildAll;
		public System.Windows.Forms.Button cmdBuildAll {
			get { return withEventsField_cmdBuildAll; }
			set {
				if (withEventsField_cmdBuildAll != null) {
					withEventsField_cmdBuildAll.Click -= cmdBuildAll_Click;
				}
				withEventsField_cmdBuildAll = value;
				if (withEventsField_cmdBuildAll != null) {
					withEventsField_cmdBuildAll.Click += cmdBuildAll_Click;
				}
			}
		}
		public System.Windows.Forms.Label _Label3_1;
		public System.Windows.Forms.Label _Label1_1;
		public System.Windows.Forms.GroupBox _frmType_2;
		public System.Windows.Forms.Label Label2;
		//Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents Label3 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents cmdType As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
		//Public WithEvents frmType As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmUpdatePOScriteria));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.tmrDeposit = new System.Windows.Forms.Timer(components);
			this.tmrMEndUpdatePOS = new System.Windows.Forms.Timer(components);
			this._frmType_0 = new System.Windows.Forms.GroupBox();
			this.cmdBuildChanges = new System.Windows.Forms.Button();
			this._Label3_0 = new System.Windows.Forms.Label();
			this._Label1_0 = new System.Windows.Forms.Label();
			this.tmrDuplicate = new System.Windows.Forms.Timer(components);
			this._cmdType_2 = new System.Windows.Forms.Button();
			this._cmdType_1 = new System.Windows.Forms.Button();
			this._cmdType_0 = new System.Windows.Forms.Button();
			this._frmType_1 = new System.Windows.Forms.GroupBox();
			this.cmdBuildFilter = new System.Windows.Forms.Button();
			this.cmdNamespace = new System.Windows.Forms.Button();
			this.lblHeading = new System.Windows.Forms.Label();
			this.cmdExit = new System.Windows.Forms.Button();
			this._frmType_2 = new System.Windows.Forms.GroupBox();
			this.cmdBuildAll = new System.Windows.Forms.Button();
			this._Label3_1 = new System.Windows.Forms.Label();
			this._Label1_1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			//Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.Label3 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.cmdType = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
			//Me.frmType = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			this._frmType_0.SuspendLayout();
			this._frmType_1.SuspendLayout();
			this._frmType_2.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.cmdType).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.frmType).BeginInit();
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Selection Criteria for Point Of Sale Update";
			this.ClientSize = new System.Drawing.Size(508, 335);
			this.Location = new System.Drawing.Point(3, 22);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmUpdatePOScriteria";
			this.tmrDeposit.Enabled = false;
			this.tmrDeposit.Interval = 10;
			this.tmrMEndUpdatePOS.Enabled = false;
			this.tmrMEndUpdatePOS.Interval = 10;
			this._frmType_0.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			this._frmType_0.Text = "Option One (Update POS Changes)";
			this._frmType_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmType_0.Size = new System.Drawing.Size(382, 196);
			this._frmType_0.Location = new System.Drawing.Point(8, 50);
			this._frmType_0.TabIndex = 4;
			this._frmType_0.Enabled = true;
			this._frmType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmType_0.Visible = true;
			this._frmType_0.Padding = new System.Windows.Forms.Padding(0);
			this._frmType_0.Name = "_frmType_0";
			this.cmdBuildChanges.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBuildChanges.Text = "&View and Update changes >>";
			this.cmdBuildChanges.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdBuildChanges.Size = new System.Drawing.Size(178, 52);
			this.cmdBuildChanges.Location = new System.Drawing.Point(180, 132);
			this.cmdBuildChanges.TabIndex = 6;
			this.cmdBuildChanges.TabStop = false;
			this.cmdBuildChanges.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBuildChanges.CausesValidation = true;
			this.cmdBuildChanges.Enabled = true;
			this.cmdBuildChanges.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBuildChanges.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBuildChanges.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBuildChanges.Name = "cmdBuildChanges";
			this._Label3_0.Text = "Click on the \"View and Update changes >>\" button to continue.";
			this._Label3_0.Size = new System.Drawing.Size(157, 46);
			this._Label3_0.Location = new System.Drawing.Point(12, 144);
			this._Label3_0.TabIndex = 15;
			this._Label3_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label3_0.BackColor = System.Drawing.Color.Transparent;
			this._Label3_0.Enabled = true;
			this._Label3_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label3_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label3_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label3_0.UseMnemonic = true;
			this._Label3_0.Visible = true;
			this._Label3_0.AutoSize = false;
			this._Label3_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label3_0.Name = "_Label3_0";
			this._Label1_0.BackColor = System.Drawing.Color.Transparent;
			this._Label1_0.Text = "As you make changes to your catalogue by the use of the Stock Item, Pricing, Deposit and Pricing Group maintenance screens, the system records these changes and allows you to quickly update just the known changes to the \"Point Of Sale\" devices.";
			this._Label1_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._Label1_0.Size = new System.Drawing.Size(316, 70);
			this._Label1_0.Location = new System.Drawing.Point(30, 36);
			this._Label1_0.TabIndex = 5;
			this._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_0.Enabled = true;
			this._Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_0.UseMnemonic = true;
			this._Label1_0.Visible = true;
			this._Label1_0.AutoSize = false;
			this._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_0.Name = "_Label1_0";
			this.tmrDuplicate.Enabled = false;
			this.tmrDuplicate.Interval = 10;
			this._cmdType_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdType_2.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			this._cmdType_2.Text = "&3. Update All";
			this._cmdType_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._cmdType_2.Size = new System.Drawing.Size(121, 31);
			this._cmdType_2.Location = new System.Drawing.Point(267, 264);
			this._cmdType_2.TabIndex = 10;
			this._cmdType_2.CausesValidation = true;
			this._cmdType_2.Enabled = true;
			this._cmdType_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdType_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdType_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdType_2.TabStop = true;
			this._cmdType_2.Name = "_cmdType_2";
			this._cmdType_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdType_1.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this._cmdType_1.Text = "&2. Update by Filter";
			this._cmdType_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._cmdType_1.Size = new System.Drawing.Size(124, 31);
			this._cmdType_1.Location = new System.Drawing.Point(134, 262);
			this._cmdType_1.TabIndex = 9;
			this._cmdType_1.CausesValidation = true;
			this._cmdType_1.Enabled = true;
			this._cmdType_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdType_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdType_1.TabStop = true;
			this._cmdType_1.Name = "_cmdType_1";
			this._cmdType_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdType_0.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			this._cmdType_0.Text = "&1. Changes Only";
			this._cmdType_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._cmdType_0.Size = new System.Drawing.Size(121, 31);
			this._cmdType_0.Location = new System.Drawing.Point(6, 264);
			this._cmdType_0.TabIndex = 8;
			this._cmdType_0.CausesValidation = true;
			this._cmdType_0.Enabled = true;
			this._cmdType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdType_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdType_0.TabStop = true;
			this._cmdType_0.Name = "_cmdType_0";
			this._frmType_1.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this._frmType_1.Text = "Update POS by a filter";
			this._frmType_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmType_1.Size = new System.Drawing.Size(382, 196);
			this._frmType_1.Location = new System.Drawing.Point(99, 72);
			this._frmType_1.TabIndex = 1;
			this._frmType_1.Enabled = true;
			this._frmType_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmType_1.Visible = true;
			this._frmType_1.Padding = new System.Windows.Forms.Padding(0);
			this._frmType_1.Name = "_frmType_1";
			this.cmdBuildFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBuildFilter.Text = "&View and Update changes >>";
			this.cmdBuildFilter.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdBuildFilter.Size = new System.Drawing.Size(178, 52);
			this.cmdBuildFilter.Location = new System.Drawing.Point(180, 132);
			this.cmdBuildFilter.TabIndex = 7;
			this.cmdBuildFilter.TabStop = false;
			this.cmdBuildFilter.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBuildFilter.CausesValidation = true;
			this.cmdBuildFilter.Enabled = true;
			this.cmdBuildFilter.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBuildFilter.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBuildFilter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBuildFilter.Name = "cmdBuildFilter";
			this.cmdNamespace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNamespace.Text = "&Filter";
			this.cmdNamespace.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdNamespace.Size = new System.Drawing.Size(97, 52);
			this.cmdNamespace.Location = new System.Drawing.Point(9, 132);
			this.cmdNamespace.TabIndex = 2;
			this.cmdNamespace.TabStop = false;
			this.cmdNamespace.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNamespace.CausesValidation = true;
			this.cmdNamespace.Enabled = true;
			this.cmdNamespace.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNamespace.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNamespace.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNamespace.Name = "cmdNamespace";
			this.lblHeading.Text = "Using the \"Stock Item Selector\" .....";
			this.lblHeading.Size = new System.Drawing.Size(349, 106);
			this.lblHeading.Location = new System.Drawing.Point(9, 18);
			this.lblHeading.TabIndex = 3;
			this.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblHeading.BackColor = System.Drawing.SystemColors.Control;
			this.lblHeading.Enabled = true;
			this.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblHeading.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblHeading.UseMnemonic = true;
			this.lblHeading.Visible = true;
			this.lblHeading.AutoSize = false;
			this.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblHeading.Name = "lblHeading";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdExit.Size = new System.Drawing.Size(97, 52);
			this.cmdExit.Location = new System.Drawing.Point(406, 8);
			this.cmdExit.TabIndex = 0;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this._frmType_2.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			this._frmType_2.Text = "Option Three (Check Data Integrity)";
			this._frmType_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmType_2.Size = new System.Drawing.Size(382, 196);
			this._frmType_2.Location = new System.Drawing.Point(63, 129);
			this._frmType_2.TabIndex = 11;
			this._frmType_2.Enabled = true;
			this._frmType_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmType_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmType_2.Visible = true;
			this._frmType_2.Padding = new System.Windows.Forms.Padding(0);
			this._frmType_2.Name = "_frmType_2";
			this.cmdBuildAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBuildAll.Text = "&View and Update changes >>";
			this.cmdBuildAll.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdBuildAll.Size = new System.Drawing.Size(178, 52);
			this.cmdBuildAll.Location = new System.Drawing.Point(180, 132);
			this.cmdBuildAll.TabIndex = 12;
			this.cmdBuildAll.TabStop = false;
			this.cmdBuildAll.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBuildAll.CausesValidation = true;
			this.cmdBuildAll.Enabled = true;
			this.cmdBuildAll.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBuildAll.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBuildAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBuildAll.Name = "cmdBuildAll";
			this._Label3_1.Text = "Click on the \"View and Update changes >>\" button to continue.";
			this._Label3_1.Size = new System.Drawing.Size(157, 46);
			this._Label3_1.Location = new System.Drawing.Point(12, 144);
			this._Label3_1.TabIndex = 16;
			this._Label3_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label3_1.BackColor = System.Drawing.Color.Transparent;
			this._Label3_1.Enabled = true;
			this._Label3_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label3_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label3_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label3_1.UseMnemonic = true;
			this._Label3_1.Visible = true;
			this._Label3_1.AutoSize = false;
			this._Label3_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label3_1.Name = "_Label3_1";
			this._Label1_1.BackColor = System.Drawing.Color.Transparent;
			this._Label1_1.Text = "This option will check all your data for changes. The reason for using this option would be to thoroughly check all your data to make sure that your data integrity is correct.";
			this._Label1_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._Label1_1.Size = new System.Drawing.Size(316, 70);
			this._Label1_1.Location = new System.Drawing.Point(30, 36);
			this._Label1_1.TabIndex = 13;
			this._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_1.Enabled = true;
			this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_1.UseMnemonic = true;
			this._Label1_1.Visible = true;
			this._Label1_1.AutoSize = false;
			this._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_1.Name = "_Label1_1";
			this.Label2.Text = "You may set the Point Of Sale update instruction with one of three methods. Each offering a different update type. By click on the buttons below you will be able to switch between each of these options.";
			this.Label2.Size = new System.Drawing.Size(370, 49);
			this.Label2.Location = new System.Drawing.Point(18, 6);
			this.Label2.TabIndex = 14;
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
			this.Controls.Add(_frmType_0);
			this.Controls.Add(_cmdType_2);
			this.Controls.Add(_cmdType_1);
			this.Controls.Add(_cmdType_0);
			this.Controls.Add(_frmType_1);
			this.Controls.Add(cmdExit);
			this.Controls.Add(_frmType_2);
			this.Controls.Add(Label2);
			this._frmType_0.Controls.Add(cmdBuildChanges);
			this._frmType_0.Controls.Add(_Label3_0);
			this._frmType_0.Controls.Add(_Label1_0);
			this._frmType_1.Controls.Add(cmdBuildFilter);
			this._frmType_1.Controls.Add(cmdNamespace);
			this._frmType_1.Controls.Add(lblHeading);
			this._frmType_2.Controls.Add(cmdBuildAll);
			this._frmType_2.Controls.Add(_Label3_1);
			this._frmType_2.Controls.Add(_Label1_1);
			//Me.Label1.SetIndex(_Label1_0, CType(0, Short))
			//Me.Label1.SetIndex(_Label1_1, CType(1, Short))
			//Me.Label3.SetIndex(_Label3_0, CType(0, Short))
			//Me.Label3.SetIndex(_Label3_1, CType(1, Short))
			//Me.cmdType.SetIndex(_cmdType_2, CType(2, Short))
			//Me.cmdType.SetIndex(_cmdType_1, CType(1, Short))
			//Me.cmdType.SetIndex(_cmdType_0, CType(0, Short))
			//Me.frmType.SetIndex(_frmType_0, CType(0, Short))
			//Me.frmType.SetIndex(_frmType_1, CType(1, Short))
			//Me.frmType.SetIndex(_frmType_2, CType(2, Short))
			//CType(Me.frmType, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.cmdType, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
			this._frmType_0.ResumeLayout(false);
			this._frmType_1.ResumeLayout(false);
			this._frmType_2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
