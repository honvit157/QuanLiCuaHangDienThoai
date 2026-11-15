using System;

namespace QuanLyCuaHangDienThoai
{
    /// <summary>
    /// Khách hàng của cửa hàng. Kế thừa <see cref="Nguoi"/> và triển khai <see cref="IKhachHang"/>.
    /// </summary>
    public class KhachHang : Nguoi, IKhachHang
    {
        public string MaKH { get; set; } = "";
        public string Email { get; set; } = "";

        public KhachHang() { }

        public KhachHang(string maKH, string tenKH, string sdt, string diaChi)
            : this(maKH, tenKH, sdt, diaChi, "")
        {
        }

        public KhachHang(string maKH, string tenKH, string sdt, string diaChi, string email)
            : base(tenKH, sdt, diaChi, "Khác", DateTime.Today)
        {
            MaKH = maKH;
            Email = email;
        }

        public string LayThongTinRutGon()
        {
            return $"{MaKH} - {HoTen} ({SDT})";
        }

        public override string LayThongTin()
        {
            return $"[KH] {LayThongTinRutGon()} - ĐC: {DiaChi}";
        }
    }
}
