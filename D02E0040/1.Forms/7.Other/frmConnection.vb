Public Class frmConnection
    Private Const EXECHILD As String = "D02E0040_V41"

    Private Sub LoadDefalut()
        txtServerName.Text = D99D0041.D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ServerName", "", CodeOption.lmCode)
        txtDBUserName.Text = D99D0041.D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ConnectionUserID", "", CodeOption.lmCode)
        txtDBPassword.Text = D99D0041.D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Password", "", CodeOption.lmCode)
        txtCompanyID.Text = D99D0041.D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "DBName", "", CodeOption.lmCode)
        txtUserLogin.Text = D99D0041.D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "UserID", "", CodeOption.lmCode)
    End Sub

    Private Sub frmConnection_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub frmConnection_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDefalut()
        'btnYes.TabIndex = 0
        btnYes.Focus()
    End Sub

    Private Sub btnYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes.Click
        gsServer = txtServerName.Text
        gsConnectionUser = txtDBUserName.Text
        gsPassword = txtDBPassword.Text
        gsCompanyID = txtCompanyID.Text
        gsUserID = txtUserLogin.Text
        gbUnicode = chkCodeTable.Checked

        D99D0041.D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ServerName", gsServer, CodeOption.lmCode)
        D99D0041.D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ConnectionUserID", gsConnectionUser, CodeOption.lmCode)
        D99D0041.D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Password", gsPassword, CodeOption.lmCode)
        D99D0041.D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DBName", gsCompanyID, CodeOption.lmCode)
        D99D0041.D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "UserID", gsUserID, CodeOption.lmCode)
        D99D0041.D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "CodeTable", gbUnicode.ToString)

        Me.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        End
    End Sub
End Class