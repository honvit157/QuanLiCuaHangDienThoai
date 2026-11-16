using System;
using System.Data;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng nghiệp vụ cho màn hình Báo cáo thống kê (FormBaoCao).
    /// Gom số liệu từ <see cref="BaoCaoDAL"/> và tính các tổng cộng cần hiển thị.
    /// </summary>
    public class BaoCaoBUS
    {
        private readonly BaoCaoDAL dal = new BaoCaoDAL();

        public DataTable DoanhThuTheoThang() => dal.LayDoanhThuTheoThang();

        public DataTable TonKho() => dal.LayTonKho();

        public DataTable TopBanChay(int soLuong = 10) => dal.LayTopBanChay(soLuong);

        /// <summary>Tổng doanh thu của tất cả các tháng có trong báo cáo.</summary>
        public decimal TongDoanhThu(DataTable dtDoanhThu)
        {
            decimal tong = 0;

            foreach (DataRow r in dtDoanhThu.Rows)
            {
                if (r["DoanhThu"] != DBNull.Value)
                    tong += Convert.ToDecimal(r["DoanhThu"]);
            }

            return tong;
        }

        /// <summary>Tổng giá trị hàng còn tồn kho theo giá bán.</summary>
        public decimal TongGiaTriTon(DataTable dtTonKho)
        {
            decimal tong = 0;

            foreach (DataRow r in dtTonKho.Rows)
            {
                if (r["GiaTriTon"] != DBNull.Value)
                    tong += Convert.ToDecimal(r["GiaTriTon"]);
            }

            return tong;
        }
    }
}
