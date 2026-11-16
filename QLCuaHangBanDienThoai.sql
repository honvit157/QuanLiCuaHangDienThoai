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
--  ---------------------------------------------------------------------------
--  BƯỚC 1/2: TẠO CƠ SỞ DỮ LIỆU, BẢNG VÀ DỮ LIỆU MẪU
--  Chạy tệp này trước, sau đó chạy StoredProcedures.sql.
--  (Hoặc chỉ chạy QLCuaHangBanDienThoai.sql - tệp gộp sẵn cả hai bước.)
--
--  Lưu ý: tệp sẽ XÓA cơ sở dữ liệu QLCuaHangBanDienThoai nếu đã tồn tại.
-- ============================================================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'QLCuaHangBanDienThoai')
BEGIN
    ALTER DATABASE QLCuaHangBanDienThoai SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLCuaHangBanDienThoai;
END
GO

CREATE DATABASE QLCuaHangBanDienThoai;
GO

USE QLCuaHangBanDienThoai;
GO

-- ============================================================================
--  A. TẠO CÁC BẢNG
-- ============================================================================

-- A.1 Danh mục hãng sản xuất
CREATE TABLE dbo.tblHangSX (
    MaHangSX   NVARCHAR(20)  NOT NULL,
    TenHangSX  NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_tblHangSX PRIMARY KEY (MaHangSX)
);
GO

-- A.2 Danh mục loại hàng
CREATE TABLE dbo.tblLoai (
    MaLoai   NVARCHAR(20)  NOT NULL,
    TenLoai  NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_tblLoai PRIMARY KEY (MaLoai)
);
GO

-- A.3 Danh mục màu sắc
CREATE TABLE dbo.tblMau (
    MaMau  NVARCHAR(20) NOT NULL,
    TenMau NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_tblMau PRIMARY KEY (MaMau)
);
GO

-- A.4 Danh mục dung lượng bộ nhớ
CREATE TABLE dbo.tblDungLuong (
    MaDungLuong  NVARCHAR(20) NOT NULL,
    TenDungLuong NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_tblDungLuong PRIMARY KEY (MaDungLuong)
);
GO

-- A.5 Nhà cung cấp
CREATE TABLE dbo.tblNhaCungCap (
    MaNCC   NVARCHAR(20)  NOT NULL,
    TenNCC  NVARCHAR(100) NOT NULL,
    SDT     NVARCHAR(20)  NULL,
    DiaChi  NVARCHAR(200) NULL,
    Email   NVARCHAR(255) NULL,
    NguoiLH NVARCHAR(100) NULL,
    CONSTRAINT PK_tblNhaCungCap PRIMARY KEY (MaNCC)
);
GO

-- A.6 Nhân viên
CREATE TABLE dbo.tblNhanVien (
    MaNV      NVARCHAR(20)  NOT NULL,
    TenNV     NVARCHAR(100) NOT NULL,
    GioiTinh  NVARCHAR(10)  NULL,
    NgaySinh  DATE          NULL,
    SDT       NVARCHAR(20)  NULL,
    DiaChi    NVARCHAR(200) NULL,
    ChucVu    NVARCHAR(50)  NULL,   -- 'Quản lý' hoặc 'Nhân viên'
    TaiKhoan  NVARCHAR(50)  NULL,
    MatKhau   NVARCHAR(100) NULL,
    TrangThai NVARCHAR(50)  NULL
        CONSTRAINT DF_tblNhanVien_TrangThai DEFAULT (N'Đang làm việc'),
    CONSTRAINT PK_tblNhanVien PRIMARY KEY (MaNV)
);
GO

-- A.7 Khách hàng
CREATE TABLE dbo.tblKhachHang (
    MaKH   NVARCHAR(20)  NOT NULL,
    TenKH  NVARCHAR(100) NOT NULL,
    SDT    NVARCHAR(20)  NULL,
    DiaChi NVARCHAR(200) NULL,
    Email  NVARCHAR(150) NULL,
    CONSTRAINT PK_tblKhachHang PRIMARY KEY (MaKH)
);
GO

-- A.8 Hàng hóa
CREATE TABLE dbo.tblHang (
    MaHang      NVARCHAR(20)   NOT NULL,
    TenHang     NVARCHAR(200)  NOT NULL,
    MaHangSX    NVARCHAR(20)   NULL,
    MaLoai      NVARCHAR(20)   NULL,
    MaMau       NVARCHAR(20)   NULL,
    MaDungLuong NVARCHAR(20)   NULL,
    DonGiaNhap  DECIMAL(18,2)  NOT NULL CONSTRAINT DF_tblHang_DonGiaNhap DEFAULT (0),
    DonGiaBan   DECIMAL(18,2)  NOT NULL CONSTRAINT DF_tblHang_DonGiaBan  DEFAULT (0),
    SoLuongTon  INT            NOT NULL CONSTRAINT DF_tblHang_SoLuongTon  DEFAULT (0),
    MoTa        NVARCHAR(500)  NULL,
    CONSTRAINT PK_tblHang PRIMARY KEY (MaHang),
    CONSTRAINT FK_tblHang_HangSX    FOREIGN KEY (MaHangSX)    REFERENCES dbo.tblHangSX (MaHangSX),
    CONSTRAINT FK_tblHang_Loai      FOREIGN KEY (MaLoai)      REFERENCES dbo.tblLoai (MaLoai),
    CONSTRAINT FK_tblHang_Mau       FOREIGN KEY (MaMau)       REFERENCES dbo.tblMau (MaMau),
    CONSTRAINT FK_tblHang_DungLuong FOREIGN KEY (MaDungLuong) REFERENCES dbo.tblDungLuong (MaDungLuong)
);
GO

-- A.9 Hóa đơn bán hàng
CREATE TABLE dbo.tblHoaDonBan (
    MaHDB    NVARCHAR(30)  NOT NULL,
    MaNV     NVARCHAR(20)  NOT NULL,
    MaKH     NVARCHAR(20)  NULL,
    NgayLap  DATETIME      NOT NULL CONSTRAINT DF_tblHoaDonBan_NgayLap DEFAULT (GETDATE()),
    TongTien DECIMAL(18,2) NOT NULL CONSTRAINT DF_tblHoaDonBan_TongTien DEFAULT (0),
    CONSTRAINT PK_tblHoaDonBan PRIMARY KEY (MaHDB),
    CONSTRAINT FK_tblHoaDonBan_NhanVien  FOREIGN KEY (MaNV) REFERENCES dbo.tblNhanVien (MaNV),
    CONSTRAINT FK_tblHoaDonBan_KhachHang FOREIGN KEY (MaKH) REFERENCES dbo.tblKhachHang (MaKH)
);
GO

-- A.10 Chi tiết hóa đơn bán hàng
CREATE TABLE dbo.tblChiTietHDB (
    MaHDB     NVARCHAR(30)  NOT NULL,
    MaHang    NVARCHAR(20)  NOT NULL,
    SoLuong   INT           NOT NULL,
    DonGia    DECIMAL(18,2) NOT NULL,
    GiamGia   DECIMAL(5,2)  NOT NULL CONSTRAINT DF_tblChiTietHDB_GiamGia DEFAULT (0),
    ThanhTien DECIMAL(18,2) NOT NULL,
    CONSTRAINT PK_tblChiTietHDB PRIMARY KEY (MaHDB, MaHang),
    CONSTRAINT FK_tblChiTietHDB_HoaDon FOREIGN KEY (MaHDB)  REFERENCES dbo.tblHoaDonBan (MaHDB),
    CONSTRAINT FK_tblChiTietHDB_Hang   FOREIGN KEY (MaHang) REFERENCES dbo.tblHang (MaHang),
    CONSTRAINT CK_tblChiTietHDB_SoLuong CHECK (SoLuong > 0),
    CONSTRAINT CK_tblChiTietHDB_GiamGia CHECK (GiamGia >= 0 AND GiamGia <= 100)
);
GO

-- A.11 Hóa đơn nhập hàng
CREATE TABLE dbo.tblHoaDonNhap (
    MaHDN    NVARCHAR(30)  NOT NULL,
    MaNV     NVARCHAR(20)  NOT NULL,
    MaNCC    NVARCHAR(20)  NOT NULL,
    NgayNhap DATETIME      NOT NULL CONSTRAINT DF_tblHoaDonNhap_NgayNhap DEFAULT (GETDATE()),
    TongTien DECIMAL(18,2) NOT NULL CONSTRAINT DF_tblHoaDonNhap_TongTien DEFAULT (0),
    CONSTRAINT PK_tblHoaDonNhap PRIMARY KEY (MaHDN),
    CONSTRAINT FK_tblHoaDonNhap_NhanVien   FOREIGN KEY (MaNV)  REFERENCES dbo.tblNhanVien (MaNV),
    CONSTRAINT FK_tblHoaDonNhap_NhaCungCap FOREIGN KEY (MaNCC) REFERENCES dbo.tblNhaCungCap (MaNCC)
);
GO

