"""
Sinh các sơ đồ minh họa cho báo cáo (kiến trúc 3 tầng, mô hình lớp,
lược đồ cơ sở dữ liệu, quan hệ giữa các Form, bố cục Dashboard) bằng Pillow.

Chạy:  python tai_lieu/bieu_do.py
Kết quả: các tệp PNG trong tai_lieu/hinh/
"""

import os

from PIL import Image, ImageDraw, ImageFont

THU_MUC = os.path.dirname(os.path.abspath(__file__))
HINH = os.path.join(THU_MUC, "hinh")

FONT_THUONG = "/usr/share/fonts/truetype/liberation/LiberationSans-Regular.ttf"
FONT_DAM = "/usr/share/fonts/truetype/liberation/LiberationSans-Bold.ttf"

MAU_NEN = (255, 255, 255)
MAU_VIEN = (31, 59, 99)
MAU_CHU = (20, 20, 20)
MAU_XANH = (220, 230, 241)
MAU_VANG = (255, 242, 204)
MAU_XANH_LA = (226, 239, 218)
MAU_HONG = (252, 228, 214)
MAU_XAM = (217, 217, 217)


def font(co, dam=False):
    return ImageFont.truetype(FONT_DAM if dam else FONT_THUONG, co)


def hop(draw, xy, chu, co=22, dam=False, nen=MAU_XANH, bo_tron=14):
    """Vẽ một hộp chữ nhật bo góc, chữ canh giữa nhiều dòng."""
    x1, y1, x2, y2 = xy
    draw.rounded_rectangle(xy, radius=bo_tron, fill=nen, outline=MAU_VIEN, width=3)
    f = font(co, dam)
    dong = chu.split("\n")
    chieu_cao = sum(f.getbbox(d)[3] - f.getbbox(d)[1] + 8 for d in dong)
    y = (y1 + y2) / 2 - chieu_cao / 2
    for d in dong:
        bbox = f.getbbox(d)
        w = bbox[2] - bbox[0]
        draw.text(((x1 + x2) / 2 - w / 2, y - bbox[1]), d, font=f, fill=MAU_CHU)
        y += bbox[3] - bbox[1] + 8


def mui_ten(draw, dau, cuoi, mau=MAU_VIEN, do_day=3, ghi_chu=None, co_chu=18):
    draw.line([dau, cuoi], fill=mau, width=do_day)
    x1, y1 = dau
    x2, y2 = cuoi
    if abs(x2 - x1) >= abs(y2 - y1):
        huong = 1 if x2 > x1 else -1
        draw.polygon([(x2, y2), (x2 - 14 * huong, y2 - 7), (x2 - 14 * huong, y2 + 7)], fill=mau)
    else:
        huong = 1 if y2 > y1 else -1
        draw.polygon([(x2, y2), (x2 - 7, y2 - 14 * huong), (x2 + 7, y2 - 14 * huong)], fill=mau)

    if ghi_chu:
        f = font(co_chu)
        bbox = f.getbbox(ghi_chu)
        w = bbox[2] - bbox[0]
        draw.text(((x1 + x2) / 2 - w / 2, (y1 + y2) / 2 - 22), ghi_chu, font=f, fill=MAU_VIEN)


def luu(img, ten):
    os.makedirs(HINH, exist_ok=True)
    duong_dan = os.path.join(HINH, ten)
    img.save(duong_dan)
    print("Đã vẽ:", duong_dan)
    return duong_dan


