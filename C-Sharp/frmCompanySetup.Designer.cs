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
	partial class frmCompanySetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmCompanySetup() : base()
		{
			FormClosed += frmCompanySetup_FormClosed;
			KeyPress += frmCompanySetup_KeyPress;
			Resize += frmCompanySetup_Resize;
			Load += frmCompanySetup_Load;
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
		public System.Windows.Forms.CheckBox _chkFields_19;
		public System.Windows.Forms.CheckBox _chkFields_18;
		public System.Windows.Forms.CheckBox _chkFields_17;
		public System.Windows.Forms.CheckBox _chkFields_16;
		private System.Windows.Forms.Button withEventsField_cmdLocate;
		public System.Windows.Forms.Button cmdLocate {
			get { return withEventsField_cmdLocate; }
			set {
				if (withEventsField_cmdLocate != null) {
					withEventsField_cmdLocate.Click -= cmdLocate_Click;
				}
				withEventsField_cmdLocate = value;
				if (withEventsField_cmdLocate != null) {
					withEventsField_cmdLocate.Click += cmdLocate_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox _txtFields_11;
		public System.Windows.Forms.CheckBox _chkFields_15;
		public System.Windows.Forms.ComboBox cboSDK;
		public System.Windows.Forms.CheckBox _chkFields_14;
		public System.Windows.Forms.CheckBox _chkFields_13;
		public System.Windows.Forms.CheckBox _chkFields_11;
		public System.Windows.Forms.CheckBox _chkFields_10;
		public System.Windows.Forms.CheckBox _chkFields_9;
		public System.Windows.Forms.CheckBox _chkFields_8;
		public System.Windows.Forms.CheckBox _chkFields_7;
		public System.Windows.Forms.CheckBox _chkFields_6;
		public System.Windows.Forms.CheckBox _chkFields_5;
		public System.Windows.Forms.CheckBox _chkFields_4;
		public System.Windows.Forms.CheckBox _chkFields_3;
		public System.Windows.Forms.CheckBox _chkBit_13;
		public System.Windows.Forms.CheckBox _chkFields_2;
		public System.Windows.Forms.TextBox _txtFields_4;
		private System.Windows.Forms.TextBox withEventsField_txtintper;
		public System.Windows.Forms.TextBox txtintper {
			get { return withEventsField_txtintper; }
			set {
				if (withEventsField_txtintper != null) {
					withEventsField_txtintper.Leave -= txtintper_Leave;
				}
				withEventsField_txtintper = value;
				if (withEventsField_txtintper != null) {
					withEventsField_txtintper.Leave += txtintper_Leave;
				}
			}
		}
		public System.Windows.Forms.ComboBox _cboIntPer_0;
		public System.Windows.Forms.CheckBox _chkBit_12;
		private System.Windows.Forms.TextBox withEventsField_txtPeriod;
		public System.Windows.Forms.TextBox txtPeriod {
			get { return withEventsField_txtPeriod; }
			set {
				if (withEventsField_txtPeriod != null) {
					withEventsField_txtPeriod.Enter -= txtPeriod_Enter;
					withEventsField_txtPeriod.KeyPress -= txtPeriod_KeyPress;
					withEventsField_txtPeriod.Leave -= txtPeriod_Leave;
				}
				withEventsField_txtPeriod = value;
				if (withEventsField_txtPeriod != null) {
					withEventsField_txtPeriod.Enter += txtPeriod_Enter;
					withEventsField_txtPeriod.KeyPress += txtPeriod_KeyPress;
					withEventsField_txtPeriod.Leave += txtPeriod_Leave;
				}
			}
		}
		public System.Windows.Forms.CheckBox _chkBit_11;
		public System.Windows.Forms.TextBox _txtFields_3;
		public System.Windows.Forms.TextBox _txtFields_2;
		public System.Windows.Forms.TextBox _txtFields_1;
		public System.Windows.Forms.TextBox _txtFields_0;
		public System.Windows.Forms.CheckBox _chkBit_10;
		public System.Windows.Forms.CheckBox _chkBit_9;
		public System.Windows.Forms.CheckBox _chkBit_8;
		public System.Windows.Forms.CheckBox _chkBit_0;
		public System.Windows.Forms.CheckBox _chkFields_1;
		public System.Windows.Forms.CheckBox _chkBit_7;
		public System.Windows.Forms.CheckBox _chkBit_6;
		public System.Windows.Forms.CheckBox _chkBit_5;
		public System.Windows.Forms.CheckBox _chkBit_4;
		public System.Windows.Forms.CheckBox _chkBit_3;
		public System.Windows.Forms.CheckBox _chkBit_2;
		public System.Windows.Forms.CheckBox _chkBit_1;
		public System.Windows.Forms.CheckBox _chkFields_0;
		public System.Windows.Forms.CheckBox _chkFields_12;
		public System.Windows.Forms.TextBox _txtFields_14;
		public System.Windows.Forms.TextBox _txtFields_13;
		public System.Windows.Forms.TextBox _txtFields_10;
		public System.Windows.Forms.TextBox _txtFields_9;
		public System.Windows.Forms.TextBox _txtFields_8;
		public System.Windows.Forms.TextBox _txtFields_7;
		public System.Windows.Forms.TextBox _txtFields_6;
		public System.Windows.Forms.TextBox _txtFields_5;
		private System.Windows.Forms.Button withEventsField_cmdSyncParam;
		public System.Windows.Forms.Button cmdSyncParam {
			get { return withEventsField_cmdSyncParam; }
			set {
				if (withEventsField_cmdSyncParam != null) {
					withEventsField_cmdSyncParam.Click -= cmdSyncParam_Click;
				}
				withEventsField_cmdSyncParam = value;
				if (withEventsField_cmdSyncParam != null) {
					withEventsField_cmdSyncParam.Click += cmdSyncParam_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdHO;
		public System.Windows.Forms.Button cmdHO {
			get { return withEventsField_cmdHO; }
			set {
				if (withEventsField_cmdHO != null) {
					withEventsField_cmdHO.Click -= cmdHO_Click;
				}
				withEventsField_cmdHO = value;
				if (withEventsField_cmdHO != null) {
					withEventsField_cmdHO.Click += cmdHO_Click;
				}
			}
		}
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
		private System.Windows.Forms.Button withEventsField_cmdCancel;
		public System.Windows.Forms.Button cmdCancel {
			get { return withEventsField_cmdCancel; }
			set {
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click -= cmdCancel_Click;
				}
				withEventsField_cmdCancel = value;
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click += cmdCancel_Click;
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
		public myDataGridView cmbLanguage;
		public System.Windows.Forms.Label _lbl_4;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_6;
		public System.Windows.Forms.Label Label14;
		public System.Windows.Forms.Label _lblLabels_2;
		public System.Windows.Forms.Label Label13;
		public System.Windows.Forms.Label Label12;
		public System.Windows.Forms.Label Label11;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape4;
		public System.Windows.Forms.Label _lblLabels_1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape3;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label lblintrfromper;
		public System.Windows.Forms.Label lblinterestper;
		public System.Windows.Forms.Label Label7;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape2;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_5;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_4;
		public System.Windows.Forms.Label _lbl_3;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_3;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label _lblLabels_0;
		public System.Windows.Forms.Label _lblLabels_14;
		public System.Windows.Forms.Label _lblLabels_13;
		public System.Windows.Forms.Label _lblLabels_10;
		public System.Windows.Forms.Label _lblLabels_9;
		public System.Windows.Forms.Label _lblLabels_8;
		public System.Windows.Forms.Label _lblLabels_7;
		public System.Windows.Forms.Label _lblLabels_6;
		public System.Windows.Forms.Label _lblLabels_5;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public System.Windows.Forms.Label _lbl_5;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape5;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape6;
		//Public WithEvents cboIntPer As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
		//Public WithEvents chkBit As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
		//Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
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
			this._Shape1_6 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.Shape4 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.Shape3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.Shape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_5 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_4 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.Shape5 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.Shape6 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._chkFields_19 = new System.Windows.Forms.CheckBox();
			this._chkFields_18 = new System.Windows.Forms.CheckBox();
			this._chkFields_17 = new System.Windows.Forms.CheckBox();
			this._chkFields_16 = new System.Windows.Forms.CheckBox();
			this.cmdLocate = new System.Windows.Forms.Button();
			this._txtFields_11 = new System.Windows.Forms.TextBox();
			this._chkFields_15 = new System.Windows.Forms.CheckBox();
			this.cboSDK = new System.Windows.Forms.ComboBox();
			this._chkFields_14 = new System.Windows.Forms.CheckBox();
			this._chkFields_13 = new System.Windows.Forms.CheckBox();
			this._chkFields_11 = new System.Windows.Forms.CheckBox();
			this._chkFields_10 = new System.Windows.Forms.CheckBox();
			this._chkFields_9 = new System.Windows.Forms.CheckBox();
			this._chkFields_8 = new System.Windows.Forms.CheckBox();
			this._chkFields_7 = new System.Windows.Forms.CheckBox();
			this._chkFields_6 = new System.Windows.Forms.CheckBox();
			this._chkFields_5 = new System.Windows.Forms.CheckBox();
			this._chkFields_4 = new System.Windows.Forms.CheckBox();
			this._chkFields_3 = new System.Windows.Forms.CheckBox();
			this._chkBit_13 = new System.Windows.Forms.CheckBox();
			this._chkFields_2 = new System.Windows.Forms.CheckBox();
			this._txtFields_4 = new System.Windows.Forms.TextBox();
			this.txtintper = new System.Windows.Forms.TextBox();
			this._cboIntPer_0 = new System.Windows.Forms.ComboBox();
			this._chkBit_12 = new System.Windows.Forms.CheckBox();
			this.txtPeriod = new System.Windows.Forms.TextBox();
			this._chkBit_11 = new System.Windows.Forms.CheckBox();
			this._txtFields_3 = new System.Windows.Forms.TextBox();
			this._txtFields_2 = new System.Windows.Forms.TextBox();
			this._txtFields_1 = new System.Windows.Forms.TextBox();
			this._txtFields_0 = new System.Windows.Forms.TextBox();
			this._chkBit_10 = new System.Windows.Forms.CheckBox();
			this._chkBit_9 = new System.Windows.Forms.CheckBox();
			this._chkBit_8 = new System.Windows.Forms.CheckBox();
			this._chkBit_0 = new System.Windows.Forms.CheckBox();
			this._chkFields_1 = new System.Windows.Forms.CheckBox();
			this._chkBit_7 = new System.Windows.Forms.CheckBox();
			this._chkBit_6 = new System.Windows.Forms.CheckBox();
			this._chkBit_5 = new System.Windows.Forms.CheckBox();
			this._chkBit_4 = new System.Windows.Forms.CheckBox();
			this._chkBit_3 = new System.Windows.Forms.CheckBox();
			this._chkBit_2 = new System.Windows.Forms.CheckBox();
			this._chkBit_1 = new System.Windows.Forms.CheckBox();
			this._chkFields_0 = new System.Windows.Forms.CheckBox();
			this._chkFields_12 = new System.Windows.Forms.CheckBox();
			this._txtFields_14 = new System.Windows.Forms.TextBox();
			this._txtFields_13 = new System.Windows.Forms.TextBox();
			this._txtFields_10 = new System.Windows.Forms.TextBox();
			this._txtFields_9 = new System.Windows.Forms.TextBox();
			this._txtFields_8 = new System.Windows.Forms.TextBox();
			this._txtFields_7 = new System.Windows.Forms.TextBox();
			this._txtFields_6 = new System.Windows.Forms.TextBox();
			this._txtFields_5 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdSyncParam = new System.Windows.Forms.Button();
			this.cmdHO = new System.Windows.Forms.Button();
			this.Command1 = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmbLanguage = new _4PosBackOffice.NET.myDataGridView();
			this._lbl_4 = new System.Windows.Forms.Label();
			this.Label14 = new System.Windows.Forms.Label();
			this._lblLabels_2 = new System.Windows.Forms.Label();
			this.Label13 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this.Label11 = new System.Windows.Forms.Label();
			this._lblLabels_1 = new System.Windows.Forms.Label();
			this.Label10 = new System.Windows.Forms.Label();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.lblintrfromper = new System.Windows.Forms.Label();
			this.lblinterestper = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this._lbl_3 = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._lblLabels_0 = new System.Windows.Forms.Label();
			this._lblLabels_14 = new System.Windows.Forms.Label();
			this._lblLabels_13 = new System.Windows.Forms.Label();
			this._lblLabels_10 = new System.Windows.Forms.Label();
			this._lblLabels_9 = new System.Windows.Forms.Label();
			this._lblLabels_8 = new System.Windows.Forms.Label();
			this._lblLabels_7 = new System.Windows.Forms.Label();
			this._lblLabels_6 = new System.Windows.Forms.Label();
			this._lblLabels_5 = new System.Windows.Forms.Label();
			this._lbl_5 = new System.Windows.Forms.Label();
			this.Shape1 = new _4PosBackOffice.NET.RectangleShapeArray(this.components);
			this.picButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.cmbLanguage).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.SuspendLayout();
			//
			//ShapeContainer1
			//
			this.ShapeContainer1.Location = new System.Drawing.Point(0, 0);
			this.ShapeContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.ShapeContainer1.Name = "ShapeContainer1";
			this.ShapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
				this._Shape1_6,
				this.Shape4,
				this.Shape3,
				this.Shape2,
				this._Shape1_5,
				this._Shape1_4,
				this._Shape1_3,
				this._Shape1_1,
				this._Shape1_2,
				this._Shape1_0,
				this.Shape5,
				this.Shape6
			});
			this.ShapeContainer1.Size = new System.Drawing.Size(867, 720);
			this.ShapeContainer1.TabIndex = 92;
			this.ShapeContainer1.TabStop = false;
			//
			//_Shape1_6
			//
			this._Shape1_6.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_6.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_6.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_6.FillColor = System.Drawing.Color.Black;
			this.Shape1.SetIndex(this._Shape1_6, Convert.ToInt16(6));
			this._Shape1_6.Location = new System.Drawing.Point(606, 60);
			this._Shape1_6.Name = "_Shape1_6";
			this._Shape1_6.Size = new System.Drawing.Size(254, 37);
			//
			//Shape4
			//
			this.Shape4.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Shape4.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this.Shape4.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Shape4.FillColor = System.Drawing.Color.Black;
			this.Shape4.Location = new System.Drawing.Point(346, 614);
			this.Shape4.Name = "Shape4";
			this.Shape4.Size = new System.Drawing.Size(254, 47);
			//
			//Shape3
			//
			this.Shape3.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Shape3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this.Shape3.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Shape3.FillColor = System.Drawing.Color.Black;
			this.Shape3.Location = new System.Drawing.Point(3, 625);
			this.Shape3.Name = "Shape3";
			this.Shape3.Size = new System.Drawing.Size(337, 37);
			//
			//Shape2
			//
			this.Shape2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Shape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this.Shape2.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Shape2.FillColor = System.Drawing.Color.Black;
			this.Shape2.Location = new System.Drawing.Point(346, 546);
			this.Shape2.Name = "Shape2";
			this.Shape2.Size = new System.Drawing.Size(254, 53);
			//
			//_Shape1_5
			//
			this._Shape1_5.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_5.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_5.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_5.FillColor = System.Drawing.Color.Black;
			this.Shape1.SetIndex(this._Shape1_5, Convert.ToInt16(5));
			this._Shape1_5.Location = new System.Drawing.Point(346, 440);
			this._Shape1_5.Name = "_Shape1_5";
			this._Shape1_5.Size = new System.Drawing.Size(254, 93);
			//
			//_Shape1_4
			//
			this._Shape1_4.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_4.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_4.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_4.FillColor = System.Drawing.Color.Black;
			this.Shape1.SetIndex(this._Shape1_4, Convert.ToInt16(4));
			this._Shape1_4.Location = new System.Drawing.Point(346, 258);
			this._Shape1_4.Name = "_Shape1_4";
			this._Shape1_4.Size = new System.Drawing.Size(254, 165);
			//
			//_Shape1_3
			//
			this._Shape1_3.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_3.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_3.FillColor = System.Drawing.Color.Black;
			this.Shape1.SetIndex(this._Shape1_3, Convert.ToInt16(3));
			this._Shape1_3.Location = new System.Drawing.Point(346, 60);
			this._Shape1_3.Name = "_Shape1_3";
			this._Shape1_3.Size = new System.Drawing.Size(254, 182);
			//
			//_Shape1_1
			//
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this.Shape1.SetIndex(this._Shape1_1, Convert.ToInt16(1));
			this._Shape1_1.Location = new System.Drawing.Point(3, 328);
			this._Shape1_1.Name = "_Shape1_1";
			this._Shape1_1.Size = new System.Drawing.Size(337, 279);
			//
			//_Shape1_2
			//
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this.Shape1.SetIndex(this._Shape1_2, Convert.ToInt16(2));
			this._Shape1_2.Location = new System.Drawing.Point(3, 60);
			this._Shape1_2.Name = "_Shape1_2";
			this._Shape1_2.Size = new System.Drawing.Size(337, 187);
			//
			//_Shape1_0
			//
			this._Shape1_0.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this.Shape1.SetIndex(this._Shape1_0, Convert.ToInt16(0));
			this._Shape1_0.Location = new System.Drawing.Point(3, 264);
			this._Shape1_0.Name = "_Shape1_0";
			this._Shape1_0.Size = new System.Drawing.Size(337, 49);
			//
			//Shape5
			//
			this.Shape5.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Shape5.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this.Shape5.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Shape5.FillColor = System.Drawing.Color.Black;
			this.Shape5.Location = new System.Drawing.Point(346, 678);
			this.Shape5.Name = "Shape5";
			this.Shape5.Size = new System.Drawing.Size(254, 37);
			//
			//Shape6
			//
			this.Shape6.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Shape6.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this.Shape6.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Shape6.FillColor = System.Drawing.Color.Black;
			this.Shape6.Location = new System.Drawing.Point(3, 684);
			this.Shape6.Name = "Shape6";
			this.Shape6.Size = new System.Drawing.Size(337, 31);
			//
			//_chkFields_19
			//
			this._chkFields_19.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_19.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_19.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_19.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_19.Location = new System.Drawing.Point(612, 64);
			this._chkFields_19.Name = "_chkFields_19";
			this._chkFields_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_19.Size = new System.Drawing.Size(242, 29);
			this._chkFields_19.TabIndex = 90;
			this._chkFields_19.Text = "Do not allow security permissions higher than person logged in.";
			this._chkFields_19.UseVisualStyleBackColor = false;
			//
			//_chkFields_18
			//
			this._chkFields_18.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_18.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_18.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_18.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_18.Location = new System.Drawing.Point(354, 394);
			this._chkFields_18.Name = "_chkFields_18";
			this._chkFields_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_18.Size = new System.Drawing.Size(242, 27);
			this._chkFields_18.TabIndex = 89;
			this._chkFields_18.Text = "Load Today's report data when application starts";
			this._chkFields_18.UseVisualStyleBackColor = false;
			//
			//_chkFields_17
			//
			this._chkFields_17.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_17.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_17.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_17.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_17.Location = new System.Drawing.Point(8, 583);
			this._chkFields_17.Name = "_chkFields_17";
			this._chkFields_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_17.Size = new System.Drawing.Size(324, 19);
			this._chkFields_17.TabIndex = 88;
			this._chkFields_17.Text = "Apply Sales Qty for 'Make Finished Product'";
			this._chkFields_17.UseVisualStyleBackColor = false;
			//
			//_chkFields_16
			//
			this._chkFields_16.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_16.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_16.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_16.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_16.Location = new System.Drawing.Point(8, 564);
			this._chkFields_16.Name = "_chkFields_16";
			this._chkFields_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_16.Size = new System.Drawing.Size(324, 19);
			this._chkFields_16.TabIndex = 87;
			this._chkFields_16.Text = "Sort stock items on Order alphabetically";
			this._chkFields_16.UseVisualStyleBackColor = false;
			//
			//cmdLocate
			//
			this.cmdLocate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLocate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdLocate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLocate.Location = new System.Drawing.Point(272, 680);
			this.cmdLocate.Name = "cmdLocate";
			this.cmdLocate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLocate.Size = new System.Drawing.Size(60, 25);
			this.cmdLocate.TabIndex = 86;
			this.cmdLocate.Text = "Locate ...";
			this.cmdLocate.UseVisualStyleBackColor = false;
			//
			//_txtFields_11
			//
			this._txtFields_11.AcceptsReturn = true;
			this._txtFields_11.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_11.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_11.Enabled = false;
			this._txtFields_11.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_11.Location = new System.Drawing.Point(76, 684);
			this._txtFields_11.MaxLength = 0;
			this._txtFields_11.Name = "_txtFields_11";
			this._txtFields_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_11.Size = new System.Drawing.Size(192, 19);
			this._txtFields_11.TabIndex = 85;
			//
			//_chkFields_15
			//
			this._chkFields_15.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_15.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_15.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_15.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_15.Location = new System.Drawing.Point(354, 216);
			this._chkFields_15.Name = "_chkFields_15";
			this._chkFields_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_15.Size = new System.Drawing.Size(242, 23);
			this._chkFields_15.TabIndex = 81;
			this._chkFields_15.Text = "Use Head Office link";
			this._chkFields_15.UseVisualStyleBackColor = false;
			//
			//cboSDK
			//
			this.cboSDK.BackColor = System.Drawing.SystemColors.Window;
			this.cboSDK.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboSDK.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboSDK.Items.AddRange(new object[] {
				"Platinum SDK",
				"One Touch SDK"
			});
			this.cboSDK.Location = new System.Drawing.Point(448, 684);
			this.cboSDK.Name = "cboSDK";
			this.cboSDK.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboSDK.Size = new System.Drawing.Size(149, 21);
			this.cboSDK.TabIndex = 78;
			//
			//_chkFields_14
			//
			this._chkFields_14.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_14.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_14.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_14.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_14.Location = new System.Drawing.Point(8, 546);
			this._chkFields_14.Name = "_chkFields_14";
			this._chkFields_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_14.Size = new System.Drawing.Size(324, 19);
			this._chkFields_14.TabIndex = 77;
			this._chkFields_14.Text = "On Stock Take Additions and Day Ends print slip";
			this._chkFields_14.UseVisualStyleBackColor = false;
			//
			//_chkFields_13
			//
			this._chkFields_13.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_13.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_13.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_13.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_13.Location = new System.Drawing.Point(8, 526);
			this._chkFields_13.Name = "_chkFields_13";
			this._chkFields_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_13.Size = new System.Drawing.Size(324, 19);
			this._chkFields_13.TabIndex = 76;
			this._chkFields_13.Text = "When print shrinkage, toggle the negative sign";
			this._chkFields_13.UseVisualStyleBackColor = false;
			//
			//_chkFields_11
			//
			this._chkFields_11.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_11.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_11.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_11.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_11.Location = new System.Drawing.Point(8, 504);
			this._chkFields_11.Name = "_chkFields_11";
			this._chkFields_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_11.Size = new System.Drawing.Size(324, 19);
			this._chkFields_11.TabIndex = 75;
			this._chkFields_11.Text = "When print Purchase order, print Barcode and not Supplier code";
			this._chkFields_11.UseVisualStyleBackColor = false;
			//
			//_chkFields_10
			//
			this._chkFields_10.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_10.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_10.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_10.Location = new System.Drawing.Point(354, 378);
			this._chkFields_10.Name = "_chkFields_10";
			this._chkFields_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_10.Size = new System.Drawing.Size(242, 19);
			this._chkFields_10.TabIndex = 74;
			this._chkFields_10.Text = "Cashless System";
			this._chkFields_10.UseVisualStyleBackColor = false;
			//
			//_chkFields_9
			//
			this._chkFields_9.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_9.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_9.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_9.Location = new System.Drawing.Point(354, 359);
			this._chkFields_9.Name = "_chkFields_9";
			this._chkFields_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_9.Size = new System.Drawing.Size(242, 19);
			this._chkFields_9.TabIndex = 73;
			this._chkFields_9.Text = "Fruit && Veg Production";
			this._chkFields_9.UseVisualStyleBackColor = false;
			//
			//_chkFields_8
			//
			this._chkFields_8.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_8.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_8.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_8.Location = new System.Drawing.Point(354, 636);
			this._chkFields_8.Name = "_chkFields_8";
			this._chkFields_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_8.Size = new System.Drawing.Size(242, 23);
			this._chkFields_8.TabIndex = 72;
			this._chkFields_8.Text = "Do not print 'Balance Due Now' on statements";
			this._chkFields_8.UseVisualStyleBackColor = false;
			//
			//_chkFields_7
			//
			this._chkFields_7.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_7.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_7.Location = new System.Drawing.Point(354, 616);
			this._chkFields_7.Name = "_chkFields_7";
			this._chkFields_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_7.Size = new System.Drawing.Size(242, 23);
			this._chkFields_7.TabIndex = 70;
			this._chkFields_7.Text = "Use Open Item Debtors for payment allocation";
			this._chkFields_7.UseVisualStyleBackColor = false;
			//
			//_chkFields_6
			//
			this._chkFields_6.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_6.Location = new System.Drawing.Point(248, 629);
			this._chkFields_6.Name = "_chkFields_6";
			this._chkFields_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_6.Size = new System.Drawing.Size(81, 23);
			this._chkFields_6.TabIndex = 67;
			this._chkFields_6.Text = "Right to Left";
			this._chkFields_6.UseVisualStyleBackColor = false;
			//
			//_chkFields_5
			//
			this._chkFields_5.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_5.Location = new System.Drawing.Point(354, 340);
			this._chkFields_5.Name = "_chkFields_5";
			this._chkFields_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_5.Size = new System.Drawing.Size(242, 19);
			this._chkFields_5.TabIndex = 65;
			this._chkFields_5.Text = "Dry Cleaning Customer";
			this._chkFields_5.UseVisualStyleBackColor = false;
			//
			//_chkFields_4
			//
			this._chkFields_4.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_4.Location = new System.Drawing.Point(8, 334);
			this._chkFields_4.Name = "_chkFields_4";
			this._chkFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_4.Size = new System.Drawing.Size(324, 19);
			this._chkFields_4.TabIndex = 64;
			this._chkFields_4.Text = "When print stock take sheets, show Barcode and not Quick Key";
			this._chkFields_4.UseVisualStyleBackColor = false;
			//
			//_chkFields_3
			//
			this._chkFields_3.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_3.Location = new System.Drawing.Point(256, 736);
			this._chkFields_3.Name = "_chkFields_3";
			this._chkFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_3.Size = new System.Drawing.Size(265, 23);
			this._chkFields_3.TabIndex = 63;
			this._chkFields_3.Text = "Donot overwrite Menus on 4POS Update";
			this._chkFields_3.UseVisualStyleBackColor = false;
			this._chkFields_3.Visible = false;
			//
			//_chkBit_13
			//
			this._chkBit_13.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkBit_13.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_13.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_13.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_13.Location = new System.Drawing.Point(8, 475);
			this._chkBit_13.Name = "_chkBit_13";
			this._chkBit_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_13.Size = new System.Drawing.Size(324, 26);
			this._chkBit_13.TabIndex = 62;
			this._chkBit_13.Text = "On processing GRV, Do not update GRV cost to LIST cost && calculate Weighted Avg " + "cost to Actual Cost";
			this._chkBit_13.UseVisualStyleBackColor = false;
			//
			//_chkFields_2
			//
			this._chkFields_2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_2.Location = new System.Drawing.Point(8, 389);
			this._chkFields_2.Name = "_chkFields_2";
			this._chkFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_2.Size = new System.Drawing.Size(324, 26);
			this._chkFields_2.TabIndex = 59;
			this._chkFields_2.Text = "On processing GRV, update GRV Cost to Actual Cost        [Default is List Cost]";
			this._chkFields_2.UseVisualStyleBackColor = false;
			//
			//_txtFields_4
			//
			this._txtFields_4.AcceptsReturn = true;
			this._txtFields_4.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_4.Location = new System.Drawing.Point(520, 552);
			this._txtFields_4.MaxLength = 0;
			this._txtFields_4.Name = "_txtFields_4";
			this._txtFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_4.Size = new System.Drawing.Size(72, 19);
			this._txtFields_4.TabIndex = 58;
			//
			//txtintper
			//
			this.txtintper.AcceptsReturn = true;
			this.txtintper.BackColor = System.Drawing.SystemColors.Window;
			this.txtintper.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtintper.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtintper.Location = new System.Drawing.Point(176, 728);
			this.txtintper.MaxLength = 0;
			this.txtintper.Name = "txtintper";
			this.txtintper.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtintper.Size = new System.Drawing.Size(71, 19);
			this.txtintper.TabIndex = 26;
			this.txtintper.Text = "0.00";
			this.txtintper.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtintper.Visible = false;
			//
			//_cboIntPer_0
			//
			this._cboIntPer_0.BackColor = System.Drawing.SystemColors.Window;
			this._cboIntPer_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cboIntPer_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._cboIntPer_0.Items.AddRange(new object[] {
				"Current",
				"30 Days",
				"60 Days",
				"90 Days",
				"120 Days",
				"150 Days"
			});
			this._cboIntPer_0.Location = new System.Drawing.Point(520, 574);
			this._cboIntPer_0.Name = "_cboIntPer_0";
			this._cboIntPer_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cboIntPer_0.Size = new System.Drawing.Size(69, 21);
			this._cboIntPer_0.TabIndex = 27;
			//
			//_chkBit_12
			//
			this._chkBit_12.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkBit_12.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_12.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_12.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_12.Location = new System.Drawing.Point(354, 323);
			this._chkBit_12.Name = "_chkBit_12";
			this._chkBit_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_12.Size = new System.Drawing.Size(242, 15);
			this._chkBit_12.TabIndex = 31;
			this._chkBit_12.Text = "Automatic Zero Stock At Day End";
			this._chkBit_12.UseVisualStyleBackColor = false;
			//
			//txtPeriod
			//
			this.txtPeriod.AcceptsReturn = true;
			this.txtPeriod.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.txtPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPeriod.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPeriod.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPeriod.Location = new System.Drawing.Point(98, 268);
			this.txtPeriod.MaxLength = 0;
			this.txtPeriod.Name = "txtPeriod";
			this.txtPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPeriod.Size = new System.Drawing.Size(49, 19);
			this.txtPeriod.TabIndex = 6;
			this.txtPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_chkBit_11
			//
			this._chkBit_11.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkBit_11.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_11.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_11.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_11.Location = new System.Drawing.Point(8, 430);
			this._chkBit_11.Name = "_chkBit_11";
			this._chkBit_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_11.Size = new System.Drawing.Size(324, 26);
			this._chkBit_11.TabIndex = 53;
			this._chkBit_11.Text = "On processing GRV, update GRV cost to LIST cost && calculate Weighted Avg cost to" + " Actual Cost";
			this._chkBit_11.UseVisualStyleBackColor = false;
			//
			//_txtFields_3
			//
			this._txtFields_3.AcceptsReturn = true;
			this._txtFields_3.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_3.Location = new System.Drawing.Point(464, 510);
			this._txtFields_3.MaxLength = 0;
			this._txtFields_3.Name = "_txtFields_3";
			this._txtFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_3.Size = new System.Drawing.Size(131, 19);
			this._txtFields_3.TabIndex = 25;
			//
			//_txtFields_2
			//
			this._txtFields_2.AcceptsReturn = true;
			this._txtFields_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_2.Location = new System.Drawing.Point(464, 488);
			this._txtFields_2.MaxLength = 0;
			this._txtFields_2.Name = "_txtFields_2";
			this._txtFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_2.Size = new System.Drawing.Size(131, 19);
			this._txtFields_2.TabIndex = 24;
			//
			//_txtFields_1
			//
			this._txtFields_1.AcceptsReturn = true;
			this._txtFields_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_1.Location = new System.Drawing.Point(464, 466);
			this._txtFields_1.MaxLength = 0;
			this._txtFields_1.Name = "_txtFields_1";
			this._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_1.Size = new System.Drawing.Size(131, 19);
			this._txtFields_1.TabIndex = 23;
			//
			//_txtFields_0
			//
			this._txtFields_0.AcceptsReturn = true;
			this._txtFields_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_0.Location = new System.Drawing.Point(464, 446);
			this._txtFields_0.MaxLength = 0;
			this._txtFields_0.Name = "_txtFields_0";
			this._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_0.Size = new System.Drawing.Size(131, 19);
			this._txtFields_0.TabIndex = 22;
			//
			//_chkBit_10
			//
			this._chkBit_10.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkBit_10.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_10.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_10.Location = new System.Drawing.Point(354, 202);
			this._chkBit_10.Name = "_chkBit_10";
			this._chkBit_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_10.Size = new System.Drawing.Size(242, 15);
			this._chkBit_10.TabIndex = 18;
			this._chkBit_10.Text = "Automatic Email to Remote Office";
			this._chkBit_10.UseVisualStyleBackColor = false;
			//
			//_chkBit_9
			//
			this._chkBit_9.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkBit_9.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_9.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_9.Location = new System.Drawing.Point(354, 306);
			this._chkBit_9.Name = "_chkBit_9";
			this._chkBit_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_9.Size = new System.Drawing.Size(242, 15);
			this._chkBit_9.TabIndex = 21;
			this._chkBit_9.Text = "Do Not View Update Warning on update POS ";
			this._chkBit_9.UseVisualStyleBackColor = false;
			//
			//_chkBit_8
			//
			this._chkBit_8.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkBit_8.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_8.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_8.Location = new System.Drawing.Point(354, 262);
			this._chkBit_8.Name = "_chkBit_8";
			this._chkBit_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_8.Size = new System.Drawing.Size(242, 23);
			this._chkBit_8.TabIndex = 19;
			this._chkBit_8.Text = "4POS Interface Handling";
			this._chkBit_8.UseVisualStyleBackColor = false;
			//
			//_chkBit_0
			//
			this._chkBit_0.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkBit_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_0.Location = new System.Drawing.Point(354, 186);
			this._chkBit_0.Name = "_chkBit_0";
			this._chkBit_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_0.Size = new System.Drawing.Size(242, 15);
			this._chkBit_0.TabIndex = 17;
			this._chkBit_0.Text = "Automatic Pastel Report";
			this._chkBit_0.UseVisualStyleBackColor = false;
			//
			//_chkFields_1
			//
			this._chkFields_1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_1.Location = new System.Drawing.Point(354, 284);
			this._chkFields_1.Name = "_chkFields_1";
			this._chkFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_1.Size = new System.Drawing.Size(242, 22);
			this._chkFields_1.TabIndex = 20;
			this._chkFields_1.Text = "Allow Day End run to be performed from the 4POS Domain Controller";
			this._chkFields_1.UseVisualStyleBackColor = false;
			//
			//_chkBit_7
			//
			this._chkBit_7.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkBit_7.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_7.Location = new System.Drawing.Point(354, 168);
			this._chkBit_7.Name = "_chkBit_7";
			this._chkBit_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_7.Size = new System.Drawing.Size(242, 15);
			this._chkBit_7.TabIndex = 16;
			this._chkBit_7.Text = "Consignment Summary";
			this._chkBit_7.UseVisualStyleBackColor = false;
			//
			//_chkBit_6
			//
			this._chkBit_6.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkBit_6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_6.Location = new System.Drawing.Point(354, 152);
			this._chkBit_6.Name = "_chkBit_6";
			this._chkBit_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_6.Size = new System.Drawing.Size(242, 15);
			this._chkBit_6.TabIndex = 15;
			this._chkBit_6.Text = "Print Quotes";
			this._chkBit_6.UseVisualStyleBackColor = false;
			//
			//_chkBit_5
			//
			this._chkBit_5.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkBit_5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_5.Location = new System.Drawing.Point(354, 134);
			this._chkBit_5.Name = "_chkBit_5";
			this._chkBit_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_5.Size = new System.Drawing.Size(242, 15);
			this._chkBit_5.TabIndex = 14;
			this._chkBit_5.Text = "Print Customer Movement Details";
			this._chkBit_5.UseVisualStyleBackColor = false;
			//
			//_chkBit_4
			//
			this._chkBit_4.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkBit_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_4.Location = new System.Drawing.Point(354, 116);
			this._chkBit_4.Name = "_chkBit_4";
			this._chkBit_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_4.Size = new System.Drawing.Size(242, 15);
			this._chkBit_4.TabIndex = 44;
			this._chkBit_4.Text = "Print Supplier Movement Summary";
			this._chkBit_4.UseVisualStyleBackColor = false;
			//
			//_chkBit_3
			//
			this._chkBit_3.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkBit_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_3.Location = new System.Drawing.Point(354, 100);
			this._chkBit_3.Name = "_chkBit_3";
			this._chkBit_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_3.Size = new System.Drawing.Size(242, 15);
			this._chkBit_3.TabIndex = 13;
			this._chkBit_3.Text = "Print Shrinkage Details";
			this._chkBit_3.UseVisualStyleBackColor = false;
			//
			//_chkBit_2
			//
			this._chkBit_2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkBit_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_2.Location = new System.Drawing.Point(354, 82);
			this._chkBit_2.Name = "_chkBit_2";
			this._chkBit_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_2.Size = new System.Drawing.Size(242, 15);
			this._chkBit_2.TabIndex = 12;
			this._chkBit_2.Text = "Stock Movement Summary";
			this._chkBit_2.UseVisualStyleBackColor = false;
			//
			//_chkBit_1
			//
			this._chkBit_1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkBit_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkBit_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBit_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBit_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBit_1.Location = new System.Drawing.Point(354, 64);
			this._chkBit_1.Name = "_chkBit_1";
			this._chkBit_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBit_1.Size = new System.Drawing.Size(242, 15);
			this._chkBit_1.TabIndex = 11;
			this._chkBit_1.Text = "Sale Channel Activities";
			this._chkBit_1.UseVisualStyleBackColor = false;
			//
			//_chkFields_0
			//
			this._chkFields_0.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_0.Location = new System.Drawing.Point(8, 370);
			this._chkFields_0.Name = "_chkFields_0";
			this._chkFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_0.Size = new System.Drawing.Size(324, 19);
			this._chkFields_0.TabIndex = 10;
			this._chkFields_0.Text = "When print stock take sheets, dont print zero stock";
			this._chkFields_0.UseVisualStyleBackColor = false;
			//
			//_chkFields_12
			//
			this._chkFields_12.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_12.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_12.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_12.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_12.Location = new System.Drawing.Point(8, 352);
			this._chkFields_12.Name = "_chkFields_12";
			this._chkFields_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_12.Size = new System.Drawing.Size(324, 19);
			this._chkFields_12.TabIndex = 9;
			this._chkFields_12.Text = "When print stock take sheets, show stock value";
			this._chkFields_12.UseVisualStyleBackColor = false;
			//
			//_txtFields_14
			//
			this._txtFields_14.AcceptsReturn = true;
			this._txtFields_14.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this._txtFields_14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_14.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_14.Enabled = false;
			this._txtFields_14.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_14.Location = new System.Drawing.Point(284, 290);
			this._txtFields_14.MaxLength = 0;
			this._txtFields_14.Name = "_txtFields_14";
			this._txtFields_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_14.Size = new System.Drawing.Size(48, 19);
			this._txtFields_14.TabIndex = 8;
			this._txtFields_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtFields_13
			//
			this._txtFields_13.AcceptsReturn = true;
			this._txtFields_13.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this._txtFields_13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_13.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_13.Enabled = false;
			this._txtFields_13.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_13.Location = new System.Drawing.Point(284, 268);
			this._txtFields_13.MaxLength = 0;
			this._txtFields_13.Name = "_txtFields_13";
			this._txtFields_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_13.Size = new System.Drawing.Size(48, 19);
			this._txtFields_13.TabIndex = 7;
			this._txtFields_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtFields_10
			//
			this._txtFields_10.AcceptsReturn = true;
			this._txtFields_10.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_10.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_10.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_10.Location = new System.Drawing.Point(98, 222);
			this._txtFields_10.MaxLength = 0;
			this._txtFields_10.Name = "_txtFields_10";
			this._txtFields_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_10.Size = new System.Drawing.Size(234, 19);
			this._txtFields_10.TabIndex = 5;
			//
			//_txtFields_9
			//
			this._txtFields_9.AcceptsReturn = true;
			this._txtFields_9.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_9.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_9.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_9.Location = new System.Drawing.Point(233, 200);
			this._txtFields_9.MaxLength = 0;
			this._txtFields_9.Name = "_txtFields_9";
			this._txtFields_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_9.Size = new System.Drawing.Size(99, 19);
			this._txtFields_9.TabIndex = 4;
			//
			//_txtFields_8
			//
			this._txtFields_8.AcceptsReturn = true;
			this._txtFields_8.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_8.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_8.Location = new System.Drawing.Point(98, 200);
			this._txtFields_8.MaxLength = 0;
			this._txtFields_8.Name = "_txtFields_8";
			this._txtFields_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_8.Size = new System.Drawing.Size(99, 19);
			this._txtFields_8.TabIndex = 3;
			//
			//_txtFields_7
			//
			this._txtFields_7.AcceptsReturn = true;
			this._txtFields_7.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_7.Location = new System.Drawing.Point(98, 156);
			this._txtFields_7.MaxLength = 0;
			this._txtFields_7.Multiline = true;
			this._txtFields_7.Name = "_txtFields_7";
			this._txtFields_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_7.Size = new System.Drawing.Size(234, 41);
			this._txtFields_7.TabIndex = 2;
			//
			//_txtFields_6
			//
			this._txtFields_6.AcceptsReturn = true;
			this._txtFields_6.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_6.Location = new System.Drawing.Point(98, 105);
			this._txtFields_6.MaxLength = 0;
			this._txtFields_6.Multiline = true;
			this._txtFields_6.Name = "_txtFields_6";
			this._txtFields_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_6.Size = new System.Drawing.Size(234, 49);
			this._txtFields_6.TabIndex = 1;
			//
			//_txtFields_5
			//
			this._txtFields_5.AcceptsReturn = true;
			this._txtFields_5.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this._txtFields_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_5.Enabled = false;
			this._txtFields_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_5.Location = new System.Drawing.Point(98, 69);
			this._txtFields_5.MaxLength = 0;
			this._txtFields_5.Name = "_txtFields_5";
			this._txtFields_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_5.Size = new System.Drawing.Size(234, 19);
			this._txtFields_5.TabIndex = 0;
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.cmdSyncParam);
			this.picButtons.Controls.Add(this.cmdHO);
			this.picButtons.Controls.Add(this.Command1);
			this.picButtons.Controls.Add(this.cmdCancel);
			this.picButtons.Controls.Add(this.cmdClose);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(867, 39);
			this.picButtons.TabIndex = 45;
			//
			//cmdSyncParam
			//
			this.cmdSyncParam.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSyncParam.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSyncParam.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSyncParam.Location = new System.Drawing.Point(296, 4);
			this.cmdSyncParam.Name = "cmdSyncParam";
			this.cmdSyncParam.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSyncParam.Size = new System.Drawing.Size(105, 29);
			this.cmdSyncParam.TabIndex = 92;
			this.cmdSyncParam.Text = "Sync Parameters";
			this.cmdSyncParam.UseVisualStyleBackColor = false;
			//
			//cmdHO
			//
			this.cmdHO.BackColor = System.Drawing.SystemColors.Control;
			this.cmdHO.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdHO.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdHO.Location = new System.Drawing.Point(184, 4);
			this.cmdHO.Name = "cmdHO";
			this.cmdHO.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdHO.Size = new System.Drawing.Size(105, 29);
			this.cmdHO.TabIndex = 82;
			this.cmdHO.Text = "Synchronize Data";
			this.cmdHO.UseVisualStyleBackColor = false;
			//
			//Command1
			//
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Location = new System.Drawing.Point(96, 4);
			this.Command1.Name = "Command1";
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.Size = new System.Drawing.Size(73, 29);
			this.Command1.TabIndex = 29;
			this.Command1.Text = "Edit Emails";
			this.Command1.UseVisualStyleBackColor = false;
			//
			//cmdCancel
			//
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Location = new System.Drawing.Point(8, 4);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.TabIndex = 30;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.UseVisualStyleBackColor = false;
			//
			//cmdClose
			//
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Location = new System.Drawing.Point(546, 4);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.TabIndex = 28;
			this.cmdClose.TabStop = false;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.UseVisualStyleBackColor = false;
			//
			//cmbLanguage
			//
			this.cmbLanguage.AllowAddNew = true;
			this.cmbLanguage.BoundText = "";
			this.cmbLanguage.CellBackColor = System.Drawing.SystemColors.AppWorkspace;
			this.cmbLanguage.Col = 0;
			this.cmbLanguage.CtlText = "";
			this.cmbLanguage.DataField = null;
			this.cmbLanguage.Location = new System.Drawing.Point(99, 629);
			this.cmbLanguage.Name = "cmbLanguage";
			this.cmbLanguage.row = 0;
			this.cmbLanguage.Size = new System.Drawing.Size(132, 21);
			this.cmbLanguage.TabIndex = 68;
			this.cmbLanguage.TopRow = 0;
			//
			//_lbl_4
			//
			this._lbl_4.AutoSize = true;
			this._lbl_4.BackColor = System.Drawing.Color.Transparent;
			this._lbl_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_4.Location = new System.Drawing.Point(606, 45);
			this._lbl_4.Name = "_lbl_4";
			this._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_4.Size = new System.Drawing.Size(144, 14);
			this._lbl_4.TabIndex = 91;
			this._lbl_4.Text = "&12. Security permissions";
			//
			//Label14
			//
			this.Label14.BackColor = System.Drawing.Color.Transparent;
			this.Label14.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label14.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label14.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label14.Location = new System.Drawing.Point(3, 664);
			this.Label14.Name = "Label14";
			this.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label14.Size = new System.Drawing.Size(273, 17);
			this.Label14.TabIndex = 84;
			this.Label14.Text = "&5. Automatic backup path";
			//
			//_lblLabels_2
			//
			this._lblLabels_2.AutoSize = true;
			this._lblLabels_2.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_2.Location = new System.Drawing.Point(8, 686);
			this._lblLabels_2.Name = "_lblLabels_2";
			this._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_2.Size = new System.Drawing.Size(72, 13);
			this._lblLabels_2.TabIndex = 83;
			this._lblLabels_2.Text = "Backup Path:";
			this._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label13
			//
			this.Label13.BackColor = System.Drawing.Color.Transparent;
			this.Label13.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label13.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label13.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label13.Location = new System.Drawing.Point(348, 664);
			this.Label13.Name = "Label13";
			this.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label13.Size = new System.Drawing.Size(273, 17);
			this.Label13.TabIndex = 80;
			this.Label13.Text = "&11. Finger Print SDK";
			//
			//Label12
			//
			this.Label12.AutoSize = true;
			this.Label12.BackColor = System.Drawing.Color.Transparent;
			this.Label12.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label12.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label12.Location = new System.Drawing.Point(352, 688);
			this.Label12.Name = "Label12";
			this.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label12.Size = new System.Drawing.Size(81, 13);
			this.Label12.TabIndex = 79;
			this.Label12.Text = "DigitalPersona :";
			//
			//Label11
			//
			this.Label11.BackColor = System.Drawing.Color.Transparent;
			this.Label11.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label11.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label11.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label11.Location = new System.Drawing.Point(348, 600);
			this.Label11.Name = "Label11";
			this.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label11.Size = new System.Drawing.Size(273, 17);
			this.Label11.TabIndex = 71;
			this.Label11.Text = "&10. Open Item Debtors";
			//
			//_lblLabels_1
			//
			this._lblLabels_1.AutoSize = true;
			this._lblLabels_1.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_1.Location = new System.Drawing.Point(8, 630);
			this._lblLabels_1.Name = "_lblLabels_1";
			this._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_1.Size = new System.Drawing.Size(95, 13);
			this._lblLabels_1.TabIndex = 69;
			this._lblLabels_1.Text = "Default Language:";
			this._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label10
			//
			this.Label10.BackColor = System.Drawing.Color.Transparent;
			this.Label10.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label10.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label10.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label10.Location = new System.Drawing.Point(3, 608);
			this.Label10.Name = "Label10";
			this.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label10.Size = new System.Drawing.Size(273, 17);
			this.Label10.TabIndex = 66;
			this.Label10.Text = "&4. Language settings";
			//
			//Label9
			//
			this.Label9.BackColor = System.Drawing.Color.Transparent;
			this.Label9.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label9.Location = new System.Drawing.Point(16, 458);
			this.Label9.Name = "Label9";
			this.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label9.Size = new System.Drawing.Size(315, 15);
			this.Label9.TabIndex = 61;
			this.Label9.Text = "-------------------------------------------  OR  --------------------------------" + "-----------";
			//
			//Label8
			//
			this.Label8.BackColor = System.Drawing.Color.Transparent;
			this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label8.Location = new System.Drawing.Point(16, 414);
			this.Label8.Name = "Label8";
			this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label8.Size = new System.Drawing.Size(315, 15);
			this.Label8.TabIndex = 60;
			this.Label8.Text = "-------------------------------------------  OR  --------------------------------" + "-----------";
			//
			//lblintrfromper
			//
			this.lblintrfromper.AutoSize = true;
			this.lblintrfromper.BackColor = System.Drawing.Color.Transparent;
			this.lblintrfromper.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblintrfromper.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblintrfromper.Location = new System.Drawing.Point(409, 577);
			this.lblintrfromper.Name = "lblintrfromper";
			this.lblintrfromper.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblintrfromper.Size = new System.Drawing.Size(107, 13);
			this.lblintrfromper.TabIndex = 57;
			this.lblintrfromper.Text = "Interest From Period :";
			//
			//lblinterestper
			//
			this.lblinterestper.AutoSize = true;
			this.lblinterestper.BackColor = System.Drawing.Color.Transparent;
			this.lblinterestper.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblinterestper.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblinterestper.Location = new System.Drawing.Point(368, 556);
			this.lblinterestper.Name = "lblinterestper";
			this.lblinterestper.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblinterestper.Size = new System.Drawing.Size(149, 13);
			this.lblinterestper.TabIndex = 56;
			this.lblinterestper.Text = "Interest Percentage per Year :";
			//
			//Label7
			//
			this.Label7.BackColor = System.Drawing.Color.Transparent;
			this.Label7.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label7.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label7.Location = new System.Drawing.Point(348, 532);
			this.Label7.Name = "Label7";
			this.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label7.Size = new System.Drawing.Size(273, 17);
			this.Label7.TabIndex = 55;
			this.Label7.Text = "&9. Interest Percentages";
			//
			//Label6
			//
			this.Label6.BackColor = System.Drawing.Color.Transparent;
			this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label6.Location = new System.Drawing.Point(8, 272);
			this.Label6.Name = "Label6";
			this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label6.Size = new System.Drawing.Size(67, 15);
			this.Label6.TabIndex = 54;
			this.Label6.Text = "Pastel period";
			//
			//Label5
			//
			this.Label5.BackColor = System.Drawing.Color.Transparent;
			this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label5.Location = new System.Drawing.Point(348, 426);
			this.Label5.Name = "Label5";
			this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label5.Size = new System.Drawing.Size(121, 15);
			this.Label5.TabIndex = 52;
			this.Label5.Text = "&8. Banking Details";
			//
			//Label4
			//
			this.Label4.BackColor = System.Drawing.Color.Transparent;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label4.Location = new System.Drawing.Point(348, 514);
			this.Label4.Name = "Label4";
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.Size = new System.Drawing.Size(113, 15);
			this.Label4.TabIndex = 51;
			this.Label4.Text = "Account Number :";
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label3
			//
			this.Label3.BackColor = System.Drawing.Color.Transparent;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Location = new System.Drawing.Point(348, 492);
			this.Label3.Name = "Label3";
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.Size = new System.Drawing.Size(113, 15);
			this.Label3.TabIndex = 50;
			this.Label3.Text = "Branch Code :";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label2
			//
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Location = new System.Drawing.Point(348, 470);
			this.Label2.Name = "Label2";
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.Size = new System.Drawing.Size(113, 15);
			this.Label2.TabIndex = 49;
			this.Label2.Text = "Branch Name :";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label1
			//
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(348, 448);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(113, 15);
			this.Label1.TabIndex = 48;
			this.Label1.Text = "Bank Name :";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_3
			//
			this._lbl_3.AutoSize = true;
			this._lbl_3.BackColor = System.Drawing.Color.Transparent;
			this._lbl_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_3.Location = new System.Drawing.Point(348, 244);
			this._lbl_3.Name = "_lbl_3";
			this._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_3.Size = new System.Drawing.Size(50, 14);
			this._lbl_3.TabIndex = 47;
			this._lbl_3.Text = "&7. Other";
			//
			//_lbl_2
			//
			this._lbl_2.AutoSize = true;
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Location = new System.Drawing.Point(346, 45);
			this._lbl_2.Name = "_lbl_2";
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.Size = new System.Drawing.Size(198, 14);
			this._lbl_2.TabIndex = 43;
			this._lbl_2.Text = "&6. Day End Report Print Parameters";
			//
			//_lbl_1
			//
			this._lbl_1.AutoSize = true;
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_1.Location = new System.Drawing.Point(3, 314);
			this._lbl_1.Name = "_lbl_1";
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.Size = new System.Drawing.Size(147, 14);
			this._lbl_1.TabIndex = 42;
			this._lbl_1.Text = "&3. Stock Take Parameters";
			//
			//_lbl_0
			//
			this._lbl_0.AutoSize = true;
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Location = new System.Drawing.Point(3, 248);
			this._lbl_0.Name = "_lbl_0";
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.Size = new System.Drawing.Size(155, 14);
			this._lbl_0.TabIndex = 39;
			this._lbl_0.Text = "&2. Current Period Numbers";
			//
			//_lblLabels_0
			//
			this._lblLabels_0.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_0.ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(128)), Convert.ToInt32(Convert.ToByte(128)), Convert.ToInt32(Convert.ToByte(128)));
			this._lblLabels_0.Location = new System.Drawing.Point(53, 87);
			this._lblLabels_0.Name = "_lblLabels_0";
			this._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_0.Size = new System.Drawing.Size(277, 13);
			this._lblLabels_0.TabIndex = 46;
			this._lblLabels_0.Text = "To change your store name, please contact 4POS Support";
			this._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			//
			//_lblLabels_14
			//
			this._lblLabels_14.AutoSize = true;
			this._lblLabels_14.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_14.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_14.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_14.Location = new System.Drawing.Point(146, 292);
			this._lblLabels_14.Name = "_lblLabels_14";
			this._lblLabels_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_14.Size = new System.Drawing.Size(139, 13);
			this._lblLabels_14.TabIndex = 41;
			this._lblLabels_14.Text = "Current Month End Number:";
			this._lblLabels_14.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_13
			//
			this._lblLabels_13.AutoSize = true;
			this._lblLabels_13.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_13.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_13.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_13.Location = new System.Drawing.Point(154, 272);
			this._lblLabels_13.Name = "_lblLabels_13";
			this._lblLabels_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_13.Size = new System.Drawing.Size(128, 13);
			this._lblLabels_13.TabIndex = 40;
			this._lblLabels_13.Text = "Current Day End Number:";
			this._lblLabels_13.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_10
			//
			this._lblLabels_10.AutoSize = true;
			this._lblLabels_10.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_10.Location = new System.Drawing.Point(66, 222);
			this._lblLabels_10.Name = "_lblLabels_10";
			this._lblLabels_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_10.Size = new System.Drawing.Size(35, 13);
			this._lblLabels_10.TabIndex = 38;
			this._lblLabels_10.Text = "Email:";
			this._lblLabels_10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_9
			//
			this._lblLabels_9.AutoSize = true;
			this._lblLabels_9.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_9.Location = new System.Drawing.Point(206, 200);
			this._lblLabels_9.Name = "_lblLabels_9";
			this._lblLabels_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_9.Size = new System.Drawing.Size(27, 13);
			this._lblLabels_9.TabIndex = 37;
			this._lblLabels_9.Text = "Fax:";
			this._lblLabels_9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_8
			//
			this._lblLabels_8.AutoSize = true;
			this._lblLabels_8.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_8.Location = new System.Drawing.Point(40, 200);
			this._lblLabels_8.Name = "_lblLabels_8";
			this._lblLabels_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_8.Size = new System.Drawing.Size(61, 13);
			this._lblLabels_8.TabIndex = 36;
			this._lblLabels_8.Text = "Telephone:";
			this._lblLabels_8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_7
			//
			this._lblLabels_7.AutoSize = true;
			this._lblLabels_7.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_7.Location = new System.Drawing.Point(20, 156);
			this._lblLabels_7.Name = "_lblLabels_7";
			this._lblLabels_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_7.Size = new System.Drawing.Size(80, 13);
			this._lblLabels_7.TabIndex = 35;
			this._lblLabels_7.Text = "Postal Address:";
			this._lblLabels_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_6
			//
			this._lblLabels_6.AutoSize = true;
			this._lblLabels_6.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_6.Location = new System.Drawing.Point(8, 105);
			this._lblLabels_6.Name = "_lblLabels_6";
			this._lblLabels_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_6.Size = new System.Drawing.Size(90, 13);
			this._lblLabels_6.TabIndex = 34;
			this._lblLabels_6.Text = "Physical Address:";
			this._lblLabels_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_5
			//
			this._lblLabels_5.AutoSize = true;
			this._lblLabels_5.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_5.Location = new System.Drawing.Point(13, 69);
			this._lblLabels_5.Name = "_lblLabels_5";
			this._lblLabels_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_5.Size = new System.Drawing.Size(85, 13);
			this._lblLabels_5.TabIndex = 33;
			this._lblLabels_5.Text = "Company Name:";
			this._lblLabels_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_5
			//
			this._lbl_5.AutoSize = true;
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_5.Location = new System.Drawing.Point(3, 45);
			this._lbl_5.Name = "_lbl_5";
			this._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_5.Size = new System.Drawing.Size(62, 14);
			this._lbl_5.TabIndex = 32;
			this._lbl_5.Text = "&1. General";
			//
			//frmCompanySetup
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.ClientSize = new System.Drawing.Size(867, 720);
			this.ControlBox = false;
			this.Controls.Add(this._chkFields_19);
			this.Controls.Add(this._chkFields_18);
			this.Controls.Add(this._chkFields_17);
			this.Controls.Add(this._chkFields_16);
			this.Controls.Add(this.cmdLocate);
			this.Controls.Add(this._txtFields_11);
			this.Controls.Add(this._chkFields_15);
			this.Controls.Add(this.cboSDK);
			this.Controls.Add(this._chkFields_14);
			this.Controls.Add(this._chkFields_13);
			this.Controls.Add(this._chkFields_11);
			this.Controls.Add(this._chkFields_10);
			this.Controls.Add(this._chkFields_9);
			this.Controls.Add(this._chkFields_8);
			this.Controls.Add(this._chkFields_7);
			this.Controls.Add(this._chkFields_6);
			this.Controls.Add(this._chkFields_5);
			this.Controls.Add(this._chkFields_4);
			this.Controls.Add(this._chkFields_3);
			this.Controls.Add(this._chkBit_13);
			this.Controls.Add(this._chkFields_2);
			this.Controls.Add(this._txtFields_4);
			this.Controls.Add(this.txtintper);
			this.Controls.Add(this._cboIntPer_0);
			this.Controls.Add(this._chkBit_12);
			this.Controls.Add(this.txtPeriod);
			this.Controls.Add(this._chkBit_11);
			this.Controls.Add(this._txtFields_3);
			this.Controls.Add(this._txtFields_2);
			this.Controls.Add(this._txtFields_1);
			this.Controls.Add(this._txtFields_0);
			this.Controls.Add(this._chkBit_10);
			this.Controls.Add(this._chkBit_9);
			this.Controls.Add(this._chkBit_8);
			this.Controls.Add(this._chkBit_0);
			this.Controls.Add(this._chkFields_1);
			this.Controls.Add(this._chkBit_7);
			this.Controls.Add(this._chkBit_6);
			this.Controls.Add(this._chkBit_5);
			this.Controls.Add(this._chkBit_4);
			this.Controls.Add(this._chkBit_3);
			this.Controls.Add(this._chkBit_2);
			this.Controls.Add(this._chkBit_1);
			this.Controls.Add(this._chkFields_0);
			this.Controls.Add(this._chkFields_12);
			this.Controls.Add(this._txtFields_14);
			this.Controls.Add(this._txtFields_13);
			this.Controls.Add(this._txtFields_10);
			this.Controls.Add(this._txtFields_9);
			this.Controls.Add(this._txtFields_8);
			this.Controls.Add(this._txtFields_7);
			this.Controls.Add(this._txtFields_6);
			this.Controls.Add(this._txtFields_5);
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this.cmbLanguage);
			this.Controls.Add(this._lbl_4);
			this.Controls.Add(this.Label14);
			this.Controls.Add(this._lblLabels_2);
			this.Controls.Add(this.Label13);
			this.Controls.Add(this.Label12);
			this.Controls.Add(this.Label11);
			this.Controls.Add(this._lblLabels_1);
			this.Controls.Add(this.Label10);
			this.Controls.Add(this.Label9);
			this.Controls.Add(this.Label8);
			this.Controls.Add(this.lblintrfromper);
			this.Controls.Add(this.lblinterestper);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this._lbl_3);
			this.Controls.Add(this._lbl_2);
			this.Controls.Add(this._lbl_1);
			this.Controls.Add(this._lbl_0);
			this.Controls.Add(this._lblLabels_0);
			this.Controls.Add(this._lblLabels_14);
			this.Controls.Add(this._lblLabels_13);
			this.Controls.Add(this._lblLabels_10);
			this.Controls.Add(this._lblLabels_9);
			this.Controls.Add(this._lblLabels_8);
			this.Controls.Add(this._lblLabels_7);
			this.Controls.Add(this._lblLabels_6);
			this.Controls.Add(this._lblLabels_5);
			this.Controls.Add(this._lbl_5);
			this.Controls.Add(this.ShapeContainer1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(73, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCompanySetup";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Edit Store Details";
			this.picButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.cmbLanguage).EndInit();
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
