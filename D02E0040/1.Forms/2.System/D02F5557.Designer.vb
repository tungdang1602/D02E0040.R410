<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D02F5557
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D02F5557))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.chkLockedVouchers = New System.Windows.Forms.CheckBox
        Me.tdbcTransactionID = New C1.Win.C1List.C1Combo
        Me.lblTransactionID = New System.Windows.Forms.Label
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        CType(Me.tdbcTransactionID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkLockedVouchers
        '
        Me.chkLockedVouchers.AutoSize = True
        Me.chkLockedVouchers.Location = New System.Drawing.Point(19, 11)
        Me.chkLockedVouchers.Name = "chkLockedVouchers"
        Me.chkLockedVouchers.Size = New System.Drawing.Size(117, 17)
        Me.chkLockedVouchers.TabIndex = 0
        Me.chkLockedVouchers.Text = "Các phiếu đã khóa"
        Me.chkLockedVouchers.UseVisualStyleBackColor = True
        '
        'tdbcTransactionID
        '
        Me.tdbcTransactionID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcTransactionID.AllowColMove = False
        Me.tdbcTransactionID.AllowSort = False
        Me.tdbcTransactionID.AlternatingRows = True
        Me.tdbcTransactionID.AutoDropDown = True
        Me.tdbcTransactionID.Caption = ""
        Me.tdbcTransactionID.CaptionHeight = 17
        Me.tdbcTransactionID.CaptionStyle = Style1
        Me.tdbcTransactionID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcTransactionID.ColumnCaptionHeight = 17
        Me.tdbcTransactionID.ColumnFooterHeight = 17
        Me.tdbcTransactionID.ColumnWidth = 100
        Me.tdbcTransactionID.ContentHeight = 17
        Me.tdbcTransactionID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcTransactionID.DisplayMember = "Description"
        Me.tdbcTransactionID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.RightDown
        Me.tdbcTransactionID.DropDownWidth = 300
        Me.tdbcTransactionID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcTransactionID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTransactionID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcTransactionID.EditorHeight = 17
        Me.tdbcTransactionID.EmptyRows = True
        Me.tdbcTransactionID.EvenRowStyle = Style2
        Me.tdbcTransactionID.ExtendRightColumn = True
        Me.tdbcTransactionID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTransactionID.FooterStyle = Style3
        Me.tdbcTransactionID.HeadingStyle = Style4
        Me.tdbcTransactionID.HighLightRowStyle = Style5
        Me.tdbcTransactionID.Images.Add(CType(resources.GetObject("tdbcTransactionID.Images"), System.Drawing.Image))
        Me.tdbcTransactionID.ItemHeight = 15
        Me.tdbcTransactionID.Location = New System.Drawing.Point(726, 8)
        Me.tdbcTransactionID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcTransactionID.MaxDropDownItems = CType(8, Short)
        Me.tdbcTransactionID.MaxLength = 32767
        Me.tdbcTransactionID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcTransactionID.Name = "tdbcTransactionID"
        Me.tdbcTransactionID.OddRowStyle = Style6
        Me.tdbcTransactionID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcTransactionID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcTransactionID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcTransactionID.SelectedStyle = Style7
        Me.tdbcTransactionID.Size = New System.Drawing.Size(289, 23)
        Me.tdbcTransactionID.Style = Style8
        Me.tdbcTransactionID.TabIndex = 1
        Me.tdbcTransactionID.ValueMember = "TransactionType"
        Me.tdbcTransactionID.PropBag = resources.GetString("tdbcTransactionID.PropBag")
        '
        'lblTransactionID
        '
        Me.lblTransactionID.AutoSize = True
        Me.lblTransactionID.Location = New System.Drawing.Point(632, 13)
        Me.lblTransactionID.Name = "lblTransactionID"
        Me.lblTransactionID.Size = New System.Drawing.Size(56, 13)
        Me.lblTransactionID.TabIndex = 2
        Me.lblTransactionID.Text = "Nghiệp vụ"
        Me.lblTransactionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FetchRowStyles = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(3, 44)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(1012, 581)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(0, 0)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 3
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsFind, Me.mnsListAll})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(137, 48)
        '
        'mnsFind
        '
        Me.mnsFind.Name = "mnsFind"
        Me.mnsFind.Size = New System.Drawing.Size(136, 22)
        Me.mnsFind.Text = "Tìm &kiếm"
        '
        'mnsListAll
        '
        Me.mnsListAll.Name = "mnsListAll"
        Me.mnsListAll.Size = New System.Drawing.Size(136, 22)
        Me.mnsListAll.Text = "&Liệt kê tất cả"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(857, 630)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(939, 630)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'D02F5557
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.tdbcTransactionID)
        Me.Controls.Add(Me.chkLockedVouchers)
        Me.Controls.Add(Me.lblTransactionID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D02F5557"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Khâa phiÕu - D02F5557"
        CType(Me.tdbcTransactionID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents chkLockedVouchers As System.Windows.Forms.CheckBox
    Private WithEvents tdbcTransactionID As C1.Win.C1List.C1Combo
    Private WithEvents lblTransactionID As System.Windows.Forms.Label
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsListAll As System.Windows.Forms.ToolStripMenuItem
End Class
