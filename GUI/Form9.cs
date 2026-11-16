
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4.GUI
{
    /// <summary>
    /// Biểu mẫu đăng nhập dùng chung cho Nhân viên / Quản lý và Khách hàng:
    /// - Tài khoản trong tblNhanVien → mở Form10 (Quản lý hoặc Nhân viên theo phân quyền).
    /// - Tài khoản trong tblKhachHang → mở Form12 (trang Khách hàng: xem điện thoại, giỏ hàng,
    ///   đặt mua, hóa đơn của tôi, thanh toán).
    /// </summary>
    public partial class Form9 : Form
    {
        // Phiên đăng nhập của Nhân viên / Quản lý
        public static string MaNVDangNhap = "";
        public static string TenNVDangNhap = "";

        // Phiên đăng nhập của Khách hàng
        public static string MaKHDangNhap = "";
        public static string TenKHDangNhap = "";

        // Vai trò của tài khoản đang đăng nhập: "Quản lý", "Nhân viên" hoặc "Khách hàng"
        public static string VaiTroDangNhap = "";

        private readonly NhanVienBUS nhanVienBus = new NhanVienBUS();
        private readonly KhachHangBUS khachHangBus = new KhachHangBUS();

        public Form9()
        {
            InitializeComponent();

            txtMatKhau.UseSystemPasswordChar = true;

            button1.Click += btnDangNhap_Click;
            button2.Click += (s, e) => Application.Exit();
            lnkDangKy.LinkClicked += lnkDangKy_LinkClicked;

            AcceptButton = button1;
            CancelButton = button2;
        }

        private void btnDangNhap_Click(object? sender, EventArgs e)
        {
            string tk = txtMaNhanVien.Text.Trim();
            string mk = txtMatKhau.Text.Trim();

            if (string.IsNullOrWhiteSpace(tk) || string.IsNullOrWhiteSpace(mk))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ tài khoản và mật khẩu!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            XoaThongTinDangNhap();

            // 1. Tài khoản Nhân viên / Quản lý (tblNhanVien) → Form10
            if (nhanVienBus.DangNhap(tk, mk, out NhanVien? nv, out _))
            {
                MaNVDangNhap = nv!.MaNV;
                TenNVDangNhap = nv.HoTen;
                VaiTroDangNhap = nv.VaiTro;

                MoFormNhanVien();
                return;
            }

            // 2. Tài khoản Khách hàng (tblKhachHang) → Form12
            if (khachHangBus.DangNhap(tk, mk, out KhachHang? kh, out _))
            {
                MaKHDangNhap = kh!.MaKH;
                TenKHDangNhap = kh.HoTen;
                VaiTroDangNhap = "Khách hàng";

                MoFormKhachHang();
                return;
            }

            // 3. Không khớp tài khoản nào
            MessageBox.Show(
                "Tên đăng nhập hoặc mật khẩu không chính xác!",
                "Lỗi đăng nhập",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            txtMatKhau.Focus();
            txtMatKhau.SelectAll();
        }

        /// <summary>Xóa toàn bộ thông tin phiên đăng nhập (cả nhân viên và khách hàng).</summary>
        private static void XoaThongTinDangNhap()
        {
            MaNVDangNhap = "";
            TenNVDangNhap = "";

            MaKHDangNhap = "";
            TenKHDangNhap = "";

            VaiTroDangNhap = "";
        }

        /// <summary>Khi Form10 hoặc Form12 đóng thì quay lại màn hình đăng nhập.</summary>
        private void XuLyDongForm(object? sender, FormClosedEventArgs e)
        {
            XoaThongTinDangNhap();

            txtMaNhanVien.Clear();
            txtMatKhau.Clear();
            txtMaNhanVien.Focus();

            Show();
        }

        /// <summary>Mở Form10 (Dashboard quản trị) cho Nhân viên / Quản lý.</summary>
        private void MoFormNhanVien()
        {
            Hide();

            Form10 main = new Form10();
            main.FormClosed += XuLyDongForm;
            main.Show();
        }

        /// <summary>Mở Form12 (trang Khách hàng) cho tài khoản trong tblKhachHang.</summary>
        private void MoFormKhachHang()
        {
            Hide();

            Form12 khachHang = new Form12();
            khachHang.FormClosed += XuLyDongForm;
            khachHang.Show();
        }

        // Mở biểu mẫu đăng ký tài khoản Khách hàng / Nhân viên (FormDangKy)
        private void lnkDangKy_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            using (FormDangKy frmDangKy = new FormDangKy())
            {
                if (frmDangKy.ShowDialog(this) != DialogResult.OK) return;

                // Điền sẵn tên đăng nhập vừa tạo để đăng nhập luôn
                txtMaNhanVien.Text = frmDangKy.TenDangNhapDaTao;
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }

        // Tự động căn giữa khung đăng nhập
        // (chuyển ra khỏi InitializeComponent để màn [Design] mở được)
        private void panelContent_Resize(object? sender, EventArgs e)
        {
            groupBox1.Location = new Point(
                (panelContent.ClientSize.Width - groupBox1.Width) / 2,
                (panelContent.ClientSize.Height - groupBox1.Height) / 2
            );
        }
    }
}
