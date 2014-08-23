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
	partial class frmStockSales
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockSales() : base()
		{
			Load += frmStockSales_Load;
			KeyPress += frmStockSales_KeyPress;
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
		public System.Windows.Forms.RadioButton _optType_4;
		public System.Windows.Forms.RadioButton _optType_3;
		public System.Windows.Forms.RadioButton _optType_2;
		public System.Windows.Forms.RadioButton _optType_1;
		public System.Windows.Forms.RadioButton _optType_0;
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
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label lblGroup;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents optType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockSales));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.cmdLoad = new System.Windows.Forms.Button();
			this._optType_4 = new System.Windows.Forms.RadioButton();
			this._optType_3 = new System.Windows.Forms.RadioButton();
			this._optType_2 = new System.Windows.Forms.RadioButton();
			this._optType_1 = new System.Windows.Forms.RadioButton();
			this._optType_0 = new System.Windows.Forms.RadioButton();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdGroup = new System.Windows.Forms.Button();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this.lblGroup = new System.Windows.Forms.Label();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.optType = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.optType, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Stock Item Sales Listing Order";
			this.ClientSize = new System.Drawing.Size(264, 310);
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
			this.Name = "frmStockSales";
			this.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdLoad.Text = "&Load Report";
			this.cmdLoad.Size = new System.Drawing.Size(79, 31);
			this.cmdLoad.Location = new System.Drawing.Point(177, 267);
			this.cmdLoad.TabIndex = 10;
			this.cmdLoad.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLoad.CausesValidation = true;
			this.cmdLoad.Enabled = true;
			this.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLoad.TabStop = true;
			this.cmdLoad.Name = "cmdLoad";
			this._optType_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_4.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._optType_4.Text = "Shrink Size";
			this._optType_4.Size = new System.Drawing.Size(196, 13);
			this._optType_4.Location = new System.Drawing.Point(15, 72);
			this._optType_4.TabIndex = 5;
			this._optType_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_4.CausesValidation = true;
			this._optType_4.Enabled = true;
			this._optType_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_4.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optType_4.TabStop = true;
			this._optType_4.Checked = false;
			this._optType_4.Visible = true;
			this._optType_4.Name = "_optType_4";
			this._optType_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_3.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._optType_3.Text = "Stock Group";
			this._optType_3.Size = new System.Drawing.Size(196, 13);
			this._optType_3.Location = new System.Drawing.Point(16, 57);
			this._optType_3.TabIndex = 4;
			this._optType_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_3.CausesValidation = true;
			this._optType_3.Enabled = true;
			this._optType_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_3.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optType_3.TabStop = true;
			this._optType_3.Checked = false;
			this._optType_3.Visible = true;
			this._optType_3.Name = "_optType_3";
			this._optType_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._optType_2.Text = "Pricing Group";
			this._optType_2.Size = new System.Drawing.Size(196, 13);
			this._optType_2.Location = new System.Drawing.Point(15, 42);
			this._optType_2.TabIndex = 3;
			this._optType_2.Checked = true;
			this._optType_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_2.CausesValidation = true;
			this._optType_2.Enabled = true;
			this._optType_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optType_2.TabStop = true;
			this._optType_2.Visible = true;
			this._optType_2.Name = "_optType_2";
			this._optType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._optType_1.Text = "Supplier";
			this._optType_1.Size = new System.Drawing.Size(196, 13);
			this._optType_1.Location = new System.Drawing.Point(15, 27);
			this._optType_1.TabIndex = 2;
			this._optType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_1.CausesValidation = true;
			this._optType_1.Enabled = true;
			this._optType_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optType_1.TabStop = true;
			this._optType_1.Checked = false;
			this._optType_1.Visible = true;
			this._optType_1.Name = "_optType_1";
			this._optType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_0.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._optType_0.Text = "Stock item (Filter)";
			this._optType_0.Size = new System.Drawing.Size(196, 13);
			this._optType_0.Location = new System.Drawing.Point(15, 88);
			this._optType_0.TabIndex = 1;
			this._optType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_0.CausesValidation = true;
			this._optType_0.Enabled = true;
			this._optType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optType_0.TabStop = true;
			this._optType_0.Checked = false;
			this._optType_0.Visible = true;
			this._optType_0.Name = "_optType_0";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(79, 31);
			this.cmdExit.Location = new System.Drawing.Point(9, 267);
			this.cmdExit.TabIndex = 9;
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
			this.cmdGroup.Location = new System.Drawing.Point(153, 213);
			this.cmdGroup.TabIndex = 8;
			this.cmdGroup.TabStop = false;
			this.cmdGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGroup.CausesValidation = true;
			this.cmdGroup.Enabled = true;
			this.cmdGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGroup.Name = "cmdGroup";
			this._lbl_2.Text = "&1.Group Report by ...";
			this._lbl_2.Size = new System.Drawing.Size(121, 13);
			this._lbl_2.Location = new System.Drawing.Point(12, 3);
			this._lbl_2.TabIndex = 0;
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Enabled = true;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.UseMnemonic = true;
			this._lbl_2.Visible = true;
			this._lbl_2.AutoSize = true;
			this._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_2.Name = "_lbl_2";
			this._lbl_1.Text = "Filter (For Stock Item)";
			this._lbl_1.Size = new System.Drawing.Size(124, 13);
			this._lbl_1.Location = new System.Drawing.Point(9, 126);
			this._lbl_1.TabIndex = 6;
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
			this.lblGroup.Location = new System.Drawing.Point(15, 147);
			this.lblGroup.TabIndex = 7;
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
			this._Shape1_1.Location = new System.Drawing.Point(9, 141);
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_1.BorderWidth = 1;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_1.Visible = true;
			this._Shape1_1.Name = "_Shape1_1";
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(247, 87);
			this._Shape1_2.Location = new System.Drawing.Point(9, 21);
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_2.BorderWidth = 1;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_2.Visible = true;
			this._Shape1_2.Name = "_Shape1_2";
			this.Controls.Add(cmdLoad);
			this.Controls.Add(_optType_4);
			this.Controls.Add(_optType_3);
			this.Controls.Add(_optType_2);
			this.Controls.Add(_optType_1);
			this.Controls.Add(_optType_0);
			this.Controls.Add(cmdExit);
			this.Controls.Add(cmdGroup);
			this.Controls.Add(_lbl_2);
			this.Controls.Add(_lbl_1);
			this.Controls.Add(lblGroup);
			this.ShapeContainer1.Shapes.Add(_Shape1_1);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.Controls.Add(ShapeContainer1);
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.optType.SetIndex(_optType_4, CType(4, Short))
			//Me.optType.SetIndex(_optType_3, CType(3, Short))
			//Me.optType.SetIndex(_optType_2, CType(2, Short))
			//Me.optType.SetIndex(_optType_1, CType(1, Short))
			//Me.optType.SetIndex(_optType_0, CType(0, Short))
			this.Shape1.SetIndex(_Shape1_1, Convert.ToInt16(1));
			this.Shape1.SetIndex(_Shape1_2, Convert.ToInt16(2));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.optType, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
