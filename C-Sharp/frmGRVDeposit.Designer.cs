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
	partial class frmGRVDeposit
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmGRVDeposit() : base()
		{
			Resize += frmGRVDeposit_Resize;
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
		private System.Windows.Forms.Button withEventsField_cmdBack;
		public System.Windows.Forms.Button cmdBack {
			get { return withEventsField_cmdBack; }
			set {
				if (withEventsField_cmdBack != null) {
					withEventsField_cmdBack.Click -= cmdBack_Click;
				}
				withEventsField_cmdBack = value;
				if (withEventsField_cmdBack != null) {
					withEventsField_cmdBack.Click += cmdBack_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdNext;
		public System.Windows.Forms.Button cmdNext {
			get { return withEventsField_cmdNext; }
			set {
				if (withEventsField_cmdNext != null) {
					withEventsField_cmdNext.Click -= cmdNext_Click;
				}
				withEventsField_cmdNext = value;
				if (withEventsField_cmdNext != null) {
					withEventsField_cmdNext.Click += cmdNext_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDelete;
		public System.Windows.Forms.Button cmdDelete {
			get { return withEventsField_cmdDelete; }
			set {
				if (withEventsField_cmdDelete != null) {
					withEventsField_cmdDelete.Click -= cmdDelete_Click;
				}
				withEventsField_cmdDelete = value;
				if (withEventsField_cmdDelete != null) {
					withEventsField_cmdDelete.Click += cmdDelete_Click;
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
		private System.Windows.Forms.Panel withEventsField_picButtons;
		public System.Windows.Forms.Panel picButtons {
			get { return withEventsField_picButtons; }
			set {
				if (withEventsField_picButtons != null) {
					withEventsField_picButtons.Resize -= picButtons_Resize;
				}
				withEventsField_picButtons = value;
				if (withEventsField_picButtons != null) {
					withEventsField_picButtons.Resize += picButtons_Resize;
				}
			}
		}
		public System.Windows.Forms.Label lblDepositExclusive;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label _lbl_8;
		public System.Windows.Forms.Label lblQuantity;
		public System.Windows.Forms.Label _lbl_9;
		public System.Windows.Forms.Label lblDepositInclusive;
		public System.Windows.Forms.GroupBox frmTotals;
		public System.Windows.Forms.Label lblSupplier;
		public System.Windows.Forms.Panel Picture1;
		private System.Windows.Forms.TextBox withEventsField_txtEdit;
		public System.Windows.Forms.TextBox txtEdit {
			get { return withEventsField_txtEdit; }
			set {
				if (withEventsField_txtEdit != null) {
					withEventsField_txtEdit.TextChanged -= txtEdit_TextChanged;
					withEventsField_txtEdit.Leave -= txtEdit_Leave;
					withEventsField_txtEdit.Enter -= txtEdit_Enter;
					withEventsField_txtEdit.KeyDown -= txtEdit_KeyDown;
					withEventsField_txtEdit.KeyPress -= txtEdit_KeyPress;
				}
				withEventsField_txtEdit = value;
				if (withEventsField_txtEdit != null) {
					withEventsField_txtEdit.TextChanged += txtEdit_TextChanged;
					withEventsField_txtEdit.Leave += txtEdit_Leave;
					withEventsField_txtEdit.Enter += txtEdit_Enter;
					withEventsField_txtEdit.KeyDown += txtEdit_KeyDown;
					withEventsField_txtEdit.KeyPress += txtEdit_KeyPress;
				}
			}
		}
		private myDataGridView withEventsField_gridItem;
		public myDataGridView gridItem {
			get { return withEventsField_gridItem; }
			set {
				if (withEventsField_gridItem != null) {
					withEventsField_gridItem.Enter -= gridItem_EnterCell;
					withEventsField_gridItem.Enter -= gridItem_Enter;
					withEventsField_gridItem.KeyPress -= gridItem_KeyPress;
					withEventsField_gridItem.Leave -= gridItem_LeaveCell;
				}
				withEventsField_gridItem = value;
				if (withEventsField_gridItem != null) {
					withEventsField_gridItem.Enter += gridItem_EnterCell;
					withEventsField_gridItem.Enter += gridItem_Enter;
					withEventsField_gridItem.KeyPress += gridItem_KeyPress;
					withEventsField_gridItem.Leave += gridItem_LeaveCell;
				}
			}
		}
		public System.Windows.Forms.Label lblReturns;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGRVDeposit));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdBack = new System.Windows.Forms.Button();
			this.cmdNext = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this.frmTotals = new System.Windows.Forms.GroupBox();
			this.lblDepositExclusive = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._lbl_8 = new System.Windows.Forms.Label();
			this.lblQuantity = new System.Windows.Forms.Label();
			this._lbl_9 = new System.Windows.Forms.Label();
			this.lblDepositInclusive = new System.Windows.Forms.Label();
			this.Picture1 = new System.Windows.Forms.Panel();
			this.lblSupplier = new System.Windows.Forms.Label();
			this.txtEdit = new System.Windows.Forms.TextBox();
			this.gridItem = new myDataGridView();
			this.lblReturns = new System.Windows.Forms.Label();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.picButtons.SuspendLayout();
			this.frmTotals.SuspendLayout();
			this.Picture1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.gridItem).BeginInit();
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.Text = "Deposit Returns Form";
			this.ClientSize = new System.Drawing.Size(806, 547);
			this.Location = new System.Drawing.Point(4, 23);
			this.ControlBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Enabled = true;
			this.KeyPreview = false;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.Name = "frmGRVDeposit";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(806, 49);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 10;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBack.Text = "<< &Back";
			this.cmdBack.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdBack.Size = new System.Drawing.Size(73, 40);
			this.cmdBack.Location = new System.Drawing.Point(426, 3);
			this.cmdBack.TabIndex = 14;
			this.cmdBack.TabStop = false;
			this.cmdBack.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBack.CausesValidation = true;
			this.cmdBack.Enabled = true;
			this.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBack.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBack.Name = "cmdBack";
			this.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNext.Text = "&Next >>";
			this.cmdNext.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdNext.Size = new System.Drawing.Size(73, 40);
			this.cmdNext.Location = new System.Drawing.Point(528, 3);
			this.cmdNext.TabIndex = 13;
			this.cmdNext.TabStop = false;
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.CausesValidation = true;
			this.cmdNext.Enabled = true;
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.Name = "cmdNext";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "D&elete";
			this.cmdDelete.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdDelete.Size = new System.Drawing.Size(73, 40);
			this.cmdDelete.Location = new System.Drawing.Point(3, 3);
			this.cmdDelete.TabIndex = 12;
			this.cmdDelete.TabStop = false;
			this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelete.CausesValidation = true;
			this.cmdDelete.Enabled = true;
			this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelete.Name = "cmdDelete";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdExit.Size = new System.Drawing.Size(73, 40);
			this.cmdExit.Location = new System.Drawing.Point(630, 3);
			this.cmdExit.TabIndex = 11;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.frmTotals.Text = "Sub Totals";
			this.frmTotals.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.frmTotals.Size = new System.Drawing.Size(370, 52);
			this.frmTotals.Location = new System.Drawing.Point(219, 444);
			this.frmTotals.TabIndex = 4;
			this.frmTotals.BackColor = System.Drawing.SystemColors.Control;
			this.frmTotals.Enabled = true;
			this.frmTotals.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmTotals.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmTotals.Visible = true;
			this.frmTotals.Padding = new System.Windows.Forms.Padding(0);
			this.frmTotals.Name = "frmTotals";
			this.lblDepositExclusive.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblDepositExclusive.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			this.lblDepositExclusive.Text = "0.00";
			this.lblDepositExclusive.Size = new System.Drawing.Size(91, 17);
			this.lblDepositExclusive.Location = new System.Drawing.Point(134, 27);
			this.lblDepositExclusive.TabIndex = 16;
			this.lblDepositExclusive.Enabled = true;
			this.lblDepositExclusive.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDepositExclusive.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositExclusive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositExclusive.UseMnemonic = true;
			this.lblDepositExclusive.Visible = true;
			this.lblDepositExclusive.AutoSize = false;
			this.lblDepositExclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDepositExclusive.Name = "lblDepositExclusive";
			this._lbl_0.Text = "Exclusive Amount";
			this._lbl_0.Size = new System.Drawing.Size(103, 13);
			this._lbl_0.Location = new System.Drawing.Point(135, 15);
			this._lbl_0.TabIndex = 15;
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Enabled = true;
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.UseMnemonic = true;
			this._lbl_0.Visible = true;
			this._lbl_0.AutoSize = false;
			this._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_0.Name = "_lbl_0";
			this._lbl_8.Text = "No Of Cases";
			this._lbl_8.Size = new System.Drawing.Size(60, 13);
			this._lbl_8.Location = new System.Drawing.Point(9, 15);
			this._lbl_8.TabIndex = 7;
			this._lbl_8.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_8.BackColor = System.Drawing.Color.Transparent;
			this._lbl_8.Enabled = true;
			this._lbl_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_8.UseMnemonic = true;
			this._lbl_8.Visible = true;
			this._lbl_8.AutoSize = true;
			this._lbl_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_8.Name = "_lbl_8";
			this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblQuantity.Text = "lblQuantity";
			this.lblQuantity.Size = new System.Drawing.Size(64, 17);
			this.lblQuantity.Location = new System.Drawing.Point(9, 27);
			this.lblQuantity.TabIndex = 6;
			this.lblQuantity.BackColor = System.Drawing.SystemColors.Control;
			this.lblQuantity.Enabled = true;
			this.lblQuantity.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblQuantity.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblQuantity.UseMnemonic = true;
			this.lblQuantity.Visible = true;
			this.lblQuantity.AutoSize = false;
			this.lblQuantity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblQuantity.Name = "lblQuantity";
			this._lbl_9.Text = "Inclusive Amount";
			this._lbl_9.Size = new System.Drawing.Size(103, 13);
			this._lbl_9.Location = new System.Drawing.Point(256, 15);
			this._lbl_9.TabIndex = 8;
			this._lbl_9.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_9.BackColor = System.Drawing.Color.Transparent;
			this._lbl_9.Enabled = true;
			this._lbl_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_9.UseMnemonic = true;
			this._lbl_9.Visible = true;
			this._lbl_9.AutoSize = false;
			this._lbl_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_9.Name = "_lbl_9";
			this.lblDepositInclusive.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblDepositInclusive.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			this.lblDepositInclusive.Text = "0.00";
			this.lblDepositInclusive.Size = new System.Drawing.Size(91, 17);
			this.lblDepositInclusive.Location = new System.Drawing.Point(255, 27);
			this.lblDepositInclusive.TabIndex = 5;
			this.lblDepositInclusive.Enabled = true;
			this.lblDepositInclusive.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDepositInclusive.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositInclusive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositInclusive.UseMnemonic = true;
			this.lblDepositInclusive.Visible = true;
			this.lblDepositInclusive.AutoSize = false;
			this.lblDepositInclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDepositInclusive.Name = "lblDepositInclusive";
			this.Picture1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Picture1.BackColor = System.Drawing.Color.FromArgb(192, 192, 192);
			this.Picture1.Size = new System.Drawing.Size(806, 25);
			this.Picture1.Location = new System.Drawing.Point(0, 49);
			this.Picture1.TabIndex = 2;
			this.Picture1.TabStop = false;
			this.Picture1.CausesValidation = true;
			this.Picture1.Enabled = true;
			this.Picture1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Picture1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Picture1.Visible = true;
			this.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Picture1.Name = "Picture1";
			this.lblSupplier.Text = "lblSupplier";
			this.lblSupplier.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblSupplier.Size = new System.Drawing.Size(85, 20);
			this.lblSupplier.Location = new System.Drawing.Point(0, 0);
			this.lblSupplier.TabIndex = 3;
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
			this.txtEdit.AutoSize = false;
			this.txtEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this.txtEdit.Size = new System.Drawing.Size(55, 16);
			this.txtEdit.Location = new System.Drawing.Point(279, 138);
			this.txtEdit.TabIndex = 0;
			this.txtEdit.Tag = "0";
			this.txtEdit.Text = "0";
			this.txtEdit.Visible = false;
			this.txtEdit.AcceptsReturn = true;
			this.txtEdit.CausesValidation = true;
			this.txtEdit.Enabled = true;
			this.txtEdit.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtEdit.HideSelection = true;
			this.txtEdit.ReadOnly = false;
			this.txtEdit.MaxLength = 0;
			this.txtEdit.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtEdit.Multiline = false;
			this.txtEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtEdit.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtEdit.TabStop = true;
			this.txtEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtEdit.Name = "txtEdit";
			//gridItem.OcxState = CType(resources.GetObject("gridItem.OcxState"), System.Windows.Forms.AxHost.State)
			this.gridItem.Size = new System.Drawing.Size(685, 277);
			this.gridItem.Location = new System.Drawing.Point(3, 81);
			this.gridItem.TabIndex = 1;
			this.gridItem.Name = "gridItem";
			this.lblReturns.BackColor = System.Drawing.Color.Red;
			this.lblReturns.Text = "PURCHASES";
			this.lblReturns.Font = new System.Drawing.Font("Arial", 24f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblReturns.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblReturns.Size = new System.Drawing.Size(208, 34);
			this.lblReturns.Location = new System.Drawing.Point(9, 453);
			this.lblReturns.TabIndex = 9;
			this.lblReturns.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblReturns.Enabled = true;
			this.lblReturns.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblReturns.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblReturns.UseMnemonic = true;
			this.lblReturns.Visible = true;
			this.lblReturns.AutoSize = false;
			this.lblReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblReturns.Name = "lblReturns";
			this.Controls.Add(picButtons);
			this.Controls.Add(frmTotals);
			this.Controls.Add(Picture1);
			this.Controls.Add(txtEdit);
			this.Controls.Add(gridItem);
			this.Controls.Add(lblReturns);
			this.picButtons.Controls.Add(cmdBack);
			this.picButtons.Controls.Add(cmdNext);
			this.picButtons.Controls.Add(cmdDelete);
			this.picButtons.Controls.Add(cmdExit);
			this.frmTotals.Controls.Add(lblDepositExclusive);
			this.frmTotals.Controls.Add(_lbl_0);
			this.frmTotals.Controls.Add(_lbl_8);
			this.frmTotals.Controls.Add(lblQuantity);
			this.frmTotals.Controls.Add(_lbl_9);
			this.frmTotals.Controls.Add(lblDepositInclusive);
			this.Picture1.Controls.Add(lblSupplier);
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_8, CType(8, Short))
			//Me.lbl.SetIndex(_lbl_9, CType(9, Short))
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this.gridItem).EndInit();
			this.picButtons.ResumeLayout(false);
			this.frmTotals.ResumeLayout(false);
			this.Picture1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
