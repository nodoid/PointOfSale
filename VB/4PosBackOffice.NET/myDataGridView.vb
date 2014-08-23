Friend Class myDataGridView
    Inherits DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView

    Public Property CtlText As String
        Get
            Return Me.BoundText
        End Get
        Set(value As String)
            Me.BoundText = value
        End Set
    End Property

    Public Property Col As Integer
        Get
            Return Me.ColumnCount
        End Get
        Set(value As Integer)
            Me.ColumnCount = value
        End Set
    End Property

    Public Property boundColumn As String
        Set(value As String)
            Me.Columns(0).DataPropertyName = value
        End Set
        Get
            Return Me.Columns(0).DataPropertyName
        End Get
    End Property

    Public Property listField As String
        Set(value As String)
            Me.CurrentRow.DataGridView.DataMember = value
        End Set
        Get
            Return Me.CurrentRow.DataGridView.DataMember
        End Get
    End Property

    Public Property row As Integer
        Set(value As Integer)
            Me.RowCount = value
        End Set
        Get
            Return Me.RowCount
        End Get
    End Property
    Public Property BoundText As String
        Set(value As String)
            Me.DataMember = value
        End Set
        Get
            Return Me.DataMember
        End Get

    End Property

    Public Property DataField As Object
        Set(value As Object)
            Me.DataSource = value
        End Set
        Get
            Return Me.DataSource
        End Get
    End Property

    Public Sub set_RowData(ByRef rowSet As Integer, ByRef value As Object)
        Me.Rows(rowSet).Cells.Add(value)
    End Sub

    Public Property CellBackColor As Color
        Get
            Return Me.BackgroundColor
        End Get
        Set(value As Color)
            Me.BackgroundColor = value
        End Set
    End Property

    Public Sub set_TextMatrix(ByRef myRow As Integer, ByRef myColumn As Integer, ByRef myValue As String)
        Me.Rows(myRow).Cells(myColumn).Value = myValue
    End Sub

    Public Function get_TextMatrix(ByRef myRow As Integer, ByRef myCol As Integer) As String
        Return Me.Rows(myRow).Cells(myCol).Value.ToString
    End Function

    Public Sub set_RowHeight(ByRef myRow As Integer, ByRef height As Integer)
        Me.Rows(myRow).Height = height
    End Sub

    Public WriteOnly Property CellFontBold As Boolean
        Set(value As Boolean)
            If value = True Then
                Me.CurrentCell.Style.Font = New Font(Me.Font, FontStyle.Bold)
            Else
                Me.CurrentCell.Style.Font = New Font(Me.Font, FontStyle.Regular)
            End If
        End Set
    End Property

    Public Sub set_ColWidth(ByRef myCol As Integer, ByRef width As Integer)
        Me.Columns(myCol).Width = width
    End Sub

    Public Function get_ColWidth(ByRef myCol As Integer) As Integer
        Return Me.Columns(myCol).Width
    End Function

    Public Sub CtlRefresh()
        Me.Invalidate()
    End Sub

    Public WriteOnly Property CellAlignment As Integer
        Set(value As Integer)
            Select Case value
                Case 0
                    Me.CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopLeft
                Case 1
                    Me.CurrentCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case 2
                    Me.CurrentCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                Case 3
                    Me.CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
                Case 4
                    Me.CurrentCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case 5
                    Me.CurrentCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
                Case 6
                    Me.CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopRight
                Case 7
                    Me.CurrentCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                Case 8
                    Me.CurrentCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                Case 9
                    Me.CurrentCell.Style.Alignment = DataGridViewContentAlignment.NotSet
            End Select
        End Set
    End Property

    Public WriteOnly Property Alignment As Integer
        Set(value As Integer)
            Select Case value
                Case 0
                    Me.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
                Case 1
                    Me.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case 2
                    Me.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                Case 3
                    Me.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
                Case 4
                    Me.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case 5
                    Me.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                Case 6
                    Me.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                Case 7
                    Me.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case 8
                    Me.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                Case 9
                    Me.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
            End Select
        End Set
    End Property

    Public Sub set_colAlignment(ByRef myCol As Integer, ByRef align As Integer)
        Select Case align
            Case 0
                Me.Columns(myCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
            Case 1
                Me.Columns(myCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Case 2
                Me.Columns(myCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            Case 3
                Me.Columns(myCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
            Case 4
                Me.Columns(myCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Case 5
                Me.Columns(myCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            Case 6
                Me.Columns(myCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Case 7
                Me.Columns(myCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Case 8
                Me.Columns(myCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            Case 9
                Me.Columns(myCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        End Select
    End Sub

    Public Function get_RowData(ByRef myRow) As Integer
        Return Me.Rows(myRow).Cells(0).Value
    End Function

    Public ReadOnly Property CellWidth As Integer
        Get
            Dim r As Rectangle
            r = Me.GetCellDisplayRectangle(Me.CurrentCell.ColumnIndex, Me.CurrentCell.RowIndex, False)
            Return r.Width
        End Get
    End Property

    Public ReadOnly Property CellLeft As Integer
        Get
            Dim r As Rectangle
            r = Me.GetCellDisplayRectangle(Me.CurrentCell.ColumnIndex, Me.CurrentCell.RowIndex, False)
            Return r.Left
        End Get
    End Property

    Public ReadOnly Property CellHeight As Integer
        Get
            Dim r As Rectangle
            r = Me.GetCellDisplayRectangle(Me.CurrentCell.ColumnIndex, Me.CurrentCell.RowIndex, False)
            Return r.Height
        End Get
    End Property

    Public ReadOnly Property CellTop As Integer
        Get
            Dim r As Rectangle
            Me.GetCellDisplayRectangle(Me.CurrentCell.ColumnIndex, Me.CurrentCell.RowIndex, False)
            Return r.Top
        End Get
    End Property

    Public Function get_RowHeight(ByRef rowID As Integer) As Integer
        Dim rs As Rectangle = Me.GetRowDisplayRectangle(rowID, False)
        Return rs.Height
    End Function

    Public Property FixedRow As Integer
        Get
            Return Me.CurrentRow.State
        End Get
        Set(value As Integer)
            Me.CurrentRow.Resizable = value
        End Set
    End Property

    Public Property FixedCols As Integer
        Get
            Return Me.Columns(0).State
        End Get
        Set(value As Integer)
            Me.Columns(0).Resizable = value
        End Set
    End Property

    Public Property TopRow As Integer
        Get

        End Get
        Set(value As Integer)

        End Set
    End Property

    Public Property FixedRows As Integer
        Get
            Dim rc As Integer = 0
            Dim c As Integer
            For c = 0 To Me.RowCount
                If Me.CurrentRow.State <> DataGridViewElementStates.Resizable Then
                    rc = rc + 1
                End If
            Next
            Return rc
        End Get
        Set(value As Integer)
            Me.CurrentRow.Resizable = value
        End Set
    End Property
    Public Property AllowAddNew As Boolean
        Get
            Return Me.AllowUserToAddRows
        End Get
        Set(value As Boolean)
            Me.AllowUserToAddRows = value
        End Set
    End Property
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(240, 150)
        Me.DataGridView1.TabIndex = 0
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
End Class
