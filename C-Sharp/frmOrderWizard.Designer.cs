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
	partial class frmOrderWizard
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmOrderWizard() : base()
		{
			FormClosed += frmOrderWizard_FormClosed;
			Resize += frmOrderWizard_Resize;
			Load += frmOrderWizard_Load;
			KeyPress += frmOrderWizard_KeyPress;
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
		private System.Windows.Forms.Button withEventsField_cmdUpdate;
		public System.Windows.Forms.Button cmdUpdate {
			get { return withEventsField_cmdUpdate; }
			set {
				if (withEventsField_cmdUpdate != null) {
					withEventsField_cmdUpdate.Click -= cmdUpdate_Click;
				}
				withEventsField_cmdUpdate = value;
				if (withEventsField_cmdUpdate != null) {
					withEventsField_cmdUpdate.Click += cmdUpdate_Click;
				}
			}
		}
		private System.Windows.Forms.ListView withEventsField_lvData;
		public System.Windows.Forms.ListView lvData {
			get { return withEventsField_lvData; }
			set {
				if (withEventsField_lvData != null) {
					withEventsField_lvData.ItemCheck -= lvData_ItemCheck;
				}
				withEventsField_lvData = value;
				if (withEventsField_lvData != null) {
					withEventsField_lvData.ItemCheck += lvData_ItemCheck;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdBuild;
		public System.Windows.Forms.Button cmdBuild {
			get { return withEventsField_cmdBuild; }
			set {
				if (withEventsField_cmdBuild != null) {
					withEventsField_cmdBuild.Click -= cmdBuild_Click;
				}
				withEventsField_cmdBuild = value;
				if (withEventsField_cmdBuild != null) {
					withEventsField_cmdBuild.Click += cmdBuild_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdFilter;
		public System.Windows.Forms.Button cmdFilter {
			get { return withEventsField_cmdFilter; }
			set {
				if (withEventsField_cmdFilter != null) {
					withEventsField_cmdFilter.Click -= cmdFilter_Click;
				}
				withEventsField_cmdFilter = value;
				if (withEventsField_cmdFilter != null) {
					withEventsField_cmdFilter.Click += cmdFilter_Click;
				}
			}
		}
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label lblFilter;
		public System.Windows.Forms.Label lblDayEnd;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmOrderWizard));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdUpdate = new System.Windows.Forms.Button();
			this.lvData = new System.Windows.Forms.ListView();
			this.cmdBuild = new System.Windows.Forms.Button();
			this.cmdFilter = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.lblFilter = new System.Windows.Forms.Label();
			this.lblDayEnd = new System.Windows.Forms.Label();
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Stock Re-order Wizard";
			this.ClientSize = new System.Drawing.Size(695, 468);
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
			this.Name = "frmOrderWizard";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdExit.Size = new System.Drawing.Size(79, 34);
			this.cmdExit.Location = new System.Drawing.Point(609, 3);
			this.cmdExit.TabIndex = 9;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUpdate.Text = "&Update";
			this.cmdUpdate.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdUpdate.Size = new System.Drawing.Size(79, 34);
			this.cmdUpdate.Location = new System.Drawing.Point(609, 45);
			this.cmdUpdate.TabIndex = 5;
			this.cmdUpdate.TabStop = false;
			this.cmdUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdate.CausesValidation = true;
			this.cmdUpdate.Enabled = true;
			this.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdate.Name = "cmdUpdate";
			this.lvData.Size = new System.Drawing.Size(664, 337);
			this.lvData.Location = new System.Drawing.Point(15, 114);
			this.lvData.TabIndex = 7;
			this.lvData.View = System.Windows.Forms.View.Details;
			this.lvData.LabelEdit = false;
			this.lvData.LabelWrap = true;
			this.lvData.HideSelection = true;
			this.lvData.CheckBoxes = true;
			this.lvData.FullRowSelect = true;
			this.lvData.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lvData.BackColor = System.Drawing.SystemColors.Window;
			this.lvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lvData.Name = "lvData";
			this.cmdBuild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBuild.Text = "&Build";
			this.cmdBuild.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdBuild.Size = new System.Drawing.Size(79, 34);
			this.cmdBuild.Location = new System.Drawing.Point(522, 3);
			this.cmdBuild.TabIndex = 4;
			this.cmdBuild.TabStop = false;
			this.cmdBuild.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBuild.CausesValidation = true;
			this.cmdBuild.Enabled = true;
			this.cmdBuild.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBuild.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBuild.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBuild.Name = "cmdBuild";
			this.cmdFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdFilter.Text = "&Filter";
			this.cmdFilter.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdFilter.Size = new System.Drawing.Size(79, 34);
			this.cmdFilter.Location = new System.Drawing.Point(522, 45);
			this.cmdFilter.TabIndex = 8;
			this.cmdFilter.TabStop = false;
			this.cmdFilter.BackColor = System.Drawing.SystemColors.Control;
			this.cmdFilter.CausesValidation = true;
			this.cmdFilter.Enabled = true;
			this.cmdFilter.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdFilter.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdFilter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdFilter.Name = "cmdFilter";
			this.Label1.Text = "&1. Affected Stock Items";
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label1.Size = new System.Drawing.Size(135, 13);
			this.Label1.Location = new System.Drawing.Point(18, 90);
			this.Label1.TabIndex = 6;
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = true;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_1.Text = "Applied Filter ";
			this._lbl_1.Size = new System.Drawing.Size(45, 31);
			this._lbl_1.Location = new System.Drawing.Point(6, 54);
			this._lbl_1.TabIndex = 2;
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Enabled = true;
			this._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.UseMnemonic = true;
			this._lbl_1.Visible = true;
			this._lbl_1.AutoSize = false;
			this._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_1.Name = "_lbl_1";
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_0.Text = "Day End Selection Criteria ";
			this._lbl_0.Size = new System.Drawing.Size(51, 40);
			this._lbl_0.Location = new System.Drawing.Point(0, 0);
			this._lbl_0.TabIndex = 0;
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Enabled = true;
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.UseMnemonic = true;
			this._lbl_0.Visible = true;
			this._lbl_0.AutoSize = false;
			this._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_0.Name = "_lbl_0";
			this.lblFilter.BackColor = System.Drawing.Color.White;
			this.lblFilter.Text = "Label1";
			this.lblFilter.Size = new System.Drawing.Size(460, 37);
			this.lblFilter.Location = new System.Drawing.Point(54, 42);
			this.lblFilter.TabIndex = 3;
			this.lblFilter.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblFilter.Enabled = true;
			this.lblFilter.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblFilter.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblFilter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblFilter.UseMnemonic = true;
			this.lblFilter.Visible = true;
			this.lblFilter.AutoSize = false;
			this.lblFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblFilter.Name = "lblFilter";
			this.lblDayEnd.BackColor = System.Drawing.Color.White;
			this.lblDayEnd.Text = "Label1";
			this.lblDayEnd.Size = new System.Drawing.Size(460, 37);
			this.lblDayEnd.Location = new System.Drawing.Point(54, 0);
			this.lblDayEnd.TabIndex = 1;
			this.lblDayEnd.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblDayEnd.Enabled = true;
			this.lblDayEnd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDayEnd.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDayEnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDayEnd.UseMnemonic = true;
			this.lblDayEnd.Visible = true;
			this.lblDayEnd.AutoSize = false;
			this.lblDayEnd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDayEnd.Name = "lblDayEnd";
			this._Shape1_0.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_0.Size = new System.Drawing.Size(682, 355);
			this._Shape1_0.Location = new System.Drawing.Point(6, 105);
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_0.BorderWidth = 1;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_0.Visible = true;
			this._Shape1_0.Name = "_Shape1_0";
			this.Controls.Add(cmdExit);
			this.Controls.Add(cmdUpdate);
			this.Controls.Add(lvData);
			this.Controls.Add(cmdBuild);
			this.Controls.Add(cmdFilter);
			this.Controls.Add(Label1);
			this.Controls.Add(_lbl_1);
			this.Controls.Add(_lbl_0);
			this.Controls.Add(lblFilter);
			this.Controls.Add(lblDayEnd);
			this.ShapeContainer1.Shapes.Add(_Shape1_0);
			this.Controls.Add(ShapeContainer1);
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			this.Shape1.SetIndex(_Shape1_0, Convert.ToInt16(0));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
