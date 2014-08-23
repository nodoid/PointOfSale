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
	partial class frmVNC
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmVNC() : base()
		{
			Load += frmVNC_Load;
			KeyPress += frmVNC_KeyPress;
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
		public System.Windows.Forms.RadioButton _optType_0;
		public System.Windows.Forms.RadioButton _optType_1;
		public System.Windows.Forms.ImageList ilPOS;
		public System.Windows.Forms.ColumnHeader _lvPOS_ColumnHeader_1;
		public System.Windows.Forms.ColumnHeader _lvPOS_ColumnHeader_2;
		public System.Windows.Forms.ColumnHeader _lvPOS_ColumnHeader_3;
		public System.Windows.Forms.ColumnHeader _lvPOS_ColumnHeader_4;
		private System.Windows.Forms.ListView withEventsField_lvPOS;
		public System.Windows.Forms.ListView lvPOS {
			get { return withEventsField_lvPOS; }
			set {
				if (withEventsField_lvPOS != null) {
					withEventsField_lvPOS.DoubleClick -= lvPOS_DoubleClick;
					withEventsField_lvPOS.KeyPress -= lvPOS_KeyPress;
				}
				withEventsField_lvPOS = value;
				if (withEventsField_lvPOS != null) {
					withEventsField_lvPOS.DoubleClick += lvPOS_DoubleClick;
					withEventsField_lvPOS.KeyPress += lvPOS_KeyPress;
				}
			}
		}
		public System.Windows.Forms.Label _Label1_3;
		public System.Windows.Forms.Label _Label1_2;
		public System.Windows.Forms.Label _Label1_1;
		public System.Windows.Forms.Label _Label1_0;
		//Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents optType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmVNC));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdExit = new System.Windows.Forms.Button();
			this._optType_0 = new System.Windows.Forms.RadioButton();
			this._optType_1 = new System.Windows.Forms.RadioButton();
			this.ilPOS = new System.Windows.Forms.ImageList();
			this.lvPOS = new System.Windows.Forms.ListView();
			this._lvPOS_ColumnHeader_1 = new System.Windows.Forms.ColumnHeader();
			this._lvPOS_ColumnHeader_2 = new System.Windows.Forms.ColumnHeader();
			this._lvPOS_ColumnHeader_3 = new System.Windows.Forms.ColumnHeader();
			this._lvPOS_ColumnHeader_4 = new System.Windows.Forms.ColumnHeader();
			this._Label1_3 = new System.Windows.Forms.Label();
			this._Label1_2 = new System.Windows.Forms.Label();
			this._Label1_1 = new System.Windows.Forms.Label();
			this._Label1_0 = new System.Windows.Forms.Label();
			//Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.optType = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
			this.lvPOS.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.optType, System.ComponentModel.ISupportInitialize).BeginInit()
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "View another computer";
			this.ClientSize = new System.Drawing.Size(513, 339);
			this.Location = new System.Drawing.Point(3, 22);
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
			this.Name = "frmVNC";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(115, 34);
			this.cmdExit.Location = new System.Drawing.Point(387, 291);
			this.cmdExit.TabIndex = 3;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this._optType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_0.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._optType_0.Text = "&View mode";
			this._optType_0.Size = new System.Drawing.Size(115, 16);
			this._optType_0.Location = new System.Drawing.Point(27, 108);
			this._optType_0.TabIndex = 2;
			this._optType_0.TabStop = false;
			this._optType_0.Checked = true;
			this._optType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_0.CausesValidation = true;
			this._optType_0.Enabled = true;
			this._optType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optType_0.Visible = true;
			this._optType_0.Name = "_optType_0";
			this._optType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._optType_1.Text = "&Edit mode";
			this._optType_1.Size = new System.Drawing.Size(115, 16);
			this._optType_1.Location = new System.Drawing.Point(27, 180);
			this._optType_1.TabIndex = 1;
			this._optType_1.TabStop = false;
			this._optType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_1.CausesValidation = true;
			this._optType_1.Enabled = true;
			this._optType_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optType_1.Checked = false;
			this._optType_1.Visible = true;
			this._optType_1.Name = "_optType_1";
			this.ilPOS.ImageSize = new System.Drawing.Size(32, 32);
			this.ilPOS.TransparentColor = System.Drawing.Color.FromArgb(192, 192, 192);
			this.ilPOS.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilPOS.ImageStream");
			this.ilPOS.Images.SetKeyName(0, "");
			this.lvPOS.Size = new System.Drawing.Size(346, 274);
			this.lvPOS.Location = new System.Drawing.Point(156, 6);
			this.lvPOS.TabIndex = 0;
			this.lvPOS.Alignment = System.Windows.Forms.ListViewAlignment.Top;
			this.lvPOS.LabelEdit = false;
			this.lvPOS.LabelWrap = true;
			this.lvPOS.HideSelection = true;
			this.lvPOS.LargeImageList = ilPOS;
			this.lvPOS.SmallImageList = ilPOS;
			this.lvPOS.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lvPOS.BackColor = System.Drawing.SystemColors.Window;
			this.lvPOS.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lvPOS.Name = "lvPOS";
			this._lvPOS_ColumnHeader_1.Text = "POS";
			this._lvPOS_ColumnHeader_1.Width = 170;
			this._lvPOS_ColumnHeader_2.Text = "Name";
			this._lvPOS_ColumnHeader_2.Width = 170;
			this._lvPOS_ColumnHeader_3.Text = "IP Address";
			this._lvPOS_ColumnHeader_3.Width = 170;
			this._lvPOS_ColumnHeader_4.Text = "Enabled";
			this._lvPOS_ColumnHeader_4.Width = 170;
			this._Label1_3.Text = "You can control the mouse and keyboard activity from your own computer. ";
			this._Label1_3.Size = new System.Drawing.Size(121, 55);
			this._Label1_3.Location = new System.Drawing.Point(27, 195);
			this._Label1_3.TabIndex = 7;
			this._Label1_3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_3.BackColor = System.Drawing.Color.Transparent;
			this._Label1_3.Enabled = true;
			this._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_3.UseMnemonic = true;
			this._Label1_3.Visible = true;
			this._Label1_3.AutoSize = false;
			this._Label1_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_3.Name = "_Label1_3";
			this._Label1_2.Text = "You can only view the activity on the computer. No intervention is permitted.";
			this._Label1_2.Size = new System.Drawing.Size(121, 55);
			this._Label1_2.Location = new System.Drawing.Point(27, 123);
			this._Label1_2.TabIndex = 6;
			this._Label1_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_2.BackColor = System.Drawing.Color.Transparent;
			this._Label1_2.Enabled = true;
			this._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_2.UseMnemonic = true;
			this._Label1_2.Visible = true;
			this._Label1_2.AutoSize = false;
			this._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_2.Name = "_Label1_2";
			this._Label1_1.Text = "There are two modes that can be activated a description of each follows:";
			this._Label1_1.Size = new System.Drawing.Size(142, 55);
			this._Label1_1.Location = new System.Drawing.Point(6, 60);
			this._Label1_1.TabIndex = 5;
			this._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_1.BackColor = System.Drawing.Color.Transparent;
			this._Label1_1.Enabled = true;
			this._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_1.UseMnemonic = true;
			this._Label1_1.Visible = true;
			this._Label1_1.AutoSize = false;
			this._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_1.Name = "_Label1_1";
			this._Label1_0.Text = "Use the Arrow keys to move to the desired computer you wish to view and then press the Enter key.";
			this._Label1_0.Size = new System.Drawing.Size(142, 70);
			this._Label1_0.Location = new System.Drawing.Point(6, 6);
			this._Label1_0.TabIndex = 4;
			this._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_0.BackColor = System.Drawing.Color.Transparent;
			this._Label1_0.Enabled = true;
			this._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_0.UseMnemonic = true;
			this._Label1_0.Visible = true;
			this._Label1_0.AutoSize = false;
			this._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_0.Name = "_Label1_0";
			this.Controls.Add(cmdExit);
			this.Controls.Add(_optType_0);
			this.Controls.Add(_optType_1);
			this.Controls.Add(lvPOS);
			this.Controls.Add(_Label1_3);
			this.Controls.Add(_Label1_2);
			this.Controls.Add(_Label1_1);
			this.Controls.Add(_Label1_0);
			this.lvPOS.Columns.Add(_lvPOS_ColumnHeader_1);
			this.lvPOS.Columns.Add(_lvPOS_ColumnHeader_2);
			this.lvPOS.Columns.Add(_lvPOS_ColumnHeader_3);
			this.lvPOS.Columns.Add(_lvPOS_ColumnHeader_4);
			//Me.Label1.SetIndex(_Label1_3, CType(3, Short))
			//Me.Label1.SetIndex(_Label1_2, CType(2, Short))
			//Me.Label1.SetIndex(_Label1_1, CType(1, Short))
			//Me.Label1.SetIndex(_Label1_0, CType(0, Short))
			//Me.optType.SetIndex(_optType_0, CType(0, Short))
			//Me.optType.SetIndex(_optType_1, CType(1, Short))
			//CType(Me.optType, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
			this.lvPOS.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
