using System;
using System.Data;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng nghiệp vụ cho hóa đơn bán hàng (Form7 - nhân viên lập hóa đơn,
    /// Form12 - khách hàng đặt hàng và thanh toán).
    /// </summary>
    public class HoaDonBanBUS
    {
        private readonly HoaDonBanDAL dal = new HoaDonBanDAL();

        /// <summary>Danh sách mã hóa đơn đã lưu, mới nhất trước.</summary>
        public DataTable LayDanhSachMa() => dal.LayDanhSachMa();

        public bool KiemTraTonTai(string maHDB) => dal.KiemTraTonTai(maHDB);

        public DataTable LayHoaDon(string maHDB) => dal.LayHoaDon(maHDB);

        public DataTable LayChiTiet(string maHDB) => dal.LayChiTiet(maHDB);

        /// <summary>
        /// Lưu hóa đơn nhân viên vừa lập trên Form7.
        /// Đơn giá và giảm giá do nhân viên nhập được giữ nguyên.
        /// </summary>
        public bool LuuHoaDon(HoaDonBan hd, DataTable chiTiet, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(hd.MaHD))
            {
                error = "Vui lòng tạo mã hóa đơn!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(hd.MaNV))
            {
                error = "Vui lòng chọn mã nhân viên hợp lệ!";
                return false;
            }

            if (chiTiet == null || chiTiet.Rows.Count == 0)
            {
                error = "Hóa đơn chưa có mặt hàng!";
                return false;
            }

            try
            {
                DataTable ketQua = dal.LuuHoaDon(hd, chiTiet, layGiaTuCSDL: false);

                if (ketQua.Rows.Count > 0)
                {
                    AppHelpers.GhiLog($"Lưu hóa đơn bán {hd.MaHD} - {chiTiet.Rows.Count} mặt hàng");
                    return true;
                }

                error = "Hóa đơn chưa được lưu vào cơ sở dữ liệu!";
                return false;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Lưu đơn hàng khách đặt trên Form12: giá bán lấy theo dữ liệu kho hiện hành,
        /// hóa đơn ở trạng thái chưa thanh toán.
        /// </summary>
        public bool DatHang(HoaDonBan hd, DataTable chiTiet, out string error)
        {
            error = "";

            if (chiTiet == null || chiTiet.Rows.Count == 0)
            {
                error = "Giỏ hàng đang trống.";
                return false;
            }

            try
            {
                DataTable ketQua = dal.LuuHoaDon(hd, chiTiet,
                    layGiaTuCSDL: true,
                    trangThaiThanhToan: "Chưa thanh toán",
                    phuongThucThanhToan: null);

                if (ketQua.Rows.Count > 0)
                {
                    if (ketQua.Columns.Contains("TongTien"))
                        hd.TongTien = Convert.ToDecimal(ketQua.Rows[0]["TongTien"]);

                    AppHelpers.GhiLog($"Khách {hd.MaKH} đặt đơn {hd.MaHD}");
                    return true;
                }

                error = "Không thể tạo hóa đơn cho đơn hàng.";
                return false;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public DataTable LayHoaDonTheoKhachHang(string maKH) => dal.LayHoaDonTheoKhachHang(maKH);

        public DataTable LayHoaDonChuaThanhToan(string maKH) => dal.LayHoaDonChuaThanhToan(maKH);

        public DataTable LayThongTinThanhToan(string maHDB, string maKH) =>
            dal.LayThongTinThanhToan(maHDB, maKH);

        /// <summary>Ghi nhận phương thức thanh toán khách đã chọn.</summary>
        public bool LuuPhuongThucThanhToan(string maHDB, string maKH,
                                           string phuongThuc, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(maHDB) || string.IsNullOrWhiteSpace(maKH))
            {
                error = "Không xác định được hóa đơn cần thanh toán.";
                return false;
            }

            string trangThai = phuongThuc == "Chuyển khoản"
                ? "Chờ xác nhận chuyển khoản"
                : "Chưa thanh toán";

            try
            {
                if (dal.CapNhatPhuongThucThanhToan(maHDB, maKH, phuongThuc, trangThai) > 0)
                {
                    AppHelpers.GhiLog($"Hóa đơn {maHDB}: {phuongThuc}");
                    return true;
                }

                error = "Không thể lưu phương thức thanh toán.";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi lưu phương thức thanh toán: " + ex.Message;
                return false;
            }
        }
    }
}