-- A.12 Chi tiết hóa đơn nhập hàng
CREATE TABLE dbo.tblChiTietHDN (
    MaHDN      NVARCHAR(30)  NOT NULL,
    MaHang     NVARCHAR(20)  NOT NULL,
    SoLuong    INT           NOT NULL,
    DonGiaNhap DECIMAL(18,2) NOT NULL,
    ThanhTien  DECIMAL(18,2) NOT NULL,
    CONSTRAINT PK_tblChiTietHDN PRIMARY KEY (MaHDN, MaHang),
    CONSTRAINT FK_tblChiTietHDN_HoaDon FOREIGN KEY (MaHDN)  REFERENCES dbo.tblHoaDonNhap (MaHDN),
    CONSTRAINT FK_tblChiTietHDN_Hang   FOREIGN KEY (MaHang) REFERENCES dbo.tblHang (MaHang),
    CONSTRAINT CK_tblChiTietHDN_SoLuong CHECK (SoLuong > 0)
);
GO

-- A.13 Chỉ mục hỗ trợ tìm kiếm và báo cáo
CREATE INDEX IX_tblHang_TenHang      ON dbo.tblHang (TenHang);
CREATE INDEX IX_tblHang_MaHangSX     ON dbo.tblHang (MaHangSX);
CREATE INDEX IX_tblHoaDonBan_NgayLap ON dbo.tblHoaDonBan (NgayLap);
CREATE INDEX IX_tblHoaDonBan_MaKH    ON dbo.tblHoaDonBan (MaKH);
CREATE INDEX IX_tblChiTietHDB_MaHang ON dbo.tblChiTietHDB (MaHang);
CREATE INDEX IX_tblHoaDonNhap_NgayNhap ON dbo.tblHoaDonNhap (NgayNhap);
GO

-- ============================================================================
--  B. DỮ LIỆU MẪU
-- ============================================================================

INSERT INTO dbo.tblHangSX (MaHangSX, TenHangSX) VALUES
('HSX001', N'Apple'),
('HSX002', N'Samsung'),
('HSX003', N'Xiaomi'),
('HSX004', N'OPPO'),
('HSX005', N'Vivo'),
('HSX006', N'Realme');
GO

INSERT INTO dbo.tblLoai (MaLoai, TenLoai) VALUES
('L001', N'Điện thoại cao cấp'),
('L002', N'Điện thoại tầm trung'),
('L003', N'Điện thoại phổ thông'),
('L004', N'Máy tính bảng');
GO

INSERT INTO dbo.tblMau (MaMau, TenMau) VALUES
('M001', N'Đen'),
('M002', N'Trắng'),
('M003', N'Xanh dương'),
('M004', N'Đỏ'),
('M005', N'Vàng'),
('M006', N'Hồng'),
('M007', N'Xám');
GO

INSERT INTO dbo.tblDungLuong (MaDungLuong, TenDungLuong) VALUES
('DL001', N'64GB'),
('DL002', N'128GB'),
('DL003', N'256GB'),
('DL004', N'512GB'),
('DL005', N'1TB');
GO

INSERT INTO dbo.tblNhaCungCap (MaNCC, TenNCC, SDT, DiaChi, Email, NguoiLH) VALUES
('NCC001', N'Công ty TNHH Phân phối Apple VN', '0901234567', N'12 Nguyễn Huệ, Quận 1, TP.HCM', N'applevn@gmail.com',  N'Trần Minh Tuấn'),
('NCC002', N'Samsung Electronics Việt Nam',   '0912345678', N'15 Lê Lợi, Quận 1, TP.HCM',     N'samsungvn@gmail.com', N'Nguyễn Thị Hồng'),
('NCC003', N'Xiaomi Việt Nam',                 '0923456789', N'20 Trần Hưng Đạo, Quận 5, TP.HCM', N'xiaomivn@gmail.com', N'Lê Hoàng Nam'),
('NCC004', N'OPPO Việt Nam',                   '0934567890', N'8 Đinh Tiên Hoàng, Quận 1, TP.HCM', N'oppovn@gmail.com',  N'Phạm Quốc Bảo'),
('NCC005', N'Vivo Việt Nam',                   '0945678901', N'25 Hai Bà Trưng, Quận 3, TP.HCM', N'vivovn@gmail.com',  N'Vũ Thanh Hùng');
GO

INSERT INTO dbo.tblNhanVien (MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, ChucVu, TaiKhoan, MatKhau, TrangThai) VALUES
('NV001', N'Nguyễn Văn An',    N'Nam', '2002-01-15', '0901111111', N'10 Lê Duẩn, Quận 1, TP.HCM',        N'Quản lý',   'an',     '123456', N'Đang làm việc'),
('NV002', N'Trần Thị Bình',    N'Nữ',  '2002-04-20', '0902222222', N'20 Điện Biên Phủ, Quận 3, TP.HCM', N'Nhân viên', 'binh',   '123456', N'Đang làm việc'),
('NV003', N'Lê Văn Cường',     N'Nam', '2001-08-12', '0903333333', N'30 Võ Văn Tần, Quận 3, TP.HCM',     N'Nhân viên', 'cuong',  '123456', N'Đang làm việc'),
('NV004', N'Phạm Thị Dung',    N'Nữ',  '2003-02-25', '0904444444', N'40 Nam Kỳ Khởi Nghĩa, Quận 1, TP.HCM', N'Nhân viên', 'dung', '123456', N'Đang làm việc'),
('NV005', N'Hoàng Văn Em',     N'Nam', '2002-06-18', '0905555555', N'50 Pasteur, Quận 1, TP.HCM',        N'Nhân viên', 'em',     '123456', N'Đang làm việc'),
('NV006', N'Đặng Thị Phương',  N'Nữ',  '2001-11-09', '0906666666', N'60 Nguyễn Đình Chiểu, Quận 3, TP.HCM', N'Nhân viên', 'phuong', '123456', N'Đang làm việc'),
('NV007', N'Bùi Văn Giang',    N'Nam', '2003-07-22', '0907777777', N'70 Lý Tự Trọng, Quận 1, TP.HCM',    N'Nhân viên', 'giang',  '123456', N'Đã nghỉ việc'),
('NV008', N'Ngô Thị Hoa',      N'Nữ',  '2002-03-30', '0908888888', N'80 Trần Phú, Quận 5, TP.HCM',       N'Quản lý',   'hoa',    '123456', N'Đang làm việc');
GO

INSERT INTO dbo.tblKhachHang (MaKH, TenKH, SDT, DiaChi, Email) VALUES
('KH001', N'Nguyễn Thị Mai',  '0911111111', N'5 Hoàng Diệu, Quận 4, TP.HCM',        N'mainguyen@gmail.com'),
('KH002', N'Trần Văn Nam',    '0922222222', N'15 Bến Vân Đồn, Quận 4, TP.HCM',      N'namtran@gmail.com'),
('KH003', N'Lê Thị Oanh',     '0933333333', N'25 Khánh Hội, Quận 4, TP.HCM',        N'oanhle@gmail.com'),
('KH004', N'Phạm Văn Phúc',   '0944444444', N'35 Tôn Đức Thắng, Quận 1, TP.HCM',    N'phucpham@gmail.com'),
('KH005', N'Hoàng Thị Quỳnh', '0955555555', N'45 Hai Bà Trưng, Quận 1, TP.HCM',     N'quynhhoang@gmail.com'),
('KH006', N'Đặng Văn Long',   '0966666666', N'55 Đinh Tiên Hoàng, Quận 1, TP.HCM',  N'longdang@gmail.com'),
('KH007', N'Bùi Thị Sen',     '0977777777', N'65 Trần Quang Khải, Quận 1, TP.HCM',  N'senbui@gmail.com'),
('KH008', N'Ngô Văn Tùng',    '0988888888', N'75 Lê Thánh Tôn, Quận 1, TP.HCM',     N'tungngo@gmail.com'),
('KH009', N'Vũ Thị Uyên',     '0999999999', N'85 Ngô Đức Kế, Quận 1, TP.HCM',       N'uyenvu@gmail.com'),
('KH010', N'Dương Văn Việt',  '0910000000', N'95 Mạc Thị Bưởi, Quận 1, TP.HCM',     N'vietduong@gmail.com');
GO

