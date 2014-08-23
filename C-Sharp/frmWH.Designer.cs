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
	partial class frmWH
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmWH() : base()
		{
			FormClosed += frmWH_FormClosed;
			KeyPress += frmWH_KeyPress;
			Resize += frmWH_Resize;
			Load += frmWH_Load;
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
		public System.Windows.Forms.TextBox _txtFields_10;
		private System.Windows.Forms.TextBox withEventsField__txtInteger_0;
		public System.Windows.Forms.TextBox _txtInteger_0 {
			get { return withEventsField__txtInteger_0; }
			set {
				if (withEventsField__txtInteger_0 != null) {
					withEventsField__txtInteger_0.Enter -= txtInteger_Enter;
					withEventsField__txtInteger_0.KeyPress -= txtInteger_KeyPress;
					withEventsField__txtInteger_0.Leave -= txtInteger_Leave;
				}
				withEventsField__txtInteger_0 = value;
				if (withEventsField__txtInteger_0 != null) {
					withEventsField__txtInteger_0.Enter += txtInteger_Enter;
					withEventsField__txtInteger_0.KeyPress += txtInteger_KeyPress;
					withEventsField__txtInteger_0.Leave += txtInteger_Leave;
				}
			}
		}
		public System.Windows.Forms.TextBox _txtFields_1;
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
		public System.Windows.Forms.Label _lblLabels_2;
		public System.Windows.Forms.Label _lblLabels_1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public System.Windows.Forms.Label _lbl_5;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtInteger As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmWH));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this._txtFields_10 = new System.Windows.Forms.TextBox();
			this._txtInteger_0 = new System.Windows.Forms.TextBox();
			this._txtFields_1 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this._lblLabels_2 = new System.Windows.Forms.Label();
			this._lblLabels_1 = new System.Windows.Forms.Label();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._lbl_5 = new System.Windows.Forms.Label();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			//Me.txtInteger = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Edit Warehouse Details";
			this.ClientSize = new System.Drawing.Size(452, 109);
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
			this.Name = "frmWH";
			this._txtFields_10.AutoSize = false;
			this._txtFields_10.BackColor = System.Drawing.Color.White;
			this._txtFields_10.Size = new System.Drawing.Size(78, 19);
			this._txtFields_10.Location = new System.Drawing.Point(352, 272);
			this._txtFields_10.TabIndex = 8;
			this._txtFields_10.AcceptsReturn = true;
			this._txtFields_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
			this._txtInteger_0.AutoSize = false;
			this._txtInteger_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtInteger_0.BackColor = System.Drawing.Color.White;
			this._txtInteger_0.Enabled = false;
			this._txtInteger_0.Size = new System.Drawing.Size(27, 19);
			this._txtInteger_0.Location = new System.Drawing.Point(412, 68);
			this._txtInteger_0.TabIndex = 3;
			this._txtInteger_0.AcceptsReturn = true;
			this._txtInteger_0.CausesValidation = true;
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
			this._txtFields_1.AutoSize = false;
			this._txtFields_1.BackColor = System.Drawing.Color.White;
			this._txtFields_1.Size = new System.Drawing.Size(190, 19);
			this._txtFields_1.Location = new System.Drawing.Point(110, 68);
			this._txtFields_1.TabIndex = 1;
			this._txtFields_1.AcceptsReturn = true;
			this._txtFields_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(452, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 7;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.Location = new System.Drawing.Point(5, 3);
			this.cmdCancel.TabIndex = 6;
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
			this.cmdClose.Location = new System.Drawing.Point(372, 2);
			this.cmdClose.TabIndex = 5;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_2.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_2.Text = "Warehouse Number:";
			this._lblLabels_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_2.Size = new System.Drawing.Size(98, 13);
			this._lblLabels_2.Location = new System.Drawing.Point(309, 71);
			this._lblLabels_2.TabIndex = 2;
			this._lblLabels_2.Enabled = true;
			this._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_2.UseMnemonic = true;
			this._lblLabels_2.Visible = true;
			this._lblLabels_2.AutoSize = true;
			this._lblLabels_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_2.Name = "_lblLabels_2";
			this._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_1.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_1.Text = "Warehouse Name:";
			this._lblLabels_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_1.Size = new System.Drawing.Size(89, 13);
			this._lblLabels_1.Location = new System.Drawing.Point(15, 71);
			this._lblLabels_1.TabIndex = 0;
			this._lblLabels_1.Enabled = true;
			this._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_1.UseMnemonic = true;
			this._lblLabels_1.Visible = true;
			this._lblLabels_1.AutoSize = true;
			this._lblLabels_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_1.Name = "_lblLabels_1";
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(442, 47);
			this._Shape1_2.Location = new System.Drawing.Point(4, 56);
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
			this._lbl_5.Location = new System.Drawing.Point(6, 42);
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
			this.Controls.Add(_txtFields_10);
			this.Controls.Add(_txtInteger_0);
			this.Controls.Add(_txtFields_1);
			this.Controls.Add(picButtons);
			this.Controls.Add(_lblLabels_2);
			this.Controls.Add(_lblLabels_1);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.Controls.Add(_lbl_5);
			this.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(cmdCancel);
			this.picButtons.Controls.Add(cmdClose);
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			//Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
			//Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
			//Me.txtFields.SetIndex(_txtFields_10, CType(10, Short))
			//Me.txtFields.SetIndex(_txtFields_1, CType(1, Short))
			//Me.txtInteger.SetIndex(_txtInteger_0, CType(0, Short))
			this.Shape1.SetIndex(_Shape1_2, Convert.ToInt16(2));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
