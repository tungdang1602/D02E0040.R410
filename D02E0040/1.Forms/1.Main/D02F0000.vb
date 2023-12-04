'#-------------------------------------------------------------------------------------
'# Created Date: 01/08/2006 4:10:02 PM
'# Created User: Nguyễn Thị Minh Hòa
'# Modify Date: 01/08/2006 4:10:02 PM
'# Modify User: Nguyễn Thị Minh Hòa
'#-------------------------------------------------------------------------------------
Public Class D02F0000

    Private Const D02P0030 As String = "\Bitmap\D02P0030.jpg"
    Private Const D02P0031 As String = "\Bitmap\D02P0031.jpg"

    Private Sub D02F0000_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        KillChildProcess(MODULED02)
    End Sub

    Private Sub D02F0000_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadLanguage(True)
        LoadStatusStrip()
        StandardlizeStatusBar()

        picMain.BackgroundImageLayout = ImageLayout.Stretch
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub StandardlizeStatusBar()
        stbMain.Items.Remove(sbServerName)
        sbServerNameCaption.Spring = True
        sbServerNameCaption.Text = ""
    End Sub


    Private Sub D02F0000_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ShowFormSystemsIfNeed()
        '*******Them ngay 7/1/2013 theo ID 53113
        'Kiểm tra Mở sổ đặc biệt
        Dim bShowFormPeriod As Boolean = OpeningSpecial(True) <> 2
        '******************
        mnuPeriod.Text = MakeMenuPeriod()
        If bShowFormPeriod AndAlso D02Options.ViewFormPeriodWhenAppRun And (ReturnPermission("D02F0003") >= EnumPermission.View) Then 'theo ID 53113
            ' If D02Options.ViewFormPeriodWhenAppRun Then
            Dim f As New D02F0003
            f.ShowDialog()
            If f.DialogResult = Windows.Forms.DialogResult.OK Then mnuPeriod.Text = MakeMenuPeriod()
            f.Dispose()
        End If
        GetFirstPeriod(gsDivisionID) ' update 6/5/2013 id 56280
        SetMenuPermission()
        SetMenuPermissionTransaction()
        SetEnableMenuPermissionTransaction()
        SetVisibleDelimiter(C1MainMenu) 'Ẩn phân nhóm
        SetTextMenu(C1MainMenu)
    End Sub

    Private Sub LoadStatusStrip()
        sbServerName.Text = gsServer.ToUpper
        sbCompany.Text = gsCompanyID.ToUpper
        sbUserID.Text = gsUserID.ToUpper
        sbCurrentDate.Text = Date.Now.ToShortDateString
    End Sub

    Private Sub LoadBitmap()
        If geLanguage = EnumLanguage.Vietnamese Then
            If My.Computer.FileSystem.FileExists(gsApplicationSetup & D02P0030) Then
                Dim bmp As New Bitmap(gsApplicationSetup & D02P0030)
                picMain.BackgroundImage = bmp
            End If
        ElseIf geLanguage = EnumLanguage.English Then
            If My.Computer.FileSystem.FileExists(gsApplicationSetup & D02P0031) Then
                Dim bmp As New Bitmap(gsApplicationSetup & D02P0031)
                picMain.BackgroundImage = bmp
            End If
        End If
    End Sub

    Private Sub LoadLanguage(Optional ByVal bLoadFirst As Boolean = False)
        GeneralItems()
        LoadMenuShortcut()
        LoadBitmap()
        If bLoadFirst = False Then SetTextMenu(C1MainMenu)

        If geLanguage = EnumLanguage.Vietnamese Then
            mnuSystemLanguageVietnamese.Checked = True
            mnuSystemLanguageEnglish.Checked = False
        Else
            mnuSystemLanguageVietnamese.Checked = False
            mnuSystemLanguageEnglish.Checked = True
        End If

    End Sub

    Private Sub LoadMenuShortcut()
        '================================================================ 
        'Phần chung của các module
        'sbServerNameCaption.Text = rl3("Ten_may_chu")
        sbCompanyCaption.Text = rl3("Doanh_nghiep")
        sbUserIDCaption.Text = rL3("Nguoi_dung")

        '================================================================ 
        mnuSystem.Text = rl3("_He_thong")
        mnuTransaction.Text = rl3("_Nghiep_vu")
        mnuInquiry.Text = rl3("_Truy_van")
        'Them ngay 5/3/2013 theo ID 54463*****************************
        mnuStatis.Text = rl3("Thong_ke_____Phan_tich")

        '*******************************
        mnuReport.Text = rl3("_Bao_cao")
        mnuList.Text = rl3("_Danh_muc")

        mnuPeriod.Text = rl3("_Ky_ke_toan") & ":" & Space(1) & giTranMonth.ToString("00") & "/" & giTranYear & Space(3) & rl3("Don_vi") & ":" & Space(1) & gsDivisionID
        '================================================================ 
        Me.Text = rl3("Tai_san_co_dinh_-_D02F0000") 'Tªi s¶n cç ¢Ünh - D02F0000
        '================================================================ 
        'Hệ thống
        mnuSystemSetup.Text = rl3("Thiet_lap_he_thong") 'Thiết lập hệ thống
        mnuSystemIndexSetup.Text = rl3("Thiet_lap_chi_so") 'Thiết lập chỉ số
        mnuSystemSetupInfo.Text = rl3("Thiet_lap_thong_tin_bo_sung") 'Thiết lập thông tin bổ sung
        ' update 5/9/2013 id 58781
        mnuSysAutoCreatingCodeMethodCIP.Text = rl3("Phuong_phap_tao_ma_tu_dong") 'Phương pháp tạo mã tự động
        mnuSysMethodCIP.Text = rL3("Ma_XDCB")
        mnuSysFixedAssets.Text = rL3("Ma_TSCD")
        mnuLockedVoucher.Text = rl3("Khoa_phieu")
        mnuSystemModifyAutoVoucherNumber.Text = rl3("Sua_so_tang_tu_dong") 'Sửa số tăng tự động
        mnuSystemCloseBook.Text = rl3("Khoa_so") 'Khóa sổ
        mnuSystemNewPeriod.Text = rl3("Tao_ky") 'Tạo kỳ
        mnuSystemOpenBook.Text = rl3("Mo_so") 'Mở sổ
        mnuSystemStatusCloseBook.Text = rl3("Tinh_trang_khoa_so")
        mnuSystemOption.Text = rl3("Tuy_chon") 'Tùy chọn
        mnuSystemLanguage.Text = rl3("Ngon_ngu") 'Ngôn ngữ
        mnuSystemLanguageVietnamese.Text = rl3("Tieng_Viet") 'Tiếng Việt
        mnuSystemLanguageEnglish.Text = rl3("Tieng_Anh") 'Tiếng Anh
        mnuSystemQuit.Text = "&X  " & rl3("Thoat") 'Thoát

        'Nghiệp vụ
        mnuTransactionSetup.Text = rl3("Hinh_thanh_TSCD") 'Hình thành TSCĐ
        mnuTransactionSetupAssetPurchasing.Text = rl3("Tu_mua_sam") 'Từ mua sắm
        mnuTransactionSetupAssetFromCIP.Text = rL3("Tu_XDCB") 'Từ XDCB
        mnuTransactionSetupAssetPurchasingDD.Text = rL3("Tu_dieu_dong_von")
        mnuTransactionInputBalance.Text = rl3("Nhap_so_du") 'Nhập số dư
        mnuTransactionInputRemainder.Text = rl3("Nhap_so_du_TSCD") 'Nhập số dư TSCĐ
        mnuTransactionSetupAssetAuto.Text = rl3("Tao_tu_dong_so_du_TSCD") 'Tạo tự động số dư TSCĐ

        mnuTransactionDepreciation.Text = rl3("Tinh_khau_hao") 'Tính khấu hao

        mnuTransactionAssetTransactionVoucher.Text = rl3("Nghiep_vu_tac_dong") 'Nghiệp vụ tác động
        mnuTransactionAssetTransferDivision.Text = rL3("Dieu_chuyen_TSCD_theo_don_vi") 'Điều chuyển TSCĐ theo đơn vị
        mnuTransationChangeSource.Text = rL3("Chuyen_nguon_von")

        mnuTransactionCollectCost.Text = rl3("Tap_hop_chi_phi_XDCB") 'Tập hợp chi phí XDCB
        mnuTransactionCIPBalanceEnter.Text = rl3("Nhap_so_du_XDCB") 'Nhập số dư XDCB
        mnuTransactionBalanceCIP.Text = rl3("Quyet_toan_XDCB") 'Quyết toán XDCB
        mnuTransactionInputVoucher.Text = rl3("Nhap_chung_tu") 'Nhập chứng từ
        mnuTransactionCostSplitVoucher.Text = rl3("Tach_chi_phi") 'Tách chi phí
        mnuTransactionUpdateIndex.Text = rL3("Cap_nhat_chi_so")
        mnuTransactionAssetActual.Text = rL3("Kiem_ke_tai_sanU") 'Kiểm kê tài sản

        'Truy vấn
        mnuInquiryFormedAsset.Text = rl3("Hinh_thanh_tai_san") 'Hình thành tài sản
        mnuInquiryAssetTransactionVoucher.Text = rL3("Nghiep_vu_tac_dong") 'Nghiệp vụ tác động
        mnuInquiryAssetTransferDivision.Text = rL3("Dieu_chuyen_TSCD_theo_don_vi") 'Điều chuyển TSCĐ theo đơn vị
        ' update 3/7/2013 id 57421
        mnuTransactionConvert.Text = rl3("Chuyen_doi_TSCD") ' Chuyển đổi TSCĐ
        mnuInquiryVoucher.Text = rl3("Chung_tu") 'Chứng từ
        mnuInquiryDepreciationAllocationVoucher.Text = rl3("Truy_van") & Space(1) & rl3("But_toan_phan_bo_khau_hao") 'Bút toán phân bổ khấu hao
        mnuInquiryBalanceCip.Text = rL3("Quyet_toan_XDCB") 'Quyết toán XDCB
        mnuInquiry_AssetRiseReduce.Text = rL3("Thuyet_minh_tang_giam_tai_san") 'Quyết toán XDCB

        'Thống kê & Phân tích
        mnuStatisAsset.Text = rl3("Truy_van_tai_san")
        mnuStatisCIPCostBalance.Text = rl3("Truy_van_tong_hop_XDCB") 'Truy vấn tổng hợp XDCB
        '*Update 3/4/2013 theo ID 55380 của Bảo Chi bởi Văn Vinh
        mnuStatisCostBalanceFixAsset.Text = rl3("Truy_van_tong_hop_TSCD") 'Truy vấn tổng hợp TSCĐ
        '****************************************
        mnuStatisFixedAssetsAndCIPs.Text = rl3("Tinh_hinh_TSCD_va_XDCB")
        mnuStaticAssetsDepreciation.Text = rl3("Tong_ket_khau_hao_TSCD") 'Tổng kết khấu hao TSCĐ

        'Báo cáo
        mnuReportInputFixAsset.Text = rl3("Phieu_nhap_TSCD") 'Phiếu nhập TSCĐ
        mnuReportCardtFixAsset.Text = rl3("The_TSCD") 'Thẻ TSCĐ
        mnuReportDetailFixAsset.Text = rl3("So_chi_tiet_TSCD") 'Sổ chi tiết TSCĐ
        mnuReportListFixAsset.Text = rl3("Danh_sach_TSCD0") 'rl3("Danh_sach_TSCD") 'Danh sách TSCĐ
        mnuReportIn_DecreaseFixAsset.Text = rl3("Bao_cao_tang_giam_TSCD") 'Báo cáo tăng giảm TSCĐ
        mnuReportAssetBalance.Text = rl3("Bao_cao_nhap_xuat_ton_TSCD") 'Báo cáo nhập xuất tồn TSCĐ
        mnuReportMovingFixAsset.Text = rl3("Tai_san_di_chuyen_noi_bo") 'Tài sản di chuyển nội bộ
        mnuReportEquipmentAttachAsset.Text = rl3("Thiet_bi_dinh_kem_tai_san") 'Thiết bị đính kèm tài sản
        mnuReportDepInPeriod.Text = rl3("Khau_hao_TSCD_theo_ky") 'Khấu hao TSCĐ theo kỳ
        mnuReportDistributeDep.Text = rl3("Bao_cao_phan_bo_khau_hao") 'Báo cáo phân bổ khấu hao
        mnuReportEndDepFixAsset.Text = rl3("Tong_ket_khau_hao_TSCD") 'Tổng kết khấu hao TSCĐ
        mnuReportEffectHistory.Text = rl3("Bao_cao_lich_su_tac_dong") 'Báo cáo lịch sử tác động
        mnuReportCost.Text = rl3("Bao_cao_chi_phi_XDCB") 'Báo cáo chi phí XDCB
        mnuReportEffectTrans.Text = rl3("Bao_cao_nghiep_vu_tac_dong") 'Báo cáo nghiệp vụ tác động
        mnuReportAnalyseFixAsset.Text = rl3("Bao_cao_phan_tich_TSCD") 'Báo cáo phân tích TSCĐ
        mnuReportCustomise.Text = rl3("Bao_cao_dac_thu") 'Báo cáo đặc thù
        'Thay đổi ngày 10/10/2012 theo incident 51651 của Bảo Trân bởi Văn Vinh
        ' mnuReportForm.Text = "&Q  " & rl3("Mau_bao_cao") 'Mẫu báo cáo
        mnuReportSetup.Text = rl3("Thiet_lap") 'Thiết lập
        mnuReportCipCost.Text = rl3("Bao_cao_chi_phi_XDCB_do_dang") 'Báo cáo chi phí XDCB dở dang
        mnuReportSetupEffectTrans.Text = rl3("Bao_cao_nghiep_vu_tac_dong") 'Báo cáo nghiệp vụ tác động
        mnuReportSetupAnaFixAsset.Text = rl3("Bao_cao_phan_tich_TSCD") 'Báo cáo phân tích TSCĐ
        mnuReportForm.Text = rl3("Mau_bao_cao") 'Mẫu báo cáo
        'Danh mục
        mnuListAsset.Text = rl3("Tai_san") 'Tài sản
        mnuListAssetAnalysisTypeCode.Text = rl3("Ma_loai_phan_tich_tai_san")
        mnuListAssetAnalyseCode.Text = rl3("Ma_phan_tich_tai_san")

        mnuListCipCode.Text = rl3("Ma_XDCB") 'Mã XDCB
        mnuListCipAnalyseTypeCode.Text = rl3("Ma_phan_loai_phan_tich_XDCB")
        mnuListCipAnalyseCode.Text = rl3("Ma_phan_tich_XDCB")

        mnuListClassification.Text = rl3("Phan_loai") 'Phân loại
        mnuListSource.Text = rl3("Nguon_hinh_thanh") 'Nguồn hình thành
        mnuListAssignment.Text = rl3("Tieu_thuc_phan_bo")
        mnuListNorm.Text = rl3("Bo_dinh_muc") 'Bộ định mức
        mnuListDepreciationTable.Text = rl3("Bang_khau_hao")
        mnuListSplitMethod.Text = rl3("Phuong_phap_tach_chi_phi") 'Phương pháp tách chi phí
        mnuListChange.Text = rl3("Nghiep_vu_tac_dong")
        mnuListReason.Text = rL3("Ly_do_tac_dong")
        mnuListPosition.Text = rL3("Vi_tri")
        mnuListStatus.Text = rL3("Tinh_trang")


    End Sub

    'Sub này không ảnh hưởng bởi biến gbClosed
    Private Sub SetMenuPermission()
        'Phân quyền cho menu Hệ thống
        VisibledMenu(mnuSystemSetup, ReturnPermission("D02F0001") >= EnumPermission.View)
        VisibledMenu(mnuSystemIndexSetup, ReturnPermission("D02F9001") >= EnumPermission.View)
        VisibledMenu(mnuSysFixedAssets, ReturnPermission("D02F0070") >= EnumPermission.View)

        ' update 5/9/2013 id 58781
        VisibledMenu(mnuSysMethodCIP, ReturnPermission("D02F0060") >= EnumPermission.View)
        VisibledMenu(mnuSystemOption, ReturnPermission("D02F0002") >= EnumPermission.View)
        VisibledMenu(mnuSystemSetupInfo, ReturnPermission("D02F1910") >= EnumPermission.View)

        'Phân quyền cho menu Truy vấn
        VisibledMenu(mnuInquiryFormedAsset, ReturnPermission("D02F0300") >= EnumPermission.View)
        VisibledMenu(mnuInquiryAssetTransactionVoucher, ReturnPermission("D02F2002") >= EnumPermission.View)
        VisibledMenu(mnuInquiryAssetTransferDivision, D02Systems.AllowChangeDivision And ReturnPermission("D02F2016") >= EnumPermission.View)

        VisibledMenu(mnuInquiryVoucher, ReturnPermission("D02F2005") >= EnumPermission.View)
        VisibledMenu(mnuInquiryDepreciationAllocationVoucher, ReturnPermission("D02F0501") >= EnumPermission.View)
        VisibledMenu(mnuStatisAsset, ReturnPermission("D02F0600") >= EnumPermission.View)
        VisibledMenu(mnuStatisCIPCostBalance, ReturnPermission("D02F0600") >= EnumPermission.View)
        VisibledMenu(mnuInquiryBalanceCip, ReturnPermission("D02F2015") >= EnumPermission.View)
        VisibledMenu(mnuInquiry_AssetRiseReduce, ReturnPermission("D02F3070") >= EnumPermission.View)
        VisibledMenu(mnuStatisFixedAssetsAndCIPs, ReturnPermission("D02F2020") >= EnumPermission.View)
        VisibledMenu(mnuStaticAssetsDepreciation, ReturnPermission("D02F3060") >= EnumPermission.View)
        VisibledMenu(mnuStatisCostBalanceFixAsset, ReturnPermission("D02F2030") >= EnumPermission.View)
        'Phân quyền cho menu Báo cáo
        VisibledMenu(mnuReportInputFixAsset, ReturnPermission("D02F3011") >= EnumPermission.View)
        VisibledMenu(mnuReportCardtFixAsset, ReturnPermission("D02F3010") >= EnumPermission.View)
        VisibledMenu(mnuReportDetailFixAsset, ReturnPermission("D02F3200") >= EnumPermission.View)
        VisibledMenu(mnuReportListFixAsset, ReturnPermission("D02F3020") >= EnumPermission.View)
        VisibledMenu(mnuReportIn_DecreaseFixAsset, ReturnPermission("D02F3012") >= EnumPermission.View)
        VisibledMenu(mnuReportAssetBalance, ReturnPermission("D02F4100") >= EnumPermission.View)
        VisibledMenu(mnuReportMovingFixAsset, ReturnPermission("D02F3040") >= EnumPermission.View)
        VisibledMenu(mnuReportEquipmentAttachAsset, ReturnPermission("D02F3050") >= EnumPermission.View)
        VisibledMenu(mnuReportDepInPeriod, ReturnPermission("D02F3021") >= EnumPermission.View)
        VisibledMenu(mnuReportDistributeDep, ReturnPermission("D02F3030") >= EnumPermission.View)
        VisibledMenu(mnuReportEndDepFixAsset, ReturnPermission("D02F3025") >= EnumPermission.View)
        VisibledMenu(mnuReportEffectHistory, ReturnPermission("D02F3300") >= EnumPermission.View)
        VisibledMenu(mnuReportCost, ReturnPermission("D02F5005") >= EnumPermission.View)
        VisibledMenu(mnuReportEffectTrans, ReturnPermission("D02F6005") >= EnumPermission.View)
        VisibledMenu(mnuReportAnalyseFixAsset, ReturnPermission("D02F7005") >= EnumPermission.View)
        VisibledMenu(mnuReportCustomise, ReturnPermission("D02F9100") >= EnumPermission.View)
        VisibledMenu(mnuReportForm, ReturnPermission("D02F9101") >= EnumPermission.View)
        VisibledMenu(mnuReportCipCost, ReturnPermission("D02F5003") >= EnumPermission.View)
        VisibledMenu(mnuReportSetupEffectTrans, ReturnPermission("D02F6003") >= EnumPermission.View)
        VisibledMenu(mnuReportSetupAnaFixAsset, ReturnPermission("D02F7003") >= EnumPermission.View)

        'Phân quyền cho menu Danh mục
        VisibledMenu(mnuListAsset, ReturnPermission("D02F1030") >= EnumPermission.View)
        VisibledMenu(mnuListAssetAnalysisTypeCode, ReturnPermission("D02F0040") >= EnumPermission.View)
        VisibledMenu(mnuListAssetAnalyseCode, ReturnPermission("D02F0041") >= EnumPermission.View)
        VisibledMenu(mnuListCipCode, ReturnPermission("D02F2000") >= EnumPermission.View)
        VisibledMenu(mnuListCipAnalyseTypeCode, ReturnPermission("D02F0050") >= EnumPermission.View)
        VisibledMenu(mnuListCipAnalyseCode, ReturnPermission("D02F0051") >= EnumPermission.View)
        VisibledMenu(mnuListClassification, ReturnPermission("D02F3000") >= EnumPermission.View)
        VisibledMenu(mnuListSource, ReturnPermission("D02F0200") >= EnumPermission.View)
        VisibledMenu(mnuListAssignment, ReturnPermission("D02F0100") >= EnumPermission.View)
        VisibledMenu(mnuListNorm, ReturnPermission("D02F0054") >= EnumPermission.View)
        VisibledMenu(mnuListDepreciationTable, ReturnPermission("D02F0020") >= EnumPermission.View)
        VisibledMenu(mnuListChange, ReturnPermission("D02F1021") >= EnumPermission.View)
        VisibledMenu(mnuListSplitMethod, ReturnPermission("D02F1041") >= EnumPermission.View)
        VisibledMenu(mnuListReason, ReturnPermission("D02F1150") >= EnumPermission.View)
        'VisibledMenu(mnuPeriod, ReturnPermission("D02F0003") >= EnumPermission.View)
        mnuPeriod.Enabled = ReturnPermission("D02F0003") >= EnumPermission.View
        VisibledMenu(mnuListPosition, ReturnPermission("D02F0700") >= EnumPermission.View)
        VisibledMenu(mnuListStatus, ReturnPermission("D02F0800") >= EnumPermission.View)

    End Sub

    Private Sub VisibledMenu(ByVal mnu As C1.Win.C1Command.C1Command, ByVal FormPermission As Boolean)
        If mnu.Visible Then mnu.Visible = FormPermission 'kiểm tra giao diện có design nhưng set Visibled = False
    End Sub

    'Sub này có ảnh hưởng bởi biến gbClosed
    Private Sub SetMenuPermissionTransaction()
        ''Phân quyền cho menu Hệ thống phụ thuộc vào biến gbClosed
        ''************* Them ngay 7/1/2013 theo ID 53113
        ''Nếu Mở sổ đặc biệt thì mờ menu Khóa sổ, Mở sổ
        'mnuSystemCloseBook.Enabled = Not gbClosed AndAlso (Not gbOpeningSpecial)
        'mnuSystemOpenBook.Enabled = gbClosed AndAlso (Not gbOpeningSpecial)
        'mnuSystemNewPeriod.Enabled = True
        'mnuSystemModifyAutoVoucherNumber.Enabled = ReturnPermission("D02F5702") > EnumPermission.View And Not gbClosed
        'mnuLockedVoucher.Enabled = ReturnPermission("D02F5557") >= EnumPermission.View And (Not gbClosed)
        ''Phân quyền cho menu Nghiệp vụ phụ thuộc vào biến gbClosed
        'If giFirstTranMonth = giTranMonth And giFirstTranYear = giTranYear Then
        '    mnuTransactionCIPBalanceEnter.Enabled = (Not gbClosed) And ReturnPermission("D02F1007") > EnumPermission.View
        '    'Modify 20/12/2013 - ID 62126
        '    mnuTransactionInputRemainder.Enabled = (Not gbClosed) And ReturnPermission("D02F1002") > EnumPermission.View
        '    mnuTransactionSetupAssetAuto.Enabled = (Not gbClosed) And ReturnPermission("D02F1002") > EnumPermission.View
        'Else
        '    mnuTransactionCIPBalanceEnter.Enabled = False  'D02F1007
        '    mnuTransactionInputRemainder.Enabled = False
        '    mnuTransactionSetupAssetAuto.Enabled = False
        'End If
        ''**************
        'mnuTransactionSetupAssetPurchasing.Enabled = (Not gbClosed) And ReturnPermission("D02F0300") > EnumPermission.View
        'mnuTransactionSetupAssetFromCIP.Enabled = (Not gbClosed) And ReturnPermission("D02F0300") > EnumPermission.View
        'mnuTransactionUpdateIndex.Enabled = (Not gbClosed) And ReturnPermission("D02F1050") > EnumPermission.View
        ''Thay doi ngay 21/11/2012 theo incident 52390 của bảo Trân bởi Văn Vinh
        'mnuTransactionDepreciation.Enabled = (Not gbClosed) And ReturnPermission("D02F5002") > EnumPermission.View
        'mnuTransactionAssetTransactionVoucher.Enabled = (Not gbClosed) And ReturnPermission("D02F2002") > EnumPermission.View
        '' update 3/7/2013 id 57421
        'mnuTransactionConvert.Enabled = (Not gbClosed) And ReturnPermission("D02F2002") > EnumPermission.View
        'mnuTransationChangeSource.Enabled = (Not gbClosed) And ReturnPermission("D02F2006") > EnumPermission.View
        'mnuTransactionCollectCost.Enabled = (Not gbClosed) And ReturnPermission("D02F1003") > EnumPermission.View
        'mnuTransactionBalanceCIP.Enabled = (Not gbClosed) And ReturnPermission("D02F2015") > EnumPermission.View
        'mnuTransactionInputVoucher.Enabled = (Not gbClosed) And ReturnPermission("D02F2005") > EnumPermission.View
        'mnuTransactionCostSplitVoucher.Enabled = (Not gbClosed) And ReturnPermission("D02F3002") > EnumPermission.View


        VisibledMenu(mnuSystemModifyAutoVoucherNumber, ReturnPermission("D02F5702") > EnumPermission.View)
        VisibledMenu(mnuLockedVoucher, ReturnPermission("D02F5557") >= EnumPermission.View)
        'Phân quyền cho menu Nghiệp vụ phụ thuộc vào biến gbClosed
        VisibledMenu(mnuTransactionCIPBalanceEnter, ReturnPermission("D02F1007") > EnumPermission.View)
        'Modify 20/12/2013 - ID 62126
        VisibledMenu(mnuTransactionInputRemainder, ReturnPermission("D02F1002") > EnumPermission.View)
        VisibledMenu(mnuTransactionSetupAssetAuto, ReturnPermission("D02F1002") > EnumPermission.View)
        '**************
        VisibledMenu(mnuTransactionSetupAssetPurchasing, ReturnPermission("D02F0300") > EnumPermission.View)
        VisibledMenu(mnuTransactionSetupAssetFromCIP, ReturnPermission("D02F0300") > EnumPermission.View)
        VisibledMenu(mnuTransactionUpdateIndex, ReturnPermission("D02F1050") > EnumPermission.View)
        'Thay doi ngay 21/11/2012 theo incident 52390 của bảo Trân bởi Văn Vinh
        VisibledMenu(mnuTransactionDepreciation, ReturnPermission("D02F5002") > EnumPermission.View)
        VisibledMenu(mnuTransactionAssetTransactionVoucher, ReturnPermission("D02F2002") > EnumPermission.View)
        VisibledMenu(mnuTransactionAssetTransferDivision, D02Systems.AllowChangeDivision And ReturnPermission("D02F2016") > EnumPermission.View)
        ' update 3/7/2013 id 57421
        VisibledMenu(mnuTransactionConvert, ReturnPermission("D02F2002") > EnumPermission.View)
        VisibledMenu(mnuTransationChangeSource, ReturnPermission("D02F2006") > EnumPermission.View)
        VisibledMenu(mnuTransactionCollectCost, ReturnPermission("D02F1003") > EnumPermission.View)
        VisibledMenu(mnuTransactionBalanceCIP, ReturnPermission("D02F2015") > EnumPermission.View)
        VisibledMenu(mnuTransactionInputVoucher, ReturnPermission("D02F2005") > EnumPermission.View)
        VisibledMenu(mnuTransactionCostSplitVoucher, ReturnPermission("D02F3002") > EnumPermission.View)
        VisibledMenu(mnuTransactionAssetActual, ReturnPermission("D02F2060") >= EnumPermission.View)
        VisibledMenu(mnuTransactionSetupAssetPurchasingDD, ReturnPermission("D02F0300") > EnumPermission.View)

    End Sub

    ' Sáng/Mờ theo khóa sổ
    Private Sub SetEnableMenuPermissionTransaction()
        mnuSystemCloseBook.Enabled = Not gbClosed AndAlso (Not gbOpeningSpecial)
        mnuSystemOpenBook.Enabled = gbClosed AndAlso (Not gbOpeningSpecial)
        mnuSystemNewPeriod.Enabled = True
        mnuSystemModifyAutoVoucherNumber.Enabled = Not gbClosed
        mnuLockedVoucher.Enabled = Not gbClosed
        'Phân quyền cho menu Nghiệp vụ phụ thuộc vào biến gbClosed
        'Start - Kiểm tra kì đầu tiên
        'Modify 20/12/2013 - ID 62126
        mnuTransactionCIPBalanceEnter.Enabled = Not gbClosed And (giFirstTranMonth = giTranMonth) And (giFirstTranYear = giTranYear)
        mnuTransactionInputRemainder.Enabled = Not gbClosed And (giFirstTranMonth = giTranMonth) And (giFirstTranYear = giTranYear)
        mnuTransactionSetupAssetAuto.Enabled = Not gbClosed And (giFirstTranMonth = giTranMonth) And (giFirstTranYear = giTranYear)
        'End - Kiểm tra kì đầu tiên

        mnuTransactionSetupAssetPurchasing.Enabled = Not gbClosed
        mnuTransactionSetupAssetFromCIP.Enabled = Not gbClosed
        mnuTransactionUpdateIndex.Enabled = Not gbClosed
        'Thay doi ngay 21/11/2012 theo incident 52390 của bảo Trân bởi Văn Vinh
        mnuTransactionDepreciation.Enabled = Not gbClosed
        mnuTransactionAssetTransactionVoucher.Enabled = Not gbClosed
        mnuTransactionAssetTransferDivision.Enabled = Not gbClosed
        ' update 3/7/2013 id 57421
        mnuTransactionConvert.Enabled = Not gbClosed
        mnuTransationChangeSource.Enabled = Not gbClosed
        mnuTransactionCollectCost.Enabled = Not gbClosed
        mnuTransactionBalanceCIP.Enabled = Not gbClosed
        mnuTransactionInputVoucher.Enabled = Not gbClosed
        mnuTransactionCostSplitVoucher.Enabled = Not gbClosed
        'mnuTransactionAssetActual.Enabled = Not gbClosed'17/7/2017, Phạm Thị Thu: id 99923-Lỗi khi khóa sổ không thực hiện được nghiệp vụ truy vấn D02
        mnuTransactionSetupAssetPurchasingDD.Enabled = Not gbClosed
    End Sub

