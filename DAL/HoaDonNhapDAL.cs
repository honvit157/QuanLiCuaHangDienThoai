using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng truy cập dữ liệu cho hóa đơn nhập hàng (tblHoaDonNhap, tblChiTietHDN).
    /// Khi lưu: kiểm tra trùng mã -> thêm đầu hóa đơn -> cộng tồn kho và cập nhật giá nhập -> thêm chi tiết.
    /// </summary>
    public class HoaDonNhapDAL
    {
        public DataTable LayDanhSachMa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachMaHoaDonNhap");
        }

        public bool KiemTraTonTai(string maHDN)
        {
            return DatabaseAccess.DemBanGhi("sp_KiemTraHoaDonNhapTonTai",
                new[] { DatabaseAccess.ThamSo("@MaHDN", maHDN) }) > 0;
        }

        public DataTable LayHoaDon(string maHDN)
        {
            return DatabaseAccess.DocBangProc("sp_LayHoaDonNhap",
                new[] { DatabaseAccess.ThamSo("@MaHDN", maHDN) });
        }

        public DataTable LayChiTiet(string maHDN)
        {
            return DatabaseAccess.DocBangProc("sp_LayChiTietHoaDonNhap",
                new[] { DatabaseAccess.ThamSo("@MaHDN", maHDN) });
        }

        /// <summary>
        /// Lưu hóa đơn nhập trong một giao dịch. Trả về số dòng chi tiết đã ghi.
        /// </summary>
        public int LuuHoaDon(HoaDonNhap hd)
        {
            using SqlConnection conn = DatabaseAccess.TaoKetNoi();
            conn.Open();

            using SqlTransaction tran = conn.BeginTransaction();
            try
            {
                object? trungMa = DatabaseAccess.GiaTriProc(conn, tran, "sp_KiemTraHoaDonNhapTonTai",
                    new[] { DatabaseAccess.ThamSo("@MaHDN", hd.MaHDN) });

                if (trungMa != null && trungMa != DBNull.Value && Convert.ToInt32(trungMa) > 0)
                {
                    throw new InvalidOperationException("Mã hóa đơn nhập đã tồn tại. Hãy tạo mã mới.");
                }

                DatabaseAccess.ThucThiProc(conn, tran, "sp_ThemHoaDonNhap",
                    new[]
                    {
                        DatabaseAccess.ThamSo("@MaHDN", hd.MaHDN),
                        DatabaseAccess.ThamSo("@MaNV", hd.MaNV),
                        DatabaseAccess.ThamSo("@MaNCC", hd.MaNCC),
                        DatabaseAccess.ThamSo("@NgayNhap", hd.NgayLap),
                        DatabaseAccess.ThamSo("@TongTien", hd.TongTien)
                    });

                foreach (ChiTietHoaDonNhap ct in hd.ChiTietList)
                {
                    object? ketQuaCong = DatabaseAccess.GiaTriProc(conn, tran, "sp_CongTonKho",
                        new[]
                        {
                            DatabaseAccess.ThamSo("@MaHang", ct.MaHang),
                            DatabaseAccess.ThamSo("@SoLuong", ct.SoLuong),
                            DatabaseAccess.ThamSo("@DonGiaNhap", ct.DonGiaNhap)
                        });

                    int soDong = ketQuaCong == null || ketQuaCong == DBNull.Value
                        ? 0
                        : Convert.ToInt32(ketQuaCong);

                    if (soDong == 0)
                    {
                        throw new InvalidOperationException(
                            $"Không tìm thấy mã hàng {ct.MaHang} trong kho.");
                    }

                    DatabaseAccess.ThucThiProc(conn, tran, "sp_ThemChiTietHoaDonNhap",
                        new[]
                        {
                            DatabaseAccess.ThamSo("@MaHDN", hd.MaHDN),
                            DatabaseAccess.ThamSo("@MaHang", ct.MaHang),
                            DatabaseAccess.ThamSo("@SoLuong", ct.SoLuong),
                            DatabaseAccess.ThamSo("@DonGiaNhap", ct.DonGiaNhap),
                            DatabaseAccess.ThamSo("@ThanhTien", ct.ThanhTien)
                        });
                }

                tran.Commit();
                return hd.ChiTietList.Count;
            }
            catch
            {
                try { tran.Rollback(); } catch { /* bỏ qua lỗi rollback */ }
                throw;
            }
        }
    }
}
