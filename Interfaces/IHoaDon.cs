using System;

namespace QuanLyCuaHangDienThoai
{
    /// <summary>
    /// Giao diện quy định cấu trúc chung của một hóa đơn bán hàng
    /// và khả năng tự tính tổng tiền từ danh sách chi tiết.
    /// Lớp triển khai: <see cref="HoaDonBan"/>.
    /// </summary>
    public interface IHoaDon
    {
        string MaHD { get; set; }
        string MaNV { get; set; }
        string MaKH { get; set; }
        DateTime NgayLap { get; set; }
        decimal TongTien { get; set; }

        /// <summary>Cộng dồn thành tiền của tất cả các dòng chi tiết.</summary>
        decimal TinhTongTien();
    }
}
