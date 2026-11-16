using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form4
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
        /// Phần dựng control được tách sang TaoGiaoDien() trong Form4.cs
        /// để màn [Design] của Visual Studio luôn mở được.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            SuspendLayout();

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(1100, 760);

            Name = "Form4";
            Text = "PHONE STORE - Quản lý nhà cung cấp";

            ResumeLayout(false);
        }

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private TextBox txtMaNCC;
        private TextBox txtTenNCC;
        private TextBox txtSDT;
        private TextBox txtDiaChi;
        private TextBox txtEmail;
        private TextBox txtNguoiLH;
        private TextBox txtTim;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamLai;
        private Button btnThoat;
        private Button button1;
        private DataGridView dgvKhachHang;
        private DataGridViewTextBoxColumn colMaNCC;
        private DataGridViewTextBoxColumn colTenNCC;
        private DataGridViewTextBoxColumn colSDT;
        private DataGridViewTextBoxColumn colDiaChi;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colNguoiLH;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label11;
    }
}
