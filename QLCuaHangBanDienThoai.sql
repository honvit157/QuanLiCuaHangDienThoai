-- ============================================================================
--  HỆ THỐNG QUẢN LÝ CỬA HÀNG ĐIỆN THOẠI - TỆP CÀI ĐẶT DUY NHẤT
--  Học phần: Lập trình trực quan (C# WinForms) - Bài tập lớn
--  Giảng viên hướng dẫn: TS. Cao Thị Luyến
--  ---------------------------------------------------------------------------
--  Tệp này được sinh tự động từ InitDb.sql + StoredProcedures.sql
--  bằng công cụ tools/gop_sql.py. Không sửa trực tiếp tệp này.
-- ============================================================================

-- ============================================================================
--  HỆ THỐNG QUẢN LÝ CỬA HÀNG ĐIỆN THOẠI
--  Học phần: Lập trình trực quan (C# WinForms) - Bài tập lớn
--  Giảng viên hướng dẫn: TS. Cao Thị Luyến
--  ----------------------------------------------------------------------------
--  BƯỚC 1/2: TẠO CƠ SỞ DỮ LIỆU, 12 BẢNG VÀ DỮ LIỆU MẪU
--  Chạy tệp này trước, sau đó chạy StoredProcedures.sql.
--  (Hoặc chỉ chạy QLCuaHangBanDienThoai.sql - tệp gộp sẵn cả hai bước.)
--
--  Lưu ý: tệp sẽ XÓA cơ sở dữ liệu QLCuaHangBanDienThoai nếu đã tồn tại.
-- ============================================================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'QLCuaHangBanDienThoai')
    DROP DATABASE QLCuaHangBanDienThoai;
GO

CREATE DATABASE QLCuaHangBanDienThoai;
GO

USE QLCuaHangBanDienThoai;
GO

-- ============================================================================
--  A. TẠO CÁC BẢNG (12 bảng)
-- ============================================================================

-- A.1 Danh mục hãng sản xuất
CREATE TABLE tblHangSX (
    MaHangSX    NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenHangSX   NVARCHAR(100) NOT NULL
);
GO

-- A.2 Danh mục loại hàng
CREATE TABLE tblLoai (
    MaLoai   NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenLoai  NVARCHAR(100) NOT NULL
);
GO

-- A.3 Danh mục màu sắc
CREATE TABLE tblMau (
    MaMau   NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenMau  NVARCHAR(50) NOT NULL
);
GO

-- A.4 Danh mục dung lượng bộ nhớ
CREATE TABLE tblDungLuong (
    MaDungLuong   NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenDungLuong  NVARCHAR(50) NOT NULL
);
GO

-- A.5 Nhà cung cấp
CREATE TABLE tblNhaCungCap (
    MaNCC    NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenNCC   NVARCHAR(100) NOT NULL,
    SDT      NVARCHAR(20)  NULL,
    DiaChi   NVARCHAR(200) NULL,
    Email    NVARCHAR(255) NULL,
    NguoiLH  NVARCHAR(100) NULL
);
GO

-- A.6 Nhân viên (kèm tài khoản đăng nhập và trạng thái làm việc)
CREATE TABLE tblNhanVien (
    MaNV       NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenNV      NVARCHAR(100) NOT NULL,
    GioiTinh   NVARCHAR(10)  NULL,
    NgaySinh   DATE          NULL,
    SDT        NVARCHAR(20)  NULL,
    DiaChi     NVARCHAR(200) NULL,
    TaiKhoan   NVARCHAR(50)  NULL,
    MatKhau    NVARCHAR(100) NULL,
    ChucVu     NVARCHAR(50)  NULL,      -- 'Quan ly' hoặc 'Nhan vien'
    TrangThai  NVARCHAR(50)  NULL CONSTRAINT DF_tblNhanVien_TrangThai
                              DEFAULT N'Đang làm việc'
);
GO

-- A.7 Khách hàng
--     TaiKhoan/MatKhau phục vụ Đăng ký - Đăng nhập của Khách hàng (Form11, Form9).
CREATE TABLE tblKhachHang (
    MaKH      NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenKH     NVARCHAR(100) NOT NULL,
    SDT       NVARCHAR(20)  NULL,
    DiaChi    NVARCHAR(200) NULL,
    Email     NVARCHAR(150) NULL,
    TaiKhoan  NVARCHAR(50)  NULL,
    MatKhau   NVARCHAR(255) NULL
);
GO

-- Mỗi tài khoản Khách hàng chỉ thuộc về một hồ sơ khách hàng
CREATE UNIQUE INDEX UX_tblKhachHang_TaiKhoan
    ON tblKhachHang(TaiKhoan)
    WHERE TaiKhoan IS NOT NULL;
GO

-- A.8 Hàng hóa (TenAnh trỏ tới tệp ảnh trong thư mục Images)
CREATE TABLE tblHang (
    MaHang       NVARCHAR(20)   NOT NULL PRIMARY KEY,
    TenHang      NVARCHAR(200)  NOT NULL,
    MaHangSX     NVARCHAR(20)   NULL REFERENCES tblHangSX(MaHangSX),
    MaLoai       NVARCHAR(20)   NULL REFERENCES tblLoai(MaLoai),
    MaMau        NVARCHAR(20)   NULL REFERENCES tblMau(MaMau),
    MaDungLuong  NVARCHAR(20)   NULL REFERENCES tblDungLuong(MaDungLuong),
    DonGiaNhap   DECIMAL(18,2)  NOT NULL DEFAULT 0,
    DonGiaBan    DECIMAL(18,2)  NOT NULL DEFAULT 0,
    SoLuongTon   INT            NOT NULL DEFAULT 0,
    MoTa         NVARCHAR(500)  NULL,
    TenAnh       NVARCHAR(255)  NULL
);
GO

-- A.9 Hóa đơn bán hàng
CREATE TABLE tblHoaDonBan (
    MaHDB                 NVARCHAR(30)   NOT NULL PRIMARY KEY,
    MaNV                  NVARCHAR(20)   NOT NULL REFERENCES tblNhanVien(MaNV),
    MaKH                  NVARCHAR(20)   NULL REFERENCES tblKhachHang(MaKH),
    NgayLap               DATETIME       NOT NULL DEFAULT GETDATE(),
    TongTien              DECIMAL(18,2)  NOT NULL DEFAULT 0,
    TrangThaiThanhToan    NVARCHAR(30)   NOT NULL
                          CONSTRAINT DF_tblHoaDonBan_TrangThai
                          DEFAULT N'Chưa thanh toán',
    PhuongThucThanhToan   NVARCHAR(50)   NULL,
    NgayThanhToan         DATETIME       NULL
);
GO

-- A.10 Chi tiết hóa đơn bán hàng
CREATE TABLE tblChiTietHDB (
    MaHDB     NVARCHAR(30)   NOT NULL REFERENCES tblHoaDonBan(MaHDB),
    MaHang    NVARCHAR(20)   NOT NULL REFERENCES tblHang(MaHang),
    SoLuong   INT            NOT NULL,
    DonGia    DECIMAL(18,2)  NOT NULL,
    GiamGia   DECIMAL(5,2)   NOT NULL DEFAULT 0,
    ThanhTien DECIMAL(18,2)  NOT NULL,
    PRIMARY KEY (MaHDB, MaHang)
);
GO

-- A.11 Hóa đơn nhập hàng
CREATE TABLE tblHoaDonNhap (
    MaHDN     NVARCHAR(30)   NOT NULL PRIMARY KEY,
    MaNV      NVARCHAR(20)   NOT NULL REFERENCES tblNhanVien(MaNV),
    MaNCC     NVARCHAR(20)   NOT NULL REFERENCES tblNhaCungCap(MaNCC),
    NgayNhap  DATETIME       NOT NULL DEFAULT GETDATE(),
    TongTien  DECIMAL(18,2)  NOT NULL DEFAULT 0
);
GO

-- A.12 Chi tiết hóa đơn nhập hàng
CREATE TABLE tblChiTietHDN (
    MaHDN       NVARCHAR(30)   NOT NULL REFERENCES tblHoaDonNhap(MaHDN),
    MaHang      NVARCHAR(20)   NOT NULL REFERENCES tblHang(MaHang),
    SoLuong     INT            NOT NULL,
    DonGiaNhap  DECIMAL(18,2)  NOT NULL,
    ThanhTien   DECIMAL(18,2)  NOT NULL,
    PRIMARY KEY (MaHDN, MaHang)
);
GO

-- A.13 Chỉ mục hỗ trợ tìm kiếm và báo cáo
CREATE INDEX IX_tblHang_TenHang ON tblHang(TenHang);
CREATE INDEX IX_tblHoaDonBan_NgayLap ON tblHoaDonBan(NgayLap);
CREATE INDEX IX_tblHoaDonBan_MaKH ON tblHoaDonBan(MaKH);
CREATE INDEX IX_tblChiTietHDB_MaHang ON tblChiTietHDB(MaHang);
GO

-- ============================================================================
--  B. DỮ LIỆU MẪU
-- ============================================================================

-- B.1 Danh mục
INSERT INTO tblHangSX (MaHangSX, TenHangSX) VALUES
('HSX001', N'Apple'),
('HSX002', N'Samsung'),
('HSX003', N'Xiaomi'),
('HSX004', N'OPPO'),
('HSX005', N'Vivo'),
('HSX006', N'Realme');
GO

INSERT INTO tblLoai (MaLoai, TenLoai) VALUES
('L001', N'Điện thoại cao cấp'),
('L002', N'Điện thoại tầm trung'),
('L003', N'Điện thoại phổ thông'),
('L004', N'Máy tính bảng');
GO

INSERT INTO tblMau (MaMau, TenMau) VALUES
('M001', N'Đen'),
('M002', N'Trắng'),
('M003', N'Xanh dương'),
('M004', N'Đỏ'),
('M005', N'Vàng'),
('M006', N'Hồng'),
('M007', N'Xám');
GO

INSERT INTO tblDungLuong (MaDungLuong, TenDungLuong) VALUES
('DL001', N'64GB'),
('DL002', N'128GB'),
('DL003', N'256GB'),
('DL004', N'512GB'),
('DL005', N'1TB');
GO

-- B.2 Nhà cung cấp
INSERT INTO tblNhaCungCap (MaNCC, TenNCC, SDT, DiaChi, Email, NguoiLH) VALUES
('NCC001', N'Công ty TNHH Phân phối Apple VN', '0901234567', N'12 Nguyễn Huệ, Q1, TP.HCM',
 N'applevn@gmail.com', N'Nguyễn Văn An'),
('NCC002', N'Samsung Electronics VN', '0912345678', N'15 Lê Lợi, Q1, TP.HCM',
 N'samsungvn@gmail.com', N'Trần Minh Tuấn'),
('NCC003', N'Xiaomi Việt Nam', '0923456789', N'20 Trần Hưng Đạo, Q5, TP.HCM',
 N'xiaomivn@gmail.com', N'Lê Hoàng Nam'),
('NCC004', N'OPPO VN Co., Ltd', '0934567890', N'8 Đinh Tiên Hoàng, Q1, TP.HCM',
 N'oppovn@gmail.com', N'Phạm Quốc Bảo'),
('NCC005', N'Vivo VN Technology', '0945678901', N'25 Hai Bà Trưng, Q3, TP.HCM',
 N'vivovn@gmail.com', N'Vũ Thanh Hùng');
GO

-- B.3 Nhân viên (tài khoản đăng nhập: an / 123456, binh / 123456, ...)
INSERT INTO tblNhanVien
(MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, TaiKhoan, MatKhau, ChucVu, TrangThai) VALUES
('NV001', N'Nguyễn Văn An',    N'Nam', '2002-01-15', '0901111111', N'10 Lê Duẩn, Q1, TP.HCM',             N'an',     N'123456', N'Quan ly',  N'Đang làm việc'),
('NV002', N'Trần Thị Bình',    N'Nữ',  '2002-04-20', '0902222222', N'20 Điện Biên Phủ, Q3, TP.HCM',      N'binh',   N'123456', N'Nhan vien', N'Đang làm việc'),
('NV003', N'Lê Văn Cường',     N'Nam', '2001-08-12', '0903333333', N'30 Võ Văn Tần, Q3, TP.HCM',         N'cuong',  N'123456', N'Nhan vien', N'Đang làm việc'),
('NV004', N'Phạm Thị Dung',    N'Nữ',  '2003-02-25', '0904444444', N'40 Nam Kỳ Khởi Nghĩa, Q1, TP.HCM',  N'dung',   N'123456', N'Nhan vien', N'Đang làm việc'),
('NV005', N'Hoàng Văn Em',     N'Nam', '2002-06-18', '0905555555', N'50 Pasteur, Q1, TP.HCM',            N'em',     N'123456', N'Nhan vien', N'Đang làm việc'),
('NV006', N'Đặng Thị Phương',  N'Nữ',  '2001-11-09', '0906666666', N'60 Nguyễn Đình Chiểu, Q3, TP.HCM',  N'phuong', N'123456', N'Nhan vien', N'Đang làm việc'),
('NV007', N'Bùi Văn Giang',    N'Nam', '2003-07-22', '0907777777', N'70 Lý Tự Trọng, Q1, TP.HCM',        N'giang',  N'123456', N'Nhan vien', N'Đang làm việc'),
('NV008', N'Ngô Thị Hoa',      N'Nữ',  '2002-09-30', '0908888888', N'80 Trần Phú, Q5, TP.HCM',           N'hoa',    N'123456', N'Quan ly',  N'Đang làm việc');
GO

-- B.4 Khách hàng (tài khoản đăng nhập: mai.nguyen / 123456, ...)
INSERT INTO tblKhachHang (MaKH, TenKH, SDT, DiaChi, Email, TaiKhoan, MatKhau) VALUES
('KH001', N'Nguyễn Thị Mai',   '0911111111', N'5 Hoàng Diệu, Q4, TP.HCM',        N'mai.nguyen@example.com',   N'mai.nguyen',   N'123456'),
('KH002', N'Trần Văn Nam',     '0922222222', N'15 Bến Vân Đồn, Q4, TP.HCM',      N'nam.tran@example.com',     N'nam.tran',     N'123456'),
('KH003', N'Lê Thị Oanh',      '0933333333', N'25 Khánh Hội, Q4, TP.HCM',        N'oanh.le@example.com',      N'oanh.le',      N'123456'),
('KH004', N'Phạm Văn Phúc',    '0944444444', N'35 Tôn Đức Thắng, Q1, TP.HCM',    N'phuc.pham@example.com',    N'phuc.pham',    N'123456'),
('KH005', N'Hoàng Thị Quỳnh',  '0955555555', N'45 Hai Bà Trưng, Q1, TP.HCM',     N'quynh.hoang@example.com',  N'quynh.hoang',  N'123456'),
('KH006', N'Đặng Văn Long',    '0966666666', N'55 Đinh Tiên Hoàng, Q1, TP.HCM',  N'long.dang@example.com',    N'long.dang',    N'123456'),
('KH007', N'Bùi Thị Sen',      '0977777777', N'65 Trần Quang Khải, Q1, TP.HCM',  N'sen.bui@example.com',      N'sen.bui',      N'123456'),
('KH008', N'Ngô Văn Tùng',     '0988888888', N'75 Lê Thánh Tôn, Q1, TP.HCM',     N'tung.ngo@example.com',     N'tung.ngo',     N'123456'),
('KH009', N'Vũ Thị Uyên',      '0999999999', N'85 Ngô Đức Kế, Q1, TP.HCM',       N'uyen.vu@example.com',      N'uyen.vu',      N'123456'),
('KH010', N'Dương Văn Việt',   '0910000000', N'95 Mạc Thị Bưởi, Q1, TP.HCM',     N'viet.duong@example.com',   N'viet.duong',   N'123456');
GO

-- B.5 Hàng hóa: mỗi mặt hàng gắn một ảnh trong thư mục Images (TenAnh)
INSERT INTO tblHang
(MaHang, TenHang, MaHangSX, MaLoai, MaMau, MaDungLuong,
 DonGiaNhap, DonGiaBan, SoLuongTon, MoTa, TenAnh) VALUES
('SP001', N'iPhone 15 Pro Max 256GB', 'HSX001', 'L001', 'M001', 'DL003', 25000000, 32000000, 15, N'Chip A17 Pro, camera 48MP',        N'SP001.jpg'),
('SP002', N'iPhone 15 128GB',         'HSX001', 'L001', 'M002', 'DL002', 18000000, 24000000, 20, N'Chip A16, Dynamic Island',        N'SP002.jpg'),
('SP003', N'Samsung Galaxy S24 Ultra','HSX002', 'L001', 'M001', 'DL003', 22000000, 28000000, 12, N'Snapdragon 8 Gen 3, bút S Pen',  N'SP003.jpg'),
('SP004', N'Samsung Galaxy A55',      'HSX002', 'L002', 'M003', 'DL002',  7000000,  9500000, 30, N'Exynos 1480, chống nước IP67',   N'SP004.jpg'),
('SP005', N'Xiaomi 14 Pro',           'HSX003', 'L001', 'M007', 'DL003', 16000000, 21000000, 10, N'Snapdragon 8 Gen 3, Leica camera', N'SP005.jpg'),
('SP006', N'Xiaomi Redmi Note 13',    'HSX003', 'L002', 'M003', 'DL002',  3500000,  5000000, 45, N'Helio G99, camera 108MP',        N'SP006.jpg'),
('SP007', N'OPPO Find X7',            'HSX004', 'L001', 'M001', 'DL003', 17000000, 22000000,  8, N'Hasselblad camera, Dimensity 9300', N'SP007.jpg'),
('SP008', N'OPPO A98',                'HSX004', 'L002', 'M002', 'DL002',  5000000,  7000000, 35, N'Snapdragon 695, sạc 67W',        N'SP008.jpg'),
('SP009', N'Vivo X100 Pro',           'HSX005', 'L001', 'M001', 'DL003', 18000000, 23000000,  7, N'Dimensity 9300, camera ZEISS',   N'SP009.jpg'),
('SP010', N'Vivo Y36',                'HSX005', 'L003', 'M004', 'DL001',  3000000,  4200000, 50, N'Snapdragon 680, camera 50MP',    N'SP010.jpg'),
('SP011', N'Realme GT 5',             'HSX006', 'L001', 'M006', 'DL003', 12000000, 16000000, 15, N'Snapdragon 8 Gen 2, sạc 240W',   N'SP011.jpg'),
('SP012', N'Realme C55',              'HSX006', 'L003', 'M002', 'DL002',  2500000,  3800000, 60, N'Helio G88, camera 64MP',         N'SP012.jpg'),
('SP013', N'iPhone 14 Pro 128GB',     'HSX001', 'L001', 'M005', 'DL002', 20000000, 26000000,  8, N'Chip A16, Always-On display',    N'SP013.jpg'),
('SP014', N'Samsung Galaxy Z Fold 5', 'HSX002', 'L001', 'M001', 'DL004', 30000000, 40000000,  5, N'Màn hình gập, Snapdragon 8 Gen 2', N'SP014.jpg'),
('SP023', N'Vivo Y17s',               'HSX005', 'L003', 'M005', 'DL001',  2200000,  3200000, 65, N'Helio G85, pin 5000mAh',         N'SP023.jpg'),
('SP024', N'Realme C30',              'HSX006', 'L003', 'M001', 'DL001',  1500000,  2400000, 80, N'UNISOC T612, thiết kế mỏng',     N'SP024.jpg'),
('SP025', N'iPhone 15 Pro 256GB',     'HSX001', 'L001', 'M007', 'DL003', 23000000, 30000000, 10, N'Titanium, USB-C, A17 Pro',        N'SP025.jpg'),
('SP026', N'Samsung Galaxy S23 FE',   'HSX002', 'L001', 'M006', 'DL002',  9000000, 12500000, 18, N'Exynos 2200, camera 50MP',        N'SP026.jpg'),
('SP027', N'Xiaomi 13T Pro',          'HSX003', 'L001', 'M001', 'DL003', 14000000, 19000000, 12, N'Dimensity 9200+, Leica tuned',   N'SP027.jpg');
GO

-- B.6 Hóa đơn nhập hàng mẫu
INSERT INTO tblHoaDonNhap (MaHDN, MaNV, MaNCC, NgayNhap, TongTien) VALUES
('HDN001', 'NV001', 'NCC001', '2026-09-01', 375000000),
('HDN002', 'NV001', 'NCC002', '2026-09-05', 297000000),
('HDN003', 'NV001', 'NCC003', '2026-09-10', 242500000);
GO

INSERT INTO tblChiTietHDN (MaHDN, MaHang, SoLuong, DonGiaNhap, ThanhTien) VALUES
('HDN001', 'SP001', 15, 25000000, 375000000),
('HDN002', 'SP003',  9, 22000000, 198000000),
('HDN002', 'SP004',  9,  7000000,  63000000),
('HDN003', 'SP005',  5, 16000000,  80000000),
('HDN003', 'SP006', 15,  3500000,  52500000),
('HDN003', 'SP007',  5, 17000000,  85000000);
GO

-- B.7 Hóa đơn bán hàng mẫu (đã thanh toán tiền mặt)
INSERT INTO tblHoaDonBan
(MaHDB, MaNV, MaKH, NgayLap, TongTien, TrangThaiThanhToan, PhuongThucThanhToan, NgayThanhToan) VALUES
('HDB001', 'NV001', 'KH001', '2026-10-01', 32000000, N'Đã thanh toán', N'Tiền mặt', '2026-10-01'),
('HDB002', 'NV002', 'KH002', '2026-10-05',  9500000, N'Đã thanh toán', N'Tiền mặt', '2026-10-05'),
('HDB003', 'NV001', 'KH003', '2026-10-10', 24000000, N'Đã thanh toán', N'Tiền mặt', '2026-10-10'),
('HDB004', 'NV003', 'KH004', '2026-10-15',  5000000, N'Đã thanh toán', N'Chuyển khoản', '2026-10-15'),
('HDB005', 'NV002', 'KH005', '2026-10-20', 28000000, N'Đã thanh toán', N'Tiền mặt', '2026-10-20'),
('HDB006', 'NV001', 'KH006', '2026-10-25', 19420000, N'Đã thanh toán', N'Tiền mặt', '2026-10-25'),
('HDB007', 'NV003', 'KH007', '2026-10-30', 10990000, N'Đã thanh toán', N'Tiền mặt', '2026-10-30');
GO

INSERT INTO tblChiTietHDB (MaHDB, MaHang, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
('HDB001', 'SP001', 1, 32000000,  0, 32000000),
('HDB002', 'SP004', 1,  9500000,  0,  9500000),
('HDB003', 'SP002', 1, 24000000,  0, 24000000),
('HDB004', 'SP006', 1,  5000000,  0,  5000000),
('HDB005', 'SP003', 1, 28000000,  0, 28000000),
('HDB006', 'SP011', 1, 16000000,  0, 16000000),
('HDB006', 'SP012', 1,  3800000, 10,  3420000),
('HDB007', 'SP008', 1,  7000000,  0,  7000000),
('HDB007', 'SP010', 1,  4200000,  5,  3990000);
GO

PRINT N'Đã tạo xong cơ sở dữ liệu QLCuaHangBanDienThoai: 12 bảng và dữ liệu mẫu.';
PRINT N'Bước tiếp theo: chạy tệp StoredProcedures.sql (hoặc dùng tệp gộp QLCuaHangBanDienThoai.sql).';
GO

-- ============================================================================
--  PHẦN THỦ TỤC LƯU TRỮ (từ StoredProcedures.sql)
-- ============================================================================

/* ============================================================================
   HỆ THỐNG QUẢN LÝ CỬA HÀNG ĐIỆN THOẠI - TOÀN BỘ THỦ TỤC LƯU TRỮ
   Học phần: Lập trình trực quan (C# WinForms) - Bài tập lớn
   ----------------------------------------------------------------------------
   Quy ước:
     - Mọi truy vấn của chương trình nằm trong tệp này; tầng DAL chỉ gọi thủ tục,
       không còn câu lệnh SQL nào viết trực tiếp trong mã C#.
     - Nhóm 1: danh mục tra cứu (hãng sản xuất, loại hàng, màu sắc, dung lượng).
     - Nhóm 2: hàng hóa.
     - Nhóm 3: nhân viên.
     - Nhóm 4: khách hàng.
     - Nhóm 5: nhà cung cấp.
     - Nhóm 6: hóa đơn bán hàng.
     - Nhóm 7: hóa đơn nhập hàng.
     - Nhóm 8: thống kê - báo cáo.
   ============================================================================ */

/* ============================================================================
   NHÓM 1. DANH MỤC TRA CỨU
   1.1 Hãng sản xuất
   ============================================================================ */

CREATE OR ALTER PROCEDURE sp_LayDanhSachHangSX
    @TheoTen BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

    IF @TheoTen = 1
        SELECT MaHangSX, TenHangSX FROM dbo.tblHangSX ORDER BY TenHangSX;
    ELSE
        SELECT MaHangSX, TenHangSX FROM dbo.tblHangSX ORDER BY MaHangSX;
END;
GO

CREATE OR ALTER PROCEDURE sp_ThemHangSX
    @Ma NVARCHAR(20),
    @Ten NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.tblHangSX (MaHangSX, TenHangSX) VALUES (@Ma, @Ten);
    RETURN @@ROWCOUNT;
END;
GO

CREATE OR ALTER PROCEDURE sp_CapNhatHangSX
    @Ma NVARCHAR(20),
    @Ten NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.tblHangSX SET TenHangSX = @Ten WHERE MaHangSX = @Ma;
    RETURN @@ROWCOUNT;
END;
GO

CREATE OR ALTER PROCEDURE sp_XoaHangSX
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.tblHangSX WHERE MaHangSX = @Ma;
    RETURN @@ROWCOUNT;
END;
GO

CREATE OR ALTER PROCEDURE sp_KiemTraHangSXTonTai
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) FROM dbo.tblHangSX WHERE MaHangSX = @Ma;
END;
GO

/* 1.2 Loại hàng */

CREATE OR ALTER PROCEDURE sp_LayDanhSachLoai
    @TheoTen BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

    IF @TheoTen = 1
        SELECT MaLoai, TenLoai FROM dbo.tblLoai ORDER BY TenLoai;
    ELSE
        SELECT MaLoai, TenLoai FROM dbo.tblLoai ORDER BY MaLoai;
END;
GO

CREATE OR ALTER PROCEDURE sp_ThemLoai
    @Ma NVARCHAR(20),
    @Ten NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.tblLoai (MaLoai, TenLoai) VALUES (@Ma, @Ten);
    RETURN @@ROWCOUNT;
END;
GO

CREATE OR ALTER PROCEDURE sp_CapNhatLoai
    @Ma NVARCHAR(20),
    @Ten NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.tblLoai SET TenLoai = @Ten WHERE MaLoai = @Ma;
    RETURN @@ROWCOUNT;
END;
GO

CREATE OR ALTER PROCEDURE sp_XoaLoai
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.tblLoai WHERE MaLoai = @Ma;
    RETURN @@ROWCOUNT;
END;
GO

CREATE OR ALTER PROCEDURE sp_KiemTraLoaiTonTai
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) FROM dbo.tblLoai WHERE MaLoai = @Ma;
END;
GO

