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
	partial class frmMaintainWeight
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmMaintainWeight() : base()
		{
			FormClosed += frmMaintainWeight_FormClosed;
			KeyPress += frmMaintainWeight_KeyPress;
			Resize += frmMaintainWeight_Resize;
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
		private System.Windows.Forms.Button withEventsField_cmdNew;
		public System.Windows.Forms.Button cmdNew {
			get { return withEventsField_cmdNew; }
			set {
				if (withEventsField_cmdNew != null) {
					withEventsField_cmdNew.Click -= cmdNew_Click;
				}
				withEventsField_cmdNew = value;
				if (withEventsField_cmdNew != null) {
					withEventsField_cmdNew.Click += cmdNew_Click;
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
		public myDataGridView grdDataGrid;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.TextBox _txtFields_4;
		public System.Windows.Forms.TextBox _txtFields_1;
		public System.Windows.Forms.TextBox _txtFields_3;
		public System.Windows.Forms.TextBox _txtFields_2;
		public System.Windows.Forms.TextBox _txtFields_0;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape1;
		public System.Windows.Forms.GroupBox Frame2;
		//Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMaintainWeight));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdNew = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.grdDataGrid = new myDataGridView();
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this._txtFields_4 = new System.Windows.Forms.TextBox();
			this._txtFields_1 = new System.Windows.Forms.TextBox();
			this._txtFields_3 = new System.Windows.Forms.TextBox();
			this._txtFields_2 = new System.Windows.Forms.TextBox();
			this._txtFields_0 = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Shape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this.picButtons.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.Frame2.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.grdDataGrid).BeginInit();
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
			this.Text = "Maintain Scale Weight Codes";
			this.ClientSize = new System.Drawing.Size(398, 289);
			this.Location = new System.Drawing.Point(4, 23);
			this.ControlBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Enabled = true;
			this.KeyPreview = false;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmMaintainWeight";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(398, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 5;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNew.Text = "&New";
			this.cmdNew.Size = new System.Drawing.Size(79, 25);
			this.cmdNew.Location = new System.Drawing.Point(4, 4);
			this.cmdNew.TabIndex = 8;
			this.cmdNew.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNew.CausesValidation = true;
			this.cmdNew.Enabled = true;
			this.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNew.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNew.TabStop = true;
			this.cmdNew.Name = "cmdNew";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.Size = new System.Drawing.Size(79, 25);
			this.cmdClose.Location = new System.Drawing.Point(312, 4);
			this.cmdClose.TabIndex = 7;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.TabStop = true;
			this.cmdClose.Name = "cmdClose";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(79, 25);
			this.cmdCancel.Location = new System.Drawing.Point(120, 4);
			this.cmdCancel.TabIndex = 6;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.Frame1.Size = new System.Drawing.Size(391, 237);
			this.Frame1.Location = new System.Drawing.Point(2, 46);
			this.Frame1.TabIndex = 15;
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			//grdDataGrid.OcxState = CType(resources.GetObject("grdDataGrid.OcxState"), System.Windows.Forms.AxHost.State)
			this.grdDataGrid.Size = new System.Drawing.Size(373, 217);
			this.grdDataGrid.Location = new System.Drawing.Point(8, 14);
			this.grdDataGrid.TabIndex = 16;
			this.grdDataGrid.Name = "grdDataGrid";
			this.Frame2.Text = "New Weight Code";
			this.Frame2.Size = new System.Drawing.Size(391, 237);
			this.Frame2.Location = new System.Drawing.Point(2, 46);
			this.Frame2.TabIndex = 9;
			this.Frame2.BackColor = System.Drawing.SystemColors.Control;
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Visible = true;
			this.Frame2.Padding = new System.Windows.Forms.Padding(0);
			this.Frame2.Name = "Frame2";
			this._txtFields_4.AutoSize = false;
			this._txtFields_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFields_4.Size = new System.Drawing.Size(37, 19);
			this._txtFields_4.Location = new System.Drawing.Point(340, 72);
			this._txtFields_4.TabIndex = 4;
			this._txtFields_4.AcceptsReturn = true;
			this._txtFields_4.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_4.CausesValidation = true;
			this._txtFields_4.Enabled = true;
			this._txtFields_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_4.HideSelection = true;
			this._txtFields_4.ReadOnly = false;
			this._txtFields_4.MaxLength = 0;
			this._txtFields_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_4.Multiline = false;
			this._txtFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_4.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_4.TabStop = true;
			this._txtFields_4.Visible = true;
			this._txtFields_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_4.Name = "_txtFields_4";
			this._txtFields_1.AutoSize = false;
			this._txtFields_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFields_1.Size = new System.Drawing.Size(37, 19);
			this._txtFields_1.Location = new System.Drawing.Point(340, 28);
			this._txtFields_1.TabIndex = 2;
			this._txtFields_1.AcceptsReturn = true;
			this._txtFields_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_1.CausesValidation = true;
			this._txtFields_1.Enabled = true;
			this._txtFields_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_1.HideSelection = true;
			this._txtFields_1.ReadOnly = false;
			this._txtFields_1.MaxLength = 0;
			this._txtFields_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_1.Multiline = false;
			this._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_1.TabStop = true;
			this._txtFields_1.Visible = true;
			this._txtFields_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_1.Name = "_txtFields_1";
			this._txtFields_3.AutoSize = false;
			this._txtFields_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFields_3.Size = new System.Drawing.Size(37, 19);
			this._txtFields_3.Location = new System.Drawing.Point(340, 50);
			this._txtFields_3.TabIndex = 3;
			this._txtFields_3.AcceptsReturn = true;
			this._txtFields_3.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_3.CausesValidation = true;
			this._txtFields_3.Enabled = true;
			this._txtFields_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_3.HideSelection = true;
			this._txtFields_3.ReadOnly = false;
			this._txtFields_3.MaxLength = 0;
			this._txtFields_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_3.Multiline = false;
			this._txtFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_3.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_3.TabStop = true;
			this._txtFields_3.Visible = true;
			this._txtFields_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_3.Name = "_txtFields_3";
			this._txtFields_2.AutoSize = false;
			this._txtFields_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFields_2.Size = new System.Drawing.Size(37, 19);
			this._txtFields_2.Location = new System.Drawing.Point(160, 50);
			this._txtFields_2.TabIndex = 1;
			this._txtFields_2.AcceptsReturn = true;
			this._txtFields_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_2.CausesValidation = true;
			this._txtFields_2.Enabled = true;
			this._txtFields_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_2.HideSelection = true;
			this._txtFields_2.ReadOnly = false;
			this._txtFields_2.MaxLength = 0;
			this._txtFields_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_2.Multiline = false;
			this._txtFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_2.TabStop = true;
			this._txtFields_2.Visible = true;
			this._txtFields_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_2.Name = "_txtFields_2";
			this._txtFields_0.AutoSize = false;
			this._txtFields_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFields_0.Size = new System.Drawing.Size(37, 19);
			this._txtFields_0.Location = new System.Drawing.Point(160, 28);
			this._txtFields_0.TabIndex = 0;
			this._txtFields_0.AcceptsReturn = true;
			this._txtFields_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_0.CausesValidation = true;
			this._txtFields_0.Enabled = true;
			this._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_0.HideSelection = true;
			this._txtFields_0.ReadOnly = false;
			this._txtFields_0.MaxLength = 0;
			this._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_0.Multiline = false;
			this._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_0.TabStop = true;
			this._txtFields_0.Visible = true;
			this._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_0.Name = "_txtFields_0";
			this.Label5.Text = "Number of Decimals";
			this.Label5.Size = new System.Drawing.Size(131, 17);
			this.Label5.Location = new System.Drawing.Point(204, 52);
			this.Label5.TabIndex = 14;
			this.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label5.BackColor = System.Drawing.Color.Transparent;
			this.Label5.Enabled = true;
			this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label5.UseMnemonic = true;
			this.Label5.Visible = true;
			this.Label5.AutoSize = false;
			this.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label5.Name = "Label5";
			this.Label4.Text = "Price Length";
			this.Label4.Size = new System.Drawing.Size(135, 17);
			this.Label4.Location = new System.Drawing.Point(16, 52);
			this.Label4.TabIndex = 13;
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label4.BackColor = System.Drawing.Color.Transparent;
			this.Label4.Enabled = true;
			this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.UseMnemonic = true;
			this.Label4.Visible = true;
			this.Label4.AutoSize = false;
			this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label4.Name = "Label4";
			this.Label3.Text = "Check Digit";
			this.Label3.Size = new System.Drawing.Size(107, 17);
			this.Label3.Location = new System.Drawing.Point(204, 74);
			this.Label3.TabIndex = 12;
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label3.BackColor = System.Drawing.Color.Transparent;
			this.Label3.Enabled = true;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.Label2.Text = "Barcode";
			this.Label2.Size = new System.Drawing.Size(105, 17);
			this.Label2.Location = new System.Drawing.Point(204, 32);
			this.Label2.TabIndex = 11;
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Enabled = true;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.Label1.Text = "Scale Prefix";
			this.Label1.Size = new System.Drawing.Size(111, 17);
			this.Label1.Location = new System.Drawing.Point(16, 32);
			this.Label1.TabIndex = 10;
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = false;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.Shape1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.Shape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this.Shape1.Size = new System.Drawing.Size(375, 209);
			this.Shape1.Location = new System.Drawing.Point(8, 7);
			this.Shape1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Shape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.Shape1.BorderWidth = 1;
			this.Shape1.FillColor = System.Drawing.Color.Black;
			this.Shape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this.Shape1.Visible = true;
			this.Shape1.Name = "Shape1";
			this.Controls.Add(picButtons);
			this.Controls.Add(Frame1);
			this.Controls.Add(Frame2);
			this.picButtons.Controls.Add(cmdNew);
			this.picButtons.Controls.Add(cmdClose);
			this.picButtons.Controls.Add(cmdCancel);
			this.Frame1.Controls.Add(grdDataGrid);
			this.Frame2.Controls.Add(_txtFields_4);
			this.Frame2.Controls.Add(_txtFields_1);
			this.Frame2.Controls.Add(_txtFields_3);
			this.Frame2.Controls.Add(_txtFields_2);
			this.Frame2.Controls.Add(_txtFields_0);
			this.Frame2.Controls.Add(Label5);
			this.Frame2.Controls.Add(Label4);
			this.Frame2.Controls.Add(Label3);
			this.Frame2.Controls.Add(Label2);
			this.Frame2.Controls.Add(Label1);
			this.ShapeContainer1.Shapes.Add(Shape1);
			this.Frame2.Controls.Add(ShapeContainer1);
			//Me.txtFields.SetIndex(_txtFields_4, CType(4, Short))
			//Me.txtFields.SetIndex(_txtFields_1, CType(1, Short))
			//Me.txtFields.SetIndex(_txtFields_3, CType(3, Short))
			//Me.txtFields.SetIndex(_txtFields_2, CType(2, Short))
			//Me.txtFields.SetIndex(_txtFields_0, CType(0, Short))
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this.grdDataGrid).EndInit();
			this.picButtons.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.Frame2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
