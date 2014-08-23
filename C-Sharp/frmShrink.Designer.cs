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
	partial class frmShrink
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmShrink() : base()
		{
			Load += frmShrink_Load;
			KeyPress += frmShrink_KeyPress;
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
		public System.Windows.Forms.TextBox _txtInteger_0;
		private System.Windows.Forms.Button withEventsField_cmdShrinkAdd;
		public System.Windows.Forms.Button cmdShrinkAdd {
			get { return withEventsField_cmdShrinkAdd; }
			set {
				if (withEventsField_cmdShrinkAdd != null) {
					withEventsField_cmdShrinkAdd.Click -= cmdShrinkAdd_Click;
				}
				withEventsField_cmdShrinkAdd = value;
				if (withEventsField_cmdShrinkAdd != null) {
					withEventsField_cmdShrinkAdd.Click += cmdShrinkAdd_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox _txtInteger_5;
		public System.Windows.Forms.TextBox _txtInteger_4;
		public System.Windows.Forms.TextBox _txtInteger_3;
		public System.Windows.Forms.TextBox _txtInteger_2;
		public System.Windows.Forms.TextBox _txtInteger_1;
		public System.Windows.Forms.Label _lbl_5;
		public System.Windows.Forms.Label _lbl_4;
		public System.Windows.Forms.Label _lbl_3;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lbl_0;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents txtInteger As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmShrink));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdExit = new System.Windows.Forms.Button();
			this._txtInteger_0 = new System.Windows.Forms.TextBox();
			this.cmdShrinkAdd = new System.Windows.Forms.Button();
			this._txtInteger_5 = new System.Windows.Forms.TextBox();
			this._txtInteger_4 = new System.Windows.Forms.TextBox();
			this._txtInteger_3 = new System.Windows.Forms.TextBox();
			this._txtInteger_2 = new System.Windows.Forms.TextBox();
			this._txtInteger_1 = new System.Windows.Forms.TextBox();
			this._lbl_5 = new System.Windows.Forms.Label();
			this._lbl_4 = new System.Windows.Forms.Label();
			this._lbl_3 = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.txtInteger = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).BeginInit()
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Add a Shrink ...";
			this.ClientSize = new System.Drawing.Size(344, 143);
			this.Location = new System.Drawing.Point(3, 29);
			this.ControlBox = false;
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
			this.Name = "frmShrink";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(97, 52);
			this.cmdExit.Location = new System.Drawing.Point(240, 78);
			this.cmdExit.TabIndex = 13;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this._txtInteger_0.AutoSize = false;
			this._txtInteger_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtInteger_0.Size = new System.Drawing.Size(43, 19);
			this._txtInteger_0.Location = new System.Drawing.Point(24, 12);
			this._txtInteger_0.TabIndex = 0;
			this._txtInteger_0.Text = "0";
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
			this.cmdShrinkAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdShrinkAdd.Text = "Add Shrink";
			this.cmdShrinkAdd.Size = new System.Drawing.Size(97, 19);
			this.cmdShrinkAdd.Location = new System.Drawing.Point(240, 39);
			this.cmdShrinkAdd.TabIndex = 11;
			this.cmdShrinkAdd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdShrinkAdd.CausesValidation = true;
			this.cmdShrinkAdd.Enabled = true;
			this.cmdShrinkAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdShrinkAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdShrinkAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdShrinkAdd.TabStop = true;
			this.cmdShrinkAdd.Name = "cmdShrinkAdd";
			this._txtInteger_5.AutoSize = false;
			this._txtInteger_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtInteger_5.Size = new System.Drawing.Size(43, 19);
			this._txtInteger_5.Location = new System.Drawing.Point(294, 12);
			this._txtInteger_5.TabIndex = 5;
			this._txtInteger_5.Text = "0";
			this._txtInteger_5.AcceptsReturn = true;
			this._txtInteger_5.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_5.CausesValidation = true;
			this._txtInteger_5.Enabled = true;
			this._txtInteger_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_5.HideSelection = true;
			this._txtInteger_5.ReadOnly = false;
			this._txtInteger_5.MaxLength = 0;
			this._txtInteger_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_5.Multiline = false;
			this._txtInteger_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_5.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtInteger_5.TabStop = true;
			this._txtInteger_5.Visible = true;
			this._txtInteger_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_5.Name = "_txtInteger_5";
			this._txtInteger_4.AutoSize = false;
			this._txtInteger_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtInteger_4.Size = new System.Drawing.Size(43, 19);
			this._txtInteger_4.Location = new System.Drawing.Point(240, 12);
			this._txtInteger_4.TabIndex = 4;
			this._txtInteger_4.Text = "0";
			this._txtInteger_4.AcceptsReturn = true;
			this._txtInteger_4.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_4.CausesValidation = true;
			this._txtInteger_4.Enabled = true;
			this._txtInteger_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_4.HideSelection = true;
			this._txtInteger_4.ReadOnly = false;
			this._txtInteger_4.MaxLength = 0;
			this._txtInteger_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_4.Multiline = false;
			this._txtInteger_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_4.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtInteger_4.TabStop = true;
			this._txtInteger_4.Visible = true;
			this._txtInteger_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_4.Name = "_txtInteger_4";
			this._txtInteger_3.AutoSize = false;
			this._txtInteger_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtInteger_3.Size = new System.Drawing.Size(43, 19);
			this._txtInteger_3.Location = new System.Drawing.Point(186, 12);
			this._txtInteger_3.TabIndex = 3;
			this._txtInteger_3.Text = "0";
			this._txtInteger_3.AcceptsReturn = true;
			this._txtInteger_3.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_3.CausesValidation = true;
			this._txtInteger_3.Enabled = true;
			this._txtInteger_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_3.HideSelection = true;
			this._txtInteger_3.ReadOnly = false;
			this._txtInteger_3.MaxLength = 0;
			this._txtInteger_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_3.Multiline = false;
			this._txtInteger_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_3.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtInteger_3.TabStop = true;
			this._txtInteger_3.Visible = true;
			this._txtInteger_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_3.Name = "_txtInteger_3";
			this._txtInteger_2.AutoSize = false;
			this._txtInteger_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtInteger_2.Size = new System.Drawing.Size(43, 19);
			this._txtInteger_2.Location = new System.Drawing.Point(132, 12);
			this._txtInteger_2.TabIndex = 2;
			this._txtInteger_2.Text = "0";
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
			this._txtInteger_1.AutoSize = false;
			this._txtInteger_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtInteger_1.Size = new System.Drawing.Size(43, 19);
			this._txtInteger_1.Location = new System.Drawing.Point(78, 12);
			this._txtInteger_1.TabIndex = 1;
			this._txtInteger_1.Text = "0";
			this._txtInteger_1.AcceptsReturn = true;
			this._txtInteger_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_1.CausesValidation = true;
			this._txtInteger_1.Enabled = true;
			this._txtInteger_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_1.HideSelection = true;
			this._txtInteger_1.ReadOnly = false;
			this._txtInteger_1.MaxLength = 0;
			this._txtInteger_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_1.Multiline = false;
			this._txtInteger_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtInteger_1.TabStop = true;
			this._txtInteger_1.Visible = true;
			this._txtInteger_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_1.Name = "_txtInteger_1";
			this._lbl_5.Text = "1 X";
			this._lbl_5.Size = new System.Drawing.Size(16, 13);
			this._lbl_5.Location = new System.Drawing.Point(6, 15);
			this._lbl_5.TabIndex = 12;
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
			this._lbl_4.Text = "X";
			this._lbl_4.Size = new System.Drawing.Size(7, 13);
			this._lbl_4.Location = new System.Drawing.Point(285, 15);
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
			this._lbl_3.Text = "X";
			this._lbl_3.Size = new System.Drawing.Size(7, 13);
			this._lbl_3.Location = new System.Drawing.Point(231, 15);
			this._lbl_3.TabIndex = 9;
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
			this._lbl_2.Text = "X";
			this._lbl_2.Size = new System.Drawing.Size(7, 13);
			this._lbl_2.Location = new System.Drawing.Point(177, 15);
			this._lbl_2.TabIndex = 8;
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
			this._lbl_1.Text = "X";
			this._lbl_1.Size = new System.Drawing.Size(7, 13);
			this._lbl_1.Location = new System.Drawing.Point(123, 15);
			this._lbl_1.TabIndex = 7;
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
			this._lbl_0.Text = "X";
			this._lbl_0.Size = new System.Drawing.Size(7, 13);
			this._lbl_0.Location = new System.Drawing.Point(69, 15);
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
			this.Controls.Add(cmdExit);
			this.Controls.Add(_txtInteger_0);
			this.Controls.Add(cmdShrinkAdd);
			this.Controls.Add(_txtInteger_5);
			this.Controls.Add(_txtInteger_4);
			this.Controls.Add(_txtInteger_3);
			this.Controls.Add(_txtInteger_2);
			this.Controls.Add(_txtInteger_1);
			this.Controls.Add(_lbl_5);
			this.Controls.Add(_lbl_4);
			this.Controls.Add(_lbl_3);
			this.Controls.Add(_lbl_2);
			this.Controls.Add(_lbl_1);
			this.Controls.Add(_lbl_0);
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			//Me.lbl.SetIndex(_lbl_4, CType(4, Short))
			//Me.lbl.SetIndex(_lbl_3, CType(3, Short))
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.txtInteger.SetIndex(_txtInteger_0, CType(0, Short))
			//Me.txtInteger.SetIndex(_txtInteger_5, CType(5, Short))
			//Me.txtInteger.SetIndex(_txtInteger_4, CType(4, Short))
			//Me.txtInteger.SetIndex(_txtInteger_3, CType(3, Short))
			//Me.txtInteger.SetIndex(_txtInteger_2, CType(2, Short))
			//Me.txtInteger.SetIndex(_txtInteger_1, CType(1, Short))
			//C() ''Type(Me.txtInteger, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
