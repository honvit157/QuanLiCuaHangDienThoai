using System;
using System.Data;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng nghiệp vụ cho màn hình Tổng quan. Chịu trách nhiệm lấy số liệu
    /// thống kê qua <see cref="ThongKeDAL"/> và định dạng sẵn để lớp giao diện
    /// hiển thị (Form10 - Dashboard).
    /// </summary>
    public class ThongKeBUS
    {
        private readonly ThongKeDAL dal = new ThongKeDAL();

        /// <summary>Tổng số mặt hàng.</summary>
        public int TongSanPham() => dal.DemTongSanPham();

        /// <summary>Tổng số khách hàng.</summary>
        public int TongKhachHang() => dal.DemTongKhachHang();

        /// <summary>Số hóa đơn bán trong ngày.</summary>
        public int HoaDonHomNay() => dal.DemHoaDonHomNay();

        /// <summary>Doanh thu trong ngày.</summary>
        public decimal DoanhThuHomNay() => dal.TinhDoanhThuHomNay();

        /// <summary>Tổng số lượng hàng tồn kho.</summary>
        public int TongHangTonKho() => dal.DemTongHangTonKho();

        /// <summary>Bảng doanh thu 7 ngày gần nhất dùng cho biểu đồ cột.</summary>
        public DataTable DoanhThu7Ngay() => dal.LayDoanhThu7Ngay();

        /// <summary>Bảng top 5 mặt hàng bán chạy.</summary>
        public DataTable Top5BanChay() => dal.LayTop5SanPhamBanChay();

        /// <summary>Bảng các mặt hàng sắp hết hàng.</summary>
        public DataTable SanPhamSapHetHang(int nguongTon = 10) => dal.LaySanPhamSapHetHang(nguongTon);

        /// <summary>Doanh thu hôm nay đã định dạng tiền Việt Nam, ví dụ "2.500.000 đ".</summary>
        public string DoanhThuHomNayDaDinhDang()
        {
            return AppHelpers.DinhDangTien(dal.TinhDoanhThuHomNay()) + " đ";
        }

        /// <summary>
        /// Tổng doanh thu của 7 ngày gần nhất - dùng cho dòng mô tả dưới biểu đồ.
        /// </summary>
        public decimal TongDoanhThu7Ngay()
        {
            decimal tong = 0;
            DataTable dt = dal.LayDoanhThu7Ngay();

            foreach (DataRow r in dt.Rows)
            {
                if (r["DoanhThu"] != DBNull.Value)
                    tong += Convert.ToDecimal(r["DoanhThu"]);
            }

            return tong;
        }
    }
}