INSERT INTO dbo.tblHang (MaHang, TenHang, MaHangSX, MaLoai, MaMau, MaDungLuong, DonGiaNhap, DonGiaBan, SoLuongTon, MoTa) VALUES
('SP001', N'iPhone 15 Pro Max 256GB', 'HSX001', 'L001', 'M001', 'DL003', 25000000, 32000000, 15, N'Chip A17 Pro, camera 48MP'),
('SP002', N'iPhone 15 128GB',        'HSX001', 'L001', 'M002', 'DL002', 18000000, 24000000, 20, N'Chip A16, Dynamic Island'),
('SP003', N'Samsung Galaxy S24 Ultra','HSX002','L001', 'M001', 'DL003', 22000000, 28000000, 12, N'Snapdragon 8 Gen 3, bút S Pen'),
('SP004', N'Samsung Galaxy A55',     'HSX002', 'L002', 'M003', 'DL002',  7000000,  9500000, 30, N'Exynos 1480, chống nước IP67'),
('SP005', N'Xiaomi 14 Pro',          'HSX003', 'L001', 'M007', 'DL003', 16000000, 21000000, 10, N'Snapdragon 8 Gen 3, camera Leica'),
('SP006', N'Xiaomi Redmi Note 13',   'HSX003', 'L002', 'M003', 'DL002',  3500000,  5000000, 45, N'Helio G99, camera 108MP'),
('SP007', N'OPPO Find X7',           'HSX004', 'L001', 'M001', 'DL003', 17000000, 22000000,  8, N'Camera Hasselblad, Dimensity 9300'),
('SP008', N'OPPO A98',               'HSX004', 'L002', 'M002', 'DL002',  5000000,  7000000, 35, N'Snapdragon 695, sạc 67W'),
('SP009', N'Vivo X100 Pro',          'HSX005', 'L001', 'M001', 'DL003', 18000000, 23000000,  7, N'Dimensity 9300, camera ZEISS'),
('SP010', N'Vivo Y36',               'HSX005', 'L003', 'M004', 'DL001',  3000000,  4200000, 50, N'Snapdragon 680, camera 50MP'),
('SP011', N'Realme GT 5',            'HSX006', 'L001', 'M006', 'DL003', 12000000, 16000000, 15, N'Snapdragon 8 Gen 2, sạc 240W'),
('SP012', N'Realme C55',             'HSX006', 'L003', 'M002', 'DL002',  2500000,  3800000, 60, N'Helio G88, camera 64MP'),
('SP013', N'iPhone 14 Pro 128GB',    'HSX001', 'L001', 'M005', 'DL002', 20000000, 26000000,  8, N'Chip A16, màn hình Always-On'),
('SP014', N'Samsung Galaxy Z Fold 5','HSX002', 'L001', 'M001', 'DL004', 30000000, 40000000,  5, N'Màn hình gập, Snapdragon 8 Gen 2'),
('SP015', N'Xiaomi Poco X6 Pro',     'HSX003', 'L002', 'M007', 'DL002',  6000000,  8500000, 25, N'Dimensity 8300, màn hình 144Hz'),
('SP016', N'OPPO Reno 11',           'HSX004', 'L002', 'M006', 'DL002',  7500000, 10000000, 20, N'Dimensity 7050, sạc 80W'),
('SP017', N'Vivo V29e',              'HSX005', 'L002', 'M003', 'DL002',  5500000,  7500000, 30, N'Snapdragon 695, selfie 50MP'),
('SP018', N'Realme 12 Pro+',         'HSX006', 'L002', 'M002', 'DL002',  7000000,  9500000, 20, N'Snapdragon 7s Gen 2, camera tele'),
('SP019', N'iPhone SE 2022',         'HSX001', 'L002', 'M002', 'DL002', 10000000, 14000000, 12, N'Chip A15, thiết kế cổ điển'),
('SP020', N'Samsung Galaxy M34',     'HSX002', 'L003', 'M004', 'DL002',  4000000,  5800000, 40, N'Exynos 1280, pin 6000mAh'),
('SP021', N'Xiaomi Redmi 12C',       'HSX003', 'L003', 'M003', 'DL001',  1800000,  2800000, 70, N'Helio G85, pin 5000mAh'),
('SP022', N'OPPO A58',               'HSX004', 'L003', 'M002', 'DL001',  2800000,  4000000, 55, N'Helio G85, camera 50MP'),
('SP023', N'Vivo Y17s',              'HSX005', 'L003', 'M005', 'DL001',  2200000,  3200000, 65, N'Helio G85, pin 5000mAh'),
('SP024', N'Realme C30',             'HSX006', 'L003', 'M001', 'DL001',  1500000,  2400000, 80, N'UNISOC T612, thiết kế mỏng'),
('SP025', N'iPhone 15 Pro 256GB',    'HSX001', 'L001', 'M007', 'DL003', 23000000, 30000000, 10, N'Khung titan, USB-C, chip A17 Pro'),
('SP026', N'Samsung Galaxy S23 FE',  'HSX002', 'L001', 'M006', 'DL002',  9000000, 12500000, 18, N'Exynos 2200, camera 50MP'),
('SP027', N'Xiaomi 13T Pro',         'HSX003', 'L001', 'M001', 'DL003', 14000000, 19000000, 12, N'Dimensity 9200+, tinh chỉnh Leica'),
('SP028', N'OPPO Find N3 Flip',      'HSX004', 'L001', 'M001', 'DL003', 18000000, 24000000,  6, N'Dimensity 9200, gập vỏ sò'),
('SP029', N'Vivo X90 Pro',           'HSX005', 'L001', 'M001', 'DL003', 16000000, 21000000,  9, N'Dimensity 9200, camera ZEISS'),
('SP030', N'Realme GT Neo 5',        'HSX006', 'L001', 'M007', 'DL003', 10000000, 14000000, 14, N'Snapdragon 8+ Gen 1, sạc 150W'),
('SP031', N'iPhone 12 64GB',         'HSX001', 'L002', 'M002', 'DL001',  9000000, 12000000,  5, N'Chip A14, 5G, màn hình OLED'),
('SP032', N'Samsung Galaxy A14',     'HSX002', 'L003', 'M003', 'DL001',  2500000,  3600000, 50, N'Exynos 850, camera 50MP'),
('SP033', N'Xiaomi Poco M6 Pro',     'HSX003', 'L002', 'M004', 'DL002',  4500000,  6500000, 30, N'Helio G99 Ultra, camera 64MP');
GO

INSERT INTO dbo.tblHoaDonBan (MaHDB, MaNV, MaKH, NgayLap, TongTien) VALUES
('HDB001', 'NV001', 'KH001', '2026-10-01',  32000000),
('HDB002', 'NV002', 'KH002', '2026-10-05',   9500000),
('HDB003', 'NV001', 'KH003', '2026-10-10',  24000000),
('HDB004', 'NV003', 'KH004', '2026-10-15',   5000000),
('HDB005', 'NV002', 'KH005', '2026-10-20',  28000000),
('HDB006', 'NV001', 'KH006', '2026-10-25',  19420000),
('HDB007', 'NV003', 'KH007', '2026-10-30',  10990000);
GO

