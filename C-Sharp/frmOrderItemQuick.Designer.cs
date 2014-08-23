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
	partial class frmOrderItemQuick
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmOrderItemQuick() : base()
		{
			Load += frmOrderItemQuick_Load;
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
		private System.Windows.Forms.TextBox withEventsField_txtMin;
		public System.Windows.Forms.TextBox txtMin {
			get { return withEventsField_txtMin; }
			set {
				if (withEventsField_txtMin != null) {
					withEventsField_txtMin.Enter -= txtMin_Enter;
					withEventsField_txtMin.KeyPress -= txtMin_KeyPress;
					withEventsField_txtMin.Leave -= txtMin_Leave;
				}
				withEventsField_txtMin = value;
				if (withEventsField_txtMin != null) {
					withEventsField_txtMin.Enter += txtMin_Enter;
					withEventsField_txtMin.KeyPress += txtMin_KeyPress;
					withEventsField_txtMin.Leave += txtMin_Leave;
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
		private System.Windows.Forms.TextBox withEventsField_txtMax;
		public System.Windows.Forms.TextBox txtMax {
			get { return withEventsField_txtMax; }
			set {
				if (withEventsField_txtMax != null) {
					withEventsField_txtMax.Enter -= txtMax_Enter;
					withEventsField_txtMax.KeyPress -= txtMax_KeyPress;
					withEventsField_txtMax.Leave -= txtMax_Leave;
				}
				withEventsField_txtMax = value;
				if (withEventsField_txtMax != null) {
					withEventsField_txtMax.Enter += txtMax_Enter;
					withEventsField_txtMax.KeyPress += txtMax_KeyPress;
					withEventsField_txtMax.Leave += txtMax_Leave;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtCost;
		public System.Windows.Forms.TextBox txtCost {
			get { return withEventsField_txtCost; }
			set {
				if (withEventsField_txtCost != null) {
					withEventsField_txtCost.Enter -= txtCost_Enter;
					withEventsField_txtCost.KeyPress -= txtCost_KeyPress;
					withEventsField_txtCost.Leave -= txtCost_Leave;
				}
				withEventsField_txtCost = value;
				if (withEventsField_txtCost != null) {
					withEventsField_txtCost.Enter += txtCost_Enter;
					withEventsField_txtCost.KeyPress += txtCost_KeyPress;
					withEventsField_txtCost.Leave += txtCost_Leave;
				}
			}
		}
		public System.Windows.Forms.Label lblPath;
		public System.Windows.Forms.Label _lbl_2;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmOrderItemQuick));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.txtMin = new System.Windows.Forms.TextBox();
			this.cmdProceed = new System.Windows.Forms.Button();
			this.txtMax = new System.Windows.Forms.TextBox();
			this.txtCost = new System.Windows.Forms.TextBox();
			this.lblPath = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.ClientSize = new System.Drawing.Size(313, 176);
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
			this.Name = "frmOrderItemQuick";
			this.txtMin.AutoSize = false;
			this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtMin.Size = new System.Drawing.Size(217, 19);
			this.txtMin.Location = new System.Drawing.Point(84, 86);
			this.txtMin.TabIndex = 0;
			this.txtMin.Text = "Text1";
			this.txtMin.AcceptsReturn = true;
			this.txtMin.BackColor = System.Drawing.SystemColors.Window;
			this.txtMin.CausesValidation = true;
			this.txtMin.Enabled = true;
			this.txtMin.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtMin.HideSelection = true;
			this.txtMin.ReadOnly = false;
			this.txtMin.MaxLength = 0;
			this.txtMin.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMin.Multiline = false;
			this.txtMin.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtMin.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtMin.TabStop = true;
			this.txtMin.Visible = true;
			this.txtMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtMin.Name = "txtMin";
			this.cmdProceed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdProceed.Text = "&Proceed";
			this.cmdProceed.Size = new System.Drawing.Size(85, 31);
			this.cmdProceed.Location = new System.Drawing.Point(216, 136);
			this.cmdProceed.TabIndex = 2;
			this.cmdProceed.BackColor = System.Drawing.SystemColors.Control;
			this.cmdProceed.CausesValidation = true;
			this.cmdProceed.Enabled = true;
			this.cmdProceed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdProceed.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdProceed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdProceed.TabStop = true;
			this.cmdProceed.Name = "cmdProceed";
			this.txtMax.AutoSize = false;
			this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtMax.Size = new System.Drawing.Size(217, 19);
			this.txtMax.Location = new System.Drawing.Point(84, 110);
			this.txtMax.TabIndex = 1;
			this.txtMax.Text = "Text1";
			this.txtMax.AcceptsReturn = true;
			this.txtMax.BackColor = System.Drawing.SystemColors.Window;
			this.txtMax.CausesValidation = true;
			this.txtMax.Enabled = true;
			this.txtMax.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtMax.HideSelection = true;
			this.txtMax.ReadOnly = false;
			this.txtMax.MaxLength = 0;
			this.txtMax.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMax.Multiline = false;
			this.txtMax.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtMax.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtMax.TabStop = true;
			this.txtMax.Visible = true;
			this.txtMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtMax.Name = "txtMax";
			this.txtCost.AutoSize = false;
			this.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtCost.Enabled = false;
			this.txtCost.Size = new System.Drawing.Size(217, 19);
			this.txtCost.Location = new System.Drawing.Point(84, 62);
			this.txtCost.TabIndex = 5;
			this.txtCost.TabStop = false;
			this.txtCost.Text = "Text1";
			this.txtCost.AcceptsReturn = true;
			this.txtCost.BackColor = System.Drawing.SystemColors.Window;
			this.txtCost.CausesValidation = true;
			this.txtCost.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCost.HideSelection = true;
			this.txtCost.ReadOnly = false;
			this.txtCost.MaxLength = 0;
			this.txtCost.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtCost.Multiline = false;
			this.txtCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtCost.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtCost.Visible = true;
			this.txtCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtCost.Name = "txtCost";
			this.lblPath.BackColor = System.Drawing.Color.Blue;
			this.lblPath.Text = "Stock Re-order Quick Edit";
			this.lblPath.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblPath.ForeColor = System.Drawing.Color.White;
			this.lblPath.Size = new System.Drawing.Size(568, 25);
			this.lblPath.Location = new System.Drawing.Point(0, 0);
			this.lblPath.TabIndex = 8;
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
			this._lbl_2.Text = "Minimum";
			this._lbl_2.Size = new System.Drawing.Size(41, 13);
			this._lbl_2.Location = new System.Drawing.Point(40, 86);
			this._lbl_2.TabIndex = 6;
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
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label1.Text = "Maximum";
			this.Label1.Size = new System.Drawing.Size(44, 13);
			this.Label1.Location = new System.Drawing.Point(34, 113);
			this.Label1.TabIndex = 7;
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
			this._lbl_0.Text = "Cost";
			this._lbl_0.Size = new System.Drawing.Size(21, 13);
			this._lbl_0.Location = new System.Drawing.Point(59, 65);
			this._lbl_0.TabIndex = 4;
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
			this.lblName.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblName.Size = new System.Drawing.Size(289, 16);
			this.lblName.Location = new System.Drawing.Point(12, 33);
			this.lblName.TabIndex = 3;
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
			this.Controls.Add(txtMin);
			this.Controls.Add(cmdProceed);
			this.Controls.Add(txtMax);
			this.Controls.Add(txtCost);
			this.Controls.Add(lblPath);
			this.Controls.Add(_lbl_2);
			this.Controls.Add(Label1);
			this.Controls.Add(_lbl_0);
			this.Controls.Add(lblName);
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
