using System;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Lớp trừu tượng cơ sở cho mọi chứng từ phát sinh tại cửa hàng
    /// (hóa đơn bán hàng, hóa đơn nhập hàng). Quy định phần chung:
    /// mã chứng từ, nhân viên lập, ngày lập, tổng tiền.
    /// Lớp dẫn xuất: <see cref="HoaDonBan"/>, <see cref="HoaDonNhap"/>.
    /// </summary>
    public abstract class ChungTuBase
    {
        /// <summary>Mã chung của chứng từ; lớp con đặt bí danh riêng (MaHD, MaHDN).</summary>
        public string MaChungTu { get; set; } = "";
        public string MaNV { get; set; } = "";
        public DateTime NgayLap { get; set; } = DateTime.Now;
        public decimal TongTien { get; set; }

        protected ChungTuBase() { }

        protected ChungTuBase(string maChungTu, string maNV, DateTime ngayLap)
        {
            MaChungTu = maChungTu;
            MaNV = maNV;
            NgayLap = ngayLap;
        }

        /// <summary>Lớp con buộc phải cài đặt cách tính tổng tiền của loại chứng từ đó.</summary>
        public abstract decimal TinhTongTien();

        /// <summary>Sinh mã chứng từ theo mẫu tiền tố + thời gian, ví dụ HDB_20261115143012001.</summary>
        protected static string SinhMa(string tienTo)
        {
            return tienTo + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        /// <summary>Dòng mô tả chung của chứng từ.</summary>
        public virtual string LayThongTinChung()
        {
            return $"{MaChungTu} - ngày {NgayLap:dd/MM/yyyy} - tổng {TongTien:N0} VNĐ";
        }
    }
}
