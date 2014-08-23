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
	partial class frmStockMultiName
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockMultiName() : base()
		{
			FormClosed += frmStockMultiName_FormClosed;
			Resize += frmStockMultiName_Resize;
			Load += frmStockMultiName_Load;
			KeyPress += frmStockMultiName_KeyPress;
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
		private System.Windows.Forms.Button withEventsField_cmdFilter;
		public System.Windows.Forms.Button cmdFilter {
			get { return withEventsField_cmdFilter; }
			set {
				if (withEventsField_cmdFilter != null) {
					withEventsField_cmdFilter.Click -= cmdFilter_Click;
				}
				withEventsField_cmdFilter = value;
				if (withEventsField_cmdFilter != null) {
					withEventsField_cmdFilter.Click += cmdFilter_Click;
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
		public System.Windows.Forms.Label lblHeading;
		public System.Windows.Forms.Panel picButtons;
		public myDataGridView grdDataGrid;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockMultiName));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdFilter = new System.Windows.Forms.Button();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.lblHeading = new System.Windows.Forms.Label();
			this.grdDataGrid = new myDataGridView();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.grdDataGrid).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Text = "Edit Stock Item Names";
			this.ClientSize = new System.Drawing.Size(565, 493);
			this.Location = new System.Drawing.Point(73, 22);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmStockMultiName";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.ForeColor = System.Drawing.SystemColors.WindowText;
			this.picButtons.Size = new System.Drawing.Size(565, 68);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 1;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.picButtons.Name = "picButtons";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.Size = new System.Drawing.Size(73, 62);
			this.cmdClose.Location = new System.Drawing.Point(489, 3);
			this.cmdClose.TabIndex = 4;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.TabStop = true;
			this.cmdClose.Name = "cmdClose";
			this.cmdFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdFilter.Text = "&Filter";
			this.cmdFilter.Size = new System.Drawing.Size(73, 29);
			this.cmdFilter.Location = new System.Drawing.Point(411, 3);
			this.cmdFilter.TabIndex = 3;
			this.cmdFilter.TabStop = false;
			this.cmdFilter.BackColor = System.Drawing.SystemColors.Control;
			this.cmdFilter.CausesValidation = true;
			this.cmdFilter.Enabled = true;
			this.cmdFilter.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdFilter.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdFilter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdFilter.Name = "cmdFilter";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.Size = new System.Drawing.Size(73, 29);
			this.cmdPrint.Location = new System.Drawing.Point(411, 36);
			this.cmdPrint.TabIndex = 2;
			this.cmdPrint.TabStop = false;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Name = "cmdPrint";
			this.lblHeading.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.lblHeading.Text = "Using the \"Stock Item Selector\" .....";
			this.lblHeading.Size = new System.Drawing.Size(403, 61);
			this.lblHeading.Location = new System.Drawing.Point(3, 3);
			this.lblHeading.TabIndex = 5;
			this.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblHeading.Enabled = true;
			this.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblHeading.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblHeading.UseMnemonic = true;
			this.lblHeading.Visible = true;
			this.lblHeading.AutoSize = false;
			this.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblHeading.Name = "lblHeading";
			//grdDataGrid.OcxState = CType(resources.GetObject("grdDataGrid.OcxState"), System.Windows.Forms.AxHost.State)
			this.grdDataGrid.Dock = System.Windows.Forms.DockStyle.Top;
			this.grdDataGrid.Size = new System.Drawing.Size(565, 233);
			this.grdDataGrid.Location = new System.Drawing.Point(0, 68);
			this.grdDataGrid.TabIndex = 0;
			this.grdDataGrid.Name = "grdDataGrid";
			this.Controls.Add(picButtons);
			this.Controls.Add(grdDataGrid);
			this.picButtons.Controls.Add(cmdClose);
			this.picButtons.Controls.Add(cmdFilter);
			this.picButtons.Controls.Add(cmdPrint);
			this.picButtons.Controls.Add(lblHeading);
			((System.ComponentModel.ISupportInitialize)this.grdDataGrid).EndInit();
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
