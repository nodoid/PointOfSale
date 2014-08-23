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
	partial class frmStockBreakShrink
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockBreakShrink() : base()
		{
			FormClosed += frmStockBreakShrink_FormClosed;
			Load += frmStockBreakShrink_Load;
			KeyPress += frmStockBreakShrink_KeyPress;
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
		private System.Windows.Forms.Button withEventsField_cmdMove;
		public System.Windows.Forms.Button cmdMove {
			get { return withEventsField_cmdMove; }
			set {
				if (withEventsField_cmdMove != null) {
					withEventsField_cmdMove.Click -= cmdMove_Click;
				}
				withEventsField_cmdMove = value;
				if (withEventsField_cmdMove != null) {
					withEventsField_cmdMove.Click += cmdMove_Click;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtQuantity;
		public System.Windows.Forms.TextBox txtQuantity {
			get { return withEventsField_txtQuantity; }
			set {
				if (withEventsField_txtQuantity != null) {
					withEventsField_txtQuantity.Enter -= txtQuantity_Enter;
					withEventsField_txtQuantity.KeyPress -= txtQuantity_KeyPress;
					withEventsField_txtQuantity.Leave -= txtQuantity_Leave;
				}
				withEventsField_txtQuantity = value;
				if (withEventsField_txtQuantity != null) {
					withEventsField_txtQuantity.Enter += txtQuantity_Enter;
					withEventsField_txtQuantity.KeyPress += txtQuantity_KeyPress;
					withEventsField_txtQuantity.Leave += txtQuantity_Leave;
				}
			}
		}
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Panel picMove;
		private System.Windows.Forms.ListView withEventsField_lvStock;
		public System.Windows.Forms.ListView lvStock {
			get { return withEventsField_lvStock; }
			set {
				if (withEventsField_lvStock != null) {
					withEventsField_lvStock.KeyPress -= lvStock_KeyPress;
				}
				withEventsField_lvStock = value;
				if (withEventsField_lvStock != null) {
					withEventsField_lvStock.KeyPress += lvStock_KeyPress;
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
		public System.Windows.Forms.Label lblData;
		public System.Windows.Forms.Label _lbl_0;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockBreakShrink));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.picMove = new System.Windows.Forms.Panel();
			this.cmdMove = new System.Windows.Forms.Button();
			this.txtQuantity = new System.Windows.Forms.TextBox();
			this._lbl_1 = new System.Windows.Forms.Label();
			this.lvStock = new System.Windows.Forms.ListView();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.cmdExit = new System.Windows.Forms.Button();
			this.lblData = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.picMove.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Break a Stock Item";
			this.ClientSize = new System.Drawing.Size(693, 433);
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
			this.Name = "frmStockBreakShrink";
			this.picMove.Size = new System.Drawing.Size(112, 70);
			this.picMove.Location = new System.Drawing.Point(432, 357);
			this.picMove.TabIndex = 5;
			this.picMove.TabStop = false;
			this.picMove.Dock = System.Windows.Forms.DockStyle.None;
			this.picMove.BackColor = System.Drawing.SystemColors.Control;
			this.picMove.CausesValidation = true;
			this.picMove.Enabled = true;
			this.picMove.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picMove.Cursor = System.Windows.Forms.Cursors.Default;
			this.picMove.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picMove.Visible = true;
			this.picMove.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picMove.Name = "picMove";
			this.cmdMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMove.Text = "&Move";
			this.cmdMove.Size = new System.Drawing.Size(103, 25);
			this.cmdMove.Location = new System.Drawing.Point(3, 39);
			this.cmdMove.TabIndex = 8;
			this.cmdMove.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMove.CausesValidation = true;
			this.cmdMove.Enabled = true;
			this.cmdMove.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMove.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMove.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMove.TabStop = true;
			this.cmdMove.Name = "cmdMove";
			this.txtQuantity.AutoSize = false;
			this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtQuantity.Size = new System.Drawing.Size(40, 19);
			this.txtQuantity.Location = new System.Drawing.Point(54, 15);
			this.txtQuantity.TabIndex = 6;
			this.txtQuantity.Text = "0";
			this.txtQuantity.AcceptsReturn = true;
			this.txtQuantity.BackColor = System.Drawing.SystemColors.Window;
			this.txtQuantity.CausesValidation = true;
			this.txtQuantity.Enabled = true;
			this.txtQuantity.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtQuantity.HideSelection = true;
			this.txtQuantity.ReadOnly = false;
			this.txtQuantity.MaxLength = 0;
			this.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtQuantity.Multiline = false;
			this.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtQuantity.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtQuantity.TabStop = true;
			this.txtQuantity.Visible = true;
			this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtQuantity.Name = "txtQuantity";
			this._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_1.Text = "&Quantity to move :";
			this._lbl_1.Size = new System.Drawing.Size(86, 13);
			this._lbl_1.Location = new System.Drawing.Point(6, 0);
			this._lbl_1.TabIndex = 7;
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
			this.lvStock.Size = new System.Drawing.Size(673, 325);
			this.lvStock.Location = new System.Drawing.Point(8, 24);
			this.lvStock.TabIndex = 3;
			this.lvStock.View = System.Windows.Forms.View.Details;
			this.lvStock.LabelEdit = false;
			this.lvStock.LabelWrap = true;
			this.lvStock.HideSelection = false;
			this.lvStock.FullRowSelect = true;
			this.lvStock.GridLines = true;
			this.lvStock.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lvStock.BackColor = System.Drawing.SystemColors.Window;
			this.lvStock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lvStock.Name = "lvStock";
			this.txtSearch.AutoSize = false;
			this.txtSearch.Size = new System.Drawing.Size(631, 19);
			this.txtSearch.Location = new System.Drawing.Point(51, 3);
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
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(97, 52);
			this.cmdExit.Location = new System.Drawing.Point(585, 375);
			this.cmdExit.TabIndex = 2;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.lblData.Size = new System.Drawing.Size(418, 70);
			this.lblData.Location = new System.Drawing.Point(12, 357);
			this.lblData.TabIndex = 4;
			this.lblData.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblData.BackColor = System.Drawing.SystemColors.Control;
			this.lblData.Enabled = true;
			this.lblData.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblData.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblData.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblData.UseMnemonic = true;
			this.lblData.Visible = true;
			this.lblData.AutoSize = false;
			this.lblData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblData.Name = "lblData";
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_0.Text = "&Search :";
			this._lbl_0.Size = new System.Drawing.Size(40, 13);
			this._lbl_0.Location = new System.Drawing.Point(8, 6);
			this._lbl_0.TabIndex = 0;
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
			this.Controls.Add(picMove);
			this.Controls.Add(lvStock);
			this.Controls.Add(txtSearch);
			this.Controls.Add(cmdExit);
			this.Controls.Add(lblData);
			this.Controls.Add(_lbl_0);
			this.picMove.Controls.Add(cmdMove);
			this.picMove.Controls.Add(txtQuantity);
			this.picMove.Controls.Add(_lbl_1);
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.picMove.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
