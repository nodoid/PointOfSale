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
	partial class frmSupplierDeposits
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmSupplierDeposits() : base()
		{
			KeyDown += frmSupplierDeposits_KeyDown;
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
		public System.Windows.Forms.Button cmdCancel;
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.ColumnHeader _lvDeposit_ColumnHeader_1;
		public System.Windows.Forms.ColumnHeader _lvDeposit_ColumnHeader_2;
		public System.Windows.Forms.ColumnHeader _lvDeposit_ColumnHeader_3;
		private System.Windows.Forms.ListView withEventsField_lvDeposit;
		public System.Windows.Forms.ListView lvDeposit {
			get { return withEventsField_lvDeposit; }
			set {
				if (withEventsField_lvDeposit != null) {
					withEventsField_lvDeposit.ItemCheck -= lvDeposit_ItemCheck;
					withEventsField_lvDeposit.KeyPress -= lvDeposit_KeyPress;
				}
				withEventsField_lvDeposit = value;
				if (withEventsField_lvDeposit != null) {
					withEventsField_lvDeposit.ItemCheck += lvDeposit_ItemCheck;
					withEventsField_lvDeposit.KeyPress += lvDeposit_KeyPress;
				}
			}
		}
		public System.Windows.Forms.Label lblSupplier;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSupplierDeposits));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.lvDeposit = new System.Windows.Forms.ListView();
			this._lvDeposit_ColumnHeader_1 = new System.Windows.Forms.ColumnHeader();
			this._lvDeposit_ColumnHeader_2 = new System.Windows.Forms.ColumnHeader();
			this._lvDeposit_ColumnHeader_3 = new System.Windows.Forms.ColumnHeader();
			this.lblSupplier = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.lvDeposit.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Text = "Supplier Deposits";
			this.ClientSize = new System.Drawing.Size(450, 477);
			this.Location = new System.Drawing.Point(3, 22);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmSupplierDeposits";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(450, 38);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 1;
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
			this.cmdClose.Location = new System.Drawing.Point(369, 3);
			this.cmdClose.TabIndex = 3;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.Location = new System.Drawing.Point(5, 3);
			this.cmdCancel.TabIndex = 2;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Name = "cmdCancel";
			this.lvDeposit.Size = new System.Drawing.Size(442, 394);
			this.lvDeposit.Location = new System.Drawing.Point(3, 72);
			this.lvDeposit.TabIndex = 0;
			this.lvDeposit.View = System.Windows.Forms.View.Details;
			this.lvDeposit.LabelEdit = false;
			this.lvDeposit.LabelWrap = true;
			this.lvDeposit.HideSelection = true;
			this.lvDeposit.AllowColumnReorder = -1;
			this.lvDeposit.CheckBoxes = true;
			this.lvDeposit.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lvDeposit.BackColor = System.Drawing.SystemColors.Window;
			this.lvDeposit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lvDeposit.Name = "lvDeposit";
			this._lvDeposit_ColumnHeader_1.Text = "Deposit Name";
			this._lvDeposit_ColumnHeader_1.Width = 236;
			this._lvDeposit_ColumnHeader_2.Text = "Type";
			this._lvDeposit_ColumnHeader_2.Width = 106;
			this._lvDeposit_ColumnHeader_3.Text = "Suppliers Description";
			this._lvDeposit_ColumnHeader_3.Width = 377;
			this.lblSupplier.Text = "Label1";
			this.lblSupplier.Size = new System.Drawing.Size(39, 13);
			this.lblSupplier.Location = new System.Drawing.Point(9, 45);
			this.lblSupplier.TabIndex = 4;
			this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblSupplier.BackColor = System.Drawing.Color.Transparent;
			this.lblSupplier.Enabled = true;
			this.lblSupplier.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblSupplier.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblSupplier.UseMnemonic = true;
			this.lblSupplier.Visible = true;
			this.lblSupplier.AutoSize = true;
			this.lblSupplier.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblSupplier.Name = "lblSupplier";
			this.Controls.Add(picButtons);
			this.Controls.Add(lvDeposit);
			this.Controls.Add(lblSupplier);
			this.picButtons.Controls.Add(cmdClose);
			this.picButtons.Controls.Add(cmdCancel);
			this.lvDeposit.Columns.Add(_lvDeposit_ColumnHeader_1);
			this.lvDeposit.Columns.Add(_lvDeposit_ColumnHeader_2);
			this.lvDeposit.Columns.Add(_lvDeposit_ColumnHeader_3);
			this.picButtons.ResumeLayout(false);
			this.lvDeposit.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
