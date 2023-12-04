'#-------------------------------------------------------------------------------------
'# Created Date: 01/08/2007 8:23:22 AM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 01/08/2007 8:23:22 AM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Imports System.Text
Imports System.Drawing


Public Class D02F9001
    Private iIndex(100) As Integer

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D02F9001_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D02F9001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        btnSave.Enabled = ReturnPermission("D02F9001") > EnumPermission.View
        InputbyUnicode(Me, gbUnicode)
        LoadForm()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadForm()
       
        Dim sSQL As New StringBuilder(109)
        sSQL.Append(" Select *, ( Case When " & SQLString(gsLanguage) & " = '84' Then VieCaption" & UnicodeJoin(gbUnicode) & " Else EngCaption" & UnicodeJoin(gbUnicode) & " End ) as Caption " & vbCrLf)
        sSQL.Append(" From D02T0039" & vbCrLf)
        sSQL.Append(" Order By ID")

        Dim dt As DataTable = ReturnDataTable(sSQL.ToString)
        If dt.Rows.Count <= 0 Then Exit Sub

        chkDisabled1.Checked = CBool(IIf(dt.Rows(0).Item("Disabled").ToString = "0", False, True))
        chkDisabled2.Checked = CBool(IIf(dt.Rows(1).Item("Disabled").ToString = "0", False, True))
        chkDisabled3.Checked = CBool(IIf(dt.Rows(2).Item("Disabled").ToString = "0", False, True))
        chkDisabled4.Checked = CBool(IIf(dt.Rows(3).Item("Disabled").ToString = "0", False, True))
        chkDisabled5.Checked = CBool(IIf(dt.Rows(4).Item("Disabled").ToString = "0", False, True))
        chkDisabled6.Checked = CBool(IIf(dt.Rows(5).Item("Disabled").ToString = "0", False, True))

        txtVieCaption1.Text = dt.Rows(0).Item("Caption").ToString
        txtVieCaption2.Text = dt.Rows(1).Item("Caption").ToString
        txtVieCaption3.Text = dt.Rows(2).Item("Caption").ToString
        txtVieCaption4.Text = dt.Rows(3).Item("Caption").ToString
        txtVieCaption5.Text = dt.Rows(4).Item("Caption").ToString
        txtVieCaption6.Text = dt.Rows(5).Item("Caption").ToString

        chkFixedIndex1.Checked = CBool(IIf(dt.Rows(0).Item("FixedIndex").ToString = "0", False, True))
        chkFixedIndex2.Checked = CBool(IIf(dt.Rows(1).Item("FixedIndex").ToString = "0", False, True))
        chkFixedIndex3.Checked = CBool(IIf(dt.Rows(2).Item("FixedIndex").ToString = "0", False, True))
        chkFixedIndex4.Checked = CBool(IIf(dt.Rows(3).Item("FixedIndex").ToString = "0", False, True))
        chkFixedIndex5.Checked = CBool(IIf(dt.Rows(4).Item("FixedIndex").ToString = "0", False, True))
        chkFixedIndex6.Checked = CBool(IIf(dt.Rows(5).Item("FixedIndex").ToString = "0", False, True))
        For i As Integer = 0 To dt.Rows.Count - 1
            iIndex(i) = CInt(dt.Rows(i).Item("ID").ToString)
        Next
    End Sub
    Private Function AllowSave() As Boolean
        If chkDisabled1.Checked = False Then
            If txtVieCaption1.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_chi_so"))
                txtVieCaption1.Focus()
                Return False
            End If
        End If
        If chkDisabled2.Checked = False Then
            If txtVieCaption2.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_chi_so"))
                txtVieCaption2.Focus()
                Return False
            End If
        End If
        If chkDisabled3.Checked = False Then
            If txtVieCaption3.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_chi_so"))
                txtVieCaption3.Focus()
                Return False
            End If
        End If
        If chkDisabled4.Checked = False Then
            If txtVieCaption4.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_chi_so"))
                txtVieCaption4.Focus()
                Return False
            End If
        End If
        If chkDisabled5.Checked = False Then
            If txtVieCaption5.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_chi_so"))
                txtVieCaption5.Focus()
                Return False
            End If
        End If
        
        If chkDisabled6.Checked = False Then
            If txtVieCaption6.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_chi_so"))
                txtVieCaption6.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLUpdateD02T0039(txtVieCaption1.Text, chkDisabled1.Checked, chkFixedIndex1.Checked, iIndex(0)))
        sSQL.Append(vbCrLf)
        sSQL.Append(SQLUpdateD02T0039(txtVieCaption2.Text, chkDisabled2.Checked, chkFixedIndex2.Checked, iIndex(1)))
        sSQL.Append(vbCrLf)
        sSQL.Append(SQLUpdateD02T0039(txtVieCaption3.Text, chkDisabled3.Checked, chkFixedIndex3.Checked, iIndex(2)))
        sSQL.Append(vbCrLf)
        sSQL.Append(SQLUpdateD02T0039(txtVieCaption4.Text, chkDisabled4.Checked, chkFixedIndex4.Checked, iIndex(3)))
        sSQL.Append(vbCrLf)
        sSQL.Append(SQLUpdateD02T0039(txtVieCaption5.Text, chkDisabled5.Checked, chkFixedIndex5.Checked, iIndex(4)))
        sSQL.Append(vbCrLf)
        sSQL.Append(SQLUpdateD02T0039(txtVieCaption6.Text, chkDisabled6.Checked, chkFixedIndex6.Checked, iIndex(5)))

        'Lưu LastKey của Số phiếu xuống Database (gọi hàm CreateIGEVoucherNo bật cờ True)
        'Kiểm tra trùng Số phiếu (gọi hàm CheckDuplicateVoucherNo)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
            btnClose.Focus()

        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD02T0039
    '# Created User: Trần Thị ÁiTrâm
    '# Created Date: 01/08/2007 08:52:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD02T0039(ByVal sVieCaption As String, ByVal bDisabled As Boolean, ByVal bFixedIndex As Boolean, ByVal iIndex As Integer) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D02T0039 Set ")
        If gsLanguage = "84" Then
            sSQL.Append("VieCaption = " & SQLStringUnicode(sVieCaption, gbUnicode, False) & COMMA) 'varchar[50], NULL
            sSQL.Append("VieCaptionU = " & SQLStringUnicode(sVieCaption, gbUnicode, True) & COMMA) 'varchar[50], NULL
        Else
            sSQL.Append("EngCaption = " & SQLStringUnicode(sVieCaption, gbUnicode, False) & COMMA) 'varchar[50], NULL
            sSQL.Append("EngCaptionU = " & SQLStringUnicode(sVieCaption, gbUnicode, True) & COMMA) 'varchar[50], NULL
        End If

        sSQL.Append("Disabled = " & SQLNumber(bDisabled) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("FixedIndex = " & SQLNumber(bFixedIndex)) 'tinyint, NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("ID = " & SQLNumber(iIndex))

        Return sSQL
    End Function
    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Dinh_nghia_cac_chi_so_-_D02F9001") & UnicodeCaption(gbUnicode) '˜Ünh nghÚa cÀc chÙ sç - D02F9001
        '================================================================ 
        lblDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        lblVieCaption.Text = rl3("Ten_chi_so") 'Tên chỉ số
        lblFixedIndex.Text = rl3("Co_dinhU") 'Cố định
        lblIndex1.Text = rl3("Chi_so") & " 1"  'Chỉ số 1
        lblIndex2.Text = rl3("Chi_so") & " 2"  'Chỉ số 2
        lblIndex3.Text = rl3("Chi_so") & " 3"  'Chỉ số 3
        lblIndex4.Text = rl3("Chi_so") & " 4" 'Chỉ số 4
        lblIndex5.Text = rl3("Chi_so") & " 5"  'Chỉ số 5
        lblIndex6.Text = rl3("Chi_so") & " 6" 'Chỉ số 6
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        'btnHelp.Text = rl3("Tro__giup") 'Trợ &giúp
        '================================================================ 
    End Sub

End Class