#Region "Menu Hệ thống"

    Private Sub mnuSystemSetup_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemSetup.Click
        'Dim f As New D02F0001
        'f.FormState = EnumFormState.FormEdit
        'f.ShowDialog()
        'f.Dispose()
        'Incident 	71021
        'Dim arrPro() As StructureProperties = Nothing
        'SetProperties(arrPro, "FormState", EnumFormState.FormEdit)
        CallFormShowDialog("D02D0940", "D02F0001")

    End Sub

    Private Sub mnuSystemIndexSetup_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemIndexSetup.Click
        'Dim f As New D02F9001
        'f.ShowDialog()
        'f.Dispose()

        'Incident 	71021
        CallFormShowDialog("D02D0940", "D02F9001")
    End Sub

    Private Sub mnuSystemSetupInfo_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemSetupInfo.Click
        'Dim f As New D02F1910
        'f.ShowDialog()
        'f.Dispose()
        'Incident 	71021
        CallFormShowDialog("D02D0940", "D02F1910")
    End Sub

    Private Sub mnuSystemModifyAutoVoucherNumber_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemModifyAutoVoucherNumber.Click
        'Dim exe As New D91E0640(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'With exe
        '    .FormActive = D91E0640Form.D91F5559
        '    .FormPermission = "D02F5702"
        '    .ModuleID = "02"
        '    .Run()
        'End With

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F5702")
        SetProperties(arrPro, "ModuleID", "02")
        CallFormShowDialog("D91D0640", "D91F5559", arrPro)

    End Sub

    Private Sub mnuSystemCloseBook_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemCloseBook.Click
        If Not AllowCloseBook() Then Exit Sub
        Dim f As New D02F5554
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'SetMenuPermissionTransaction()
            SetEnableMenuPermissionTransaction()
        End If
        f.Dispose()
    End Sub

    Private Function AllowCloseBook() As Boolean
        If ReturnPermission("D02F5554") <= EnumPermission.View Then
            D99C0008.MsgNoPermissionCloseBook()
            Return False
        End If
        Return True
    End Function

    Private Sub mnuSystemNewPeriod_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemNewPeriod.Click
        'If Not AllowNewPeriod() Then Exit Sub
        'Dim f As New D02F5556
        'f.ShowDialog()
        'f.Dispose()

        'ID 88919 16.09.2016  
        Lemon3.D99Finance.CallFormD91F5556("02")
    End Sub

    'Private Function AllowNewPeriod() As Boolean
    '    If ReturnPermission("D02F5556") <= EnumPermission.View Then
    '        D99C0008.MsgNoPermissionNewPeriod()
    '        Return False
    '    End If
    '    Return True
    'End Function

    Private Sub mnuSystemOpenBook_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemOpenBook.Click
        If Not AllowOpenBook() Then Exit Sub
        Dim f As New D02F5555
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'SetMenuPermissionTransaction()
            SetEnableMenuPermissionTransaction()
        End If

        f.Dispose()
    End Sub

    Private Function AllowOpenBook() As Boolean
        If ReturnPermission("D02F5555") <= EnumPermission.View Then
            D99C0008.MsgNoPermissionOpenBook()
            Return False
        End If
        Return True
    End Function

    'Hệ thống -> Tnh trạng khóa sổ
    Private Sub mnuSystemStatusCloseBook_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemStatusCloseBook.Click
        'Dim exe As New D90E0140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D90E0140Form.D90F5553
        'exe.FormPermission = "D90F5553"
        'exe.ModuleID = "D02"
        'exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", D02)
        SetProperties(arrPro, "FormIDPermission", "D90F5553")
        CallFormThread(Me, "D90D0140", "D90F5553", arrPro)
    End Sub

    Private Sub mnuSystemOption_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemOption.Click
        'Dim f As New D02F0002
        'f.ShowDialog()
        'f.Dispose()
        'Incident 	71021
        CallFormShowDialog("D02D0940", "D02F0002")
    End Sub

    Private Sub mnuSystemLanguageVietnamese_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemLanguageVietnamese.Click
        geLanguage = EnumLanguage.Vietnamese
        gsLanguage = "84"
        D99C0008.Language = geLanguage
        MsgAnnouncement = "Th¤ng bÀo"
        LoadLanguage()
    End Sub

    Private Sub mnuSystemLanguageEnglish_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemLanguageEnglish.Click
        geLanguage = EnumLanguage.English
        gsLanguage = "01"
        D99C0008.Language = geLanguage
        MsgAnnouncement = "Announcement"
        LoadLanguage()
    End Sub

    Private Sub mnuSystemQuit_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemQuit.Click
        End
    End Sub

