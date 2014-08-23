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
	partial class frmGRVTemplate
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmGRVTemplate() : base()
		{
			Load += frmGRVTemplate_Load;
			KeyPress += frmGRVTemplate_KeyPress;
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
		private System.Windows.Forms.Button withEventsField_cmdDown;
		public System.Windows.Forms.Button cmdDown {
			get { return withEventsField_cmdDown; }
			set {
				if (withEventsField_cmdDown != null) {
					withEventsField_cmdDown.Click -= cmdDown_Click;
				}
				withEventsField_cmdDown = value;
				if (withEventsField_cmdDown != null) {
					withEventsField_cmdDown.Click += cmdDown_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdUp;
		public System.Windows.Forms.Button cmdUp {
			get { return withEventsField_cmdUp; }
			set {
				if (withEventsField_cmdUp != null) {
					withEventsField_cmdUp.Click -= cmdUp_Click;
				}
				withEventsField_cmdUp = value;
				if (withEventsField_cmdUp != null) {
					withEventsField_cmdUp.Click += cmdUp_Click;
				}
			}
		}
		private System.Windows.Forms.ListBox withEventsField_lstItem;
		public System.Windows.Forms.ListBox lstItem {
			get { return withEventsField_lstItem; }
			set {
				if (withEventsField_lstItem != null) {
					withEventsField_lstItem.DoubleClick -= lstItem_DoubleClick;
				}
				withEventsField_lstItem = value;
				if (withEventsField_lstItem != null) {
					withEventsField_lstItem.DoubleClick += lstItem_DoubleClick;
				}
			}
		}
		private System.Windows.Forms.ComboBox withEventsField_cmbTemplate;
		public System.Windows.Forms.ComboBox cmbTemplate {
			get { return withEventsField_cmbTemplate; }
			set {
				if (withEventsField_cmbTemplate != null) {
					withEventsField_cmbTemplate.SelectedIndexChanged -= cmbTemplate_SelectedIndexChanged;
				}
				withEventsField_cmbTemplate = value;
				if (withEventsField_cmbTemplate != null) {
					withEventsField_cmbTemplate.SelectedIndexChanged += cmbTemplate_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.ListBox withEventsField_lstTemplate;
		public System.Windows.Forms.ListBox lstTemplate {
			get { return withEventsField_lstTemplate; }
			set {
				if (withEventsField_lstTemplate != null) {
					withEventsField_lstTemplate.DoubleClick -= lstTemplate_DoubleClick;
				}
				withEventsField_lstTemplate = value;
				if (withEventsField_lstTemplate != null) {
					withEventsField_lstTemplate.DoubleClick += lstTemplate_DoubleClick;
				}
			}
		}
		public System.Windows.Forms.Button cmdNew;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lbl_0;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGRVTemplate));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdDown = new System.Windows.Forms.Button();
			this.cmdUp = new System.Windows.Forms.Button();
			this.lstItem = new System.Windows.Forms.ListBox();
			this.cmbTemplate = new System.Windows.Forms.ComboBox();
			this.lstTemplate = new System.Windows.Forms.ListBox();
			this.cmdNew = new System.Windows.Forms.Button();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "GRV Template Editor";
			this.ClientSize = new System.Drawing.Size(419, 382);
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
			this.Name = "frmGRVTemplate";
			this.cmdDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDown.Text = "Down";
			this.cmdDown.Size = new System.Drawing.Size(46, 70);
			this.cmdDown.Location = new System.Drawing.Point(363, 294);
			this.cmdDown.TabIndex = 5;
			this.cmdDown.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDown.CausesValidation = true;
			this.cmdDown.Enabled = true;
			this.cmdDown.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDown.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDown.TabStop = true;
			this.cmdDown.Name = "cmdDown";
			this.cmdUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUp.Text = "Up";
			this.cmdUp.Size = new System.Drawing.Size(46, 70);
			this.cmdUp.Location = new System.Drawing.Point(363, 45);
			this.cmdUp.TabIndex = 4;
			this.cmdUp.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUp.CausesValidation = true;
			this.cmdUp.Enabled = true;
			this.cmdUp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUp.TabStop = true;
			this.cmdUp.Name = "cmdUp";
			this.lstItem.Size = new System.Drawing.Size(172, 319);
			this.lstItem.Location = new System.Drawing.Point(186, 45);
			this.lstItem.TabIndex = 3;
			this.lstItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstItem.BackColor = System.Drawing.SystemColors.Window;
			this.lstItem.CausesValidation = true;
			this.lstItem.Enabled = true;
			this.lstItem.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstItem.IntegralHeight = true;
			this.lstItem.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstItem.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstItem.Sorted = false;
			this.lstItem.TabStop = true;
			this.lstItem.Visible = true;
			this.lstItem.MultiColumn = false;
			this.lstItem.Name = "lstItem";
			this.cmbTemplate.Size = new System.Drawing.Size(268, 21);
			this.cmbTemplate.Location = new System.Drawing.Point(87, 3);
			this.cmbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTemplate.TabIndex = 2;
			this.cmbTemplate.BackColor = System.Drawing.SystemColors.Window;
			this.cmbTemplate.CausesValidation = true;
			this.cmbTemplate.Enabled = true;
			this.cmbTemplate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbTemplate.IntegralHeight = true;
			this.cmbTemplate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbTemplate.Sorted = false;
			this.cmbTemplate.TabStop = true;
			this.cmbTemplate.Visible = true;
			this.cmbTemplate.Name = "cmbTemplate";
			this.lstTemplate.Size = new System.Drawing.Size(172, 319);
			this.lstTemplate.Location = new System.Drawing.Point(6, 45);
			this.lstTemplate.TabIndex = 1;
			this.lstTemplate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstTemplate.BackColor = System.Drawing.SystemColors.Window;
			this.lstTemplate.CausesValidation = true;
			this.lstTemplate.Enabled = true;
			this.lstTemplate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstTemplate.IntegralHeight = true;
			this.lstTemplate.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstTemplate.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstTemplate.Sorted = false;
			this.lstTemplate.TabStop = true;
			this.lstTemplate.Visible = true;
			this.lstTemplate.MultiColumn = false;
			this.lstTemplate.Name = "lstTemplate";
			this.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNew.Text = "New ...";
			this.cmdNew.Size = new System.Drawing.Size(49, 22);
			this.cmdNew.Location = new System.Drawing.Point(360, 3);
			this.cmdNew.TabIndex = 0;
			this.cmdNew.Visible = false;
			this.cmdNew.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNew.CausesValidation = true;
			this.cmdNew.Enabled = true;
			this.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNew.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNew.TabStop = true;
			this.cmdNew.Name = "cmdNew";
			this._lbl_2.Text = "GRV Columns :";
			this._lbl_2.Size = new System.Drawing.Size(72, 13);
			this._lbl_2.Location = new System.Drawing.Point(189, 30);
			this._lbl_2.TabIndex = 8;
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
			this._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_1.Text = "Available Columns :";
			this._lbl_1.Size = new System.Drawing.Size(92, 13);
			this._lbl_1.Location = new System.Drawing.Point(9, 30);
			this._lbl_1.TabIndex = 7;
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
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_0.Text = "GRV Tempate :";
			this._lbl_0.Size = new System.Drawing.Size(74, 13);
			this._lbl_0.Location = new System.Drawing.Point(8, 6);
			this._lbl_0.TabIndex = 6;
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
			this.Controls.Add(cmdDown);
			this.Controls.Add(cmdUp);
			this.Controls.Add(lstItem);
			this.Controls.Add(cmbTemplate);
			this.Controls.Add(lstTemplate);
			this.Controls.Add(cmdNew);
			this.Controls.Add(_lbl_2);
			this.Controls.Add(_lbl_1);
			this.Controls.Add(_lbl_0);
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
