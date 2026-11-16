using System;
using System.Data;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng nghiệp vụ cho hóa đơn nhập hàng (Form8).
    /// </summary>
    public class HoaDonNhapBUS
    {
        private readonly HoaDonNhapDAL dal = new HoaDonNhapDAL();

        public DataTable LayDanhSachMa() => dal.LayDanhSachMa();

        public bool KiemTraTonTai(string maHDN) => dal.KiemTraTonTai(maHDN);

        public DataTable LayHoaDon(string maHDN) => dal.LayHoaDon(maHDN);

        public DataTable LayChiTiet(string maHDN) => dal.LayChiTiet(maHDN);

        /// <summary>
        /// Lưu hóa đơn nhập hàng: cộng tồn kho, cập nhật giá nhập và ghi chi tiết.
        /// </summary>
        public bool LuuHoaDon(HoaDonNhap hd, DataTable chiTiet, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(hd.MaHDN))
            {
                error = "Bạn hãy nhập mã hóa đơn.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(hd.MaNV))
            {
                error = "Mã nhân viên không tồn tại trong CSDL.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(hd.MaNCC))
            {
                error = "Bạn hãy chọn nhà cung cấp.";
                return false;
            }

            if (chiTiet == null || chiTiet.Rows.Count == 0)
            {
                error = "Hóa đơn chưa có mặt hàng.";
                return false;
            }

            try
            {
                DataTable ketQua = dal.LuuHoaDon(hd, chiTiet);

                if (ketQua.Rows.Count > 0)
                {
                    AppHelpers.GhiLog($"Lưu hóa đơn nhập {hd.MaHDN}");
                    return true;
                }

                error = "Hóa đơn nhập chưa được lưu vào cơ sở dữ liệu!";
                return false;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
