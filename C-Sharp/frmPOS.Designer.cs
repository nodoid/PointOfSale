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
	partial class frmPOS
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmPOS() : base()
		{
			Load += frmPOS_Load;
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
		public System.Windows.Forms.TextBox _txtInteger_1;
		public System.Windows.Forms.Button cmdLocate;
		public System.Windows.Forms.TextBox _txtFields_10;
		public System.Windows.Forms.CheckBox chkKitchenMonitors;
		public System.Windows.Forms.TextBox _txtInteger_0;
		public System.Windows.Forms.TextBox _txtFloat_5;
		public System.Windows.Forms.TextBox _txtInteger_4;
		public System.Windows.Forms.TextBox _txtFields_3;
		public System.Windows.Forms.CheckBox _chkFields_2;
		public System.Windows.Forms.TextBox _txtFields_1;
		public System.Windows.Forms.Button cmdCancel;
		public System.Windows.Forms.Button cmdClose;
		public System.Windows.Forms.Label _lblLic_0;
		public System.Windows.Forms.Label _lblLic_1;
		public System.Windows.Forms.Panel picButtons;
		public myDataGridView cmbKeyboard;
		public System.Windows.Forms.OpenFileDialog CommonDialog1Open;
		public myDataGridView cmbWH;
		public System.Windows.Forms.Label _lblLabels_6;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label Label1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape2;
		public System.Windows.Forms.Label _lblLabels_2;
		public System.Windows.Forms.Label _lblLabels_0;
		public System.Windows.Forms.Label _lblLabels_5;
		public System.Windows.Forms.Label _lblLabels_4;
		public System.Windows.Forms.Label _lblLabels_3;
		public System.Windows.Forms.Label _lblLabels_1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public System.Windows.Forms.Label _lbl_5;
		//Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLic As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtFloat As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtInteger As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		public RectangleShapeArray Shape1;
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
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._txtInteger_1 = new System.Windows.Forms.TextBox();
			this.cmdLocate = new System.Windows.Forms.Button();
			this._txtFields_10 = new System.Windows.Forms.TextBox();
			this.chkKitchenMonitors = new System.Windows.Forms.CheckBox();
			this._txtInteger_0 = new System.Windows.Forms.TextBox();
			this._txtFloat_5 = new System.Windows.Forms.TextBox();
			this._txtInteger_4 = new System.Windows.Forms.TextBox();
			this._txtFields_3 = new System.Windows.Forms.TextBox();
			this._chkFields_2 = new System.Windows.Forms.CheckBox();
			this._txtFields_1 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this._lblLic_0 = new System.Windows.Forms.Label();
			this._lblLic_1 = new System.Windows.Forms.Label();
			this.CommonDialog1Open = new System.Windows.Forms.OpenFileDialog();
			this._lblLabels_6 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this._lblLabels_2 = new System.Windows.Forms.Label();
			this._lblLabels_0 = new System.Windows.Forms.Label();
			this._lblLabels_5 = new System.Windows.Forms.Label();
			this._lblLabels_4 = new System.Windows.Forms.Label();
			this._lblLabels_3 = new System.Windows.Forms.Label();
			this._lblLabels_1 = new System.Windows.Forms.Label();
			this._lbl_5 = new System.Windows.Forms.Label();
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
				this._Shape1_2
			});
			this.ShapeContainer1.Size = new System.Drawing.Size(452, 214);
			this.ShapeContainer1.TabIndex = 25;
			this.ShapeContainer1.TabStop = false;
			//
			//Shape2
			//
			this.Shape2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Shape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this.Shape2.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Shape2.FillColor = System.Drawing.Color.Black;
			this.Shape2.Location = new System.Drawing.Point(4, 180);
			this.Shape2.Name = "Shape2";
			this.Shape2.Size = new System.Drawing.Size(441, 29);
			//
			//_Shape1_2
			//
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.Location = new System.Drawing.Point(4, 56);
			this._Shape1_2.Name = "_Shape1_2";
			this._Shape1_2.Size = new System.Drawing.Size(442, 103);
			//
			//_txtInteger_1
			//
			this._txtInteger_1.AcceptsReturn = true;
			this._txtInteger_1.BackColor = System.Drawing.Color.White;
			this._txtInteger_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_1.Enabled = false;
			this._txtInteger_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_1.Location = new System.Drawing.Point(110, 248);
			this._txtInteger_1.MaxLength = 0;
			this._txtInteger_1.Name = "_txtInteger_1";
			this._txtInteger_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_1.Size = new System.Drawing.Size(246, 19);
			this._txtInteger_1.TabIndex = 22;
			this._txtInteger_1.Visible = false;
			//
			//cmdLocate
			//
			this.cmdLocate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLocate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdLocate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLocate.Location = new System.Drawing.Point(360, 248);
			this.cmdLocate.Name = "cmdLocate";
			this.cmdLocate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLocate.Size = new System.Drawing.Size(76, 19);
			this.cmdLocate.TabIndex = 20;
			this.cmdLocate.Text = "Locate ...";
			this.cmdLocate.UseVisualStyleBackColor = false;
			this.cmdLocate.Visible = false;
			//
			//_txtFields_10
			//
			this._txtFields_10.AcceptsReturn = true;
			this._txtFields_10.BackColor = System.Drawing.Color.White;
			this._txtFields_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_10.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_10.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_10.Location = new System.Drawing.Point(272, 280);
			this._txtFields_10.MaxLength = 0;
			this._txtFields_10.Name = "_txtFields_10";
			this._txtFields_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_10.Size = new System.Drawing.Size(78, 19);
			this._txtFields_10.TabIndex = 19;
			//
			//chkKitchenMonitors
			//
			this.chkKitchenMonitors.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkKitchenMonitors.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkKitchenMonitors.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkKitchenMonitors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkKitchenMonitors.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkKitchenMonitors.Location = new System.Drawing.Point(122, 186);
			this.chkKitchenMonitors.Name = "chkKitchenMonitors";
			this.chkKitchenMonitors.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkKitchenMonitors.Size = new System.Drawing.Size(317, 17);
			this.chkKitchenMonitors.TabIndex = 18;
			this.chkKitchenMonitors.Text = "Setup this Terminal as a Kitchen Monitor  ( for Drive Thru only )";
			this.chkKitchenMonitors.UseVisualStyleBackColor = false;
			//
			//_txtInteger_0
			//
			this._txtInteger_0.AcceptsReturn = true;
			this._txtInteger_0.BackColor = System.Drawing.Color.White;
			this._txtInteger_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_0.Location = new System.Drawing.Point(300, 60);
			this._txtInteger_0.MaxLength = 0;
			this._txtInteger_0.Name = "_txtInteger_0";
			this._txtInteger_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_0.Size = new System.Drawing.Size(27, 19);
			this._txtInteger_0.TabIndex = 3;
			this._txtInteger_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtFloat_5
			//
			this._txtFloat_5.AcceptsReturn = true;
			this._txtFloat_5.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_5.Location = new System.Drawing.Point(110, 104);
			this._txtFloat_5.MaxLength = 0;
			this._txtFloat_5.Name = "_txtFloat_5";
			this._txtFloat_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_5.Size = new System.Drawing.Size(78, 19);
			this._txtFloat_5.TabIndex = 10;
			this._txtFloat_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtInteger_4
			//
			this._txtInteger_4.AcceptsReturn = true;
			this._txtInteger_4.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._txtInteger_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_4.Enabled = false;
			this._txtInteger_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_4.Location = new System.Drawing.Point(362, 80);
			this._txtInteger_4.MaxLength = 0;
			this._txtInteger_4.Name = "_txtInteger_4";
			this._txtInteger_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_4.Size = new System.Drawing.Size(78, 19);
			this._txtInteger_4.TabIndex = 7;
			//
			//_txtFields_3
			//
			this._txtFields_3.AcceptsReturn = true;
			this._txtFields_3.BackColor = System.Drawing.Color.White;
			this._txtFields_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_3.Location = new System.Drawing.Point(110, 82);
			this._txtFields_3.MaxLength = 0;
			this._txtFields_3.Name = "_txtFields_3";
			this._txtFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_3.Size = new System.Drawing.Size(78, 19);
			this._txtFields_3.TabIndex = 5;
			//
			//_chkFields_2
			//
			this._chkFields_2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_2.Location = new System.Drawing.Point(10, 106);
			this._chkFields_2.Name = "_chkFields_2";
			this._chkFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_2.Size = new System.Drawing.Size(60, 17);
			this._chkFields_2.TabIndex = 8;
			this._chkFields_2.Text = "Disable:";
			this._chkFields_2.UseVisualStyleBackColor = false;
			//
			//_txtFields_1
			//
			this._txtFields_1.AcceptsReturn = true;
			this._txtFields_1.BackColor = System.Drawing.Color.White;
			this._txtFields_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_1.Location = new System.Drawing.Point(110, 60);
			this._txtFields_1.MaxLength = 0;
			this._txtFields_1.Name = "_txtFields_1";
			this._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_1.Size = new System.Drawing.Size(78, 19);
			this._txtFields_1.TabIndex = 1;
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.cmdCancel);
			this.picButtons.Controls.Add(this.cmdClose);
			this.picButtons.Controls.Add(this._lblLic_0);
			this.picButtons.Controls.Add(this._lblLic_1);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(452, 39);
			this.picButtons.TabIndex = 16;
			//
			//cmdCancel
			//
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Location = new System.Drawing.Point(5, 3);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.TabIndex = 15;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.UseVisualStyleBackColor = false;
			//
			//cmdClose
			//
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Location = new System.Drawing.Point(372, 2);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.TabIndex = 14;
			this.cmdClose.TabStop = false;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.UseVisualStyleBackColor = false;
			//
			//_lblLic_0
			//
			this._lblLic_0.BackColor = System.Drawing.Color.Red;
			this._lblLic_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLic_0.ForeColor = System.Drawing.Color.White;
			this._lblLic_0.Location = new System.Drawing.Point(176, 8);
			this._lblLic_0.Name = "_lblLic_0";
			this._lblLic_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLic_0.Size = new System.Drawing.Size(113, 19);
			this._lblLic_0.TabIndex = 25;
			this._lblLic_0.Text = "Not Licensed";
			this._lblLic_0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblLic_0.Visible = false;
			//
			//_lblLic_1
			//
			this._lblLic_1.BackColor = System.Drawing.Color.Red;
			this._lblLic_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLic_1.ForeColor = System.Drawing.Color.White;
			this._lblLic_1.Location = new System.Drawing.Point(120, 3);
			this._lblLic_1.Name = "_lblLic_1";
			this._lblLic_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLic_1.Size = new System.Drawing.Size(217, 27);
			this._lblLic_1.TabIndex = 26;
			this._lblLic_1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblLic_1.Visible = false;
			//
			//CommonDialog1Open
			//
			this.CommonDialog1Open.FileName = "waitron.mdb";
			this.CommonDialog1Open.Title = "Path to Waitron dabatase";
			//
			//_lblLabels_6
			//
			this._lblLabels_6.AutoSize = true;
			this._lblLabels_6.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_6.Location = new System.Drawing.Point(10, 131);
			this._lblLabels_6.Name = "_lblLabels_6";
			this._lblLabels_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_6.Size = new System.Drawing.Size(65, 13);
			this._lblLabels_6.TabIndex = 24;
			this._lblLabels_6.Text = "Warehouse:";
			this._lblLabels_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_0
			//
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Location = new System.Drawing.Point(10, 250);
			this._lbl_0.Name = "_lbl_0";
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.Size = new System.Drawing.Size(94, 13);
			this._lbl_0.TabIndex = 21;
			this._lbl_0.Text = "Server Path:";
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_0.Visible = false;
			//
			//Label1
			//
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(6, 166);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(117, 15);
			this.Label1.TabIndex = 17;
			this.Label1.Text = "&2. Kitchen Monitors";
			//
			//_lblLabels_2
			//
			this._lblLabels_2.AutoSize = true;
			this._lblLabels_2.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_2.Location = new System.Drawing.Point(230, 63);
			this._lblLabels_2.Name = "_lblLabels_2";
			this._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_2.Size = new System.Drawing.Size(72, 13);
			this._lblLabels_2.TabIndex = 2;
			this._lblLabels_2.Text = "POS Number:";
			this._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_0
			//
			this._lblLabels_0.AutoSize = true;
			this._lblLabels_0.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_0.Location = new System.Drawing.Point(204, 108);
			this._lblLabels_0.Name = "_lblLabels_0";
			this._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_0.Size = new System.Drawing.Size(92, 13);
			this._lblLabels_0.TabIndex = 11;
			this._lblLabels_0.Text = "Default Keyboard:";
			this._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_5
			//
			this._lblLabels_5.AutoSize = true;
			this._lblLabels_5.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_5.Location = new System.Drawing.Point(80, 108);
			this._lblLabels_5.Name = "_lblLabels_5";
			this._lblLabels_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_5.Size = new System.Drawing.Size(33, 13);
			this._lblLabels_5.TabIndex = 9;
			this._lblLabels_5.Text = "Float:";
			this._lblLabels_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_4
			//
			this._lblLabels_4.AutoSize = true;
			this._lblLabels_4.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_4.Location = new System.Drawing.Point(271, 84);
			this._lblLabels_4.Name = "_lblLabels_4";
			this._lblLabels_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_4.Size = new System.Drawing.Size(87, 13);
			this._lblLabels_4.TabIndex = 6;
			this._lblLabels_4.Text = "Last Declaration:";
			this._lblLabels_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_3
			//
			this._lblLabels_3.AutoSize = true;
			this._lblLabels_3.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_3.Location = new System.Drawing.Point(26, 84);
			this._lblLabels_3.Name = "_lblLabels_3";
			this._lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_3.Size = new System.Drawing.Size(86, 13);
			this._lblLabels_3.TabIndex = 4;
			this._lblLabels_3.Text = "POS IP Address:";
			this._lblLabels_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_1
			//
			this._lblLabels_1.AutoSize = true;
			this._lblLabels_1.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_1.Location = new System.Drawing.Point(48, 63);
			this._lblLabels_1.Name = "_lblLabels_1";
			this._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_1.Size = new System.Drawing.Size(63, 13);
			this._lblLabels_1.TabIndex = 0;
			this._lblLabels_1.Text = "POS Name:";
			this._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_5
			//
			this._lbl_5.AutoSize = true;
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_5.Location = new System.Drawing.Point(6, 42);
			this._lbl_5.Name = "_lbl_5";
			this._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_5.Size = new System.Drawing.Size(56, 13);
			this._lbl_5.TabIndex = 13;
			this._lbl_5.Text = "&1. General";
			//
			//frmPOS
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.ClientSize = new System.Drawing.Size(452, 214);
			this.ControlBox = false;
			this.Controls.Add(this._txtInteger_1);
			this.Controls.Add(this.cmdLocate);
			this.Controls.Add(this._txtFields_10);
			this.Controls.Add(this.chkKitchenMonitors);
			this.Controls.Add(this._txtInteger_0);
			this.Controls.Add(this._txtFloat_5);
			this.Controls.Add(this._txtInteger_4);
			this.Controls.Add(this._txtFields_3);
			this.Controls.Add(this._chkFields_2);
			this.Controls.Add(this._txtFields_1);
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this._lblLabels_6);
			this.Controls.Add(this._lbl_0);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this._lblLabels_2);
			this.Controls.Add(this._lblLabels_0);
			this.Controls.Add(this._lblLabels_5);
			this.Controls.Add(this._lblLabels_4);
			this.Controls.Add(this._lblLabels_3);
			this.Controls.Add(this._lblLabels_1);
			this.Controls.Add(this._lbl_5);
			this.Controls.Add(this.ShapeContainer1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(73, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPOS";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edit Point Of Sale Details";
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
