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
	partial class frmStockBreak
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockBreak() : base()
		{
			KeyPress += frmStockBreak_KeyPress;
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
		private System.Windows.Forms.Button withEventsField_cmdChild;
		public System.Windows.Forms.Button cmdChild {
			get { return withEventsField_cmdChild; }
			set {
				if (withEventsField_cmdChild != null) {
					withEventsField_cmdChild.Click -= cmdChild_Click;
				}
				withEventsField_cmdChild = value;
				if (withEventsField_cmdChild != null) {
					withEventsField_cmdChild.Click += cmdChild_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdParent;
		public System.Windows.Forms.Button cmdParent {
			get { return withEventsField_cmdParent; }
			set {
				if (withEventsField_cmdParent != null) {
					withEventsField_cmdParent.Click -= cmdParent_Click;
				}
				withEventsField_cmdParent = value;
				if (withEventsField_cmdParent != null) {
					withEventsField_cmdParent.Click += cmdParent_Click;
				}
			}
		}
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
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.CheckBox chkDisabled;
		private System.Windows.Forms.TextBox withEventsField_txtQuantity;
		public System.Windows.Forms.TextBox txtQuantity {
			get { return withEventsField_txtQuantity; }
			set {
				if (withEventsField_txtQuantity != null) {
					withEventsField_txtQuantity.Enter -= txtQuantity_Enter;
					withEventsField_txtQuantity.KeyPress -= txtQuantity_KeyPress;
					withEventsField_txtQuantity.Leave -= txtQuantity_Leave;
				}
				withEventsField_txtQuantity = value;
				if (withEventsField_txtQuantity != null) {
					withEventsField_txtQuantity.Enter += txtQuantity_Enter;
					withEventsField_txtQuantity.KeyPress += txtQuantity_KeyPress;
					withEventsField_txtQuantity.Leave += txtQuantity_Leave;
				}
			}
		}
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label lblChild;
		public System.Windows.Forms.Label lblParent;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockBreak));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdChild = new System.Windows.Forms.Button();
			this.cmdParent = new System.Windows.Forms.Button();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.chkDisabled = new System.Windows.Forms.CheckBox();
			this.txtQuantity = new System.Windows.Forms.TextBox();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.lblChild = new System.Windows.Forms.Label();
			this.lblParent = new System.Windows.Forms.Label();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Maintain Stock Item Conversion";
			this.ClientSize = new System.Drawing.Size(396, 129);
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
			this.Name = "frmStockBreak";
			this.cmdChild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChild.Text = "...";
			this.cmdChild.Size = new System.Drawing.Size(40, 16);
			this.cmdChild.Location = new System.Drawing.Point(348, 75);
			this.cmdChild.TabIndex = 7;
			this.cmdChild.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChild.CausesValidation = true;
			this.cmdChild.Enabled = true;
			this.cmdChild.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChild.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChild.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChild.TabStop = true;
			this.cmdChild.Name = "cmdChild";
			this.cmdParent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdParent.Text = "...";
			this.cmdParent.Size = new System.Drawing.Size(40, 16);
			this.cmdParent.Location = new System.Drawing.Point(348, 54);
			this.cmdParent.TabIndex = 2;
			this.cmdParent.BackColor = System.Drawing.SystemColors.Control;
			this.cmdParent.CausesValidation = true;
			this.cmdParent.Enabled = true;
			this.cmdParent.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdParent.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdParent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdParent.TabStop = true;
			this.cmdParent.Name = "cmdParent";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(396, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 9;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(73, 29);
			this.cmdExit.Location = new System.Drawing.Point(315, 3);
			this.cmdExit.TabIndex = 12;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.Location = new System.Drawing.Point(5, 3);
			this.cmdCancel.TabIndex = 11;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.Size = new System.Drawing.Size(73, 29);
			this.cmdPrint.Location = new System.Drawing.Point(237, 3);
			this.cmdPrint.TabIndex = 10;
			this.cmdPrint.TabStop = false;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Name = "cmdPrint";
			this.chkDisabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkDisabled.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.chkDisabled.Text = "Disable this Stock Item Conversion.";
			this.chkDisabled.Size = new System.Drawing.Size(187, 13);
			this.chkDisabled.Location = new System.Drawing.Point(156, 99);
			this.chkDisabled.TabIndex = 8;
			this.chkDisabled.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkDisabled.CausesValidation = true;
			this.chkDisabled.Enabled = true;
			this.chkDisabled.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkDisabled.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkDisabled.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkDisabled.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkDisabled.TabStop = true;
			this.chkDisabled.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkDisabled.Visible = true;
			this.chkDisabled.Name = "chkDisabled";
			this.txtQuantity.AutoSize = false;
			this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtQuantity.Size = new System.Drawing.Size(34, 19);
			this.txtQuantity.Location = new System.Drawing.Point(24, 75);
			this.txtQuantity.TabIndex = 4;
			this.txtQuantity.Text = "0";
			this.txtQuantity.AcceptsReturn = true;
			this.txtQuantity.BackColor = System.Drawing.SystemColors.Window;
			this.txtQuantity.CausesValidation = true;
			this.txtQuantity.Enabled = true;
			this.txtQuantity.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtQuantity.HideSelection = true;
			this.txtQuantity.ReadOnly = false;
			this.txtQuantity.MaxLength = 0;
			this.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtQuantity.Multiline = false;
			this.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtQuantity.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtQuantity.TabStop = true;
			this.txtQuantity.Visible = true;
			this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtQuantity.Name = "txtQuantity";
			this._lbl_2.Text = "units of ";
			this._lbl_2.Size = new System.Drawing.Size(37, 13);
			this._lbl_2.Location = new System.Drawing.Point(63, 78);
			this._lbl_2.TabIndex = 5;
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
			this._lbl_1.Text = "to";
			this._lbl_1.Size = new System.Drawing.Size(9, 13);
			this._lbl_1.Location = new System.Drawing.Point(9, 78);
			this._lbl_1.TabIndex = 3;
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
			this._lbl_0.Text = "Convert one unit of ";
			this._lbl_0.Size = new System.Drawing.Size(93, 13);
			this._lbl_0.Location = new System.Drawing.Point(9, 57);
			this._lbl_0.TabIndex = 0;
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
			this.lblChild.Text = "No Stock Item Selected ...";
			this.lblChild.Size = new System.Drawing.Size(243, 17);
			this.lblChild.Location = new System.Drawing.Point(102, 75);
			this.lblChild.TabIndex = 6;
			this.lblChild.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblChild.BackColor = System.Drawing.SystemColors.Control;
			this.lblChild.Enabled = true;
			this.lblChild.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblChild.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblChild.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblChild.UseMnemonic = true;
			this.lblChild.Visible = true;
			this.lblChild.AutoSize = false;
			this.lblChild.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblChild.Name = "lblChild";
			this.lblParent.Text = "No Stock Item Selected ...";
			this.lblParent.Size = new System.Drawing.Size(243, 17);
			this.lblParent.Location = new System.Drawing.Point(102, 54);
			this.lblParent.TabIndex = 1;
			this.lblParent.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblParent.BackColor = System.Drawing.SystemColors.Control;
			this.lblParent.Enabled = true;
			this.lblParent.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblParent.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblParent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblParent.UseMnemonic = true;
			this.lblParent.Visible = true;
			this.lblParent.AutoSize = false;
			this.lblParent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblParent.Name = "lblParent";
			this.Controls.Add(cmdChild);
			this.Controls.Add(cmdParent);
			this.Controls.Add(picButtons);
			this.Controls.Add(chkDisabled);
			this.Controls.Add(txtQuantity);
			this.Controls.Add(_lbl_2);
			this.Controls.Add(_lbl_1);
			this.Controls.Add(_lbl_0);
			this.Controls.Add(lblChild);
			this.Controls.Add(lblParent);
			this.picButtons.Controls.Add(cmdExit);
			this.picButtons.Controls.Add(cmdCancel);
			this.picButtons.Controls.Add(cmdPrint);
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
