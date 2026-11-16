using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng truy cập dữ liệu cho bảng tblHang.
    /// Mọi thao tác đều gọi thủ tục lưu trữ đã khai báo trong StoredProcedures.sql.
    /// </summary>
    public class HangHoaDAL
    {
        /// <summary>Lấy toàn bộ danh sách hàng kèm tên hãng, loại, màu, dung lượng.</summary>
        public DataTable LayTatCa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachHang");
        }

        /// <summary>Lấy thông tin một mặt hàng theo mã.</summary>
        public DataTable LayTheoMa(string maHang)
        {
            return DatabaseAccess.DocBangProc("sp_LayHangTheoMa",
                new[] { DatabaseAccess.ThamSo("@MaHang", maHang) });
        }

        /// <summary>Lấy danh sách mã hàng để nạp ComboBox.</summary>
        public DataTable LayDanhSachMa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachMaHang");
        }

        public int Them(HangHoa h)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@MaHang", h.MaHang),
                DatabaseAccess.ThamSo("@TenHang", h.TenHang),
                DatabaseAccess.ThamSo("@MaHangSX", h.MaHangSX),
                DatabaseAccess.ThamSo("@MaLoai", h.MaLoai),
                DatabaseAccess.ThamSo("@MaMau", h.MaMau),
                DatabaseAccess.ThamSo("@MaDungLuong", h.MaDungLuong),
                DatabaseAccess.ThamSo("@DonGiaNhap", h.GiaNhap),
                DatabaseAccess.ThamSo("@DonGiaBan", h.GiaBan),
                DatabaseAccess.ThamSo("@SoLuongTon", h.SoLuongTon),
                DatabaseAccess.ThamSo("@MoTa", h.MoTa),
                DatabaseAccess.ThamSo("@TenAnh", string.IsNullOrWhiteSpace(h.TenAnh) ? null : h.TenAnh)
            };
            return DatabaseAccess.ThucThiProc("sp_ThemHang", pars);
        }

        public int Sua(HangHoa h)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@MaHang", h.MaHang),
                DatabaseAccess.ThamSo("@TenHang", h.TenHang),
                DatabaseAccess.ThamSo("@MaHangSX", h.MaHangSX),
                DatabaseAccess.ThamSo("@MaLoai", h.MaLoai),
                DatabaseAccess.ThamSo("@MaMau", h.MaMau),
                DatabaseAccess.ThamSo("@MaDungLuong", h.MaDungLuong),
                DatabaseAccess.ThamSo("@DonGiaNhap", h.GiaNhap),
                DatabaseAccess.ThamSo("@DonGiaBan", h.GiaBan),
                DatabaseAccess.ThamSo("@SoLuongTon", h.SoLuongTon),
                DatabaseAccess.ThamSo("@MoTa", h.MoTa),
                DatabaseAccess.ThamSo("@TenAnh", string.IsNullOrWhiteSpace(h.TenAnh) ? null : h.TenAnh)
            };
            return DatabaseAccess.ThucThiProc("sp_CapNhatHang", pars);
        }

        public int Xoa(string maHang)
        {
            return DatabaseAccess.ThucThiProc("sp_XoaHang",
                new[] { DatabaseAccess.ThamSo("@MaHang", maHang) });
        }

        /// <summary>Tìm kiếm hàng theo nhiều tiêu chí (tham số null = bỏ qua tiêu chí đó).</summary>
        public DataTable TimKiem(string? ten, string? hang, string? loai, string? mau,
                                 decimal? giaTu, decimal? giaDen)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@TenHang", string.IsNullOrWhiteSpace(ten) ? null : ten),
                DatabaseAccess.ThamSo("@MaHangSX", string.IsNullOrWhiteSpace(hang) ? null : hang),
                DatabaseAccess.ThamSo("@MaLoai", string.IsNullOrWhiteSpace(loai) ? null : loai),
                DatabaseAccess.ThamSo("@MaMau", string.IsNullOrWhiteSpace(mau) ? null : mau),
                DatabaseAccess.ThamSo("@GiaTu", giaTu.HasValue ? giaTu.Value : (object?)null),
                DatabaseAccess.ThamSo("@GiaDen", giaDen.HasValue ? giaDen.Value : (object?)null)
            };
            return DatabaseAccess.DocBangProc("sp_TimKiemHang", pars);
        }

        public bool KiemTraTonTai(string maHang)
        {
            return DatabaseAccess.DemBanGhi("sp_KiemTraHangTonTai",
                new[] { DatabaseAccess.ThamSo("@MaHang", maHang) }) > 0;
        }
    }
}
