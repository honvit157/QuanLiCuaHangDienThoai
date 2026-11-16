"""
Sinh slide thuyết trình bài tập lớn (PowerPoint) bằng python-pptx.

Chạy:  python make_ppt.py
Kết quả: ThuyetTrinh_BTL_QuanLyCuaHangDienThoai.pptx
"""

import os

from pptx import Presentation
from pptx.dml.color import RGBColor
from pptx.enum.shapes import MSO_SHAPE
from pptx.enum.text import PP_ALIGN
from pptx.util import Inches, Pt

GOC = os.path.dirname(os.path.abspath(__file__))
TEN_TEP = "ThuyetTrinh_BTL_QuanLyCuaHangDienThoai.pptx"
HINH = os.path.join(GOC, "tai_lieu", "hinh")

XANH_DAM = RGBColor(0x1F, 0x3B, 0x63)
XANH = RGBColor(0x1F, 0x4E, 0x79)
XANH_NHAT = RGBColor(0xDC, 0xE6, 0xF1)
TRANG = RGBColor(0xFF, 0xFF, 0xFF)
XAM = RGBColor(0xF2, 0xF5, 0xF9)
CHU = RGBColor(0x21, 0x21, 0x21)
DO = RGBColor(0x9C, 0x1B, 0x1B)
VANG = RGBColor(0xFF, 0xC0, 0x00)

prs = Presentation()
prs.slide_width = Inches(13.333)
prs.slide_height = Inches(7.5)
TRONG = prs.slide_layouts[6]


def trang_moi(tieu_de, phu_de=None):
    s = prs.slides.add_slide(TRONG)

    nen = s.shapes.add_shape(MSO_SHAPE.RECTANGLE, 0, 0, prs.slide_width, Inches(1.05))
    nen.fill.solid()
    nen.fill.fore_color.rgb = XANH_DAM
    nen.line.fill.background()
    nen.shadow.inherit = False

    hop = s.shapes.add_textbox(Inches(0.55), Inches(0.12), Inches(12.2), Inches(0.85))
    tf = hop.text_frame
    tf.word_wrap = True
    p = tf.paragraphs[0]
    p.text = tieu_de
    p.font.name = "Arial"
    p.font.size = Pt(26)
    p.font.bold = True
    p.font.color.rgb = TRANG
    p.alignment = PP_ALIGN.LEFT

    if phu_de:
        p2 = tf.add_paragraph()
        p2.text = phu_de
        p2.font.name = "Arial"
        p2.font.size = Pt(13)
        p2.font.color.rgb = RGBColor(0xC9, 0xDC, 0xF2)

    chan = s.shapes.add_shape(MSO_SHAPE.RECTANGLE, 0, Inches(7.2), prs.slide_width, Inches(0.3))
    chan.fill.solid()
    chan.fill.fore_color.rgb = XANH_NHAT
    chan.line.fill.background()

    so = s.shapes.add_textbox(Inches(12.2), Inches(7.18), Inches(1.0), Inches(0.3))
    p = so.text_frame.paragraphs[0]
    p.text = f"{len(prs.slides._sldIdLst):>2}"
    p.font.size = Pt(10)
    p.font.color.rgb = XANH
    p.alignment = PP_ALIGN.RIGHT
    return s


def gach_dau_dong(s, muc, top=1.35, left=0.7, width=12.0, co=17, khoang=10):
    hop = s.shapes.add_textbox(Inches(left), Inches(top), Inches(width), Inches(5.6))
    tf = hop.text_frame
    tf.word_wrap = True
    dau_tien = True
    for dong in muc:
        if isinstance(dong, tuple):
            chu, cap = dong
        else:
            chu, cap = dong, 0
        p = tf.paragraphs[0] if dau_tien else tf.add_paragraph()
        dau_tien = False
        p.text = ("• " if cap == 0 else "– ") + chu
        p.font.name = "Arial"
        p.font.size = Pt(co if cap == 0 else co - 3)
        p.font.bold = cap == 0
        p.font.color.rgb = CHU if cap == 0 else RGBColor(0x44, 0x44, 0x44)
        p.space_after = Pt(khoang if cap == 0 else 4)
        if cap > 0:
            p.level = 1
    return hop


