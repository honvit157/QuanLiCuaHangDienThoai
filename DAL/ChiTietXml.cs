using System.Data;
using System.Text;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Chuyển bảng chi tiết hóa đơn (DataTable đang hiển thị trên lưới)
    /// thành chuỗi XML để truyền vào thủ tục lưu trữ chỉ bằng một tham số.
    /// Nhờ đó tầng DAL không phải phát sinh nhiều lần gọi SQL cho từng dòng.
    /// </summary>
    public static class ChiTietXml
    {
        /// <summary>
        /// Sinh XML dạng &lt;ChiTiet&gt;&lt;Dong MaHang="..." /&gt;&lt;/ChiTiet&gt;.
        /// </summary>
        public static string TaoTuBang(
            DataTable bang,
            string cotMaHang,
            string cotSoLuong,
            string cotDonGia,
            string? cotGiamGia,
            string cotThanhTien)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ChiTiet>");

            foreach (DataRow row in bang.Rows)
            {
                sb.Append("<Dong");
                sb.Append(" MaHang=\"").Append(Chuoi(row[cotMaHang])).Append('"');
                sb.Append(" SoLuong=\"").Append(So(row[cotSoLuong])).Append('"');
                sb.Append(" DonGia=\"").Append(So(row[cotDonGia])).Append('"');
                sb.Append(" GiamGia=\"").Append(
                    cotGiamGia == null ? "0" : So(row[cotGiamGia])).Append('"');
                sb.Append(" ThanhTien=\"").Append(So(row[cotThanhTien])).Append('"');
                sb.Append("/>");
            }

            sb.Append("</ChiTiet>");
            return sb.ToString();
        }

        /// <summary>Đọc một ô dạng chuỗi, bỏ ký tự XML không hợp lệ.</summary>
        private static string Chuoi(object giaTri)
        {
            if (giaTri == null || giaTri == System.DBNull.Value)
                return "";

            return System.Security.SecurityElement.Escape(giaTri.ToString() ?? "") ?? "";
        }

        /// <summary>Đọc một ô dạng số, dùng dấu chấm thập phân để SQL Server hiểu đúng.</summary>
        private static string So(object giaTri)
        {
            if (giaTri == null || giaTri == System.DBNull.Value)
                return "0";

            decimal so = System.Convert.ToDecimal(giaTri);
            return so.ToString("0.####", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
