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
	partial class frmRegister
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmRegister() : base()
		{
			Load += frmRegister_Load;
			KeyPress += frmRegister_KeyPress;
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
		public System.Windows.Forms.TextBox txtCompany;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_3;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		public System.Windows.Forms.Panel _picMode_0;
		public System.Windows.Forms.TextBox txtKey;
		public System.Windows.Forms.Label lblCompany;
		public System.Windows.Forms.Label _Label2_2;
		public System.Windows.Forms.Label _Label1_1;
		public System.Windows.Forms.Label _Label2_0;
		public System.Windows.Forms.Label lblCode;
		public System.Windows.Forms.Label _Label2_1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_3;
		public System.Windows.Forms.Panel _picMode_1;
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
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		//Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents Label2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents picMode As Microsoft.VisualBasic.Compatibility.VB6.PanelArray
		public OvalShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer2;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRegister));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.cmdExit = new System.Windows.Forms.Button();
			this._picMode_0 = new System.Windows.Forms.Panel();
			this.txtCompany = new System.Windows.Forms.TextBox();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_3 = new System.Windows.Forms.Label();
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._picMode_1 = new System.Windows.Forms.Panel();
			this.txtKey = new System.Windows.Forms.TextBox();
			this.lblCompany = new System.Windows.Forms.Label();
			this._Label2_2 = new System.Windows.Forms.Label();
			this._Label1_1 = new System.Windows.Forms.Label();
			this._Label2_0 = new System.Windows.Forms.Label();
			this.lblCode = new System.Windows.Forms.Label();
			this._Label2_1 = new System.Windows.Forms.Label();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.cmdNext = new System.Windows.Forms.Button();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			//Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.Label2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.picMode = New Microsoft.VisualBasic.Compatibility.VB6.PanelArray(components)
			this.Shape1 = new OvalShapeArray(components);
			this._picMode_0.SuspendLayout();
			this._picMode_1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.picMode, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Registration Wizard";
			this.ClientSize = new System.Drawing.Size(296, 282);
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
			this.Name = "frmRegister";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(97, 28);
			this.cmdExit.Location = new System.Drawing.Point(8, 249);
			this.cmdExit.TabIndex = 8;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.TabStop = true;
			this.cmdExit.Name = "cmdExit";
			this._picMode_0.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._picMode_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._picMode_0.Size = new System.Drawing.Size(283, 232);
			this._picMode_0.Location = new System.Drawing.Point(6, 9);
			this._picMode_0.TabIndex = 13;
			this._picMode_0.TabStop = false;
			this._picMode_0.Dock = System.Windows.Forms.DockStyle.None;
			this._picMode_0.CausesValidation = true;
			this._picMode_0.Enabled = true;
			this._picMode_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._picMode_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._picMode_0.Visible = true;
			this._picMode_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._picMode_0.Name = "_picMode_0";
			this.txtCompany.AutoSize = false;
			this.txtCompany.Size = new System.Drawing.Size(271, 19);
			this.txtCompany.Location = new System.Drawing.Point(6, 201);
			this.txtCompany.MaxLength = 50;
			this.txtCompany.TabIndex = 6;
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
			this.txtCompany.TabStop = true;
			this.txtCompany.Visible = true;
			this.txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtCompany.Name = "txtCompany";
			this._lbl_0.Text = "Store Name:";
			this._lbl_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_0.Size = new System.Drawing.Size(178, 16);
			this._lbl_0.Location = new System.Drawing.Point(6, 186);
			this._lbl_0.TabIndex = 5;
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lbl_1.Text = "Welcome to the 4POS Application Suite of products designed for the Retailer.";
			this._lbl_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_1.Size = new System.Drawing.Size(280, 43);
			this._lbl_1.Location = new System.Drawing.Point(0, 0);
			this._lbl_1.TabIndex = 2;
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Enabled = true;
			this._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.UseMnemonic = true;
			this._lbl_1.Visible = true;
			this._lbl_1.AutoSize = false;
			this._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_1.Name = "_lbl_1";
			this._lbl_2.Text = "In the text box below, please capture your store's name. It is imperative that you capture you stores name correctly as this makes up part of your licensing agreement with 4POS.";
			this._lbl_2.Size = new System.Drawing.Size(274, 64);
			this._lbl_2.Location = new System.Drawing.Point(6, 36);
			this._lbl_2.TabIndex = 3;
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Enabled = true;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.UseMnemonic = true;
			this._lbl_2.Visible = true;
			this._lbl_2.AutoSize = false;
			this._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_2.Name = "_lbl_2";
			this._lbl_3.Text = "To bypass this registration process, press the \"Exit\" button. This will activate the demo version of this software, which is fully functional except that you may only complete ten \"Day End\" runs.";
			this._lbl_3.Size = new System.Drawing.Size(274, 64);
			this._lbl_3.Location = new System.Drawing.Point(6, 99);
			this._lbl_3.TabIndex = 4;
			this._lbl_3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this._Shape1_0.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_0.Size = new System.Drawing.Size(283, 133);
			this._Shape1_0.Location = new System.Drawing.Point(0, 30);
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_0.BorderWidth = 1;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_0.Visible = true;
			this._Shape1_0.Name = "_Shape1_0";
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.Size = new System.Drawing.Size(283, 46);
			this._Shape1_1.Location = new System.Drawing.Point(0, 183);
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_1.BorderWidth = 1;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_1.Visible = true;
			this._Shape1_1.Name = "_Shape1_1";
			this._picMode_1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._picMode_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._picMode_1.Size = new System.Drawing.Size(283, 232);
			this._picMode_1.Location = new System.Drawing.Point(333, 57);
			this._picMode_1.TabIndex = 9;
			this._picMode_1.TabStop = false;
			this._picMode_1.Visible = false;
			this._picMode_1.Dock = System.Windows.Forms.DockStyle.None;
			this._picMode_1.CausesValidation = true;
			this._picMode_1.Enabled = true;
			this._picMode_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._picMode_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._picMode_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._picMode_1.Name = "_picMode_1";
			this.txtKey.AutoSize = false;
			this.txtKey.Size = new System.Drawing.Size(175, 19);
			this.txtKey.Location = new System.Drawing.Point(99, 186);
			this.txtKey.TabIndex = 1;
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
			this.txtKey.TabStop = true;
			this.txtKey.Visible = true;
			this.txtKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtKey.Name = "txtKey";
			this.lblCompany.BackColor = System.Drawing.Color.Transparent;
			this.lblCompany.Text = "123456789012345";
			this.lblCompany.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblCompany.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCompany.Size = new System.Drawing.Size(276, 18);
			this.lblCompany.Location = new System.Drawing.Point(3, 87);
			this.lblCompany.TabIndex = 15;
			this.lblCompany.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblCompany.Enabled = true;
			this.lblCompany.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblCompany.UseMnemonic = true;
			this.lblCompany.Visible = true;
			this.lblCompany.AutoSize = false;
			this.lblCompany.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblCompany.Name = "lblCompany";
			this._Label2_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._Label2_2.Text = "Company Name:";
			this._Label2_2.Size = new System.Drawing.Size(93, 13);
			this._Label2_2.Location = new System.Drawing.Point(-12, 75);
			this._Label2_2.TabIndex = 14;
			this._Label2_2.BackColor = System.Drawing.Color.Transparent;
			this._Label2_2.Enabled = true;
			this._Label2_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label2_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label2_2.UseMnemonic = true;
			this._Label2_2.Visible = true;
			this._Label2_2.AutoSize = false;
			this._Label2_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label2_2.Name = "_Label2_2";
			this._Label1_1.Text = "Please contact a \"4POS\" representative and quote the company name and registration code below to get your new activation key for the product.";
			this._Label1_1.Size = new System.Drawing.Size(280, 58);
			this._Label1_1.Location = new System.Drawing.Point(3, 0);
			this._Label1_1.TabIndex = 12;
			this._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_1.BackColor = System.Drawing.Color.Transparent;
			this._Label1_1.Enabled = true;
			this._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_1.UseMnemonic = true;
			this._Label1_1.Visible = true;
			this._Label1_1.AutoSize = false;
			this._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_1.Name = "_Label1_1";
			this._Label2_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._Label2_0.Text = "Registration code:";
			this._Label2_0.Size = new System.Drawing.Size(93, 13);
			this._Label2_0.Location = new System.Drawing.Point(-3, 102);
			this._Label2_0.TabIndex = 11;
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
			this.lblCode.BackColor = System.Drawing.Color.Transparent;
			this.lblCode.Text = "123456789012345";
			this.lblCode.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblCode.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCode.Size = new System.Drawing.Size(123, 18);
			this.lblCode.Location = new System.Drawing.Point(3, 114);
			this.lblCode.TabIndex = 10;
			this.lblCode.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblCode.Enabled = true;
			this.lblCode.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblCode.UseMnemonic = true;
			this.lblCode.Visible = true;
			this.lblCode.AutoSize = false;
			this.lblCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblCode.Name = "lblCode";
			this._Label2_1.Text = "Activation key:";
			this._Label2_1.Size = new System.Drawing.Size(70, 13);
			this._Label2_1.Location = new System.Drawing.Point(21, 189);
			this._Label2_1.TabIndex = 0;
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
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(283, 67);
			this._Shape1_2.Location = new System.Drawing.Point(0, 72);
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_2.BorderWidth = 1;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_2.Visible = true;
			this._Shape1_2.Name = "_Shape1_2";
			this._Shape1_3.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			this._Shape1_3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_3.Size = new System.Drawing.Size(283, 31);
			this._Shape1_3.Location = new System.Drawing.Point(0, 180);
			this._Shape1_3.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_3.BorderWidth = 1;
			this._Shape1_3.FillColor = System.Drawing.Color.Black;
			this._Shape1_3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_3.Visible = true;
			this._Shape1_3.Name = "_Shape1_3";
			this.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNext.Text = "&Next";
			this.cmdNext.Size = new System.Drawing.Size(97, 28);
			this.cmdNext.Location = new System.Drawing.Point(186, 249);
			this.cmdNext.TabIndex = 7;
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.CausesValidation = true;
			this.cmdNext.Enabled = true;
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.TabStop = true;
			this.cmdNext.Name = "cmdNext";
			this.Label4.Text = "Label4";
			this.Label4.Size = new System.Drawing.Size(273, 33);
			this.Label4.Location = new System.Drawing.Point(16, 320);
			this.Label4.TabIndex = 17;
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label4.BackColor = System.Drawing.SystemColors.Control;
			this.Label4.Enabled = true;
			this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.UseMnemonic = true;
			this.Label4.Visible = true;
			this.Label4.AutoSize = false;
			this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label4.Name = "Label4";
			this.Label3.Text = "Label3";
			this.Label3.Size = new System.Drawing.Size(265, 25);
			this.Label3.Location = new System.Drawing.Point(16, 288);
			this.Label3.TabIndex = 16;
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Enabled = true;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.Controls.Add(cmdExit);
			this.Controls.Add(_picMode_0);
			this.Controls.Add(_picMode_1);
			this.Controls.Add(cmdNext);
			this.Controls.Add(Label4);
			this.Controls.Add(Label3);
			this._picMode_0.Controls.Add(txtCompany);
			this._picMode_0.Controls.Add(_lbl_0);
			this._picMode_0.Controls.Add(_lbl_1);
			this._picMode_0.Controls.Add(_lbl_2);
			this._picMode_0.Controls.Add(_lbl_3);
			this.ShapeContainer1.Shapes.Add(_Shape1_0);
			this.ShapeContainer1.Shapes.Add(_Shape1_1);
			this._picMode_0.Controls.Add(ShapeContainer1);
			this._picMode_1.Controls.Add(txtKey);
			this._picMode_1.Controls.Add(lblCompany);
			this._picMode_1.Controls.Add(_Label2_2);
			this._picMode_1.Controls.Add(_Label1_1);
			this._picMode_1.Controls.Add(_Label2_0);
			this._picMode_1.Controls.Add(lblCode);
			this._picMode_1.Controls.Add(_Label2_1);
			this.ShapeContainer2.Shapes.Add(_Shape1_2);
			this.ShapeContainer2.Shapes.Add(_Shape1_3);
			this._picMode_1.Controls.Add(ShapeContainer2);
			//Me.Label1.SetIndex(_Label1_1, CType(1, Short))
			//Me.Label2.SetIndex(_Label2_2, CType(2, Short))
			//Me.Label2.SetIndex(_Label2_0, CType(0, Short))
			//Me.Label2.SetIndex(_Label2_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_3, CType(3, Short))
			//Me.picMode.SetIndex(_picMode_0, CType(0, Short))
			//Me.picMode.SetIndex(_picMode_1, CType(1, Short))
			//Me.Shape1.SetIndex(_Shape1_0, CType(0, Short))
			//Me.Shape1.SetIndex(_Shape1_1, CType(1, Short))
			//Me.Shape1.SetIndex(_Shape1_2, CType(2, Short))
			//Me.Shape1.SetIndex(_Shape1_3, CType(3, Short))
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.picMode, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
			this._picMode_0.ResumeLayout(false);
			this._picMode_1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
