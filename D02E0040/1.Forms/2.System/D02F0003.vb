'#-------------------------------------------------------------------------------------
'# Created Date: 25/07/2006 10:14:33 AM
'# Created User: Nguyễn Thị Minh Hòa
'# Modify Date: 25/07/2006 10:14:33 AM
'# Modify User: Nguyễn Thị Minh Hòa
'#-------------------------------------------------------------------------------------
Public Class D02F0003

    Dim dtPeriod As DataTable
    '******Them ngay 7/1/2013 theo ID 53113
    Dim sDivisionID_Old As String = ""
    '**************************

#Region "Events tdbcDivisionID load tdbcPeriod"

    Private Sub tdbcDivisionID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Close
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then tdbcDivisionID.Text = ""
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        If Not (tdbcDivisionID.Tag Is Nothing OrElse tdbcDivisionID.Tag.ToString = "") Then
            tdbcDivisionID.Tag = ""
            Exit Sub
        End If
        If tdbcDivisionID.SelectedValue Is Nothing Then
            LoadtdbcPeriod("-1")
            Exit Sub
        End If
        LoadtdbcPeriod(tdbcDivisionID.SelectedValue.ToString())
        tdbcPeriod.Text = tdbcPeriod.Columns(0).Text
    End Sub

    Private Sub tdbcDivisionID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDivisionID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcDivisionID.Text = ""
    End Sub

    Private Sub tdbcPeriod_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriod.Close
        If tdbcPeriod.FindStringExact(tdbcPeriod.Text) = -1 Then tdbcPeriod.Text = ""
    End Sub

    Private Sub tdbcPeriod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPeriod.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcPeriod.Text = ""
    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    '*******Them ngay 7/1/2013 theo ID 53113
    Private Sub D02F0003_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If gbEndModule = True Then End
    End Sub
    '************

    Private Sub SetBackColorObligatory()
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub D02F0003_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D02F0003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loadlanguage()
        'Để đoạn code này để chỉnh lại Font cho tdbcPeriod nên không được bỏ
        tdbcPeriod.Font = New Font("Microsoft Sans Serif", 8.25)
        tdbcPeriod.EditorFont = tdbcPeriod.Font
        '   update 8/5/2013 id 56071
        '   btnSelected.Enabled = ReturnPermission(Me.Name) >= EnumPermission.View
        dtPeriod = LoadTablePeriodReport(D02, True)
        LoadTDBCombo()
        LoadEdit()
        SetBackColorObligatory()
    SetResolutionForm(Me)
Me.Cursor = Cursors.Default
End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chon_ky") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Chãn kù kÕ toÀn - D02F0003
        '================================================================ 
        lblDivisionID.Text = rl3("Don_vi") 'Đơn vị
        lblPeriod.Text = rl3("Ky") 'Kỳ kế toán
        '================================================================ 
        btnSelected.Text = "&" & rl3("Chon") 'Chọn
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã đơn vị
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên đơn vị
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcDivisionID
        'sSQL = "Select Distinct D02.DivisionID, D16.DivisionName From D02T9999 D02 Inner Join D91T0016 D16 On D02.DivisionID = D16.DivisionID Order By D02.DivisionID"
        'LoadDataSource(tdbcDivisionID, sSQL)
        LoadCboDivisionID(tdbcDivisionID, D02, , gbUnicode)
        'Load tdbcPeriod
        LoadtdbcPeriod("-1")
    End Sub

    Private Sub LoadtdbcPeriod(ByVal ID As String)
        'Dim sSQL As String = ""
        'sSQL &= "Select (Right(('0'+ RTrim(LTrim(Str(TranMonth)))), 2) + '/' + LTrim(Str(TranYear))) As Period, TranMonth, TranYear "
        'sSQL &= "From D02T9999 Where DivisionID = " & SQLString(ID) & " Order By TranYear Desc, TranMonth Desc"
        'LoadDataSource(tdbcPeriod, sSQL)
        LoadCboPeriodReport(tdbcPeriod, dtPeriod, ID)
        ' update 6/5/2013 id 56280
        '   GetFirstPeriod(ReturnValueC1Combo(tdbcDivisionID).ToString)
    End Sub

    Private Sub LoadEdit()
        'tdbcDivisionID.Enabled = Not gbLockedDivisionID
        tdbcDivisionID.Tag = gsDivisionID
        tdbcDivisionID.SelectedValue = gsDivisionID
        LoadtdbcPeriod(gsDivisionID)
        tdbcPeriod.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        sDivisionID_Old = gsDivisionID 'ID 53113
    End Sub

    Private Sub btnSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelected.Click
        'Thay doi ngay 7/1/2013 theo ID 53113
        'If Not AllowSelected() Then Exit Sub
        'Dim sPeriod As String = tdbcPeriod.SelectedValue.ToString
        'gsDivisionID = tdbcDivisionID.SelectedValue.ToString
        'giTranMonth = Convert.ToInt16(sPeriod.Substring(0, 2))
        'giTranYear = Convert.ToInt16(sPeriod.Substring(3))
        'Me.DialogResult = Windows.Forms.DialogResult.OK
        'Me.Close()
        If Not AllowSelected() Then Exit Sub
        Dim sPeriod As String = tdbcPeriod.SelectedValue.ToString
        If sDivisionID_Old <> tdbcDivisionID.SelectedValue.ToString OrElse sPeriod <> giTranMonth.ToString("00") & "/" & giTranYear.ToString Then
            sDivisionID_Old = tdbcDivisionID.SelectedValue.ToString
            gsDivisionID = tdbcDivisionID.SelectedValue.ToString
            giTranMonth = L3Int(sPeriod.Substring(0, 2))
            giTranYear = L3Int(sPeriod.Substring(3))
            'Kiểm tra Mở sổ đặc biệt
            If OpeningSpecial(False) = 2 Then sDivisionID_Old = "" : Exit Sub
        End If
        If gbEndModule Then Exit Sub
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Function AllowSelected() As Boolean
        If tdbcDivisionID.Text = "" Then
            D99C0008.MsgNotYetEnter(rl3("Don_vi"))
            tdbcDivisionID.Focus()
            Return False
        End If
        If tdbcPeriod.Text = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ky_ke_toan"))
            tdbcPeriod.Focus()
            Return False
        End If
        Return True
    End Function

End Class