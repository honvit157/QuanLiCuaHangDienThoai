namespace QuanLyCuaHangDienThoai
{
    /// <summary>
    /// Nhà cung cấp hàng hóa. Triển khai giao diện <see cref="INhaCungCap"/>.
    /// </summary>
    public class NhaCungCap : INhaCungCap
    {
        public string MaNCC { get; set; } = "";
        public string TenNCC { get; set; } = "";
        public string SDT { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public string Email { get; set; } = "";
        public string NguoiLH { get; set; } = "";

        public NhaCungCap() { }

        public NhaCungCap(string maNCC, string tenNCC, string sdt, string diaChi)
            : this(maNCC, tenNCC, sdt, diaChi, "", "")
        {
        }

        public NhaCungCap(string maNCC, string tenNCC, string sdt, string diaChi,
                          string email, string nguoiLH)
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            SDT = sdt;
            DiaChi = diaChi;
            Email = email;
            NguoiLH = nguoiLH;
        }

        public string LayThongTinLienHe()
        {
            return $"{TenNCC} - Hotline: {SDT} - Email: {Email} - Người liên hệ: {NguoiLH}";
        }
    }
}
