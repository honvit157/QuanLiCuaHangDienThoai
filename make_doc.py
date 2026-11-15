"""
Sinh báo cáo bài tập lớn định dạng Word theo đúng bố cục hướng dẫn của giảng viên.

Chạy:  python make_doc.py
Kết quả: BaoCao_BTL_QuanLyCuaHangDienThoai.docx

Cấu trúc tệp:
  - Trang bìa (trường, học phần, đề tài, nhóm, bảng thành viên, giảng viên hướng dẫn)
  - Mục lục (trang riêng, tự cập nhật khi mở bằng Word)
  - Danh mục các từ viết tắt (trang riêng)
  - Danh mục bảng biểu và sơ đồ (trang riêng)
  - Chương 1, Chương 2, Chương 3, Kết luận, Danh mục sách tham khảo
"""

import os
import sys

from docx.enum.text import WD_ALIGN_PARAGRAPH
from docx.shared import Cm, Pt, RGBColor

sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))

from tai_lieu.docx_helpers import DocBuilder, _dat_font  # noqa: E402
import tai_lieu.chuong1 as chuong1  # noqa: E402
import tai_lieu.chuong2 as chuong2  # noqa: E402
import tai_lieu.chuong3 as chuong3  # noqa: E402

GOC = os.path.dirname(os.path.abspath(__file__))
TEN_TEP = "BaoCao_BTL_QuanLyCuaHangDienThoai.docx"

TEN_DE_TAI = "XÂY DỰNG ỨNG DỤNG QUẢN LÝ CỬA HÀNG ĐIỆN THOẠI"
TEN_DE_TAI_2 = "THEO KIẾN TRÚC BA TẦNG VÀ HỆ QUẢN TRỊ SQL SERVER"

TU_VIET_TAT = [
    ["1", "ADO.NET", "Công nghệ truy cập dữ liệu của nền tảng .NET"],
    ["2", "API", "Giao diện lập trình ứng dụng (Application Programming Interface)"],
    ["3", "BUS", "Tầng nghiệp vụ (Business Logic Layer)"],
    ["4", "CRUD", "Bốn thao tác cơ bản: Create, Read, Update, Delete"],
    ["5", "CSDL", "Cơ sở dữ liệu"],
    ["6", "DAL", "Tầng truy cập dữ liệu (Data Access Layer)"],
    ["7", "DTO", "Đối tượng truyền dữ liệu (Data Transfer Object)"],
    ["8", "FK", "Khóa ngoại (Foreign Key)"],
    ["9", "GUI", "Tầng giao diện đồ họa (Graphical User Interface)"],
    ["10", "OOP", "Lập trình hướng đối tượng (Object-Oriented Programming)"],
    ["11", "PK", "Khóa chính (Primary Key)"],
    ["12", "SP", "Thủ tục lưu trữ (Stored Procedure)"],
    ["13", "SQL", "Ngôn ngữ truy vấn có cấu trúc (Structured Query Language)"],
    ["14", "T-SQL", "Ngôn ngữ Transact-SQL của SQL Server"],
    ["15", "UI", "Giao diện người dùng (User Interface)"],
    ["16", "VNĐ", "Đơn vị tiền tệ Việt Nam Đồng"],
]


