using System;

namespace QuanLyCuaHangDienThoai
{
    /// <summary>
    /// Lớp trừu tượng cơ sở cho mọi mặt hàng kinh doanh (điện thoại, phụ kiện...).
    /// Chứa các thuộc tính và hành vi chung về giá cả, tồn kho.
    /// Các lớp dẫn xuất: <see cref="HangHoa"/> (và có thể mở rộng thêm PhuKien).
    /// </summary>
    public abstract class SanPhamBase
    {
        public string MaHang { get; set; } = "";
        public string TenHang { get; set; } = "";
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }

        protected SanPhamBase() { }

        protected SanPhamBase(string maHang, string tenHang, decimal giaNhap, decimal giaBan, int soLuongTon)
        {
            MaHang = maHang;
            TenHang = tenHang;
            GiaNhap = giaNhap;
            GiaBan = giaBan;
            SoLuongTon = soLuongTon;
        }

        /// <summary>Lợi nhuận gộp trên một đơn vị sản phẩm.</summary>
        public virtual decimal TinhLoiNhuan()
        {
            return GiaBan - GiaNhap;
        }

        /// <summary>Tỷ lệ lãi gộp (%) so với giá nhập.</summary>
        public virtual decimal TinhTyLeLoiNhuan()
        {
            return GiaNhap <= 0 ? 0 : Math.Round((GiaBan - GiaNhap) / GiaNhap * 100m, 2);
        }

        /// <summary>Giá trị hàng đang nằm trong kho theo giá bán.</summary>
        public decimal TinhGiaTriTon()
        {
            return GiaBan * SoLuongTon;
        }

        /// <summary>Dòng mô tả ngắn, lớp con có thể ghi đè.</summary>
        public virtual string LayMoTa()
        {
            return $"{MaHang} - {TenHang}";
        }
    }
}
