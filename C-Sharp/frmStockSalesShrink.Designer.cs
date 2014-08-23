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
	partial class frmStockSalesShrink
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockSalesShrink() : base()
		{
			Load += frmStockSalesShrink_Load;
			KeyPress += frmStockSalesShrink_KeyPress;
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
		private System.Windows.Forms.Button withEventsField_cmdLoad;
		public System.Windows.Forms.Button cmdLoad {
			get { return withEventsField_cmdLoad; }
			set {
				if (withEventsField_cmdLoad != null) {
					withEventsField_cmdLoad.Click -= cmdLoad_Click;
				}
				withEventsField_cmdLoad = value;
				if (withEventsField_cmdLoad != null) {
					withEventsField_cmdLoad.Click += cmdLoad_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdExit;
		public System.Windows.Forms.Button cmdExit {
			get { return withEventsField_cmdExit; }
			set {
				if (withEventsField_cmdExit != null) {
					withEventsField_cmdExit.Click -= cmdExit_Click;
				}
				withEventsField_cmdExit = value;
				if (withEventsField_cmdExit != null) {
					withEventsField_cmdExit.Click += cmdExit_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdGroup;
		public System.Windows.Forms.Button cmdGroup {
			get { return withEventsField_cmdGroup; }
			set {
				if (withEventsField_cmdGroup != null) {
					withEventsField_cmdGroup.Click -= cmdGroup_Click;
				}
				withEventsField_cmdGroup = value;
				if (withEventsField_cmdGroup != null) {
					withEventsField_cmdGroup.Click += cmdGroup_Click;
				}
			}
		}
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label lblGroup;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockSalesShrink));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.cmdLoad = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdGroup = new System.Windows.Forms.Button();
			this._lbl_1 = new System.Windows.Forms.Label();
			this.lblGroup = new System.Windows.Forms.Label();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Stock Item Sales Shrink Analysis";
			this.ClientSize = new System.Drawing.Size(264, 192);
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
			this.Name = "frmStockSalesShrink";
			this.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdLoad.Text = "&Load Report";
			this.cmdLoad.Size = new System.Drawing.Size(79, 31);
			this.cmdLoad.Location = new System.Drawing.Point(177, 147);
			this.cmdLoad.TabIndex = 4;
			this.cmdLoad.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLoad.CausesValidation = true;
			this.cmdLoad.Enabled = true;
			this.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLoad.TabStop = true;
			this.cmdLoad.Name = "cmdLoad";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(79, 31);
			this.cmdExit.Location = new System.Drawing.Point(9, 147);
			this.cmdExit.TabIndex = 3;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.TabStop = true;
			this.cmdExit.Name = "cmdExit";
			this.cmdGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdGroup.Text = "&Filter";
			this.cmdGroup.Size = new System.Drawing.Size(97, 31);
			this.cmdGroup.Location = new System.Drawing.Point(153, 93);
			this.cmdGroup.TabIndex = 2;
			this.cmdGroup.TabStop = false;
			this.cmdGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGroup.CausesValidation = true;
			this.cmdGroup.Enabled = true;
			this.cmdGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGroup.Name = "cmdGroup";
			this._lbl_1.Text = "Filter";
			this._lbl_1.Size = new System.Drawing.Size(29, 13);
			this._lbl_1.Location = new System.Drawing.Point(9, 6);
			this._lbl_1.TabIndex = 0;
			this._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Enabled = true;
			this._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.UseMnemonic = true;
			this._lbl_1.Visible = true;
			this._lbl_1.AutoSize = true;
			this._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_1.Name = "_lbl_1";
			this.lblGroup.Text = "lblGroup";
			this.lblGroup.Size = new System.Drawing.Size(232, 58);
			this.lblGroup.Location = new System.Drawing.Point(15, 27);
			this.lblGroup.TabIndex = 1;
			this.lblGroup.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblGroup.BackColor = System.Drawing.SystemColors.Control;
			this.lblGroup.Enabled = true;
			this.lblGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblGroup.UseMnemonic = true;
			this.lblGroup.Visible = true;
			this.lblGroup.AutoSize = false;
			this.lblGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblGroup.Name = "lblGroup";
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.Size = new System.Drawing.Size(247, 112);
			this._Shape1_1.Location = new System.Drawing.Point(9, 21);
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_1.BorderWidth = 1;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_1.Visible = true;
			this._Shape1_1.Name = "_Shape1_1";
			this.Controls.Add(cmdLoad);
			this.Controls.Add(cmdExit);
			this.Controls.Add(cmdGroup);
			this.Controls.Add(_lbl_1);
			this.Controls.Add(lblGroup);
			this.ShapeContainer1.Shapes.Add(_Shape1_1);
			this.Controls.Add(ShapeContainer1);
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			this.Shape1.SetIndex(_Shape1_1, Convert.ToInt16(1));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
