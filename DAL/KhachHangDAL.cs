using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng truy cập dữ liệu cho bảng khách hàng (tblKhachHang),
    /// bao gồm đăng ký và đăng nhập tài khoản khách hàng.
    /// </summary>
    public class KhachHangDAL
    {
        /// <summary>Lấy danh sách khách hàng.</summary>
        public DataTable LayTatCa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachKhachHang");
        }

        /// <summary>Thêm khách hàng bằng chức năng quản lý.</summary>
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

        /// <summary>Sửa thông tin khách hàng.</summary>
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

        /// <summary>Kiểm tra mã khách hàng đã tồn tại.</summary>
        public bool KiemTraTonTai(string maKH)
        {
            return DatabaseAccess.DemBanGhi("sp_KiemTraKhachHangTonTai",
                new[] { DatabaseAccess.ThamSo("@Ma", maKH) }) > 0;
        }

        /// <summary>Kiểm tra tên tài khoản đã được dùng.</summary>
        public bool KiemTraTaiKhoan(string taiKhoan)
        {
            return DatabaseAccess.DemBanGhi("sp_KiemTraTaiKhoanKhachHang",
                new[] { DatabaseAccess.ThamSo("@TaiKhoan", taiKhoan) }) > 0;
        }

        /// <summary>Kiểm tra email đã được đăng ký.</summary>
        public bool KiemTraEmail(string email)
        {
            return DatabaseAccess.DemBanGhi("sp_KiemTraEmailKhachHang",
                new[] { DatabaseAccess.ThamSo("@Email", email) }) > 0;
        }

        /// <summary>
        /// Đăng ký khách hàng mới: thủ tục tự sinh mã KH kế tiếp và trả mã đó
        /// qua tham số đầu ra, sau đó gán lại vào đối tượng <paramref name="kh"/>.
        /// </summary>
        public int DangKyTaiKhoan(KhachHang kh)
        {
            SqlParameter maKH = new SqlParameter("@MaKH", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };

            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@TenKH", kh.HoTen),
                DatabaseAccess.ThamSo("@SDT", kh.SDT),
                DatabaseAccess.ThamSo("@Email", string.IsNullOrWhiteSpace(kh.Email) ? null : kh.Email),
                DatabaseAccess.ThamSo("@TaiKhoan", kh.TaiKhoan),
                DatabaseAccess.ThamSo("@MatKhau", kh.MatKhau),
                DatabaseAccess.ThamSo("@DiaChi", string.IsNullOrWhiteSpace(kh.DiaChi) ? null : kh.DiaChi),
                maKH
            };

            int ketQua = DatabaseAccess.ThucThiProc("sp_DangKyKhachHang", pars);

            if (maKH.Value != null && maKH.Value != DBNull.Value)
                kh.MaKH = maKH.Value.ToString() ?? "";

            return ketQua;
        }

        /// <summary>Đăng nhập khách hàng.</summary>
        public KhachHang? DangNhap(string taiKhoan, string matKhau)
        {
            DataTable dt = DatabaseAccess.DocBangProc("sp_DangNhapKhachHang",
                new[]
                {
                    DatabaseAccess.ThamSo("@TaiKhoan", taiKhoan),
                    DatabaseAccess.ThamSo("@MatKhau", matKhau)
                });

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new KhachHang(
                row["MaKH"].ToString() ?? "",
                row["TenKH"].ToString() ?? "",
                row["SDT"].ToString() ?? "",
                row["DiaChi"] == DBNull.Value ? "" : row["DiaChi"].ToString() ?? "",
                row["Email"] == DBNull.Value ? "" : row["Email"].ToString() ?? "")
            {
                TaiKhoan = row["TaiKhoan"].ToString() ?? ""
            };
        }

        /// <summary>Danh sách hóa đơn của khách hàng (dùng trước khi xóa).</summary>
        public DataTable LayHoaDonCuaKhachHang(string maKH)
        {
            return DatabaseAccess.DocBangProc("sp_LayHoaDonCuaKhachHang",
                new[] { DatabaseAccess.ThamSo("@MaKH", maKH) });
        }

        /// <summary>Xóa khách hàng.</summary>
        public int Xoa(string maKH)
        {
            return DatabaseAccess.ThucThiProc("sp_XoaKhachHang",
                new[] { DatabaseAccess.ThamSo("@MaKH", maKH) });
        }

        /// <summary>Danh sách mã khách hàng cho AutoComplete khi lập hóa đơn.</summary>
        public DataTable LayDanhSachMa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachMaKH");
        }

        /// <summary>Thông tin khách hàng theo mã.</summary>
        public DataTable LayThongTin(string maKH)
        {
            return DatabaseAccess.DocBangProc("sp_LayThongTinKhachHang",
                new[] { DatabaseAccess.ThamSo("@MaKH", maKH) });
        }
    }
}
