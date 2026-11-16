using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng truy cập dữ liệu cho màn hình Tổng quan (Form10).
    /// Mỗi chỉ số là một thủ tục lưu trữ tính sẵn trong SQL Server.
    /// </summary>
    public class ThongKeDAL
    {
        /// <summary>Tổng số mặt hàng đang kinh doanh.</summary>
        public int DemTongSanPham()
        {
            return DatabaseAccess.DemBanGhi("sp_ThongKe_TongSanPham");
        }

        /// <summary>Tổng số khách hàng.</summary>
        public int DemTongKhachHang()
        {
            return DatabaseAccess.DemBanGhi("sp_ThongKe_TongKhachHang");
        }

        /// <summary>Số hóa đơn bán trong ngày hôm nay.</summary>
        public int DemHoaDonHomNay()
        {
            return DatabaseAccess.DemBanGhi("sp_ThongKe_HoaDonHomNay");
        }

        /// <summary>Doanh thu trong ngày hôm nay.</summary>
        public decimal TinhDoanhThuHomNay()
        {
            return DatabaseAccess.LaySoThuc("sp_ThongKe_DoanhThuHomNay");
        }

        /// <summary>Tổng số lượng hàng đang tồn kho.</summary>
        public int DemTongHangTonKho()
        {
            return DatabaseAccess.DemBanGhi("sp_ThongKe_TongHangTonKho");
        }

        /// <summary>Doanh thu 7 ngày gần nhất (gồm cả ngày không có hóa đơn).</summary>
        public DataTable LayDoanhThu7Ngay()
        {
            return DatabaseAccess.DocBangProc("sp_ThongKe_DoanhThu7Ngay");
        }

        /// <summary>Top 5 mặt hàng bán chạy.</summary>
        public DataTable LayTop5SanPhamBanChay()
        {
            return DatabaseAccess.DocBangProc("sp_ThongKe_Top5BanChay");
        }

        /// <summary>Danh sách mặt hàng sắp hết hàng theo ngưỡng tồn kho.</summary>
        public DataTable LaySanPhamSapHetHang(int nguongTon)
        {
            return DatabaseAccess.DocBangProc("sp_ThongKe_SanPhamSapHetHang",
                new[] { DatabaseAccess.ThamSo("@NguongTon", nguongTon) });
        }
    }
}
