using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form2
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
        /// Phần dựng control được tách sang TaoGiaoDien() trong Form2.cs
        /// để màn [Design] của Visual Studio luôn mở được.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            SuspendLayout();

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(1100, 760);

            Name = "Form2";
            Text = "PHONE STORE - Quản lý nhân viên";

            ResumeLayout(false);
        }

        private TextBox txtTim;
        private Label label10;
        private Button btnThoat;
        private Button btnLamLai;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private Button btnTim;
        private TextBox txtTenNV;
        private TextBox txtMatKhau;
        private TextBox txtMaNV;
        private TextBox txtDiaChi;
        private TextBox txtSDT;
        private Label label8;
        private Label label7;
        private Label label4;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label6;
        private Label label1;
        private Label label9;
        private Label label11;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private RadioButton radNu;
        private RadioButton radNam;
        private DateTimePicker dtpNgaySinh;
        private ComboBox cboChucVu;
        private ComboBox cboTrangThai;
        private DataGridView dgvNhanVien;
        private ListBox listBox4;
        private ListBox listBox1;
    }
}