# ----------------------------------------------------------------------------
# Hình 2.1 - Kiến trúc ba tầng
# ----------------------------------------------------------------------------
def kien_truc_ba_tang():
    img = Image.new("RGB", (1600, 940), MAU_NEN)
    d = ImageDraw.Draw(img)

    hop(d, (120, 30, 1480, 105), "NGƯỜI DÙNG\n(Quản lý cửa hàng, nhân viên bán hàng)",
        co=26, dam=True, nen=MAU_VANG)

    hop(d, (120, 165, 1480, 300),
        "TẦNG GIAO DIỆN - GUI (Windows Forms)\n"
        "Form9 đăng nhập  ·  Form10 Dashboard 3 cột  ·  Form1-Form8, FormBaoCao",
        co=24, dam=True, nen=MAU_XANH)

    hop(d, (120, 365, 1480, 520),
        "TẦNG NGHIỆP VỤ - BUS (Business Logic)\n"
        "HangHoaBUS · KhachHangBUS · NhaCungCapBUS · NhanVienBUS · DanhMucBUS\n"
        "HoaDonBanBUS · HoaDonNhapBUS · BaoCaoBUS · ThongKeBUS",
        co=22, dam=True, nen=MAU_XANH_LA)

    hop(d, (120, 590, 1480, 745),
        "TẦNG TRUY CẬP DỮ LIỆU - DAL (Data Access)\n"
        "DatabaseAccess (chỉ gọi Stored Procedure) · HangHoaDAL · KhachHangDAL\n"
        "NhaCungCapDAL · NhanVienDAL · DanhMucDAL · HoaDonBanDAL · HoaDonNhapDAL\n"
        "BaoCaoDAL · ThongKeDAL",
        co=22, dam=True, nen=MAU_HONG)

    hop(d, (390, 800, 1210, 890),
        "SQL SERVER: QLCuaHangBanDienThoai\n78 thủ tục lưu trữ (Stored Procedure)",
        co=22, dam=True, nen=MAU_XAM)

    mui_ten(d, (800, 105), (800, 163), ghi_chu="thao tác trên form")
    mui_ten(d, (800, 300), (800, 363), ghi_chu="gọi hàm nghiệp vụ")
    mui_ten(d, (800, 520), (800, 588), ghi_chu="gọi lớp truy cập dữ liệu")
    mui_ten(d, (800, 745), (800, 798), ghi_chu="CommandType.StoredProcedure")
    return luu(img, "hinh_2_1_kien_truc_3_tang.png")


# ----------------------------------------------------------------------------
# Hình 2.2 - Mô hình lớp
# ----------------------------------------------------------------------------
def mo_hinh_lop():
    img = Image.new("RGB", (1660, 900), MAU_NEN)
    d = ImageDraw.Draw(img)

    # Nhánh 1: Nguoi
    hop(d, (40, 30, 460, 150), "«abstract» Nguoi\nHoTen, SDT, DiaChi\nGioiTinh, NgaySinh\nLayThongTin()",
        co=19, dam=True)
    hop(d, (40, 230, 460, 360), "KhachHang : Nguoi, IKhachHang\nMaKH, Email\nLayThongTinRutGon()", co=18, nen=MAU_XANH_LA)
    hop(d, (40, 410, 460, 545), "NhanVien : Nguoi, INhanVien\nMaNV, TenDangNhap, MatKhau\nVaiTro, TrangThai\nKiemTraQuyenQuanLy()",
        co=18, nen=MAU_XANH_LA)

    # Nhánh 2: SanPhamBase
    hop(d, (560, 30, 1060, 160), "«abstract» SanPhamBase\nMaHang, TenHang, GiaNhap\nGiaBan, SoLuongTon\nTinhLoiNhuan()",
        co=19, dam=True)
    hop(d, (560, 240, 1060, 390), "HangHoa : SanPhamBase, IHangHoa\nMaHangSX, MaLoai, MaMau\nMaDungLuong, MoTa\nTinhLoiNhuan() override",
        co=18, nen=MAU_XANH_LA)
    hop(d, (560, 470, 1060, 600), "NhaCungCap : INhaCungCap\nMaNCC, TenNCC, SDT\nDiaChi, Email, NguoiLH\nLayThongTinLienHe()",
        co=18, nen=MAU_VANG)

    # Nhánh 3: ChungTuBase
    hop(d, (1160, 30, 1620, 160), "«abstract» ChungTuBase\nMaChungTu, MaNV\nNgayLap, TongTien\nTinhTongTien()",
        co=19, dam=True)
    hop(d, (1160, 240, 1620, 400), "HoaDonBan : ChungTuBase, IHoaDon\nMaHD, MaKH\nList<ChiTietHoaDonBan>", co=18, nen=MAU_XANH_LA)
    hop(d, (1160, 470, 1620, 640), "HoaDonNhap : ChungTuBase, IHoaDonNhap\nMaHDN, MaNCC, NgayNhap\nList<ChiTietHoaDonNhap>",
        co=18, nen=MAU_XANH_LA)

    # Hàng chi tiết
    hop(d, (180, 700, 620, 830), "LoaiDanhMuc (enum)\nHangSanXuat · LoaiHang\nMauSac · DungLuong", co=17, nen=MAU_XAM)
    hop(d, (700, 700, 1140, 830), "ChiTietHoaDonBan\nMaHang, SoLuong, DonGia\nGiamGia, ThanhTien\nTinhThanhTien()",
        co=18, nen=MAU_HONG)
    hop(d, (1180, 700, 1620, 830), "ChiTietHoaDonNhap\nMaHang, SoLuong\nDonGiaNhap, ThanhTien\nTinhThanhTien()",
        co=18, nen=MAU_HONG)

    # Kế thừa
    mui_ten(d, (250, 150), (250, 228))
    mui_ten(d, (250, 360), (250, 408))
    mui_ten(d, (810, 160), (810, 238))
    mui_ten(d, (1390, 160), (1390, 238))

    # ChungTuBase -> HoaDonNhap (đi theo hành lang x = 1120)
    d.line([(1160, 95), (1120, 95)], fill=MAU_VIEN, width=3)
    d.line([(1120, 95), (1120, 500)], fill=MAU_VIEN, width=3)
    mui_ten(d, (1120, 500), (1158, 500))

    # Kết tập: HoaDonBan -> ChiTietHoaDonBan
    d.line([(1160, 320), (1100, 320)], fill=MAU_VIEN, width=3)
    d.line([(1100, 320), (1100, 660)], fill=MAU_VIEN, width=3)
    d.line([(1100, 660), (920, 660)], fill=MAU_VIEN, width=3)
    mui_ten(d, (920, 660), (920, 698), ghi_chu="kết tập")
    # Kết tập: HoaDonNhap -> ChiTietHoaDonNhap
    mui_ten(d, (1400, 640), (1400, 698), ghi_chu="kết tập")
    return luu(img, "hinh_2_2_mo_hinh_lop.png")


