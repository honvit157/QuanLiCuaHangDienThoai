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

USE QLCuaHangBanDienThoai;
GO

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

-- 8.5 Kiểm tra đăng nhập: trả về thông tin nhân viên nếu tài khoản và mật khẩu đúng
CREATE OR ALTER PROCEDURE sp_KiemTraDangNhap
    @TaiKhoan NVARCHAR(50),
    @MatKhau  NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaNV, TenNV,
           ISNULL(ChucVu, N'Nhân viên') AS VaiTro,
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
