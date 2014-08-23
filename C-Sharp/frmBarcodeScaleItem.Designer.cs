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
	partial class frmBarcodeScaleItem
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmBarcodeScaleItem() : base()
		{
			KeyPress += frmBarcodeScaleItem_KeyPress;
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
		private System.Windows.Forms.TextBox withEventsField_txtQtyT;
		public System.Windows.Forms.TextBox txtQtyT {
			get { return withEventsField_txtQtyT; }
			set {
				if (withEventsField_txtQtyT != null) {
					withEventsField_txtQtyT.KeyPress -= txtQtyT_KeyPress;
					withEventsField_txtQtyT.Enter -= txtQtyT_Enter;
					withEventsField_txtQtyT.Leave -= txtQtyT_Leave;
				}
				withEventsField_txtQtyT = value;
				if (withEventsField_txtQtyT != null) {
					withEventsField_txtQtyT.KeyPress += txtQtyT_KeyPress;
					withEventsField_txtQtyT.Enter += txtQtyT_Enter;
					withEventsField_txtQtyT.Leave += txtQtyT_Leave;
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
		public System.Windows.Forms.Label _LBL_2;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label lblPComp;
		public System.Windows.Forms.Label lblSComp;
		public System.Windows.Forms.Label lblStockItemS;
		public System.Windows.Forms.Label _LBL_5;
		public System.Windows.Forms.Label _LBL_0;
		public System.Windows.Forms.Label _LBL_3;
		public System.Windows.Forms.Label _LBL_1;
		public System.Windows.Forms.Label lblStockItem;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		//Public WithEvents LBL As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.txtQty = new System.Windows.Forms.TextBox();
			this.txtPSize = new System.Windows.Forms.TextBox();
			this.txtPack = new System.Windows.Forms.TextBox();
			this.txtPriceS = new System.Windows.Forms.TextBox();
			this.txtQtyT = new System.Windows.Forms.TextBox();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.cmbQuantity = new System.Windows.Forms.ComboBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdPack = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this._LBL_6 = new System.Windows.Forms.Label();
			this._LBL_4 = new System.Windows.Forms.Label();
			this._LBL_2 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.lblPComp = new System.Windows.Forms.Label();
			this.lblSComp = new System.Windows.Forms.Label();
			this.lblStockItemS = new System.Windows.Forms.Label();
			this._LBL_5 = new System.Windows.Forms.Label();
			this._LBL_0 = new System.Windows.Forms.Label();
			this._LBL_3 = new System.Windows.Forms.Label();
			this._LBL_1 = new System.Windows.Forms.Label();
			this.lblStockItem = new System.Windows.Forms.Label();
			this.Shape1 = new _4PosBackOffice.NET.RectangleShapeArray(this.components);
			this.picButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.SuspendLayout();
			//
			//ShapeContainer1
			//
			this.ShapeContainer1.Location = new System.Drawing.Point(0, 0);
			this.ShapeContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.ShapeContainer1.Name = "ShapeContainer1";
			this.ShapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
				this._Shape1_0,
				this._Shape1_2
			});
			this.ShapeContainer1.Size = new System.Drawing.Size(400, 145);
			this.ShapeContainer1.TabIndex = 22;
			this.ShapeContainer1.TabStop = false;
			//
			//_Shape1_0
			//
			this._Shape1_0.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this.Shape1.SetIndex(this._Shape1_0, Convert.ToInt16(0));
			this._Shape1_0.Location = new System.Drawing.Point(7, 296);
			this._Shape1_0.Name = "_Shape1_0";
			this._Shape1_0.Size = new System.Drawing.Size(383, 56);
			//
			//_Shape1_2
			//
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this.Shape1.SetIndex(this._Shape1_2, Convert.ToInt16(2));
			this._Shape1_2.Location = new System.Drawing.Point(7, 48);
			this._Shape1_2.Name = "_Shape1_2";
			this._Shape1_2.Size = new System.Drawing.Size(383, 88);
			//
			//txtQty
			//
			this.txtQty.AcceptsReturn = true;
			this.txtQty.BackColor = System.Drawing.SystemColors.Window;
			this.txtQty.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtQty.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtQty.Location = new System.Drawing.Point(314, 102);
			this.txtQty.MaxLength = 0;
			this.txtQty.Name = "txtQty";
			this.txtQty.ReadOnly = true;
			this.txtQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtQty.Size = new System.Drawing.Size(67, 19);
			this.txtQty.TabIndex = 20;
			this.txtQty.Text = "0";
			this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtQty.Visible = false;
			//
			//txtPSize
			//
			this.txtPSize.AcceptsReturn = true;
			this.txtPSize.BackColor = System.Drawing.SystemColors.Window;
			this.txtPSize.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPSize.Enabled = false;
			this.txtPSize.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPSize.Location = new System.Drawing.Point(184, 101);
			this.txtPSize.MaxLength = 0;
			this.txtPSize.Name = "txtPSize";
			this.txtPSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPSize.Size = new System.Drawing.Size(27, 19);
			this.txtPSize.TabIndex = 19;
			this.txtPSize.Text = "1";
			this.txtPSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtPSize.Visible = false;
			//
			//txtPack
			//
			this.txtPack.AcceptsReturn = true;
			this.txtPack.BackColor = System.Drawing.SystemColors.Window;
			this.txtPack.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPack.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPack.Location = new System.Drawing.Point(352, 272);
			this.txtPack.MaxLength = 0;
			this.txtPack.Name = "txtPack";
			this.txtPack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPack.Size = new System.Drawing.Size(41, 19);
			this.txtPack.TabIndex = 16;
			this.txtPack.Text = "0";
			this.txtPack.Visible = false;
			//
			//txtPriceS
			//
			this.txtPriceS.AcceptsReturn = true;
			this.txtPriceS.BackColor = System.Drawing.SystemColors.Window;
			this.txtPriceS.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPriceS.Enabled = false;
			this.txtPriceS.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPriceS.Location = new System.Drawing.Point(291, 346);
			this.txtPriceS.MaxLength = 0;
			this.txtPriceS.Name = "txtPriceS";
			this.txtPriceS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPriceS.Size = new System.Drawing.Size(91, 19);
			this.txtPriceS.TabIndex = 8;
			this.txtPriceS.Text = "0.00";
			this.txtPriceS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPriceS.Visible = false;
			//
			//txtQtyT
			//
			this.txtQtyT.AcceptsReturn = true;
			this.txtQtyT.BackColor = System.Drawing.SystemColors.Window;
			this.txtQtyT.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtQtyT.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtQtyT.Location = new System.Drawing.Point(79, 101);
			this.txtQtyT.MaxLength = 0;
			this.txtQtyT.Name = "txtQtyT";
			this.txtQtyT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtQtyT.Size = new System.Drawing.Size(75, 19);
			this.txtQtyT.TabIndex = 0;
			this.txtQtyT.Text = "0";
			this.txtQtyT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//txtPrice
			//
			this.txtPrice.AcceptsReturn = true;
			this.txtPrice.BackColor = System.Drawing.SystemColors.Window;
			this.txtPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPrice.Enabled = false;
			this.txtPrice.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPrice.Location = new System.Drawing.Point(301, 249);
			this.txtPrice.MaxLength = 0;
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPrice.Size = new System.Drawing.Size(91, 19);
			this.txtPrice.TabIndex = 5;
			this.txtPrice.Text = "0.00";
			this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPrice.Visible = false;
			//
			//cmbQuantity
			//
			this.cmbQuantity.BackColor = System.Drawing.SystemColors.Window;
			this.cmbQuantity.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbQuantity.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbQuantity.Location = new System.Drawing.Point(192, 248);
			this.cmbQuantity.Name = "cmbQuantity";
			this.cmbQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbQuantity.Size = new System.Drawing.Size(79, 21);
			this.cmbQuantity.TabIndex = 4;
			this.cmbQuantity.Visible = false;
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.cmdPack);
			this.picButtons.Controls.Add(this.cmdCancel);
			this.picButtons.Controls.Add(this.cmdClose);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(400, 39);
			this.picButtons.TabIndex = 1;
			//
			//cmdPack
			//
			this.cmdPack.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPack.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPack.Location = new System.Drawing.Point(88, 3);
			this.cmdPack.Name = "cmdPack";
			this.cmdPack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPack.Size = new System.Drawing.Size(105, 29);
			this.cmdPack.TabIndex = 22;
			this.cmdPack.TabStop = false;
			this.cmdPack.Text = "Break / Build P&ack";
			this.cmdPack.UseVisualStyleBackColor = false;
			this.cmdPack.Visible = false;
			//
			//cmdCancel
			//
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Location = new System.Drawing.Point(8, 3);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.TabIndex = 15;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.UseVisualStyleBackColor = false;
			//
			//cmdClose
			//
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Location = new System.Drawing.Point(312, 3);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.TabIndex = 2;
			this.cmdClose.TabStop = false;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.UseVisualStyleBackColor = false;
			//
			//_LBL_6
			//
			this._LBL_6.AutoSize = true;
			this._LBL_6.BackColor = System.Drawing.Color.Transparent;
			this._LBL_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._LBL_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._LBL_6.Location = new System.Drawing.Point(257, 105);
			this._LBL_6.Name = "_LBL_6";
			this._LBL_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LBL_6.Size = new System.Drawing.Size(53, 13);
			this._LBL_6.TabIndex = 21;
			this._LBL_6.Text = "Total Qty:";
			this._LBL_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_6.Visible = false;
			//
			//_LBL_4
			//
			this._LBL_4.AutoSize = true;
			this._LBL_4.BackColor = System.Drawing.Color.Transparent;
			this._LBL_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._LBL_4.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._LBL_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._LBL_4.Location = new System.Drawing.Point(162, 102);
			this._LBL_4.Name = "_LBL_4";
			this._LBL_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LBL_4.Size = new System.Drawing.Size(16, 16);
			this._LBL_4.TabIndex = 18;
			this._LBL_4.Text = "x";
			this._LBL_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_4.Visible = false;
			//
			//_LBL_2
			//
			this._LBL_2.AutoSize = true;
			this._LBL_2.BackColor = System.Drawing.Color.Transparent;
			this._LBL_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._LBL_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._LBL_2.Location = new System.Drawing.Point(24, 104);
			this._LBL_2.Name = "_LBL_2";
			this._LBL_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LBL_2.Size = new System.Drawing.Size(49, 13);
			this._LBL_2.TabIndex = 17;
			this._LBL_2.Text = "Item Qty:";
			this._LBL_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label2
			//
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label2.ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(0)), Convert.ToInt32(Convert.ToByte(0)));
			this.Label2.Location = new System.Drawing.Point(56, 272);
			this.Label2.Name = "Label2";
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.Size = new System.Drawing.Size(296, 23);
			this.Label2.TabIndex = 14;
			this.Label2.Text = "Please verify products from both locations";
			//
			//lblPComp
			//
			this.lblPComp.BackColor = System.Drawing.Color.Transparent;
			this.lblPComp.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblPComp.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblPComp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblPComp.Location = new System.Drawing.Point(16, 152);
			this.lblPComp.Name = "lblPComp";
			this.lblPComp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblPComp.Size = new System.Drawing.Size(352, 24);
			this.lblPComp.TabIndex = 13;
			this.lblPComp.Text = "Promotion Name:";
			this.lblPComp.Visible = false;
			//
			//lblSComp
			//
			this.lblSComp.BackColor = System.Drawing.Color.Transparent;
			this.lblSComp.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblSComp.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblSComp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblSComp.Location = new System.Drawing.Point(16, 304);
			this.lblSComp.Name = "lblSComp";
			this.lblSComp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblSComp.Size = new System.Drawing.Size(360, 24);
			this.lblSComp.TabIndex = 12;
			this.lblSComp.Text = "Promotion Name:";
			//
			//lblStockItemS
			//
			this.lblStockItemS.BackColor = System.Drawing.SystemColors.Control;
			this.lblStockItemS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblStockItemS.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblStockItemS.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblStockItemS.Location = new System.Drawing.Point(98, 328);
			this.lblStockItemS.Name = "lblStockItemS";
			this.lblStockItemS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblStockItemS.Size = new System.Drawing.Size(286, 17);
			this.lblStockItemS.TabIndex = 11;
			this.lblStockItemS.Text = "Label1";
			//
			//_LBL_5
			//
			this._LBL_5.AutoSize = true;
			this._LBL_5.BackColor = System.Drawing.Color.Transparent;
			this._LBL_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._LBL_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._LBL_5.Location = new System.Drawing.Point(10, 328);
			this._LBL_5.Name = "_LBL_5";
			this._LBL_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LBL_5.Size = new System.Drawing.Size(92, 13);
			this._LBL_5.TabIndex = 10;
			this._LBL_5.Text = "Stock Item Name:";
			this._LBL_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_LBL_0
			//
			this._LBL_0.AutoSize = true;
			this._LBL_0.BackColor = System.Drawing.Color.Transparent;
			this._LBL_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._LBL_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._LBL_0.Location = new System.Drawing.Point(260, 349);
			this._LBL_0.Name = "_LBL_0";
			this._LBL_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LBL_0.Size = new System.Drawing.Size(34, 13);
			this._LBL_0.TabIndex = 9;
			this._LBL_0.Text = "Price:";
			this._LBL_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_0.Visible = false;
			//
			//_LBL_3
			//
			this._LBL_3.AutoSize = true;
			this._LBL_3.BackColor = System.Drawing.Color.Transparent;
			this._LBL_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._LBL_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._LBL_3.Location = new System.Drawing.Point(270, 252);
			this._LBL_3.Name = "_LBL_3";
			this._LBL_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LBL_3.Size = new System.Drawing.Size(34, 13);
			this._LBL_3.TabIndex = 7;
			this._LBL_3.Text = "Price:";
			this._LBL_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_3.Visible = false;
			//
			//_LBL_1
			//
			this._LBL_1.AutoSize = true;
			this._LBL_1.BackColor = System.Drawing.Color.Transparent;
			this._LBL_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._LBL_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._LBL_1.Location = new System.Drawing.Point(24, 56);
			this._LBL_1.Name = "_LBL_1";
			this._LBL_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LBL_1.Size = new System.Drawing.Size(92, 13);
			this._LBL_1.TabIndex = 6;
			this._LBL_1.Text = "Stock Item Name:";
			this._LBL_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblStockItem
			//
			this.lblStockItem.BackColor = System.Drawing.SystemColors.Control;
			this.lblStockItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblStockItem.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblStockItem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblStockItem.Location = new System.Drawing.Point(24, 72);
			this.lblStockItem.Name = "lblStockItem";
			this.lblStockItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblStockItem.Size = new System.Drawing.Size(358, 25);
			this.lblStockItem.TabIndex = 3;
			this.lblStockItem.Text = "Label1";
			//
			//frmBarcodeScaleItem
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.ClientSize = new System.Drawing.Size(400, 145);
			this.ControlBox = false;
			this.Controls.Add(this.txtQty);
			this.Controls.Add(this.txtPSize);
			this.Controls.Add(this.txtPack);
			this.Controls.Add(this.txtPriceS);
			this.Controls.Add(this.txtQtyT);
			this.Controls.Add(this.txtPrice);
			this.Controls.Add(this.cmbQuantity);
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this._LBL_6);
			this.Controls.Add(this._LBL_4);
			this.Controls.Add(this._LBL_2);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.lblPComp);
			this.Controls.Add(this.lblSComp);
			this.Controls.Add(this.lblStockItemS);
			this.Controls.Add(this._LBL_5);
			this.Controls.Add(this._LBL_0);
			this.Controls.Add(this._LBL_3);
			this.Controls.Add(this._LBL_1);
			this.Controls.Add(this.lblStockItem);
			this.Controls.Add(this.ShapeContainer1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(3, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmBarcodeScaleItem";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Scale Item - Barcode printing";
			this.picButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
