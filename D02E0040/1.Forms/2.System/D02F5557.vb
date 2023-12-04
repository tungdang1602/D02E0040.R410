Imports System.Windows.Forms
Imports System
Public Class D02F5557



#Region "Const of tdbg"
    Private Const COL_TransactionID As String = "TransactionID"       ' TransactionID
    Private Const COL_VoucherNo As String = "VoucherNo"               ' Số phiếu
    Private Const COL_VoucherDate As String = "VoucherDate"           ' Ngày phiếu
    Private Const COL_VoucherDesc As String = "VoucherDesc"           ' Diễn giải
    Private Const COL_CAmount As String = "CAmount"                   ' Số tiền
    Private Const COL_LockedVoucherID As String = "LockedVoucherID"   ' Người khóa/Mở khoá
    Private Const COL_LockedDate As String = "LockedDate"             ' Ngày khóa/Mở khoá
    Private Const COL_LastModifyUserID As String = "LastModifyUserID" ' Người cập nhật sau cùng
    Private Const COL_LastModifyDate As String = "LastModifyDate"     ' Ngày cập nhật sau cùng
    Private Const COL_Locked As String = "Locked"                     ' Khóa
    Private Const COL_BatchID As String = "BatchID"                   ' BatchID
#End Region


    Dim dtFind As DataTable
    Dim iper As Integer = 0 'Quyền của formPermision truyền vô

    Private Sub D02F5557_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg, 3, IndexOfColumn(tdbg, COL_Locked))
        End If

        If e.Modifiers = Keys.Control And e.KeyCode = Keys.A Then
            mnsListAll_Click(sender, Nothing)
        ElseIf e.Modifiers = Keys.Control And e.KeyCode = Keys.F Then
            mnsFind_Click(sender, Nothing)
        End If

    End Sub

    Private Sub D02F5557_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        ResetColorGrid(tdbg)
        SetShortcutPopupMenu(Me, Nothing, ContextMenuStrip1)
        ResetSplitDividerSize(tdbg)
        tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
        iper = ReturnPermission(Me.Name) 'Lấy quyền 1 lần
        chkLockedVouchers.Enabled = iper <> 2
        LoadTDBCombo()
        InputDateInTrueDBGrid(tdbg, IndexOfColumn(tdbg, COL_LockedDate), IndexOfColumn(tdbg, COL_VoucherDate), IndexOfColumn(tdbg, COL_LastModifyDate))
        tdbg_NumberFormat()
        ' LoadTDBGrid()
        Loadlanguage()
        gbEnabledUseFind = False
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Khoa_phieu_-_D02F5557") & UnicodeCaption(gbUnicode) 'Khâa phiÕu - D02F5557
        '================================================================ 
        lblTransactionID.Text = rl3("Nghiep_vu") 'Nghiệp vụ
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkLockedVouchers.Text = rl3("Cac_phieu_da_khoa") 'Các phiếu đã khóa
        '================================================================ 
        'tdbcTransactionID.Columns("TransactionType").Caption = rl3("Ma") 'Mã
        tdbcTransactionID.Columns("Description").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("VoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("VoucherDesc").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("CAmount").Caption = rl3("So_tien") 'Số tiền
        tdbg.Columns("LockedVoucherID").Caption = rl3("Nguoi_khoaMo_khoa") 'Người khóa/Mở khoá
        tdbg.Columns("LockedDate").Caption = rl3("Ngay_khoaMo_khoa") 'Ngày khóa/Mở khoá
        tdbg.Columns("LastModifyUserID").Caption = rl3("Nguoi_cap_nhat_sau_cung") 'Người cập nhật sau cùng
        tdbg.Columns("LastModifyDate").Caption = rl3("Ngay_cap_nhat_sau_cung") 'Ngày cập nhật sau cùng
        tdbg.Columns("Locked").Caption = rl3("Khoa") 'Khóa
    End Sub





    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcTransactionID
        sSQL &= "Select TransactionType, Description" & UnicodeJoin(gbUnicode) & " as Description " & vbCrLf
        sSQL &= "From D02V5557 " & vbCrLf
        sSQL &= "Where Language=" & SQLString(gsLanguage) & vbCrLf
        sSQL &= "Order By TransactionType"

        LoadDataSource(tdbcTransactionID, sSQL, gbUnicode)
        tdbcTransactionID.SelectedIndex = 0
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P5557
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 26/04/2012 01:25:56
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load lưới
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P5557() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P5557 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcTransactionID)) & COMMA 'TransactionType, int, NOT NULL
        sSQL &= SQLNumber(chkLockedVouchers.Checked) & COMMA 'Locked, tinyint, NOT NULL
        'sSQL &= "N''" & COMMA 'strFind, nvarchar[2000], NOT NULL
        'sSQL &= SQLString("") & COMMA 'strOrderBy, varchar[100], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_CAmount).NumberFormat = DxxFormat.D90_ConvertedDecimals
    End Sub

    Private Sub LoadTDBGrid()
        Me.Cursor = Cursors.WaitCursor
        dtFind = ReturnDataTable(SQLStoreD02P5557)
        gbEnabledUseFind = dtFind.Rows.Count > 0
        LoadDataSource(tdbg, dtFind, gbUnicode)

        ReLoadTDBGrid()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        dtFind.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        '  CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        mnsFind.Enabled = gbEnabledUseFind Or tdbg.RowCount > 0
        mnsListAll.Enabled = mnsFind.Enabled

        btnSave.Enabled = iper >= 2 And tdbg.RowCount > 0

        FooterTotalGrid(tdbg, COL_VoucherNo)
        FooterSumNew(tdbg, COL_CAmount)
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#Region "Events tdbcTransactionID"

    Private Sub tdbcTransactionID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransactionID.LostFocus
        If tdbcTransactionID.FindStringExact(tdbcTransactionID.Text) = -1 Then tdbcTransactionID.Text = ""

    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransactionID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransactionID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

    'Private Sub tdbg_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg.FetchRowStyle
    '    If tdbg(e.Row, COL_SystemLock).ToString = "1" Then
    '        e.CellStyle.Locked = True
    '        e.CellStyle.ForeColor = Color.Gray
    '    Else
    '        e.CellStyle.Locked = False
    '        e.CellStyle.ForeColor = SystemColors.WindowText
    '    End If
    'End Sub

    Dim bSelected As Boolean = False
    Private Sub HeadClick(ByVal col As String)
        Select Case col
            Case COL_Locked
                tdbg.AllowSort = False
                L3HeadClick(tdbg, col, bSelected)
            Case Else
                tdbg.AllowSort = True
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.Column.DataColumn.DataField)
    End Sub


