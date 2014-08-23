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
	partial class frmBrokenPack
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmBrokenPack() : base()
		{
			Load += frmBrokenPack_Load;
			KeyPress += frmBrokenPack_KeyPress;
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
		public System.Windows.Forms.ComboBox cmbSize;
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
		public System.Windows.Forms.PictureBox Picture1;
		public Microsoft.VisualBasic.PowerPacks.LineShape _Line1_1;
		public Microsoft.VisualBasic.PowerPacks.LineShape _Line1_0;
		public System.Windows.Forms.Label _Label2_1;
		public System.Windows.Forms.Label lblHeading;
		public System.Windows.Forms.Label _Label2_0;
		//Public WithEvents Label2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		public LineShapeArray Line1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmBrokenPack));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmbSize = new System.Windows.Forms.ComboBox();
			this.cmdFilter = new System.Windows.Forms.Button();
			this.cmdBuild = new System.Windows.Forms.Button();
			this.Picture1 = new System.Windows.Forms.PictureBox();
			this._Line1_1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this._Line1_0 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this._Label2_1 = new System.Windows.Forms.Label();
			this.lblHeading = new System.Windows.Forms.Label();
			this._Label2_0 = new System.Windows.Forms.Label();
			//Me.Label2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.Line1 = new LineShapeArray(components);
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Line1).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = " ";
			this.ClientSize = new System.Drawing.Size(515, 332);
			this.Location = new System.Drawing.Point(3, 29);
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ControlBox = true;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmBrokenPack";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.Size = new System.Drawing.Size(106, 46);
			this.cmdPrint.Location = new System.Drawing.Point(276, 273);
			this.cmdPrint.TabIndex = 5;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.TabStop = true;
			this.cmdPrint.Name = "cmdPrint";
			this.cmbSize.Size = new System.Drawing.Size(229, 21);
			this.cmbSize.Location = new System.Drawing.Point(21, 225);
			this.cmbSize.Items.AddRange(new object[] {
				"Rebuild all broken packs",
				"1 case",
				"3/4 of a case",
				"2/3 of a case",
				"1/2 a case",
				"1/3 of a case",
				"1/4 of a case"
			});
			this.cmbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSize.TabIndex = 4;
			this.cmbSize.BackColor = System.Drawing.SystemColors.Window;
			this.cmbSize.CausesValidation = true;
			this.cmbSize.Enabled = true;
			this.cmbSize.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbSize.IntegralHeight = true;
			this.cmbSize.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbSize.Sorted = false;
			this.cmbSize.TabStop = true;
			this.cmbSize.Visible = true;
			this.cmbSize.Name = "cmbSize";
			this.cmdFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdFilter.Text = "&Filter";
			this.cmdFilter.Size = new System.Drawing.Size(79, 49);
			this.cmdFilter.Location = new System.Drawing.Point(423, 123);
			this.cmdFilter.TabIndex = 2;
			this.cmdFilter.BackColor = System.Drawing.SystemColors.Control;
			this.cmdFilter.CausesValidation = true;
			this.cmdFilter.Enabled = true;
			this.cmdFilter.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdFilter.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdFilter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdFilter.TabStop = true;
			this.cmdFilter.Name = "cmdFilter";
			this.cmdBuild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBuild.Text = "&Execute";
			this.cmdBuild.Size = new System.Drawing.Size(106, 46);
			this.cmdBuild.Location = new System.Drawing.Point(396, 273);
			this.cmdBuild.TabIndex = 6;
			this.cmdBuild.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBuild.CausesValidation = true;
			this.cmdBuild.Enabled = true;
			this.cmdBuild.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBuild.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBuild.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBuild.TabStop = true;
			this.cmdBuild.Name = "cmdBuild";
			this.Picture1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Picture1.BackColor = System.Drawing.SystemColors.Window;
			this.Picture1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Picture1.Size = new System.Drawing.Size(515, 76);
			this.Picture1.Location = new System.Drawing.Point(0, 0);
			this.Picture1.Image = (System.Drawing.Image)resources.GetObject("Picture1.Image");
			this.Picture1.TabIndex = 7;
			this.Picture1.TabStop = false;
			this.Picture1.CausesValidation = true;
			this.Picture1.Enabled = true;
			this.Picture1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Picture1.Visible = true;
			this.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Picture1.Name = "Picture1";
			this._Line1_1.X1 = 21;
			this._Line1_1.X2 = 505;
			this._Line1_1.Y1 = 255;
			this._Line1_1.Y2 = 255;
			this._Line1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Line1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Line1_1.BorderWidth = 1;
			this._Line1_1.Visible = true;
			this._Line1_1.Name = "_Line1_1";
			this._Line1_0.X1 = 21;
			this._Line1_0.X2 = 505;
			this._Line1_0.Y1 = 186;
			this._Line1_0.Y2 = 186;
			this._Line1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Line1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Line1_0.BorderWidth = 1;
			this._Line1_0.Visible = true;
			this._Line1_0.Name = "_Line1_0";
			this._Label2_1.Text = "If you have not sold what proportion of a case in the last ten days then break the case so as to order as single unit ...";
			this._Label2_1.Size = new System.Drawing.Size(478, 40);
			this._Label2_1.Location = new System.Drawing.Point(21, 195);
			this._Label2_1.TabIndex = 3;
			this._Label2_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label2_1.BackColor = System.Drawing.Color.Transparent;
			this._Label2_1.Enabled = true;
			this._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label2_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label2_1.UseMnemonic = true;
			this._Label2_1.Visible = true;
			this._Label2_1.AutoSize = false;
			this._Label2_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label2_1.Name = "_Label2_1";
			this.lblHeading.BackColor = System.Drawing.Color.White;
			this.lblHeading.Size = new System.Drawing.Size(391, 49);
			this.lblHeading.Location = new System.Drawing.Point(21, 123);
			this.lblHeading.TabIndex = 1;
			this.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblHeading.Enabled = true;
			this.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblHeading.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblHeading.UseMnemonic = true;
			this.lblHeading.Visible = true;
			this.lblHeading.AutoSize = false;
			this.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblHeading.Name = "lblHeading";
			this._Label2_0.Text = "Some suppliers do not allow you to order \"broken packs\". For example you may not order a single unit of \"Coca-cola 340ml can\". To allow liquid to assist in determining which stock items you require as a single order quantity, click on the \"Filter\" button to create an exclusion list.";
			this._Label2_0.Size = new System.Drawing.Size(478, 40);
			this._Label2_0.Location = new System.Drawing.Point(21, 81);
			this._Label2_0.TabIndex = 0;
			this._Label2_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label2_0.BackColor = System.Drawing.Color.Transparent;
			this._Label2_0.Enabled = true;
			this._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label2_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label2_0.UseMnemonic = true;
			this._Label2_0.Visible = true;
			this._Label2_0.AutoSize = false;
			this._Label2_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label2_0.Name = "_Label2_0";
			this.Controls.Add(cmdPrint);
			this.Controls.Add(cmbSize);
			this.Controls.Add(cmdFilter);
			this.Controls.Add(cmdBuild);
			this.Controls.Add(Picture1);
			this.ShapeContainer1.Shapes.Add(_Line1_1);
			this.ShapeContainer1.Shapes.Add(_Line1_0);
			this.Controls.Add(_Label2_1);
			this.Controls.Add(lblHeading);
			this.Controls.Add(_Label2_0);
			this.Controls.Add(ShapeContainer1);
			//Me.Label2.SetIndex(_Label2_1, CType(1, Short))
			//Me.Label2.SetIndex(_Label2_0, CType(0, Short))
			this.Line1.SetIndex(_Line1_1, Convert.ToInt16(1));
			this.Line1.SetIndex(_Line1_0, Convert.ToInt16(0));
			((System.ComponentModel.ISupportInitialize)this.Line1).EndInit();
			//CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
