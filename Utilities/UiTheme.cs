using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai
{
    /// <summary>
    /// Bảng màu và kiểu chữ dùng chung cho toàn bộ biểu mẫu WinForms.
    /// Mọi Form*.Designer.cs chỉ tham chiếu tới các hằng số ở đây để giao diện
    /// đồng bộ: một màu chủ đạo (navy), nền sáng, chữ xanh đậm, lưới kẻ mảnh.
    /// Đổi màu ở một chỗ là đổi cho cả 11 biểu mẫu.
    /// </summary>
    internal static class UiTheme
    {
        // ------------------------------------------------------------------
        // Màu sắc
        // ------------------------------------------------------------------

        /// <summary>Màu chủ đạo (navy) - thanh menu, tiêu đề, nút chính.</summary>
        public static readonly Color Chinh = Color.FromArgb(31, 58, 95);

        /// <summary>Màu nhấn (xanh sáng) - nút phụ, dòng đang chọn.</summary>
        public static readonly Color Nhan = Color.FromArgb(46, 134, 222);

        /// <summary>Nền biểu mẫu (xám xanh rất nhạt).</summary>
        public static readonly Color Nen = Color.FromArgb(244, 246, 250);

        /// <summary>Nền thẻ: GroupBox, Panel, DataGridView.</summary>
        public static readonly Color The = Color.White;

        /// <summary>Màu chữ chính.</summary>
        public static readonly Color Chu = Color.FromArgb(34, 49, 63);

        /// <summary>Màu chữ phụ (ghi chú, hướng dẫn).</summary>
        public static readonly Color ChuPhu = Color.FromArgb(107, 124, 147);

        /// <summary>Màu đường viền, lưới kẻ.</summary>
        public static readonly Color Vien = Color.FromArgb(214, 222, 232);

        /// <summary>Màu cảnh báo / nút nguy hiểm (Xóa, Hủy).</summary>
        public static readonly Color NguyHiem = Color.FromArgb(231, 76, 60);

        /// <summary>Màu thành công / nút lưu, xuất.</summary>
        public static readonly Color ThanhCong = Color.FromArgb(39, 174, 96);

        /// <summary>Nền nút phụ (xám nhạt).</summary>
        public static readonly Color NutNhat = Color.FromArgb(233, 238, 245);

        /// <summary>Nền nút phụ khi rê chuột.</summary>
        public static readonly Color NutNhatHover = Color.FromArgb(219, 227, 238);

        /// <summary>Màu dòng xen kẽ của DataGridView.</summary>
        public static readonly Color DongXen = Color.FromArgb(242, 246, 252);

        /// <summary>Nền dòng đang chọn trên DataGridView.</summary>
        public static readonly Color ChonDong = Color.FromArgb(219, 233, 249);

        /// <summary>Màu nút chính khi rê chuột / khi bấm.</summary>
        public static readonly Color ChinhHover = Color.FromArgb(42, 79, 127);
        public static readonly Color ChinhDown = Color.FromArgb(21, 43, 72);

        /// <summary>Màu nút phụ (xanh sáng) khi rê chuột / khi bấm.</summary>
        public static readonly Color NhanHover = Color.FromArgb(58, 148, 233);
        public static readonly Color NhanDown = Color.FromArgb(36, 113, 190);

        /// <summary>Màu nút thành công khi rê chuột / khi bấm.</summary>
        public static readonly Color ThanhCongHover = Color.FromArgb(46, 190, 108);
        public static readonly Color ThanhCongDown = Color.FromArgb(31, 148, 80);

        /// <summary>Màu nút nguy hiểm khi rê chuột / khi bấm.</summary>
        public static readonly Color NguyHiemHover = Color.FromArgb(238, 96, 80);
        public static readonly Color NguyHiemDown = Color.FromArgb(198, 58, 44);

        // ------------------------------------------------------------------
        // Kiểu chữ (Segoe UI - font hệ thống của Windows 10/11)
        // ------------------------------------------------------------------

        /// <summary>Chữ nội dung 9pt - font nền của biểu mẫu.</summary>
        public static readonly Font Than = new Font("Segoe UI", 9F);

        /// <summary>Chữ tiêu đề biểu mẫu 15pt đậm.</summary>
        public static readonly Font TieuDe = new Font("Segoe UI Semibold", 15F);

        /// <summary>Chữ tiêu đề khung (GroupBox) 9pt đậm vừa.</summary>
        public static readonly Font TieuDeMuc = new Font("Segoe UI Semibold", 9F);

        /// <summary>Chữ tiêu đề mục 11pt đậm.</summary>
        public static readonly Font TieuDeNho = new Font("Segoe UI Semibold", 11F);

        /// <summary>Chữ trên nút bấm 9pt đậm.</summary>
        public static readonly Font Nut = new Font("Segoe UI", 9F, FontStyle.Bold);

        /// <summary>Chữ trong lưới 9pt.</summary>
        public static readonly Font Luoi = new Font("Segoe UI", 9F);

        /// <summary>Chữ tiêu đề cột của lưới 9pt đậm.</summary>
        public static readonly Font LuoiTieuDe = new Font("Segoe UI", 9F, FontStyle.Bold);

        /// <summary>Chữ nhấn 9pt đậm (dòng trạng thái, tổng tiền).</summary>
        public static readonly Font Nhan = new Font("Segoe UI", 9F, FontStyle.Bold);

        // ------------------------------------------------------------------
        // Kiểu nút dùng cho TrangTriNut
        // ------------------------------------------------------------------
        public enum KieuNut
        {
            /// <summary>Nút chính (Thêm, Lưu, Đăng nhập) - nền navy.</summary>
            Chinh,

            /// <summary>Nút phụ (Sửa, Tìm, Làm mới) - nền xanh sáng.</summary>
            Nhan,

            /// <summary>Nút thành công (Lưu, Xuất Excel) - nền xanh lá.</summary>
            ThanhCong,

            /// <summary>Nút nguy hiểm (Xóa, Hủy) - nền đỏ.</summary>
            NguyHiem,

            /// <summary>Nút trung tính (Thoát, Làm lại) - nền xám nhạt.</summary>
            Nhat
        }

        // ------------------------------------------------------------------
        // Hàm tiện ích cho các form viết tay (FormBaoCao) - Designer.cs gọi trực tiếp
        // ------------------------------------------------------------------

        /// <summary>Áp kiểu chung cho một nút bấm theo vai trò.</summary>
        public static void TrangTriNut(Button nut, KieuNut kieu)
        {
            Color nen, chu, hover, down;

            switch (kieu)
            {
                case KieuNut.Nhan:
                    nen = Nhan; chu = Color.White; hover = NhanHover; down = NhanDown;
                    break;
                case KieuNut.ThanhCong:
                    nen = ThanhCong; chu = Color.White; hover = ThanhCongHover; down = ThanhCongDown;
                    break;
                case KieuNut.NguyHiem:
                    nen = NguyHiem; chu = Color.White; hover = NguyHiemHover; down = NguyHiemDown;
                    break;
                case KieuNut.Nhat:
                    nen = NutNhat; chu = Chinh; hover = NutNhatHover; down = Vien;
                    break;
                default:
                    nen = Chinh; chu = Color.White; hover = ChinhHover; down = ChinhDown;
                    break;
            }

            nut.BackColor = nen;
            nut.ForeColor = chu;
            nut.Font = Nut;
            nut.Cursor = Cursors.Hand;
            nut.FlatStyle = FlatStyle.Flat;
            nut.UseVisualStyleBackColor = false;
            nut.FlatAppearance.BorderSize = 0;
            nut.FlatAppearance.MouseOverBackColor = hover;
            nut.FlatAppearance.MouseDownBackColor = down;
        }

        /// <summary>Áp kiểu chung cho DataGridView: tiêu đề navy, dòng xen kẽ, lưới mảnh.</summary>
        public static void TrangTriLuoi(DataGridView luoi)
        {
            luoi.Font = Luoi;
            luoi.BackgroundColor = The;
            luoi.BorderStyle = BorderStyle.None;
            luoi.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            luoi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            luoi.GridColor = Vien;
            luoi.RowHeadersVisible = false;
            luoi.RowTemplate.Height = 30;
            luoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            luoi.EnableHeadersVisualStyles = false;
            luoi.ColumnHeadersDefaultCellStyle.BackColor = Chinh;
            luoi.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            luoi.ColumnHeadersDefaultCellStyle.SelectionBackColor = Chinh;
            luoi.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            luoi.ColumnHeadersDefaultCellStyle.Font = LuoiTieuDe;
            luoi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            luoi.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);

            luoi.DefaultCellStyle.BackColor = The;
            luoi.DefaultCellStyle.ForeColor = Chu;
            luoi.DefaultCellStyle.SelectionBackColor = ChonDong;
            luoi.DefaultCellStyle.SelectionForeColor = Chinh;
            luoi.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);

            luoi.AlternatingRowsDefaultCellStyle.BackColor = DongXen;
        }
    }
}
