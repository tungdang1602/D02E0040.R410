Public Class D02F0002

    Private Sub D02F0001_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If

        If e.Alt = True And (e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1) Then
            tabOption.SelectedIndex = 0
            tabOption.Focus()
        End If
        If e.Alt = True And (e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2) Then
            tabOption.SelectedIndex = 1
            tabOption.Focus()
        End If
    End Sub

    Private Sub D02F0002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        btnSave.Enabled = ReturnPermission(Me.Name) > EnumPermission.View
        LoadTDBCombo()
        LoadEdit()
    SetResolutionForm(Me)
Me.Cursor = Cursors.Default
End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Tuy_chon_-_D02F0002") & UnicodeCaption(gbUnicode) 'Tîy chãn - D02F0002
        '================================================================ 
        Label1.Text = rl3("Don_vi_mac_dinh") 'Đơn vị mặc định
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        chkShowReportPathNextTime.Text = rl3("MSG000035") 'Hiển thị màn hình đường dẫn báo cáo cho lần sau
        chkLockConvertedAmount.Text = rl3("Khoa_so_tien_quy_doi") 'Khóa số tiền quy đổi
        chkSaveLastRecent.Text = rl3("Luu_cac_gia_tri_gan_nhat_khi_nhap_tiep") 'Lưu các giá trị gần nhất khi nhập tiếp
        chkViewFormPeriodWhenAppRun.Text = rl3("Hien_thi_man_hinh_chon_ky_ke_toan_truoc_khi_chay_chuong_trinh")
        chkMessageWhenSaveOK.Text = rl3("Thong_bao_khi_luu_thanh_cong") 'Thông báo khi lưu thành công
        chkMessageAskBeforeSave.Text = rl3("Hoi_truoc_khi_luu") 'Hỏi trước khi lưu
        chkDepAndEmpID.Text = rl3("Bo_phan_tiep_nhan_va_nguoi_tiep_nhan")
        chkCipName.Text = rl3("Ten_XDCB")
        chkCipDescription.Text = rl3("Dien_giai")
        '================================================================ 
        optEnglish.Text = rl3("Tieng_Anh") 'Tiếng Anh
        optVietnameseEnglish.Text = rl3("Song_ngu_Viet_-_Anh") 'Song ngữ Việt - Anh
        optVietnamese.Text = rl3("Tieng_Viet") 'Tiếng Việt
        '================================================================ 
        grpReportLanguage.Text = rl3("Ngon_ngu_bao_cao") 'Ngôn ngữ báo cáo
        grpCopy.Text = rl3("Sao_chep_cac_thong_tin_tu_XDCB_sang_tai_san")
        '================================================================ 
        TabPage1.Text = "1. " & rl3("Mac_dinh") 'Mặc định
        TabPage2.Text = "2. " & rl3("Bao_cao") 'Báo cáo
        TabPage3.Text = "3. " & rl3("Sao_chep") 'Sao chép
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma_don_vi") 'Mã đơn vị
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten_don_vi") 'Tên đơn vị
    End Sub

#Region "Events tdbcDivisionID with txtDivisionName"

    Private Sub tdbcDivisionID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Close
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then
            tdbcDivisionID.Text = ""
            txtDivisionName.Text = ""
        End If
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        txtDivisionName.Text = tdbcDivisionID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcDivisionID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDivisionID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcDivisionID.Text = ""
            txtDivisionName.Text = ""
        End If
    End Sub

