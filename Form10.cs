
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai
{
    public partial class Form10 : Form
    {
        private Panel pnlNoiDung;
        private Form formDangHienThi;

        public Form10()
        {
            InitializeComponent();

            // Kích thước cửa sổ Form10:
            // - MinimumSize đủ nhỏ để vừa màn hình 1366x768 (vùng làm việc ~1366x728),
            //   nhưng vẫn đủ rộng để các form con bên trong không bị bóp méo.
            // - Mở ra là phóng to hết màn hình; khi thu nhỏ lại thì trở về cỡ Size ở dưới.
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(1170, 700);
            this.Size = new Size(1280, 780);
            this.WindowState = FormWindowState.Maximized;

            // Tạo vùng hiển thị các Form con
            TaoPanelNoiDung();

            Load += Form10_Load;

            // Menu Danh mục
            if (mnuDanhMuc.DropDownItems.Count >= 5)
            {
                mnuDanhMuc.DropDownItems[0].Click += (s, e) => MoForm(new Form1());
                mnuDanhMuc.DropDownItems[1].Click += (s, e) => MoForm(new Form5());
                mnuDanhMuc.DropDownItems[2].Click += (s, e) => MoForm(new Form2());
                mnuDanhMuc.DropDownItems[3].Click += (s, e) => MoForm(new Form3());
                mnuDanhMuc.DropDownItems[4].Click += (s, e) => MoForm(new Form4());
            }

            // Menu Hóa đơn
            ToolStripMenuItem mnuHDB = new ToolStripMenuItem(
                "Hóa đơn bán hàng", null,
                (s, e) => MoForm(new Form7()));

            ToolStripMenuItem mnuHDN = new ToolStripMenuItem(
                "Hóa đơn nhập hàng", null,
                (s, e) => MoForm(new Form8()));

            mnuHoaDon.DropDownItems.Add(mnuHDB);
            mnuHoaDon.DropDownItems.Add(mnuHDN);

            // Menu Tìm kiếm và Báo cáo
            mnuTimKiem.Click += (s, e) => MoForm(new Form6());
            mnuBaocao.Click += (s, e) => MoForm(new FormBaoCao());

            // Đăng xuất
            mnuThoat.Click += (s, e) =>
            {
                if (MessageBox.Show(
                    "Bạn có muốn đăng xuất khỏi hệ thống?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Close();
                }
            };
        }

        // Tạo vùng chứa Form1, Form2, Form3...
        private void TaoPanelNoiDung()
        {
            pnlNoiDung = new Panel();

            pnlNoiDung.Name = "pnlNoiDung";
            pnlNoiDung.Dock = DockStyle.Fill;
            pnlNoiDung.BackColor = Color.White;
            pnlNoiDung.AutoScroll = true;

            this.Controls.Add(pnlNoiDung);

            // Đảm bảo thanh menu và thanh trạng thái
            // luôn hiển thị phía trên/dưới vùng nội dung
            foreach (Control control in this.Controls)
            {
                if (control is MenuStrip || control is StatusStrip)
                {
                    control.BringToFront();
                }
            }
        }

        private void Form10_Load(object? sender, EventArgs e)
        {
            this.Text = "HỆ THỐNG QUẢN LÝ CỬA HÀNG ĐIỆN THOẠI";

            // Mở hết màn hình cho dễ dùng; người dùng vẫn thu nhỏ/phóng to tự do
            // (giới hạn nhỏ nhất là MinimumSize ở trên).
            this.WindowState = FormWindowState.Maximized;

            string tenNV = string.IsNullOrWhiteSpace(Form9.TenNVDangNhap)
                ? "Chưa xác định"
                : Form9.TenNVDangNhap.Trim();

            string vaiTro = string.IsNullOrWhiteSpace(Form9.VaiTroDangNhap)
                ? "Không xác định"
                : Form9.VaiTroDangNhap.Trim();

            bool laQuanLy =
                vaiTro.Equals("Quản lý", StringComparison.OrdinalIgnoreCase) ||
                vaiTro.Equals("Quan ly", StringComparison.OrdinalIgnoreCase);

            tslNhanVien.Text = $"Người dùng: {tenNV} | Quyền: {vaiTro}      ";
            tslNgay.Text = $"Hôm nay: {DateTime.Now:dd/MM/yyyy HH:mm}";

            // Phân quyền
            if (!vaiTro.Equals("Quản lý", StringComparison.OrdinalIgnoreCase)
                && !vaiTro.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                if (mnuDanhMuc.DropDownItems.Count >= 3)
                {
                    mnuDanhMuc.DropDownItems[2].Enabled = laQuanLy;
                }
            }

            // Mặc định mở Form1 ngay khi đăng nhập
            MoForm(new Form1());
        }

        // Hiển thị Form con bên trong Form10
        private void MoForm(Form f)
        {
            // Đóng Form đang hiển thị trước đó
            if (formDangHienThi != null)
            {
                formDangHienThi.Close();
                formDangHienThi.Dispose();
                formDangHienThi = null;
            }

            // Thiết lập Form mới thành Form con
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;

            // Đưa Form vào vùng nội dung
            pnlNoiDung.Controls.Clear();
            pnlNoiDung.Controls.Add(f);

            formDangHienThi = f;

            f.Show();
            f.BringToFront();
        }
    }
}
