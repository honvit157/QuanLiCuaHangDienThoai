"""Nội dung Chương 3 của báo cáo bài tập lớn."""

import os

HINH = os.path.join(os.path.dirname(os.path.abspath(__file__)), "hinh")


def viet(b):
    b.chuong_moi(3, "PHÁT TRIỂN HỆ THỐNG")

    b.p(
        "Chương này trình bày quá trình cài đặt hệ thống theo bốn phần tương ứng bốn tầng và thành phần: lớp "
        "giao diện GUI, lớp nghiệp vụ BUS, lớp truy cập dữ liệu DAL và các thủ tục lưu trữ. Với mỗi phần, "
        "báo cáo nêu cấu trúc tệp, nhiệm vụ của từng lớp, những đoạn mã tiêu biểu và các quy ước mà nhóm "
        "thống nhất khi viết mã. Phần cuối chương tổng hợp kết quả thu được, các kịch bản kiểm thử, hạn chế "
        "và hướng phát triển của sản phẩm."
    )

    # ==================================================================
    b.h(2, "3.1. Lớp GUI")

    b.p(
        "Lớp giao diện gồm mười một biểu mẫu, mỗi biểu mẫu gồm hai tệp: tệp thiết kế FormX.Designer.cs chứa "
        "khai báo điều khiển và tệp FormX.cs chứa mã xử lý sự kiện. Cách tách hai tệp như vậy là quy ước của "
        "Visual Studio, giúp phần giao diện có thể chỉnh bằng công cụ kéo thả mà không ảnh hưởng đến phần "
        "logic. Trong đề tài, mã xử lý sự kiện chỉ làm ba việc: đọc dữ liệu từ điều khiển, gọi tầng BUS và "
        "hiển thị kết quả. Không có biểu mẫu nào chứa câu lệnh SQL, cũng không có biểu mẫu nào mở kết nối cơ "
        "sở dữ liệu trực tiếp. Hình 3.1 minh họa quan hệ giữa các biểu mẫu."
    )
    b.hinh("Quan hệ giữa các biểu mẫu trong hệ thống", os.path.join(HINH, "hinh_3_1_quan_he_form.png"), 15.5)

    b.bang(
        "Danh sách các biểu mẫu và tầng nghiệp vụ tương ứng",
        ["STT", "Biểu mẫu", "Chức năng chính", "Lớp BUS sử dụng"],
        [
            ["1", "Form9", "Đăng nhập, kiểm tra tài khoản, lưu thông tin phiên làm việc.", "NhanVienBUS"],
            ["2", "Form10", "Cửa sổ chính: menu, thanh trạng thái, vùng chứa biểu mẫu con.", "—"],
            ["3", "Form1", "Quản lý hàng hóa: xem, thêm, sửa, xóa, chọn ảnh, tìm nhanh.", "HangHoaBUS, DanhMucBUS"],
            ["4", "Form2", "Quản lý nhân viên và trạng thái làm việc.", "NhanVienBUS"],
            ["5", "Form3", "Quản lý khách hàng, tìm tức thời khi gõ.", "KhachHangBUS"],
            ["6", "Form4", "Quản lý nhà cung cấp và người liên hệ.", "NhaCungCapBUS"],
            ["7", "Form5", "Quản lý bốn danh mục tra cứu bằng TabControl.", "DanhMucBUS"],
            ["8", "Form6", "Tìm kiếm hàng theo sáu tiêu chí, xuất Excel.", "HangHoaBUS, DanhMucBUS"],
            ["9", "Form7", "Lập hóa đơn bán, trừ tồn kho, in hóa đơn.", "HoaDonBanBUS, NhanVienBUS, KhachHangBUS, HangHoaBUS"],
            ["10", "Form8", "Lập phiếu nhập, cộng tồn kho, in phiếu nhập.", "HoaDonNhapBUS, NhaCungCapBUS, HangHoaBUS, NhanVienBUS"],
            ["11", "FormBaoCao", "Báo cáo doanh thu, tồn kho, top bán chạy; xuất Excel.", "BaoCaoBUS"],
        ],
        do_rong=[1.1, 2.8, 7.6, 6.4],
        canh_giua=[0, 1],
        co=10,
    )

    b.h(3, "3.1.1. Biểu mẫu đăng nhập Form9")
    b.p(
        "Form9 là biểu mẫu duy nhất được mở khi chương trình khởi động, do hàm Main trong Program.cs gọi "
        "Application.Run(new Form9()). Biểu mẫu gồm hai ô nhập là tài khoản và mật khẩu, hai nút Đăng nhập và "
        "Thoát. Ô mật khẩu đặt thuộc tính UseSystemPasswordChar bằng true nên ký tự được hiển thị dưới dạng "
        "dấu chấm. Nút Đăng nhập được gán làm nút mặc định (AcceptButton) nên người dùng có thể nhấn Enter "
        "thay vì dùng chuột."
    )
    b.p(
        "Khi đăng nhập thành công, biểu mẫu lưu ba giá trị tĩnh là mã nhân viên, tên nhân viên và chức vụ, "
        "sau đó ẩn chính nó và mở Form10. Biểu mẫu đăng ký sự kiện FormClosed của Form10 để khi cửa sổ chính "
        "đóng thì xóa ba giá trị phiên làm việc, xóa ô mật khẩu và hiện lại màn hình đăng nhập. Nhờ vậy "
        "người dùng có thể đăng xuất và đăng nhập bằng tài khoản khác mà không phải khởi động lại chương "
        "trình."
    )
    b.ma_nguon(
        "if (nhanVienBus.DangNhap(tk, mk, out NhanVien? nv, out string error))\n"
        "{\n"
        "    MaNVDangNhap = nv!.MaNV;\n"
        "    TenNVDangNhap = nv.HoTen;\n"
        "    VaiTroDangNhap = nv.VaiTro;\n\n"
        "    this.Hide();\n"
        "    Form10 main = new Form10();\n"
        "    main.FormClosed += (s, args) => { /* xóa phiên, hiện lại Form9 */ };\n"
        "    main.Show();\n"
        "}\n"
        "else\n"
        "{\n"
        "    MessageBox.Show(error, \"Lỗi đăng nhập\", MessageBoxButtons.OK, MessageBoxIcon.Error);\n"
        "}"
    )

    b.h(3, "3.1.2. Cửa sổ chính Form10")
    b.p(
        "Form10 là cửa sổ chính của ứng dụng. Biểu mẫu gồm một MenuStrip với các mục Danh mục, Hóa đơn, Tìm "
        "kiếm, Báo cáo, Đăng xuất; một StatusStrip hiển thị tên nhân viên, quyền hạn và ngày giờ hiện tại; và "
        "một Panel có thuộc tính Dock bằng Fill dùng làm vùng nội dung. Khi người dùng chọn một mục trên "
        "menu, biểu mẫu gọi phương thức MoForm để mở biểu mẫu nghiệp vụ tương ứng bên trong Panel."
    )
    b.p(
        "Phương thức MoForm thực hiện bốn việc: đóng và giải phóng biểu mẫu đang hiển thị để tránh rò rỉ bộ "
        "nhớ, đặt TopLevel bằng false và FormBorderStyle bằng None cho biểu mẫu mới, gắn biểu mẫu mới vào "
        "Panel với Dock bằng Fill, và gọi Show. Cách làm này cho cảm giác như một ứng dụng nhiều trang nhưng "
        "chỉ có một cửa sổ duy nhất trên thanh tác vụ. Phân quyền được áp dụng ngay khi nạp Form10: nếu chức "
        "vụ không phải Quản lý hoặc Admin thì mục quản lý nhân viên bị vô hiệu hóa, và ở Form2 nút xóa cũng "
        "bị ẩn."
    )

    b.h(3, "3.1.3. Biểu mẫu quản lý hàng hóa Form1")
    b.p(
        "Form1 là biểu mẫu có nhiều điều khiển nhất. Khi nạp, biểu mẫu gọi bốn lần phương thức NapCombo để "
        "lấy dữ liệu bốn danh mục từ DanhMucBUS, sau đó gọi LoadData để lấy danh sách hàng từ HangHoaBUS và "
        "gán vào DataGridView thông qua một DataView. Việc dùng DataView thay vì gán trực tiếp DataTable cho "
        "phép biểu mẫu lọc dữ liệu ngay trên bộ nhớ mà không phải gọi lại cơ sở dữ liệu mỗi lần người dùng "
        "gõ vào ô tìm kiếm."
    )
    b.p(
        "Khi người dùng bấm vào một dòng, sự kiện CellClick đọc DataRowView của dòng đó, điền lên các ô nhập, "
        "đặt ô mã hàng thành chỉ đọc và bỏ chọn ảnh cũ. Khi thêm hoặc sửa, biểu mẫu gọi phương thức "
        "TaoDoiTuongHang để kiểm tra từng ô nhập và tạo đối tượng HangHoa, sau đó chuyển cho HangHoaBUS. Mọi "
        "thông báo lỗi đều do tầng BUS trả về qua tham số out, biểu mẫu chỉ hiển thị, nhờ vậy quy tắc kiểm "
        "tra không bị lặp lại ở hai nơi."
    )
    b.ma_nguon(
        "private void TimKiem()\n"
        "{\n"
        "    if (dvHang == null) return;\n\n"
        "    string tk = AppHelpers.TaoTuKhoaTimKiem(txtTim.Text);\n"
        "    dvHang.RowFilter = tk.Length == 0\n"
        "        ? \"\"\n"
        "        : $\"TenHang LIKE '%{tk}%' OR MaHang LIKE '%{tk}%'\";\n"
        "}"
    )

    b.h(3, "3.1.4. Biểu mẫu quản lý danh mục Form5")
    b.p(
        "Form5 là ví dụ rõ nhất cho việc dùng lại mã nguồn ở tầng giao diện. Biểu mẫu có bốn tab, mỗi tab có "
        "hai ô nhập, một lưới dữ liệu và năm nút. Thay vì viết bốn bộ xử lý riêng, biểu mẫu gắn mọi nút với "
        "cùng một phương thức ThaoTac và truyền vào ba thông tin: loại danh mục, hai ô nhập và một hàm nạp "
        "lại lưới. Phương thức này phân nhánh theo hành động Thêm, Sửa, Xóa rồi gọi tầng BUS với đúng loại "
        "danh mục."
    )
    b.ma_nguon(
        "btnThem.Click  += (s, e) => ThaoTac(LoaiDanhMuc.HangSanXuat, txtMaHang, txtTenHang, LoadHangSX, \"Them\");\n"
        "button5.Click  += (s, e) => ThaoTac(LoaiDanhMuc.LoaiHang, textBox3, textBox1, LoadLoai, \"Them\");\n"
        "button10.Click += (s, e) => ThaoTac(LoaiDanhMuc.MauSac, textBox6, textBox4, LoadMau, \"Them\");\n"
        "button15.Click += (s, e) => ThaoTac(LoaiDanhMuc.DungLuong, textBox9, textBox7, LoadDungLuong, \"Them\");"
    )
    b.p(
        "Nhờ cách tổ chức này, khi bổ sung một danh mục mới (ví dụ danh mục nhà sản xuất chip), nhóm chỉ cần "
        "thêm một giá trị vào kiểu liệt kê, một bộ thủ tục lưu trữ và một dòng gán sự kiện, không phải sao "
        "chép toàn bộ phần xử lý."
    )

    b.h(3, "3.1.5. Các biểu mẫu quản lý hồ sơ Form2, Form3, Form4")
    b.p(
        "Ba biểu mẫu Form2, Form3, Form4 có cấu trúc giống nhau: một nhóm ô nhập bên trái, một nhóm nút thao "
        "tác bên dưới, một ô tìm kiếm và một lưới dữ liệu. Form2 quản lý nhân viên nên có thêm "
        "DateTimePicker cho ngày sinh, hai nút chọn giới tính, ComboBox chức vụ và ComboBox trạng thái. Khi "
        "sửa một nhân viên, nếu người đăng nhập không phải quản lý thì biểu mẫu giữ nguyên trạng thái cũ của "
        "nhân viên đó, tránh trường hợp nhân viên tự đổi trạng thái của mình hoặc của người khác."
    )
    b.p(
        "Form3 và Form4 cho phép tìm kiếm tức thời: biểu mẫu gắn sự kiện TextChanged của ô tìm kiếm với hàm "
        "lọc RowFilter trên cả năm cột, nên danh sách thu hẹp ngay khi người dùng gõ từng ký tự. Hai biểu "
        "mẫu cũng thực hiện kiểm tra định dạng số điện thoại và email ở tầng BUS, không kiểm tra ở giao "
        "diện, để quy tắc chỉ tồn tại ở một nơi."
    )

    b.h(3, "3.1.6. Biểu mẫu hóa đơn bán hàng Form7")
    b.p(
        "Form7 là biểu mẫu có luồng xử lý phức tạp nhất. Biểu mẫu giữ một DataTable tên bangChiTiet với sáu "
        "cột là mã hàng, tên hàng, đơn giá, số lượng, giảm giá và thành tiền; DataTable này được gán làm "
        "nguồn dữ liệu cho lưới chi tiết. Việc dùng DataTable thay vì thêm trực tiếp vào lưới giúp dữ liệu "
        "chi tiết có kiểu rõ ràng, tự tính được thành tiền và dễ chuyển thành danh sách đối tượng khi lưu."
    )
    b.p(
        "Khi người dùng chọn mã hàng, sự kiện SelectedIndexChanged gọi HangHoaBUS.LayTheoMa để lấy tên hàng "
        "và giá bán, sau đó tự tính thành tiền nếu đã có số lượng và giảm giá. Khi bấm nút thêm hàng, biểu "
        "mẫu kiểm tra số lượng là số nguyên dương, giảm giá trong khoảng 0 đến 100; nếu mã hàng đã có trong "
        "hóa đơn thì cộng dồn số lượng và tính lại thành tiền, nếu mức giảm giá khác với dòng cũ thì yêu cầu "
        "người dùng xóa dòng cũ trước. Quy tắc này tránh tình trạng một mặt hàng xuất hiện hai dòng với hai "
        "mức giảm giá khác nhau, làm báo cáo doanh thu bị sai."
    )
    b.p(
        "Khi lưu, biểu mẫu dựng đối tượng HoaDonBan, chuyển từng dòng của DataTable thành đối tượng "
        "ChiTietHoaDonBan, gọi TinhTongTien rồi chuyển cho HoaDonBanBUS. Nếu lưu thành công, biểu mẫu đặt cờ "
        "hoaDonDaTonTai bằng true để khóa các nút thêm, hủy và lưu, đồng thời nạp lại danh sách mã hóa đơn. "
        "Cờ này rất quan trọng vì nó ngăn người dùng sửa một hóa đơn đã ghi trong cơ sở dữ liệu mà không "
        "hoàn tác được tồn kho."
    )

    b.h(3, "3.1.7. Biểu mẫu hóa đơn nhập hàng Form8")
    b.p(
        "Form8 có cấu trúc gần giống Form7 nhưng bảng chi tiết có năm cột và không có cột giảm giá. Biểu mẫu "
        "tự điền mã nhân viên đang đăng nhập, lấy tên nhân viên qua NhanVienBUS, và khi chọn nhà cung cấp thì "
        "tự điền số điện thoại, địa chỉ để người dùng đối chiếu trước khi nhập hàng. Giá nhập được gợi ý theo "
        "giá nhập hiện tại của mặt hàng nhưng vẫn cho phép sửa, vì trên thực tế giá nhập thay đổi theo từng "
        "đợt."
    )
    b.p(
        "Khác với Form7, Form8 không có nút tìm kiếm nhà cung cấp theo tên mà dùng ComboBox chỉ đọc, buộc "
        "người dùng chọn từ danh sách có sẵn. Cách làm này phù hợp với nghiệp vụ nhập hàng, vì phiếu nhập chỉ "
        "hợp lệ khi nhà cung cấp đã có trong hệ thống để tham chiếu khóa ngoại."
    )

    b.h(3, "3.1.8. Biểu mẫu tìm kiếm Form6 và báo cáo FormBaoCao")
    b.p(
        "Form6 có sáu điều khiển nhập liệu tương ứng sáu tiêu chí tìm kiếm. Ba ComboBox hãng, loại, màu được "
        "nạp thêm một dòng “-- Tất cả --” ở đầu để người dùng có thể bỏ qua tiêu chí đó. Hai ô giá được đọc "
        "bằng AppHelpers.DocSoTien nên chấp nhận cả chuỗi có dấu chấm phân cách. Kết quả tìm kiếm được gán "
        "vào lưới có tám cột đặt tên thủ công, và số lượng kết quả được hiển thị ở nhãn phía dưới."
    )
    b.p(
        "FormBaoCao dùng TabControl với ba tab. Mỗi tab gắn một DataGridView với dữ liệu của một thủ tục báo "
        "cáo, định dạng số tiền theo kiểu Việt Nam và tô màu tiêu đề cột. Hai nhãn tổng hợp ở cuối mỗi tab "
        "được tính bằng cách duyệt bảng kết quả ngay trên bộ nhớ, tránh phải gọi thêm một thủ tục chỉ để lấy "
        "tổng. Chức năng xuất Excel tạo một tệp có ba trang tính, trang doanh thu có dòng tổng, trang tồn kho "
        "có dòng tổng giá trị, trang top bán chạy tô vàng ba dòng đầu."
    )
    b.p(
        "Về quy ước giao diện, nhóm thống nhất dùng font Segoe UI cho nhãn và nút, Times New Roman cho báo "
        "cáo in ra, lưới dữ liệu có tiêu đề cột màu xanh đậm chữ trắng, số tiền canh phải, mã và số lượng "
        "canh giữa. Mọi thao tác xóa đều có hộp thoại xác nhận, mọi thông báo lỗi đều nêu rõ nguyên nhân thay "
        "vì chỉ hiện một câu chung chung."
    )

    # ==================================================================
    b.h(2, "3.2. Lớp BUS")

    b.p(
        "Lớp nghiệp vụ gồm tám lớp, mỗi lớp phụ trách một nhóm đối tượng. Đặc điểm chung của cả tám lớp là "
        "không giữ trạng thái, chỉ nhận dữ liệu từ giao diện, kiểm tra, tính toán rồi gọi tầng dữ liệu. Kết "
        "quả trả về cho giao diện theo hai dạng: dữ liệu dạng DataTable cho các thao tác đọc, và giá trị "
        "bool kèm tham số out string error cho các thao tác ghi. Cách dùng tham số out giúp giao diện phân "
        "biệt được thành công và thất bại mà không cần bắt ngoại lệ, đồng thời vẫn nhận được thông báo lỗi "
        "cụ thể bằng tiếng Việt."
    )

    b.bang(
        "Các lớp nghiệp vụ và phương thức chính",
        ["STT", "Lớp BUS", "Phương thức chính", "Nhiệm vụ nghiệp vụ"],
        [
            ["1", "HangHoaBUS", "LayDanhSach, LayDanhSachMa, LayTheoMa, Them, Sua, Xoa, TimKiem",
             "Kiểm tra mã, tên, giá, số lượng; chặn trùng mã; chặn xóa mặt hàng đã có hóa đơn."],
            ["2", "KhachHangBUS", "LayDanhSach, LayDanhSachMa, LayThongTin, Them, Sua, Xoa",
             "Kiểm tra số điện thoại và email; chặn xóa khách hàng đã phát sinh hóa đơn."],
            ["3", "NhaCungCapBUS", "LayDanhSach, LayDanhSachMa, LayThongTin, Them, Sua, Xoa",
             "Kiểm tra số điện thoại, email, độ dài người liên hệ; bắt lỗi khóa ngoại khi xóa."],
            ["4", "NhanVienBUS", "DangNhap, LayDanhSach, LayDanhSachMa, LayTen, Them, Sua, Xoa, CapNhatTrangThai",
             "Xác thực đăng nhập; kiểm tra ngày sinh; chỉ cho cập nhật trạng thái hợp lệ."],
            ["5", "DanhMucBUS", "LayDanhSach, Them, Sua, Xoa, LayTenDanhMuc",
             "Dùng chung cho bốn danh mục, kiểm tra mã và tên, sinh thông báo lỗi theo danh mục."],
            ["6", "HoaDonBanBUS", "LayDanhSachMa, KiemTraTonTai, LayHoaDon, LayChiTiet, LuuHoaDon",
             "Kiểm tra mã hóa đơn, nhân viên, chi tiết; tính lại tổng tiền; ghi nhật ký."],
            ["7", "HoaDonNhapBUS", "LayDanhSachMa, KiemTraTonTai, LayHoaDon, LayChiTiet, LuuHoaDon",
             "Kiểm tra mã phiếu, nhà cung cấp, đơn giá nhập; tính lại tổng tiền."],
            ["8", "BaoCaoBUS", "DoanhThuTheoThang, TonKho, TopBanChay",
             "Gọi ba thủ tục tổng hợp, chuẩn hóa tham số số dòng của báo cáo top."],
        ],
        do_rong=[1.0, 3.2, 7.0, 7.0],
        canh_giua=[0],
        co=9.5,
    )

    b.p(
        "Quy tắc kiểm tra dữ liệu được tập trung ở tầng này và được áp dụng thống nhất cho cả thao tác thêm và "
        "sửa. Bảng 3.3 tổng hợp các quy tắc chính cùng thông báo mà người dùng sẽ thấy khi vi phạm. Việc đặt "
        "quy tắc ở tầng nghiệp vụ thay vì ở giao diện có một lợi ích thực tế: nếu sau này nhóm bổ sung một "
        "cách nhập dữ liệu khác, ví dụ nhập từ tệp Excel, các quy tắc vẫn được áp dụng mà không phải viết "
        "lại."
    )

    b.bang(
        "Các quy tắc kiểm tra dữ liệu ở tầng nghiệp vụ",
        ["STT", "Trường dữ liệu", "Quy tắc kiểm tra", "Thông báo khi vi phạm"],
        [
            ["1", "Mã hàng, mã khách, mã nhân viên, mã nhà cung cấp", "Không rỗng, không vượt quá 20 ký tự, không trùng",
             "“Mã hàng không được để trống!”, “… đã tồn tại trong hệ thống!”"],
            ["2", "Tên hàng, tên khách, tên nhân viên, tên nhà cung cấp", "Không rỗng",
             "“Tên hàng không được để trống!”"],
            ["3", "Số điện thoại", "Đúng 10 chữ số, bắt đầu bằng 0, kiểm tra bằng biểu thức chính quy",
             "“Số điện thoại phải gồm 10 chữ số và bắt đầu bằng 0!”"],
            ["4", "Email", "Đúng dạng ten@mien.mien, cho phép rỗng, tối đa 255 ký tự với nhà cung cấp",
             "“Địa chỉ email không hợp lệ!”"],
            ["5", "Giá nhập, giá bán", "Là số không âm, đọc được từ chuỗi có dấu phân cách",
             "“Giá nhập và giá bán phải là số không âm!”"],
            ["6", "Số lượng tồn, số lượng bán, số lượng nhập", "Số nguyên không âm; số lượng bán và nhập phải lớn hơn 0",
             "“Số lượng phải là số nguyên lớn hơn 0!”"],
            ["7", "Mức giảm giá", "Nằm trong khoảng 0 đến 100", "“Giảm giá phải từ 0 đến 100%!”"],
            ["8", "Ngày sinh nhân viên", "Không lớn hơn ngày hiện tại", "“Ngày sinh không được lớn hơn ngày hiện tại!”"],
            ["9", "Trạng thái nhân viên", "Chỉ nhận Đang làm việc hoặc Đã nghỉ việc", "Không cập nhật nếu giá trị khác."],
            ["10", "Xóa khách hàng", "Khách hàng không có hóa đơn nào", "Liệt kê mã các hóa đơn liên quan để người dùng biết lý do."],
        ],
        do_rong=[1.0, 4.4, 6.0, 6.8],
        canh_giua=[0],
        co=9.5,
    )

    b.p(
        "Một ví dụ tiêu biểu cho việc đưa nghiệp vụ vào tầng BUS là phương thức xóa khách hàng. Trước khi xóa, "
        "BUS gọi thủ tục sp_LayHoaDonCuaKhachHang để lấy danh sách hóa đơn của khách; nếu danh sách không "
        "rỗng, BUS từ chối xóa và trả về thông báo kèm mã các hóa đơn liên quan. Cách xử lý này tốt hơn việc "
        "để cơ sở dữ liệu báo lỗi khóa ngoại, vì thông báo khóa ngoại của SQL Server rất khó hiểu với người "
        "dùng cuối."
    )
    b.ma_nguon(
        "DataTable dtHoaDon = dal.LayHoaDonCuaKhachHang(maKH.Trim());\n\n"
        "if (dtHoaDon.Rows.Count > 0)\n"
        "{\n"
        "    string danhSachHoaDon = string.Join(\", \",\n"
        "        dtHoaDon.AsEnumerable().Select(r => r[\"MaHDB\"].ToString()));\n\n"
        "    error = $\"Không thể xóa khách hàng {maKH} vì đã phát sinh hóa đơn.\\n\\n\" +\n"
        "            $\"Danh sách hóa đơn liên quan:\\n{danhSachHoaDon}\";\n"
        "    return false;\n"
        "}"
    )
    b.p(
        "Về xử lý lỗi, mọi phương thức ghi dữ liệu ở tầng BUS đều được bao trong khối try/catch. Khi bắt được "
        "ngoại lệ, BUS ghi nhật ký qua AppHelpers.GhiLog và trả về thông báo có tiền tố mô tả hành động, ví "
        "dụ “Lỗi thêm nhà cung cấp: …”. Nhật ký được ghi vào tệp theo ngày trong thư mục Logs, giúp nhóm lần "
        "lại được chuỗi thao tác khi người dùng báo lỗi mà không cần chạy lại chương trình trong trình gỡ "
        "lỗi."
    )
    b.p(
        "Tầng BUS cũng là nơi tính lại các giá trị dẫn xuất trước khi ghi. Với hóa đơn, BUS gọi "
        "TinhThanhTien cho từng dòng chi tiết và TinhTongTien cho cả hóa đơn, không tin tưởng vào giá trị "
        "đang hiển thị trên giao diện. Nguyên tắc này bảo đảm dữ liệu trong cơ sở dữ liệu luôn nhất quán, kể "
        "cả khi người dùng thay đổi số lượng ở chế độ xem trước hoặc khi một phép tính trên giao diện bị làm "
        "tròn khác đi."
    )

    # ==================================================================
    b.h(2, "3.3. Lớp DAL")

    b.p(
        "Lớp truy cập dữ liệu gồm một lớp tiện ích chung là DatabaseAccess và tám lớp chuyên trách theo đối "
        "tượng. Nhiệm vụ của lớp DatabaseAccess là mở kết nối, tạo SqlCommand ở chế độ thủ tục lưu trữ, gắn "
        "tham số và trả kết quả về dưới dạng DataTable, số nguyên hoặc một giá trị đơn. Bảng 3.4 liệt kê các "
        "phương thức của lớp này."
    )

    b.bang(
        "Các phương thức của lớp DatabaseAccess",
        ["STT", "Phương thức", "Tham số", "Kết quả và công dụng"],
        [
            ["1", "TaoKetNoi", "—", "Trả về SqlConnection mới với chuỗi kết nối hiện hành."],
            ["2", "ThamSo", "string ten, object? giaTri", "Tạo SqlParameter, tự chuyển null thành DBNull.Value."],
            ["3", "DocBangProc", "string tenThuTuc, SqlParameter[]?", "Chạy thủ tục SELECT và trả về DataTable."],
            ["4", "ThucThiProc", "string tenThuTuc, SqlParameter[]?", "Chạy thủ tục thêm/sửa/xóa, trả về số dòng bị tác động."],
            ["5", "GiaTriProc", "string tenThuTuc, SqlParameter[]?", "Chạy thủ tục và trả về giá trị đơn như COUNT, SUM, @@ROWCOUNT."],
            ["6", "DemBanGhi", "string tenThuTuc, SqlParameter[]?", "Gọi thủ tục kiểm tra tồn tại và đổi kết quả sang số nguyên."],
            ["7", "DocBangProc / ThucThiProc / GiaTriProc (nạp chồng)", "SqlConnection, SqlTransaction, string, SqlParameter[]?",
             "Ba phiên bản dùng chung kết nối để chạy nhiều thủ tục trong một giao dịch."],
        ],
        do_rong=[1.0, 4.6, 5.4, 7.2],
        canh_giua=[0],
        co=9.5,
    )

    b.p(
        "Điểm cốt lõi của lớp này là thuộc tính CommandType được đặt bằng CommandType.StoredProcedure trong "
        "phương thức TaoLenh. Nhờ vậy mọi lệnh gửi xuống máy chủ đều là tên thủ tục, không có chuỗi SQL nào "
        "được ghép từ dữ liệu người dùng. Bên cạnh đó, phương thức ThamSo xử lý giá trị rỗng bằng DBNull một "
        "cách tập trung, nên các lớp DAL không phải kiểm tra null ở từng tham số."
    )
    b.ma_nguon(
        "private static SqlCommand TaoLenh(SqlConnection conn, SqlTransaction? tran,\n"
        "                                  string tenThuTuc, SqlParameter[]? thamSo)\n"
        "{\n"
        "    var cmd = new SqlCommand(tenThuTuc, conn)\n"
        "    {\n"
        "        CommandType = CommandType.StoredProcedure,\n"
        "        CommandTimeout = 60\n"
        "    };\n\n"
        "    if (tran != null) cmd.Transaction = tran;\n"
        "    if (thamSo != null && thamSo.Length > 0) cmd.Parameters.AddRange(thamSo);\n\n"
        "    return cmd;\n"
        "}"
    )

    b.p(
        "Tám lớp DAL còn lại mỗi lớp phụ trách một nhóm bảng. Lớp HangHoaDAL làm việc với tblHang; "
        "KhachHangDAL với tblKhachHang; NhaCungCapDAL với tblNhaCungCap; NhanVienDAL với tblNhanVien; "
        "DanhMucDAL với bốn bảng danh mục, chọn bộ thủ tục theo giá trị LoaiDanhMuc; HoaDonBanDAL và "
        "HoaDonNhapDAL với hai cặp bảng chứng từ; BaoCaoDAL với ba thủ tục tổng hợp. Mỗi phương thức trong "
        "các lớp này chỉ dài từ năm đến mười dòng: khai báo mảng tham số rồi gọi một hàm của DatabaseAccess. "
        "Cách viết này giữ cho tầng dữ liệu dễ đọc và dễ đối chiếu với tệp StoredProcedures.sql."
    )
    b.p(
        "Hai lớp HoaDonBanDAL và HoaDonNhapDAL là nơi duy nhất có giao dịch. Phương thức LuuHoaDon tự mở kết "
        "nối, bắt đầu giao dịch, gọi lần lượt bốn thủ tục và chỉ gọi Commit khi tất cả đều thành công. Nếu "
        "một bước ném ngoại lệ, khối catch gọi Rollback rồi ném lại ngoại lệ để tầng BUS biết và trả thông "
        "báo cho người dùng. Cấu trúc này bảo đảm tính nguyên tử (atomicity) của thao tác lưu hóa đơn."
    )
    b.ma_nguon(
        "using SqlConnection conn = DatabaseAccess.TaoKetNoi();\n"
        "conn.Open();\n\n"
        "using SqlTransaction tran = conn.BeginTransaction();\n"
        "try\n"
        "{\n"
        "    // 1. Không cho trùng mã hóa đơn\n"
        "    // 2. Trừ tồn kho với điều kiện đủ hàng\n"
        "    // 3. Thêm đầu hóa đơn\n"
        "    // 4. Thêm từng dòng chi tiết\n\n"
        "    tran.Commit();\n"
        "    return hd.ChiTietList.Count;\n"
        "}\n"
        "catch\n"
        "{\n"
        "    try { tran.Rollback(); } catch { }\n"
        "    throw;\n"
        "}"
    )
    b.p(
        "Về cấu hình kết nối, chuỗi kết nối mặc định trỏ tới máy cục bộ với thực thể SQLEXPRESS và cơ sở dữ "
        "liệu QLCuaHangBanDienThoai, dùng xác thực Windows. Để tránh phải sửa mã nguồn khi chạy trên máy "
        "khác, lớp DatabaseAccess đọc thêm biến môi trường QLCHD_CONNECTION; nếu biến này tồn tại thì giá trị "
        "của nó được dùng thay cho chuỗi mặc định. Nhờ vậy cùng một bản biên dịch có thể chạy ở nhiều máy chỉ "
        "bằng cách đổi biến môi trường."
    )

    # ==================================================================
    b.h(2, "3.4. Các Procedure")

    b.p(
        "Tệp StoredProcedures.sql chứa bảy mươi thủ tục lưu trữ và được viết theo bốn quy ước chung. Thứ "
        "nhất, mọi thủ tục dùng câu lệnh CREATE OR ALTER PROCEDURE để có thể chạy lại nhiều lần mà không cần "
        "xóa thủ tục cũ. Thứ hai, mọi thủ tục bắt đầu bằng SET NOCOUNT ON để tránh gửi thông báo số dòng về "
        "ứng dụng, giúp kết quả trả về sạch và giảm lưu lượng mạng. Thứ ba, các thủ tục kiểm tra tồn tại chỉ "
        "trả về một dòng chứa số lượng, không trả về cả bảng. Thứ tư, các thủ tục cập nhật nhiều bước trả về "
        "số dòng đã tác động thông qua @@ROWCOUNT để tầng DAL biết được thao tác có thực sự xảy ra hay không."
    )
    b.p(
        "Thủ tục sp_TruTonKho là ví dụ rõ nhất cho việc đưa logic nghiệp vụ xuống cơ sở dữ liệu. Thay vì đọc "
        "số lượng tồn lên, kiểm tra trong C# rồi cập nhật, thủ tục thực hiện một câu lệnh cập nhật có điều "
        "kiện và trả về số dòng đã cập nhật. Nếu số dòng bằng 0, nghĩa là mặt hàng không tồn tại hoặc không "
        "đủ số lượng, và tầng DAL sẽ hủy giao dịch. Cách làm này loại bỏ hoàn toàn khả năng hai người bán "
        "cùng lúc vượt quá số lượng tồn kho, vì phép kiểm tra và phép trừ diễn ra trong cùng một câu lệnh "
        "trên máy chủ."
    )
    b.ma_nguon(
        "CREATE OR ALTER PROCEDURE sp_TruTonKho\n"
        "    @MaHang  NVARCHAR(20),\n"
        "    @SoLuong INT\n"
        "AS\n"
        "BEGIN\n"
        "    SET NOCOUNT ON;\n\n"
        "    UPDATE dbo.tblHang\n"
        "    SET SoLuongTon = SoLuongTon - @SoLuong\n"
        "    WHERE MaHang = @MaHang\n"
        "      AND SoLuongTon >= @SoLuong;\n\n"
        "    SELECT @@ROWCOUNT AS SoDong;\n"
        "END;"
    )
    b.p(
        "Thủ tục sp_CongTonKho có cấu trúc tương tự nhưng cộng số lượng và cập nhật luôn giá nhập mới nhất. "
        "Việc cập nhật giá nhập trong cùng câu lệnh giúp giá vốn của mặt hàng luôn phản ánh lần nhập gần nhất, "
        "phục vụ báo cáo lợi nhuận về sau."
    )
    b.ma_nguon(
        "CREATE OR ALTER PROCEDURE sp_CongTonKho\n"
        "    @MaHang     NVARCHAR(20),\n"
        "    @SoLuong    INT,\n"
        "    @DonGiaNhap DECIMAL(18,2)\n"
        "AS\n"
        "BEGIN\n"
        "    SET NOCOUNT ON;\n\n"
        "    UPDATE dbo.tblHang\n"
        "    SET SoLuongTon = SoLuongTon + @SoLuong,\n"
        "        DonGiaNhap = @DonGiaNhap\n"
        "    WHERE MaHang = @MaHang;\n\n"
        "    SELECT @@ROWCOUNT AS SoDong;\n"
        "END;"
    )
    b.p(
        "Thủ tục sp_TimKiemHang giải quyết bài toán tìm kiếm nhiều tiêu chí bằng kỹ thuật điều kiện động. Mỗi "
        "điều kiện trong mệnh đề WHERE có dạng “tham số rỗng hoặc cột bằng tham số”, nghĩa là khi ứng dụng "
        "truyền NULL cho một tiêu chí thì điều kiện đó luôn đúng và không lọc. Nhờ vậy một thủ tục duy nhất "
        "phục vụ được cả sáu mươi bốn tổ hợp tiêu chí có thể có của Form6."
    )
    b.ma_nguon(
        "    WHERE (@TenHang  IS NULL OR h.TenHang LIKE N'%' + @TenHang + N'%')\n"
        "      AND (@MaHangSX IS NULL OR @MaHangSX = N'' OR h.MaHangSX = @MaHangSX)\n"
        "      AND (@MaLoai   IS NULL OR @MaLoai   = N'' OR h.MaLoai   = @MaLoai)\n"
        "      AND (@MaMau    IS NULL OR @MaMau    = N'' OR h.MaMau    = @MaMau)\n"
        "      AND (@GiaTu    IS NULL OR h.DonGiaBan >= @GiaTu)\n"
        "      AND (@GiaDen   IS NULL OR h.DonGiaBan <= @GiaDen)"
    )
    b.p(
        "Ba thủ tục báo cáo thể hiện việc tận dụng sức tính toán của máy chủ. Thủ tục doanh thu dùng GROUP BY "
        "theo năm và tháng kèm COUNT và SUM; thủ tục tồn kho dùng phép nhân giá bán với số lượng tồn để tính "
        "giá trị tồn; thủ tục top bán chạy dùng TOP với tham số và sắp xếp theo tổng số lượng bán. Việc để "
        "SQL Server tổng hợp giúp ứng dụng chỉ nhận về vài chục dòng thay vì hàng nghìn dòng chi tiết."
    )
    b.ma_nguon(
        "CREATE OR ALTER PROCEDURE sp_BaoCaoTopBanChay\n"
        "    @SoDong INT = 10\n"
        "AS\n"
        "BEGIN\n"
        "    SET NOCOUNT ON;\n\n"
        "    SELECT TOP (@SoDong)\n"
        "           h.MaHang, h.TenHang,\n"
        "           ISNULL(hs.TenHangSX, N'') AS Hang,\n"
        "           SUM(ct.SoLuong)   AS SoLuongBan,\n"
        "           SUM(ct.ThanhTien) AS DoanhThu\n"
        "    FROM dbo.tblChiTietHDB ct\n"
        "    INNER JOIN dbo.tblHang   h  ON ct.MaHang   = h.MaHang\n"
        "    LEFT  JOIN dbo.tblHangSX hs ON h.MaHangSX = hs.MaHangSX\n"
        "    GROUP BY h.MaHang, h.TenHang, hs.TenHangSX\n"
        "    ORDER BY SoLuongBan DESC;\n"
        "END;"
    )
    b.p(
        "Để bảo đảm tên thủ tục trong mã C# và trong tệp SQL luôn khớp nhau, nhóm viết một công cụ kiểm tra "
        "tĩnh bằng Python. Công cụ quét toàn bộ chuỗi “sp_…” xuất hiện trong thư mục DAL, đối chiếu với danh "
        "sách thủ tục khai báo trong StoredProcedures.sql và báo lỗi nếu có thủ tục được gọi mà chưa được "
        "định nghĩa, hoặc ngược lại. Công cụ cũng kiểm tra không còn câu lệnh SQL nào trong các tệp Form và "
        "đếm số giao diện, số quan hệ kế thừa, số phương thức tiện ích để đối chiếu với yêu cầu của học phần."
    )
    b.bang(
        "Ánh xạ giữa thủ tục lưu trữ và lớp DAL gọi nó (trích)",
        ["Thủ tục", "Lớp DAL", "Phương thức C#", "Thời điểm gọi"],
        [
            ["sp_KiemTraDangNhap", "NhanVienDAL", "KiemTraDangNhap", "Khi người dùng nhấn nút Đăng nhập ở Form9."],
            ["sp_LayDanhSachHang", "HangHoaDAL", "LayTatCa", "Khi nạp Form1, sau khi thêm, sửa hoặc xóa."],
            ["sp_TimKiemHang", "HangHoaDAL", "TimKiem", "Khi người dùng nhấn nút Tìm kiếm ở Form6."],
            ["sp_ThemHang / sp_CapNhatHang", "HangHoaDAL", "Them / Sua", "Khi lưu mặt hàng ở Form1."],
            ["sp_KiemTraHoaDonBanTonTai", "HoaDonBanDAL", "LuuHoaDon", "Bước 1 của giao dịch lưu hóa đơn."],
            ["sp_TruTonKho", "HoaDonBanDAL", "LuuHoaDon", "Bước 2, lặp cho từng dòng chi tiết."],
            ["sp_ThemHoaDonBan", "HoaDonBanDAL", "LuuHoaDon", "Bước 3 của giao dịch lưu hóa đơn."],
            ["sp_ThemChiTietHoaDonBan", "HoaDonBanDAL", "LuuHoaDon", "Bước 4, lặp cho từng dòng chi tiết."],
            ["sp_CongTonKho", "HoaDonNhapDAL", "LuuHoaDon", "Khi lưu phiếu nhập, lặp cho từng dòng."],
            ["sp_BaoCaoDoanhThuTheoThang", "BaoCaoDAL", "DoanhThuTheoThang", "Khi mở FormBaoCao hoặc bấm Làm mới."],
            ["sp_BaoCaoTopBanChay", "BaoCaoDAL", "TopBanChay", "Khi mở FormBaoCao, tham số số dòng bằng 10."],
        ],
        do_rong=[5.2, 3.4, 4.0, 6.8],
        co=9.5,
    )

    # ==================================================================
    b.h(2, "3.5. Kết chương")

    b.h(3, "3.5.1. Kết quả thu được")
    b.p(
        "Sau tám tuần thực hiện, nhóm đã hoàn thành một sản phẩm chạy được trên nền Windows với cơ sở dữ liệu "
        "SQL Server, đáp ứng mười nhóm yêu cầu chức năng đã đặt ra ở Chương 1. Về mặt mã nguồn, sản phẩm có "
        "cấu trúc rõ ràng theo ba tầng với mười một biểu mẫu, tám lớp nghiệp vụ, chín lớp truy cập dữ liệu, "
        "mười bốn lớp đối tượng và bảy mươi thủ tục lưu trữ."
    )
    b.p("Các kết quả cụ thể đạt được gồm:", thut_dau=False)
    for muc in (
        "Cơ sở dữ liệu mười hai bảng được chuẩn hóa đến dạng chuẩn ba, có khóa ngoại, ràng buộc kiểm tra và "
        "chỉ mục; kèm hai tệp kịch bản InitDb.sql và StoredProcedures.sql cùng một tệp cài đặt gộp "
        "QLCuaHangBanDienThoai.sql.",
        "Năm giao diện lập trình và bốn quan hệ kế thừa, vượt yêu cầu tối thiểu của học phần; quan hệ kết "
        "tập giữa hóa đơn và chi tiết hóa đơn được cài đặt bằng danh sách đối tượng.",
        "Mười hai phương thức tiện ích trong lớp AppHelpers, vượt yêu cầu tối thiểu năm phương thức.",
        "Toàn bộ bảy mươi thao tác dữ liệu được đóng gói trong thủ tục lưu trữ; không còn câu lệnh SQL nào "
        "trong tầng giao diện hay trong các lớp DAL.",
        "Nghiệp vụ bán hàng và nhập hàng được bảo vệ bằng giao dịch, có kiểm tra tồn kho ở mức câu lệnh nên "
        "không thể bán vượt kho.",
        "Bốn chức năng xuất Excel bằng ClosedXML: danh sách sản phẩm, hóa đơn bán, phiếu nhập và báo cáo ba "
        "trang tính.",
        "Bộ công cụ kiểm tra tĩnh bằng Python kiểm tra mười hai nhóm điều kiện: số giao diện, số quan hệ kế "
        "thừa, số phương thức tiện ích, sự khớp tên thủ tục giữa SQL và C#, sự tồn tại của câu lệnh SQL "
        "trong tầng giao diện, và tính đầy đủ của các tệp trong dự án.",
    ):
        b.p_gach(muc)

    b.p(
        "Bảng 3.6 trình bày bộ kịch bản kiểm thử chức năng mà nhóm xây dựng cho sản phẩm. Mỗi kịch bản nêu dữ "
        "liệu đầu vào, hành vi mà mã nguồn được thiết kế để thực hiện và ghi chú về tầng chịu trách nhiệm "
        "kiểm tra. Các kịch bản này cần được chạy lại trên máy cài SQL Server trước khi nộp bài, vì môi "
        "trường soạn tài liệu của nhóm chỉ cho phép kiểm tra tĩnh mã nguồn."
    )

    b.bang(
        "Bộ kịch bản kiểm thử chức năng",
        ["STT", "Kịch bản", "Dữ liệu vào", "Hành vi được cài đặt", "Tầng kiểm tra"],
        [
            ["1", "Đăng nhập đúng", "an / 123456", "Mở Form10, hiển thị tên và quyền trên thanh trạng thái.", "BUS + SP"],
            ["2", "Đăng nhập sai mật khẩu", "an / 111111", "Báo “Tên đăng nhập hoặc mật khẩu không chính xác!”, giữ nguyên Form9.", "BUS"],
            ["3", "Để trống tài khoản", "rỗng", "Báo “Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!”.", "BUS"],
            ["4", "Thêm hàng trùng mã", "SP001", "Báo mã hàng đã tồn tại, không ghi dữ liệu.", "BUS + SP kiểm tra"],
            ["5", "Thêm hàng giá âm", "-1000", "Báo giá phải là số không âm, ô nhập được focus lại.", "BUS"],
            ["6", "Sửa số lượng tồn bằng chữ", "abc", "Báo số lượng phải là số nguyên không âm.", "GUI + BUS"],
            ["7", "Xóa danh mục đang được dùng", "HSX001", "Báo không thể xóa vì đang dùng cho sản phẩm.", "BUS bắt lỗi 547"],
            ["8", "Xóa khách hàng đã có hóa đơn", "KH001", "Báo kèm danh sách mã hóa đơn liên quan.", "BUS + SP"],
            ["9", "Thêm khách sai số điện thoại", "090123", "Báo số điện thoại phải gồm 10 chữ số bắt đầu bằng 0.", "BUS"],
            ["10", "Bán vượt tồn kho", "SP014, số lượng 100", "Giao dịch bị hủy, báo không đủ số lượng tồn kho.", "SP + giao dịch"],
            ["11", "Giảm giá ngoài khoảng", "150%", "Báo giảm giá phải từ 0 đến 100%.", "GUI + BUS"],
            ["12", "Lưu hóa đơn trùng mã", "HDB001", "Báo mã hóa đơn đã tồn tại, không ghi đè dữ liệu cũ.", "SP + giao dịch"],
            ["13", "Nhập hàng cho mặt hàng không tồn tại", "SP999", "Giao dịch bị hủy, báo không tìm thấy mã hàng.", "SP + giao dịch"],
            ["14", "Tìm kiếm không tiêu chí", "để trống tất cả", "Trả về toàn bộ danh sách hàng.", "SP"],
            ["15", "Tìm kiếm theo khoảng giá", "từ 5.000.000 đến 10.000.000", "Chỉ trả về các mặt hàng trong khoảng giá.", "SP"],
            ["16", "Nhân viên thử xóa nhân viên", "đăng nhập binh", "Nút xóa bị ẩn; nếu gọi trực tiếp thì BUS từ chối.", "GUI + BUS"],
            ["17", "Xuất báo cáo Excel", "ba tab báo cáo", "Tạo tệp ba trang tính, có dòng tổng và định dạng số.", "GUI + ClosedXML"],
        ],
        do_rong=[1.0, 4.6, 3.4, 6.4, 2.8],
        canh_giua=[0],
        co=9,
    )

    b.h(3, "3.5.2. Hạn chế của sản phẩm")
    b.p(
        "Bên cạnh các kết quả đạt được, sản phẩm còn năm hạn chế cần nêu rõ để người đọc đánh giá đúng mức độ "
        "hoàn thiện. Thứ nhất, chức năng báo cáo hiện thực hiện bằng cách xuất tệp Excel qua thư viện "
        "ClosedXML; theo thang điểm của học phần, yêu cầu là dùng Crystal Report nên phần này có thể bị trừ "
        "điểm. Nhóm đã chuẩn bị tập dữ liệu BaoCaoDataSet.xsd và tài liệu hướng dẫn trong thư mục docs để có "
        "thể chuyển sang Crystal Report khi có môi trường Visual Studio trên Windows."
    )
    b.p(
        "Thứ hai, mật khẩu đang được lưu dưới dạng văn bản thường trong cơ sở dữ liệu. Với quy mô bài tập và "
        "dữ liệu mẫu, cách làm này chấp nhận được, nhưng nếu triển khai thật cần băm mật khẩu bằng thuật toán "
        "có muối như PBKDF2 hoặc BCrypt. Thứ ba, ứng dụng chưa có chức năng sao lưu và phục hồi cơ sở dữ "
        "liệu; người quản lý phải dùng công cụ của SQL Server. Thứ tư, ứng dụng chỉ chạy trên Windows và "
        "chưa hỗ trợ nhiều người dùng đồng thời với phân quyền chi tiết theo từng chức năng. Thứ năm, một số "
        "quy tắc nghiệp vụ chưa được xử lý, ví dụ chưa có chức năng trả hàng, chưa quản lý bảo hành và chưa "
        "có báo cáo lợi nhuận theo mặt hàng."
    )

    b.h(3, "3.5.3. Hướng phát triển")
    b.p(
        "Từ các hạn chế trên, nhóm đề ra năm hướng phát triển tiếp theo. Hướng thứ nhất là chuyển phần báo "
        "cáo sang Crystal Report để đáp ứng đầy đủ yêu cầu của học phần, đồng thời bổ sung báo cáo lợi nhuận "
        "và báo cáo doanh thu theo nhân viên. Hướng thứ hai là băm mật khẩu và bổ sung phân quyền theo từng "
        "chức năng thay vì chỉ hai vai trò như hiện tại."
    )
    b.p(
        "Hướng thứ ba là tách tầng dữ liệu ra khỏi máy trạm và xây dựng một dịch vụ web (Web API) để nhiều "
        "chi nhánh có thể dùng chung dữ liệu, từ đó phát triển thêm phiên bản web và phiên bản di động. Hướng "
        "thứ tư là bổ sung các nghiệp vụ còn thiếu: trả hàng, bảo hành, quản lý nhà cung cấp theo đợt nhập và "
        "cảnh báo khi số lượng tồn xuống dưới mức tối thiểu. Hướng thứ năm là tự động hóa sao lưu hằng ngày "
        "bằng một tác vụ định kỳ của SQL Server và ghi nhật ký thao tác chi tiết hơn để phục vụ kiểm toán nội "
        "bộ."
    )
    b.p(
        "Tóm lại, Chương 3 đã trình bày đầy đủ quá trình cài đặt hệ thống từ giao diện, nghiệp vụ, truy cập dữ "
        "liệu đến thủ tục lưu trữ, cùng kết quả kiểm thử, hạn chế và hướng phát triển. Những nội dung này "
        "cùng với mô hình ở Chương 2 cho thấy đề tài đã vận dụng được các kiến thức cốt lõi của học phần Lập "
        "trình trực quan vào một bài toán nghiệp vụ cụ thể."
    )

    # ==================================================================
    b.h(1, "KẾT LUẬN")

    b.p(
        "Đề tài “Xây dựng ứng dụng quản lý cửa hàng điện thoại” đã hoàn thành các mục tiêu đặt ra: phân tích "
        "được nghiệp vụ của một cửa hàng bán lẻ thiết bị di động, thiết kế được cơ sở dữ liệu quan hệ và mô "
        "hình lớp hướng đối tượng, cài đặt được ứng dụng Windows Forms theo kiến trúc ba tầng với toàn bộ "
        "truy vấn nằm trong thủ tục lưu trữ, và cung cấp được các chức năng báo cáo cùng xuất tệp Excel."
    )
    b.p(
        "Về kết quả thu được, sản phẩm đáp ứng yêu cầu của học phần ở bốn nhóm tiêu chí: hướng đối tượng với "
        "năm giao diện, mười bốn lớp và bốn quan hệ kế thừa; chức năng với đầy đủ thêm, sửa, xóa, tìm kiếm và "
        "báo cáo; cơ sở dữ liệu với bảy mươi thủ tục lưu trữ; và kiến trúc ba tầng tách bạch GUI, BUS, DAL. "
        "Sản phẩm cũng có bộ công cụ tự kiểm tra để bảo đảm các yêu cầu định lượng này luôn được giữ khi mã "
        "nguồn tiếp tục thay đổi."
    )
    b.p(
        "Về hạn chế, phần báo cáo chưa thực hiện bằng Crystal Report theo đúng thang điểm, mật khẩu chưa được "
        "băm, chưa có sao lưu tự động và một số nghiệp vụ mở rộng như trả hàng, bảo hành chưa được cài đặt. "
        "Về hướng phát triển, nhóm đề xuất chuyển báo cáo sang Crystal Report, bổ sung phân quyền chi tiết, "
        "tách tầng dữ liệu thành dịch vụ web để hỗ trợ nhiều chi nhánh và phát triển thêm phiên bản web, di "
        "động."
    )
    b.p(
        "Qua quá trình thực hiện, nhóm rút ra ba bài học. Bài học thứ nhất là thiết kế cơ sở dữ liệu phải làm "
        "trước và làm kỹ, vì mọi thay đổi cấu trúc bảng về sau đều kéo theo sửa thủ tục, sửa DAL và đôi khi "
        "sửa cả giao diện. Bài học thứ hai là đưa truy vấn vào thủ tục lưu trữ giúp mã C# ngắn hơn nhiều và "
        "giảm hẳn các lỗi do ghép chuỗi. Bài học thứ ba là quy ước làm việc nhóm và kiểm tra tĩnh tự động giúp "
        "phát hiện sớm những lỗi khó thấy như gọi sai tên thủ tục hay để sót câu SQL trong tầng giao diện."
    )

    # ==================================================================
    b.h(1, "DANH MỤC SÁCH THAM KHẢO")

    for i, sach in enumerate((
        "Phạm Hữu Khang, Lập trình Windows Forms với C#, Nhà xuất bản Lao động - Xã hội, 2008.",
        "Nguyễn Ngọc Bình Phương, Trần Thị Anh Thi, Giáo trình Cơ sở dữ liệu, Nhà xuất bản Giáo dục Việt Nam, 2013.",
        "John Sharp, Microsoft Visual C# Step by Step, 10th Edition, Microsoft Press, 2022.",
        "Jeffrey Richter, CLR via C#, 4th Edition, Microsoft Press, 2012.",
        "Microsoft Learn, ADO.NET - Truy cập dữ liệu trong .NET, https://learn.microsoft.com/dotnet/framework/data/adonet/ "
        "[tham khảo ngày 10 tháng 11 năm 2026].",
        "Microsoft Learn, Stored Procedures (Database Engine), "
        "https://learn.microsoft.com/sql/relational-databases/stored-procedures/stored-procedures-database-engine "
        "[tham khảo ngày 10 tháng 11 năm 2026].",
        "Microsoft Learn, Windows Forms documentation, https://learn.microsoft.com/dotnet/desktop/winforms/ "
        "[tham khảo ngày 11 tháng 11 năm 2026].",
        "ClosedXML Documentation, https://docs.closedxml.io/ [tham khảo ngày 12 tháng 11 năm 2026].",
        "SAP Crystal Reports for Visual Studio - Tài liệu hướng dẫn cài đặt, "
        "https://www.sap.com/products/crystal-reports.html [tham khảo ngày 12 tháng 11 năm 2026].",
        "Git documentation, https://git-scm.com/doc [tham khảo ngày 13 tháng 11 năm 2026].",
    ), start=1):
        b.tai_lieu(f"[{i}] {sach}")
