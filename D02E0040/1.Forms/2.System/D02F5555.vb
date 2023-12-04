﻿'#-------------------------------------------------------------------------------------
'# Created Date: 01/08/2006 4:34:12 PM
'# Created User: Nguyễn Thị Minh Hòa
'# Modify Date: 01/08/2006 4:34:12 PM
'# Modify User: Nguyễn Thị Minh Hòa
'#-------------------------------------------------------------------------------------
Public Class D02F5555

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub D02F5554_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loadlanguage()
        LoadEdit()
    SetResolutionForm(Me)
Me.Cursor = Cursors.Default
End Sub
    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Mo_so_-_D02F5555") & UnicodeCaption(gbUnicode)  'Mê så - D02F5555
        '================================================================ 
        lblDivisionCaption.Text = rl3("Don_vi") & ":"  'Đơn vị:
        lblPeriodCaption.Text = rl3("Ky_ke_toan") & ":" 'Kỳ kế toán:
        lblQuestion.Text = rl3("Ban_co_muon_mo_so_ky_nay_khong") 'Bạn có muốn mở sổ kỳ này không?
    End Sub

    Private Sub LoadEdit()
        lblDivisionID.Text = gsDivisionID
        lblPeriod.Text = giTranMonth.ToString("00") & "/" & giTranYear.ToString
    End Sub

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
        If Not AllowYes() Then Exit Sub
        Dim sSQL As String = SQLUpdateD02T9999()
        If ExecuteSQL(sSQL) Then
            D99C0008.MsgOpenBook(lblPeriod.Text)
            'RunAuditLog(AuditCodeOpenBook, "01", lblPeriod.Text)
            Lemon3.D91.RunAuditLog("02", AuditCodeOpenBook, "01", lblPeriod.Text)
            gbClosed = False
        Else
            D99C0008.MsgL3(rl3("Mo_so_khong_thanh_cong_cho_ky") & lblPeriod.Text)
            gbClosed = True
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Function AllowYes() As Boolean
        Dim sSQL As String = SQLStoreD90P0011()
        Return CheckStore(sSQL)
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD90P0011
    '# Create User: 
    '# Create Date: 
    '# Modified User: 
    '# Modified Date: 
    '# Description: Kiểm tra D90 đã khóa sổ hay chưa
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD90P0011() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D90P0011 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, VarChar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, Int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, Int, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, VarChar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD02T9999
    '# Create User: 
    '# Create Date: 
    '# Modified User: 
    '# Modified Date: 
    '# Description: Update trường Closing = 0
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD02T9999() As String
        Dim sSQL As String = ""
        sSQL &= "Update D02T9999 Set "
        sSQL &= "Closing = " & SQLNumber("0") 'Bit, NOT NULL
        sSQL &= " Where "
        sSQL &= "TranMonth = " & SQLNumber(giTranMonth) & " And "
        sSQL &= "TranYear = " & SQLNumber(giTranYear) & " And "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID)
        Return sSQL
    End Function

End Class