def viet_trang_bia(b):
    doc = b.doc

    p = doc.add_paragraph()
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.paragraph_format.space_after = Pt(2)
    r = p.add_run("BỘ GIÁO DỤC VÀ ĐÀO TẠO")
    _dat_font(r, co=13, dam=True)

    p = doc.add_paragraph()
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.paragraph_format.space_after = Pt(2)
    r = p.add_run("TRƯỜNG ĐẠI HỌC CÔNG NGHỆ GIAO THÔNG VẬN TẢI")
    _dat_font(r, co=14, dam=True)

    p = doc.add_paragraph()
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.paragraph_format.space_after = Pt(2)
    r = p.add_run("KHOA CÔNG NGHỆ THÔNG TIN")
    _dat_font(r, co=14, dam=True)

    p = doc.add_paragraph()
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.paragraph_format.space_after = Pt(18)
    r = p.add_run("────────────")
    _dat_font(r, co=13)

    p = doc.add_paragraph()
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.paragraph_format.space_after = Pt(6)
    r = p.add_run("BÁO CÁO BÀI TẬP LỚN")
    _dat_font(r, co=22, dam=True, mau=RGBColor(0x1F, 0x3B, 0x63))

    p = doc.add_paragraph()
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.paragraph_format.space_after = Pt(20)
    r = p.add_run("HỌC PHẦN: LẬP TRÌNH TRỰC QUAN")
    _dat_font(r, co=15, dam=True)

    p = doc.add_paragraph()
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.paragraph_format.space_after = Pt(4)
    r = p.add_run("ĐỀ TÀI:")
    _dat_font(r, co=14, dam=True)

    p = doc.add_paragraph()
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.paragraph_format.space_after = Pt(2)
    r = p.add_run(TEN_DE_TAI)
    _dat_font(r, co=17, dam=True, mau=RGBColor(0x9C, 0x1B, 0x1B))

    p = doc.add_paragraph()
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.paragraph_format.space_after = Pt(22)
    r = p.add_run(TEN_DE_TAI_2)
    _dat_font(r, co=15, dam=True, mau=RGBColor(0x9C, 0x1B, 0x1B))

    # Bảng thành viên nhóm
    p = doc.add_paragraph()
    p.paragraph_format.space_after = Pt(4)
    r = p.add_run(
        "Nhóm số: [.....]          Khóa: [.....]          Lớp: [.....]          "
        "Năm học: 2026 - 2027"
    )
    _dat_font(r, co=13, dam=True)

    p = doc.add_paragraph()
    p.paragraph_format.space_before = Pt(8)
    p.paragraph_format.space_after = Pt(4)
    r = p.add_run("Danh sách thành viên nhóm thực hiện đề tài")
    _dat_font(r, co=12.5, dam=True, nghieng=True)

    tieu_de = ["STT", "Sinh viên thực hiện", "Khóa", "Lớp", "Mã sinh viên", "Công việc đảm nhiệm trong nhóm"]
    du_lieu = [
        ["1", "[Đặng Việt Hoàn]", "[Khóa]", "[Lớp]", "[Mã SV]",
         "Phân tích nghiệp vụ, thiết kế cơ sở dữ liệu, viết thủ tục lưu trữ, xây dựng tầng DAL."],
        ["2", "[Họ và tên thành viên 2]", "[Khóa]", "[Lớp]", "[Mã SV]",
         "Thiết kế mô hình lớp, năm giao diện, các lớp DTO và lớp tiện ích."],
        ["3", "[Họ và tên thành viên 3]", "[Khóa]", "[Lớp]", "[Mã SV]",
         "Xây dựng tầng BUS và các biểu mẫu quản lý danh mục, nhân viên, khách hàng, nhà cung cấp."],
        ["4", "[Họ và tên thành viên 4]", "[Khóa]", "[Lớp]", "[Mã SV]",
         "Xây dựng biểu mẫu bán hàng, nhập hàng, tìm kiếm, báo cáo; soạn báo cáo và slide."],
    ]
    b.bang("Thành viên nhóm thực hiện đề tài", tieu_de, du_lieu,
           do_rong=[1.1, 3.4, 1.6, 1.6, 2.4, 6.4], canh_giua=[0, 2, 3, 4], co=10,
           co_caption=False)

    p = doc.add_paragraph()
    p.paragraph_format.space_before = Pt(16)
    p.paragraph_format.space_after = Pt(2)
    r = p.add_run("Giảng viên hướng dẫn: TS. CAO THỊ LUYẾN")
    _dat_font(r, co=14, dam=True)

    p = doc.add_paragraph()
    p.paragraph_format.space_before = Pt(14)
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    r = p.add_run("Hà Nội, tháng 11 năm 2026")
    _dat_font(r, co=13, nghieng=True)


def viet_muc_luc(b):
    b.ngat_trang()
    p = b.doc.add_paragraph()
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.paragraph_format.space_after = Pt(12)
    r = p.add_run("MỤC LỤC")
    _dat_font(r, co=16, dam=True, mau=RGBColor(0x1F, 0x3B, 0x63))
    b.muc_luc()
    b.ghi_chu("Ghi chú: nếu mục lục chưa hiện số trang, bấm chuột phải vào khung mục lục, "
              "chọn Update Field (hoặc nhấn Ctrl+A rồi F9) để Word cập nhật.")


def viet_tu_viet_tat(b):
    b.ngat_trang()
    p = b.doc.add_paragraph()
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.paragraph_format.space_after = Pt(12)
    r = p.add_run("DANH MỤC CÁC TỪ VIẾT TẮT")
    _dat_font(r, co=16, dam=True, mau=RGBColor(0x1F, 0x3B, 0x63))

    b.bang("Các từ viết tắt dùng trong báo cáo",
           ["STT", "Chữ viết tắt", "Giải thích"],
           TU_VIET_TAT, do_rong=[1.4, 4.0, 10.0], canh_giua=[0, 1], co=11,
           co_caption=False)


