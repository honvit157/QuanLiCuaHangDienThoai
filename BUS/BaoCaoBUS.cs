using System.Data;

namespace QuanLyCuaHangDienThoai
{
    /// <summary>
    /// Tầng nghiệp vụ cho báo cáo - thống kê: doanh thu, tồn kho, sản phẩm bán chạy.
    /// </summary>
    public class BaoCaoBUS
    {
        private readonly BaoCaoDAL dal = new BaoCaoDAL();

        /// <summary>Doanh thu và số hóa đơn theo từng tháng.</summary>
        public DataTable DoanhThuTheoThang()
        {
            return dal.DoanhThuTheoThang();
        }

        /// <summary>Tồn kho và giá trị tồn của từng mặt hàng.</summary>
        public DataTable TonKho()
        {
            return dal.TonKho();
        }

        /// <summary>Top sản phẩm bán chạy (mặc định 10 dòng).</summary>
        public DataTable TopBanChay(int soDong = 10)
        {
            return dal.TopBanChay(soDong <= 0 ? 10 : soDong);
        }
    }
}