#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
    Private sFind As String = ""
    Dim dtCaptionCols As DataTable

    Private Sub mnsFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsFind.Click
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then 'Incident 72333
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, , True, , gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If

        ShowFindDialogClient(Finder, dtCaptionCols, Me.Name, "0", gbUnicode)
    End Sub

    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
        If ResultWhereClause Is Nothing Then Exit Sub
        sFind = ResultWhereClause.ToString()
        ReLoadTDBGrid()
    End Sub

    Private Sub mnsListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub
#End Region

    Private Sub chkLockedVouchers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLockedVouchers.Click
        bSelected = chkLockedVouchers.Checked
        LoadTDBGrid()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        Dim dr() As DataRow = Nothing

        If Not AllowSave(dr) Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        btnSave.Enabled = True
        btnClose.Enabled = True
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD91T9009() & vbCrLf)
        sSQL.Append(SQLInsertD91T9009s(dr).ToString & vbCrLf)
        sSQL.Append(SQLStoreD02P5559)
        Dim bResult As Boolean = ExecuteSQL(sSQL.ToString)
        If bResult Then
            SaveOK()
            LoadTDBGrid()
            btnClose.Focus()
        Else
            SaveNotOK()
        End If

    End Sub


    Public Sub WriteLogFile1(ByVal Text As String)
        Dim sLog As String = ""
        Dim sFileName As String = gsApplicationSetup & "\Log.log"
        If (My.Computer.FileSystem.FileExists(sFileName) = False) Then My.Computer.FileSystem.WriteAllText(sFileName, "", True)
        Dim lFileSize As Long = My.Computer.FileSystem.GetFileInfo(sFileName).Length
        If lFileSize > 10 * 1028 * 1028 Then My.Computer.FileSystem.DeleteFile(sFileName, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
        sLog &= Space(20) & Now & vbCrLf
        sLog &= Text & vbCrLf
        sLog &= "--------------------------------------------------------------------------" & vbCrLf
        My.Computer.FileSystem.WriteAllText(sFileName, sLog, True)
    End Sub

    'Luu theo Batch
    Private Function ExecuteSQL1(ByVal strSQL As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
        Dim cmd As New SqlCommand(strSQL, conn)

        If Trim(strSQL) = "" Then Exit Function
        If giAppMode = 0 Then

            Try
                cmd.CommandTimeout = 0
                cmd.Transaction = trans
                cmd.ExecuteNonQuery()

                Return True
            Catch
                Clipboard.Clear()
                Clipboard.SetText(strSQL)
                'MsgErr("Error when execute SQL in function ExecuteSQL(). Paste your SQL code from Clipboard")
                MessageBox.Show("Error when execute SQL in function ExecuteSQL(). Paste your SQL code from Clipboard", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                WriteLogFile1(strSQL)
                Return False
            End Try

        Else
            'Dùng D99D0041 mới
            Dim bCaLlWS As Boolean = False
            ''bCaLlWS = CallWebService.ExcuteSQLQuery(strSQL, gsCompanyID, gsUserID, True, gsWSSPara01, gsWSSPara02, gsWSSPara03, gsWSSPara04, gsWSSPara05)
            'If Not bCaLlWS Then
            '    MsgErr(CallWebService.ResultError)
            '    WriteLogFile1(strSQL)
            'End If
            Return bCaLlWS
        End If
    End Function

    'Kiểm tra trước khi khóa/mở khóa phiếu
    Private Function AllowSave(ByRef dr() As DataRow) As Boolean
        tdbg.UpdateData()
        dtFind.AcceptChanges()
        dr = dtFind.Select(COL_Locked & "=" & Not chkLockedVouchers.Checked)
        If dr.Length = 0 Then
            D99C0008.MsgL3(IIf(chkLockedVouchers.Checked, rl3("Ban_chua_chon_phieu_de_mo_khoa"), rl3("MSG000010")).ToString) 'Ban_chua_chon_phieu_de_khoa")).ToString)
            tdbg.Col = IndexOfColumn(tdbg, COL_Locked)
            tdbg.SplitIndex = SPLIT0
            tdbg.Focus()
            Return False
        End If
        Return True
    End Function


#Region "Active fillter Change"
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtFind Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub

            'Filter the data 
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            'MessageBox.Show(ex.Message & " - " & ex.Source)
            ' tdbg.Columns(tdbg.Col).FilterText = ""
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte -> Không hiển thị thông báo
        End Try
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.Columns.Count <= 0 Then Exit Sub
        If tdbg.FilterActive Then
            HotKeyCtrlVOnGrid(tdbg, e)
        Else
            If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbg.Columns(tdbg.Col).DataField)
        End If
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Columns(tdbg.Col).DataField
            Case COL_Locked
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub
#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD91T9009s
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 26/04/2012 01:53:32
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD91T9009s(ByVal dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dr.Length - 1
            sSQL.Append("Insert Into D91T9009(")
            sSQL.Append("UserID, HostID, Key01ID, FormID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NULL
            'Thay doi ngay 13/11/2012 theo incident 52440 của Bảo Trân bởi Văn Vinh
            sSQL.Append("N" & SQLString(dr(i).Item(COL_BatchID).ToString) & COMMA) 'Key01ID, nvarchar[500], NULL
            sSQL.Append(SQLString(Me.Name)) 'FormID, varchar[50], NOT NULL
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD91T9009
    '# Created User: VANVINH
    '# Created Date: 14/11/2012 11:44:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD91T9009() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu bang tam" & vbCrlf)
        sSQL &= "Delete From D91T9009"
        sSQL &= " Where UserID = " & SQLString(gsUserID) & " and HostID = " & SQLString(My.Computer.Name) & " and FormID = " & SQLString(Me.Name)
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P5559
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 26/04/2012 01:57:19
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P5559() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P5559 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(IIf(chkLockedVouchers.Checked, 0, 1)) & COMMA 'Locked, tinyint, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcTransactionID)) 'TransactionType, int, NOT NULL
        Return sSQL
    End Function


    Private Sub tdbcTransactionID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransactionID.SelectedValueChanged
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        LoadTDBGrid()
    End Sub
End Class