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
	partial class frmStockValSelect
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockValSelect() : base()
		{
			FormClosed += frmStockValSelect_FormClosed;
			Load += frmStockValSelect_Load;
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
		public System.Windows.Forms.CheckedListBox lstFilter;
		private System.Windows.Forms.CheckBox withEventsField_ckbGrp;
		public System.Windows.Forms.CheckBox ckbGrp {
			get { return withEventsField_ckbGrp; }
			set {
				if (withEventsField_ckbGrp != null) {
					withEventsField_ckbGrp.CheckStateChanged -= ckbGrp_CheckStateChanged;
				}
				withEventsField_ckbGrp = value;
				if (withEventsField_ckbGrp != null) {
					withEventsField_ckbGrp.CheckStateChanged += ckbGrp_CheckStateChanged;
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
		private System.Windows.Forms.Button withEventsField_cmdShow;
		public System.Windows.Forms.Button cmdShow {
			get { return withEventsField_cmdShow; }
			set {
				if (withEventsField_cmdShow != null) {
					withEventsField_cmdShow.Click -= cmdShow_Click;
				}
				withEventsField_cmdShow = value;
				if (withEventsField_cmdShow != null) {
					withEventsField_cmdShow.Click += cmdShow_Click;
				}
			}
		}
		public System.Windows.Forms.RadioButton optSum;
		public System.Windows.Forms.RadioButton optDel;
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
		public System.Windows.Forms.Label lblHeading;
		public System.Windows.Forms.Panel picButtons;
		private myDataGridView withEventsField_DataList1;
		public myDataGridView DataList1 {
			get { return withEventsField_DataList1; }
			set {
				if (withEventsField_DataList1 != null) {
					withEventsField_DataList1.Click -= DataList1_ClickEvent;
				}
				withEventsField_DataList1 = value;
				if (withEventsField_DataList1 != null) {
					withEventsField_DataList1.Click += DataList1_ClickEvent;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockValSelect));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.lstFilter = new System.Windows.Forms.CheckedListBox();
			this.ckbGrp = new System.Windows.Forms.CheckBox();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.cmdShow = new System.Windows.Forms.Button();
			this.optSum = new System.Windows.Forms.RadioButton();
			this.optDel = new System.Windows.Forms.RadioButton();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdClose = new System.Windows.Forms.Button();
			this.lblHeading = new System.Windows.Forms.Label();
			this.DataList1 = new myDataGridView();
			this.lbl = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.DataList1).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Stock Value Report";
			this.ClientSize = new System.Drawing.Size(354, 159);
			this.Location = new System.Drawing.Point(3, 22);
			this.ControlBox = false;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmStockValSelect";
			this.lstFilter.Size = new System.Drawing.Size(247, 79);
			this.lstFilter.Location = new System.Drawing.Point(8, 72);
			this.lstFilter.TabIndex = 10;
			this.lstFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstFilter.BackColor = System.Drawing.SystemColors.Window;
			this.lstFilter.CausesValidation = true;
			this.lstFilter.Enabled = true;
			this.lstFilter.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstFilter.IntegralHeight = true;
			this.lstFilter.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstFilter.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstFilter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstFilter.Sorted = false;
			this.lstFilter.TabStop = true;
			this.lstFilter.Visible = true;
			this.lstFilter.MultiColumn = false;
			this.lstFilter.Name = "lstFilter";
			this.ckbGrp.Text = "Select Group ?";
			this.ckbGrp.Size = new System.Drawing.Size(97, 17);
			this.ckbGrp.Location = new System.Drawing.Point(160, 48);
			this.ckbGrp.TabIndex = 9;
			this.ckbGrp.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ckbGrp.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.ckbGrp.BackColor = System.Drawing.SystemColors.Control;
			this.ckbGrp.CausesValidation = true;
			this.ckbGrp.Enabled = true;
			this.ckbGrp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ckbGrp.Cursor = System.Windows.Forms.Cursors.Default;
			this.ckbGrp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ckbGrp.Appearance = System.Windows.Forms.Appearance.Normal;
			this.ckbGrp.TabStop = true;
			this.ckbGrp.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.ckbGrp.Visible = true;
			this.ckbGrp.Name = "ckbGrp";
			this.txtSearch.AutoSize = false;
			this.txtSearch.Size = new System.Drawing.Size(94, 19);
			this.txtSearch.Location = new System.Drawing.Point(51, 46);
			this.txtSearch.TabIndex = 7;
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
			this.cmdShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdShow.Text = "&Print";
			this.cmdShow.Size = new System.Drawing.Size(73, 29);
			this.cmdShow.Location = new System.Drawing.Point(272, 124);
			this.cmdShow.TabIndex = 5;
			this.cmdShow.TabStop = false;
			this.cmdShow.BackColor = System.Drawing.SystemColors.Control;
			this.cmdShow.CausesValidation = true;
			this.cmdShow.Enabled = true;
			this.cmdShow.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdShow.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdShow.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdShow.Name = "cmdShow";
			this.optSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optSum.Text = "Summary";
			this.optSum.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optSum.Size = new System.Drawing.Size(96, 23);
			this.optSum.Location = new System.Drawing.Point(266, 86);
			this.optSum.TabIndex = 4;
			this.optSum.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optSum.BackColor = System.Drawing.SystemColors.Control;
			this.optSum.CausesValidation = true;
			this.optSum.Enabled = true;
			this.optSum.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optSum.Cursor = System.Windows.Forms.Cursors.Default;
			this.optSum.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optSum.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optSum.TabStop = true;
			this.optSum.Checked = false;
			this.optSum.Visible = true;
			this.optSum.Name = "optSum";
			this.optDel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optDel.Text = "Detail";
			this.optDel.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optDel.Size = new System.Drawing.Size(72, 23);
			this.optDel.Location = new System.Drawing.Point(266, 46);
			this.optDel.TabIndex = 3;
			this.optDel.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optDel.BackColor = System.Drawing.SystemColors.Control;
			this.optDel.CausesValidation = true;
			this.optDel.Enabled = true;
			this.optDel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optDel.Cursor = System.Windows.Forms.Cursors.Default;
			this.optDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optDel.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optDel.TabStop = true;
			this.optDel.Checked = false;
			this.optDel.Visible = true;
			this.optDel.Name = "optDel";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(354, 38);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 0;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.Location = new System.Drawing.Point(272, 2);
			this.cmdClose.TabIndex = 1;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this.lblHeading.Text = "Select option for Detail / Summary";
			this.lblHeading.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblHeading.ForeColor = System.Drawing.Color.White;
			this.lblHeading.Size = new System.Drawing.Size(273, 21);
			this.lblHeading.Location = new System.Drawing.Point(2, 8);
			this.lblHeading.TabIndex = 2;
			this.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblHeading.BackColor = System.Drawing.Color.Transparent;
			this.lblHeading.Enabled = true;
			this.lblHeading.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblHeading.UseMnemonic = true;
			this.lblHeading.Visible = true;
			this.lblHeading.AutoSize = false;
			this.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblHeading.Name = "lblHeading";
			//DataList1.OcxState = CType(resources.GetObject("'DataList1.OcxState"), System.Windows.Forms.AxHost.State)
			this.DataList1.Size = new System.Drawing.Size(244, 82);
			this.DataList1.Location = new System.Drawing.Point(8, 168);
			this.DataList1.TabIndex = 6;
			this.DataList1.Name = "DataList1";
			this.lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lbl.Text = "&Search :";
			this.lbl.Size = new System.Drawing.Size(40, 13);
			this.lbl.Location = new System.Drawing.Point(8, 49);
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
			this.Controls.Add(lstFilter);
			this.Controls.Add(ckbGrp);
			this.Controls.Add(txtSearch);
			this.Controls.Add(cmdShow);
			this.Controls.Add(optSum);
			this.Controls.Add(optDel);
			this.Controls.Add(picButtons);
			this.Controls.Add(DataList1);
			this.Controls.Add(lbl);
			this.picButtons.Controls.Add(cmdClose);
			this.picButtons.Controls.Add(lblHeading);
			((System.ComponentModel.ISupportInitialize)this.DataList1).EndInit();
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
