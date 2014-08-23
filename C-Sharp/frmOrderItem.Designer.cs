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
	partial class frmOrderItem
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmOrderItem() : base()
		{
			Load += frmOrderItem_Load;
			FormClosed += frmOrderItem_FormClosed;
			Resize += frmOrderItem_Resize;
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
		public System.Windows.Forms.TextBox _txtEdit_1;
		private System.Windows.Forms.Button withEventsField_cmdPriceBOM;
		public System.Windows.Forms.Button cmdPriceBOM {
			get { return withEventsField_cmdPriceBOM; }
			set {
				if (withEventsField_cmdPriceBOM != null) {
					withEventsField_cmdPriceBOM.Click -= cmdPriceBOM_Click;
				}
				withEventsField_cmdPriceBOM = value;
				if (withEventsField_cmdPriceBOM != null) {
					withEventsField_cmdPriceBOM.Click += cmdPriceBOM_Click;
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
		private System.Windows.Forms.Button withEventsField_cmdStockItem;
		public System.Windows.Forms.Button cmdStockItem {
			get { return withEventsField_cmdStockItem; }
			set {
				if (withEventsField_cmdStockItem != null) {
					withEventsField_cmdStockItem.Click -= cmdStockItem_Click;
				}
				withEventsField_cmdStockItem = value;
				if (withEventsField_cmdStockItem != null) {
					withEventsField_cmdStockItem.Click += cmdStockItem_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdEdit;
		public System.Windows.Forms.Button cmdEdit {
			get { return withEventsField_cmdEdit; }
			set {
				if (withEventsField_cmdEdit != null) {
					withEventsField_cmdEdit.Click -= cmdEdit_Click;
				}
				withEventsField_cmdEdit = value;
				if (withEventsField_cmdEdit != null) {
					withEventsField_cmdEdit.Click += cmdEdit_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdPack;
		public System.Windows.Forms.Button cmdPack {
			get { return withEventsField_cmdPack; }
			set {
				if (withEventsField_cmdPack != null) {
					withEventsField_cmdPack.Click -= cmdPack_Click;
				}
				withEventsField_cmdPack = value;
				if (withEventsField_cmdPack != null) {
					withEventsField_cmdPack.Click += cmdPack_Click;
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
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label lblBrokenPack;
		public System.Windows.Forms.Label lblTotal;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lbl_10;
		public System.Windows.Forms.Label _lbl_9;
		public System.Windows.Forms.Label _lbl_8;
		public System.Windows.Forms.Label lblQuantity;
		public System.Windows.Forms.Label lblDeposit;
		public System.Windows.Forms.Label lblContent;
		public System.Windows.Forms.GroupBox frmTotals;
		public System.Windows.Forms.Label lblSupplier;
		public System.Windows.Forms.Panel Picture1;
		public System.Windows.Forms.TextBox _txtEdit_0;
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
		private System.Windows.Forms.ListBox withEventsField_lstWorkspace;
		public System.Windows.Forms.ListBox lstWorkspace {
			get { return withEventsField_lstWorkspace; }
			set {
				if (withEventsField_lstWorkspace != null) {
					withEventsField_lstWorkspace.DoubleClick -= lstWorkspace_DoubleClick;
					withEventsField_lstWorkspace.KeyPress -= lstWorkspace_KeyPress;
					withEventsField_lstWorkspace.KeyDown -= lstWorkspace_KeyDown;
				}
				withEventsField_lstWorkspace = value;
				if (withEventsField_lstWorkspace != null) {
					withEventsField_lstWorkspace.DoubleClick += lstWorkspace_DoubleClick;
					withEventsField_lstWorkspace.KeyPress += lstWorkspace_KeyPress;
					withEventsField_lstWorkspace.KeyDown += lstWorkspace_KeyDown;
				}
			}
		}
		public System.Windows.Forms.Label _lbl_7;
		public System.Windows.Forms.Label _lbl_0;
		public Microsoft.VisualBasic.Compatibility.VB6.LabelArray lbl;
		private Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray withEventsField_txtEdit;
		public Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray txtEdit {
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
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmOrderItem));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this._txtEdit_1 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdPriceBOM = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdNext = new System.Windows.Forms.Button();
			this.cmdBack = new System.Windows.Forms.Button();
			this.cmdStockItem = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdPack = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.frmTotals = new System.Windows.Forms.GroupBox();
			this._lbl_2 = new System.Windows.Forms.Label();
			this.lblBrokenPack = new System.Windows.Forms.Label();
			this.lblTotal = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lbl_10 = new System.Windows.Forms.Label();
			this._lbl_9 = new System.Windows.Forms.Label();
			this._lbl_8 = new System.Windows.Forms.Label();
			this.lblQuantity = new System.Windows.Forms.Label();
			this.lblDeposit = new System.Windows.Forms.Label();
			this.lblContent = new System.Windows.Forms.Label();
			this.Picture1 = new System.Windows.Forms.Panel();
			this.lblSupplier = new System.Windows.Forms.Label();
			this._txtEdit_0 = new System.Windows.Forms.TextBox();
			this.gridItem = new myDataGridView();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.lstWorkspace = new System.Windows.Forms.ListBox();
			this._lbl_7 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.lbl = new Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components);
			this.txtEdit = new Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components);
			this.picButtons.SuspendLayout();
			this.frmTotals.SuspendLayout();
			this.Picture1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.gridItem).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.lbl).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.txtEdit).BeginInit();
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.Text = "Order Form";
			this.ClientSize = new System.Drawing.Size(592, 547);
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
			this.Name = "frmOrderItem";
			this._txtEdit_1.AutoSize = false;
			this._txtEdit_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtEdit_1.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this._txtEdit_1.Size = new System.Drawing.Size(55, 16);
			this._txtEdit_1.Location = new System.Drawing.Point(376, 136);
			this._txtEdit_1.TabIndex = 27;
			this._txtEdit_1.Tag = "0";
			this._txtEdit_1.Text = "0";
			this._txtEdit_1.Visible = false;
			this._txtEdit_1.AcceptsReturn = true;
			this._txtEdit_1.CausesValidation = true;
			this._txtEdit_1.Enabled = true;
			this._txtEdit_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtEdit_1.HideSelection = true;
			this._txtEdit_1.ReadOnly = false;
			this._txtEdit_1.MaxLength = 0;
			this._txtEdit_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtEdit_1.Multiline = false;
			this._txtEdit_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtEdit_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtEdit_1.TabStop = true;
			this._txtEdit_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._txtEdit_1.Name = "_txtEdit_1";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(592, 38);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 19;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdPriceBOM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPriceBOM.Text = "Change &BOM Price";
			this.cmdPriceBOM.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdPriceBOM.Size = new System.Drawing.Size(123, 28);
			this.cmdPriceBOM.Location = new System.Drawing.Point(432, 3);
			this.cmdPriceBOM.TabIndex = 28;
			this.cmdPriceBOM.TabStop = false;
			this.cmdPriceBOM.Tag = "0";
			this.cmdPriceBOM.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPriceBOM.CausesValidation = true;
			this.cmdPriceBOM.Enabled = true;
			this.cmdPriceBOM.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPriceBOM.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPriceBOM.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPriceBOM.Name = "cmdPriceBOM";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdExit.Size = new System.Drawing.Size(73, 28);
			this.cmdExit.Location = new System.Drawing.Point(717, 3);
			this.cmdExit.TabIndex = 26;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNext.Text = "&Next >>";
			this.cmdNext.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdNext.Size = new System.Drawing.Size(73, 28);
			this.cmdNext.Location = new System.Drawing.Point(669, 3);
			this.cmdNext.TabIndex = 25;
			this.cmdNext.TabStop = false;
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.CausesValidation = true;
			this.cmdNext.Enabled = true;
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.Name = "cmdNext";
			this.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBack.Text = "<< &Back";
			this.cmdBack.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdBack.Size = new System.Drawing.Size(73, 28);
			this.cmdBack.Location = new System.Drawing.Point(570, 3);
			this.cmdBack.TabIndex = 24;
			this.cmdBack.TabStop = false;
			this.cmdBack.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBack.CausesValidation = true;
			this.cmdBack.Enabled = true;
			this.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBack.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBack.Name = "cmdBack";
			this.cmdStockItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdStockItem.Text = "All Stoc&k Items";
			this.cmdStockItem.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdStockItem.Size = new System.Drawing.Size(97, 28);
			this.cmdStockItem.Location = new System.Drawing.Point(0, 3);
			this.cmdStockItem.TabIndex = 23;
			this.cmdStockItem.TabStop = false;
			this.cmdStockItem.Tag = "0";
			this.cmdStockItem.BackColor = System.Drawing.SystemColors.Control;
			this.cmdStockItem.CausesValidation = true;
			this.cmdStockItem.Enabled = true;
			this.cmdStockItem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdStockItem.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdStockItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdStockItem.Name = "cmdStockItem";
			this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEdit.Text = "&Edit Stock Item";
			this.cmdEdit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdEdit.Size = new System.Drawing.Size(103, 28);
			this.cmdEdit.Location = new System.Drawing.Point(324, 3);
			this.cmdEdit.TabIndex = 22;
			this.cmdEdit.TabStop = false;
			this.cmdEdit.Tag = "0";
			this.cmdEdit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEdit.CausesValidation = true;
			this.cmdEdit.Enabled = true;
			this.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEdit.Name = "cmdEdit";
			this.cmdPack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPack.Text = "Break / Build P&ack";
			this.cmdPack.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdPack.Size = new System.Drawing.Size(124, 28);
			this.cmdPack.Location = new System.Drawing.Point(195, 3);
			this.cmdPack.TabIndex = 21;
			this.cmdPack.TabStop = false;
			this.cmdPack.Tag = "0";
			this.cmdPack.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPack.CausesValidation = true;
			this.cmdPack.Enabled = true;
			this.cmdPack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPack.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPack.Name = "cmdPack";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "Dele&te";
			this.cmdDelete.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdDelete.Size = new System.Drawing.Size(73, 28);
			this.cmdDelete.Location = new System.Drawing.Point(117, 3);
			this.cmdDelete.TabIndex = 20;
			this.cmdDelete.TabStop = false;
			this.cmdDelete.Tag = "0";
			this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelete.CausesValidation = true;
			this.cmdDelete.Enabled = true;
			this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelete.Name = "cmdDelete";
			this.frmTotals.Text = "Sub Totals";
			this.frmTotals.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.frmTotals.Size = new System.Drawing.Size(457, 58);
			this.frmTotals.Location = new System.Drawing.Point(219, 366);
			this.frmTotals.TabIndex = 8;
			this.frmTotals.BackColor = System.Drawing.SystemColors.Control;
			this.frmTotals.Enabled = true;
			this.frmTotals.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmTotals.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmTotals.Visible = true;
			this.frmTotals.Padding = new System.Windows.Forms.Padding(0);
			this.frmTotals.Name = "frmTotals";
			this._lbl_2.Text = "Broken Packs";
			this._lbl_2.Size = new System.Drawing.Size(67, 13);
			this._lbl_2.Location = new System.Drawing.Point(78, 15);
			this._lbl_2.TabIndex = 18;
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Enabled = true;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.UseMnemonic = true;
			this._lbl_2.Visible = true;
			this._lbl_2.AutoSize = true;
			this._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_2.Name = "_lbl_2";
			this.lblBrokenPack.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblBrokenPack.Text = "lblQuantity";
			this.lblBrokenPack.Size = new System.Drawing.Size(64, 17);
			this.lblBrokenPack.Location = new System.Drawing.Point(81, 27);
			this.lblBrokenPack.TabIndex = 17;
			this.lblBrokenPack.BackColor = System.Drawing.SystemColors.Control;
			this.lblBrokenPack.Enabled = true;
			this.lblBrokenPack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblBrokenPack.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblBrokenPack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblBrokenPack.UseMnemonic = true;
			this.lblBrokenPack.Visible = true;
			this.lblBrokenPack.AutoSize = false;
			this.lblBrokenPack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblBrokenPack.Name = "lblBrokenPack";
			this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblTotal.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			this.lblTotal.Text = "0.00";
			this.lblTotal.Size = new System.Drawing.Size(91, 17);
			this.lblTotal.Location = new System.Drawing.Point(357, 27);
			this.lblTotal.TabIndex = 16;
			this.lblTotal.Enabled = true;
			this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotal.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTotal.UseMnemonic = true;
			this.lblTotal.Visible = true;
			this.lblTotal.AutoSize = false;
			this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotal.Name = "lblTotal";
			this._lbl_1.Text = "Total Value";
			this._lbl_1.Size = new System.Drawing.Size(91, 13);
			this._lbl_1.Location = new System.Drawing.Point(358, 15);
			this._lbl_1.TabIndex = 15;
			this._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Enabled = true;
			this._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.UseMnemonic = true;
			this._lbl_1.Visible = true;
			this._lbl_1.AutoSize = false;
			this._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_1.Name = "_lbl_1";
			this._lbl_10.Text = "Contents Value";
			this._lbl_10.Size = new System.Drawing.Size(91, 13);
			this._lbl_10.Location = new System.Drawing.Point(256, 15);
			this._lbl_10.TabIndex = 14;
			this._lbl_10.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_10.BackColor = System.Drawing.Color.Transparent;
			this._lbl_10.Enabled = true;
			this._lbl_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_10.UseMnemonic = true;
			this._lbl_10.Visible = true;
			this._lbl_10.AutoSize = false;
			this._lbl_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_10.Name = "_lbl_10";
			this._lbl_9.Text = "Deposit Value";
			this._lbl_9.Size = new System.Drawing.Size(91, 13);
			this._lbl_9.Location = new System.Drawing.Point(163, 15);
			this._lbl_9.TabIndex = 13;
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
			this._lbl_8.Text = "No Of Cases";
			this._lbl_8.Size = new System.Drawing.Size(60, 13);
			this._lbl_8.Location = new System.Drawing.Point(9, 15);
			this._lbl_8.TabIndex = 12;
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
			this.lblQuantity.TabIndex = 11;
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
			this.lblDeposit.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblDeposit.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			this.lblDeposit.Text = "0.00";
			this.lblDeposit.Size = new System.Drawing.Size(91, 17);
			this.lblDeposit.Location = new System.Drawing.Point(162, 27);
			this.lblDeposit.TabIndex = 10;
			this.lblDeposit.Enabled = true;
			this.lblDeposit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDeposit.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDeposit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDeposit.UseMnemonic = true;
			this.lblDeposit.Visible = true;
			this.lblDeposit.AutoSize = false;
			this.lblDeposit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDeposit.Name = "lblDeposit";
			this.lblContent.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblContent.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			this.lblContent.Text = "0.00";
			this.lblContent.Size = new System.Drawing.Size(91, 17);
			this.lblContent.Location = new System.Drawing.Point(255, 27);
			this.lblContent.TabIndex = 9;
			this.lblContent.Enabled = true;
			this.lblContent.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblContent.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblContent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblContent.UseMnemonic = true;
			this.lblContent.Visible = true;
			this.lblContent.AutoSize = false;
			this.lblContent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblContent.Name = "lblContent";
			this.Picture1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Picture1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.Picture1.ForeColor = System.Drawing.Color.White;
			this.Picture1.Size = new System.Drawing.Size(592, 25);
			this.Picture1.Location = new System.Drawing.Point(0, 38);
			this.Picture1.TabIndex = 6;
			this.Picture1.TabStop = false;
			this.Picture1.CausesValidation = true;
			this.Picture1.Enabled = true;
			this.Picture1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Picture1.Visible = true;
			this.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Picture1.Name = "Picture1";
			this.lblSupplier.Text = "lblSupplier";
			this.lblSupplier.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblSupplier.ForeColor = System.Drawing.Color.Black;
			this.lblSupplier.Size = new System.Drawing.Size(85, 20);
			this.lblSupplier.Location = new System.Drawing.Point(0, 0);
			this.lblSupplier.TabIndex = 7;
			this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblSupplier.BackColor = System.Drawing.Color.Transparent;
			this.lblSupplier.Enabled = true;
			this.lblSupplier.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblSupplier.UseMnemonic = true;
			this.lblSupplier.Visible = true;
			this.lblSupplier.AutoSize = true;
			this.lblSupplier.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblSupplier.Name = "lblSupplier";
			this._txtEdit_0.AutoSize = false;
			this._txtEdit_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtEdit_0.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this._txtEdit_0.Size = new System.Drawing.Size(55, 16);
			this._txtEdit_0.Location = new System.Drawing.Point(279, 120);
			this._txtEdit_0.TabIndex = 3;
			this._txtEdit_0.Tag = "0";
			this._txtEdit_0.Text = "0";
			this._txtEdit_0.Visible = false;
			this._txtEdit_0.AcceptsReturn = true;
			this._txtEdit_0.CausesValidation = true;
			this._txtEdit_0.Enabled = true;
			this._txtEdit_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtEdit_0.HideSelection = true;
			this._txtEdit_0.ReadOnly = false;
			this._txtEdit_0.MaxLength = 0;
			this._txtEdit_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtEdit_0.Multiline = false;
			this._txtEdit_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtEdit_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtEdit_0.TabStop = true;
			this._txtEdit_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._txtEdit_0.Name = "_txtEdit_0";
			//gridItem.OcxState = CType(resources.GetObject("gridItem.OcxState"), System.Windows.Forms.AxHost.State)
			this.gridItem.Size = new System.Drawing.Size(493, 355);
			this.gridItem.Location = new System.Drawing.Point(195, 63);
			this.gridItem.TabIndex = 5;
			this.gridItem.Name = "gridItem";
			this.txtSearch.AutoSize = false;
			this.txtSearch.Size = new System.Drawing.Size(142, 19);
			this.txtSearch.Location = new System.Drawing.Point(45, 81);
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
			this.lstWorkspace.Size = new System.Drawing.Size(187, 358);
			this.lstWorkspace.Location = new System.Drawing.Point(0, 102);
			this.lstWorkspace.TabIndex = 2;
			this.lstWorkspace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstWorkspace.BackColor = System.Drawing.SystemColors.Window;
			this.lstWorkspace.CausesValidation = true;
			this.lstWorkspace.Enabled = true;
			this.lstWorkspace.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstWorkspace.IntegralHeight = true;
			this.lstWorkspace.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstWorkspace.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstWorkspace.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstWorkspace.Sorted = false;
			this.lstWorkspace.TabStop = true;
			this.lstWorkspace.Visible = true;
			this.lstWorkspace.MultiColumn = false;
			this.lstWorkspace.Name = "lstWorkspace";
			this._lbl_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_7.Text = "&Search";
			this._lbl_7.Size = new System.Drawing.Size(34, 13);
			this._lbl_7.Location = new System.Drawing.Point(6, 84);
			this._lbl_7.TabIndex = 0;
			this._lbl_7.BackColor = System.Drawing.Color.Transparent;
			this._lbl_7.Enabled = true;
			this._lbl_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_7.UseMnemonic = true;
			this._lbl_7.Visible = true;
			this._lbl_7.AutoSize = true;
			this._lbl_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_7.Name = "_lbl_7";
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lbl_0.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
			this._lbl_0.Text = "Stock Item Selector";
			this._lbl_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_0.ForeColor = System.Drawing.Color.White;
			this._lbl_0.Size = new System.Drawing.Size(190, 16);
			this._lbl_0.Location = new System.Drawing.Point(0, 63);
			this._lbl_0.TabIndex = 4;
			this._lbl_0.Enabled = true;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.UseMnemonic = true;
			this._lbl_0.Visible = true;
			this._lbl_0.AutoSize = false;
			this._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lbl_0.Name = "_lbl_0";
			this.Controls.Add(_txtEdit_1);
			this.Controls.Add(picButtons);
			this.Controls.Add(frmTotals);
			this.Controls.Add(Picture1);
			this.Controls.Add(_txtEdit_0);
			this.Controls.Add(gridItem);
			this.Controls.Add(txtSearch);
			this.Controls.Add(lstWorkspace);
			this.Controls.Add(_lbl_7);
			this.Controls.Add(_lbl_0);
			this.picButtons.Controls.Add(cmdPriceBOM);
			this.picButtons.Controls.Add(cmdExit);
			this.picButtons.Controls.Add(cmdNext);
			this.picButtons.Controls.Add(cmdBack);
			this.picButtons.Controls.Add(cmdStockItem);
			this.picButtons.Controls.Add(cmdEdit);
			this.picButtons.Controls.Add(cmdPack);
			this.picButtons.Controls.Add(cmdDelete);
			this.frmTotals.Controls.Add(_lbl_2);
			this.frmTotals.Controls.Add(lblBrokenPack);
			this.frmTotals.Controls.Add(lblTotal);
			this.frmTotals.Controls.Add(_lbl_1);
			this.frmTotals.Controls.Add(_lbl_10);
			this.frmTotals.Controls.Add(_lbl_9);
			this.frmTotals.Controls.Add(_lbl_8);
			this.frmTotals.Controls.Add(lblQuantity);
			this.frmTotals.Controls.Add(lblDeposit);
			this.frmTotals.Controls.Add(lblContent);
			this.Picture1.Controls.Add(lblSupplier);
			this.lbl.SetIndex(_lbl_2, Convert.ToInt16(2));
			this.lbl.SetIndex(_lbl_1, Convert.ToInt16(1));
			this.lbl.SetIndex(_lbl_10, Convert.ToInt16(10));
			this.lbl.SetIndex(_lbl_9, Convert.ToInt16(9));
			this.lbl.SetIndex(_lbl_8, Convert.ToInt16(8));
			this.lbl.SetIndex(_lbl_7, Convert.ToInt16(7));
			this.lbl.SetIndex(_lbl_0, Convert.ToInt16(0));
			this.txtEdit.SetIndex(_txtEdit_1, Convert.ToInt16(1));
			this.txtEdit.SetIndex(_txtEdit_0, Convert.ToInt16(0));
			((System.ComponentModel.ISupportInitialize)this.txtEdit).EndInit();
			((System.ComponentModel.ISupportInitialize)this.lbl).EndInit();
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
