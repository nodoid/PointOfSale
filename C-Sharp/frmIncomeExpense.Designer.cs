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
	partial class frmIncomeExpense
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmIncomeExpense() : base()
		{
			Load += frmIncomeExpense_Load;
			KeyPress += frmIncomeExpense_KeyPress;
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
		public System.Windows.Forms.ComboBox cmbMonthEnd;
		public System.Windows.Forms.Label lbl;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmIncomeExpense));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdLoad = new System.Windows.Forms.Button();
			this.cmbMonthEnd = new System.Windows.Forms.ComboBox();
			this.lbl = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Income and Expense Report";
			this.ClientSize = new System.Drawing.Size(448, 94);
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
			this.Name = "frmIncomeExpense";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(172, 31);
			this.cmdExit.Location = new System.Drawing.Point(267, 54);
			this.cmdExit.TabIndex = 3;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.TabStop = true;
			this.cmdExit.Name = "cmdExit";
			this.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdLoad.Text = "&Load Report";
			this.cmdLoad.Size = new System.Drawing.Size(172, 31);
			this.cmdLoad.Location = new System.Drawing.Point(12, 54);
			this.cmdLoad.TabIndex = 1;
			this.cmdLoad.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLoad.CausesValidation = true;
			this.cmdLoad.Enabled = true;
			this.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLoad.TabStop = true;
			this.cmdLoad.Name = "cmdLoad";
			this.cmbMonthEnd.Size = new System.Drawing.Size(427, 21);
			this.cmbMonthEnd.Location = new System.Drawing.Point(12, 27);
			this.cmbMonthEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMonthEnd.TabIndex = 0;
			this.cmbMonthEnd.BackColor = System.Drawing.SystemColors.Window;
			this.cmbMonthEnd.CausesValidation = true;
			this.cmbMonthEnd.Enabled = true;
			this.cmbMonthEnd.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbMonthEnd.IntegralHeight = true;
			this.cmbMonthEnd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbMonthEnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbMonthEnd.Sorted = false;
			this.cmbMonthEnd.TabStop = true;
			this.cmbMonthEnd.Visible = true;
			this.cmbMonthEnd.Name = "cmbMonthEnd";
			this.lbl.Text = "&1.Select the Month-end Period for the Report.";
			this.lbl.Size = new System.Drawing.Size(215, 13);
			this.lbl.Location = new System.Drawing.Point(15, 6);
			this.lbl.TabIndex = 2;
			this.lbl.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lbl.BackColor = System.Drawing.Color.Transparent;
			this.lbl.Enabled = true;
			this.lbl.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbl.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl.UseMnemonic = true;
			this.lbl.Visible = true;
			this.lbl.AutoSize = true;
			this.lbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbl.Name = "lbl";
			this.Controls.Add(cmdExit);
			this.Controls.Add(cmdLoad);
			this.Controls.Add(cmbMonthEnd);
			this.Controls.Add(lbl);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