/* 1.3 Màu sắc */

CREATE OR ALTER PROCEDURE sp_LayDanhSachMau
    @TheoTen BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

    IF @TheoTen = 1
        SELECT MaMau, TenMau FROM dbo.tblMau ORDER BY TenMau;
    ELSE
        SELECT MaMau, TenMau FROM dbo.tblMau ORDER BY MaMau;
END;
GO

CREATE OR ALTER PROCEDURE sp_ThemMau
    @Ma NVARCHAR(20),
    @Ten NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.tblMau (MaMau, TenMau) VALUES (@Ma, @Ten);
    RETURN @@ROWCOUNT;
END;
GO

CREATE OR ALTER PROCEDURE sp_CapNhatMau
    @Ma NVARCHAR(20),
    @Ten NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.tblMau SET TenMau = @Ten WHERE MaMau = @Ma;
    RETURN @@ROWCOUNT;
END;
GO

CREATE OR ALTER PROCEDURE sp_XoaMau
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.tblMau WHERE MaMau = @Ma;
    RETURN @@ROWCOUNT;
END;
GO

CREATE OR ALTER PROCEDURE sp_KiemTraMauTonTai
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) FROM dbo.tblMau WHERE MaMau = @Ma;
END;
GO

/* 1.4 Dung lượng bộ nhớ */

