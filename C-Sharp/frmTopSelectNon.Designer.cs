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
	partial class frmTopSelectNon
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmTopSelectNon() : base()
		{
			Load += frmTopSelectNon_Load;
			Leave += frmTopSelectNon_Leave;
			KeyPress += frmTopSelectNon_KeyPress;
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
		public System.Windows.Forms.Label lblGroup;
		public System.Windows.Forms.GroupBox _Frame1_2;
		public System.Windows.Forms.ComboBox cmbSort;
		public System.Windows.Forms.ComboBox cmbSortField;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.GroupBox _Frame1_1;
		public System.Windows.Forms.CheckBox chkPageBreak;
		public System.Windows.Forms.ComboBox cmbGroup;
		public System.Windows.Forms.RadioButton _optType_0;
		public System.Windows.Forms.RadioButton _optType_1;
		public System.Windows.Forms.RadioButton _optType_2;
		public System.Windows.Forms.Label _lbl_3;
		public System.Windows.Forms.GroupBox _Frame1_0;
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
		//Public WithEvents Frame1 As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents optType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTopSelectNon));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this._Frame1_2 = new System.Windows.Forms.GroupBox();
			this.cmdGroup = new System.Windows.Forms.Button();
			this.lblGroup = new System.Windows.Forms.Label();
			this._Frame1_1 = new System.Windows.Forms.GroupBox();
			this.cmbSort = new System.Windows.Forms.ComboBox();
			this.cmbSortField = new System.Windows.Forms.ComboBox();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._Frame1_0 = new System.Windows.Forms.GroupBox();
			this.chkPageBreak = new System.Windows.Forms.CheckBox();
			this.cmbGroup = new System.Windows.Forms.ComboBox();
			this._optType_0 = new System.Windows.Forms.RadioButton();
			this._optType_1 = new System.Windows.Forms.RadioButton();
			this._optType_2 = new System.Windows.Forms.RadioButton();
			this._lbl_3 = new System.Windows.Forms.Label();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdLoad = new System.Windows.Forms.Button();
			//Me.Frame1 = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.optType = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
			this._Frame1_2.SuspendLayout();
			this._Frame1_1.SuspendLayout();
			this._Frame1_0.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.Frame1).BeginInit();
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.optType).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Product Non-Performance";
			this.ClientSize = new System.Drawing.Size(252, 465);
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
			this.Name = "frmTopSelectNon";
			this._Frame1_2.Text = "&3. Report Filter";
			this._Frame1_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_2.Size = new System.Drawing.Size(232, 145);
			this._Frame1_2.Location = new System.Drawing.Point(12, 249);
			this._Frame1_2.TabIndex = 12;
			this._Frame1_2.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_2.Enabled = true;
			this._Frame1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_2.Visible = true;
			this._Frame1_2.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_2.Name = "_Frame1_2";
			this.cmdGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdGroup.Text = "&Filter";
			this.cmdGroup.Size = new System.Drawing.Size(97, 31);
			this.cmdGroup.Location = new System.Drawing.Point(129, 105);
			this.cmdGroup.TabIndex = 14;
			this.cmdGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGroup.CausesValidation = true;
			this.cmdGroup.Enabled = true;
			this.cmdGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGroup.TabStop = true;
			this.cmdGroup.Name = "cmdGroup";
			this.lblGroup.BackColor = System.Drawing.Color.FromArgb(192, 192, 192);
			this.lblGroup.Text = "lblGroup";
			this.lblGroup.Size = new System.Drawing.Size(220, 76);
			this.lblGroup.Location = new System.Drawing.Point(6, 21);
			this.lblGroup.TabIndex = 13;
			this.lblGroup.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblGroup.Enabled = true;
			this.lblGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblGroup.UseMnemonic = true;
			this.lblGroup.Visible = true;
			this.lblGroup.AutoSize = false;
			this.lblGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblGroup.Name = "lblGroup";
			this._Frame1_1.Text = "&2. Report Sort Order";
			this._Frame1_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_1.Size = new System.Drawing.Size(232, 85);
			this._Frame1_1.Location = new System.Drawing.Point(12, 156);
			this._Frame1_1.TabIndex = 7;
			this._Frame1_1.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_1.Enabled = true;
			this._Frame1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_1.Visible = true;
			this._Frame1_1.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_1.Name = "_Frame1_1";
			this.cmbSort.Size = new System.Drawing.Size(115, 21);
			this.cmbSort.Location = new System.Drawing.Point(63, 48);
			this.cmbSort.Items.AddRange(new object[] {
				"Ascending",
				"Descending"
			});
			this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSort.TabIndex = 11;
			this.cmbSort.BackColor = System.Drawing.SystemColors.Window;
			this.cmbSort.CausesValidation = true;
			this.cmbSort.Enabled = true;
			this.cmbSort.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbSort.IntegralHeight = true;
			this.cmbSort.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbSort.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbSort.Sorted = false;
			this.cmbSort.TabStop = true;
			this.cmbSort.Visible = true;
			this.cmbSort.Name = "cmbSort";
			this.cmbSortField.Size = new System.Drawing.Size(115, 21);
			this.cmbSortField.Location = new System.Drawing.Point(63, 24);
			this.cmbSortField.Items.AddRange(new object[] {
				"Item Name",
				"Cost",
				"Selling",
				"Gross Profit",
				"Gross Profit %",
				"Quantity Sold"
			});
			this.cmbSortField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSortField.TabIndex = 9;
			this.cmbSortField.BackColor = System.Drawing.SystemColors.Window;
			this.cmbSortField.CausesValidation = true;
			this.cmbSortField.Enabled = true;
			this.cmbSortField.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbSortField.IntegralHeight = true;
			this.cmbSortField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbSortField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbSortField.Sorted = false;
			this.cmbSortField.TabStop = true;
			this.cmbSortField.Visible = true;
			this.cmbSortField.Name = "cmbSortField";
			this._lbl_0.Text = "Sort Field:";
			this._lbl_0.Size = new System.Drawing.Size(47, 13);
			this._lbl_0.Location = new System.Drawing.Point(12, 30);
			this._lbl_0.TabIndex = 8;
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
			this._lbl_2.Text = "Sort Order:";
			this._lbl_2.Size = new System.Drawing.Size(51, 13);
			this._lbl_2.Location = new System.Drawing.Point(9, 54);
			this._lbl_2.TabIndex = 10;
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
			this._Frame1_0.Text = "&1. Report Options";
			this._Frame1_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_0.Size = new System.Drawing.Size(232, 139);
			this._Frame1_0.Location = new System.Drawing.Point(12, 9);
			this._Frame1_0.TabIndex = 0;
			this._Frame1_0.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_0.Enabled = true;
			this._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_0.Visible = true;
			this._Frame1_0.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_0.Name = "_Frame1_0";
			this.chkPageBreak.Text = "Page Break after each Group.";
			this.chkPageBreak.Enabled = false;
			this.chkPageBreak.Size = new System.Drawing.Size(163, 13);
			this.chkPageBreak.Location = new System.Drawing.Point(54, 114);
			this.chkPageBreak.TabIndex = 6;
			this.chkPageBreak.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkPageBreak.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkPageBreak.BackColor = System.Drawing.SystemColors.Control;
			this.chkPageBreak.CausesValidation = true;
			this.chkPageBreak.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkPageBreak.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkPageBreak.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkPageBreak.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkPageBreak.TabStop = true;
			this.chkPageBreak.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkPageBreak.Visible = true;
			this.chkPageBreak.Name = "chkPageBreak";
			this.cmbGroup.Enabled = false;
			this.cmbGroup.Size = new System.Drawing.Size(106, 21);
			this.cmbGroup.Location = new System.Drawing.Point(108, 93);
			this.cmbGroup.Items.AddRange(new object[] {
				"Pricing Group",
				"Stock Group",
				"Supplier",
				"Report Group"
			});
			this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGroup.TabIndex = 5;
			this.cmbGroup.BackColor = System.Drawing.SystemColors.Window;
			this.cmbGroup.CausesValidation = true;
			this.cmbGroup.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbGroup.IntegralHeight = true;
			this.cmbGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbGroup.Sorted = false;
			this.cmbGroup.TabStop = true;
			this.cmbGroup.Visible = true;
			this.cmbGroup.Name = "cmbGroup";
			this._optType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_0.Text = "Normal Item Listing";
			this._optType_0.Size = new System.Drawing.Size(115, 13);
			this._optType_0.Location = new System.Drawing.Point(12, 21);
			this._optType_0.TabIndex = 1;
			this._optType_0.Checked = true;
			this._optType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_0.BackColor = System.Drawing.SystemColors.Control;
			this._optType_0.CausesValidation = true;
			this._optType_0.Enabled = true;
			this._optType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optType_0.TabStop = true;
			this._optType_0.Visible = true;
			this._optType_0.Name = "_optType_0";
			this._optType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_1.Text = "Items Per Group";
			this._optType_1.Size = new System.Drawing.Size(115, 13);
			this._optType_1.Location = new System.Drawing.Point(12, 39);
			this._optType_1.TabIndex = 2;
			this._optType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_1.BackColor = System.Drawing.SystemColors.Control;
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
			this._optType_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_2.Text = "Group Totals";
			this._optType_2.Size = new System.Drawing.Size(115, 13);
			this._optType_2.Location = new System.Drawing.Point(12, 57);
			this._optType_2.TabIndex = 3;
			this._optType_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_2.BackColor = System.Drawing.SystemColors.Control;
			this._optType_2.CausesValidation = true;
			this._optType_2.Enabled = true;
			this._optType_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optType_2.TabStop = true;
			this._optType_2.Checked = false;
			this._optType_2.Visible = true;
			this._optType_2.Name = "_optType_2";
			this._lbl_3.Text = "Group on:";
			this._lbl_3.Size = new System.Drawing.Size(47, 13);
			this._lbl_3.Location = new System.Drawing.Point(54, 96);
			this._lbl_3.TabIndex = 4;
			this._lbl_3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_3.BackColor = System.Drawing.Color.Transparent;
			this._lbl_3.Enabled = true;
			this._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_3.UseMnemonic = true;
			this._lbl_3.Visible = true;
			this._lbl_3.AutoSize = true;
			this._lbl_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_3.Name = "_lbl_3";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(79, 43);
			this.cmdExit.Location = new System.Drawing.Point(12, 408);
			this.cmdExit.TabIndex = 16;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.TabStop = true;
			this.cmdExit.Name = "cmdExit";
			this.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdLoad.Text = "Show/&Print Report";
			this.cmdLoad.Size = new System.Drawing.Size(79, 43);
			this.cmdLoad.Location = new System.Drawing.Point(164, 408);
			this.cmdLoad.TabIndex = 15;
			this.cmdLoad.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLoad.CausesValidation = true;
			this.cmdLoad.Enabled = true;
			this.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLoad.TabStop = true;
			this.cmdLoad.Name = "cmdLoad";
			this.Controls.Add(_Frame1_2);
			this.Controls.Add(_Frame1_1);
			this.Controls.Add(_Frame1_0);
			this.Controls.Add(cmdExit);
			this.Controls.Add(cmdLoad);
			this._Frame1_2.Controls.Add(cmdGroup);
			this._Frame1_2.Controls.Add(lblGroup);
			this._Frame1_1.Controls.Add(cmbSort);
			this._Frame1_1.Controls.Add(cmbSortField);
			this._Frame1_1.Controls.Add(_lbl_0);
			this._Frame1_1.Controls.Add(_lbl_2);
			this._Frame1_0.Controls.Add(chkPageBreak);
			this._Frame1_0.Controls.Add(cmbGroup);
			this._Frame1_0.Controls.Add(_optType_0);
			this._Frame1_0.Controls.Add(_optType_1);
			this._Frame1_0.Controls.Add(_optType_2);
			this._Frame1_0.Controls.Add(_lbl_3);
			//Me.Frame1.SetIndex(_Frame1_2, CType(2, Short))
			//Me.Frame1.SetIndex(_Frame1_1, CType(1, Short))
			//Me.Frame1.SetIndex(_Frame1_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_3, CType(3, Short))
			//Me.optType.SetIndex(_optType_0, CType(0, Short))
			//Me.optType.SetIndex(_optType_1, CType(1, Short))
			//Me.optType.SetIndex(_optType_2, CType(2, Short))
			//CType(Me.optType, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Frame1, System.ComponentModel.ISupportInitialize).EndInit()
			this._Frame1_2.ResumeLayout(false);
			this._Frame1_1.ResumeLayout(false);
			this._Frame1_0.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
