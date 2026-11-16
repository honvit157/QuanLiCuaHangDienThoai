using System;
using System.Data;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng nghiệp vụ cho hóa đơn bán hàng: kiểm tra dữ liệu hóa đơn,
    /// tính lại thành tiền - tổng tiền rồi mới giao cho DAL lưu trong giao dịch.
    /// </summary>
    public class HoaDonBanBUS
    {
        private readonly HoaDonBanDAL dal = new HoaDonBanDAL();

        public DataTable LayDanhSachMa()
        {
            return dal.LayDanhSachMa();
        }

        public bool KiemTraTonTai(string maHDB)
        {
            if (string.IsNullOrWhiteSpace(maHDB)) return false;
            try
            {
                return dal.KiemTraTonTai(maHDB.Trim());
            }
            catch
            {
                return false;
            }
        }

        public DataTable LayHoaDon(string maHDB)
        {
            return dal.LayHoaDon(maHDB);
        }

        public DataTable LayChiTiet(string maHDB)
        {
            return dal.LayChiTiet(maHDB);
        }

        /// <summary>
        /// Danh sách hóa đơn của khách hàng đang đăng nhập (trang Khách hàng - Form12).
        /// chiChuaThanhToan = true: chỉ lấy hóa đơn chưa thanh toán / chờ xác nhận chuyển khoản.
        /// </summary>
        public DataTable LayHoaDonKhachHang(string maKH, bool chiChuaThanhToan)
        {
            if (string.IsNullOrWhiteSpace(maKH)) return new DataTable();
            return dal.LayHoaDonKhachHang(maKH.Trim(), chiChuaThanhToan);
        }

        /// <summary>Một hóa đơn thuộc về khách hàng đang đăng nhập (bảng rỗng nếu không phải chủ hóa đơn).</summary>
        public DataTable LayHoaDonKhachHangTheoMa(string maHDB, string maKH)
        {
            if (string.IsNullOrWhiteSpace(maHDB) || string.IsNullOrWhiteSpace(maKH))
                return new DataTable();

            return dal.LayHoaDonKhachHangTheoMa(maHDB.Trim(), maKH.Trim());
        }

        /// <summary>
        /// Khách hàng chọn phương thức thanh toán cho hóa đơn của mình:
        /// Tiền mặt -> Chưa thanh toán (trả khi nhận hàng),
        /// Chuyển khoản -> Chờ xác nhận chuyển khoản.
        /// </summary>
        public bool CapNhatPhuongThucThanhToan(string maHDB, string maKH,
                                               string phuongThuc, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(maHDB) || string.IsNullOrWhiteSpace(maKH))
            {
                error = "Chưa xác định được hóa đơn hoặc khách hàng!";
                return false;
            }

            if (phuongThuc != "Tiền mặt" && phuongThuc != "Chuyển khoản")
            {
                error = "Phương thức thanh toán không hợp lệ!";
                return false;
            }

            string trangThai = phuongThuc == "Chuyển khoản"
                ? "Chờ xác nhận chuyển khoản"
                : "Chưa thanh toán";

            try
            {
                if (dal.CapNhatPhuongThucThanhToan(maHDB.Trim(), maKH.Trim(), phuongThuc, trangThai) <= 0)
                {
                    error = "Không tìm thấy hóa đơn của bạn để cập nhật phương thức thanh toán!";
                    return false;
                }

                AppHelpers.GhiLog($"Khách hàng {maKH} chọn thanh toán {phuongThuc} cho hóa đơn {maHDB}");
                return true;
            }
            catch (Exception ex)
            {
                error = "Lỗi lưu phương thức thanh toán: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Lưu hóa đơn bán hàng sau khi kiểm tra nghiệp vụ.
        /// </summary>
        public bool LuuHoaDon(HoaDonBan hd, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(hd.MaHD))
            {
                error = "Vui lòng tạo mã hóa đơn!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(hd.MaNV))
            {
                error = "Vui lòng chọn nhân viên lập hóa đơn!";
                return false;
            }

            if (hd.ChiTietList.Count == 0)
            {
                error = "Hóa đơn chưa có mặt hàng!";
                return false;
            }

            foreach (ChiTietHoaDonBan ct in hd.ChiTietList)
            {
                if (ct.SoLuong <= 0)
                {
                    error = $"Số lượng của mặt hàng {ct.MaHang} phải lớn hơn 0!";
                    return false;
                }

                if (ct.DonGia < 0 || ct.GiamGia < 0 || ct.GiamGia > 100)
                {
                    error = $"Đơn giá/giảm giá của mặt hàng {ct.MaHang} không hợp lệ!";
                    return false;
                }

                ct.TinhThanhTien();
            }

            // Tính lại tổng tiền từ dữ liệu chi tiết để tránh sai lệch
            hd.TinhTongTien();

            try
            {
                dal.LuuHoaDon(hd);
                AppHelpers.GhiLog($"Lưu hóa đơn bán {hd.MaHD}: {hd.ChiTietList.Count} dòng, tổng {hd.TongTien:N0} đ");
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                AppHelpers.GhiLog($"Lỗi lưu hóa đơn bán {hd.MaHD}: {ex.Message}");
                return false;
            }
        }

        // ------------------------------------------------------------------
        // Lịch sử hóa đơn bán (FormLichSuHoaDon)
        // ------------------------------------------------------------------

        /// <summary>
        /// Danh sách hóa đơn bán để tra cứu. Từ khóa rỗng trả về toàn bộ,
        /// ngược lại lọc theo mã hóa đơn, số điện thoại, tên khách hàng hoặc tên nhân viên.
        /// </summary>
        public DataTable TimHoaDon(string tuKhoa)
        {
            return dal.TimHoaDon((tuKhoa ?? "").Trim());
        }

        /// <summary>
        /// Hủy hóa đơn bán: hoàn lại tồn kho rồi xóa hóa đơn khỏi hệ thống.
        /// </summary>
        public bool HuyHoaDon(string maHDB, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(maHDB))
            {
                error = "Chưa chọn hóa đơn để hủy!";
                return false;
            }

            try
            {
                int soDong = dal.HuyHoaDon(maHDB.Trim());

                if (soDong <= 0)
                {
                    error = "Không tìm thấy hóa đơn " + maHDB.Trim() + " để hủy!";
                    return false;
                }

                AppHelpers.GhiLog($"Hủy hóa đơn bán {maHDB.Trim()}: đã hoàn lại tồn kho");
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                AppHelpers.GhiLog($"Lỗi hủy hóa đơn bán {maHDB.Trim()}: {ex.Message}");
                return false;
            }
        }
    }
}
