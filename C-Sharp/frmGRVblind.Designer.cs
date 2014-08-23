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
	partial class frmGRVblind
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmGRVblind() : base()
		{
			Load += frmGRVblind_Load;
			KeyPress += frmGRVblind_KeyPress;
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
		private System.Windows.Forms.Button withEventsField_cmdProceed;
		public System.Windows.Forms.Button cmdProceed {
			get { return withEventsField_cmdProceed; }
			set {
				if (withEventsField_cmdProceed != null) {
					withEventsField_cmdProceed.Click -= cmdProceed_Click;
				}
				withEventsField_cmdProceed = value;
				if (withEventsField_cmdProceed != null) {
					withEventsField_cmdProceed.Click += cmdProceed_Click;
				}
			}
		}
		public System.Windows.Forms.Label lblData;
		public System.Windows.Forms.Label _lbl_4;
		public Microsoft.VisualBasic.PowerPacks.LineShape Line1;
		public System.Windows.Forms.Label lblRepNumber;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label lblRepName;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label lblName;
		public System.Windows.Forms.GroupBox _frmMode_1;
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
		public System.Windows.Forms.ImageList ilHeading;
		private System.Windows.Forms.ListBox withEventsField_lstSupplier;
		public System.Windows.Forms.ListBox lstSupplier {
			get { return withEventsField_lstSupplier; }
			set {
				if (withEventsField_lstSupplier != null) {
					withEventsField_lstSupplier.SelectedIndexChanged -= lstSupplier_SelectedIndexChanged;
					withEventsField_lstSupplier.DoubleClick -= lstSupplier_DoubleClick;
					withEventsField_lstSupplier.KeyPress -= lstSupplier_KeyPress;
				}
				withEventsField_lstSupplier = value;
				if (withEventsField_lstSupplier != null) {
					withEventsField_lstSupplier.SelectedIndexChanged += lstSupplier_SelectedIndexChanged;
					withEventsField_lstSupplier.DoubleClick += lstSupplier_DoubleClick;
					withEventsField_lstSupplier.KeyPress += lstSupplier_KeyPress;
				}
			}
		}
		public System.Windows.Forms.GroupBox _frmMode_0;
		public System.Windows.Forms.Label Label1;
		//Public WithEvents frmMode As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGRVblind));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this._frmMode_1 = new System.Windows.Forms.GroupBox();
			this.cmdProceed = new System.Windows.Forms.Button();
			this.lblData = new System.Windows.Forms.Label();
			this._lbl_4 = new System.Windows.Forms.Label();
			this.Line1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.lblRepNumber = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this.lblRepName = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.cmdNext = new System.Windows.Forms.Button();
			this.cmdBack = new System.Windows.Forms.Button();
			this.ilHeading = new System.Windows.Forms.ImageList();
			this._frmMode_0 = new System.Windows.Forms.GroupBox();
			this.lstSupplier = new System.Windows.Forms.ListBox();
			this.Label1 = new System.Windows.Forms.Label();
			//Me.frmMode = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this._frmMode_1.SuspendLayout();
			this._frmMode_0.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.frmMode, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			this.ControlBox = false;
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.ClientSize = new System.Drawing.Size(377, 434);
			this.Location = new System.Drawing.Point(3, 3);
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
			this.Name = "frmGRVblind";
			this._frmMode_1.Text = "Supplier Details";
			this._frmMode_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmMode_1.Size = new System.Drawing.Size(352, 349);
			this._frmMode_1.Location = new System.Drawing.Point(12, 39);
			this._frmMode_1.TabIndex = 3;
			this._frmMode_1.Visible = false;
			this._frmMode_1.BackColor = System.Drawing.SystemColors.Control;
			this._frmMode_1.Enabled = true;
			this._frmMode_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmMode_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmMode_1.Padding = new System.Windows.Forms.Padding(0);
			this._frmMode_1.Name = "_frmMode_1";
			this.cmdProceed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdProceed.Text = "&Create Purchase Order";
			this.cmdProceed.Size = new System.Drawing.Size(127, 28);
			this.cmdProceed.Location = new System.Drawing.Point(216, 312);
			this.cmdProceed.TabIndex = 12;
			this.cmdProceed.BackColor = System.Drawing.SystemColors.Control;
			this.cmdProceed.CausesValidation = true;
			this.cmdProceed.Enabled = true;
			this.cmdProceed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdProceed.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdProceed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdProceed.TabStop = true;
			this.cmdProceed.Name = "cmdProceed";
			this.lblData.Text = "By clicking the \"Create Purchase Order\" button, you will create a blank purchase order for the above supplier. You will then be prompted for the invoice details and proceed to the GRV product capture screen.";
			this.lblData.Size = new System.Drawing.Size(334, 151);
			this.lblData.Location = new System.Drawing.Point(3, 120);
			this.lblData.TabIndex = 11;
			this.lblData.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblData.BackColor = System.Drawing.SystemColors.Control;
			this.lblData.Enabled = true;
			this.lblData.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblData.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblData.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblData.UseMnemonic = true;
			this.lblData.Visible = true;
			this.lblData.AutoSize = false;
			this.lblData.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblData.Name = "lblData";
			this._lbl_4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lbl_4.BackColor = System.Drawing.Color.Blue;
			this._lbl_4.Text = "Create New Purchase Order";
			this._lbl_4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_4.ForeColor = System.Drawing.Color.White;
			this._lbl_4.Size = new System.Drawing.Size(347, 17);
			this._lbl_4.Location = new System.Drawing.Point(3, 93);
			this._lbl_4.TabIndex = 10;
			this._lbl_4.Enabled = true;
			this._lbl_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_4.UseMnemonic = true;
			this._lbl_4.Visible = true;
			this._lbl_4.AutoSize = false;
			this._lbl_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lbl_4.Name = "_lbl_4";
			this.Line1.X1 = 342;
			this.Line1.X2 = 12;
			this.Line1.Y1 = 74;
			this.Line1.Y2 = 74;
			this.Line1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Line1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.Line1.BorderWidth = 1;
			this.Line1.Visible = true;
			this.Line1.Name = "Line1";
			this.lblRepNumber.BackColor = System.Drawing.SystemColors.Window;
			this.lblRepNumber.Text = "lblRepNumber";
			this.lblRepNumber.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblRepNumber.Size = new System.Drawing.Size(91, 16);
			this.lblRepNumber.Location = new System.Drawing.Point(252, 63);
			this.lblRepNumber.TabIndex = 9;
			this.lblRepNumber.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblRepNumber.Enabled = true;
			this.lblRepNumber.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblRepNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblRepNumber.UseMnemonic = true;
			this.lblRepNumber.Visible = true;
			this.lblRepNumber.AutoSize = false;
			this.lblRepNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblRepNumber.Name = "lblRepNumber";
			this._lbl_1.Text = "Representative Name";
			this._lbl_1.Size = new System.Drawing.Size(103, 13);
			this._lbl_1.Location = new System.Drawing.Point(12, 51);
			this._lbl_1.TabIndex = 8;
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
			this.lblRepName.BackColor = System.Drawing.SystemColors.Window;
			this.lblRepName.Text = "lblRepName";
			this.lblRepName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblRepName.Size = new System.Drawing.Size(238, 16);
			this.lblRepName.Location = new System.Drawing.Point(12, 63);
			this.lblRepName.TabIndex = 7;
			this.lblRepName.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblRepName.Enabled = true;
			this.lblRepName.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblRepName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblRepName.UseMnemonic = true;
			this.lblRepName.Visible = true;
			this.lblRepName.AutoSize = false;
			this.lblRepName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblRepName.Name = "lblRepName";
			this._lbl_0.Text = "Supplier Name";
			this._lbl_0.Size = new System.Drawing.Size(69, 13);
			this._lbl_0.Location = new System.Drawing.Point(12, 15);
			this._lbl_0.TabIndex = 6;
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
			this.lblName.BackColor = System.Drawing.SystemColors.Window;
			this.lblName.Text = "lblName";
			this.lblName.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblName.Size = new System.Drawing.Size(268, 16);
			this.lblName.Location = new System.Drawing.Point(12, 27);
			this.lblName.TabIndex = 5;
			this.lblName.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblName.Enabled = true;
			this.lblName.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblName.UseMnemonic = true;
			this.lblName.Visible = true;
			this.lblName.AutoSize = false;
			this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblName.Name = "lblName";
			this.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNext.Text = "&Next >>";
			this.cmdNext.Enabled = false;
			this.cmdNext.Size = new System.Drawing.Size(84, 25);
			this.cmdNext.Location = new System.Drawing.Point(270, 396);
			this.cmdNext.TabIndex = 1;
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.CausesValidation = true;
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.TabStop = true;
			this.cmdNext.Name = "cmdNext";
			this.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBack.Text = "&New Supplier";
			this.cmdBack.Size = new System.Drawing.Size(85, 25);
			this.cmdBack.Location = new System.Drawing.Point(18, 396);
			this.cmdBack.TabIndex = 2;
			this.cmdBack.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBack.CausesValidation = true;
			this.cmdBack.Enabled = true;
			this.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBack.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBack.TabStop = true;
			this.cmdBack.Name = "cmdBack";
			this.ilHeading.ImageSize = new System.Drawing.Size(32, 32);
			this.ilHeading.TransparentColor = System.Drawing.Color.FromArgb(192, 192, 192);
			this.ilHeading.Images.SetKeyName(0, "");
			this.ilHeading.Images.SetKeyName(1, "");
			this.ilHeading.Images.SetKeyName(2, "");
			this._frmMode_0.Text = "Select a supplier";
			this._frmMode_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmMode_0.Size = new System.Drawing.Size(352, 349);
			this._frmMode_0.Location = new System.Drawing.Point(12, 39);
			this._frmMode_0.TabIndex = 4;
			this._frmMode_0.Visible = false;
			this._frmMode_0.BackColor = System.Drawing.SystemColors.Control;
			this._frmMode_0.Enabled = true;
			this._frmMode_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmMode_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmMode_0.Padding = new System.Windows.Forms.Padding(0);
			this._frmMode_0.Name = "_frmMode_0";
			this.lstSupplier.Size = new System.Drawing.Size(328, 319);
			this.lstSupplier.Location = new System.Drawing.Point(12, 18);
			this.lstSupplier.TabIndex = 0;
			this.lstSupplier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSupplier.BackColor = System.Drawing.SystemColors.Window;
			this.lstSupplier.CausesValidation = true;
			this.lstSupplier.Enabled = true;
			this.lstSupplier.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSupplier.IntegralHeight = true;
			this.lstSupplier.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSupplier.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSupplier.Sorted = false;
			this.lstSupplier.TabStop = true;
			this.lstSupplier.Visible = true;
			this.lstSupplier.MultiColumn = false;
			this.lstSupplier.Name = "lstSupplier";
			this.Label1.Text = "This utility will create a blank \"Purchase Order\" so you can process a \"Goods Receiving Voucher\" for a supplier without creating an order first.";
			this.Label1.Size = new System.Drawing.Size(352, 31);
			this.Label1.Location = new System.Drawing.Point(12, 3);
			this.Label1.TabIndex = 13;
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
			this.Controls.Add(_frmMode_1);
			this.Controls.Add(cmdNext);
			this.Controls.Add(cmdBack);
			this.Controls.Add(_frmMode_0);
			this.Controls.Add(Label1);
			this._frmMode_1.Controls.Add(cmdProceed);
			this._frmMode_1.Controls.Add(lblData);
			this._frmMode_1.Controls.Add(_lbl_4);
			this.ShapeContainer1.Shapes.Add(Line1);
			this._frmMode_1.Controls.Add(lblRepNumber);
			this._frmMode_1.Controls.Add(_lbl_1);
			this._frmMode_1.Controls.Add(lblRepName);
			this._frmMode_1.Controls.Add(_lbl_0);
			this._frmMode_1.Controls.Add(lblName);
			this._frmMode_1.Controls.Add(ShapeContainer1);
			this._frmMode_0.Controls.Add(lstSupplier);
			this._frmMode_0.TabIndex = 0;
			this._frmMode_1.TabIndex = 1;
			this._lbl_0.TabIndex = 0;
			this._lbl_1.TabIndex = 1;
			this._lbl_4.TabIndex = 4;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.frmMode, System.ComponentModel.ISupportInitialize).EndInit()
			this._frmMode_1.ResumeLayout(false);
			this._frmMode_0.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
