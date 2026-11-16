using System;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4.GUI
{
    /// <summary>
    /// Biểu mẫu đăng ký tài khoản nhân viên, mở từ liên kết "Đăng ký ngay" trên Form9.
    /// Tài khoản tự đăng ký luôn có chức vụ "Nhân viên" và trạng thái "Đang làm việc".
    /// </summary>
    public partial class FormDangKy : Form
    {
        private readonly NhanVienBUS nhanVienBus = new NhanVienBUS();

        /// <summary>Tên đăng nhập vừa tạo, dùng để điền sẵn lại ô đăng nhập của Form9.</summary>
        public string TenDangNhapDaTao { get; private set; } = "";

        public FormDangKy()
        {
            InitializeComponent();

            txtMatKhau.UseSystemPasswordChar = true;
            txtNhapLaiMK.UseSystemPasswordChar = true;

            btnDangKy.Click += btnDangKy_Click;
            btnHuy.Click += btnHuy_Click;

            AcceptButton = btnDangKy;
            CancelButton = btnHuy;
        }

        private void btnDangKy_Click(object? sender, EventArgs e)
        {
            // Toàn bộ kiểm tra (họ tên, SĐT 10 số, tên đăng nhập chưa trùng, mật khẩu khớp)
            // và việc ghi vào tblNhanVien đều thực hiện qua BUS → DAL → Stored Procedure.
            if (!nhanVienBus.DangKy(txtHoTen.Text, txtSDT.Text, txtTenDN.Text,
                                    txtMatKhau.Text, txtNhapLaiMK.Text,
                                    out string maNV, out string error))
            {
                AppHelpers.HienCanhBao(error);

                txtMatKhau.Clear();
                txtNhapLaiMK.Clear();
                txtMatKhau.Focus();
                return;
            }

            TenDangNhapDaTao = txtTenDN.Text.Trim();

            AppHelpers.HienThongBao(
                "Đăng ký tài khoản thành công!\n" +
                $"Mã nhân viên: {maNV}\n" +
                $"Tên đăng nhập: {TenDangNhapDaTao}\n" +
                "Chức vụ: Nhân viên - Trạng thái: Đang làm việc.");

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
