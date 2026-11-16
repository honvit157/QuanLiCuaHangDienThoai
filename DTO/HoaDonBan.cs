using System;
using System.Collections.Generic;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Hóa đơn bán hàng: kế thừa <see cref="ChungTuBase"/> và triển khai
    /// giao diện <see cref="IHoaDon"/>. Chứa danh sách chi tiết hóa đơn
    /// (quan hệ kết tập - Composition).
    /// </summary>
    public class HoaDonBan : ChungTuBase, IHoaDon
    {
        public string MaHD
        {
            get => MaChungTu;
            set => MaChungTu = value;
        }

        public string MaKH { get; set; } = "";

        /// <summary>Trạng thái thanh toán: Chưa thanh toán / Đã thanh toán / Chờ xác nhận chuyển khoản.</summary>
        public string TrangThaiThanhToan { get; set; } = "Chưa thanh toán";

        /// <summary>Phương thức thanh toán: Tiền mặt / Chuyển khoản.</summary>
        public string? PhuongThucThanhToan { get; set; }

        /// <summary>Danh sách chi tiết hóa đơn (quan hệ kết tập - Composition).</summary>
        public List<ChiTietHoaDonBan> ChiTietList { get; set; } = new List<ChiTietHoaDonBan>();

        public HoaDonBan() { }

        public HoaDonBan(string maHD, string maNV, string maKH, DateTime ngayLap)
            : base(maHD, maNV, ngayLap)
        {
            MaKH = maKH;
        }

        public override decimal TinhTongTien()
        {
            decimal tong = 0;

            foreach (ChiTietHoaDonBan item in ChiTietList)
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
}