CREATE OR ALTER PROCEDURE sp_LayDanhSachDungLuong
    @TheoTen BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

    IF @TheoTen = 1
        SELECT MaDungLuong, TenDungLuong FROM dbo.tblDungLuong ORDER BY TenDungLuong;
    ELSE
        SELECT MaDungLuong, TenDungLuong FROM dbo.tblDungLuong ORDER BY MaDungLuong;
END;
GO

CREATE OR ALTER PROCEDURE sp_ThemDungLuong
    @Ma NVARCHAR(20),
    @Ten NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.tblDungLuong (MaDungLuong, TenDungLuong) VALUES (@Ma, @Ten);
    RETURN @@ROWCOUNT;
END;
GO

CREATE OR ALTER PROCEDURE sp_CapNhatDungLuong
    @Ma NVARCHAR(20),
    @Ten NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.tblDungLuong SET TenDungLuong = @Ten WHERE MaDungLuong = @Ma;
    RETURN @@ROWCOUNT;
END;
GO

CREATE OR ALTER PROCEDURE sp_XoaDungLuong
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.tblDungLuong WHERE MaDungLuong = @Ma;
    RETURN @@ROWCOUNT;
END;
GO

CREATE OR ALTER PROCEDURE sp_KiemTraDungLuongTonTai
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) FROM dbo.tblDungLuong WHERE MaDungLuong = @Ma;
END;
GO

