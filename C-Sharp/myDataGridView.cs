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
	internal class myDataGridView : DataGridView
	{

		internal System.Windows.Forms.DataGridView DataGridView1;
		public string CtlText {
			get { return this.BoundText; }
			set { this.BoundText = value; }
		}

		public int Col {
			get { return this.ColumnCount; }
			set { this.ColumnCount = value; }
		}

		public string boundColumn {
			get { return this.Columns[0].DataPropertyName; }
			set { this.Columns[0].DataPropertyName = value; }
		}

		public string listField {
			get { return this.CurrentRow.DataGridView.DataMember; }
			set { this.CurrentRow.DataGridView.DataMember = value; }
		}

		public int row {
			get { return this.RowCount; }
			set { this.RowCount = value; }
		}
		public string BoundText {
			get { return this.DataMember; }
			set { this.DataMember = value; }
		}


		public object DataField {
			get { return this.DataSource; }
			set { this.DataSource = value; }
		}

		public void set_RowData(ref int rowSet, ref object value)
		{
			this.Rows[rowSet].Cells.Add(value);
		}

		public Color CellBackColor {
			get { return this.BackgroundColor; }
			set { this.BackgroundColor = value; }
		}

		public void set_TextMatrix(ref int myRow, ref int myColumn, ref string myValue)
		{
			this.Rows[myRow].Cells[myColumn].Value = myValue;
		}

		public string get_TextMatrix(ref int myRow, ref int myCol)
		{
			return this.Rows[myRow].Cells[myCol].Value.ToString();
		}

		public void set_RowHeight(ref int myRow, ref int height)
		{
			this.Rows[myRow].Height = height;
		}

		public bool CellFontBold {
			set {
				if (value == true) {
					this.CurrentCell.Style.Font = new Font(this.Font, FontStyle.Bold);
				} else {
					this.CurrentCell.Style.Font = new Font(this.Font, FontStyle.Regular);
				}
			}
		}

		public void set_ColWidth(ref int myCol, ref int width)
		{
			this.Columns[myCol].Width = width;
		}

		public int get_ColWidth(ref int myCol)
		{
			return this.Columns[myCol].Width;
		}

		public void CtlRefresh()
		{
			this.Invalidate();
		}

		public int CellAlignment {
			set {
				switch (value) {
					case 0:
						this.CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
						break;
					case 1:
						this.CurrentCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
						break;
					case 2:
						this.CurrentCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft;
						break;
					case 3:
						this.CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
						break;
					case 4:
						this.CurrentCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
						break;
					case 5:
						this.CurrentCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
						break;
					case 6:
						this.CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopRight;
						break;
					case 7:
						this.CurrentCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
						break;
					case 8:
						this.CurrentCell.Style.Alignment = DataGridViewContentAlignment.BottomRight;
						break;
					case 9:
						this.CurrentCell.Style.Alignment = DataGridViewContentAlignment.NotSet;
						break;
				}
			}
		}

		public int Alignment {
			set {
				switch (value) {
					case 0:
						this.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
						break;
					case 1:
						this.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
						break;
					case 2:
						this.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
						break;
					case 3:
						this.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
						break;
					case 4:
						this.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
						break;
					case 5:
						this.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
						break;
					case 6:
						this.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
						break;
					case 7:
						this.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
						break;
					case 8:
						this.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
						break;
					case 9:
						this.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet;
						break;
				}
			}
		}

		public void set_colAlignment(ref int myCol, ref int align)
		{
			switch (align) {
				case 0:
					this.Columns[myCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
					break;
				case 1:
					this.Columns[myCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
					break;
				case 2:
					this.Columns[myCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
					break;
				case 3:
					this.Columns[myCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
					break;
				case 4:
					this.Columns[myCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					break;
				case 5:
					this.Columns[myCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
					break;
				case 6:
					this.Columns[myCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
					break;
				case 7:
					this.Columns[myCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					break;
				case 8:
					this.Columns[myCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
					break;
				case 9:
					this.Columns[myCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet;
					break;
			}
		}

		public int get_RowData(ref myRow)
		{
			return this.Rows[myRow].Cells[0].Value;
		}

		public int CellWidth {
			get {
				Rectangle r = default(Rectangle);
				r = this.GetCellDisplayRectangle(this.CurrentCell.ColumnIndex, this.CurrentCell.RowIndex, false);
				return r.Width;
			}
		}

		public int CellLeft {
			get {
				Rectangle r = default(Rectangle);
				r = this.GetCellDisplayRectangle(this.CurrentCell.ColumnIndex, this.CurrentCell.RowIndex, false);
				return r.Left;
			}
		}

		public int CellHeight {
			get {
				Rectangle r = default(Rectangle);
				r = this.GetCellDisplayRectangle(this.CurrentCell.ColumnIndex, this.CurrentCell.RowIndex, false);
				return r.Height;
			}
		}

		public int CellTop {
			get {
				Rectangle r = default(Rectangle);
				this.GetCellDisplayRectangle(this.CurrentCell.ColumnIndex, this.CurrentCell.RowIndex, false);
				return r.Top;
			}
		}

		public int get_RowHeight(ref int rowID)
		{
			Rectangle rs = this.GetRowDisplayRectangle(rowID, false);
			return rs.Height;
		}

		public int FixedRow {
			get { return this.CurrentRow.State; }
			set { this.CurrentRow.Resizable = value; }
		}

		public int FixedCols {
			get { return this.Columns[0].State; }
			set { this.Columns[0].Resizable = value; }
		}

		public int TopRow {

			get { }

			set { }
		}

		public int FixedRows {
			get {
				int rc = 0;
				int c = 0;
				for (c = 0; c <= this.RowCount; c++) {
					if (this.CurrentRow.State != DataGridViewElementStates.Resizable) {
						rc = rc + 1;
					}
				}
				return rc;
			}
			set { this.CurrentRow.Resizable = value; }
		}
		public bool AllowAddNew {
			get { return this.AllowUserToAddRows; }
			set { this.AllowUserToAddRows = value; }
		}
		private void InitializeComponent()
		{
			this.DataGridView1 = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)this.DataGridView1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this).BeginInit();
			this.SuspendLayout();
			//
			//DataGridView1
			//
			this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridView1.Location = new System.Drawing.Point(0, 0);
			this.DataGridView1.Name = "DataGridView1";
			this.DataGridView1.Size = new System.Drawing.Size(240, 150);
			this.DataGridView1.TabIndex = 0;
			((System.ComponentModel.ISupportInitialize)this.DataGridView1).EndInit();
			((System.ComponentModel.ISupportInitialize)this).EndInit();
			this.ResumeLayout(false);

		}
	}
}
