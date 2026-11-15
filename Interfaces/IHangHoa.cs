namespace QuanLyCuaHangDienThoai
{
    /// <summary>
    /// Giao diện (Interface) quy định mọi mặt hàng trong cửa hàng phải có
    /// mã, tên, giá nhập, giá bán, số lượng tồn và biết tự tính lợi nhuận.
    /// Lớp triển khai: <see cref="HangHoa"/>.
    /// </summary>
    public interface IHangHoa
    {
        string MaHang { get; set; }
        string TenHang { get; set; }
        string? MaHangSX { get; set; }
        string? MaLoai { get; set; }
        string? MaMau { get; set; }
        string? MaDungLuong { get; set; }
        decimal GiaNhap { get; set; }
        decimal GiaBan { get; set; }
        int SoLuongTon { get; set; }

        /// <summary>Lợi nhuận gộp của một đơn vị hàng hóa.</summary>
        decimal TinhLoiNhuan();
    }
}
