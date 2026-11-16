using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Lớp tiện ích dùng chung (utility class) gồm các class method tĩnh:
    /// kiểm tra dữ liệu đầu vào, định dạng tiền - ngày, đọc số tiền người dùng nhập,
    /// chuẩn hóa chuỗi tìm kiếm, ghi nhật ký thao tác và hiển thị thông báo thống nhất.
    /// </summary>
    public static class AppHelpers
    {
        /// <summary>Culture Việt Nam dùng để định dạng số và ngày.</summary>
        public static readonly CultureInfo ViVn = new CultureInfo("vi-VN");

        // ------------------------------------------------------------------
        // 1. Kiểm tra dữ liệu (validation)
        // ------------------------------------------------------------------

        /// <summary>Kiểm tra số điện thoại Việt Nam: đúng 10 chữ số và bắt đầu bằng số 0.</summary>
        public static bool KiemTraSoDienThoai(string? sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt)) return false;
            return Regex.IsMatch(sdt.Trim(), @"^0\d{9}$");
        }

        /// <summary>Kiểm tra định dạng email (chuỗi rỗng vẫn được coi là hợp lệ).</summary>
        public static bool KiemTraEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email)) return true;
            return Regex.IsMatch(email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        /// <summary>Kiểm tra một chuỗi có phải số nguyên không âm hay không.</summary>
        public static bool KiemTraSoNguyenKhongAm(string? chuoi, out int giaTri)
        {
            giaTri = 0;
            if (string.IsNullOrWhiteSpace(chuoi)) return false;
            return int.TryParse(chuoi.Trim(), out giaTri) && giaTri >= 0;
        }

        // ------------------------------------------------------------------
        // 2. Định dạng và đọc số tiền
        // ------------------------------------------------------------------

        /// <summary>Định dạng số tiền theo kiểu Việt Nam: 32.000.000.</summary>
        public static string DinhDangTien(decimal tien)
        {
            return tien.ToString("N0", ViVn);
        }

        /// <summary>Định dạng số tiền kèm đơn vị: 32.000.000 ₫.</summary>
        public static string DinhDangTienVnd(decimal tien)
        {
            return DinhDangTien(tien) + " ₫";
        }

        /// <summary>Định dạng ngày theo dd/MM/yyyy.</summary>
        public static string DinhDangNgay(DateTime ngay)
        {
            return ngay.ToString("dd/MM/yyyy", ViVn);
        }

        /// <summary>
        /// Đọc số tiền do người dùng nhập, chấp nhận cả chuỗi có dấu phân cách nghìn
        /// ("32.000.000") hoặc có đơn vị ("32.000.000 VNĐ").
        /// </summary>
        public static bool DocSoTien(string? chuoi, out decimal giaTri)
        {
            giaTri = 0;
            if (string.IsNullOrWhiteSpace(chuoi)) return false;

            StringBuilder sb = new StringBuilder();

            foreach (char c in chuoi.Trim())
            {
                if (char.IsDigit(c)) sb.Append(c);
            }

            if (sb.Length == 0) return false;

            return decimal.TryParse(sb.ToString(), NumberStyles.Number,
                CultureInfo.InvariantCulture, out giaTri);
        }

        // ------------------------------------------------------------------
        // 3. Chuẩn hóa chuỗi phục vụ tìm kiếm
        // ------------------------------------------------------------------

        /// <summary>Cắt khoảng trắng thừa ở hai đầu và gộp nhiều khoảng trắng ở giữa.</summary>
        public static string ChuanHoaChuoi(string? chuoi)
        {
            if (string.IsNullOrWhiteSpace(chuoi)) return "";
            return Regex.Replace(chuoi.Trim(), @"\s+", " ");
        }

        /// <summary>
        /// Chuẩn hóa từ khóa để đưa vào bộ lọc RowFilter của DataView:
        /// bỏ khoảng trắng thừa và nhân đôi dấu nháy đơn để tránh lỗi cú pháp.
        /// </summary>
        public static string TaoTuKhoaTimKiem(string? tuKhoa)
        {
            string s = ChuanHoaChuoi(tuKhoa);
            return s.Replace("'", "''");
        }

        // ------------------------------------------------------------------
        // 4. Nhật ký thao tác (ghi log ra tệp)
        // ------------------------------------------------------------------

        /// <summary>
        /// Ghi một dòng nhật ký vào thư mục Logs cạnh tệp chạy.
        /// Lỗi ghi log được bỏ qua để không ảnh hưởng nghiệp vụ chính.
        /// </summary>
        public static void GhiLog(string noiDung)
        {
            try
            {
                string thuMuc = Path.Combine(Application.StartupPath, "Logs");
                Directory.CreateDirectory(thuMuc);

                string tep = Path.Combine(thuMuc, "app-" + DateTime.Now.ToString("yyyyMMdd") + ".log");
                string dong = $"[{DateTime.Now:HH:mm:ss}] {noiDung}{Environment.NewLine}";

                File.AppendAllText(tep, dong, Encoding.UTF8);
            }
            catch
            {
                // Ghi log là chức năng phụ.
            }
        }

        // ------------------------------------------------------------------
        // 5. Thông báo thống nhất
        // ------------------------------------------------------------------

        public static void HienThongBao(string noiDung)
        {
            MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void HienCanhBao(string noiDung)
        {
            MessageBox.Show(noiDung, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>Hỏi xác nhận, trả về true nếu người dùng chọn Có.</summary>
        public static bool XacNhan(string noiDung)
        {
            return MessageBox.Show(noiDung, "Xác nhận", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        // ------------------------------------------------------------------
        // 6. Tiện ích tệp ảnh sản phẩm
        // ------------------------------------------------------------------

        /// <summary>Thư mục lưu ảnh sản phẩm: &lt;thư mục chạy&gt;\Images.</summary>
        public static string ThuMucAnh => Path.Combine(Application.StartupPath, "Images");

        /// <summary>
        /// Sao chép ảnh người dùng chọn vào thư mục Images của ứng dụng
        /// và trả về tên tệp để lưu vào cơ sở dữ liệu.
        /// </summary>
        public static string SaoChepAnh(string duongDanNguon)
        {
            Directory.CreateDirectory(ThuMucAnh);

            string ten = Path.GetFileName(duongDanNguon);
            string dich = Path.Combine(ThuMucAnh, ten);

            if (!string.Equals(Path.GetFullPath(duongDanNguon), Path.GetFullPath(dich),
                               StringComparison.OrdinalIgnoreCase))
            {
                File.Copy(duongDanNguon, dich, true);
            }

            return ten;
        }
    }
}
