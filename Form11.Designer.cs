using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form11
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Khởi tạo các thuộc tính cơ bản của biểu mẫu.
        /// Phần dựng control được tách sang TaoGiaoDien() trong Form11.cs
        /// để màn [Design] của Visual Studio luôn mở được.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(1000, 780);

            Name = "Form11";
            Text = "PHONE STORE - Đăng ký tài khoản";

            ResumeLayout(false);
        }

        private Panel panelHeader;
        private Panel panelContent;
        private GroupBox groupBox1;
        private Label label1;
        private Label labelSubtitle;
        private Label labelHoTen;
        private Label labelSDT;
        private Label labelEmail;
        private Label labelTaiKhoan;
        private Label labelMatKhau;
        private Label labelXacNhan;
        private Label labelRole;
        private TextBox txtHoTen;
        private TextBox txtSoDienThoai;
        private TextBox txtEmail;
        private TextBox txtTaiKhoan;
        private TextBox txtMatKhau;
        private TextBox txtXacNhanMatKhau;
        private ComboBox cboRole;
        private Button btnDangKy;
        private Button btnQuayLai;
    }
}
