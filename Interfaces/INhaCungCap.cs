namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Giao diện quy định thông tin của nhà cung cấp.
    /// Lớp triển khai: <see cref="NhaCungCap"/>.
    /// </summary>
    public interface INhaCungCap
    {
        string MaNCC { get; set; }
        string TenNCC { get; set; }
        string SDT { get; set; }
        string DiaChi { get; set; }

        /// <summary>Chuỗi hiển thị thông tin liên hệ của nhà cung cấp.</summary>
        string LayThongTinLienHe();
    }
}
