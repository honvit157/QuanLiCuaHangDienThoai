using System;
using System.Data;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng nghiệp vụ cho màn hình Tổng quan (Form10).
    /// Lấy số liệu qua <see cref="ThongKeDAL"/> và định dạng sẵn để giao diện hiển thị.
    /// </summary>
    public class ThongKeBUS
    {
        private readonly ThongKeDAL dal = new ThongKeDAL();

        public int TongSanPham() => dal.DemTongSanPham();

        public int TongKhachHang() => dal.DemTongKhachHang();

        public int HoaDonHomNay() => dal.DemHoaDonHomNay();

        public decimal DoanhThuHomNay() => dal.TinhDoanhThuHomNay();

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

        /// <summary>Tổng doanh thu của 7 ngày gần nhất (dòng mô tả dưới biểu đồ).</summary>
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
