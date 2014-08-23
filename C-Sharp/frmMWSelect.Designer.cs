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
	partial class frmMWSelect
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmMWSelect() : base()
		{
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
		public System.Windows.Forms.ComboBox cmbMWNo;
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
		public System.Windows.Forms.TextBox txtWNO;
		public System.Windows.Forms.Label _lbl_5;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMWSelect));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.cmbMWNo = new System.Windows.Forms.ComboBox();
			this.cmdExit = new System.Windows.Forms.Button();
			this.txtWNO = new System.Windows.Forms.TextBox();
			this._lbl_5 = new System.Windows.Forms.Label();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Warehouse selection";
			this.ClientSize = new System.Drawing.Size(418, 99);
			this.Location = new System.Drawing.Point(3, 29);
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
			this.Name = "frmMWSelect";
			this.cmbMWNo.Size = new System.Drawing.Size(276, 21);
			this.cmbMWNo.Location = new System.Drawing.Point(16, 32);
			this.cmbMWNo.Items.AddRange(new object[] {
				"No relationship",
				"Always the same or cheaper",
				"Always the same or more expensive"
			});
			this.cmbMWNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMWNo.TabIndex = 2;
			this.cmbMWNo.BackColor = System.Drawing.SystemColors.Window;
			this.cmbMWNo.CausesValidation = true;
			this.cmbMWNo.Enabled = true;
			this.cmbMWNo.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbMWNo.IntegralHeight = true;
			this.cmbMWNo.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbMWNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbMWNo.Sorted = false;
			this.cmbMWNo.TabStop = true;
			this.cmbMWNo.Visible = true;
			this.cmbMWNo.Name = "cmbMWNo";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "Next";
			this.cmdExit.Size = new System.Drawing.Size(97, 52);
			this.cmdExit.Location = new System.Drawing.Point(304, 32);
			this.cmdExit.TabIndex = 1;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.txtWNO.AutoSize = false;
			this.txtWNO.Size = new System.Drawing.Size(89, 25);
			this.txtWNO.Location = new System.Drawing.Point(104, 56);
			this.txtWNO.TabIndex = 0;
			this.txtWNO.Text = "2";
			this.txtWNO.Visible = false;
			this.txtWNO.AcceptsReturn = true;
			this.txtWNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtWNO.BackColor = System.Drawing.SystemColors.Window;
			this.txtWNO.CausesValidation = true;
			this.txtWNO.Enabled = true;
			this.txtWNO.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtWNO.HideSelection = true;
			this.txtWNO.ReadOnly = false;
			this.txtWNO.MaxLength = 0;
			this.txtWNO.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtWNO.Multiline = false;
			this.txtWNO.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtWNO.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtWNO.TabStop = true;
			this.txtWNO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtWNO.Name = "txtWNO";
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Text = "&Select Warehouse you wish to see/edit information for.";
			this._lbl_5.Size = new System.Drawing.Size(313, 13);
			this._lbl_5.Location = new System.Drawing.Point(8, 8);
			this._lbl_5.TabIndex = 3;
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
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(403, 68);
			this._Shape1_2.Location = new System.Drawing.Point(8, 23);
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_2.BorderWidth = 1;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_2.Visible = true;
			this._Shape1_2.Name = "_Shape1_2";
			this.Controls.Add(cmbMWNo);
			this.Controls.Add(cmdExit);
			this.Controls.Add(txtWNO);
			this.Controls.Add(_lbl_5);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.Controls.Add(ShapeContainer1);
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			this.Shape1.SetIndex(_Shape1_2, Convert.ToInt16(2));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
