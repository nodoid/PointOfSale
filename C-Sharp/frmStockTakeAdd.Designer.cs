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
	partial class frmStockTakeAdd
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockTakeAdd() : base()
		{
			FormClosed += frmStockTakeAdd_FormClosed;
			KeyPress += frmStockTakeAdd_KeyPress;
			Resize += frmStockTakeAdd_Resize;
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
		public System.Windows.Forms.TextBox txtSARef;
		private System.Windows.Forms.Button withEventsField_cmdPrintSlip;
		public System.Windows.Forms.Button cmdPrintSlip {
			get { return withEventsField_cmdPrintSlip; }
			set {
				if (withEventsField_cmdPrintSlip != null) {
					withEventsField_cmdPrintSlip.Click -= cmdPrintSlip_Click;
				}
				withEventsField_cmdPrintSlip = value;
				if (withEventsField_cmdPrintSlip != null) {
					withEventsField_cmdPrintSlip.Click += cmdPrintSlip_Click;
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
		private myDataGridView withEventsField_grdDataGrid1;
		public myDataGridView grdDataGrid1 {
			get { return withEventsField_grdDataGrid1; }
			set {
				if (withEventsField_grdDataGrid1 != null) {
					withEventsField_grdDataGrid1.CellValueChanged -= grdDataGrid1_CellValueChanged;
				}
				withEventsField_grdDataGrid1 = value;
				if (withEventsField_grdDataGrid1 != null) {
					withEventsField_grdDataGrid1.CellValueChanged += grdDataGrid1_CellValueChanged;
				}
			}
		}
		public System.Windows.Forms.Panel grdDataGrid;
		public System.Windows.Forms.Label lbl;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockTakeAdd));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.txtSARef = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdPrintSlip = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.lblHeading = new System.Windows.Forms.Label();
			this.grdDataGrid = new System.Windows.Forms.Panel();
			this.grdDataGrid1 = new myDataGridView();
			this.lbl = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.grdDataGrid.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.grdDataGrid1).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Text = "Stock Take Add(This option only add stock to your quantities and is not a stock take)";
			this.ClientSize = new System.Drawing.Size(564, 555);
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
			this.Name = "frmStockTakeAdd";
			this.txtSARef.AutoSize = false;
			this.txtSARef.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.txtSARef.Size = new System.Drawing.Size(486, 22);
			this.txtSARef.Location = new System.Drawing.Point(72, 528);
			this.txtSARef.TabIndex = 6;
			this.txtSARef.AcceptsReturn = true;
			this.txtSARef.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtSARef.CausesValidation = true;
			this.txtSARef.Enabled = true;
			this.txtSARef.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtSARef.HideSelection = true;
			this.txtSARef.ReadOnly = false;
			this.txtSARef.MaxLength = 0;
			this.txtSARef.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSARef.Multiline = false;
			this.txtSARef.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtSARef.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtSARef.TabStop = true;
			this.txtSARef.Visible = true;
			this.txtSARef.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtSARef.Name = "txtSARef";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.ForeColor = System.Drawing.SystemColors.WindowText;
			this.picButtons.Size = new System.Drawing.Size(564, 35);
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
			this.cmdPrintSlip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrintSlip.Text = "&Print Slip";
			this.cmdPrintSlip.Size = new System.Drawing.Size(73, 29);
			this.cmdPrintSlip.Location = new System.Drawing.Point(336, 0);
			this.cmdPrintSlip.TabIndex = 8;
			this.cmdPrintSlip.TabStop = false;
			this.cmdPrintSlip.Visible = false;
			this.cmdPrintSlip.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrintSlip.CausesValidation = true;
			this.cmdPrintSlip.Enabled = true;
			this.cmdPrintSlip.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrintSlip.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrintSlip.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrintSlip.Name = "cmdPrintSlip";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.Location = new System.Drawing.Point(488, 2);
			this.cmdClose.TabIndex = 3;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.TabStop = true;
			this.cmdClose.Name = "cmdClose";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.Size = new System.Drawing.Size(73, 29);
			this.cmdPrint.Location = new System.Drawing.Point(411, 3);
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
			this.lblHeading.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblHeading.Size = new System.Drawing.Size(403, 22);
			this.lblHeading.Location = new System.Drawing.Point(3, 6);
			this.lblHeading.TabIndex = 4;
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
			this.grdDataGrid.Dock = System.Windows.Forms.DockStyle.Top;
			this.grdDataGrid.Size = new System.Drawing.Size(564, 486);
			this.grdDataGrid.Location = new System.Drawing.Point(0, 35);
			this.grdDataGrid.TabIndex = 0;
			this.grdDataGrid.BackColor = System.Drawing.SystemColors.Control;
			this.grdDataGrid.CausesValidation = true;
			this.grdDataGrid.Enabled = true;
			this.grdDataGrid.ForeColor = System.Drawing.SystemColors.ControlText;
			this.grdDataGrid.Cursor = System.Windows.Forms.Cursors.Default;
			this.grdDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grdDataGrid.TabStop = true;
			this.grdDataGrid.Visible = true;
			this.grdDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.grdDataGrid.Name = "grdDataGrid";
			//grdDataGrid1.OcxState = CType(resources.GetObject("grdDataGrid1.OcxState"), System.Windows.Forms.AxHost.State)
			this.grdDataGrid1.Size = new System.Drawing.Size(557, 247);
			this.grdDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.grdDataGrid1.TabIndex = 5;
			this.grdDataGrid1.Name = "grdDataGrid1";
			this.lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lbl.Text = "&Reference :";
			this.lbl.Size = new System.Drawing.Size(64, 22);
			this.lbl.Location = new System.Drawing.Point(0, 530);
			this.lbl.TabIndex = 7;
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
			this.Controls.Add(txtSARef);
			this.Controls.Add(picButtons);
			this.Controls.Add(grdDataGrid);
			this.Controls.Add(lbl);
			this.picButtons.Controls.Add(cmdPrintSlip);
			this.picButtons.Controls.Add(cmdClose);
			this.picButtons.Controls.Add(cmdPrint);
			this.picButtons.Controls.Add(lblHeading);
			this.grdDataGrid.Controls.Add(grdDataGrid1);
			((System.ComponentModel.ISupportInitialize)this.grdDataGrid1).EndInit();
			this.picButtons.ResumeLayout(false);
			this.grdDataGrid.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
