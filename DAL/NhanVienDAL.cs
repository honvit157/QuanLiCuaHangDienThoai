using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng truy cập dữ liệu cho bảng tblNhanVien.
    /// </summary>
    public class NhanVienDAL
    {
        /// <summary>Kiểm tra tài khoản/mật khẩu, trả về thông tin nhân viên nếu đúng.</summary>
        public DataTable KiemTraDangNhap(string taiKhoan, string matKhau)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@TaiKhoan", taiKhoan),
                DatabaseAccess.ThamSo("@MatKhau", matKhau)
            };
            return DatabaseAccess.DocBangProc("sp_KiemTraDangNhap", pars);
        }

        public DataTable LayTatCa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachNhanVien");
        }

        public DataTable LayTheoMa(string maNV)
        {
            return DatabaseAccess.DocBangProc("sp_LayNhanVienTheoMa",
                new[] { DatabaseAccess.ThamSo("@MaNV", maNV) });
        }

        public DataTable LayDanhSachMa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachMaNhanVien");
        }

        /// <summary>Lấy họ tên nhân viên theo mã (dùng cho Form hóa đơn).</summary>
        public string LayTen(string maNV)
        {
            DataTable dt = DatabaseAccess.DocBangProc("sp_LayTenNhanVien",
                new[] { DatabaseAccess.ThamSo("@MaNV", maNV) });
            if (dt.Rows.Count == 0 || dt.Rows[0]["TenNV"] == DBNull.Value) return "";
            return dt.Rows[0]["TenNV"].ToString() ?? "";
        }

        public int Them(NhanVien nv)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@MaNV", nv.MaNV),
                DatabaseAccess.ThamSo("@TenNV", nv.HoTen),
                DatabaseAccess.ThamSo("@GioiTinh", nv.GioiTinh),
                DatabaseAccess.ThamSo("@NgaySinh", nv.NgaySinh.Date),
                DatabaseAccess.ThamSo("@SDT", nv.SDT),
                DatabaseAccess.ThamSo("@DiaChi", nv.DiaChi),
                DatabaseAccess.ThamSo("@TenDangNhap", nv.TenDangNhap),
                DatabaseAccess.ThamSo("@MatKhau", nv.MatKhau),
                DatabaseAccess.ThamSo("@ChucVu", nv.VaiTro),
                DatabaseAccess.ThamSo("@TrangThai", nv.TrangThai)
            };
            return DatabaseAccess.ThucThiProc("sp_ThemNhanVien", pars);
        }

        public int Sua(NhanVien nv)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@MaNV", nv.MaNV),
                DatabaseAccess.ThamSo("@TenNV", nv.HoTen),
                DatabaseAccess.ThamSo("@GioiTinh", nv.GioiTinh),
                DatabaseAccess.ThamSo("@NgaySinh", nv.NgaySinh.Date),
                DatabaseAccess.ThamSo("@SDT", nv.SDT),
                DatabaseAccess.ThamSo("@DiaChi", nv.DiaChi),
                DatabaseAccess.ThamSo("@MatKhau", nv.MatKhau),
                DatabaseAccess.ThamSo("@ChucVu", nv.VaiTro),
                DatabaseAccess.ThamSo("@TrangThai", nv.TrangThai)
            };
            return DatabaseAccess.ThucThiProc("sp_CapNhatNhanVien", pars);
        }

        public int CapNhatTrangThai(string maNV, string trangThai)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@MaNV", maNV),
                DatabaseAccess.ThamSo("@TrangThai", trangThai)
            };
            return DatabaseAccess.ThucThiProc("sp_CapNhatTrangThaiNhanVien", pars);
        }

        public int Xoa(string maNV)
        {
            return DatabaseAccess.ThucThiProc("sp_XoaNhanVien",
                new[] { DatabaseAccess.ThamSo("@MaNV", maNV) });
        }

        public bool KiemTraTonTai(string maNV)
        {
            return DatabaseAccess.DemBanGhi("sp_KiemTraNhanVienTonTai",
                new[] { DatabaseAccess.ThamSo("@MaNV", maNV) }) > 0;
        }
    }
}