/* ============================================================================
   NHÓM 2. HÀNG HÓA
   ============================================================================ */

-- 2.1 Danh sách hàng kèm tên danh mục để hiển thị
CREATE OR ALTER PROCEDURE sp_LayDanhSachHang
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        h.MaHang,
        h.TenHang,
        h.MaHangSX,
        h.MaLoai,
        h.MaMau,
        h.MaDungLuong,
        hs.TenHangSX AS Hang,
        l.TenLoai    AS Loai,
        m.TenMau     AS Mau,
        dl.TenDungLuong AS DungLuong,
        h.DonGiaNhap,
        h.DonGiaBan,
        h.SoLuongTon,
        h.MoTa,
        h.TenAnh
    FROM dbo.tblHang h
    LEFT JOIN dbo.tblHangSX hs ON h.MaHangSX = hs.MaHangSX
    LEFT JOIN dbo.tblLoai l    ON h.MaLoai = l.MaLoai
    LEFT JOIN dbo.tblMau m     ON h.MaMau = m.MaMau
    LEFT JOIN dbo.tblDungLuong dl ON h.MaDungLuong = dl.MaDungLuong
    ORDER BY h.TenHang;
END;
GO

-- 2.2 Tìm kiếm hàng hóa theo nhiều tiêu chí
CREATE OR ALTER PROCEDURE sp_TimKiemHang
    @TenHang NVARCHAR(200) = NULL,
    @MaHangSX NVARCHAR(20) = NULL,
    @MaLoai NVARCHAR(20) = NULL,
    @MaMau NVARCHAR(20) = NULL,
    @GiaTu DECIMAL(18,2) = NULL,
    @GiaDen DECIMAL(18,2) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        h.MaHang,
        h.TenHang,
        h.MaHangSX,
        h.MaLoai,
        h.MaMau,
        h.MaDungLuong,
        hs.TenHangSX AS Hang,
        l.TenLoai    AS Loai,
        m.TenMau     AS Mau,
        dl.TenDungLuong AS DungLuong,
        h.DonGiaNhap,
        h.DonGiaBan,
        h.SoLuongTon,
        h.MoTa,
        h.TenAnh
    FROM dbo.tblHang h
    LEFT JOIN dbo.tblHangSX hs ON h.MaHangSX = hs.MaHangSX
    LEFT JOIN dbo.tblLoai l    ON h.MaLoai = l.MaLoai
    LEFT JOIN dbo.tblMau m     ON h.MaMau = m.MaMau
    LEFT JOIN dbo.tblDungLuong dl ON h.MaDungLuong = dl.MaDungLuong
    WHERE
        (@TenHang IS NULL OR h.TenHang LIKE N'%' + @TenHang + N'%')
        AND (@MaHangSX IS NULL OR h.MaHangSX = @MaHangSX)
        AND (@MaLoai IS NULL OR h.MaLoai = @MaLoai)
        AND (@MaMau IS NULL OR h.MaMau = @MaMau)
        AND (@GiaTu IS NULL OR h.DonGiaBan >= @GiaTu)
        AND (@GiaDen IS NULL OR h.DonGiaBan <= @GiaDen)
    ORDER BY h.TenHang;
END;
GO

-- 2.3 Thêm hàng hóa
CREATE OR ALTER PROCEDURE sp_ThemHang
    @MaHang NVARCHAR(20),
    @TenHang NVARCHAR(100),
    @MaHangSX NVARCHAR(20) = NULL,
    @MaLoai NVARCHAR(20) = NULL,
    @MaMau NVARCHAR(20) = NULL,
    @MaDungLuong NVARCHAR(20) = NULL,
    @DonGiaNhap DECIMAL(18,2),
    @DonGiaBan DECIMAL(18,2),
    @SoLuongTon INT,
    @TenAnh NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblHang
        (MaHang, TenHang, MaHangSX, MaLoai, MaMau, MaDungLuong,
         DonGiaNhap, DonGiaBan, SoLuongTon, TenAnh)
    VALUES
        (@MaHang, @TenHang, @MaHangSX, @MaLoai, @MaMau, @MaDungLuong,
         @DonGiaNhap, @DonGiaBan, @SoLuongTon, @TenAnh);

    RETURN @@ROWCOUNT;
END;
GO

