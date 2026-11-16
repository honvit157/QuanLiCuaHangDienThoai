namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Giao diện chung cho hóa đơn nhập hàng từ nhà cung cấp.
    /// Lớp triển khai: <see cref="HoaDonNhap"/>.
    /// </summary>
    public interface IHoaDonNhap
    {
        string MaHDN { get; set; }
        string MaNV { get; set; }
        System.DateTime NgayNhap { get; set; }
        decimal TongTien { get; set; }

        decimal TinhTongTien();
    }
}