def hop_thong_tin(s, trai, tren, rong, cao, tieu_de, noi_dung, mau_nen=XAM, mau_chu=XANH_DAM):
    o = s.shapes.add_shape(MSO_SHAPE.ROUNDED_RECTANGLE, Inches(trai), Inches(tren), Inches(rong), Inches(cao))
    o.fill.solid()
    o.fill.fore_color.rgb = mau_nen
    o.line.color.rgb = XANH_NHAT
    o.shadow.inherit = False

    tf = o.text_frame
    tf.word_wrap = True
    tf.margin_left = Inches(0.15)
    tf.margin_right = Inches(0.15)

    p = tf.paragraphs[0]
    p.text = tieu_de
    p.font.name = "Arial"
    p.font.size = Pt(15)
    p.font.bold = True
    p.font.color.rgb = mau_chu
    p.alignment = PP_ALIGN.CENTER

    for dong in noi_dung.split("\n"):
        p2 = tf.add_paragraph()
        p2.text = dong
        p2.font.name = "Arial"
        p2.font.size = Pt(12)
        p2.font.color.rgb = CHU
        p2.alignment = PP_ALIGN.CENTER
    return o


def ghi_chu(s, noi_dung):
    s.notes_slide.notes_text_frame.text = noi_dung


# =====================================================================
# 1. Trang tiêu đề
# =====================================================================
s = prs.slides.add_slide(TRONG)
nen = s.shapes.add_shape(MSO_SHAPE.RECTANGLE, 0, 0, prs.slide_width, prs.slide_height)
nen.fill.solid()
nen.fill.fore_color.rgb = XANH_DAM
nen.line.fill.background()

hop = s.shapes.add_textbox(Inches(0.9), Inches(0.9), Inches(11.5), Inches(5.6))
tf = hop.text_frame
tf.word_wrap = True

p = tf.paragraphs[0]
p.text = "TRƯỜNG ĐẠI HỌC CÔNG NGHỆ GIAO THÔNG VẬN TẢI - KHOA CÔNG NGHỆ THÔNG TIN"
p.font.name = "Arial"
p.font.size = Pt(14)
p.font.color.rgb = RGBColor(0xC9, 0xDC, 0xF2)

p = tf.add_paragraph()
p.text = "BÁO CÁO BÀI TẬP LỚN - HỌC PHẦN LẬP TRÌNH TRỰC QUAN"
p.font.name = "Arial"
p.font.size = Pt(18)
p.font.bold = True
p.font.color.rgb = TRANG
p.space_before = Pt(10)

p = tf.add_paragraph()
p.text = "XÂY DỰNG ỨNG DỤNG QUẢN LÝ CỬA HÀNG ĐIỆN THOẠI"
p.font.name = "Arial"
p.font.size = Pt(34)
p.font.bold = True
p.font.color.rgb = VANG
p.space_before = Pt(26)

p = tf.add_paragraph()
p.text = "Kiến trúc ba tầng DAL - BUS - GUI  |  ADO.NET  |  78 Stored Procedure  |  Lập trình hướng đối tượng"
p.font.name = "Arial"
p.font.size = Pt(14)
p.font.color.rgb = RGBColor(0xC9, 0xDC, 0xF2)
p.space_before = Pt(14)

p = tf.add_paragraph()
p.text = "Nhóm số: [.....]     Khóa: [.....]     Lớp: [.....]"
p.font.name = "Arial"
p.font.size = Pt(14)
p.font.color.rgb = TRANG
p.space_before = Pt(26)

p = tf.add_paragraph()
p.text = "Thành viên: [Họ tên thành viên 1], [Họ tên thành viên 2], [Họ tên thành viên 3], [Họ tên thành viên 4]"
p.font.name = "Arial"
p.font.size = Pt(13)
p.font.color.rgb = TRANG

p = tf.add_paragraph()
p.text = "Giảng viên hướng dẫn: TS. CAO THỊ LUYẾN"
p.font.name = "Arial"
p.font.size = Pt(15)
p.font.bold = True
p.font.color.rgb = VANG
p.space_before = Pt(18)

