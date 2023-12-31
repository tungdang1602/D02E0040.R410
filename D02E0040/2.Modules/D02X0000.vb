''' <summary>
''' Module này liên quan đến các vấn đề của SUB Main
''' </summary>
''' <remarks></remarks>
Module D02X0000

    ''' <summary>
    ''' Sub khởi động cho Module D02
    ''' </summary>
    
    Public Sub Main()
        SetSysDateTime()
#If DEBUG Then
        Dim frm As New frmConnection
        frm.ShowDialog()
        frm.Dispose()
        ''MakeVirtualConnection() 'Gán các kết nối ảo tạo đây
        '' ''CheckDLL() 'Kiểm tra tính đồng bộ giữa các dll
        ''SaveParameter()
        ''gbUnicode = True
#End If
        If PrevInstance() Then End 'Kiểm tra nếu chương trình đã chạy rồi thì END
        ReadLanguage() 'Đọc biến ngôn ngữ ở đây nhằm mục đích để báo lỗi theo ngôn ngữ cho những phần sau
#If DEBUG Then
        'GetAllParameter() 'Đọc các giá trị từ Registry lưu vào biến toàn cục
#Else
        If Not CheckSecurity() Then End 'Kiểm tra an toàn cho chương trình, nếu không an toàn thì END
        D00C0001.GetInfoFromSystemModule(My.Application.CommandLineArgs(0), gsCompanyID, gsUserID, gsServer, gsPassword, OptSettings, gsConnectionUser)  'Đọc các giá trị kết nối được truyền vào từ D00
#End If
        ' gsConnectionString = "Data Source=" & gsServer & ";Initial Catalog=" & gsCompanyID & ";User ID=" & gsConnectionUser & ";Password=" & gsPassword & ";Connect Timeout = 0" 'Tạo chuỗi kết nối dùng cho toàn bộ project
        If Not CheckConnection() Then End 'Kiểm tra nối không kết nối được với Server thì END
        If Not CheckPermissionF0000() Then End 'Kiểm tra nếu không được quyền vào module thì END
        'Update 19/11/2010: Kiểm tra đồng bộ exe và fix 
        If Not CheckExeFixSynchronous(My.Application.Info.AssemblyName) Then End

        If Not CheckTableT9999() Then End 'Kiểm tra xem có đơn vị đã đăng ký cho module này chưa, nếu chưa thì END
        If Not CheckTrigger() Then End 'Kiểm tra Trigger cho module này, nếu không được thì END
        If Not CheckOther() Then End 'Vì lý do gì đó, có thể kiểm tra một điều kiện không hợp lệ và có thể kết thúc chương trình
        'Tới đây quá trình kiểm tra cho modlue đã hoàn thành, không còn lệnh END để kết thúc chương trình nữa

        'LoadOptions() 'Load các thông số cho phần tùy chọn
        'LoadSystems() 'Load các thông số cho phần thiết lập hệ thống
        'LoadFormatsNew() 'Load các thông số format cho phần format của module
        LoadInfoGeneral()
        LoadOthers() 'Các lập trình viên có thể load những thứ khác ở đây
        'GetCodeTable() 'Load tuỳ chọn Unicode

        ViewFormF0000() 'Hiển thị form main D02F0000, form này phải ShowDialog  

        'Xóa Registry
        '#If DEBUG Then

#If DEBUG Then
        'gbUnicode = True
        'PARA_FormID = "D02F1910"
#End If
        '#Else
        'D99C0007.RegDeleteExe(EXECHILD)

        'Hiển thị form tương ứng(Nếu là exe cha thì rem lại)
        'Select Case PARA_FormID
        '    Case "D02F0001"
        '        Dim frm As New D02F0001
        '        frm.ShowInTaskbar = True
        '        frm.ShowDialog()
        '        frm.Dispose()
        '    Case "D02F0002"
        '        Dim frm As New D02F0002
        '        frm.ShowInTaskbar = True
        '        frm.ShowDialog()
        '        frm.Dispose()
        '    Case "D02F9001"
        '        Dim frm As New D02F9001
        '        frm.ShowInTaskbar = True
        '        frm.ShowDialog()
        '        frm.Dispose()
        '    Case "D02F1910"
        '        Dim frm As New D02F1910
        '        frm.ShowInTaskbar = True
        '        frm.ShowDialog()
        '        frm.Dispose()
        '    Case "D02F2000"
        '        Dim frm As New D02F2000
        '        frm.ShowInTaskbar = True
        '        frm.ShowDialog()
        '        frm.Dispose()
        '    Case Else
        '        D99C0008.MsgL3("Can't open form " & PARA_FormID & " at exe " & EXECHILD)
        'End Select
        '#End If

    End Sub


    Private Function PrevInstance() As Boolean
        If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then
            Return True
        End If
        Return False
    End Function

    Private Sub ReadLanguage()
        Dim sLanguage As String = GetSetting("Lemon3 System Module", "Caption Setting", "Language", "0")
        If sLanguage = "0" Then
            geLanguage = EnumLanguage.Vietnamese
            gsLanguage = "84"
        Else
            geLanguage = EnumLanguage.English
            gsLanguage = "01"
        End If
        D99C0008.Language = geLanguage
        MsgAnnouncement = IIf(geLanguage = EnumLanguage.Vietnamese, "Th¤ng bÀo", "Announcement").ToString
    End Sub

    'Private Function CheckSecurity() As Boolean
    '    Dim D00_CompanyName As String
    '    Dim D00_LegalCopyright As String
    '    Dim CompanyName As String
    '    Dim LegalCopyright As String
    '    If Not System.IO.File.Exists(Application.StartupPath & "\D00E0030.EXE") Then
    '        If gsLanguage = "84" Then
    '            MessageBox.Show("Thï tóc gãi nèi bè bÊt híp lÖ! (10)", "Th¤ng bÀo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '        Else
    '            MessageBox.Show("Invalid internal system call! (10)", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '        End If
    '        Return False
    '    Else
    '        Dim D00_FiVerInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.StartupPath & "\D00E0030.EXE")
    '        Dim FiVerInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.StartupPath & "\" & MODULED02 & ".EXE")
    '        D00_CompanyName = D00_FiVerInfo.CompanyName
    '        D00_LegalCopyright = D00_FiVerInfo.LegalCopyright
    '        CompanyName = FiVerInfo.CompanyName
    '        LegalCopyright = FiVerInfo.LegalCopyright
    '        If (D00_CompanyName <> CompanyName) OrElse (D00_LegalCopyright <> LegalCopyright) Then
    '            If gsLanguage = "84" Then
    '                MessageBox.Show("Thï tóc gãi nèi bè bÊt híp lÖ! (10)", "Th¤ng bÀo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '            Else
    '                MessageBox.Show("Invalid internal system call! (10)", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '            End If
    '            Return False
    '        End If
    '    End If

    '    Dim CommandArgs() As String = Environment.GetCommandLineArgs()
    '    If CommandArgs.Length <> 3 OrElse CommandArgs(1) <> "/DigiNet" OrElse CommandArgs(2) <> "Corporation" Then
    '        If gsLanguage = "84" Then
    '            MessageBox.Show("Thï tóc gãi nèi bè bÊt híp lÖ! (12)", "Th¤ng bÀo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '        Else
    '            MessageBox.Show("Invalid internal system call! (12)", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '        End If
    '        Return False
    '    End If
    '    Return True
    'End Function

    'Private Function CheckSecurity() As Boolean
    '    Return D00C0003.SecurityL3R4(MODULED02, CType(geLanguage, D00D0041.EnumLanguage), L3_APP_NAME, L3_HS_SECTION, L3_HS_SECTION1, L3_HS_SECTION2, L3_HS_MODULE, L3_HS_VALUE)
    ''End Function

    Private Function CheckPermissionF0000() As Boolean
        Dim iPer As Integer = ReturnPermission("D02F0000")
        If iPer <= 0 Then
            D99C0008.MsgL3(rl3("Ban_khong_co_quyen_vao_Tai_san_co_dinh"), L3MessageBoxIcon.Exclamation)
            Return False
        End If
        Return True
    End Function

    Private Function CheckTableT9999() As Boolean
        Dim sSQL As String = ""
        sSQL &= "Select top 1 1 "
        sSQL &= "From D02T9999 T99 Inner Join D91T0016 T16 On T99.DivisionID = T16.DivisionID "
        sSQL &= "Where T16.Disabled = 0 Order By T99.DivisionID"
        If ExistRecord(sSQL) Then
            Return True
        End If
        D99C0008.MsgRegisterDivision()
        Return False
    End Function

    Private Function CheckTrigger() As Boolean
        Dim sSQL As String = SQLStoreD91P9101()
        Dim dt As New DataTable
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("Status").ToString <> "0" Then
                D99C0008.MsgL3(ConvertVietwareFToUnicode(dt.Rows(0).Item("Message").ToString), L3MessageBoxIcon.Information)
                dt = Nothing
                Return False
            End If
            dt = Nothing
            Return True
        End If
        Return False
    End Function

    Private Function CheckOther() As Boolean
        Return True
    End Function

    Private Sub LoadOthers()
        'LoadUserKey()
        'GeneralItems()
        GetModuleAdmin(D02)
        UseModuleD54()
    End Sub

    Private Sub ViewFormF0000()
        Dim frmD02F0000 As New D02F0000()
        frmD02F0000.ShowDialog()
        frmD02F0000.Dispose()
        System.GC.Collect()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD91P9101
    '# Create User: LE VAN PHUOC
    '# Create Date: 04/05/2006 08:32:16
    '# Modified User: 
    '# Modified Date: 
    '# Description: Kiểm tra bằng Trigger khi module khởi động
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD91P9101() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D91P9101 "
        sSQL &= SQLString(D02.Substring(1, 2)) & COMMA 'ModuleID, VarChar[20], NOT NULL
        sSQL &= SQLNumber(IIf(geLanguage = EnumLanguage.Vietnamese, "0", "1")) 'Language, TinyInt, NOT NULL
        Return sSQL
    End Function

    Public Sub MakeVirtualConnection()
        'gsServer = "DRD289"
        'gsCompanyID = "CAMTU"
        'gsConnectionUser = "sa"
        'gsPassword = ""
        'gsUserID = "LEMONADMIN" 'LEMONADMIN"

        'gsServer = "10.0.0.7\sql2008"
        'gsCompanyID = "ftc"
        'gsConnectionUser = "sa"
        'gsPassword = ""
        'gsUserID = "LEMONADMIN"

        gsServer = "10.0.0.15"
        gsCompanyID = "DRD02    "
        gsConnectionUser = "sa"
        gsPassword = "2008"
        gsUserID = "LEMONADMIN"
    End Sub

    'D02E0040 dùng như một Exe con được gọi từ Menu Thiết lập chỉ số của Exe D02E0030
    'Private Sub GetAllParameter()
    '    PARA_Server = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ServerName", "", CodeOption.lmCode)
    '    PARA_Database = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "DBName", "", CodeOption.lmCode)
    '    PARA_ConnectionUser = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ConnectionUserID", "", CodeOption.lmCode)
    '    PARA_UserID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "UserID", "", CodeOption.lmCode)
    '    PARA_Password = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Password", "", CodeOption.lmCode)
    '    PARA_DivisionID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "DivisionID", "DIGINET")
    '    PARA_TranMonth = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "TranMonth", "05")
    '    PARA_TranYear = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "TranYear", "2007")
    '    PARA_Language = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Language", "0"), EnumLanguage)
    '    PARA_FormID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", "")
    '    PARA_FormIDPermission = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", "")

    '    '-----------------------------------------------------------------------
    '    AssignToPublicVariable()

    'End Sub

    'Private Sub AssignToPublicVariable()
    '    gsServer = PARA_Server
    '    gsCompanyID = PARA_Database
    '    gsConnectionUser = PARA_ConnectionUser
    '    gsUserID = PARA_UserID
    '    gsPassword = PARA_Password
    '    gsDivisionID = PARA_DivisionID
    '    giTranMonth = CInt(PARA_TranMonth)
    '    giTranYear = CInt(PARA_TranYear)
    '    geLanguage = PARA_Language
    '    gsLanguage = IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString
    '    D99C0008.Language = geLanguage
    '    PARA_FormID = PARA_FormID
    '    PARA_FormIDPermission = PARA_FormIDPermission
    '    '-----------------------------------------------------------------------        
    'End Sub

    'Private Sub SaveParameter()
    '    D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ServerName", gsServer, CodeOption.lmCode)
    '    D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DBName", gsCompanyID, CodeOption.lmCode)
    '    D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ConnectionUserID", gsConnectionUser, CodeOption.lmCode)
    '    D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "UserID", gsUserID, CodeOption.lmCode)
    '    D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Password", gsPassword, CodeOption.lmCode)
    '    D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DivisionID", "HANOI")
    '    D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TranMonth", "05")
    '    D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TranYear", "2008")
    '    D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Language", "0")
    '    D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", "D02F1910") 'PARA_FormID
    '    D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", "D02F1910") 'PARA_FormIDPermission
    'End Sub
    
End Module
