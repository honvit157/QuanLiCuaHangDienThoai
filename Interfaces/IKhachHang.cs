namespace QuanLyCuaHangDienThoai
{
    /// <summary>
    /// Giao diện quy định thông tin tối thiểu của một khách hàng.
    /// Lớp triển khai: <see cref="KhachHang"/>.
    /// </summary>
    public interface IKhachHang
    {
        string MaKH { get; set; }

        /// <summary>Chuỗi hiển thị nhanh "Mã - Tên (SĐT)".</summary>
        string LayThongTinRutGon();
    }
}
