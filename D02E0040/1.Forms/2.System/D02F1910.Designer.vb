<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D02F1910
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D02F1910))
        Me.tabMain = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.tdbg1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.tdbg2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.tdbg3 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.tabMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.tdbg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.tdbg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.tdbg3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.TabPage1)
        Me.tabMain.Controls.Add(Me.TabPage2)
        Me.tabMain.Controls.Add(Me.TabPage3)
        Me.tabMain.Location = New System.Drawing.Point(5, 5)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(890, 322)
        Me.tabMain.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tdbg1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(882, 296)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "1. Hình thành TSCĐ"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tdbg1
        '
        Me.tdbg1.AllowColMove = False
        Me.tdbg1.AllowColSelect = False
        Me.tdbg1.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg1.AllowSort = False
        Me.tdbg1.AlternatingRows = True
        Me.tdbg1.CaptionHeight = 17
        Me.tdbg1.ColumnFooters = True
        Me.tdbg1.EmptyRows = True
        Me.tdbg1.ExtendRightColumn = True
        Me.tdbg1.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg1.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg1.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg1.Images.Add(CType(resources.GetObject("tdbg1.Images"), System.Drawing.Image))
        Me.tdbg1.Location = New System.Drawing.Point(6, 6)
        Me.tdbg1.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg1.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg1.Name = "tdbg1"
        Me.tdbg1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg1.PreviewInfo.ZoomFactor = 75
        Me.tdbg1.PrintInfo.PageSettings = CType(resources.GetObject("tdbg1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg1.RowHeight = 15
        Me.tdbg1.Size = New System.Drawing.Size(872, 286)
        Me.tdbg1.TabAcrossSplits = True
        Me.tdbg1.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg1.TabIndex = 0
        Me.tdbg1.Tag = "COL1"
        Me.tdbg1.PropBag = resources.GetString("tdbg1.PropBag")
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.tdbg2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(882, 296)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "2. Mã TSCĐ"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'tdbg2
        '
        Me.tdbg2.AllowColMove = False
        Me.tdbg2.AllowColSelect = False
        Me.tdbg2.AllowFilter = False
        Me.tdbg2.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg2.AllowSort = False
        Me.tdbg2.AlternatingRows = True
        Me.tdbg2.CaptionHeight = 17
        Me.tdbg2.ColumnFooters = True
        Me.tdbg2.EmptyRows = True
        Me.tdbg2.ExtendRightColumn = True
        Me.tdbg2.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg2.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg2.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg2.Images.Add(CType(resources.GetObject("tdbg2.Images"), System.Drawing.Image))
        Me.tdbg2.Location = New System.Drawing.Point(6, 6)
        Me.tdbg2.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg2.Name = "tdbg2"
        Me.tdbg2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg2.PreviewInfo.ZoomFactor = 75
        Me.tdbg2.PrintInfo.PageSettings = CType(resources.GetObject("tdbg2.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg2.RowHeight = 15
        Me.tdbg2.Size = New System.Drawing.Size(873, 286)
        Me.tdbg2.TabAcrossSplits = True
        Me.tdbg2.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg2.TabIndex = 0
        Me.tdbg2.Tag = "COL2"
        Me.tdbg2.PropBag = resources.GetString("tdbg2.PropBag")
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.tdbg3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(882, 296)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "3. Mã XDCB"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'tdbg3
        '
        Me.tdbg3.AllowColMove = False
        Me.tdbg3.AllowColSelect = False
        Me.tdbg3.AllowFilter = False
        Me.tdbg3.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg3.AllowSort = False
        Me.tdbg3.AlternatingRows = True
        Me.tdbg3.CaptionHeight = 17
        Me.tdbg3.ColumnFooters = True
        Me.tdbg3.EmptyRows = True
        Me.tdbg3.ExtendRightColumn = True
        Me.tdbg3.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg3.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg3.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg3.Images.Add(CType(resources.GetObject("tdbg3.Images"), System.Drawing.Image))
        Me.tdbg3.Location = New System.Drawing.Point(6, 6)
        Me.tdbg3.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg3.Name = "tdbg3"
        Me.tdbg3.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg3.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg3.PreviewInfo.ZoomFactor = 75
        Me.tdbg3.PrintInfo.PageSettings = CType(resources.GetObject("tdbg3.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg3.RowHeight = 15
        Me.tdbg3.Size = New System.Drawing.Size(870, 286)
        Me.tdbg3.TabAcrossSplits = True
        Me.tdbg3.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg3.TabIndex = 0
        Me.tdbg3.Tag = "COL3"
        Me.tdbg3.PropBag = resources.GetString("tdbg3.PropBag")
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(819, 329)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(737, 329)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        '
        'D02F1910
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 355)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D02F1910"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "˜Ünh nghÚa th¤ng tin bå sung - D00F1910"
        Me.tabMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.tdbg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.tdbg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.tdbg3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Private WithEvents tdbg1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Private WithEvents tdbg2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Private WithEvents tdbg3 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
