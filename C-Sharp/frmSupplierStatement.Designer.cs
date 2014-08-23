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
	partial class frmSupplierStatement
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmSupplierStatement() : base()
		{
			KeyPress += frmSupplierStatement_KeyPress;
			FormClosed += frmSupplierStatement_FormClosed;
			Load += frmSupplierStatement_Load;
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
		public System.Windows.Forms.ComboBox cmbMonth;
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
		public System.Windows.Forms.Panel picButtons;
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
		public System.Windows.Forms.Label lbl;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSupplierStatement));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmbMonth = new System.Windows.Forms.ComboBox();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this.DataList1 = new myDataGridView();
			this.lbl = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.DataList1).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Supplier Previous Statements";
			this.ClientSize = new System.Drawing.Size(263, 425);
			this.Location = new System.Drawing.Point(3, 22);
			this.ControlBox = false;
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
			this.Name = "frmSupplierStatement";
			this.txtSearch.AutoSize = false;
			this.txtSearch.Size = new System.Drawing.Size(199, 19);
			this.txtSearch.Location = new System.Drawing.Point(54, 48);
			this.txtSearch.TabIndex = 1;
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
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(263, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 4;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmbMonth.Size = new System.Drawing.Size(88, 21);
			this.cmbMonth.Location = new System.Drawing.Point(84, 6);
			this.cmbMonth.Items.AddRange(new object[] {
				"Last Month",
				"2 Months Ago",
				"3 Months Ago",
				"4 Months Ago",
				"5 Months Ago",
				"6 Months Ago"
			});
			this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMonth.TabIndex = 3;
			this.cmbMonth.BackColor = System.Drawing.SystemColors.Window;
			this.cmbMonth.CausesValidation = true;
			this.cmbMonth.Enabled = true;
			this.cmbMonth.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbMonth.IntegralHeight = true;
			this.cmbMonth.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbMonth.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbMonth.Sorted = false;
			this.cmbMonth.TabStop = true;
			this.cmbMonth.Visible = true;
			this.cmbMonth.Name = "cmbMonth";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.Size = new System.Drawing.Size(73, 29);
			this.cmdPrint.Location = new System.Drawing.Point(5, 3);
			this.cmdPrint.TabIndex = 6;
			this.cmdPrint.TabStop = false;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(73, 29);
			this.cmdExit.Location = new System.Drawing.Point(177, 3);
			this.cmdExit.TabIndex = 5;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			//DataList1.OcxState = CType(resources.GetObject("'DataList1.OcxState"), System.Windows.Forms.AxHost.State)
			this.DataList1.Size = new System.Drawing.Size(244, 342);
			this.DataList1.Location = new System.Drawing.Point(9, 72);
			this.DataList1.TabIndex = 2;
			this.DataList1.Name = "DataList1";
			this.lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lbl.Text = "&Search :";
			this.lbl.Size = new System.Drawing.Size(40, 13);
			this.lbl.Location = new System.Drawing.Point(11, 51);
			this.lbl.TabIndex = 0;
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
			this.Controls.Add(txtSearch);
			this.Controls.Add(picButtons);
			this.Controls.Add(DataList1);
			this.Controls.Add(lbl);
			this.picButtons.Controls.Add(cmbMonth);
			this.picButtons.Controls.Add(cmdPrint);
			this.picButtons.Controls.Add(cmdExit);
			((System.ComponentModel.ISupportInitialize)this.DataList1).EndInit();
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
