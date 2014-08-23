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
	partial class frmMenu
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmMenu() : base()
		{
			Load += frmMenu_Load1;
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
		public System.Windows.Forms.ToolStripMenuItem mnuWelcome;
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuDashboard;
		public System.Windows.Forms.ToolStripMenuItem mnuDashboard {
			get { return withEventsField_mnuDashboard; }
			set {
				if (withEventsField_mnuDashboard != null) {
					withEventsField_mnuDashboard.Click -= mnuDashboard_Click;
				}
				withEventsField_mnuDashboard = value;
				if (withEventsField_mnuDashboard != null) {
					withEventsField_mnuDashboard.Click += mnuDashboard_Click;
				}
			}
		}
		public System.Windows.Forms.ToolStripMenuItem mnuReports;
		public System.Windows.Forms.MenuStrip MainMenu1;
		private System.Windows.Forms.CheckBox withEventsField_chkDash;
		public System.Windows.Forms.CheckBox chkDash {
			get { return withEventsField_chkDash; }
			set {
				if (withEventsField_chkDash != null) {
					withEventsField_chkDash.Click -= chkDash_CheckStateChanged;
				}
				withEventsField_chkDash = value;
				if (withEventsField_chkDash != null) {
					withEventsField_chkDash.Click += chkDash_CheckStateChanged;
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
		private System.Windows.Forms.Button withEventsField_cmdYesterday;
		public System.Windows.Forms.Button cmdYesterday {
			get { return withEventsField_cmdYesterday; }
			set {
				if (withEventsField_cmdYesterday != null) {
					withEventsField_cmdYesterday.Click -= cmdYesterday_Click;
				}
				withEventsField_cmdYesterday = value;
				if (withEventsField_cmdYesterday != null) {
					withEventsField_cmdYesterday.Click += cmdYesterday_Click;
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
		private System.Windows.Forms.Timer withEventsField_tmrReports;
		public System.Windows.Forms.Timer tmrReports {
			get { return withEventsField_tmrReports; }
			set {
				if (withEventsField_tmrReports != null) {
					withEventsField_tmrReports.Tick -= tmrReports_Tick;
				}
				withEventsField_tmrReports = value;
				if (withEventsField_tmrReports != null) {
					withEventsField_tmrReports.Tick += tmrReports_Tick;
				}
			}
		}
		private System.Windows.Forms.Timer withEventsField_tmrReportCancel;
		public System.Windows.Forms.Timer tmrReportCancel {
			get { return withEventsField_tmrReportCancel; }
			set {
				if (withEventsField_tmrReportCancel != null) {
					withEventsField_tmrReportCancel.Tick -= tmrReportCancel_Tick;
				}
				withEventsField_tmrReportCancel = value;
				if (withEventsField_tmrReportCancel != null) {
					withEventsField_tmrReportCancel.Tick += tmrReportCancel_Tick;
				}
			}
		}
		private System.Windows.Forms.Timer withEventsField_tmrForm;
		public System.Windows.Forms.Timer tmrForm {
			get { return withEventsField_tmrForm; }
			set {
				if (withEventsField_tmrForm != null) {
					withEventsField_tmrForm.Tick -= tmrForm_Tick;
				}
				withEventsField_tmrForm = value;
				if (withEventsField_tmrForm != null) {
					withEventsField_tmrForm.Tick += tmrForm_Tick;
				}
			}
		}
		public System.Windows.Forms.TextBox Text1;
		//Public WithEvents CRViewer1 As CrystalDecisions.Web.CrystalReportViewer
		public System.Windows.Forms.Panel picReport;
		private System.Windows.Forms.Timer withEventsField_tmrMenuShow;
		public System.Windows.Forms.Timer tmrMenuShow {
			get { return withEventsField_tmrMenuShow; }
			set {
				if (withEventsField_tmrMenuShow != null) {
					withEventsField_tmrMenuShow.Tick -= tmrMenuShow_Tick;
				}
				withEventsField_tmrMenuShow = value;
				if (withEventsField_tmrMenuShow != null) {
					withEventsField_tmrMenuShow.Tick += tmrMenuShow_Tick;
				}
			}
		}
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label lblPath;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label lblDayEndCurrent;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label lblCompany;
		public System.Windows.Forms.PictureBox _imgArrow_0;
		public System.Windows.Forms.Label lblUser;
		public System.Windows.Forms.Label lblVersion;
		public System.Windows.Forms.PictureBox Image1;
		public System.Windows.Forms.PictureBox Image2;
		//Public WithEvents DTPicker1 As AxDTPickerArray
		//Public WithEvents imgArrow As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
		//Public WithEvents imgMenu As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblColor As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//'Public WithEvents lblMenu As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblMenuMain As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents picMenuList As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.MainMenu1 = new System.Windows.Forms.MenuStrip();
			this.mnuReports = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuWelcome = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDashboard = new System.Windows.Forms.ToolStripMenuItem();
			this.chkDash = new System.Windows.Forms.CheckBox();
			this.cmdToday = new System.Windows.Forms.Button();
			this.cmdYesterday = new System.Windows.Forms.Button();
			this.cmdLoad = new System.Windows.Forms.Button();
			this.tmrReports = new System.Windows.Forms.Timer(this.components);
			this.tmrReportCancel = new System.Windows.Forms.Timer(this.components);
			this.tmrForm = new System.Windows.Forms.Timer(this.components);
			this.Text1 = new System.Windows.Forms.TextBox();
			this.picReport = new System.Windows.Forms.Panel();
			this.CrystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.tmrMenuShow = new System.Windows.Forms.Timer(this.components);
			this.Label2 = new System.Windows.Forms.Label();
			this.lblPath = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.lblDayEndCurrent = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this.lblCompany = new System.Windows.Forms.Label();
			this._imgArrow_0 = new System.Windows.Forms.PictureBox();
			this.lblUser = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.Image1 = new System.Windows.Forms.PictureBox();
			this.Image2 = new System.Windows.Forms.PictureBox();
			this._DTPicker1_0 = new System.Windows.Forms.DateTimePicker();
			this._DTPicker1_1 = new System.Windows.Forms.DateTimePicker();
			this.lblDayEnd = new System.Windows.Forms.Label();
			this.MainMenu1.SuspendLayout();
			this.picReport.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this._imgArrow_0).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.Image1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.Image2).BeginInit();
			this.SuspendLayout();
			//
			//MainMenu1
			//
			this.MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuReports });
			this.MainMenu1.Location = new System.Drawing.Point(0, 0);
			this.MainMenu1.Name = "MainMenu1";
			this.MainMenu1.Size = new System.Drawing.Size(1013, 24);
			this.MainMenu1.TabIndex = 31;
			//
			//mnuReports
			//
			this.mnuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.mnuWelcome,
				this.mnuDashboard
			});
			this.mnuReports.Name = "mnuReports";
			this.mnuReports.Size = new System.Drawing.Size(84, 20);
			this.mnuReports.Text = "mnuReports";
			this.mnuReports.Visible = false;
			//
			//mnuWelcome
			//
			this.mnuWelcome.Name = "mnuWelcome";
			this.mnuWelcome.Size = new System.Drawing.Size(160, 22);
			this.mnuWelcome.Text = "Welcome Note";
			//
			//mnuDashboard
			//
			this.mnuDashboard.Name = "mnuDashboard";
			this.mnuDashboard.Size = new System.Drawing.Size(160, 22);
			this.mnuDashboard.Text = "Sales &Dashboard";
			//
			//chkDash
			//
			this.chkDash.BackColor = System.Drawing.SystemColors.Control;
			this.chkDash.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkDash.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkDash.Location = new System.Drawing.Point(320, 672);
			this.chkDash.Name = "chkDash";
			this.chkDash.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkDash.Size = new System.Drawing.Size(14, 14);
			this.chkDash.TabIndex = 22;
			this.chkDash.Text = " Show  Sales  Dashboard";
			this.chkDash.UseVisualStyleBackColor = false;
			//
			//cmdToday
			//
			this.cmdToday.BackColor = System.Drawing.SystemColors.Control;
			this.cmdToday.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdToday.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdToday.Location = new System.Drawing.Point(761, 128);
			this.cmdToday.Name = "cmdToday";
			this.cmdToday.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdToday.Size = new System.Drawing.Size(126, 19);
			this.cmdToday.TabIndex = 17;
			this.cmdToday.TabStop = false;
			this.cmdToday.Text = "&1. Goto Today";
			this.cmdToday.UseVisualStyleBackColor = false;
			//
			//cmdYesterday
			//
			this.cmdYesterday.BackColor = System.Drawing.SystemColors.Control;
			this.cmdYesterday.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdYesterday.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdYesterday.Location = new System.Drawing.Point(761, 148);
			this.cmdYesterday.Name = "cmdYesterday";
			this.cmdYesterday.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdYesterday.Size = new System.Drawing.Size(126, 19);
			this.cmdYesterday.TabIndex = 16;
			this.cmdYesterday.TabStop = false;
			this.cmdYesterday.Text = "&2. Goto Yesterday";
			this.cmdYesterday.UseVisualStyleBackColor = false;
			//
			//cmdLoad
			//
			this.cmdLoad.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdLoad.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLoad.Location = new System.Drawing.Point(892, 126);
			this.cmdLoad.Name = "cmdLoad";
			this.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLoad.Size = new System.Drawing.Size(100, 39);
			this.cmdLoad.TabIndex = 15;
			this.cmdLoad.TabStop = false;
			this.cmdLoad.Text = "&Load Reports";
			this.cmdLoad.UseVisualStyleBackColor = false;
			//
			//tmrReports
			//
			this.tmrReports.Interval = 1;
			//
			//tmrReportCancel
			//
			this.tmrReportCancel.Interval = 30000;
			//
			//tmrForm
			//
			this.tmrForm.Interval = 10;
			//
			//Text1
			//
			this.Text1.AcceptsReturn = true;
			this.Text1.BackColor = System.Drawing.SystemColors.Window;
			this.Text1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.Text1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Text1.Location = new System.Drawing.Point(-66, 75);
			this.Text1.MaxLength = 0;
			this.Text1.Name = "Text1";
			this.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text1.Size = new System.Drawing.Size(55, 20);
			this.Text1.TabIndex = 9;
			this.Text1.TabStop = false;
			this.Text1.Text = "Text1";
			//
			//picReport
			//
			this.picReport.BackColor = System.Drawing.SystemColors.Window;
			this.picReport.Controls.Add(this.CrystalReportViewer1);
			this.picReport.Cursor = System.Windows.Forms.Cursors.Default;
			this.picReport.Enabled = false;
			this.picReport.ForeColor = System.Drawing.SystemColors.WindowText;
			this.picReport.Location = new System.Drawing.Point(312, 216);
			this.picReport.Name = "picReport";
			this.picReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picReport.Size = new System.Drawing.Size(683, 449);
			this.picReport.TabIndex = 6;
			//
			//CrystalReportViewer1
			//
			this.CrystalReportViewer1.ActiveViewIndex = -1;
			this.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
			this.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CrystalReportViewer1.Location = new System.Drawing.Point(0, 0);
			this.CrystalReportViewer1.Name = "CrystalReportViewer1";
			this.CrystalReportViewer1.Size = new System.Drawing.Size(683, 449);
			this.CrystalReportViewer1.TabIndex = 0;
			//
			//tmrMenuShow
			//
			this.tmrMenuShow.Interval = 10;
			//
			//Label2
			//
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label2.ForeColor = System.Drawing.Color.White;
			this.Label2.Location = new System.Drawing.Point(336, 672);
			this.Label2.Name = "Label2";
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.Size = new System.Drawing.Size(137, 17);
			this.Label2.TabIndex = 23;
			this.Label2.Text = "Show Sales Dashboard";
			//
			//lblPath
			//
			this.lblPath.AutoSize = true;
			this.lblPath.BackColor = System.Drawing.Color.Transparent;
			this.lblPath.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblPath.ForeColor = System.Drawing.Color.White;
			this.lblPath.Location = new System.Drawing.Point(525, 99);
			this.lblPath.Name = "lblPath";
			this.lblPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblPath.Size = new System.Drawing.Size(0, 13);
			this.lblPath.TabIndex = 21;
			//
			//Label1
			//
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.ForeColor = System.Drawing.Color.White;
			this.Label1.Location = new System.Drawing.Point(312, 134);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(270, 61);
			this.Label1.TabIndex = 20;
			this.Label1.Text = "Before viewing any reports, the date range needs to be selected. Your \"Day End\" r" + "uns determine the date range and the details of your selection is given in the \"" + "Calculated Criteria\" box.";
			//
			//lblDayEndCurrent
			//
			this.lblDayEndCurrent.BackColor = System.Drawing.SystemColors.Window;
			this.lblDayEndCurrent.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDayEndCurrent.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblDayEndCurrent.Location = new System.Drawing.Point(596, 674);
			this.lblDayEndCurrent.Name = "lblDayEndCurrent";
			this.lblDayEndCurrent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDayEndCurrent.Size = new System.Drawing.Size(400, 16);
			this.lblDayEndCurrent.TabIndex = 19;
			this.lblDayEndCurrent.Text = "Label1";
			//
			//_lbl_0
			//
			this._lbl_0.AutoSize = true;
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_0.ForeColor = System.Drawing.Color.White;
			this._lbl_0.Location = new System.Drawing.Point(582, 133);
			this._lbl_0.Name = "_lbl_0";
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.Size = new System.Drawing.Size(63, 14);
			this._lbl_0.TabIndex = 14;
			this._lbl_0.Text = "&From Date";
			//
			//_lbl_1
			//
			this._lbl_1.AutoSize = true;
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_1.ForeColor = System.Drawing.Color.White;
			this._lbl_1.Location = new System.Drawing.Point(582, 152);
			this._lbl_1.Name = "_lbl_1";
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.Size = new System.Drawing.Size(47, 14);
			this._lbl_1.TabIndex = 13;
			this._lbl_1.Text = "&To Date";
			//
			//lblCompany
			//
			this.lblCompany.AutoSize = true;
			this.lblCompany.BackColor = System.Drawing.Color.Transparent;
			this.lblCompany.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblCompany.Font = new System.Drawing.Font("Arial", 24f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblCompany.ForeColor = System.Drawing.Color.White;
			this.lblCompany.Location = new System.Drawing.Point(524, 37);
			this.lblCompany.Name = "lblCompany";
			this.lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblCompany.Size = new System.Drawing.Size(255, 37);
			this.lblCompany.TabIndex = 8;
			this.lblCompany.Text = "Company Name";
			//
			//_imgArrow_0
			//
			this._imgArrow_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._imgArrow_0.Image = (System.Drawing.Image)resources.GetObject("_imgArrow_0.Image");
			this._imgArrow_0.Location = new System.Drawing.Point(392, 280);
			this._imgArrow_0.Name = "_imgArrow_0";
			this._imgArrow_0.Size = new System.Drawing.Size(11, 9);
			this._imgArrow_0.TabIndex = 24;
			this._imgArrow_0.TabStop = false;
			this._imgArrow_0.Visible = false;
			//
			//lblUser
			//
			this.lblUser.BackColor = System.Drawing.Color.Transparent;
			this.lblUser.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblUser.Font = new System.Drawing.Font("Arial", 13.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblUser.ForeColor = System.Drawing.Color.White;
			this.lblUser.Location = new System.Drawing.Point(14, 156);
			this.lblUser.Name = "lblUser";
			this.lblUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblUser.Size = new System.Drawing.Size(267, 43);
			this.lblUser.TabIndex = 3;
			this.lblUser.Text = "lblUserName";
			//
			//lblVersion
			//
			this.lblVersion.AutoSize = true;
			this.lblVersion.BackColor = System.Drawing.Color.Transparent;
			this.lblVersion.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblVersion.ForeColor = System.Drawing.Color.White;
			this.lblVersion.Location = new System.Drawing.Point(18, 674);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblVersion.Size = new System.Drawing.Size(42, 13);
			this.lblVersion.TabIndex = 4;
			this.lblVersion.Text = "Version";
			this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Image1
			//
			this.Image1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Image1.Image = (System.Drawing.Image)resources.GetObject("Image1.Image");
			this.Image1.Location = new System.Drawing.Point(1240, 24);
			this.Image1.Name = "Image1";
			this.Image1.Size = new System.Drawing.Size(1025, 720);
			this.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Image1.TabIndex = 29;
			this.Image1.TabStop = false;
			//
			//Image2
			//
			this.Image2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Image2.Image = (System.Drawing.Image)resources.GetObject("Image2.Image");
			this.Image2.Location = new System.Drawing.Point(1056, 168);
			this.Image2.Name = "Image2";
			this.Image2.Size = new System.Drawing.Size(17, 714);
			this.Image2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Image2.TabIndex = 30;
			this.Image2.TabStop = false;
			//
			//_DTPicker1_0
			//
			this._DTPicker1_0.Location = new System.Drawing.Point(652, 130);
			this._DTPicker1_0.Name = "_DTPicker1_0";
			this._DTPicker1_0.Size = new System.Drawing.Size(103, 20);
			this._DTPicker1_0.TabIndex = 32;
			//
			//_DTPicker1_1
			//
			this._DTPicker1_1.Location = new System.Drawing.Point(652, 152);
			this._DTPicker1_1.Name = "_DTPicker1_1";
			this._DTPicker1_1.Size = new System.Drawing.Size(103, 20);
			this._DTPicker1_1.TabIndex = 33;
			//
			//lblDayEnd
			//
			this.lblDayEnd.AutoSize = true;
			this.lblDayEnd.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lblDayEnd.Location = new System.Drawing.Point(762, 170);
			this.lblDayEnd.Name = "lblDayEnd";
			this.lblDayEnd.Size = new System.Drawing.Size(39, 13);
			this.lblDayEnd.TabIndex = 34;
			this.lblDayEnd.Text = "Label3";
			//
			//frmMenu
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(1013, 710);
			this.Controls.Add(this.lblDayEnd);
			this.Controls.Add(this._DTPicker1_1);
			this.Controls.Add(this._DTPicker1_0);
			this.Controls.Add(this.chkDash);
			this.Controls.Add(this.cmdToday);
			this.Controls.Add(this.cmdYesterday);
			this.Controls.Add(this.cmdLoad);
			this.Controls.Add(this.Text1);
			this.Controls.Add(this.picReport);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.lblPath);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.lblDayEndCurrent);
			this.Controls.Add(this._lbl_0);
			this.Controls.Add(this._lbl_1);
			this.Controls.Add(this.lblCompany);
			this.Controls.Add(this._imgArrow_0);
			this.Controls.Add(this.lblUser);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.Image1);
			this.Controls.Add(this.Image2);
			this.Controls.Add(this.MainMenu1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(11, 37);
			this.Name = "frmMenu";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "4POS Back Office";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.MainMenu1.ResumeLayout(false);
			this.MainMenu1.PerformLayout();
			this.picReport.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this._imgArrow_0).EndInit();
			((System.ComponentModel.ISupportInitialize)this.Image1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.Image2).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalReportViewer1;
		internal System.Windows.Forms.DateTimePicker _DTPicker1_0;
		internal System.Windows.Forms.DateTimePicker _DTPicker1_1;
			#endregion
		internal System.Windows.Forms.Label lblDayEnd;
	}
}
