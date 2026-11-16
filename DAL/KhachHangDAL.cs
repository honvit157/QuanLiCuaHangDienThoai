using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng truy cập dữ liệu cho bảng tblKhachHang.
    /// </summary>
    public class KhachHangDAL
    {
        public DataTable LayTatCa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachKhachHang");
        }

        /// <summary>Thông tin chi tiết một khách hàng (dùng cho Form hóa đơn).</summary>
        public DataTable LayThongTin(string maKH)
        {
            return DatabaseAccess.DocBangProc("sp_LayThongTinKhachHang",
                new[] { DatabaseAccess.ThamSo("@MaKH", maKH) });
        }

        public DataTable LayDanhSachMa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachMaKhachHang");
        }

        public int Them(KhachHang kh)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@MaKH", kh.MaKH),
                DatabaseAccess.ThamSo("@TenKH", kh.HoTen),
                DatabaseAccess.ThamSo("@SDT", kh.SDT),
                DatabaseAccess.ThamSo("@DiaChi", kh.DiaChi),
                DatabaseAccess.ThamSo("@Email", string.IsNullOrWhiteSpace(kh.Email) ? null : kh.Email)
            };
            return DatabaseAccess.ThucThiProc("sp_ThemKhachHang", pars);
        }

        public int Sua(KhachHang kh)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@MaKH", kh.MaKH),
                DatabaseAccess.ThamSo("@TenKH", kh.HoTen),
                DatabaseAccess.ThamSo("@SDT", kh.SDT),
                DatabaseAccess.ThamSo("@DiaChi", kh.DiaChi),
                DatabaseAccess.ThamSo("@Email", string.IsNullOrWhiteSpace(kh.Email) ? null : kh.Email)
            };
            return DatabaseAccess.ThucThiProc("sp_CapNhatKhachHang", pars);
        }

        public int Xoa(string maKH)
        {
            return DatabaseAccess.ThucThiProc("sp_XoaKhachHang",
                new[] { DatabaseAccess.ThamSo("@MaKH", maKH) });
        }

        /// <summary>Danh sách mã hóa đơn đã phát sinh của khách hàng.</summary>
        public DataTable LayHoaDonCuaKhachHang(string maKH)
        {
            return DatabaseAccess.DocBangProc("sp_LayHoaDonCuaKhachHang",
                new[] { DatabaseAccess.ThamSo("@MaKH", maKH) });
        }

        public bool KiemTraTonTai(string maKH)
        {
            return DatabaseAccess.DemBanGhi("sp_KiemTraKhachHangTonTai",
                new[] { DatabaseAccess.ThamSo("@MaKH", maKH) }) > 0;
        }
    }
}