# ----------------------------------------------------------------------------
# Hình 2.3 - Lược đồ cơ sở dữ liệu quan hệ
# ----------------------------------------------------------------------------
def luoc_do_csdl():
    img = Image.new("RGB", (1600, 980), MAU_NEN)
    d = ImageDraw.Draw(img)

    hop(d, (40, 40, 330, 150), "tblHangSX\nMaHangSX (PK)\nTenHangSX", co=19, nen=MAU_VANG)
    hop(d, (40, 200, 330, 310), "tblLoai\nMaLoai (PK)\nTenLoai", co=19, nen=MAU_VANG)
    hop(d, (40, 360, 330, 470), "tblMau\nMaMau (PK)\nTenMau", co=19, nen=MAU_VANG)
    hop(d, (40, 520, 330, 640), "tblDungLuong\nMaDungLuong (PK)\nTenDungLuong", co=19, nen=MAU_VANG)

    hop(d, (430, 40, 850, 230),
        "tblHang\nMaHang (PK)\nTenHang, MaHangSX (FK)\nMaLoai, MaMau, MaDungLuong (FK)\nDonGiaNhap, DonGiaBan, SoLuongTon, MoTa",
        co=18, dam=True)

    hop(d, (430, 320, 850, 480),
        "tblNhanVien\nMaNV (PK)\nTenNV, GioiTinh, NgaySinh\nSDT, DiaChi, ChucVu\nTaiKhoan, MatKhau, TrangThai", co=18)
    hop(d, (430, 560, 850, 700), "tblKhachHang\nMaKH (PK)\nTenKH, SDT\nDiaChi, Email", co=18)
    hop(d, (430, 780, 850, 930), "tblNhaCungCap\nMaNCC (PK)\nTenNCC, SDT, DiaChi\nEmail, NguoiLH", co=18)

    hop(d, (960, 40, 1380, 190), "tblHoaDonBan\nMaHDB (PK)\nMaNV (FK), MaKH (FK)\nNgayLap, TongTien", co=18, dam=True)
    hop(d, (960, 230, 1380, 370), "tblChiTietHDB\nMaHDB (PK, FK)\nMaHang (PK, FK)\nSoLuong, DonGia, GiamGia, ThanhTien",
        co=18, nen=MAU_XANH_LA)

    hop(d, (960, 470, 1380, 620), "tblHoaDonNhap\nMaHDN (PK)\nMaNV (FK), MaNCC (FK)\nNgayNhap, TongTien", co=18, dam=True)
    hop(d, (960, 660, 1380, 800), "tblChiTietHDN\nMaHDN (PK, FK)\nMaHang (PK, FK)\nSoLuong, DonGiaNhap, ThanhTien",
        co=18, nen=MAU_XANH_LA)

    mui_ten(d, (330, 95), (428, 120))
    mui_ten(d, (330, 255), (428, 150))
    mui_ten(d, (330, 415), (428, 165))
    mui_ten(d, (330, 580), (428, 185))
    mui_ten(d, (850, 130), (958, 115), ghi_chu="1 - n")
    mui_ten(d, (1170, 190), (1170, 228))
    mui_ten(d, (850, 400), (958, 520), ghi_chu="1 - n")
    mui_ten(d, (850, 630), (958, 760))
    mui_ten(d, (1170, 620), (1170, 658))
    mui_ten(d, (850, 400), (958, 760), ghi_chu="1 - n")
    return luu(img, "hinh_2_3_luoc_do_csdl.png")


