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
	partial class frmVegTestStockBack
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmVegTestStockBack() : base()
		{
			KeyPress += frmVegTestStockBack_KeyPress;
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
		public System.Windows.Forms.TextBox txtQtyB;
		public System.Windows.Forms.TextBox txtPriceB;
		private System.Windows.Forms.Button withEventsField_cmdSelectChild;
		public System.Windows.Forms.Button cmdSelectChild {
			get { return withEventsField_cmdSelectChild; }
			set {
				if (withEventsField_cmdSelectChild != null) {
					withEventsField_cmdSelectChild.Click -= cmdSelectChild_Click;
				}
				withEventsField_cmdSelectChild = value;
				if (withEventsField_cmdSelectChild != null) {
					withEventsField_cmdSelectChild.Click += cmdSelectChild_Click;
				}
			}
		}
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
		public System.Windows.Forms.Label lblStockItemB;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmVegTestStockBack));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.txtQtyB = new System.Windows.Forms.TextBox();
			this.txtPriceB = new System.Windows.Forms.TextBox();
			this.cmdSelectChild = new System.Windows.Forms.Button();
			this.txtPack = new System.Windows.Forms.TextBox();
			this.txtPriceS = new System.Windows.Forms.TextBox();
			this.txtQty = new System.Windows.Forms.TextBox();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this._LBL_6 = new System.Windows.Forms.Label();
			this._LBL_4 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.lblPComp = new System.Windows.Forms.Label();
			this.lblSComp = new System.Windows.Forms.Label();
			this.lblStockItemB = new System.Windows.Forms.Label();
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
			this.Text = "Stock Receiving";
			this.ClientSize = new System.Drawing.Size(397, 287);
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
			this.Name = "frmVegTestStockBack";
			this.txtQtyB.AutoSize = false;
			this.txtQtyB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtQtyB.Enabled = false;
			this.txtQtyB.Size = new System.Drawing.Size(91, 19);
			this.txtQtyB.Location = new System.Drawing.Point(293, 227);
			this.txtQtyB.TabIndex = 19;
			this.txtQtyB.Text = "0.00";
			this.txtQtyB.AcceptsReturn = true;
			this.txtQtyB.BackColor = System.Drawing.SystemColors.Window;
			this.txtQtyB.CausesValidation = true;
			this.txtQtyB.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtQtyB.HideSelection = true;
			this.txtQtyB.ReadOnly = false;
			this.txtQtyB.MaxLength = 0;
			this.txtQtyB.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtQtyB.Multiline = false;
			this.txtQtyB.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtQtyB.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtQtyB.TabStop = true;
			this.txtQtyB.Visible = true;
			this.txtQtyB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtQtyB.Name = "txtQtyB";
			this.txtPriceB.AutoSize = false;
			this.txtPriceB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPriceB.Enabled = false;
			this.txtPriceB.Size = new System.Drawing.Size(91, 19);
			this.txtPriceB.Location = new System.Drawing.Point(293, 251);
			this.txtPriceB.TabIndex = 18;
			this.txtPriceB.Text = "0";
			this.txtPriceB.AcceptsReturn = true;
			this.txtPriceB.BackColor = System.Drawing.SystemColors.Window;
			this.txtPriceB.CausesValidation = true;
			this.txtPriceB.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPriceB.HideSelection = true;
			this.txtPriceB.ReadOnly = false;
			this.txtPriceB.MaxLength = 0;
			this.txtPriceB.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPriceB.Multiline = false;
			this.txtPriceB.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPriceB.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtPriceB.TabStop = true;
			this.txtPriceB.Visible = true;
			this.txtPriceB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtPriceB.Name = "txtPriceB";
			this.cmdSelectChild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSelectChild.Text = "Select Item you wish above QTY to add on";
			this.cmdSelectChild.Size = new System.Drawing.Size(217, 29);
			this.cmdSelectChild.Location = new System.Drawing.Point(173, 136);
			this.cmdSelectChild.TabIndex = 17;
			this.cmdSelectChild.TabStop = false;
			this.cmdSelectChild.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSelectChild.CausesValidation = true;
			this.cmdSelectChild.Enabled = true;
			this.cmdSelectChild.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSelectChild.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSelectChild.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSelectChild.Name = "cmdSelectChild";
			this.txtPack.AutoSize = false;
			this.txtPack.Size = new System.Drawing.Size(41, 19);
			this.txtPack.Location = new System.Drawing.Point(336, 320);
			this.txtPack.TabIndex = 16;
			this.txtPack.Text = "0";
			this.txtPack.Visible = false;
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
			this.txtPack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtPack.Name = "txtPack";
			this.txtPriceS.AutoSize = false;
			this.txtPriceS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPriceS.Enabled = false;
			this.txtPriceS.Size = new System.Drawing.Size(91, 19);
			this.txtPriceS.Location = new System.Drawing.Point(291, 354);
			this.txtPriceS.TabIndex = 8;
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
			this.txtQty.Enabled = false;
			this.txtQty.Size = new System.Drawing.Size(67, 19);
			this.txtQty.Location = new System.Drawing.Point(96, 97);
			this.txtQty.TabIndex = 7;
			this.txtQty.Text = "0";
			this.txtQty.AcceptsReturn = true;
			this.txtQty.BackColor = System.Drawing.SystemColors.Window;
			this.txtQty.CausesValidation = true;
			this.txtQty.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtQty.HideSelection = true;
			this.txtQty.ReadOnly = false;
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
			this.txtPrice.Location = new System.Drawing.Point(293, 97);
			this.txtPrice.TabIndex = 3;
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
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(397, 39);
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
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.Location = new System.Drawing.Point(8, 3);
			this.cmdCancel.TabIndex = 15;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "Process && E&xit";
			this.cmdClose.Size = new System.Drawing.Size(97, 29);
			this.cmdClose.Location = new System.Drawing.Point(288, 3);
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
			this._LBL_6.Text = "Total Receiving QTY in KG:";
			this._LBL_6.Size = new System.Drawing.Size(132, 13);
			this._LBL_6.Location = new System.Drawing.Point(157, 254);
			this._LBL_6.TabIndex = 21;
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
			this._LBL_4.Text = "Total Receiving QTY:";
			this._LBL_4.Size = new System.Drawing.Size(103, 13);
			this._LBL_4.Location = new System.Drawing.Point(186, 230);
			this._LBL_4.TabIndex = 20;
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
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label2.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label2.Size = new System.Drawing.Size(296, 23);
			this.Label2.Location = new System.Drawing.Point(40, 320);
			this.Label2.TabIndex = 14;
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
			this.lblPComp.Text = "From";
			this.lblPComp.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblPComp.Size = new System.Drawing.Size(352, 24);
			this.lblPComp.Location = new System.Drawing.Point(16, 52);
			this.lblPComp.TabIndex = 13;
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
			this.lblSComp.Text = "To";
			this.lblSComp.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblSComp.Size = new System.Drawing.Size(360, 24);
			this.lblSComp.Location = new System.Drawing.Point(16, 184);
			this.lblSComp.TabIndex = 12;
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
			this.lblStockItemB.Text = " <Receiving Stock Item>";
			this.lblStockItemB.Size = new System.Drawing.Size(286, 17);
			this.lblStockItemB.Location = new System.Drawing.Point(98, 208);
			this.lblStockItemB.TabIndex = 11;
			this.lblStockItemB.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblStockItemB.BackColor = System.Drawing.SystemColors.Control;
			this.lblStockItemB.Enabled = true;
			this.lblStockItemB.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblStockItemB.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblStockItemB.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblStockItemB.UseMnemonic = true;
			this.lblStockItemB.Visible = true;
			this.lblStockItemB.AutoSize = false;
			this.lblStockItemB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblStockItemB.Name = "lblStockItemB";
			this._LBL_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_5.Text = "Stock Item Name:";
			this._LBL_5.Size = new System.Drawing.Size(85, 13);
			this._LBL_5.Location = new System.Drawing.Point(10, 208);
			this._LBL_5.TabIndex = 10;
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
			this._LBL_0.Location = new System.Drawing.Point(260, 357);
			this._LBL_0.TabIndex = 9;
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
			this._LBL_3.Text = "Available QTY in KG:";
			this._LBL_3.Size = new System.Drawing.Size(100, 13);
			this._LBL_3.Location = new System.Drawing.Point(189, 100);
			this._LBL_3.TabIndex = 6;
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
			this._LBL_2.Text = "Available QTY:";
			this._LBL_2.Size = new System.Drawing.Size(71, 13);
			this._LBL_2.Location = new System.Drawing.Point(24, 100);
			this._LBL_2.TabIndex = 5;
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
			this._LBL_1.TabIndex = 4;
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
			this._Shape1_2.Size = new System.Drawing.Size(383, 80);
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
			this._Shape1_0.Size = new System.Drawing.Size(383, 104);
			this._Shape1_0.Location = new System.Drawing.Point(7, 176);
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_0.BorderWidth = 1;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_0.Visible = true;
			this._Shape1_0.Name = "_Shape1_0";
			this.Controls.Add(txtQtyB);
			this.Controls.Add(txtPriceB);
			this.Controls.Add(cmdSelectChild);
			this.Controls.Add(txtPack);
			this.Controls.Add(txtPriceS);
			this.Controls.Add(txtQty);
			this.Controls.Add(txtPrice);
			this.Controls.Add(picButtons);
			this.Controls.Add(_LBL_6);
			this.Controls.Add(_LBL_4);
			this.Controls.Add(Label2);
			this.Controls.Add(lblPComp);
			this.Controls.Add(lblSComp);
			this.Controls.Add(lblStockItemB);
			this.Controls.Add(_LBL_5);
			this.Controls.Add(_LBL_0);
			this.Controls.Add(_LBL_3);
			this.Controls.Add(_LBL_2);
			this.Controls.Add(_LBL_1);
			this.Controls.Add(lblStockItem);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.ShapeContainer1.Shapes.Add(_Shape1_0);
			this.Controls.Add(ShapeContainer1);
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
