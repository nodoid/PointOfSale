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
	partial class frmRPpriceCompare
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmRPpriceCompare() : base()
		{
			KeyPress += frmRPpriceCompare_KeyPress;
			Load += frmRPpriceCompare_Load;
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
		private System.Windows.Forms.TextBox withEventsField_txtAbove;
		public System.Windows.Forms.TextBox txtAbove {
			get { return withEventsField_txtAbove; }
			set {
				if (withEventsField_txtAbove != null) {
					withEventsField_txtAbove.Enter -= txtAbove_Enter;
					withEventsField_txtAbove.KeyPress -= txtAbove_KeyPress;
					withEventsField_txtAbove.Leave -= txtAbove_Leave;
				}
				withEventsField_txtAbove = value;
				if (withEventsField_txtAbove != null) {
					withEventsField_txtAbove.Enter += txtAbove_Enter;
					withEventsField_txtAbove.KeyPress += txtAbove_KeyPress;
					withEventsField_txtAbove.Leave += txtAbove_Leave;
				}
			}
		}
		public System.Windows.Forms.CheckBox chkAbove;
		public System.Windows.Forms.TextBox txtBelow;
		public System.Windows.Forms.CheckBox chkBelow;
		private System.Windows.Forms.CheckBox withEventsField_chkQuantity;
		public System.Windows.Forms.CheckBox chkQuantity {
			get { return withEventsField_chkQuantity; }
			set {
				if (withEventsField_chkQuantity != null) {
					withEventsField_chkQuantity.CheckStateChanged -= chkQuantity_CheckStateChanged;
				}
				withEventsField_chkQuantity = value;
				if (withEventsField_chkQuantity != null) {
					withEventsField_chkQuantity.CheckStateChanged += chkQuantity_CheckStateChanged;
				}
			}
		}
		public System.Windows.Forms.CheckBox chkDifferent;
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
		private myDataGridView withEventsField_cmbChannel;
		public myDataGridView cmbChannel {
			get { return withEventsField_cmbChannel; }
			set {
				if (withEventsField_cmbChannel != null) {
					withEventsField_cmbChannel.KeyPress -= cmbChannel_KeyPress;
				}
				withEventsField_cmbChannel = value;
				if (withEventsField_cmbChannel != null) {
					withEventsField_cmbChannel.KeyPress += cmbChannel_KeyPress;
				}
			}
		}
		private myDataGridView withEventsField_cmbShrink;
		public myDataGridView cmbShrink {
			get { return withEventsField_cmbShrink; }
			set {
				if (withEventsField_cmbShrink != null) {
					withEventsField_cmbShrink.KeyPress -= cmbShrink_KeyPress;
				}
				withEventsField_cmbShrink = value;
				if (withEventsField_cmbShrink != null) {
					withEventsField_cmbShrink.KeyPress += cmbShrink_KeyPress;
				}
			}
		}
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label lblHeading;
		public System.Windows.Forms.Label _lbl_0;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRPpriceCompare));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.txtAbove = new System.Windows.Forms.TextBox();
			this.chkAbove = new System.Windows.Forms.CheckBox();
			this.txtBelow = new System.Windows.Forms.TextBox();
			this.chkBelow = new System.Windows.Forms.CheckBox();
			this.chkQuantity = new System.Windows.Forms.CheckBox();
			this.chkDifferent = new System.Windows.Forms.CheckBox();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdNamespace = new System.Windows.Forms.Button();
			this.cmbChannel = new myDataGridView();
			this.cmbShrink = new myDataGridView();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this.lblHeading = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.cmbChannel).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbShrink).BeginInit();
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.Text = "Setup Price Comparison Report";
			this.ClientSize = new System.Drawing.Size(462, 215);
			this.Location = new System.Drawing.Point(4, 23);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Enabled = true;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmRPpriceCompare";
			this.txtAbove.AutoSize = false;
			this.txtAbove.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtAbove.Size = new System.Drawing.Size(28, 19);
			this.txtAbove.Location = new System.Drawing.Point(252, 168);
			this.txtAbove.TabIndex = 13;
			this.txtAbove.Text = "0";
			this.txtAbove.AcceptsReturn = true;
			this.txtAbove.BackColor = System.Drawing.SystemColors.Window;
			this.txtAbove.CausesValidation = true;
			this.txtAbove.Enabled = true;
			this.txtAbove.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtAbove.HideSelection = true;
			this.txtAbove.ReadOnly = false;
			this.txtAbove.MaxLength = 0;
			this.txtAbove.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtAbove.Multiline = false;
			this.txtAbove.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtAbove.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtAbove.TabStop = true;
			this.txtAbove.Visible = true;
			this.txtAbove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtAbove.Name = "txtAbove";
			this.chkAbove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkAbove.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.chkAbove.Text = "Show stock Items where exit price above";
			this.chkAbove.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkAbove.Size = new System.Drawing.Size(217, 13);
			this.chkAbove.Location = new System.Drawing.Point(33, 171);
			this.chkAbove.TabIndex = 12;
			this.chkAbove.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAbove.CausesValidation = true;
			this.chkAbove.Enabled = true;
			this.chkAbove.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkAbove.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkAbove.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkAbove.TabStop = true;
			this.chkAbove.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkAbove.Visible = true;
			this.chkAbove.Name = "chkAbove";
			this.txtBelow.AutoSize = false;
			this.txtBelow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtBelow.Size = new System.Drawing.Size(28, 19);
			this.txtBelow.Location = new System.Drawing.Point(252, 189);
			this.txtBelow.TabIndex = 10;
			this.txtBelow.Text = "0";
			this.txtBelow.AcceptsReturn = true;
			this.txtBelow.BackColor = System.Drawing.SystemColors.Window;
			this.txtBelow.CausesValidation = true;
			this.txtBelow.Enabled = true;
			this.txtBelow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtBelow.HideSelection = true;
			this.txtBelow.ReadOnly = false;
			this.txtBelow.MaxLength = 0;
			this.txtBelow.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtBelow.Multiline = false;
			this.txtBelow.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtBelow.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtBelow.TabStop = true;
			this.txtBelow.Visible = true;
			this.txtBelow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtBelow.Name = "txtBelow";
			this.chkBelow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkBelow.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.chkBelow.Text = "Show stock Items where exit price below ";
			this.chkBelow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkBelow.Size = new System.Drawing.Size(217, 13);
			this.chkBelow.Location = new System.Drawing.Point(33, 192);
			this.chkBelow.TabIndex = 9;
			this.chkBelow.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBelow.CausesValidation = true;
			this.chkBelow.Enabled = true;
			this.chkBelow.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkBelow.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkBelow.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkBelow.TabStop = true;
			this.chkBelow.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkBelow.Visible = true;
			this.chkBelow.Name = "chkBelow";
			this.chkQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkQuantity.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.chkQuantity.Text = "Show stock Items where quantity is exactly ";
			this.chkQuantity.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkQuantity.Size = new System.Drawing.Size(226, 13);
			this.chkQuantity.Location = new System.Drawing.Point(33, 141);
			this.chkQuantity.TabIndex = 5;
			this.chkQuantity.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkQuantity.CausesValidation = true;
			this.chkQuantity.Enabled = true;
			this.chkQuantity.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkQuantity.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkQuantity.TabStop = true;
			this.chkQuantity.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkQuantity.Visible = true;
			this.chkQuantity.Name = "chkQuantity";
			this.chkDifferent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkDifferent.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.chkDifferent.Text = "Only show stock item where prices are different";
			this.chkDifferent.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkDifferent.Size = new System.Drawing.Size(268, 13);
			this.chkDifferent.Location = new System.Drawing.Point(33, 111);
			this.chkDifferent.TabIndex = 4;
			this.chkDifferent.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkDifferent.CausesValidation = true;
			this.chkDifferent.Enabled = true;
			this.chkDifferent.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkDifferent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkDifferent.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkDifferent.TabStop = true;
			this.chkDifferent.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkDifferent.Visible = true;
			this.chkDifferent.Name = "chkDifferent";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(97, 52);
			this.cmdExit.Location = new System.Drawing.Point(363, 156);
			this.cmdExit.TabIndex = 8;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.Size = new System.Drawing.Size(97, 52);
			this.cmdPrint.Location = new System.Drawing.Point(363, 96);
			this.cmdPrint.TabIndex = 7;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.TabStop = true;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdNamespace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNamespace.Text = "&Filter";
			this.cmdNamespace.Size = new System.Drawing.Size(97, 52);
			this.cmdNamespace.Location = new System.Drawing.Point(363, 3);
			this.cmdNamespace.TabIndex = 1;
			this.cmdNamespace.TabStop = false;
			this.cmdNamespace.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNamespace.CausesValidation = true;
			this.cmdNamespace.Enabled = true;
			this.cmdNamespace.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNamespace.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNamespace.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNamespace.Name = "cmdNamespace";
			//cmbChannel.OcxState = CType(resources.GetObject("cmbChannel.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbChannel.Size = new System.Drawing.Size(124, 21);
			this.cmbChannel.Location = new System.Drawing.Point(153, 60);
			this.cmbChannel.TabIndex = 3;
			this.cmbChannel.Name = "cmbChannel";
			//cmbShrink.OcxState = CType(resources.GetObject("cmbShrink.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbShrink.Size = new System.Drawing.Size(67, 21);
			this.cmbShrink.Location = new System.Drawing.Point(261, 138);
			this.cmbShrink.TabIndex = 6;
			this.cmbShrink.Name = "cmbShrink";
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_2.Text = "%";
			this._lbl_2.Size = new System.Drawing.Size(11, 13);
			this._lbl_2.Location = new System.Drawing.Point(282, 171);
			this._lbl_2.TabIndex = 14;
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
			this._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_1.Text = "%";
			this._lbl_1.Size = new System.Drawing.Size(11, 13);
			this._lbl_1.Location = new System.Drawing.Point(282, 192);
			this._lbl_1.TabIndex = 11;
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
			this.lblHeading.Text = "Using the \"Stock Item Selector\" .....";
			this.lblHeading.Size = new System.Drawing.Size(349, 52);
			this.lblHeading.Location = new System.Drawing.Point(3, 3);
			this.lblHeading.TabIndex = 0;
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
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_0.Text = "For which Sale Channel";
			this._lbl_0.Size = new System.Drawing.Size(112, 13);
			this._lbl_0.Location = new System.Drawing.Point(34, 63);
			this._lbl_0.TabIndex = 2;
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
			this.Controls.Add(txtAbove);
			this.Controls.Add(chkAbove);
			this.Controls.Add(txtBelow);
			this.Controls.Add(chkBelow);
			this.Controls.Add(chkQuantity);
			this.Controls.Add(chkDifferent);
			this.Controls.Add(cmdExit);
			this.Controls.Add(cmdPrint);
			this.Controls.Add(cmdNamespace);
			this.Controls.Add(cmbChannel);
			this.Controls.Add(cmbShrink);
			this.Controls.Add(_lbl_2);
			this.Controls.Add(_lbl_1);
			this.Controls.Add(lblHeading);
			this.Controls.Add(_lbl_0);
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this.cmbShrink).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbChannel).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
