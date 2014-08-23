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
	partial class frmCustomerAllocPaymentAmount
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmCustomerAllocPaymentAmount() : base()
		{
			KeyPress += frmCustomerAllocPaymentAmount_KeyPress;
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
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label lblPComp;
		public System.Windows.Forms.Label lblSComp;
		public System.Windows.Forms.Label lblStockItemS;
		public System.Windows.Forms.Label _LBL_5;
		public System.Windows.Forms.Label _LBL_0;
		public System.Windows.Forms.Label _LBL_3;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCustomerAllocPaymentAmount));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.txtPack = new System.Windows.Forms.TextBox();
			this.txtPriceS = new System.Windows.Forms.TextBox();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.lblPComp = new System.Windows.Forms.Label();
			this.lblSComp = new System.Windows.Forms.Label();
			this.lblStockItemS = new System.Windows.Forms.Label();
			this._LBL_5 = new System.Windows.Forms.Label();
			this._LBL_0 = new System.Windows.Forms.Label();
			this._LBL_3 = new System.Windows.Forms.Label();
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
			this.Text = "Allocate Partial Amount";
			this.ClientSize = new System.Drawing.Size(400, 134);
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
			this.Name = "frmCustomerAllocPaymentAmount";
			this.txtPack.AutoSize = false;
			this.txtPack.Size = new System.Drawing.Size(41, 19);
			this.txtPack.Location = new System.Drawing.Point(352, 136);
			this.txtPack.TabIndex = 14;
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
			this.txtPriceS.Location = new System.Drawing.Point(291, 210);
			this.txtPriceS.TabIndex = 6;
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
			this.txtPrice.AutoSize = false;
			this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPrice.Size = new System.Drawing.Size(91, 19);
			this.txtPrice.Location = new System.Drawing.Point(293, 79);
			this.txtPrice.TabIndex = 3;
			this.txtPrice.Text = "0.00";
			this.txtPrice.AcceptsReturn = true;
			this.txtPrice.BackColor = System.Drawing.SystemColors.Window;
			this.txtPrice.CausesValidation = true;
			this.txtPrice.Enabled = true;
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
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.Location = new System.Drawing.Point(8, 3);
			this.cmdCancel.TabIndex = 13;
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
			this.Label2.Text = "Please verify products from both locations";
			this.Label2.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label2.Size = new System.Drawing.Size(296, 23);
			this.Label2.Location = new System.Drawing.Point(56, 136);
			this.Label2.TabIndex = 12;
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
			this.lblPComp.Text = "Allocate ";
			this.lblPComp.Size = new System.Drawing.Size(352, 24);
			this.lblPComp.Location = new System.Drawing.Point(16, 52);
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
			this.lblSComp.Text = "Promotion Name:";
			this.lblSComp.Size = new System.Drawing.Size(360, 24);
			this.lblSComp.Location = new System.Drawing.Point(16, 168);
			this.lblSComp.TabIndex = 10;
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
			this.lblStockItemS.Location = new System.Drawing.Point(98, 192);
			this.lblStockItemS.TabIndex = 9;
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
			this._LBL_5.Location = new System.Drawing.Point(10, 192);
			this._LBL_5.TabIndex = 8;
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
			this._LBL_0.Location = new System.Drawing.Point(260, 213);
			this._LBL_0.TabIndex = 7;
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
			this._LBL_3.Text = "Allocate :";
			this._LBL_3.Size = new System.Drawing.Size(44, 13);
			this._LBL_3.Location = new System.Drawing.Point(245, 79);
			this._LBL_3.TabIndex = 5;
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
			this._LBL_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_1.Text = "Available :";
			this._LBL_1.Size = new System.Drawing.Size(49, 13);
			this._LBL_1.Location = new System.Drawing.Point(46, 79);
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
			this.lblStockItem.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblStockItem.Text = "Label1";
			this.lblStockItem.Size = new System.Drawing.Size(110, 17);
			this.lblStockItem.Location = new System.Drawing.Point(98, 79);
			this.lblStockItem.TabIndex = 2;
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
			this._Shape1_0.Size = new System.Drawing.Size(383, 56);
			this._Shape1_0.Location = new System.Drawing.Point(7, 160);
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_0.BorderWidth = 1;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_0.Visible = true;
			this._Shape1_0.Name = "_Shape1_0";
			this.Controls.Add(txtPack);
			this.Controls.Add(txtPriceS);
			this.Controls.Add(txtPrice);
			this.Controls.Add(picButtons);
			this.Controls.Add(Label2);
			this.Controls.Add(lblPComp);
			this.Controls.Add(lblSComp);
			this.Controls.Add(lblStockItemS);
			this.Controls.Add(_LBL_5);
			this.Controls.Add(_LBL_0);
			this.Controls.Add(_LBL_3);
			this.Controls.Add(_LBL_1);
			this.Controls.Add(lblStockItem);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.ShapeContainer1.Shapes.Add(_Shape1_0);
			this.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(cmdCancel);
			this.picButtons.Controls.Add(cmdClose);
			//Me.LBL.SetIndex(_LBL_5, CType(5, Short))
			//Me.LBL.SetIndex(_LBL_0, CType(0, Short))
			//Me.LBL.SetIndex(_LBL_3, CType(3, Short))
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
