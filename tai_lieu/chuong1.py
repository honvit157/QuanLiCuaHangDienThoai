"""Chương 1 - Giới thiệu về đề tài."""

import os

from docx.enum.text import WD_ALIGN_PARAGRAPH

from tai_lieu import bieu_do

HINH = os.path.join(os.path.dirname(os.path.abspath(__file__)), "hinh")


def viet(b):
    b.chuong_moi(1, "GIỚI THIỆU VỀ ĐỀ TÀI")

    # ------------------------------------------------------------------
    b.h(2, "1.1. Giới thiệu về đề tài")

    b.h(3, "1.1.1. Lý do chọn đề tài")
    b.p(
        "Trong những năm gần đây, thị trường bán lẻ điện thoại di động tại Việt Nam tăng trưởng "
        "nhanh và có tính cạnh tranh cao. Một cửa hàng quy mô vừa và nhỏ mỗi ngày có thể phát sinh "
        "hàng chục giao dịch bán hàng, hàng chục phiếu nhập từ nhà phân phối, kèm theo việc theo dõi "
        "tồn kho của hàng trăm mã sản phẩm khác nhau theo hãng, loại, màu sắc và dung lượng bộ nhớ. "
        "Nếu quản lý bằng sổ sách hoặc bằng bảng tính rời rạc thì rất dễ xảy ra các sai sót quen thuộc: "
        "bán quá số lượng còn trong kho, nhập hàng nhưng quên cập nhật giá vốn, không biết mặt hàng nào "
        "bán chạy để nhập thêm, hoặc không đối chiếu được doanh thu từng ngày."
    )
    b.p(
        "Một hệ thống quản lý tập trung giải quyết đúng những vấn đề đó: dữ liệu hàng hóa, khách hàng, "
        "nhà cung cấp, nhân viên và hóa đơn được lưu trong cùng một cơ sở dữ liệu quan hệ; mọi thay đổi "
        "tồn kho đều gắn với một chứng từ cụ thể; và người quản lý có thể nhìn thấy tình hình kinh doanh "
        "ngay khi mở ứng dụng. Vì vậy nhóm chọn đề tài “Xây dựng ứng dụng quản lý cửa hàng điện thoại” "
        "làm bài tập lớn cho học phần Lập trình trực quan."
    )
    b.p(
        "Đề tài cũng là dịp để nhóm vận dụng một cách có hệ thống những kiến thức đã học: lập trình "
        "hướng đối tượng với lớp, lớp trừu tượng, giao diện, kế thừa và đa hình; lập trình giao diện "
        "Windows Forms; truy cập cơ sở dữ liệu bằng ADO.NET; và đặc biệt là tổ chức chương trình theo "
        "mô hình ba tầng (GUI – BUS – DAL) với toàn bộ truy vấn đặt trong thủ tục lưu trữ (Stored "
        "Procedure) trên SQL Server."
    )

    b.h(3, "1.1.2. Mục tiêu của đề tài")
    b.p("Nhóm đặt ra bốn mục tiêu cụ thể cho bài tập lớn:", thut_dau=True)
    b.p_gach(
        "Xây dựng được ứng dụng desktop chạy ổn định trên Windows, có đăng nhập và phân quyền giữa "
        "quản lý và nhân viên."
    )
    b.p_gach(
        "Thực hiện đầy đủ bốn nhóm chức năng nghiệp vụ: quản lý danh mục và hàng hóa; quản lý đối tác "
        "(khách hàng, nhà cung cấp, nhân viên); lập và tra cứu hóa đơn bán – hóa đơn nhập; báo cáo "
        "thống kê và xuất tệp Excel."
    )
    b.p_gach(
        "Tổ chức mã nguồn theo mô hình ba tầng, mỗi tầng chỉ giao tiếp với tầng liền kề; tầng truy cập "
        "dữ liệu không chứa câu lệnh SQL viết trực tiếp mà chỉ gọi thủ tục lưu trữ."
    )
    b.p_gach(
        "Vận dụng đầy đủ các kỹ thuật hướng đối tượng theo yêu cầu của học phần: tối thiểu 5 giao diện, "
        "các lớp triển khai giao diện, tối thiểu 3 lớp kế thừa, quan hệ kết tập và các lớp tiện ích "
        "chứa class method dùng chung."
    )

    b.h(3, "1.1.3. Phạm vi và đối tượng sử dụng")
    b.p(
        "Phạm vi của đề tài là một cửa hàng bán lẻ điện thoại có một điểm bán, có nhiều nhân viên và "
        "làm việc với vài nhà cung cấp. Hệ thống không xử lý các nghiệp vụ đặc thù của chuỗi nhiều chi "
        "nhánh như điều chuyển kho giữa các cửa hàng, không tích hợp cổng thanh toán trực tuyến và "
        "không kết nối với sàn thương mại điện tử. Ứng dụng chạy trên máy tính để bàn trong nội bộ cửa "
        "hàng và dùng chung một cơ sở dữ liệu SQL Server đặt tại máy chủ của cửa hàng."
    )
    b.p("Hệ thống phục vụ hai nhóm người dùng với quyền hạn khác nhau:", thut_dau=True)
    b.bang(
        "Đối tượng sử dụng và quyền hạn trong hệ thống",
        ["STT", "Đối tượng", "Cách truy cập", "Quyền hạn chính"],
        [
            ["1", "Quản lý cửa hàng",
             "Đăng nhập bằng tài khoản có chức vụ “Quản lý”",
             "Toàn bộ chức năng: quản lý hàng hóa, danh mục, nhân viên, khách hàng, nhà cung cấp, "
             "lập hóa đơn bán – nhập, xem báo cáo và Dashboard."],
            ["2", "Nhân viên bán hàng",
             "Đăng nhập bằng tài khoản có chức vụ “Nhân viên”",
             "Bán hàng, lập hóa đơn bán, tra cứu hàng hóa và khách hàng; mục “Nhân viên” bị ẩn khỏi "
             "menu nên không sửa được hồ sơ nhân sự."],
        ],
        do_rong=[1.2, 3.4, 5.4, 6.0],
        canh_giua=[0],
    )

    b.h(3, "1.1.4. Khảo sát hiện trạng và yêu cầu đặt ra")
    b.p(
        "Trước khi viết mã, nhóm khảo sát cách một cửa hàng điện thoại quy mô nhỏ đang làm việc. Kết quả "
        "khảo sát cho thấy ba vấn đề lặp lại. Thứ nhất, hàng hóa được ghi trong sổ theo tên gọi tự do nên "
        "cùng một mẫu máy có thể được ghi thành nhiều tên khác nhau, dẫn tới việc không đối chiếu được số "
        "lượng tồn. Thứ hai, khi bán hàng, nhân viên thường không kiểm tra tồn kho trước khi nhận tiền, "
        "đến lúc lấy hàng mới phát hiện đã hết. Thứ ba, cuối tháng người quản lý phải cộng tay doanh thu "
        "từ nhiều tờ hóa đơn giấy nên mất thời gian và dễ sai."
    )
    b.p(
        "Từ hiện trạng đó, nhóm xác định năm yêu cầu chức năng bắt buộc và bốn yêu cầu phi chức năng cho "
        "hệ thống. Năm yêu cầu chức năng là: quản lý danh mục hàng hóa thống nhất; lập hóa đơn bán có "
        "kiểm tra tồn kho; lập phiếu nhập có cập nhật giá vốn; tra cứu hàng hóa theo nhiều tiêu chí; và "
        "báo cáo doanh thu, tồn kho, mặt hàng bán chạy. Bốn yêu cầu phi chức năng là: giao diện tiếng "
        "Việt, dễ dùng với nhân viên không rành máy tính; thao tác thường gặp phải xong trong vài giây; "
        "dữ liệu phải nhất quán, không chấp nhận hóa đơn trừ kho thất bại; và mã nguồn phải đủ rõ ràng để "
        "các thành viên khác trong nhóm đọc hiểu, sửa tiếp."
    )
    b.bang(
        "Yêu cầu chức năng và cách hệ thống đáp ứng",
        ["STT", "Yêu cầu", "Cách đáp ứng trong sản phẩm"],
        [
            ["1", "Danh mục hàng hóa thống nhất",
             "Hàng hóa tham chiếu tới bốn bảng danh mục (hãng, loại, màu, dung lượng) bằng khóa ngoại, "
             "Form5 quản lý bốn danh mục đó"],
            ["2", "Bán hàng có kiểm tra tồn kho",
             "sp_TruTonKho chỉ trừ khi đủ hàng và trả về số dòng đã trừ; hóa đơn được lưu trong một giao dịch"],
            ["3", "Nhập hàng cập nhật giá vốn",
             "sp_CongTonKho cộng tồn kho và cập nhật DonGiaNhap mới nhất của mặt hàng"],
            ["4", "Tra cứu nhiều tiêu chí",
             "sp_TimKiemHang với sáu tham số lọc tùy chọn, dùng cho Form6 và tìm nhanh trên Form1"],
            ["5", "Báo cáo và tổng quan",
             "Ba thủ tục báo cáo cho FormBaoCao, tám thủ tục thống kê cho Dashboard Form10"],
        ],
        do_rong=[1.2, 5.2, 11.6],
        canh_giua=[0],
        co=10.5,
    )
    b.p(
        "Về giới hạn kỹ thuật, nhóm thống nhất chỉ dùng những công nghệ có sẵn trong học phần để bảo đảm "
        "mọi thành viên đều chạy được trên máy của mình: Windows Forms trên .NET, SQL Server bản Express "
        "và thư viện ClosedXML cho phần xuất Excel. Cơ sở dữ liệu đặt trên máy cục bộ, chuỗi kết nối dùng "
        "xác thực Windows nên không phải cấu hình tài khoản SQL riêng."
    )

    # ------------------------------------------------------------------
    b.h(2, "1.2. Kế hoạch làm đề tài")

    b.p(
        "Nhóm làm việc trong sáu tuần. Tuần đầu dùng để khảo sát nghiệp vụ và thống nhất phạm vi; các "
        "tuần tiếp theo chia theo tầng của kiến trúc: tuần 2 thiết kế cơ sở dữ liệu và thủ tục lưu trữ, "
        "tuần 3 dựng khung ba tầng cùng các lớp thực thể, tuần 4 và 5 hoàn thiện giao diện và nghiệp vụ, "
        "tuần 6 kiểm thử, viết báo cáo và chuẩn bị slide thuyết trình."
    )
    b.bang(
        "Kế hoạch thực hiện theo tuần",
        ["Tuần", "Nội dung công việc", "Kết quả bàn giao"],
        [
            ["1", "Khảo sát quy trình bán hàng và nhập hàng thực tế; xác định chức năng, đối tượng sử dụng",
             "Danh sách chức năng, sơ đồ use case mức thô"],
            ["2", "Thiết kế lược đồ quan hệ 12 bảng; viết thủ tục lưu trữ cho từng nhóm nghiệp vụ",
             "InitDb.sql, StoredProcedures.sql"],
            ["3", "Dựng khung ba tầng; xây dựng lớp thực thể, giao diện và lớp tiện ích",
             "DTO, Interfaces, Utilities, DAL nền"],
            ["4", "Viết tầng nghiệp vụ; hoàn thiện Form quản lý hàng hóa, danh mục, đối tác",
             "BUS, Form1 – Form6"],
            ["5", "Lập hóa đơn bán, hóa đơn nhập; báo cáo thống kê; Dashboard tổng quan",
             "Form7, Form8, FormBaoCao, Form10"],
            ["6", "Kiểm thử theo kịch bản, sửa lỗi, viết báo cáo và làm slide",
             "Báo cáo Word, slide thuyết trình"],
        ],
        do_rong=[1.6, 9.0, 5.2],
        canh_giua=[0],
    )
    b.p(
        "Về phân công, mỗi thành viên phụ trách một nhóm chức năng và chịu trách nhiệm chính ở một tầng "
        "của kiến trúc, sau đó cả nhóm cùng rà soát chéo. Bảng phân công chi tiết và phần đánh giá chéo "
        "được trình bày ở trang bìa của báo cáo và trong biên bản làm việc của nhóm."
    )

    # ------------------------------------------------------------------
    b.h(2, "1.3. Các công nghệ sử dụng")

    b.h(3, "1.3.1. Ngôn ngữ C# và nền tảng .NET")
    b.p(
        "Ứng dụng được viết bằng C# trên nền .NET với mô hình dự án SDK-style, hướng tới "
        "khung đích net10.0-windows. C# là ngôn ngữ hướng đối tượng đầy đủ, hỗ trợ lớp trừu tượng, "
        "giao diện, kế thừa, đa hình, thuộc tính tự động và các tính năng hiện đại như kiểu nullable, "
        "biểu thức switch hay toán tử điều kiện null, giúp mã nguồn ngắn gọn và an toàn hơn."
    )

    b.h(3, "1.3.2. Windows Forms")
    b.p(
        "Windows Forms là thư viện giao diện có sẵn của .NET, cho phép kéo thả để tạo biểu mẫu và xử lý "
        "sự kiện theo mô hình hướng sự kiện. Mỗi biểu mẫu gồm hai tệp: tệp Designer mô tả các control và "
        "tệp mã xử lý logic. Trong báo cáo này, toàn bộ giao diện của các biểu mẫu được giữ nguyên theo "
        "bản thiết kế mới nhất của nhóm; phần mã chỉ thay đổi cách lấy dữ liệu để tuân thủ mô hình ba tầng."
    )

    b.h(3, "1.3.3. ADO.NET và SQL Server")
    b.p(
        "ADO.NET là công nghệ truy cập dữ liệu của .NET. Ứng dụng dùng các đối tượng SqlConnection, "
        "SqlCommand, SqlParameter, SqlDataAdapter và SqlDataReader thuộc gói Microsoft.Data.SqlClient "
        "để làm việc với SQL Server. Điểm quan trọng trong thiết kế của nhóm là mọi lệnh gửi xuống máy "
        "chủ đều có CommandType là StoredProcedure, nghĩa là câu lệnh SQL nằm trong cơ sở dữ liệu chứ "
        "không nằm trong mã C#."
    )
    b.p(
        "Cơ sở dữ liệu QLCuaHangBanDienThoai gồm 12 bảng, có khóa chính, khóa ngoại và ràng buộc kiểm "
        "tra; toàn bộ thủ tục lưu trữ được tạo bằng một tệp kịch bản duy nhất để có thể cài đặt lại "
        "nhanh trên máy khác. Chi tiết lược đồ và danh sách thủ tục được trình bày ở mục 2.4."
    )

    b.h(3, "1.3.4. Thủ tục lưu trữ (Stored Procedure)")
    b.p(
        "Thủ tục lưu trữ là một chương trình con được biên dịch sẵn và lưu trong SQL Server. Sử dụng "
        "thủ tục lưu trữ đem lại ba lợi ích rõ rệt cho bài toán này: thứ nhất, câu lệnh SQL tập trung "
        "một chỗ nên dễ rà soát và sửa; thứ hai, tham số truyền vào được xử lý như tham số của hàm, "
        "hạn chế lỗi ghép chuỗi và giảm nguy cơ tấn công chèn SQL; thứ ba, các nghiệp vụ nhiều bước "
        "như trừ tồn kho rồi mới ghi hóa đơn có thể gói trong một giao dịch ngay tại máy chủ."
    )

    b.h(3, "1.3.5. ClosedXML và báo cáo Excel")
    b.p(
        "Để xuất danh sách hàng hóa, hóa đơn và báo cáo thống kê ra tệp Excel, nhóm dùng thư viện mã "
        "nguồn mở ClosedXML. Thư viện này cho phép tạo bảng tính, đặt tiêu đề, tô màu, kẻ khung và định "
        "dạng số tiền theo kiểu Việt Nam chỉ bằng vài dòng mã, không cần cài Microsoft Excel trên máy "
        "phát triển. Cần lưu ý rằng học phần yêu cầu dùng Crystal Report cho chức năng báo cáo; nhóm "
        "hiện xuất báo cáo ra tệp Excel nên phần này chỉ đạt mức điểm thấp hơn, điều này được ghi rõ "
        "trong phần hạn chế của báo cáo."
    )

    b.h(3, "1.3.6. Mô hình ba tầng và Git")
    b.p(
        "Kiến trúc ba tầng tách ứng dụng thành tầng giao diện (GUI), tầng nghiệp vụ (BUS) và tầng truy "
        "cập dữ liệu (DAL). Cách tách này giúp thay đổi giao diện mà không ảnh hưởng nghiệp vụ, và thay "
        "đổi cách lưu trữ mà không phải sửa các biểu mẫu. Ngoài ra nhóm dùng Git và GitHub để quản lý "
        "phiên bản: mỗi thành viên làm trên một nhánh riêng, sau đó gộp vào nhánh main sau khi rà soát, "
        "nhờ vậy không ghi đè công việc của nhau."
    )
