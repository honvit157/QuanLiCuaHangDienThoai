namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Một dòng chi tiết của hóa đơn bán hàng.
    /// </summary>
    public class ChiTietHoaDonBan
    {
        public string MaHDB { get; set; } = "";
        public string MaHang { get; set; } = "";
        public string TenHang { get; set; } = "";
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThanhTien { get; set; }

        public ChiTietHoaDonBan() { }

        public ChiTietHoaDonBan(string maHDB, string maHang, string tenHang, int soLuong,
                                decimal donGia, decimal giamGia)
        {
            MaHDB = maHDB;
            MaHang = maHang;
            TenHang = tenHang;
            SoLuong = soLuong;
            DonGia = donGia;
            GiamGia = giamGia;
            TinhThanhTien();
        }

        /// <summary>Tính thành tiền = đơn giá × số lượng × (100 - giảm giá)/100.</summary>
        public decimal TinhThanhTien()
        {
            ThanhTien = SoLuong * DonGia * (100 - GiamGia) / 100m;
            return ThanhTien;
        }
    }

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

        public ChiTietHoaDonNhap(string maHDN, string maHang, string tenHang, int soLuong, decimal donGiaNhap)
        {
            MaHDN = maHDN;
            MaHang = maHang;
            TenHang = tenHang;
            SoLuong = soLuong;
            DonGiaNhap = donGiaNhap;
            TinhThanhTien();
        }

        public decimal TinhThanhTien()
        {
            ThanhTien = SoLuong * DonGiaNhap;
            return ThanhTien;
        }
    }
}