-- 2.4 Cập nhật hàng hóa
CREATE OR ALTER PROCEDURE sp_CapNhatHang
    @MaHang NVARCHAR(20),
    @TenHang NVARCHAR(100),
    @MaHangSX NVARCHAR(20) = NULL,
    @MaLoai NVARCHAR(20) = NULL,
    @MaMau NVARCHAR(20) = NULL,
    @MaDungLuong NVARCHAR(20) = NULL,
    @DonGiaNhap DECIMAL(18,2),
    @DonGiaBan DECIMAL(18,2),
    @SoLuongTon INT,
    @TenAnh NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.tblHang
    SET TenHang      = @TenHang,
        MaHangSX     = @MaHangSX,
        MaLoai       = @MaLoai,
        MaMau        = @MaMau,
        MaDungLuong  = @MaDungLuong,
        DonGiaNhap   = @DonGiaNhap,
        DonGiaBan    = @DonGiaBan,
        SoLuongTon   = @SoLuongTon,
        TenAnh       = @TenAnh
    WHERE MaHang = @MaHang;

    RETURN @@ROWCOUNT;
END;
GO

-- 2.5 Xóa hàng hóa
CREATE OR ALTER PROCEDURE sp_XoaHang
    @MaHang NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.tblHang WHERE MaHang = @MaHang;

    RETURN @@ROWCOUNT;
END;
GO

-- 2.6 Kiểm tra mã hàng đã tồn tại
CREATE OR ALTER PROCEDURE sp_KiemTraHangTonTai
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) FROM dbo.tblHang WHERE MaHang = @Ma;
END;
GO

-- 2.7 Danh sách mã hàng (nạp ComboBox / AutoComplete)
CREATE OR ALTER PROCEDURE sp_LayDanhSachMaHang
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaHang FROM dbo.tblHang ORDER BY MaHang;
END;
GO

-- 2.8 Thông tin một mặt hàng (tên, giá, tồn kho)
CREATE OR ALTER PROCEDURE sp_LayThongTinHang
    @MaHang NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        MaHang,
        TenHang,
        DonGiaNhap,
        DonGiaBan,
        SoLuongTon,
        TenAnh
    FROM dbo.tblHang
    WHERE MaHang = @MaHang;
END;
GO

/* ============================================================================
   NHÓM 3. NHÂN VIÊN
   ============================================================================ */

-- 3.1 Đăng nhập nhân viên
CREATE OR ALTER PROCEDURE sp_KiemTraDangNhap
    @TaiKhoan NVARCHAR(50),
    @MatKhau NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        MaNV,
        TenNV,
        ChucVu AS VaiTro,
        TaiKhoan
    FROM dbo.tblNhanVien
    WHERE TaiKhoan = @TaiKhoan
      AND MatKhau = @MatKhau;
END;
GO

-- 3.2 Danh sách nhân viên
CREATE OR ALTER PROCEDURE sp_LayDanhSachNhanVien
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        MaNV,
        TenNV,
        GioiTinh,
        NgaySinh,
        SDT,
        DiaChi,
        TaiKhoan AS TenDangNhap,
        MatKhau,
        ChucVu,
        ISNULL(TrangThai, N'Đang làm việc') AS TrangThai
    FROM dbo.tblNhanVien
    ORDER BY MaNV;
END;
GO

-- 3.3 Thêm nhân viên
CREATE OR ALTER PROCEDURE sp_ThemNhanVien
    @MaNV NVARCHAR(20),
    @TenNV NVARCHAR(100),
    @GioiTinh NVARCHAR(10) = NULL,
    @NgaySinh DATETIME = NULL,
    @SDT NVARCHAR(20) = NULL,
    @DiaChi NVARCHAR(200) = NULL,
    @TaiKhoan NVARCHAR(50) = NULL,
    @MatKhau NVARCHAR(100) = NULL,
    @ChucVu NVARCHAR(50) = NULL,
    @TrangThai NVARCHAR(30) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblNhanVien
        (MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi,
         TaiKhoan, MatKhau, ChucVu, TrangThai)
    VALUES
        (@MaNV, @TenNV, @GioiTinh, @NgaySinh, @SDT, @DiaChi,
         @TaiKhoan, @MatKhau, @ChucVu, ISNULL(@TrangThai, N'Đang làm việc'));

    RETURN @@ROWCOUNT;
END;
GO

-- 3.4 Cập nhật nhân viên
CREATE OR ALTER PROCEDURE sp_CapNhatNhanVien
    @MaNV NVARCHAR(20),
    @TenNV NVARCHAR(100),
    @GioiTinh NVARCHAR(10) = NULL,
    @NgaySinh DATETIME = NULL,
    @SDT NVARCHAR(20) = NULL,
    @DiaChi NVARCHAR(200) = NULL,
    @MatKhau NVARCHAR(100) = NULL,
    @ChucVu NVARCHAR(50) = NULL,
    @TrangThai NVARCHAR(30) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.tblNhanVien
    SET TenNV     = @TenNV,
        GioiTinh  = @GioiTinh,
        NgaySinh  = @NgaySinh,
        SDT       = @SDT,
        DiaChi    = @DiaChi,
        MatKhau   = @MatKhau,
        ChucVu    = @ChucVu,
        TrangThai = @TrangThai
    WHERE MaNV = @MaNV;

    RETURN @@ROWCOUNT;
END;
GO

-- 3.5 Cập nhật trạng thái làm việc
CREATE OR ALTER PROCEDURE sp_CapNhatTrangThaiNhanVien
    @MaNV NVARCHAR(20),
    @TrangThai NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.tblNhanVien
    SET TrangThai = @TrangThai
    WHERE MaNV = @MaNV;

    RETURN @@ROWCOUNT;
END;
GO

-- 3.6 Xóa nhân viên
CREATE OR ALTER PROCEDURE sp_XoaNhanVien
    @MaNV NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.tblNhanVien WHERE MaNV = @MaNV;

    RETURN @@ROWCOUNT;
END;
GO

-- 3.7 Kiểm tra mã nhân viên tồn tại
CREATE OR ALTER PROCEDURE sp_KiemTraNhanVienTonTai
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) FROM dbo.tblNhanVien WHERE MaNV = @Ma;
END;
GO

-- 3.8 Danh sách mã nhân viên (AutoComplete khi lập hóa đơn)
CREATE OR ALTER PROCEDURE sp_LayDanhSachMaNV
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaNV FROM dbo.tblNhanVien ORDER BY MaNV;
END;
GO

-- 3.9 Tên nhân viên theo mã
CREATE OR ALTER PROCEDURE sp_LayTenNhanVien
    @MaNV NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TenNV FROM dbo.tblNhanVien WHERE MaNV = @MaNV;
END;
GO

/* ============================================================================
   NHÓM 4. KHÁCH HÀNG
   ============================================================================ */

-- 4.1 Danh sách khách hàng
CREATE OR ALTER PROCEDURE sp_LayDanhSachKhachHang
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaKH, TenKH, SDT, DiaChi, Email, TaiKhoan
    FROM dbo.tblKhachHang
    ORDER BY MaKH;
END;
GO

-- 4.2 Thêm khách hàng (chức năng quản lý)
CREATE OR ALTER PROCEDURE sp_ThemKhachHang
    @MaKH NVARCHAR(20),
    @TenKH NVARCHAR(100),
    @SDT NVARCHAR(20) = NULL,
    @DiaChi NVARCHAR(200) = NULL,
    @Email NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblKhachHang (MaKH, TenKH, SDT, DiaChi, Email)
    VALUES (@MaKH, @TenKH, @SDT, @DiaChi, @Email);

    RETURN @@ROWCOUNT;
END;
GO

-- 4.3 Cập nhật khách hàng
CREATE OR ALTER PROCEDURE sp_CapNhatKhachHang
    @MaKH NVARCHAR(20),
    @TenKH NVARCHAR(100),
    @SDT NVARCHAR(20) = NULL,
    @DiaChi NVARCHAR(200) = NULL,
    @Email NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.tblKhachHang
    SET TenKH  = @TenKH,
        SDT    = @SDT,
        DiaChi = @DiaChi,
        Email  = @Email
    WHERE MaKH = @MaKH;

    RETURN @@ROWCOUNT;
END;
GO

-- 4.4 Xóa khách hàng
CREATE OR ALTER PROCEDURE sp_XoaKhachHang
    @MaKH NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.tblKhachHang WHERE MaKH = @MaKH;

    RETURN @@ROWCOUNT;
END;
GO

-- 4.5 Kiểm tra mã khách hàng tồn tại
CREATE OR ALTER PROCEDURE sp_KiemTraKhachHangTonTai
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) FROM dbo.tblKhachHang WHERE MaKH = @Ma;
END;
GO

