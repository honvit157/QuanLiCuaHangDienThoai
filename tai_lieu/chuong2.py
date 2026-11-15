"""Nội dung Chương 2 của báo cáo bài tập lớn."""

import os

HINH = os.path.join(os.path.dirname(os.path.abspath(__file__)), "hinh")


def viet(b):
    b.chuong_moi(2, "MÔ HÌNH HỆ THỐNG")

    b.p(
        "Chương này trình bày mô hình của hệ thống ở mức thiết kế, trước khi đi vào cài đặt. Nội dung gồm năm "
        "phần: các chức năng của hệ thống, các giao diện lập trình kèm mô tả điều khiển trên từng biểu mẫu, mô "
        "hình lớp, mô hình cơ sở dữ liệu và các tiện ích dùng chung. Toàn bộ hệ thống được tổ chức theo kiến "
        "trúc ba tầng GUI - BUS - DAL như hình 2.1: tầng giao diện tiếp nhận thao tác của người dùng, tầng "
        "nghiệp vụ kiểm tra và tính toán, tầng truy cập dữ liệu làm việc với SQL Server thông qua thủ tục lưu "
        "trữ. Mỗi tầng chỉ gọi xuống tầng ngay dưới nó, không có tầng nào bỏ qua tầng giữa."
    )
    b.hinh("Kiến trúc ba tầng của hệ thống", os.path.join(HINH, "hinh_2_1_kien_truc_3_tang.png"), 15.5)

    # ==================================================================
    b.h(2, "2.1. Các chức năng của hệ thống")

    b.p(
        "Hệ thống được tổ chức thành chin nhóm chức năng, tương ứng với các nghiệp vụ hằng ngày của một cửa "
        "hàng bán lẻ điện thoại. Mỗi nhóm chức năng gắn với một hoặc vài biểu mẫu, một lớp nghiệp vụ ở tầng "
        "BUS và một tập thủ tục lưu trữ ở tầng dữ liệu. Cách phân chia này giúp việc kiểm tra, sửa lỗi và "
        "phân công công việc được rõ ràng: khi một chức năng hoạt động chưa đúng, nhóm biết chính xác cần "
        "xem tầng nào trước."
    )
    b.p(
        "Bảng 2.1 mô tả từng nhóm chức năng theo bốn tiêu chí: mục đích sử dụng, người dùng, cách thực hiện "
        "và kết quả nhận được. Đây là bảng quan trọng để đối chiếu với yêu cầu của học phần, vì mỗi dòng "
        "trong bảng tương ứng với một chức năng phải có trong sản phẩm."
    )

    b.bang(
        "Các chức năng của hệ thống",
        ["STT", "Chức năng", "Mục đích", "Người dùng và cách thực hiện", "Kết quả"],
        [
            ["1", "Đăng nhập", "Xác thực người dùng trước khi cho phép sử dụng hệ thống.",
             "Nhân viên nhập tài khoản, mật khẩu ở Form9 và nhấn nút Đăng nhập (hoặc Enter).",
             "Mở Form10, ghi nhận mã, tên và chức vụ của người đăng nhập."],
            ["2", "Quản lý hàng hóa", "Quản lý danh mục mặt hàng đang kinh doanh.",
             "Chọn Danh mục → Hàng hóa ở Form1; nhập thông tin và nhấn Thêm/Sửa/Xóa; chọn ảnh nếu cần.",
             "Lưới dữ liệu cập nhật ngay; thông báo thành công hoặc lỗi cụ thể."],
            ["3", "Quản lý danh mục tra cứu", "Quản lý hãng sản xuất, loại hàng, màu sắc, dung lượng.",
             "Mở Form5, chọn một trong bốn tab, nhập mã và tên rồi nhấn nút tương ứng.",
             "Danh mục mới dùng được ngay khi thêm hàng hóa."],
            ["4", "Quản lý nhân viên", "Quản lý hồ sơ, tài khoản và trạng thái làm việc.",
             "Mở Form2; nhập hồ sơ, chọn chức vụ, trạng thái; quản lý có thể xóa.",
             "Danh sách nhân viên và quyền đăng nhập được cập nhật."],
            ["5", "Quản lý khách hàng", "Lưu thông tin khách để lập hóa đơn và chăm sóc.",
             "Mở Form3; nhập mã, tên, số điện thoại, địa chỉ, email; tìm tức thời khi gõ.",
             "Khách hàng sẵn sàng để chọn trong Form7."],
            ["6", "Quản lý nhà cung cấp", "Lưu thông tin đối tác cung cấp hàng.",
             "Mở Form4; nhập thông tin, người liên hệ, email; nhấn Lưu.",
             "Nhà cung cấp sẵn sàng để chọn trong Form8."],
            ["7", "Bán hàng", "Lập hóa đơn bán và cập nhật tồn kho.",
             "Mở Form7; tạo hóa đơn mới, chọn nhân viên, khách hàng, thêm từng mặt hàng, nhấn Lưu.",
             "Hóa đơn được ghi, tồn kho giảm đúng số lượng, có thể xuất Excel."],
            ["8", "Nhập hàng", "Lập phiếu nhập và cập nhật tồn kho, giá nhập.",
             "Mở Form8; chọn nhà cung cấp, thêm mặt hàng và số lượng, nhấn Lưu.",
             "Phiếu nhập được ghi, tồn kho tăng, giá nhập mới nhất được cập nhật."],
            ["9", "Tìm kiếm và báo cáo", "Tra cứu hàng hóa và tổng hợp số liệu kinh doanh.",
             "Mở Form6 để tìm theo nhiều tiêu chí; mở FormBaoCao để xem báo cáo.",
             "Danh sách kết quả, báo cáo doanh thu, tồn kho, top bán chạy; xuất Excel."],
        ],
        do_rong=[1.1, 3.0, 4.0, 5.0, 4.0],
        canh_giua=[0],
        co=10,
    )

    b.p(
        "Chức năng đăng nhập là cửa ngõ của toàn bộ hệ thống. Khi người dùng nhấn nút Đăng nhập, Form9 gọi "
        "phương thức DangNhap của lớp NhanVienBUS; lớp này kiểm tra dữ liệu rỗng, sau đó gọi thủ tục "
        "sp_KiemTraDangNhap với hai tham số là tài khoản và mật khẩu. Nếu thủ tục trả về một dòng dữ liệu, "
        "BUS tạo đối tượng NhanVien và ghi nhận ba giá trị tĩnh: mã nhân viên, tên nhân viên và chức vụ. Ba "
        "giá trị này được dùng lại ở mọi biểu mẫu để hiển thị thanh trạng thái và để quyết định quyền thao "
        "tác. Khi người dùng đóng Form10, hệ thống xóa ba giá trị đó để kết thúc phiên làm việc và quay lại "
        "màn hình đăng nhập."
    )
    b.p(
        "Chức năng quản lý hàng hóa là chức năng có nhiều trường nhập nhất. Ngoài các thông tin cơ bản như "
        "mã, tên, hãng, loại, màu, dung lượng, giá nhập, giá bán và số lượng tồn, biểu mẫu còn cho phép chọn "
        "một tệp ảnh để minh họa. Tệp ảnh được sao chép vào thư mục Images cạnh tệp chạy để tránh trường hợp "
        "người dùng xóa ảnh gốc. Khi chọn một dòng trên lưới, các ô nhập được điền lại và ô mã hàng chuyển "
        "sang chế độ chỉ đọc, nhờ vậy người dùng không vô tình đổi khóa chính của bản ghi đang sửa."
    )
    b.p(
        "Chức năng quản lý danh mục tra cứu gồm bốn tab tương ứng bốn bảng độc lập. Điểm đáng chú ý là bốn "
        "tab dùng chung một bộ xử lý: khi người dùng nhấn nút Thêm ở tab nào, biểu mẫu truyền vào một giá "
        "trị liệt kê LoaiDanhMuc tương ứng và tầng BUS sẽ chọn đúng nhóm thủ tục lưu trữ cần gọi. Cách làm "
        "này giảm khoảng bốn lần khối lượng mã nguồn so với việc viết riêng bốn bộ xử lý, đồng thời vẫn giữ "
        "được thông báo lỗi riêng cho từng danh mục, ví dụ “Không thể xóa màu sắc này vì đang được dùng "
        "trong danh sách sản phẩm”."
    )
    b.p(
        "Chức năng bán hàng là chức năng phức tạp nhất về nghiệp vụ. Người dùng tạo một hóa đơn mới, hệ "
        "thống sinh mã hóa đơn theo mẫu HDB_ kèm thời gian đến mili giây để bảo đảm không trùng. Sau đó "
        "người dùng chọn nhân viên lập hóa đơn, chọn khách hàng nếu khách đã có trong hệ thống, rồi thêm "
        "từng mặt hàng với số lượng và mức giảm giá. Mỗi lần thêm, hệ thống kiểm tra số lượng là số nguyên "
        "dương, giảm giá nằm trong khoảng từ 0 đến 100, đơn giá đọc được từ ô văn bản, và nếu mặt hàng đã "
        "có trong hóa đơn thì cộng dồn số lượng thay vì tạo dòng trùng. Khi nhấn Lưu, toàn bộ hóa đơn được "
        "kiểm tra một lần cuối rồi chuyển xuống tầng dữ liệu để ghi trong một giao dịch."
    )
    b.p(
        "Chức năng nhập hàng có cấu trúc tương tự chức năng bán hàng nhưng chiều cập nhật tồn kho ngược lại. "
        "Khi lưu phiếu nhập, hệ thống cộng số lượng vào tồn kho và cập nhật luôn giá nhập mới nhất của mặt "
        "hàng, nhờ vậy các báo cáo về lợi nhuận sau này phản ánh đúng giá vốn gần nhất. Biểu mẫu cũng tự "
        "điền mã nhân viên đang đăng nhập để giảm thao tác và tránh nhập sai người lập phiếu."
    )
    b.p(
        "Chức năng tìm kiếm cho phép kết hợp tối đa sáu tiêu chí: tên hàng, hãng sản xuất, loại hàng, màu "
        "sắc, giá từ và giá đến. Mỗi tiêu chí để trống nghĩa là không lọc theo tiêu chí đó. Câu truy vấn "
        "được viết trong thủ tục sp_TimKiemHang theo mẫu điều kiện động, tức là mỗi điều kiện có dạng “tham "
        "số rỗng hoặc cột bằng tham số”. Nhờ vậy chỉ cần một thủ tục duy nhất phục vụ mọi tổ hợp tiêu chí, "
        "tránh phải viết hàng chục câu truy vấn riêng."
    )
    b.p(
        "Chức năng báo cáo gồm ba báo cáo: doanh thu theo tháng, giá trị tồn kho và top mười mặt hàng bán "
        "chạy. Cả ba báo cáo đều do SQL Server tổng hợp bằng hàm GROUP BY và các hàm tổng hợp SUM, COUNT, "
        "sau đó ứng dụng chỉ nhận về bảng kết quả gọn nhẹ. Cách làm này giúp báo cáo vẫn nhanh khi dữ liệu "
        "tăng lên hàng chục nghìn dòng, đồng thời giảm dung lượng truyền giữa máy chủ và máy trạm."
    )

    # ==================================================================
    b.h(2, "2.2. Các giao diện có trong hệ thống")

    b.p(
        "Theo yêu cầu của học phần, hệ thống phải có tối thiểu năm giao diện lập trình (interface) và các "
        "lớp triển khai chúng. Giao diện trong C# là một bản cam kết: nó chỉ khai báo thuộc tính và chữ ký "
        "phương thức mà không cài đặt nội dung, buộc mọi lớp triển khai phải có đủ các thành phần đó. Nhờ "
        "vậy tầng nghiệp vụ có thể làm việc với một đối tượng thông qua giao diện mà không cần biết chi tiết "
        "lớp cụ thể, đây chính là tính trừu tượng hóa và là nền tảng để mở rộng hệ thống sau này."
    )
    b.p(
        "Năm giao diện của hệ thống là IHangHoa, IKhachHang, INhanVien, INhaCungCap và IHoaDon. Năm lớp "
        "tương ứng triển khai chúng là HangHoa, KhachHang, NhanVien, NhaCungCap và HoaDonBan. Ngoài ra "
        "HoaDonNhap là lớp thứ sáu cùng nhóm chứng từ nhưng không triển khai giao diện nào, vì nghiệp vụ "
        "nhập hàng không nằm trong yêu cầu tối thiểu của giao diện hóa đơn."
    )

    b.h(3, "2.2.1. Giao diện IHangHoa")
    b.p(
        "Giao diện IHangHoa quy định mọi mặt hàng trong cửa hàng đều phải có mã, tên, các mã tham chiếu đến "
        "hãng sản xuất, loại hàng, màu sắc, dung lượng, cùng ba giá trị số là giá nhập, giá bán và số lượng "
        "tồn. Giao diện cũng bắt buộc lớp triển khai phải có phương thức TinhLoiNhuan để tính chênh lệch "
        "giữa giá bán và giá nhập. Nhờ giao diện này, nếu sau này cửa hàng bán thêm phụ kiện với cách tính "
        "lợi nhuận khác, chỉ cần thêm một lớp mới triển khai IHangHoa mà không phải sửa bất kỳ dòng nào ở "
        "tầng nghiệp vụ."
    )
    b.bang(
        "Thuộc tính và phương thức của giao diện IHangHoa",
        ["STT", "Thành phần", "Kiểu", "Ý nghĩa"],
        [
            ["1", "MaHang", "string (thuộc tính)", "Mã mặt hàng, khóa chính trong bảng tblHang."],
            ["2", "TenHang", "string (thuộc tính)", "Tên đầy đủ của mặt hàng, ví dụ “iPhone 15 128GB”."],
            ["3", "MaHangSX", "string? (thuộc tính)", "Mã hãng sản xuất, tham chiếu bảng tblHangSX."],
            ["4", "MaLoai", "string? (thuộc tính)", "Mã loại hàng, tham chiếu bảng tblLoai."],
            ["5", "MaMau", "string? (thuộc tính)", "Mã màu sắc, tham chiếu bảng tblMau."],
            ["6", "MaDungLuong", "string? (thuộc tính)", "Mã dung lượng, tham chiếu bảng tblDungLuong."],
            ["7", "GiaNhap", "decimal (thuộc tính)", "Giá nhập một đơn vị, dùng để tính giá vốn."],
            ["8", "GiaBan", "decimal (thuộc tính)", "Giá bán một đơn vị, dùng khi lập hóa đơn."],
            ["9", "SoLuongTon", "int (thuộc tính)", "Số lượng còn trong kho tại thời điểm hiện tại."],
            ["10", "TinhLoiNhuan()", "decimal (phương thức)", "Trả về GiaBan - GiaNhap cho một đơn vị hàng."],
        ],
        do_rong=[1.2, 3.4, 3.6, 8.4],
        canh_giua=[0, 2],
        co=10.5,
    )

    b.h(3, "2.2.2. Giao diện IKhachHang")
    b.p(
        "Giao diện IKhachHang quy định thông tin tối thiểu của một khách hàng gồm mã khách hàng và phương "
        "thức LayThongTinRutGon trả về chuỗi hiển thị nhanh dạng “Mã - Tên (Số điện thoại)”. Phương thức này "
        "được dùng ở những nơi cần hiển thị khách hàng trong một dòng, ví dụ dòng trạng thái của biểu mẫu "
        "bán hàng hoặc nội dung ghi chú của hóa đơn in ra. Việc đưa cách hiển thị vào lớp thay vì viết rải "
        "rác trong các biểu mẫu giúp khi cần đổi định dạng chỉ sửa một chỗ."
    )
    b.bang(
        "Thuộc tính và phương thức của giao diện IKhachHang",
        ["STT", "Thành phần", "Kiểu", "Ý nghĩa"],
        [
            ["1", "MaKH", "string (thuộc tính)", "Mã khách hàng, khóa chính trong bảng tblKhachHang."],
            ["2", "LayThongTinRutGon()", "string (phương thức)", "Trả về chuỗi “Mã - Họ tên (SĐT)” để hiển thị nhanh."],
        ],
        do_rong=[1.2, 4.0, 3.6, 7.8],
        canh_giua=[0],
        co=11,
    )

    b.h(3, "2.2.3. Giao diện INhanVien")
    b.p(
        "Giao diện INhanVien quy định tài khoản và quyền hạn của nhân viên. Ngoài bốn thuộc tính là mã nhân "
        "viên, tên đăng nhập, mật khẩu và vai trò, giao diện còn bắt buộc phương thức KiemTraQuyenQuanLy. "
        "Phương thức này trả về true khi vai trò là “Quản lý” hoặc “Admin”, nhờ vậy các biểu mẫu chỉ cần gọi "
        "một lệnh duy nhất để biết có nên hiện nút xóa hay không, thay vì so sánh chuỗi ở nhiều nơi và dễ "
        "sai khi cách ghi chức vụ thay đổi."
    )
    b.bang(
        "Thuộc tính và phương thức của giao diện INhanVien",
        ["STT", "Thành phần", "Kiểu", "Ý nghĩa"],
        [
            ["1", "MaNV", "string (thuộc tính)", "Mã nhân viên, khóa chính trong bảng tblNhanVien."],
            ["2", "TenDangNhap", "string (thuộc tính)", "Tài khoản đăng nhập, tương ứng cột TaiKhoan."],
            ["3", "MatKhau", "string (thuộc tính)", "Mật khẩu đăng nhập của nhân viên."],
            ["4", "VaiTro", "string (thuộc tính)", "Chức vụ: Quản lý hoặc Nhân viên."],
            ["5", "KiemTraQuyenQuanLy()", "bool (phương thức)", "Kiểm tra nhân viên có quyền quản lý hay không."],
        ],
        do_rong=[1.2, 4.0, 3.6, 7.8],
        canh_giua=[0],
        co=11,
    )

    b.h(3, "2.2.4. Giao diện INhaCungCap")
    b.p(
        "Giao diện INhaCungCap quy định thông tin của nhà cung cấp gồm mã, tên, số điện thoại, địa chỉ và "
        "phương thức LayThongTinLienHe trả về một chuỗi tổng hợp để hiển thị hoặc in. Trong nghiệp vụ nhập "
        "hàng, thông tin liên hệ của nhà cung cấp thường được in kèm phiếu nhập để tiện đối chiếu khi nhận "
        "hàng, vì vậy việc có sẵn một phương thức tạo chuỗi thống nhất là cần thiết."
    )
    b.bang(
        "Thuộc tính và phương thức của giao diện INhaCungCap",
        ["STT", "Thành phần", "Kiểu", "Ý nghĩa"],
        [
            ["1", "MaNCC", "string (thuộc tính)", "Mã nhà cung cấp, khóa chính trong bảng tblNhaCungCap."],
            ["2", "TenNCC", "string (thuộc tính)", "Tên đầy đủ của nhà cung cấp."],
            ["3", "SDT", "string (thuộc tính)", "Số điện thoại liên hệ, phải đúng 10 chữ số bắt đầu bằng 0."],
            ["4", "DiaChi", "string (thuộc tính)", "Địa chỉ giao dịch của nhà cung cấp."],
            ["5", "LayThongTinLienHe()", "string (phương thức)", "Trả về chuỗi gồm tên, hotline, email, người liên hệ."],
        ],
        do_rong=[1.2, 4.0, 3.6, 7.8],
        canh_giua=[0],
        co=11,
    )

    b.h(3, "2.2.5. Giao diện IHoaDon")
    b.p(
        "Giao diện IHoaDon quy định cấu trúc chung của một hóa đơn bán hàng gồm mã hóa đơn, mã nhân viên lập, "
        "mã khách hàng, ngày lập, tổng tiền và phương thức TinhTongTien. Phương thức TinhTongTien không nhận "
        "tham số mà đọc chính danh sách chi tiết bên trong đối tượng, cộng dồn thành tiền của từng dòng rồi "
        "gán lại vào thuộc tính TongTien. Cách thiết kế này bảo đảm tổng tiền của hóa đơn luôn khớp với chi "
        "tiết, tránh trường hợp người dùng sửa chi tiết mà tổng tiền không được tính lại."
    )
    b.bang(
        "Thuộc tính và phương thức của giao diện IHoaDon",
        ["STT", "Thành phần", "Kiểu", "Ý nghĩa"],
        [
            ["1", "MaHD", "string (thuộc tính)", "Mã hóa đơn, sinh tự động theo mẫu HDB_yyyyMMddHHmmssfff."],
            ["2", "MaNV", "string (thuộc tính)", "Mã nhân viên lập hóa đơn, bắt buộc phải tồn tại."],
            ["3", "MaKH", "string (thuộc tính)", "Mã khách hàng; có thể để trống nếu khách mua lẻ không lưu tên."],
            ["4", "NgayLap", "DateTime (thuộc tính)", "Ngày giờ lập hóa đơn, lấy từ DateTimePicker."],
            ["5", "TongTien", "decimal (thuộc tính)", "Tổng tiền của hóa đơn sau khi cộng dồn chi tiết."],
            ["6", "TinhTongTien()", "decimal (phương thức)", "Cộng thành tiền các dòng chi tiết và gán vào TongTien."],
        ],
        do_rong=[1.2, 4.0, 3.6, 7.8],
        canh_giua=[0],
        co=11,
    )

    b.p(
        "Ngoài năm giao diện, phần giao diện của hệ thống còn gồm mười một biểu mẫu. Để đáp ứng yêu cầu của "
        "học phần về việc mô tả các đối tượng điều khiển trên từng biểu mẫu, các bảng từ 2.7 đến 2.11 liệt "
        "kê những điều khiển quan trọng nhất theo đúng năm cột: số thứ tự, tên đối tượng, kiểu, ý nghĩa và "
        "ghi chú. Những điều khiển chỉ mang tính trang trí như Label tiêu đề được lược bớt để bảng không quá "
        "dài."
    )

    b.bang(
        "Các đối tượng điều khiển trên Form1 - Quản lý hàng hóa",
        ["STT", "Tên đối tượng", "Kiểu", "Ý nghĩa", "Ghi chú"],
        [
            ["1", "Form1", "Form", "Biểu mẫu quản lý danh sách mặt hàng.", "Mở trong Panel của Form10."],
            ["2", "txtMaHang", "TextBox", "Nhập hoặc hiển thị mã mặt hàng.", "Chỉ đọc khi đang sửa một dòng."],
            ["3", "txtTenHang", "TextBox", "Nhập tên đầy đủ của mặt hàng.", ""],
            ["4", "cboHang", "ComboBox", "Chọn hãng sản xuất từ danh mục.", "Dữ liệu do DanhMucBUS nạp."],
            ["5", "cboLoai", "ComboBox", "Chọn loại hàng (cao cấp, tầm trung, phổ thông, máy tính bảng).", ""],
            ["6", "cboMau", "ComboBox", "Chọn màu sắc của máy.", ""],
            ["7", "cboDungLuong", "ComboBox", "Chọn dung lượng bộ nhớ.", "Có thể để trống."],
            ["8", "txtGiaNhap", "TextBox", "Nhập giá nhập, chấp nhận dấu phân cách nghìn.", "Đọc bằng AppHelpers.DocSoTien."],
            ["9", "txtGiaBan", "TextBox", "Nhập giá bán cho khách.", ""],
            ["10", "txtSoLuong", "TextBox", "Nhập số lượng đang có trong kho.", "Chỉ nhận số nguyên không âm."],
            ["11", "txtTim", "TextBox", "Ô tìm nhanh theo mã hoặc tên.", "Lọc ngay khi gõ."],
            ["12", "dgvHang", "DataGridView", "Hiển thị danh sách mặt hàng và các cột tham chiếu.", "Chọn dòng để nạp dữ liệu lên form."],
            ["13", "picAnh", "PictureBox", "Hiển thị ảnh minh họa của mặt hàng đang chọn.", "Ảnh sao chép vào thư mục Images."],
            ["14", "btnThem / btnSua / btnXoa", "Button", "Thêm mới, cập nhật, xóa mặt hàng.", "Gọi HangHoaBUS tương ứng."],
            ["15", "btnLamLai / btnThoat", "Button", "Xóa trắng các ô nhập, đóng biểu mẫu.", ""],
        ],
        do_rong=[1.0, 3.3, 2.4, 6.4, 4.7],
        canh_giua=[0],
        co=9.5,
    )

    b.bang(
        "Các đối tượng điều khiển trên Form5 - Quản lý bốn danh mục",
        ["STT", "Tên đối tượng", "Kiểu", "Ý nghĩa", "Ghi chú"],
        [
            ["1", "tabDanhMuc", "TabControl", "Chứa bốn tab danh mục: hãng sản xuất, loại hàng, màu sắc, dung lượng.", ""],
            ["2", "tpMauSac / tpDungLuong", "TabPage", "Trang chứa nội dung của từng danh mục.", "Thiết kế sẵn trong Form Designer."],
            ["3", "txtMaHang / textBox3", "TextBox", "Nhập mã danh mục của tab đang mở.", "Chỉ đọc khi đang sửa."],
            ["4", "txtTenHang / textBox1", "TextBox", "Nhập tên danh mục tương ứng.", ""],
            ["5", "dgvHangSX / dataGridView1", "DataGridView", "Hiển thị danh sách danh mục của tab hiện tại.", "Dùng chung hàm SetupDgv."],
            ["6", "btnThem / button5 / button10 / button15", "Button", "Thêm danh mục mới cho tab tương ứng.", "Gọi DanhMucBUS.Them."],
            ["7", "btnSua / button4 / button9 / button14", "Button", "Cập nhật tên danh mục đang chọn.", "Gọi DanhMucBUS.Sua."],
            ["8", "btnXoa / button3 / button8 / button13", "Button", "Xóa danh mục đang chọn nếu không bị ràng buộc.", "Bắt lỗi khóa ngoại 547."],
            ["9", "btnLamLai / button2 / button7 / button12", "Button", "Xóa trắng ô nhập và bỏ chế độ chỉ đọc.", ""],
            ["10", "btnThoat / button1 / button6 / button11", "Button", "Đóng biểu mẫu quản lý danh mục.", ""],
        ],
        do_rong=[1.0, 3.6, 2.4, 6.4, 4.4],
        canh_giua=[0],
        co=9.5,
    )

    b.bang(
        "Các đối tượng điều khiển trên Form7 - Hóa đơn bán hàng",
        ["STT", "Tên đối tượng", "Kiểu", "Ý nghĩa", "Ghi chú"],
        [
            ["1", "cboMaHD", "ComboBox", "Mã hóa đơn: chọn hóa đơn cũ hoặc nhập mã mới.", "Cho phép gõ tự do."],
            ["2", "dtpNgayLap", "DateTimePicker", "Ngày lập hóa đơn.", "Mặc định là ngày hiện tại."],
            ["3", "txtMaNV / txtMaKH", "TextBox", "Nhập mã nhân viên, mã khách hàng.", "Có gợi ý tự động (AutoComplete)."],
            ["4", "txtTenNV / txtTenKH", "TextBox", "Hiển thị tên tương ứng với mã đã nhập.", "Chỉ đọc."],
            ["5", "txtSDT / txtDiaChi", "TextBox", "Hiển thị số điện thoại và địa chỉ khách hàng.", "Chỉ đọc."],
            ["6", "cboMaHang", "ComboBox", "Chọn mã mặt hàng cần bán.", "Nạp từ tblHang."],
            ["7", "txtTenHang / txtDonGia", "TextBox", "Hiển thị tên hàng và đơn giá bán.", "Chỉ đọc, tự điền khi chọn mã."],
            ["8", "txtSoLuong / txtGiamGia", "TextBox", "Nhập số lượng bán và mức giảm giá theo phần trăm.", "Giảm giá từ 0 đến 100."],
            ["9", "txtThanhTien", "TextBox", "Thành tiền của dòng đang nhập.", "Tự tính khi đổi số lượng hoặc giảm giá."],
            ["10", "dgvChiTiet", "DataGridView", "Danh sách mặt hàng của hóa đơn đang lập.", "Bấm vào dòng để xóa dòng đó."],
            ["11", "lblTongTien", "Label", "Hiển thị tổng tiền của hóa đơn.", "Cập nhật sau mỗi thay đổi."],
            ["12", "btnThemHang", "Button", "Đưa mặt hàng đang nhập vào danh sách chi tiết.", "Cộng dồn nếu trùng mã hàng."],
            ["13", "btnLuu", "Button", "Lưu hóa đơn và trừ tồn kho.", "Gọi HoaDonBanBUS.LuuHoaDon."],
            ["14", "btnThemHD / btnHuy", "Button", "Tạo hóa đơn mới, bỏ các dòng đang lập.", "Có hộp thoại xác nhận."],
            ["15", "btnTim / btnIn", "Button", "Tìm hóa đơn đã lưu, xuất hóa đơn ra Excel.", "Dùng ClosedXML."],
        ],
        do_rong=[1.0, 3.4, 2.4, 6.4, 4.6],
        canh_giua=[0],
        co=9.5,
    )

    b.bang(
        "Các đối tượng điều khiển trên Form8 - Hóa đơn nhập hàng",
        ["STT", "Tên đối tượng", "Kiểu", "Ý nghĩa", "Ghi chú"],
        [
            ["1", "cboMaHDN", "ComboBox", "Mã phiếu nhập, sinh tự động hoặc chọn phiếu cũ.", "Mẫu HDN_yyyyMMddHHmmssfff."],
            ["2", "dtpNgayNhap", "DateTimePicker", "Ngày nhập hàng.", ""],
            ["3", "txtMaNV / txtTenNV", "TextBox", "Mã và tên nhân viên lập phiếu.", "Tự điền theo người đăng nhập."],
            ["4", "cboNCC", "ComboBox", "Chọn nhà cung cấp.", "Nạp từ tblNhaCungCap."],
            ["5", "txtMaNCC / txtSDT / txtDiaChi", "TextBox", "Thông tin nhà cung cấp ứng với mã đã chọn.", "Chỉ đọc."],
            ["6", "cboMaHang", "ComboBox", "Chọn mặt hàng cần nhập.", ""],
            ["7", "txtTenHang / txtDonGiaNhap", "TextBox", "Tên hàng và giá nhập gợi ý.", "Có thể sửa giá nhập."],
            ["8", "txtSoLuong / txtThanhTien", "TextBox", "Số lượng nhập và thành tiền của dòng.", "Thành tiền tự tính."],
            ["9", "dgvChiTiet", "DataGridView", "Danh sách mặt hàng của phiếu nhập.", ""],
            ["10", "lblTongTien", "Label", "Tổng tiền phải trả cho nhà cung cấp.", ""],
            ["11", "button1", "Button", "Thêm mặt hàng vào phiếu nhập.", "Đổi tên hiển thị thành “Thêm mặt hàng vào HĐ”."],
            ["12", "btnLuu / btnHuy", "Button", "Lưu phiếu nhập (cộng tồn kho) hoặc hủy các dòng đang nhập.", ""],
            ["13", "btnTim / btnIn / btnThoat", "Button", "Tìm phiếu cũ, xuất Excel, đóng biểu mẫu.", ""],
        ],
        do_rong=[1.0, 3.4, 2.4, 6.2, 4.8],
        canh_giua=[0],
        co=9.5,
    )

    b.bang(
        "Các đối tượng điều khiển trên FormBaoCao - Báo cáo thống kê",
        ["STT", "Tên đối tượng", "Kiểu", "Ý nghĩa", "Ghi chú"],
        [
            ["1", "tabControl1", "TabControl", "Ba tab báo cáo: doanh thu, tồn kho, top bán chạy.", ""],
            ["2", "dgvDoanhThu", "DataGridView", "Bảng doanh thu theo tháng gồm năm, tháng, số hóa đơn, doanh thu.", "Số liệu từ sp_BaoCaoDoanhThuTheoThang."],
            ["3", "dgvTonKho", "DataGridView", "Bảng tồn kho gồm mã, tên, hãng, loại, giá bán, tồn, giá trị tồn.", "Số liệu từ sp_BaoCaoTonKho."],
            ["4", "dgvTopBanChay", "DataGridView", "Top 10 mặt hàng bán chạy kèm doanh thu.", "Số liệu từ sp_BaoCaoTopBanChay."],
            ["5", "lblTongDoanhThu", "Label", "Tổng doanh thu của tất cả các tháng.", "Tính lại khi nạp dữ liệu."],
            ["6", "lblTongTonKho", "Label", "Tổng giá trị tồn kho và số mặt hàng.", ""],
            ["7", "btnXuatExcel", "Button", "Xuất cả ba báo cáo ra tệp Excel ba trang tính.", "Dùng ClosedXML."],
            ["8", "btnLamMoi / btnDong", "Button", "Nạp lại số liệu, đóng biểu mẫu.", ""],
        ],
        do_rong=[1.0, 3.4, 2.4, 6.6, 4.4],
        canh_giua=[0],
        co=9.5,
    )

    # ==================================================================
    b.h(2, "2.3. Mô hình lớp")

    b.p(
        "Mô hình lớp của hệ thống được xây dựng quanh sáu khái niệm nghiệp vụ: người, mặt hàng, chứng từ, "
        "khách hàng, nhân viên và nhà cung cấp. Ba khái niệm đầu là lớp trừu tượng, đóng vai trò lớp cơ sở "
        "chứa các thuộc tính và hành vi chung; các khái niệm còn lại là lớp cụ thể, kế thừa lớp cơ sở và bổ "
        "sung những gì đặc thù cho mình. Hình 2.2 minh họa mô hình lớp rút gọn của hệ thống."
    )
    b.hinh("Mô hình lớp của hệ thống", os.path.join(HINH, "hinh_2_2_mo_hinh_lop.png"), 16)

    b.p(
        "Hệ thống có bốn quan hệ kế thừa, vượt yêu cầu tối thiểu ba quan hệ của học phần. Đó là KhachHang "
        "kế thừa Nguoi, NhanVien kế thừa Nguoi, HangHoa kế thừa SanPhamBase và HoaDonBan kế thừa ChungTuBase "
        "(HoaDonNhap cũng kế thừa ChungTuBase). Bảng 2.12 liệt kê toàn bộ lớp trong hệ thống, quan hệ kế "
        "thừa hoặc giao diện mà lớp triển khai, và vai trò của lớp đó."
    )

    b.bang(
        "Danh sách các lớp trong hệ thống",
        ["STT", "Tên lớp", "Kế thừa / Triển khai", "Vai trò trong hệ thống"],
        [
            ["1", "Nguoi", "Lớp trừu tượng cơ sở", "Chứa họ tên, số điện thoại, địa chỉ, giới tính, ngày sinh; "
             "cung cấp phương thức ảo LayThongTin và TinhTuoi."],
            ["2", "KhachHang", "Nguoi, IKhachHang", "Đại diện khách mua hàng; bổ sung mã khách, email; "
             "ghi đè LayThongTin."],
            ["3", "NhanVien", "Nguoi, INhanVien", "Đại diện nhân viên; bổ sung mã, tài khoản, mật khẩu, chức vụ, "
             "trạng thái; có KiemTraQuyenQuanLy."],
            ["4", "SanPhamBase", "Lớp trừu tượng cơ sở", "Chứa mã, tên, giá nhập, giá bán, số lượng tồn; "
             "cung cấp TinhLoiNhuan, TinhTyLeLoiNhuan, TinhGiaTriTon."],
            ["5", "HangHoa", "SanPhamBase, IHangHoa", "Đại diện mặt hàng điện thoại; bổ sung mã hãng, loại, màu, "
             "dung lượng, mô tả."],
            ["6", "NhaCungCap", "INhaCungCap", "Đại diện nhà cung cấp; chứa thông tin liên hệ và người phụ trách."],
            ["7", "ChungTuBase", "Lớp trừu tượng cơ sở", "Chứa mã chứng từ, mã nhân viên, ngày lập, tổng tiền; "
             "bắt buộc lớp con cài đặt TinhTongTien."],
            ["8", "HoaDonBan", "ChungTuBase, IHoaDon", "Hóa đơn bán hàng; chứa danh sách ChiTietHoaDonBan và "
             "mã khách hàng."],
            ["9", "HoaDonNhap", "ChungTuBase", "Hóa đơn nhập hàng; chứa danh sách ChiTietHoaDonNhap và mã nhà cung cấp."],
            ["10", "ChiTietHoaDonBan", "Lớp độc lập", "Một dòng của hóa đơn bán; tự tính thành tiền theo số lượng, "
             "đơn giá, giảm giá."],
            ["11", "ChiTietHoaDonNhap", "Lớp độc lập", "Một dòng của phiếu nhập; tính thành tiền theo số lượng và "
             "giá nhập."],
            ["12", "DatabaseAccess", "Lớp tĩnh", "Cung cấp kết nối và bốn hàm thực thi thủ tục lưu trữ dùng chung "
             "cho mọi lớp DAL."],
            ["13", "AppHelpers", "Lớp tĩnh", "Chứa các phương thức tiện ích: kiểm tra dữ liệu, định dạng tiền, "
             "chuẩn hóa chuỗi, ghi nhật ký."],
            ["14", "LoaiDanhMuc", "Kiểu liệt kê", "Bốn giá trị HangSanXuat, LoaiHang, MauSac, DungLuong dùng để "
             "chọn nhóm thủ tục ở tầng DAL."],
        ],
        do_rong=[1.0, 3.4, 4.2, 9.2],
        canh_giua=[0],
        co=9.5,
    )

    b.h(3, "2.3.1. Lớp cơ sở Nguoi và hai lớp kế thừa")
    b.p(
        "Lớp Nguoi là lớp trừu tượng, nghĩa là không thể tạo trực tiếp đối tượng Nguoi mà chỉ dùng làm lớp cơ "
        "sở. Lớp khai báo năm thuộc tính chung cho mọi con người trong hệ thống: họ tên, số điện thoại, địa "
        "chỉ, giới tính và ngày sinh. Lớp cũng cung cấp hai phương thức: LayThongTin trả về chuỗi mô tả và "
        "TinhTuoi tính tuổi hiện tại từ ngày sinh. Phương thức LayThongTin được khai báo là virtual để lớp "
        "con có thể ghi đè, đây là biểu hiện của tính đa hình."
    )
    b.p(
        "Lớp KhachHang kế thừa Nguoi và triển khai IKhachHang. Ngoài các thuộc tính thừa hưởng, lớp bổ sung mã "
        "khách hàng và email. Hàm khởi tạo của lớp gọi hàm khởi tạo của lớp cơ sở thông qua từ khóa base, "
        "truyền họ tên, số điện thoại, địa chỉ và giá trị giới tính mặc định. Lớp ghi đè LayThongTin để thêm "
        "tiền tố [KH] vào chuỗi mô tả, nhờ vậy khi ghi nhật ký, người đọc phân biệt được dòng nào là khách "
        "hàng và dòng nào là nhân viên."
    )
    b.p(
        "Lớp NhanVien cũng kế thừa Nguoi nhưng triển khai INhanVien. Lớp bổ sung năm thuộc tính nghiệp vụ: mã "
        "nhân viên, tên đăng nhập, mật khẩu, vai trò và trạng thái làm việc. Phương thức KiemTraQuyenQuanLy "
        "so sánh vai trò với ba giá trị “Quản lý”, “Quan ly” và “Admin” theo cách không phân biệt chữ hoa "
        "chữ thường, vì dữ liệu mẫu ban đầu lưu chức vụ không dấu. Việc xử lý cả hai cách ghi giúp hệ thống "
        "không bị sai quyền khi cơ sở dữ liệu còn dữ liệu cũ."
    )

    b.h(3, "2.3.2. Lớp cơ sở SanPhamBase và lớp HangHoa")
    b.p(
        "Lớp SanPhamBase ra đời từ quan sát rằng mọi mặt hàng đều có chung bốn thông tin: mã, tên, giá nhập, "
        "giá bán và số lượng tồn. Ba hành vi cũng được cài đặt sẵn ở lớp này: TinhLoiNhuan tính chênh lệch "
        "giá, TinhTyLeLoiNhuan tính tỷ lệ phần trăm lợi nhuận so với giá nhập, và TinhGiaTriTon tính giá trị "
        "hàng đang nằm trong kho theo giá bán. Nhờ lớp cơ sở này, lớp HangHoa chỉ cần bổ sung bốn mã tham "
        "chiếu và trường mô tả, thay vì lặp lại toàn bộ phần giá cả."
    )
    b.p(
        "Lớp HangHoa triển khai IHangHoa bằng cách thừa hưởng các thuộc tính của SanPhamBase. Đây là điểm "
        "đáng chú ý về mặt kỹ thuật: một giao diện có thể được thỏa mãn bởi các thành phần nằm ở lớp cơ sở, "
        "nên lớp dẫn xuất không phải khai báo lại. Lớp ghi đè phương thức LayMoTa để trả về chuỗi gồm mã, "
        "tên và mô tả cấu hình, phục vụ việc in danh sách hàng hoặc ghi chú trong hóa đơn."
    )

    b.h(3, "2.3.3. Lớp cơ sở ChungTuBase và hai lớp chứng từ")
    b.p(
        "Lớp ChungTuBase là lớp trừu tượng chứa những gì chung nhất của một chứng từ: mã chứng từ, mã nhân "
        "viên lập, ngày lập và tổng tiền. Lớp khai báo phương thức trừu tượng TinhTongTien, buộc mọi lớp con "
        "phải tự cài đặt cách tính tổng tiền của loại chứng từ mình phụ trách, vì hóa đơn bán cộng thành "
        "tiền sau giảm giá còn phiếu nhập cộng thành tiền theo giá nhập. Lớp cũng có hàm SinhMa dùng chung "
        "để sinh mã theo tiền tố và thời gian."
    )
    b.p(
        "Lớp HoaDonBan kế thừa ChungTuBase, triển khai IHoaDon và chứa danh sách ChiTietHoaDonBan. Đây là "
        "quan hệ kết tập (composition) điển hình: một hóa đơn được tạo thành từ nhiều dòng chi tiết, nếu hóa "
        "đơn bị hủy thì các dòng chi tiết cũng không còn ý nghĩa. Lớp HoaDonNhap có cấu trúc tương tự nhưng "
        "chứa danh sách ChiTietHoaDonNhap và mã nhà cung cấp. Việc dùng chung lớp cơ sở giúp hai lớp chứng "
        "từ có cùng cách đặt mã, cùng cách lưu ngày và cùng cách hiển thị thông tin chung."
    )

    b.h(3, "2.3.4. Quan hệ kết tập và tính đa hình")
    b.p(
        "Quan hệ kết tập thể hiện rõ nhất ở hai lớp hóa đơn. Thuộc tính ChiTietList được khai báo là "
        "List<ChiTietHoaDonBan> nên mỗi đối tượng hóa đơn quản lý một tập đối tượng chi tiết, và phương thức "
        "TinhTongTien duyệt qua danh sách đó để cộng dồn. Khi lưu hóa đơn, tầng DAL cũng duyệt chính danh "
        "sách này để ghi từng dòng, nhờ vậy dữ liệu trên giao diện và dữ liệu ghi xuống cơ sở dữ liệu luôn "
        "xuất phát từ một nguồn duy nhất."
    )
    b.p(
        "Tính đa hình được thể hiện qua ba cặp phương thức ghi đè: LayThongTin của Nguoi được ghi đè ở "
        "KhachHang và NhanVien, LayMoTa của SanPhamBase được ghi đè ở HangHoa, và TinhTongTien của "
        "ChungTuBase được cài đặt riêng ở HoaDonBan và HoaDonNhap. Nhờ đa hình, đoạn mã ghi nhật ký có thể "
        "nhận một danh sách Nguoi gồm cả khách hàng lẫn nhân viên rồi gọi LayThongTin cho từng phần tử mà "
        "không cần kiểm tra kiểu, mỗi đối tượng sẽ tự trả về chuỗi mô tả đúng của mình."
    )

    # ==================================================================
    b.h(2, "2.4. Mô hình cơ sở dữ liệu")

    b.p(
        "Cơ sở dữ liệu của hệ thống có tên QLCuaHangBanDienThoai, gồm mười hai bảng được chia thành ba nhóm. "
        "Nhóm danh mục gồm bốn bảng tblHangSX, tblLoai, tblMau, tblDungLuong, mỗi bảng chỉ có mã và tên. "
        "Nhóm đối tượng gồm tblHang, tblNhanVien, tblKhachHang, tblNhaCungCap. Nhóm chứng từ gồm bốn bảng "
        "tblHoaDonBan, tblChiTietHDB, tblHoaDonNhap, tblChiTietHDN. Hình 2.3 trình bày lược đồ quan hệ của "
        "cơ sở dữ liệu."
    )
    b.hinh("Lược đồ quan hệ của cơ sở dữ liệu", os.path.join(HINH, "hinh_2_3_luoc_do_csdl.png"), 16)

    b.p(
        "Cơ sở dữ liệu được chuẩn hóa đến dạng chuẩn ba. Cụ thể, thông tin hãng, loại, màu và dung lượng "
        "không lặp lại trong bảng tblHang mà được tách thành bốn bảng danh mục và tham chiếu bằng khóa "
        "ngoại; thông tin nhân viên, khách hàng, nhà cung cấp không lặp lại trong bảng hóa đơn mà chỉ lưu "
        "mã tham chiếu. Cách chuẩn hóa này tránh được hiện tượng sửa tên hãng ở một chỗ nhưng dữ liệu hóa "
        "đơn vẫn giữ tên cũ, đồng thời giảm dung lượng lưu trữ."
    )
    b.p(
        "Bảng 2.13 mô tả chi tiết cấu trúc của từng bảng: tên cột, kiểu dữ liệu, khóa và ý nghĩa. Các bảng "
        "danh mục nhỏ được mô tả gộp để tránh lặp lại nội dung không cần thiết."
    )

    b.bang(
        "Cấu trúc bảng tblHang",
        ["STT", "Tên cột", "Kiểu dữ liệu", "Khóa", "Ý nghĩa"],
        [
            ["1", "MaHang", "NVARCHAR(20)", "PK", "Mã mặt hàng, ví dụ SP001."],
            ["2", "TenHang", "NVARCHAR(200)", "", "Tên đầy đủ của mặt hàng."],
            ["3", "MaHangSX", "NVARCHAR(20)", "FK → tblHangSX", "Hãng sản xuất."],
            ["4", "MaLoai", "NVARCHAR(20)", "FK → tblLoai", "Loại hàng."],
            ["5", "MaMau", "NVARCHAR(20)", "FK → tblMau", "Màu sắc."],
            ["6", "MaDungLuong", "NVARCHAR(20)", "FK → tblDungLuong", "Dung lượng bộ nhớ."],
            ["7", "DonGiaNhap", "DECIMAL(18,2)", "", "Giá nhập, mặc định 0, không cho âm."],
            ["8", "DonGiaBan", "DECIMAL(18,2)", "", "Giá bán cho khách."],
            ["9", "SoLuongTon", "INT", "", "Số lượng còn trong kho."],
            ["10", "MoTa", "NVARCHAR(500)", "", "Mô tả cấu hình: chip, camera, pin."],
        ],
        do_rong=[1.1, 3.4, 3.6, 3.6, 6.0],
        canh_giua=[0],
        co=10,
    )

    b.bang(
        "Cấu trúc bảng tblNhanVien",
        ["STT", "Tên cột", "Kiểu dữ liệu", "Khóa", "Ý nghĩa"],
        [
            ["1", "MaNV", "NVARCHAR(20)", "PK", "Mã nhân viên, ví dụ NV001."],
            ["2", "TenNV", "NVARCHAR(100)", "", "Họ tên nhân viên."],
            ["3", "GioiTinh", "NVARCHAR(10)", "", "Nam hoặc Nữ."],
            ["4", "NgaySinh", "DATE", "", "Ngày sinh, dùng để tính tuổi."],
            ["5", "SDT", "NVARCHAR(20)", "", "Số điện thoại liên hệ."],
            ["6", "DiaChi", "NVARCHAR(200)", "", "Địa chỉ thường trú."],
            ["7", "ChucVu", "NVARCHAR(50)", "", "Quản lý hoặc Nhân viên, dùng để phân quyền."],
            ["8", "TaiKhoan", "NVARCHAR(50)", "", "Tài khoản đăng nhập."],
            ["9", "MatKhau", "NVARCHAR(100)", "", "Mật khẩu đăng nhập."],
            ["10", "TrangThai", "NVARCHAR(50)", "", "Đang làm việc hoặc Đã nghỉ việc, mặc định Đang làm việc."],
        ],
        do_rong=[1.1, 3.4, 3.6, 2.2, 7.4],
        canh_giua=[0],
        co=10,
    )

    b.bang(
        "Cấu trúc các bảng còn lại",
        ["Bảng", "Các cột chính", "Khóa ngoại", "Ghi chú"],
        [
            ["tblHangSX", "MaHangSX (PK), TenHangSX", "—", "Sáu hãng: Apple, Samsung, Xiaomi, OPPO, Vivo, Realme."],
            ["tblLoai", "MaLoai (PK), TenLoai", "—", "Bốn loại: cao cấp, tầm trung, phổ thông, máy tính bảng."],
            ["tblMau", "MaMau (PK), TenMau", "—", "Bảy màu cơ bản."],
            ["tblDungLuong", "MaDungLuong (PK), TenDungLuong", "—", "Năm mức dung lượng từ 64GB đến 1TB."],
            ["tblKhachHang", "MaKH (PK), TenKH, SDT, DiaChi, Email", "—", "Email dùng để kiểm tra định dạng, không bắt buộc."],
            ["tblNhaCungCap", "MaNCC (PK), TenNCC, SDT, DiaChi, Email, NguoiLH", "—", "NguoiLH là người phụ trách liên hệ."],
            ["tblHoaDonBan", "MaHDB (PK), MaNV, MaKH, NgayLap, TongTien", "MaNV → tblNhanVien; MaKH → tblKhachHang",
             "MaKH cho phép NULL với khách mua lẻ."],
            ["tblChiTietHDB", "MaHDB (PK, FK), MaHang (PK, FK), SoLuong, DonGia, GiamGia, ThanhTien",
             "MaHDB → tblHoaDonBan; MaHang → tblHang", "Ràng buộc SoLuong > 0 và 0 ≤ GiamGia ≤ 100."],
            ["tblHoaDonNhap", "MaHDN (PK), MaNV, MaNCC, NgayNhap, TongTien", "MaNV → tblNhanVien; MaNCC → tblNhaCungCap", ""],
            ["tblChiTietHDN", "MaHDN (PK, FK), MaHang (PK, FK), SoLuong, DonGiaNhap, ThanhTien",
             "MaHDN → tblHoaDonNhap; MaHang → tblHang", "Ràng buộc SoLuong > 0."],
        ],
        do_rong=[3.2, 6.4, 5.0, 5.4],
        co=9.5,
    )

    b.h(3, "2.4.1. Các thủ tục lưu trữ")
    b.p(
        "Toàn bộ truy vấn của hệ thống được đóng gói trong bảy mươi thủ tục lưu trữ, chia theo tám nhóm đối "
        "tượng. Mỗi nhóm có các thủ tục lấy danh sách, lấy theo mã, thêm, cập nhật, xóa và kiểm tra tồn tại. "
        "Ngoài ra còn các thủ tục chuyên biệt cho nghiệp vụ như trừ tồn kho có điều kiện, cộng tồn kho kèm "
        "cập nhật giá nhập, lấy thông tin khách hàng, lấy hóa đơn kèm tên nhân viên, và ba thủ tục tổng hợp "
        "báo cáo. Bảng 2.16 liệt kê các thủ tục theo nhóm và chức năng."
    )

    b.bang(
        "Danh sách thủ tục lưu trữ theo nhóm",
        ["Nhóm", "Các thủ tục", "Chức năng chính"],
        [
            ["Hàng hóa (8)", "sp_LayDanhSachHang, sp_LayHangTheoMa, sp_LayDanhSachMaHang, sp_ThemHang, "
             "sp_CapNhatHang, sp_XoaHang, sp_KiemTraHangTonTai, sp_TimKiemHang",
             "Truy vấn và cập nhật bảng tblHang; thủ tục tìm kiếm hỗ trợ sáu tiêu chí kết hợp."],
            ["Hãng sản xuất (5)", "sp_LayDanhSachHangSX, sp_ThemHangSX, sp_CapNhatHangSX, sp_XoaHangSX, "
             "sp_KiemTraHangSXTonTai", "CRUD bảng tblHangSX, tham số chung là @Ma và @Ten."],
            ["Loại hàng (5)", "sp_LayDanhSachLoai, sp_ThemLoai, sp_CapNhatLoai, sp_XoaLoai, sp_KiemTraLoaiTonTai",
             "CRUD bảng tblLoai."],
            ["Màu sắc (5)", "sp_LayDanhSachMau, sp_ThemMau, sp_CapNhatMau, sp_XoaMau, sp_KiemTraMauTonTai",
             "CRUD bảng tblMau."],
            ["Dung lượng (5)", "sp_LayDanhSachDungLuong, sp_ThemDungLuong, sp_CapNhatDungLuong, sp_XoaDungLuong, "
             "sp_KiemTraDungLuongTonTai", "CRUD bảng tblDungLuong."],
            ["Khách hàng (8)", "sp_LayDanhSachKhachHang, sp_LayDanhSachMaKhachHang, sp_LayThongTinKhachHang, "
             "sp_ThemKhachHang, sp_CapNhatKhachHang, sp_XoaKhachHang, sp_KiemTraKhachHangTonTai, sp_LayHoaDonCuaKhachHang",
             "CRUD bảng tblKhachHang; thủ tục cuối cùng trả về danh sách hóa đơn để chặn xóa."],
            ["Nhà cung cấp (7)", "sp_LayDanhSachNhaCungCap, sp_LayDanhSachMaNhaCungCap, sp_LayThongTinNhaCungCap, "
             "sp_ThemNhaCungCap, sp_CapNhatNhaCungCap, sp_XoaNhaCungCap, sp_KiemTraNhaCungCapTonTai",
             "CRUD bảng tblNhaCungCap."],
            ["Nhân viên (10)", "sp_LayDanhSachNhanVien, sp_LayDanhSachMaNhanVien, sp_LayNhanVienTheoMa, "
             "sp_LayTenNhanVien, sp_KiemTraDangNhap, sp_ThemNhanVien, sp_CapNhatNhanVien, "
             "sp_CapNhatTrangThaiNhanVien, sp_XoaNhanVien, sp_KiemTraNhanVienTonTai",
             "CRUD bảng tblNhanVien, xác thực đăng nhập, cập nhật trạng thái làm việc."],
            ["Hóa đơn bán (7)", "sp_LayDanhSachMaHoaDonBan, sp_KiemTraHoaDonBanTonTai, sp_LayHoaDonBan, "
             "sp_LayChiTietHoaDonBan, sp_TruTonKho, sp_ThemHoaDonBan, sp_ThemChiTietHoaDonBan",
             "Ghi hóa đơn bán và chi tiết; sp_TruTonKho chỉ trừ khi đủ tồn và trả về số dòng đã trừ."],
            ["Hóa đơn nhập (7)", "sp_LayDanhSachMaHoaDonNhap, sp_KiemTraHoaDonNhapTonTai, sp_LayHoaDonNhap, "
             "sp_LayChiTietHoaDonNhap, sp_CongTonKho, sp_ThemHoaDonNhap, sp_ThemChiTietHoaDonNhap",
             "Ghi phiếu nhập; sp_CongTonKho cộng tồn và cập nhật giá nhập mới nhất."],
            ["Báo cáo (3)", "sp_BaoCaoDoanhThuTheoThang, sp_BaoCaoTonKho, sp_BaoCaoTopBanChay",
             "Tổng hợp doanh thu theo tháng, giá trị tồn kho, top sản phẩm bán chạy."],
        ],
        do_rong=[3.0, 8.4, 6.6],
        co=9,
    )

    b.h(3, "2.4.2. Các thao tác cập nhật dữ liệu")
    b.p(
        "Các thao tác cập nhật dữ liệu được chia thành hai loại: cập nhật một bảng và cập nhật nhiều bảng "
        "trong một giao dịch. Loại thứ nhất gồm thêm, sửa, xóa một danh mục, một mặt hàng, một khách hàng, "
        "một nhà cung cấp hoặc một nhân viên; mỗi thao tác tương ứng một thủ tục và không cần giao dịch vì "
        "chỉ ảnh hưởng một bảng. Loại thứ hai là lưu hóa đơn bán và lưu phiếu nhập, mỗi thao tác ảnh hưởng "
        "đến ba bảng nên bắt buộc phải nằm trong một giao dịch."
    )
    b.p(
        "Với hóa đơn bán, trình tự gồm bốn bước. Bước một, gọi sp_KiemTraHoaDonBanTonTai để chắc chắn mã hóa "
        "đơn chưa tồn tại. Bước hai, với từng dòng chi tiết, gọi sp_TruTonKho; thủ tục thực hiện câu lệnh "
        "cập nhật có điều kiện “SoLuongTon >= @SoLuong” và trả về số dòng đã cập nhật, nếu trả về 0 thì "
        "nghĩa là không đủ hàng và giao dịch phải hủy. Bước ba, gọi sp_ThemHoaDonBan để ghi đầu hóa đơn. "
        "Bước bốn, gọi sp_ThemChiTietHoaDonBan cho từng dòng. Sau khi cả bốn bước thành công, tầng DAL gọi "
        "Commit; nếu bất kỳ bước nào ném ngoại lệ, tầng DAL gọi Rollback để trả cơ sở dữ liệu về trạng thái "
        "trước khi lưu."
    )
    b.p(
        "Với phiếu nhập, trình tự gồm bốn bước tương tự nhưng chiều cập nhật ngược lại: kiểm tra mã, ghi đầu "
        "phiếu, với từng dòng gọi sp_CongTonKho để cộng tồn kho và cập nhật giá nhập, sau đó gọi "
        "sp_ThemChiTietHoaDonNhap để ghi chi tiết. Nhờ giao dịch, nếu một mặt hàng không tồn tại trong kho "
        "thì toàn bộ phiếu nhập bị hủy, không xảy ra tình trạng cộng tồn cho vài mặt hàng rồi dừng giữa "
        "chừng."
    )
    b.p(
        "Ngoài ra, cơ sở dữ liệu còn có các ràng buộc toàn vẹn ở mức bảng để chặn dữ liệu sai ngay cả khi có "
        "người dùng trực tiếp bằng SQL Server Management Studio. Các ràng buộc chính gồm: khóa ngoại giữa "
        "tblHang với bốn bảng danh mục, giữa chi tiết hóa đơn với hóa đơn và hàng hóa, giữa hóa đơn với "
        "nhân viên và khách hàng; ràng buộc kiểm tra số lượng lớn hơn 0 và giảm giá trong khoảng 0 đến 100; "
        "giá trị mặc định 0 cho các cột tiền và số lượng; và chỉ mục trên các cột thường dùng để tìm kiếm "
        "hoặc tổng hợp như TenHang, NgayLap, MaKH."
    )

    # ==================================================================
    b.h(2, "2.5. Các tiện ích")

    b.p(
        "Yêu cầu của học phần là hệ thống phải có tối thiểu năm class method tiện ích. Nhóm tập trung các "
        "phương thức này trong một lớp tĩnh duy nhất là AppHelpers, đặt trong thư mục Utilities. Lớp có mười "
        "phương thức, chia thành bốn nhóm chức năng: kiểm tra dữ liệu, định dạng và đọc số, chuẩn hóa chuỗi, "
        "và các tiện ích ghi nhật ký, thông báo, xử lý ảnh. Việc tập trung như vậy giúp quy tắc kiểm tra "
        "được áp dụng thống nhất ở mọi biểu mẫu, khi cần thay đổi chỉ sửa một nơi."
    )

    b.bang(
        "Các phương thức tiện ích trong lớp AppHelpers",
        ["STT", "Phương thức", "Tham số", "Chức năng và ví dụ"],
        [
            ["1", "KiemTraSoDienThoai", "string? sdt", "Kiểm tra số điện thoại đúng 10 chữ số và bắt đầu bằng 0. "
             "Ví dụ: “0901234567” trả về true, “901234567” trả về false."],
            ["2", "KiemTraEmail", "string? email", "Kiểm tra định dạng email; chuỗi rỗng được coi là hợp lệ vì "
             "email không bắt buộc."],
            ["3", "KiemTraSoNguyenKhongAm", "string? chuoi, out int", "Kiểm tra chuỗi có phải số nguyên không âm, "
             "dùng cho ô số lượng tồn."],
            ["4", "DinhDangTien", "decimal tien", "Định dạng số tiền theo kiểu Việt Nam: 32000000 thành “32.000.000”."],
            ["5", "DinhDangTienVnd", "decimal tien", "Như trên nhưng thêm đơn vị: “32.000.000 ₫”."],
            ["6", "DinhDangNgay", "DateTime ngay", "Định dạng ngày theo dd/MM/yyyy để hiển thị và in."],
            ["7", "DocSoTien", "string? chuoi, out decimal", "Đọc số tiền người dùng nhập, bỏ dấu chấm, dấu phẩy và "
             "ký tự không phải số. Ví dụ “32.000.000 VNĐ” đọc được thành 32000000."],
            ["8", "ChuanHoaChuoi", "string? chuoi", "Cắt khoảng trắng thừa hai đầu và gộp nhiều khoảng trắng ở giữa "
             "thành một."],
            ["9", "TaoTuKhoaTimKiem", "string? tuKhoa", "Chuẩn hóa từ khóa và nhân đôi dấu nháy đơn để đưa vào bộ lọc "
             "RowFilter mà không gây lỗi cú pháp."],
            ["10", "GhiLog", "string noiDung", "Ghi một dòng nhật ký kèm thời gian vào tệp Logs/app-yyyyMMdd.log; "
             "lỗi ghi tệp được bỏ qua để không ảnh hưởng nghiệp vụ."],
            ["11", "HienThongBao, HienCanhBao, XacNhan", "string noiDung", "Ba phương thức hiển thị hộp thoại thông "
             "báo, cảnh báo và hộp thoại xác nhận Có/Không, trả về DialogResult.Yes."],
            ["12", "SaoChepAnh, ThuMucAnh", "string duongDanNguon", "Sao chép ảnh người dùng chọn vào thư mục Images "
             "cạnh tệp chạy và trả về tên tệp."],
        ],
        do_rong=[1.0, 4.2, 4.0, 8.8],
        canh_giua=[0],
        co=9.5,
    )

    b.p(
        "Hai phương thức được dùng nhiều nhất là DocSoTien và TaoTuKhoaTimKiem. Phương thức DocSoTien giải "
        "quyết một vấn đề thường gặp trong ứng dụng tài chính: người dùng có thể nhập “32000000”, "
        "“32.000.000” hoặc “32,000,000” và cả ba đều phải được hiểu là ba mươi hai triệu. Cách cài đặt là "
        "duyệt từng ký tự, chỉ giữ lại chữ số rồi chuyển thành số, nhờ vậy không phụ thuộc vào cài đặt vùng "
        "của máy tính. Phương thức TaoTuKhoaTimKiem thì bảo đảm bộ lọc của DataView không bị lỗi khi người "
        "dùng gõ dấu nháy đơn vào ô tìm kiếm, đồng thời loại bỏ khoảng trắng thừa để việc so khớp chính xác "
        "hơn."
    )
    b.p(
        "Lớp AppHelpers còn chứa thuộc tính ViVn giữ một đối tượng CultureInfo của Việt Nam để các biểu mẫu "
        "dùng lại khi định dạng số trên lưới dữ liệu. Nhờ dùng chung một đối tượng culture, cách hiển thị số "
        "tiền ở Form1, Form6 và FormBaoCao hoàn toàn giống nhau, tránh tình trạng mỗi lưới hiển thị một kiểu."
    )
