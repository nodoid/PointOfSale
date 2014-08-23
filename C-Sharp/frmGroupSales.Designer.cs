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
	partial class frmGroupSales
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmGroupSales() : base()
		{
			Load += frmGroupSales_Load;
			KeyPress += frmGroupSales_KeyPress;
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
		public System.Windows.Forms.ComboBox cmbMinor;
		public System.Windows.Forms.ComboBox cmbMajor;
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
		private System.Windows.Forms.Button withEventsField_cmdLoad;
		public System.Windows.Forms.Button cmdLoad {
			get { return withEventsField_cmdLoad; }
			set {
				if (withEventsField_cmdLoad != null) {
					withEventsField_cmdLoad.Click -= cmdLoad_Click;
				}
				withEventsField_cmdLoad = value;
				if (withEventsField_cmdLoad != null) {
					withEventsField_cmdLoad.Click += cmdLoad_Click;
				}
			}
		}
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lbl_0;
		public Microsoft.VisualBasic.Compatibility.VB6.LabelArray lbl;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGroupSales));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmbMinor = new System.Windows.Forms.ComboBox();
			this.cmbMajor = new System.Windows.Forms.ComboBox();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdLoad = new System.Windows.Forms.Button();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.lbl = new Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components);
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.lbl).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Group Sales Profitability Order Criteria";
			this.ClientSize = new System.Drawing.Size(447, 152);
			this.Location = new System.Drawing.Point(3, 22);
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
			this.Name = "frmGroupSales";
			this.cmbMinor.Size = new System.Drawing.Size(400, 21);
			this.cmbMinor.Location = new System.Drawing.Point(36, 78);
			this.cmbMinor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMinor.TabIndex = 3;
			this.cmbMinor.BackColor = System.Drawing.SystemColors.Window;
			this.cmbMinor.CausesValidation = true;
			this.cmbMinor.Enabled = true;
			this.cmbMinor.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbMinor.IntegralHeight = true;
			this.cmbMinor.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbMinor.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbMinor.Sorted = false;
			this.cmbMinor.TabStop = true;
			this.cmbMinor.Visible = true;
			this.cmbMinor.Name = "cmbMinor";
			this.cmbMajor.Size = new System.Drawing.Size(400, 21);
			this.cmbMajor.Location = new System.Drawing.Point(36, 27);
			this.cmbMajor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMajor.TabIndex = 1;
			this.cmbMajor.BackColor = System.Drawing.SystemColors.Window;
			this.cmbMajor.CausesValidation = true;
			this.cmbMajor.Enabled = true;
			this.cmbMajor.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbMajor.IntegralHeight = true;
			this.cmbMajor.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbMajor.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbMajor.Sorted = false;
			this.cmbMajor.TabStop = true;
			this.cmbMajor.Visible = true;
			this.cmbMajor.Name = "cmbMajor";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(79, 31);
			this.cmdExit.Location = new System.Drawing.Point(12, 111);
			this.cmdExit.TabIndex = 4;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdLoad.Text = "&Load report >>";
			this.cmdLoad.Size = new System.Drawing.Size(79, 31);
			this.cmdLoad.Location = new System.Drawing.Point(357, 111);
			this.cmdLoad.TabIndex = 5;
			this.cmdLoad.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLoad.CausesValidation = true;
			this.cmdLoad.Enabled = true;
			this.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLoad.TabStop = true;
			this.cmdLoad.Name = "cmdLoad";
			this._lbl_1.Text = "&2. Select the Minor Break Group";
			this._lbl_1.Size = new System.Drawing.Size(184, 13);
			this._lbl_1.Location = new System.Drawing.Point(9, 57);
			this._lbl_1.TabIndex = 2;
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
			this._lbl_0.Text = "&1. Select the Major Break Group";
			this._lbl_0.Size = new System.Drawing.Size(184, 13);
			this._lbl_0.Location = new System.Drawing.Point(9, 9);
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
			this.Controls.Add(cmbMinor);
			this.Controls.Add(cmbMajor);
			this.Controls.Add(cmdExit);
			this.Controls.Add(cmdLoad);
			this.Controls.Add(_lbl_1);
			this.Controls.Add(_lbl_0);
			this.lbl.SetIndex(_lbl_1, Convert.ToInt16(1));
			this.lbl.SetIndex(_lbl_0, Convert.ToInt16(0));
			((System.ComponentModel.ISupportInitialize)this.lbl).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
