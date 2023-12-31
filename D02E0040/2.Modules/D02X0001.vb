''' <summary>
''' Module này liên qua đến các khai báo biến, enum, ... toàn cục
''' </summary>
Module D02X0001
    '''' <summary>
    '''' Module đang coding D02E0040
    '''' </summary>
    ''Public Const MODULED02 As String = "D02E0040"
    '''' <summary>
    '''' Chuỗi D02
    '''' </summary>
    'Public Const D02 As String = "D02"
    Public Const gsModuleID As String = "02"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_APP_NAME As String = "Lemon3"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET cho phiên bản hiện tại
    ''' </summary>
    Public Const L3_HS_SECTION As String = "HandshakeR360"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET  cho 2 phiên bản cũ
    ''' </summary>
    Public Const L3_HS_SECTION1 As String = "Handshake"
    Public Const L3_HS_SECTION2 As String = "Handshake"

    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_MODULE As String = "D02"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_VALUE As String = "R3.60.00.Y2007"

    Public gbSaveOK As Boolean = False
    Public giFirstTranMonth As Integer 'Dùng để phân cho D40F2000 :Số dư đầu kỳ
    Public giFirstTranYear As Integer 'Dùng để phân cho D40F2000 :Số dư đầu kỳ
    'Khóa sổ
    Public Const AuditCodeCloseBook As String = "CloseBookD02"
    'Mở sổ
    Public Const AuditCodeOpenBook As String = "OpenBookD02"
    '*******Update ngay 7/1/2013 theo ID 53113
    'Mở sổ đặc biệt
    Public gbOpeningSpecial As Boolean = False
    Public gbEndModule As Boolean = False
    '*********************
End Module
