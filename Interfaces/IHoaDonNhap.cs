using System;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Giao diện quy định cấu trúc chung của một hóa đơn nhập hàng
    /// và khả năng tự tính tổng tiền nhập từ danh sách chi tiết.
    /// Lớp triển khai: <see cref="HoaDonNhap"/>.
    /// </summary>
    public interface IHoaDonNhap
    {
        string MaHDN { get; set; }
        string MaNV { get; set; }
        string MaNCC { get; set; }
        DateTime NgayNhap { get; set; }
        decimal TongTien { get; set; }

        /// <summary>Cộng dồn thành tiền nhập của tất cả các dòng chi tiết.</summary>
        decimal TinhTongTien();
    }
}