#End Region

#Region "Menu Nghiệp vụ"

    'NV -> Hình thành TSCĐ -> Từ mua sắm
    Private Sub mnuTransactionSetupAssetPurchasing_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionSetupAssetPurchasing.Click
        'Dim f As New D02M2240
        'f.FormActive = "D02F1001"
        'f.ShowDialog()
        'f.Dispose()

        Lemon3.CallDxxExx40("D02E2240", "D02F1001", "D02F1001", Nothing, Nothing)
    End Sub

    'NV -> Hình thành TSCĐ -> Từ XDCB
    Private Sub mnuTransactionSetupAssetFromCIP_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionSetupAssetFromCIP.Click
        'Dim f As New D02M2240
        'f.FormActive = "D02F1010"
        'f.ShowDialog()
        'f.Dispose()

        Lemon3.CallDxxExx40("D02E2240", "D02F1010", "D02F1010", Nothing, Nothing)
    End Sub

    'NV -> Hình thành TSCĐ -> Từ điều động vốn
    Private Sub mnuTransactionSetupAssetPurchasingDD_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionSetupAssetPurchasingDD.Click
        'Dim f As New D02M2240
        'f.FormActive = "D02F1009"
        'f.ShowDialog()
        'f.Dispose()

        Lemon3.CallDxxExx40("D02E2240", "D02F1009", "D02F1009", Nothing, Nothing)
    End Sub

    'NV -> Nhập số dư -> Nhập số dư TSCĐ
    Private Sub mnuTransactionInputRemainder_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionInputRemainder.Click
        'Dim exe As New D02E2240_Old(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E2240Form.D02F1002
        'exe.FormPermission = "D02F0300"
        'exe.In_ModuleName = "D02"
        'exe.StatusForm = "0"
        'exe.Run()

        'Dim f As New D02M2240
        'f.FormActive = "D02F1002"
        'f.ShowDialog()
        'f.Dispose()

        Lemon3.CallDxxExx40("D02E2240", "D02F1002", "D02F1002", Nothing, Nothing)
    End Sub

    'NV -> Nhập số dư -> Tạo tự động số dư TSCĐ
    Private Sub mnuTransactionSetupAssetAuto_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionSetupAssetAuto.Click
        'Dim exe As New D02E2240_Old(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E2240Form.D02F2100
        'exe.FormPermission = "D02F2100"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        'Dim f As New D02M2240
        'f.FormActive = "D02F2100"
        'f.ShowDialog()
        'f.Dispose()

        Lemon3.CallDxxExx40("D02E2240", "D02F2100", "D02F2100", Nothing, Nothing)
    End Sub

    'NV -> Tính khấu hao
    Private Sub mnuTransactionDepreciation_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionDepreciation.Click
        'Dim exe As New D02E2140_Old(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E2140Form.D02F5002
        'exe.FormPermission = "D21F5002"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        'Dim f As New D02M2140
        'f.FormActive = "D02F5002"
        'f.FormPermission = "D02F5002"
        'f.ShowDialog()
        'f.Dispose()

        Lemon3.CallDxxExx40("D02E2140", "D02F5002", "D02F5002", Nothing, Nothing)
    End Sub

    'NV -> Nghiệp vụ tác động
    Private Sub mnuTransactionAssetTransactionVoucher_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionAssetTransactionVoucher.Click
        'Dim exe As New D02E2040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E2040Form.D02F2003
        'exe.FormPermission = "D02F2002"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        Dim sField() As String = {"ID01"}
        Dim sValue() As String = {"D02"}
        Lemon3.CallDxxExx40("D02E2040", "D02F2003", "D02F2002", sField, sValue)
    End Sub

    'Nghiệp vụ -> Điều chuyển TSCĐ theo đơn vị
    Private Sub mnuTransactionAssetTransferDivision_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionAssetTransferDivision.Click
        '28/3/2017, Trần Hoàng Anh: id 75367-Bổ sung tính năng điều chuyển đơn vị TSCĐ
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F2016")
        CallFormThread(Me, "D02D2040", "D02F2017", arrPro)
    End Sub

    'Nghiệp vụ -> Chuyển đổi TSCĐ
    Private Sub mnuTransactionConvert_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionConvert.Click
        'Dim exe As New DxxExx40("D02E2340", gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'With exe
        '    .FormActive = "D02F2040" 'Form cần hiển thị
        '    .FormPermission = "D02F2002" 'Mã màn hình phân quyền
        '    .Run()
        'End With

        Lemon3.CallDxxExx40("D02E2340", "D02F2040", "D02F2002", Nothing, Nothing)
    End Sub

    'NV -> Chuyển nguồn vốn
    Private Sub mnuTransationChangeSource_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransationChangeSource.Click
        'Dim exe As New D02E2040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E2040Form.D02F2006
        'exe.FormPermission = "D02F2006"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        'Dim f As New D02M2140
        'f.FormActive = "D02F2006"
        'f.ShowDialog()
        'f.Dispose()

        Lemon3.CallDxxExx40("D02E2140", "D02F2006", "D02F2006", Nothing, Nothing)
    End Sub

    'NV -> Tập hợp chi phí XDCB
    Private Sub mnuTransactionCollectCost_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionCollectCost.Click
        'Dim exe As New D02E2140_Old(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E2140Form.D02F1003
        'exe.FormPermission = "D02F1003"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        'Dim f As New D02M2140
        'f.FormActive = "D02F1003"
        'f.FormPermission = "D02F1003"
        'f.ShowDialog()
        'f.Dispose()

        Lemon3.CallDxxExx40("D02E2140", "D02F1003", "D02F1003", Nothing, Nothing)
    End Sub

    'NV -> Nhập số dư XDCB
    Private Sub mnuTransactionCIPBalanceEnter_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionCIPBalanceEnter.Click
        'Dim exe As New D02E2140_Old(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E2140Form.D02F1007
        'exe.FormPermission = "D02F1007"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        'Dim f As New D02M2140
        'f.FormActive = "D02F1007"
        'f.FormPermission = "D02F1007"
        'f.ShowDialog()
        'f.Dispose()

        Lemon3.CallDxxExx40("D02E2140", "D02F1007", "D02F1007", Nothing, Nothing)
    End Sub

    'NV -> Quyết toán XDCB
    Private Sub mnuTransactionBalanceCIP_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionBalanceCIP.Click
        'Dim exe As New D02E2040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E2040Form.D02F2011
        'exe.FormPermission = "D02F2015"
        'exe.In_ModuleName = "D02"
        'exe.StatusForm = "0"
        'exe.Run()

        Dim sField() As String = {"ID01", "Status"}
        Dim sValue() As String = {"D02", "0"}
        Lemon3.CallDxxExx40("D02E2040", "D02F2011", "D02F2015", sField, sValue)
    End Sub

    'NV -> Nhập chứng từ
    Private Sub mnuTransactionInputVoucher_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionInputVoucher.Click
        'Dim exe As New D02E2040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E2040Form.D02F2004
        'exe.FormPermission = "D02F2005"
        'exe.In_ModuleName = "D02"
        'exe.StatusForm = "0"
        'exe.Run()

        Dim sField() As String = {"ID01", "Status"}
        Dim sValue() As String = {"D02", "0"}
        Lemon3.CallDxxExx40("D02E2040", "D02F2004", "D02F2005", sField, sValue)
    End Sub

    'NV -> Tách chi phí
    Private Sub mnuTransactionCostSplitVoucher_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionCostSplitVoucher.Click
        'Dim f As New D02M2140
        'f.FormActive = "D02F3002"
        'f.FormPermission = "D02F3002"
        'f.ShowDialog()
        'f.Dispose()

        Lemon3.CallDxxExx40("D02E2140", "D02F3002", "D02F3002", Nothing, Nothing)
    End Sub

    'NV -> Cập nhật chỉ số
    Private Sub mnuTransactionUpdateIndex_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionUpdateIndex.Click
        'Dim exe As New D02E2140_Old(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E2140Form.D02F1050
        'exe.FormPermission = "D02F1050"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        'Dim f As New D02M2140
        'f.FormActive = "D02F1050"
        'f.FormPermission = "D02F1050"
        'f.ShowDialog()
        'f.Dispose()

        Lemon3.CallDxxExx40("D02E2140", "D02F1050", "D02F1050", Nothing, Nothing)
    End Sub

    'NV -> Kiểm kê tài sản
    Private Sub mnuTransactionAssetActual_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionAssetActual.Click
        'Dim exe As New DxxExx40("D02E2240", gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'With exe
        '    .FormActive = "D02F2060" 'Form cần hiển thị
        '    .FormPermission = "D02F2060" 'Mã màn hình phân quyền
        '    .Run()
        'End With

        Lemon3.CallDxxExx40("D02E2240", "D02F2060", "D02F2060", Nothing, Nothing)
    End Sub

