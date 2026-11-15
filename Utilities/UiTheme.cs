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

        /// <summary>Chữ nội dung 9pt - font nền của biểu mẫu.
        /// Xem thêm ghi chú DPI ở cuối tệp: AutoScaleDimensions của mọi form phải là
        /// (7, 15) vì đó là số đo của Segoe UI 9pt ở 96 DPI.</summary>
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

        /// <summary>Chữ nhấn 9pt đậm (dòng trạng thái, tổng tiền).
        /// Đặt tên NhanDam để không trùng với màu Nhan ở phía trên (lỗi CS0102).</summary>
        public static readonly Font NhanDam = new Font("Segoe UI", 9F, FontStyle.Bold);

        // ------------------------------------------------------------------
        // Kiểu nút dùng cho TrangTriNut
        // Chỉ có 3 vai trò để giao diện không bị "loạn màu":
        //   Chinh    - hành động chính (Thêm, Sửa, Tìm, Lưu, In, Xuất, Đăng nhập)
        //   NguyHiem - hành động nguy hiểm (Xóa)
        //   Nhat     - nút phụ (Làm lại, Thoát, Hủy, Chọn ảnh, Đóng)
        // Màu nhấn UiTheme.Nhan KHÔNG dùng làm màu nền nút nữa.
        // ------------------------------------------------------------------
        public enum KieuNut
        {
            /// <summary>Nút chính (Thêm, Sửa, Tìm, Lưu, In) - nền navy.</summary>
            Chinh,

            /// <summary>Nút nguy hiểm (Xóa) - nền đỏ.</summary>
            NguyHiem,

            /// <summary>Nút phụ (Làm lại, Thoát, Hủy) - nền trắng, chữ navy, viền xám nhạt.</summary>
            Nhat
        }

        // ------------------------------------------------------------------
        // Hàm tiện ích cho các form viết tay (FormBaoCao) - Designer.cs gọi trực tiếp
        // ------------------------------------------------------------------

        /// <summary>Áp kiểu chung cho một nút bấm theo vai trò.</summary>
        public static void TrangTriNut(Button nut, KieuNut kieu)
        {
            Color nen, chu, hover, down;
            int vienDay;

            switch (kieu)
            {
                case KieuNut.NguyHiem:
                    nen = NguyHiem; chu = Color.White; hover = NguyHiemHover; down = NguyHiemDown;
                    vienDay = 0;
                    break;
                case KieuNut.Nhat:
                    // nút phụ: nền trắng, chữ navy, viền mảnh để không bị chìm vào nền
                    nen = The; chu = Chinh; hover = NutNhat; down = NutNhatHover;
                    vienDay = 1;
                    break;
                default:
                    nen = Chinh; chu = Color.White; hover = ChinhHover; down = ChinhDown;
                    vienDay = 0;
                    break;
            }

            nut.BackColor = nen;
            nut.ForeColor = chu;
            nut.Font = Nut;
            nut.Cursor = Cursors.Hand;
            nut.FlatStyle = FlatStyle.Flat;
            nut.UseVisualStyleBackColor = false;
            nut.FlatAppearance.BorderSize = vienDay;
            nut.FlatAppearance.BorderColor = Vien;
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

        // ------------------------------------------------------------------
        // GHI CHÚ QUAN TRỌNG VỀ DPI / TỰ CO GIÃN
        // ------------------------------------------------------------------
        // Mọi Form*.Designer.cs dùng:
        //     AutoScaleMode = AutoScaleMode.Font;
        //     AutoScaleDimensions = new SizeF(7F, 15F);
        // (7, 15) là số đo thực của Segoe UI 9pt ở 96 DPI (đúng giá trị Visual Studio
        // sinh ra cho font mặc định này). Nếu để sai, ví dụ (8, 20), WinForms coi như
        // form được thiết kế với font to hơn nên thu nhỏ toàn bộ control còn khoảng
        // 0,75 - 0,875 lần khi chạy: giao diện dồn về góc trái trên, chừa khoảng trống
        // bên phải và phía dưới. Đổi font nền (Than) thì phải đổi lại số này cho khớp.
        // ------------------------------------------------------------------
    }
}
