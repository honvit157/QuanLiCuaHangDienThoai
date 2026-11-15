using System;
using System.Data;

namespace QuanLyCuaHangDienThoai
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
    }
}