-- 4.6 Kiểm tra tên tài khoản đã dùng
CREATE OR ALTER PROCEDURE sp_KiemTraTaiKhoanKhachHang
    @TaiKhoan NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) FROM dbo.tblKhachHang WHERE TaiKhoan = @TaiKhoan;
END;
GO

-- 4.7 Kiểm tra email đã dùng
CREATE OR ALTER PROCEDURE sp_KiemTraEmailKhachHang
    @Email NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) FROM dbo.tblKhachHang WHERE Email = @Email;
END;
GO

-- 4.8 Đăng ký tài khoản khách hàng: tự sinh mã KH và ghi tài khoản
CREATE OR ALTER PROCEDURE sp_DangKyKhachHang
    @TenKH NVARCHAR(100),
    @SDT NVARCHAR(20) = NULL,
    @Email NVARCHAR(100) = NULL,
    @TaiKhoan NVARCHAR(50),
    @MatKhau NVARCHAR(255),
    @DiaChi NVARCHAR(200) = NULL,
    @MaKH NVARCHAR(20) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @SoMoi INT;

    BEGIN TRAN;

    SELECT @SoMoi = ISNULL(MAX(TRY_CONVERT(INT, SUBSTRING(MaKH, 3, 18))), 0) + 1
    FROM dbo.tblKhachHang WITH (UPDLOCK, HOLDLOCK)
    WHERE MaKH LIKE N'KH[0-9]%';

    SET @MaKH = 'KH' + RIGHT('000' + CAST(@SoMoi AS VARCHAR(10)), 3);

    INSERT INTO dbo.tblKhachHang
        (MaKH, TenKH, SDT, DiaChi, Email, TaiKhoan, MatKhau)
    VALUES
        (@MaKH, @TenKH, @SDT, @DiaChi, @Email, @TaiKhoan, @MatKhau);

    DECLARE @SoDong INT = @@ROWCOUNT;

    COMMIT TRAN;

    RETURN @SoDong;
END;
GO

-- 4.9 Đăng nhập khách hàng
CREATE OR ALTER PROCEDURE sp_DangNhapKhachHang
    @TaiKhoan NVARCHAR(50),
    @MatKhau NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaKH, TenKH, SDT, DiaChi, Email, TaiKhoan
    FROM dbo.tblKhachHang
    WHERE TaiKhoan = @TaiKhoan
      AND MatKhau = @MatKhau;
END;
GO

-- 4.10 Danh sách mã khách hàng (AutoComplete khi lập hóa đơn)
CREATE OR ALTER PROCEDURE sp_LayDanhSachMaKH
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaKH FROM dbo.tblKhachHang ORDER BY MaKH;
END;
GO

-- 4.11 Thông tin khách hàng theo mã
CREATE OR ALTER PROCEDURE sp_LayThongTinKhachHang
    @MaKH NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaKH, TenKH, SDT, DiaChi, Email
    FROM dbo.tblKhachHang
    WHERE MaKH = @MaKH;
END;
GO

-- 4.12 Danh sách hóa đơn của một khách hàng (dùng khi kiểm tra trước khi xóa)
CREATE OR ALTER PROCEDURE sp_LayHoaDonCuaKhachHang
    @MaKH NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaHDB
    FROM dbo.tblHoaDonBan
    WHERE MaKH = @MaKH
    ORDER BY MaHDB;
END;
GO

/* ============================================================================
   NHÓM 5. NHÀ CUNG CẤP
   ============================================================================ */

CREATE OR ALTER PROCEDURE sp_LayDanhSachNhaCungCap
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaNCC, TenNCC, SDT, DiaChi, Email, NguoiLH
    FROM dbo.tblNhaCungCap
    ORDER BY MaNCC;
END;
GO

CREATE OR ALTER PROCEDURE sp_ThemNhaCungCap
    @MaNCC NVARCHAR(20),
    @TenNCC NVARCHAR(100),
    @SDT NVARCHAR(20) = NULL,
    @DiaChi NVARCHAR(200) = NULL,
    @Email NVARCHAR(100) = NULL,
    @NguoiLH NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblNhaCungCap (MaNCC, TenNCC, SDT, DiaChi, Email, NguoiLH)
    VALUES (@MaNCC, @TenNCC, @SDT, @DiaChi, @Email, @NguoiLH);

    RETURN @@ROWCOUNT;
END;
GO

CREATE OR ALTER PROCEDURE sp_CapNhatNhaCungCap
    @MaNCC NVARCHAR(20),
    @TenNCC NVARCHAR(100),
    @SDT NVARCHAR(20) = NULL,
    @DiaChi NVARCHAR(200) = NULL,
    @Email NVARCHAR(100) = NULL,
    @NguoiLH NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.tblNhaCungCap
    SET TenNCC  = @TenNCC,
        SDT     = @SDT,
        DiaChi  = @DiaChi,
        Email   = @Email,
        NguoiLH = @NguoiLH
    WHERE MaNCC = @MaNCC;

    RETURN @@ROWCOUNT;
END;
GO

CREATE OR ALTER PROCEDURE sp_XoaNhaCungCap
    @MaNCC NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.tblNhaCungCap WHERE MaNCC = @MaNCC;

    RETURN @@ROWCOUNT;
END;
GO

CREATE OR ALTER PROCEDURE sp_KiemTraNhaCungCapTonTai
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) FROM dbo.tblNhaCungCap WHERE MaNCC = @Ma;
END;
GO

CREATE OR ALTER PROCEDURE sp_LayDanhSachMaNCC
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaNCC FROM dbo.tblNhaCungCap ORDER BY MaNCC;
END;
GO

CREATE OR ALTER PROCEDURE sp_LayThongTinNhaCungCap
    @MaNCC NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaNCC, TenNCC, SDT, DiaChi, Email, NguoiLH
    FROM dbo.tblNhaCungCap
    WHERE MaNCC = @MaNCC;
END;
GO

/* ============================================================================
   NHÓM 6. HÓA ĐƠN BÁN HÀNG
   ============================================================================ */

-- 6.1 Danh sách mã hóa đơn bán (mới nhất trước)
CREATE OR ALTER PROCEDURE sp_LayDanhSachMaHDB
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaHDB FROM dbo.tblHoaDonBan ORDER BY MaHDB DESC;
END;
GO

-- 6.2 Kiểm tra hóa đơn bán tồn tại
CREATE OR ALTER PROCEDURE sp_KiemTraHoaDonBanTonTai
    @MaHDB NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) FROM dbo.tblHoaDonBan WHERE MaHDB = @MaHDB;
END;
GO

-- 6.3 Thông tin đầu hóa đơn bán (kèm nhân viên, khách hàng)
CREATE OR ALTER PROCEDURE sp_LayHoaDonBan
    @MaHDB NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        hd.MaHDB,
        hd.MaNV,
        nv.TenNV,
        hd.MaKH,
        kh.TenKH,
        kh.SDT,
        kh.DiaChi,
        hd.NgayLap,
        hd.TongTien,
        hd.PhuongThucThanhToan,
        hd.TrangThaiThanhToan,
        hd.NgayThanhToan
    FROM dbo.tblHoaDonBan hd
    INNER JOIN dbo.tblNhanVien nv ON hd.MaNV = nv.MaNV
    LEFT JOIN dbo.tblKhachHang kh ON hd.MaKH = kh.MaKH
    WHERE hd.MaHDB = @MaHDB;
END;
GO

-- 6.4 Chi tiết hóa đơn bán
CREATE OR ALTER PROCEDURE sp_LayChiTietHoaDonBan
    @MaHDB NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ct.MaHang,
        hang.TenHang,
        ct.DonGia,
        ct.SoLuong,
        ct.GiamGia,
        ct.ThanhTien
    FROM dbo.tblChiTietHDB ct
    INNER JOIN dbo.tblHang hang ON ct.MaHang = hang.MaHang
    WHERE ct.MaHDB = @MaHDB
    ORDER BY ct.MaHang;
END;
GO

