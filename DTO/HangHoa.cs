using System;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Mặt hàng điện thoại của cửa hàng: kế thừa <see cref="SanPhamBase"/>
    /// và triển khai giao diện <see cref="IHangHoa"/>.
    /// </summary>
    public class HangHoa : SanPhamBase, IHangHoa
    {
        public string TenAnh { get; set; } = "";
        public string? MaHangSX { get; set; }
        public string? MaLoai { get; set; }
        public string? MaMau { get; set; }
        public string? MaDungLuong { get; set; }

        public HangHoa() { }

        public HangHoa(string maHang, string tenHang, string? maHangSX, string? maLoai,
                       string? maMau, string? maDungLuong, decimal giaNhap, decimal giaBan, int soLuongTon)
            : base(maHang, tenHang, giaNhap, giaBan, soLuongTon)
        {
            MaHangSX = maHangSX;
            MaLoai = maLoai;
            MaMau = maMau;
            MaDungLuong = maDungLuong;
        }

        /// <summary>Ghi đè cách mô tả: kèm hãng và dung lượng để dễ đọc.</summary>
        public override string LayMoTa()
        {
            return $"{MaHang} - {TenHang} ({MaDungLuong})";
        }
    }
}
