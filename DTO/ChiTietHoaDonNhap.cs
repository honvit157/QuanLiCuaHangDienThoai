namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Một dòng chi tiết của hóa đơn nhập hàng.
    /// </summary>
    public class ChiTietHoaDonNhap
    {
        public string MaHDN { get; set; } = "";
        public string MaHang { get; set; } = "";
        public string TenHang { get; set; } = "";
        public int SoLuong { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal ThanhTien { get; set; }

        public ChiTietHoaDonNhap() { }

        public ChiTietHoaDonNhap(string maHDN, string maHang, string tenHang,
                                 int soLuong, decimal donGiaNhap)
        {
            MaHDN = maHDN;
            MaHang = maHang;
            TenHang = tenHang;
            SoLuong = soLuong;
            DonGiaNhap = donGiaNhap;
            ThanhTien = soLuong * donGiaNhap;
        }
    }
}
