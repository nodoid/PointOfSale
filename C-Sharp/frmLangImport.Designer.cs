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
	partial class frmLangImport
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmLangImport() : base()
		{
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
		public System.Windows.Forms.TextBox Text1;
		private System.Windows.Forms.Button withEventsField_Command1;
		public System.Windows.Forms.Button Command1 {
			get { return withEventsField_Command1; }
			set {
				if (withEventsField_Command1 != null) {
					withEventsField_Command1.Click -= Command1_Click;
				}
				withEventsField_Command1 = value;
				if (withEventsField_Command1 != null) {
					withEventsField_Command1.Click += Command1_Click;
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
		public System.Windows.Forms.ProgressBar prgUpdate;
		private System.Windows.Forms.Button withEventsField_Command3;
		public System.Windows.Forms.Button Command3 {
			get { return withEventsField_Command3; }
			set {
				if (withEventsField_Command3 != null) {
					withEventsField_Command3.Click -= Command3_Click;
				}
				withEventsField_Command3 = value;
				if (withEventsField_Command3 != null) {
					withEventsField_Command3.Click += Command3_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox txtFile;
		public System.Windows.Forms.OpenFileDialog cmdDlgOpen;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label1;
		public Microsoft.VisualBasic.PowerPacks.LineShape Line2;
		public System.Windows.Forms.Label lblHeading;
		public Microsoft.VisualBasic.PowerPacks.LineShape Line1;
		public System.Windows.Forms.Label Label2;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.Line2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.Line1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.Text1 = new System.Windows.Forms.TextBox();
			this.Command1 = new System.Windows.Forms.Button();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdClose = new System.Windows.Forms.Button();
			this.prgUpdate = new System.Windows.Forms.ProgressBar();
			this.Command3 = new System.Windows.Forms.Button();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.cmdDlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.lblHeading = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			//
			//ShapeContainer1
			//
			this.ShapeContainer1.Location = new System.Drawing.Point(0, 0);
			this.ShapeContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.ShapeContainer1.Name = "ShapeContainer1";
			this.ShapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
				this.Line2,
				this.Line1
			});
			this.ShapeContainer1.Size = new System.Drawing.Size(512, 234);
			this.ShapeContainer1.TabIndex = 11;
			this.ShapeContainer1.TabStop = false;
			//
			//Line2
			//
			this.Line2.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Line2.BorderWidth = 2;
			this.Line2.Name = "Line2";
			this.Line2.X1 = 8;
			this.Line2.X2 = 508;
			this.Line2.Y1 = 156;
			this.Line2.Y2 = 156;
			//
			//Line1
			//
			this.Line1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Line1.BorderWidth = 2;
			this.Line1.Name = "Line1";
			this.Line1.X1 = 4;
			this.Line1.X2 = 504;
			this.Line1.Y1 = 76;
			this.Line1.Y2 = 76;
			//
			//Text1
			//
			this.Text1.AcceptsReturn = true;
			this.Text1.BackColor = System.Drawing.SystemColors.Window;
			this.Text1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Text1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.Text1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Text1.Location = new System.Drawing.Point(88, 160);
			this.Text1.MaxLength = 0;
			this.Text1.Name = "Text1";
			this.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text1.Size = new System.Drawing.Size(371, 17);
			this.Text1.TabIndex = 8;
			//
			//Command1
			//
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Location = new System.Drawing.Point(476, 164);
			this.Command1.Name = "Command1";
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.Size = new System.Drawing.Size(35, 15);
			this.Command1.TabIndex = 7;
			this.Command1.Text = "...";
			this.Command1.UseVisualStyleBackColor = false;
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.cmdClose);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(512, 38);
			this.picButtons.TabIndex = 4;
			//
			//cmdClose
			//
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Location = new System.Drawing.Point(432, 2);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.TabIndex = 5;
			this.cmdClose.TabStop = false;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.UseVisualStyleBackColor = false;
			//
			//prgUpdate
			//
			this.prgUpdate.Location = new System.Drawing.Point(84, 192);
			this.prgUpdate.Maximum = 1;
			this.prgUpdate.Name = "prgUpdate";
			this.prgUpdate.Size = new System.Drawing.Size(373, 33);
			this.prgUpdate.TabIndex = 3;
			//
			//Command3
			//
			this.Command3.BackColor = System.Drawing.SystemColors.Control;
			this.Command3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command3.Location = new System.Drawing.Point(472, 84);
			this.Command3.Name = "Command3";
			this.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command3.Size = new System.Drawing.Size(35, 15);
			this.Command3.TabIndex = 2;
			this.Command3.Text = "...";
			this.Command3.UseVisualStyleBackColor = false;
			//
			//txtFile
			//
			this.txtFile.AcceptsReturn = true;
			this.txtFile.BackColor = System.Drawing.SystemColors.Window;
			this.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFile.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtFile.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFile.Location = new System.Drawing.Point(84, 80);
			this.txtFile.MaxLength = 0;
			this.txtFile.Name = "txtFile";
			this.txtFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtFile.Size = new System.Drawing.Size(371, 17);
			this.txtFile.TabIndex = 0;
			//
			//Label3
			//
			this.Label3.BackColor = System.Drawing.Color.Transparent;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(0)), Convert.ToInt32(Convert.ToByte(0)), Convert.ToInt32(Convert.ToByte(128)));
			this.Label3.Location = new System.Drawing.Point(12, 128);
			this.Label3.Name = "Label3";
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.Size = new System.Drawing.Size(495, 21);
			this.Label3.TabIndex = 10;
			this.Label3.Text = "Menu Translation  -  CSV file layout: ( MenuNo | Description )";
			//
			//Label1
			//
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(12, 162);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(65, 15);
			this.Label1.TabIndex = 9;
			this.Label1.Text = "File path";
			//
			//lblHeading
			//
			this.lblHeading.BackColor = System.Drawing.Color.Transparent;
			this.lblHeading.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblHeading.ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(0)), Convert.ToInt32(Convert.ToByte(0)), Convert.ToInt32(Convert.ToByte(128)));
			this.lblHeading.Location = new System.Drawing.Point(8, 48);
			this.lblHeading.Name = "lblHeading";
			this.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblHeading.Size = new System.Drawing.Size(495, 21);
			this.lblHeading.TabIndex = 6;
			this.lblHeading.Text = "Main Translation  -  CSV file layout: ( LanguageNo | Description )";
			//
			//Label2
			//
			this.Label2.BackColor = System.Drawing.SystemColors.Control;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Location = new System.Drawing.Point(8, 82);
			this.Label2.Name = "Label2";
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.Size = new System.Drawing.Size(65, 15);
			this.Label2.TabIndex = 1;
			this.Label2.Text = "File path";
			//
			//frmLangImport
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(512, 234);
			this.ControlBox = false;
			this.Controls.Add(this.Text1);
			this.Controls.Add(this.Command1);
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this.prgUpdate);
			this.Controls.Add(this.Command3);
			this.Controls.Add(this.txtFile);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.lblHeading);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.ShapeContainer1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Location = new System.Drawing.Point(3, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmLangImport";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Import Language Translation";
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
