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
	partial class frmStockList
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockList() : base()
		{
			FormClosed += frmStockList_FormClosed;
			KeyPress += frmStockList_KeyPress;
			KeyDown += frmStockList_KeyDown;
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
		private System.Windows.Forms.Button withEventsField_cmdBOM;
		public System.Windows.Forms.Button cmdBOM {
			get { return withEventsField_cmdBOM; }
			set {
				if (withEventsField_cmdBOM != null) {
					withEventsField_cmdBOM.Click -= cmdBOM_Click;
				}
				withEventsField_cmdBOM = value;
				if (withEventsField_cmdBOM != null) {
					withEventsField_cmdBOM.Click += cmdBOM_Click;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtSearch;
		public System.Windows.Forms.TextBox txtSearch {
			get { return withEventsField_txtSearch; }
			set {
				if (withEventsField_txtSearch != null) {
					withEventsField_txtSearch.Enter -= txtSearch_Enter;
					withEventsField_txtSearch.KeyDown -= txtSearch_KeyDown;
					withEventsField_txtSearch.KeyPress -= txtSearch_KeyPress;
				}
				withEventsField_txtSearch = value;
				if (withEventsField_txtSearch != null) {
					withEventsField_txtSearch.Enter += txtSearch_Enter;
					withEventsField_txtSearch.KeyDown += txtSearch_KeyDown;
					withEventsField_txtSearch.KeyPress += txtSearch_KeyPress;
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
		private myDataGridView withEventsField_DataList1;
		public myDataGridView DataList1 {
			get { return withEventsField_DataList1; }
			set {
				if (withEventsField_DataList1 != null) {
					withEventsField_DataList1.DoubleClick -= DataList1_DblClick;
					withEventsField_DataList1.KeyPress -= DataList1_KeyPress;
				}
				withEventsField_DataList1 = value;
				if (withEventsField_DataList1 != null) {
					withEventsField_DataList1.DoubleClick += DataList1_DblClick;
					withEventsField_DataList1.KeyPress += DataList1_KeyPress;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtBCode;
		public System.Windows.Forms.TextBox txtBCode {
			get { return withEventsField_txtBCode; }
			set {
				if (withEventsField_txtBCode != null) {
					withEventsField_txtBCode.Enter -= txtBCode_Enter;
					withEventsField_txtBCode.KeyDown -= txtBCode_KeyDown;
					withEventsField_txtBCode.KeyPress -= txtBCode_KeyPress;
				}
				withEventsField_txtBCode = value;
				if (withEventsField_txtBCode != null) {
					withEventsField_txtBCode.Enter += txtBCode_Enter;
					withEventsField_txtBCode.KeyDown += txtBCode_KeyDown;
					withEventsField_txtBCode.KeyPress += txtBCode_KeyPress;
				}
			}
		}
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.Label lblRecords;
		public System.Windows.Forms.Label lbl;
		public System.Windows.Forms.Label lblHeading;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockList));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdBOM = new System.Windows.Forms.Button();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdNamespace = new System.Windows.Forms.Button();
			this.DataList1 = new myDataGridView();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.txtBCode = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.lblRecords = new System.Windows.Forms.Label();
			this.lbl = new System.Windows.Forms.Label();
			this.lblHeading = new System.Windows.Forms.Label();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.DataList1).BeginInit();
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Select a Stock Item";
			this.ClientSize = new System.Drawing.Size(352, 449);
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
			this.Name = "frmStockList";
			this.cmdBOM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBOM.Text = "&Show Items with Bill of Materials";
			this.cmdBOM.Size = new System.Drawing.Size(97, 52);
			this.cmdBOM.Location = new System.Drawing.Point(250, 96);
			this.cmdBOM.TabIndex = 10;
			this.cmdBOM.TabStop = false;
			this.cmdBOM.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBOM.CausesValidation = true;
			this.cmdBOM.Enabled = true;
			this.cmdBOM.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBOM.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBOM.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBOM.Name = "cmdBOM";
			this.txtSearch.AutoSize = false;
			this.txtSearch.Size = new System.Drawing.Size(294, 19);
			this.txtSearch.Location = new System.Drawing.Point(53, 8);
			this.txtSearch.TabIndex = 0;
			this.txtSearch.AcceptsReturn = true;
			this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
			this.txtSearch.CausesValidation = true;
			this.txtSearch.Enabled = true;
			this.txtSearch.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtSearch.HideSelection = true;
			this.txtSearch.ReadOnly = false;
			this.txtSearch.MaxLength = 0;
			this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSearch.Multiline = false;
			this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtSearch.TabStop = true;
			this.txtSearch.Visible = true;
			this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtSearch.Name = "txtSearch";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(97, 52);
			this.cmdExit.Location = new System.Drawing.Point(252, 318);
			this.cmdExit.TabIndex = 6;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.cmdNamespace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNamespace.Text = "&Filter";
			this.cmdNamespace.Size = new System.Drawing.Size(97, 52);
			this.cmdNamespace.Location = new System.Drawing.Point(250, 32);
			this.cmdNamespace.TabIndex = 5;
			this.cmdNamespace.TabStop = false;
			this.cmdNamespace.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNamespace.CausesValidation = true;
			this.cmdNamespace.Enabled = true;
			this.cmdNamespace.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNamespace.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNamespace.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNamespace.Name = "cmdNamespace";
			//'DataList1.OcxState = CType(resources.GetObject("'DataList1.OcxState"), System.Windows.Forms.AxHost.State)
			this.DataList1.Size = new System.Drawing.Size(244, 342);
			this.DataList1.Location = new System.Drawing.Point(2, 32);
			this.DataList1.TabIndex = 4;
			this.DataList1.Name = "DataList1";
			this.Frame1.Text = "Search . . .";
			this.Frame1.Size = new System.Drawing.Size(345, 73);
			this.Frame1.Location = new System.Drawing.Point(2, 32);
			this.Frame1.TabIndex = 1;
			this.Frame1.Visible = false;
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.txtBCode.AutoSize = false;
			this.txtBCode.Size = new System.Drawing.Size(182, 19);
			this.txtBCode.Location = new System.Drawing.Point(59, 16);
			this.txtBCode.TabIndex = 2;
			this.txtBCode.AcceptsReturn = true;
			this.txtBCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtBCode.BackColor = System.Drawing.SystemColors.Window;
			this.txtBCode.CausesValidation = true;
			this.txtBCode.Enabled = true;
			this.txtBCode.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtBCode.HideSelection = true;
			this.txtBCode.ReadOnly = false;
			this.txtBCode.MaxLength = 0;
			this.txtBCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtBCode.Multiline = false;
			this.txtBCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtBCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtBCode.TabStop = true;
			this.txtBCode.Visible = true;
			this.txtBCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtBCode.Name = "txtBCode";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label1.Text = "&Barcode :";
			this.Label1.Size = new System.Drawing.Size(46, 13);
			this.Label1.Location = new System.Drawing.Point(10, 21);
			this.Label1.TabIndex = 3;
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = true;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.lblRecords.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblRecords.Font = new System.Drawing.Font("Verdana", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblRecords.Size = new System.Drawing.Size(337, 15);
			this.lblRecords.Location = new System.Drawing.Point(8, 426);
			this.lblRecords.TabIndex = 9;
			this.lblRecords.BackColor = System.Drawing.SystemColors.Control;
			this.lblRecords.Enabled = true;
			this.lblRecords.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblRecords.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblRecords.UseMnemonic = true;
			this.lblRecords.Visible = true;
			this.lblRecords.AutoSize = false;
			this.lblRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblRecords.Name = "lblRecords";
			this.lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lbl.Text = "&Search :";
			this.lbl.Size = new System.Drawing.Size(40, 13);
			this.lbl.Location = new System.Drawing.Point(8, 8);
			this.lbl.TabIndex = 8;
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
			this.lblHeading.Text = "Using the \"Stock Item Selector\" .....";
			this.lblHeading.Size = new System.Drawing.Size(349, 70);
			this.lblHeading.Location = new System.Drawing.Point(0, 376);
			this.lblHeading.TabIndex = 7;
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
			this.Controls.Add(cmdBOM);
			this.Controls.Add(txtSearch);
			this.Controls.Add(cmdExit);
			this.Controls.Add(cmdNamespace);
			this.Controls.Add(DataList1);
			this.Controls.Add(Frame1);
			this.Controls.Add(lblRecords);
			this.Controls.Add(lbl);
			this.Controls.Add(lblHeading);
			this.Frame1.Controls.Add(txtBCode);
			this.Frame1.Controls.Add(Label1);
			((System.ComponentModel.ISupportInitialize)this.DataList1).EndInit();
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
