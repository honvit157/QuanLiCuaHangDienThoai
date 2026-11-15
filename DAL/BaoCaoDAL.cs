using System.Data;

namespace QuanLyCuaHangDienThoai
{
    /// <summary>
    /// Tầng truy cập dữ liệu phục vụ Form báo cáo - thống kê.
    /// Cả ba báo cáo đều được tính toán bằng thủ tục lưu trữ trên SQL Server
    /// để giảm khối lượng dữ liệu truyền về ứng dụng.
    /// </summary>
    public class BaoCaoDAL
    {
        /// <summary>Doanh thu, số hóa đơn theo từng tháng.</summary>
        public DataTable DoanhThuTheoThang()
        {
            return DatabaseAccess.DocBangProc("sp_BaoCaoDoanhThuTheoThang");
        }

        /// <summary>Tồn kho hiện tại và giá trị tồn của từng mặt hàng.</summary>
        public DataTable TonKho()
        {
            return DatabaseAccess.DocBangProc("sp_BaoCaoTonKho");
        }

        /// <summary>Top sản phẩm bán chạy nhất.</summary>
        public DataTable TopBanChay(int soDong)
        {
            return DatabaseAccess.DocBangProc("sp_BaoCaoTopBanChay",
                new[] { DatabaseAccess.ThamSo("@SoDong", soDong) });
        }
    }
}