-- 6.5 Lưu hóa đơn bán: kiểm tra mã, trừ tồn kho, ghi đầu + chi tiết trong MỘT giao dịch
--     Chi tiết truyền vào dưới dạng XML:
--     <ChiTiet><Dong MaHang="SP001" SoLuong="2" DonGia="32000000" GiamGia="0" ThanhTien="64000000"/></ChiTiet>
CREATE OR ALTER PROCEDURE sp_LuuHoaDonBan
    @MaHDB NVARCHAR(30),
    @MaNV NVARCHAR(20),
    @MaKH NVARCHAR(20) = NULL,
    @NgayLap DATETIME = NULL,
    @ChiTietXml NVARCHAR(MAX),
    @LayGiaTuCSDL BIT = 0,
    @TrangThaiThanhToan NVARCHAR(30) = NULL,
    @PhuongThucThanhToan NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @NgayLap IS NULL SET @NgayLap = GETDATE();
    IF @TrangThaiThanhToan IS NULL SET @TrangThaiThanhToan = N'Chưa thanh toán';

    IF EXISTS (SELECT 1 FROM dbo.tblHoaDonBan WHERE MaHDB = @MaHDB)
        THROW 51001, N'Mã hóa đơn đã tồn tại. Hãy tạo mã mới.', 1;

    IF NOT EXISTS (SELECT 1 FROM dbo.tblNhanVien WHERE MaNV = @MaNV)
        THROW 51002, N'Mã nhân viên không tồn tại trong hệ thống.', 1;

    IF @MaKH IS NOT NULL AND @MaKH <> '' AND NOT EXISTS
        (SELECT 1 FROM dbo.tblKhachHang WHERE MaKH = @MaKH)
        THROW 51003, N'Mã khách hàng không tồn tại trong hệ thống.', 1;

    DECLARE @xml XML = TRY_CAST(@ChiTietXml AS XML);

    IF @xml IS NULL
        THROW 51004, N'Chi tiết hóa đơn không hợp lệ.', 1;

    DECLARE @ds TABLE
    (
        MaHang    NVARCHAR(20) NOT NULL,
        SoLuong   INT          NOT NULL,
        DonGia    DECIMAL(18,2) NOT NULL,
        GiamGia   DECIMAL(5,2)  NOT NULL,
        ThanhTien DECIMAL(18,2) NOT NULL
    );

    INSERT INTO @ds (MaHang, SoLuong, DonGia, GiamGia, ThanhTien)
    SELECT
        x.value('@MaHang', 'NVARCHAR(20)'),
        x.value('@SoLuong', 'INT'),
        x.value('@DonGia', 'DECIMAL(18,2)'),
        x.value('@GiamGia', 'DECIMAL(5,2)'),
        x.value('@ThanhTien', 'DECIMAL(18,2)')
    FROM @xml.nodes('/ChiTiet/Dong') AS t(x);

    IF NOT EXISTS (SELECT 1 FROM @ds)
        THROW 51005, N'Hóa đơn chưa có mặt hàng.', 1;

    -- Giá bán lấy theo dữ liệu hiện hành của kho (dùng cho đơn khách đặt trên Form12)
    IF @LayGiaTuCSDL = 1
    BEGIN
        UPDATE d
        SET DonGia    = hang.DonGiaBan,
            GiamGia   = 0,
            d.ThanhTien = hang.DonGiaBan * d.SoLuong
        FROM @ds d
        INNER JOIN dbo.tblHang hang ON hang.MaHang = d.MaHang;
    END;

    IF EXISTS (SELECT 1 FROM @ds d WHERE NOT EXISTS
              (SELECT 1 FROM dbo.tblHang hang WHERE hang.MaHang = d.MaHang))
        THROW 51007, N'Có mã hàng không tồn tại trong kho. Hóa đơn chưa được lưu.', 1;

    IF EXISTS (
        SELECT 1
        FROM @ds d
        INNER JOIN dbo.tblHang hang ON hang.MaHang = d.MaHang
        WHERE hang.SoLuongTon < d.SoLuong)
        THROW 51006, N'Số lượng tồn kho không đủ cho một mặt hàng trong hóa đơn. Hóa đơn chưa được lưu.', 1;

    DECLARE @TongTien DECIMAL(18,2) = (SELECT SUM(ThanhTien) FROM @ds);

    BEGIN TRAN;

    INSERT INTO dbo.tblHoaDonBan
        (MaHDB, MaNV, MaKH, NgayLap, TongTien, TrangThaiThanhToan, PhuongThucThanhToan)
    VALUES
        (@MaHDB, @MaNV,
         CASE WHEN @MaKH = '' THEN NULL ELSE @MaKH END,
         @NgayLap, @TongTien, @TrangThaiThanhToan, @PhuongThucThanhToan);

    INSERT INTO dbo.tblChiTietHDB (MaHDB, MaHang, SoLuong, DonGia, GiamGia, ThanhTien)
    SELECT @MaHDB, d.MaHang, d.SoLuong, d.DonGia, d.GiamGia, d.ThanhTien
    FROM @ds d;

    UPDATE hang
    SET SoLuongTon = hang.SoLuongTon - d.SoLuong
    FROM dbo.tblHang hang
    INNER JOIN @ds d ON d.MaHang = hang.MaHang;

    COMMIT TRAN;

    SELECT @MaHDB AS MaHDB, @TongTien AS TongTien;
    RETURN 0;
END;
GO

-- 6.6 Danh sách hóa đơn của khách hàng (mới nhất trước)
CREATE OR ALTER PROCEDURE sp_LayHoaDonTheoKhachHang
    @MaKH NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        MaHDB AS MaHD,
        NgayLap,
        TongTien,
        PhuongThucThanhToan,
        TrangThaiThanhToan
    FROM dbo.tblHoaDonBan
    WHERE MaKH = @MaKH
    ORDER BY NgayLap DESC;
END;
GO

-- 6.7 Hóa đơn chưa thanh toán của khách hàng (màn hình Thanh toán)
CREATE OR ALTER PROCEDURE sp_LayHoaDonChuaThanhToan
    @MaKH NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        MaHDB AS MaHD,
        NgayLap,
        TongTien,
        PhuongThucThanhToan,
        TrangThaiThanhToan
    FROM dbo.tblHoaDonBan
    WHERE MaKH = @MaKH
      AND TrangThaiThanhToan IN (N'Chưa thanh toán', N'Chờ xác nhận chuyển khoản')
    ORDER BY NgayLap DESC;
END;
GO

-- 6.8 Thông tin thanh toán của một hóa đơn thuộc đúng khách hàng
CREATE OR ALTER PROCEDURE sp_LayThongTinThanhToan
    @MaHDB NVARCHAR(30),
    @MaKH NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TongTien, PhuongThucThanhToan, TrangThaiThanhToan
    FROM dbo.tblHoaDonBan
    WHERE MaHDB = @MaHDB
      AND MaKH = @MaKH;
END;
GO

-- 6.9 Cập nhật phương thức thanh toán của hóa đơn
CREATE OR ALTER PROCEDURE sp_CapNhatPhuongThucThanhToan
    @MaHDB NVARCHAR(30),
    @MaKH NVARCHAR(20),
    @PhuongThuc NVARCHAR(50),
    @TrangThai NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.tblHoaDonBan
    SET PhuongThucThanhToan = @PhuongThuc,
        TrangThaiThanhToan  = @TrangThai
    WHERE MaHDB = @MaHDB
      AND MaKH = @MaKH;

    RETURN @@ROWCOUNT;
END;
GO

/* ============================================================================
   NHÓM 7. HÓA ĐƠN NHẬP HÀNG
   ============================================================================ */

CREATE OR ALTER PROCEDURE sp_LayDanhSachMaHDN
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaHDN FROM dbo.tblHoaDonNhap ORDER BY MaHDN;
END;
GO

CREATE OR ALTER PROCEDURE sp_KiemTraHoaDonNhapTonTai
    @MaHDN NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) FROM dbo.tblHoaDonNhap WHERE MaHDN = @MaHDN;
END;
GO

CREATE OR ALTER PROCEDURE sp_LayHoaDonNhap
    @MaHDN NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        hd.MaHDN,
        hd.MaNV,
        nv.TenNV,
        hd.MaNCC,
        ncc.TenNCC,
        ncc.SDT,
        ncc.DiaChi,
        hd.NgayNhap,
        hd.TongTien
    FROM dbo.tblHoaDonNhap hd
    INNER JOIN dbo.tblNhanVien nv ON hd.MaNV = nv.MaNV
    INNER JOIN dbo.tblNhaCungCap ncc ON hd.MaNCC = ncc.MaNCC
    WHERE hd.MaHDN = @MaHDN;
END;
GO

CREATE OR ALTER PROCEDURE sp_LayChiTietHoaDonNhap
    @MaHDN NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ct.MaHang,
        hang.TenHang,
        ct.DonGiaNhap,
        ct.SoLuong,
        ct.ThanhTien
    FROM dbo.tblChiTietHDN ct
    INNER JOIN dbo.tblHang hang ON ct.MaHang = hang.MaHang
    WHERE ct.MaHDN = @MaHDN
    ORDER BY ct.MaHang;
END;
GO

