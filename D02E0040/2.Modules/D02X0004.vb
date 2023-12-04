Imports System.Text

#Region "Khai báo Structure"

''' <summary>
''' Khai báo Structure cho phần Tùy chọn của Module
''' </summary>
Public Structure StructureOption
    ''' <summary>
    ''' Hỏi trước khi lưu
    ''' </summary>
    Public MessageAskBeforeSave As Boolean
    ''' <summary>
    ''' Thông báo khi lưu thành công
    ''' </summary>
    Public MessageWhenSaveOK As Boolean
    ''' <summary>
    ''' Hiển thị form chọn kỳ kế toán khi chạy chương trình
    ''' </summary>
    Public ViewFormPeriodWhenAppRun As Boolean
    ''' <summary>
    ''' Lưu giá trị gần nhất
    ''' </summary>
    Public SaveLastRecent As Boolean
    ''' <summary>
    ''' Lưu đơn vị mặc định
    ''' </summary>
    Public DefaultDivisionID As String
    ''' <summary>
    ''' Khóa thành tiền quy đổi
    ''' </summary>
    Public LockConvertedAmount As Boolean
    ''' <summary>
    ''' Làm tròn thành tiền quy đổi
    ''' </summary>
    Public RoundConvertedAmount As Boolean
    ''' <summary>
    ''' Hiển thị quy trình sơ đồ nghiệp vụ
    ''' </summary>
    Public ViewWorkflow As Boolean
    ''' <summary>
    ''' Ngôn ngữ báo cáo
    ''' </summary>
    Public ReportLanguage As Byte
    ''' <summary>
    ''' Hiển thị đường dẫn báo cáo cho lần sau
    ''' </summary>
    Public ShowReportPath As Boolean
    '------------------------------------------------------------------------
    '  D02 Options here
    '------------------------------------------------------------------------
    Public DepAndEmpID As Boolean 'Bộ phận tiếp nhận và người tiếp nhận
    Public CipName As Boolean 'Tên XDCB
    Public CipDescription As Boolean 'Diễn giải
End Structure

''' <summary>
''' Khai báo structure cho phần Thiết lập hệ thống
''' </summary>
Public Structure StructureSystem
    ''' <summary>
    ''' Đơn vị mặc định
    ''' </summary>
    Public DefaultDivisionID As String
    ''' <summary>
    ''' TK tài sản
    ''' </summary>
    Public DefAssetAccountID As String
    ''' <summary>
    ''' TK khấu hao
    ''' </summary>
    Public DefDepreciationAccountID As String
    ''' <summary>
    ''' Nguồn vốn
    ''' </summary>
    Public DefSourceID As String
    ''' <summary>
    ''' Phân bổ KH
    ''' </summary>
    Public DefAssignmentID As String
    ''' <summary>
    ''' Phương pháp KH
    ''' </summary>
    Public MethodID As String
    ''' <summary>
    ''' Xử lý KH kỳ cuối
    ''' </summary>
    Public MethodEndID As String
    ''' <summary>
    ''' Các bút toán giảm TS
    ''' </summary>
    Public DecreaseAsset As Boolean
    ''' <summary>
    ''' Tạo mã tự động cho tài sản cố định
    ''' </summary>
    Public AssetAuto As Integer
    ''' <summary>
    ''' Phân loại 1
    ''' </summary>
    Public AssetS1Enabled As Boolean
    ''' <summary>
    ''' Phân loại 2
    ''' </summary>
    Public AssetS2Enabled As Boolean
    ''' <summary>
    ''' Phân loại 3
    ''' </summary>
    Public AssetS3Enabled As Boolean
    ''' <summary>
    ''' AssetS1Default
    ''' </summary>
    Public AssetS1Default As String
    ''' <summary>
    ''' AssetS2Default
    ''' </summary>
    Public AssetS2Default As String
    ''' <summary>
    ''' AssetS3Default
    ''' </summary>
    Public AssetS3Default As String
    ''' <summary>
    ''' S1Length
    ''' </summary>
    Public S1Length As Integer
    ''' <summary>
    ''' S2Length
    ''' </summary>
    Public S2Length As Integer
    ''' <summary>
    ''' S3Length
    ''' </summary>
    Public S3Length As Integer
    ''' <summary>
    ''' Dấu phân cách
    ''' </summary>
    Public AssetSeperated As Boolean
    ''' <summary>
    ''' Dấu phân cách
    ''' </summary>
    Public AssetSeperator As String
    ''' <summary>
    ''' Dạng hiển thị
    ''' </summary>
    Public AssetOutputOrder As String
    ''' <summary>
    ''' Độ dài số
    ''' </summary>
    Public AutoNumberLength As Integer
    ''' <summary>
    ''' Độ dài mã
    ''' </summary>
    Public AssetOutputLength As Integer
    ''' <summary>
    ''' Độ dài mã Incident 69247
    ''' </summary>
    Public CIPAuto As Boolean
    ''' <summary>
    ''' Mã TSCĐ và mã CCDC tăng liên tục
    ''' </summary>
    Public IsAssetIDForD02D43 As Boolean
    ''' <summary>
    ''' BĐS đầu tư
    ''' </summary>
    Public UseProperty As Boolean
    '------------------------------------------------------------------------
    '  D02 Systems here
    '------------------------------------------------------------------------
