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
	partial class frmOrderWizardFilter
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmOrderWizardFilter() : base()
		{
			Load += frmOrderWizardFilter_Load;
			KeyPress += frmOrderWizardFilter_KeyPress;
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
		private System.Windows.Forms.Button withEventsField_cmdFilter;
		public System.Windows.Forms.Button cmdFilter {
			get { return withEventsField_cmdFilter; }
			set {
				if (withEventsField_cmdFilter != null) {
					withEventsField_cmdFilter.Click -= cmdFilter_Click;
				}
				withEventsField_cmdFilter = value;
				if (withEventsField_cmdFilter != null) {
					withEventsField_cmdFilter.Click += cmdFilter_Click;
				}
			}
		}
		public System.Windows.Forms.CheckBox chkDynamic;
		private System.Windows.Forms.TextBox withEventsField_txtDays;
		public System.Windows.Forms.TextBox txtDays {
			get { return withEventsField_txtDays; }
			set {
				if (withEventsField_txtDays != null) {
					withEventsField_txtDays.Enter -= txtDays_Enter;
					withEventsField_txtDays.KeyPress -= txtDays_KeyPress;
					withEventsField_txtDays.Leave -= txtDays_Leave;
				}
				withEventsField_txtDays = value;
				if (withEventsField_txtDays != null) {
					withEventsField_txtDays.Enter += txtDays_Enter;
					withEventsField_txtDays.KeyPress += txtDays_KeyPress;
					withEventsField_txtDays.Leave += txtDays_Leave;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtMinimum;
		public System.Windows.Forms.TextBox txtMinimum {
			get { return withEventsField_txtMinimum; }
			set {
				if (withEventsField_txtMinimum != null) {
					withEventsField_txtMinimum.Enter -= txtMinimum_Enter;
					withEventsField_txtMinimum.KeyPress -= txtMinimum_KeyPress;
					withEventsField_txtMinimum.Leave -= txtMinimum_Leave;
				}
				withEventsField_txtMinimum = value;
				if (withEventsField_txtMinimum != null) {
					withEventsField_txtMinimum.Enter += txtMinimum_Enter;
					withEventsField_txtMinimum.KeyPress += txtMinimum_KeyPress;
					withEventsField_txtMinimum.Leave += txtMinimum_Leave;
				}
			}
		}
		public System.Windows.Forms.MonthCalendar _MonthView1_1;
		public System.Windows.Forms.MonthCalendar _MonthView1_0;
		public System.Windows.Forms.Label _lbl_6;
		public System.Windows.Forms.Label lblFilter;
		public System.Windows.Forms.Label _Label1_2;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public System.Windows.Forms.Label _Label1_1;
		public System.Windows.Forms.Label _Label1_0;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label lblDayEnd;
		public System.Windows.Forms.Label _lbl_5;
		public System.Windows.Forms.Label _lbl_3;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lbl_4;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		//Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents MonthView1 As AxMonthViewArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmOrderWizardFilter));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.cmdFilter = new System.Windows.Forms.Button();
			this.chkDynamic = new System.Windows.Forms.CheckBox();
			this.txtDays = new System.Windows.Forms.TextBox();
			this.txtMinimum = new System.Windows.Forms.TextBox();
			this._MonthView1_1 = new System.Windows.Forms.MonthCalendar();
			this._MonthView1_0 = new System.Windows.Forms.MonthCalendar();
			this._lbl_6 = new System.Windows.Forms.Label();
			this.lblFilter = new System.Windows.Forms.Label();
			this._Label1_2 = new System.Windows.Forms.Label();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Label1_1 = new System.Windows.Forms.Label();
			this._Label1_0 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.lblDayEnd = new System.Windows.Forms.Label();
			this._lbl_5 = new System.Windows.Forms.Label();
			this._lbl_3 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lbl_4 = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.MonthView1 = New AxMonthViewArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this._MonthView1_1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this._MonthView1_0).BeginInit();
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.MonthView1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.ClientSize = new System.Drawing.Size(436, 590);
			this.Location = new System.Drawing.Point(3, 3);
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
			this.Name = "frmOrderWizardFilter";
			this.cmdFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdFilter.Text = "&Filter ...";
			this.cmdFilter.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdFilter.Size = new System.Drawing.Size(79, 37);
			this.cmdFilter.Location = new System.Drawing.Point(336, 528);
			this.cmdFilter.TabIndex = 16;
			this.cmdFilter.TabStop = false;
			this.cmdFilter.BackColor = System.Drawing.SystemColors.Control;
			this.cmdFilter.CausesValidation = true;
			this.cmdFilter.Enabled = true;
			this.cmdFilter.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdFilter.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdFilter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdFilter.Name = "cmdFilter";
			this.chkDynamic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkDynamic.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.chkDynamic.Text = "Automatically re-calculate start and end dates based on current \"Day End\" date.";
			this.chkDynamic.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkDynamic.Size = new System.Drawing.Size(400, 13);
			this.chkDynamic.Location = new System.Drawing.Point(21, 393);
			this.chkDynamic.TabIndex = 13;
			this.chkDynamic.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkDynamic.CausesValidation = true;
			this.chkDynamic.Enabled = true;
			this.chkDynamic.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkDynamic.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkDynamic.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkDynamic.TabStop = true;
			this.chkDynamic.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkDynamic.Visible = true;
			this.chkDynamic.Name = "chkDynamic";
			this.txtDays.AutoSize = false;
			this.txtDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDays.Size = new System.Drawing.Size(40, 19);
			this.txtDays.Location = new System.Drawing.Point(156, 348);
			this.txtDays.TabIndex = 8;
			this.txtDays.Text = "9";
			this.txtDays.AcceptsReturn = true;
			this.txtDays.BackColor = System.Drawing.SystemColors.Window;
			this.txtDays.CausesValidation = true;
			this.txtDays.Enabled = true;
			this.txtDays.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtDays.HideSelection = true;
			this.txtDays.ReadOnly = false;
			this.txtDays.MaxLength = 0;
			this.txtDays.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtDays.Multiline = false;
			this.txtDays.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtDays.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtDays.TabStop = true;
			this.txtDays.Visible = true;
			this.txtDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDays.Name = "txtDays";
			this.txtMinimum.AutoSize = false;
			this.txtMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtMinimum.Size = new System.Drawing.Size(40, 19);
			this.txtMinimum.Location = new System.Drawing.Point(105, 366);
			this.txtMinimum.TabIndex = 11;
			this.txtMinimum.Text = "2";
			this.txtMinimum.AcceptsReturn = true;
			this.txtMinimum.BackColor = System.Drawing.SystemColors.Window;
			this.txtMinimum.CausesValidation = true;
			this.txtMinimum.Enabled = true;
			this.txtMinimum.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtMinimum.HideSelection = true;
			this.txtMinimum.ReadOnly = false;
			this.txtMinimum.MaxLength = 0;
			this.txtMinimum.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMinimum.Multiline = false;
			this.txtMinimum.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtMinimum.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtMinimum.TabStop = true;
			this.txtMinimum.Visible = true;
			this.txtMinimum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMinimum.Name = "txtMinimum";
			//_MonthView1_1.OcxState = CType(resources.GetObject("_MonthView1_1.OcxState"), System.Windows.Forms.AxHost.State)
			this._MonthView1_1.Size = new System.Drawing.Size(180, 158);
			this._MonthView1_1.Location = new System.Drawing.Point(237, 96);
			this._MonthView1_1.TabIndex = 4;
			this._MonthView1_1.Name = "_MonthView1_1";
			//_MonthView1_0.OcxState = CType(resources.GetObject("_MonthView1_0.OcxState"), System.Windows.Forms.AxHost.State)
			this._MonthView1_0.Size = new System.Drawing.Size(180, 158);
			this._MonthView1_0.Location = new System.Drawing.Point(21, 96);
			this._MonthView1_0.TabIndex = 2;
			this._MonthView1_0.Name = "_MonthView1_0";
			this._lbl_6.Text = "units.";
			this._lbl_6.Size = new System.Drawing.Size(25, 13);
			this._lbl_6.Location = new System.Drawing.Point(150, 369);
			this._lbl_6.TabIndex = 12;
			this._lbl_6.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this.lblFilter.Text = "Label1";
			this.lblFilter.Size = new System.Drawing.Size(391, 76);
			this.lblFilter.Location = new System.Drawing.Point(24, 447);
			this.lblFilter.TabIndex = 15;
			this.lblFilter.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblFilter.BackColor = System.Drawing.SystemColors.Control;
			this.lblFilter.Enabled = true;
			this.lblFilter.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblFilter.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblFilter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblFilter.UseMnemonic = true;
			this.lblFilter.Visible = true;
			this.lblFilter.AutoSize = false;
			this.lblFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblFilter.Name = "lblFilter";
			this._Label1_2.Text = "&3. Filter";
			this._Label1_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Label1_2.Size = new System.Drawing.Size(44, 13);
			this._Label1_2.Location = new System.Drawing.Point(15, 423);
			this._Label1_2.TabIndex = 14;
			this._Label1_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_2.BackColor = System.Drawing.Color.Transparent;
			this._Label1_2.Enabled = true;
			this._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_2.UseMnemonic = true;
			this._Label1_2.Visible = true;
			this._Label1_2.AutoSize = true;
			this._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_2.Name = "_Label1_2";
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(415, 136);
			this._Shape1_2.Location = new System.Drawing.Point(12, 438);
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_2.BorderWidth = 1;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_2.Visible = true;
			this._Shape1_2.Name = "_Shape1_2";
			this._Label1_1.Text = "&2. Wizard Rules";
			this._Label1_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Label1_1.Size = new System.Drawing.Size(91, 13);
			this._Label1_1.Location = new System.Drawing.Point(15, 327);
			this._Label1_1.TabIndex = 6;
			this._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_1.BackColor = System.Drawing.Color.Transparent;
			this._Label1_1.Enabled = true;
			this._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_1.UseMnemonic = true;
			this._Label1_1.Visible = true;
			this._Label1_1.AutoSize = true;
			this._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_1.Name = "_Label1_1";
			this._Label1_0.Text = "&1. Day End Criteria";
			this._Label1_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Label1_0.Size = new System.Drawing.Size(108, 13);
			this._Label1_0.Location = new System.Drawing.Point(15, 63);
			this._Label1_0.TabIndex = 0;
			this._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_0.BackColor = System.Drawing.Color.Transparent;
			this._Label1_0.Enabled = true;
			this._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_0.UseMnemonic = true;
			this._Label1_0.Visible = true;
			this._Label1_0.AutoSize = true;
			this._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_0.Name = "_Label1_0";
			this.Label2.Text = "When calculating your ordering levels, you must select the mean number of \"day Ends\" to cover to get an average number of units sold. This average is then projected for a set number of days to give you your expected sales. This expectation is then your minimum order level for the \"Stock Item\".";
			this.Label2.Size = new System.Drawing.Size(397, 55);
			this.Label2.Location = new System.Drawing.Point(15, 3);
			this.Label2.TabIndex = 17;
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
			this.lblDayEnd.Text = "Label1";
			this.lblDayEnd.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblDayEnd.Size = new System.Drawing.Size(397, 34);
			this.lblDayEnd.Location = new System.Drawing.Point(21, 276);
			this.lblDayEnd.TabIndex = 5;
			this.lblDayEnd.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblDayEnd.BackColor = System.Drawing.SystemColors.Control;
			this.lblDayEnd.Enabled = true;
			this.lblDayEnd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDayEnd.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDayEnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDayEnd.UseMnemonic = true;
			this.lblDayEnd.Visible = true;
			this.lblDayEnd.AutoSize = false;
			this.lblDayEnd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDayEnd.Name = "lblDayEnd";
			this._lbl_5.Text = "From Date";
			this._lbl_5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_5.Size = new System.Drawing.Size(59, 13);
			this._lbl_5.Location = new System.Drawing.Point(24, 81);
			this._lbl_5.TabIndex = 1;
			this._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this._lbl_3.Text = "To Date";
			this._lbl_3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_3.Size = new System.Drawing.Size(47, 13);
			this._lbl_3.Location = new System.Drawing.Point(240, 81);
			this._lbl_3.TabIndex = 3;
			this._lbl_3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_3.BackColor = System.Drawing.Color.Transparent;
			this._lbl_3.Enabled = true;
			this._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_3.UseMnemonic = true;
			this._lbl_3.Visible = true;
			this._lbl_3.AutoSize = true;
			this._lbl_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_3.Name = "_lbl_3";
			this._lbl_1.Text = "Calculated Day End Criteria";
			this._lbl_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_1.Size = new System.Drawing.Size(157, 13);
			this._lbl_1.Location = new System.Drawing.Point(21, 261);
			this._lbl_1.TabIndex = 18;
			this._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Enabled = true;
			this._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.UseMnemonic = true;
			this._lbl_1.Visible = true;
			this._lbl_1.AutoSize = true;
			this._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_1.Name = "_lbl_1";
			this._lbl_4.Text = "level will be below";
			this._lbl_4.Size = new System.Drawing.Size(85, 13);
			this._lbl_4.Location = new System.Drawing.Point(15, 369);
			this._lbl_4.TabIndex = 10;
			this._lbl_4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this._lbl_2.Text = "\"Day Ends\" and then guarantee no re-order";
			this._lbl_2.Size = new System.Drawing.Size(206, 13);
			this._lbl_2.Location = new System.Drawing.Point(201, 351);
			this._lbl_2.TabIndex = 9;
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this._lbl_0.Text = "Forecast my stock holding for ";
			this._lbl_0.Size = new System.Drawing.Size(141, 13);
			this._lbl_0.Location = new System.Drawing.Point(15, 351);
			this._lbl_0.TabIndex = 7;
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this._Shape1_0.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_0.Size = new System.Drawing.Size(415, 241);
			this._Shape1_0.Location = new System.Drawing.Point(12, 78);
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_0.BorderWidth = 1;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_0.Visible = true;
			this._Shape1_0.Name = "_Shape1_0";
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.Size = new System.Drawing.Size(415, 73);
			this._Shape1_1.Location = new System.Drawing.Point(12, 342);
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_1.BorderWidth = 1;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_1.Visible = true;
			this._Shape1_1.Name = "_Shape1_1";
			this.Controls.Add(cmdFilter);
			this.Controls.Add(chkDynamic);
			this.Controls.Add(txtDays);
			this.Controls.Add(txtMinimum);
			this.Controls.Add(_MonthView1_1);
			this.Controls.Add(_MonthView1_0);
			this.Controls.Add(_lbl_6);
			this.Controls.Add(lblFilter);
			this.Controls.Add(_Label1_2);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.Controls.Add(_Label1_1);
			this.Controls.Add(_Label1_0);
			this.Controls.Add(Label2);
			this.Controls.Add(lblDayEnd);
			this.Controls.Add(_lbl_5);
			this.Controls.Add(_lbl_3);
			this.Controls.Add(_lbl_1);
			this.Controls.Add(_lbl_4);
			this.Controls.Add(_lbl_2);
			this.Controls.Add(_lbl_0);
			this.ShapeContainer1.Shapes.Add(_Shape1_0);
			this.ShapeContainer1.Shapes.Add(_Shape1_1);
			this.Controls.Add(ShapeContainer1);
			//Me.Label1.SetIndex(_Label1_2, CType(2, Short))
			//Me.Label1.SetIndex(_Label1_1, CType(1, Short))
			//Me.Label1.SetIndex(_Label1_0, CType(0, Short))
			//Me.MonthView1.SetIndex(_MonthView1_1, CType(1, Short))
			//Me.MonthView1.SetIndex(_MonthView1_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_6, CType(6, Short))
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			//Me.lbl.SetIndex(_lbl_3, CType(3, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_4, CType(4, Short))
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			this.Shape1.SetIndex(_Shape1_2, Convert.ToInt16(2));
			this.Shape1.SetIndex(_Shape1_0, Convert.ToInt16(0));
			this.Shape1.SetIndex(_Shape1_1, Convert.ToInt16(1));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.MonthView1, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this._MonthView1_0).EndInit();
			((System.ComponentModel.ISupportInitialize)this._MonthView1_1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
