Public Class D91F0310

    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private ChildName As String = "D91E0140"
    Dim exe As D91E0140
    Dim p As System.Diagnostics.Process

    Private _formPermission As String
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            _formPermission = Value
        End Set
    End Property

    Private _formName As String = ""
    Public WriteOnly Property FormName() As String
        Set(ByVal Value As String)
            _formName = Value
        End Set
    End Property


    'Private _myFormState As EnumFormState
    'Public WriteOnly Property MyFormState() As EnumFormState
    '    Set(ByVal Value As EnumFormState)
    '        _myFormState = Value
    '    End Set
    'End Property

    Private _LookupType As String
    Public WriteOnly Property LookupType() As String
        Set(ByVal Value As String)
            _LookupType = Value
        End Set
    End Property


    Private _FormText As String
    Public WriteOnly Property FormText() As String
        Set(ByVal Value As String)
            _FormText = Value
        End Set
    End Property

    Private _FormSubText As String
    Public WriteOnly Property FormSubText() As String
        Set(ByVal Value As String)
            _FormSubText = Value
        End Set
    End Property


    Private _outPut01 As String ' Kết quả biến trả về sau khi Thêm/sửa
    Public ReadOnly Property OutPut01() As String
        Get
            Return _outPut01
        End Get
    End Property

    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork
        'Tạo một process gắn với exe con, process này sẽ quan sát exe con.
        Dim p As System.Diagnostics.Process
        Try
            p = Process.GetProcessesByName(ChildName)(0)

            If p Is Nothing Then
                Exit Sub
            End If

            'Chờ đợi exe con tắt tiến trình 
            p.EnableRaisingEvents = True
            p.WaitForExit()

        Catch ex As Exception
            MsgBox(ex.Message & " - " & ex.Source)
        End Try

    End Sub

    Private Sub FormLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ẩn form trung gian
        Me.Size = New Size(0, 0)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        '----Truyền tham số exe con------
        exe = New D91E0140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString)

        If _formName = "D91F0310" Then ' Danh mục các mã tham khảo
            exe.FormActive = D91E0140Form.D91F0310
            exe.FormPermission = _formPermission '"D91F0310"
            'FormName là form Phân quyền (_formPermission)
            exe.FormName = _formPermission 'IIf(_formName = "", _formPermission, _formName).ToString
            exe.LookupType = _LookupType
            exe.FormText = _FormText
            exe.FormSubText = _FormSubText
        ElseIf _formName = "D91F0320" Then ' Cập nhật mã tham khảo
            exe.FormActive = D91E0140Form.D91F0320
            exe.FormPermission = _formPermission '"D91F0310"
            exe.FormName = _formPermission 'IIf(_formName = "", _formPermission, _formName).ToString
            exe.LookupType = _LookupType
            exe.FormStatus = EnumFormState.FormAdd
            exe.FormText = "" '_FormText
            exe.FormSubText = _FormSubText
        End If
        exe.Run()


        If _formName = "D91F0310" Then ' Cơ chế không đợi
            Me.Close()
        Else ' Cơ chế đợi
            'Bắt đầu chạy cơ chế background
            backgroundWorker1 = New System.ComponentModel.BackgroundWorker
            backgroundWorker1.RunWorkerAsync()
        End If

    End Sub

    'sự kiện hoàn thành và dừng của Background
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        _outPut01 = exe.Output01
        Me.Close()
    End Sub

End Class