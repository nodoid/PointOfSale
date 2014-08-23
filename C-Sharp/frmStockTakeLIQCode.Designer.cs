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
	partial class frmStockTakeLIQCode
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockTakeLIQCode() : base()
		{
			KeyPress += frmStockTakeLIQCode_KeyPress;
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			Form_Initialize_Renamed();
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
		public System.Windows.Forms.Timer Timer1;
		public System.Windows.Forms.Button Command2;
		public System.Windows.Forms.Button Command1;
		//Public WithEvents Drive1 As Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
		public System.Windows.Forms.CheckBox chkFields;
		public System.Windows.Forms.TextBox txtFields;
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
		public System.Windows.Forms.Label _lblLabels_0;
		public System.Windows.Forms.Label _lblLabels_1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public System.Windows.Forms.Label _lbl_5;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockTakeLIQCode));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.Timer1 = new System.Windows.Forms.Timer(components);
			this.Command2 = new System.Windows.Forms.Button();
			this.Command1 = new System.Windows.Forms.Button();
			//Me.Drive1 = New Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
			this.chkFields = new System.Windows.Forms.CheckBox();
			this.txtFields = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this._lblLabels_0 = new System.Windows.Forms.Label();
			this._lblLabels_1 = new System.Windows.Forms.Label();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._lbl_5 = new System.Windows.Forms.Label();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "4LIQUOR Registration";
			this.ClientSize = new System.Drawing.Size(345, 120);
			this.Location = new System.Drawing.Point(73, 22);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmStockTakeLIQCode";
			this.Timer1.Interval = 1;
			this.Timer1.Enabled = true;
			this.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command2.Text = "Close CD Tray and Register";
			this.Command2.Size = new System.Drawing.Size(151, 19);
			this.Command2.Location = new System.Drawing.Point(184, 256);
			this.Command2.TabIndex = 10;
			this.Command2.BackColor = System.Drawing.SystemColors.Control;
			this.Command2.CausesValidation = true;
			this.Command2.Enabled = true;
			this.Command2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command2.TabStop = true;
			this.Command2.Name = "Command2";
			this.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command1.Text = "Open";
			this.Command1.Size = new System.Drawing.Size(59, 19);
			this.Command1.Location = new System.Drawing.Point(216, 280);
			this.Command1.TabIndex = 8;
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.CausesValidation = true;
			this.Command1.Enabled = true;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.TabStop = true;
			this.Command1.Name = "Command1";
			//Me.Drive1.Enabled = False
			//Me.Drive1.Size = New System.Drawing.Size(111, 21)
			//Me.Drive1.Location = New System.Drawing.Point(64, 256)
			//Me.Drive1.TabIndex = 7
			//Me.Drive1.BackColor = System.Drawing.SystemColors.Window
			//Me.Drive1.CausesValidation = True
			//Me.Drive1.ForeColor = System.Drawing.SystemColors.WindowText
			//Me.Drive1.Cursor = System.Windows.Forms.Cursors.Default
			//Me.Drive1.TabStop = True
			//Me.Drive1.Visible = True
			//Me.Drive1.Name = "Drive1"
			this.chkFields.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkFields.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.chkFields.Text = "Manual :";
			this.chkFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkFields.Size = new System.Drawing.Size(68, 17);
			this.chkFields.Location = new System.Drawing.Point(264, 231);
			this.chkFields.TabIndex = 2;
			this.chkFields.CausesValidation = true;
			this.chkFields.Enabled = true;
			this.chkFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkFields.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkFields.TabStop = true;
			this.chkFields.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkFields.Visible = true;
			this.chkFields.Name = "chkFields";
			this.txtFields.AutoSize = false;
			this.txtFields.BackColor = System.Drawing.Color.White;
			this.txtFields.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.txtFields.Size = new System.Drawing.Size(270, 27);
			this.txtFields.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.txtFields.Location = new System.Drawing.Point(64, 76);
			this.txtFields.TabIndex = 1;
			this.txtFields.AcceptsReturn = true;
			this.txtFields.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtFields.CausesValidation = true;
			this.txtFields.Enabled = true;
			this.txtFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFields.HideSelection = true;
			this.txtFields.ReadOnly = false;
			this.txtFields.MaxLength = 0;
			this.txtFields.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtFields.Multiline = false;
			this.txtFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtFields.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtFields.TabStop = true;
			this.txtFields.Visible = true;
			this.txtFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFields.Name = "txtFields";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(345, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 6;
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
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.Location = new System.Drawing.Point(5, 3);
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "N&ext";
			this.cmdClose.Size = new System.Drawing.Size(81, 29);
			this.cmdClose.Location = new System.Drawing.Point(256, 2);
			this.cmdClose.TabIndex = 4;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_0.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_0.Text = "CD Drive :";
			this._lblLabels_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_0.Size = new System.Drawing.Size(49, 13);
			this._lblLabels_0.Location = new System.Drawing.Point(8, 258);
			this._lblLabels_0.TabIndex = 9;
			this._lblLabels_0.Enabled = true;
			this._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_0.UseMnemonic = true;
			this._lblLabels_0.Visible = true;
			this._lblLabels_0.AutoSize = true;
			this._lblLabels_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_0.Name = "_lblLabels_0";
			this._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_1.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_1.Text = "CD Key :";
			this._lblLabels_1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblLabels_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_1.Size = new System.Drawing.Size(51, 16);
			this._lblLabels_1.Location = new System.Drawing.Point(8, 79);
			this._lblLabels_1.TabIndex = 0;
			this._lblLabels_1.Enabled = true;
			this._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_1.UseMnemonic = true;
			this._lblLabels_1.Visible = true;
			this._lblLabels_1.AutoSize = true;
			this._lblLabels_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_1.Name = "_lblLabels_1";
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(338, 49);
			this._Shape1_2.Location = new System.Drawing.Point(4, 64);
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_2.BorderWidth = 1;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_2.Visible = true;
			this._Shape1_2.Name = "_Shape1_2";
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Text = "Please type in your 4LIQUOR CD Key. [ without dashes ]";
			this._lbl_5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_5.Size = new System.Drawing.Size(333, 21);
			this._lbl_5.Location = new System.Drawing.Point(6, 48);
			this._lbl_5.TabIndex = 3;
			this._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_5.Enabled = true;
			this._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_5.UseMnemonic = true;
			this._lbl_5.Visible = true;
			this._lbl_5.AutoSize = false;
			this._lbl_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_5.Name = "_lbl_5";
			this.Controls.Add(Command2);
			this.Controls.Add(Command1);
			//Me.Controls.Add(Drive1)
			this.Controls.Add(chkFields);
			this.Controls.Add(txtFields);
			this.Controls.Add(picButtons);
			this.Controls.Add(_lblLabels_0);
			this.Controls.Add(_lblLabels_1);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.Controls.Add(_lbl_5);
			this.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(cmdCancel);
			this.picButtons.Controls.Add(cmdClose);
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			//Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
			//Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
			this.Shape1.SetIndex(_Shape1_2, Convert.ToInt16(2));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