#End Region

#Region "Menu Truy vấn"

    'TV -> Hình thành tài sản
    Private Sub mnuInquiryFormedAsset_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryFormedAsset.Click
        'D02F0333
        'Dim f As New D02M2240
        'f.FormActive = "D02F0300"
        'f.FormPermission = "D02F0300"
        'f.ShowDialog()
        'f.Dispose()

        Lemon3.CallDxxExx40("D02E2240", "D02F0300", "D02F0300", Nothing, Nothing)
    End Sub

    'TV -> Nghiệp vụ tác động
    Private Sub mnuInquiryAssetTransactionVoucher_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryAssetTransactionVoucher.Click
        'Dim exe As New D02E2040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E2040Form.D02F2002
        'exe.FormPermission = "D02F2002"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        Dim sField() As String = {"ID01"}
        Dim sValue() As String = {"D02"}
        Lemon3.CallDxxExx40("D02E2040", "D02F2002", "D02F2002", sField, sValue)
    End Sub

    'Truy vấn -> Điều chuyển TSCĐ theo đơn vị
    Private Sub mnuInquiryAssetTransferDivision_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryAssetTransferDivision.Click
        '28/3/2017, Trần Hoàng Anh: id 75367-Bổ sung tính năng điều chuyển đơn vị TSCĐ
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F2016")
        CallFormThread(Me, "D02D2040", "D02F2016", arrPro)
    End Sub

    'TV -> Chứng từ
    Private Sub mnuInquiryVoucher_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryVoucher.Click
        'Dim exe As New D02E2040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E2040Form.D02F2005
        'exe.FormPermission = "D02F2005"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        Dim sField() As String = {"ID01"}
        Dim sValue() As String = {"D02"}
        Lemon3.CallDxxExx40("D02E2040", "D02F2005", "D02F2005", sField, sValue)
    End Sub

    'TV -> Truy vấn Bút toán phân bổ khấu hao
    Private Sub mnuInquiryDepreciationAllocationVoucher_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryDepreciationAllocationVoucher.Click
        'Dim exe As New D02E2040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E2040Form.D02F0501
        'exe.FormPermission = "D02F0501"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        Dim sField() As String = {"ID01"}
        Dim sValue() As String = {"D02"}
        Lemon3.CallDxxExx40("D02E2040", "D02F0501", "D02F0501", sField, sValue)
    End Sub

    'TV -> Quyết toán XDCB
    Private Sub mnuInquiryBalanceCip_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryBalanceCip.Click
        'Dim exe As New D02E2040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E2040Form.D02F2015
        'exe.FormPermission = "D02F2015"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        Dim sField() As String = {"ID01"}
        Dim sValue() As String = {"D02"}
        Lemon3.CallDxxExx40("D02E2040", "D02F2015", "D02F2015", sField, sValue)
    End Sub

