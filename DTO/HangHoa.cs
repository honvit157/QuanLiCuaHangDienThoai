using System;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Mặt hàng điện thoại trong cửa hàng.
    /// Kế thừa <see cref="SanPhamBase"/> và triển khai giao diện <see cref="IHangHoa"/>.
    /// </summary>
    public class HangHoa : SanPhamBase, IHangHoa
    {
        public string? MaHangSX { get; set; }
        public string? MaLoai { get; set; }
        public string? MaMau { get; set; }
        public string? MaDungLuong { get; set; }

        /// <summary>Tên tệp ảnh trong thư mục Images/ (ví dụ SP001.jpg), rỗng nếu chưa có ảnh.</summary>
        public string? TenAnh { get; set; }

        /// <summary>Mô tả cấu hình (chip, camera...) - hiển thị trên bảng hàng.</summary>
        public string? MoTa { get; set; }

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

        public HangHoa(string maHang, string tenHang, string? maHangSX, string? maLoai,
                       string? maMau, string? maDungLuong, decimal giaNhap, decimal giaBan,
                       int soLuongTon, string? moTa)
            : this(maHang, tenHang, maHangSX, maLoai, maMau, maDungLuong, giaNhap, giaBan, soLuongTon)
        {
            MoTa = moTa;
        }

        public override string LayMoTa()
        {
            string moTa = string.IsNullOrWhiteSpace(MoTa) ? "(chưa có mô tả)" : MoTa!;
            return $"{MaHang} - {TenHang} - {moTa}";
        }
    }
}
