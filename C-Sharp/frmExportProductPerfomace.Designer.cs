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
	partial class frmExportProductPerfomace
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmExportProductPerfomace() : base()
		{
			Load += frmExportProductPerfomace_Load;
			KeyPress += frmExportProductPerfomace_KeyPress;
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
		public System.Windows.Forms.RadioButton _optType_2;
		public System.Windows.Forms.RadioButton _optType_1;
		public System.Windows.Forms.RadioButton _optType_0;
		public System.Windows.Forms.ComboBox cmbGroup;
		public System.Windows.Forms.CheckBox chkPageBreak;
		public System.Windows.Forms.Label _lbl_3;
		public System.Windows.Forms.GroupBox _Frame1_0;
		public System.Windows.Forms.ComboBox cmbSortField;
		public System.Windows.Forms.ComboBox cmbSort;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.GroupBox _Frame1_1;
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
		//Public WithEvents Frame1 As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents optType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.cmdLoad = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this._Frame1_0 = new System.Windows.Forms.GroupBox();
			this._optType_2 = new System.Windows.Forms.RadioButton();
			this._optType_1 = new System.Windows.Forms.RadioButton();
			this._optType_0 = new System.Windows.Forms.RadioButton();
			this.cmbGroup = new System.Windows.Forms.ComboBox();
			this.chkPageBreak = new System.Windows.Forms.CheckBox();
			this._lbl_3 = new System.Windows.Forms.Label();
			this._Frame1_1 = new System.Windows.Forms.GroupBox();
			this.cmbSortField = new System.Windows.Forms.ComboBox();
			this.cmbSort = new System.Windows.Forms.ComboBox();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._Frame1_2 = new System.Windows.Forms.GroupBox();
			this.cmdGroup = new System.Windows.Forms.Button();
			this.lblGroup = new System.Windows.Forms.Label();
			this._Frame1_0.SuspendLayout();
			this._Frame1_1.SuspendLayout();
			this._Frame1_2.SuspendLayout();
			this.SuspendLayout();
			//
			//cmdLoad
			//
			this.cmdLoad.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLoad.Location = new System.Drawing.Point(160, 356);
			this.cmdLoad.Name = "cmdLoad";
			this.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLoad.Size = new System.Drawing.Size(79, 43);
			this.cmdLoad.TabIndex = 16;
			this.cmdLoad.Text = "Export Now";
			this.cmdLoad.UseVisualStyleBackColor = false;
			//
			//cmdExit
			//
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Location = new System.Drawing.Point(6, 356);
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Size = new System.Drawing.Size(79, 43);
			this.cmdExit.TabIndex = 15;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.UseVisualStyleBackColor = false;
			//
			//_Frame1_0
			//
			this._Frame1_0.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_0.Controls.Add(this._optType_2);
			this._Frame1_0.Controls.Add(this._optType_1);
			this._Frame1_0.Controls.Add(this._optType_0);
			this._Frame1_0.Controls.Add(this.cmbGroup);
			this._Frame1_0.Controls.Add(this.chkPageBreak);
			this._Frame1_0.Controls.Add(this._lbl_3);
			this._Frame1_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_0.Location = new System.Drawing.Point(6, 4);
			this._Frame1_0.Name = "_Frame1_0";
			this._Frame1_0.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_0.Size = new System.Drawing.Size(232, 105);
			this._Frame1_0.TabIndex = 8;
			this._Frame1_0.TabStop = false;
			this._Frame1_0.Text = "&1. Export Options";
			//
			//_optType_2
			//
			this._optType_2.BackColor = System.Drawing.SystemColors.Control;
			this._optType_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_2.Location = new System.Drawing.Point(12, 57);
			this._optType_2.Name = "_optType_2";
			this._optType_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_2.Size = new System.Drawing.Size(115, 22);
			this._optType_2.TabIndex = 13;
			this._optType_2.TabStop = true;
			this._optType_2.Text = "Group Totals";
			this._optType_2.UseVisualStyleBackColor = false;
			//
			//_optType_1
			//
			this._optType_1.BackColor = System.Drawing.SystemColors.Control;
			this._optType_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_1.Location = new System.Drawing.Point(12, 39);
			this._optType_1.Name = "_optType_1";
			this._optType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_1.Size = new System.Drawing.Size(115, 18);
			this._optType_1.TabIndex = 12;
			this._optType_1.TabStop = true;
			this._optType_1.Text = "Items Per Group";
			this._optType_1.UseVisualStyleBackColor = false;
			//
			//_optType_0
			//
			this._optType_0.BackColor = System.Drawing.SystemColors.Control;
			this._optType_0.Checked = true;
			this._optType_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_0.Location = new System.Drawing.Point(12, 21);
			this._optType_0.Name = "_optType_0";
			this._optType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_0.Size = new System.Drawing.Size(115, 20);
			this._optType_0.TabIndex = 11;
			this._optType_0.TabStop = true;
			this._optType_0.Text = "Normal Item Listing";
			this._optType_0.UseVisualStyleBackColor = false;
			//
			//cmbGroup
			//
			this.cmbGroup.BackColor = System.Drawing.SystemColors.Window;
			this.cmbGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGroup.Enabled = false;
			this.cmbGroup.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbGroup.Items.AddRange(new object[] {
				"Pricing Group",
				"Stock Group",
				"Supplier"
			});
			this.cmbGroup.Location = new System.Drawing.Point(110, 78);
			this.cmbGroup.Name = "cmbGroup";
			this.cmbGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbGroup.Size = new System.Drawing.Size(106, 22);
			this.cmbGroup.TabIndex = 10;
			//
			//chkPageBreak
			//
			this.chkPageBreak.BackColor = System.Drawing.SystemColors.Control;
			this.chkPageBreak.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkPageBreak.Enabled = false;
			this.chkPageBreak.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkPageBreak.Location = new System.Drawing.Point(30, 130);
			this.chkPageBreak.Name = "chkPageBreak";
			this.chkPageBreak.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkPageBreak.Size = new System.Drawing.Size(163, 13);
			this.chkPageBreak.TabIndex = 9;
			this.chkPageBreak.Text = "Page Break after each Group.";
			this.chkPageBreak.UseVisualStyleBackColor = false;
			this.chkPageBreak.Visible = false;
			//
			//_lbl_3
			//
			this._lbl_3.AutoSize = true;
			this._lbl_3.BackColor = System.Drawing.Color.Transparent;
			this._lbl_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_3.Location = new System.Drawing.Point(54, 82);
			this._lbl_3.Name = "_lbl_3";
			this._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_3.Size = new System.Drawing.Size(61, 14);
			this._lbl_3.TabIndex = 14;
			this._lbl_3.Text = "Group on:";
			//
			//_Frame1_1
			//
			this._Frame1_1.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_1.Controls.Add(this.cmbSortField);
			this._Frame1_1.Controls.Add(this.cmbSort);
			this._Frame1_1.Controls.Add(this._lbl_2);
			this._Frame1_1.Controls.Add(this._lbl_0);
			this._Frame1_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_1.Location = new System.Drawing.Point(6, 114);
			this._Frame1_1.Name = "_Frame1_1";
			this._Frame1_1.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_1.Size = new System.Drawing.Size(232, 85);
			this._Frame1_1.TabIndex = 3;
			this._Frame1_1.TabStop = false;
			this._Frame1_1.Text = "&2. Export Sort Options";
			//
			//cmbSortField
			//
			this.cmbSortField.BackColor = System.Drawing.SystemColors.Window;
			this.cmbSortField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbSortField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSortField.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbSortField.Items.AddRange(new object[] {
				"Item Name",
				"Cost",
				"Selling",
				"Gross Profit",
				"Gross Profit %",
				"Quantity Sold"
			});
			this.cmbSortField.Location = new System.Drawing.Point(80, 27);
			this.cmbSortField.Name = "cmbSortField";
			this.cmbSortField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbSortField.Size = new System.Drawing.Size(115, 22);
			this.cmbSortField.TabIndex = 5;
			//
			//cmbSort
			//
			this.cmbSort.BackColor = System.Drawing.SystemColors.Window;
			this.cmbSort.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSort.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbSort.Items.AddRange(new object[] {
				"Ascending",
				"Descending"
			});
			this.cmbSort.Location = new System.Drawing.Point(80, 51);
			this.cmbSort.Name = "cmbSort";
			this.cmbSort.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbSort.Size = new System.Drawing.Size(115, 22);
			this.cmbSort.TabIndex = 4;
			//
			//_lbl_2
			//
			this._lbl_2.AutoSize = true;
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Location = new System.Drawing.Point(9, 54);
			this._lbl_2.Name = "_lbl_2";
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.Size = new System.Drawing.Size(68, 14);
			this._lbl_2.TabIndex = 7;
			this._lbl_2.Text = "Sort Order:";
			//
			//_lbl_0
			//
			this._lbl_0.AutoSize = true;
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Location = new System.Drawing.Point(12, 30);
			this._lbl_0.Name = "_lbl_0";
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.Size = new System.Drawing.Size(62, 14);
			this._lbl_0.TabIndex = 6;
			this._lbl_0.Text = "Sort Field:";
			//
			//_Frame1_2
			//
			this._Frame1_2.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_2.Controls.Add(this.cmdGroup);
			this._Frame1_2.Controls.Add(this.lblGroup);
			this._Frame1_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_2.Location = new System.Drawing.Point(6, 204);
			this._Frame1_2.Name = "_Frame1_2";
			this._Frame1_2.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_2.Size = new System.Drawing.Size(232, 145);
			this._Frame1_2.TabIndex = 0;
			this._Frame1_2.TabStop = false;
			this._Frame1_2.Text = "&3. Export Filter";
			//
			//cmdGroup
			//
			this.cmdGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGroup.Location = new System.Drawing.Point(129, 105);
			this.cmdGroup.Name = "cmdGroup";
			this.cmdGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGroup.Size = new System.Drawing.Size(97, 31);
			this.cmdGroup.TabIndex = 1;
			this.cmdGroup.Text = "&Filter";
			this.cmdGroup.UseVisualStyleBackColor = false;
			//
			//lblGroup
			//
			this.lblGroup.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)));
			this.lblGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblGroup.Location = new System.Drawing.Point(6, 21);
			this.lblGroup.Name = "lblGroup";
			this.lblGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblGroup.Size = new System.Drawing.Size(220, 76);
			this.lblGroup.TabIndex = 2;
			this.lblGroup.Text = "lblGroup";
			//
			//frmExportProductPerfomace
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(243, 403);
			this.ControlBox = false;
			this.Controls.Add(this.cmdLoad);
			this.Controls.Add(this.cmdExit);
			this.Controls.Add(this._Frame1_0);
			this.Controls.Add(this._Frame1_1);
			this.Controls.Add(this._Frame1_2);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Location = new System.Drawing.Point(4, 23);
			this.Name = "frmExportProductPerfomace";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Export Product Perfomance";
			this._Frame1_0.ResumeLayout(false);
			this._Frame1_0.PerformLayout();
			this._Frame1_1.ResumeLayout(false);
			this._Frame1_1.PerformLayout();
			this._Frame1_2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
