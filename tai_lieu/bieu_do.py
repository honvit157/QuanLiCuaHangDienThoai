"""
Sinh các sơ đồ minh họa cho báo cáo (kiến trúc 3 tầng, mô hình lớp,
lược đồ cơ sở dữ liệu, quan hệ giữa các Form) bằng Pillow.

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
    # đầu mũi tên
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
        draw.text(((x1 + x2) / 2 - w / 2, (y1 + y2) / 2 - 26), ghi_chu, font=f, fill=(90, 90, 90))


def luu(img, ten):
    os.makedirs(HINH, exist_ok=True)
    duong_dan = os.path.join(HINH, ten)
    img.save(duong_dan)
    print("Đã tạo", duong_dan)
    return duong_dan


# ----------------------------------------------------------------------------
# Hình 2.1 - Kiến trúc 3 tầng
# ----------------------------------------------------------------------------
def kien_truc_ba_tang():
    img = Image.new("RGB", (1600, 900), MAU_NEN)
    d = ImageDraw.Draw(img)

    hop(d, (120, 40, 1480, 120), "NGƯỜI DÙNG\n(Quản lý cửa hàng, nhân viên bán hàng)", co=26, dam=True, nen=MAU_VANG)

    hop(d, (120, 190, 1480, 330),
        "TẦNG GIAO DIỆN - GUI (Windows Forms)\nForm9 đăng nhập · Form10 menu chính · Form1-Form8, FormBaoCao",
        co=24, dam=True, nen=MAU_XANH)

    hop(d, (120, 400, 1480, 540),
        "TẦNG NGHIỆP VỤ - BUS (Business Logic)\nHangHoaBUS · KhachHangBUS · NhaCungCapBUS · NhanVienBUS\nDanhMucBUS · HoaDonBanBUS · HoaDonNhapBUS · BaoCaoBUS",
        co=22, dam=True, nen=MAU_XANH_LA)

    hop(d, (120, 610, 1480, 750),
        "TẦNG TRUY CẬP DỮ LIỆU - DAL (Data Access)\nDatabaseAccess · HangHoaDAL · KhachHangDAL · NhaCungCapDAL\nNhanVienDAL · DanhMucDAL · HoaDonBanDAL · HoaDonNhapDAL · BaoCaoDAL",
        co=22, dam=True, nen=MAU_HONG)

    hop(d, (440, 800, 1160, 880), "SQL SERVER: QLCuaHangBanDienThoai\n70 thủ tục lưu trữ (Stored Procedure)", co=22, dam=True, nen=(217, 217, 217))

    mui_ten(d, (800, 120), (800, 188), ghi_chu="thao tác trên form")
    mui_ten(d, (800, 330), (800, 398), ghi_chu="gọi hàm nghiệp vụ")
    mui_ten(d, (800, 540), (800, 608), ghi_chu="gọi lớp truy cập dữ liệu")
    mui_ten(d, (800, 750), (800, 798), ghi_chu="CommandType.StoredProcedure")
    return luu(img, "hinh_2_1_kien_truc_3_tang.png")


# ----------------------------------------------------------------------------
# Hình 2.2 - Mô hình lớp rút gọn
# ----------------------------------------------------------------------------
def mo_hinh_lop():
    img = Image.new("RGB", (1600, 1000), MAU_NEN)
    d = ImageDraw.Draw(img)

    hop(d, (60, 40, 460, 150), "«abstract»\nNguoi\nHoTen, SDT, DiaChi\nGioiTinh, NgaySinh", co=20, dam=True)
    hop(d, (60, 250, 460, 360), "KhachHang : Nguoi, IKhachHang\nMaKH, Email\nLayThongTinRutGon()", co=19, nen=MAU_XANH_LA)
    hop(d, (60, 420, 460, 530), "NhanVien : Nguoi, INhanVien\nMaNV, TenDangNhap, MatKhau\nVaiTro, TrangThai", co=19, nen=MAU_XANH_LA)

    hop(d, (560, 40, 960, 150), "«abstract»\nSanPhamBase\nMaHang, TenHang\nGiaNhap, GiaBan, SoLuongTon", co=20, dam=True)
    hop(d, (560, 250, 960, 360), "HangHoa : SanPhamBase, IHangHoa\nMaHangSX, MaLoai, MaMau\nMaDungLuong, MoTa", co=19, nen=MAU_XANH_LA)

    hop(d, (1060, 40, 1540, 150), "«abstract»\nChungTuBase\nMaChungTu, MaNV\nNgayLap, TongTien", co=20, dam=True)
    hop(d, (1060, 250, 1540, 370), "HoaDonBan : ChungTuBase, IHoaDon\nMaHD, MaKH\nList<ChiTietHoaDonBan>", co=19, nen=MAU_XANH_LA)
    hop(d, (1060, 420, 1540, 540), "HoaDonNhap : ChungTuBase\nMaHDN, MaNCC\nList<ChiTietHoaDonNhap>", co=19, nen=MAU_XANH_LA)

    hop(d, (560, 470, 960, 570), "NhaCungCap : INhaCungCap\nMaNCC, TenNCC, SDT\nDiaChi, Email, NguoiLH", co=19, nen=MAU_VANG)
    hop(d, (560, 640, 960, 740), "ChiTietHoaDonBan\nChiTietHoaDonNhap\n(quan hệ kết tập)", co=19, nen=MAU_HONG)

    mui_ten(d, (260, 150), (260, 248))
    mui_ten(d, (260, 360), (260, 418))
    mui_ten(d, (760, 150), (760, 248))
    mui_ten(d, (1300, 150), (1300, 248))
    mui_ten(d, (1300, 370), (1300, 418))
    mui_ten(d, (1300, 540), (960, 690), ghi_chu="kết tập")
    return luu(img, "hinh_2_2_mo_hinh_lop.png")


# ----------------------------------------------------------------------------
# Hình 2.3 - Lược đồ quan hệ
# ----------------------------------------------------------------------------
def luoc_do_csdl():
    img = Image.new("RGB", (1600, 980), MAU_NEN)
    d = ImageDraw.Draw(img)

    hop(d, (40, 40, 330, 150), "tblHangSX\nMaHangSX (PK)\nTenHangSX", co=19, nen=MAU_VANG)
    hop(d, (40, 200, 330, 310), "tblLoai\nMaLoai (PK)\nTenLoai", co=19, nen=MAU_VANG)
    hop(d, (40, 360, 330, 470), "tblMau\nMaMau (PK)\nTenMau", co=19, nen=MAU_VANG)
    hop(d, (40, 520, 330, 640), "tblDungLuong\nMaDungLuong (PK)\nTenDungLuong", co=19, nen=MAU_VANG)

    hop(d, (430, 40, 850, 230),
        "tblHang\nMaHang (PK)\nTenHang, MaHangSX (FK)\nMaLoai, MaMau, MaDungLuong (FK)\nDonGiaNhap, DonGiaBan, SoLuongTon",
        co=18, dam=True)

    hop(d, (430, 320, 850, 470), "tblNhanVien\nMaNV (PK)\nTenNV, GioiTinh, NgaySinh\nSDT, DiaChi, ChucVu\nTaiKhoan, MatKhau, TrangThai", co=18)
    hop(d, (430, 560, 850, 700), "tblKhachHang\nMaKH (PK)\nTenKH, SDT\nDiaChi, Email", co=18)
    hop(d, (430, 780, 850, 930), "tblNhaCungCap\nMaNCC (PK)\nTenNCC, SDT, DiaChi\nEmail, NguoiLH", co=18)

    hop(d, (960, 40, 1380, 190), "tblHoaDonBan\nMaHDB (PK)\nMaNV (FK), MaKH (FK)\nNgayLap, TongTien", co=18, dam=True)
    hop(d, (960, 230, 1380, 360), "tblChiTietHDB\nMaHDB (PK, FK)\nMaHang (PK, FK)\nSoLuong, DonGia, GiamGia, ThanhTien", co=18, nen=MAU_XANH_LA)

    hop(d, (960, 470, 1380, 610), "tblHoaDonNhap\nMaHDN (PK)\nMaNV (FK), MaNCC (FK)\nNgayNhap, TongTien", co=18, dam=True)
    hop(d, (960, 650, 1380, 790), "tblChiTietHDN\nMaHDN (PK, FK)\nMaHang (PK, FK)\nSoLuong, DonGiaNhap, ThanhTien", co=18, nen=MAU_XANH_LA)

    mui_ten(d, (330, 95), (428, 120))
    mui_ten(d, (330, 255), (428, 150))
    mui_ten(d, (330, 415), (428, 165))
    mui_ten(d, (330, 580), (428, 180))
    mui_ten(d, (850, 130), (958, 115), ghi_chu="1 - n")
    mui_ten(d, (1170, 190), (1170, 228))
    mui_ten(d, (850, 400), (958, 520), ghi_chu="1 - n")
    mui_ten(d, (1170, 610), (1170, 648))
    mui_ten(d, (850, 630), (958, 760))
    return luu(img, "hinh_2_3_luoc_do_csdl.png")


# ----------------------------------------------------------------------------
# Hình 3.1 - Quan hệ giữa các Form
# ----------------------------------------------------------------------------
def quan_he_form():
    img = Image.new("RGB", (1600, 940), MAU_NEN)
    d = ImageDraw.Draw(img)

    hop(d, (60, 60, 460, 190), "Form9 - Đăng nhập\n(NhanVienBUS.DangNhap)\ntài khoản / mật khẩu", co=20, dam=True, nen=MAU_VANG)
    hop(d, (60, 260, 460, 430), "Form10 - Menu chính\nMenuStrip + Panel nội dung\n+ StatusStrip", co=20, dam=True)
    hop(d, (60, 520, 460, 680), "Tất cả Form con mở trong\nPanel của Form10\n(TopLevel = false)", co=18)

    con = [
        ("Form1 - Quản lý hàng hóa", MAU_XANH_LA),
        ("Form5 - Bốn danh mục (hãng, loại, màu, dung lượng)", MAU_XANH_LA),
        ("Form2 - Nhân viên", MAU_XANH_LA),
        ("Form3 - Khách hàng", MAU_XANH_LA),
        ("Form4 - Nhà cung cấp", MAU_XANH_LA),
        ("Form6 - Tìm kiếm nâng cao", MAU_XANH_LA),
        ("Form7 - Hóa đơn bán hàng", MAU_HONG),
        ("Form8 - Hóa đơn nhập hàng", MAU_HONG),
        ("FormBaoCao - Báo cáo thống kê", (217, 217, 217)),
    ]

    y = 20
    for ten, mau in con:
        hop(d, (640, y, 1540, y + 84), ten, co=20, nen=mau)
        mui_ten(d, (462, 320), (636, y + 42))
        y += 100

    mui_ten(d, (260, 190), (260, 258), ghi_chu="đăng nhập thành công")
    return luu(img, "hinh_3_1_quan_he_form.png")


if __name__ == "__main__":
    kien_truc_ba_tang()
    mo_hinh_lop()
    luoc_do_csdl()
    quan_he_form()
