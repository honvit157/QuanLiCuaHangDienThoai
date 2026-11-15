using System;
using System.Data;

namespace QuanLyCuaHangDienThoai
{
    /// <summary>
    /// Tầng nghiệp vụ cho hóa đơn nhập hàng.
    /// </summary>
    public class HoaDonNhapBUS
    {
        private readonly HoaDonNhapDAL dal = new HoaDonNhapDAL();

        public DataTable LayDanhSachMa()
        {
            return dal.LayDanhSachMa();
        }

        public bool KiemTraTonTai(string maHDN)
        {
            if (string.IsNullOrWhiteSpace(maHDN)) return false;
            try
            {
                return dal.KiemTraTonTai(maHDN.Trim());
            }
            catch
            {
                return false;
            }
        }

        public DataTable LayHoaDon(string maHDN)
        {
            return dal.LayHoaDon(maHDN);
        }

        public DataTable LayChiTiet(string maHDN)
        {
            return dal.LayChiTiet(maHDN);
        }

        /// <summary>Lưu hóa đơn nhập hàng sau khi kiểm tra nghiệp vụ.</summary>
        public bool LuuHoaDon(HoaDonNhap hd, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(hd.MaHDN))
            {
                error = "Bạn hãy nhập mã hóa đơn nhập!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(hd.MaNV))
            {
                error = "Mã nhân viên không tồn tại trong cơ sở dữ liệu!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(hd.MaNCC))
            {
                error = "Bạn hãy chọn nhà cung cấp!";
                return false;
            }

            if (hd.ChiTietList.Count == 0)
            {
                error = "Hóa đơn chưa có mặt hàng!";
                return false;
            }

            foreach (ChiTietHoaDonNhap ct in hd.ChiTietList)
            {
                if (ct.SoLuong <= 0)
                {
                    error = $"Số lượng của mặt hàng {ct.MaHang} phải lớn hơn 0!";
                    return false;
                }

                if (ct.DonGiaNhap <= 0)
                {
                    error = $"Đơn giá nhập của mặt hàng {ct.MaHang} không hợp lệ!";
                    return false;
                }

                ct.TinhThanhTien();
            }

            hd.TinhTongTien();

            try
            {
                dal.LuuHoaDon(hd);
                AppHelpers.GhiLog($"Lưu hóa đơn nhập {hd.MaHDN}: {hd.ChiTietList.Count} dòng, tổng {hd.TongTien:N0} đ");
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                AppHelpers.GhiLog($"Lỗi lưu hóa đơn nhập {hd.MaHDN}: {ex.Message}");
                return false;
            }
        }
    }
}
