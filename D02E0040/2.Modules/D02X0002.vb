''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
Module D02X0002

    '''' <summary>
    '''' Tạo caption cho menu Period và kiểm tra tình trạng khóa, mở sổ cho biến gbClosed
    '''' </summary>
    '<DebuggerStepThrough()> _
    Public Function MakeMenuPeriod() As String
        'Dim sRet As String = "&Kỳ kế toán:" & Space(1) & giTranMonth.ToString("00") & "/" & giTranYear & Space(3) & "Đơn vị:" & Space(1) & gsDivisionID
        Dim sRet As String = rl3("_Ky_ke_toan") & ":" & Space(1) & giTranMonth.ToString("00") & "/" & giTranYear & Space(3) & rl3("Don_vi") & ":" & Space(1) & gsDivisionID
        '**********Them ngay 7/1/2013 theo ID 53113
        'Nếu mở sổ đặc biệt thì không kiểm tra khóa sổ 
        If gbOpeningSpecial Then Return sRet
        '******************************
        Dim sSQL As String = ""
        sSQL = "Select Closing From D02T9999 Where TranMonth = " & SQLNumber(giTranMonth) & " And TranYear = " & SQLNumber(giTranYear) & " And DivisionID = " & SQLString(gsDivisionID)
        Dim sClosing As String = ReturnScalar(sSQL)
        'gbClosed = Convert.ToBoolean(IIf(sClosing = "0", False, True))
        gbClosed = L3Bool(sClosing)
        Return sRet
    End Function

    'Lấy kỳ đầu tiên dùng để phân quyền : màn hình D40F2000 (Số dư đầu kỳ)
    Public Sub GetFirstPeriod(ByVal gsDivisionID As String) 'Them bien ngay 6/3/2013 theo ID 54611
        Dim dt As DataTable
        Dim sSQL As String
        sSQL = "Select  TranMonth , TranYear From D02T9999  " & vbCrLf
        sSQL = sSQL & "Where DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL = sSQL & "Order By TranYear , TranMonth "

        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            giFirstTranMonth = CInt(dt.Rows(0)("TranMonth").ToString())
            giFirstTranYear = CInt(dt.Rows(0)("TranYear").ToString())
        End If

    End Sub
    '#--------------------------------------------------------------------------
    '#CreateUser: Trần Thị Ái Trâm
    '#CreateDate: 04/09/2007
    '#ModifiedUser:
    '#ModifiedDate:
    '#Description: Hàm kiểm tra Audit log
    '#--------------------------------------------------------------------------
    Public Function PermissionAudit(ByVal sAuditCode As String) As Byte
        Dim sSQL As String
        Dim dt As DataTable

        sSQL = "Select Audit From D91T9200 " & vbCrLf
        sSQL &= "Where AuditCode=" & SQLString(sAuditCode)

        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            If CByte(dt.Rows(0).Item("Audit")) = 1 Then
                Return 1
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD91P9106
    '# Created User: Trần Thị ÁiTrâm
    '# Created Date: 04/09/2007 11:30:16
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    'Private Function SQLStoreD91P9106(ByVal sAuditCode As String, ByVal sEventID As String, ByVal sDesc1 As String, ByVal sDesc2 As String, ByVal sDesc3 As String, ByVal sDesc4 As String, ByVal sDesc5 As String) As String
    '    Dim sSQL As String = ""
    '    sSQL &= "Exec D91P9106 "
    '    sSQL &= SQLString(Date.Today) & COMMA 'AuditDate, datetime, NOT NULL
    '    sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
    '    sSQL &= SQLString("") & COMMA 'DivisionID, varchar[20], NOT NULL
    '    sSQL &= SQLString("02") & COMMA 'ModuleID, varchar[2], NOT NULL
    '    sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
    '    sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
    '    sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc5) 'Desc5, varchar[250], NOT NULL
    '    Return sSQL
    'End Function

    '#--------------------------------------------------------------------------
    '#CreateUser: Trần Thị ÁiTrâm
    '#CreateDate: 04/09/2007
    '#ModifiedUser:
    '#ModifiedDate:
    '#Description: Thực thi store Audit Log
    '#--------------------------------------------------------------------------
    'Public Sub ExecuteAuditLog(ByVal sAuditCode As String, ByVal sEventID As String, Optional ByVal sDesc1 As String = "", Optional ByVal sDesc2 As String = "", Optional ByVal sDesc3 As String = "", Optional ByVal sDesc4 As String = "", Optional ByVal sDesc5 As String = "")
    '    Dim sSQL As String
    '    sSQL = SQLStoreD91P9106(sAuditCode, sEventID, sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)
    '    ExecuteSQL(sSQL)
    'End Sub

    Public Function ComboValue(ByVal c1Combo As C1.Win.C1List.C1Combo) As String
        If c1Combo.Text = "" Then Return ""
        If c1Combo.SelectedValue IsNot Nothing Then
            Return c1Combo.SelectedValue.ToString
        Else
            Return ""
        End If
    End Function

    'Them ngay 7/1/2013 theo ID 53113
    Private Function SQLStoreD90P6000(ByVal iTranMonth As Integer, ByVal iTranYear As Integer, ByVal sDivisionID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra mo so dac biet" & vbCrLf)
        sSQL &= "Exec D90P6000 "
        sSQL &= SQLString(sDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString("02") & COMMA 'ModuleID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(iTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function

    ''' <summary>
    ''' Dùng cho kiểm tra Mở sổ đặc biệt
    ''' bMain: True:gọi từ DxxF0000. False: gọi từ form Chọn kỳ
    ''' Giá trị trả về: 0,1,2(Đã hiển thị form Chọn kỳ)
    ''' </summary>
    Public Function OpeningSpecial(ByVal bMain As Boolean) As Integer
        'kiem tra co phai la truong hop mo so dac biet khong
        Dim sSQL As String = SQLStoreD90P6000(giTranMonth, giTranYear, gsDivisionID)
        Dim dt As DataTable = ReturnDataTable(sSQL)

        gbOpeningSpecial = False
        If dt.Rows.Count > 0 Then
            Select Case dt.Rows(0).Item("Status").ToString
                Case "0"
                    If bMain = False Then gbEndModule = False
                Case "1"
                    gbOpeningSpecial = True
                    gbClosed = False
                    If bMain = False Then gbEndModule = False
                    D99C0008.MsgL3(ConvertVietwareFToUnicode(dt.Rows(0).Item("Message").ToString), L3MessageBoxIcon.Exclamation)
                Case "2"
                    D99C0008.MsgL3(ConvertVietwareFToUnicode(dt.Rows(0).Item("Message").ToString))
                    gbEndModule = True
                    If bMain Then
                        Dim f As New D02F0003
                        f.ShowDialog()
                        f.Dispose()
                    End If
            End Select
            Return L3Int(dt.Rows(0).Item("Status"))
        End If
        Return 0
    End Function

    'Public Sub RunEXEDxxExx40(ByVal sExeName As String, ByVal sFormActive As String, Optional ByVal sFormPermission As String = "", Optional ByVal sKey01ID As String = "")
    '    Dim exe As New DxxExx40(sExeName, gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
    '    With exe
    '        .FormActive = sFormActive 'Form cần hiển thị
    '        .FormPermission = IIf(sFormPermission = "", sFormActive, sFormPermission).ToString 'Mã màn hình phân quyền
    '        ' .IDxx(Khóa cần Lưu xuống Registry) = sKey01ID
    '        .Run()
    '    End With
    '    ' Bổ sung thêm các biến sKey02ID, sKey03ID,..... khi cần tương tự như sKey01ID
    'End Sub

    'Ẩn phân nhóm: các hàm này để DxxX0002
    'Public Sub SetVisibleDelimiter(ByVal menu As C1.Win.C1Command.C1MainMenu)
    '    For i As Integer = 0 To menu.CommandLinks.Count - 1
    '        If TypeOf (menu.CommandLinks(i).Command) Is C1.Win.C1Command.C1CommandMenu Then 'Lấy 5 menu chính
    '            Dim mnu As C1.Win.C1Command.C1CommandMenu = CType(menu.CommandLinks(i).Command, C1.Win.C1Command.C1CommandMenu)
    '            SetVisibleDelimiter(mnu) 'Set menu con trong từng menu chính
    '        End If
    '    Next
    'End Sub

    'Private Sub SetVisibleDelimiter(ByVal mnu As C1.Win.C1Command.C1CommandMenu)
    '    For i As Integer = 0 To mnu.CommandLinks.Count - 1
    '        If (i > 0 And mnu.CommandLinks(i).Delimiter = True) AndAlso mnu.CommandLinks(i - 1).Command.Visible = False Then
    '            mnu.CommandLinks(i).Delimiter = False
    '        End If

    '        If TypeOf (mnu.CommandLinks(i).Command) Is C1.Win.C1Command.C1CommandMenu Then 'menu chứa menu con
    '            Dim cmnu As C1.Win.C1Command.C1CommandMenu = CType(mnu.CommandLinks(i).Command, C1.Win.C1Command.C1CommandMenu)
    '            SetVisibleChildDelimiter(cmnu)
    '        End If
    '    Next
    'End Sub

    'Private Sub SetVisibleChildDelimiter(ByVal mnu As C1.Win.C1Command.C1CommandMenu)
    '    Dim iVisible As Integer = 0

    '    For i As Integer = 0 To mnu.CommandLinks.Count - 1
    '        If (i > 0 And mnu.CommandLinks(i).Delimiter) AndAlso mnu.CommandLinks(i - 1).Command.Visible = False Then
    '            mnu.CommandLinks(i).Delimiter = False
    '        End If

    '        'Ẩn menu cha khi các menu con bị ẩn
    '        If mnu.CommandLinks(i).Command.Visible = True Then iVisible += 1
    '    Next

    '    If mnu.Visible Then mnu.Visible = (iVisible > 0)
    'End Sub
End Module