# ----------------------------------------------------------------------------
# Hình 3.1 - Quan hệ giữa các Form
# ----------------------------------------------------------------------------
def quan_he_form():
    img = Image.new("RGB", (1600, 1000), MAU_NEN)
    d = ImageDraw.Draw(img)

    hop(d, (60, 60, 520, 200), "Form9 - Đăng nhập\n(NhanVienBUS.DangNhap)\ntài khoản / mật khẩu",
        co=20, dam=True, nen=MAU_VANG)
    hop(d, (60, 270, 520, 470),
        "Form10 - Dashboard 3 cột\nmenu trái phân quyền 500px\nheader + nội dung + sidebar phải 400px",
        co=19, dam=True)
    hop(d, (60, 540, 520, 700),
        "Form con mở trong pnlNoiDung\n(TopLevel = false, Dock = Fill)\nđóng form cũ khi mở form mới",
        co=18)

    con = [
        ("Form1 - Quản lý điện thoại (CRUD + ảnh)", MAU_XANH_LA),
        ("Form5 - Bốn danh mục: hãng, loại, màu, dung lượng", MAU_XANH_LA),
        ("Form2 - Nhân viên (chỉ Quản lý thấy trên menu)", MAU_XANH_LA),
        ("Form3 - Khách hàng", MAU_XANH_LA),
        ("Form4 - Nhà cung cấp", MAU_XANH_LA),
        ("Form6 - Tìm kiếm điện thoại + xuất Excel", MAU_XANH_LA),
        ("Form7 - Hóa đơn bán hàng", MAU_HONG),
        ("Form8 - Hóa đơn nhập hàng", MAU_HONG),
        ("FormBaoCao - Báo cáo thống kê 3 tab", MAU_XAM),
    ]

    y = 20
    for ten, mau in con:
        hop(d, (700, y, 1540, y + 84), ten, co=20, nen=mau)
        mui_ten(d, (522, 370), (696, y + 42))
        y += 105

    mui_ten(d, (290, 200), (290, 268), ghi_chu="đăng nhập thành công")
    mui_ten(d, (290, 470), (290, 538), ghi_chu="bấm nút menu")
    return luu(img, "hinh_3_1_quan_he_form.png")


