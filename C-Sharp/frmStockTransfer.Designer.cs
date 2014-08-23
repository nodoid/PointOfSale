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
	partial class frmStockTransfer
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockTransfer() : base()
		{
			FormClosed += frmStockTransfer_FormClosed;
			KeyPress += frmStockTransfer_KeyPress;
			Resize += frmStockTransfer_Resize;
			Load += frmStockTransfer_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdSelComp;
		public System.Windows.Forms.Button cmdSelComp {
			get { return withEventsField_cmdSelComp; }
			set {
				if (withEventsField_cmdSelComp != null) {
					withEventsField_cmdSelComp.Click -= cmdSelComp_Click;
				}
				withEventsField_cmdSelComp = value;
				if (withEventsField_cmdSelComp != null) {
					withEventsField_cmdSelComp.Click += cmdSelComp_Click;
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
		public System.Windows.Forms.Label lblSComp;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label lblPComp;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockTransfer));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.cmdSelComp = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.lvStockT = new System.Windows.Forms.ListView();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdTransfer = new System.Windows.Forms.Button();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.lblSComp = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.lblPComp = new System.Windows.Forms.Label();
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
			this.ClientSize = new System.Drawing.Size(453, 406);
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
			this.Name = "frmStockTransfer";
			this.cmdSelComp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSelComp.Text = "&Select Company to Transfer";
			this.cmdSelComp.Size = new System.Drawing.Size(161, 25);
			this.cmdSelComp.Location = new System.Drawing.Point(280, 120);
			this.cmdSelComp.TabIndex = 9;
			this.cmdSelComp.TabStop = false;
			this.cmdSelComp.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSelComp.CausesValidation = true;
			this.cmdSelComp.Enabled = true;
			this.cmdSelComp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSelComp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSelComp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSelComp.Name = "cmdSelComp";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "&Delete";
			this.cmdDelete.Enabled = false;
			this.cmdDelete.Size = new System.Drawing.Size(94, 25);
			this.cmdDelete.Location = new System.Drawing.Point(112, 120);
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
			this.cmdAdd.Location = new System.Drawing.Point(8, 120);
			this.cmdAdd.TabIndex = 6;
			this.cmdAdd.TabStop = false;
			this.cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAdd.CausesValidation = true;
			this.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAdd.Name = "cmdAdd";
			this.lvStockT.Size = new System.Drawing.Size(445, 250);
			this.lvStockT.Location = new System.Drawing.Point(2, 150);
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
			this.lblSComp.Text = "Promotion Name:";
			this.lblSComp.Size = new System.Drawing.Size(192, 48);
			this.lblSComp.Location = new System.Drawing.Point(248, 64);
			this.lblSComp.TabIndex = 11;
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
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Text = "&Transfer To";
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
			this.lblPComp.Text = "Promotion Name:";
			this.lblPComp.Size = new System.Drawing.Size(216, 48);
			this.lblPComp.Location = new System.Drawing.Point(16, 64);
			this.lblPComp.TabIndex = 1;
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
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(439, 56);
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
			this.Controls.Add(cmdSelComp);
			this.Controls.Add(cmdDelete);
			this.Controls.Add(cmdAdd);
			this.Controls.Add(lvStockT);
			this.Controls.Add(picButtons);
			this.Controls.Add(lblSComp);
			this.Controls.Add(_lbl_0);
			this.Controls.Add(lblPComp);
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