INSERT INTO dbo.tblChiTietHDB (MaHDB, MaHang, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
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

INSERT INTO dbo.tblHoaDonNhap (MaHDN, MaNV, MaNCC, NgayNhap, TongTien) VALUES
('HDN001', 'NV001', 'NCC001', '2026-09-01', 375000000),
('HDN002', 'NV001', 'NCC002', '2026-09-05', 261000000),
('HDN003', 'NV001', 'NCC003', '2026-09-10', 217500000);
GO

INSERT INTO dbo.tblChiTietHDN (MaHDN, MaHang, SoLuong, DonGiaNhap, ThanhTien) VALUES
('HDN001', 'SP001', 15, 25000000, 375000000),
('HDN002', 'SP003',  9, 22000000, 198000000),
('HDN002', 'SP004',  9,  7000000,  63000000),
('HDN003', 'SP005',  5, 16000000,  80000000),
('HDN003', 'SP006', 15,  3500000,  52500000),
('HDN003', 'SP007',  5, 17000000,  85000000);
GO

PRINT N'Đã tạo cơ sở dữ liệu QLCuaHangBanDienThoai và dữ liệu mẫu.';
PRINT N'Bước tiếp theo: chạy tệp StoredProcedures.sql để tạo các thủ tục lưu trữ.';
GO

-- ============================================================================
--  C. DỮ LIỆU THỬ NGHIỆM CHO DASHBOARD (7 NGÀY GẦN NHẤT)
--  Bảy hóa đơn TEST001..TEST007 được lập lùi dần về quá khứ để biểu đồ
--  "DOANH THU 7 NGÀY GẦN NHẤT" trên Form10 luôn có cột dữ liệu.
-- ============================================================================

DECLARE @MaNVTest VARCHAR(20);
DECLARE @MaKHTest VARCHAR(20);
DECLARE @i INT = 0;

SELECT TOP 1 @MaNVTest = MaNV FROM dbo.tblNhanVien ORDER BY MaNV;
SELECT TOP 1 @MaKHTest = MaKH FROM dbo.tblKhachHang ORDER BY MaKH;

IF @MaNVTest IS NULL OR @MaKHTest IS NULL
BEGIN
    PRINT N'Không tìm thấy nhân viên hoặc khách hàng để tạo dữ liệu thử nghiệm.';
    RETURN;
END

DECLARE @DoanhThu TABLE
(
    Ngay     INT,
    TongTien DECIMAL(18,2)
);

INSERT INTO @DoanhThu (Ngay, TongTien) VALUES
(0, 2500000),
(1, 4200000),
(2, 1800000),
(3, 6500000),
(4, 3200000),
(5, 7800000),
(6, 5500000);

WHILE @i <= 6
BEGIN
    INSERT INTO dbo.tblHoaDonBan (MaHDB, MaNV, MaKH, NgayLap, TongTien)
    VALUES
    (
        'TEST' + RIGHT('000' + CAST(@i + 1 AS VARCHAR(3)), 3),
        @MaNVTest,
        @MaKHTest,
        DATEADD(DAY, -@i, GETDATE()),
        (SELECT TongTien FROM @DoanhThu WHERE Ngay = @i)
    );

    SET @i = @i + 1;
END;
GO

PRINT N'Đã tạo cơ sở dữ liệu QLCuaHangBanDienThoai, bảng, dữ liệu mẫu và dữ liệu Dashboard.';
PRINT N'Bước tiếp theo: chạy tệp StoredProcedures.sql để tạo các thủ tục lưu trữ.';
GO

-- ============================================================================
--  PHẦN THỦ TỤC LƯU TRỮ (từ StoredProcedures.sql)
-- ============================================================================

-- ============================================================================
--  HỆ THỐNG QUẢN LÝ CỬA HÀNG ĐIỆN THOẠI
--  Học phần: Lập trình trực quan (C# WinForms) - Bài tập lớn
--  Giảng viên hướng dẫn: TS. Cao Thị Luyến
--  ---------------------------------------------------------------------------
--  TẬP THỦ TỤC LƯU TRỮ (STORED PROCEDURES)
--  Chạy sau khi đã chạy InitDb.sql (hoặc QLCuaHangBanDienThoai.sql).
--  Toàn bộ truy vấn của ứng dụng C# đều gọi các thủ tục trong tệp này thông qua
--  tầng DAL với CommandType.StoredProcedure, không có câu SQL viết trực tiếp.
-- ============================================================================


-- ============================================================================
--  PHẦN 1. HÀNG HÓA (tblHang)
-- ============================================================================

-- 1.1 Lấy toàn bộ danh sách hàng kèm tên hãng, loại, màu, dung lượng
CREATE OR ALTER PROCEDURE sp_LayDanhSachHang
AS
BEGIN
    SET NOCOUNT ON;

    SELECT h.MaHang,
           h.TenHang,
           ISNULL(hsx.TenHangSX, N'')   AS Hang,
           ISNULL(l.TenLoai, N'')       AS Loai,
           ISNULL(m.TenMau, N'')        AS Mau,
           ISNULL(dl.TenDungLuong, N'') AS DungLuong,
           h.DonGiaNhap                 AS GiaNhap,
           h.DonGiaBan                  AS GiaBan,
           h.SoLuongTon                 AS SoLuong,
           h.MaHangSX,
           h.MaLoai,
           h.MaMau,
           h.MaDungLuong,
           ISNULL(h.MoTa, N'')          AS MoTa
    FROM dbo.tblHang AS h
    LEFT JOIN dbo.tblHangSX    AS hsx ON h.MaHangSX    = hsx.MaHangSX
    LEFT JOIN dbo.tblLoai      AS l   ON h.MaLoai      = l.MaLoai
    LEFT JOIN dbo.tblMau       AS m   ON h.MaMau       = m.MaMau
    LEFT JOIN dbo.tblDungLuong AS dl  ON h.MaDungLuong = dl.MaDungLuong
    ORDER BY h.MaHang;
END;
GO

-- 1.2 Lấy thông tin một mặt hàng theo mã
CREATE OR ALTER PROCEDURE sp_LayHangTheoMa
    @MaHang NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT h.MaHang, h.TenHang,
           h.DonGiaNhap, h.DonGiaBan, h.SoLuongTon,
           ISNULL(hsx.TenHangSX, N'')   AS Hang,
           ISNULL(l.TenLoai, N'')       AS Loai,
           ISNULL(m.TenMau, N'')        AS Mau,
           ISNULL(dl.TenDungLuong, N'') AS DungLuong,
           ISNULL(h.MoTa, N'')          AS MoTa
    FROM dbo.tblHang AS h
    LEFT JOIN dbo.tblHangSX    AS hsx ON h.MaHangSX    = hsx.MaHangSX
    LEFT JOIN dbo.tblLoai      AS l   ON h.MaLoai      = l.MaLoai
    LEFT JOIN dbo.tblMau       AS m   ON h.MaMau       = m.MaMau
    LEFT JOIN dbo.tblDungLuong AS dl  ON h.MaDungLuong = dl.MaDungLuong
    WHERE h.MaHang = @MaHang;
END;
GO

-- 1.3 Danh sách mã hàng (nạp ComboBox ở Form hóa đơn)
CREATE OR ALTER PROCEDURE sp_LayDanhSachMaHang
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaHang FROM dbo.tblHang ORDER BY MaHang;
END;
GO

-- 1.4 Thêm mặt hàng mới
CREATE OR ALTER PROCEDURE sp_ThemHang
    @MaHang      NVARCHAR(20),
    @TenHang     NVARCHAR(200),
    @MaHangSX    NVARCHAR(20)  = NULL,
    @MaLoai      NVARCHAR(20)  = NULL,
    @MaMau       NVARCHAR(20)  = NULL,
    @MaDungLuong NVARCHAR(20)  = NULL,
    @DonGiaNhap  DECIMAL(18,2) = 0,
    @DonGiaBan   DECIMAL(18,2) = 0,
    @SoLuongTon  INT           = 0,
    @MoTa        NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblHang
        (MaHang, TenHang, MaHangSX, MaLoai, MaMau, MaDungLuong,
         DonGiaNhap, DonGiaBan, SoLuongTon, MoTa)
    VALUES
        (@MaHang, @TenHang, @MaHangSX, @MaLoai, @MaMau, @MaDungLuong,
         @DonGiaNhap, @DonGiaBan, @SoLuongTon, @MoTa);
END;
GO

-- 1.5 Cập nhật mặt hàng
CREATE OR ALTER PROCEDURE sp_CapNhatHang
    @MaHang      NVARCHAR(20),
    @TenHang     NVARCHAR(200),
    @MaHangSX    NVARCHAR(20)  = NULL,
    @MaLoai      NVARCHAR(20)  = NULL,
    @MaMau       NVARCHAR(20)  = NULL,
    @MaDungLuong NVARCHAR(20)  = NULL,
    @DonGiaNhap  DECIMAL(18,2) = 0,
    @DonGiaBan   DECIMAL(18,2) = 0,
    @SoLuongTon  INT           = 0,
    @MoTa        NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.tblHang
    SET TenHang     = @TenHang,
        MaHangSX    = @MaHangSX,
        MaLoai      = @MaLoai,
        MaMau       = @MaMau,
        MaDungLuong = @MaDungLuong,
        DonGiaNhap  = @DonGiaNhap,
        DonGiaBan   = @DonGiaBan,
        SoLuongTon  = @SoLuongTon,
        MoTa        = @MoTa
    WHERE MaHang = @MaHang;
END;
GO

-- 1.6 Xóa mặt hàng
CREATE OR ALTER PROCEDURE sp_XoaHang
    @MaHang NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.tblHang WHERE MaHang = @MaHang;
END;
GO

-- 1.7 Kiểm tra mã hàng đã tồn tại
CREATE OR ALTER PROCEDURE sp_KiemTraHangTonTai
    @MaHang NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS SoLuong FROM dbo.tblHang WHERE MaHang = @MaHang;
END;
GO

-- 1.8 Tìm kiếm hàng theo nhiều tiêu chí (tham số NULL = bỏ qua tiêu chí đó)
CREATE OR ALTER PROCEDURE sp_TimKiemHang
    @TenHang  NVARCHAR(200) = NULL,
    @MaHangSX NVARCHAR(20)  = NULL,
    @MaLoai   NVARCHAR(20)  = NULL,
    @MaMau    NVARCHAR(20)  = NULL,
    @GiaTu    DECIMAL(18,2) = NULL,
    @GiaDen   DECIMAL(18,2) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT h.MaHang, h.TenHang,
           ISNULL(sx.TenHangSX, N'')   AS Hang,
           ISNULL(l.TenLoai, N'')      AS Loai,
           ISNULL(m.TenMau, N'')       AS Mau,
           ISNULL(dl.TenDungLuong, N'') AS DungLuong,
           h.DonGiaBan, h.SoLuongTon
    FROM dbo.tblHang AS h
    LEFT JOIN dbo.tblHangSX    AS sx ON h.MaHangSX    = sx.MaHangSX
    LEFT JOIN dbo.tblLoai      AS l  ON h.MaLoai      = l.MaLoai
    LEFT JOIN dbo.tblMau       AS m  ON h.MaMau       = m.MaMau
    LEFT JOIN dbo.tblDungLuong AS dl ON h.MaDungLuong = dl.MaDungLuong
    WHERE (@TenHang  IS NULL OR h.TenHang LIKE N'%' + @TenHang + N'%')
      AND (@MaHangSX IS NULL OR @MaHangSX = N'' OR h.MaHangSX = @MaHangSX)
      AND (@MaLoai   IS NULL OR @MaLoai   = N'' OR h.MaLoai   = @MaLoai)
      AND (@MaMau    IS NULL OR @MaMau    = N'' OR h.MaMau    = @MaMau)
      AND (@GiaTu    IS NULL OR h.DonGiaBan >= @GiaTu)
      AND (@GiaDen   IS NULL OR h.DonGiaBan <= @GiaDen)
    ORDER BY h.MaHang;
END;
GO

-- ============================================================================
--  PHẦN 2. DANH MỤC: HÃNG SẢN XUẤT (tblHangSX)
-- ============================================================================

CREATE OR ALTER PROCEDURE sp_LayDanhSachHangSX
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaHangSX, TenHangSX FROM dbo.tblHangSX ORDER BY MaHangSX;
END;
GO

CREATE OR ALTER PROCEDURE sp_ThemHangSX
    @Ma  NVARCHAR(20),
    @Ten NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.tblHangSX (MaHangSX, TenHangSX) VALUES (@Ma, @Ten);
END;
GO

CREATE OR ALTER PROCEDURE sp_CapNhatHangSX
    @Ma  NVARCHAR(20),
    @Ten NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.tblHangSX SET TenHangSX = @Ten WHERE MaHangSX = @Ma;
END;
GO

CREATE OR ALTER PROCEDURE sp_XoaHangSX
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.tblHangSX WHERE MaHangSX = @Ma;
END;
GO

CREATE OR ALTER PROCEDURE sp_KiemTraHangSXTonTai
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS SoLuong FROM dbo.tblHangSX WHERE MaHangSX = @Ma;
END;
GO

-- ============================================================================
--  PHẦN 3. DANH MỤC: LOẠI HÀNG (tblLoai)
-- ============================================================================

CREATE OR ALTER PROCEDURE sp_LayDanhSachLoai
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaLoai, TenLoai FROM dbo.tblLoai ORDER BY MaLoai;
END;
GO

CREATE OR ALTER PROCEDURE sp_ThemLoai
    @Ma  NVARCHAR(20),
    @Ten NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.tblLoai (MaLoai, TenLoai) VALUES (@Ma, @Ten);
END;
GO

CREATE OR ALTER PROCEDURE sp_CapNhatLoai
    @Ma  NVARCHAR(20),
    @Ten NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.tblLoai SET TenLoai = @Ten WHERE MaLoai = @Ma;
END;
GO

CREATE OR ALTER PROCEDURE sp_XoaLoai
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.tblLoai WHERE MaLoai = @Ma;
END;
GO

CREATE OR ALTER PROCEDURE sp_KiemTraLoaiTonTai
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS SoLuong FROM dbo.tblLoai WHERE MaLoai = @Ma;
END;
GO

-- ============================================================================
--  PHẦN 4. DANH MỤC: MÀU SẮC (tblMau)
-- ============================================================================

CREATE OR ALTER PROCEDURE sp_LayDanhSachMau
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaMau, TenMau FROM dbo.tblMau ORDER BY MaMau;
END;
GO

CREATE OR ALTER PROCEDURE sp_ThemMau
    @Ma  NVARCHAR(20),
    @Ten NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.tblMau (MaMau, TenMau) VALUES (@Ma, @Ten);
END;
GO

CREATE OR ALTER PROCEDURE sp_CapNhatMau
    @Ma  NVARCHAR(20),
    @Ten NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.tblMau SET TenMau = @Ten WHERE MaMau = @Ma;
END;
GO

CREATE OR ALTER PROCEDURE sp_XoaMau
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.tblMau WHERE MaMau = @Ma;
END;
GO

CREATE OR ALTER PROCEDURE sp_KiemTraMauTonTai
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS SoLuong FROM dbo.tblMau WHERE MaMau = @Ma;
END;
GO

-- ============================================================================
--  PHẦN 5. DANH MỤC: DUNG LƯỢNG (tblDungLuong)
-- ============================================================================

CREATE OR ALTER PROCEDURE sp_LayDanhSachDungLuong
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaDungLuong, TenDungLuong FROM dbo.tblDungLuong ORDER BY MaDungLuong;
END;
GO

CREATE OR ALTER PROCEDURE sp_ThemDungLuong
    @Ma  NVARCHAR(20),
    @Ten NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.tblDungLuong (MaDungLuong, TenDungLuong) VALUES (@Ma, @Ten);
END;
GO

CREATE OR ALTER PROCEDURE sp_CapNhatDungLuong
    @Ma  NVARCHAR(20),
    @Ten NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.tblDungLuong SET TenDungLuong = @Ten WHERE MaDungLuong = @Ma;
END;
GO

CREATE OR ALTER PROCEDURE sp_XoaDungLuong
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.tblDungLuong WHERE MaDungLuong = @Ma;
END;
GO

CREATE OR ALTER PROCEDURE sp_KiemTraDungLuongTonTai
    @Ma NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS SoLuong FROM dbo.tblDungLuong WHERE MaDungLuong = @Ma;
END;
GO

-- ============================================================================
--  PHẦN 6. KHÁCH HÀNG (tblKhachHang)
-- ============================================================================

CREATE OR ALTER PROCEDURE sp_LayDanhSachKhachHang
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaKH, TenKH, SDT, DiaChi, ISNULL(Email, N'') AS Email
    FROM dbo.tblKhachHang
    ORDER BY MaKH;
END;
GO

CREATE OR ALTER PROCEDURE sp_LayDanhSachMaKhachHang
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaKH FROM dbo.tblKhachHang ORDER BY MaKH;
END;
GO

CREATE OR ALTER PROCEDURE sp_LayThongTinKhachHang
    @MaKH NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaKH, TenKH, SDT, DiaChi, ISNULL(Email, N'') AS Email
    FROM dbo.tblKhachHang
    WHERE MaKH = @MaKH;
END;
GO

CREATE OR ALTER PROCEDURE sp_ThemKhachHang
    @MaKH    NVARCHAR(20),
    @TenKH   NVARCHAR(100),
    @SDT     NVARCHAR(20)  = NULL,
    @DiaChi  NVARCHAR(200) = NULL,
    @Email   NVARCHAR(150) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblKhachHang (MaKH, TenKH, SDT, DiaChi, Email)
    VALUES (@MaKH, @TenKH, @SDT, @DiaChi, @Email);
END;
GO

CREATE OR ALTER PROCEDURE sp_CapNhatKhachHang
    @MaKH    NVARCHAR(20),
    @TenKH   NVARCHAR(100),
    @SDT     NVARCHAR(20)  = NULL,
    @DiaChi  NVARCHAR(200) = NULL,
    @Email   NVARCHAR(150) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.tblKhachHang
    SET TenKH  = @TenKH,
        SDT    = @SDT,
        DiaChi = @DiaChi,
        Email  = @Email
    WHERE MaKH = @MaKH;
END;
GO

CREATE OR ALTER PROCEDURE sp_XoaKhachHang
    @MaKH NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.tblKhachHang WHERE MaKH = @MaKH;
END;
GO

CREATE OR ALTER PROCEDURE sp_KiemTraKhachHangTonTai
    @MaKH NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS SoLuong FROM dbo.tblKhachHang WHERE MaKH = @MaKH;
END;
GO

-- 6.7 Danh sách hóa đơn đã phát sinh của một khách hàng (phục vụ kiểm tra trước khi xóa)
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

-- 6.8 Thêm khách hàng mới ngay trên hóa đơn bán:
--     - Nếu số điện thoại đã có trong tblKhachHang thì dùng lại mã khách hàng cũ.
--     - Nếu chưa có thì tự sinh mã kế tiếp (KH011, KH012, ...) rồi thêm mới.
--     Trả về MaKH và cờ LaKhachMoi (1 = vừa thêm mới, 0 = dùng lại khách cũ).
CREATE OR ALTER PROCEDURE sp_ThemKhachHangTuDong
    @TenKH  NVARCHAR(100),
    @SDT    NVARCHAR(20)  = NULL,
    @DiaChi NVARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @MaKH NVARCHAR(20);
    DECLARE @SoTiepTheo INT;
    DECLARE @LaKhachMoi INT = 0;
    DECLARE @SdtChuan NVARCHAR(20);

    SET @SdtChuan = NULLIF(LTRIM(RTRIM(@SDT)), N'');

    -- Số điện thoại đã có trong danh bạ khách hàng: dùng luôn khách hàng đó
    IF @SdtChuan IS NOT NULL
    BEGIN
        SELECT TOP (1) @MaKH = MaKH
        FROM dbo.tblKhachHang
        WHERE SDT = @SdtChuan
        ORDER BY MaKH;
    END

    IF @MaKH IS NULL
    BEGIN
        -- Lấy số lớn nhất trong các mã dạng KHxxx rồi cộng thêm 1
        SELECT @SoTiepTheo = ISNULL(MAX(TRY_CAST(SUBSTRING(MaKH, 3, 18) AS INT)), 0) + 1
        FROM dbo.tblKhachHang
        WHERE MaKH LIKE N'KH%'
          AND TRY_CAST(SUBSTRING(MaKH, 3, 18) AS INT) IS NOT NULL;

        IF @SoTiepTheo > 999
            SET @MaKH = N'KH' + CAST(@SoTiepTheo AS NVARCHAR(10));
        ELSE
            SET @MaKH = N'KH' + RIGHT(N'000' + CAST(@SoTiepTheo AS NVARCHAR(10)), 3);

        INSERT INTO dbo.tblKhachHang (MaKH, TenKH, SDT, DiaChi, Email)
        VALUES (@MaKH, LTRIM(RTRIM(@TenKH)), @SdtChuan,
                NULLIF(LTRIM(RTRIM(@DiaChi)), N''), NULL);

        SET @LaKhachMoi = 1;
    END

    SELECT @MaKH AS MaKH, @LaKhachMoi AS LaKhachMoi;
END;
GO

-- ============================================================================
--  PHẦN 7. NHÀ CUNG CẤP (tblNhaCungCap)
-- ============================================================================

CREATE OR ALTER PROCEDURE sp_LayDanhSachNhaCungCap
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaNCC, TenNCC, SDT, DiaChi,
           ISNULL(Email, N'')   AS Email,
           ISNULL(NguoiLH, N'') AS NguoiLH
    FROM dbo.tblNhaCungCap
    ORDER BY MaNCC;
END;
GO

CREATE OR ALTER PROCEDURE sp_LayDanhSachMaNhaCungCap
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

    SELECT MaNCC, TenNCC, SDT, DiaChi,
           ISNULL(Email, N'')   AS Email,
           ISNULL(NguoiLH, N'') AS NguoiLH
    FROM dbo.tblNhaCungCap
    WHERE MaNCC = @MaNCC;
END;
GO

CREATE OR ALTER PROCEDURE sp_ThemNhaCungCap
    @MaNCC   NVARCHAR(20),
    @TenNCC  NVARCHAR(100),
    @SDT     NVARCHAR(20)  = NULL,
    @DiaChi  NVARCHAR(200) = NULL,
    @Email   NVARCHAR(255) = NULL,
    @NguoiLH NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblNhaCungCap (MaNCC, TenNCC, SDT, DiaChi, Email, NguoiLH)
    VALUES (@MaNCC, @TenNCC, @SDT, @DiaChi, @Email, @NguoiLH);
END;
GO

CREATE OR ALTER PROCEDURE sp_CapNhatNhaCungCap
    @MaNCC   NVARCHAR(20),
    @TenNCC  NVARCHAR(100),
    @SDT     NVARCHAR(20)  = NULL,
    @DiaChi  NVARCHAR(200) = NULL,
    @Email   NVARCHAR(255) = NULL,
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
END;
GO

CREATE OR ALTER PROCEDURE sp_XoaNhaCungCap
    @MaNCC NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.tblNhaCungCap WHERE MaNCC = @MaNCC;
END;
GO

CREATE OR ALTER PROCEDURE sp_KiemTraNhaCungCapTonTai
    @MaNCC NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS SoLuong FROM dbo.tblNhaCungCap WHERE MaNCC = @MaNCC;
END;
GO

-- ============================================================================
--  PHẦN 8. NHÂN VIÊN (tblNhanVien)
-- ============================================================================

-- 8.1 Danh sách nhân viên (kèm tài khoản, chức vụ, trạng thái)
CREATE OR ALTER PROCEDURE sp_LayDanhSachNhanVien
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaNV, TenNV,
           ISNULL(GioiTinh, N'Nam') AS GioiTinh,
           NgaySinh, SDT, DiaChi,
           ISNULL(TaiKhoan, N'')    AS TenDangNhap,
           ISNULL(MatKhau, N'')     AS MatKhau,
           ISNULL(ChucVu, N'Nhân viên') AS ChucVu,
           ISNULL(TrangThai, N'Đang làm việc') AS TrangThai
    FROM dbo.tblNhanVien
    ORDER BY MaNV;
END;
GO

CREATE OR ALTER PROCEDURE sp_LayDanhSachMaNhanVien
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaNV FROM dbo.tblNhanVien ORDER BY MaNV;
END;
GO

CREATE OR ALTER PROCEDURE sp_LayNhanVienTheoMa
    @MaNV NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi,
           ISNULL(TaiKhoan, N'') AS TenDangNhap,
           ISNULL(ChucVu, N'Nhân viên') AS ChucVu,
           ISNULL(TrangThai, N'Đang làm việc') AS TrangThai
    FROM dbo.tblNhanVien
    WHERE MaNV = @MaNV;
END;
GO

CREATE OR ALTER PROCEDURE sp_LayTenNhanVien
    @MaNV NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TenNV FROM dbo.tblNhanVien WHERE MaNV = @MaNV;
END;
GO

-- 8.5 Kiểm tra đăng nhập: trả về thông tin nhân viên nếu tài khoản và mật khẩu đúng.
--     Cột VaiTro chỉ trả về một trong ba giá trị N'Quản lý', N'Nhân viên', N'Khách hàng'
--     (dữ liệu cũ bị trống hoặc ghi giá trị lạ được coi là N'Nhân viên').
CREATE OR ALTER PROCEDURE sp_KiemTraDangNhap
    @TaiKhoan NVARCHAR(50),
    @MatKhau  NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaNV, TenNV,
           CASE
               WHEN ChucVu = N'Khách hàng' THEN N'Khách hàng'
               WHEN ChucVu = N'Quản lý'    THEN N'Quản lý'
               ELSE N'Nhân viên'
           END AS VaiTro,
           ChucVu,
           TaiKhoan
    FROM dbo.tblNhanVien
    WHERE TaiKhoan = @TaiKhoan
      AND MatKhau  = @MatKhau;
END;
GO

CREATE OR ALTER PROCEDURE sp_ThemNhanVien
    @MaNV        NVARCHAR(20),
    @TenNV       NVARCHAR(100),
    @GioiTinh    NVARCHAR(10)  = NULL,
    @NgaySinh    DATE          = NULL,
    @SDT         NVARCHAR(20)  = NULL,
    @DiaChi      NVARCHAR(200) = NULL,
    @TenDangNhap NVARCHAR(50)  = NULL,
    @MatKhau     NVARCHAR(100) = NULL,
    @ChucVu      NVARCHAR(50)  = NULL,
    @TrangThai   NVARCHAR(50)  = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblNhanVien
        (MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, TaiKhoan, MatKhau, ChucVu, TrangThai)
    VALUES
        (@MaNV, @TenNV, @GioiTinh, @NgaySinh, @SDT, @DiaChi,
         @TenDangNhap, @MatKhau, @ChucVu, ISNULL(@TrangThai, N'Đang làm việc'));
END;
GO

CREATE OR ALTER PROCEDURE sp_CapNhatNhanVien
    @MaNV      NVARCHAR(20),
    @TenNV     NVARCHAR(100),
    @GioiTinh  NVARCHAR(10)  = NULL,
    @NgaySinh  DATE          = NULL,
    @SDT       NVARCHAR(20)  = NULL,
    @DiaChi    NVARCHAR(200) = NULL,
    @MatKhau   NVARCHAR(100) = NULL,
    @ChucVu    NVARCHAR(50)  = NULL,
    @TrangThai NVARCHAR(50)  = NULL
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
END;
GO

CREATE OR ALTER PROCEDURE sp_CapNhatTrangThaiNhanVien
    @MaNV      NVARCHAR(20),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.tblNhanVien SET TrangThai = @TrangThai WHERE MaNV = @MaNV;
END;
GO

CREATE OR ALTER PROCEDURE sp_XoaNhanVien
    @MaNV NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.tblNhanVien WHERE MaNV = @MaNV;
END;
GO

CREATE OR ALTER PROCEDURE sp_KiemTraNhanVienTonTai
    @MaNV NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS SoLuong FROM dbo.tblNhanVien WHERE MaNV = @MaNV;
END;
GO

-- 8.6 Kiểm tra tên đăng nhập đã có người dùng chưa (chức năng Đăng ký tài khoản)
CREATE OR ALTER PROCEDURE sp_KiemTraTenDangNhapTonTai
    @TenDangNhap NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(*) AS SoLuong
    FROM dbo.tblNhanVien
    WHERE TaiKhoan = @TenDangNhap;
END;
GO

-- 8.7 Đăng ký tài khoản: tự sinh MaNV kế tiếp (NV001, NV002, ...), nhận vai trò
--     N'Nhân viên' hoặc N'Khách hàng' qua tham số @VaiTro. Mọi giá trị khác (kể cả
--     N'Quản lý') đều bị ép về N'Nhân viên' để không ai tự nâng quyền khi đăng ký.
--     Đăng ký vai trò Khách hàng thì đồng thời thêm hồ sơ vào tblKhachHang nếu số
--     điện thoại chưa có, để khách mới hiện ngay trong danh sách khách hàng khi bán hàng.
CREATE OR ALTER PROCEDURE sp_DangKyNhanVien
    @TenNV       NVARCHAR(100),
    @SDT         NVARCHAR(20),
    @TenDangNhap NVARCHAR(50),
    @MatKhau     NVARCHAR(100),
    @VaiTro      NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @MaNVMoi NVARCHAR(20);
    DECLARE @SoTiepTheo INT;
    DECLARE @VaiTroChuan NVARCHAR(50);
    DECLARE @MaKHMoi NVARCHAR(20);
    DECLARE @SoKHTiepTheo INT;

    -- Chỉ có hai vai trò hợp lệ khi tự đăng ký
    SET @VaiTroChuan = CASE
        WHEN @VaiTro = N'Khách hàng' THEN N'Khách hàng'
        ELSE N'Nhân viên'
    END;

    -- Lấy số lớn nhất trong các mã dạng NVxxx rồi cộng thêm 1
    SELECT @SoTiepTheo = ISNULL(MAX(TRY_CAST(SUBSTRING(MaNV, 3, 18) AS INT)), 0) + 1
    FROM dbo.tblNhanVien
    WHERE MaNV LIKE N'NV%'
      AND TRY_CAST(SUBSTRING(MaNV, 3, 18) AS INT) IS NOT NULL;

    IF @SoTiepTheo > 999
        SET @MaNVMoi = N'NV' + CAST(@SoTiepTheo AS NVARCHAR(10));
    ELSE
        SET @MaNVMoi = N'NV' + RIGHT(N'000' + CAST(@SoTiepTheo AS NVARCHAR(10)), 3);

    INSERT INTO dbo.tblNhanVien
        (MaNV, TenNV, SDT, TaiKhoan, MatKhau, ChucVu, TrangThai)
    VALUES
        (@MaNVMoi, @TenNV, @SDT, @TenDangNhap, @MatKhau, @VaiTroChuan, N'Đang làm việc');

    -- Khách hàng tự đăng ký: bổ sung hồ sơ khách hàng theo số điện thoại (nếu chưa có)
    IF @VaiTroChuan = N'Khách hàng'
       AND NOT EXISTS (SELECT 1 FROM dbo.tblKhachHang WHERE SDT = @SDT)
    BEGIN
        SELECT @SoKHTiepTheo = ISNULL(MAX(TRY_CAST(SUBSTRING(MaKH, 3, 18) AS INT)), 0) + 1
        FROM dbo.tblKhachHang
        WHERE MaKH LIKE N'KH%'
          AND TRY_CAST(SUBSTRING(MaKH, 3, 18) AS INT) IS NOT NULL;

        IF @SoKHTiepTheo > 999
            SET @MaKHMoi = N'KH' + CAST(@SoKHTiepTheo AS NVARCHAR(10));
        ELSE
            SET @MaKHMoi = N'KH' + RIGHT(N'000' + CAST(@SoKHTiepTheo AS NVARCHAR(10)), 3);

        INSERT INTO dbo.tblKhachHang (MaKH, TenKH, SDT, DiaChi, Email)
        VALUES (@MaKHMoi, @TenNV, @SDT, NULL, NULL);
    END

    SELECT @MaNVMoi AS MaNV, @VaiTroChuan AS VaiTro;
END;
GO

-- ============================================================================
--  PHẦN 9. HÓA ĐƠN BÁN HÀNG (tblHoaDonBan, tblChiTietHDB)
-- ============================================================================

CREATE OR ALTER PROCEDURE sp_LayDanhSachMaHoaDonBan
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaHDB FROM dbo.tblHoaDonBan ORDER BY MaHDB DESC;
END;
GO

CREATE OR ALTER PROCEDURE sp_KiemTraHoaDonBanTonTai
    @MaHDB NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS SoLuong FROM dbo.tblHoaDonBan WHERE MaHDB = @MaHDB;
END;
GO

-- 9.3 Đầu hóa đơn kèm tên nhân viên và thông tin khách hàng
CREATE OR ALTER PROCEDURE sp_LayHoaDonBan
    @MaHDB NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT h.MaHDB, h.MaNV, n.TenNV,
           h.MaKH, k.TenKH, k.SDT, k.DiaChi,
           h.NgayLap, h.TongTien
    FROM dbo.tblHoaDonBan h
    INNER JOIN dbo.tblNhanVien  n ON h.MaNV = n.MaNV
    LEFT  JOIN dbo.tblKhachHang k ON h.MaKH = k.MaKH
    WHERE h.MaHDB = @MaHDB;
END;
GO

CREATE OR ALTER PROCEDURE sp_LayChiTietHoaDonBan
    @MaHDB NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ct.MaHang, h.TenHang, ct.DonGia,
           ct.SoLuong, ct.GiamGia, ct.ThanhTien
    FROM dbo.tblChiTietHDB ct
    INNER JOIN dbo.tblHang h ON ct.MaHang = h.MaHang
    WHERE ct.MaHDB = @MaHDB
    ORDER BY ct.MaHang;
END;
GO

-- 9.5 Trừ tồn kho có điều kiện: chỉ trừ khi đủ hàng, trả về số dòng đã cập nhật
CREATE OR ALTER PROCEDURE sp_TruTonKho
    @MaHang  NVARCHAR(20),
    @SoLuong INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.tblHang
    SET SoLuongTon = SoLuongTon - @SoLuong
    WHERE MaHang = @MaHang
      AND SoLuongTon >= @SoLuong;

    SELECT @@ROWCOUNT AS SoDong;
END;
GO

CREATE OR ALTER PROCEDURE sp_ThemHoaDonBan
    @MaHDB   NVARCHAR(30),
    @MaNV    NVARCHAR(20),
    @MaKH    NVARCHAR(20)  = NULL,
    @NgayLap DATETIME,
    @TongTien DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblHoaDonBan (MaHDB, MaNV, MaKH, NgayLap, TongTien)
    VALUES (@MaHDB, @MaNV, @MaKH, @NgayLap, @TongTien);
END;
GO

CREATE OR ALTER PROCEDURE sp_ThemChiTietHoaDonBan
    @MaHDB     NVARCHAR(30),
    @MaHang    NVARCHAR(20),
    @SoLuong   INT,
    @DonGia    DECIMAL(18,2),
    @GiamGia   DECIMAL(5,2),
    @ThanhTien DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblChiTietHDB (MaHDB, MaHang, SoLuong, DonGia, GiamGia, ThanhTien)
    VALUES (@MaHDB, @MaHang, @SoLuong, @DonGia, @GiamGia, @ThanhTien);
END;
GO

-- ============================================================================
--  PHẦN 10. HÓA ĐƠN NHẬP HÀNG (tblHoaDonNhap, tblChiTietHDN)
-- ============================================================================

CREATE OR ALTER PROCEDURE sp_LayDanhSachMaHoaDonNhap
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaHDN FROM dbo.tblHoaDonNhap ORDER BY MaHDN DESC;
END;
GO

CREATE OR ALTER PROCEDURE sp_KiemTraHoaDonNhapTonTai
    @MaHDN NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS SoLuong FROM dbo.tblHoaDonNhap WHERE MaHDN = @MaHDN;
END;
GO

CREATE OR ALTER PROCEDURE sp_LayHoaDonNhap
    @MaHDN NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT h.MaHDN, h.MaNV, n.TenNV, h.MaNCC,
           ncc.SDT, ncc.DiaChi, h.NgayNhap, h.TongTien
    FROM dbo.tblHoaDonNhap h
    INNER JOIN dbo.tblNhanVien   n   ON h.MaNV  = n.MaNV
    INNER JOIN dbo.tblNhaCungCap ncc ON h.MaNCC = ncc.MaNCC
    WHERE h.MaHDN = @MaHDN;
END;
GO

CREATE OR ALTER PROCEDURE sp_LayChiTietHoaDonNhap
    @MaHDN NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT c.MaHang, h.TenHang, c.DonGiaNhap, c.SoLuong, c.ThanhTien
    FROM dbo.tblChiTietHDN c
    INNER JOIN dbo.tblHang h ON c.MaHang = h.MaHang
    WHERE c.MaHDN = @MaHDN
    ORDER BY c.MaHang;
END;
GO

-- 10.5 Cộng tồn kho và cập nhật giá nhập mới nhất
CREATE OR ALTER PROCEDURE sp_CongTonKho
    @MaHang     NVARCHAR(20),
    @SoLuong    INT,
    @DonGiaNhap DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.tblHang
    SET SoLuongTon = SoLuongTon + @SoLuong,
        DonGiaNhap = @DonGiaNhap
    WHERE MaHang = @MaHang;

    SELECT @@ROWCOUNT AS SoDong;
END;
GO

CREATE OR ALTER PROCEDURE sp_ThemHoaDonNhap
    @MaHDN    NVARCHAR(30),
    @MaNV     NVARCHAR(20),
    @MaNCC    NVARCHAR(20),
    @NgayNhap DATETIME,
    @TongTien DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblHoaDonNhap (MaHDN, MaNV, MaNCC, NgayNhap, TongTien)
    VALUES (@MaHDN, @MaNV, @MaNCC, @NgayNhap, @TongTien);
END;
GO

CREATE OR ALTER PROCEDURE sp_ThemChiTietHoaDonNhap
    @MaHDN      NVARCHAR(30),
    @MaHang     NVARCHAR(20),
    @SoLuong    INT,
    @DonGiaNhap DECIMAL(18,2),
    @ThanhTien  DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblChiTietHDN (MaHDN, MaHang, SoLuong, DonGiaNhap, ThanhTien)
    VALUES (@MaHDN, @MaHang, @SoLuong, @DonGiaNhap, @ThanhTien);
END;
GO

-- ============================================================================
--  PHẦN 11. BÁO CÁO - THỐNG KÊ
-- ============================================================================

-- 11.1 Doanh thu và số hóa đơn theo từng tháng
CREATE OR ALTER PROCEDURE sp_BaoCaoDoanhThuTheoThang
AS
BEGIN
    SET NOCOUNT ON;

    SELECT YEAR(NgayLap)  AS Nam,
           MONTH(NgayLap) AS Thang,
           COUNT(*)       AS SoHoaDon,
           SUM(TongTien)  AS DoanhThu
    FROM dbo.tblHoaDonBan
    GROUP BY YEAR(NgayLap), MONTH(NgayLap)
    ORDER BY Nam DESC, Thang DESC;
END;
GO

-- 11.2 Tồn kho hiện tại và giá trị tồn của từng mặt hàng
CREATE OR ALTER PROCEDURE sp_BaoCaoTonKho
AS
BEGIN
    SET NOCOUNT ON;

    SELECT h.MaHang, h.TenHang,
           ISNULL(hs.TenHangSX, N'') AS Hang,
           ISNULL(l.TenLoai, N'')    AS Loai,
           h.DonGiaBan,
           h.SoLuongTon,
           (h.DonGiaBan * h.SoLuongTon) AS GiaTriTon
    FROM dbo.tblHang h
    LEFT JOIN dbo.tblHangSX hs ON h.MaHangSX = hs.MaHangSX
    LEFT JOIN dbo.tblLoai   l  ON h.MaLoai   = l.MaLoai
    ORDER BY h.SoLuongTon DESC, h.MaHang;
END;
GO

-- 11.3 Top sản phẩm bán chạy nhất
CREATE OR ALTER PROCEDURE sp_BaoCaoTopBanChay
    @SoDong INT = 10
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP (@SoDong)
           h.MaHang, h.TenHang,
           ISNULL(hs.TenHangSX, N'') AS Hang,
           SUM(ct.SoLuong)   AS SoLuongBan,
           SUM(ct.ThanhTien) AS DoanhThu
    FROM dbo.tblChiTietHDB ct
    INNER JOIN dbo.tblHang   h  ON ct.MaHang   = h.MaHang
    LEFT  JOIN dbo.tblHangSX hs ON h.MaHangSX = hs.MaHangSX
    GROUP BY h.MaHang, h.TenHang, hs.TenHangSX
    ORDER BY SoLuongBan DESC;
END;
GO

-- ============================================================================
--  PHẦN 12. THỐNG KÊ PHỤC VỤ DASHBOARD (Form10)
--  Các thủ tục dưới đây cung cấp số liệu cho bốn thẻ thống kê và biểu đồ
--  doanh thu 7 ngày gần nhất của màn hình Tổng quan.
-- ============================================================================

-- 12.1 Tổng số mặt hàng đang quản lý
CREATE OR ALTER PROCEDURE sp_ThongKe_TongSanPham
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS TongSanPham FROM dbo.tblHang;
END;
GO

-- 12.2 Tổng số khách hàng
CREATE OR ALTER PROCEDURE sp_ThongKe_TongKhachHang
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS TongKhachHang FROM dbo.tblKhachHang;
END;
GO

-- 12.3 Số hóa đơn bán lập trong ngày hôm nay
CREATE OR ALTER PROCEDURE sp_ThongKe_HoaDonHomNay
AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(*) AS SoHoaDon
    FROM dbo.tblHoaDonBan
    WHERE NgayLap >= CONVERT(date, GETDATE())
      AND NgayLap <  DATEADD(day, 1, CONVERT(date, GETDATE()));
END;
GO

-- 12.4 Doanh thu bán hàng của ngày hôm nay
CREATE OR ALTER PROCEDURE sp_ThongKe_DoanhThuHomNay
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ISNULL(SUM(TongTien), 0) AS DoanhThu
    FROM dbo.tblHoaDonBan
    WHERE NgayLap >= CONVERT(date, GETDATE())
      AND NgayLap <  DATEADD(day, 1, CONVERT(date, GETDATE()));
END;
GO

-- 12.5 Doanh thu 7 ngày gần nhất (kể cả ngày không phát sinh hóa đơn)
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
    SELECT n.Ngay,
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

-- 12.6 Top 5 mặt hàng bán chạy nhất (theo số lượng bán)
CREATE OR ALTER PROCEDURE sp_ThongKe_Top5SanPhamBanChay
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 5
           h.MaHang,
           h.TenHang,
           SUM(ct.SoLuong)   AS TongSoLuongBan,
           SUM(ct.ThanhTien) AS TongDoanhThu
    FROM dbo.tblChiTietHDB ct
    INNER JOIN dbo.tblHang h ON ct.MaHang = h.MaHang
    GROUP BY h.MaHang, h.TenHang
    ORDER BY SUM(ct.SoLuong) DESC, h.MaHang;
END;
GO

-- 12.7 Danh sách mặt hàng sắp hết hàng (tồn kho <= ngưỡng cảnh báo)
CREATE OR ALTER PROCEDURE sp_ThongKe_SanPhamSapHetHang
    @NguongTon INT = 10
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaHang,
           TenHang,
           SoLuongTon
    FROM dbo.tblHang
    WHERE SoLuongTon <= @NguongTon
    ORDER BY SoLuongTon ASC, MaHang;
END;
GO

-- 12.8 Tổng số lượng hàng đang nằm trong kho
CREATE OR ALTER PROCEDURE sp_ThongKe_TongHangTonKho
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(SUM(SoLuongTon), 0) AS TongTonKho FROM dbo.tblHang;
END;
GO

PRINT N'Đã tạo xong toàn bộ thủ tục lưu trữ cho cơ sở dữ liệu QLCuaHangBanDienThoai.';
GO
