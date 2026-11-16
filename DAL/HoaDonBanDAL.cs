using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng truy cập dữ liệu cho hóa đơn bán hàng (tblHoaDonBan, tblChiTietHDB).
    /// Việc lưu hóa đơn gồm nhiều bước nên được thực hiện trong một giao dịch (transaction):
    /// kiểm tra trùng mã -> trừ tồn kho -> thêm đầu hóa đơn -> thêm từng dòng chi tiết.
    /// </summary>
    public class HoaDonBanDAL
    {
        public DataTable LayDanhSachMa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachMaHoaDonBan");
        }

        public bool KiemTraTonTai(string maHDB)
        {
            return DatabaseAccess.DemBanGhi("sp_KiemTraHoaDonBanTonTai",
                new[] { DatabaseAccess.ThamSo("@MaHDB", maHDB) }) > 0;
        }

        /// <summary>Thông tin đầu hóa đơn kèm tên nhân viên, khách hàng.</summary>
        public DataTable LayHoaDon(string maHDB)
        {
            return DatabaseAccess.DocBangProc("sp_LayHoaDonBan",
                new[] { DatabaseAccess.ThamSo("@MaHDB", maHDB) });
        }

        public DataTable LayChiTiet(string maHDB)
        {
            return DatabaseAccess.DocBangProc("sp_LayChiTietHoaDonBan",
                new[] { DatabaseAccess.ThamSo("@MaHDB", maHDB) });
        }

        /// <summary>
        /// Lưu hóa đơn bán hàng trong một giao dịch.
        /// Trả về số dòng chi tiết đã ghi; ném ngoại lệ nếu không đủ tồn kho
        /// hoặc mã hóa đơn đã tồn tại (giao dịch sẽ được hoàn tác).
        /// </summary>
        public int LuuHoaDon(HoaDonBan hd)
        {
            using SqlConnection conn = DatabaseAccess.TaoKetNoi();
            conn.Open();

            using SqlTransaction tran = conn.BeginTransaction();
            try
            {
                // 1. Không cho trùng mã hóa đơn
                object? trungMa = DatabaseAccess.GiaTriProc(conn, tran, "sp_KiemTraHoaDonBanTonTai",
                    new[] { DatabaseAccess.ThamSo("@MaHDB", hd.MaHD) });

                if (trungMa != null && trungMa != DBNull.Value && Convert.ToInt32(trungMa) > 0)
                {
                    throw new InvalidOperationException("Mã hóa đơn đã tồn tại. Hãy tạo mã mới.");
                }

                // 2. Trừ tồn kho với điều kiện đủ hàng (tránh bán vượt tồn)
                foreach (ChiTietHoaDonBan ct in hd.ChiTietList)
                {
                    // Thủ tục trả về số dòng đã trừ được (0 nếu không đủ tồn kho)
                    object? ketQuaTru = DatabaseAccess.GiaTriProc(conn, tran, "sp_TruTonKho",
                        new[]
                        {
                            DatabaseAccess.ThamSo("@MaHang", ct.MaHang),
                            DatabaseAccess.ThamSo("@SoLuong", ct.SoLuong)
                        });

                    int soDong = ketQuaTru == null || ketQuaTru == DBNull.Value
                        ? 0
                        : Convert.ToInt32(ketQuaTru);

                    if (soDong == 0)
                    {
                        throw new InvalidOperationException(
                            $"Mặt hàng {ct.MaHang} không tồn tại hoặc không đủ số lượng tồn kho.");
                    }
                }

                // 3. Thêm đầu hóa đơn
                DatabaseAccess.ThucThiProc(conn, tran, "sp_ThemHoaDonBan",
                    new[]
                    {
                        DatabaseAccess.ThamSo("@MaHDB", hd.MaHD),
                        DatabaseAccess.ThamSo("@MaNV", hd.MaNV),
                        DatabaseAccess.ThamSo("@MaKH", string.IsNullOrWhiteSpace(hd.MaKH) ? null : hd.MaKH),
                        DatabaseAccess.ThamSo("@NgayLap", hd.NgayLap),
                        DatabaseAccess.ThamSo("@TongTien", hd.TongTien)
                    });

                // 4. Thêm từng dòng chi tiết
                foreach (ChiTietHoaDonBan ct in hd.ChiTietList)
                {
                    DatabaseAccess.ThucThiProc(conn, tran, "sp_ThemChiTietHoaDonBan",
                        new[]
                        {
                            DatabaseAccess.ThamSo("@MaHDB", hd.MaHD),
                            DatabaseAccess.ThamSo("@MaHang", ct.MaHang),
                            DatabaseAccess.ThamSo("@SoLuong", ct.SoLuong),
                            DatabaseAccess.ThamSo("@DonGia", ct.DonGia),
                            DatabaseAccess.ThamSo("@GiamGia", ct.GiamGia),
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
