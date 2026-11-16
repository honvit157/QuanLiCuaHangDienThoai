using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng truy cập dữ liệu cho màn hình Báo cáo thống kê (FormBaoCao):
    /// doanh thu theo tháng, tồn kho và top sản phẩm bán chạy.
    /// </summary>
    public class BaoCaoDAL
    {
        /// <summary>Doanh thu gộp theo tháng.</summary>
        public DataTable LayDoanhThuTheoThang()
        {
            return DatabaseAccess.DocBangProc("sp_BaoCao_DoanhThuTheoThang");
        }

        /// <summary>Tồn kho kèm giá trị tồn của từng mặt hàng.</summary>
        public DataTable LayTonKho()
        {
            return DatabaseAccess.DocBangProc("sp_BaoCao_TonKho");
        }

        /// <summary>Top sản phẩm bán chạy theo số lượng bán.</summary>
        public DataTable LayTopBanChay(int soLuong)
        {
            return DatabaseAccess.DocBangProc("sp_BaoCao_TopBanChay",
                new[] { DatabaseAccess.ThamSo("@SoLuong", soLuong) });
        }
    }
}