# ----------------------------------------------------------------------------
# Hình 3.2 - Bố cục Dashboard Form10
# ----------------------------------------------------------------------------
def bo_cuc_dashboard():
    img = Image.new("RGB", (1600, 900), MAU_NEN)
    d = ImageDraw.Draw(img)

    # Khung ngoài
    d.rectangle([30, 30, 1570, 870], outline=MAU_VIEN, width=4)

    # Cột trái
    d.rectangle([30, 30, 500, 870], fill=(20, 43, 74), outline=MAU_VIEN, width=3)
    d.text((60, 60), "PHONE STORE", font=font(30, True), fill=(255, 255, 255))
    d.text((60, 100), "MANAGEMENT SYSTEM", font=font(18), fill=(175, 195, 220))

    menu = [
        "TỔNG QUAN", "⌂  Tổng quan",
        "QUẢN LÝ CỬA HÀNG", "▣  Điện thoại", "▤  Danh mục", "♙  Nhân viên (*)",
        "♧  Khách hàng", "▱  Nhà cung cấp", "⌕  Tìm kiếm",
        "GIAO DỊCH", "▤  Hóa đơn bán", "▧  Hóa đơn nhập",
        "THỐNG KÊ", "▥  Báo cáo",
    ]
    y = 160
    for m in menu:
        if m.isupper():
            d.text((60, y), m, font=font(17, True), fill=(151, 174, 202))
        else:
            d.rounded_rectangle([50, y - 6, 480, y + 30], radius=6, fill=(20, 43, 74), outline=(39, 72, 111))
            d.text((70, y), m, font=font(21), fill=(255, 255, 255))
        y += 46
    d.text((60, y + 6), "(*) chỉ hiện khi đăng nhập bằng tài khoản Quản lý", font=font(16), fill=(151, 174, 202))

    # Header
    d.rectangle([500, 30, 1570, 140], fill=(255, 255, 255), outline=MAU_VIEN, width=3)
    d.text((530, 60), "Tổng quan", font=font(34, True), fill=(35, 51, 72))
    d.text((1230, 70), "Nguyễn Văn An  |  Quản lý", font=font(20, True), fill=(20, 43, 74))

    # Nội dung
    d.rectangle([500, 140, 1170, 870], fill=(244, 247, 251), outline=MAU_VIEN, width=3)
    d.text((530, 170), "Xin chào, Nguyễn Văn An!", font=font(28, True), fill=(20, 43, 74))
    d.text((530, 210), "Tổng quan hoạt động cửa hàng điện thoại", font=font(18), fill=(112, 128, 150))

    the = ["Tổng sản phẩm", "Khách hàng", "Hóa đơn hôm nay", "Doanh thu hôm nay"]
    x = 530
    for t in the:
        d.rounded_rectangle([x, 250, x + 145, 370], radius=8, fill=(255, 255, 255), outline=(225, 231, 239))
        d.text((x + 12, 262), t, font=font(15, True), fill=(112, 128, 150))
        d.text((x + 12, 310), "1.234", font=font(26, True), fill=(20, 43, 74))
        x += 155

    d.rounded_rectangle([530, 395, 1140, 840], radius=8, fill=(255, 255, 255), outline=(225, 231, 239))
    d.text((550, 412), "DOANH THU 7 NGÀY GẦN NHẤT", font=font(22, True), fill=(20, 43, 74))
    d.text((550, 448), "Thống kê doanh thu bán hàng theo ngày", font=font(16), fill=(112, 128, 150))
    # trục + cột
    d.line([600, 780, 1110, 780], fill=(190, 200, 215), width=2)
    d.line([600, 500, 600, 780], fill=(190, 200, 215), width=2)
    cao = [60, 120, 90, 200, 150, 240, 180]
    for i, c in enumerate(cao):
        x = 630 + i * 66
        d.rectangle([x, 780 - c, x + 34, 780], fill=(36, 120, 212))
        d.text((x + 2, 790), "01/11", font=font(13), fill=(112, 128, 150))

    # Sidebar phải
    d.rectangle([1170, 140, 1570, 870], fill=(255, 255, 255), outline=MAU_VIEN, width=3)
    d.text((1210, 160), "THÔNG TIN NỔI BẬT", font=font(20, True), fill=(23, 43, 77))
    d.text((1210, 210), "KHUYẾN MÃI HOT", font=font(17, True), fill=(23, 43, 77))
    d.rectangle([1200, 238, 1545, 480], outline=(200, 210, 225), width=2)
    d.text((1240, 350), "banner_khuyenmai.jpg", font=font(18), fill=(120, 130, 145))
    d.text((1210, 500), "ĐIỆN THOẠI NỔI BẬT", font=font(17, True), fill=(23, 43, 77))
    d.rectangle([1200, 528, 1545, 700], outline=(200, 210, 225), width=2)
    d.text((1280, 610), "iphone18.jpg", font=font(18), fill=(120, 130, 145))
    d.text((1290, 705), "iPhone 18", font=font(17, True), fill=(23, 43, 77))
    d.rectangle([1200, 740, 1545, 850], fill=(245, 248, 252), outline=(200, 210, 225), width=2)
    d.text((1215, 752), "THÔNG TIN CỬA HÀNG", font=font(16, True), fill=(23, 43, 77))
    d.text((1215, 782), "Hotline: 1900 xxxx", font=font(15), fill=(80, 90, 105))
    d.text((1215, 806), "Hỗ trợ khách hàng 24/7", font=font(15), fill=(80, 90, 105))
    d.text((1215, 830), "Bảo hành và đổi trả uy tín", font=font(15), fill=(80, 90, 105))

    return luu(img, "hinh_3_2_bo_cuc_dashboard.png")


if __name__ == "__main__":
    kien_truc_ba_tang()
    mo_hinh_lop()
    luoc_do_csdl()
    quan_he_form()
    bo_cuc_dashboard()