#End Region

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcDivisionID
        LoadCboDivisionID(tdbcDivisionID, D02, False, gbUnicode)
    End Sub

    Private Sub LoadEdit()
        With D02Options
            tdbcDivisionID.SelectedValue = .DefaultDivisionID
            tdbcDivisionID.Tag = .DefaultDivisionID
            chkMessageAskBeforeSave.Checked = .MessageAskBeforeSave
            chkMessageWhenSaveOK.Checked = .MessageWhenSaveOK
            chkSaveLastRecent.Checked = .SaveLastRecent
            chkLockConvertedAmount.Checked = .LockConvertedAmount
            chkViewFormPeriodWhenAppRun.Checked = .ViewFormPeriodWhenAppRun
            chkShowReportPathNextTime.Checked = .ShowReportPath

            chkCipDescription.Checked = .CipDescription
            chkCipName.Checked = .CipName
            chkDepAndEmpID.Checked = .DepAndEmpID

            If .ReportLanguage = 0 Then
                optVietnamese.Checked = True
            ElseIf .ReportLanguage = 1 Then
                optVietnameseEnglish.Checked = True
            ElseIf .ReportLanguage = 2 Then
                optEnglish.Checked = True
            End If

        End With
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        UpdateOptions()

        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD02T5550() & vbCrLf)
        sSQL.Append(SQLInsertD02T5550("DepAndEmpID", chkDepAndEmpID.Checked).ToString & vbCrLf)
        sSQL.Append(SQLInsertD02T5550("CipName", chkCipName.Checked).ToString & vbCrLf)
        sSQL.Append(SQLInsertD02T5550("CipDescription", chkCipDescription.Checked).ToString & vbCrLf)
        ExecuteSQL(sSQL.ToString)

        If tdbcDivisionID.Tag.ToString <> tdbcDivisionID.Text Then
            D99C0008.MsgSetUpDivision()
        Else
            SaveOK()
        End If
        Me.Close()
    End Sub

    Private Sub UpdateOptions()
        With D02Options
            .DefaultDivisionID = tdbcDivisionID.Text
            .MessageAskBeforeSave = chkMessageAskBeforeSave.Checked
            .MessageWhenSaveOK = chkMessageWhenSaveOK.Checked
            .SaveLastRecent = chkSaveLastRecent.Checked
            .LockConvertedAmount = chkLockConvertedAmount.Checked
            .ViewFormPeriodWhenAppRun = chkViewFormPeriodWhenAppRun.Checked
            .ShowReportPath = chkShowReportPathNextTime.Checked
            .ReportLanguage = CType(IIf(optVietnamese.Checked, 0, IIf(optVietnameseEnglish.Checked, 1, 2)), Byte)
            .CipDescription = L3Bool(chkCipDescription.Checked)
            .CipName = L3Bool(chkCipName.Checked)
            .DepAndEmpID = L3Bool(chkDepAndEmpID.Checked)

            D99C0007.SaveModulesSetting(D02, ModuleOption.lmOptions, "DefaultDivisionID", .DefaultDivisionID)
            D99C0007.SaveModulesSetting(D02, ModuleOption.lmOptions, "MessageAskBeforeSave", .MessageAskBeforeSave)
            D99C0007.SaveModulesSetting(D02, ModuleOption.lmOptions, "MessageWhenSaveOK", .MessageWhenSaveOK)
            D99C0007.SaveModulesSetting(D02, ModuleOption.lmOptions, "SaveLastRecent", .SaveLastRecent)
            D99C0007.SaveModulesSetting(D02, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun", .ViewFormPeriodWhenAppRun)
            D99C0007.SaveModulesSetting(D02, ModuleOption.lmOptions, "LockConvertedAmount", .LockConvertedAmount)
            D99C0007.SaveModulesSetting(D02, ModuleOption.lmOptions, "ShowReportPath", .ShowReportPath)
            D99C0007.SaveModulesSetting(D02, ModuleOption.lmOptions, "ReportLanguage", .ReportLanguage)
        End With
    End Sub

    Private Function AllowSave() As Boolean
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD02T5550
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 13/07/2012 11:07:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD02T5550() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D02T5550"
        sSQL &= " Where UserID=" & SQLString(gsUserID)
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T5550
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 13/07/2012 10:59:13
    '# Modified User: 
    '# Modified Date: 
    '# Description: Lưu
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T5550(ByVal FieldName As String, ByVal CheckValue As Boolean, Optional ByVal OptionName As String = "CopyFromCip") As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D02T5550(")
        sSQL.Append("UserID, OptionName, FieldName, CheckValue")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(OptionName) & COMMA) 'OptionName, varchar[250], NOT NULL
        sSQL.Append(SQLString(FieldName) & COMMA) 'FieldName, varchar[50], NOT NULL
        sSQL.Append(SQLNumber(CheckValue)) 'CheckValue, tinyint, NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function


End Class