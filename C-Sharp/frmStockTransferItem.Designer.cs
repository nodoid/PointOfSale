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
	partial class frmStockTransferItem
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockTransferItem() : base()
		{
			KeyPress += frmStockTransferItem_KeyPress;
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
		private System.Windows.Forms.TextBox withEventsField_txtQtyT;
		public System.Windows.Forms.TextBox txtQtyT {
			get { return withEventsField_txtQtyT; }
			set {
				if (withEventsField_txtQtyT != null) {
					withEventsField_txtQtyT.TextChanged -= txtQtyT_TextChanged;
					withEventsField_txtQtyT.KeyPress -= txtQtyT_KeyPress;
					withEventsField_txtQtyT.Enter -= txtQtyT_Enter;
					withEventsField_txtQtyT.Leave -= txtQtyT_Leave;
				}
				withEventsField_txtQtyT = value;
				if (withEventsField_txtQtyT != null) {
					withEventsField_txtQtyT.TextChanged += txtQtyT_TextChanged;
					withEventsField_txtQtyT.KeyPress += txtQtyT_KeyPress;
					withEventsField_txtQtyT.Enter += txtQtyT_Enter;
					withEventsField_txtQtyT.Leave += txtQtyT_Leave;
				}
			}
		}
		public System.Windows.Forms.TextBox txtPSize;
		public System.Windows.Forms.TextBox txtPack;
		private System.Windows.Forms.TextBox withEventsField_txtPriceS;
		public System.Windows.Forms.TextBox txtPriceS {
			get { return withEventsField_txtPriceS; }
			set {
				if (withEventsField_txtPriceS != null) {
					withEventsField_txtPriceS.Enter -= txtPriceS_Enter;
					withEventsField_txtPriceS.Leave -= txtPriceS_Leave;
				}
				withEventsField_txtPriceS = value;
				if (withEventsField_txtPriceS != null) {
					withEventsField_txtPriceS.Enter += txtPriceS_Enter;
					withEventsField_txtPriceS.Leave += txtPriceS_Leave;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtQty;
		public System.Windows.Forms.TextBox txtQty {
			get { return withEventsField_txtQty; }
			set {
				if (withEventsField_txtQty != null) {
					withEventsField_txtQty.KeyPress -= txtQty_KeyPress;
					withEventsField_txtQty.Enter -= txtQty_Enter;
					withEventsField_txtQty.Leave -= txtQty_Leave;
				}
				withEventsField_txtQty = value;
				if (withEventsField_txtQty != null) {
					withEventsField_txtQty.KeyPress += txtQty_KeyPress;
					withEventsField_txtQty.Enter += txtQty_Enter;
					withEventsField_txtQty.Leave += txtQty_Leave;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtPrice;
		public System.Windows.Forms.TextBox txtPrice {
			get { return withEventsField_txtPrice; }
			set {
				if (withEventsField_txtPrice != null) {
					withEventsField_txtPrice.Enter -= txtPrice_Enter;
					withEventsField_txtPrice.KeyPress -= txtPrice_KeyPress;
					withEventsField_txtPrice.Leave -= txtPrice_Leave;
				}
				withEventsField_txtPrice = value;
				if (withEventsField_txtPrice != null) {
					withEventsField_txtPrice.Enter += txtPrice_Enter;
					withEventsField_txtPrice.KeyPress += txtPrice_KeyPress;
					withEventsField_txtPrice.Leave += txtPrice_Leave;
				}
			}
		}
		public System.Windows.Forms.ComboBox cmbQuantity;
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
		private System.Windows.Forms.Button withEventsField_cmdCancel;
		public System.Windows.Forms.Button cmdCancel {
			get { return withEventsField_cmdCancel; }
			set {
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click -= cmdCancel_Click;
				}
				withEventsField_cmdCancel = value;
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click += cmdCancel_Click;
				}
			}
		}
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
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.Label _LBL_6;
		public System.Windows.Forms.Label _LBL_4;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label lblPComp;
		public System.Windows.Forms.Label lblSComp;
		public System.Windows.Forms.Label lblStockItemS;
		public System.Windows.Forms.Label _LBL_5;
		public System.Windows.Forms.Label _LBL_0;
		public System.Windows.Forms.Label _LBL_3;
		public System.Windows.Forms.Label _LBL_2;
		public System.Windows.Forms.Label _LBL_1;
		public System.Windows.Forms.Label lblStockItem;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_0;
		//Public WithEvents LBL As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockTransferItem));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.txtQtyT = new System.Windows.Forms.TextBox();
			this.txtPSize = new System.Windows.Forms.TextBox();
			this.txtPack = new System.Windows.Forms.TextBox();
			this.txtPriceS = new System.Windows.Forms.TextBox();
			this.txtQty = new System.Windows.Forms.TextBox();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.cmbQuantity = new System.Windows.Forms.ComboBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdPack = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this._LBL_6 = new System.Windows.Forms.Label();
			this._LBL_4 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.lblPComp = new System.Windows.Forms.Label();
			this.lblSComp = new System.Windows.Forms.Label();
			this.lblStockItemS = new System.Windows.Forms.Label();
			this._LBL_5 = new System.Windows.Forms.Label();
			this._LBL_0 = new System.Windows.Forms.Label();
			this._LBL_3 = new System.Windows.Forms.Label();
			this._LBL_2 = new System.Windows.Forms.Label();
			this._LBL_1 = new System.Windows.Forms.Label();
			this.lblStockItem = new System.Windows.Forms.Label();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.LBL = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.LBL, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Edit Stock Transfer Item";
			this.ClientSize = new System.Drawing.Size(400, 249);
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
			this.Name = "frmStockTransferItem";
			this.txtQtyT.AutoSize = false;
			this.txtQtyT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtQtyT.Size = new System.Drawing.Size(67, 19);
			this.txtQtyT.Location = new System.Drawing.Point(96, 97);
			this.txtQtyT.TabIndex = 20;
			this.txtQtyT.Text = "0";
			this.txtQtyT.AcceptsReturn = true;
			this.txtQtyT.BackColor = System.Drawing.SystemColors.Window;
			this.txtQtyT.CausesValidation = true;
			this.txtQtyT.Enabled = true;
			this.txtQtyT.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtQtyT.HideSelection = true;
			this.txtQtyT.ReadOnly = false;
			this.txtQtyT.MaxLength = 0;
			this.txtQtyT.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtQtyT.Multiline = false;
			this.txtQtyT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtQtyT.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtQtyT.TabStop = true;
			this.txtQtyT.Visible = true;
			this.txtQtyT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtQtyT.Name = "txtQtyT";
			this.txtPSize.AutoSize = false;
			this.txtPSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtPSize.Enabled = false;
			this.txtPSize.Size = new System.Drawing.Size(27, 19);
			this.txtPSize.Location = new System.Drawing.Point(184, 97);
			this.txtPSize.TabIndex = 19;
			this.txtPSize.Text = "1";
			this.txtPSize.AcceptsReturn = true;
			this.txtPSize.BackColor = System.Drawing.SystemColors.Window;
			this.txtPSize.CausesValidation = true;
			this.txtPSize.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPSize.HideSelection = true;
			this.txtPSize.ReadOnly = false;
			this.txtPSize.MaxLength = 0;
			this.txtPSize.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPSize.Multiline = false;
			this.txtPSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPSize.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtPSize.TabStop = true;
			this.txtPSize.Visible = true;
			this.txtPSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtPSize.Name = "txtPSize";
			this.txtPack.AutoSize = false;
			this.txtPack.Size = new System.Drawing.Size(41, 19);
			this.txtPack.Location = new System.Drawing.Point(352, 160);
			this.txtPack.TabIndex = 17;
			this.txtPack.Text = "0";
			this.txtPack.AcceptsReturn = true;
			this.txtPack.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtPack.BackColor = System.Drawing.SystemColors.Window;
			this.txtPack.CausesValidation = true;
			this.txtPack.Enabled = true;
			this.txtPack.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPack.HideSelection = true;
			this.txtPack.ReadOnly = false;
			this.txtPack.MaxLength = 0;
			this.txtPack.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPack.Multiline = false;
			this.txtPack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPack.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtPack.TabStop = true;
			this.txtPack.Visible = true;
			this.txtPack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtPack.Name = "txtPack";
			this.txtPriceS.AutoSize = false;
			this.txtPriceS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPriceS.Enabled = false;
			this.txtPriceS.Size = new System.Drawing.Size(91, 19);
			this.txtPriceS.Location = new System.Drawing.Point(291, 234);
			this.txtPriceS.TabIndex = 9;
			this.txtPriceS.Text = "0.00";
			this.txtPriceS.Visible = false;
			this.txtPriceS.AcceptsReturn = true;
			this.txtPriceS.BackColor = System.Drawing.SystemColors.Window;
			this.txtPriceS.CausesValidation = true;
			this.txtPriceS.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPriceS.HideSelection = true;
			this.txtPriceS.ReadOnly = false;
			this.txtPriceS.MaxLength = 0;
			this.txtPriceS.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPriceS.Multiline = false;
			this.txtPriceS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPriceS.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtPriceS.TabStop = true;
			this.txtPriceS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtPriceS.Name = "txtPriceS";
			this.txtQty.AutoSize = false;
			this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtQty.Size = new System.Drawing.Size(67, 19);
			this.txtQty.Location = new System.Drawing.Point(316, 97);
			this.txtQty.ReadOnly = true;
			this.txtQty.TabIndex = 8;
			this.txtQty.Text = "0";
			this.txtQty.AcceptsReturn = true;
			this.txtQty.BackColor = System.Drawing.SystemColors.Window;
			this.txtQty.CausesValidation = true;
			this.txtQty.Enabled = true;
			this.txtQty.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtQty.HideSelection = true;
			this.txtQty.MaxLength = 0;
			this.txtQty.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtQty.Multiline = false;
			this.txtQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtQty.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtQty.TabStop = true;
			this.txtQty.Visible = true;
			this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtQty.Name = "txtQty";
			this.txtPrice.AutoSize = false;
			this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPrice.Enabled = false;
			this.txtPrice.Size = new System.Drawing.Size(91, 19);
			this.txtPrice.Location = new System.Drawing.Point(293, 121);
			this.txtPrice.TabIndex = 4;
			this.txtPrice.Text = "0.00";
			this.txtPrice.AcceptsReturn = true;
			this.txtPrice.BackColor = System.Drawing.SystemColors.Window;
			this.txtPrice.CausesValidation = true;
			this.txtPrice.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPrice.HideSelection = true;
			this.txtPrice.ReadOnly = false;
			this.txtPrice.MaxLength = 0;
			this.txtPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPrice.Multiline = false;
			this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtPrice.TabStop = true;
			this.txtPrice.Visible = true;
			this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtPrice.Name = "txtPrice";
			this.cmbQuantity.Size = new System.Drawing.Size(79, 21);
			this.cmbQuantity.Location = new System.Drawing.Point(184, 96);
			this.cmbQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbQuantity.TabIndex = 3;
			this.cmbQuantity.Visible = false;
			this.cmbQuantity.BackColor = System.Drawing.SystemColors.Window;
			this.cmbQuantity.CausesValidation = true;
			this.cmbQuantity.Enabled = true;
			this.cmbQuantity.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbQuantity.IntegralHeight = true;
			this.cmbQuantity.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbQuantity.Sorted = false;
			this.cmbQuantity.TabStop = true;
			this.cmbQuantity.Name = "cmbQuantity";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(400, 39);
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
			this.cmdPack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPack.Text = "Break / Build P&ack";
			this.cmdPack.Size = new System.Drawing.Size(105, 29);
			this.cmdPack.Location = new System.Drawing.Point(88, 3);
			this.cmdPack.TabIndex = 18;
			this.cmdPack.TabStop = false;
			this.cmdPack.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPack.CausesValidation = true;
			this.cmdPack.Enabled = true;
			this.cmdPack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPack.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPack.Name = "cmdPack";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.Location = new System.Drawing.Point(8, 3);
			this.cmdCancel.TabIndex = 16;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.Location = new System.Drawing.Point(312, 3);
			this.cmdClose.TabIndex = 1;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this._LBL_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_6.Text = "Item Qty:";
			this._LBL_6.Size = new System.Drawing.Size(42, 13);
			this._LBL_6.Location = new System.Drawing.Point(52, 99);
			this._LBL_6.TabIndex = 22;
			this._LBL_6.BackColor = System.Drawing.Color.Transparent;
			this._LBL_6.Enabled = true;
			this._LBL_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._LBL_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._LBL_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LBL_6.UseMnemonic = true;
			this._LBL_6.Visible = true;
			this._LBL_6.AutoSize = true;
			this._LBL_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._LBL_6.Name = "_LBL_6";
			this._LBL_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_4.Text = "x";
			this._LBL_4.Size = new System.Drawing.Size(8, 16);
			this._LBL_4.Location = new System.Drawing.Point(170, 98);
			this._LBL_4.TabIndex = 21;
			this._LBL_4.BackColor = System.Drawing.Color.Transparent;
			this._LBL_4.Enabled = true;
			this._LBL_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._LBL_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._LBL_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LBL_4.UseMnemonic = true;
			this._LBL_4.Visible = true;
			this._LBL_4.AutoSize = true;
			this._LBL_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._LBL_4.Name = "_LBL_4";
			this.Label2.Text = "Please verify products from both locations";
			this.Label2.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label2.Size = new System.Drawing.Size(296, 23);
			this.Label2.Location = new System.Drawing.Point(56, 160);
			this.Label2.TabIndex = 15;
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Enabled = true;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.lblPComp.Text = "Promotion Name:";
			this.lblPComp.Size = new System.Drawing.Size(352, 24);
			this.lblPComp.Location = new System.Drawing.Point(16, 52);
			this.lblPComp.TabIndex = 14;
			this.lblPComp.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblPComp.BackColor = System.Drawing.Color.Transparent;
			this.lblPComp.Enabled = true;
			this.lblPComp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblPComp.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblPComp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblPComp.UseMnemonic = true;
			this.lblPComp.Visible = true;
			this.lblPComp.AutoSize = false;
			this.lblPComp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblPComp.Name = "lblPComp";
			this.lblSComp.Text = "Promotion Name:";
			this.lblSComp.Size = new System.Drawing.Size(360, 24);
			this.lblSComp.Location = new System.Drawing.Point(16, 192);
			this.lblSComp.TabIndex = 13;
			this.lblSComp.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblSComp.BackColor = System.Drawing.Color.Transparent;
			this.lblSComp.Enabled = true;
			this.lblSComp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblSComp.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblSComp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblSComp.UseMnemonic = true;
			this.lblSComp.Visible = true;
			this.lblSComp.AutoSize = false;
			this.lblSComp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblSComp.Name = "lblSComp";
			this.lblStockItemS.Text = "Label1";
			this.lblStockItemS.Size = new System.Drawing.Size(286, 17);
			this.lblStockItemS.Location = new System.Drawing.Point(98, 216);
			this.lblStockItemS.TabIndex = 12;
			this.lblStockItemS.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblStockItemS.BackColor = System.Drawing.SystemColors.Control;
			this.lblStockItemS.Enabled = true;
			this.lblStockItemS.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblStockItemS.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblStockItemS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblStockItemS.UseMnemonic = true;
			this.lblStockItemS.Visible = true;
			this.lblStockItemS.AutoSize = false;
			this.lblStockItemS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblStockItemS.Name = "lblStockItemS";
			this._LBL_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_5.Text = "Stock Item Name:";
			this._LBL_5.Size = new System.Drawing.Size(85, 13);
			this._LBL_5.Location = new System.Drawing.Point(10, 184);
			this._LBL_5.TabIndex = 11;
			this._LBL_5.BackColor = System.Drawing.Color.Transparent;
			this._LBL_5.Enabled = true;
			this._LBL_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._LBL_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._LBL_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LBL_5.UseMnemonic = true;
			this._LBL_5.Visible = true;
			this._LBL_5.AutoSize = true;
			this._LBL_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._LBL_5.Name = "_LBL_5";
			this._LBL_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_0.Text = "Price:";
			this._LBL_0.Size = new System.Drawing.Size(27, 13);
			this._LBL_0.Location = new System.Drawing.Point(260, 237);
			this._LBL_0.TabIndex = 10;
			this._LBL_0.Visible = false;
			this._LBL_0.BackColor = System.Drawing.Color.Transparent;
			this._LBL_0.Enabled = true;
			this._LBL_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._LBL_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._LBL_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LBL_0.UseMnemonic = true;
			this._LBL_0.AutoSize = true;
			this._LBL_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._LBL_0.Name = "_LBL_0";
			this._LBL_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_3.Text = "Cost Price (singles) :";
			this._LBL_3.Size = new System.Drawing.Size(95, 13);
			this._LBL_3.Location = new System.Drawing.Point(194, 124);
			this._LBL_3.TabIndex = 7;
			this._LBL_3.BackColor = System.Drawing.Color.Transparent;
			this._LBL_3.Enabled = true;
			this._LBL_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._LBL_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._LBL_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LBL_3.UseMnemonic = true;
			this._LBL_3.Visible = true;
			this._LBL_3.AutoSize = true;
			this._LBL_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._LBL_3.Name = "_LBL_3";
			this._LBL_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_2.Text = "Total Qty:";
			this._LBL_2.Size = new System.Drawing.Size(46, 13);
			this._LBL_2.Location = new System.Drawing.Point(268, 99);
			this._LBL_2.TabIndex = 6;
			this._LBL_2.BackColor = System.Drawing.Color.Transparent;
			this._LBL_2.Enabled = true;
			this._LBL_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._LBL_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._LBL_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LBL_2.UseMnemonic = true;
			this._LBL_2.Visible = true;
			this._LBL_2.AutoSize = true;
			this._LBL_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._LBL_2.Name = "_LBL_2";
			this._LBL_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_1.Text = "Stock Item Name:";
			this._LBL_1.Size = new System.Drawing.Size(85, 13);
			this._LBL_1.Location = new System.Drawing.Point(10, 79);
			this._LBL_1.TabIndex = 5;
			this._LBL_1.BackColor = System.Drawing.Color.Transparent;
			this._LBL_1.Enabled = true;
			this._LBL_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._LBL_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._LBL_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LBL_1.UseMnemonic = true;
			this._LBL_1.Visible = true;
			this._LBL_1.AutoSize = true;
			this._LBL_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._LBL_1.Name = "_LBL_1";
			this.lblStockItem.Text = "Label1";
			this.lblStockItem.Size = new System.Drawing.Size(286, 17);
			this.lblStockItem.Location = new System.Drawing.Point(98, 79);
			this.lblStockItem.TabIndex = 2;
			this.lblStockItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblStockItem.BackColor = System.Drawing.SystemColors.Control;
			this.lblStockItem.Enabled = true;
			this.lblStockItem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblStockItem.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblStockItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblStockItem.UseMnemonic = true;
			this.lblStockItem.Visible = true;
			this.lblStockItem.AutoSize = false;
			this.lblStockItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblStockItem.Name = "lblStockItem";
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(383, 104);
			this._Shape1_2.Location = new System.Drawing.Point(7, 48);
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_2.BorderWidth = 1;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_2.Visible = true;
			this._Shape1_2.Name = "_Shape1_2";
			this._Shape1_0.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_0.Size = new System.Drawing.Size(383, 56);
			this._Shape1_0.Location = new System.Drawing.Point(7, 184);
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_0.BorderWidth = 1;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_0.Visible = true;
			this._Shape1_0.Name = "_Shape1_0";
			this.Controls.Add(txtQtyT);
			this.Controls.Add(txtPSize);
			this.Controls.Add(txtPack);
			this.Controls.Add(txtPriceS);
			this.Controls.Add(txtQty);
			this.Controls.Add(txtPrice);
			this.Controls.Add(cmbQuantity);
			this.Controls.Add(picButtons);
			this.Controls.Add(_LBL_6);
			this.Controls.Add(_LBL_4);
			this.Controls.Add(Label2);
			this.Controls.Add(lblPComp);
			this.Controls.Add(lblSComp);
			this.Controls.Add(lblStockItemS);
			this.Controls.Add(_LBL_5);
			this.Controls.Add(_LBL_0);
			this.Controls.Add(_LBL_3);
			this.Controls.Add(_LBL_2);
			this.Controls.Add(_LBL_1);
			this.Controls.Add(lblStockItem);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.ShapeContainer1.Shapes.Add(_Shape1_0);
			this.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(cmdPack);
			this.picButtons.Controls.Add(cmdCancel);
			this.picButtons.Controls.Add(cmdClose);
			//Me.LBL.SetIndex(_LBL_6, CType(6, Short))
			//Me.LBL.SetIndex(_LBL_4, CType(4, Short))
			//Me.LBL.SetIndex(_LBL_5, CType(5, Short))
			//Me.LBL.SetIndex(_LBL_0, CType(0, Short))
			//Me.LBL.SetIndex(_LBL_3, CType(3, Short))
			//Me.LBL.SetIndex(_LBL_2, CType(2, Short))
			//Me.LBL.SetIndex(_LBL_1, CType(1, Short))
			this.Shape1.SetIndex(_Shape1_2, Convert.ToInt16(2));
			this.Shape1.SetIndex(_Shape1_0, Convert.ToInt16(0));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.LBL, System.ComponentModel.ISupportInitialize).EndInit()
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
