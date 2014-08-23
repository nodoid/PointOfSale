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
	partial class frmStockItemNew
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockItemNew() : base()
		{
			Load += frmStockItemNew_Load;
			KeyPress += frmStockItemNew_KeyPress;
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
		private System.Windows.Forms.Button withEventsField_cmdPackSize;
		public System.Windows.Forms.Button cmdPackSize {
			get { return withEventsField_cmdPackSize; }
			set {
				if (withEventsField_cmdPackSize != null) {
					withEventsField_cmdPackSize.Click -= cmdPackSize_Click;
				}
				withEventsField_cmdPackSize = value;
				if (withEventsField_cmdPackSize != null) {
					withEventsField_cmdPackSize.Click += cmdPackSize_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdStockGroup;
		public System.Windows.Forms.Button cmdStockGroup {
			get { return withEventsField_cmdStockGroup; }
			set {
				if (withEventsField_cmdStockGroup != null) {
					withEventsField_cmdStockGroup.Click -= cmdStockGroup_Click;
				}
				withEventsField_cmdStockGroup = value;
				if (withEventsField_cmdStockGroup != null) {
					withEventsField_cmdStockGroup.Click += cmdStockGroup_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdPricingGroup;
		public System.Windows.Forms.Button cmdPricingGroup {
			get { return withEventsField_cmdPricingGroup; }
			set {
				if (withEventsField_cmdPricingGroup != null) {
					withEventsField_cmdPricingGroup.Click -= cmdPricingGroup_Click;
				}
				withEventsField_cmdPricingGroup = value;
				if (withEventsField_cmdPricingGroup != null) {
					withEventsField_cmdPricingGroup.Click += cmdPricingGroup_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDeposit;
		public System.Windows.Forms.Button cmdDeposit {
			get { return withEventsField_cmdDeposit; }
			set {
				if (withEventsField_cmdDeposit != null) {
					withEventsField_cmdDeposit.Click -= cmdDeposit_Click;
				}
				withEventsField_cmdDeposit = value;
				if (withEventsField_cmdDeposit != null) {
					withEventsField_cmdDeposit.Click += cmdDeposit_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdSupplier;
		public System.Windows.Forms.Button cmdSupplier {
			get { return withEventsField_cmdSupplier; }
			set {
				if (withEventsField_cmdSupplier != null) {
					withEventsField_cmdSupplier.Click -= cmdSupplier_Click;
				}
				withEventsField_cmdSupplier = value;
				if (withEventsField_cmdSupplier != null) {
					withEventsField_cmdSupplier.Click += cmdSupplier_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdShrink;
		public System.Windows.Forms.Button cmdShrink {
			get { return withEventsField_cmdShrink; }
			set {
				if (withEventsField_cmdShrink != null) {
					withEventsField_cmdShrink.Click -= cmdShrink_Click;
				}
				withEventsField_cmdShrink = value;
				if (withEventsField_cmdShrink != null) {
					withEventsField_cmdShrink.Click += cmdShrink_Click;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtCost;
		public System.Windows.Forms.TextBox txtCost {
			get { return withEventsField_txtCost; }
			set {
				if (withEventsField_txtCost != null) {
					withEventsField_txtCost.Enter -= txtCost_Enter;
					withEventsField_txtCost.KeyPress -= txtCost_KeyPress;
					withEventsField_txtCost.Leave -= txtCost_Leave;
				}
				withEventsField_txtCost = value;
				if (withEventsField_txtCost != null) {
					withEventsField_txtCost.Enter += txtCost_Enter;
					withEventsField_txtCost.KeyPress += txtCost_KeyPress;
					withEventsField_txtCost.Leave += txtCost_Leave;
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
		private myDataGridView withEventsField_cmbShrink;
		public myDataGridView cmbShrink {
			get { return withEventsField_cmbShrink; }
			set {
				if (withEventsField_cmbShrink != null) {
					withEventsField_cmbShrink.KeyDown -= cmbShrink_KeyDown;
				}
				withEventsField_cmbShrink = value;
				if (withEventsField_cmbShrink != null) {
					withEventsField_cmbShrink.KeyDown += cmbShrink_KeyDown;
				}
			}
		}
		public System.Windows.Forms.Label _lblLabels_1;
		public System.Windows.Forms.Label _lblLabels_10;
		public System.Windows.Forms.Label _lblLabels_2;
		public System.Windows.Forms.GroupBox Frame1;
		private System.Windows.Forms.TextBox withEventsField_txtReceipt;
		public System.Windows.Forms.TextBox txtReceipt {
			get { return withEventsField_txtReceipt; }
			set {
				if (withEventsField_txtReceipt != null) {
					withEventsField_txtReceipt.Enter -= txtReceipt_Enter;
				}
				withEventsField_txtReceipt = value;
				if (withEventsField_txtReceipt != null) {
					withEventsField_txtReceipt.Enter += txtReceipt_Enter;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtName;
		public System.Windows.Forms.TextBox txtName {
			get { return withEventsField_txtName; }
			set {
				if (withEventsField_txtName != null) {
					withEventsField_txtName.Enter -= txtName_Enter;
					withEventsField_txtName.Leave -= txtName_Leave;
				}
				withEventsField_txtName = value;
				if (withEventsField_txtName != null) {
					withEventsField_txtName.Enter += txtName_Enter;
					withEventsField_txtName.Leave += txtName_Leave;
				}
			}
		}
		public System.Windows.Forms.PictureBox Picture1;
		private myDataGridView withEventsField_cmbPricingGroup;
		public myDataGridView cmbPricingGroup {
			get { return withEventsField_cmbPricingGroup; }
			set {
				if (withEventsField_cmbPricingGroup != null) {
					withEventsField_cmbPricingGroup.KeyDown -= cmbPricingGroup_KeyDown;
				}
				withEventsField_cmbPricingGroup = value;
				if (withEventsField_cmbPricingGroup != null) {
					withEventsField_cmbPricingGroup.KeyDown += cmbPricingGroup_KeyDown;
				}
			}
		}
		private myDataGridView withEventsField_cmbStockGroup;
		public myDataGridView cmbStockGroup {
			get { return withEventsField_cmbStockGroup; }
			set {
				if (withEventsField_cmbStockGroup != null) {
					withEventsField_cmbStockGroup.KeyDown -= cmbStockGroup_KeyDown;
				}
				withEventsField_cmbStockGroup = value;
				if (withEventsField_cmbStockGroup != null) {
					withEventsField_cmbStockGroup.KeyDown += cmbStockGroup_KeyDown;
				}
			}
		}
		private myDataGridView withEventsField_cmbDeposit;
		public myDataGridView cmbDeposit {
			get { return withEventsField_cmbDeposit; }
			set {
				if (withEventsField_cmbDeposit != null) {
					withEventsField_cmbDeposit.KeyDown -= cmbDeposit_KeyDown;
				}
				withEventsField_cmbDeposit = value;
				if (withEventsField_cmbDeposit != null) {
					withEventsField_cmbDeposit.KeyDown += cmbDeposit_KeyDown;
				}
			}
		}
		private myDataGridView withEventsField_cmbSupplier;
		public myDataGridView cmbSupplier {
			get { return withEventsField_cmbSupplier; }
			set {
				if (withEventsField_cmbSupplier != null) {
					withEventsField_cmbSupplier.KeyDown -= cmbSupplier_KeyDown;
				}
				withEventsField_cmbSupplier = value;
				if (withEventsField_cmbSupplier != null) {
					withEventsField_cmbSupplier.KeyDown += cmbSupplier_KeyDown;
				}
			}
		}
		private myDataGridView withEventsField_cmbPackSize;
		public myDataGridView cmbPackSize {
			get { return withEventsField_cmbPackSize; }
			set {
				if (withEventsField_cmbPackSize != null) {
					withEventsField_cmbPackSize.KeyDown -= cmbPackSize_KeyDown;
				}
				withEventsField_cmbPackSize = value;
				if (withEventsField_cmbPackSize != null) {
					withEventsField_cmbPackSize.KeyDown += cmbPackSize_KeyDown;
				}
			}
		}
		public System.Windows.Forms.Label _lblLabels_5;
		public System.Windows.Forms.Label _lblLabels_8;
		public System.Windows.Forms.Label _lblLabels_7;
		public System.Windows.Forms.Label _lblLabels_4;
		public System.Windows.Forms.Label _lblLabels_3;
		public System.Windows.Forms.Label _lblLabels_0;
		public System.Windows.Forms.Label _lblLabels_6;
		public System.Windows.Forms.GroupBox _frmMode_1;
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
		private System.Windows.Forms.Button withEventsField_cmdCustom;
		public System.Windows.Forms.Button cmdCustom {
			get { return withEventsField_cmdCustom; }
			set {
				if (withEventsField_cmdCustom != null) {
					withEventsField_cmdCustom.Click -= cmdCustom_Click;
				}
				withEventsField_cmdCustom = value;
				if (withEventsField_cmdCustom != null) {
					withEventsField_cmdCustom.Click += cmdCustom_Click;
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
		public System.Windows.Forms.Label lblRecords;
		public System.Windows.Forms.Label _lbl_35;
		public System.Windows.Forms.GroupBox _frmMode_0;
		//Public WithEvents frmMode As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockItemNew));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdBack = new System.Windows.Forms.Button();
			this.cmdNext = new System.Windows.Forms.Button();
			this._frmMode_1 = new System.Windows.Forms.GroupBox();
			this.cmdPackSize = new System.Windows.Forms.Button();
			this.cmdStockGroup = new System.Windows.Forms.Button();
			this.cmdPricingGroup = new System.Windows.Forms.Button();
			this.cmdDeposit = new System.Windows.Forms.Button();
			this.cmdSupplier = new System.Windows.Forms.Button();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.cmdShrink = new System.Windows.Forms.Button();
			this.txtCost = new System.Windows.Forms.TextBox();
			this.txtQuantity = new System.Windows.Forms.TextBox();
			this.cmbShrink = new myDataGridView();
			this._lblLabels_1 = new System.Windows.Forms.Label();
			this._lblLabels_10 = new System.Windows.Forms.Label();
			this._lblLabels_2 = new System.Windows.Forms.Label();
			this.txtReceipt = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.Picture1 = new System.Windows.Forms.PictureBox();
			this.cmbPricingGroup = new myDataGridView();
			this.cmbStockGroup = new myDataGridView();
			this.cmbDeposit = new myDataGridView();
			this.cmbSupplier = new myDataGridView();
			this.cmbPackSize = new myDataGridView();
			this._lblLabels_5 = new System.Windows.Forms.Label();
			this._lblLabels_8 = new System.Windows.Forms.Label();
			this._lblLabels_7 = new System.Windows.Forms.Label();
			this._lblLabels_4 = new System.Windows.Forms.Label();
			this._lblLabels_3 = new System.Windows.Forms.Label();
			this._lblLabels_0 = new System.Windows.Forms.Label();
			this._lblLabels_6 = new System.Windows.Forms.Label();
			this._frmMode_0 = new System.Windows.Forms.GroupBox();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.cmdCustom = new System.Windows.Forms.Button();
			this.DataList1 = new myDataGridView();
			this.lblRecords = new System.Windows.Forms.Label();
			this._lbl_35 = new System.Windows.Forms.Label();
			//Me.frmMode = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this._frmMode_1.SuspendLayout();
			this.Frame1.SuspendLayout();
			this._frmMode_0.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.cmbShrink).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbPricingGroup).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbStockGroup).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbDeposit).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbSupplier).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbPackSize).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.DataList1).BeginInit();
			//CType(Me.frmMode, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "New Stock Item";
			this.ClientSize = new System.Drawing.Size(366, 413);
			this.Location = new System.Drawing.Point(3, 22);
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
			this.Name = "frmStockItemNew";
			this.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBack.Text = "E&xit";
			this.cmdBack.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdBack.Size = new System.Drawing.Size(97, 43);
			this.cmdBack.Location = new System.Drawing.Point(4, 364);
			this.cmdBack.TabIndex = 20;
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
			this.cmdNext.Size = new System.Drawing.Size(96, 43);
			this.cmdNext.Location = new System.Drawing.Point(266, 364);
			this.cmdNext.TabIndex = 19;
			this.cmdNext.TabStop = false;
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.CausesValidation = true;
			this.cmdNext.Enabled = true;
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.Name = "cmdNext";
			this._frmMode_1.Text = "New \"Stock Item\" Details.";
			this._frmMode_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmMode_1.Size = new System.Drawing.Size(357, 353);
			this._frmMode_1.Location = new System.Drawing.Point(96, 6);
			this._frmMode_1.TabIndex = 0;
			this._frmMode_1.BackColor = System.Drawing.SystemColors.Control;
			this._frmMode_1.Enabled = true;
			this._frmMode_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmMode_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmMode_1.Visible = true;
			this._frmMode_1.Padding = new System.Windows.Forms.Padding(0);
			this._frmMode_1.Name = "_frmMode_1";
			this.cmdPackSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPackSize.Text = "...";
			this.cmdPackSize.Size = new System.Drawing.Size(25, 19);
			this.cmdPackSize.Location = new System.Drawing.Point(326, 158);
			this.cmdPackSize.TabIndex = 36;
			this.cmdPackSize.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPackSize.CausesValidation = true;
			this.cmdPackSize.Enabled = true;
			this.cmdPackSize.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPackSize.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPackSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPackSize.TabStop = true;
			this.cmdPackSize.Name = "cmdPackSize";
			this.cmdStockGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdStockGroup.Text = "...";
			this.cmdStockGroup.Size = new System.Drawing.Size(25, 19);
			this.cmdStockGroup.Location = new System.Drawing.Point(326, 134);
			this.cmdStockGroup.TabIndex = 31;
			this.cmdStockGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdStockGroup.CausesValidation = true;
			this.cmdStockGroup.Enabled = true;
			this.cmdStockGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdStockGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdStockGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdStockGroup.TabStop = true;
			this.cmdStockGroup.Name = "cmdStockGroup";
			this.cmdPricingGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPricingGroup.Text = "...";
			this.cmdPricingGroup.Size = new System.Drawing.Size(25, 19);
			this.cmdPricingGroup.Location = new System.Drawing.Point(326, 110);
			this.cmdPricingGroup.TabIndex = 30;
			this.cmdPricingGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPricingGroup.CausesValidation = true;
			this.cmdPricingGroup.Enabled = true;
			this.cmdPricingGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPricingGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPricingGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPricingGroup.TabStop = true;
			this.cmdPricingGroup.Name = "cmdPricingGroup";
			this.cmdDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDeposit.Text = "...";
			this.cmdDeposit.Size = new System.Drawing.Size(25, 19);
			this.cmdDeposit.Location = new System.Drawing.Point(326, 86);
			this.cmdDeposit.TabIndex = 29;
			this.cmdDeposit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDeposit.CausesValidation = true;
			this.cmdDeposit.Enabled = true;
			this.cmdDeposit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDeposit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDeposit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDeposit.TabStop = true;
			this.cmdDeposit.Name = "cmdDeposit";
			this.cmdSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSupplier.Text = "...";
			this.cmdSupplier.Size = new System.Drawing.Size(25, 19);
			this.cmdSupplier.Location = new System.Drawing.Point(326, 62);
			this.cmdSupplier.TabIndex = 28;
			this.cmdSupplier.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSupplier.CausesValidation = true;
			this.cmdSupplier.Enabled = true;
			this.cmdSupplier.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSupplier.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSupplier.TabStop = true;
			this.cmdSupplier.Name = "cmdSupplier";
			this.Frame1.Size = new System.Drawing.Size(343, 75);
			this.Frame1.Location = new System.Drawing.Point(8, 200);
			this.Frame1.TabIndex = 21;
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.cmdShrink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdShrink.Text = "...";
			this.cmdShrink.Size = new System.Drawing.Size(25, 19);
			this.cmdShrink.Location = new System.Drawing.Point(230, 40);
			this.cmdShrink.TabIndex = 32;
			this.cmdShrink.BackColor = System.Drawing.SystemColors.Control;
			this.cmdShrink.CausesValidation = true;
			this.cmdShrink.Enabled = true;
			this.cmdShrink.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdShrink.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdShrink.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdShrink.TabStop = true;
			this.cmdShrink.Name = "cmdShrink";
			this.txtCost.AutoSize = false;
			this.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtCost.Size = new System.Drawing.Size(56, 19);
			this.txtCost.Location = new System.Drawing.Point(282, 14);
			this.txtCost.TabIndex = 25;
			this.txtCost.Text = "0.00";
			this.txtCost.AcceptsReturn = true;
			this.txtCost.BackColor = System.Drawing.SystemColors.Window;
			this.txtCost.CausesValidation = true;
			this.txtCost.Enabled = true;
			this.txtCost.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCost.HideSelection = true;
			this.txtCost.ReadOnly = false;
			this.txtCost.MaxLength = 0;
			this.txtCost.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtCost.Multiline = false;
			this.txtCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtCost.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtCost.TabStop = true;
			this.txtCost.Visible = true;
			this.txtCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCost.Name = "txtCost";
			this.txtQuantity.AutoSize = false;
			this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtQuantity.Size = new System.Drawing.Size(34, 19);
			this.txtQuantity.Location = new System.Drawing.Point(68, 14);
			this.txtQuantity.TabIndex = 23;
			this.txtQuantity.Text = "1";
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
			this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtQuantity.Name = "txtQuantity";
			//cmbShrink.OcxState = CType(resources.GetObject("cmbShrink.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbShrink.Size = new System.Drawing.Size(91, 21);
			this.cmbShrink.Location = new System.Drawing.Point(132, 38);
			this.cmbShrink.TabIndex = 27;
			this.cmbShrink.Name = "cmbShrink";
			this._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_1.Text = "and you sell in shrinks of";
			this._lblLabels_1.Size = new System.Drawing.Size(115, 13);
			this._lblLabels_1.Location = new System.Drawing.Point(14, 42);
			this._lblLabels_1.TabIndex = 26;
			this._lblLabels_1.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_1.Enabled = true;
			this._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_1.UseMnemonic = true;
			this._lblLabels_1.Visible = true;
			this._lblLabels_1.AutoSize = true;
			this._lblLabels_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_1.Name = "_lblLabels_1";
			this._lblLabels_10.Text = "Units in a case/carton, which costs";
			this._lblLabels_10.Size = new System.Drawing.Size(167, 13);
			this._lblLabels_10.Location = new System.Drawing.Point(106, 16);
			this._lblLabels_10.TabIndex = 24;
			this._lblLabels_10.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblLabels_10.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_10.Enabled = true;
			this._lblLabels_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_10.UseMnemonic = true;
			this._lblLabels_10.Visible = true;
			this._lblLabels_10.AutoSize = true;
			this._lblLabels_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_10.Name = "_lblLabels_10";
			this._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_2.Text = "There are ";
			this._lblLabels_2.Size = new System.Drawing.Size(49, 13);
			this._lblLabels_2.Location = new System.Drawing.Point(14, 16);
			this._lblLabels_2.TabIndex = 22;
			this._lblLabels_2.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_2.Enabled = true;
			this._lblLabels_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_2.UseMnemonic = true;
			this._lblLabels_2.Visible = true;
			this._lblLabels_2.AutoSize = true;
			this._lblLabels_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_2.Name = "_lblLabels_2";
			this.txtReceipt.AutoSize = false;
			this.txtReceipt.Size = new System.Drawing.Size(241, 19);
			this.txtReceipt.Location = new System.Drawing.Point(82, 40);
			this.txtReceipt.MaxLength = 40;
			this.txtReceipt.TabIndex = 4;
			this.txtReceipt.Text = "[New Product]";
			this.txtReceipt.AcceptsReturn = true;
			this.txtReceipt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtReceipt.BackColor = System.Drawing.SystemColors.Window;
			this.txtReceipt.CausesValidation = true;
			this.txtReceipt.Enabled = true;
			this.txtReceipt.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtReceipt.HideSelection = true;
			this.txtReceipt.ReadOnly = false;
			this.txtReceipt.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtReceipt.Multiline = false;
			this.txtReceipt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtReceipt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtReceipt.TabStop = true;
			this.txtReceipt.Visible = true;
			this.txtReceipt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtReceipt.Name = "txtReceipt";
			this.txtName.AutoSize = false;
			this.txtName.Size = new System.Drawing.Size(241, 19);
			this.txtName.Location = new System.Drawing.Point(82, 18);
			this.txtName.MaxLength = 128;
			this.txtName.TabIndex = 2;
			this.txtName.Text = "[New Product]";
			this.txtName.AcceptsReturn = true;
			this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtName.BackColor = System.Drawing.SystemColors.Window;
			this.txtName.CausesValidation = true;
			this.txtName.Enabled = true;
			this.txtName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtName.HideSelection = true;
			this.txtName.ReadOnly = false;
			this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtName.Multiline = false;
			this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtName.TabStop = true;
			this.txtName.Visible = true;
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.Name = "txtName";
			this.Picture1.Size = new System.Drawing.Size(295, 4);
			this.Picture1.Location = new System.Drawing.Point(28, 192);
			this.Picture1.TabIndex = 13;
			this.Picture1.TabStop = false;
			this.Picture1.Dock = System.Windows.Forms.DockStyle.None;
			this.Picture1.BackColor = System.Drawing.SystemColors.Control;
			this.Picture1.CausesValidation = true;
			this.Picture1.Enabled = true;
			this.Picture1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Picture1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Picture1.Visible = true;
			this.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Picture1.Name = "Picture1";
			//cmbPricingGroup.OcxState = CType(resources.GetObject("cmbPricingGroup.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbPricingGroup.Size = new System.Drawing.Size(241, 21);
			this.cmbPricingGroup.Location = new System.Drawing.Point(82, 108);
			this.cmbPricingGroup.TabIndex = 10;
			this.cmbPricingGroup.Name = "cmbPricingGroup";
			//cmbStockGroup.OcxState = CType(resources.GetObject("cmbStockGroup.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbStockGroup.Size = new System.Drawing.Size(241, 21);
			this.cmbStockGroup.Location = new System.Drawing.Point(82, 132);
			this.cmbStockGroup.TabIndex = 12;
			this.cmbStockGroup.Name = "cmbStockGroup";
			//cmbDeposit.OcxState = CType(resources.GetObject("cmbDeposit.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbDeposit.Size = new System.Drawing.Size(241, 21);
			this.cmbDeposit.Location = new System.Drawing.Point(82, 84);
			this.cmbDeposit.TabIndex = 8;
			this.cmbDeposit.Name = "cmbDeposit";
			//cmbSupplier.OcxState = CType(resources.GetObject("cmbSupplier.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbSupplier.Size = new System.Drawing.Size(241, 21);
			this.cmbSupplier.Location = new System.Drawing.Point(82, 60);
			this.cmbSupplier.TabIndex = 6;
			this.cmbSupplier.Name = "cmbSupplier";
			//cmbPackSize.OcxState = CType(resources.GetObject("cmbPackSize.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbPackSize.Size = new System.Drawing.Size(241, 21);
			this.cmbPackSize.Location = new System.Drawing.Point(82, 156);
			this.cmbPackSize.TabIndex = 35;
			this.cmbPackSize.Name = "cmbPackSize";
			this._lblLabels_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_5.Text = "Pack Size:";
			this._lblLabels_5.Size = new System.Drawing.Size(51, 13);
			this._lblLabels_5.Location = new System.Drawing.Point(28, 160);
			this._lblLabels_5.TabIndex = 34;
			this._lblLabels_5.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_5.Enabled = true;
			this._lblLabels_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_5.UseMnemonic = true;
			this._lblLabels_5.Visible = true;
			this._lblLabels_5.AutoSize = true;
			this._lblLabels_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_5.Name = "_lblLabels_5";
			this._lblLabels_8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_8.Text = "Receipt Name:";
			this._lblLabels_8.Size = new System.Drawing.Size(71, 13);
			this._lblLabels_8.Location = new System.Drawing.Point(6, 45);
			this._lblLabels_8.TabIndex = 3;
			this._lblLabels_8.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_8.Enabled = true;
			this._lblLabels_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_8.UseMnemonic = true;
			this._lblLabels_8.Visible = true;
			this._lblLabels_8.AutoSize = true;
			this._lblLabels_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_8.Name = "_lblLabels_8";
			this._lblLabels_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_7.Text = "Display Name:";
			this._lblLabels_7.Size = new System.Drawing.Size(68, 13);
			this._lblLabels_7.Location = new System.Drawing.Point(10, 20);
			this._lblLabels_7.TabIndex = 1;
			this._lblLabels_7.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_7.Enabled = true;
			this._lblLabels_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_7.UseMnemonic = true;
			this._lblLabels_7.Visible = true;
			this._lblLabels_7.AutoSize = true;
			this._lblLabels_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_7.Name = "_lblLabels_7";
			this._lblLabels_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_4.Text = "Stock Group:";
			this._lblLabels_4.Size = new System.Drawing.Size(63, 13);
			this._lblLabels_4.Location = new System.Drawing.Point(14, 138);
			this._lblLabels_4.TabIndex = 11;
			this._lblLabels_4.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_4.Enabled = true;
			this._lblLabels_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_4.UseMnemonic = true;
			this._lblLabels_4.Visible = true;
			this._lblLabels_4.AutoSize = true;
			this._lblLabels_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_4.Name = "_lblLabels_4";
			this._lblLabels_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_3.Text = "Pricing Group:";
			this._lblLabels_3.Size = new System.Drawing.Size(67, 13);
			this._lblLabels_3.Location = new System.Drawing.Point(10, 114);
			this._lblLabels_3.TabIndex = 9;
			this._lblLabels_3.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_3.Enabled = true;
			this._lblLabels_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_3.UseMnemonic = true;
			this._lblLabels_3.Visible = true;
			this._lblLabels_3.AutoSize = true;
			this._lblLabels_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_3.Name = "_lblLabels_3";
			this._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_0.Text = "Supplier:";
			this._lblLabels_0.Size = new System.Drawing.Size(41, 13);
			this._lblLabels_0.Location = new System.Drawing.Point(36, 66);
			this._lblLabels_0.TabIndex = 5;
			this._lblLabels_0.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_0.Enabled = true;
			this._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_0.UseMnemonic = true;
			this._lblLabels_0.Visible = true;
			this._lblLabels_0.AutoSize = true;
			this._lblLabels_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_0.Name = "_lblLabels_0";
			this._lblLabels_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_6.Text = "Deposit:";
			this._lblLabels_6.Size = new System.Drawing.Size(39, 13);
			this._lblLabels_6.Location = new System.Drawing.Point(38, 90);
			this._lblLabels_6.TabIndex = 7;
			this._lblLabels_6.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_6.Enabled = true;
			this._lblLabels_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_6.UseMnemonic = true;
			this._lblLabels_6.Visible = true;
			this._lblLabels_6.AutoSize = true;
			this._lblLabels_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_6.Name = "_lblLabels_6";
			this._frmMode_0.Text = "Select the Product for the New \"Stock Item\".";
			this._frmMode_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmMode_0.Size = new System.Drawing.Size(357, 355);
			this._frmMode_0.Location = new System.Drawing.Point(4, 4);
			this._frmMode_0.TabIndex = 15;
			this._frmMode_0.BackColor = System.Drawing.SystemColors.Control;
			this._frmMode_0.Enabled = true;
			this._frmMode_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmMode_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmMode_0.Visible = true;
			this._frmMode_0.Padding = new System.Windows.Forms.Padding(0);
			this._frmMode_0.Name = "_frmMode_0";
			this.txtSearch.AutoSize = false;
			this.txtSearch.Size = new System.Drawing.Size(291, 19);
			this.txtSearch.Location = new System.Drawing.Point(57, 18);
			this.txtSearch.TabIndex = 16;
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
			this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSearch.Name = "txtSearch";
			this.cmdCustom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCustom.Text = "The product I want is not in this list.";
			this.cmdCustom.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdCustom.Size = new System.Drawing.Size(336, 37);
			this.cmdCustom.Location = new System.Drawing.Point(12, 306);
			this.cmdCustom.TabIndex = 18;
			this.cmdCustom.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCustom.CausesValidation = true;
			this.cmdCustom.Enabled = true;
			this.cmdCustom.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCustom.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCustom.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCustom.TabStop = true;
			this.cmdCustom.Name = "cmdCustom";
			//'DataList1.OcxState = CType(resources.GetObject("'DataList1.OcxState"), System.Windows.Forms.AxHost.State)
			this.DataList1.Size = new System.Drawing.Size(336, 225);
			this.DataList1.Location = new System.Drawing.Point(12, 44);
			this.DataList1.TabIndex = 17;
			this.DataList1.Name = "DataList1";
			this.lblRecords.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblRecords.Text = "Displayed Records 0 of 0";
			this.lblRecords.Font = new System.Drawing.Font("Verdana", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblRecords.Size = new System.Drawing.Size(336, 17);
			this.lblRecords.Location = new System.Drawing.Point(12, 272);
			this.lblRecords.TabIndex = 33;
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
			this._lbl_35.Text = "Search";
			this._lbl_35.Size = new System.Drawing.Size(43, 16);
			this._lbl_35.Location = new System.Drawing.Point(15, 21);
			this._lbl_35.TabIndex = 14;
			this._lbl_35.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_35.BackColor = System.Drawing.SystemColors.Control;
			this._lbl_35.Enabled = true;
			this._lbl_35.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_35.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_35.UseMnemonic = true;
			this._lbl_35.Visible = true;
			this._lbl_35.AutoSize = false;
			this._lbl_35.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_35.Name = "_lbl_35";
			this.Controls.Add(cmdBack);
			this.Controls.Add(cmdNext);
			this.Controls.Add(_frmMode_1);
			this.Controls.Add(_frmMode_0);
			this._frmMode_1.Controls.Add(cmdPackSize);
			this._frmMode_1.Controls.Add(cmdStockGroup);
			this._frmMode_1.Controls.Add(cmdPricingGroup);
			this._frmMode_1.Controls.Add(cmdDeposit);
			this._frmMode_1.Controls.Add(cmdSupplier);
			this._frmMode_1.Controls.Add(Frame1);
			this._frmMode_1.Controls.Add(txtReceipt);
			this._frmMode_1.Controls.Add(txtName);
			this._frmMode_1.Controls.Add(Picture1);
			this._frmMode_1.Controls.Add(cmbPricingGroup);
			this._frmMode_1.Controls.Add(cmbStockGroup);
			this._frmMode_1.Controls.Add(cmbDeposit);
			this._frmMode_1.Controls.Add(cmbSupplier);
			this._frmMode_1.Controls.Add(cmbPackSize);
			this._frmMode_1.Controls.Add(_lblLabels_5);
			this._frmMode_1.Controls.Add(_lblLabels_8);
			this._frmMode_1.Controls.Add(_lblLabels_7);
			this._frmMode_1.Controls.Add(_lblLabels_4);
			this._frmMode_1.Controls.Add(_lblLabels_3);
			this._frmMode_1.Controls.Add(_lblLabels_0);
			this._frmMode_1.Controls.Add(_lblLabels_6);
			this.Frame1.Controls.Add(cmdShrink);
			this.Frame1.Controls.Add(txtCost);
			this.Frame1.Controls.Add(txtQuantity);
			this.Frame1.Controls.Add(cmbShrink);
			this.Frame1.Controls.Add(_lblLabels_1);
			this.Frame1.Controls.Add(_lblLabels_10);
			this.Frame1.Controls.Add(_lblLabels_2);
			this._frmMode_0.Controls.Add(txtSearch);
			this._frmMode_0.Controls.Add(cmdCustom);
			this._frmMode_0.Controls.Add(DataList1);
			this._frmMode_0.Controls.Add(lblRecords);
			this._frmMode_0.Controls.Add(_lbl_35);
			//Me.frmMode.SetIndex(_frmMode_1, CType(1, Short))
			//Me.frmMode.SetIndex(_frmMode_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_35, CType(35, Short))
			//Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
			//Me.lblLabels.SetIndex(_lblLabels_10, CType(10, Short))
			//Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
			//Me.lblLabels.SetIndex(_lblLabels_5, CType(5, Short))
			//Me.lblLabels.SetIndex(_lblLabels_8, CType(8, Short))
			//Me.lblLabels.SetIndex(_lblLabels_7, CType(7, Short))
			//Me.lblLabels.SetIndex(_lblLabels_4, CType(4, Short))
			//Me.lblLabels.SetIndex(_lblLabels_3, CType(3, Short))
			//Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
			//Me.lblLabels.SetIndex(_lblLabels_6, CType(6, Short))
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.frmMode, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this.DataList1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbPackSize).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbSupplier).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbDeposit).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbStockGroup).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbPricingGroup).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbShrink).EndInit();
			this._frmMode_1.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this._frmMode_0.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
