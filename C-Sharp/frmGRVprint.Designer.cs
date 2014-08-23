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
	partial class frmGRVprint
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmGRVprint() : base()
		{
			Load += frmGRVprint_Load;
			KeyPress += frmGRVprint_KeyPress;
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
		private System.Windows.Forms.ListBox withEventsField_lstSupplier;
		public System.Windows.Forms.ListBox lstSupplier {
			get { return withEventsField_lstSupplier; }
			set {
				if (withEventsField_lstSupplier != null) {
					withEventsField_lstSupplier.SelectedIndexChanged -= lstSupplier_SelectedIndexChanged;
					withEventsField_lstSupplier.KeyPress -= lstSupplier_KeyPress;
				}
				withEventsField_lstSupplier = value;
				if (withEventsField_lstSupplier != null) {
					withEventsField_lstSupplier.SelectedIndexChanged += lstSupplier_SelectedIndexChanged;
					withEventsField_lstSupplier.KeyPress += lstSupplier_KeyPress;
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
		public System.Windows.Forms.Label lblPath;
		public System.Windows.Forms.Panel Picture1;
		private System.Windows.Forms.ListView withEventsField_lvItems;
		public System.Windows.Forms.ListView lvItems {
			get { return withEventsField_lvItems; }
			set {
				if (withEventsField_lvItems != null) {
					withEventsField_lvItems.DoubleClick -= lvItems_DoubleClick;
					withEventsField_lvItems.KeyPress -= lvItems_KeyPress;
				}
				withEventsField_lvItems = value;
				if (withEventsField_lvItems != null) {
					withEventsField_lvItems.DoubleClick += lvItems_DoubleClick;
					withEventsField_lvItems.KeyPress += lvItems_KeyPress;
				}
			}
		}
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label _lbl_1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_0;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGRVprint));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.lstSupplier = new System.Windows.Forms.ListBox();
			this.Picture1 = new System.Windows.Forms.Panel();
			this.cmdBack = new System.Windows.Forms.Button();
			this.lblPath = new System.Windows.Forms.Label();
			this.lvItems = new System.Windows.Forms.ListView();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.Picture1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.ClientSize = new System.Drawing.Size(618, 459);
			this.Location = new System.Drawing.Point(3, 3);
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
			this.Name = "frmGRVprint";
			this.lstSupplier.Size = new System.Drawing.Size(151, 384);
			this.lstSupplier.Location = new System.Drawing.Point(12, 64);
			this.lstSupplier.TabIndex = 1;
			this.lstSupplier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSupplier.BackColor = System.Drawing.SystemColors.Window;
			this.lstSupplier.CausesValidation = true;
			this.lstSupplier.Enabled = true;
			this.lstSupplier.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSupplier.IntegralHeight = true;
			this.lstSupplier.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSupplier.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSupplier.Sorted = false;
			this.lstSupplier.TabStop = true;
			this.lstSupplier.Visible = true;
			this.lstSupplier.MultiColumn = false;
			this.lstSupplier.Name = "lstSupplier";
			this.Picture1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Picture1.BackColor = System.Drawing.Color.Blue;
			this.Picture1.Size = new System.Drawing.Size(618, 35);
			this.Picture1.Location = new System.Drawing.Point(0, 0);
			this.Picture1.TabIndex = 4;
			this.Picture1.TabStop = false;
			this.Picture1.CausesValidation = true;
			this.Picture1.Enabled = true;
			this.Picture1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Picture1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Picture1.Visible = true;
			this.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Picture1.Name = "Picture1";
			this.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBack.Text = "E&xit";
			this.cmdBack.Size = new System.Drawing.Size(97, 25);
			this.cmdBack.Location = new System.Drawing.Point(512, 3);
			this.cmdBack.TabIndex = 6;
			this.cmdBack.TabStop = false;
			this.cmdBack.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBack.CausesValidation = true;
			this.cmdBack.Enabled = true;
			this.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBack.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBack.Name = "cmdBack";
			this.lblPath.BackColor = System.Drawing.Color.Transparent;
			this.lblPath.Text = "Invoice Print";
			this.lblPath.ForeColor = System.Drawing.Color.White;
			this.lblPath.Size = new System.Drawing.Size(100, 20);
			this.lblPath.Location = new System.Drawing.Point(0, 0);
			this.lblPath.TabIndex = 5;
			this.lblPath.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblPath.Enabled = true;
			this.lblPath.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblPath.UseMnemonic = true;
			this.lblPath.Visible = true;
			this.lblPath.AutoSize = true;
			this.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblPath.Name = "lblPath";
			this.lvItems.Size = new System.Drawing.Size(424, 382);
			this.lvItems.Location = new System.Drawing.Point(183, 64);
			this.lvItems.TabIndex = 3;
			this.lvItems.View = System.Windows.Forms.View.Details;
			this.lvItems.LabelEdit = false;
			this.lvItems.LabelWrap = true;
			this.lvItems.HideSelection = true;
			this.lvItems.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lvItems.BackColor = System.Drawing.SystemColors.Window;
			this.lvItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lvItems.Name = "lvItems";
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Text = "&1. Select a Supplier";
			this._lbl_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lbl_0.Size = new System.Drawing.Size(113, 13);
			this._lbl_0.Location = new System.Drawing.Point(9, 43);
			this._lbl_0.TabIndex = 0;
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_0.Enabled = true;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.UseMnemonic = true;
			this._lbl_0.Visible = true;
			this._lbl_0.AutoSize = true;
			this._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_0.Name = "_lbl_0";
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Text = "&2. Select an Invoice";
			this._lbl_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lbl_1.Size = new System.Drawing.Size(116, 13);
			this._lbl_1.Location = new System.Drawing.Point(180, 43);
			this._lbl_1.TabIndex = 2;
			this._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_1.Enabled = true;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.UseMnemonic = true;
			this._lbl_1.Visible = true;
			this._lbl_1.AutoSize = true;
			this._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_1.Name = "_lbl_1";
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.Size = new System.Drawing.Size(436, 394);
			this._Shape1_1.Location = new System.Drawing.Point(177, 58);
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_1.BorderWidth = 1;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_1.Visible = true;
			this._Shape1_1.Name = "_Shape1_1";
			this._Shape1_0.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_0.Size = new System.Drawing.Size(163, 394);
			this._Shape1_0.Location = new System.Drawing.Point(6, 58);
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_0.BorderWidth = 1;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_0.Visible = true;
			this._Shape1_0.Name = "_Shape1_0";
			this.Controls.Add(lstSupplier);
			this.Controls.Add(Picture1);
			this.Controls.Add(lvItems);
			this.Controls.Add(_lbl_0);
			this.Controls.Add(_lbl_1);
			this.ShapeContainer1.Shapes.Add(_Shape1_1);
			this.ShapeContainer1.Shapes.Add(_Shape1_0);
			this.Controls.Add(ShapeContainer1);
			this.Picture1.Controls.Add(cmdBack);
			this.Picture1.Controls.Add(lblPath);
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			this.Shape1.SetIndex(_Shape1_1, Convert.ToInt16(1));
			this.Shape1.SetIndex(_Shape1_0, Convert.ToInt16(0));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.Picture1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
