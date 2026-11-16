using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng truy cập dữ liệu cho bảng nhân viên (tblNhanVien).
    /// </summary>
    public class NhanVienDAL
    {
        /// <summary>Kiểm tra tài khoản - mật khẩu đăng nhập.</summary>
        public DataTable KiemTraDangNhap(string tk, string mk)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@TaiKhoan", tk),
                DatabaseAccess.ThamSo("@MatKhau", mk)
            };

            return DatabaseAccess.DocBangProc("sp_KiemTraDangNhap", pars);
        }

        /// <summary>Danh sách toàn bộ nhân viên.</summary>
        public DataTable LayTatCa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachNhanVien");
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
                DatabaseAccess.ThamSo("@TaiKhoan", nv.TenDangNhap),
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
                new[] { DatabaseAccess.ThamSo("@Ma", maNV) }) > 0;
        }

        /// <summary>Danh sách mã nhân viên cho AutoComplete khi lập hóa đơn.</summary>
        public DataTable LayDanhSachMa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachMaNV");
        }

        /// <summary>Tên nhân viên theo mã.</summary>
        public DataTable LayTen(string maNV)
        {
            return DatabaseAccess.DocBangProc("sp_LayTenNhanVien",
                new[] { DatabaseAccess.ThamSo("@MaNV", maNV) });
        }
    }
}