p = tf.add_paragraph()
p.text = "Năm học 2026 - 2027"
p.font.name = "Arial"
p.font.size = Pt(12)
p.font.color.rgb = RGBColor(0xC9, 0xDC, 0xF2)
p.space_before = Pt(10)

ghi_chu(s, "Kính thưa cô và các bạn, nhóm chúng em xin trình bày bài tập lớn học phần Lập trình trực quan: "
           "ứng dụng quản lý cửa hàng điện thoại xây dựng bằng C# WinForms và SQL Server, theo kiến trúc ba tầng "
           "với toàn bộ truy vấn đặt trong thủ tục lưu trữ.")

# =====================================================================
# 2. Nội dung trình bày
# =====================================================================
s = trang_moi("NỘI DUNG TRÌNH BÀY")
gach_dau_dong(s, [
    "Đặt vấn đề và mục tiêu của đề tài",
    "Các chức năng của hệ thống",
    "Kiến trúc ba tầng GUI - BUS - DAL",
    "Lập trình hướng đối tượng: 6 giao diện, 5 quan hệ kế thừa, quan hệ kết tập",
    "Mô hình cơ sở dữ liệu và 78 thủ tục lưu trữ",
    "Các giao diện chính và Dashboard tổng quan",
    "Nghiệp vụ then chốt: bán hàng và nhập hàng trong một giao dịch",
    "Báo cáo, xuất Excel, kết quả và hạn chế",
], top=1.5, co=19, khoang=14)

# =====================================================================
# 3. Đặt vấn đề và mục tiêu
# =====================================================================
s = trang_moi("ĐẶT VẤN ĐỀ VÀ MỤC TIÊU", "Vì sao cần một ứng dụng quản lý cho cửa hàng điện thoại")
gach_dau_dong(s, [
    "Thực trạng: sổ sách và nhiều tệp Excel rời rạc",
    ("Tồn kho không cập nhật ngay sau mỗi lần bán, dễ bán vượt số lượng thực có", 1),
    ("Tra cứu hóa đơn cũ chậm, cuối tháng phải cộng tay doanh thu", 1),
    ("Cùng một mẫu máy bị ghi nhiều tên khác nhau nên không đối chiếu được", 1),
    "Mục tiêu của đề tài",
    ("Quản lý hàng hóa, bốn danh mục tra cứu, nhân viên, khách hàng, nhà cung cấp", 1),
    ("Lập hóa đơn bán (trừ tồn kho) và phiếu nhập (cộng tồn kho, cập nhật giá nhập)", 1),
    ("Tìm kiếm đa tiêu chí, báo cáo, Dashboard tổng quan, xuất Excel", 1),
    ("Vận dụng OOP, ADO.NET, kiến trúc ba tầng và stored procedure", 1),
], top=1.4, co=17, khoang=9)

# =====================================================================
# 4. Chức năng hệ thống
# =====================================================================
s = trang_moi("CÁC CHỨC NĂNG CỦA HỆ THỐNG", "10 nhóm chức năng - 11 biểu mẫu")
cot = [
    ("Quản lý danh mục", "Hàng hóa, hãng sản xuất, loại hàng, màu sắc, dung lượng"),
    ("Quản lý hồ sơ", "Nhân viên, khách hàng, nhà cung cấp; kiểm tra SĐT và email"),
    ("Bán hàng", "Lập hóa đơn, giảm giá, tự trừ tồn kho trong giao dịch"),
    ("Nhập hàng", "Lập phiếu nhập, cộng tồn kho, cập nhật giá nhập mới nhất"),
    ("Tìm kiếm", "Theo tên, hãng, loại, màu và khoảng giá"),
    ("Tổng quan và báo cáo", "Dashboard 3 cột, ba báo cáo chi tiết, xuất Excel"),
]
trai, tren = 0.55, 1.4
for i, (td, nd) in enumerate(cot):
    hang, cot_i = divmod(i, 3)
    hop_thong_tin(s, trai + cot_i * 4.2, tren + hang * 2.55, 3.95, 2.3, td, nd)

