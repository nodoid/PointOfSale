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
	partial class frmMainHOParam
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmMainHOParam() : base()
		{
			FormClosed += frmMainHOParam_FormClosed;
			KeyPress += frmMainHOParam_KeyPress;
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
		public System.Windows.Forms.CheckBox _chkBit_6;
		public System.Windows.Forms.CheckBox _chkBit_5;
		public System.Windows.Forms.CheckBox _chkBit_1;
		public System.Windows.Forms.CheckBox _chkBit_2;
		public System.Windows.Forms.CheckBox _chkBit_3;
		public System.Windows.Forms.CheckBox _chkBit_4;
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
		public System.Windows.Forms.Button cmdClearLock;
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
		public System.Windows.Forms.Label _lbl_2;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_3;
		//Public WithEvents chkBit As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMainHOParam));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this._chkBit_6 = new System.Windows.Forms.CheckBox();
			this._chkBit_5 = new System.Windows.Forms.CheckBox();
			this._chkBit_1 = new System.Windows.Forms.CheckBox();
			this._chkBit_2 = new System.Windows.Forms.CheckBox();
			this._chkBit_3 = new System.Windows.Forms.CheckBox();
			this._chkBit_4 = new System.Windows.Forms.CheckBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClearLock = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._Shape1_3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.chkBit = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.chkBit, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "4POS HeadOffice Sync - Parameters";
			this.ClientSize = new System.Drawing.Size(271, 189);
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
			this.Name = "frmMainHOParam";
			this._chkBit_6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_6.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkBit_6.Text = "Ignore Bill of Material / Recipe";
			this._chkBit_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_6.Size = new System.Drawing.Size(242, 15);
			this._chkBit_6.Location = new System.Drawing.Point(16, 160);
			this._chkBit_6.TabIndex = 10;
			this._chkBit_6.CausesValidation = true;
			this._chkBit_6.Enabled = true;
			this._chkBit_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_6.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkBit_6.TabStop = true;
			this._chkBit_6.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkBit_6.Visible = true;
			this._chkBit_6.Name = "_chkBit_6";
			this._chkBit_5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_5.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkBit_5.Text = "Overwrite Promotion";
			this._chkBit_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_5.Size = new System.Drawing.Size(242, 15);
			this._chkBit_5.Location = new System.Drawing.Point(16, 142);
			this._chkBit_5.TabIndex = 9;
			this._chkBit_5.CausesValidation = true;
			this._chkBit_5.Enabled = true;
			this._chkBit_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_5.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkBit_5.TabStop = true;
			this._chkBit_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkBit_5.Visible = true;
			this._chkBit_5.Name = "_chkBit_5";
			this._chkBit_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkBit_1.Text = "Update Re-order level";
			this._chkBit_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_1.Size = new System.Drawing.Size(242, 15);
			this._chkBit_1.Location = new System.Drawing.Point(16, 59);
			this._chkBit_1.TabIndex = 6;
			this._chkBit_1.CausesValidation = true;
			this._chkBit_1.Enabled = true;
			this._chkBit_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkBit_1.TabStop = true;
			this._chkBit_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkBit_1.Visible = true;
			this._chkBit_1.Name = "_chkBit_1";
			this._chkBit_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkBit_2.Text = "Overwrite Employee information";
			this._chkBit_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_2.Size = new System.Drawing.Size(242, 15);
			this._chkBit_2.Location = new System.Drawing.Point(16, 79);
			this._chkBit_2.TabIndex = 5;
			this._chkBit_2.CausesValidation = true;
			this._chkBit_2.Enabled = true;
			this._chkBit_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkBit_2.TabStop = true;
			this._chkBit_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkBit_2.Visible = true;
			this._chkBit_2.Name = "_chkBit_2";
			this._chkBit_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_3.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkBit_3.Text = "Update Item Counter for Waitron";
			this._chkBit_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_3.Size = new System.Drawing.Size(242, 15);
			this._chkBit_3.Location = new System.Drawing.Point(16, 99);
			this._chkBit_3.TabIndex = 4;
			this._chkBit_3.CausesValidation = true;
			this._chkBit_3.Enabled = true;
			this._chkBit_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_3.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkBit_3.TabStop = true;
			this._chkBit_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkBit_3.Visible = true;
			this._chkBit_3.Name = "_chkBit_3";
			this._chkBit_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_4.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkBit_4.Text = "Update Actual Cost";
			this._chkBit_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_4.Size = new System.Drawing.Size(242, 15);
			this._chkBit_4.Location = new System.Drawing.Point(16, 120);
			this._chkBit_4.TabIndex = 3;
			this._chkBit_4.CausesValidation = true;
			this._chkBit_4.Enabled = true;
			this._chkBit_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_4.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkBit_4.TabStop = true;
			this._chkBit_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkBit_4.Visible = true;
			this._chkBit_4.Name = "_chkBit_4";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(271, 39);
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
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.Location = new System.Drawing.Point(8, 4);
			this.cmdCancel.TabIndex = 8;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdClearLock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClearLock.Text = "Clear Log";
			this.cmdClearLock.Size = new System.Drawing.Size(73, 29);
			this.cmdClearLock.Location = new System.Drawing.Point(552, 4);
			this.cmdClearLock.TabIndex = 2;
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
			this.cmdClose.Location = new System.Drawing.Point(184, 4);
			this.cmdClose.TabIndex = 1;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Text = "1. 4POS HeadOffice Sync - Parameters";
			this._lbl_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_2.Size = new System.Drawing.Size(206, 14);
			this._lbl_2.Location = new System.Drawing.Point(8, 40);
			this._lbl_2.TabIndex = 7;
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_2.Enabled = true;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.UseMnemonic = true;
			this._lbl_2.Visible = true;
			this._lbl_2.AutoSize = true;
			this._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_2.Name = "_lbl_2";
			this._Shape1_3.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_3.Size = new System.Drawing.Size(254, 125);
			this._Shape1_3.Location = new System.Drawing.Point(8, 55);
			this._Shape1_3.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_3.BorderWidth = 1;
			this._Shape1_3.FillColor = System.Drawing.Color.Black;
			this._Shape1_3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_3.Visible = true;
			this._Shape1_3.Name = "_Shape1_3";
			this.Controls.Add(_chkBit_6);
			this.Controls.Add(_chkBit_5);
			this.Controls.Add(_chkBit_1);
			this.Controls.Add(_chkBit_2);
			this.Controls.Add(_chkBit_3);
			this.Controls.Add(_chkBit_4);
			this.Controls.Add(picButtons);
			this.Controls.Add(_lbl_2);
			this.ShapeContainer1.Shapes.Add(_Shape1_3);
			this.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(cmdCancel);
			this.picButtons.Controls.Add(cmdClearLock);
			this.picButtons.Controls.Add(cmdClose);
			//Me.chkBit.SetIndex(_chkBit_6, CType(6, Short))
			//Me.chkBit.SetIndex(_chkBit_5, CType(5, Short))
			//Me.chkBit.SetIndex(_chkBit_1, CType(1, Short))
			//Me.chkBit.SetIndex(_chkBit_2, CType(2, Short))
			//Me.chkBit.SetIndex(_chkBit_3, CType(3, Short))
			//Me.chkBit.SetIndex(_chkBit_4, CType(4, Short))
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			this.Shape1.SetIndex(_Shape1_3, Convert.ToInt16(3));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.chkBit, System.ComponentModel.ISupportInitialize).EndInit()
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
