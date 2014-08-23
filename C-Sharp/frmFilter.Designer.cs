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
	partial class frmFilter
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmFilter() : base()
		{
			Load += frmFilter_Load;
			FormClosed += frmFilter_FormClosed;
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
		private System.Windows.Forms.Button withEventsField_cmdClear;
		public System.Windows.Forms.Button cmdClear {
			get { return withEventsField_cmdClear; }
			set {
				if (withEventsField_cmdClear != null) {
					withEventsField_cmdClear.Click -= cmdClear_Click;
				}
				withEventsField_cmdClear = value;
				if (withEventsField_cmdClear != null) {
					withEventsField_cmdClear.Click += cmdClear_Click;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField__txtString_0;
		public System.Windows.Forms.TextBox _txtString_0 {
			get { return withEventsField__txtString_0; }
			set {
				if (withEventsField__txtString_0 != null) {
					withEventsField__txtString_0.KeyPress -= txtString_KeyPress;
				}
				withEventsField__txtString_0 = value;
				if (withEventsField__txtString_0 != null) {
					withEventsField__txtString_0.KeyPress += txtString_KeyPress;
				}
			}
		}
		public System.Windows.Forms.GroupBox _frmString_0;
		private System.Windows.Forms.Button withEventsField__cmdList_0;
		public System.Windows.Forms.Button _cmdList_0 {
			get { return withEventsField__cmdList_0; }
			set {
				if (withEventsField__cmdList_0 != null) {
					withEventsField__cmdList_0.Click -= cmdList_Click;
					withEventsField__cmdList_0.KeyDown -= cmdList_KeyDown;
					withEventsField__cmdList_0.KeyPress -= cmdList_KeyPress;
				}
				withEventsField__cmdList_0 = value;
				if (withEventsField__cmdList_0 != null) {
					withEventsField__cmdList_0.Click += cmdList_Click;
					withEventsField__cmdList_0.KeyDown += cmdList_KeyDown;
					withEventsField__cmdList_0.KeyPress += cmdList_KeyPress;
				}
			}
		}
		public System.Windows.Forms.Label _lblList_0;
		public System.Windows.Forms.GroupBox _frmList_0;
		//Public WithEvents cmdList As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
		//Public WithEvents frmList As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//Public WithEvents frmString As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//Public WithEvents lblList As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents txtString As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFilter));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdClear = new System.Windows.Forms.Button();
			this._frmString_0 = new System.Windows.Forms.GroupBox();
			this._txtString_0 = new System.Windows.Forms.TextBox();
			this._frmList_0 = new System.Windows.Forms.GroupBox();
			this._cmdList_0 = new System.Windows.Forms.Button();
			this._lblList_0 = new System.Windows.Forms.Label();
			//Me.cmdList = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
			//Me.frmList = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			//Me.frmString = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			//Me.lblList = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.txtString = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this._frmString_0.SuspendLayout();
			this._frmList_0.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.cmdList, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.frmList, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.frmString, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblList, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtString, System.ComponentModel.ISupportInitialize).BeginInit()
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.Text = "Edit Selection Criteria";
			this.ClientSize = new System.Drawing.Size(520, 498);
			this.Location = new System.Drawing.Point(4, 23);
			this.ControlBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
			this.Name = "frmFilter";
			this.cmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClear.Text = "&Clear All";
			this.cmdClear.Size = new System.Drawing.Size(106, 31);
			this.cmdClear.Location = new System.Drawing.Point(396, 6);
			this.cmdClear.TabIndex = 5;
			this.cmdClear.TabStop = false;
			this.cmdClear.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClear.CausesValidation = true;
			this.cmdClear.Enabled = true;
			this.cmdClear.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClear.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClear.Name = "cmdClear";
			this._frmString_0.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._frmString_0.Text = "Frame1";
			this._frmString_0.Size = new System.Drawing.Size(493, 55);
			this._frmString_0.Location = new System.Drawing.Point(9, 117);
			this._frmString_0.TabIndex = 3;
			this._frmString_0.Visible = false;
			this._frmString_0.Enabled = true;
			this._frmString_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmString_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmString_0.Padding = new System.Windows.Forms.Padding(0);
			this._frmString_0.Name = "_frmString_0";
			this._txtString_0.AutoSize = false;
			this._txtString_0.Size = new System.Drawing.Size(472, 19);
			this._txtString_0.Location = new System.Drawing.Point(12, 21);
			this._txtString_0.TabIndex = 4;
			this._txtString_0.Text = "Text1";
			this._txtString_0.AcceptsReturn = true;
			this._txtString_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtString_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtString_0.CausesValidation = true;
			this._txtString_0.Enabled = true;
			this._txtString_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtString_0.HideSelection = true;
			this._txtString_0.ReadOnly = false;
			this._txtString_0.MaxLength = 0;
			this._txtString_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtString_0.Multiline = false;
			this._txtString_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtString_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtString_0.TabStop = true;
			this._txtString_0.Visible = true;
			this._txtString_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._txtString_0.Name = "_txtString_0";
			this._frmList_0.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._frmList_0.Text = "Frame1";
			this._frmList_0.Size = new System.Drawing.Size(493, 55);
			this._frmList_0.Location = new System.Drawing.Point(9, 42);
			this._frmList_0.TabIndex = 0;
			this._frmList_0.Visible = false;
			this._frmList_0.Enabled = true;
			this._frmList_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmList_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmList_0.Padding = new System.Windows.Forms.Padding(0);
			this._frmList_0.Name = "_frmList_0";
			this._cmdList_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdList_0.Text = "Build";
			this._cmdList_0.Size = new System.Drawing.Size(52, 37);
			this._cmdList_0.Location = new System.Drawing.Point(435, 12);
			this._cmdList_0.TabIndex = 1;
			this._cmdList_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdList_0.CausesValidation = true;
			this._cmdList_0.Enabled = true;
			this._cmdList_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdList_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdList_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdList_0.TabStop = true;
			this._cmdList_0.Name = "_cmdList_0";
			this._lblList_0.Text = "Label1";
			this._lblList_0.Size = new System.Drawing.Size(421, 31);
			this._lblList_0.Location = new System.Drawing.Point(9, 15);
			this._lblList_0.TabIndex = 2;
			this._lblList_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblList_0.BackColor = System.Drawing.SystemColors.Control;
			this._lblList_0.Enabled = true;
			this._lblList_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblList_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblList_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblList_0.UseMnemonic = true;
			this._lblList_0.Visible = true;
			this._lblList_0.AutoSize = false;
			this._lblList_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblList_0.Name = "_lblList_0";
			this.Controls.Add(cmdClear);
			this.Controls.Add(_frmString_0);
			this.Controls.Add(_frmList_0);
			this._frmString_0.Controls.Add(_txtString_0);
			this._frmList_0.Controls.Add(_cmdList_0);
			this._frmList_0.Controls.Add(_lblList_0);
			//Me.cmdList.SetIndex(_cmdList_0, CType(0, Short))
			//Me.frmList.SetIndex(_frmList_0, CType(0, Short))
			//Me.frmString.SetIndex(_frmString_0, CType(0, Short))
			//Me.lblList.SetIndex(_lblList_0, CType(0, Short))
			//Me.txtString.SetIndex(_txtString_0, CType(0, Short))
			//CType(Me.txtString, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblList, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.frmString, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.frmList, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.cmdList, System.ComponentModel.ISupportInitialize).EndInit()
			this._frmString_0.ResumeLayout(false);
			this._frmList_0.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