End Structure

''' <summary>
''' Khai báo structure cho phần định dạng format
''' </summary>
Public Structure StructureFormat

    ''' <summary>
    ''' format thành tiền nguyên tệ
    ''' </summary>
    Public OriginalAmount As String
    ''' <summary>
    ''' Số làm tròn của thành tiền nguyên tệ
    ''' </summary>
    Public OriginalAmountRound As Integer
    ''' <summary>
    ''' format thành tiền quy đổi
    ''' </summary>
    Public ConvertedAmount As String
    ''' <summary>
    ''' Số làm tròn của thành tiền quy đổi
    ''' </summary>
    Public ConvertedAmountRound As Integer
    ''' <summary>
    ''' format giảm giá
    ''' </summary>
    Public OriginalReduction As String
    ''' <summary>
    ''' Số làm tròn của giảm giá
    ''' </summary>
    Public OriginalReductionRound As Integer
    ''' <summary>
    ''' format giảm giá quy đổi
    ''' </summary>
    Public ConvertedReduction As String
    ''' <summary>
    ''' Số làm tròn của giảm giá quy đổi
    ''' </summary>
    Public ConvertedReductionRound As Integer

    ''' <summary>
    ''' format tỷ giá
    ''' </summary>
    Public ExchangeRate As String
    ''' <summary>
    ''' Số làm tròn của tỷ giá
    ''' </summary>
    Public ExchangeRateRound As Integer
    ''' <summary>
    ''' Nguyên tệ gốc
    ''' </summary>
    Public BaseCurrencyID As String
    ''' <summary>
    ''' Dấu phân cách thập phân
    ''' </summary>
    Public DecimalSeperator As String
    ''' <summary>
    ''' Dấu phân cách hàng ngàn
    ''' </summary>
    Public ThousandSeperator As String
    '------------------------------------------------------------------------
    '  D02 Format here
    '------------------------------------------------------------------------
End Structure