#End Region

#Region "Menu thống kê và phân tích"

    'TK & PT -> Truy vấn tài sản
    Private Sub mnuStatisAsset_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatisAsset.Click
        'Dim exe As New D02E4040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E4040Form.D02F0600
        'exe.FormPermission = "D02F0600"
        'exe.In_ModuleName = "D02"
        'exe.Run()
        CallFormShow("D02D4040", "D02F0600")
    End Sub

    'TK & PT -> Truy vấn tổng hợp XDCB
    Private Sub mnuStatisCIPCostBalance_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatisCIPCostBalance.Click

        'Dim exe As New D02E4040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E4040Form.D02F3100
        'exe.FormPermission = "D02F3100"
        'exe.In_ModuleName = "D02"
        'exe.Run()
        CallFormShow("D02D4040", "D02F3100")
    End Sub

    'TK & PT -> Truy vấn tổng hợp TSCĐ
    Private Sub mnuStatisCostBalanceFixAsset_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatisCostBalanceFixAsset.Click
        'Dim exe As New D02E4040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E4040Form.D02F2030
        'exe.FormPermission = "D02F2030"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        CallFormShow("D02D4040", "D02F2030")
    End Sub

    'TK & PT -> Tình hình TSCĐ và XDCB
    Private Sub mnuStatisFixedAssetsAndCIPs_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatisFixedAssetsAndCIPs.Click
        'Dim exe As New D02E4040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E4040Form.D02F2020
        'exe.FormPermission = "D02F2020"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        CallFormShow("D02D4040", "D02F2020")
    End Sub

    'TK & PT -> Tổng kết khấu hao TSCĐ
    Private Sub mnuStaticAssetsDepreciation_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStaticAssetsDepreciation.Click
        'RunEXEDxxExx40("D02E4040", "D02F3060")
        CallFormShow("D02D4040", "D02F3060")
    End Sub

    'TK & PT -> Thuyết minh tăng giảm tài sản
    Private Sub mnuInquiry_AssetRiseReduce_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiry_AssetRiseReduce.Click
        CallFormShow("D02D2040", "D02F3070")
    End Sub