# =====================================================================
# 5. Kiến trúc ba tầng
# =====================================================================
s = trang_moi("KIẾN TRÚC BA TẦNG GUI - BUS - DAL", "Tách bạch giao diện, nghiệp vụ và truy cập dữ liệu")
s.shapes.add_picture(os.path.join(HINH, "hinh_2_1_kien_truc_3_tang.png"),
                     Inches(0.5), Inches(1.2), width=Inches(9.2))
gach_dau_dong(s, [
    "GUI: chỉ đọc control, gọi BUS",
    "BUS: kiểm tra dữ liệu, quy tắc nghiệp vụ",
    "DAL: chỉ gọi stored procedure",
    "SQL Server: 78 thủ tục lưu trữ",
    "0 câu SQL trong mã C#",
], top=1.35, left=9.9, width=3.2, co=13, khoang=8)
ghi_chu(s, "Mỗi tầng chỉ gọi xuống tầng dưới. Giao diện không chứa câu SQL nào; khi đổi cấu trúc bảng chỉ cần "
           "sửa thủ tục và tầng DAL, không phải sửa biểu mẫu.")

# =====================================================================
# 6. Hướng đối tượng
# =====================================================================
s = trang_moi("LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG", "6 giao diện - 5 quan hệ kế thừa - 2 quan hệ kết tập")
gach_dau_dong(s, [
    "6 giao diện (interface)",
    ("IHangHoa, IHoaDon, IHoaDonNhap, IKhachHang, INhaCungCap, INhanVien", 1),
    "6 lớp triển khai giao diện",
    ("HangHoa, HoaDonBan, HoaDonNhap, KhachHang, NhaCungCap, NhanVien", 1),
    "5 quan hệ kế thừa trên 3 lớp trừu tượng (yêu cầu tối thiểu 3)",
    ("Nguoi → KhachHang, NhanVien", 1),
    ("SanPhamBase → HangHoa", 1),
    ("ChungTuBase → HoaDonBan, HoaDonNhap", 1),
    "Quan hệ kết tập: hóa đơn chứa danh sách chi tiết",
    "Đa hình: ghi đè LayThongTin, LayMoTa, TinhTongTien",
], top=1.3, co=16, khoang=6)

# =====================================================================
# 7. Mô hình lớp
# =====================================================================
s = trang_moi("MÔ HÌNH LỚP", "Ba lớp trừu tượng, sáu lớp cụ thể, sáu giao diện")
s.shapes.add_picture(os.path.join(HINH, "hinh_2_2_mo_hinh_lop.png"),
                     Inches(1.67), Inches(1.2), width=Inches(10.0))

# =====================================================================
# 8. Cơ sở dữ liệu và stored procedure
# =====================================================================
s = trang_moi("MÔ HÌNH CƠ SỞ DỮ LIỆU", "12 bảng chuẩn hóa và 78 thủ tục lưu trữ")
s.shapes.add_picture(os.path.join(HINH, "hinh_2_3_luoc_do_csdl.png"),
                     Inches(0.5), Inches(1.2), width=Inches(8.8))
gach_dau_dong(s, [
    "Nhóm danh mục: 4 bảng",
    "Nhóm đối tượng: hàng, nhân viên, khách, nhà cung cấp",
    "Nhóm chứng từ: hóa đơn bán, phiếu nhập và chi tiết",
    "Khóa ngoại + ràng buộc CHECK + chỉ mục",
    "78 thủ tục: 8 hàng hóa, 20 danh mục, 8 khách, 7 NCC, 10 nhân viên, 7 bán, 7 nhập, 3 báo cáo, 8 thống kê",
    "Mọi lệnh dùng CommandType.StoredProcedure",
], top=1.3, left=9.5, width=3.6, co=12, khoang=6)

# =====================================================================
# 9. Giao diện chương trình
# =====================================================================
s = trang_moi("CÁC GIAO DIỆN CHÍNH", "Form9 đăng nhập - Form10 Dashboard - 9 biểu mẫu nghiệp vụ")
s.shapes.add_picture(os.path.join(HINH, "hinh_3_1_quan_he_form.png"),
                     Inches(1.76), Inches(1.2), width=Inches(9.8))

