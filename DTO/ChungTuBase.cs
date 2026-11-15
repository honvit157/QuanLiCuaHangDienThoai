using System.Collections.Generic;

namespace QuanLyCuaHangDienThoai
{
    /// <summary>
    /// Lớp trừu tượng cơ sở cho mọi chứng từ phát sinh trong cửa hàng
    /// (hóa đơn bán hàng, hóa đơn nhập hàng).
    /// Các lớp dẫn xuất: <see cref="HoaDonBan"/>, <see cref="HoaDonNhap"/>.
    /// </summary>
    public abstract class ChungTuBase
    {
        public string MaChungTu { get; set; } = "";
        public string MaNV { get; set; } = "";
        public System.DateTime NgayLap { get; set; } = System.DateTime.Now;
        public decimal TongTien { get; set; }

        protected ChungTuBase() { }

        protected ChungTuBase(string maChungTu, string maNV, System.DateTime ngayLap)
        {
            MaChungTu = maChungTu;
            MaNV = maNV;
            NgayLap = ngayLap;
        }

        /// <summary>
        /// Lớp con buộc phải cài đặt cách tính tổng tiền của loại chứng từ đó.
        /// </summary>
        public abstract decimal TinhTongTien();

        /// <summary>
        /// Sinh mã chứng từ theo mẫu tiền tố + thời gian, ví dụ HDB_20261115143012001.
        /// </summary>
        protected static string SinhMa(string tienTo)
        {
            return tienTo + System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        public virtual string LayThongTinChung()
        {
            return $"{MaChungTu} - ngày {NgayLap:dd/MM/yyyy} - tổng {TongTien:N0} VNĐ";
        }
    }

    /// <summary>
    /// Hóa đơn bán hàng là một chứng từ và chứa danh sách chi tiết (quan hệ kết tập).
    /// </summary>
    public class HoaDonBan : ChungTuBase, IHoaDon
    {
        public string MaHD
        {
            get => MaChungTu;
            set => MaChungTu = value;
        }

        public string MaKH { get; set; } = "";

        /// <summary>Danh sách chi tiết hóa đơn (quan hệ kết tập - Composition).</summary>
        public List<ChiTietHoaDonBan> ChiTietList { get; set; } = new List<ChiTietHoaDonBan>();

        public HoaDonBan() { }

        public HoaDonBan(string maHD, string maNV, string maKH, System.DateTime ngayLap)
            : base(maHD, maNV, ngayLap)
        {
            MaHD = maHD;
            MaKH = maKH;
            NgayLap = ngayLap;
        }

        public override decimal TinhTongTien()
        {
            decimal tong = 0;
            foreach (var item in ChiTietList)
            {
                tong += item.ThanhTien;
            }
            TongTien = tong;
            return tong;
        }

        public static string TaoMaMoi()
        {
            return SinhMa("HDB_");
        }
    }

    /// <summary>
    /// Hóa đơn nhập hàng từ nhà cung cấp.
    /// </summary>
    public class HoaDonNhap : ChungTuBase
    {
        public string MaHDN
        {
            get => MaChungTu;
            set => MaChungTu = value;
        }

        public string MaNCC { get; set; } = "";

        /// <summary>Danh sách chi tiết nhập hàng (quan hệ kết tập - Composition).</summary>
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
            foreach (var item in ChiTietList)
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
