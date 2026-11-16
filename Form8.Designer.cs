using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form8
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
        /// Phần dựng control được tách sang TaoGiaoDien() trong Form8.cs
        /// để màn [Design] của Visual Studio luôn mở được.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            SuspendLayout();

            AutoScaleMode = AutoScaleMode.Font;
            Name = "Form8";
            Text = "HÓA ĐƠN NHẬP HÀNG";

            ResumeLayout(false);
        }

        private readonly Color mauNen = Color.FromArgb(244, 247, 251);
        private readonly Color mauChu = Color.FromArgb(35, 51, 72);
        private readonly Color mauXanh = Color.FromArgb(36, 120, 212);
        private readonly Color mauXanhDam = Color.FromArgb(20, 43, 74);
        private readonly Color mauXanhLa = Color.FromArgb(36, 155, 110);
        private readonly Color mauDo = Color.FromArgb(220, 75, 75);
        private readonly Color mauXam = Color.FromArgb(105, 119, 139);
        private readonly Color mauVien = Color.FromArgb(220, 227, 237);
        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private ComboBox cboMaHDN;
        private TextBox txtMaNV;
        private ComboBox cboNCC;
        private TextBox txtSDT;
        private DateTimePicker dtpNgayNhap;
        private TextBox txtTenNV;
        private TextBox txtMaNCC;
        private TextBox txtDiaChi;
        private ComboBox cboMaHang;
        private TextBox txtTenHang;
        private TextBox txtDonGiaNhap;
        private TextBox txtSoLuong;
        private TextBox txtThanhTien;
        private Button btnTim;
        private Button button1;
        private DataGridView dgvChiTiet;
        private Label lblTongTien;
        private Button btnThemHD;
        private Button btnLuu;
        private Button btnHuy;
        private Button btnIn;
        private Button btnThoat;
    }
}
