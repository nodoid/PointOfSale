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
	partial class frmMakeRepairItem
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmMakeRepairItem() : base()
		{
			Load += frmMakeRepairItem_Load;
			KeyPress += frmMakeRepairItem_KeyPress;
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
		private System.Windows.Forms.TextBox withEventsField_txtQtyTaken;
		public System.Windows.Forms.TextBox txtQtyTaken {
			get { return withEventsField_txtQtyTaken; }
			set {
				if (withEventsField_txtQtyTaken != null) {
					withEventsField_txtQtyTaken.Enter -= txtQtyTaken_Enter;
					withEventsField_txtQtyTaken.KeyPress -= txtQtyTaken_KeyPress;
					withEventsField_txtQtyTaken.Leave -= txtQtyTaken_Leave;
				}
				withEventsField_txtQtyTaken = value;
				if (withEventsField_txtQtyTaken != null) {
					withEventsField_txtQtyTaken.Enter += txtQtyTaken_Enter;
					withEventsField_txtQtyTaken.KeyPress += txtQtyTaken_KeyPress;
					withEventsField_txtQtyTaken.Leave += txtQtyTaken_Leave;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtQty;
		public System.Windows.Forms.TextBox txtQty {
			get { return withEventsField_txtQty; }
			set {
				if (withEventsField_txtQty != null) {
					withEventsField_txtQty.Enter -= txtQty_Enter;
					withEventsField_txtQty.KeyPress -= txtQty_KeyPress;
					withEventsField_txtQty.Leave -= txtQty_Leave;
				}
				withEventsField_txtQty = value;
				if (withEventsField_txtQty != null) {
					withEventsField_txtQty.Enter += txtQty_Enter;
					withEventsField_txtQty.KeyPress += txtQty_KeyPress;
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
		public System.Windows.Forms.Label _LBL_0;
		public System.Windows.Forms.Label lblPComp;
		public System.Windows.Forms.Label _LBL_3;
		public System.Windows.Forms.Label _LBL_2;
		public System.Windows.Forms.Label _LBL_1;
		public System.Windows.Forms.Label lblStockItem;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMakeRepairItem));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.txtQtyTaken = new System.Windows.Forms.TextBox();
			this.txtQty = new System.Windows.Forms.TextBox();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.cmbQuantity = new System.Windows.Forms.ComboBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this._LBL_0 = new System.Windows.Forms.Label();
			this.lblPComp = new System.Windows.Forms.Label();
			this._LBL_3 = new System.Windows.Forms.Label();
			this._LBL_2 = new System.Windows.Forms.Label();
			this._LBL_1 = new System.Windows.Forms.Label();
			this.lblStockItem = new System.Windows.Forms.Label();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.LBL = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.LBL, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Repair product - 4VEG";
			this.ClientSize = new System.Drawing.Size(468, 143);
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
			this.Name = "frmMakeRepairItem";
			this.txtQtyTaken.AutoSize = false;
			this.txtQtyTaken.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtQtyTaken.Size = new System.Drawing.Size(67, 19);
			this.txtQtyTaken.Location = new System.Drawing.Point(98, 103);
			this.txtQtyTaken.TabIndex = 0;
			this.txtQtyTaken.Text = "0";
			this.txtQtyTaken.AcceptsReturn = true;
			this.txtQtyTaken.BackColor = System.Drawing.SystemColors.Window;
			this.txtQtyTaken.CausesValidation = true;
			this.txtQtyTaken.Enabled = true;
			this.txtQtyTaken.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtQtyTaken.HideSelection = true;
			this.txtQtyTaken.ReadOnly = false;
			this.txtQtyTaken.MaxLength = 0;
			this.txtQtyTaken.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtQtyTaken.Multiline = false;
			this.txtQtyTaken.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtQtyTaken.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtQtyTaken.TabStop = true;
			this.txtQtyTaken.Visible = true;
			this.txtQtyTaken.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtQtyTaken.Name = "txtQtyTaken";
			this.txtQty.AutoSize = false;
			this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtQty.Size = new System.Drawing.Size(67, 19);
			this.txtQty.Location = new System.Drawing.Point(248, 103);
			this.txtQty.TabIndex = 1;
			this.txtQty.Text = "0";
			this.txtQty.AcceptsReturn = true;
			this.txtQty.BackColor = System.Drawing.SystemColors.Window;
			this.txtQty.CausesValidation = true;
			this.txtQty.Enabled = true;
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
			this.txtPrice.Location = new System.Drawing.Point(357, 103);
			this.txtPrice.TabIndex = 7;
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
			this.cmbQuantity.Location = new System.Drawing.Point(184, 176);
			this.cmbQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbQuantity.TabIndex = 6;
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
			this.picButtons.Size = new System.Drawing.Size(468, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 4;
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
			this.cmdCancel.TabIndex = 3;
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
			this.cmdClose.Location = new System.Drawing.Point(360, 3);
			this.cmdClose.TabIndex = 2;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this._LBL_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_0.Text = "Shelf Qty Taken:";
			this._LBL_0.Size = new System.Drawing.Size(80, 13);
			this._LBL_0.Location = new System.Drawing.Point(18, 106);
			this._LBL_0.TabIndex = 12;
			this._LBL_0.BackColor = System.Drawing.Color.Transparent;
			this._LBL_0.Enabled = true;
			this._LBL_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._LBL_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._LBL_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LBL_0.UseMnemonic = true;
			this._LBL_0.Visible = true;
			this._LBL_0.AutoSize = true;
			this._LBL_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._LBL_0.Name = "_LBL_0";
			this.lblPComp.Text = "Please enter the Qty you wish to make:";
			this.lblPComp.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblPComp.Size = new System.Drawing.Size(352, 20);
			this.lblPComp.Location = new System.Drawing.Point(10, 56);
			this.lblPComp.TabIndex = 11;
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
			this._LBL_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_3.Text = "Price:";
			this._LBL_3.Size = new System.Drawing.Size(35, 13);
			this._LBL_3.Location = new System.Drawing.Point(320, 106);
			this._LBL_3.TabIndex = 10;
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
			this._LBL_2.Text = "New Qty Made:";
			this._LBL_2.Size = new System.Drawing.Size(74, 13);
			this._LBL_2.Location = new System.Drawing.Point(173, 106);
			this._LBL_2.TabIndex = 9;
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
			this._LBL_1.TabIndex = 8;
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
			this.lblStockItem.Size = new System.Drawing.Size(350, 17);
			this.lblStockItem.Location = new System.Drawing.Point(98, 80);
			this.lblStockItem.TabIndex = 5;
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
			this._Shape1_2.Size = new System.Drawing.Size(452, 87);
			this._Shape1_2.Location = new System.Drawing.Point(7, 48);
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_2.BorderWidth = 1;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_2.Visible = true;
			this._Shape1_2.Name = "_Shape1_2";
			this.Controls.Add(txtQtyTaken);
			this.Controls.Add(txtQty);
			this.Controls.Add(txtPrice);
			this.Controls.Add(cmbQuantity);
			this.Controls.Add(picButtons);
			this.Controls.Add(_LBL_0);
			this.Controls.Add(lblPComp);
			this.Controls.Add(_LBL_3);
			this.Controls.Add(_LBL_2);
			this.Controls.Add(_LBL_1);
			this.Controls.Add(lblStockItem);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(cmdCancel);
			this.picButtons.Controls.Add(cmdClose);
			//Me.LBL.SetIndex(_LBL_0, CType(0, Short))
			//Me.LBL.SetIndex(_LBL_3, CType(3, Short))
			//Me.LBL.SetIndex(_LBL_2, CType(2, Short))
			//Me.LBL.SetIndex(_LBL_1, CType(1, Short))
			this.Shape1.SetIndex(_Shape1_2, Convert.ToInt16(2));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.LBL, System.ComponentModel.ISupportInitialize).EndInit()
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
