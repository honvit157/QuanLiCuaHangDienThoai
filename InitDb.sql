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
