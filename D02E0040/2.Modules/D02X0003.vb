''' <summary>
''' Module này dùng để khai báo các vấn đề liên quan đến việc gọi một exe con
''' </summary>
Module D02X0003

    Public Const EXEMODULE As String = "D02"
    Public Const EXED00 As String = "D00E0030"
    Public Const EXEPARENT As String = "D02E0030"
    Public Const EXECHILD As String = "D02E0040"
    '---------------------------------------
    '''' <summary>
    '''' Server truyền vào
    '''' </summary>
    ''Public PARA_Server As String
    '''' <summary>
    '''' Database truyền vào
    '''' </summary>
    'Public PARA_Database As String
    '''' <summary>
    '''' User login vào Lemon3 truyền vào
    '''' </summary>
    'Public PARA_ConnectionUser As String
    '''' <summary>
    '''' User login vào Database truyền vào
    '''' </summary>
    'Public PARA_UserID As String
    '''' <summary>
    '''' Password user login vào Database truyền vào
    '''' </summary>
    'Public PARA_Password As String
    '''' <summary>
    '''' Đơn vị truyền vào
    '''' </summary>
    'Public PARA_DivisionID As String
    '''' <summary>
    '''' Tháng kế toán truyền vào
    '''' </summary>
    'Public PARA_TranMonth As String
    '''' <summary>
    '''' Năm kế toán truyền vào
    '''' </summary>
    'Public PARA_TranYear As String
    '''' <summary>
    '''' Ngôn ngữ truyền vào
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_Language As EnumLanguage
    '''' <summary>
    '''' Form ID dùng để hiện thị. Ví dụ: DxxFxxxx
    '''' </summary>
    'Public PARA_FormID As String
    '''' <summary>
    '''' Form ID dùng để phân quyền. Ví dụ: DxxFxxxx
    '''' </summary>
    'Public PARA_FormIDPermission As String

    'Public Sub RunAuditLog(ByVal sAuditCode As String, ByVal sEventID As String, Optional ByVal sDesc1 As String = "", Optional ByVal sDesc2 As String = "", Optional ByVal sDesc3 As String = "", Optional ByVal sDesc4 As String = "", Optional ByVal sDesc5 As String = "")

    '    'Ghi Audit cho mỗi nghiệp vụ
    '    Dim sSQL As String = ""
    '    sSQL &= "Exec D91P9106 "
    '    sSQL &= SQLDateTimeSave(Now) & COMMA 'AuditDate, datetime, NOT NULL
    '    sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
    '    sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
    '    sSQL &= SQLString(gsModuleID) & COMMA 'ModuleID, varchar[2], NOT NULL
    '    sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
    '    sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
    '    sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc5) 'Desc5, varchar[250], NOT NULL

    '    ExecuteSQL(sSQL)

    'End Sub

End Module
