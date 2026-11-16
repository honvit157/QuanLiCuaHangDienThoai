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

        /// <summary>Kiểm tra tên đăng nhập đã có nhân viên nào dùng chưa.</summary>
        public bool KiemTraTenDangNhapTonTai(string tenDangNhap)
        {
            return DatabaseAccess.DemBanGhi("sp_KiemTraTenDangNhapTonTai",
                new[] { DatabaseAccess.ThamSo("@TenDangNhap", tenDangNhap) }) > 0;
        }

        /// <summary>
        /// Đăng ký tài khoản mới hoàn toàn trong Stored Procedure
        /// (tự sinh MaNV, chức vụ theo @VaiTro là "Nhân viên" hoặc "Khách hàng",
        /// trạng thái "Đang làm việc"), trả về mã nhân viên do SQL sinh ra.
        /// </summary>
        public string DangKy(string hoTen, string sdt, string tenDangNhap, string matKhau, string vaiTro)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@TenNV", hoTen),
                DatabaseAccess.ThamSo("@SDT", sdt),
                DatabaseAccess.ThamSo("@TenDangNhap", tenDangNhap),
                DatabaseAccess.ThamSo("@MatKhau", matKhau),
                DatabaseAccess.ThamSo("@VaiTro", vaiTro)
            };

            DataTable dt = DatabaseAccess.DocBangProc("sp_DangKyNhanVien", pars);
            if (dt.Rows.Count == 0 || dt.Rows[0]["MaNV"] == DBNull.Value) return "";
            return dt.Rows[0]["MaNV"].ToString() ?? "";
        }
    }
}
