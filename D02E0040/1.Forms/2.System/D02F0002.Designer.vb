<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D02F0002
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D02F0002))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.tabOption = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.chkShowReportPathNextTime = New System.Windows.Forms.CheckBox
        Me.chkLockConvertedAmount = New System.Windows.Forms.CheckBox
        Me.chkSaveLastRecent = New System.Windows.Forms.CheckBox
        Me.chkViewFormPeriodWhenAppRun = New System.Windows.Forms.CheckBox
        Me.chkMessageWhenSaveOK = New System.Windows.Forms.CheckBox
        Me.chkMessageAskBeforeSave = New System.Windows.Forms.CheckBox
        Me.grp1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tdbcDivisionID = New C1.Win.C1List.C1Combo
        Me.txtDivisionName = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.grpReportLanguage = New System.Windows.Forms.GroupBox
        Me.optEnglish = New System.Windows.Forms.RadioButton
        Me.optVietnameseEnglish = New System.Windows.Forms.RadioButton
        Me.optVietnamese = New System.Windows.Forms.RadioButton
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.grpCopy = New System.Windows.Forms.GroupBox
        Me.chkDepAndEmpID = New System.Windows.Forms.CheckBox
        Me.chkCipName = New System.Windows.Forms.CheckBox
        Me.chkCipDescription = New System.Windows.Forms.CheckBox
        Me.tabOption.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.grp1.SuspendLayout()
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.grpReportLanguage.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.grpCopy.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(468, 280)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(385, 280)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tabOption
        '
        Me.tabOption.Controls.Add(Me.TabPage1)
        Me.tabOption.Controls.Add(Me.TabPage2)
        Me.tabOption.Controls.Add(Me.TabPage3)
        Me.tabOption.Location = New System.Drawing.Point(12, 12)
        Me.tabOption.Name = "tabOption"
        Me.tabOption.SelectedIndex = 0
        Me.tabOption.Size = New System.Drawing.Size(532, 262)
        Me.tabOption.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chkShowReportPathNextTime)
        Me.TabPage1.Controls.Add(Me.chkLockConvertedAmount)
        Me.TabPage1.Controls.Add(Me.chkSaveLastRecent)
        Me.TabPage1.Controls.Add(Me.chkViewFormPeriodWhenAppRun)
        Me.TabPage1.Controls.Add(Me.chkMessageWhenSaveOK)
        Me.TabPage1.Controls.Add(Me.chkMessageAskBeforeSave)
        Me.TabPage1.Controls.Add(Me.grp1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(524, 236)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Mặc định"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkShowReportPathNextTime
        '
        Me.chkShowReportPathNextTime.AutoSize = True
        Me.chkShowReportPathNextTime.Location = New System.Drawing.Point(18, 187)
        Me.chkShowReportPathNextTime.Name = "chkShowReportPathNextTime"
        Me.chkShowReportPathNextTime.Size = New System.Drawing.Size(263, 17)
        Me.chkShowReportPathNextTime.TabIndex = 6
        Me.chkShowReportPathNextTime.Text = "Hiển thị màn hình đường dẫn báo cáo cho lần sau"
        Me.chkShowReportPathNextTime.UseVisualStyleBackColor = True
        '
        'chkLockConvertedAmount
        '
        Me.chkLockConvertedAmount.AutoSize = True
        Me.chkLockConvertedAmount.Location = New System.Drawing.Point(18, 141)
        Me.chkLockConvertedAmount.Name = "chkLockConvertedAmount"
        Me.chkLockConvertedAmount.Size = New System.Drawing.Size(123, 17)
        Me.chkLockConvertedAmount.TabIndex = 4
        Me.chkLockConvertedAmount.Text = "Khóa số tiền quy đổi"
        Me.chkLockConvertedAmount.UseVisualStyleBackColor = True
        '
        'chkSaveLastRecent
        '
        Me.chkSaveLastRecent.AutoSize = True
        Me.chkSaveLastRecent.Location = New System.Drawing.Point(18, 118)
        Me.chkSaveLastRecent.Name = "chkSaveLastRecent"
        Me.chkSaveLastRecent.Size = New System.Drawing.Size(202, 17)
        Me.chkSaveLastRecent.TabIndex = 3
        Me.chkSaveLastRecent.Text = "Lưu các giá trị gần nhất khi nhập tiếp"
        Me.chkSaveLastRecent.UseVisualStyleBackColor = True
        '
        'chkViewFormPeriodWhenAppRun
        '
        Me.chkViewFormPeriodWhenAppRun.AutoSize = True
        Me.chkViewFormPeriodWhenAppRun.Location = New System.Drawing.Point(18, 164)
        Me.chkViewFormPeriodWhenAppRun.Name = "chkViewFormPeriodWhenAppRun"
        Me.chkViewFormPeriodWhenAppRun.Size = New System.Drawing.Size(293, 17)
        Me.chkViewFormPeriodWhenAppRun.TabIndex = 5
        Me.chkViewFormPeriodWhenAppRun.Text = "Hiển thị màn hình chọn kỳ kế toán khi chạy chương trình"
        Me.chkViewFormPeriodWhenAppRun.UseVisualStyleBackColor = True
        '
        'chkMessageWhenSaveOK
        '
        Me.chkMessageWhenSaveOK.AutoSize = True
        Me.chkMessageWhenSaveOK.Location = New System.Drawing.Point(18, 95)
        Me.chkMessageWhenSaveOK.Name = "chkMessageWhenSaveOK"
        Me.chkMessageWhenSaveOK.Size = New System.Drawing.Size(169, 17)
        Me.chkMessageWhenSaveOK.TabIndex = 2
        Me.chkMessageWhenSaveOK.Text = "Thông báo khi lưu thành công"
        Me.chkMessageWhenSaveOK.UseVisualStyleBackColor = True
        '
        'chkMessageAskBeforeSave
        '
        Me.chkMessageAskBeforeSave.AutoSize = True
        Me.chkMessageAskBeforeSave.Location = New System.Drawing.Point(18, 72)
        Me.chkMessageAskBeforeSave.Name = "chkMessageAskBeforeSave"
        Me.chkMessageAskBeforeSave.Size = New System.Drawing.Size(103, 17)
        Me.chkMessageAskBeforeSave.TabIndex = 1
        Me.chkMessageAskBeforeSave.Text = "Hỏi trước khi lưu"
        Me.chkMessageAskBeforeSave.UseVisualStyleBackColor = True
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.Label1)
        Me.grp1.Controls.Add(Me.tdbcDivisionID)
        Me.grp1.Controls.Add(Me.txtDivisionName)
        Me.grp1.Location = New System.Drawing.Point(6, 6)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(510, 51)
        Me.grp1.TabIndex = 0
        Me.grp1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Đơn vị mặc định"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcDivisionID
        '
        Me.tdbcDivisionID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcDivisionID.AllowColMove = False
        Me.tdbcDivisionID.AllowSort = False
        Me.tdbcDivisionID.AlternatingRows = True
        Me.tdbcDivisionID.AutoCompletion = True
        Me.tdbcDivisionID.AutoDropDown = True
        Me.tdbcDivisionID.Caption = ""
        Me.tdbcDivisionID.CaptionHeight = 17
        Me.tdbcDivisionID.CaptionStyle = Style1
        Me.tdbcDivisionID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcDivisionID.ColumnCaptionHeight = 17
        Me.tdbcDivisionID.ColumnFooterHeight = 17
        Me.tdbcDivisionID.ColumnWidth = 100
        Me.tdbcDivisionID.ContentHeight = 17
        Me.tdbcDivisionID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcDivisionID.DisplayMember = "DivisionID"
        Me.tdbcDivisionID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcDivisionID.DropDownWidth = 400
        Me.tdbcDivisionID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcDivisionID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDivisionID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcDivisionID.EditorHeight = 17
        Me.tdbcDivisionID.EmptyRows = True
        Me.tdbcDivisionID.EvenRowStyle = Style2
        Me.tdbcDivisionID.ExtendRightColumn = True
        Me.tdbcDivisionID.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.tdbcDivisionID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDivisionID.FooterStyle = Style3
        Me.tdbcDivisionID.HeadingStyle = Style4
        Me.tdbcDivisionID.HighLightRowStyle = Style5
        Me.tdbcDivisionID.Images.Add(CType(resources.GetObject("tdbcDivisionID.Images"), System.Drawing.Image))
        Me.tdbcDivisionID.ItemHeight = 15
        Me.tdbcDivisionID.Location = New System.Drawing.Point(123, 19)
        Me.tdbcDivisionID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcDivisionID.MaxDropDownItems = CType(8, Short)
        Me.tdbcDivisionID.MaxLength = 32767
        Me.tdbcDivisionID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDivisionID.Name = "tdbcDivisionID"
        Me.tdbcDivisionID.OddRowStyle = Style6
        Me.tdbcDivisionID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcDivisionID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDivisionID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDivisionID.SelectedStyle = Style7
        Me.tdbcDivisionID.Size = New System.Drawing.Size(128, 23)
        Me.tdbcDivisionID.Style = Style8
        Me.tdbcDivisionID.TabIndex = 1
        Me.tdbcDivisionID.ValueMember = "DivisionID"
        Me.tdbcDivisionID.PropBag = resources.GetString("tdbcDivisionID.PropBag")
        '
        'txtDivisionName
        '
        Me.txtDivisionName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtDivisionName.Location = New System.Drawing.Point(252, 19)
        Me.txtDivisionName.Name = "txtDivisionName"
        Me.txtDivisionName.ReadOnly = True
        Me.txtDivisionName.Size = New System.Drawing.Size(252, 22)
        Me.txtDivisionName.TabIndex = 2
        Me.txtDivisionName.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grpReportLanguage)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(524, 236)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Báo cáo"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grpReportLanguage
        '
        Me.grpReportLanguage.Controls.Add(Me.optEnglish)
        Me.grpReportLanguage.Controls.Add(Me.optVietnameseEnglish)
        Me.grpReportLanguage.Controls.Add(Me.optVietnamese)
        Me.grpReportLanguage.Location = New System.Drawing.Point(7, 7)
        Me.grpReportLanguage.Name = "grpReportLanguage"
        Me.grpReportLanguage.Size = New System.Drawing.Size(509, 221)
        Me.grpReportLanguage.TabIndex = 0
        Me.grpReportLanguage.TabStop = False
        Me.grpReportLanguage.Text = "Ngôn ngữ báo cáo"
        '
        'optEnglish
        '
        Me.optEnglish.AutoSize = True
        Me.optEnglish.Location = New System.Drawing.Point(361, 38)
        Me.optEnglish.Name = "optEnglish"
        Me.optEnglish.Size = New System.Drawing.Size(74, 17)
        Me.optEnglish.TabIndex = 2
        Me.optEnglish.TabStop = True
        Me.optEnglish.Text = "Tiếng Anh"
        Me.optEnglish.UseVisualStyleBackColor = True
        '
        'optVietnameseEnglish
        '
        Me.optVietnameseEnglish.AutoSize = True
        Me.optVietnameseEnglish.Location = New System.Drawing.Point(172, 38)
        Me.optVietnameseEnglish.Name = "optVietnameseEnglish"
        Me.optVietnameseEnglish.Size = New System.Drawing.Size(120, 17)
        Me.optVietnameseEnglish.TabIndex = 1
        Me.optVietnameseEnglish.TabStop = True
        Me.optVietnameseEnglish.Text = "Song ngữ Việt - Anh"
        Me.optVietnameseEnglish.UseVisualStyleBackColor = True
        '
        'optVietnamese
        '
        Me.optVietnamese.AutoSize = True
        Me.optVietnamese.Location = New System.Drawing.Point(36, 38)
        Me.optVietnamese.Name = "optVietnamese"
        Me.optVietnamese.Size = New System.Drawing.Size(73, 17)
        Me.optVietnamese.TabIndex = 0
        Me.optVietnamese.TabStop = True
        Me.optVietnamese.Text = "Tiếng Việt"
        Me.optVietnamese.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.grpCopy)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(524, 236)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Sao chép"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'grpCopy
        '
        Me.grpCopy.Controls.Add(Me.chkCipDescription)
        Me.grpCopy.Controls.Add(Me.chkCipName)
        Me.grpCopy.Controls.Add(Me.chkDepAndEmpID)
        Me.grpCopy.Location = New System.Drawing.Point(6, 6)
        Me.grpCopy.Name = "grpCopy"
        Me.grpCopy.Size = New System.Drawing.Size(512, 224)
        Me.grpCopy.TabIndex = 0
        Me.grpCopy.TabStop = False
        Me.grpCopy.Text = "Sao chép các thông tin từ XDCB sang tài sản"
        '
        'chkDepAndEmpID
        '
        Me.chkDepAndEmpID.AutoSize = True
        Me.chkDepAndEmpID.Location = New System.Drawing.Point(21, 29)
        Me.chkDepAndEmpID.Name = "chkDepAndEmpID"
        Me.chkDepAndEmpID.Size = New System.Drawing.Size(204, 17)
        Me.chkDepAndEmpID.TabIndex = 0
        Me.chkDepAndEmpID.Text = "Bộ phận tiếp nhận và người tiếp nhận"
        Me.chkDepAndEmpID.UseVisualStyleBackColor = True
        '
        'chkCipName
        '
        Me.chkCipName.AutoSize = True
        Me.chkCipName.Location = New System.Drawing.Point(21, 62)
        Me.chkCipName.Name = "chkCipName"
        Me.chkCipName.Size = New System.Drawing.Size(77, 17)
        Me.chkCipName.TabIndex = 1
        Me.chkCipName.Text = "Tên XDCB"
        Me.chkCipName.UseVisualStyleBackColor = True
        '
        'chkCipDescription
        '
        Me.chkCipDescription.AutoSize = True
        Me.chkCipDescription.Location = New System.Drawing.Point(21, 95)
        Me.chkCipDescription.Name = "chkCipDescription"
        Me.chkCipDescription.Size = New System.Drawing.Size(67, 17)
        Me.chkCipDescription.TabIndex = 2
        Me.chkCipDescription.Text = "Diễn giải"
        Me.chkCipDescription.UseVisualStyleBackColor = True
        '
        'D02F0002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 315)
        Me.Controls.Add(Me.tabOption)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D02F0002"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tîy chãn - D02F0002"
        Me.tabOption.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.grpReportLanguage.ResumeLayout(False)
        Me.grpReportLanguage.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.grpCopy.ResumeLayout(False)
        Me.grpCopy.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents tabOption As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Private WithEvents grp1 As System.Windows.Forms.GroupBox
    Private WithEvents tdbcDivisionID As C1.Win.C1List.C1Combo
    Private WithEvents txtDivisionName As System.Windows.Forms.TextBox
    Private WithEvents chkViewFormPeriodWhenAppRun As System.Windows.Forms.CheckBox
    Private WithEvents chkMessageWhenSaveOK As System.Windows.Forms.CheckBox
    Private WithEvents chkMessageAskBeforeSave As System.Windows.Forms.CheckBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents chkShowReportPathNextTime As System.Windows.Forms.CheckBox
    Private WithEvents chkLockConvertedAmount As System.Windows.Forms.CheckBox
    Private WithEvents chkSaveLastRecent As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Private WithEvents grpReportLanguage As System.Windows.Forms.GroupBox
    Private WithEvents optEnglish As System.Windows.Forms.RadioButton
    Private WithEvents optVietnameseEnglish As System.Windows.Forms.RadioButton
    Private WithEvents optVietnamese As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Private WithEvents grpCopy As System.Windows.Forms.GroupBox
    Private WithEvents chkCipName As System.Windows.Forms.CheckBox
    Private WithEvents chkDepAndEmpID As System.Windows.Forms.CheckBox
    Private WithEvents chkCipDescription As System.Windows.Forms.CheckBox
End Class
