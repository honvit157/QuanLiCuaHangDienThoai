"""Chương 3 - Phát triển hệ thống, Kết luận và Danh mục sách tham khảo."""

import os

from tai_lieu import bieu_do

HINH = os.path.join(os.path.dirname(os.path.abspath(__file__)), "hinh")


def viet(b):
    b.chuong_moi(3, "PHÁT TRIỂN HỆ THỐNG")

    b.p(
        "Chương này trình bày cách hiện thực từng tầng của kiến trúc, bắt đầu từ giao diện, qua nghiệp "
        "vụ, xuống truy cập dữ liệu và cuối cùng là các thủ tục lưu trữ. Với mỗi tầng, báo cáo nêu danh "
        "sách lớp, nhiệm vụ của từng lớp và một vài đoạn mã tiêu biểu để thấy rõ ranh giới giữa các tầng."
    )

    # ==================================================================
    b.h(2, "3.1. Lớp GUI")

    b.p(
        "Tầng giao diện gồm mười một biểu mẫu. Form9 là biểu mẫu đăng nhập, Form10 là màn hình chính "
        "đóng vai trò khung chứa, tám biểu mẫu còn lại thực hiện từng nhóm chức năng và được mở bên "
        "trong vùng nội dung của Form10. Mối quan hệ giữa các biểu mẫu được mô tả ở Hình 3.1."
    )
    b.hinh("Quan hệ giữa các biểu mẫu trong hệ thống", os.path.join(HINH, "hinh_3_1_quan_he_form.png"), 16.0)

    b.h(3, "3.1.1. Biểu mẫu đăng nhập Form9")
    b.p(
        "Form9 nhận tài khoản và mật khẩu, chuyển cho NhanVienBUS kiểm tra. Tầng nghiệp vụ gọi thủ tục "
        "sp_KiemTraDangNhap; nếu có bản ghi trả về thì tạo đối tượng NhanVien và lưu ba thông tin phiên "
        "làm việc vào các biến tĩnh: mã nhân viên, tên nhân viên và chức vụ. Form9 ẩn đi và mở Form10; "
        "khi Form10 đóng, thông tin phiên được xóa và Form9 hiện lại, sẵn sàng cho lượt đăng nhập tiếp "
        "theo. Cách làm này bảo đảm không có hai phiên đăng nhập cùng tồn tại trong một tiến trình."
    )

    b.h(3, "3.1.2. Màn hình chính và Dashboard Form10")
    b.p(
        "Form10 là biểu mẫu quan trọng nhất của tầng giao diện. Khác với các biểu mẫu còn lại được thiết "
        "kế bằng công cụ kéo thả, Form10 dựng toàn bộ giao diện bằng mã nguồn: hàm TaoGiaoDien() tạo "
        "TableLayoutPanel ba cột và hai hàng, hàm TaoSidebar() dựng menu trái, hàm TaoHeader() dựng thanh "
        "tiêu đề, hàm TaoRightSidebar() dựng cột thông tin bên phải và hàm HienThiDashboard() dựng nội "
        "dung trang tổng quan. Cách dựng bằng mã giúp bố cục co giãn đúng theo mọi độ phân giải màn hình."
    )
    b.p(
        "Bố cục ba cột gồm: cột trái rộng 500 điểm ảnh chứa logo và menu phân nhóm; cột giữa chiếm phần "
        "còn lại, phía trên là thanh tiêu đề cao 110 điểm ảnh và phía dưới là vùng nội dung; cột phải "
        "rộng 400 điểm ảnh chứa ảnh khuyến mãi, ảnh điện thoại nổi bật và thông tin cửa hàng. Sơ đồ bố "
        "cục được trình bày ở Hình 3.2."
    )
    b.hinh("Bố cục ba cột của Dashboard Form10", os.path.join(HINH, "hinh_3_2_bo_cuc_dashboard.png"), 16.0)

    b.p(
        "Menu trái được chia thành bốn nhóm có tiêu đề: Tổng quan, Quản lý cửa hàng, Giao dịch và Thống "
        "kê. Mỗi mục là một nút phẳng có biểu tượng và nhãn; khi bấm, biểu mẫu tương ứng được mở trong "
        "vùng nội dung. Mục “Nhân viên” chỉ được thêm vào menu khi chức vụ của người đăng nhập là quản "
        "lý, nhờ vậy việc phân quyền được thực hiện ngay ở tầng giao diện bên cạnh việc kiểm tra lại ở "
        "tầng nghiệp vụ."
    )
    b.p(
        "Trang tổng quan gồm bốn thẻ số liệu và một biểu đồ. Mỗi thẻ hiển thị một biểu tượng, một nhãn và "
        "một giá trị: tổng số sản phẩm, số khách hàng, số hóa đơn lập trong ngày và doanh thu trong "
        "ngày. Biểu đồ doanh thu bảy ngày được vẽ trực tiếp bằng thư viện đồ họa GDI+ trong sự kiện Paint "
        "của một Panel: chương trình tính giá trị lớn nhất, chọn bước chia trục cho gọn (1, 2 hoặc 5 nhân "
        "với lũy thừa của 10), vẽ lưới, vẽ trục, vẽ từng cột và ghi giá trị rút gọn phía trên mỗi cột. "
        "Toàn bộ dữ liệu của trang này lấy qua ThongKeBUS, mỗi chỉ số tương ứng một thủ tục thống kê."
    )
    b.bang(
        "Các thành phần giao diện chính của Form10 (dựng bằng mã)",
        ["STT", "Thành phần", "Kiểu", "Ý nghĩa"],
        [
            ["1", "tblBoCuc", "TableLayoutPanel", "Bố cục ba cột, hai hàng của toàn màn hình"],
            ["2", "pnlSidebar", "Panel", "Menu trái rộng 500 điểm ảnh, nền xanh đậm"],
            ["3", "pnlHeader", "Panel", "Thanh tiêu đề cao 110 điểm ảnh, hiển thị tên trang và tài khoản"],
            ["4", "pnlNoiDung", "Panel", "Vùng chứa biểu mẫu con, chiếm cột giữa"],
            ["5", "pnlRightSidebar", "Panel", "Cột phải rộng 400 điểm ảnh chứa ảnh và thông tin cửa hàng"],
            ["6", "flpMenu", "FlowLayoutPanel", "Danh sách nút menu xếp dọc, có cuộn"],
            ["7", "TaoTheThongKe()", "Panel (hàm tạo)", "Sinh một thẻ số liệu gồm nhãn, biểu tượng và giá trị"],
            ["8", "pnlVungBieuDo", "Panel + sự kiện Paint", "Vùng vẽ biểu đồ cột doanh thu bảy ngày"],
            ["9", "picBanner, picDienThoai", "PictureBox", "Ảnh banner_khuyenmai.jpg và iphone18.jpg"],
            ["10", "lblTieuDe, lblTaiKhoan", "Label", "Tiêu đề trang và tên người dùng kèm chức vụ"],
        ],
        do_rong=[1.2, 4.0, 4.0, 8.4],
        canh_giua=[0],
        co=10,
    )

    b.h(3, "3.1.3. Cơ chế mở biểu mẫu con")
    b.p(
        "Khi người dùng bấm một mục menu, hàm MoForm() được gọi. Hàm này đóng biểu mẫu đang hiển thị, cập "
        "nhật tiêu đề trên thanh header, sau đó đặt thuộc tính TopLevel bằng false và Dock bằng Fill cho "
        "biểu mẫu mới rồi thêm nó vào vùng nội dung. Nhờ hai thuộc tính này, biểu mẫu con hoạt động như "
        "một control bình thường, không có thanh tiêu đề riêng và tự co giãn theo cửa sổ chính. Đoạn mã "
        "dưới đây minh họa cách làm:"
    )
    b.ma_nguon(
        "private void MoForm(Form f, string tieuDe)\n"
        "{\n"
        "    DongFormDangHienThi();          // đóng và giải phóng form cũ\n"
        "    lblTieuDe.Text = tieuDe;\n"
        "    pnlNoiDung.SuspendLayout();\n"
        "    pnlNoiDung.Controls.Clear();\n"
        "    f.TopLevel = false;             // không phải cửa sổ độc lập\n"
        "    f.FormBorderStyle = FormBorderStyle.None;\n"
        "    f.Dock = DockStyle.Fill;        // lấp đầy vùng nội dung\n"
        "    pnlNoiDung.Controls.Add(f);\n"
        "    f.Show();\n"
        "    f.BringToFront();\n"
        "    formDangHienThi = f;\n"
        "    pnlNoiDung.ResumeLayout(true);\n"
        "}"
    )

    b.h(3, "3.1.4. Các biểu mẫu nghiệp vụ")
    b.p(
        "Form1 quản lý hàng hóa với bốn hộp chọn danh mục được nạp qua DanhMucBUS, một bảng danh sách "
        "dùng DataView để lọc nhanh tại máy khách và một vùng chọn ảnh minh họa. Form5 quản lý bốn danh "
        "mục bằng bốn thẻ có cùng bộ nút. Form2, Form3, Form4 quản lý nhân viên, khách hàng và nhà cung "
        "cấp theo cùng một khuôn: vùng nhập bên trái, bảng danh sách bên phải, các nút Thêm – Sửa – Xóa – "
        "Làm lại – Thoát và ô tìm kiếm nhanh. Form6 tìm kiếm hàng hóa theo sáu tiêu chí và xuất kết quả "
        "ra Excel. Form7 và Form8 lập chứng từ, có bảng chi tiết tự tính thành tiền và tổng tiền. "
        "FormBaoCao hiển thị ba báo cáo trong ba thẻ và xuất cả ba ra một tệp Excel."
    )
    b.bang(
        "Các control chính của Form1 (giữ nguyên theo Designer của nhóm)",
        ["STT", "Tên đối tượng", "Kiểu", "Ý nghĩa"],
        [
            ["1", "txtMaHang, txtTenHang", "TextBox", "Nhập mã và tên mặt hàng"],
            ["2", "cboHang, cboLoai, cboMau, cboDungLuong", "ComboBox", "Chọn hãng, loại, màu, dung lượng"],
            ["3", "txtGiaNhap, txtGiaBan, txtSoLuong", "TextBox", "Nhập giá nhập, giá bán, số lượng tồn"],
            ["4", "dgvHang", "DataGridView", "Danh sách mặt hàng, chọn dòng để sửa hoặc xóa"],
            ["5", "txtTim", "TextBox", "Tìm nhanh theo mã hoặc tên"],
            ["6", "picAnh, lblTenAnh, btnChonAnh", "PictureBox, Label, Button", "Chọn và hiển thị ảnh minh họa"],
            ["7", "btnThem, btnSua, btnXoa, btnLamLai, btnThoat, btnTim", "Button", "Các nút chức năng"],
        ],
        do_rong=[1.2, 5.4, 3.6, 7.4],
        canh_giua=[0],
        co=10,
    )
    b.bang(
        "Các control chính của Form7 (hóa đơn bán)",
        ["STT", "Tên đối tượng", "Kiểu", "Ý nghĩa"],
        [
            ["1", "cboMaHD", "ComboBox", "Mã hóa đơn đang lập hoặc cần tìm"],
            ["2", "txtMaNV, txtTenNV", "TextBox", "Mã và tên nhân viên lập hóa đơn"],
            ["3", "txtMaKH, txtTenKH, txtSDT, txtDiaChi", "TextBox", "Thông tin khách hàng, tự hiện khi nhập mã"],
            ["4", "dtpNgayLap", "DateTimePicker", "Ngày lập hóa đơn"],
            ["5", "cboMaHang, txtTenHang, txtDonGia", "ComboBox, TextBox", "Chọn mặt hàng, tên và đơn giá tự hiện"],
            ["6", "txtSoLuong, txtGiamGia, txtThanhTien", "TextBox", "Số lượng, giảm giá và thành tiền của dòng"],
            ["7", "dgvChiTiet", "DataGridView", "Các dòng chi tiết của hóa đơn"],
            ["8", "lblTongTien", "Label", "Tổng tiền của hóa đơn"],
            ["9", "btnThemHang, btnThemHD, btnLuu, btnHuy, btnIn, btnTim, btnThoat", "Button", "Các nút chức năng"],
        ],
        do_rong=[1.2, 6.0, 3.6, 6.8],
        canh_giua=[0],
        co=9.5,
    )
    b.bang(
        "Các control chính của Form8 (hóa đơn nhập)",
        ["STT", "Tên đối tượng", "Kiểu", "Ý nghĩa"],
        [
            ["1", "cboMaHDN", "ComboBox", "Mã phiếu nhập đang lập hoặc cần tìm"],
            ["2", "txtMaNV, txtTenNV", "TextBox", "Mã và tên nhân viên lập phiếu"],
            ["3", "cboNCC, txtMaNCC, txtSDT, txtDiaChi", "ComboBox, TextBox", "Nhà cung cấp và thông tin liên hệ"],
            ["4", "dtpNgayNhap", "DateTimePicker", "Ngày nhập hàng"],
            ["5", "cboMaHang, txtTenHang, txtDonGiaNhap", "ComboBox, TextBox", "Chọn mặt hàng và đơn giá nhập"],
            ["6", "txtSoLuong, txtThanhTien", "TextBox", "Số lượng nhập và thành tiền của dòng"],
            ["7", "dgvChiTiet", "DataGridView", "Các dòng chi tiết của phiếu nhập"],
            ["8", "lblTongTien", "Label", "Tổng tiền nhập"],
            ["9", "button1, btnThemHD, btnLuu, btnHuy, btnIn, btnTim, btnThoat", "Button", "Các nút chức năng"],
        ],
        do_rong=[1.2, 6.0, 3.6, 6.8],
        canh_giua=[0],
        co=9.5,
    )
    b.p(
        "Cần lưu ý rằng toàn bộ giao diện của các biểu mẫu, gồm bố cục, màu sắc, phông chữ và vị trí "
        "control, được giữ nguyên theo bản thiết kế mới nhất của nhóm. Việc chuẩn hóa chỉ tác động tới "
        "phần mã xử lý sự kiện: thay vì mở kết nối và viết câu lệnh SQL ngay trong biểu mẫu, mã chỉ gọi "
        "hàm của tầng nghiệp vụ."
    )

    # ==================================================================
    b.h(2, "3.2. Lớp BUS")

    b.p(
        "Tầng nghiệp vụ gồm chín lớp, mỗi lớp phụ trách một nhóm đối tượng. Nhiệm vụ của tầng này là kiểm "
        "tra tính hợp lệ của dữ liệu trước khi ghi, áp dụng các quy tắc nghiệp vụ, ghi nhật ký thao tác "
        "quan trọng và chuyển yêu cầu xuống tầng truy cập dữ liệu. Tầng nghiệp vụ không biết giao diện "
        "nào đang gọi mình, cũng không biết câu lệnh SQL cụ thể ra sao."
    )
    b.bang(
        "Các lớp trong tầng nghiệp vụ",
        ["STT", "Lớp", "Nhiệm vụ chính", "Phương thức tiêu biểu"],
        [
            ["1", "HangHoaBUS", "Kiểm tra mã, tên, giá, tồn kho; chặn trùng mã; tìm kiếm đa tiêu chí",
             "LayDanhSach(), LayTheoMa(), Them(), Sua(), Xoa(), TimKiem()"],
            ["2", "DanhMucBUS", "Kiểm tra mã và tên của bốn danh mục; chọn nhóm thủ tục theo LoaiDanhMuc",
             "LayDanhSach(loai), Them(), Sua(), Xoa()"],
            ["3", "KhachHangBUS", "Kiểm tra số điện thoại, email; chặn xóa khách đã có hóa đơn",
             "LayThongTin(), Them(), Sua(), Xoa()"],
            ["4", "NhaCungCapBUS", "Kiểm tra số điện thoại, email; bắt lỗi khóa ngoại khi xóa",
             "LayThongTin(), Them(), Sua(), Xoa()"],
            ["5", "NhanVienBUS", "Xác thực đăng nhập; đổi trạng thái làm việc; kiểm tra mật khẩu",
             "DangNhap(), LayTen(), CapNhatTrangThai(), Them(), Sua(), Xoa()"],
            ["6", "HoaDonBanBUS", "Kiểm tra chứng từ trước khi lưu; gọi DAL trong một giao dịch",
             "LuuHoaDon(), LayHoaDon(), LayChiTiet(), LayDanhSachMa()"],
            ["7", "HoaDonNhapBUS", "Kiểm tra phiếu nhập trước khi lưu; gọi DAL trong một giao dịch",
             "LuuHoaDon(), LayHoaDon(), LayChiTiet(), LayDanhSachMa()"],
            ["8", "BaoCaoBUS", "Tổng hợp ba báo cáo phục vụ FormBaoCao",
             "DoanhThuTheoThang(), TonKho(), TopBanChay()"],
            ["9", "ThongKeBUS", "Cung cấp số liệu cho Dashboard và định dạng sẵn để hiển thị",
             "TongSanPham(), DoanhThu7Ngay(), Top5BanChay(), SanPhamSapHetHang()"],
        ],
        do_rong=[1.1, 3.4, 7.6, 7.5],
        canh_giua=[0],
        co=9.5,
    )

    b.h(3, "3.2.1. Kiểm tra dữ liệu trước khi ghi")
    b.p(
        "Mỗi lớp nghiệp vụ có hàm kiểm tra riêng, dùng chung cho cả thao tác thêm và sửa để quy tắc không "
        "bị lệch nhau. Ví dụ với hàng hóa, hàm kiểm tra từ chối mã rỗng, mã dài quá 20 ký tự, tên rỗng, "
        "giá âm và số lượng tồn âm. Với khách hàng và nhà cung cấp, hàm kiểm tra dùng "
        "AppHelpers.KiemTraSoDienThoai và AppHelpers.KiemTraEmail để bảo đảm số điện thoại đúng mười chữ "
        "số bắt đầu bằng 0 và email đúng dạng. Khi dữ liệu không hợp lệ, hàm trả về false kèm thông báo "
        "tiếng Việt cụ thể để biểu mẫu hiển thị, thay vì để cơ sở dữ liệu báo lỗi kỹ thuật."
    )

    b.h(3, "3.2.2. Quy tắc bảo toàn lịch sử giao dịch")
    b.p(
        "Với khách hàng, tầng nghiệp vụ thực hiện một quy tắc quan trọng: trước khi xóa, hàm Xoa() gọi "
        "DAL lấy danh sách mã hóa đơn của khách hàng đó. Nếu danh sách không rỗng, hàm từ chối xóa và "
        "liệt kê các mã hóa đơn liên quan cho người dùng thấy. Cách làm này giữ cho báo cáo doanh thu "
        "theo tháng và báo cáo top bán chạy luôn khớp với dữ liệu gốc, vì không có hóa đơn nào bị mồ côi."
    )

    b.h(3, "3.2.3. Tầng nghiệp vụ của Dashboard")
    b.p(
        "ThongKeBUS là lớp nghiệp vụ được bổ sung để màn hình tổng quan không phải gọi trực tiếp tầng "
        "truy cập dữ liệu. Lớp này cung cấp bốn hàm trả về số liệu thẻ (tổng sản phẩm, tổng khách hàng, "
        "số hóa đơn hôm nay, doanh thu hôm nay), ba hàm trả về bảng dữ liệu (doanh thu bảy ngày, top năm "
        "mặt hàng bán chạy, danh sách mặt hàng sắp hết) và hai hàm tiện ích tính tổng doanh thu bảy ngày "
        "hoặc trả về chuỗi tiền đã định dạng. Nhờ vậy Form10 chỉ còn một dòng lệnh cho mỗi chỉ số, ví dụ:"
    )
    b.ma_nguon(
        "private readonly ThongKeBUS thongKeBUS = new ThongKeBUS();\n"
        "\n"
        "tongSanPham     = thongKeBUS.TongSanPham();\n"
        "tongKhachHang   = thongKeBUS.TongKhachHang();\n"
        "hoaDonHomNay    = thongKeBUS.HoaDonHomNay();\n"
        "doanhThuHomNay  = thongKeBUS.DoanhThuHomNay();\n"
        "dtDoanhThu      = thongKeBUS.DoanhThu7Ngay();   // DataTable cho biểu đồ"
    )

    # ==================================================================
    b.h(2, "3.3. Lớp DAL")

    b.p(
        "Tầng truy cập dữ liệu gồm mười lớp: một lớp hạ tầng DatabaseAccess, một lớp cho mỗi nhóm bảng và "
        "hai lớp chuyên trách hóa đơn. Nhiệm vụ duy nhất của tầng này là chuyển yêu cầu của tầng nghiệp "
        "vụ thành lời gọi thủ tục lưu trữ và trả kết quả về dưới dạng DataTable, số nguyên hoặc đối tượng "
        "thực thể. Tầng này không kiểm tra nghiệp vụ và không hiển thị thông báo."
    )
    b.bang(
        "Các lớp trong tầng truy cập dữ liệu",
        ["STT", "Lớp", "Bảng dữ liệu phụ trách", "Phương thức tiêu biểu"],
        [
            ["1", "DatabaseAccess", "Không phụ trách bảng nào; mở kết nối và chạy thủ tục",
             "DocBangProc(), ThucThiProc(), GiaTriProc(), DemBanGhi(), ThamSo()"],
            ["2", "HangHoaDAL", "tblHang", "LayTatCa(), LayTheoMa(), Them(), Sua(), Xoa(), TimKiem()"],
            ["3", "DanhMucDAL", "tblHangSX, tblLoai, tblMau, tblDungLuong",
             "LayTatCa(loai), Them(), Sua(), Xoa(), KiemTraTonTai()"],
            ["4", "KhachHangDAL", "tblKhachHang, tblHoaDonBan", "LayTatCa(), LayThongTin(), LayHoaDonCuaKhachHang()"],
            ["5", "NhaCungCapDAL", "tblNhaCungCap", "LayTatCa(), LayThongTin(), Them(), Sua(), Xoa()"],
            ["6", "NhanVienDAL", "tblNhanVien", "KiemTraDangNhap(), LayTen(), CapNhatTrangThai()"],
            ["7", "HoaDonBanDAL", "tblHoaDonBan, tblChiTietHDB", "LuuHoaDon(), LayHoaDon(), LayChiTiet()"],
            ["8", "HoaDonNhapDAL", "tblHoaDonNhap, tblChiTietHDN", "LuuHoaDon(), LayHoaDon(), LayChiTiet()"],
            ["9", "BaoCaoDAL", "tblHoaDonBan, tblHang, tblChiTietHDB",
             "DoanhThuTheoThang(), TonKho(), TopBanChay()"],
            ["10", "ThongKeDAL", "tblHang, tblKhachHang, tblHoaDonBan, tblChiTietHDB",
             "DemTongSanPham(), LayDoanhThu7Ngay(), LayTop5SanPhamBanChay()"],
        ],
        do_rong=[1.1, 3.6, 6.0, 8.9],
        canh_giua=[0],
        co=9.5,
    )

    b.h(3, "3.3.1. Lớp hạ tầng DatabaseAccess")
    b.p(
        "DatabaseAccess giữ chuỗi kết nối và cung cấp bốn hàm dùng chung: DocBangProc() đổ kết quả một "
        "thủ tục truy vấn vào DataTable; ThucThiProc() chạy thủ tục thêm, sửa, xóa và trả về số dòng tác "
        "động; GiaTriProc() lấy một giá trị duy nhất như COUNT hay SUM; DemBanGhi() chuyển giá trị đó "
        "thành số nguyên. Hàm ThamSo() tạo tham số và tự đổi giá trị null của C# thành DBNull của SQL "
        "Server, nhờ vậy các lớp DAL không phải kiểm tra null ở từng lời gọi. Ba hàm này còn có bản nhận "
        "vào một kết nối và một giao dịch có sẵn, phục vụ nghiệp vụ lưu hóa đơn nhiều bước."
    )
    b.p(
        "Điểm cốt lõi của lớp này là mọi SqlCommand đều được đặt CommandType bằng StoredProcedure và tên "
        "lệnh là tên thủ tục, không có chuỗi SQL nào được ghép trong mã C#. Chuỗi kết nối có thể ghi đè "
        "bằng biến môi trường QLCHD_CONNECTION để chạy trên máy có tên instance SQL Server khác."
    )

    b.h(3, "3.3.2. Lưu chứng từ trong một giao dịch")
    b.p(
        "Hai lớp HoaDonBanDAL và HoaDonNhapDAL cài đặt nghiệp vụ nhiều bước. Với hóa đơn bán, hàm "
        "LuuHoaDon() mở kết nối và bắt đầu giao dịch, kiểm tra mã hóa đơn chưa tồn tại, gọi sp_TruTonKho "
        "cho từng dòng và kiểm tra số dòng trả về, ghi đầu hóa đơn, ghi từng dòng chi tiết, rồi cam kết "
        "giao dịch. Nếu bất kỳ bước nào ném ngoại lệ, khối catch gọi Rollback để hoàn tác toàn bộ và "
        "ngoại lệ được chuyển lên tầng nghiệp vụ để hiển thị thông báo cho người dùng."
    )
    b.ma_nguon(
        "using SqlConnection conn = DatabaseAccess.TaoKetNoi();\n"
        "conn.Open();\n"
        "using SqlTransaction tran = conn.BeginTransaction();\n"
        "try\n"
        "{\n"
        "    // 1) không cho trùng mã hóa đơn\n"
        "    object? trungMa = DatabaseAccess.GiaTriProc(conn, tran,\n"
        "        \"sp_KiemTraHoaDonBanTonTai\", new[] { DatabaseAccess.ThamSo(\"@MaHDB\", hd.MaHD) });\n"
        "    if (Convert.ToInt32(trungMa) > 0)\n"
        "        throw new InvalidOperationException(\"Mã hóa đơn đã tồn tại.\");\n"
        "\n"
        "    // 2) trừ tồn kho, sp_TruTonKho trả về số dòng đã trừ\n"
        "    foreach (ChiTietHoaDonBan ct in hd.ChiTietList)\n"
        "    {\n"
        "        object? kq = DatabaseAccess.GiaTriProc(conn, tran, \"sp_TruTonKho\",\n"
        "            new[] { DatabaseAccess.ThamSo(\"@MaHang\", ct.MaHang),\n"
        "                    DatabaseAccess.ThamSo(\"@SoLuong\", ct.SoLuong) });\n"
        "        if (Convert.ToInt32(kq) == 0)\n"
        "            throw new InvalidOperationException($\"Mặt hàng {ct.MaHang} không đủ tồn kho.\");\n"
        "    }\n"
        "\n"
        "    // 3) ghi đầu hóa đơn và từng dòng chi tiết\n"
        "    DatabaseAccess.ThucThiProc(conn, tran, \"sp_ThemHoaDonBan\", thamSoDauHoaDon);\n"
        "    foreach (ChiTietHoaDonBan ct in hd.ChiTietList)\n"
        "        DatabaseAccess.ThucThiProc(conn, tran, \"sp_ThemChiTietHoaDonBan\", thamSoChiTiet(ct));\n"
        "\n"
        "    tran.Commit();\n"
        "}\n"
        "catch\n"
        "{\n"
        "    tran.Rollback();   // hoàn tác toàn bộ nếu có bước thất bại\n"
        "    throw;\n"
        "}"
    )

    # ==================================================================
    b.h(2, "3.4. Các Procedure")

    b.p(
        "Toàn bộ truy vấn nằm trong hai tệp kịch bản: InitDb.sql tạo cơ sở dữ liệu, mười hai bảng và dữ "
        "liệu mẫu; StoredProcedures.sql tạo bảy mươi tám thủ tục lưu trữ. Tệp thứ ba "
        "QLCuaHangBanDienThoai.sql là bản gộp của hai tệp trên để chỉ cần chạy một lần là đủ. Mỗi thủ tục "
        "được tạo bằng lệnh CREATE OR ALTER nên chạy lại nhiều lần vẫn an toàn."
    )
    b.p("Quy ước chung khi viết thủ tục trong dự án:", thut_dau=True)
    b.p_gach("Đặt SET NOCOUNT ON ở đầu thân thủ tục để không trả về thông báo số dòng thừa.")
    b.p_gach("Tham số có kiểu dữ liệu trùng với cột trong bảng, tham số lọc không bắt buộc có giá trị mặc định NULL.")
    b.p_gach("Thủ tục cập nhật có điều kiện trả về @@ROWCOUNT để tầng trên kiểm tra kết quả thực tế.")
    b.p_gach("Kết quả trả về dùng bí danh (alias) trùng với tên cột mà lớp DAL đọc, tránh phải đổi tên ở C#.")
    b.p_gach("Thủ tục chỉ đọc dữ liệu, không hiển thị thông báo và không ghi tệp.")

    b.bang(
        "Bảng ánh xạ giữa lớp DAL và thủ tục lưu trữ (trích)",
        ["Lớp DAL", "Phương thức", "Thủ tục được gọi"],
        [
            ["HangHoaDAL", "LayTatCa()", "sp_LayDanhSachHang"],
            ["HangHoaDAL", "Them(h)", "sp_ThemHang"],
            ["HangHoaDAL", "TimKiem(...)", "sp_TimKiemHang"],
            ["DanhMucDAL", "LayTatCa(loai)", "sp_LayDanhSachHangSX / Loai / Mau / DungLuong"],
            ["KhachHangDAL", "LayHoaDonCuaKhachHang(maKH)", "sp_LayHoaDonCuaKhachHang"],
            ["NhanVienDAL", "KiemTraDangNhap(tk, mk)", "sp_KiemTraDangNhap"],
            ["HoaDonBanDAL", "LuuHoaDon(hd)", "sp_KiemTraHoaDonBanTonTai, sp_TruTonKho, sp_ThemHoaDonBan, sp_ThemChiTietHoaDonBan"],
            ["HoaDonNhapDAL", "LuuHoaDon(hd)", "sp_KiemTraHoaDonNhapTonTai, sp_ThemHoaDonNhap, sp_CongTonKho, sp_ThemChiTietHoaDonNhap"],
            ["BaoCaoDAL", "TonKho()", "sp_BaoCaoTonKho"],
            ["ThongKeDAL", "LayDoanhThu7Ngay()", "sp_ThongKe_DoanhThu7Ngay"],
        ],
        do_rong=[3.4, 5.4, 11.0],
        co=9.5,
    )

    b.h(3, "3.4.1. Nhóm thủ tục phục vụ Dashboard")
    b.p(
        "Tám thủ tục thống kê được viết riêng cho màn hình tổng quan, tách khỏi ba thủ tục báo cáo chi "
        "tiết để mỗi màn hình chỉ tải đúng lượng dữ liệu cần thiết. Bốn thủ tục đầu trả về một con số "
        "duy nhất nên tầng DAL đọc bằng GiaTriProc; thủ tục doanh thu bảy ngày trả về bảy dòng để vẽ biểu "
        "đồ; hai thủ tục top năm và sắp hết hàng trả về bảng; thủ tục cuối cùng trả về tổng số lượng hàng "
        "trong kho. Tham số ngưỡng cảnh báo của thủ tục sắp hết hàng có giá trị mặc định là 10 nên có thể "
        "đổi ngưỡng mà không phải sửa mã."
    )

    b.h(3, "3.4.2. Kiểm soát chất lượng mã nguồn")
    b.p(
        "Vì nhóm phát triển trên nhiều máy và gộp mã thường xuyên, nhóm dùng thêm vài bước kiểm tra tự "
        "động trước khi gộp nhánh: kiểm tra cú pháp toàn bộ tệp C# bằng bộ phân tích cây cú pháp; kiểm "
        "tra trùng tên type và trùng tên thành viên trong cùng một lớp; rà soát để bảo đảm không còn "
        "chuỗi SELECT, INSERT, UPDATE hay DELETE nào trong tệp .cs; và đối chiếu danh sách thủ tục được "
        "gọi trong mã C# với danh sách thủ tục định nghĩa trong hai tệp SQL. Những bước này phát hiện sớm "
        "các lỗi khó thấy bằng mắt như gọi sai tên thủ tục hay để sót câu SQL trong tầng giao diện."
    )

    # ==================================================================
    b.h(2, "3.5. Kết chương")

    b.p(
        "Chương 3 đã trình bày cách hiện thực hệ thống theo ba tầng. Tầng giao diện gồm mười một biểu "
        "mẫu, trong đó Form10 đóng vai trò khung chứa với bố cục ba cột và trang tổng quan có bốn thẻ số "
        "liệu cùng biểu đồ doanh thu vẽ bằng GDI+. Tầng nghiệp vụ gồm chín lớp, đảm nhận kiểm tra dữ "
        "liệu, áp dụng quy tắc nghiệp vụ và ghi nhật ký. Tầng truy cập dữ liệu gồm mười lớp, chỉ gọi thủ "
        "tục lưu trữ và thực hiện giao dịch cho nghiệp vụ nhiều bước. Cuối cùng, bảy mươi tám thủ tục "
        "lưu trữ trong cơ sở dữ liệu đảm nhận toàn bộ truy vấn, kể cả các truy vấn thống kê phục vụ "
        "Dashboard. Cách phân tầng này giúp mã nguồn dễ đọc, dễ sửa và dễ mở rộng."
    )

    # ==================================================================
    b.h(1, "KẾT LUẬN")

    b.h(2, "Kết quả thu được")

    b.p(
        "Sau sáu tuần thực hiện, nhóm đã hoàn thành ứng dụng quản lý cửa hàng điện thoại chạy trên nền "
        "Windows Forms với đầy đủ bốn nhóm chức năng: quản lý hàng hóa và danh mục, quản lý đối tác, lập "
        "và tra cứu chứng từ bán – nhập, báo cáo thống kê và xuất Excel. Ứng dụng có đăng nhập và phân "
        "quyền giữa quản lý với nhân viên, có màn hình tổng quan hiển thị số liệu theo thời gian thực lấy "
        "từ cơ sở dữ liệu."
    )
    b.p("Các yêu cầu định lượng của học phần đều đạt và vượt mức tối thiểu:", thut_dau=True)
    b.p_gach("Sáu giao diện (yêu cầu tối thiểu năm) và sáu lớp triển khai các giao diện đó.")
    b.p_gach("Năm lớp kế thừa trên ba lớp cơ sở trừu tượng (yêu cầu tối thiểu ba lớp kế thừa).")
    b.p_gach("Hai quan hệ kết tập giữa hóa đơn với danh sách chi tiết của nó.")
    b.p_gach("Mười sáu class method tiện ích (yêu cầu tối thiểu năm).")
    b.p_gach("Bảy mươi tám thủ tục lưu trữ, không còn câu SQL nào viết trực tiếp trong mã C#.")
    b.p_gach("Kiến trúc ba tầng GUI – BUS – DAL tách bạch, mỗi tầng chỉ gọi tầng liền kề.")
    b.p(
        "Ngoài phần chức năng, nhóm còn xây dựng được bộ công cụ kiểm tra tĩnh để tự rà soát các yêu cầu "
        "trên mỗi khi mã nguồn thay đổi, cùng hệ thống tài liệu gồm báo cáo, slide thuyết trình và các "
        "sơ đồ minh họa."
    )

    b.h(2, "Hạn chế và hướng phát triển của đề tài")

    b.p("Nhóm ghi nhận những hạn chế sau của sản phẩm:", thut_dau=True)
    b.p_gach(
        "Chức năng báo cáo hiện xuất ra tệp Excel bằng thư viện ClosedXML chứ chưa dùng Crystal Report "
        "như yêu cầu của học phần. Đây là điểm trừ đã biết của nhóm; muốn khắc phục cần cài đặt bộ công "
        "cụ Crystal Reports cho Visual Studio, thiết kế tệp .rpt cho ba báo cáo và thay lời gọi xuất Excel "
        "bằng lời gọi ReportDocument."
    )
    b.p_gach(
        "Mật khẩu nhân viên đang lưu dạng chuỗi rõ trong cơ sở dữ liệu để tiện cho việc trình diễn và "
        "chấm bài. Nếu triển khai thật cần băm mật khẩu bằng thuật toán có muối."
    )
    b.p_gach(
        "Phân quyền mới dừng ở mức ẩn mục “Nhân viên” trên menu và khóa nút xóa nhân viên; chưa có bảng "
        "phân quyền chi tiết theo từng chức năng cho từng vai trò."
    )
    b.p_gach(
        "Dashboard hiện hiển thị bốn thẻ số liệu và biểu đồ doanh thu bảy ngày. Hai thủ tục thống kê top "
        "năm mặt hàng bán chạy và danh sách mặt hàng sắp hết hàng đã được cài đặt ở tầng dữ liệu và tầng "
        "nghiệp vụ nhưng chưa có khối giao diện tương ứng trên màn hình tổng quan."
    )
    b.p_gach(
        "Chưa có chức năng sao lưu và phục hồi cơ sở dữ liệu trong ứng dụng; việc sao lưu hiện thực hiện "
        "bằng công cụ của SQL Server."
    )
    b.p_gach(
        "Chưa có bộ kiểm thử tự động cho tầng nghiệp vụ; việc kiểm thử được thực hiện thủ công theo kịch "
        "bản trên từng biểu mẫu."
    )
    b.p("Hướng phát triển trong thời gian tới:", thut_dau=True)
    b.p_gach("Chuyển ba báo cáo sang Crystal Report để đúng yêu cầu và đủ điểm của học phần.")
    b.p_gach("Bổ sung khối top bán chạy và sắp hết hàng vào Dashboard, kèm biểu đồ tròn theo hãng sản xuất.")
    b.p_gach("Thêm chức năng trả hàng, bảo hành và quản lý phiếu thu – phiếu chi.")
    b.p_gach("Bổ sung phân quyền chi tiết theo vai trò và nhật ký thao tác lưu trong cơ sở dữ liệu.")
    b.p_gach(
        "Tách tầng dữ liệu thành dịch vụ web (ASP.NET Core Web API) và phát triển thêm bản web, bản di "
        "động để hỗ trợ cửa hàng có nhiều điểm bán."
    )

    b.h(2, "Bài học kinh nghiệm")
    b.p(
        "Quá trình làm bài giúp nhóm rút ra ba bài học. Thứ nhất, thiết kế cơ sở dữ liệu phải làm trước "
        "và làm kỹ, vì mọi thay đổi cấu trúc bảng về sau đều kéo theo sửa thủ tục, sửa DAL và đôi khi sửa "
        "cả giao diện. Thứ hai, đưa truy vấn vào thủ tục lưu trữ làm mã C# ngắn hơn nhiều và giảm hẳn lỗi "
        "do ghép chuỗi. Thứ ba, quy ước làm việc nhóm rõ ràng và các bước kiểm tra tĩnh giúp phát hiện sớm "
        "những lỗi khó thấy, đặc biệt khi nhiều thành viên cùng sửa một dự án."
    )

    # ==================================================================
    b.h(1, "DANH MỤC SÁCH THAM KHẢO")

    for i, sach in enumerate((
        "Phạm Hữu Khang, Lập trình Windows Forms với C#, Nhà xuất bản Lao động - Xã hội, 2008.",
        "Nguyễn Ngọc Bình Phương, Trần Thị Anh Thi, Giáo trình Cơ sở dữ liệu, "
        "Nhà xuất bản Giáo dục Việt Nam, 2013.",
        "John Sharp, Microsoft Visual C# Step by Step, 10th Edition, Microsoft Press, 2022.",
        "Jeffrey Richter, CLR via C#, 4th Edition, Microsoft Press, 2012.",
        "Microsoft Learn, ADO.NET - Truy cập dữ liệu trong .NET, "
        "https://learn.microsoft.com/dotnet/framework/data/adonet/ [tham khảo ngày 10 tháng 11 năm 2026].",
        "Microsoft Learn, Stored Procedures (Database Engine), "
        "https://learn.microsoft.com/sql/relational-databases/stored-procedures/stored-procedures-database-engine "
        "[tham khảo ngày 10 tháng 11 năm 2026].",
        "Microsoft Learn, Windows Forms documentation, https://learn.microsoft.com/dotnet/desktop/winforms/ "
        "[tham khảo ngày 11 tháng 11 năm 2026].",
        "ClosedXML Documentation, https://docs.closedxml.io/ [tham khảo ngày 12 tháng 11 năm 2026].",
        "SAP Crystal Reports for Visual Studio, https://www.sap.com/products/crystal-reports.html "
        "[tham khảo ngày 12 tháng 11 năm 2026].",
        "Git documentation, https://git-scm.com/doc [tham khảo ngày 13 tháng 11 năm 2026].",
    ), start=1):
        b.tai_lieu(f"[{i}] {sach}")
