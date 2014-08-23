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
	partial class frmPOSreport
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmPOSreport() : base()
		{
			Load += frmPOSreport_Load;
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
		public System.Windows.Forms.CheckBox chkNoCon;
		public System.Windows.Forms.CheckBox chkOutCon;
		public System.Windows.Forms.CheckBox chkSum;
		public System.Windows.Forms.CheckBox chkFC;
		public System.Windows.Forms.CheckedListBox lstSaleref;
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
		public System.Windows.Forms.CheckBox chkReversal;
		public System.Windows.Forms.CheckBox chkRevoke;
		public System.Windows.Forms.CheckedListBox lstPOS;
		public System.Windows.Forms.CheckedListBox lstChannel;
		public System.Windows.Forms.CheckedListBox lstPerson;
		public System.Windows.Forms.Label _Label1_3;
		public System.Windows.Forms.Label _Label1_2;
		public System.Windows.Forms.Label _Label1_1;
		public System.Windows.Forms.Label _Label1_0;
		//Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPOSreport));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.chkNoCon = new System.Windows.Forms.CheckBox();
			this.chkOutCon = new System.Windows.Forms.CheckBox();
			this.chkSum = new System.Windows.Forms.CheckBox();
			this.chkFC = new System.Windows.Forms.CheckBox();
			this.lstSaleref = new System.Windows.Forms.CheckedListBox();
			this.cmdLoad = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this.chkReversal = new System.Windows.Forms.CheckBox();
			this.chkRevoke = new System.Windows.Forms.CheckBox();
			this.lstPOS = new System.Windows.Forms.CheckedListBox();
			this.lstChannel = new System.Windows.Forms.CheckedListBox();
			this.lstPerson = new System.Windows.Forms.CheckedListBox();
			this._Label1_3 = new System.Windows.Forms.Label();
			this._Label1_2 = new System.Windows.Forms.Label();
			this._Label1_1 = new System.Windows.Forms.Label();
			this._Label1_0 = new System.Windows.Forms.Label();
			//Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
			this.Text = "Sale Tranaction List ...";
			this.ClientSize = new System.Drawing.Size(672, 308);
			this.Location = new System.Drawing.Point(4, 30);
			this.ControlBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
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
			this.Name = "frmPOSreport";
			this.chkNoCon.Text = "Do not show Consignments";
			this.chkNoCon.Size = new System.Drawing.Size(233, 19);
			this.chkNoCon.Location = new System.Drawing.Point(18, 234);
			this.chkNoCon.TabIndex = 15;
			this.chkNoCon.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkNoCon.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkNoCon.BackColor = System.Drawing.SystemColors.Control;
			this.chkNoCon.CausesValidation = true;
			this.chkNoCon.Enabled = true;
			this.chkNoCon.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkNoCon.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkNoCon.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkNoCon.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkNoCon.TabStop = true;
			this.chkNoCon.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkNoCon.Visible = true;
			this.chkNoCon.Name = "chkNoCon";
			this.chkOutCon.Text = "Only show Outstanding Consignments";
			this.chkOutCon.Size = new System.Drawing.Size(233, 19);
			this.chkOutCon.Location = new System.Drawing.Point(424, 208);
			this.chkOutCon.TabIndex = 14;
			this.chkOutCon.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkOutCon.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkOutCon.BackColor = System.Drawing.SystemColors.Control;
			this.chkOutCon.CausesValidation = true;
			this.chkOutCon.Enabled = true;
			this.chkOutCon.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkOutCon.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkOutCon.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkOutCon.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkOutCon.TabStop = true;
			this.chkOutCon.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkOutCon.Visible = true;
			this.chkOutCon.Name = "chkOutCon";
			this.chkSum.Text = "Only show Summary";
			this.chkSum.Size = new System.Drawing.Size(129, 19);
			this.chkSum.Location = new System.Drawing.Point(288, 208);
			this.chkSum.TabIndex = 13;
			this.chkSum.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkSum.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkSum.BackColor = System.Drawing.SystemColors.Control;
			this.chkSum.CausesValidation = true;
			this.chkSum.Enabled = true;
			this.chkSum.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkSum.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkSum.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkSum.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkSum.TabStop = true;
			this.chkSum.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkSum.Visible = true;
			this.chkSum.Name = "chkSum";
			this.chkFC.Text = "Only show transaction with Foreign Currencies";
			this.chkFC.Size = new System.Drawing.Size(249, 19);
			this.chkFC.Location = new System.Drawing.Point(288, 186);
			this.chkFC.TabIndex = 12;
			this.chkFC.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkFC.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkFC.BackColor = System.Drawing.SystemColors.Control;
			this.chkFC.CausesValidation = true;
			this.chkFC.Enabled = true;
			this.chkFC.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkFC.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkFC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkFC.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkFC.TabStop = true;
			this.chkFC.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkFC.Visible = true;
			this.chkFC.Name = "chkFC";
			this.lstSaleref.Size = new System.Drawing.Size(145, 154);
			this.lstSaleref.Location = new System.Drawing.Point(510, 24);
			this.lstSaleref.Items.AddRange(new object[] {
				"Card Number",
				"Order Number",
				"Serial Number"
			});
			this.lstSaleref.TabIndex = 10;
			this.lstSaleref.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSaleref.BackColor = System.Drawing.SystemColors.Window;
			this.lstSaleref.CausesValidation = true;
			this.lstSaleref.Enabled = true;
			this.lstSaleref.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSaleref.IntegralHeight = true;
			this.lstSaleref.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSaleref.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstSaleref.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSaleref.Sorted = false;
			this.lstSaleref.TabStop = true;
			this.lstSaleref.Visible = true;
			this.lstSaleref.MultiColumn = false;
			this.lstSaleref.Name = "lstSaleref";
			this.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdLoad.Text = "Show/&Print Report";
			this.cmdLoad.Size = new System.Drawing.Size(79, 43);
			this.cmdLoad.Location = new System.Drawing.Point(576, 260);
			this.cmdLoad.TabIndex = 9;
			this.cmdLoad.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLoad.CausesValidation = true;
			this.cmdLoad.Enabled = true;
			this.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLoad.TabStop = true;
			this.cmdLoad.Name = "cmdLoad";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(79, 43);
			this.cmdExit.Location = new System.Drawing.Point(18, 260);
			this.cmdExit.TabIndex = 8;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.TabStop = true;
			this.cmdExit.Name = "cmdExit";
			this.chkReversal.Text = "Only show transaction with one or more Reversals";
			this.chkReversal.Size = new System.Drawing.Size(258, 19);
			this.chkReversal.Location = new System.Drawing.Point(18, 210);
			this.chkReversal.TabIndex = 4;
			this.chkReversal.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkReversal.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkReversal.BackColor = System.Drawing.SystemColors.Control;
			this.chkReversal.CausesValidation = true;
			this.chkReversal.Enabled = true;
			this.chkReversal.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkReversal.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkReversal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkReversal.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkReversal.TabStop = true;
			this.chkReversal.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkReversal.Visible = true;
			this.chkReversal.Name = "chkReversal";
			this.chkRevoke.Text = "Only show transaction with revoked Lines";
			this.chkRevoke.Size = new System.Drawing.Size(234, 19);
			this.chkRevoke.Location = new System.Drawing.Point(18, 186);
			this.chkRevoke.TabIndex = 3;
			this.chkRevoke.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkRevoke.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkRevoke.BackColor = System.Drawing.SystemColors.Control;
			this.chkRevoke.CausesValidation = true;
			this.chkRevoke.Enabled = true;
			this.chkRevoke.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkRevoke.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkRevoke.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkRevoke.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkRevoke.TabStop = true;
			this.chkRevoke.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkRevoke.Visible = true;
			this.chkRevoke.Name = "chkRevoke";
			this.lstPOS.Size = new System.Drawing.Size(145, 154);
			this.lstPOS.Location = new System.Drawing.Point(360, 24);
			this.lstPOS.TabIndex = 2;
			this.lstPOS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstPOS.BackColor = System.Drawing.SystemColors.Window;
			this.lstPOS.CausesValidation = true;
			this.lstPOS.Enabled = true;
			this.lstPOS.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstPOS.IntegralHeight = true;
			this.lstPOS.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstPOS.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstPOS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstPOS.Sorted = false;
			this.lstPOS.TabStop = true;
			this.lstPOS.Visible = true;
			this.lstPOS.MultiColumn = false;
			this.lstPOS.Name = "lstPOS";
			this.lstChannel.Size = new System.Drawing.Size(145, 154);
			this.lstChannel.Location = new System.Drawing.Point(210, 24);
			this.lstChannel.TabIndex = 1;
			this.lstChannel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstChannel.BackColor = System.Drawing.SystemColors.Window;
			this.lstChannel.CausesValidation = true;
			this.lstChannel.Enabled = true;
			this.lstChannel.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstChannel.IntegralHeight = true;
			this.lstChannel.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstChannel.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstChannel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstChannel.Sorted = false;
			this.lstChannel.TabStop = true;
			this.lstChannel.Visible = true;
			this.lstChannel.MultiColumn = false;
			this.lstChannel.Name = "lstChannel";
			this.lstPerson.Size = new System.Drawing.Size(187, 154);
			this.lstPerson.Location = new System.Drawing.Point(18, 24);
			this.lstPerson.TabIndex = 0;
			this.lstPerson.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstPerson.BackColor = System.Drawing.SystemColors.Window;
			this.lstPerson.CausesValidation = true;
			this.lstPerson.Enabled = true;
			this.lstPerson.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstPerson.IntegralHeight = true;
			this.lstPerson.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstPerson.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstPerson.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstPerson.Sorted = false;
			this.lstPerson.TabStop = true;
			this.lstPerson.Visible = true;
			this.lstPerson.MultiColumn = false;
			this.lstPerson.Name = "lstPerson";
			this._Label1_3.Text = "Transaction Reference";
			this._Label1_3.Size = new System.Drawing.Size(109, 13);
			this._Label1_3.Location = new System.Drawing.Point(512, 10);
			this._Label1_3.TabIndex = 11;
			this._Label1_3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_3.BackColor = System.Drawing.Color.Transparent;
			this._Label1_3.Enabled = true;
			this._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_3.UseMnemonic = true;
			this._Label1_3.Visible = true;
			this._Label1_3.AutoSize = true;
			this._Label1_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_3.Name = "_Label1_3";
			this._Label1_2.Text = "POS Devices";
			this._Label1_2.Size = new System.Drawing.Size(64, 13);
			this._Label1_2.Location = new System.Drawing.Point(360, 10);
			this._Label1_2.TabIndex = 7;
			this._Label1_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_2.BackColor = System.Drawing.Color.Transparent;
			this._Label1_2.Enabled = true;
			this._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_2.UseMnemonic = true;
			this._Label1_2.Visible = true;
			this._Label1_2.AutoSize = true;
			this._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_2.Name = "_Label1_2";
			this._Label1_1.Text = "Sale Channels";
			this._Label1_1.Size = new System.Drawing.Size(68, 13);
			this._Label1_1.Location = new System.Drawing.Point(210, 10);
			this._Label1_1.TabIndex = 6;
			this._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_1.BackColor = System.Drawing.Color.Transparent;
			this._Label1_1.Enabled = true;
			this._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_1.UseMnemonic = true;
			this._Label1_1.Visible = true;
			this._Label1_1.AutoSize = true;
			this._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_1.Name = "_Label1_1";
			this._Label1_0.Text = "Persons";
			this._Label1_0.Size = new System.Drawing.Size(38, 13);
			this._Label1_0.Location = new System.Drawing.Point(21, 10);
			this._Label1_0.TabIndex = 5;
			this._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_0.BackColor = System.Drawing.Color.Transparent;
			this._Label1_0.Enabled = true;
			this._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_0.UseMnemonic = true;
			this._Label1_0.Visible = true;
			this._Label1_0.AutoSize = true;
			this._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_0.Name = "_Label1_0";
			this.Controls.Add(chkNoCon);
			this.Controls.Add(chkOutCon);
			this.Controls.Add(chkSum);
			this.Controls.Add(chkFC);
			this.Controls.Add(lstSaleref);
			this.Controls.Add(cmdLoad);
			this.Controls.Add(cmdExit);
			this.Controls.Add(chkReversal);
			this.Controls.Add(chkRevoke);
			this.Controls.Add(lstPOS);
			this.Controls.Add(lstChannel);
			this.Controls.Add(lstPerson);
			this.Controls.Add(_Label1_3);
			this.Controls.Add(_Label1_2);
			this.Controls.Add(_Label1_1);
			this.Controls.Add(_Label1_0);
			//Me.Label1.SetIndex(_Label1_3, CType(3, Short))
			//Me.Label1.SetIndex(_Label1_2, CType(2, Short))
			//Me.Label1.SetIndex(_Label1_1, CType(1, Short))
			//Me.Label1.SetIndex(_Label1_0, CType(0, Short))
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
