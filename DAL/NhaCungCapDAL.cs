using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng truy cập dữ liệu cho bảng nhà cung cấp (tblNhaCungCap).
    /// </summary>
    public class NhaCungCapDAL
    {
        /// <summary>Lấy toàn bộ danh sách nhà cung cấp.</summary>
        public DataTable LayTatCa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachNhaCungCap");
        }

        public int Them(NhaCungCap ncc)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@MaNCC", ncc.MaNCC),
                DatabaseAccess.ThamSo("@TenNCC", ncc.TenNCC),
                DatabaseAccess.ThamSo("@SDT", ncc.SDT),
                DatabaseAccess.ThamSo("@DiaChi", ncc.DiaChi),
                DatabaseAccess.ThamSo("@Email", string.IsNullOrWhiteSpace(ncc.Email) ? null : ncc.Email),
                DatabaseAccess.ThamSo("@NguoiLH", string.IsNullOrWhiteSpace(ncc.NguoiLH) ? null : ncc.NguoiLH)
            };

            return DatabaseAccess.ThucThiProc("sp_ThemNhaCungCap", pars);
        }

        public int Sua(NhaCungCap ncc)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@MaNCC", ncc.MaNCC),
                DatabaseAccess.ThamSo("@TenNCC", ncc.TenNCC),
                DatabaseAccess.ThamSo("@SDT", ncc.SDT),
                DatabaseAccess.ThamSo("@DiaChi", ncc.DiaChi),
                DatabaseAccess.ThamSo("@Email", string.IsNullOrWhiteSpace(ncc.Email) ? null : ncc.Email),
                DatabaseAccess.ThamSo("@NguoiLH", string.IsNullOrWhiteSpace(ncc.NguoiLH) ? null : ncc.NguoiLH)
            };

            return DatabaseAccess.ThucThiProc("sp_CapNhatNhaCungCap", pars);
        }

        public int Xoa(string maNCC)
        {
            return DatabaseAccess.ThucThiProc("sp_XoaNhaCungCap",
                new[] { DatabaseAccess.ThamSo("@MaNCC", maNCC) });
        }

        public bool KiemTraTonTai(string maNCC)
        {
            return DatabaseAccess.DemBanGhi("sp_KiemTraNhaCungCapTonTai",
                new[] { DatabaseAccess.ThamSo("@Ma", maNCC) }) > 0;
        }

        /// <summary>Danh sách mã nhà cung cấp để nạp ComboBox.</summary>
        public DataTable LayDanhSachMa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachMaNCC");
        }

        /// <summary>Thông tin nhà cung cấp theo mã.</summary>
        public DataTable LayThongTin(string maNCC)
        {
            return DatabaseAccess.DocBangProc("sp_LayThongTinNhaCungCap",
                new[] { DatabaseAccess.ThamSo("@MaNCC", maNCC) });
        }
    }
}
