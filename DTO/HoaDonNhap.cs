using System.Collections.Generic;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Hóa đơn nhập hàng từ nhà cung cấp: kế thừa <see cref="ChungTuBase"/>
    /// và triển khai giao diện <see cref="IHoaDonNhap"/>.
    /// Chứa danh sách chi tiết nhập hàng (quan hệ kết tập - Composition).
    /// </summary>
    public class HoaDonNhap : ChungTuBase, IHoaDonNhap
    {
        public string MaHDN
        {
            get => MaChungTu;
            set => MaChungTu = value;
        }

        public string MaNCC { get; set; } = "";

        /// <summary>Ngày nhập hàng: cùng mốc thời gian với NgayLap của lớp cơ sở.</summary>
        public System.DateTime NgayNhap
        {
            get => NgayLap;
            set => NgayLap = value;
        }

        public List<ChiTietHoaDonNhap> ChiTietList { get; set; } = new List<ChiTietHoaDonNhap>();

        public HoaDonNhap() { }

        public HoaDonNhap(string maHDN, string maNV, string maNCC, System.DateTime ngayNhap)
            : base(maHDN, maNV, ngayNhap)
        {
            MaHDN = maHDN;
            MaNCC = maNCC;
        }

        public override decimal TinhTongTien()
        {
            decimal tong = 0;

            foreach (ChiTietHoaDonNhap item in ChiTietList)
            {
                tong += item.ThanhTien;
            }

            TongTien = tong;
            return tong;
        }

        public static string TaoMaMoi()
        {
            return SinhMa("HDN_");
        }
    }
}