#End Region

#Region "Menu Báo cáo"


    'BC -> Phiếu nhập TSCĐ
    Private Sub mnuReportInputFixAsset_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportInputFixAsset.Click
        'Dim exe As New D02E5040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E5040Form.D02F3011
        'exe.FormPermission = "D02F3011"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        CallFormShow("D02D5040", "D02F3011")
    End Sub

    'BC -> Thẻ TSCĐ
    Private Sub mnuReportCardtFixAsset_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportCardtFixAsset.Click
        'Dim exe As New D02E5040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E5040Form.D02F3010
        'exe.FormPermission = "D02F3010"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        CallFormShow("D02D5040", "D02F3010")
    End Sub

    'BC -> Sổ chi tiết TSCĐ
    Private Sub mnuReportDetailFixAsset_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportDetailFixAsset.Click
        'Dim exe As New D02E5040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E5040Form.D02F3200
        'exe.FormPermission = "D02F3200"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        CallFormShow("D02D5040", "D02F3200")
    End Sub

    'BC -> Danh sách TSCĐ
    Private Sub mnuReportListFixAsset_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportListFixAsset.Click
        'Dim exe As New D02E5040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E5040Form.D02F3020
        'exe.FormPermission = "D02F3020"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        CallFormShow("D02D5040", "D02F3020")
    End Sub

    'BC -> Báo cáo tăng giảm TSCĐ
    Private Sub mnuReportIn_DecreaseFixAsset_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportIn_DecreaseFixAsset.Click
        'Dim exe As New D02E5140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E5140Form.D02F3012
        'exe.FormPermission = "D02F3012"
        'exe.In_ModuleName = "D02"
        'exe.Run()
        CallFormShow("D02D5140", "D02F3012")
    End Sub

    'BC -> Báo cáo nhập xuất tồn TSCĐ
    Private Sub mnuReportAssetBalance_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportAssetBalance.Click
        'Dim exe As New D02E5140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E5140Form.D02F4100
        'exe.FormPermission = "D02F4100"
        'exe.In_ModuleName = "D02"
        'exe.Run()
        CallFormShow("D02D5140", "D02F4100")
    End Sub

    'BC -> Tài sản di chuyển nội bộ
    Private Sub mnuReportMovingFixAsset_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportMovingFixAsset.Click
        'Dim exe As New D02E5140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E5140Form.D02F3040
        'exe.FormPermission = "D02F3040"
        'exe.In_ModuleName = "D02"
        'exe.Run()
        CallFormShow("D02D5140", "D02F3040")
    End Sub

    'BC -> Thiết bị đính kèm tài sản
    Private Sub mnuReportEquipmentAttachAsset_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportEquipmentAttachAsset.Click
        'Dim exe As New D02E5140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E5140Form.D02F3050
        'exe.FormPermission = "D02F3050"
        'exe.In_ModuleName = "D02"
        'exe.Run()
        CallFormShow("D02D5140", "D02F3050")
    End Sub

    'BC -> Khấu hao TSCĐ theo kỳ
    Private Sub mnuReportDepInPeriod_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportDepInPeriod.Click
        'Dim exe As New D02E5240(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E5240Form.D02F3021
        'exe.FormPermission = "D02F3021"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        CallFormShow("D02D5240", "D02F3021")
    End Sub

    'BC -> Báo cáo phân bổ khấu hao
    Private Sub mnuReportDistributeDep_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportDistributeDep.Click
        'Dim exe As New D02E5240(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E5240Form.D02F3030
        'exe.FormPermission = "D02F3030"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        CallFormShow("D02D5240", "D02F3030")
    End Sub

    'BC -> Tổng kết khấu hao TSCĐ
    Private Sub mnuReportEndDepFixAsset_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportEndDepFixAsset.Click
        'Dim exe As New D02E5240(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E5240Form.D02F3025
        'exe.FormPermission = "D02F3025"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        CallFormShow("D02D5240", "D02F3025")
    End Sub

    'BC -> Báo cáo lịch sử tác động
    Private Sub mnuReportEffectHistory_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportEffectHistory.Click
        'Dim exe As New D02E5240(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E5240Form.D02F3300
        'exe.FormPermission = "D02F3300"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        CallFormShow("D02D5240", "D02F3300")
    End Sub

    'BC -> Báo cáo chi phí XDCB
    Private Sub mnuReportCost_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportCost.Click
        'Dim exe As New D02E5340(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E5340Form.D02F5005
        'exe.FormPermission = "D02F5005"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        CallFormShow("D02D5340", "D02F5005")
    End Sub

    
    'BC -> Báo cáo nghiệp vụ tác động
    Private Sub mnuReportEffectTrans_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportEffectTrans.Click
        'Dim exe As New D02E5340(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E5340Form.D02F6005
        'exe.FormPermission = "D02F6005"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        CallFormShow("D02D5340", "D02F6005")
    End Sub

    'BC -> Báo cáo phân tích TSCĐ
    Private Sub mnuReportAnalyseFixAsset_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportAnalyseFixAsset.Click
        'Dim exe As New D02E5340(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E5340Form.D02F7005
        'exe.FormPermission = "D02F7005"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        CallFormShow("D02D5340", "D02F7005")
    End Sub

    'BC -> Báo cáo đặc thù
    Private Sub mnuReportCustomise_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportCustomise.Click
        'Dim exe As New D89E0140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D89E0140Form.D89F9100
        'exe.FormPermission = "D02F9100"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", "D02")
        CallFormShow("D89D0140", "D89F9100", arrPro)
    End Sub

    'BC -> Thiết lập -> Báo cáo chi phí XDCB dở dang
    Private Sub mnuReportCipCost_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportCipCost.Click
        'Dim exe As New D02E6040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E6040Form.D02F5003
        'exe.FormPermission = "D02F5003"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        CallFormShow("D02D6040", "D02F5003")
    End Sub

    'BC -> Thiết lập -> Báo cáo nghiệp vụ tác động
    Private Sub mnuReportSetupEffectTrans_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportSetupEffectTrans.Click
        'Dim exe As New D02E6040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E6040Form.D02F6003
        'exe.FormPermission = "D02F6003"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        CallFormShow("D02D6040", "D02F6003")
    End Sub

    'BC -> Thiết lập -> Báo cáo phân tích TSCĐ
    Private Sub mnuReportSetupAnaFixAsset_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportSetupAnaFixAsset.Click
        'Dim exe As New D02E6040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E6040Form.D02F7003
        'exe.FormPermission = "D02F7003"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        CallFormShow("D02D6040", "D02F7003")
    End Sub

    'BC -> Thiết lập -> Mẫu báo cáo
    Private Sub mnuReportForm_Click1(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportForm.Click
        'Dim exe As New D89E0240(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D89E0240Form.D89F9101
        'exe.FormPermission = "D02F9101"
        'exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", "02")
        SetProperties(arrPro, "FormIDPermission", "D02F9101")
        CallFormShow("D89D0240", "D89F9101", arrPro)
    End Sub

#End Region

#Region "Menu Danh mục"

    'DM -> Tài sản
    Private Sub mnuListAsset_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAsset.Click
        'Dim exe As New D02E1040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E1040Form.D02F1030
        'exe.FormPermission = "D02F1030"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F1030")
        CallFormShow("D02D1040", "D02F1030", arrPro)
    End Sub

    'DM -> Mã loại phân tích tài sản
    Private Sub mnuListAssetAnalysisTypeCode_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAssetAnalysisTypeCode.Click
        'Dim exe As New D02E1040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E1040Form.D02F0040
        'exe.FormPermission = "D02F0040"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F0040")
        CallFormShow("D02D1040", "D02F0040", arrPro)
    End Sub

    'DM -> Mã phân tích tài sản
    Private Sub mnuListAssetAnalyseCode_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAssetAnalyseCode.Click
        'Dim exe As New D02E1040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E1040Form.D02F0041
        'exe.FormPermission = "D02F0041"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F0041")
        CallFormShow("D02D1040", "D02F0041", arrPro)
    End Sub

    'DM -> Mã XDCB
    Private Sub mnuListCipCode_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListCipCode.Click
        'Dim exe As New D02E1140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E1140Form.D02F2000
        'exe.FormPermission = "D02F2000"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F2000")
        CallFormShow("D02D1140", "D02F2000", arrPro)
    End Sub

    'DM -> Mã loại phân tích XDCB
    Private Sub mnuListCipAnalyseTypeCode_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListCipAnalyseTypeCode.Click
        'Dim exe As New D02E1140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E1140Form.D02F0050
        'exe.FormPermission = "D02F0050"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F0050")
        CallFormShow("D02D1140", "D02F0050", arrPro)
    End Sub

    'DM -> Mã phân tích XDCB
    Private Sub mnuListCipAnalyseCode_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListCipAnalyseCode.Click
        'Dim exe As New D02E1140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E1140Form.D02F0051
        'exe.FormPermission = "D02F0051"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F0051")
        CallFormShow("D02D1140", "D02F0051", arrPro)
    End Sub

    'DM -> Phân loại
    Private Sub mnuListClassification_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListClassification.Click
        'Dim exe As New D02E1240(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E1240Form.D02F3000
        'exe.FormPermission = "D02F3000"
        ''exe.In_ModuleName = "D02"
        'exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F3000")
        CallFormShow("D02D1240", "D02F3000", arrPro)
    End Sub

    'DM -> Nguồn hình thành
    Private Sub mnuListSource_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListSource.Click
        'Dim exe As New D02E1240(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E1240Form.D02F0200
        'exe.FormPermission = "D02F0200"
        ''exe.In_ModuleName = "D02"
        'exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F0200")
        CallFormShow("D02D1240", "D02F0200", arrPro)
    End Sub

    'DM -> Tiêu thức phân bổ
    Private Sub mnuListAssignment_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAssignment.Click
        'Dim exe As New D02E1240(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E1240Form.D02F0100
        'exe.FormPermission = "D02F0100"
        ''exe.In_ModuleName = "D02"
        'exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F0100")
        CallFormShow("D02D1240", "D02F0100", arrPro)
    End Sub

    'DM -> Bộ định mức
    Private Sub mnuListNorm_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListNorm.Click
        'Dim exe As New D02E1340(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E1340Form.D02F0054
        'exe.FormPermission = "D02F0054"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F0054")
        CallFormShow("D02D1340", "D02F0054", arrPro)
    End Sub

    'DM -> Bảng khấu hao
    Private Sub mnuListDepreciationTable_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListDepreciationTable.Click
        'D02F0020
        'Dim exe As New D02E1340(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E1340Form.D02F0020
        'exe.FormPermission = "D02F0020"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F0020")
        CallFormShow("D02D1340", "D02F0020", arrPro)
    End Sub

    'DM -> Phương pháp tách chi phí
    Private Sub mnuListSplitMethod_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListSplitMethod.Click
        'Dim exe As New D02E1340(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E1340Form.D02F1041
        'exe.FormPermission = "D02F1041"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F1041")
        CallFormShow("D02D1340", "D02F1041", arrPro)
    End Sub

    'DM -> Nghiệp vụ tác động
    Private Sub mnuListChange_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListChange.Click
        'Dim exe As New D02E1440(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D02E1440Form.D02F1021
        'exe.FormPermission = "D02F1021"
        'exe.In_ModuleName = "D02"
        'exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F1021")
        CallFormShow("D02D1440", "D02F1021", arrPro)
    End Sub

    'DM -> Lý do tác động
    Private Sub mnuListReason_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListReason.Click
        'Dim frm As New D91F0310
        'With frm
        '    .FormName = "D91F0310"  'Form kích hoạt
        '    .FormPermission = "D02F1150" 'Màn hình phân quyền Theo TL
        '    .LookupType = "D02_EffectReason" ' Theo TL phân tích quy định
        '    .FormText = rL3("Danh_muc_ly_do_tac_dong")  'Theo TL Caption MH hiển thị
        '    .FormSubText = rL3("Cap_nhat_ly_do_tac_dong") 'Theo TL Caption MH cập nhật
        '    .ShowDialog()
        '    .Dispose()
        'End With

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F1150")
        SetProperties(arrPro, "FormName", "D91F0310")
        SetProperties(arrPro, "LookupType", "D02_EffectReason")
        SetProperties(arrPro, "FormText", "Danh_muc_ly_do_tac_dong")
        CallFormShow("D91D0140", "D91F0310", arrPro)
    End Sub
    
    'DM -> Vị trí
    'Incident 68272 - 2014-08-07
    Private Sub mnuListPosition_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListPosition.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F0700")
        SetProperties(arrPro, "FormName", "D02F0700")
        SetProperties(arrPro, "TransTypeID", "D02F0700")
        SetProperties(arrPro, "ModuleID", "D02")
        SetProperties(arrPro, "LookupType", "D02_Position")
        SetProperties(arrPro, "FormText", "Danh_muc_vi_tri_cho_doi_tuong_tai_san_co_dinh")
        CallFormShow("D91D0140", "D91F0310", arrPro)
    End Sub

    'DM -> Tình trạng
    Private Sub mnuListStatus_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListStatus.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F0800")
        SetProperties(arrPro, "FormName", "D02F0800")
        SetProperties(arrPro, "LookupType", "D02_AssetConditionID")
        SetProperties(arrPro, "FormText", "Danh_muc_tinh_trang")
        CallFormShow("D91D0140", "D91F0310", arrPro)
    End Sub
#End Region

    Private Sub mnuPeriod_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPeriod.Click
        gbEndModule = False
        Dim f As New D02F0003
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
            mnuPeriod.Text = MakeMenuPeriod()
            GetFirstPeriod(gsDivisionID)
            'SetMenuPermissionTransaction()
            SetEnableMenuPermissionTransaction()
        End If
        f.Dispose()
    End Sub

    Private Sub ShowFormSystemsIfNeed()
        Dim sSQL As String = "Select Top 1 1 From D02T0000 WITH(NOLOCK) "
        If Not ExistRecord(sSQL) Then 'Chưa có dữ liệu ở bảng T0000, hiện thị form Thiết lập hệ thống
            OpenFormSystem()
            If Not ExistRecord(sSQL) Then End
        Else 'Đã có dữ liệu ở bảng T0000
            If D02Options.DefaultDivisionID = "" Then 'Chưa có đơn vị dưới Registry
                gsDivisionID = D02Systems.DefaultDivisionID
                'Kiểm tra lại có tồn tại đơn vị này không
                If Not CheckExistDivision() Then 'Không Có dữ liệu trong bảng T9999 và D91T0016
                    OpenFormSystem()
                End If

            Else 'Đã có dưới Registry rồi
                gsDivisionID = D02Options.DefaultDivisionID

                'Kiểm tra lại có tồn tại đơn vị này không
                If Not CheckExistDivision() Then 'Không Có dữ liệu trong bảng T9999 và D91T0016
                    gsDivisionID = D02Systems.DefaultDivisionID
                    If Not CheckExistDivision() Then 'Không Có dữ liệu trong bảng T9999 và D91T0016
                        OpenFormSystem()
                    End If
                End If
            End If
        End If

        GetMonthYear()

    End Sub

    Private Sub OpenFormSystem()
        'Dim f As New D02F0001
        'f.FormState = EnumFormState.FormAdd
        'f.ShowDialog()
        'f.Dispose()
        'Incident 	71021
        'Dim arrPro() As StructureProperties = Nothing
        'SetProperties(arrPro, "FormState", EnumFormState.FormAdd)
        CallFormShowDialog("D02D0940", "D02F0001")
        'Lấy đơn vị và kỳ kế tóan
        gsDivisionID = D02Systems.DefaultDivisionID
    End Sub
    Private Function CheckExistDivision(Optional ByVal bNoMessage As Boolean = False) As Boolean
        Dim sSQL As String
        sSQL = SQLStoreD91P9020("02") 'xx: Mã module truyền vào 2 ký tự 
        If bNoMessage Then
            Return CheckStoreNoMessage(sSQL)
        Else
            Return CheckStoreDivision(sSQL)
        End If
    End Function

    Private Function CheckStoreDivision(ByVal SQL As String) As Boolean
        Dim dt As New DataTable
        dt = ReturnDataTable(SQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("Status").ToString <> "0" Then 'Đơn vị không hợp lệ
                'Kiểm tra User này có được quyền sử dụng Đơn vị nào không
                If dt.Rows(0).Item("DivisionID").ToString <> "" Then ' Có: Lấy đơn vị này để làm việc.
                    gsDivisionID = dt.Rows(0).Item("DivisionID").ToString
                    dt = Nothing
                    Return True
                Else 'Không: Thông báo và kết thúc chương trình
                    D99C0008.MsgL3(ConvertVietwareFToUnicode(dt.Rows(0).Item("Message").ToString), L3MessageBoxIcon.Exclamation)
                    dt = Nothing
                    Return False
                End If
            End If
            dt = Nothing
        Else
            D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
            Return False
        End If
        Return True
    End Function

    Private Function CheckStoreNoMessage(ByVal SQL As String) As Boolean
        Dim dt As New DataTable
        dt = ReturnDataTable(SQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("Status").ToString <> "0" Then
                dt = Nothing
                Return False
            End If
            dt = Nothing
        Else
            D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
            Return False
        End If
        Return True
    End Function

    Private Function SQLStoreD91P9020(ByVal sModuleID As String) As String
        ' Kiểm tra có tồn tại Đơn vị
        Dim sSQL As String = ""
        sSQL &= "Exec D91P9020 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID,varchar[20],NOT NULL
        sSQL &= SQLString(sModuleID) & COMMA 'ModuleID,varchar[20],NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function
    'Private Function CheckExistDivision() As Boolean
    '    Dim sSQL As String
    '    sSQL = "Select Top 1 1 From D02T9999 T99  WITH(NOLOCK) Inner Join D91T0016 T16  WITH(NOLOCK) On T99.DivisionID = T16.DivisionID "
    '    sSQL &= " Inner Join D91T0060 T60 On T99.DivisionID = T60.DivisionID "
    '    sSQL &= " Where T99.DivisionID = " & SQLString(gsDivisionID) & " And T16.Disabled = 0 Order By TranYear Desc, TranMonth Desc"
    '    Return ExistRecord(sSQL)
    'End Function

    Private Function GetMonthYear() As Boolean
        Dim sSQL As String
        sSQL = "Select Top 1 T99.TranMonth, T99.TranYear From D02T9999 T99  WITH(NOLOCK) Inner Join D91T0016 T16  WITH(NOLOCK) On T99.DivisionID = T16.DivisionID Where T99.DivisionID = " & SQLString(gsDivisionID) & " And T16.Disabled = 0 Order By TranYear Desc, TranMonth Desc"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then 'Có dữ liệu trong bảng T9999 và D91T0016
            giTranMonth = Convert.ToInt16(dt.Rows(0).Item("TranMonth").ToString)
            giTranYear = Convert.ToInt16(dt.Rows(0).Item("TranYear").ToString)
            dt.Dispose()
            Return True
        End If
        Return False
    End Function

    Private Sub GetPeriodFromDivisionT0000()
        Dim sSQL As String
        gsDivisionID = D02Systems.DefaultDivisionID
        'gbLockedDivisionID = D02Systems.LockedDivisionID
        sSQL = "Select Top 1 T99.TranMonth, T99.TranYear From D02T9999 T99  WITH(NOLOCK) Inner Join D91T0016 T16  WITH(NOLOCK) On T99.DivisionID = T16.DivisionID Where T99.DivisionID = " & SQLString(gsDivisionID) & " And T16.Disabled = 0 Order By TranYear Desc, TranMonth Desc"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then 'Có dữ liệu trong bảng D02T9999 và D91T0016
            giTranMonth = Convert.ToInt16(dt.Rows(0).Item("TranMonth").ToString)
            giTranYear = Convert.ToInt16(dt.Rows(0).Item("TranYear").ToString)
            dt.Dispose()
        End If
    End Sub

    

    Private Sub mnuLockedVoucher_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuLockedVoucher.Click
        'Dim f As New D02F5557
        'f.ShowDialog()
        'f.Dispose()

        'Incident 	71021
        CallFormShowDialog("D02D0940", "D02F5557")
    End Sub

    

    
    

    

    ' update 5/9/2013 id 58781
    Private Sub mnuSysMethodCIP_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysMethodCIP.Click
        'Dim frm As New D91F5558
        'With frm
        '    .FormName = "D91F0040" 'Form Active
        '    .FormPermission = "D02F0060" 'Form phân quyền theo TL
        '    .ID01 = "D02F0060" 'Form truyền vào câu SQL
        '    .ID02 = "D02F0061" 'Mã form cho form con Thêm, Sửa,…
        '    .ShowDialog()
        '    .Dispose()
        'End With


        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F0060")
        SetProperties(arrPro, "ModuleID", "02")
        SetProperties(arrPro, "FormID", "D02F0060")
        SetProperties(arrPro, "FormIDSub", "D02F0061") ''DxxFxxxx mã form của Caption D91F0041
        SetProperties(arrPro, "MethodMode", L3Byte("0")) '0: PP tạo mã tự động; 1: Phương pháp tính
        CallFormShowDialog("D91D0640", "D91F0040", arrPro)
    End Sub

  
    

    

    ''Ẩn phân nhóm: các hàm này để DxxX0002
    'Private Sub SetVisibleDelimiter(ByVal menu As C1.Win.C1Command.C1MainMenu)
    '    For i As Integer = 0 To menu.CommandLinks.Count - 1
    '        If TypeOf (menu.CommandLinks(i).Command) Is C1.Win.C1Command.C1CommandMenu Then 'Lấy 5 menu chính
    '            Dim mnu As C1.Win.C1Command.C1CommandMenu = CType(menu.CommandLinks(i).Command, C1.Win.C1Command.C1CommandMenu)
    '            SetVisibleDelimiter(mnu) 'Set menu con trong từng menu chính
    '        End If
    '    Next
    'End Sub

    'Private Sub SetVisibleDelimiter(ByVal mnu As C1.Win.C1Command.C1CommandMenu)
    '    For i As Integer = 0 To mnu.CommandLinks.Count - 1
    '        If (i > 0 And mnu.CommandLinks(i).Delimiter = True) AndAlso mnu.CommandLinks(i - 1).Command.Visible = False Then
    '            mnu.CommandLinks(i).Delimiter = False
    '        End If

    '        If TypeOf (mnu.CommandLinks(i).Command) Is C1.Win.C1Command.C1CommandMenu Then 'menu chứa menu con
    '            Dim cmnu As C1.Win.C1Command.C1CommandMenu = CType(mnu.CommandLinks(i).Command, C1.Win.C1Command.C1CommandMenu)
    '            SetVisibleChildDelimiter(cmnu)
    '        End If
    '    Next
    'End Sub

    'Private Sub SetVisibleChildDelimiter(ByVal mnu As C1.Win.C1Command.C1CommandMenu)
    '    Dim iVisible As Integer = 0

    '    For i As Integer = 0 To mnu.CommandLinks.Count - 1
    '        If (i > 0 And mnu.CommandLinks(i).Delimiter) AndAlso mnu.CommandLinks(i - 1).Command.Visible = False Then
    '            mnu.CommandLinks(i).Delimiter = False
    '        End If

    '        'Ẩn menu cha khi các menu con bị ẩn
    '        If mnu.CommandLinks(i).Command.Visible = True Then iVisible += 1
    '    Next

    '    If mnu.Visible Then mnu.Visible = (iVisible > 0)
    'End Sub

    Private Sub mnuSysFixedAssets_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysFixedAssets.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F0070")
        SetProperties(arrPro, "FormID", "D02F0070")
        SetProperties(arrPro, "ModuleID", "02")
        'SetProperties(arrPro, "ModuleIDT9999", "D91") ''Dxx: Dùng cho các module không có bảng DxxT9999
        SetProperties(arrPro, "MethodMode", L3Byte("0")) '0: PP tạo mã tự động; 1: Phương pháp tính
        SetProperties(arrPro, "FormIDSub", "D02F0071") ''DxxFxxxx mã form của Caption D91F0041
        CallFormShow("D91D0640", "D91F0040", arrPro)
    End Sub


    

   

   
  
 
End Class
