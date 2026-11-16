using System;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Lớp trừu tượng cơ sở cho mọi đối tượng là "con người" trong hệ thống.
    /// Thể hiện quan hệ kế thừa (Inheritance) và tính đóng gói của OOP.
    /// Các lớp dẫn xuất: <see cref="KhachHang"/>, <see cref="NhanVien"/>.
    /// </summary>
    public abstract class Nguoi
    {
        public string HoTen { get; set; } = "";
        public string SDT { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public string GioiTinh { get; set; } = "Nam";
        public DateTime NgaySinh { get; set; } = DateTime.Today;

        protected Nguoi() { }

        protected Nguoi(string hoTen, string sdt, string diaChi, string gioiTinh, DateTime ngaySinh)
        {
            HoTen = hoTen;
            SDT = sdt;
            DiaChi = diaChi;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
        }

        /// <summary>
        /// Phương thức ảo (đa hình): lớp con có thể ghi đè để trả về cách hiển thị riêng.
        /// </summary>
        public virtual string LayThongTin()
        {
            return $"{HoTen} - SĐT: {SDT} - ĐC: {DiaChi}";
        }

        /// <summary>Tuổi hiện tại, tính theo năm.</summary>
        public int TinhTuoi()
        {
            int tuoi = DateTime.Today.Year - NgaySinh.Year;
            if (NgaySinh.Date > DateTime.Today.AddYears(-tuoi)) tuoi--;
            return tuoi > 0 ? tuoi : 0;
        }
    }
}
