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
	partial class frmPricingGroup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmPricingGroup() : base()
		{
			FormClosed += frmPricingGroup_FormClosed;
			KeyPress += frmPricingGroup_KeyPress;
			Resize += frmPricingGroup_Resize;
			Load += frmPricingGroup_Load;
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
		public System.Windows.Forms.CheckBox chkPricing;
		public System.Windows.Forms.TextBox _txtFields_28;
		public System.Windows.Forms.TextBox _txtInteger_0;
		public System.Windows.Forms.TextBox _txtFloat_1;
		public System.Windows.Forms.TextBox _txtInteger_2;
		public System.Windows.Forms.TextBox _txtFloatNegative_0;
		public System.Windows.Forms.TextBox _txtFloatNegative_1;
		public System.Windows.Forms.TextBox _txtFloatNegative_2;
		public System.Windows.Forms.TextBox _txtFloatNegative_3;
		public System.Windows.Forms.TextBox _txtFloatNegative_4;
		public System.Windows.Forms.TextBox _txtFloatNegative_5;
		public System.Windows.Forms.TextBox _txtFloatNegative_6;
		public System.Windows.Forms.TextBox _txtFloatNegative_7;
		public System.Windows.Forms.TextBox _txtFloatNegative_8;
		public System.Windows.Forms.TextBox _txtFloatNegative_9;
		public System.Windows.Forms.TextBox _txtFloatNegative_10;
		public System.Windows.Forms.TextBox _txtFloatNegative_11;
		public System.Windows.Forms.TextBox _txtFloatNegative_12;
		public System.Windows.Forms.TextBox _txtFloatNegative_13;
		public System.Windows.Forms.TextBox _txtFloatNegative_14;
		public System.Windows.Forms.TextBox _txtFloatNegative_15;
		private System.Windows.Forms.Button withEventsField_cmdMatrix;
		public System.Windows.Forms.Button cmdMatrix {
			get { return withEventsField_cmdMatrix; }
			set {
				if (withEventsField_cmdMatrix != null) {
					withEventsField_cmdMatrix.Click -= cmdMatrix_Click;
				}
				withEventsField_cmdMatrix = value;
				if (withEventsField_cmdMatrix != null) {
					withEventsField_cmdMatrix.Click += cmdMatrix_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdPrint;
		public System.Windows.Forms.Button cmdPrint {
			get { return withEventsField_cmdPrint; }
			set {
				if (withEventsField_cmdPrint != null) {
					withEventsField_cmdPrint.Click -= cmdPrint_Click;
				}
				withEventsField_cmdPrint = value;
				if (withEventsField_cmdPrint != null) {
					withEventsField_cmdPrint.Click += cmdPrint_Click;
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
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_3;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label _lbl_10;
		public System.Windows.Forms.Label _lbl_18;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_3;
		public System.Windows.Forms.Label _lbl_4;
		public System.Windows.Forms.Label _lblLabels_38;
		public System.Windows.Forms.Label _lblLabels_34;
		public System.Windows.Forms.Label _lblLabels_33;
		public System.Windows.Forms.Label _lblCG_0;
		public System.Windows.Forms.Label _lblCG_1;
		public System.Windows.Forms.Label _lblCG_2;
		public System.Windows.Forms.Label _lblCG_3;
		public System.Windows.Forms.Label _lblCG_4;
		public System.Windows.Forms.Label _lblCG_5;
		public System.Windows.Forms.Label _lblCG_6;
		public System.Windows.Forms.Label _lblCG_7;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lbl_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public System.Windows.Forms.Label _lbl_5;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//	Public WithEvents lblCG As Microsoft.VisualBasic.Compatibility.VB6.LabelArray'
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtFloat As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtFloatNegative As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtInteger As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPricingGroup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.chkPricing = new System.Windows.Forms.CheckBox();
			this._txtFields_28 = new System.Windows.Forms.TextBox();
			this._txtInteger_0 = new System.Windows.Forms.TextBox();
			this._txtFloat_1 = new System.Windows.Forms.TextBox();
			this._txtInteger_2 = new System.Windows.Forms.TextBox();
			this._txtFloatNegative_0 = new System.Windows.Forms.TextBox();
			this._txtFloatNegative_1 = new System.Windows.Forms.TextBox();
			this._txtFloatNegative_2 = new System.Windows.Forms.TextBox();
			this._txtFloatNegative_3 = new System.Windows.Forms.TextBox();
			this._txtFloatNegative_4 = new System.Windows.Forms.TextBox();
			this._txtFloatNegative_5 = new System.Windows.Forms.TextBox();
			this._txtFloatNegative_6 = new System.Windows.Forms.TextBox();
			this._txtFloatNegative_7 = new System.Windows.Forms.TextBox();
			this._txtFloatNegative_8 = new System.Windows.Forms.TextBox();
			this._txtFloatNegative_9 = new System.Windows.Forms.TextBox();
			this._txtFloatNegative_10 = new System.Windows.Forms.TextBox();
			this._txtFloatNegative_11 = new System.Windows.Forms.TextBox();
			this._txtFloatNegative_12 = new System.Windows.Forms.TextBox();
			this._txtFloatNegative_13 = new System.Windows.Forms.TextBox();
			this._txtFloatNegative_14 = new System.Windows.Forms.TextBox();
			this._txtFloatNegative_15 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdMatrix = new System.Windows.Forms.Button();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this._Shape1_3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.Label1 = new System.Windows.Forms.Label();
			this._lbl_10 = new System.Windows.Forms.Label();
			this._lbl_18 = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_3 = new System.Windows.Forms.Label();
			this._lbl_4 = new System.Windows.Forms.Label();
			this._lblLabels_38 = new System.Windows.Forms.Label();
			this._lblLabels_34 = new System.Windows.Forms.Label();
			this._lblLabels_33 = new System.Windows.Forms.Label();
			this._lblCG_0 = new System.Windows.Forms.Label();
			this._lblCG_1 = new System.Windows.Forms.Label();
			this._lblCG_2 = new System.Windows.Forms.Label();
			this._lblCG_3 = new System.Windows.Forms.Label();
			this._lblCG_4 = new System.Windows.Forms.Label();
			this._lblCG_5 = new System.Windows.Forms.Label();
			this._lblCG_6 = new System.Windows.Forms.Label();
			this._lblCG_7 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._lbl_5 = new System.Windows.Forms.Label();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblCG = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			//Me.txtFloat = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			//M''e.txtFloatNegative = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			//Me.txtInteger = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblCG, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtFloat, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtFloatNegative, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Edit Pricing Group Details";
			this.ClientSize = new System.Drawing.Size(527, 351);
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
			this.Name = "frmPricingGroup";
			this.chkPricing.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkPricing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkPricing.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.chkPricing.Text = "Disable This Pricing Group";
			this.chkPricing.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkPricing.Size = new System.Drawing.Size(157, 19);
			this.chkPricing.Location = new System.Drawing.Point(352, 312);
			this.chkPricing.TabIndex = 44;
			this.chkPricing.CausesValidation = true;
			this.chkPricing.Enabled = true;
			this.chkPricing.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkPricing.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkPricing.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkPricing.TabStop = true;
			this.chkPricing.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkPricing.Visible = true;
			this.chkPricing.Name = "chkPricing";
			this._txtFields_28.AutoSize = false;
			this._txtFields_28.Size = new System.Drawing.Size(375, 19);
			this._txtFields_28.Location = new System.Drawing.Point(126, 66);
			this._txtFields_28.TabIndex = 5;
			this._txtFields_28.AcceptsReturn = true;
			this._txtFields_28.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_28.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_28.CausesValidation = true;
			this._txtFields_28.Enabled = true;
			this._txtFields_28.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_28.HideSelection = true;
			this._txtFields_28.ReadOnly = false;
			this._txtFields_28.MaxLength = 0;
			this._txtFields_28.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_28.Multiline = false;
			this._txtFields_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_28.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_28.TabStop = true;
			this._txtFields_28.Visible = true;
			this._txtFields_28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_28.Name = "_txtFields_28";
			this._txtInteger_0.AutoSize = false;
			this._txtInteger_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtInteger_0.Size = new System.Drawing.Size(52, 19);
			this._txtInteger_0.Location = new System.Drawing.Point(144, 159);
			this._txtInteger_0.TabIndex = 13;
			this._txtInteger_0.AcceptsReturn = true;
			this._txtInteger_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_0.CausesValidation = true;
			this._txtInteger_0.Enabled = true;
			this._txtInteger_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_0.HideSelection = true;
			this._txtInteger_0.ReadOnly = false;
			this._txtInteger_0.MaxLength = 0;
			this._txtInteger_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_0.Multiline = false;
			this._txtInteger_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtInteger_0.TabStop = true;
			this._txtInteger_0.Visible = true;
			this._txtInteger_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_0.Name = "_txtInteger_0";
			this._txtFloat_1.AutoSize = false;
			this._txtFloat_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloat_1.Size = new System.Drawing.Size(52, 19);
			this._txtFloat_1.Location = new System.Drawing.Point(207, 123);
			this._txtFloat_1.TabIndex = 8;
			this._txtFloat_1.AcceptsReturn = true;
			this._txtFloat_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_1.CausesValidation = true;
			this._txtFloat_1.Enabled = true;
			this._txtFloat_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_1.HideSelection = true;
			this._txtFloat_1.ReadOnly = false;
			this._txtFloat_1.MaxLength = 0;
			this._txtFloat_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_1.Multiline = false;
			this._txtFloat_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloat_1.TabStop = true;
			this._txtFloat_1.Visible = true;
			this._txtFloat_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_1.Name = "_txtFloat_1";
			this._txtInteger_2.AutoSize = false;
			this._txtInteger_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtInteger_2.Size = new System.Drawing.Size(52, 19);
			this._txtInteger_2.Location = new System.Drawing.Point(378, 123);
			this._txtInteger_2.TabIndex = 10;
			this._txtInteger_2.AcceptsReturn = true;
			this._txtInteger_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_2.CausesValidation = true;
			this._txtInteger_2.Enabled = true;
			this._txtInteger_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_2.HideSelection = true;
			this._txtInteger_2.ReadOnly = false;
			this._txtInteger_2.MaxLength = 0;
			this._txtInteger_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_2.Multiline = false;
			this._txtInteger_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtInteger_2.TabStop = true;
			this._txtInteger_2.Visible = true;
			this._txtInteger_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_2.Name = "_txtInteger_2";
			this._txtFloatNegative_0.AutoSize = false;
			this._txtFloatNegative_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloatNegative_0.Size = new System.Drawing.Size(49, 19);
			this._txtFloatNegative_0.Location = new System.Drawing.Point(93, 234);
			this._txtFloatNegative_0.TabIndex = 19;
			this._txtFloatNegative_0.Text = "999.99";
			this._txtFloatNegative_0.AcceptsReturn = true;
			this._txtFloatNegative_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloatNegative_0.CausesValidation = true;
			this._txtFloatNegative_0.Enabled = true;
			this._txtFloatNegative_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloatNegative_0.HideSelection = true;
			this._txtFloatNegative_0.ReadOnly = false;
			this._txtFloatNegative_0.MaxLength = 0;
			this._txtFloatNegative_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloatNegative_0.Multiline = false;
			this._txtFloatNegative_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloatNegative_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloatNegative_0.TabStop = true;
			this._txtFloatNegative_0.Visible = true;
			this._txtFloatNegative_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloatNegative_0.Name = "_txtFloatNegative_0";
			this._txtFloatNegative_1.AutoSize = false;
			this._txtFloatNegative_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloatNegative_1.Size = new System.Drawing.Size(49, 19);
			this._txtFloatNegative_1.Location = new System.Drawing.Point(93, 252);
			this._txtFloatNegative_1.TabIndex = 20;
			this._txtFloatNegative_1.AcceptsReturn = true;
			this._txtFloatNegative_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloatNegative_1.CausesValidation = true;
			this._txtFloatNegative_1.Enabled = true;
			this._txtFloatNegative_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloatNegative_1.HideSelection = true;
			this._txtFloatNegative_1.ReadOnly = false;
			this._txtFloatNegative_1.MaxLength = 0;
			this._txtFloatNegative_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloatNegative_1.Multiline = false;
			this._txtFloatNegative_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloatNegative_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloatNegative_1.TabStop = true;
			this._txtFloatNegative_1.Visible = true;
			this._txtFloatNegative_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloatNegative_1.Name = "_txtFloatNegative_1";
			this._txtFloatNegative_2.AutoSize = false;
			this._txtFloatNegative_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloatNegative_2.Size = new System.Drawing.Size(49, 19);
			this._txtFloatNegative_2.Location = new System.Drawing.Point(144, 234);
			this._txtFloatNegative_2.TabIndex = 22;
			this._txtFloatNegative_2.AcceptsReturn = true;
			this._txtFloatNegative_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloatNegative_2.CausesValidation = true;
			this._txtFloatNegative_2.Enabled = true;
			this._txtFloatNegative_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloatNegative_2.HideSelection = true;
			this._txtFloatNegative_2.ReadOnly = false;
			this._txtFloatNegative_2.MaxLength = 0;
			this._txtFloatNegative_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloatNegative_2.Multiline = false;
			this._txtFloatNegative_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloatNegative_2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloatNegative_2.TabStop = true;
			this._txtFloatNegative_2.Visible = true;
			this._txtFloatNegative_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloatNegative_2.Name = "_txtFloatNegative_2";
			this._txtFloatNegative_3.AutoSize = false;
			this._txtFloatNegative_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloatNegative_3.Size = new System.Drawing.Size(49, 19);
			this._txtFloatNegative_3.Location = new System.Drawing.Point(144, 252);
			this._txtFloatNegative_3.TabIndex = 23;
			this._txtFloatNegative_3.AcceptsReturn = true;
			this._txtFloatNegative_3.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloatNegative_3.CausesValidation = true;
			this._txtFloatNegative_3.Enabled = true;
			this._txtFloatNegative_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloatNegative_3.HideSelection = true;
			this._txtFloatNegative_3.ReadOnly = false;
			this._txtFloatNegative_3.MaxLength = 0;
			this._txtFloatNegative_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloatNegative_3.Multiline = false;
			this._txtFloatNegative_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloatNegative_3.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloatNegative_3.TabStop = true;
			this._txtFloatNegative_3.Visible = true;
			this._txtFloatNegative_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloatNegative_3.Name = "_txtFloatNegative_3";
			this._txtFloatNegative_4.AutoSize = false;
			this._txtFloatNegative_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloatNegative_4.Size = new System.Drawing.Size(49, 19);
			this._txtFloatNegative_4.Location = new System.Drawing.Point(195, 234);
			this._txtFloatNegative_4.TabIndex = 25;
			this._txtFloatNegative_4.AcceptsReturn = true;
			this._txtFloatNegative_4.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloatNegative_4.CausesValidation = true;
			this._txtFloatNegative_4.Enabled = true;
			this._txtFloatNegative_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloatNegative_4.HideSelection = true;
			this._txtFloatNegative_4.ReadOnly = false;
			this._txtFloatNegative_4.MaxLength = 0;
			this._txtFloatNegative_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloatNegative_4.Multiline = false;
			this._txtFloatNegative_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloatNegative_4.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloatNegative_4.TabStop = true;
			this._txtFloatNegative_4.Visible = true;
			this._txtFloatNegative_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloatNegative_4.Name = "_txtFloatNegative_4";
			this._txtFloatNegative_5.AutoSize = false;
			this._txtFloatNegative_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloatNegative_5.Size = new System.Drawing.Size(49, 19);
			this._txtFloatNegative_5.Location = new System.Drawing.Point(195, 252);
			this._txtFloatNegative_5.TabIndex = 26;
			this._txtFloatNegative_5.AcceptsReturn = true;
			this._txtFloatNegative_5.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloatNegative_5.CausesValidation = true;
			this._txtFloatNegative_5.Enabled = true;
			this._txtFloatNegative_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloatNegative_5.HideSelection = true;
			this._txtFloatNegative_5.ReadOnly = false;
			this._txtFloatNegative_5.MaxLength = 0;
			this._txtFloatNegative_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloatNegative_5.Multiline = false;
			this._txtFloatNegative_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloatNegative_5.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloatNegative_5.TabStop = true;
			this._txtFloatNegative_5.Visible = true;
			this._txtFloatNegative_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloatNegative_5.Name = "_txtFloatNegative_5";
			this._txtFloatNegative_6.AutoSize = false;
			this._txtFloatNegative_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloatNegative_6.Size = new System.Drawing.Size(49, 19);
			this._txtFloatNegative_6.Location = new System.Drawing.Point(246, 234);
			this._txtFloatNegative_6.TabIndex = 28;
			this._txtFloatNegative_6.AcceptsReturn = true;
			this._txtFloatNegative_6.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloatNegative_6.CausesValidation = true;
			this._txtFloatNegative_6.Enabled = true;
			this._txtFloatNegative_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloatNegative_6.HideSelection = true;
			this._txtFloatNegative_6.ReadOnly = false;
			this._txtFloatNegative_6.MaxLength = 0;
			this._txtFloatNegative_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloatNegative_6.Multiline = false;
			this._txtFloatNegative_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloatNegative_6.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloatNegative_6.TabStop = true;
			this._txtFloatNegative_6.Visible = true;
			this._txtFloatNegative_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloatNegative_6.Name = "_txtFloatNegative_6";
			this._txtFloatNegative_7.AutoSize = false;
			this._txtFloatNegative_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloatNegative_7.Size = new System.Drawing.Size(49, 19);
			this._txtFloatNegative_7.Location = new System.Drawing.Point(246, 252);
			this._txtFloatNegative_7.TabIndex = 29;
			this._txtFloatNegative_7.AcceptsReturn = true;
			this._txtFloatNegative_7.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloatNegative_7.CausesValidation = true;
			this._txtFloatNegative_7.Enabled = true;
			this._txtFloatNegative_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloatNegative_7.HideSelection = true;
			this._txtFloatNegative_7.ReadOnly = false;
			this._txtFloatNegative_7.MaxLength = 0;
			this._txtFloatNegative_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloatNegative_7.Multiline = false;
			this._txtFloatNegative_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloatNegative_7.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloatNegative_7.TabStop = true;
			this._txtFloatNegative_7.Visible = true;
			this._txtFloatNegative_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloatNegative_7.Name = "_txtFloatNegative_7";
			this._txtFloatNegative_8.AutoSize = false;
			this._txtFloatNegative_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloatNegative_8.Size = new System.Drawing.Size(49, 19);
			this._txtFloatNegative_8.Location = new System.Drawing.Point(297, 234);
			this._txtFloatNegative_8.TabIndex = 31;
			this._txtFloatNegative_8.AcceptsReturn = true;
			this._txtFloatNegative_8.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloatNegative_8.CausesValidation = true;
			this._txtFloatNegative_8.Enabled = true;
			this._txtFloatNegative_8.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloatNegative_8.HideSelection = true;
			this._txtFloatNegative_8.ReadOnly = false;
			this._txtFloatNegative_8.MaxLength = 0;
			this._txtFloatNegative_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloatNegative_8.Multiline = false;
			this._txtFloatNegative_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloatNegative_8.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloatNegative_8.TabStop = true;
			this._txtFloatNegative_8.Visible = true;
			this._txtFloatNegative_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloatNegative_8.Name = "_txtFloatNegative_8";
			this._txtFloatNegative_9.AutoSize = false;
			this._txtFloatNegative_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloatNegative_9.Size = new System.Drawing.Size(49, 19);
			this._txtFloatNegative_9.Location = new System.Drawing.Point(297, 252);
			this._txtFloatNegative_9.TabIndex = 32;
			this._txtFloatNegative_9.AcceptsReturn = true;
			this._txtFloatNegative_9.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloatNegative_9.CausesValidation = true;
			this._txtFloatNegative_9.Enabled = true;
			this._txtFloatNegative_9.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloatNegative_9.HideSelection = true;
			this._txtFloatNegative_9.ReadOnly = false;
			this._txtFloatNegative_9.MaxLength = 0;
			this._txtFloatNegative_9.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloatNegative_9.Multiline = false;
			this._txtFloatNegative_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloatNegative_9.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloatNegative_9.TabStop = true;
			this._txtFloatNegative_9.Visible = true;
			this._txtFloatNegative_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloatNegative_9.Name = "_txtFloatNegative_9";
			this._txtFloatNegative_10.AutoSize = false;
			this._txtFloatNegative_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloatNegative_10.Size = new System.Drawing.Size(49, 19);
			this._txtFloatNegative_10.Location = new System.Drawing.Point(348, 234);
			this._txtFloatNegative_10.TabIndex = 34;
			this._txtFloatNegative_10.AcceptsReturn = true;
			this._txtFloatNegative_10.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloatNegative_10.CausesValidation = true;
			this._txtFloatNegative_10.Enabled = true;
			this._txtFloatNegative_10.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloatNegative_10.HideSelection = true;
			this._txtFloatNegative_10.ReadOnly = false;
			this._txtFloatNegative_10.MaxLength = 0;
			this._txtFloatNegative_10.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloatNegative_10.Multiline = false;
			this._txtFloatNegative_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloatNegative_10.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloatNegative_10.TabStop = true;
			this._txtFloatNegative_10.Visible = true;
			this._txtFloatNegative_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloatNegative_10.Name = "_txtFloatNegative_10";
			this._txtFloatNegative_11.AutoSize = false;
			this._txtFloatNegative_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloatNegative_11.Size = new System.Drawing.Size(49, 19);
			this._txtFloatNegative_11.Location = new System.Drawing.Point(348, 252);
			this._txtFloatNegative_11.TabIndex = 35;
			this._txtFloatNegative_11.AcceptsReturn = true;
			this._txtFloatNegative_11.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloatNegative_11.CausesValidation = true;
			this._txtFloatNegative_11.Enabled = true;
			this._txtFloatNegative_11.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloatNegative_11.HideSelection = true;
			this._txtFloatNegative_11.ReadOnly = false;
			this._txtFloatNegative_11.MaxLength = 0;
			this._txtFloatNegative_11.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloatNegative_11.Multiline = false;
			this._txtFloatNegative_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloatNegative_11.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloatNegative_11.TabStop = true;
			this._txtFloatNegative_11.Visible = true;
			this._txtFloatNegative_11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloatNegative_11.Name = "_txtFloatNegative_11";
			this._txtFloatNegative_12.AutoSize = false;
			this._txtFloatNegative_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloatNegative_12.Size = new System.Drawing.Size(49, 19);
			this._txtFloatNegative_12.Location = new System.Drawing.Point(399, 234);
			this._txtFloatNegative_12.TabIndex = 37;
			this._txtFloatNegative_12.AcceptsReturn = true;
			this._txtFloatNegative_12.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloatNegative_12.CausesValidation = true;
			this._txtFloatNegative_12.Enabled = true;
			this._txtFloatNegative_12.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloatNegative_12.HideSelection = true;
			this._txtFloatNegative_12.ReadOnly = false;
			this._txtFloatNegative_12.MaxLength = 0;
			this._txtFloatNegative_12.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloatNegative_12.Multiline = false;
			this._txtFloatNegative_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloatNegative_12.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloatNegative_12.TabStop = true;
			this._txtFloatNegative_12.Visible = true;
			this._txtFloatNegative_12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloatNegative_12.Name = "_txtFloatNegative_12";
			this._txtFloatNegative_13.AutoSize = false;
			this._txtFloatNegative_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloatNegative_13.Size = new System.Drawing.Size(49, 19);
			this._txtFloatNegative_13.Location = new System.Drawing.Point(399, 252);
			this._txtFloatNegative_13.TabIndex = 38;
			this._txtFloatNegative_13.AcceptsReturn = true;
			this._txtFloatNegative_13.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloatNegative_13.CausesValidation = true;
			this._txtFloatNegative_13.Enabled = true;
			this._txtFloatNegative_13.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloatNegative_13.HideSelection = true;
			this._txtFloatNegative_13.ReadOnly = false;
			this._txtFloatNegative_13.MaxLength = 0;
			this._txtFloatNegative_13.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloatNegative_13.Multiline = false;
			this._txtFloatNegative_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloatNegative_13.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloatNegative_13.TabStop = true;
			this._txtFloatNegative_13.Visible = true;
			this._txtFloatNegative_13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloatNegative_13.Name = "_txtFloatNegative_13";
			this._txtFloatNegative_14.AutoSize = false;
			this._txtFloatNegative_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloatNegative_14.Size = new System.Drawing.Size(49, 19);
			this._txtFloatNegative_14.Location = new System.Drawing.Point(450, 234);
			this._txtFloatNegative_14.TabIndex = 40;
			this._txtFloatNegative_14.AcceptsReturn = true;
			this._txtFloatNegative_14.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloatNegative_14.CausesValidation = true;
			this._txtFloatNegative_14.Enabled = true;
			this._txtFloatNegative_14.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloatNegative_14.HideSelection = true;
			this._txtFloatNegative_14.ReadOnly = false;
			this._txtFloatNegative_14.MaxLength = 0;
			this._txtFloatNegative_14.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloatNegative_14.Multiline = false;
			this._txtFloatNegative_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloatNegative_14.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloatNegative_14.TabStop = true;
			this._txtFloatNegative_14.Visible = true;
			this._txtFloatNegative_14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloatNegative_14.Name = "_txtFloatNegative_14";
			this._txtFloatNegative_15.AutoSize = false;
			this._txtFloatNegative_15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloatNegative_15.Size = new System.Drawing.Size(49, 19);
			this._txtFloatNegative_15.Location = new System.Drawing.Point(450, 252);
			this._txtFloatNegative_15.TabIndex = 41;
			this._txtFloatNegative_15.AcceptsReturn = true;
			this._txtFloatNegative_15.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloatNegative_15.CausesValidation = true;
			this._txtFloatNegative_15.Enabled = true;
			this._txtFloatNegative_15.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloatNegative_15.HideSelection = true;
			this._txtFloatNegative_15.ReadOnly = false;
			this._txtFloatNegative_15.MaxLength = 0;
			this._txtFloatNegative_15.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloatNegative_15.Multiline = false;
			this._txtFloatNegative_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloatNegative_15.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloatNegative_15.TabStop = true;
			this._txtFloatNegative_15.Visible = true;
			this._txtFloatNegative_15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloatNegative_15.Name = "_txtFloatNegative_15";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(527, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 2;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdMatrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMatrix.Text = "Pricing Matrix";
			this.cmdMatrix.Size = new System.Drawing.Size(81, 29);
			this.cmdMatrix.Location = new System.Drawing.Point(104, 3);
			this.cmdMatrix.TabIndex = 45;
			this.cmdMatrix.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMatrix.CausesValidation = true;
			this.cmdMatrix.Enabled = true;
			this.cmdMatrix.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMatrix.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMatrix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMatrix.TabStop = true;
			this.cmdMatrix.Name = "cmdMatrix";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.Size = new System.Drawing.Size(73, 29);
			this.cmdPrint.Location = new System.Drawing.Point(345, 3);
			this.cmdPrint.TabIndex = 42;
			this.cmdPrint.TabStop = false;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.Location = new System.Drawing.Point(5, 3);
			this.cmdCancel.TabIndex = 1;
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
			this.cmdClose.Location = new System.Drawing.Point(441, 3);
			this.cmdClose.TabIndex = 0;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this._Shape1_3.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_3.Size = new System.Drawing.Size(502, 35);
			this._Shape1_3.Location = new System.Drawing.Point(14, 304);
			this._Shape1_3.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_3.BorderWidth = 1;
			this._Shape1_3.FillColor = System.Drawing.Color.Black;
			this._Shape1_3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_3.Visible = true;
			this._Shape1_3.Name = "_Shape1_3";
			this.Label1.Text = "&4 Disabled Pricing Group";
			this.Label1.Size = new System.Drawing.Size(193, 17);
			this.Label1.Location = new System.Drawing.Point(16, 288);
			this.Label1.TabIndex = 43;
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
			this._lbl_10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_10.Text = "When a Stock Item value is over";
			this._lbl_10.Size = new System.Drawing.Size(157, 13);
			this._lbl_10.Location = new System.Drawing.Point(48, 126);
			this._lbl_10.TabIndex = 7;
			this._lbl_10.BackColor = System.Drawing.Color.Transparent;
			this._lbl_10.Enabled = true;
			this._lbl_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_10.UseMnemonic = true;
			this._lbl_10.Visible = true;
			this._lbl_10.AutoSize = true;
			this._lbl_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_10.Name = "_lbl_10";
			this._lbl_18.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_18.Text = "round all amounts below";
			this._lbl_18.Size = new System.Drawing.Size(115, 13);
			this._lbl_18.Location = new System.Drawing.Point(258, 126);
			this._lbl_18.TabIndex = 9;
			this._lbl_18.BackColor = System.Drawing.Color.Transparent;
			this._lbl_18.Enabled = true;
			this._lbl_18.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_18.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_18.UseMnemonic = true;
			this._lbl_18.Visible = true;
			this._lbl_18.AutoSize = true;
			this._lbl_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_18.Name = "_lbl_18";
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_2.Text = " value, then remove ";
			this._lbl_2.Size = new System.Drawing.Size(97, 13);
			this._lbl_2.Location = new System.Drawing.Point(45, 162);
			this._lbl_2.TabIndex = 12;
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
			this._lbl_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_3.Text = "cents to the lower Rand value, else the amount is rounded to the next highest Rand";
			this._lbl_3.Size = new System.Drawing.Size(394, 13);
			this._lbl_3.Location = new System.Drawing.Point(48, 144);
			this._lbl_3.TabIndex = 11;
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
			this._lbl_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_4.Text = "cents from the rounded stock item Rand value.";
			this._lbl_4.Size = new System.Drawing.Size(223, 13);
			this._lbl_4.Location = new System.Drawing.Point(195, 162);
			this._lbl_4.TabIndex = 14;
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
			this._lblLabels_38.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_38.Text = "Pricing Group Name:";
			this._lblLabels_38.Size = new System.Drawing.Size(98, 13);
			this._lblLabels_38.Location = new System.Drawing.Point(23, 69);
			this._lblLabels_38.TabIndex = 4;
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
			this._lblLabels_34.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_34.Text = "Unit:";
			this._lblLabels_34.Size = new System.Drawing.Size(22, 13);
			this._lblLabels_34.Location = new System.Drawing.Point(66, 235);
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
			this._lblLabels_33.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_33.Text = "Case/Carton:";
			this._lblLabels_33.Size = new System.Drawing.Size(63, 13);
			this._lblLabels_33.Location = new System.Drawing.Point(25, 254);
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
			this._lblCG_0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblCG_0.Text = "PricingGroup_Unit3:";
			this._lblCG_0.Size = new System.Drawing.Size(49, 13);
			this._lblCG_0.Location = new System.Drawing.Point(93, 222);
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
			this._lblCG_1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblCG_1.Text = "PricingGroup_Case3:";
			this._lblCG_1.Size = new System.Drawing.Size(49, 13);
			this._lblCG_1.Location = new System.Drawing.Point(144, 222);
			this._lblCG_1.TabIndex = 21;
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
			this._lblCG_2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblCG_2.Text = "PricingGroup_Unit4:";
			this._lblCG_2.Size = new System.Drawing.Size(49, 13);
			this._lblCG_2.Location = new System.Drawing.Point(195, 222);
			this._lblCG_2.TabIndex = 24;
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
			this._lblCG_3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblCG_3.Text = "PricingGroup_Case4:";
			this._lblCG_3.Size = new System.Drawing.Size(49, 13);
			this._lblCG_3.Location = new System.Drawing.Point(246, 222);
			this._lblCG_3.TabIndex = 27;
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
			this._lblCG_4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblCG_4.Text = "PricingGroup_Unit5:";
			this._lblCG_4.Size = new System.Drawing.Size(49, 13);
			this._lblCG_4.Location = new System.Drawing.Point(297, 222);
			this._lblCG_4.TabIndex = 30;
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
			this._lblCG_5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblCG_5.Text = "PricingGroup_Case5:";
			this._lblCG_5.Size = new System.Drawing.Size(49, 13);
			this._lblCG_5.Location = new System.Drawing.Point(348, 222);
			this._lblCG_5.TabIndex = 33;
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
			this._lblCG_6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblCG_6.Text = "PricingGroup_Unit6:";
			this._lblCG_6.Size = new System.Drawing.Size(49, 13);
			this._lblCG_6.Location = new System.Drawing.Point(399, 222);
			this._lblCG_6.TabIndex = 36;
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
			this._lblCG_7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblCG_7.Text = "PricingGroup_Case6:";
			this._lblCG_7.Size = new System.Drawing.Size(49, 13);
			this._lblCG_7.Location = new System.Drawing.Point(450, 222);
			this._lblCG_7.TabIndex = 39;
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
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Text = "&3. Default Pricing Markup Percentage";
			this._lbl_1.Size = new System.Drawing.Size(215, 13);
			this._lbl_1.Location = new System.Drawing.Point(15, 201);
			this._lbl_1.TabIndex = 15;
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
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Text = "&2. Pricing Rules";
			this._lbl_0.Size = new System.Drawing.Size(283, 13);
			this._lbl_0.Location = new System.Drawing.Point(15, 102);
			this._lbl_0.TabIndex = 6;
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
			this._Shape1_0.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_0.Size = new System.Drawing.Size(502, 70);
			this._Shape1_0.Location = new System.Drawing.Point(15, 117);
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_0.BorderWidth = 1;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_0.Visible = true;
			this._Shape1_0.Name = "_Shape1_0";
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.Size = new System.Drawing.Size(502, 67);
			this._Shape1_1.Location = new System.Drawing.Point(15, 216);
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_1.BorderWidth = 1;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_1.Visible = true;
			this._Shape1_1.Name = "_Shape1_1";
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(502, 31);
			this._Shape1_2.Location = new System.Drawing.Point(15, 60);
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_2.BorderWidth = 1;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_2.Visible = true;
			this._Shape1_2.Name = "_Shape1_2";
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Text = "&1. General";
			this._lbl_5.Size = new System.Drawing.Size(60, 13);
			this._lbl_5.Location = new System.Drawing.Point(15, 45);
			this._lbl_5.TabIndex = 3;
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
			this.Controls.Add(chkPricing);
			this.Controls.Add(_txtFields_28);
			this.Controls.Add(_txtInteger_0);
			this.Controls.Add(_txtFloat_1);
			this.Controls.Add(_txtInteger_2);
			this.Controls.Add(_txtFloatNegative_0);
			this.Controls.Add(_txtFloatNegative_1);
			this.Controls.Add(_txtFloatNegative_2);
			this.Controls.Add(_txtFloatNegative_3);
			this.Controls.Add(_txtFloatNegative_4);
			this.Controls.Add(_txtFloatNegative_5);
			this.Controls.Add(_txtFloatNegative_6);
			this.Controls.Add(_txtFloatNegative_7);
			this.Controls.Add(_txtFloatNegative_8);
			this.Controls.Add(_txtFloatNegative_9);
			this.Controls.Add(_txtFloatNegative_10);
			this.Controls.Add(_txtFloatNegative_11);
			this.Controls.Add(_txtFloatNegative_12);
			this.Controls.Add(_txtFloatNegative_13);
			this.Controls.Add(_txtFloatNegative_14);
			this.Controls.Add(_txtFloatNegative_15);
			this.Controls.Add(picButtons);
			this.ShapeContainer1.Shapes.Add(_Shape1_3);
			this.Controls.Add(Label1);
			this.Controls.Add(_lbl_10);
			this.Controls.Add(_lbl_18);
			this.Controls.Add(_lbl_2);
			this.Controls.Add(_lbl_3);
			this.Controls.Add(_lbl_4);
			this.Controls.Add(_lblLabels_38);
			this.Controls.Add(_lblLabels_34);
			this.Controls.Add(_lblLabels_33);
			this.Controls.Add(_lblCG_0);
			this.Controls.Add(_lblCG_1);
			this.Controls.Add(_lblCG_2);
			this.Controls.Add(_lblCG_3);
			this.Controls.Add(_lblCG_4);
			this.Controls.Add(_lblCG_5);
			this.Controls.Add(_lblCG_6);
			this.Controls.Add(_lblCG_7);
			this.Controls.Add(_lbl_1);
			this.Controls.Add(_lbl_0);
			this.ShapeContainer1.Shapes.Add(_Shape1_0);
			this.ShapeContainer1.Shapes.Add(_Shape1_1);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.Controls.Add(_lbl_5);
			this.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(cmdMatrix);
			this.picButtons.Controls.Add(cmdPrint);
			this.picButtons.Controls.Add(cmdCancel);
			this.picButtons.Controls.Add(cmdClose);
			//Me.lbl.SetIndex(_lbl_10, CType(10, Short))
			//Me.lbl.SetIndex(_lbl_18, CType(18, Short))
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_3, CType(3, Short))
			//Me.lbl.SetIndex(_lbl_4, CType(4, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			//Me.lblCG.SetIndex(_lblCG_0, CType(0, Short))
			//Me.lblCG.SetIndex(_lblCG_1, CType(1, Short))
			//Me.lblCG.SetIndex(_lblCG_2, CType(2, Short))
			//Me.lblCG.SetIndex(_lblCG_3, CType(3, Short))
			//Me.lblCG.SetIndex(_lblCG_4, CType(4, Short))
			//Me.lblCG.SetIndex(_lblCG_5, CType(5, Short))
			//Me.lblCG.SetIndex(_lblCG_6, CType(6, Short))
			//Me.lblCG.SetIndex(_lblCG_7, CType(7, Short))
			//Me.lblLabels.SetIndex(_lblLabels_38, CType(38, Short))
			//Me.lblLabels.SetIndex(_lblLabels_34, CType(34, Short))
			//Me.lblLabels.SetIndex(_lblLabels_33, CType(33, Short))
			//Me.txtFields.SetIndex(_txtFields_28, CType(28, Short))
			//Me.txtFloat.SetIndex(_txtFloat_1, CType(1, Short))
			//Me.txtFloatNegative.SetIndex(_txtFloatNegative_0, CType(0, Short))
			//Me.txtFloatNegative.SetIndex(_txtFloatNegative_1, CType(1, Short))
			//Me.txtFloatNegative.SetIndex(_txtFloatNegative_2, CType(2, Short))
			//Me.txtFloatNegative.SetIndex(_txtFloatNegative_3, CType(3, Short))
			//Me.txtFloatNegative.SetIndex(_txtFloatNegative_4, CType(4, Short))
			//Me.txtFloatNegative.SetIndex(_txtFloatNegative_5, CType(5, Short))
			//Me.txtFloatNegative.SetIndex(_txtFloatNegative_6, CType(6, Short))
			//Me.txtFloatNegative.SetIndex(_txtFloatNegative_7, CType(7, Short))
			//Me.txtFloatNegative.SetIndex(_txtFloatNegative_8, CType(8, Short))
			//Me.txtFloatNegative.SetIndex(_txtFloatNegative_9, CType(9, Short))
			//Me.txtFloatNegative.SetIndex(_txtFloatNegative_10, CType(10, Short))
			//Me.txtFloatNegative.SetIndex(_txtFloatNegative_11, CType(11, Short))
			//Me.txtFloatNegative.SetIndex(_txtFloatNegative_12, CType(12, Short))
			//Me.txtFloatNegative.SetIndex(_txtFloatNegative_13, CType(13, Short))
			//Me.txtFloatNegative.SetIndex(_txtFloatNegative_14, CType(14, Short))
			//Me.txtFloatNegative.SetIndex(_txtFloatNegative_15, CType(15, Short))
			//Me.txtInteger.SetIndex(_txtInteger_0, CType(0, Short))
			//Me.txtInteger.SetIndex(_txtInteger_2, CType(2, Short))
			this.Shape1.SetIndex(_Shape1_3, Convert.ToInt16(3));
			this.Shape1.SetIndex(_Shape1_0, Convert.ToInt16(0));
			this.Shape1.SetIndex(_Shape1_1, Convert.ToInt16(1));
			this.Shape1.SetIndex(_Shape1_2, Convert.ToInt16(2));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.txtFloatNegative, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.txtFloat, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
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
