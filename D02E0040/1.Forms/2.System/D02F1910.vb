Imports System.Collections
Public Class D02F1910

#Region "Const of tdbg1"
    Private Const COL1_Description As Integer = 0  ' Thông tin phiếu
    Private Const COL1_Data84 As Integer = 1       ' Diễn giải tiếng Việt
    Private Const COL1_Data01 As Integer = 2       ' Diễn giải tiếng Anh
    Private Const COL1_DataTypeName As Integer = 3 ' Tên kiểu dữ liệu
    Private Const COL1_DecimalNum As Integer = 4   ' Số lẻ/Chiều dài
    Private Const COL1_Disable As Integer = 5      ' Sử dụng
    Private Const COL1_DataID As Integer = 6      ' DataID
    Private Const COL1_DataType As Integer = 7      ' DataID

#End Region

#Region "Const of tdbg2"
    Private Const COL2_Description As Integer = 0  ' Thông tin
    Private Const COL2_Data84 As Integer = 1       ' Diễn giải tiếng Việt
    Private Const COL2_Data01 As Integer = 2       ' Diễn giải tiếng Anh
    Private Const COL2_DataTypeName As Integer = 3 ' Tên kiểu dữ liệu
    Private Const COL2_DecimalNum As Integer = 4   ' Số lẻ/Chiều dài
    Private Const COL2_Disable As Integer = 5      ' Sử dụng
    Private Const COL2_DataID As Integer = 6      ' DataID
    Private Const COL2_DataType As Integer = 7      ' DataID
#End Region

#Region "Const of tdbg3"
    Private Const COL3_Description As Integer = 0  ' Thông tin
    Private Const COL3_Data84 As Integer = 1       ' Diễn giải tiếng Việt
    Private Const COL3_Data01 As Integer = 2       ' Diễn giải tiếng Anh
    Private Const COL3_DataTypeName As Integer = 3 ' Tên kiểu dữ liệu
    Private Const COL3_DecimalNum As Integer = 4   ' Số lẻ/Chiều dài
    Private Const COL3_Disabled As Integer = 5     ' Sử dụng
    Private Const COL3_DataID As Integer = 6       ' DataID
    Private Const COL3_DataType As Integer = 7     ' DataType