# =====================================================================
# 10. Dashboard Form10
# =====================================================================
s = trang_moi("DASHBOARD TỔNG QUAN FORM10", "Bố cục ba cột: menu phân quyền - nội dung - thông tin nổi bật")
s.shapes.add_picture(os.path.join(HINH, "hinh_3_2_bo_cuc_dashboard.png"),
                     Inches(0.5), Inches(1.2), width=Inches(8.7))
gach_dau_dong(s, [
    "Menu trái 500px, chia 4 nhóm",
    ("Mục Nhân viên chỉ hiện với tài khoản Quản lý", 1),
    "Header 110px + vùng nội dung",
    "4 thẻ số liệu lấy qua ThongKeBUS",
    "Biểu đồ doanh thu 7 ngày vẽ bằng GDI+",
    "Sidebar phải 400px: banner, iPhone 18, thông tin cửa hàng",
], top=1.3, left=9.4, width=3.7, co=12.5, khoang=6)
ghi_chu(s, "Màn hình tổng quan là biểu mẫu duy nhất dựng hoàn toàn bằng mã: TableLayoutPanel ba cột, "
           "bốn thẻ số liệu, biểu đồ cột tự chọn bước chia trục, sidebar phải gắn hai ảnh trong thư mục Images.")

# =====================================================================
# 11. Nghiệp vụ bán hàng
# =====================================================================
s = trang_moi("NGHIỆP VỤ THEN CHỐT: LƯU HÓA ĐƠN BÁN", "Bốn bước trong một giao dịch - không thể bán vượt kho")
gach_dau_dong(s, [
    "Bước 1: sp_KiemTraHoaDonBanTonTai - chặn trùng mã hóa đơn",
    "Bước 2: sp_TruTonKho cho từng dòng chi tiết",
    ("UPDATE có điều kiện SoLuongTon >= @SoLuong, trả về @@ROWCOUNT", 1),
    ("Trả về 0 nghĩa là không đủ hàng, giao dịch bị hủy (Rollback)", 1),
    "Bước 3: sp_ThemHoaDonBan - ghi đầu hóa đơn",
    "Bước 4: sp_ThemChiTietHoaDonBan - ghi từng dòng chi tiết",
    "Kết thúc: Commit; nếu bất kỳ bước nào lỗi thì Rollback toàn bộ",
    "Phiếu nhập dùng cùng cơ chế với sp_CongTonKho",
], top=1.4, co=17, khoang=12)

# =====================================================================
# 12. Báo cáo và xuất Excel
# =====================================================================
s = trang_moi("BÁO CÁO VÀ XUẤT EXCEL", "Số liệu do SQL Server tính, ứng dụng chỉ hiển thị và xuất")
gach_dau_dong(s, [
    "Ba báo cáo chính của FormBaoCao",
    ("Doanh thu theo tháng: GROUP BY năm, tháng; COUNT hóa đơn; SUM doanh thu", 1),
    ("Tồn kho: số lượng tồn và giá trị tồn = giá bán × số lượng", 1),
    ("Top 10 bán chạy: TOP (@SoDong) theo tổng số lượng bán", 1),
    "Xuất tệp Excel bằng thư viện ClosedXML",
    ("Danh sách sản phẩm, hóa đơn bán, phiếu nhập, báo cáo ba trang tính", 1),
    ("Có tiêu đề, kẻ khung, định dạng số, dòng tổng", 1),
    "Ghi chú trung thực theo thang điểm",
    ("Học phần yêu cầu Crystal Report; nhóm đang xuất Excel nên phần này chưa đạt điểm tối đa", 1),
], top=1.35, co=16, khoang=8)

# =====================================================================
# 13. Kết quả đạt được và hạn chế
# =====================================================================
s = trang_moi("KẾT QUẢ ĐẠT ĐƯỢC VÀ HẠN CHẾ")
hop_thong_tin(s, 0.55, 1.35, 6.0, 5.4, "Kết quả đạt được",
              "6 giao diện, 6 lớp triển khai\n"
              "5 quan hệ kế thừa, 2 quan hệ kết tập\n"
              "78 thủ tục lưu trữ, 0 câu SQL trong C#\n"
              "12 bảng chuẩn hóa, có khóa ngoại và chỉ mục\n"
              "11 biểu mẫu, 10 nhóm chức năng\n"
              "Dashboard 3 cột với biểu đồ doanh thu 7 ngày\n"
              "Giao dịch bảo vệ nghiệp vụ bán và nhập hàng\n"
              "16 class method tiện ích dùng chung")
