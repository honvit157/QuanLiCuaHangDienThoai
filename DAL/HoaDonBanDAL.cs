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

        // ------------------------------------------------------------------
        // Hóa đơn của Khách hàng (trang Khách hàng - Form12)
        // ------------------------------------------------------------------

        /// <summary>
        /// Danh sách hóa đơn của một khách hàng kèm trạng thái và phương thức thanh toán.
        /// chiChuaThanhToan = true: chỉ lấy hóa đơn chưa thanh toán / chờ xác nhận chuyển khoản.
        /// </summary>
        public DataTable LayHoaDonKhachHang(string maKH, bool chiChuaThanhToan)
        {
            return DatabaseAccess.DocBangProc("sp_LayHoaDonKhachHang",
                new[]
                {
                    DatabaseAccess.ThamSo("@MaKH", maKH),
                    DatabaseAccess.ThamSo("@ChiChuaThanhToan", chiChuaThanhToan ? 1 : 0)
                });
        }

        /// <summary>Một hóa đơn của đúng khách hàng đang đăng nhập (bảng rỗng nếu không phải chủ).</summary>
        public DataTable LayHoaDonKhachHangTheoMa(string maHDB, string maKH)
        {
            return DatabaseAccess.DocBangProc("sp_LayHoaDonKhachHangTheoMa",
                new[]
                {
                    DatabaseAccess.ThamSo("@MaHDB", maHDB),
                    DatabaseAccess.ThamSo("@MaKH", maKH)
                });
        }

        /// <summary>
        /// Lưu phương thức và trạng thái thanh toán của hóa đơn thuộc về khách hàng đang đăng nhập.
        /// Trả về số dòng đã cập nhật (0 = không tìm thấy hóa đơn của khách hàng này).
        /// </summary>
        public int CapNhatPhuongThucThanhToan(string maHDB, string maKH,
                                             string phuongThuc, string trangThai)
        {
            object? kq = DatabaseAccess.GiaTriProc("sp_CapNhatPhuongThucThanhToan",
                new[]
                {
                    DatabaseAccess.ThamSo("@MaHDB", maHDB),
                    DatabaseAccess.ThamSo("@MaKH", maKH),
                    DatabaseAccess.ThamSo("@PhuongThuc", phuongThuc),
                    DatabaseAccess.ThamSo("@TrangThai", trangThai)
                });

            return kq == null || kq == DBNull.Value ? 0 : Convert.ToInt32(kq);
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

        // ------------------------------------------------------------------
        // Lịch sử hóa đơn bán (FormLichSuHoaDon)
        // ------------------------------------------------------------------

        /// <summary>
        /// Danh sách hóa đơn bán kèm nhân viên, khách hàng và trạng thái thanh toán.
        /// Từ khóa rỗng thì trả về toàn bộ hóa đơn; ngược lại lọc theo mã hóa đơn,
        /// số điện thoại, tên khách hàng hoặc tên nhân viên.
        /// </summary>
        public DataTable TimHoaDon(string tuKhoa)
        {
            return DatabaseAccess.DocBangProc("sp_TimHoaDonBan",
                new[] { DatabaseAccess.ThamSo("@TuKhoa", tuKhoa) });
        }

        /// <summary>
        /// Hủy một hóa đơn bán trong một giao dịch: hoàn lại tồn kho theo từng dòng chi tiết,
        /// xóa chi tiết rồi xóa đầu hóa đơn. Trả về số dòng đầu hóa đơn đã xóa (0 = không tìm thấy).
        /// </summary>
        public int HuyHoaDon(string maHDB)
        {
            using SqlConnection conn = DatabaseAccess.TaoKetNoi();
            conn.Open();

            using SqlTransaction tran = conn.BeginTransaction();
            try
            {
                // 1. Đọc chi tiết để biết cần hoàn lại bao nhiêu hàng
                DataTable chiTiet = DatabaseAccess.DocBangProc(conn, tran, "sp_LayChiTietHoaDonBan",
                    new[] { DatabaseAccess.ThamSo("@MaHDB", maHDB) });

                if (chiTiet.Rows.Count == 0)
                {
                    tran.Rollback();
                    return 0;
                }

                // 2. Hoàn lại tồn kho cho từng mặt hàng
                foreach (DataRow r in chiTiet.Rows)
                {
                    DatabaseAccess.ThucThiProc(conn, tran, "sp_HoanTonKho",
                        new[]
                        {
                            DatabaseAccess.ThamSo("@MaHang", r["MaHang"].ToString()),
                            DatabaseAccess.ThamSo("@SoLuong", Convert.ToInt32(r["SoLuong"]))
                        });
                }

                // 3. Xóa chi tiết rồi xóa đầu hóa đơn
                DatabaseAccess.ThucThiProc(conn, tran, "sp_XoaChiTietHoaDonBan",
                    new[] { DatabaseAccess.ThamSo("@MaHDB", maHDB) });

                int soDong = DatabaseAccess.ThucThiProc(conn, tran, "sp_XoaHoaDonBan",
                    new[] { DatabaseAccess.ThamSo("@MaHDB", maHDB) });

                tran.Commit();
                return soDong;
            }
            catch
            {
                try { tran.Rollback(); } catch { /* bỏ qua lỗi rollback */ }
                throw;
            }
        }
    }
}
