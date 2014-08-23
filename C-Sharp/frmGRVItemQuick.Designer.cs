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
	partial class frmGRVItemQuick
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmGRVItemQuick() : base()
		{
			Load += frmGRVItemQuick_Load;
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
		private System.Windows.Forms.TextBox withEventsField_txtPrice;
		public System.Windows.Forms.TextBox txtPrice {
			get { return withEventsField_txtPrice; }
			set {
				if (withEventsField_txtPrice != null) {
					withEventsField_txtPrice.Enter -= txtPrice_Enter;
					withEventsField_txtPrice.KeyPress -= txtPrice_KeyPress;
					withEventsField_txtPrice.Leave -= txtPrice_Leave;
				}
				withEventsField_txtPrice = value;
				if (withEventsField_txtPrice != null) {
					withEventsField_txtPrice.Enter += txtPrice_Enter;
					withEventsField_txtPrice.KeyPress += txtPrice_KeyPress;
					withEventsField_txtPrice.Leave += txtPrice_Leave;
				}
			}
		}
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
		private System.Windows.Forms.TextBox withEventsField_txtDiscountMinus;
		public System.Windows.Forms.TextBox txtDiscountMinus {
			get { return withEventsField_txtDiscountMinus; }
			set {
				if (withEventsField_txtDiscountMinus != null) {
					withEventsField_txtDiscountMinus.Enter -= txtDiscountMinus_Enter;
					withEventsField_txtDiscountMinus.KeyPress -= txtDiscountMinus_KeyPress;
					withEventsField_txtDiscountMinus.Leave -= txtDiscountMinus_Leave;
				}
				withEventsField_txtDiscountMinus = value;
				if (withEventsField_txtDiscountMinus != null) {
					withEventsField_txtDiscountMinus.Enter += txtDiscountMinus_Enter;
					withEventsField_txtDiscountMinus.KeyPress += txtDiscountMinus_KeyPress;
					withEventsField_txtDiscountMinus.Leave += txtDiscountMinus_Leave;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtDiscountPlus;
		public System.Windows.Forms.TextBox txtDiscountPlus {
			get { return withEventsField_txtDiscountPlus; }
			set {
				if (withEventsField_txtDiscountPlus != null) {
					withEventsField_txtDiscountPlus.Enter -= txtDiscountPlus_Enter;
					withEventsField_txtDiscountPlus.KeyPress -= txtDiscountPlus_KeyPress;
					withEventsField_txtDiscountPlus.Leave -= txtDiscountPlus_Leave;
				}
				withEventsField_txtDiscountPlus = value;
				if (withEventsField_txtDiscountPlus != null) {
					withEventsField_txtDiscountPlus.Enter += txtDiscountPlus_Enter;
					withEventsField_txtDiscountPlus.KeyPress += txtDiscountPlus_KeyPress;
					withEventsField_txtDiscountPlus.Leave += txtDiscountPlus_Leave;
				}
			}
		}
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
		private System.Windows.Forms.CheckBox withEventsField_chkBreakPack;
		public System.Windows.Forms.CheckBox chkBreakPack {
			get { return withEventsField_chkBreakPack; }
			set {
				if (withEventsField_chkBreakPack != null) {
					withEventsField_chkBreakPack.CheckStateChanged -= chkBreakPack_CheckStateChanged;
					withEventsField_chkBreakPack.KeyPress -= chkBreakPack_KeyPress;
				}
				withEventsField_chkBreakPack = value;
				if (withEventsField_chkBreakPack != null) {
					withEventsField_chkBreakPack.CheckStateChanged += chkBreakPack_CheckStateChanged;
					withEventsField_chkBreakPack.KeyPress += chkBreakPack_KeyPress;
				}
			}
		}
		public System.Windows.Forms.Label lblPath;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label lblName;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGRVItemQuick));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.cmdProceed = new System.Windows.Forms.Button();
			this.txtDiscountMinus = new System.Windows.Forms.TextBox();
			this.txtDiscountPlus = new System.Windows.Forms.TextBox();
			this.txtQuantity = new System.Windows.Forms.TextBox();
			this.chkBreakPack = new System.Windows.Forms.CheckBox();
			this.lblPath = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.ClientSize = new System.Drawing.Size(313, 213);
			this.Location = new System.Drawing.Point(3, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmGRVItemQuick";
			this.txtPrice.AutoSize = false;
			this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPrice.Size = new System.Drawing.Size(217, 19);
			this.txtPrice.Location = new System.Drawing.Point(85, 99);
			this.txtPrice.TabIndex = 5;
			this.txtPrice.Text = "Text1";
			this.txtPrice.AcceptsReturn = true;
			this.txtPrice.BackColor = System.Drawing.SystemColors.Window;
			this.txtPrice.CausesValidation = true;
			this.txtPrice.Enabled = true;
			this.txtPrice.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPrice.HideSelection = true;
			this.txtPrice.ReadOnly = false;
			this.txtPrice.MaxLength = 0;
			this.txtPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPrice.Multiline = false;
			this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtPrice.TabStop = true;
			this.txtPrice.Visible = true;
			this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtPrice.Name = "txtPrice";
			this.cmdProceed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdProceed.Text = "&Proceed";
			this.cmdProceed.Size = new System.Drawing.Size(85, 31);
			this.cmdProceed.Location = new System.Drawing.Point(216, 174);
			this.cmdProceed.TabIndex = 10;
			this.cmdProceed.BackColor = System.Drawing.SystemColors.Control;
			this.cmdProceed.CausesValidation = true;
			this.cmdProceed.Enabled = true;
			this.cmdProceed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdProceed.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdProceed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdProceed.TabStop = true;
			this.cmdProceed.Name = "cmdProceed";
			this.txtDiscountMinus.AutoSize = false;
			this.txtDiscountMinus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDiscountMinus.Size = new System.Drawing.Size(217, 19);
			this.txtDiscountMinus.Location = new System.Drawing.Point(84, 147);
			this.txtDiscountMinus.TabIndex = 9;
			this.txtDiscountMinus.Text = "Text1";
			this.txtDiscountMinus.AcceptsReturn = true;
			this.txtDiscountMinus.BackColor = System.Drawing.SystemColors.Window;
			this.txtDiscountMinus.CausesValidation = true;
			this.txtDiscountMinus.Enabled = true;
			this.txtDiscountMinus.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtDiscountMinus.HideSelection = true;
			this.txtDiscountMinus.ReadOnly = false;
			this.txtDiscountMinus.MaxLength = 0;
			this.txtDiscountMinus.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtDiscountMinus.Multiline = false;
			this.txtDiscountMinus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtDiscountMinus.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtDiscountMinus.TabStop = true;
			this.txtDiscountMinus.Visible = true;
			this.txtDiscountMinus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtDiscountMinus.Name = "txtDiscountMinus";
			this.txtDiscountPlus.AutoSize = false;
			this.txtDiscountPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDiscountPlus.Size = new System.Drawing.Size(217, 19);
			this.txtDiscountPlus.Location = new System.Drawing.Point(84, 126);
			this.txtDiscountPlus.TabIndex = 7;
			this.txtDiscountPlus.Text = "Text1";
			this.txtDiscountPlus.AcceptsReturn = true;
			this.txtDiscountPlus.BackColor = System.Drawing.SystemColors.Window;
			this.txtDiscountPlus.CausesValidation = true;
			this.txtDiscountPlus.Enabled = true;
			this.txtDiscountPlus.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtDiscountPlus.HideSelection = true;
			this.txtDiscountPlus.ReadOnly = false;
			this.txtDiscountPlus.MaxLength = 0;
			this.txtDiscountPlus.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtDiscountPlus.Multiline = false;
			this.txtDiscountPlus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtDiscountPlus.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtDiscountPlus.TabStop = true;
			this.txtDiscountPlus.Visible = true;
			this.txtDiscountPlus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtDiscountPlus.Name = "txtDiscountPlus";
			this.txtQuantity.AutoSize = false;
			this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtQuantity.Size = new System.Drawing.Size(217, 19);
			this.txtQuantity.Location = new System.Drawing.Point(84, 78);
			this.txtQuantity.TabIndex = 3;
			this.txtQuantity.Text = "Text1";
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
			this.chkBreakPack.Text = "Break Pack";
			this.chkBreakPack.Size = new System.Drawing.Size(286, 16);
			this.chkBreakPack.Location = new System.Drawing.Point(12, 54);
			this.chkBreakPack.TabIndex = 1;
			this.chkBreakPack.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBreakPack.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkBreakPack.BackColor = System.Drawing.SystemColors.Control;
			this.chkBreakPack.CausesValidation = true;
			this.chkBreakPack.Enabled = true;
			this.chkBreakPack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkBreakPack.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkBreakPack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkBreakPack.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkBreakPack.TabStop = true;
			this.chkBreakPack.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkBreakPack.Visible = true;
			this.chkBreakPack.Name = "chkBreakPack";
			this.lblPath.BackColor = System.Drawing.Color.Blue;
			this.lblPath.Text = "GRV Quick Edit";
			this.lblPath.ForeColor = System.Drawing.Color.White;
			this.lblPath.Size = new System.Drawing.Size(568, 25);
			this.lblPath.Location = new System.Drawing.Point(0, 0);
			this.lblPath.TabIndex = 11;
			this.lblPath.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblPath.Enabled = true;
			this.lblPath.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblPath.UseMnemonic = true;
			this.lblPath.Visible = true;
			this.lblPath.AutoSize = false;
			this.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblPath.Name = "lblPath";
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_2.Text = "Price";
			this._lbl_2.Size = new System.Drawing.Size(24, 13);
			this._lbl_2.Location = new System.Drawing.Point(57, 102);
			this._lbl_2.TabIndex = 4;
			this._lbl_2.BackColor = System.Drawing.SystemColors.Control;
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
			this._lbl_1.Text = "Surcharges";
			this._lbl_1.Size = new System.Drawing.Size(54, 13);
			this._lbl_1.Location = new System.Drawing.Point(24, 150);
			this._lbl_1.TabIndex = 8;
			this._lbl_1.BackColor = System.Drawing.SystemColors.Control;
			this._lbl_1.Enabled = true;
			this._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.UseMnemonic = true;
			this._lbl_1.Visible = true;
			this._lbl_1.AutoSize = true;
			this._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_1.Name = "_lbl_1";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label1.Text = "Discount";
			this.Label1.Size = new System.Drawing.Size(42, 13);
			this.Label1.Location = new System.Drawing.Point(36, 129);
			this.Label1.TabIndex = 6;
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = true;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_0.Text = "Quantity";
			this._lbl_0.Size = new System.Drawing.Size(39, 13);
			this._lbl_0.Location = new System.Drawing.Point(41, 81);
			this._lbl_0.TabIndex = 2;
			this._lbl_0.BackColor = System.Drawing.SystemColors.Control;
			this._lbl_0.Enabled = true;
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.UseMnemonic = true;
			this._lbl_0.Visible = true;
			this._lbl_0.AutoSize = true;
			this._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_0.Name = "_lbl_0";
			this.lblName.Text = "Label1";
			this.lblName.Size = new System.Drawing.Size(289, 16);
			this.lblName.Location = new System.Drawing.Point(12, 33);
			this.lblName.TabIndex = 0;
			this.lblName.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblName.BackColor = System.Drawing.SystemColors.Control;
			this.lblName.Enabled = true;
			this.lblName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblName.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblName.UseMnemonic = true;
			this.lblName.Visible = true;
			this.lblName.AutoSize = false;
			this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblName.Name = "lblName";
			this.Controls.Add(txtPrice);
			this.Controls.Add(cmdProceed);
			this.Controls.Add(txtDiscountMinus);
			this.Controls.Add(txtDiscountPlus);
			this.Controls.Add(txtQuantity);
			this.Controls.Add(chkBreakPack);
			this.Controls.Add(lblPath);
			this.Controls.Add(_lbl_2);
			this.Controls.Add(_lbl_1);
			this.Controls.Add(Label1);
			this.Controls.Add(_lbl_0);
			this.Controls.Add(lblName);
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
