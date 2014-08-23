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
	partial class frmFilterOrder
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmFilterOrder() : base()
		{
			Load += frmFilterOrder_Load;
			FormClosed += frmFilterOrder_FormClosed;
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
		//Public WithEvents lblList As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFilterOrder));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this._frmList_0 = new System.Windows.Forms.GroupBox();
			this._cmdList_0 = new System.Windows.Forms.Button();
			this._lblList_0 = new System.Windows.Forms.Label();
			//Me.cmdList = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
			//Me.frmList = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			//Me.lblList = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this._frmList_0.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.cmdList, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.frmList, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblList, System.ComponentModel.ISupportInitialize).BeginInit()
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.Text = "Broken Pack Exclusion List Criteria";
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
			this.Name = "frmFilterOrder";
			this._frmList_0.Text = "Frame1";
			this._frmList_0.Size = new System.Drawing.Size(493, 55);
			this._frmList_0.Location = new System.Drawing.Point(9, 18);
			this._frmList_0.TabIndex = 0;
			this._frmList_0.Visible = false;
			this._frmList_0.BackColor = System.Drawing.SystemColors.Control;
			this._frmList_0.Enabled = true;
			this._frmList_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmList_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmList_0.Padding = new System.Windows.Forms.Padding(0);
			this._frmList_0.Name = "_frmList_0";
			this._cmdList_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdList_0.Text = "Build";
			this._cmdList_0.Size = new System.Drawing.Size(52, 37);
			this._cmdList_0.Location = new System.Drawing.Point(435, 12);
			this._cmdList_0.TabIndex = 2;
			this._cmdList_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdList_0.CausesValidation = true;
			this._cmdList_0.Enabled = true;
			this._cmdList_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdList_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdList_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdList_0.TabStop = true;
			this._cmdList_0.Name = "_cmdList_0";
			this._lblList_0.BackColor = System.Drawing.Color.White;
			this._lblList_0.Text = "Label1";
			this._lblList_0.Size = new System.Drawing.Size(421, 31);
			this._lblList_0.Location = new System.Drawing.Point(9, 15);
			this._lblList_0.TabIndex = 1;
			this._lblList_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblList_0.Enabled = true;
			this._lblList_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblList_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblList_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblList_0.UseMnemonic = true;
			this._lblList_0.Visible = true;
			this._lblList_0.AutoSize = false;
			this._lblList_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblList_0.Name = "_lblList_0";
			this.Controls.Add(_frmList_0);
			this._frmList_0.Controls.Add(_cmdList_0);
			this._frmList_0.Controls.Add(_lblList_0);
			//Me.cmdList.SetIndex(_cmdList_0, CType(0, Short))
			//Me.frmList.SetIndex(_frmList_0, CType(0, Short))
			//Me.lblList.SetIndex(_lblList_0, CType(0, Short))
			//CType(Me.lblList, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.frmList, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.cmdList, System.ComponentModel.ISupportInitialize).EndInit()
			this._frmList_0.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
