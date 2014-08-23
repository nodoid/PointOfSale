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
	partial class frmCustomerStatement
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmCustomerStatement() : base()
		{
			KeyPress += frmCustomerStatement_KeyPress;
			FormClosed += frmCustomerStatement_FormClosed;
			Load += frmCustomerStatement_Load;
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
		public System.Windows.Forms.CheckBox chkFields;
		public System.Windows.Forms.ComboBox cmbMonthEnd;
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
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.chkFields = new System.Windows.Forms.CheckBox();
			this.cmbMonthEnd = new System.Windows.Forms.ComboBox();
			this.cmbMonth = new System.Windows.Forms.ComboBox();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this.DataList1 = new _4PosBackOffice.NET.myDataGridView();
			this.lbl = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.DataList1).BeginInit();
			this.SuspendLayout();
			//
			//txtSearch
			//
			this.txtSearch.AcceptsReturn = true;
			this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
			this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSearch.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtSearch.Location = new System.Drawing.Point(54, 115);
			this.txtSearch.MaxLength = 0;
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtSearch.Size = new System.Drawing.Size(199, 19);
			this.txtSearch.TabIndex = 1;
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.chkFields);
			this.picButtons.Controls.Add(this.cmbMonthEnd);
			this.picButtons.Controls.Add(this.cmbMonth);
			this.picButtons.Controls.Add(this.cmdPrint);
			this.picButtons.Controls.Add(this.cmdExit);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(263, 109);
			this.picButtons.TabIndex = 4;
			//
			//chkFields
			//
			this.chkFields.BackColor = System.Drawing.Color.Blue;
			this.chkFields.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkFields.ForeColor = System.Drawing.Color.White;
			this.chkFields.Location = new System.Drawing.Point(7, 82);
			this.chkFields.Name = "chkFields";
			this.chkFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkFields.Size = new System.Drawing.Size(241, 23);
			this.chkFields.TabIndex = 8;
			this.chkFields.Text = "Do not print Payment Date on Statement :";
			this.chkFields.UseVisualStyleBackColor = false;
			//
			//cmbMonthEnd
			//
			this.cmbMonthEnd.BackColor = System.Drawing.SystemColors.Window;
			this.cmbMonthEnd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbMonthEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMonthEnd.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbMonthEnd.Location = new System.Drawing.Point(7, 31);
			this.cmbMonthEnd.Name = "cmbMonthEnd";
			this.cmbMonthEnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbMonthEnd.Size = new System.Drawing.Size(243, 21);
			this.cmbMonthEnd.TabIndex = 7;
			//
			//cmbMonth
			//
			this.cmbMonth.BackColor = System.Drawing.SystemColors.Window;
			this.cmbMonth.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMonth.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbMonth.Items.AddRange(new object[] {
				"Last Month",
				"2 Months Ago",
				"3 Months Ago",
				"4 Months Ago",
				"5 Months Ago",
				"6 Months Ago",
				"7 Months Ago",
				"8 Months Ago",
				"9 Months Ago",
				"10 Months Ago",
				"11 Months Ago",
				"12 Months Ago",
				"13 Months Ago",
				"14 Months Ago",
				"15 Months Ago"
			});
			this.cmbMonth.Location = new System.Drawing.Point(7, 8);
			this.cmbMonth.Name = "cmbMonth";
			this.cmbMonth.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbMonth.Size = new System.Drawing.Size(242, 21);
			this.cmbMonth.TabIndex = 3;
			this.cmbMonth.Visible = false;
			//
			//cmdPrint
			//
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Location = new System.Drawing.Point(5, 53);
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Size = new System.Drawing.Size(73, 29);
			this.cmdPrint.TabIndex = 6;
			this.cmdPrint.TabStop = false;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.UseVisualStyleBackColor = false;
			//
			//cmdExit
			//
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Location = new System.Drawing.Point(177, 53);
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Size = new System.Drawing.Size(73, 29);
			this.cmdExit.TabIndex = 5;
			this.cmdExit.TabStop = false;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.UseVisualStyleBackColor = false;
			//
			//DataList1
			//
			this.DataList1.AllowAddNew = true;
			this.DataList1.BoundText = "";
			this.DataList1.CellBackColor = System.Drawing.SystemColors.AppWorkspace;
			this.DataList1.Col = 0;
			this.DataList1.CtlText = "";
			this.DataList1.DataField = null;
			this.DataList1.Location = new System.Drawing.Point(9, 141);
			this.DataList1.Name = "DataList1";
			this.DataList1.row = 0;
			this.DataList1.Size = new System.Drawing.Size(244, 321);
			this.DataList1.TabIndex = 2;
			this.DataList1.TopRow = 0;
			//
			//lbl
			//
			this.lbl.AutoSize = true;
			this.lbl.BackColor = System.Drawing.Color.Transparent;
			this.lbl.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbl.Location = new System.Drawing.Point(6, 115);
			this.lbl.Name = "lbl";
			this.lbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl.Size = new System.Drawing.Size(47, 13);
			this.lbl.TabIndex = 0;
			this.lbl.Text = "&Search :";
			this.lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//frmCustomerStatement
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(263, 468);
			this.ControlBox = false;
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this.DataList1);
			this.Controls.Add(this.lbl);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Location = new System.Drawing.Point(3, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCustomerStatement";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Customer Statement Run";
			this.picButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.DataList1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