''' <summary>
''' Khai báo cho phần định dạng chung lấy từ D91P9300
''' Createdate 20/12/2007
''' </summary>
''' <remarks></remarks>
Public Structure StructureFormatNew
    ''' <summary>
    ''' Format tỷ giá
    ''' </summary>
    ''' <remarks></remarks>
    Public ExchangeRate As String
    ''' <summary>
    ''' Format nguyên tệ 
    ''' </summary>
    ''' <remarks></remarks>
    Public DecimalPlaces As String
    ''' <summary>
    ''' Format nguyên tệ ứng với mỗi loại tiền
    ''' </summary>
    ''' <remarks></remarks>
    Public MyOriginal As String
    ''' <summary>
    ''' Format tiền quy đổi
    ''' </summary>
    ''' <remarks></remarks>
    Public D90_Converted As String
    ''' <summary>
    ''' Format số lượng, số lượng quy đổi theo nhóm sản xuất
    ''' </summary>
    ''' <remarks></remarks>
    Public D07_Quantity As String
    ''' <summary>
    ''' Format đơn giá theo nhóm sản xuất
    ''' </summary>
    ''' <remarks></remarks>
    Public D07_UnitCost As String
    Public D08_Quantity As String
    Public D08_UnitCost As String
    Public D08_Ratio As String
    Public DecimalSeparator As String
    Public ThousandSeparator As String
    Public D90_ConvertedDecimals As Integer
    Public BaseCurrencyID As String 'Loai tien hoach toan
    ''' <summary>
    ''' Format 2 số lẽ
    ''' </summary>
    ''' <remarks></remarks>
    Public DefaultNumber2 As String
    ''' <summary>
    ''' Format 4 số lẽ
    ''' </summary>
    ''' <remarks></remarks>
    Public DefaultNumber4 As String
    ''' <summary>
    ''' Format 0 số lẽ
    ''' </summary>
    ''' <remarks></remarks>
    Public DefaultNumber0 As String
End Structure

#End Region

''' <summary>
''' Module liên quan đến các vấn đề về Tùy chọn, Thiết lập hệ thống, ...
''' </summary>
''' <remarks></remarks>
Module D02X0004

    ''' <summary>
    ''' Lưu trữ các thiết lập tùy chọn
    ''' </summary>
    Public D02Options As StructureOption
    ''' <summary>
    ''' Lưu trữ các thiết lập Thông tin hệ thống
    ''' </summary>
    Public D02Systems As StructureSystem
    ''' <summary>
    ''' Lưu trữ các thiết lập format
    ''' </summary>
    Public D02Format As StructureFormatNew
    ''' <summary>
    ''' Form Main của Module D02
    ''' </summary>
    Public frmD02F0000 As D02F0000
    ''' <summary>
    ''' Load toàn bộ các thông số tùy chọn vào biến D02Options
    ''' </summary>
    Public Sub LoadOptions()
        With D02Options
            'Kiểm tra tồn tại đường dẫn mới lưu .Net thì lấy dữ liệu, ngược lại thì lấy theo đường dẫn cũ (Lemon3_Dxx)
            'Kiem tra ky cac ten luu xuong cua VB6 de gan vao NET

            If D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "MessageAskBeforeSave") = "" Then 'Lay duong dan cu VB6
                Dim D02LocalOptionsLocations As String = "D02"
                Dim Options As String = "Options"

                With D02Options
                    .DefaultDivisionID = GetSetting(D02LocalOptionsLocations, Options, "Division", "")
                    .MessageAskBeforeSave = CType(GetSetting(D02LocalOptionsLocations, Options, "AskBeforeSave", "True"), Boolean)
                    .MessageWhenSaveOK = CType(GetSetting(D02LocalOptionsLocations, Options, "MessageWhenSaveOK", "True"), Boolean)
                    .SaveLastRecent = CType(GetSetting(D02LocalOptionsLocations, Options, "SaveRecentValues", "False"), Boolean)
                    .RoundConvertedAmount = CType(GetSetting(D02LocalOptionsLocations, Options, "RoundConvertedAmount", "False"), Boolean)
                    .LockConvertedAmount = CType(GetSetting(D02LocalOptionsLocations, Options, "LockConvertedAmount", "False"), Boolean)
                    .ViewFormPeriodWhenAppRun = CType(GetSetting(D02LocalOptionsLocations, Options, "AcountingScreen", "False"), Boolean)
                    .ViewWorkflow = CType(GetSetting(D02LocalOptionsLocations, Options, "ShowDiagramTransaction", "False"), Boolean)
                    .ReportLanguage = CType(GetSetting(D02LocalOptionsLocations, Options, "nRPLang", "0"), Byte)
                    .ShowReportPath = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "ShowReportPath", "True"), Boolean)
                End With
            Else 'Lấy đường dẫn mới .Net
                With D02Options
                    .DefaultDivisionID = D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "DefaultDivisionID", "")
                    .MessageAskBeforeSave = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "MessageAskBeforeSave", "True"), Boolean)
                    .MessageWhenSaveOK = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "MessageWhenSaveOK", "True"), Boolean)
                    .SaveLastRecent = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "SaveLastRecent", "False"), Boolean)
                    .RoundConvertedAmount = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "RoundConvertedAmount", "False"), Boolean)
                    .LockConvertedAmount = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "LockConvertedAmount", "False"), Boolean)
                    .ViewFormPeriodWhenAppRun = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun", "False"), Boolean)
                    .ViewWorkflow = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "ViewWorkflow", "False"), Boolean)
                    .ReportLanguage = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)
                    .ShowReportPath = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "ShowReportPath", "True"), Boolean)
                End With
            End If
            'Dim dt As DataTable = ReturnDataTable(SQLStoreD02P5550)
            'If dt.Rows.Count > 0 Then
            '    .DepAndEmpID = L3Bool(dt.Rows(0).Item("DepAndEmpID"))
            '    .CipName = L3Bool(dt.Rows(0).Item("CipName"))
            '    .CipDescription = L3Bool(dt.Rows(0).Item("CipDescription"))
            'End If
            'dt.Dispose()
        End With
    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P5550
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 13/07/2012 09:20:14
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load tùy chọn
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P5550() As String
        Dim sSQL As String = ""
        ' Làm theo incident 49472 - BỔ SUNG CÂU LỆNH KHI LOAD FORM - Theo THIHUAN (16/07/12)
        sSQL &= "--Lay du lieu thiet lap cua tab Sao chep tai form D02F0002"
        sSQL &= vbCrLf
        sSQL &= "Exec D02P5550 "
        sSQL &= SQLString(gsUserID) 'UserID, varchar[20], NOT NULL
        Return sSQL
    End Function



    ''' <summary>
    ''' Load toàn bộ các thống số thiết lập hệ thống vào biến D02Systems
    ''' </summary>
    Public Sub LoadSystems()
        Dim sSQL As String = "Select * From D02T0000"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            With D02Systems
                .DefaultDivisionID = dt.Rows(0).Item("DefaultDivisionID").ToString
                ' TK tài sản
                .DefAssetAccountID = dt.Rows(0).Item("DefAssetAccountID").ToString
                ' TK khấu hao
                .DefDepreciationAccountID = dt.Rows(0).Item("DefDepreciationAccountID").ToString
                ' Nguồn vốn
                .DefSourceID = dt.Rows(0).Item("DefSourceID").ToString
                ' Phân bổ KH
                .DefAssignmentID = dt.Rows(0).Item("DefAssignmentID").ToString
                ' Phương pháp KH
                .MethodID = dt.Rows(0).Item("MethodID").ToString
                ' Xử lý KH kỳ cuối
                .MethodEndID = dt.Rows(0).Item("MethodEndID").ToString
                ' Các bút toán giảm TS
                .DecreaseAsset = L3Bool(dt.Rows(0).Item("MethodEndID"))
                ' Tạo mã tự động cho tài sản cố định
                .AssetAuto = L3Int(dt.Rows(0).Item("AssetAuto"))
                ' Phân loại 1
                .AssetS1Enabled = L3Bool(dt.Rows(0).Item("AssetS1Enabled"))
                ' Phân loại 2
                .AssetS2Enabled = L3Bool(dt.Rows(0).Item("AssetS2Enabled"))
                ' Phân loại 3
                .AssetS3Enabled = L3Bool(dt.Rows(0).Item("AssetS3Enabled"))
                ' AssetS1Default
                .AssetS1Default = dt.Rows(0).Item("AssetS1Default").ToString
                ' AssetS2Default
                .AssetS2Default = dt.Rows(0).Item("AssetS2Default").ToString
                ' AssetS3Default
                .AssetS3Default = dt.Rows(0).Item("AssetS3Default").ToString
                ' S1Length
                .S1Length = L3Int(dt.Rows(0).Item("S1Length"))
                ' S2Length
                .S2Length = L3Int(dt.Rows(0).Item("S2Length"))
                ' S3Length
                .S3Length = L3Int(dt.Rows(0).Item("S3Length"))
                ' Dấu phân cách
                .AssetSeperated = L3Bool(dt.Rows(0).Item("AssetSeperated"))
                ' Dấu phân cách
                .AssetSeperator = dt.Rows(0).Item("AssetSeperator").ToString
                ' Dạng hiển thị
                .AssetOutputOrder = dt.Rows(0).Item("AssetOutputOrder").ToString
                ' Độ dài số
                .AutoNumberLength = L3Int(dt.Rows(0).Item("AutoNumberLength"))
                ' Độ dài mã
                .AssetOutputLength = L3Int(dt.Rows(0).Item("AssetOutputLength"))
                'Tạo mã tự động Incident 69247
                .CIPAuto = L3Bool(dt.Rows(0).Item("CIPAuto"))
                .IsAssetIDForD02D43 = L3Bool(dt.Rows(0).Item("IsAssetIDForD02D43"))
                .UseProperty = L3Bool(dt.Rows(0).Item("UseProperty"))
            End With
            dt.Dispose()
        Else
            With D02Systems
                .DefaultDivisionID = ""
                ' TK tài sản
                .DefAssetAccountID = ""
                ' TK khấu hao
                .DefDepreciationAccountID = ""
                ' Nguồn vốn
                .DefSourceID = ""
                ' Phân bổ KH
                .DefAssignmentID = ""
                ' Phương pháp KH
                .MethodID = ""
                ' Xử lý KH kỳ cuối
                .MethodEndID = ""
                ' Các bút toán giảm TS
                .DecreaseAsset = False
                ' Tạo mã tự động cho tài sản cố định
                .AssetAuto = 0
                ' Phân loại 1
                .AssetS1Enabled = False
                ' Phân loại 2
                .AssetS2Enabled = False
                ' Phân loại 3
                .AssetS3Enabled = False
                ' AssetS1Default
                .AssetS1Default = ""
                ' AssetS2Default
                .AssetS2Default = ""
                ' AssetS3Default
                .AssetS3Default = ""
                ' S1Length
                .S1Length = 0
                ' S2Length
                .S2Length = 0
                ' S3Length
                .S3Length = 0
                ' Dấu phân cách
                .AssetSeperated = False
                ' Dấu phân cách
                .AssetSeperator = ""
                ' Dạng hiển thị
                .AssetOutputOrder = ""
                ' Độ dài số
                .AutoNumberLength = 0
                ' Độ dài mã
                .AssetOutputLength = 0
            End With
        End If
    End Sub

    '''' <summary>
    '''' Load toàn bộ các thông số format cho biến D02Format
    '''' </summary>
    Public Sub LoadFormatsNew()
        Const Number2 As String = "#,##0.00"
        Const Number4 As String = "#,##0.0000" 'dung Format ty le thue
        Const Number0 As String = "#,##0"
        Dim sSQL As String = "Exec D91P9300 "
        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)
        With D02Format
            If dt.Rows.Count > 0 Then
                .ExchangeRate = InsertFormat(dt.Rows(0).Item("ExchangeRateDecimals"))
                .DecimalPlaces = InsertFormat(dt.Rows(0).Item("DecimalPlaces"))
                .MyOriginal = .DecimalPlaces
                .D90_Converted = InsertFormat(dt.Rows(0).Item("D90_ConvertedDecimals"))
                .D07_Quantity = InsertFormat(dt.Rows(0).Item("D07_QuantityDecimals"))
                .D07_UnitCost = InsertFormat(dt.Rows(0).Item("D07_UnitCostDecimals"))
                .D08_Quantity = InsertFormat(dt.Rows(0).Item("D08_QuantityDecimals"))
                .D08_UnitCost = InsertFormat(dt.Rows(0).Item("D08_UnitCostDecimals"))
                .D08_Ratio = InsertFormat(dt.Rows(0).Item("D08_RatioDecimals"))
                .D90_ConvertedDecimals = CInt(dt.Rows(0).Item("D90_ConvertedDecimals"))
                .BaseCurrencyID = (IIf(IsDBNull(dt.Rows(0).Item("BaseCurrencyID").ToString), "", dt.Rows(0).Item("BaseCurrencyID").ToString)).ToString

                '.BOMQty = InsertFormat(dt.Rows(0).Item("BOMQtyDecimals"))
                '.BOMPrice = InsertFormat(dt.Rows(0).Item("BOMPriceDecimals"))
                '.BOMAmt = InsertFormat(dt.Rows(0).Item("BOMAmtDecimals"))
            Else
                .ExchangeRate = Number2
                .D90_Converted = Number2
                .D07_Quantity = Number2
                .D07_UnitCost = Number2
                .D08_Quantity = Number2
                .D08_UnitCost = Number2
                .D08_Ratio = Number2
                .D90_ConvertedDecimals = 0
                .DecimalSeparator = ","
                .ThousandSeparator = "."
                .BaseCurrencyID = ""
                '.BOMQty = Number2
                '.BOMPrice = Number2
                '.BOMAmt = Number2
            End If
            .DefaultNumber2 = Number2
            .DefaultNumber4 = Number4
            .DefaultNumber0 = Number0
        End With
    End Sub

    Public Function InsertFormat(ByVal ONumber As Object) As String
        Dim iNumber As Int16 = Convert.ToInt16(ONumber)
        Dim sRet As String = "#,##0"
        If iNumber = 0 Then
        Else
            sRet &= "." & Strings.StrDup(iNumber, "0")
        End If
        Return sRet
    End Function

    Public Function GetOriginalDecimal(ByVal sCurrencyID As String) As String

        Dim sSQL As String
        sSQL = "Select OriginalDecimal From D91V0010 Where CurrencyID = " & SQLString(sCurrencyID)
        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            Return InsertFormat(dt.Rows(0).Item("OriginalDecimal"))
        Else
            Return D02Format.DecimalPlaces
        End If
    End Function

    Public Function InserZero(ByVal NumZero As Byte) As String
        '#------------------------------------------------------
        '#CreateUser: Nguyen Thi Minh Hoa
        '#CreateDate: 04/04/2006
        '#ModifiedUser:  Nguyen Thi Minh Hoa
        '#ModifiedDate:  04/04/2006
        '#Description: Format so theo D91
        '#------------------------------------------------------
        If NumZero = 0 Then
            InserZero = ""
        Else
            InserZero = "."
            InserZero &= StrDup(NumZero, "0")
        End If
    End Function

    ''' <summary>
    ''' Hỏi trước khi lưu tùy thuộc vào thiết lập ở phần Tùy chọn
    ''' </summary>
    Public Function AskSave() As DialogResult
        If D02Options.MessageAskBeforeSave Then
            Return D99C0008.MsgAskSave()
        Else
            Return DialogResult.Yes
        End If
    End Function

    ''' <summary>
    ''' Thông báo trước khi xóa
    ''' </summary>    
    Public Function AskDelete() As DialogResult
        If D02Options.MessageAskBeforeSave Then
            Return D99C0008.MsgAskDelete
        Else
            Return DialogResult.Yes
        End If
    End Function

    ''' <summary>
    ''' Thông báo trước khi khóa phiếu
    ''' </summary>    
    Public Function AskLocked() As DialogResult
        If D02Options.MessageAskBeforeSave Then
            Return D99C0008.MsgAsk(rl3("MSG000002"), MessageBoxDefaultButton.Button2)
        Else
            Return DialogResult.Yes
        End If
    End Function

    ''' <summary>
    ''' Thông báo khi lưu thành công tùy theo phần thiết lập ở tùy chọn
    ''' </summary>
    Public Sub SaveOK()
        If D02Options.MessageWhenSaveOK Then D99C0008.MsgSaveOK()
    End Sub

    ''' <summary>
    ''' Thông báo sau khi xóa thành công
    ''' </summary>
    Public Sub DeleteOK()
        If D02Options.MessageWhenSaveOK Then D99C0008.MsgL3(rl3("MSG000008"))
    End Sub

    ''' <summary>
    ''' Thông báo sau khi khóa phiếu thành công
    ''' </summary>
    Public Sub LockedOK()
        If D02Options.MessageWhenSaveOK Then D99C0008.MsgSaveOK()
    End Sub

    ''' <summary>
    ''' Thông báo không lưu được dữ liệu
    ''' </summary>
    Public Sub SaveNotOK()
        D99C0008.MsgSaveNotOK()
    End Sub

    ''' <summary>
    ''' Thông báo không xóa được dữ liệu
    ''' </summary>
    Public Sub DeleteNotOK()
        'D99C0008.MsgL3(rl3("Khong_xoa_duoc_du_lieu"))
        D99C0008.MsgCanNotDelete()
    End Sub

    ''' <summary>
    ''' Thông báo không khóa được phiếu
    ''' </summary>
    Public Sub LockedNotOK()
        D99C0008.MsgSaveNotOK()
    End Sub

End Module
