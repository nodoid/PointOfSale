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
	partial class frmGRVPromotionItem
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmGRVPromotionItem() : base()
		{
			KeyPress += frmGRVPromotionItem_KeyPress;
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
		public System.Windows.Forms.Label _LBL_3;
		public System.Windows.Forms.Label _LBL_2;
		public System.Windows.Forms.Label _LBL_1;
		public System.Windows.Forms.Label _LBL_0;
		public System.Windows.Forms.Label lblPromotion;
		public System.Windows.Forms.Label lblStockItem;
		//Public WithEvents LBL As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGRVPromotionItem));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.cmbQuantity = new System.Windows.Forms.ComboBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdClose = new System.Windows.Forms.Button();
			this._LBL_3 = new System.Windows.Forms.Label();
			this._LBL_2 = new System.Windows.Forms.Label();
			this._LBL_1 = new System.Windows.Forms.Label();
			this._LBL_0 = new System.Windows.Forms.Label();
			this.lblPromotion = new System.Windows.Forms.Label();
			this.lblStockItem = new System.Windows.Forms.Label();
			//Me.LBL = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.LBL, System.ComponentModel.ISupportInitialize).BeginInit()
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Edit GRV Deal Item";
			this.ClientSize = new System.Drawing.Size(388, 115);
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
			this.Name = "frmGRVPromotionItem";
			this.txtPrice.AutoSize = false;
			this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPrice.Size = new System.Drawing.Size(91, 19);
			this.txtPrice.Location = new System.Drawing.Point(285, 81);
			this.txtPrice.TabIndex = 5;
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
			this.cmbQuantity.Size = new System.Drawing.Size(79, 21);
			this.cmbQuantity.Location = new System.Drawing.Point(90, 81);
			this.cmbQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbQuantity.TabIndex = 4;
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
			this.picButtons.Size = new System.Drawing.Size(388, 39);
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
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.Location = new System.Drawing.Point(303, 3);
			this.cmdClose.TabIndex = 1;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this._LBL_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_3.Text = "Price:";
			this._LBL_3.Size = new System.Drawing.Size(27, 13);
			this._LBL_3.Location = new System.Drawing.Point(254, 84);
			this._LBL_3.TabIndex = 9;
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
			this._LBL_2.Text = "Shrink Size:";
			this._LBL_2.Size = new System.Drawing.Size(56, 13);
			this._LBL_2.Location = new System.Drawing.Point(31, 84);
			this._LBL_2.TabIndex = 8;
			this._LBL_2.Visible = false;
			this._LBL_2.BackColor = System.Drawing.Color.Transparent;
			this._LBL_2.Enabled = true;
			this._LBL_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._LBL_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._LBL_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LBL_2.UseMnemonic = true;
			this._LBL_2.AutoSize = true;
			this._LBL_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._LBL_2.Name = "_LBL_2";
			this._LBL_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_1.Text = "Stock Item Name:";
			this._LBL_1.Size = new System.Drawing.Size(85, 13);
			this._LBL_1.Location = new System.Drawing.Point(2, 63);
			this._LBL_1.TabIndex = 7;
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
			this._LBL_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._LBL_0.Text = "Deal Name:";
			this._LBL_0.Size = new System.Drawing.Size(56, 13);
			this._LBL_0.Location = new System.Drawing.Point(32, 45);
			this._LBL_0.TabIndex = 6;
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
			this.lblPromotion.Text = "lblPromotion";
			this.lblPromotion.Size = new System.Drawing.Size(286, 17);
			this.lblPromotion.Location = new System.Drawing.Point(90, 45);
			this.lblPromotion.TabIndex = 3;
			this.lblPromotion.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblPromotion.BackColor = System.Drawing.SystemColors.Control;
			this.lblPromotion.Enabled = true;
			this.lblPromotion.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblPromotion.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblPromotion.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblPromotion.UseMnemonic = true;
			this.lblPromotion.Visible = true;
			this.lblPromotion.AutoSize = false;
			this.lblPromotion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblPromotion.Name = "lblPromotion";
			this.lblStockItem.Text = "Label1";
			this.lblStockItem.Size = new System.Drawing.Size(286, 17);
			this.lblStockItem.Location = new System.Drawing.Point(90, 63);
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
			this.Controls.Add(txtPrice);
			this.Controls.Add(cmbQuantity);
			this.Controls.Add(picButtons);
			this.Controls.Add(_LBL_3);
			this.Controls.Add(_LBL_2);
			this.Controls.Add(_LBL_1);
			this.Controls.Add(_LBL_0);
			this.Controls.Add(lblPromotion);
			this.Controls.Add(lblStockItem);
			this.picButtons.Controls.Add(cmdClose);
			//Me.LBL.SetIndex(_LBL_3, CType(3, Short))
			//Me.LBL.SetIndex(_LBL_2, CType(2, Short))
			//Me.LBL.SetIndex(_LBL_1, CType(1, Short))
			//Me.LBL.SetIndex(_LBL_0, CType(0, Short))
			//CType(Me.LBL, System.ComponentModel.ISupportInitialize).EndInit()
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