def viet_danh_muc_bang_hinh(b, ds_bang, ds_hinh):
    b.ngat_trang()
    p = b.doc.add_paragraph()
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.paragraph_format.space_after = Pt(12)
    r = p.add_run("DANH MỤC BẢNG BIỂU VÀ SƠ ĐỒ")
    _dat_font(r, co=16, dam=True, mau=RGBColor(0x1F, 0x3B, 0x63))

    b.ghi_chu("Tên bảng được đặt phía trên bảng, tên hình vẽ và sơ đồ được đặt phía dưới hình theo "
              "đúng hướng dẫn trình bày báo cáo. Cột Trang được điền theo bản in thực tế.")

    du_lieu = []
    for so_hieu, ten in ds_bang:
        du_lieu.append([so_hieu, ten, "…"])
    b.bang("Danh mục bảng biểu", ["Số hiệu", "Tên bảng", "Trang"], du_lieu,
           do_rong=[2.4, 11.4, 1.8], canh_giua=[0, 2], co=10.5, co_caption=False)

    du_lieu_hinh = []
    for so_hieu, ten in ds_hinh:
        du_lieu_hinh.append([so_hieu, ten, "…"])
    b.bang("Danh mục hình vẽ và sơ đồ", ["Số hiệu", "Tên hình vẽ, sơ đồ", "Trang"], du_lieu_hinh,
           do_rong=[2.4, 11.4, 1.8], canh_giua=[0, 2], co=10.5, co_caption=False)


def viet_noi_dung(b):
    chuong1.viet(b)
    b.ngat_trang()
    chuong2.viet(b)
    b.ngat_trang()
    chuong3.viet(b)


def thong_ke(doc, ds_bang, ds_hinh):
    """Ước lượng độ dài từng chương để đối chiếu yêu cầu tối thiểu 3/7/7 trang."""
    chuong = "Bìa"
    dem = {}
    for p in doc.paragraphs:
        if p.style is not None and p.style.name == "Heading 1" and p.text.startswith("CHƯƠNG "):
            chuong = p.text.split(".")[0].strip()
        so_tu = len([t for t in p.text.split() if t.strip()])
        dem[chuong] = dem.get(chuong, 0) + so_tu

    print("\n--- Thống kê báo cáo ---")
    tong = 0
    for k in ("CHƯƠNG 1", "CHƯƠNG 2", "CHƯƠNG 3"):
        so_tu = dem.get(k, 0)
        tong += so_tu
        # 470 từ/trang với Times 13, giãn dòng 1.3; bảng và hình chiếm thêm chỗ
        so_trang = so_tu / 470
        print(f"{k}: {so_tu} từ ≈ {so_trang:.1f} trang văn bản")
    print(f"Tổng số từ ba chương: {tong}")
    print(f"Số bảng: {len(ds_bang)}, số hình: {len(ds_hinh)}")

    theo_chuong = {}
    for so_hieu, _ in ds_bang:
        c = so_hieu.split(".")[0].replace("Bảng ", "")
        theo_chuong[c] = theo_chuong.get(c, 0) + 1
    print("Bảng theo chương:", theo_chuong)


def main():
    # Lượt 1: dựng nội dung để thu danh mục bảng, hình
    tam = DocBuilder()
    viet_noi_dung(tam)
    ds_bang, ds_hinh = list(tam.tat_ca_bang), list(tam.tat_ca_hinh)

    # Lượt 2: dựng tài liệu hoàn chỉnh
    b = DocBuilder()
    viet_trang_bia(b)
    ds_bang_bia = list(b.ds_bang)   # bảng thành viên ở trang bìa không đưa vào danh mục
    ds_hinh_bia = list(b.ds_hinh)
    b.ds_bang, b.ds_hinh = [], []

    viet_muc_luc(b)
    viet_tu_viet_tat(b)
    b.ds_bang, b.ds_hinh = [], []
    viet_danh_muc_bang_hinh(b, ds_bang, ds_hinh)
    b.ds_bang, b.ds_hinh = [], []
    b.ngat_trang()

    viet_noi_dung(b)
    b.danh_so_trang()
    b.cap_nhat_truong_khi_mo()

    duong_dan = os.path.join(GOC, TEN_TEP)
    b.luu(duong_dan)

    thong_ke(b.doc, ds_bang, ds_hinh)
    print("\nĐã lưu:", duong_dan)
    print("Bảng thành viên ở bìa:", ds_bang_bia)
    print("Số hình ở bìa:", len(ds_hinh_bia))


if __name__ == "__main__":
    main()
