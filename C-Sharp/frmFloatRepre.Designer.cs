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
	partial class frmFloatRepre
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmFloatRepre() : base()
		{
			Load += frmFloatRepre_Load;
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
		public System.Windows.Forms.ComboBox cbmChangeType;
		public System.Windows.Forms.TextBox _txtFloat_3;
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
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.CheckBox chkDisable;
		public System.Windows.Forms.TextBox _txtFloat_2;
		public System.Windows.Forms.TextBox _txtFloat_0;
		public System.Windows.Forms.TextBox _txtFloat_1;
		private System.Windows.Forms.CheckBox withEventsField_chkKey;
		public System.Windows.Forms.CheckBox chkKey {
			get { return withEventsField_chkKey; }
			set {
				if (withEventsField_chkKey != null) {
					withEventsField_chkKey.CheckStateChanged -= chkKey_CheckStateChanged;
				}
				withEventsField_chkKey = value;
				if (withEventsField_chkKey != null) {
					withEventsField_chkKey.CheckStateChanged += chkKey_CheckStateChanged;
				}
			}
		}
		public System.Windows.Forms.TextBox _txtKey_0;
		public System.Windows.Forms.TextBox _txtKey_1;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label9;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape2;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape1;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label7;
		//Public WithEvents txtFloat As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtKey As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
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
			this.Shape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.Shape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.cbmChangeType = new System.Windows.Forms.ComboBox();
			this._txtFloat_3 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.Command1 = new System.Windows.Forms.Button();
			this.chkDisable = new System.Windows.Forms.CheckBox();
			this._txtFloat_2 = new System.Windows.Forms.TextBox();
			this._txtFloat_0 = new System.Windows.Forms.TextBox();
			this._txtFloat_1 = new System.Windows.Forms.TextBox();
			this.chkKey = new System.Windows.Forms.CheckBox();
			this._txtKey_0 = new System.Windows.Forms.TextBox();
			this._txtKey_1 = new System.Windows.Forms.TextBox();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			//
			//ShapeContainer1
			//
			this.ShapeContainer1.Location = new System.Drawing.Point(0, 0);
			this.ShapeContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.ShapeContainer1.Name = "ShapeContainer1";
			this.ShapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
				this.Shape2,
				this.Shape1
			});
			this.ShapeContainer1.Size = new System.Drawing.Size(343, 231);
			this.ShapeContainer1.TabIndex = 20;
			this.ShapeContainer1.TabStop = false;
			//
			//Shape2
			//
			this.Shape2.BackColor = System.Drawing.SystemColors.Window;
			this.Shape2.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Shape2.FillColor = System.Drawing.Color.Black;
			this.Shape2.Location = new System.Drawing.Point(4, 160);
			this.Shape2.Name = "Shape2";
			this.Shape2.Size = new System.Drawing.Size(337, 67);
			//
			//Shape1
			//
			this.Shape1.BackColor = System.Drawing.SystemColors.Window;
			this.Shape1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Shape1.FillColor = System.Drawing.Color.Black;
			this.Shape1.Location = new System.Drawing.Point(4, 66);
			this.Shape1.Name = "Shape1";
			this.Shape1.Size = new System.Drawing.Size(337, 75);
			//
			//cbmChangeType
			//
			this.cbmChangeType.BackColor = System.Drawing.SystemColors.Window;
			this.cbmChangeType.Cursor = System.Windows.Forms.Cursors.Default;
			this.cbmChangeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbmChangeType.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cbmChangeType.Items.AddRange(new object[] {
				"Coin",
				"Note"
			});
			this.cbmChangeType.Location = new System.Drawing.Point(256, 92);
			this.cbmChangeType.Name = "cbmChangeType";
			this.cbmChangeType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cbmChangeType.Size = new System.Drawing.Size(79, 21);
			this.cbmChangeType.TabIndex = 18;
			//
			//_txtFloat_3
			//
			this._txtFloat_3.AcceptsReturn = true;
			this._txtFloat_3.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_3.Location = new System.Drawing.Point(70, 116);
			this._txtFloat_3.MaxLength = 0;
			this._txtFloat_3.Name = "_txtFloat_3";
			this._txtFloat_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_3.Size = new System.Drawing.Size(75, 20);
			this._txtFloat_3.TabIndex = 16;
			this._txtFloat_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.Command1);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(343, 38);
			this.picButtons.TabIndex = 14;
			//
			//Command1
			//
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Location = new System.Drawing.Point(244, 4);
			this.Command1.Name = "Command1";
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.Size = new System.Drawing.Size(93, 25);
			this.Command1.TabIndex = 15;
			this.Command1.Text = "E&xit";
			this.Command1.UseVisualStyleBackColor = false;
			//
			//chkDisable
			//
			this.chkDisable.BackColor = System.Drawing.SystemColors.Control;
			this.chkDisable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkDisable.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkDisable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkDisable.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkDisable.Location = new System.Drawing.Point(218, 120);
			this.chkDisable.Name = "chkDisable";
			this.chkDisable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkDisable.Size = new System.Drawing.Size(117, 16);
			this.chkDisable.TabIndex = 6;
			this.chkDisable.Text = "Float Disabled";
			this.chkDisable.UseVisualStyleBackColor = false;
			//
			//_txtFloat_2
			//
			this._txtFloat_2.AcceptsReturn = true;
			this._txtFloat_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_2.Enabled = false;
			this._txtFloat_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_2.Location = new System.Drawing.Point(70, 94);
			this._txtFloat_2.MaxLength = 0;
			this._txtFloat_2.Name = "_txtFloat_2";
			this._txtFloat_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_2.Size = new System.Drawing.Size(49, 20);
			this._txtFloat_2.TabIndex = 5;
			//
			//_txtFloat_0
			//
			this._txtFloat_0.AcceptsReturn = true;
			this._txtFloat_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_0.Location = new System.Drawing.Point(70, 72);
			this._txtFloat_0.MaxLength = 0;
			this._txtFloat_0.Name = "_txtFloat_0";
			this._txtFloat_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_0.Size = new System.Drawing.Size(75, 20);
			this._txtFloat_0.TabIndex = 0;
			//
			//_txtFloat_1
			//
			this._txtFloat_1.AcceptsReturn = true;
			this._txtFloat_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_1.Location = new System.Drawing.Point(288, 70);
			this._txtFloat_1.MaxLength = 0;
			this._txtFloat_1.Name = "_txtFloat_1";
			this._txtFloat_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_1.Size = new System.Drawing.Size(47, 20);
			this._txtFloat_1.TabIndex = 1;
			this._txtFloat_1.Text = "0";
			this._txtFloat_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//chkKey
			//
			this.chkKey.BackColor = System.Drawing.SystemColors.Control;
			this.chkKey.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkKey.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkKey.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkKey.Location = new System.Drawing.Point(8, 165);
			this.chkKey.Name = "chkKey";
			this.chkKey.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkKey.Size = new System.Drawing.Size(329, 19);
			this.chkKey.TabIndex = 4;
			this.chkKey.Text = "Float set as a Fast Preset Tender on POS";
			this.chkKey.UseVisualStyleBackColor = false;
			//
			//_txtKey_0
			//
			this._txtKey_0.AcceptsReturn = true;
			this._txtKey_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtKey_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtKey_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtKey_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtKey_0.Location = new System.Drawing.Point(252, 184);
			this._txtKey_0.MaxLength = 0;
			this._txtKey_0.Name = "_txtKey_0";
			this._txtKey_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtKey_0.Size = new System.Drawing.Size(85, 20);
			this._txtKey_0.TabIndex = 3;
			this._txtKey_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtKey_1
			//
			this._txtKey_1.AcceptsReturn = true;
			this._txtKey_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtKey_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtKey_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtKey_1.Enabled = false;
			this._txtKey_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtKey_1.Location = new System.Drawing.Point(252, 204);
			this._txtKey_1.MaxLength = 0;
			this._txtKey_1.Name = "_txtKey_1";
			this._txtKey_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtKey_1.Size = new System.Drawing.Size(85, 20);
			this._txtKey_1.TabIndex = 2;
			this._txtKey_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//Label8
			//
			this.Label8.BackColor = System.Drawing.Color.Transparent;
			this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label8.Location = new System.Drawing.Point(160, 96);
			this.Label8.Name = "Label8";
			this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label8.Size = new System.Drawing.Size(91, 15);
			this.Label8.TabIndex = 19;
			this.Label8.Text = "Change Float Type";
			//
			//Label9
			//
			this.Label9.BackColor = System.Drawing.Color.Transparent;
			this.Label9.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label9.Location = new System.Drawing.Point(8, 118);
			this.Label9.Name = "Label9";
			this.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label9.Size = new System.Drawing.Size(69, 15);
			this.Label9.TabIndex = 17;
			this.Label9.Text = "Float Value";
			//
			//Label1
			//
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(6, 50);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(95, 15);
			this.Label1.TabIndex = 13;
			this.Label1.Text = "1. Float Details";
			//
			//Label2
			//
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Location = new System.Drawing.Point(4, 144);
			this.Label2.Name = "Label2";
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.Size = new System.Drawing.Size(101, 15);
			this.Label2.TabIndex = 12;
			this.Label2.Text = "2. Preset Details";
			//
			//Label3
			//
			this.Label3.BackColor = System.Drawing.Color.Transparent;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Location = new System.Drawing.Point(8, 72);
			this.Label3.Name = "Label3";
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.Size = new System.Drawing.Size(77, 15);
			this.Label3.TabIndex = 11;
			this.Label3.Text = "Float Name";
			//
			//Label4
			//
			this.Label4.BackColor = System.Drawing.Color.Transparent;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label4.Location = new System.Drawing.Point(160, 74);
			this.Label4.Name = "Label4";
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.Size = new System.Drawing.Size(67, 15);
			this.Label4.TabIndex = 10;
			this.Label4.Text = "Float Pack";
			//
			//Label5
			//
			this.Label5.BackColor = System.Drawing.Color.Transparent;
			this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label5.Location = new System.Drawing.Point(8, 96);
			this.Label5.Name = "Label5";
			this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label5.Size = new System.Drawing.Size(69, 15);
			this.Label5.TabIndex = 9;
			this.Label5.Text = "Float Type";
			//
			//Label6
			//
			this.Label6.BackColor = System.Drawing.Color.Transparent;
			this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label6.Location = new System.Drawing.Point(160, 188);
			this.Label6.Name = "Label6";
			this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label6.Size = new System.Drawing.Size(93, 13);
			this.Label6.TabIndex = 8;
			this.Label6.Text = "Keyboard Name:";
			//
			//Label7
			//
			this.Label7.BackColor = System.Drawing.Color.Transparent;
			this.Label7.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label7.Location = new System.Drawing.Point(160, 206);
			this.Label7.Name = "Label7";
			this.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label7.Size = new System.Drawing.Size(89, 15);
			this.Label7.TabIndex = 7;
			this.Label7.Text = "Keyboard Key(s)";
			//
			//frmFloatRepre
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(343, 231);
			this.ControlBox = false;
			this.Controls.Add(this.cbmChangeType);
			this.Controls.Add(this._txtFloat_3);
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this.chkDisable);
			this.Controls.Add(this._txtFloat_2);
			this.Controls.Add(this._txtFloat_0);
			this.Controls.Add(this._txtFloat_1);
			this.Controls.Add(this.chkKey);
			this.Controls.Add(this._txtKey_0);
			this.Controls.Add(this._txtKey_1);
			this.Controls.Add(this.Label8);
			this.Controls.Add(this.Label9);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.ShapeContainer1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Location = new System.Drawing.Point(4, 23);
			this.Name = "frmFloatRepre";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Denomination Details";
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
