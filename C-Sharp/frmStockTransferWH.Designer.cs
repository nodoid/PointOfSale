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
	partial class frmStockTransferWH
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockTransferWH() : base()
		{
			FormClosed += frmStockTransferWH_FormClosed;
			KeyPress += frmStockTransferWH_KeyPress;
			Resize += frmStockTransferWH_Resize;
			Load += frmStockTransferWH_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdSelWHB;
		public System.Windows.Forms.Button cmdSelWHB {
			get { return withEventsField_cmdSelWHB; }
			set {
				if (withEventsField_cmdSelWHB != null) {
					withEventsField_cmdSelWHB.Click -= cmdSelWHB_Click;
				}
				withEventsField_cmdSelWHB = value;
				if (withEventsField_cmdSelWHB != null) {
					withEventsField_cmdSelWHB.Click += cmdSelWHB_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdSelWHA;
		public System.Windows.Forms.Button cmdSelWHA {
			get { return withEventsField_cmdSelWHA; }
			set {
				if (withEventsField_cmdSelWHA != null) {
					withEventsField_cmdSelWHA.Click -= cmdSelWHA_Click;
				}
				withEventsField_cmdSelWHA = value;
				if (withEventsField_cmdSelWHA != null) {
					withEventsField_cmdSelWHA.Click += cmdSelWHA_Click;
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
		private System.Windows.Forms.Button withEventsField_cmdAdd;
		public System.Windows.Forms.Button cmdAdd {
			get { return withEventsField_cmdAdd; }
			set {
				if (withEventsField_cmdAdd != null) {
					withEventsField_cmdAdd.Click -= cmdAdd_Click;
				}
				withEventsField_cmdAdd = value;
				if (withEventsField_cmdAdd != null) {
					withEventsField_cmdAdd.Click += cmdAdd_Click;
				}
			}
		}
		private System.Windows.Forms.ListView withEventsField_lvStockT;
		public System.Windows.Forms.ListView lvStockT {
			get { return withEventsField_lvStockT; }
			set {
				if (withEventsField_lvStockT != null) {
					withEventsField_lvStockT.DoubleClick -= lvStockT_DoubleClick;
					withEventsField_lvStockT.KeyPress -= lvStockT_KeyPress;
				}
				withEventsField_lvStockT = value;
				if (withEventsField_lvStockT != null) {
					withEventsField_lvStockT.DoubleClick += lvStockT_DoubleClick;
					withEventsField_lvStockT.KeyPress += lvStockT_KeyPress;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdTransfer;
		public System.Windows.Forms.Button cmdTransfer {
			get { return withEventsField_cmdTransfer; }
			set {
				if (withEventsField_cmdTransfer != null) {
					withEventsField_cmdTransfer.Click -= cmdTransfer_Click;
				}
				withEventsField_cmdTransfer = value;
				if (withEventsField_cmdTransfer != null) {
					withEventsField_cmdTransfer.Click += cmdTransfer_Click;
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
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.Label lblWHB;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label lblWHA;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public System.Windows.Forms.Label _lbl_5;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockTransferWH));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.cmdSelWHB = new System.Windows.Forms.Button();
			this.cmdSelWHA = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.lvStockT = new System.Windows.Forms.ListView();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdTransfer = new System.Windows.Forms.Button();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.lblWHB = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.lblWHA = new System.Windows.Forms.Label();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._lbl_5 = new System.Windows.Forms.Label();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Stock Transfer Details";
			this.ClientSize = new System.Drawing.Size(453, 438);
			this.Location = new System.Drawing.Point(73, 22);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmStockTransferWH";
			this.cmdSelWHB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSelWHB.Text = "&Select Warehouse Transfer To";
			this.cmdSelWHB.Size = new System.Drawing.Size(169, 25);
			this.cmdSelWHB.Location = new System.Drawing.Point(248, 112);
			this.cmdSelWHB.TabIndex = 13;
			this.cmdSelWHB.TabStop = false;
			this.cmdSelWHB.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSelWHB.CausesValidation = true;
			this.cmdSelWHB.Enabled = true;
			this.cmdSelWHB.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSelWHB.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSelWHB.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSelWHB.Name = "cmdSelWHB";
			this.cmdSelWHA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSelWHA.Text = "&Select Warehouse Transfer From";
			this.cmdSelWHA.Size = new System.Drawing.Size(169, 25);
			this.cmdSelWHA.Location = new System.Drawing.Point(16, 112);
			this.cmdSelWHA.TabIndex = 9;
			this.cmdSelWHA.TabStop = false;
			this.cmdSelWHA.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSelWHA.CausesValidation = true;
			this.cmdSelWHA.Enabled = true;
			this.cmdSelWHA.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSelWHA.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSelWHA.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSelWHA.Name = "cmdSelWHA";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "&Delete";
			this.cmdDelete.Enabled = false;
			this.cmdDelete.Size = new System.Drawing.Size(94, 25);
			this.cmdDelete.Location = new System.Drawing.Point(112, 152);
			this.cmdDelete.TabIndex = 7;
			this.cmdDelete.TabStop = false;
			this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelete.CausesValidation = true;
			this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelete.Name = "cmdDelete";
			this.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAdd.Text = "&Add";
			this.cmdAdd.Enabled = false;
			this.cmdAdd.Size = new System.Drawing.Size(94, 25);
			this.cmdAdd.Location = new System.Drawing.Point(8, 152);
			this.cmdAdd.TabIndex = 6;
			this.cmdAdd.TabStop = false;
			this.cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAdd.CausesValidation = true;
			this.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAdd.Name = "cmdAdd";
			this.lvStockT.Size = new System.Drawing.Size(445, 250);
			this.lvStockT.Location = new System.Drawing.Point(2, 182);
			this.lvStockT.TabIndex = 4;
			this.lvStockT.View = System.Windows.Forms.View.Details;
			this.lvStockT.LabelEdit = false;
			this.lvStockT.LabelWrap = true;
			this.lvStockT.HideSelection = false;
			this.lvStockT.FullRowSelect = true;
			this.lvStockT.GridLines = true;
			this.lvStockT.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lvStockT.BackColor = System.Drawing.SystemColors.Window;
			this.lvStockT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lvStockT.Name = "lvStockT";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(453, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 3;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdTransfer.Text = "&Transfer";
			this.cmdTransfer.Size = new System.Drawing.Size(73, 29);
			this.cmdTransfer.Location = new System.Drawing.Point(368, 3);
			this.cmdTransfer.TabIndex = 12;
			this.cmdTransfer.TabStop = false;
			this.cmdTransfer.BackColor = System.Drawing.SystemColors.Control;
			this.cmdTransfer.CausesValidation = true;
			this.cmdTransfer.Enabled = true;
			this.cmdTransfer.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdTransfer.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdTransfer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdTransfer.Name = "cmdTransfer";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.Size = new System.Drawing.Size(73, 29);
			this.cmdPrint.Location = new System.Drawing.Point(80, 3);
			this.cmdPrint.TabIndex = 8;
			this.cmdPrint.TabStop = false;
			this.cmdPrint.Visible = false;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.Location = new System.Drawing.Point(161, 3);
			this.cmdClose.TabIndex = 5;
			this.cmdClose.TabStop = false;
			this.cmdClose.Visible = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.Location = new System.Drawing.Point(5, 3);
			this.cmdCancel.TabIndex = 2;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Name = "cmdCancel";
			this.lblWHB.Text = "Promotion Name:";
			this.lblWHB.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblWHB.Size = new System.Drawing.Size(192, 48);
			this.lblWHB.Location = new System.Drawing.Point(248, 64);
			this.lblWHB.TabIndex = 11;
			this.lblWHB.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblWHB.BackColor = System.Drawing.Color.Transparent;
			this.lblWHB.Enabled = true;
			this.lblWHB.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblWHB.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblWHB.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblWHB.UseMnemonic = true;
			this.lblWHB.Visible = true;
			this.lblWHB.AutoSize = false;
			this.lblWHB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblWHB.Name = "lblWHB";
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Text = "&Transfer To";
			this._lbl_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_0.Size = new System.Drawing.Size(67, 13);
			this._lbl_0.Location = new System.Drawing.Point(248, 45);
			this._lbl_0.TabIndex = 10;
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_0.Enabled = true;
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.UseMnemonic = true;
			this._lbl_0.Visible = true;
			this._lbl_0.AutoSize = true;
			this._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_0.Name = "_lbl_0";
			this.lblWHA.Text = "Promotion Name:";
			this.lblWHA.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblWHA.Size = new System.Drawing.Size(216, 40);
			this.lblWHA.Location = new System.Drawing.Point(16, 64);
			this.lblWHA.TabIndex = 1;
			this.lblWHA.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblWHA.BackColor = System.Drawing.Color.Transparent;
			this.lblWHA.Enabled = true;
			this.lblWHA.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblWHA.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblWHA.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblWHA.UseMnemonic = true;
			this.lblWHA.Visible = true;
			this.lblWHA.AutoSize = false;
			this.lblWHA.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblWHA.Name = "lblWHA";
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(439, 88);
			this._Shape1_2.Location = new System.Drawing.Point(8, 60);
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_2.BorderWidth = 1;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_2.Visible = true;
			this._Shape1_2.Name = "_Shape1_2";
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Text = "&Transfer From";
			this._lbl_5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_5.Size = new System.Drawing.Size(79, 13);
			this._lbl_5.Location = new System.Drawing.Point(8, 45);
			this._lbl_5.TabIndex = 0;
			this._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_5.Enabled = true;
			this._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_5.UseMnemonic = true;
			this._lbl_5.Visible = true;
			this._lbl_5.AutoSize = true;
			this._lbl_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_5.Name = "_lbl_5";
			this.Controls.Add(cmdSelWHB);
			this.Controls.Add(cmdSelWHA);
			this.Controls.Add(cmdDelete);
			this.Controls.Add(cmdAdd);
			this.Controls.Add(lvStockT);
			this.Controls.Add(picButtons);
			this.Controls.Add(lblWHB);
			this.Controls.Add(_lbl_0);
			this.Controls.Add(lblWHA);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.Controls.Add(_lbl_5);
			this.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(cmdTransfer);
			this.picButtons.Controls.Add(cmdPrint);
			this.picButtons.Controls.Add(cmdClose);
			this.picButtons.Controls.Add(cmdCancel);
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			this.Shape1.SetIndex(_Shape1_2, Convert.ToInt16(2));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
