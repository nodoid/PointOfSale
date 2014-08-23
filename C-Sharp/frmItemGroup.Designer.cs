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
	partial class frmItemGroup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmItemGroup() : base()
		{
			Load += frmItemGroup_Load;
			KeyPress += frmItemGroup_KeyPress;
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
		public System.Windows.Forms.RadioButton _optDataType_1;
		public System.Windows.Forms.RadioButton _optDataType_0;
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
		private System.Windows.Forms.Button withEventsField_cmdStockItem;
		public System.Windows.Forms.Button cmdStockItem {
			get { return withEventsField_cmdStockItem; }
			set {
				if (withEventsField_cmdStockItem != null) {
					withEventsField_cmdStockItem.Click -= cmdStockItem_Click;
				}
				withEventsField_cmdStockItem = value;
				if (withEventsField_cmdStockItem != null) {
					withEventsField_cmdStockItem.Click += cmdStockItem_Click;
				}
			}
		}
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label lblGroup;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label lblItem;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents optDataType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmItemGroup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdLoad = new System.Windows.Forms.Button();
			this._optDataType_1 = new System.Windows.Forms.RadioButton();
			this._optDataType_0 = new System.Windows.Forms.RadioButton();
			this.cmdGroup = new System.Windows.Forms.Button();
			this.cmdStockItem = new System.Windows.Forms.Button();
			this._lbl_1 = new System.Windows.Forms.Label();
			this.lblGroup = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.lblItem = new System.Windows.Forms.Label();
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.optDataType = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.optDataType, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Stock Item / Stock Group Compare";
			this.ClientSize = new System.Drawing.Size(558, 196);
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
			this.Name = "frmItemGroup";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(79, 31);
			this.cmdExit.Location = new System.Drawing.Point(9, 144);
			this.cmdExit.TabIndex = 9;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.TabStop = true;
			this.cmdExit.Name = "cmdExit";
			this.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdLoad.Text = "&Load report >>";
			this.cmdLoad.Size = new System.Drawing.Size(79, 31);
			this.cmdLoad.Location = new System.Drawing.Point(465, 144);
			this.cmdLoad.TabIndex = 8;
			this.cmdLoad.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLoad.CausesValidation = true;
			this.cmdLoad.Enabled = true;
			this.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLoad.TabStop = true;
			this.cmdLoad.Name = "cmdLoad";
			this._optDataType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optDataType_1.Text = "Sales Value";
			this._optDataType_1.Size = new System.Drawing.Size(145, 13);
			this._optDataType_1.Location = new System.Drawing.Point(315, 162);
			this._optDataType_1.TabIndex = 7;
			this._optDataType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optDataType_1.BackColor = System.Drawing.SystemColors.Control;
			this._optDataType_1.CausesValidation = true;
			this._optDataType_1.Enabled = true;
			this._optDataType_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optDataType_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._optDataType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optDataType_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optDataType_1.TabStop = true;
			this._optDataType_1.Checked = false;
			this._optDataType_1.Visible = true;
			this._optDataType_1.Name = "_optDataType_1";
			this._optDataType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optDataType_0.Text = "Sales Quantity";
			this._optDataType_0.Size = new System.Drawing.Size(145, 13);
			this._optDataType_0.Location = new System.Drawing.Point(315, 144);
			this._optDataType_0.TabIndex = 6;
			this._optDataType_0.Checked = true;
			this._optDataType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optDataType_0.BackColor = System.Drawing.SystemColors.Control;
			this._optDataType_0.CausesValidation = true;
			this._optDataType_0.Enabled = true;
			this._optDataType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optDataType_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._optDataType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optDataType_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optDataType_0.TabStop = true;
			this._optDataType_0.Visible = true;
			this._optDataType_0.Name = "_optDataType_0";
			this.cmdGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdGroup.Text = "Get a Group >>";
			this.cmdGroup.Size = new System.Drawing.Size(97, 31);
			this.cmdGroup.Location = new System.Drawing.Point(441, 90);
			this.cmdGroup.TabIndex = 3;
			this.cmdGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGroup.CausesValidation = true;
			this.cmdGroup.Enabled = true;
			this.cmdGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGroup.TabStop = true;
			this.cmdGroup.Name = "cmdGroup";
			this.cmdStockItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdStockItem.Text = "Get Stock Item >>";
			this.cmdStockItem.Size = new System.Drawing.Size(97, 22);
			this.cmdStockItem.Location = new System.Drawing.Point(441, 30);
			this.cmdStockItem.TabIndex = 1;
			this.cmdStockItem.BackColor = System.Drawing.SystemColors.Control;
			this.cmdStockItem.CausesValidation = true;
			this.cmdStockItem.Enabled = true;
			this.cmdStockItem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdStockItem.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdStockItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdStockItem.TabStop = true;
			this.cmdStockItem.Name = "cmdStockItem";
			this._lbl_1.Text = "&2. Select a Group";
			this._lbl_1.Size = new System.Drawing.Size(101, 13);
			this._lbl_1.Location = new System.Drawing.Point(9, 66);
			this._lbl_1.TabIndex = 5;
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
			this.lblGroup.Size = new System.Drawing.Size(421, 37);
			this.lblGroup.Location = new System.Drawing.Point(15, 87);
			this.lblGroup.TabIndex = 4;
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
			this._lbl_0.Text = "&1. Select a Stock Item";
			this._lbl_0.Size = new System.Drawing.Size(128, 13);
			this._lbl_0.Location = new System.Drawing.Point(9, 9);
			this._lbl_0.TabIndex = 2;
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Enabled = true;
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.UseMnemonic = true;
			this._lbl_0.Visible = true;
			this._lbl_0.AutoSize = true;
			this._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_0.Name = "_lbl_0";
			this.lblItem.Size = new System.Drawing.Size(421, 19);
			this.lblItem.Location = new System.Drawing.Point(15, 30);
			this.lblItem.TabIndex = 0;
			this.lblItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblItem.BackColor = System.Drawing.SystemColors.Control;
			this.lblItem.Enabled = true;
			this.lblItem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblItem.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblItem.UseMnemonic = true;
			this.lblItem.Visible = true;
			this.lblItem.AutoSize = false;
			this.lblItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblItem.Name = "lblItem";
			this._Shape1_0.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_0.Size = new System.Drawing.Size(535, 34);
			this._Shape1_0.Location = new System.Drawing.Point(9, 24);
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_0.BorderWidth = 1;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_0.Visible = true;
			this._Shape1_0.Name = "_Shape1_0";
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.Size = new System.Drawing.Size(535, 52);
			this._Shape1_1.Location = new System.Drawing.Point(9, 81);
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_1.BorderWidth = 1;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_1.Visible = true;
			this._Shape1_1.Name = "_Shape1_1";
			this.Controls.Add(cmdExit);
			this.Controls.Add(cmdLoad);
			this.Controls.Add(_optDataType_1);
			this.Controls.Add(_optDataType_0);
			this.Controls.Add(cmdGroup);
			this.Controls.Add(cmdStockItem);
			this.Controls.Add(_lbl_1);
			this.Controls.Add(lblGroup);
			this.Controls.Add(_lbl_0);
			this.Controls.Add(lblItem);
			this.ShapeContainer1.Shapes.Add(_Shape1_0);
			this.ShapeContainer1.Shapes.Add(_Shape1_1);
			this.Controls.Add(ShapeContainer1);
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.optDataType.SetIndex(_optDataType_1, CType(1, Short))
			//Me.optDataType.SetIndex(_optDataType_0, CType(0, Short))
			this.Shape1.SetIndex(_Shape1_0, Convert.ToInt16(0));
			this.Shape1.SetIndex(_Shape1_1, Convert.ToInt16(1));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.optDataType, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