#End Region

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Dinh_nghia_thong_tin_bo_sung_-_D02F1910") & UnicodeCaption(gbUnicode) '˜Ünh nghÚa th¤ng tin bå sung - D00F1910
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        TabPage1.Text = "1. " & rl3("Hinh_thanh_TSCD") '1. Hình thành TSCĐ
        TabPage2.Text = "2. " & rl3("Ma_TSCD") 'Mã TSCĐ
        TabPage3.Text = "3. " & rl3("Ma_XDCB")
        '================================================================ 
        tdbg1.Columns("Description").Caption = rl3("Thong_tin") 'Thông tin
        tdbg1.Columns("Data84").Caption = rl3("Dien_giai_tieng_Viet") 'Diễn giải tiếng Việt
        tdbg1.Columns("Data01").Caption = rl3("Dien_giai_tieng_Anh") 'Diễn giải tiếng Anh
        tdbg1.Columns("DataTypeName").Caption = rl3("Ten_kieu_du_lieu") 'Tên kiểu dữ liệu
        tdbg1.Columns("DecimalNum").Caption = rl3("So_leChieu_dai") 'Số lẻ/Chiều dài
        tdbg1.Columns("Disabled").Caption = rl3("Su_dung") 'Sử dụng
        tdbg2.Columns("Description").Caption = rl3("Thong_tin") 'Thông tin
        tdbg2.Columns("Data84").Caption = rl3("Dien_giai_tieng_Viet") 'Diễn giải tiếng Việt
        tdbg2.Columns("Data01").Caption = rl3("Dien_giai_tieng_Anh") 'Diễn giải tiếng Anh
        tdbg2.Columns("DataTypeName").Caption = rl3("Ten_kieu_du_lieu") 'Tên kiểu dữ liệu
        tdbg2.Columns("DecimalNum").Caption = rl3("So_leChieu_dai") 'Số lẻ/Chiều dài
        tdbg2.Columns("Disabled").Caption = rl3("Su_dung") 'Sử dụng

        tdbg3.Columns("Description").Caption = rl3("Thong_tin") 'Thông tin
        tdbg3.Columns("Data84").Caption = rl3("Dien_giai_tieng_Viet") 'Diễn giải tiếng Việt
        tdbg3.Columns("Data01").Caption = rl3("Dien_giai_tieng_Anh") 'Diễn giải tiếng Anh
        tdbg3.Columns("DataTypeName").Caption = rl3("Ten_kieu_du_lieu") 'Tên kiểu dữ liệu
        tdbg3.Columns("DecimalNum").Caption = rl3("So_leChieu_dai") 'Số lẻ/Chiều dài
        tdbg3.Columns("Disabled").Caption = rl3("Su_dung") 'Sử dụng
    End Sub

    Private Sub D02F1910_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            UseEnterAsTab(Me)
        ElseIf (e.Alt) Then
            If (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1) Then
                tabMain.SelectedTab = TabPage1
            ElseIf (e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2) Then
                tabMain.SelectedTab = TabPage2
            ElseIf (e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.D3) Then
                tabMain.SelectedTab = TabPage3
            End If
        End If
    End Sub

    Private Sub D00F1910_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loadlanguage()
        LoadTDBG1()
        LoadTDBG2()
        LoadTDBG3()
        ResetFooterGrid(tdbg1)
        ResetFooterGrid(tdbg2)
        ResetFooterGrid(tdbg3)
        tdbg1_LockedColumns()
        tdbg2_LockedColumns()
        tdbg3_LockedColumns()
        SetResolutionForm(Me)
    End Sub

    Private Sub tdbg1_LockedColumns()
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_DataTypeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg2_LockedColumns()
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_DataTypeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg3_LockedColumns()
        tdbg3.Splits(SPLIT0).DisplayColumns(COL3_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg3.Splits(SPLIT0).DisplayColumns(COL3_DataTypeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub



    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Sub LoadTDBG1()
        Dim sSQL As String = SQLStoreD02P0015("D02T0012")
        LoadDataSource(tdbg1, sSQL, gbUnicode)
        FooterTotalGrid(tdbg1, COL1_Description)
    End Sub

    Private Sub LoadTDBG2()
        Dim sSQL As String = SQLStoreD02P0015("D02T0001")
        LoadDataSource(tdbg2, sSQL, gbUnicode)
        FooterTotalGrid(tdbg2, COL2_Description)
    End Sub

    Private Sub LoadTDBG3()
        Dim sSQL As String = SQLStoreD02P0015("D02T0100")
        LoadDataSource(tdbg3, sSQL, gbUnicode)
        FooterTotalGrid(tdbg3, COL3_Description)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P0015
    '# Created User: Lê Đình Thái
    '# Created Date: 10/11/2011 08:47:56
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P0015(ByVal sTable As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P0015 "
        sSQL &= SQLString(sTable) & COMMA 'TableName, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        Dim sSQL As String = ""
        sSQL &= SQLUpdateD02T0003sD02T0001.ToString() & vbCrLf
        sSQL &= SQLUpdateD02T0003sD02T0012.ToString() & vbCrLf
        sSQL &= SQLUpdateD02T0003sD02T0100.ToString
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            LoadTDBG1()
            LoadTDBG2()
            LoadTDBG3()
            btnClose.Enabled = True
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD02T0003s
    '# Created User: Lê Đình Thái
    '# Created Date: 10/11/2011 08:54:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD02T0003sD02T0001() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg1.RowCount - 1
            sSQL.Append("Update D02T0003 Set ")
            sSQL.Append("Data84 = " & SQLStringUnicode(tdbg1(i, COL1_Data84), gbUnicode, False) & COMMA) 'varchar[20], NULL
            sSQL.Append("Data01 = " & SQLStringUnicode(tdbg1(i, COL1_Data01), gbUnicode, False) & COMMA) 'varchar[20], NULL
            sSQL.Append("Description = " & SQLStringUnicode(tdbg1(i, COL1_Description), gbUnicode, False) & COMMA) 'varchar[250], NULL
            If (L3Bool(tdbg1(i, COL1_Disable)) = True) Then
                sSQL.Append("Disabled = " & SQLNumber(0) & COMMA) 'tinyint, NULL
            Else
                sSQL.Append("Disabled = " & SQLNumber(1) & COMMA) 'tinyint, NULL
            End If
            sSQL.Append("Data84U = " & SQLStringUnicode(tdbg1(i, COL1_Data84), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("Data01U = " & SQLStringUnicode(tdbg1(i, COL1_Data01), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("DescriptionU = " & SQLStringUnicode(tdbg1(i, COL1_Description), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("DecimalNum = " & SQLNumber(tdbg1(i, COL1_DecimalNum)) & COMMA) 'tinyint, NOT NULL
            sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
            sSQL.Append("LastModifyUserID = " & SQLString(gsUserID)) 'varchar[20], NOT NULL
            sSQL.Append(" Where TableName = 'D02T0012' and ")
            sSQL.Append("DataID = " & SQLString(tdbg1(i, COL1_DataID)))
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD02T0003s
    '# Created User: Lê Đình Thái
    '# Created Date: 10/11/2011 08:54:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD02T0003sD02T0012() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg2.RowCount - 1
            sSQL.Append("Update D02T0003 Set ")
            sSQL.Append("Data84 = " & SQLStringUnicode(tdbg2(i, COL2_Data84), gbUnicode, False) & COMMA) 'varchar[20], NULL
            sSQL.Append("Data01 = " & SQLStringUnicode(tdbg2(i, COL2_Data01), gbUnicode, False) & COMMA) 'varchar[20], NULL
            sSQL.Append("Description = " & SQLStringUnicode(tdbg2(i, COL2_Description), gbUnicode, False) & COMMA) 'varchar[250], NULL
            If (L3Bool(tdbg2(i, COL2_Disable)) = True) Then
                sSQL.Append("Disabled = " & SQLNumber(0) & COMMA) 'tinyint, NULL
            Else
                sSQL.Append("Disabled = " & SQLNumber(1) & COMMA) 'tinyint, NULL
            End If
            sSQL.Append("Data84U = " & SQLStringUnicode(tdbg2(i, COL2_Data84), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("Data01U = " & SQLStringUnicode(tdbg2(i, COL2_Data01), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("DescriptionU = " & SQLStringUnicode(tdbg2(i, COL2_Description), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("DecimalNum = " & SQLNumber(tdbg2(i, COL2_DecimalNum)) & COMMA) 'tinyint, NOT NULL
            sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
            sSQL.Append("LastModifyUserID = " & SQLString(gsUserID)) 'varchar[20], NOT NULL
            sSQL.Append(" Where TableName = 'D02T0001' and ")
            sSQL.Append("DataID = " & SQLString(tdbg2(i, COL2_DataID)))
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD02T0003s
    '# Created User: Lê Đình Thái
    '# Created Date: 10/11/2011 08:54:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD02T0003sD02T0100() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg3.RowCount - 1
            sSQL.Append("Update D02T0003 Set ")
            sSQL.Append("Data84 = " & SQLStringUnicode(tdbg3(i, COL3_Data84), gbUnicode, False) & COMMA) 'varchar[20], NULL
            sSQL.Append("Data01 = " & SQLStringUnicode(tdbg3(i, COL3_Data01), gbUnicode, False) & COMMA) 'varchar[20], NULL
            sSQL.Append("Description = " & SQLStringUnicode(tdbg3(i, COL3_Description), gbUnicode, False) & COMMA) 'varchar[250], NULL
            If (L3Bool(tdbg3(i, COL3_Disabled)) = True) Then
                sSQL.Append("Disabled = " & SQLNumber(0) & COMMA) 'tinyint, NULL
            Else
                sSQL.Append("Disabled = " & SQLNumber(1) & COMMA) 'tinyint, NULL
            End If
            sSQL.Append("Data84U = " & SQLStringUnicode(tdbg3(i, COL3_Data84), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("Data01U = " & SQLStringUnicode(tdbg3(i, COL3_Data01), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("DescriptionU = " & SQLStringUnicode(tdbg3(i, COL3_Description), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("DecimalNum = " & SQLNumber(tdbg3(i, COL3_DecimalNum)) & COMMA) 'tinyint, NOT NULL
            sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
            sSQL.Append("LastModifyUserID = " & SQLString(gsUserID)) 'varchar[20], NOT NULL
            sSQL.Append(" Where TableName = 'D02T0100' and ")
            sSQL.Append("DataID = " & SQLString(tdbg3(i, COL3_DataID)))
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub tdbg1_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg1.BeforeColUpdate
        Select Case tdbg1.Col
            Case COL1_DecimalNum
                If (L3Int(tdbg1.Columns(COL1_DataType).Text) = 0) Then
                    If (L3Int(tdbg1.Columns(COL1_DecimalNum).Text) > 8) Then
                        D99C0008.MsgL3(rl3("Kieu_so_khong_duoc_nhap_qua_8_so_le"))
                        tdbg1.Columns(COL1_DecimalNum).Text = "8"
                    End If
                ElseIf (L3Int(tdbg1.Columns(COL1_DataType).Text) = 1) Then
                    If (L3Int(tdbg1.Columns(COL1_DecimalNum).Text) > 1000) Then
                        D99C0008.MsgL3(rl3("Kieu_chuoi_khong_duoc_vuot_qua_1000_ky_tu"))
                        tdbg1.Columns(COL1_DecimalNum).Text = "1000"
                    End If
                End If
        End Select
    End Sub

    Dim bHeadClick1 As Boolean = False

    Private Sub tdbg1_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.HeadClick
        HeadClick1(e.ColIndex)
    End Sub

    Private Sub tdbg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg1.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            HeadClick1(tdbg1.Col)
        End If
        HotKeyCtrlVOnGrid(tdbg1, e)
    End Sub

    Private Sub HeadClick1(ByVal iCol As Integer)
        If tdbg1.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL1_Disable
                L3HeadClick(tdbg1, iCol, bHeadClick1) 'Có trong D99X0000
            Case Else
                tdbg1.AllowSort = False 'Nếu mặc định AllowSort = True
        End Select
    End Sub

    Private Sub tdbg1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg1.KeyPress
        Select Case tdbg1.Col
            Case COL1_Disable
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL1_DecimalNum
                If L3Int(tdbg1.Columns(COL1_DataType).Text) = 2 Then
                    e.Handled = True
                Else
                    e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
                End If
        End Select
    End Sub


    Dim bHeadClick2 As Boolean = False
    Private Sub tdbg2_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.HeadClick
        HeadClick2(e.ColIndex)
    End Sub

    Private Sub tdbg2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg2.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            HeadClick2(tdbg2.Col)
        End If
        If tdbg2.Col = COL2_Disable Or tdbg2.Col = COL2_DecimalNum Or tdbg2.Col = COL2_Description Or tdbg2.Col = COL2_DataTypeName Then
            If (e.Control) Then
                If (e.KeyCode = Keys.V) Then
                    e.Handled = True
                End If
            End If
        Else
            HotKeyCtrlVOnGrid(tdbg2, e)
        End If

    End Sub

    Private Sub HeadClick2(ByVal iCol As Integer)
        If tdbg2.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL2_Disable
                L3HeadClick(tdbg2, iCol, bHeadClick2) 'Có trong D99X0000
            Case Else
                tdbg2.AllowSort = False 'Nếu mặc định AllowSort = True
        End Select
    End Sub

    Private Sub tdbg2_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg2.BeforeColUpdate
        Select Case tdbg2.Col
            Case COL2_DecimalNum
                If (L3Int(tdbg2.Columns(COL2_DataType).Text) = 0) Then
                    If (L3Int(tdbg2.Columns(COL2_DecimalNum).Text) > 8) Then
                        D99C0008.MsgL3(rl3("Kieu_so_khong_duoc_nhap_qua_8_so_le"))
                        tdbg2.Columns(COL2_DecimalNum).Text = "8"
                    End If
                ElseIf (L3Int(tdbg2.Columns(COL2_DataType).Text) = 1) Then
                    If (L3Int(tdbg2.Columns(COL2_DecimalNum).Text) > 1000) Then
                        D99C0008.MsgL3(rl3("Kieu_chuoi_khong_duoc_vuot_qua_1000_ky_tu"))
                        tdbg2.Columns(COL2_DecimalNum).Text = "1000"
                    End If
                End If
        End Select
    End Sub

    Private Sub tdbg2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg2.KeyPress
        Select Case tdbg2.Col
            Case COL2_Disable
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL2_DecimalNum
                If L3Int(tdbg2.Columns(COL2_DataType).Text) = 2 Then
                    e.Handled = True
                Else
                    e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
                End If
        End Select
    End Sub



    Dim bHeadClick3 As Boolean = False
    Private Sub tdbg3_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg3.HeadClick
        HeadClick3(e.ColIndex)
    End Sub

    Private Sub tdbg3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg3.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            HeadClick3(tdbg3.Col)
        End If
        If tdbg3.Col = COL3_Disabled Or tdbg3.Col = COL3_DecimalNum Or tdbg3.Col = COL3_Description Or tdbg3.Col = COL3_DataTypeName Then
            If (e.Control) Then
                If (e.KeyCode = Keys.V) Then
                    e.Handled = True
                End If
            End If
        Else
            HotKeyCtrlVOnGrid(tdbg3, e)
        End If

    End Sub

    Private Sub HeadClick3(ByVal iCol As Integer)
        If tdbg3.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL3_Disabled
                L3HeadClick(tdbg3, iCol, bHeadClick3) 'Có trong D99X0000
            Case Else
                tdbg3.AllowSort = False 'Nếu mặc định AllowSort = True
        End Select
    End Sub

    Private Sub tdbg3_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg3.BeforeColUpdate
        Select Case tdbg3.Col
            Case COL3_DecimalNum
                If (L3Int(tdbg3.Columns(COL3_DataType).Text) = 0) Then
                    If (L3Int(tdbg3.Columns(COL3_DecimalNum).Text) > 8) Then
                        D99C0008.MsgL3(rl3("Kieu_so_khong_duoc_nhap_qua_8_so_le"))
                        tdbg3.Columns(COL3_DecimalNum).Text = "8"
                    End If
                ElseIf (L3Int(tdbg3.Columns(COL3_DataType).Text) = 1) Then
                    If (L3Int(tdbg3.Columns(COL3_DecimalNum).Text) > 1000) Then
                        D99C0008.MsgL3(rl3("Kieu_chuoi_khong_duoc_vuot_qua_1000_ky_tu"))
                        tdbg3.Columns(COL3_DecimalNum).Text = "1000"
                    End If
                End If
        End Select
    End Sub

    Private Sub tdbg3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg3.KeyPress
        Select Case tdbg3.Col
            Case COL3_Disabled
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL3_DecimalNum
                If L3Int(tdbg3.Columns(COL3_DataType).Text) = 2 Then
                    e.Handled = True
                Else
                    e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
                End If
        End Select
    End Sub
End Class