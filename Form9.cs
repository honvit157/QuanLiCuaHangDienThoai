
using System;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form9 : Form
    {
        // Thông tin nhân viên
        public static string MaNVDangNhap = "";
        public static string TenNVDangNhap = "";

        // Thông tin khách hàng
        public static string MaKHDangNhap = "";
        public static string TenKHDangNhap = "";

        // Vai trò tài khoản
        public static string VaiTroDangNhap = "";

        private readonly NhanVienBUS nhanVienBus = new NhanVienBUS();
        private readonly KhachHangBUS khachHangBus = new KhachHangBUS();

        public Form9()
        {
            InitializeComponent();

            TaoGiaoDien();

            txtMatKhau.UseSystemPasswordChar = true;

            button1.Click += btnDangNhap_Click;
            button2.Click += (s, e) => Application.Exit();
            button3.Click += btnDangKy_Click;

            AcceptButton = button1;
            CancelButton = button2;
        }

        // Đăng ký tài khoản khách hàng
        private void btnDangKy_Click(object? sender, EventArgs e)
        {
            using (Form11 form = new Form11())
            {
                form.ShowDialog(this);
            }
        }

        // Xóa phiên đăng nhập
        private void XoaThongTinDangNhap()
        {
            MaNVDangNhap = "";
            TenNVDangNhap = "";

            MaKHDangNhap = "";
            TenKHDangNhap = "";

            VaiTroDangNhap = "";
        }

        // Quay lại màn hình đăng nhập khi form chính đóng
        private void XuLyDongForm(object? sender, FormClosedEventArgs e)
        {
            XoaThongTinDangNhap();

            txtMaNhanVien.Clear();
            txtMatKhau.Clear();

            txtMaNhanVien.Focus();

            this.Show();
        }

        // Mở Form10 cho nhân viên và quản lý
        private void MoFormNhanVien()
        {
            this.Hide();

            Form10 form = new Form10();
            form.FormClosed += XuLyDongForm;
            form.Show();
        }

        // Mở Form12 cho khách hàng
        private void MoFormKhachHang()
        {
            this.Hide();

            Form12 form = new Form12();
            form.FormClosed += XuLyDongForm;
            form.Show();
        }

        // Xử lý đăng nhập
        private void btnDangNhap_Click(object? sender, EventArgs e)
        {
            string tk = txtMaNhanVien.Text.Trim();
            string mk = txtMatKhau.Text;

            if (string.IsNullOrWhiteSpace(tk) ||
                string.IsNullOrWhiteSpace(mk))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ tài khoản và mật khẩu!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            XoaThongTinDangNhap();

            // ==================================
            // 1. KIỂM TRA TÀI KHOẢN NHÂN VIÊN
            // ==================================

            if (nhanVienBus.DangNhap(
                tk,
                mk,
                out NhanVien? nv,
                out string errorNhanVien))
            {
                MaNVDangNhap = nv!.MaNV;
                TenNVDangNhap = nv.HoTen;
                VaiTroDangNhap = nv.VaiTro;

                MoFormNhanVien();
                return;
            }

            // ==================================
            // 2. KIỂM TRA TÀI KHOẢN KHÁCH HÀNG
            // ==================================

            if (khachHangBus.DangNhap(
                tk,
                mk,
                out KhachHang? kh,
                out string errorKhachHang))
            {
                MaKHDangNhap = kh!.MaKH;
                TenKHDangNhap = kh.HoTen;
                VaiTroDangNhap = "Khách hàng";

                MoFormKhachHang();
                return;
            }

            // ==================================
            // 3. ĐĂNG NHẬP THẤT BẠI
            // ==================================

            MessageBox.Show(
                "Tên đăng nhập hoặc mật khẩu không chính xác!",
                "Lỗi đăng nhập",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            txtMatKhau.Focus();
            txtMatKhau.SelectAll();
        }

        // =====================================================
        // DỰNG GIAO DIỆN
        // Tách khỏi InitializeComponent() để màn [Design] của Visual Studio
        // luôn mở được: trình thiết kế không đọc được vòng lặp và biến cục bộ.
        // =====================================================
        private void TaoGiaoDien()
        {
            panelHeader = new Panel();
            label1 = new Label();
            panelContent = new Panel();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtMaNhanVien = new TextBox();
            txtMatKhau = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            groupBox1.SuspendLayout();
            // ==============================
            // FORM 9
            // ==============================
            BackColor = Color.FromArgb(241, 246, 252);
            MinimumSize = new Size(850, 620);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 10F);
            // ==============================
            // HEADER
            // ==============================
            panelHeader.BackColor =
                Color.FromArgb(11, 46, 77);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 85;
            label1.AutoSize = false;
            label1.Text =
                "HỆ THỐNG QUẢN LÝ CỬA HÀNG | PHONE STORE";
            label1.Font =
                new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Dock = DockStyle.Fill;
            label1.TextAlign =
                ContentAlignment.MiddleCenter;
            panelHeader.Controls.Add(label1);
            // ==============================
            // CONTENT
            // ==============================
            panelContent.Dock = DockStyle.Fill;
            panelContent.BackColor =
                Color.FromArgb(241, 246, 252);
            panelContent.Resize += panelContent_Resize;
            // ==============================
            // LOGIN CARD
            // ==============================
            groupBox1.BackColor = Color.White;
            groupBox1.ForeColor =
                Color.FromArgb(11, 46, 77);
            groupBox1.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBox1.Text = "ĐĂNG NHẬP HỆ THỐNG";
            groupBox1.Size = new Size(580, 420);
            groupBox1.TabStop = false;
            groupBox1.Padding = new Padding(20);
            // ==============================
            // SUBTITLE
            // ==============================
            label4.AutoSize = false;
            label4.Location = new Point(35, 65);
            label4.Size = new Size(500, 35);
            label4.Text =
                "Vui lòng nhập thông tin tài khoản của bạn";
            label4.Font =
                new Font("Segoe UI", 10F);
            label4.ForeColor =
                Color.FromArgb(110, 125, 145);
            // ==============================
            // LABEL NHẬP TÀI KHOẢN
            // ==============================
            label2.AutoSize = true;
            label2.Location = new Point(38, 125);
            label2.Text = "NHẬP TÀI KHOẢN";
            label2.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor =
                Color.FromArgb(45, 65, 85);
            // ==============================
            // TEXTBOX MÃ NHÂN VIÊN
            // ==============================
            txtMaNhanVien.Location =
                new Point(40, 155);
            txtMaNhanVien.Size =
                new Size(490, 35);
            txtMaNhanVien.Font =
                new Font("Segoe UI", 12F);
            txtMaNhanVien.BorderStyle =
                BorderStyle.FixedSingle;
            txtMaNhanVien.BackColor =
                Color.FromArgb(248, 250, 253);
            txtMaNhanVien.Name = "txtMaNhanVien";
            // ==============================
            // LABEL MẬT KHẨU
            // ==============================
            label3.AutoSize = true;
            label3.Location = new Point(38, 220);
            label3.Text = "MẬT KHẨU";
            label3.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor =
                Color.FromArgb(45, 65, 85);
            // ==============================
            // TEXTBOX MẬT KHẨU
            // ==============================
            txtMatKhau.Location =
                new Point(40, 250);
            txtMatKhau.Size =
                new Size(490, 35);
            txtMatKhau.Font =
                new Font("Segoe UI", 12F);
            txtMatKhau.BorderStyle =
                BorderStyle.FixedSingle;
            txtMatKhau.BackColor =
                Color.FromArgb(248, 250, 253);
            txtMatKhau.Name = "txtMatKhau";
            // ==============================
            // BUTTON ĐĂNG NHẬP
            // ==============================
            button1.Location = new Point(40, 330);
            button1.Size = new Size(150, 48);
            button1.Text = "ĐĂNG NHẬP";
            button1.Name = "button1";
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.BackColor = Color.FromArgb(8, 120, 209);
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Cursor = Cursors.Hand;
            button1.UseVisualStyleBackColor = false;
            // ==============================
            // BUTTON ĐĂNG KÝ
            // ==============================
            button3.Location = new Point(205, 330);
            button3.Size = new Size(150, 48);
            button3.Text = "ĐĂNG KÝ";
            button3.Name = "button3";
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.BackColor = Color.FromArgb(16, 160, 110);
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.Cursor = Cursors.Hand;
            button3.UseVisualStyleBackColor = false;
            // ==============================
            // BUTTON THOÁT
            // ==============================
            button2.Location = new Point(370, 330);
            button2.Size = new Size(160, 48);
            button2.Text = "THOÁT";
            button2.Name = "button2";
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button2.ForeColor = Color.FromArgb(60, 75, 90);
            button2.BackColor = Color.FromArgb(231, 237, 245);
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.Cursor = Cursors.Hand;
            button2.UseVisualStyleBackColor = false;
            // ==============================
            // ADD CONTROLS
            // ==============================
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtMaNhanVien);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtMatKhau);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            panelContent.Controls.Add(groupBox1);
            // ==============================
            // FORM CONTROLS
            // ==============================
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            panelHeader.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
        }

        // =====================================================
        // CÁC HÀM HỖ TRỢ THIẾT KẾ
        // =====================================================
        private void panelContent_Resize(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(
                (panelContent.ClientSize.Width - groupBox1.Width) / 2,
                (panelContent.ClientSize.Height - groupBox1.Height) / 2
            );
        }
    }
}
