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
	partial class frmCurrencySetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmCurrencySetup() : base()
		{
			FormClosed += frmCurrencySetup_FormClosed;
			KeyPress += frmCurrencySetup_KeyPress;
			Resize += frmCurrencySetup_Resize;
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
		private System.Windows.Forms.Button withEventsField_cmdSave;
		public System.Windows.Forms.Button cmdSave {
			get { return withEventsField_cmdSave; }
			set {
				if (withEventsField_cmdSave != null) {
					withEventsField_cmdSave.Click -= cmdSave_Click;
				}
				withEventsField_cmdSave = value;
				if (withEventsField_cmdSave != null) {
					withEventsField_cmdSave.Click += cmdSave_Click;
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
		private myDataGridView withEventsField_grdDataGrid = new myDataGridView();
		public myDataGridView grdDataGrid {
			get { return withEventsField_grdDataGrid; }
			set {
				if (withEventsField_grdDataGrid != null) {
					withEventsField_grdDataGrid.CurrentCellChanged -= grdDataGrid_CellValueChanged;
				}
				withEventsField_grdDataGrid = value;
				if (withEventsField_grdDataGrid != null) {
					withEventsField_grdDataGrid.CurrentCellChanged += grdDataGrid_CellValueChanged;
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
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCurrencySetup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.cmdSave = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdNew = new System.Windows.Forms.Button();
			this.grdDataGrid = new myDataGridView();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Shape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.grdDataGrid).BeginInit();
			this.Text = "Currency Setup";
			this.ClientSize = new System.Drawing.Size(419, 269);
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
			this.Name = "frmCurrencySetup";
			this.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSave.Text = "&Save";
			this.cmdSave.Enabled = false;
			this.cmdSave.Size = new System.Drawing.Size(91, 29);
			this.cmdSave.Location = new System.Drawing.Point(120, 216);
			this.cmdSave.TabIndex = 8;
			this.cmdSave.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSave.CausesValidation = true;
			this.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSave.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSave.TabStop = true;
			this.cmdSave.Name = "cmdSave";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "&Delete";
			this.cmdDelete.Size = new System.Drawing.Size(91, 29);
			this.cmdDelete.Location = new System.Drawing.Point(224, 216);
			this.cmdDelete.TabIndex = 7;
			this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelete.CausesValidation = true;
			this.cmdDelete.Enabled = true;
			this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelete.TabStop = true;
			this.cmdDelete.Name = "cmdDelete";
			this.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNew.Text = "A&dd New";
			this.cmdNew.Size = new System.Drawing.Size(91, 29);
			this.cmdNew.Location = new System.Drawing.Point(16, 216);
			this.cmdNew.TabIndex = 6;
			this.cmdNew.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNew.CausesValidation = true;
			this.cmdNew.Enabled = true;
			this.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNew.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNew.TabStop = true;
			this.cmdNew.Name = "cmdNew";
			//grdDataGrid.OcxState = CType(resources.GetObject("grdDataGrid.OcxState"), System.Windows.Forms.AxHost.State)
			this.grdDataGrid.Size = new System.Drawing.Size(401, 131);
			this.grdDataGrid.Location = new System.Drawing.Point(8, 72);
			this.grdDataGrid.TabIndex = 2;
			this.grdDataGrid.Name = "grdDataGrid";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(419, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 0;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Undo";
			this.cmdCancel.Size = new System.Drawing.Size(91, 29);
			this.cmdCancel.Location = new System.Drawing.Point(2, 2);
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.Size = new System.Drawing.Size(91, 29);
			this.cmdClose.Location = new System.Drawing.Point(320, 2);
			this.cmdClose.TabIndex = 1;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.TabStop = true;
			this.cmdClose.Name = "cmdClose";
			this.Label2.Text = "Last Update :";
			this.Label2.Size = new System.Drawing.Size(87, 15);
			this.Label2.Location = new System.Drawing.Point(0, 272);
			this.Label2.TabIndex = 4;
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.SystemColors.Control;
			this.Label2.Enabled = true;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.Label1.Text = "Available Currencies";
			this.Label1.Size = new System.Drawing.Size(127, 17);
			this.Label1.Location = new System.Drawing.Point(4, 44);
			this.Label1.TabIndex = 3;
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
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
			this.Shape1.Size = new System.Drawing.Size(413, 203);
			this.Shape1.Location = new System.Drawing.Point(2, 62);
			this.Shape1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Shape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.Shape1.BorderWidth = 1;
			this.Shape1.FillColor = System.Drawing.Color.Black;
			this.Shape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this.Shape1.Visible = true;
			this.Shape1.Name = "Shape1";
			this.Controls.Add(cmdSave);
			this.Controls.Add(cmdDelete);
			this.Controls.Add(cmdNew);
			this.Controls.Add(grdDataGrid);
			this.Controls.Add(picButtons);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.ShapeContainer1.Shapes.Add(Shape1);
			this.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(cmdCancel);
			this.picButtons.Controls.Add(cmdClose);
			((System.ComponentModel.ISupportInitialize)this.grdDataGrid).EndInit();
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
