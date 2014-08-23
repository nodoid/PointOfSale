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
	partial class frmBackupDatabase
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmBackupDatabase() : base()
		{
			Load += frmBackupDatabase_Load;
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
		private System.Windows.Forms.Timer withEventsField_tmrBackup;
		public System.Windows.Forms.Timer tmrBackup {
			get { return withEventsField_tmrBackup; }
			set {
				if (withEventsField_tmrBackup != null) {
					withEventsField_tmrBackup.Tick -= tmrBackup_Tick;
				}
				withEventsField_tmrBackup = value;
				if (withEventsField_tmrBackup != null) {
					withEventsField_tmrBackup.Tick += tmrBackup_Tick;
				}
			}
		}
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmBackupDatabase));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.tmrBackup = new System.Windows.Forms.Timer(components);
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.ControlBox = false;
			this.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.ClientSize = new System.Drawing.Size(463, 95);
			this.Location = new System.Drawing.Point(3, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.BackgroundImage = (System.Drawing.Image)resources.GetObject("frmBackupDatabase.BackgroundImage");
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmBackupDatabase";
			this.tmrBackup.Enabled = false;
			this.tmrBackup.Interval = 100;
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
