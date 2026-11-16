using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng truy cập dữ liệu cho hóa đơn nhập hàng (tblHoaDonNhap, tblChiTietHDN).
    /// </summary>
    public class HoaDonNhapDAL
    {
        /// <summary>Danh sách mã hóa đơn nhập.</summary>
        public DataTable LayDanhSachMa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachMaHDN");
        }

        public bool KiemTraTonTai(string maHDN)
        {
            return DatabaseAccess.DemBanGhi("sp_KiemTraHoaDonNhapTonTai",
                new[] { DatabaseAccess.ThamSo("@MaHDN", maHDN) }) > 0;
        }

        /// <summary>Đầu hóa đơn nhập kèm nhân viên và nhà cung cấp.</summary>
        public DataTable LayHoaDon(string maHDN)
        {
            return DatabaseAccess.DocBangProc("sp_LayHoaDonNhap",
                new[] { DatabaseAccess.ThamSo("@MaHDN", maHDN) });
        }

        /// <summary>Chi tiết hóa đơn nhập.</summary>
        public DataTable LayChiTiet(string maHDN)
        {
            return DatabaseAccess.DocBangProc("sp_LayChiTietHoaDonNhap",
                new[] { DatabaseAccess.ThamSo("@MaHDN", maHDN) });
        }

        /// <summary>
        /// Lưu hóa đơn nhập: cộng tồn kho, cập nhật giá nhập, ghi đầu và chi tiết
        /// trong cùng một giao dịch.
        /// </summary>
        public DataTable LuuHoaDon(HoaDonNhap hd, DataTable chiTiet)
        {
            string xml = ChiTietXml.TaoTuBang(chiTiet,
                "MaHang", "SoLuong", "DonGiaNhap", null, "ThanhTien");

            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@MaHDN", hd.MaHDN),
                DatabaseAccess.ThamSo("@MaNV", hd.MaNV),
                DatabaseAccess.ThamSo("@MaNCC", hd.MaNCC),
                DatabaseAccess.ThamSo("@NgayNhap", hd.NgayNhap),
                DatabaseAccess.ThamSo("@ChiTietXml", xml)
            };

            return DatabaseAccess.DocBangProc("sp_LuuHoaDonNhap", pars);
        }
    }
}
