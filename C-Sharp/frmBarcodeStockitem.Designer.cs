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
	partial class frmBarcodeStockitem
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmBarcodeStockitem() : base()
		{
			Load += frmBarcodeStockitem_Load;
			KeyDown += frmBarcodeStockitem_KeyDown;
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
		private System.Windows.Forms.Button withEventsField_Command1;
		public System.Windows.Forms.Button Command1 {
			get { return withEventsField_Command1; }
			set {
				if (withEventsField_Command1 != null) {
					withEventsField_Command1.Click -= Command1_Click;
				}
				withEventsField_Command1 = value;
				if (withEventsField_Command1 != null) {
					withEventsField_Command1.Click += Command1_Click;
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
		private System.Windows.Forms.Button withEventsField_cmdClear;
		public System.Windows.Forms.Button cmdClear {
			get { return withEventsField_cmdClear; }
			set {
				if (withEventsField_cmdClear != null) {
					withEventsField_cmdClear.Click -= cmdClear_Click;
				}
				withEventsField_cmdClear = value;
				if (withEventsField_cmdClear != null) {
					withEventsField_cmdClear.Click += cmdClear_Click;
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
		private System.Windows.Forms.TextBox withEventsField_txtEdit;
		public System.Windows.Forms.TextBox txtEdit {
			get { return withEventsField_txtEdit; }
			set {
				if (withEventsField_txtEdit != null) {
					withEventsField_txtEdit.TextChanged -= txtEdit_TextChanged;
					withEventsField_txtEdit.Enter -= txtEdit_Enter;
					withEventsField_txtEdit.KeyDown -= txtEdit_KeyDown;
					withEventsField_txtEdit.KeyPress -= txtEdit_KeyPress;
				}
				withEventsField_txtEdit = value;
				if (withEventsField_txtEdit != null) {
					withEventsField_txtEdit.TextChanged += txtEdit_TextChanged;
					withEventsField_txtEdit.Enter += txtEdit_Enter;
					withEventsField_txtEdit.KeyDown += txtEdit_KeyDown;
					withEventsField_txtEdit.KeyPress += txtEdit_KeyPress;
				}
			}
		}
		public System.Windows.Forms.TextBox _txtSearch_4;
		public System.Windows.Forms.TextBox _txtSearch_3;
		public System.Windows.Forms.TextBox _txtSearch_2;
		public System.Windows.Forms.TextBox _txtSearch_1;
		public System.Windows.Forms.TextBox _txtSearch_0;
		private myDataGridView withEventsField_gridEdit;
		public myDataGridView gridEdit {
			get { return withEventsField_gridEdit; }
			set {
				if (withEventsField_gridEdit != null) {
					withEventsField_gridEdit.DoubleClick -= gridEdit_DblClick;
				}
				withEventsField_gridEdit = value;
				if (withEventsField_gridEdit != null) {
					withEventsField_gridEdit.DoubleClick += gridEdit_DblClick;
				}
			}
		}
		public System.Windows.Forms.OpenFileDialog cmdDlgOpen;
		//Public WithEvents txtSearch As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmBarcodeStockitem));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.Command1 = new System.Windows.Forms.Button();
			this.cmdLoad = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdClear = new System.Windows.Forms.Button();
			this.cmdShow = new System.Windows.Forms.Button();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.txtEdit = new System.Windows.Forms.TextBox();
			this._txtSearch_4 = new System.Windows.Forms.TextBox();
			this._txtSearch_3 = new System.Windows.Forms.TextBox();
			this._txtSearch_2 = new System.Windows.Forms.TextBox();
			this._txtSearch_1 = new System.Windows.Forms.TextBox();
			this._txtSearch_0 = new System.Windows.Forms.TextBox();
			this.gridEdit = new myDataGridView();
			this.cmdDlgOpen = new System.Windows.Forms.OpenFileDialog();
			//Me.txtSearch = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.gridEdit).BeginInit();
			//CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).BeginInit()
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Select products for barcode printing ...";
			this.ClientSize = new System.Drawing.Size(839, 573);
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
			this.Name = "frmBarcodeStockitem";
			this.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command1.Text = "&Show Only with   Single Qty";
			this.Command1.Size = new System.Drawing.Size(121, 64);
			this.Command1.Location = new System.Drawing.Point(712, 288);
			this.Command1.TabIndex = 12;
			this.Command1.TabStop = false;
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.CausesValidation = true;
			this.Command1.Enabled = true;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.Name = "Command1";
			this.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdLoad.Text = "&Load Qty from  CSV file";
			this.cmdLoad.Size = new System.Drawing.Size(121, 64);
			this.cmdLoad.Location = new System.Drawing.Point(712, 64);
			this.cmdLoad.TabIndex = 11;
			this.cmdLoad.TabStop = false;
			this.cmdLoad.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLoad.CausesValidation = true;
			this.cmdLoad.Enabled = true;
			this.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLoad.Name = "cmdLoad";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "&Exit";
			this.cmdExit.Size = new System.Drawing.Size(121, 64);
			this.cmdExit.Location = new System.Drawing.Point(712, 471);
			this.cmdExit.TabIndex = 10;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.cmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClear.Text = "&Clear All Selected Products";
			this.cmdClear.Size = new System.Drawing.Size(121, 64);
			this.cmdClear.Location = new System.Drawing.Point(712, 216);
			this.cmdClear.TabIndex = 9;
			this.cmdClear.TabStop = false;
			this.cmdClear.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClear.CausesValidation = true;
			this.cmdClear.Enabled = true;
			this.cmdClear.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClear.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClear.Name = "cmdClear";
			this.cmdShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdShow.Text = "&Show Changed     Price Items    Or      Selected Products";
			this.cmdShow.Size = new System.Drawing.Size(121, 72);
			this.cmdShow.Location = new System.Drawing.Point(712, 136);
			this.cmdShow.TabIndex = 8;
			this.cmdShow.TabStop = false;
			this.cmdShow.BackColor = System.Drawing.SystemColors.Control;
			this.cmdShow.CausesValidation = true;
			this.cmdShow.Enabled = true;
			this.cmdShow.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdShow.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdShow.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdShow.Name = "cmdShow";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.Size = new System.Drawing.Size(121, 64);
			this.cmdPrint.Location = new System.Drawing.Point(712, 400);
			this.cmdPrint.TabIndex = 7;
			this.cmdPrint.TabStop = false;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Name = "cmdPrint";
			this.txtEdit.AutoSize = false;
			this.txtEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this.txtEdit.Size = new System.Drawing.Size(55, 16);
			this.txtEdit.Location = new System.Drawing.Point(0, 0);
			this.txtEdit.MaxLength = 4;
			this.txtEdit.TabIndex = 6;
			this.txtEdit.Tag = "0";
			this.txtEdit.Text = "0";
			this.txtEdit.Visible = false;
			this.txtEdit.AcceptsReturn = true;
			this.txtEdit.CausesValidation = true;
			this.txtEdit.Enabled = true;
			this.txtEdit.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtEdit.HideSelection = true;
			this.txtEdit.ReadOnly = false;
			this.txtEdit.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtEdit.Multiline = false;
			this.txtEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtEdit.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtEdit.TabStop = true;
			this.txtEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtEdit.Name = "txtEdit";
			this._txtSearch_4.AutoSize = false;
			this._txtSearch_4.BackColor = System.Drawing.SystemColors.Control;
			this._txtSearch_4.Size = new System.Drawing.Size(76, 19);
			this._txtSearch_4.Location = new System.Drawing.Point(369, 39);
			this._txtSearch_4.TabIndex = 4;
			this._txtSearch_4.Tag = "PricingGroup_Name";
			this._txtSearch_4.AcceptsReturn = true;
			this._txtSearch_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtSearch_4.CausesValidation = true;
			this._txtSearch_4.Enabled = true;
			this._txtSearch_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtSearch_4.HideSelection = true;
			this._txtSearch_4.ReadOnly = false;
			this._txtSearch_4.MaxLength = 0;
			this._txtSearch_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtSearch_4.Multiline = false;
			this._txtSearch_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtSearch_4.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtSearch_4.TabStop = true;
			this._txtSearch_4.Visible = true;
			this._txtSearch_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtSearch_4.Name = "_txtSearch_4";
			this._txtSearch_3.AutoSize = false;
			this._txtSearch_3.BackColor = System.Drawing.SystemColors.Control;
			this._txtSearch_3.Size = new System.Drawing.Size(76, 19);
			this._txtSearch_3.Location = new System.Drawing.Point(282, 39);
			this._txtSearch_3.TabIndex = 3;
			this._txtSearch_3.Tag = "Supplier_Name";
			this._txtSearch_3.AcceptsReturn = true;
			this._txtSearch_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtSearch_3.CausesValidation = true;
			this._txtSearch_3.Enabled = true;
			this._txtSearch_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtSearch_3.HideSelection = true;
			this._txtSearch_3.ReadOnly = false;
			this._txtSearch_3.MaxLength = 0;
			this._txtSearch_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtSearch_3.Multiline = false;
			this._txtSearch_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtSearch_3.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtSearch_3.TabStop = true;
			this._txtSearch_3.Visible = true;
			this._txtSearch_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtSearch_3.Name = "_txtSearch_3";
			this._txtSearch_2.AutoSize = false;
			this._txtSearch_2.BackColor = System.Drawing.SystemColors.Control;
			this._txtSearch_2.Size = new System.Drawing.Size(76, 19);
			this._txtSearch_2.Location = new System.Drawing.Point(189, 39);
			this._txtSearch_2.TabIndex = 2;
			this._txtSearch_2.Tag = "StockItem_Name";
			this._txtSearch_2.AcceptsReturn = true;
			this._txtSearch_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtSearch_2.CausesValidation = true;
			this._txtSearch_2.Enabled = true;
			this._txtSearch_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtSearch_2.HideSelection = true;
			this._txtSearch_2.ReadOnly = false;
			this._txtSearch_2.MaxLength = 0;
			this._txtSearch_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtSearch_2.Multiline = false;
			this._txtSearch_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtSearch_2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtSearch_2.TabStop = true;
			this._txtSearch_2.Visible = true;
			this._txtSearch_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtSearch_2.Name = "_txtSearch_2";
			this._txtSearch_1.AutoSize = false;
			this._txtSearch_1.BackColor = System.Drawing.SystemColors.Control;
			this._txtSearch_1.Size = new System.Drawing.Size(76, 19);
			this._txtSearch_1.Location = new System.Drawing.Point(93, 39);
			this._txtSearch_1.TabIndex = 1;
			this._txtSearch_1.Tag = "StockItemID";
			this._txtSearch_1.AcceptsReturn = true;
			this._txtSearch_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtSearch_1.CausesValidation = true;
			this._txtSearch_1.Enabled = true;
			this._txtSearch_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtSearch_1.HideSelection = true;
			this._txtSearch_1.ReadOnly = false;
			this._txtSearch_1.MaxLength = 0;
			this._txtSearch_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtSearch_1.Multiline = false;
			this._txtSearch_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtSearch_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtSearch_1.TabStop = true;
			this._txtSearch_1.Visible = true;
			this._txtSearch_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtSearch_1.Name = "_txtSearch_1";
			this._txtSearch_0.AutoSize = false;
			this._txtSearch_0.BackColor = System.Drawing.SystemColors.Control;
			this._txtSearch_0.Size = new System.Drawing.Size(76, 19);
			this._txtSearch_0.Location = new System.Drawing.Point(9, 39);
			this._txtSearch_0.TabIndex = 0;
			this._txtSearch_0.Tag = "Catalogue_Barcode";
			this._txtSearch_0.AcceptsReturn = true;
			this._txtSearch_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtSearch_0.CausesValidation = true;
			this._txtSearch_0.Enabled = true;
			this._txtSearch_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtSearch_0.HideSelection = true;
			this._txtSearch_0.ReadOnly = false;
			this._txtSearch_0.MaxLength = 0;
			this._txtSearch_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtSearch_0.Multiline = false;
			this._txtSearch_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtSearch_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtSearch_0.TabStop = true;
			this._txtSearch_0.Visible = true;
			this._txtSearch_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtSearch_0.Name = "_txtSearch_0";
			//gridEdit.OcxState = CType(resources.GetObject("gridEdit.OcxState"), System.Windows.Forms.AxHost.State)
			this.gridEdit.Size = new System.Drawing.Size(695, 475);
			this.gridEdit.Location = new System.Drawing.Point(9, 60);
			this.gridEdit.TabIndex = 5;
			this.gridEdit.Name = "gridEdit";
			this.Controls.Add(Command1);
			this.Controls.Add(cmdLoad);
			this.Controls.Add(cmdExit);
			this.Controls.Add(cmdClear);
			this.Controls.Add(cmdShow);
			this.Controls.Add(cmdPrint);
			this.Controls.Add(txtEdit);
			this.Controls.Add(_txtSearch_4);
			this.Controls.Add(_txtSearch_3);
			this.Controls.Add(_txtSearch_2);
			this.Controls.Add(_txtSearch_1);
			this.Controls.Add(_txtSearch_0);
			this.Controls.Add(gridEdit);
			//Me.txtSearch.SetIndex(_txtSearch_4, CType(4, Short))
			//Me.txtSearch.SetIndex(_txtSearch_3, CType(3, Short))
			//Me.txtSearch.SetIndex(_txtSearch_2, CType(2, Short))
			//Me.txtSearch.SetIndex(_txtSearch_1, CType(1, Short))
			//Me.txtSearch.SetIndex(_txtSearch_0, CType(0, Short))
			//CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this.gridEdit).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
