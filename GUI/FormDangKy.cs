using System;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4.GUI
{
    /// <summary>
    /// Biểu mẫu đăng ký tài khoản, mở từ liên kết "Đăng ký ngay" trên Form9.
    /// Người đăng ký chọn vai trò "Khách hàng" (mặc định) hoặc "Nhân viên";
    /// tài khoản luôn có trạng thái "Đang làm việc" và không thể tự đăng ký "Quản lý".
    /// </summary>
    public partial class FormDangKy : Form
    {
        private readonly NhanVienBUS nhanVienBus = new NhanVienBUS();

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
            string vaiTro = cboVaiTro.SelectedItem?.ToString() ?? NhanVienBUS.VaiTroNhanVien;

            // Toàn bộ kiểm tra (họ tên, SĐT 10 số, tên đăng nhập chưa trùng, mật khẩu khớp)
            // và việc ghi vào tblNhanVien (+ tblKhachHang nếu là Khách hàng) đều thực hiện
            // qua BUS → DAL → Stored Procedure.
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

            string thongBao =
                "Đăng ký tài khoản thành công!\n" +
                $"Mã tài khoản: {maNV}\n" +
                $"Tên đăng nhập: {TenDangNhapDaTao}\n" +
                $"Vai trò: {vaiTro}\n";

            thongBao += vaiTro == NhanVienBUS.VaiTroKhachHang
                ? "Hồ sơ khách hàng đã được thêm vào danh sách khách hàng của cửa hàng\n" +
                  "(nếu số điện thoại chưa có trong danh sách)."
                : "Trạng thái: Đang làm việc.";

            AppHelpers.HienThongBao(thongBao);

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
