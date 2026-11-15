"""Nội dung Chương 1 của báo cáo bài tập lớn."""


def viet(b):
    b.chuong_moi(1, "GIỚI THIỆU VỀ ĐỀ TÀI")

    # ==================================================================
    b.h(2, "1.1. Giới thiệu về đề tài")

    b.p(
        "Thị trường bán lẻ thiết bị di động tại Việt Nam trong những năm gần đây tăng trưởng nhanh "
        "và có mức độ cạnh tranh cao. Chỉ tính riêng các thương hiệu phổ biến như Apple, Samsung, "
        "Xiaomi, OPPO, Vivo hay Realme, mỗi thương hiệu đã tung ra hàng chục mẫu máy với nhiều phiên bản "
        "dung lượng, màu sắc và cấu hình khác nhau trong một năm. Một cửa hàng bán lẻ quy mô vừa thường "
        "phải quản lý vài trăm mã hàng cùng lúc, trong khi giá nhập và giá bán thay đổi liên tục theo "
        "đợt khuyến mại của nhà sản xuất. Bên cạnh hàng hóa, cửa hàng còn phải lưu thông tin khách hàng, "
        "nhà cung cấp, nhân viên bán hàng và toàn bộ lịch sử giao dịch để phục vụ đối chiếu, bảo hành "
        "và tính doanh thu."
    )
    b.p(
        "Trên thực tế, phần lớn cửa hàng nhỏ vẫn quản lý bằng sổ sách giấy hoặc bằng những bảng tính "
        "Excel rời rạc, mỗi nhân viên giữ một tệp riêng. Cách làm này bộc lộ nhiều hạn chế: dữ liệu trùng "
        "lặp và không thống nhất giữa các tệp, số lượng tồn kho không được cập nhật ngay sau mỗi lần bán "
        "nên dễ xảy ra tình trạng bán vượt số lượng thực có, việc tra cứu một hóa đơn cũ mất nhiều thời "
        "gian, và người quản lý không có báo cáo tổng hợp kịp thời để ra quyết định nhập hàng. Ngoài ra, "
        "khi một nhân viên nghỉ việc, tệp dữ liệu do người đó quản lý có thể bị thất lạc hoàn toàn."
    )
    b.p(
        "Từ những bất cập đó, nhóm lựa chọn đề tài “Xây dựng ứng dụng quản lý cửa hàng điện thoại” nhằm "
        "tin học hóa các nghiệp vụ cơ bản nhất của một cửa hàng bán lẻ thiết bị di động. Ứng dụng được "
        "xây dựng dưới dạng chương trình máy tính để bàn chạy trên nền Windows Forms, sử dụng ngôn ngữ C# "
        "và hệ quản trị cơ sở dữ liệu Microsoft SQL Server. Về mặt học thuật, đề tài là dịp để nhóm vận "
        "dụng đồng thời các nội dung cốt lõi của học phần Lập trình trực quan: lập trình hướng đối tượng, "
        "thiết kế giao diện, truy cập cơ sở dữ liệu bằng ADO.NET và tổ chức chương trình theo kiến trúc "
        "nhiều tầng."
    )
    b.p(
        "Bài toán nghiệp vụ mà ứng dụng giải quyết gồm bảy nhóm công việc. Thứ nhất là quản lý danh mục "
        "hàng hóa cùng bốn danh mục tra cứu đi kèm: hãng sản xuất, loại hàng, màu sắc và dung lượng bộ nhớ. "
        "Thứ hai là quản lý hồ sơ nhân viên kèm tài khoản đăng nhập và chức vụ để phân quyền sử dụng. "
        "Thứ ba là quản lý thông tin khách hàng và nhà cung cấp. Thứ tư là lập hóa đơn bán hàng, trong đó "
        "hệ thống tự động trừ số lượng tồn kho và không cho phép bán vượt quá số lượng đang có. Thứ năm là "
        "lập hóa đơn nhập hàng, tự động cộng tồn kho và cập nhật giá nhập mới nhất cho mặt hàng. Thứ sáu là "
        "tra cứu hàng hóa theo nhiều tiêu chí kết hợp như tên, hãng, loại, màu và khoảng giá. Thứ bảy là "
        "tổng hợp báo cáo doanh thu theo tháng, báo cáo tồn kho và danh sách các mặt hàng bán chạy."
    )
    b.p(
        "Phạm vi của đề tài được giới hạn ở mô hình một cửa hàng đơn lẻ, dữ liệu đặt trên một máy chủ SQL "
        "Server và ứng dụng chạy trên máy trạm trong nội bộ cửa hàng. Đề tài chưa xử lý các nghiệp vụ mở "
        "rộng như quản lý bảo hành, quản lý trả hàng, thanh toán trực tuyến, quản lý nhiều chi nhánh hay "
        "đồng bộ dữ liệu qua Internet. Các phần này được trình bày ở mục hạn chế và hướng phát triển của "
        "báo cáo để làm rõ ranh giới của sản phẩm."
    )
    b.p(
        "Người sử dụng hệ thống được chia thành hai nhóm. Nhóm thứ nhất là quản lý cửa hàng, có toàn quyền "
        "trên mọi chức năng, bao gồm cả việc thêm, sửa, xóa nhân viên và xem toàn bộ báo cáo. Nhóm thứ hai "
        "là nhân viên bán hàng, được phép tra cứu hàng hóa, lập hóa đơn bán, lập phiếu nhập và quản lý "
        "thông tin khách hàng, nhưng không được xóa nhân viên và không được đổi trạng thái làm việc của "
        "người khác. Việc phân quyền này được kiểm tra ngay sau khi đăng nhập và được áp dụng nhất quán ở "
        "cả tầng giao diện lẫn tầng nghiệp vụ."
    )

    b.p("Mục tiêu cụ thể của đề tài được xác định như sau:", thut_dau=False)
    for muc in (
        "Xây dựng cơ sở dữ liệu quan hệ trên SQL Server gồm mười hai bảng, có khóa chính, khóa ngoại và "
        "ràng buộc kiểm tra để bảo đảm tính toàn vẹn dữ liệu.",
        "Xây dựng hệ thống gồm mười một biểu mẫu (Form) chạy trên Windows Forms, bao phủ toàn bộ nghiệp vụ "
        "đã nêu, giao diện tiếng Việt, thao tác được bằng bàn phím và chuột.",
        "Áp dụng đầy đủ bốn tính chất của lập trình hướng đối tượng: đóng gói, kế thừa, đa hình và trừu "
        "tượng hóa, thông qua năm giao diện (interface) và các lớp cơ sở dùng chung.",
        "Tổ chức mã nguồn theo kiến trúc ba tầng GUI - BUS - DAL, trong đó tầng giao diện không chứa câu "
        "lệnh SQL và tầng truy cập dữ liệu chỉ làm việc với thủ tục lưu trữ.",
        "Chuyển toàn bộ truy vấn sang thủ tục lưu trữ (Stored Procedure) nhằm giảm phụ thuộc giữa mã C# "
        "và cấu trúc bảng, đồng thời hạn chế nguy cơ tấn công chèn mã SQL.",
        "Cung cấp chức năng xuất báo cáo và hóa đơn ra tệp Excel để giáo viên và người quản lý có thể đối "
        "chiếu số liệu, in ấn hoặc lưu trữ ngoài ứng dụng.",
    ):
        b.p_gach(muc)

    b.p(
        "Bảng 1.1 tổng hợp các yêu cầu chức năng của hệ thống, kèm theo người dùng được phép thực hiện và "
        "kết quả mong đợi của từng chức năng."
    )

    b.bang(
        "Bảng yêu cầu chức năng của hệ thống",
        ["STT", "Nhóm chức năng", "Người dùng", "Mô tả và kết quả mong đợi"],
        [
            ["1", "Đăng nhập và phân quyền", "Tất cả",
             "Nhập tài khoản và mật khẩu; hệ thống kiểm tra trong bảng tblNhanVien, "
             "lưu thông tin phiên làm việc và ẩn/hiện các chức năng theo chức vụ."],
            ["2", "Quản lý hàng hóa", "Quản lý, nhân viên",
             "Xem danh sách hàng dạng bảng, thêm, sửa, xóa mặt hàng; chọn ảnh minh họa; "
             "tìm nhanh theo mã hoặc tên."],
            ["3", "Quản lý bốn danh mục", "Quản lý, nhân viên",
             "Thêm, sửa, xóa hãng sản xuất, loại hàng, màu sắc, dung lượng; chặn xóa nếu "
             "danh mục đang được dùng cho mặt hàng."],
            ["4", "Quản lý nhân viên", "Quản lý", "Xem, thêm, sửa nhân viên; chỉ quản lý được xóa nhân viên "
             "và đổi trạng thái đang làm việc / đã nghỉ việc."],
            ["5", "Quản lý khách hàng", "Quản lý, nhân viên",
             "Xem, thêm, sửa, xóa khách hàng; kiểm tra số điện thoại và email; chặn xóa "
             "khách hàng đã có hóa đơn."],
            ["6", "Quản lý nhà cung cấp", "Quản lý, nhân viên",
             "Xem, thêm, sửa, xóa nhà cung cấp; chặn xóa nhà cung cấp đã có hóa đơn nhập."],
            ["7", "Lập hóa đơn bán hàng", "Quản lý, nhân viên",
             "Chọn nhân viên, khách hàng, mặt hàng, số lượng và mức giảm giá; hệ thống tính "
             "thành tiền, tổng tiền, trừ tồn kho trong một giao dịch và xuất hóa đơn ra Excel."],
            ["8", "Lập hóa đơn nhập hàng", "Quản lý, nhân viên",
             "Chọn nhà cung cấp và các mặt hàng cần nhập; hệ thống cộng tồn kho, cập nhật giá "
             "nhập, ghi chi tiết và xuất phiếu nhập ra Excel."],
            ["9", "Tìm kiếm hàng hóa", "Quản lý, nhân viên",
             "Lọc theo tên, hãng, loại, màu và khoảng giá; hiển thị số lượng kết quả và xuất "
             "danh sách ra Excel."],
            ["10", "Báo cáo - thống kê", "Quản lý",
             "Xem doanh thu theo tháng, giá trị tồn kho và top 10 mặt hàng bán chạy; xuất báo "
             "cáo ba trang tính ra Excel."],
        ],
        do_rong=[1.2, 3.4, 2.6, 7.8],
        canh_giua=[0, 1, 2],
        co=10.5,
    )

    b.p(
        "Ngoài các yêu cầu chức năng, nhóm đặt ra năm yêu cầu phi chức năng để bảo đảm chất lượng sản phẩm. "
        "Về hiệu năng, các lưới dữ liệu phải hiển thị dưới một giây với cơ sở dữ liệu khoảng mười nghìn dòng "
        "nhờ phân trang tự động của DataGridView và nhờ chỉ mục trên các cột thường tìm kiếm. Về toàn vẹn "
        "dữ liệu, mọi thao tác ảnh hưởng đến nhiều bảng (lưu hóa đơn, trừ hoặc cộng tồn kho) đều phải nằm "
        "trong một giao dịch để hoặc thành công toàn bộ, hoặc không thay đổi gì. Về bảo mật, mật khẩu không "
        "hiển thị khi nhập, mọi câu lệnh đều dùng tham số hóa và quyền thao tác được kiểm tra theo chức vụ. "
        "Về khả năng bảo trì, mã nguồn phải tách biệt theo tầng để khi thay đổi cấu trúc bảng chỉ cần sửa "
        "tầng DAL và thủ tục lưu trữ. Cuối cùng, toàn bộ giao diện, thông báo lỗi và tên bảng phải dùng "
        "tiếng Việt có dấu, thống nhất về thuật ngữ với nghiệp vụ của cửa hàng."
    )
    b.p(
        "Đề tài có ý nghĩa cả về học tập và thực tiễn. Về học tập, sản phẩm là minh chứng cho việc vận dụng "
        "tổng hợp kiến thức của học phần vào một bài toán trọn vẹn từ phân tích, thiết kế, cài đặt đến kiểm "
        "thử và đóng gói. Về thực tiễn, ứng dụng có thể dùng ngay tại một cửa hàng nhỏ, giúp giảm thời gian "
        "lập hóa đơn, tránh sai sót tồn kho và cung cấp số liệu doanh thu chính xác cho người quản lý. "
        "Ngoài ra, cách tổ chức mã nguồn theo ba tầng còn là nền tảng để nhóm tiếp tục mở rộng sản phẩm "
        "thành phiên bản nhiều chi nhánh hoặc phiên bản web sau này."
    )
    b.p(
        "Báo cáo được trình bày trong ba chương. Chương 1 giới thiệu bối cảnh, mục tiêu, phạm vi, kế hoạch "
        "thực hiện và các công nghệ sử dụng. Chương 2 trình bày mô hình hệ thống: chức năng, giao diện lập "
        "trình, mô hình lớp, mô hình cơ sở dữ liệu và các tiện ích dùng chung. Chương 3 trình bày quá trình "
        "phát triển hệ thống theo từng tầng GUI, BUS, DAL và các thủ tục lưu trữ, kèm theo kết quả thử "
        "nghiệm, hạn chế và hướng phát triển."
    )

    # ==================================================================
    b.h(2, "1.2. Kế hoạch làm đề tài")

    b.p(
        "Đề tài được thực hiện trong tám tuần, chia thành bốn giai đoạn: khảo sát và phân tích, thiết kế, "
        "cài đặt, kiểm thử và đóng gói. Nhóm gồm bốn thành viên, mỗi thành viên phụ trách một nhóm chức "
        "năng và một tầng của hệ thống để bảo đảm khối lượng công việc tương đương nhau, đồng thời vẫn có "
        "người kiểm tra chéo sản phẩm của nhau. Bảng 1.2 trình bày phân công công việc; các thông tin về "
        "họ tên, khóa, lớp và mã sinh viên được để dạng ô trống để nhóm điền chính xác khi nộp bài."
    )

    b.bang(
        "Phân công công việc trong nhóm",
        ["STT", "Sinh viên thực hiện", "Công việc đảm nhận", "Sản phẩm bàn giao"],
        [
            ["1", "[Họ tên thành viên 1 - nhóm trưởng]",
             "Phân tích nghiệp vụ, thiết kế cơ sở dữ liệu, viết toàn bộ thủ tục lưu trữ, "
             "xây dựng tầng DAL và lớp tiện ích kết nối.",
             "InitDb.sql, StoredProcedures.sql, DAL/*.cs, DatabaseAccess.cs, tài liệu phân tích."],
            ["2", "[Họ tên thành viên 2]",
             "Thiết kế mô hình lớp hướng đối tượng, xây dựng năm giao diện và các lớp DTO, "
             "lớp tiện ích AppHelpers.",
             "Interfaces/*.cs, DTO/*.cs, Utilities/AppHelpers.cs."],
            ["3", "[Họ tên thành viên 3]",
             "Xây dựng tầng nghiệp vụ và các biểu mẫu quản lý danh mục: hàng hóa, bốn danh "
             "mục tra cứu, nhân viên, khách hàng, nhà cung cấp.",
             "BUS/*.cs, Form1, Form2, Form3, Form4, Form5, Form9, Form10."],
            ["4", "[Họ tên thành viên 4]",
             "Xây dựng biểu mẫu bán hàng, nhập hàng, tìm kiếm và báo cáo; viết hàm xuất Excel; "
             "soạn báo cáo và slide thuyết trình.",
             "Form6, Form7, Form8, FormBaoCao, BaoCao_BTL.docx, ThuyetTrinh_BTL.pptx."],
        ],
        do_rong=[1.2, 4.0, 5.6, 4.6],
        canh_giua=[0],
        co=10.5,
    )

    b.p(
        "Tiến độ thực hiện được chia theo tuần như bảng 1.3. Mốc quan trọng nhất là cuối tuần thứ tư, khi "
        "cơ sở dữ liệu và các thủ tục lưu trữ phải hoàn tất để các thành viên còn lại có thể cài đặt song "
        "song phần giao diện. Việc đặt mốc này sớm giúp nhóm tránh tình trạng phải sửa lại giao diện khi "
        "cấu trúc dữ liệu thay đổi."
    )

    b.bang(
        "Kế hoạch tiến độ thực hiện đề tài",
        ["Tuần", "Công việc chính", "Kết quả cần đạt"],
        [
            ["Tuần 1", "Khảo sát quy trình bán hàng của cửa hàng nhỏ; liệt kê chức năng; xác định phạm vi đề tài.",
             "Bản mô tả bài toán và danh sách chức năng."],
            ["Tuần 2", "Thiết kế lược đồ quan hệ, chuẩn hóa dữ liệu đến dạng chuẩn 3; xác định khóa và ràng buộc.",
             "Lược đồ mười hai bảng, sơ đồ quan hệ."],
            ["Tuần 3", "Thiết kế mô hình lớp, năm giao diện, các quan hệ kế thừa và kết tập.",
             "Sơ đồ lớp, danh sách thuộc tính và phương thức."],
            ["Tuần 4", "Viết InitDb.sql, dữ liệu mẫu và toàn bộ thủ tục lưu trữ; thử nghiệm trên SQL Server.",
             "Bộ 70 thủ tục lưu trữ chạy được, có kiểm thử bằng tay."],
            ["Tuần 5", "Cài đặt tầng DAL, BUS và lớp tiện ích; kiểm thử kết nối và các thao tác CRUD.",
             "Các lớp DAL, BUS hoạt động độc lập, có ghi nhật ký."],
            ["Tuần 6", "Cài đặt các biểu mẫu quản lý danh mục, nhân viên, khách hàng, nhà cung cấp.",
             "Form1 đến Form5, Form9, Form10 chạy được."],
            ["Tuần 7", "Cài đặt biểu mẫu bán hàng, nhập hàng, tìm kiếm, báo cáo; xuất Excel.",
             "Form6, Form7, Form8, FormBaoCao chạy được."],
            ["Tuần 8", "Kiểm thử tổng thể, sửa lỗi, viết báo cáo, làm slide, đóng gói và nộp bài.",
             "Bộ sản phẩm hoàn chỉnh kèm báo cáo và slide."],
        ],
        do_rong=[2.0, 8.6, 5.0],
        canh_giua=[0],
        co=11,
    )

    b.p(
        "Nhóm sử dụng Git và GitHub để quản lý mã nguồn. Nhánh main luôn chứa phiên bản chạy được; mỗi "
        "thành viên làm việc trên nhánh riêng đặt theo tên chức năng, sau đó tạo yêu cầu hợp nhất "
        "(pull request) để nhóm trưởng xem lại trước khi gộp. Cách làm này giúp phát hiện sớm xung đột mã "
        "nguồn và giữ được lịch sử thay đổi của từng phần. Cơ sở dữ liệu cũng được đưa vào kho mã nguồn "
        "dưới dạng hai tệp kịch bản để bất kỳ thành viên nào cũng có thể dựng lại môi trường giống nhau "
        "chỉ bằng vài lệnh."
    )
    b.p(
        "Về kiểm thử, nhóm áp dụng ba mức. Mức thứ nhất là kiểm thử chức năng theo kịch bản: mỗi chức năng "
        "có danh sách trường hợp hợp lệ và không hợp lệ, ghi rõ dữ liệu nhập và kết quả mong đợi. Mức thứ "
        "hai là kiểm thử dữ liệu biên: số lượng bằng không, số lượng âm, số lượng vượt tồn kho, giá nhập "
        "lớn hơn giá bán, số điện thoại thiếu chữ số, mã hàng trùng. Mức thứ ba là kiểm thử phân quyền: "
        "đăng nhập bằng tài khoản nhân viên và thử thao tác xóa nhân viên để chắc chắn hệ thống chặn đúng. "
        "Kết quả kiểm thử được ghi lại trong mục 3.5 của báo cáo."
    )
    b.p(
        "Các rủi ro chính của đề tài và biện pháp xử lý cũng được xác định trước. Rủi ro thứ nhất là mất "
        "dữ liệu khi thử nghiệm, khắc phục bằng việc luôn chạy lại kịch bản tạo cơ sở dữ liệu có sẵn dữ "
        "liệu mẫu. Rủi ro thứ hai là máy thành viên không cài SQL Server đúng phiên bản, khắc phục bằng "
        "cách cho phép đổi chuỗi kết nối qua biến môi trường thay vì sửa mã nguồn. Rủi ro thứ ba là xung "
        "đột mã nguồn khi nhiều người sửa cùng một tệp thiết kế của Form, khắc phục bằng quy ước mỗi người "
        "chỉ phụ trách những Form đã được phân công."
    )

    # ==================================================================
    b.h(2, "1.3. Các công nghệ sử dụng")

    b.p(
        "Hệ thống được xây dựng trên bốn nhóm công nghệ: nền tảng .NET và ngôn ngữ C#, thư viện giao diện "
        "Windows Forms, công nghệ truy cập dữ liệu ADO.NET cùng SQL Server, và thư viện xuất báo cáo "
        "Excel. Phần dưới trình bày vai trò của từng công nghệ, lý do lựa chọn và những điểm cần lưu ý khi "
        "sử dụng."
    )

    b.h(3, "1.3.1. Nền tảng .NET và ngôn ngữ C#")
    b.p(
        "C# là ngôn ngữ lập trình hướng đối tượng, định kiểu tĩnh, do Microsoft phát triển trong khuôn khổ "
        "nền tảng .NET. Ngôn ngữ này hỗ trợ đầy đủ bốn tính chất của lập trình hướng đối tượng: đóng gói "
        "thông qua thuộc tính và mức truy cập, kế thừa thông qua lớp cơ sở, đa hình thông qua phương thức "
        "ảo và ghi đè, trừu tượng hóa thông qua lớp trừu tượng và giao diện. Ngoài ra, C# còn có các tính "
        "năng hiện đại giúp mã nguồn ngắn gọn và an toàn hơn như kiểu nullable, biểu thức chuyển đổi, câu "
        "lệnh using khai báo, chuỗi nội suy và các mẫu so khớp."
    )
    b.p(
        "Phiên bản .NET được sử dụng là .NET 10 với mục tiêu nền tảng net10.0-windows. Việc chọn nền tảng "
        "mới giúp dự án dùng được các thư viện hiện đại như Microsoft.Data.SqlClient 6 và ClosedXML 0.102, "
        "đồng thời vẫn biên dịch được với Visual Studio 2022 trở lên. Mã nguồn bật chế độ nullable để trình "
        "biên dịch cảnh báo những chỗ có thể phát sinh lỗi tham chiếu rỗng, một trong những nguyên nhân phổ "
        "biến gây treo chương trình."
    )

    b.h(3, "1.3.2. Thư viện giao diện Windows Forms")
    b.p(
        "Windows Forms là thư viện giao diện có sẵn của .NET, cho phép dựng màn hình bằng cách kéo thả các "
        "điều khiển như TextBox, ComboBox, DataGridView, DateTimePicker, MenuStrip, StatusStrip. Mô hình "
        "lập trình của Windows Forms là mô hình hướng sự kiện: mỗi điều khiển phát sinh sự kiện (Click, "
        "TextChanged, SelectedIndexChanged, CellClick) và chương trình phản ứng bằng hàm xử lý tương ứng."
    )
    b.p(
        "Trong đề tài, Windows Forms được dùng để dựng mười một biểu mẫu. Biểu mẫu Form9 là màn hình đăng "
        "nhập; Form10 là cửa sổ chính chứa MenuStrip, StatusStrip và một Panel dùng làm vùng nội dung. Các "
        "biểu mẫu nghiệp vụ được mở bên trong Panel này bằng cách đặt thuộc tính TopLevel bằng false và "
        "Dock bằng Fill, nhờ vậy người dùng có cảm giác như đang dùng một ứng dụng nhiều trang nhưng thực "
        "chất chỉ có một cửa sổ. Cách làm này tránh được việc mở quá nhiều cửa sổ rời rạc và giữ được thanh "
        "menu, thanh trạng thái luôn hiển thị."
    )

    b.h(3, "1.3.3. ADO.NET và Microsoft.Data.SqlClient")
    b.p(
        "ADO.NET là công nghệ truy cập dữ liệu của .NET. Bốn đối tượng được dùng nhiều nhất trong đề tài là "
        "SqlConnection (quản lý kết nối), SqlCommand (thực thi lệnh hoặc thủ tục), SqlDataAdapter (đổ kết quả "
        "vào DataTable) và SqlTransaction (nhóm nhiều lệnh thành một giao dịch). Thư viện "
        "Microsoft.Data.SqlClient là phiên bản hiện đại của SqlClient, hỗ trợ mã hóa mạnh hơn và được "
        "Microsoft khuyến nghị thay cho System.Data.SqlClient."
    )
    b.p(
        "Điểm quan trọng trong cách dùng ADO.NET của đề tài là đặt thuộc tính CommandType bằng "
        "CommandType.StoredProcedure cho mọi lệnh. Khi đó tham số thứ nhất của SqlCommand là tên thủ tục "
        "lưu trữ chứ không phải câu SQL, còn các giá trị truyền vào được khai báo qua SqlParameter. Cách "
        "làm này mang lại ba lợi ích: câu lệnh được biên dịch sẵn trên máy chủ nên chạy nhanh hơn, mã C# "
        "không phụ thuộc vào tên cột nên khi đổi cấu trúc bảng chỉ cần sửa thủ tục, và tham số hóa loại bỏ "
        "nguy cơ chèn mã SQL qua ô nhập liệu."
    )

    b.h(3, "1.3.4. Hệ quản trị cơ sở dữ liệu SQL Server và T-SQL")
    b.p(
        "SQL Server là hệ quản trị cơ sở dữ liệu quan hệ của Microsoft, phù hợp với ứng dụng để bàn trong "
        "mạng nội bộ vì chi phí triển khai thấp và tích hợp tốt với .NET. Cơ sở dữ liệu của đề tài gồm mười "
        "hai bảng, được chuẩn hóa đến dạng chuẩn ba, có khóa chính, khóa ngoại, ràng buộc kiểm tra và chỉ "
        "mục trên các cột thường tìm kiếm."
    )
    b.p(
        "T-SQL là ngôn ngữ của SQL Server, được dùng để viết bảy mươi thủ tục lưu trữ. Các thủ tục được "
        "nhóm theo đối tượng nghiệp vụ: hàng hóa, bốn danh mục, khách hàng, nhà cung cấp, nhân viên, hóa "
        "đơn bán, hóa đơn nhập và báo cáo. Một số thủ tục không chỉ thực hiện một câu lệnh mà còn chứa "
        "logic nghiệp vụ ở mức cơ sở dữ liệu, ví dụ thủ tục trừ tồn kho chỉ cập nhật khi số lượng tồn đủ "
        "lớn hơn hoặc bằng số lượng bán, nhờ vậy hai người bán cùng lúc cũng không thể bán vượt kho."
    )

    b.h(3, "1.3.5. Kiến trúc ba tầng GUI - BUS - DAL")
    b.p(
        "Kiến trúc ba tầng tách chương trình thành ba lớp trách nhiệm. Tầng giao diện (GUI) chỉ hiển thị dữ "
        "liệu và tiếp nhận thao tác của người dùng. Tầng nghiệp vụ (BUS) kiểm tra tính hợp lệ của dữ liệu và "
        "thực hiện các tính toán nghiệp vụ. Tầng truy cập dữ liệu (DAL) là nơi duy nhất làm việc với cơ sở "
        "dữ liệu. Việc phân tầng như vậy giúp ba thành viên có thể làm việc song song, giúp việc tìm lỗi "
        "nhanh hơn vì lỗi hiển thị nằm ở GUI còn lỗi dữ liệu nằm ở DAL, và giúp sản phẩm dễ mở rộng khi "
        "phải thay đổi hệ quản trị cơ sở dữ liệu."
    )

    b.h(3, "1.3.6. Thư viện xuất báo cáo Excel ClosedXML")
    b.p(
        "ClosedXML là thư viện mã nguồn mở cho phép tạo tệp .xlsx trực tiếp từ C# mà không cần cài đặt "
        "Microsoft Excel trên máy. Thư viện hỗ trợ định dạng chữ, tô màu ô, gộp ô, định dạng số, viền và "
        "tự động điều chỉnh độ rộng cột. Trong đề tài, ClosedXML được dùng để xuất kết quả tìm kiếm, hóa "
        "đơn bán, phiếu nhập và ba báo cáo tổng hợp, mỗi báo cáo là một hoặc nhiều trang tính."
    )
    b.p(
        "Cần trình bày rõ một điểm về yêu cầu báo cáo của học phần. Thang điểm môn học nêu rằng chức năng "
        "báo cáo nên thực hiện bằng Crystal Report, nếu chỉ xuất tệp Excel thì bị trừ 0,5 điểm. Nhóm đã cài "
        "đặt và kiểm thử đường xuất Excel bằng ClosedXML, đồng thời chuẩn bị sẵn tập dữ liệu báo cáo "
        "BaoCaoDataSet.xsd và tài liệu hướng dẫn chuyển sang Crystal Report trong thư mục docs. Tuy nhiên "
        "việc tạo tệp .rpt cần Visual Studio trên Windows cùng bộ công cụ SAP Crystal Reports, môi trường "
        "soạn mã nguồn của nhóm không có hai công cụ này, nên phần Crystal Report chưa được biên dịch và "
        "nhóm ghi nhận trung thực trong báo cáo thay vì tuyên bố đã hoàn thành."
    )

    b.h(3, "1.3.7. Git và GitHub")
    b.p(
        "Git là hệ thống quản lý phiên bản phân tán, cho phép lưu lại lịch sử thay đổi và làm việc song song "
        "trên nhiều nhánh. GitHub là dịch vụ lưu trữ kho mã nguồn Git trực tuyến. Nhóm dùng GitHub để chia "
        "sẻ mã nguồn giữa bốn thành viên, theo dõi công việc qua các yêu cầu hợp nhất và lưu lại toàn bộ "
        "lịch sử phát triển của sản phẩm. Mỗi lần gộp nhánh, nhóm trưởng kiểm tra lại ba điểm: dự án còn "
        "biên dịch được, không có tệp rác, và các thủ tục lưu trữ vẫn khớp với tên gọi trong mã C#."
    )

    b.p("Bảng 1.4 tóm tắt các công nghệ đã chọn, phương án thay thế đã cân nhắc và lý do quyết định.")
    b.bang(
        "Công nghệ sử dụng và phương án thay thế",
        ["Thành phần", "Công nghệ sử dụng", "Phương án đã cân nhắc", "Lý do lựa chọn"],
        [
            ["Ngôn ngữ và nền tảng", "C# trên .NET 10 (net10.0-windows)", "Java Swing, Python Tkinter",
             "Đúng yêu cầu học phần; hỗ trợ OOP đầy đủ; thư viện phong phú."],
            ["Giao diện", "Windows Forms", "WPF, DevExpress",
             "Đơn giản, quen thuộc, không phát sinh chi phí; đủ dùng cho quy mô đề tài."],
            ["Truy cập dữ liệu", "ADO.NET (Microsoft.Data.SqlClient)", "Entity Framework Core, Dapper",
             "Thể hiện rõ thao tác kết nối và thủ tục lưu trữ theo yêu cầu môn học."],
            ["Cơ sở dữ liệu", "SQL Server (SQL Express)", "MySQL, SQLite, PostgreSQL",
             "Tích hợp tốt với .NET; hỗ trợ T-SQL và thủ tục lưu trữ mạnh."],
            ["Báo cáo", "ClosedXML (Excel) + dữ liệu chuẩn bị cho Crystal Report", "Crystal Report, RDLC",
             "Chạy được trên mọi máy không cần Excel; vẫn giữ đường nâng cấp lên Crystal Report."],
            ["Quản lý mã nguồn", "Git và GitHub", "SVN, lưu trữ thủ công",
             "Miễn phí, phổ biến, hỗ trợ làm việc nhóm và xem lại thay đổi."],
        ],
        do_rong=[3.0, 4.0, 4.0, 4.6],
        co=10.5,
    )
    b.p(
        "Tóm lại, Chương 1 đã xác định rõ bài toán, mục tiêu, phạm vi, kế hoạch thực hiện và nền công nghệ "
        "của đề tài. Đây là căn cứ để Chương 2 trình bày mô hình hệ thống ở mức thiết kế, gồm chức năng, "
        "giao diện lập trình, mô hình lớp và mô hình cơ sở dữ liệu."
    )
