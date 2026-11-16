using System;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4.GUI
{
    /// <summary>
    /// Biểu mẫu đăng ký tài khoản, mở từ liên kết "Đăng ký ngay" trên Form9.
    /// Người đăng ký chọn vai trò "Khách hàng" (mặc định) hoặc "Nhân viên":
    /// - Khách hàng: ghi thẳng hồ sơ + tài khoản vào tblKhachHang (KhachHangBUS.DangKy),
    ///   đăng nhập xong sẽ vào trang Khách hàng (Form12).
    /// - Nhân viên: ghi vào tblNhanVien như trước (NhanVienBUS.DangKy), đăng nhập xong vào Form10.
    /// Không ai có thể tự đăng ký vai trò "Quản lý".
    /// </summary>
    public partial class FormDangKy : Form
    {
        private readonly NhanVienBUS nhanVienBus = new NhanVienBUS();
        private readonly KhachHangBUS khachHangBus = new KhachHangBUS();

        /// <summary>Tên đăng nhập vừa tạo, dùng để điền sẵn lại ô đăng nhập của Form9.</summary>
        public string TenDangNhapDaTao { get; private set; } = "";

        /// <summary>Vai trò vừa đăng ký ("Khách hàng" hoặc "Nhân viên").</summary>
        public string VaiTroDaTao { get; private set; } = "";

        public FormDangKy()
        {
            InitializeComponent();

            txtMatKhau.UseSystemPasswordChar = true;
            txtNhapLaiMK.UseSystemPasswordChar = true;

            // Mặc định đăng ký với quyền thấp nhất; muốn vào hệ thống quản lý thì chọn "Nhân viên".
            cboVaiTro.SelectedIndex = 0;

            btnDangKy.Click += btnDangKy_Click;
            btnHuy.Click += btnHuy_Click;

            AcceptButton = btnDangKy;
            CancelButton = btnHuy;
        }

        private void btnDangKy_Click(object? sender, EventArgs e)
        {
            string vaiTro = cboVaiTro.SelectedItem?.ToString() ?? NhanVienBUS.VaiTroKhachHang;

            // Mật khẩu nhập lại phải khớp (kiểm tra chung cho cả hai vai trò)
            if (!string.Equals(txtMatKhau.Text.Trim(), txtNhapLaiMK.Text.Trim(),
                               StringComparison.Ordinal))
            {
                AppHelpers.HienCanhBao("Mật khẩu nhập lại không khớp!");

                txtNhapLaiMK.Clear();
                txtNhapLaiMK.Focus();
                return;
            }

            bool laKhachHang = vaiTro == NhanVienBUS.VaiTroKhachHang;

            if (laKhachHang)
            {
                DangKyKhachHang(vaiTro);
                return;
            }

            DangKyNhanVien(vaiTro);
        }

        /// <summary>
        /// Đăng ký tài khoản Khách hàng: lưu thẳng vào tblKhachHang qua
        /// KhachHangBUS → KhachHangDAL → sp_DangKyKhachHang (không tạo hồ sơ nhân viên).
        /// </summary>
        private void DangKyKhachHang(string vaiTro)
        {
            var khachHang = new KhachHang
            {
                HoTen = txtHoTen.Text,
                SDT = txtSDT.Text,
                Email = txtEmail.Text,
                TaiKhoan = txtTenDN.Text,
                MatKhau = txtMatKhau.Text.Trim()
            };

            if (!khachHangBus.DangKy(khachHang, out string maKH, out string error))
            {
                AppHelpers.HienCanhBao(error);

                txtMatKhau.Clear();
                txtNhapLaiMK.Clear();
                txtMatKhau.Focus();
                return;
            }

            TenDangNhapDaTao = khachHang.TaiKhoan;
            VaiTroDaTao = vaiTro;

            AppHelpers.HienThongBao(
                "Đăng ký tài khoản Khách hàng thành công!\n" +
                $"Mã khách hàng: {maKH}\n" +
                $"Tên đăng nhập: {TenDangNhapDaTao}\n" +
                "Đăng nhập bằng tài khoản này để vào trang Khách hàng:\n" +
                "xem điện thoại, thêm vào giỏ, đặt mua và theo dõi hóa đơn của mình.");

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>Đăng ký tài khoản Nhân viên: lưu vào tblNhanVien như trước.</summary>
        private void DangKyNhanVien(string vaiTro)
        {
            // Toàn bộ kiểm tra (họ tên, SĐT 10 số, tên đăng nhập chưa trùng, mật khẩu khớp)
            // và việc ghi vào tblNhanVien đều thực hiện qua BUS → DAL → Stored Procedure.
            if (!nhanVienBus.DangKy(txtHoTen.Text, txtSDT.Text, txtTenDN.Text,
                                   txtMatKhau.Text, txtNhapLaiMK.Text, vaiTro,
                                   out string maNV, out string error))
            {
                AppHelpers.HienCanhBao(error);

                txtMatKhau.Clear();
                txtNhapLaiMK.Clear();
                txtMatKhau.Focus();
                return;
            }

            TenDangNhapDaTao = txtTenDN.Text.Trim();
            VaiTroDaTao = vaiTro;

            AppHelpers.HienThongBao(
                "Đăng ký tài khoản thành công!\n" +
                $"Mã tài khoản: {maNV}\n" +
                $"Tên đăng nhập: {TenDangNhapDaTao}\n" +
                $"Vai trò: {vaiTro}\n" +
                "Trạng thái: Đang làm việc.");

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnHuy_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