hop_thong_tin(s, 6.8, 1.35, 6.0, 5.4, "Hạn chế",
              "Báo cáo dùng Excel (ClosedXML), chưa dùng Crystal Report\n"
              "Mật khẩu lưu dạng chuỗi rõ\n"
              "Phân quyền mới ở mức ẩn menu và khóa nút\n"
              "Dashboard chưa có khối Top 5 và sắp hết hàng\n"
              "Chưa có sao lưu, phục hồi trong ứng dụng\n"
              "Chưa có kiểm thử tự động\n"
              "Chỉ chạy trên Windows, một máy chủ",
              mau_nen=RGBColor(0xFC, 0xE4, 0xD6), mau_chu=DO)

# =====================================================================
# 14. Hướng phát triển
# =====================================================================
s = trang_moi("HƯỚNG PHÁT TRIỂN")
gach_dau_dong(s, [
    "Chuyển ba báo cáo sang Crystal Report, bổ sung báo cáo lợi nhuận và doanh thu theo nhân viên",
    "Bổ sung khối Top 5 bán chạy và sắp hết hàng vào Dashboard, thêm biểu đồ tròn theo hãng",
    "Băm mật khẩu (PBKDF2/BCrypt) và phân quyền chi tiết theo từng chức năng",
    "Thêm trả hàng, bảo hành, quản lý phiếu thu - phiếu chi",
    "Tự động sao lưu hằng ngày bằng tác vụ định kỳ của SQL Server",
    "Tách tầng dữ liệu thành Web API, phát triển bản web và di động cho nhiều chi nhánh",
], top=1.6, co=18, khoang=16)

# =====================================================================
# 15. Kết thúc
# =====================================================================
s = prs.slides.add_slide(TRONG)
nen = s.shapes.add_shape(MSO_SHAPE.RECTANGLE, 0, 0, prs.slide_width, prs.slide_height)
nen.fill.solid()
nen.fill.fore_color.rgb = XANH_DAM
nen.line.fill.background()

hop = s.shapes.add_textbox(Inches(1.2), Inches(2.3), Inches(11.0), Inches(3.2))
tf = hop.text_frame
tf.word_wrap = True
p = tf.paragraphs[0]
p.text = "CẢM ƠN CÔ VÀ CÁC BẠN ĐÃ LẮNG NGHE"
p.font.name = "Arial"
p.font.size = Pt(34)
p.font.bold = True
p.font.color.rgb = VANG
p.alignment = PP_ALIGN.CENTER

p = tf.add_paragraph()
p.text = "Nhóm số: [.....] - Học phần Lập trình trực quan"
p.font.name = "Arial"
p.font.size = Pt(16)
p.font.color.rgb = TRANG
p.alignment = PP_ALIGN.CENTER
p.space_before = Pt(24)

p = tf.add_paragraph()
p.text = "Giảng viên hướng dẫn: TS. CAO THỊ LUYẾN"
p.font.name = "Arial"
p.font.size = Pt(16)
p.font.color.rgb = RGBColor(0xC9, 0xDC, 0xF2)
p.alignment = PP_ALIGN.CENTER
p.space_before = Pt(10)

ghi_chu(s, "Nhóm em xin cảm ơn cô và các bạn. Nhóm sẵn sàng nhận câu hỏi và góp ý để hoàn thiện sản phẩm.")

prs.core_properties.title = "Báo cáo bài tập lớn - Quản lý cửa hàng điện thoại"
prs.core_properties.author = "Nhóm sinh viên - Học phần Lập trình trực quan"
prs.core_properties.subject = "TS. Cao Thị Luyến"

duong_dan = os.path.join(GOC, TEN_TEP)
prs.save(duong_dan)
print("Đã lưu:", duong_dan, "-", len(prs.slides._sldIdLst), "slide")
