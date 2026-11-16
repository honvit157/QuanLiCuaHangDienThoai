using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng truy cập dữ liệu cho hóa đơn bán hàng (tblHoaDonBan, tblChiTietHDB).
    /// Việc lưu hóa đơn (kiểm tra mã, trừ tồn kho, ghi đầu và chi tiết) được
    /// thực hiện trọn vẹn trong một thủ tục lưu trữ có giao dịch.
    /// </summary>
    public class HoaDonBanDAL
    {
        /// <summary>Danh sách mã hóa đơn bán, mới nhất trước.</summary>
        public DataTable LayDanhSachMa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachMaHDB");
        }

        public bool KiemTraTonTai(string maHDB)
        {
            return DatabaseAccess.DemBanGhi("sp_KiemTraHoaDonBanTonTai",
                new[] { DatabaseAccess.ThamSo("@MaHDB", maHDB) }) > 0;
        }

        /// <summary>Đầu hóa đơn kèm tên nhân viên và thông tin khách hàng.</summary>
        public DataTable LayHoaDon(string maHDB)
        {
            return DatabaseAccess.DocBangProc("sp_LayHoaDonBan",
                new[] { DatabaseAccess.ThamSo("@MaHDB", maHDB) });
        }

        /// <summary>Chi tiết hóa đơn bán.</summary>
        public DataTable LayChiTiet(string maHDB)
        {
            return DatabaseAccess.DocBangProc("sp_LayChiTietHoaDonBan",
                new[] { DatabaseAccess.ThamSo("@MaHDB", maHDB) });
        }

        /// <summary>
        /// Lưu hóa đơn bán và chi tiết trong cùng một giao dịch.
        /// </summary>
        /// <param name="layGiaTuCSDL">
        /// true: thủ tục tự lấy giá bán hiện hành của kho (đơn khách đặt trên Form12);
        /// false: dùng đơn giá, giảm giá do nhân viên nhập trên Form7.
        /// </param>
        /// <returns>Bảng một dòng gồm MaHDB và TongTien do thủ tục trả về.</returns>
        public DataTable LuuHoaDon(HoaDonBan hd, DataTable chiTiet,
                                   bool layGiaTuCSDL,
                                   string? trangThaiThanhToan = null,
                                   string? phuongThucThanhToan = null)
        {
            string xml = ChiTietXml.TaoTuBang(chiTiet,
                "MaHang", "SoLuong", "DonGia", "GiamGia", "ThanhTien");

            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@MaHDB", hd.MaHD),
                DatabaseAccess.ThamSo("@MaNV", hd.MaNV),
                DatabaseAccess.ThamSo("@MaKH", string.IsNullOrWhiteSpace(hd.MaKH) ? null : hd.MaKH),
                DatabaseAccess.ThamSo("@NgayLap", hd.NgayLap),
                DatabaseAccess.ThamSo("@ChiTietXml", xml),
                DatabaseAccess.ThamSo("@LayGiaTuCSDL", layGiaTuCSDL),
                DatabaseAccess.ThamSo("@TrangThaiThanhToan", trangThaiThanhToan),
                DatabaseAccess.ThamSo("@PhuongThucThanhToan", phuongThucThanhToan)
            };

            return DatabaseAccess.DocBangProc("sp_LuuHoaDonBan", pars);
        }

        /// <summary>Danh sách hóa đơn của một khách hàng.</summary>
        public DataTable LayHoaDonTheoKhachHang(string maKH)
        {
            return DatabaseAccess.DocBangProc("sp_LayHoaDonTheoKhachHang",
                new[] { DatabaseAccess.ThamSo("@MaKH", maKH) });
        }

        /// <summary>Hóa đơn chưa thanh toán của khách hàng (màn hình Thanh toán).</summary>
        public DataTable LayHoaDonChuaThanhToan(string maKH)
        {
            return DatabaseAccess.DocBangProc("sp_LayHoaDonChuaThanhToan",
                new[] { DatabaseAccess.ThamSo("@MaKH", maKH) });
        }

        /// <summary>Thông tin thanh toán của hóa đơn thuộc đúng khách hàng.</summary>
        public DataTable LayThongTinThanhToan(string maHDB, string maKH)
        {
            return DatabaseAccess.DocBangProc("sp_LayThongTinThanhToan",
                new[]
                {
                    DatabaseAccess.ThamSo("@MaHDB", maHDB),
                    DatabaseAccess.ThamSo("@MaKH", maKH)
                });
        }

        /// <summary>Cập nhật phương thức và trạng thái thanh toán của hóa đơn.</summary>
        public int CapNhatPhuongThucThanhToan(string maHDB, string maKH,
                                              string phuongThuc, string trangThai)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@MaHDB", maHDB),
                DatabaseAccess.ThamSo("@MaKH", maKH),
                DatabaseAccess.ThamSo("@PhuongThuc", phuongThuc),
                DatabaseAccess.ThamSo("@TrangThai", trangThai)
            };

            return DatabaseAccess.ThucThiProc("sp_CapNhatPhuongThucThanhToan", pars);
        }
    }
}
