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
	partial class frmGRVitemFnV
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmGRVitemFnV() : base()
		{
			FormClosed += frmGRVitemFnV_FormClosed;
			Resize += frmGRVitemFnV_Resize;
			Load += frmGRVitemFnV_Load;
			KeyPress += frmGRVitemFnV_KeyPress;
			KeyDown += frmGRVitemFnV_KeyDown;
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
		public System.Windows.Forms.TextBox txtPackSize;
		private System.Windows.Forms.Button withEventsField_cmdEditPackSize;
		public System.Windows.Forms.Button cmdEditPackSize {
			get { return withEventsField_cmdEditPackSize; }
			set {
				if (withEventsField_cmdEditPackSize != null) {
					withEventsField_cmdEditPackSize.Click -= cmdEditPackSize_Click;
				}
				withEventsField_cmdEditPackSize = value;
				if (withEventsField_cmdEditPackSize != null) {
					withEventsField_cmdEditPackSize.Click += cmdEditPackSize_Click;
				}
			}
		}
		public System.Windows.Forms.GroupBox frmFNVeg;
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
		public System.Windows.Forms.TextBox _txtEdit_2;
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
		private System.Windows.Forms.Timer withEventsField_tmrAutoGRV;
		public System.Windows.Forms.Timer tmrAutoGRV {
			get { return withEventsField_tmrAutoGRV; }
			set {
				if (withEventsField_tmrAutoGRV != null) {
					withEventsField_tmrAutoGRV.Tick -= tmrAutoGRV_Tick;
				}
				withEventsField_tmrAutoGRV = value;
				if (withEventsField_tmrAutoGRV != null) {
					withEventsField_tmrAutoGRV.Tick += tmrAutoGRV_Tick;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdVat;
		public System.Windows.Forms.Button cmdVat {
			get { return withEventsField_cmdVat; }
			set {
				if (withEventsField_cmdVat != null) {
					withEventsField_cmdVat.Click -= cmdVAT_Click;
				}
				withEventsField_cmdVat = value;
				if (withEventsField_cmdVat != null) {
					withEventsField_cmdVat.Click += cmdVAT_Click;
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
		private System.Windows.Forms.Button withEventsField_cmdDiscount;
		public System.Windows.Forms.Button cmdDiscount {
			get { return withEventsField_cmdDiscount; }
			set {
				if (withEventsField_cmdDiscount != null) {
					withEventsField_cmdDiscount.Click -= cmdDiscount_Click;
				}
				withEventsField_cmdDiscount = value;
				if (withEventsField_cmdDiscount != null) {
					withEventsField_cmdDiscount.Click += cmdDiscount_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdPrintOrder;
		public System.Windows.Forms.Button cmdPrintOrder {
			get { return withEventsField_cmdPrintOrder; }
			set {
				if (withEventsField_cmdPrintOrder != null) {
					withEventsField_cmdPrintOrder.Click -= cmdPrintOrder_Click;
				}
				withEventsField_cmdPrintOrder = value;
				if (withEventsField_cmdPrintOrder != null) {
					withEventsField_cmdPrintOrder.Click += cmdPrintOrder_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdPrintGRV;
		public System.Windows.Forms.Button cmdPrintGRV {
			get { return withEventsField_cmdPrintGRV; }
			set {
				if (withEventsField_cmdPrintGRV != null) {
					withEventsField_cmdPrintGRV.Click -= cmdPrintGRV_Click;
				}
				withEventsField_cmdPrintGRV = value;
				if (withEventsField_cmdPrintGRV != null) {
					withEventsField_cmdPrintGRV.Click += cmdPrintGRV_Click;
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
		private System.Windows.Forms.Button withEventsField_cmdPrice;
		public System.Windows.Forms.Button cmdPrice {
			get { return withEventsField_cmdPrice; }
			set {
				if (withEventsField_cmdPrice != null) {
					withEventsField_cmdPrice.Click -= cmdPrice_Click;
				}
				withEventsField_cmdPrice = value;
				if (withEventsField_cmdPrice != null) {
					withEventsField_cmdPrice.Click += cmdPrice_Click;
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
		private System.Windows.Forms.Button withEventsField_cmdNew;
		public System.Windows.Forms.Button cmdNew {
			get { return withEventsField_cmdNew; }
			set {
				if (withEventsField_cmdNew != null) {
					withEventsField_cmdNew.Click -= cmdNew_Click;
				}
				withEventsField_cmdNew = value;
				if (withEventsField_cmdNew != null) {
					withEventsField_cmdNew.Click += cmdNew_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdQuick;
		public System.Windows.Forms.Button cmdQuick {
			get { return withEventsField_cmdQuick; }
			set {
				if (withEventsField_cmdQuick != null) {
					withEventsField_cmdQuick.Click -= cmdQuick_Click;
				}
				withEventsField_cmdQuick = value;
				if (withEventsField_cmdQuick != null) {
					withEventsField_cmdQuick.Click += cmdQuick_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdSort;
		public System.Windows.Forms.Button cmdSort {
			get { return withEventsField_cmdSort; }
			set {
				if (withEventsField_cmdSort != null) {
					withEventsField_cmdSort.Click -= cmdSort_Click;
				}
				withEventsField_cmdSort = value;
				if (withEventsField_cmdSort != null) {
					withEventsField_cmdSort.Click += cmdSort_Click;
				}
			}
		}
		private System.Windows.Forms.Panel withEventsField_Picture2;
		public System.Windows.Forms.Panel Picture2 {
			get { return withEventsField_Picture2; }
			set {
				if (withEventsField_Picture2 != null) {
					withEventsField_Picture2.Resize -= Picture2_Resize;
				}
				withEventsField_Picture2 = value;
				if (withEventsField_Picture2 != null) {
					withEventsField_Picture2.Resize += Picture2_Resize;
				}
			}
		}
		public System.Windows.Forms.Label _lblTotal_5;
		public System.Windows.Forms.Label _lblTotal_4;
		public System.Windows.Forms.Label _lblTotal_3;
		public System.Windows.Forms.Label _lblTotal_2;
		public System.Windows.Forms.Label _lblTotal_1;
		public System.Windows.Forms.Label _lblTotal_0;
		public System.Windows.Forms.Label lblTotalInclusive;
		public System.Windows.Forms.Label lblTotalExclusive;
		public System.Windows.Forms.Label lblDepositInclusive;
		public System.Windows.Forms.Label lblDepositExclusive;
		public System.Windows.Forms.Label lblContentInclusive;
		public System.Windows.Forms.Label lblContentExclusive;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label lblBrokenPack;
		public System.Windows.Forms.Label _lbl_8;
		public System.Windows.Forms.Label lblQuantity;
		public System.Windows.Forms.GroupBox frmTotals;
		public System.Windows.Forms.Label lblSupplier;
		public System.Windows.Forms.Panel Picture1;
		public System.Windows.Forms.TextBox _txtEdit_0;
		private myDataGridView withEventsField_gridItem;
		public myDataGridView gridItem {
			get { return withEventsField_gridItem; }
			set {
				if (withEventsField_gridItem != null) {
					withEventsField_gridItem.CellClick -= gridItem_ClickEvent;
					withEventsField_gridItem.CellEnter -= gridItem_EnterCell;
					withEventsField_gridItem.Enter -= gridItem_Enter;
					withEventsField_gridItem.KeyPress -= gridItem_KeyPress;
					withEventsField_gridItem.CellLeave -= gridItem_LeaveCell;
				}
				withEventsField_gridItem = value;
				if (withEventsField_gridItem != null) {
					withEventsField_gridItem.CellClick += gridItem_ClickEvent;
					withEventsField_gridItem.CellEnter += gridItem_EnterCell;
					withEventsField_gridItem.Enter += gridItem_Enter;
					withEventsField_gridItem.KeyPress += gridItem_KeyPress;
					withEventsField_gridItem.CellLeave += gridItem_LeaveCell;
				}
			}
		}
		public System.Windows.Forms.TextBox txtSearch0;
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
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label lblReturns;
		public System.Windows.Forms.Label _lbl_7;
		public System.Windows.Forms.Label _lbl_0;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblTotal As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents txtEdit As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGRVitemFnV));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.frmFNVeg = new System.Windows.Forms.GroupBox();
			this.txtPackSize = new System.Windows.Forms.TextBox();
			this.cmdEditPackSize = new System.Windows.Forms.Button();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.txtBCode = new System.Windows.Forms.TextBox();
			this._txtEdit_2 = new System.Windows.Forms.TextBox();
			this._txtEdit_1 = new System.Windows.Forms.TextBox();
			this.Picture2 = new System.Windows.Forms.Panel();
			this.cmdPriceBOM = new System.Windows.Forms.Button();
			this.tmrAutoGRV = new System.Windows.Forms.Timer(components);
			this.cmdVat = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdNext = new System.Windows.Forms.Button();
			this.cmdBack = new System.Windows.Forms.Button();
			this.cmdStockItem = new System.Windows.Forms.Button();
			this.cmdDiscount = new System.Windows.Forms.Button();
			this.cmdPrintOrder = new System.Windows.Forms.Button();
			this.cmdPrintGRV = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdPack = new System.Windows.Forms.Button();
			this.cmdPrice = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdNew = new System.Windows.Forms.Button();
			this.cmdQuick = new System.Windows.Forms.Button();
			this.cmdSort = new System.Windows.Forms.Button();
			this.frmTotals = new System.Windows.Forms.GroupBox();
			this._lblTotal_5 = new System.Windows.Forms.Label();
			this._lblTotal_4 = new System.Windows.Forms.Label();
			this._lblTotal_3 = new System.Windows.Forms.Label();
			this._lblTotal_2 = new System.Windows.Forms.Label();
			this._lblTotal_1 = new System.Windows.Forms.Label();
			this._lblTotal_0 = new System.Windows.Forms.Label();
			this.lblTotalInclusive = new System.Windows.Forms.Label();
			this.lblTotalExclusive = new System.Windows.Forms.Label();
			this.lblDepositInclusive = new System.Windows.Forms.Label();
			this.lblDepositExclusive = new System.Windows.Forms.Label();
			this.lblContentInclusive = new System.Windows.Forms.Label();
			this.lblContentExclusive = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this.lblBrokenPack = new System.Windows.Forms.Label();
			this._lbl_8 = new System.Windows.Forms.Label();
			this.lblQuantity = new System.Windows.Forms.Label();
			this.Picture1 = new System.Windows.Forms.Panel();
			this.lblSupplier = new System.Windows.Forms.Label();
			this._txtEdit_0 = new System.Windows.Forms.TextBox();
			this.gridItem = new myDataGridView();
			this.txtSearch0 = new System.Windows.Forms.TextBox();
			this.lstWorkspace = new System.Windows.Forms.ListBox();
			this._lbl_1 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.lblReturns = new System.Windows.Forms.Label();
			this._lbl_7 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblTotal = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.txtEdit = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this.frmFNVeg.SuspendLayout();
			this.Picture2.SuspendLayout();
			this.frmTotals.SuspendLayout();
			this.Picture1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.gridItem).BeginInit();
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtEdit, System.ComponentModel.ISupportInitialize).BeginInit()
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.Text = "GRV Processing Form - Fruit and Veg";
			this.ClientSize = new System.Drawing.Size(836, 566);
			this.Location = new System.Drawing.Point(4, 23);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Enabled = true;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.Name = "frmGRVitemFnV";
			this.frmFNVeg.Text = "Pack Size Volume";
			this.frmFNVeg.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.frmFNVeg.Size = new System.Drawing.Size(192, 49);
			this.frmFNVeg.Location = new System.Drawing.Point(48, 472);
			this.frmFNVeg.TabIndex = 48;
			this.frmFNVeg.BackColor = System.Drawing.SystemColors.Control;
			this.frmFNVeg.Enabled = true;
			this.frmFNVeg.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmFNVeg.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmFNVeg.Visible = true;
			this.frmFNVeg.Padding = new System.Windows.Forms.Padding(0);
			this.frmFNVeg.Name = "frmFNVeg";
			this.txtPackSize.AutoSize = false;
			this.txtPackSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPackSize.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.txtPackSize.Enabled = false;
			this.txtPackSize.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.txtPackSize.Size = new System.Drawing.Size(100, 19);
			this.txtPackSize.Location = new System.Drawing.Point(8, 24);
			this.txtPackSize.TabIndex = 50;
			this.txtPackSize.Text = "0.00";
			this.txtPackSize.AcceptsReturn = true;
			this.txtPackSize.CausesValidation = true;
			this.txtPackSize.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPackSize.HideSelection = true;
			this.txtPackSize.ReadOnly = false;
			this.txtPackSize.MaxLength = 0;
			this.txtPackSize.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPackSize.Multiline = false;
			this.txtPackSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPackSize.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtPackSize.TabStop = true;
			this.txtPackSize.Visible = true;
			this.txtPackSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtPackSize.Name = "txtPackSize";
			this.cmdEditPackSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEditPackSize.Text = "&Edit Size";
			this.cmdEditPackSize.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdEditPackSize.Size = new System.Drawing.Size(70, 32);
			this.cmdEditPackSize.Location = new System.Drawing.Point(112, 14);
			this.cmdEditPackSize.TabIndex = 49;
			this.cmdEditPackSize.TabStop = false;
			this.cmdEditPackSize.Tag = "0";
			this.cmdEditPackSize.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEditPackSize.CausesValidation = true;
			this.cmdEditPackSize.Enabled = true;
			this.cmdEditPackSize.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEditPackSize.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEditPackSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEditPackSize.Name = "cmdEditPackSize";
			this.txtSearch.AutoSize = false;
			this.txtSearch.Size = new System.Drawing.Size(142, 19);
			this.txtSearch.Location = new System.Drawing.Point(45, 104);
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
			this.txtBCode.AutoSize = false;
			this.txtBCode.Size = new System.Drawing.Size(142, 19);
			this.txtBCode.Location = new System.Drawing.Point(45, 99);
			this.txtBCode.TabIndex = 1;
			this.txtBCode.Visible = false;
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
			this.txtBCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtBCode.Name = "txtBCode";
			this._txtEdit_2.AutoSize = false;
			this._txtEdit_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtEdit_2.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this._txtEdit_2.Size = new System.Drawing.Size(55, 16);
			this._txtEdit_2.Location = new System.Drawing.Point(534, 87);
			this._txtEdit_2.MaxLength = 10;
			this._txtEdit_2.TabIndex = 43;
			this._txtEdit_2.Tag = "0";
			this._txtEdit_2.Text = "0";
			this._txtEdit_2.Visible = false;
			this._txtEdit_2.AcceptsReturn = true;
			this._txtEdit_2.CausesValidation = true;
			this._txtEdit_2.Enabled = true;
			this._txtEdit_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtEdit_2.HideSelection = true;
			this._txtEdit_2.ReadOnly = false;
			this._txtEdit_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtEdit_2.Multiline = false;
			this._txtEdit_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtEdit_2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtEdit_2.TabStop = true;
			this._txtEdit_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._txtEdit_2.Name = "_txtEdit_2";
			this._txtEdit_1.AutoSize = false;
			this._txtEdit_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtEdit_1.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this._txtEdit_1.Size = new System.Drawing.Size(55, 16);
			this._txtEdit_1.Location = new System.Drawing.Point(462, 87);
			this._txtEdit_1.MaxLength = 10;
			this._txtEdit_1.TabIndex = 42;
			this._txtEdit_1.Tag = "0";
			this._txtEdit_1.Text = "0";
			this._txtEdit_1.Visible = false;
			this._txtEdit_1.AcceptsReturn = true;
			this._txtEdit_1.CausesValidation = true;
			this._txtEdit_1.Enabled = true;
			this._txtEdit_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtEdit_1.HideSelection = true;
			this._txtEdit_1.ReadOnly = false;
			this._txtEdit_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtEdit_1.Multiline = false;
			this._txtEdit_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtEdit_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtEdit_1.TabStop = true;
			this._txtEdit_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._txtEdit_1.Name = "_txtEdit_1";
			this.Picture2.Dock = System.Windows.Forms.DockStyle.Top;
			this.Picture2.BackColor = System.Drawing.Color.Blue;
			this.Picture2.Size = new System.Drawing.Size(836, 49);
			this.Picture2.Location = new System.Drawing.Point(0, 0);
			this.Picture2.TabIndex = 27;
			this.Picture2.TabStop = false;
			this.Picture2.CausesValidation = true;
			this.Picture2.Enabled = true;
			this.Picture2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Picture2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Picture2.Visible = true;
			this.Picture2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Picture2.Name = "Picture2";
			this.cmdPriceBOM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPriceBOM.Text = "Change &BOM Price";
			this.cmdPriceBOM.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdPriceBOM.Size = new System.Drawing.Size(70, 40);
			this.cmdPriceBOM.Location = new System.Drawing.Point(731, 3);
			this.cmdPriceBOM.TabIndex = 51;
			this.cmdPriceBOM.TabStop = false;
			this.cmdPriceBOM.Tag = "0";
			this.cmdPriceBOM.Visible = false;
			this.cmdPriceBOM.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPriceBOM.CausesValidation = true;
			this.cmdPriceBOM.Enabled = true;
			this.cmdPriceBOM.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPriceBOM.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPriceBOM.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPriceBOM.Name = "cmdPriceBOM";
			this.tmrAutoGRV.Enabled = false;
			this.tmrAutoGRV.Interval = 10;
			this.cmdVat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdVat.Text = "Change VAT";
			this.cmdVat.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdVat.Size = new System.Drawing.Size(70, 40);
			this.cmdVat.Location = new System.Drawing.Point(435, 3);
			this.cmdVat.TabIndex = 44;
			this.cmdVat.TabStop = false;
			this.cmdVat.Tag = "0";
			this.cmdVat.BackColor = System.Drawing.SystemColors.Control;
			this.cmdVat.CausesValidation = true;
			this.cmdVat.Enabled = true;
			this.cmdVat.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdVat.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdVat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdVat.Name = "cmdVat";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdExit.Size = new System.Drawing.Size(67, 40);
			this.cmdExit.Location = new System.Drawing.Point(885, 3);
			this.cmdExit.TabIndex = 40;
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
			this.cmdNext.Size = new System.Drawing.Size(67, 40);
			this.cmdNext.Location = new System.Drawing.Point(813, 3);
			this.cmdNext.TabIndex = 39;
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
			this.cmdBack.Size = new System.Drawing.Size(67, 40);
			this.cmdBack.Location = new System.Drawing.Point(744, 3);
			this.cmdBack.TabIndex = 38;
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
			this.cmdStockItem.Size = new System.Drawing.Size(70, 40);
			this.cmdStockItem.Location = new System.Drawing.Point(3, 3);
			this.cmdStockItem.TabIndex = 37;
			this.cmdStockItem.TabStop = false;
			this.cmdStockItem.Tag = "0";
			this.cmdStockItem.BackColor = System.Drawing.SystemColors.Control;
			this.cmdStockItem.CausesValidation = true;
			this.cmdStockItem.Enabled = true;
			this.cmdStockItem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdStockItem.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdStockItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdStockItem.Name = "cmdStockItem";
			this.cmdDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDiscount.Text = "&Discount";
			this.cmdDiscount.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdDiscount.Size = new System.Drawing.Size(70, 40);
			this.cmdDiscount.Location = new System.Drawing.Point(291, 3);
			this.cmdDiscount.TabIndex = 36;
			this.cmdDiscount.TabStop = false;
			this.cmdDiscount.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDiscount.CausesValidation = true;
			this.cmdDiscount.Enabled = true;
			this.cmdDiscount.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDiscount.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDiscount.Name = "cmdDiscount";
			this.cmdPrintOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrintOrder.Text = "Print &Order";
			this.cmdPrintOrder.Size = new System.Drawing.Size(79, 19);
			this.cmdPrintOrder.Location = new System.Drawing.Point(507, 3);
			this.cmdPrintOrder.TabIndex = 35;
			this.cmdPrintOrder.TabStop = false;
			this.cmdPrintOrder.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrintOrder.CausesValidation = true;
			this.cmdPrintOrder.Enabled = true;
			this.cmdPrintOrder.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrintOrder.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrintOrder.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrintOrder.Name = "cmdPrintOrder";
			this.cmdPrintGRV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrintGRV.Text = "Print &GRV";
			this.cmdPrintGRV.Size = new System.Drawing.Size(79, 19);
			this.cmdPrintGRV.Location = new System.Drawing.Point(507, 24);
			this.cmdPrintGRV.TabIndex = 34;
			this.cmdPrintGRV.TabStop = false;
			this.cmdPrintGRV.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrintGRV.CausesValidation = true;
			this.cmdPrintGRV.Enabled = true;
			this.cmdPrintGRV.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrintGRV.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrintGRV.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrintGRV.Name = "cmdPrintGRV";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "Dele&te";
			this.cmdDelete.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdDelete.Size = new System.Drawing.Size(70, 40);
			this.cmdDelete.Location = new System.Drawing.Point(75, 3);
			this.cmdDelete.TabIndex = 33;
			this.cmdDelete.TabStop = false;
			this.cmdDelete.Tag = "0";
			this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelete.CausesValidation = true;
			this.cmdDelete.Enabled = true;
			this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelete.Name = "cmdDelete";
			this.cmdPack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPack.Text = "Break / Build P&ack";
			this.cmdPack.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdPack.Size = new System.Drawing.Size(70, 40);
			this.cmdPack.Location = new System.Drawing.Point(147, 3);
			this.cmdPack.TabIndex = 32;
			this.cmdPack.TabStop = false;
			this.cmdPack.Tag = "0";
			this.cmdPack.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPack.CausesValidation = true;
			this.cmdPack.Enabled = true;
			this.cmdPack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPack.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPack.Name = "cmdPack";
			this.cmdPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrice.Text = "&Change Price";
			this.cmdPrice.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdPrice.Size = new System.Drawing.Size(70, 40);
			this.cmdPrice.Location = new System.Drawing.Point(219, 3);
			this.cmdPrice.TabIndex = 31;
			this.cmdPrice.TabStop = false;
			this.cmdPrice.Tag = "0";
			this.cmdPrice.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrice.CausesValidation = true;
			this.cmdPrice.Enabled = true;
			this.cmdPrice.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrice.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrice.Name = "cmdPrice";
			this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEdit.Text = "&Edit Stock Item";
			this.cmdEdit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdEdit.Size = new System.Drawing.Size(70, 40);
			this.cmdEdit.Location = new System.Drawing.Point(588, 3);
			this.cmdEdit.TabIndex = 30;
			this.cmdEdit.TabStop = false;
			this.cmdEdit.Tag = "0";
			this.cmdEdit.Visible = false;
			this.cmdEdit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEdit.CausesValidation = true;
			this.cmdEdit.Enabled = true;
			this.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEdit.Name = "cmdEdit";
			this.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNew.Text = "Ne&w Stock Item";
			this.cmdNew.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdNew.Size = new System.Drawing.Size(70, 40);
			this.cmdNew.Location = new System.Drawing.Point(660, 3);
			this.cmdNew.TabIndex = 29;
			this.cmdNew.TabStop = false;
			this.cmdNew.Tag = "0";
			this.cmdNew.Visible = false;
			this.cmdNew.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNew.CausesValidation = true;
			this.cmdNew.Enabled = true;
			this.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNew.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNew.Name = "cmdNew";
			this.cmdQuick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdQuick.Text = "&Quick Edit";
			this.cmdQuick.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdQuick.Size = new System.Drawing.Size(70, 40);
			this.cmdQuick.Location = new System.Drawing.Point(363, 3);
			this.cmdQuick.TabIndex = 28;
			this.cmdQuick.TabStop = false;
			this.cmdQuick.BackColor = System.Drawing.SystemColors.Control;
			this.cmdQuick.CausesValidation = true;
			this.cmdQuick.Enabled = true;
			this.cmdQuick.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdQuick.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdQuick.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdQuick.Name = "cmdQuick";
			this.cmdSort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSort.Text = "&Sort";
			this.cmdSort.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdSort.Size = new System.Drawing.Size(73, 40);
			this.cmdSort.Location = new System.Drawing.Point(3, 3);
			this.cmdSort.TabIndex = 41;
			this.cmdSort.TabStop = false;
			this.cmdSort.Tag = "0";
			this.cmdSort.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSort.CausesValidation = true;
			this.cmdSort.Enabled = true;
			this.cmdSort.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSort.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSort.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSort.Name = "cmdSort";
			this.frmTotals.Text = "Sub Totals";
			this.frmTotals.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.frmTotals.Size = new System.Drawing.Size(457, 130);
			this.frmTotals.Location = new System.Drawing.Point(102, 294);
			this.frmTotals.TabIndex = 9;
			this.frmTotals.BackColor = System.Drawing.SystemColors.Control;
			this.frmTotals.Enabled = true;
			this.frmTotals.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmTotals.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmTotals.Visible = true;
			this.frmTotals.Padding = new System.Windows.Forms.Padding(0);
			this.frmTotals.Name = "frmTotals";
			this._lblTotal_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_5.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_5.Text = "Inclusive Total :";
			this._lblTotal_5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_5.Size = new System.Drawing.Size(115, 16);
			this._lblTotal_5.Location = new System.Drawing.Point(234, 102);
			this._lblTotal_5.TabIndex = 26;
			this._lblTotal_5.Enabled = true;
			this._lblTotal_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_5.UseMnemonic = true;
			this._lblTotal_5.Visible = true;
			this._lblTotal_5.AutoSize = false;
			this._lblTotal_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_5.Name = "_lblTotal_5";
			this._lblTotal_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_4.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_4.Text = "Exclusive Total :";
			this._lblTotal_4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_4.Size = new System.Drawing.Size(115, 16);
			this._lblTotal_4.Location = new System.Drawing.Point(234, 84);
			this._lblTotal_4.TabIndex = 25;
			this._lblTotal_4.Enabled = true;
			this._lblTotal_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_4.UseMnemonic = true;
			this._lblTotal_4.Visible = true;
			this._lblTotal_4.AutoSize = false;
			this._lblTotal_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_4.Name = "_lblTotal_4";
			this._lblTotal_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_3.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_3.Text = "Total Selling :";
			this._lblTotal_3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_3.Size = new System.Drawing.Size(115, 16);
			this._lblTotal_3.Location = new System.Drawing.Point(234, 66);
			this._lblTotal_3.TabIndex = 24;
			this._lblTotal_3.Enabled = true;
			this._lblTotal_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_3.UseMnemonic = true;
			this._lblTotal_3.Visible = true;
			this._lblTotal_3.AutoSize = false;
			this._lblTotal_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_3.Name = "_lblTotal_3";
			this._lblTotal_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_2.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_2.Text = "Total GP% :";
			this._lblTotal_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_2.Size = new System.Drawing.Size(115, 16);
			this._lblTotal_2.Location = new System.Drawing.Point(234, 48);
			this._lblTotal_2.TabIndex = 23;
			this._lblTotal_2.Enabled = true;
			this._lblTotal_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_2.UseMnemonic = true;
			this._lblTotal_2.Visible = true;
			this._lblTotal_2.AutoSize = false;
			this._lblTotal_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_2.Name = "_lblTotal_2";
			this._lblTotal_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_1.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_1.Text = "Inclusive Content :";
			this._lblTotal_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_1.Size = new System.Drawing.Size(115, 16);
			this._lblTotal_1.Location = new System.Drawing.Point(234, 30);
			this._lblTotal_1.TabIndex = 22;
			this._lblTotal_1.Enabled = true;
			this._lblTotal_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_1.UseMnemonic = true;
			this._lblTotal_1.Visible = true;
			this._lblTotal_1.AutoSize = false;
			this._lblTotal_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_1.Name = "_lblTotal_1";
			this._lblTotal_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_0.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_0.Text = "Exclusive Content :";
			this._lblTotal_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_0.Size = new System.Drawing.Size(115, 16);
			this._lblTotal_0.Location = new System.Drawing.Point(234, 12);
			this._lblTotal_0.TabIndex = 21;
			this._lblTotal_0.Enabled = true;
			this._lblTotal_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_0.UseMnemonic = true;
			this._lblTotal_0.Visible = true;
			this._lblTotal_0.AutoSize = false;
			this._lblTotal_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_0.Name = "_lblTotal_0";
			this.lblTotalInclusive.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblTotalInclusive.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
			this.lblTotalInclusive.Text = "0.00";
			this.lblTotalInclusive.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblTotalInclusive.Size = new System.Drawing.Size(100, 16);
			this.lblTotalInclusive.Location = new System.Drawing.Point(351, 102);
			this.lblTotalInclusive.TabIndex = 20;
			this.lblTotalInclusive.Enabled = true;
			this.lblTotalInclusive.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalInclusive.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblTotalInclusive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTotalInclusive.UseMnemonic = true;
			this.lblTotalInclusive.Visible = true;
			this.lblTotalInclusive.AutoSize = false;
			this.lblTotalInclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotalInclusive.Name = "lblTotalInclusive";
			this.lblTotalExclusive.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblTotalExclusive.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			this.lblTotalExclusive.Text = "0.00";
			this.lblTotalExclusive.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblTotalExclusive.Size = new System.Drawing.Size(100, 16);
			this.lblTotalExclusive.Location = new System.Drawing.Point(351, 84);
			this.lblTotalExclusive.TabIndex = 19;
			this.lblTotalExclusive.Enabled = true;
			this.lblTotalExclusive.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalExclusive.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblTotalExclusive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTotalExclusive.UseMnemonic = true;
			this.lblTotalExclusive.Visible = true;
			this.lblTotalExclusive.AutoSize = false;
			this.lblTotalExclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotalExclusive.Name = "lblTotalExclusive";
			this.lblDepositInclusive.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblDepositInclusive.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
			this.lblDepositInclusive.Text = "0.00";
			this.lblDepositInclusive.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblDepositInclusive.Size = new System.Drawing.Size(100, 16);
			this.lblDepositInclusive.Location = new System.Drawing.Point(351, 66);
			this.lblDepositInclusive.TabIndex = 18;
			this.lblDepositInclusive.Enabled = true;
			this.lblDepositInclusive.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDepositInclusive.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositInclusive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositInclusive.UseMnemonic = true;
			this.lblDepositInclusive.Visible = true;
			this.lblDepositInclusive.AutoSize = false;
			this.lblDepositInclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDepositInclusive.Name = "lblDepositInclusive";
			this.lblDepositExclusive.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblDepositExclusive.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.lblDepositExclusive.Text = "0.00";
			this.lblDepositExclusive.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblDepositExclusive.Size = new System.Drawing.Size(100, 16);
			this.lblDepositExclusive.Location = new System.Drawing.Point(351, 48);
			this.lblDepositExclusive.TabIndex = 17;
			this.lblDepositExclusive.Enabled = true;
			this.lblDepositExclusive.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDepositExclusive.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositExclusive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositExclusive.UseMnemonic = true;
			this.lblDepositExclusive.Visible = true;
			this.lblDepositExclusive.AutoSize = false;
			this.lblDepositExclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDepositExclusive.Name = "lblDepositExclusive";
			this.lblContentInclusive.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblContentInclusive.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
			this.lblContentInclusive.Text = "0.00";
			this.lblContentInclusive.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblContentInclusive.Size = new System.Drawing.Size(100, 16);
			this.lblContentInclusive.Location = new System.Drawing.Point(351, 30);
			this.lblContentInclusive.TabIndex = 16;
			this.lblContentInclusive.Enabled = true;
			this.lblContentInclusive.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblContentInclusive.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblContentInclusive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblContentInclusive.UseMnemonic = true;
			this.lblContentInclusive.Visible = true;
			this.lblContentInclusive.AutoSize = false;
			this.lblContentInclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblContentInclusive.Name = "lblContentInclusive";
			this.lblContentExclusive.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblContentExclusive.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.lblContentExclusive.Text = "0.00";
			this.lblContentExclusive.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblContentExclusive.Size = new System.Drawing.Size(100, 16);
			this.lblContentExclusive.Location = new System.Drawing.Point(351, 12);
			this.lblContentExclusive.TabIndex = 15;
			this.lblContentExclusive.Enabled = true;
			this.lblContentExclusive.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblContentExclusive.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblContentExclusive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblContentExclusive.UseMnemonic = true;
			this.lblContentExclusive.Visible = true;
			this.lblContentExclusive.AutoSize = false;
			this.lblContentExclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblContentExclusive.Name = "lblContentExclusive";
			this._lbl_2.Text = "Broken Packs";
			this._lbl_2.Size = new System.Drawing.Size(67, 13);
			this._lbl_2.Location = new System.Drawing.Point(78, 15);
			this._lbl_2.TabIndex = 13;
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
			this.lblBrokenPack.TabIndex = 12;
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
			this._lbl_8.Text = "No Of Cases";
			this._lbl_8.Size = new System.Drawing.Size(60, 13);
			this._lbl_8.Location = new System.Drawing.Point(9, 15);
			this._lbl_8.TabIndex = 11;
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
			this.lblQuantity.TabIndex = 10;
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
			this.Picture1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Picture1.BackColor = System.Drawing.Color.Red;
			this.Picture1.Size = new System.Drawing.Size(836, 25);
			this.Picture1.Location = new System.Drawing.Point(0, 49);
			this.Picture1.TabIndex = 7;
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
			this.lblSupplier.ForeColor = System.Drawing.Color.White;
			this.lblSupplier.Size = new System.Drawing.Size(85, 20);
			this.lblSupplier.Location = new System.Drawing.Point(0, 0);
			this.lblSupplier.TabIndex = 8;
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
			this._txtEdit_0.Location = new System.Drawing.Point(279, 138);
			this._txtEdit_0.MaxLength = 8;
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
			this._txtEdit_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtEdit_0.Multiline = false;
			this._txtEdit_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtEdit_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtEdit_0.TabStop = true;
			this._txtEdit_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._txtEdit_0.Name = "_txtEdit_0";
			//gridItem.OcxState = CType(resources.GetObject("gridItem.OcxState"), System.Windows.Forms.AxHost.State)
			this.gridItem.Size = new System.Drawing.Size(493, 319);
			this.gridItem.Location = new System.Drawing.Point(195, 117);
			this.gridItem.TabIndex = 4;
			this.gridItem.Name = "gridItem";
			this.txtSearch0.AutoSize = false;
			this.txtSearch0.Size = new System.Drawing.Size(142, 19);
			this.txtSearch0.Location = new System.Drawing.Point(45, 99);
			this.txtSearch0.TabIndex = 47;
			this.txtSearch0.Visible = false;
			this.txtSearch0.AcceptsReturn = true;
			this.txtSearch0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtSearch0.BackColor = System.Drawing.SystemColors.Window;
			this.txtSearch0.CausesValidation = true;
			this.txtSearch0.Enabled = true;
			this.txtSearch0.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtSearch0.HideSelection = true;
			this.txtSearch0.ReadOnly = false;
			this.txtSearch0.MaxLength = 0;
			this.txtSearch0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSearch0.Multiline = false;
			this.txtSearch0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtSearch0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtSearch0.TabStop = true;
			this.txtSearch0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtSearch0.Name = "txtSearch0";
			this.lstWorkspace.Size = new System.Drawing.Size(187, 306);
			this.lstWorkspace.Location = new System.Drawing.Point(0, 128);
			this.lstWorkspace.TabIndex = 2;
			this.lstWorkspace.TabStop = false;
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
			this.lstWorkspace.Visible = true;
			this.lstWorkspace.MultiColumn = false;
			this.lstWorkspace.Name = "lstWorkspace";
			this._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_1.Text = "&Search";
			this._lbl_1.Size = new System.Drawing.Size(34, 13);
			this._lbl_1.Location = new System.Drawing.Point(8, 104);
			this._lbl_1.TabIndex = 46;
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
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label1.Text = "&Barcode";
			this.Label1.Size = new System.Drawing.Size(40, 13);
			this.Label1.Location = new System.Drawing.Point(0, 102);
			this.Label1.TabIndex = 45;
			this.Label1.Visible = false;
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.AutoSize = true;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.lblReturns.BackColor = System.Drawing.Color.Red;
			this.lblReturns.Text = "RETURNS";
			this.lblReturns.Font = new System.Drawing.Font("Arial", 24f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblReturns.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblReturns.Size = new System.Drawing.Size(166, 34);
			this.lblReturns.Location = new System.Drawing.Point(195, 480);
			this.lblReturns.TabIndex = 14;
			this.lblReturns.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblReturns.Enabled = true;
			this.lblReturns.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblReturns.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblReturns.UseMnemonic = true;
			this.lblReturns.Visible = true;
			this.lblReturns.AutoSize = false;
			this.lblReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblReturns.Name = "lblReturns";
			this._lbl_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_7.Text = "Search";
			this._lbl_7.Size = new System.Drawing.Size(34, 13);
			this._lbl_7.Location = new System.Drawing.Point(48, 102);
			this._lbl_7.TabIndex = 5;
			this._lbl_7.Visible = false;
			this._lbl_7.BackColor = System.Drawing.Color.Transparent;
			this._lbl_7.Enabled = true;
			this._lbl_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_7.UseMnemonic = true;
			this._lbl_7.AutoSize = true;
			this._lbl_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_7.Name = "_lbl_7";
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lbl_0.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
			this._lbl_0.Text = "Stock Item Selector";
			this._lbl_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_0.ForeColor = System.Drawing.Color.White;
			this._lbl_0.Size = new System.Drawing.Size(190, 16);
			this._lbl_0.Location = new System.Drawing.Point(0, 81);
			this._lbl_0.TabIndex = 6;
			this._lbl_0.Enabled = true;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.UseMnemonic = true;
			this._lbl_0.Visible = true;
			this._lbl_0.AutoSize = false;
			this._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lbl_0.Name = "_lbl_0";
			this.Controls.Add(frmFNVeg);
			this.Controls.Add(txtSearch);
			this.Controls.Add(txtBCode);
			this.Controls.Add(_txtEdit_2);
			this.Controls.Add(_txtEdit_1);
			this.Controls.Add(Picture2);
			this.Controls.Add(frmTotals);
			this.Controls.Add(Picture1);
			this.Controls.Add(_txtEdit_0);
			this.Controls.Add(gridItem);
			this.Controls.Add(txtSearch0);
			this.Controls.Add(lstWorkspace);
			this.Controls.Add(_lbl_1);
			this.Controls.Add(Label1);
			this.Controls.Add(lblReturns);
			this.Controls.Add(_lbl_7);
			this.Controls.Add(_lbl_0);
			this.frmFNVeg.Controls.Add(txtPackSize);
			this.frmFNVeg.Controls.Add(cmdEditPackSize);
			this.Picture2.Controls.Add(cmdPriceBOM);
			this.Picture2.Controls.Add(cmdVat);
			this.Picture2.Controls.Add(cmdExit);
			this.Picture2.Controls.Add(cmdNext);
			this.Picture2.Controls.Add(cmdBack);
			this.Picture2.Controls.Add(cmdStockItem);
			this.Picture2.Controls.Add(cmdDiscount);
			this.Picture2.Controls.Add(cmdPrintOrder);
			this.Picture2.Controls.Add(cmdPrintGRV);
			this.Picture2.Controls.Add(cmdDelete);
			this.Picture2.Controls.Add(cmdPack);
			this.Picture2.Controls.Add(cmdPrice);
			this.Picture2.Controls.Add(cmdEdit);
			this.Picture2.Controls.Add(cmdNew);
			this.Picture2.Controls.Add(cmdQuick);
			this.Picture2.Controls.Add(cmdSort);
			this.frmTotals.Controls.Add(_lblTotal_5);
			this.frmTotals.Controls.Add(_lblTotal_4);
			this.frmTotals.Controls.Add(_lblTotal_3);
			this.frmTotals.Controls.Add(_lblTotal_2);
			this.frmTotals.Controls.Add(_lblTotal_1);
			this.frmTotals.Controls.Add(_lblTotal_0);
			this.frmTotals.Controls.Add(lblTotalInclusive);
			this.frmTotals.Controls.Add(lblTotalExclusive);
			this.frmTotals.Controls.Add(lblDepositInclusive);
			this.frmTotals.Controls.Add(lblDepositExclusive);
			this.frmTotals.Controls.Add(lblContentInclusive);
			this.frmTotals.Controls.Add(lblContentExclusive);
			this.frmTotals.Controls.Add(_lbl_2);
			this.frmTotals.Controls.Add(lblBrokenPack);
			this.frmTotals.Controls.Add(_lbl_8);
			this.frmTotals.Controls.Add(lblQuantity);
			this.Picture1.Controls.Add(lblSupplier);
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_8, CType(8, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_7, CType(7, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.lblTotal.SetIndex(_lblTotal_5, CType(5, Short))
			//Me.lblTotal.SetIndex(_lblTotal_4, CType(4, Short))
			//Me.lblTotal.SetIndex(_lblTotal_3, CType(3, Short))
			//Me.lblTotal.SetIndex(_lblTotal_2, CType(2, Short))
			//Me.lblTotal.SetIndex(_lblTotal_1, CType(1, Short))
			//Me.lblTotal.SetIndex(_lblTotal_0, CType(0, Short))
			//Me.txtEdit.SetIndex(_txtEdit_2, CType(2, Short))
			//Me.txtEdit.SetIndex(_txtEdit_1, CType(1, Short))
			//Me.txtEdit.SetIndex(_txtEdit_0, CType(0, Short))
			//CType(Me.txtEdit, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this.gridItem).EndInit();
			this.frmFNVeg.ResumeLayout(false);
			this.Picture2.ResumeLayout(false);
			this.frmTotals.ResumeLayout(false);
			this.Picture1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
