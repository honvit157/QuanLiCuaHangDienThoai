"""Chương 2 - Mô hình hệ thống."""

import os

from tai_lieu import bieu_do

HINH = os.path.join(os.path.dirname(os.path.abspath(__file__)), "hinh")


def viet(b):
    b.chuong_moi(2, "MÔ HÌNH HỆ THỐNG")

    b.p(
        "Chương này mô tả mô hình của hệ thống ở bốn góc nhìn: chức năng, giao diện lập trình, lớp đối "
        "tượng và cơ sở dữ liệu. Bốn góc nhìn này tương ứng với bốn tầng trừu tượng khác nhau của cùng "
        "một sản phẩm, giúp người đọc thấy được yêu cầu nghiệp vụ được chuyển thành mã nguồn và cấu trúc "
        "dữ liệu như thế nào."
    )
    b.p(
        "Về tổng thể, ứng dụng được tổ chức theo kiến trúc ba tầng: tầng giao diện Windows Forms, tầng "
        "nghiệp vụ và tầng truy cập dữ liệu, đặt trên cùng một cơ sở dữ liệu SQL Server. Mỗi tầng chỉ giao "
        "tiếp với tầng liền kề, và mọi truy vấn đều đi qua thủ tục lưu trữ. Kiến trúc này được minh họa ở "
        "Hình 2.1."
    )
    b.hinh("Kiến trúc ba tầng của hệ thống", os.path.join(HINH, "hinh_2_1_kien_truc_3_tang.png"), 16.0)

    # ==================================================================
    b.h(2, "2.1. Các chức năng của hệ thống")

    b.p(
        "Hệ thống được chia thành bốn nhóm chức năng lớn, tương ứng với bốn công việc hằng ngày của một "
        "cửa hàng bán điện thoại: quản lý hàng hóa – danh mục, quản lý đối tác, lập chứng từ bán – nhập "
        "và theo dõi kết quả kinh doanh. Mỗi nhóm chức năng đều được thực hiện trên một biểu mẫu riêng, "
        "mở từ menu bên trái của màn hình chính."
    )

    b.bang(
        "Danh mục chức năng của hệ thống",
        ["Nhóm", "Chức năng", "Biểu mẫu", "Người dùng"],
        [
            ["Đăng nhập", "Xác thực tài khoản, mở màn hình chính theo chức vụ", "Form9", "Tất cả"],
            ["Tổng quan", "Bốn thẻ số liệu, biểu đồ doanh thu 7 ngày, thông tin nổi bật", "Form10", "Tất cả"],
            ["Hàng hóa", "Thêm, sửa, xóa, xem danh sách, chọn ảnh minh họa, tìm nhanh", "Form1", "Tất cả"],
            ["Danh mục", "Quản lý hãng sản xuất, loại hàng, màu sắc, dung lượng", "Form5", "Tất cả"],
            ["Nhân viên", "Thêm, sửa, xóa, khóa – mở trạng thái làm việc", "Form2", "Quản lý"],
            ["Khách hàng", "Thêm, sửa, xóa, tìm theo mã hoặc tên", "Form3", "Tất cả"],
            ["Nhà cung cấp", "Thêm, sửa, xóa, tìm kiếm", "Form4", "Tất cả"],
            ["Tìm kiếm", "Tìm hàng theo tên, hãng, loại, màu, khoảng giá; xuất Excel", "Form6", "Tất cả"],
            ["Hóa đơn bán", "Lập hóa đơn, trừ tồn kho, in – xuất Excel", "Form7", "Tất cả"],
            ["Hóa đơn nhập", "Lập phiếu nhập, cộng tồn kho, cập nhật giá nhập", "Form8", "Tất cả"],
            ["Báo cáo", "Doanh thu theo tháng, tồn kho, top bán chạy; xuất Excel ba sheet",
             "FormBaoCao", "Tất cả"],
        ],
        do_rong=[2.4, 8.0, 2.6, 2.4],
        canh_giua=[0, 2, 3],
        co=10.5,
    )

    b.h(3, "2.1.1. Nhóm chức năng quản lý hàng hóa và danh mục")
    b.p(
        "Đây là nhóm chức năng nền tảng, vì mọi hóa đơn đều tham chiếu tới một mã hàng cụ thể. Trên "
        "Form1, người dùng nhập mã hàng, tên hàng, chọn hãng sản xuất, loại hàng, màu sắc và dung lượng "
        "từ bốn hộp chọn được nạp sẵn từ cơ sở dữ liệu, sau đó nhập giá nhập, giá bán, số lượng tồn và "
        "có thể chọn một tệp ảnh để minh họa. Danh sách hàng hiển thị ở bảng bên phải; khi bấm vào một "
        "dòng, thông tin của dòng đó được đưa lên vùng nhập để sửa hoặc xóa. Ô tìm nhanh cho phép lọc "
        "ngay trên danh sách theo mã hoặc tên hàng mà không cần gọi lại máy chủ."
    )
    b.p(
        "Form5 quản lý bốn danh mục tra cứu được tổ chức thành bốn thẻ: hãng sản xuất, loại hàng, màu "
        "sắc và dung lượng. Bốn thẻ có cùng cách thao tác (thêm – sửa – xóa – làm lại) nên nhóm dùng "
        "chung một bộ xử lý, chỉ khác nhau ở loại danh mục truyền vào tầng nghiệp vụ. Khi xóa một danh "
        "mục đang được hàng hóa sử dụng, cơ sở dữ liệu trả về lỗi vi phạm khóa ngoại và chương trình "
        "hiển thị thông báo giải thích thay vì làm ứng dụng dừng đột ngột."
    )

    b.h(3, "2.1.2. Nhóm chức năng quản lý đối tác")
    b.p(
        "Form2 quản lý nhân viên với các thông tin: mã, họ tên, giới tính, ngày sinh, số điện thoại, "
        "địa chỉ, tài khoản, mật khẩu, chức vụ và trạng thái làm việc. Trạng thái chỉ được thay đổi bởi "
        "tài khoản quản lý, và nút xóa được ẩn với nhân viên thường. Form3 quản lý khách hàng, có thêm "
        "trường email. Form4 quản lý nhà cung cấp với các trường email và người liên hệ, phục vụ cho "
        "việc lập phiếu nhập hàng."
    )
    b.p(
        "Điểm nghiệp vụ đáng chú ý ở nhóm này là quy tắc bảo toàn lịch sử giao dịch: khi người dùng xóa "
        "một khách hàng đã có hóa đơn, tầng nghiệp vụ kiểm tra trước và liệt kê các mã hóa đơn liên quan "
        "để từ chối xóa. Với nhà cung cấp đã phát sinh phiếu nhập, ràng buộc khóa ngoại của cơ sở dữ "
        "liệu cũng chặn thao tác xóa; chương trình bắt lỗi này và hướng dẫn người dùng giữ lại bản ghi."
    )

    b.h(3, "2.1.3. Nhóm chức năng lập chứng từ")
    b.p(
        "Form7 dùng để lập hóa đơn bán hàng. Người dùng tạo mã hóa đơn mới, chọn nhân viên lập và khách "
        "hàng (có thể để trống với khách lẻ), sau đó chọn từng mặt hàng, nhập số lượng và mức giảm giá. "
        "Đơn giá được lấy tự động từ giá bán của mặt hàng, thành tiền được tính lại ngay khi thay đổi số "
        "lượng hoặc giảm giá, và tổng tiền của hóa đơn được cộng dồn ở cuối biểu mẫu. Khi lưu, hệ thống "
        "kiểm tra mã hóa đơn chưa tồn tại, kiểm tra tồn kho đủ cho từng mặt hàng rồi mới trừ kho, ghi "
        "đầu hóa đơn và ghi các dòng chi tiết trong cùng một giao dịch; nếu bất kỳ bước nào thất bại thì "
        "toàn bộ thay đổi được hoàn tác."
    )
    b.p(
        "Form8 lập phiếu nhập hàng theo quy trình ngược lại: chọn nhà cung cấp, chọn mặt hàng và nhập số "
        "lượng, đơn giá nhập. Khi lưu, hệ thống ghi đầu phiếu nhập, cộng số lượng vào tồn kho và cập "
        "nhật luôn giá nhập mới nhất của mặt hàng, sau đó ghi các dòng chi tiết. Cả hai biểu mẫu đều có "
        "chức năng tìm lại chứng từ đã lưu theo mã và xuất chứng từ ra tệp Excel để in."
    )

    b.h(3, "2.1.4. Nhóm chức năng báo cáo và tổng quan")
    b.p(
        "Form10 là màn hình đầu tiên sau khi đăng nhập. Màn hình gồm bốn thẻ số liệu (tổng sản phẩm, số "
        "khách hàng, số hóa đơn trong ngày, doanh thu trong ngày), một biểu đồ cột thể hiện doanh thu "
        "bảy ngày gần nhất và cột thông tin nổi bật bên phải. Toàn bộ số liệu của màn hình này được lấy "
        "qua lớp ThongKeBUS, lớp này gọi tám thủ tục thống kê trong cơ sở dữ liệu."
    )
    b.p(
        "FormBaoCao cung cấp ba báo cáo chi tiết hơn: doanh thu và số hóa đơn theo từng tháng, giá trị "
        "tồn kho của từng mặt hàng và top mười mặt hàng bán chạy. Ba báo cáo được đặt trong ba thẻ; nút "
        "“Xuất Excel” ghi cả ba ra một tệp gồm ba trang tính có tiêu đề, định dạng số tiền và tô màu cho "
        "ba mặt hàng bán chạy nhất."
    )

    b.h(3, "2.1.5. Luồng xử lý của hai nghiệp vụ chính")
    b.p(
        "Nghiệp vụ bán hàng là nghiệp vụ phức tạp nhất vì tác động đồng thời lên bảng hàng, đầu hóa đơn và "
        "bảng chi tiết. Luồng xử lý gồm bảy bước: người dùng tạo mã hóa đơn mới; chọn nhân viên và khách "
        "hàng; chọn mặt hàng, nhập số lượng và giảm giá; chương trình tính thành tiền và tổng tiền; khi "
        "bấm Lưu, tầng nghiệp vụ kiểm tra dữ liệu đầu vào; tầng truy cập dữ liệu mở giao dịch và gọi lần "
        "lượt các thủ tục kiểm tra trùng mã, trừ tồn kho, ghi đầu hóa đơn và ghi chi tiết; cuối cùng cam "
        "kết giao dịch và nạp lại danh sách mã hóa đơn. Nếu ở bước trừ tồn kho có mặt hàng không đủ số "
        "lượng, toàn bộ giao dịch được hoàn tác và người dùng nhận thông báo chỉ rõ mặt hàng nào thiếu."
    )
    b.p(
        "Nghiệp vụ nhập hàng có luồng tương tự nhưng theo chiều ngược: chọn nhà cung cấp thay cho khách "
        "hàng, cộng tồn kho thay vì trừ, và cập nhật giá nhập mới nhất thay vì giữ nguyên giá vốn. Điểm "
        "khác biệt về nghiệp vụ là phiếu nhập không có mức giảm giá cho từng dòng, vì giá nhập đã là giá "
        "thỏa thuận với nhà cung cấp. Hai nghiệp vụ dùng chung cơ chế giao dịch và chung cách đánh số "
        "chứng từ theo dạng tiền tố cộng với thời điểm lập, nhờ vậy mã chứng từ không trùng giữa các máy."
    )
    b.bang(
        "So sánh hai nghiệp vụ lập chứng từ",
        ["Nội dung", "Hóa đơn bán (Form7)", "Phiếu nhập (Form8)"],
        [
            ["Đối tượng đi kèm", "Khách hàng (có thể để trống với khách lẻ)", "Nhà cung cấp (bắt buộc)"],
            ["Giá sử dụng", "Giá bán của mặt hàng", "Giá nhập do người dùng nhập"],
            ["Giảm giá từng dòng", "Có, từ 0 đến 100 phần trăm", "Không có"],
            ["Ảnh hưởng tồn kho", "Trừ số lượng, không cho âm", "Cộng số lượng"],
            ["Ảnh hưởng giá vốn", "Không thay đổi", "Cập nhật DonGiaNhap của mặt hàng"],
            ["Mã chứng từ", "HDB_yyyyMMddHHmmssfff", "HDN_yyyyMMddHHmmssfff"],
        ],
        do_rong=[4.2, 6.8, 7.0],
        co=10.5,
    )

    # ==================================================================
    b.h(2, "2.2. Các giao diện có trong hệ thống")

    b.p(
        "Theo yêu cầu của học phần, hệ thống phải có tối thiểu năm giao diện (interface). Nhóm xây dựng "
        "sáu giao diện, mỗi giao diện quy định hợp đồng tối thiểu cho một nhóm đối tượng nghiệp vụ. Các "
        "lớp thực thể trong tầng DTO triển khai những giao diện này, nhờ vậy tầng nghiệp vụ có thể làm "
        "việc với đối tượng thông qua giao diện thay vì phụ thuộc vào lớp cụ thể."
    )

    b.bang(
        "Sáu giao diện của hệ thống",
        ["STT", "Giao diện", "Lớp triển khai", "Ý nghĩa"],
        [
            ["1", "IHangHoa", "HangHoa", "Quy định thuộc tính của một mặt hàng và khả năng tự tính lợi nhuận"],
            ["2", "IHoaDon", "HoaDonBan", "Quy định cấu trúc một hóa đơn bán và khả năng tự tính tổng tiền"],
            ["3", "IHoaDonNhap", "HoaDonNhap", "Quy định cấu trúc một hóa đơn nhập và khả năng tự tính tổng tiền"],
            ["4", "IKhachHang", "KhachHang", "Quy định mã khách hàng và chuỗi hiển thị nhanh"],
            ["5", "INhaCungCap", "NhaCungCap", "Quy định thông tin nhà cung cấp và chuỗi liên hệ"],
            ["6", "INhanVien", "NhanVien", "Quy định tài khoản, vai trò và kiểm tra quyền quản lý"],
        ],
        do_rong=[1.2, 3.2, 3.0, 7.6],
        canh_giua=[0],
        co=10.5,
    )

    b.h(3, "2.2.1. Giao diện IHangHoa")
    b.p(
        "Giao diện này mô tả một mặt hàng kinh doanh. Mọi lớp triển khai nó phải có mã hàng, tên hàng, "
        "các khóa tham chiếu tới danh mục (hãng, loại, màu, dung lượng), giá nhập, giá bán, số lượng tồn "
        "và phương thức tính lợi nhuận. Nhờ có giao diện này, tầng nghiệp vụ có thể viết hàm kiểm tra hợp "
        "lệ chung cho mọi loại mặt hàng mà không cần biết đó là điện thoại hay phụ kiện."
    )
    b.bang(
        "Thành phần của giao diện IHangHoa",
        ["Thành phần", "Kiểu", "Ý nghĩa"],
        [
            ["MaHang", "string (thuộc tính)", "Mã mặt hàng, khóa chính"],
            ["TenHang", "string (thuộc tính)", "Tên mặt hàng hiển thị trên hóa đơn"],
            ["MaHangSX, MaLoai, MaMau, MaDungLuong", "string? (thuộc tính)", "Bốn khóa tham chiếu tới bảng danh mục"],
            ["GiaNhap, GiaBan", "decimal (thuộc tính)", "Giá vốn và giá bán một đơn vị"],
            ["SoLuongTon", "int (thuộc tính)", "Số lượng còn trong kho"],
            ["TinhLoiNhuan()", "decimal (phương thức)", "Trả về chênh lệch giữa giá bán và giá nhập"],
        ],
        do_rong=[5.6, 3.6, 6.2],
        co=10.5,
    )

    b.h(3, "2.2.2. Giao diện IHoaDon và IHoaDonNhap")
    b.p(
        "Hai giao diện này quy định cấu trúc chung của chứng từ bán và chứng từ nhập. Mỗi chứng từ phải "
        "có mã, mã nhân viên lập, ngày lập, tổng tiền và phương thức tự cộng tổng tiền từ danh sách chi "
        "tiết. Hóa đơn bán có thêm mã khách hàng, hóa đơn nhập có thêm mã nhà cung cấp và thuộc tính "
        "ngày nhập. Việc tách thành hai giao diện giúp lớp ChungTuBase dùng chung phần lõi, còn mỗi lớp "
        "dẫn xuất chỉ bổ sung phần đặc thù."
    )
    b.bang(
        "Thành phần của giao diện IHoaDon và IHoaDonNhap",
        ["Giao diện", "Thành phần", "Kiểu", "Ý nghĩa"],
        [
            ["IHoaDon", "MaHD", "string", "Mã hóa đơn bán"],
            ["IHoaDon", "MaNV, MaKH", "string", "Nhân viên lập và khách hàng mua"],
            ["IHoaDon", "NgayLap", "DateTime", "Ngày lập hóa đơn"],
            ["IHoaDon", "TongTien", "decimal", "Tổng tiền phải thanh toán"],
            ["IHoaDon", "TinhTongTien()", "decimal", "Cộng thành tiền các dòng chi tiết"],
            ["IHoaDonNhap", "MaHDN", "string", "Mã phiếu nhập"],
            ["IHoaDonNhap", "MaNV, MaNCC", "string", "Nhân viên lập và nhà cung cấp"],
            ["IHoaDonNhap", "NgayNhap", "DateTime", "Ngày nhập hàng"],
            ["IHoaDonNhap", "TongTien", "decimal", "Tổng tiền nhập"],
            ["IHoaDonNhap", "TinhTongTien()", "decimal", "Cộng thành tiền các dòng chi tiết"],
        ],
        do_rong=[3.2, 3.6, 2.8, 6.4],
        co=10.5,
    )

    b.h(3, "2.2.3. Giao diện IKhachHang, INhaCungCap và INhanVien")
    b.p(
        "Ba giao diện còn lại quy định thông tin của các đối tượng là người và tổ chức. IKhachHang yêu "
        "cầu mã khách hàng và một phương thức trả về chuỗi hiển thị nhanh dạng “mã – tên (số điện "
        "thoại)”, chuỗi này được dùng trong hộp chọn khách hàng khi lập hóa đơn. INhaCungCap yêu cầu các "
        "thông tin liên hệ và phương thức trả về chuỗi liên hệ đầy đủ. INhanVien yêu cầu thông tin tài "
        "khoản, vai trò và phương thức kiểm tra quyền quản lý, được dùng để quyết định có hiện mục "
        "“Nhân viên” trên menu hay không."
    )
    b.bang(
        "Thành phần của IKhachHang, INhaCungCap và INhanVien",
        ["Giao diện", "Thành phần", "Kiểu", "Ý nghĩa"],
        [
            ["IKhachHang", "MaKH", "string", "Mã khách hàng"],
            ["IKhachHang", "LayThongTinRutGon()", "string", "Chuỗi “mã – tên (số điện thoại)”"],
            ["INhaCungCap", "MaNCC, TenNCC, SDT, DiaChi", "string", "Thông tin cơ bản của nhà cung cấp"],
            ["INhaCungCap", "LayThongTinLienHe()", "string", "Chuỗi liên hệ đầy đủ kèm email, người liên hệ"],
            ["INhanVien", "MaNV, TenDangNhap, MatKhau, VaiTro", "string", "Thông tin tài khoản đăng nhập"],
            ["INhanVien", "KiemTraQuyenQuanLy()", "bool", "Kiểm tra chức vụ có phải quản lý hay không"],
        ],
        do_rong=[3.4, 6.0, 2.0, 5.6],
        co=10.5,
    )

    b.h(3, "2.2.4. Vai trò của giao diện trong kiến trúc")
    b.p(
        "Sáu giao diện không chỉ để đủ số lượng theo yêu cầu của học phần mà còn có tác dụng thực tế. Tầng "
        "nghiệp vụ khai báo tham số và giá trị trả về bằng kiểu giao diện ở những chỗ không cần biết lớp cụ "
        "thể, ví dụ hàm lấy thông tin khách hàng trả về IKhachHang, hàm lấy mặt hàng trả về IHangHoa. Nhờ "
        "vậy nếu sau này nhóm bổ sung loại mặt hàng mới như phụ kiện, chỉ cần tạo lớp mới triển khai "
        "IHangHoa là các hàm hiện có vẫn dùng được, không phải sửa tầng nghiệp vụ. Đây chính là lợi ích "
        "của nguyên tắc lập trình hướng giao diện."
    )
    b.p(
        "Một điểm cần phân biệt là giao diện trong C# chỉ quy định hợp đồng, không chứa dữ liệu. Vì vậy "
        "mỗi giao diện đều đi kèm một lớp cụ thể cài đặt đầy đủ thuộc tính và phương thức; lớp đó nằm "
        "trong tầng DTO và được tầng DAL đổ dữ liệu vào sau khi đọc từ cơ sở dữ liệu. Việc tách này giúp "
        "giao diện không phụ thuộc vào cấu trúc bảng, còn lớp thực thể thì ánh xạ một-một với bảng."
    )

    # ==================================================================
    b.h(2, "2.3. Mô hình lớp")

    b.p(
        "Mô hình lớp của hệ thống gồm mười hai kiểu dữ liệu trong tầng DTO, trong đó có ba lớp trừu "
        "tượng, sáu giao diện, một enum và các lớp cụ thể. Sơ đồ lớp rút gọn được trình bày ở Hình 2.2. "
        "Ba lớp trừu tượng Nguoi, SanPhamBase và ChungTuBase giữ những thuộc tính và hành vi chung nhất; "
        "các lớp cụ thể kế thừa chúng và triển khai giao diện tương ứng."
    )
    b.hinh("Mô hình lớp rút gọn của hệ thống", os.path.join(HINH, "hinh_2_2_mo_hinh_lop.png"), 16.0)

    b.h(3, "2.3.1. Các lớp thực thể")
    b.bang(
        "Các lớp thực thể và nhiệm vụ",
        ["STT", "Lớp", "Loại", "Thuộc tính / phương thức chính", "Nhiệm vụ"],
        [
            ["1", "Nguoi", "Lớp trừu tượng", "HoTen, SDT, DiaChi, GioiTinh, NgaySinh; LayThongTin(), TinhTuoi()",
             "Giữ thông tin chung của một con người"],
            ["2", "KhachHang", "Lớp cụ thể", "MaKH, Email; LayThongTinRutGon()",
             "Khách mua hàng, được tham chiếu từ hóa đơn bán"],
            ["3", "NhanVien", "Lớp cụ thể", "MaNV, TenDangNhap, MatKhau, VaiTro, TrangThai; KiemTraQuyenQuanLy()",
             "Tài khoản đăng nhập và người lập chứng từ"],
            ["4", "SanPhamBase", "Lớp trừu tượng", "MaHang, TenHang, GiaNhap, GiaBan, SoLuongTon; TinhLoiNhuan()",
             "Phần lõi chung của mọi mặt hàng"],
            ["5", "HangHoa", "Lớp cụ thể", "MaHangSX, MaLoai, MaMau, MaDungLuong, MoTa; LayMoTa()",
             "Mặt hàng điện thoại hiển thị trên Form1 và Form6"],
            ["6", "ChungTuBase", "Lớp trừu tượng", "MaChungTu, MaNV, NgayLap, TongTien; TinhTongTien()",
             "Phần lõi chung của mọi chứng từ"],
            ["7", "HoaDonBan", "Lớp cụ thể", "MaHD, MaKH, ChiTietList; TinhTongTien()",
             "Hóa đơn bán, chứa danh sách chi tiết"],
            ["8", "HoaDonNhap", "Lớp cụ thể", "MaHDN, MaNCC, NgayNhap, ChiTietList; TinhTongTien()",
             "Phiếu nhập, chứa danh sách chi tiết"],
            ["9", "NhaCungCap", "Lớp cụ thể", "MaNCC, TenNCC, SDT, DiaChi, Email, NguoiLH; LayThongTinLienHe()",
             "Đối tác cung cấp hàng"],
            ["10", "ChiTietHoaDonBan", "Lớp cụ thể", "MaHang, SoLuong, DonGia, GiamGia, ThanhTien; TinhThanhTien()",
             "Một dòng của hóa đơn bán"],
            ["11", "ChiTietHoaDonNhap", "Lớp cụ thể", "MaHang, SoLuong, DonGiaNhap, ThanhTien; TinhThanhTien()",
             "Một dòng của phiếu nhập"],
            ["12", "LoaiDanhMuc", "Enum", "HangSanXuat, LoaiHang, MauSac, DungLuong",
             "Chọn nhóm thủ tục danh mục cần gọi"],
        ],
        do_rong=[1.1, 3.0, 2.4, 6.4, 4.4],
        canh_giua=[0],
        co=9.5,
    )

    b.h(3, "2.3.2. Quan hệ kế thừa và đa hình")
    b.p(
        "Học phần yêu cầu tối thiểu ba lớp được kế thừa từ lớp khác. Hệ thống có năm lớp kế thừa nằm "
        "trên ba lớp cơ sở trừu tượng. Mỗi lớp dẫn xuất vừa kế thừa thuộc tính và phương thức của lớp "
        "cha, vừa triển khai một giao diện và có thể ghi đè phương thức ảo để thể hiện tính đa hình."
    )
    b.bang(
        "Các lớp kế thừa trong hệ thống",
        ["STT", "Lớp dẫn xuất", "Lớp cơ sở", "Giao diện", "Ghi đè / bổ sung"],
        [
            ["1", "KhachHang", "Nguoi", "IKhachHang",
             "Ghi đè LayThongTin() và bổ sung LayThongTinRutGon(); hưởng TinhTuoi()"],
            ["2", "NhanVien", "Nguoi", "INhanVien",
             "Ghi đè LayThongTin() để in kèm vai trò; bổ sung KiemTraQuyenQuanLy()"],
            ["3", "HangHoa", "SanPhamBase", "IHangHoa",
             "Ghi đè LayMoTa(); hưởng TinhLoiNhuan(), TinhTyLeLoiNhuan(), TinhGiaTriTon()"],
            ["4", "HoaDonBan", "ChungTuBase", "IHoaDon",
             "Ghi đè TinhTongTien() để cộng từ danh sách chi tiết"],
            ["5", "HoaDonNhap", "ChungTuBase", "IHoaDonNhap",
             "Ghi đè TinhTongTien() và ánh xạ NgayNhap vào NgayLap của lớp cơ sở"],
        ],
        do_rong=[1.1, 3.0, 3.0, 2.8, 7.4],
        canh_giua=[0],
        co=10,
    )
    b.p(
        "Tính đa hình thể hiện rõ nhất ở phương thức TinhTongTien(): lớp ChungTuBase khai báo phương "
        "thức trừu tượng, mỗi lớp con cài đặt theo cách riêng, nhưng nơi gọi chỉ cần một biến kiểu "
        "ChungTuBase là có thể tính được tổng tiền của cả hóa đơn bán lẫn phiếu nhập. Tương tự, phương "
        "thức LayThongTin() của lớp Nguoi cho kết quả khác nhau khi đối tượng là khách hàng hay nhân viên."
    )

    b.h(3, "2.3.3. Quan hệ kết tập")
    b.p(
        "Hóa đơn và phiếu nhập thể hiện quan hệ kết tập: một chứng từ chứa nhiều dòng chi tiết, và các "
        "dòng chi tiết chỉ tồn tại trong phạm vi chứng từ đó. Trong mã nguồn, quan hệ này được cài đặt "
        "bằng thuộc tính ChiTietList kiểu List<ChiTietHoaDonBan> và List<ChiTietHoaDonNhap>. Khi lưu "
        "chứng từ, tầng nghiệp vụ duyệt danh sách này để ghi từng dòng và cộng ra tổng tiền."
    )

    b.h(3, "2.3.4. Tính đóng gói")
    b.p(
        "Các lớp thực thể đều đặt thuộc tính ở mức public vì chúng đóng vai trò hộp dữ liệu cho tầng giao "
        "diện; tuy nhiên những phần xử lý bên trong được che lại. Ví dụ lớp ChungTuBase có phương thức "
        "SinhMa() ở mức protected, chỉ lớp dẫn xuất dùng được để sinh mã chứng từ theo tiền tố riêng; lớp "
        "Nguoi có phương thức TinhTuoi() tính từ ngày sinh mà bên ngoài không cần biết cách tính. Ở tầng "
        "nghiệp vụ, mỗi lớp đều giữ đối tượng DAL trong trường private readonly và chỉ công khai các "
        "phương thức nghiệp vụ, nhờ vậy biểu mẫu không thể gọi vòng qua tầng nghiệp vụ để xuống thẳng cơ "
        "sở dữ liệu."
    )

    # ==================================================================
    b.h(2, "2.4. Mô hình cơ sở dữ liệu")

    b.p(
        "Cơ sở dữ liệu QLCuaHangBanDienThoai được thiết kế theo mô hình quan hệ và chuẩn hóa đến dạng "
        "ba. Hệ thống gồm mười hai bảng: bốn bảng danh mục tra cứu, bốn bảng đối tượng (nhà cung cấp, "
        "nhân viên, khách hàng, hàng hóa) và bốn bảng chứng từ (đầu và chi tiết của hóa đơn bán, hóa "
        "đơn nhập). Lược đồ quan hệ được trình bày ở Hình 2.3."
    )
    b.hinh("Lược đồ cơ sở dữ liệu quan hệ của hệ thống", os.path.join(HINH, "hinh_2_3_luoc_do_csdl.png"), 16.0)

    b.h(3, "2.4.1. Các bảng và thuộc tính")
    b.bang(
        "Cấu trúc các bảng trong cơ sở dữ liệu",
        ["Bảng", "Thuộc tính chính (kiểu dữ liệu)", "Khóa", "Ghi chú"],
        [
            ["tblHangSX", "MaHangSX NVARCHAR(20), TenHangSX NVARCHAR(100)", "PK: MaHangSX",
             "Danh mục hãng sản xuất"],
            ["tblLoai", "MaLoai NVARCHAR(20), TenLoai NVARCHAR(100)", "PK: MaLoai", "Danh mục loại hàng"],
            ["tblMau", "MaMau NVARCHAR(20), TenMau NVARCHAR(50)", "PK: MaMau", "Danh mục màu sắc"],
            ["tblDungLuong", "MaDungLuong NVARCHAR(20), TenDungLuong NVARCHAR(50)", "PK: MaDungLuong",
             "Danh mục dung lượng bộ nhớ"],
            ["tblNhaCungCap", "MaNCC NVARCHAR(20), TenNCC NVARCHAR(100), SDT NVARCHAR(20), "
                              "DiaChi NVARCHAR(200), Email NVARCHAR(255), NguoiLH NVARCHAR(100)",
             "PK: MaNCC", "Đối tác cung cấp hàng"],
            ["tblNhanVien", "MaNV NVARCHAR(20), TenNV NVARCHAR(100), GioiTinh NVARCHAR(10), NgaySinh DATE, "
                            "SDT NVARCHAR(20), DiaChi NVARCHAR(200), ChucVu NVARCHAR(50), "
                            "TaiKhoan NVARCHAR(50), MatKhau NVARCHAR(100), TrangThai NVARCHAR(50)",
             "PK: MaNV", "Tài khoản đăng nhập; mật khẩu lưu dạng chuỗi"],
            ["tblKhachHang", "MaKH NVARCHAR(20), TenKH NVARCHAR(100), SDT NVARCHAR(20), "
                             "DiaChi NVARCHAR(200), Email NVARCHAR(150)", "PK: MaKH", "Khách mua hàng"],
            ["tblHang", "MaHang NVARCHAR(20), TenHang NVARCHAR(200), MaHangSX, MaLoai, MaMau, MaDungLuong, "
                        "DonGiaNhap DECIMAL(18,2), DonGiaBan DECIMAL(18,2), SoLuongTon INT, MoTa NVARCHAR(500)",
             "PK: MaHang; FK tới bốn bảng danh mục", "Mặt hàng điện thoại"],
            ["tblHoaDonBan", "MaHDB NVARCHAR(30), MaNV, MaKH, NgayLap DATETIME, TongTien DECIMAL(18,2)",
             "PK: MaHDB; FK: MaNV, MaKH", "Đầu hóa đơn bán"],
            ["tblChiTietHDB", "MaHDB, MaHang, SoLuong INT, DonGia DECIMAL(18,2), GiamGia DECIMAL(5,2), "
                              "ThanhTien DECIMAL(18,2)",
             "PK: (MaHDB, MaHang); FK: MaHDB, MaHang", "Chi tiết hóa đơn bán"],
            ["tblHoaDonNhap", "MaHDN NVARCHAR(30), MaNV, MaNCC, NgayNhap DATETIME, TongTien DECIMAL(18,2)",
             "PK: MaHDN; FK: MaNV, MaNCC", "Đầu phiếu nhập"],
            ["tblChiTietHDN", "MaHDN, MaHang, SoLuong INT, DonGiaNhap DECIMAL(18,2), ThanhTien DECIMAL(18,2)",
             "PK: (MaHDN, MaHang); FK: MaHDN, MaHang", "Chi tiết phiếu nhập"],
        ],
        do_rong=[3.0, 8.6, 4.2, 4.0],
        co=9,
    )

    b.h(3, "2.4.2. Các truy vấn bằng thủ tục lưu trữ")
    b.p(
        "Toàn bộ truy vấn của ứng dụng được cài đặt thành 78 thủ tục lưu trữ, chia thành chín nhóm theo "
        "bảng mà thủ tục tác động. Mỗi thủ tục nhận tham số có kiểu rõ ràng, đặt SET NOCOUNT ON để không "
        "trả về thông báo số dòng thừa, và với các thủ tục cập nhật có điều kiện thì trả về số dòng đã "
        "tác động để tầng trên kiểm tra."
    )
    b.bang(
        "Các nhóm thủ tục lưu trữ trong cơ sở dữ liệu",
        ["Nhóm", "Số lượng", "Các thủ tục tiêu biểu"],
        [
            ["Hàng hóa", "8",
             "sp_LayDanhSachHang, sp_LayHangTheoMa, sp_LayDanhSachMaHang, sp_ThemHang, sp_CapNhatHang, "
             "sp_XoaHang, sp_KiemTraHangTonTai, sp_TimKiemHang"],
            ["Danh mục (4 bảng × 5)", "20",
             "sp_LayDanhSachHangSX, sp_ThemHangSX, sp_CapNhatHangSX, sp_XoaHangSX, sp_KiemTraHangSXTonTai "
             "và bộ tương tự cho Loai, Mau, DungLuong"],
            ["Khách hàng", "8",
             "sp_LayDanhSachKhachHang, sp_LayThongTinKhachHang, sp_ThemKhachHang, sp_CapNhatKhachHang, "
             "sp_XoaKhachHang, sp_LayHoaDonCuaKhachHang, …"],
            ["Nhà cung cấp", "7",
             "sp_LayDanhSachNhaCungCap, sp_LayThongTinNhaCungCap, sp_ThemNhaCungCap, "
             "sp_CapNhatNhaCungCap, sp_XoaNhaCungCap, …"],
            ["Nhân viên", "10",
             "sp_KiemTraDangNhap, sp_LayDanhSachNhanVien, sp_LayTenNhanVien, sp_ThemNhanVien, "
             "sp_CapNhatNhanVien, sp_CapNhatTrangThaiNhanVien, sp_XoaNhanVien, …"],
            ["Hóa đơn bán", "7",
             "sp_KiemTraHoaDonBanTonTai, sp_LayHoaDonBan, sp_LayChiTietHoaDonBan, sp_TruTonKho, "
             "sp_ThemHoaDonBan, sp_ThemChiTietHoaDonBan"],
            ["Hóa đơn nhập", "7",
             "sp_KiemTraHoaDonNhapTonTai, sp_LayHoaDonNhap, sp_LayChiTietHoaDonNhap, sp_CongTonKho, "
             "sp_ThemHoaDonNhap, sp_ThemChiTietHoaDonNhap"],
            ["Báo cáo", "3",
             "sp_BaoCaoDoanhThuTheoThang, sp_BaoCaoTonKho, sp_BaoCaoTopBanChay"],
            ["Thống kê Dashboard", "8",
             "sp_ThongKe_TongSanPham, sp_ThongKe_TongKhachHang, sp_ThongKe_HoaDonHomNay, "
             "sp_ThongKe_DoanhThuHomNay, sp_ThongKe_DoanhThu7Ngay, sp_ThongKe_Top5SanPhamBanChay, "
             "sp_ThongKe_SanPhamSapHetHang, sp_ThongKe_TongHangTonKho"],
        ],
        do_rong=[3.4, 1.8, 12.6],
        canh_giua=[1],
        co=9.5,
    )

    b.p("Ba thủ tục tiêu biểu được trình bày dưới đây để minh họa cách viết.", thut_dau=True)
    b.p("Thủ tục tìm kiếm hàng hóa nhận sáu tham số, mỗi tham số có giá trị mặc định NULL; khi tham số "
        "là NULL thì điều kiện tương ứng được bỏ qua, nhờ vậy chỉ cần một thủ tục mà đáp ứng mọi tổ hợp "
        "tiêu chí tìm kiếm:", thut_dau=True)
    b.ma_nguon(
        "CREATE OR ALTER PROCEDURE sp_TimKiemHang\n"
        "    @TenHang  NVARCHAR(200) = NULL,  @MaHangSX NVARCHAR(20)  = NULL,\n"
        "    @MaLoai   NVARCHAR(20)  = NULL,  @MaMau    NVARCHAR(20)  = NULL,\n"
        "    @GiaTu    DECIMAL(18,2) = NULL,  @GiaDen   DECIMAL(18,2) = NULL\n"
        "AS\n"
        "BEGIN\n"
        "    SET NOCOUNT ON;\n"
        "    SELECT h.MaHang, h.TenHang, hsx.TenHangSX AS Hang, l.TenLoai AS Loai,\n"
        "           m.TenMau AS Mau, dl.TenDungLuong AS DungLuong, h.DonGiaBan, h.SoLuongTon\n"
        "    FROM dbo.tblHang h\n"
        "    LEFT JOIN dbo.tblHangSX hsx ON h.MaHangSX = hsx.MaHangSX\n"
        "    LEFT JOIN dbo.tblLoai l ON h.MaLoai = l.MaLoai\n"
        "    LEFT JOIN dbo.tblMau m ON h.MaMau = m.MaMau\n"
        "    LEFT JOIN dbo.tblDungLuong dl ON h.MaDungLuong = dl.MaDungLuong\n"
        "    WHERE (@TenHang IS NULL OR h.TenHang LIKE N'%' + @TenHang + N'%')\n"
        "      AND (@MaHangSX IS NULL OR h.MaHangSX = @MaHangSX)\n"
        "      AND (@MaLoai   IS NULL OR h.MaLoai   = @MaLoai)\n"
        "      AND (@MaMau    IS NULL OR h.MaMau    = @MaMau)\n"
        "      AND (@GiaTu    IS NULL OR h.DonGiaBan >= @GiaTu)\n"
        "      AND (@GiaDen   IS NULL OR h.DonGiaBan <= @GiaDen)\n"
        "    ORDER BY h.TenHang;\n"
        "END;"
    )

    b.p("Thủ tục trừ tồn kho chỉ cập nhật khi số lượng còn đủ và trả về số dòng đã cập nhật, nhờ vậy "
        "tầng trên phát hiện được trường hợp bán vượt tồn kho:", thut_dau=True)
    b.ma_nguon(
        "CREATE OR ALTER PROCEDURE sp_TruTonKho\n"
        "    @MaHang NVARCHAR(20), @SoLuong INT\n"
        "AS\n"
        "BEGIN\n"
        "    SET NOCOUNT ON;\n"
        "    UPDATE dbo.tblHang\n"
        "       SET SoLuongTon = SoLuongTon - @SoLuong\n"
        "     WHERE MaHang = @MaHang AND SoLuongTon >= @SoLuong;\n"
        "    SELECT @@ROWCOUNT AS SoDong;   -- 0 nghĩa là không đủ tồn kho\n"
        "END;"
    )

    b.p("Thủ tục thống kê doanh thu bảy ngày gần nhất dùng bảng tạm đệ quy để sinh đủ bảy ngày, kể cả "
        "ngày không phát sinh hóa đơn, rồi ghép với bảng hóa đơn để ra doanh thu từng ngày. Nhờ vậy biểu "
        "đồ trên Dashboard luôn có đủ bảy cột:", thut_dau=True)
    b.ma_nguon(
        "CREATE OR ALTER PROCEDURE sp_ThongKe_DoanhThu7Ngay\n"
        "AS\n"
        "BEGIN\n"
        "    SET NOCOUNT ON;\n"
        "    ;WITH NgayGanDay AS (\n"
        "        SELECT CONVERT(date, DATEADD(day, -6, GETDATE())) AS Ngay\n"
        "        UNION ALL\n"
        "        SELECT DATEADD(day, 1, Ngay) FROM NgayGanDay\n"
        "         WHERE Ngay < CONVERT(date, GETDATE())\n"
        "    )\n"
        "    SELECT n.Ngay, ISNULL(SUM(h.TongTien), 0) AS DoanhThu\n"
        "    FROM NgayGanDay n\n"
        "    LEFT JOIN dbo.tblHoaDonBan h\n"
        "           ON h.NgayLap >= n.Ngay AND h.NgayLap < DATEADD(day, 1, n.Ngay)\n"
        "    GROUP BY n.Ngay ORDER BY n.Ngay\n"
        "    OPTION (MAXRECURSION 7);\n"
        "END;"
    )

    b.h(3, "2.4.3. Các cập nhật dữ liệu và tính nhất quán")
    b.p(
        "Những thao tác chỉ tác động một bảng (thêm, sửa, xóa hàng hóa, khách hàng, nhà cung cấp, nhân "
        "viên, danh mục) được thực hiện bằng một thủ tục duy nhất. Những nghiệp vụ tác động nhiều bảng "
        "cùng lúc là lưu hóa đơn bán và lưu phiếu nhập; với hai nghiệp vụ này, tầng truy cập dữ liệu mở "
        "một giao dịch (transaction) rồi gọi lần lượt các thủ tục: kiểm tra trùng mã, trừ (hoặc cộng) tồn "
        "kho, ghi đầu chứng từ và ghi từng dòng chi tiết. Nếu một bước trả về kết quả không như mong đợi, "
        "ngoại lệ được ném ra và giao dịch được hoàn tác, nhờ vậy không bao giờ có chuyện đã trừ kho mà "
        "chưa ghi hóa đơn."
    )
    b.p(
        "Ngoài ra cơ sở dữ liệu còn có các ràng buộc bảo vệ dữ liệu: khóa ngoại giữa bảng hàng với bốn "
        "bảng danh mục và giữa bảng chi tiết với bảng đầu chứng từ; ràng buộc kiểm tra số lượng bán lớn "
        "hơn 0 và mức giảm giá nằm trong khoảng 0 đến 100; giá trị mặc định 0 cho các cột tiền và tồn "
        "kho; cùng các chỉ mục trên cột tên hàng, ngày lập hóa đơn để tăng tốc tìm kiếm và báo cáo."
    )

    b.h(3, "2.4.4. Dữ liệu mẫu phục vụ kiểm thử")
    b.p(
        "Kịch bản tạo cơ sở dữ liệu không chỉ tạo bảng mà còn nạp dữ liệu mẫu để ứng dụng có nội dung "
        "ngay sau khi cài đặt. Dữ liệu mẫu gồm sáu hãng sản xuất, bốn loại hàng, bảy màu, năm dung lượng, "
        "năm nhà cung cấp, tám nhân viên, mười khách hàng, ba mươi mặt hàng và bảy hóa đơn bán, ba phiếu "
        "nhập. Ngoài ra kịch bản còn sinh thêm bảy hóa đơn đánh số TEST001 đến TEST007 với ngày lập lùi "
        "dần trong bảy ngày gần nhất, mục đích là để biểu đồ doanh thu trên Dashboard có đủ cột ngay lần "
        "chạy đầu tiên, kể cả khi máy chấm bài chưa phát sinh giao dịch nào."
    )
    b.bang(
        "Dữ liệu mẫu theo bảng",
        ["Bảng", "Số bản ghi", "Ghi chú"],
        [
            ["tblHangSX", "6", "Apple, Samsung, Xiaomi, OPPO, Vivo, Realme"],
            ["tblLoai", "4", "Cao cấp, tầm trung, phổ thông, máy tính bảng"],
            ["tblMau", "7", "Đen, trắng, xanh dương, đỏ, vàng, hồng, xám"],
            ["tblDungLuong", "5", "64GB đến 1TB"],
            ["tblNhaCungCap", "5", "Kèm email và người liên hệ"],
            ["tblNhanVien", "8", "Hai quản lý, sáu nhân viên; mật khẩu mẫu 123456"],
            ["tblKhachHang", "10", "Kèm email"],
            ["tblHang", "30", "Đủ bốn hãng lớn, có giá nhập và giá bán"],
            ["tblHoaDonBan", "7 + 7", "Bảy hóa đơn tháng 10 và bảy hóa đơn TEST cho Dashboard"],
            ["tblChiTietHDB", "9", "Một số hóa đơn có hai dòng chi tiết để thử giảm giá"],
            ["tblHoaDonNhap", "3", "Ba phiếu nhập từ ba nhà cung cấp"],
            ["tblChiTietHDN", "6", "Có mặt hàng xuất hiện ở hai phiếu để thử cộng dồn tồn kho"],
        ],
        do_rong=[4.2, 3.0, 9.8],
        co=10.5,
    )

    # ==================================================================
    b.h(2, "2.5. Các tiện ích")

    b.p(
        "Nhóm gom những đoạn mã lặp lại ở nhiều biểu mẫu vào lớp tiện ích AppHelpers trong thư mục "
        "Utilities. Đây là lớp tĩnh, không cần khởi tạo đối tượng, gồm mười sáu class method chia làm "
        "sáu nhóm chức năng: kiểm tra dữ liệu, định dạng và đọc số tiền, chuẩn hóa chuỗi tìm kiếm, ghi "
        "nhật ký, hiển thị thông báo và xử lý ảnh sản phẩm."
    )
    b.bang(
        "Các class method trong lớp tiện ích AppHelpers",
        ["STT", "Phương thức", "Tham số", "Kết quả / công dụng"],
        [
            ["1", "KiemTraSoDienThoai", "string? sdt", "true nếu đúng 10 chữ số và bắt đầu bằng 0"],
            ["2", "KiemTraEmail", "string? email", "true nếu đúng dạng ten@mien; chuỗi rỗng vẫn hợp lệ"],
            ["3", "KiemTraSoNguyenKhongAm", "string? chuoi, out int giaTri", "Kiểm tra số nguyên không âm"],
            ["4", "DinhDangTien", "decimal tien", "Chuỗi kiểu Việt Nam, ví dụ 32.000.000"],
            ["5", "DinhDangTienVnd", "decimal tien", "Chuỗi kèm đơn vị, ví dụ 32.000.000 ₫"],
            ["6", "DinhDangNgay", "DateTime ngay", "Chuỗi ngày dạng dd/MM/yyyy"],
            ["7", "DocSoTien", "string? chuoi, out decimal giaTri", "Đọc số tiền người dùng nhập, bỏ dấu phân cách"],
            ["8", "ChuanHoaChuoi", "string? chuoi", "Cắt khoảng trắng thừa, gộp khoảng trắng giữa"],
            ["9", "TaoTuKhoaTimKiem", "string? tuKhoa", "Chuỗi an toàn để đưa vào RowFilter của DataView"],
            ["10", "GhiLog", "string noiDung", "Ghi nhật ký thao tác ra thư mục Logs"],
            ["11", "HienThongBao", "string noiDung", "Hộp thoại thông báo thống nhất"],
            ["12", "HienCanhBao", "string noiDung", "Hộp thoại cảnh báo thống nhất"],
            ["13", "XacNhan", "string noiDung", "Hộp thoại xác nhận, trả về true nếu chọn Có"],
            ["14", "ThuMucAnh", "(thuộc tính)", "Đường dẫn thư mục Images cạnh tệp chạy"],
            ["15", "SaoChepAnh", "string duongDanNguon", "Chép ảnh người dùng chọn vào thư mục Images"],
            ["16", "ViVn", "(trường tĩnh)", "Đối tượng CultureInfo vi-VN dùng chung"],
        ],
        do_rong=[1.1, 4.6, 5.6, 6.5],
        canh_giua=[0],
        co=9.5,
    )
    b.p(
        "Nhờ lớp tiện ích, quy tắc kiểm tra số điện thoại chỉ được viết một lần nhưng dùng cho cả khách "
        "hàng, nhà cung cấp và nhân viên; cách định dạng tiền cũng thống nhất trên mọi biểu mẫu và trong "
        "tệp Excel xuất ra, tránh tình trạng mỗi form hiển thị một kiểu."
    )