-- 7.5 Lưu hóa đơn nhập: cộng tồn kho, cập nhật giá nhập, ghi đầu + chi tiết trong MỘT giao dịch
CREATE OR ALTER PROCEDURE sp_LuuHoaDonNhap
    @MaHDN NVARCHAR(30),
    @MaNV NVARCHAR(20),
    @MaNCC NVARCHAR(20),
    @NgayNhap DATETIME = NULL,
    @ChiTietXml NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @NgayNhap IS NULL SET @NgayNhap = GETDATE();

    IF EXISTS (SELECT 1 FROM dbo.tblHoaDonNhap WHERE MaHDN = @MaHDN)
        THROW 52001, N'Mã hóa đơn nhập đã tồn tại. Hãy tạo mã mới.', 1;

    IF NOT EXISTS (SELECT 1 FROM dbo.tblNhanVien WHERE MaNV = @MaNV)
        THROW 52002, N'Mã nhân viên không tồn tại trong hệ thống.', 1;

    IF NOT EXISTS (SELECT 1 FROM dbo.tblNhaCungCap WHERE MaNCC = @MaNCC)
        THROW 52003, N'Mã nhà cung cấp không tồn tại trong hệ thống.', 1;

    DECLARE @xml XML = TRY_CAST(@ChiTietXml AS XML);

    IF @xml IS NULL
        THROW 52004, N'Chi tiết hóa đơn nhập không hợp lệ.', 1;

    DECLARE @ds TABLE
    (
        MaHang    NVARCHAR(20) NOT NULL,
        SoLuong   INT          NOT NULL,
        DonGiaNhap DECIMAL(18,2) NOT NULL,
        ThanhTien DECIMAL(18,2) NOT NULL
    );

    INSERT INTO @ds (MaHang, SoLuong, DonGiaNhap, ThanhTien)
    SELECT
        x.value('@MaHang', 'NVARCHAR(20)'),
        x.value('@SoLuong', 'INT'),
        x.value('@DonGiaNhap', 'DECIMAL(18,2)'),
        x.value('@ThanhTien', 'DECIMAL(18,2)')
    FROM @xml.nodes('/ChiTiet/Dong') AS t(x);

    IF NOT EXISTS (SELECT 1 FROM @ds)
        THROW 52005, N'Hóa đơn nhập chưa có mặt hàng.', 1;

    IF EXISTS (SELECT 1 FROM @ds d WHERE NOT EXISTS
              (SELECT 1 FROM dbo.tblHang hang WHERE hang.MaHang = d.MaHang))
        THROW 52006, N'Có mã hàng không tồn tại trong kho. Hóa đơn chưa được lưu.', 1;

    DECLARE @TongTien DECIMAL(18,2) = (SELECT SUM(ThanhTien) FROM @ds);

    BEGIN TRAN;

    INSERT INTO dbo.tblHoaDonNhap (MaHDN, MaNV, MaNCC, NgayNhap, TongTien)
    VALUES (@MaHDN, @MaNV, @MaNCC, @NgayNhap, @TongTien);

    INSERT INTO dbo.tblChiTietHDN (MaHDN, MaHang, SoLuong, DonGiaNhap, ThanhTien)
    SELECT @MaHDN, d.MaHang, d.SoLuong, d.DonGiaNhap, d.ThanhTien
    FROM @ds d;

    UPDATE hang
    SET SoLuongTon = hang.SoLuongTon + d.SoLuong,
        DonGiaNhap  = d.DonGiaNhap
    FROM dbo.tblHang hang
    INNER JOIN @ds d ON d.MaHang = hang.MaHang;

    COMMIT TRAN;

    SELECT @MaHDN AS MaHDN, @TongTien AS TongTien;
    RETURN 0;
END;
GO

/* ============================================================================
   NHÓM 8. THỐNG KÊ - BÁO CÁO
   ============================================================================ */

CREATE OR ALTER PROCEDURE sp_ThongKe_TongSanPham
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) FROM dbo.tblHang;
END;
GO

CREATE OR ALTER PROCEDURE sp_ThongKe_TongKhachHang
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) FROM dbo.tblKhachHang;
END;
GO

CREATE OR ALTER PROCEDURE sp_ThongKe_HoaDonHomNay
AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(*)
    FROM dbo.tblHoaDonBan
    WHERE NgayLap >= CONVERT(date, GETDATE())
      AND NgayLap <  DATEADD(day, 1, CONVERT(date, GETDATE()));
END;
GO

CREATE OR ALTER PROCEDURE sp_ThongKe_DoanhThuHomNay
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ISNULL(SUM(TongTien), 0)
    FROM dbo.tblHoaDonBan
    WHERE NgayLap >= CONVERT(date, GETDATE())
      AND NgayLap <  DATEADD(day, 1, CONVERT(date, GETDATE()));
END;
GO

CREATE OR ALTER PROCEDURE sp_ThongKe_TongHangTonKho
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(SUM(SoLuongTon), 0) FROM dbo.tblHang;
END;
GO

-- Doanh thu 7 ngày gần nhất, gồm cả ngày không có hóa đơn
CREATE OR ALTER PROCEDURE sp_ThongKe_DoanhThu7Ngay
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH NgayGanDay AS
    (
        SELECT CONVERT(date, DATEADD(day, -6, GETDATE())) AS Ngay
        UNION ALL
        SELECT DATEADD(day, 1, Ngay)
        FROM NgayGanDay
        WHERE Ngay < CONVERT(date, GETDATE())
    )
    SELECT
        n.Ngay,
        ISNULL(SUM(h.TongTien), 0) AS DoanhThu
    FROM NgayGanDay n
    LEFT JOIN dbo.tblHoaDonBan h
        ON h.NgayLap >= n.Ngay
       AND h.NgayLap <  DATEADD(day, 1, n.Ngay)
    GROUP BY n.Ngay
    ORDER BY n.Ngay
    OPTION (MAXRECURSION 7);
END;
GO

CREATE OR ALTER PROCEDURE sp_ThongKe_Top5BanChay
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 5
        hang.MaHang,
        hang.TenHang,
        SUM(ct.SoLuong)   AS TongSoLuongBan,
        SUM(ct.ThanhTien) AS TongDoanhThu
    FROM dbo.tblChiTietHDB ct
    INNER JOIN dbo.tblHang hang ON ct.MaHang = hang.MaHang
    GROUP BY hang.MaHang, hang.TenHang
    ORDER BY SUM(ct.SoLuong) DESC;
END;
GO

CREATE OR ALTER PROCEDURE sp_ThongKe_SanPhamSapHetHang
    @NguongTon INT = 10
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaHang, TenHang, SoLuongTon
    FROM dbo.tblHang
    WHERE SoLuongTon <= @NguongTon
    ORDER BY SoLuongTon ASC;
END;
GO

-- Báo cáo doanh thu theo tháng (FormBaoCao)
CREATE OR ALTER PROCEDURE sp_BaoCao_DoanhThuTheoThang
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        YEAR(NgayLap)  AS Nam,
        MONTH(NgayLap) AS Thang,
        COUNT(*)       AS SoHoaDon,
        SUM(TongTien)  AS DoanhThu
    FROM dbo.tblHoaDonBan
    GROUP BY YEAR(NgayLap), MONTH(NgayLap)
    ORDER BY Nam DESC, Thang DESC;
END;
GO

-- Báo cáo tồn kho kèm giá trị tồn (FormBaoCao)
CREATE OR ALTER PROCEDURE sp_BaoCao_TonKho
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        hang.MaHang,
        hang.TenHang,
        hs.TenHangSX AS Hang,
        l.TenLoai    AS Loai,
        hang.DonGiaBan,
        hang.SoLuongTon,
        (hang.DonGiaBan * hang.SoLuongTon) AS GiaTriTon
    FROM dbo.tblHang hang
    LEFT JOIN dbo.tblHangSX hs ON hang.MaHangSX = hs.MaHangSX
    LEFT JOIN dbo.tblLoai l    ON hang.MaLoai = l.MaLoai
    ORDER BY hang.SoLuongTon DESC;
END;
GO

-- Báo cáo top sản phẩm bán chạy (FormBaoCao)
CREATE OR ALTER PROCEDURE sp_BaoCao_TopBanChay
    @SoLuong INT = 10
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP (@SoLuong)
        hang.MaHang,
        hang.TenHang,
        hs.TenHangSX AS Hang,
        SUM(ct.SoLuong)   AS SoLuongBan,
        SUM(ct.ThanhTien) AS DoanhThu
    FROM dbo.tblChiTietHDB ct
    INNER JOIN dbo.tblHang hang ON ct.MaHang = hang.MaHang
    LEFT JOIN dbo.tblHangSX hs  ON hang.MaHangSX = hs.MaHangSX
    GROUP BY hang.MaHang, hang.TenHang, hs.TenHangSX
    ORDER BY SUM(ct.SoLuong) DESC;
END;
GO
