using System;
using System.Data;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng truy cập dữ liệu cho màn hình Tổng quan (Dashboard - Form10).
    /// Toàn bộ số liệu đều lấy từ các thủ tục lưu trữ trong nhóm
    /// <c>sp_ThongKe_*</c>, không có câu SQL viết trực tiếp trong C#.
    /// </summary>
    public class ThongKeDAL
    {
        /// <summary>Tổng số mặt hàng đang quản lý.</summary>
        public int DemTongSanPham()
        {
            return DatabaseAccess.DemBanGhi("sp_ThongKe_TongSanPham");
        }

        /// <summary>Tổng số khách hàng.</summary>
        public int DemTongKhachHang()
        {
            return DatabaseAccess.DemBanGhi("sp_ThongKe_TongKhachHang");
        }

        /// <summary>Số hóa đơn bán lập trong ngày hôm nay.</summary>
        public int DemHoaDonHomNay()
        {
            return DatabaseAccess.DemBanGhi("sp_ThongKe_HoaDonHomNay");
        }

        /// <summary>Doanh thu bán hàng của ngày hôm nay.</summary>
        public decimal TinhDoanhThuHomNay()
        {
            object? ketQua = DatabaseAccess.GiaTriProc("sp_ThongKe_DoanhThuHomNay");
            return ketQua == null || ketQua == DBNull.Value ? 0m : Convert.ToDecimal(ketQua);
        }

        /// <summary>Doanh thu 7 ngày gần nhất (Ngay, DoanhThu) để vẽ biểu đồ.</summary>
        public DataTable LayDoanhThu7Ngay()
        {
            return DatabaseAccess.DocBangProc("sp_ThongKe_DoanhThu7Ngay");
        }

        /// <summary>Top 5 mặt hàng bán chạy nhất.</summary>
        public DataTable LayTop5SanPhamBanChay()
        {
            return DatabaseAccess.DocBangProc("sp_ThongKe_Top5SanPhamBanChay");
        }

        /// <summary>Danh sách mặt hàng có tồn kho dưới hoặc bằng ngưỡng cảnh báo.</summary>
        public DataTable LaySanPhamSapHetHang(int nguongTon = 10)
        {
            return DatabaseAccess.DocBangProc("sp_ThongKe_SanPhamSapHetHang",
                new[] { DatabaseAccess.ThamSo("@NguongTon", nguongTon) });
        }

        /// <summary>Tổng số lượng hàng đang nằm trong kho.</summary>
        public int DemTongHangTonKho()
        {
            return DatabaseAccess.DemBanGhi("sp_ThongKe_TongHangTonKho");
        }
    }
}
