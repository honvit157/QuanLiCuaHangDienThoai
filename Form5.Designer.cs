using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form5
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
        /// Phần dựng control được tách sang TaoGiaoDien() trong Form5.cs
        /// để màn [Design] của Visual Studio luôn mở được.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            SuspendLayout();

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 850);
            Name = "Form5";
            Text = "QUẢN LÝ DANH MỤC";

            ResumeLayout(false);
        }

        private readonly Color mauNen = Color.FromArgb(244, 247, 252);
        private readonly Color mauChu = Color.FromArgb(35, 48, 68);
        private readonly Color mauXanh = Color.FromArgb(41, 98, 170);
        private readonly Color mauXanhDam = Color.FromArgb(30, 75, 135);
        private readonly Color mauDo = Color.FromArgb(220, 75, 75);
        private readonly Color mauXam = Color.FromArgb(105, 119, 139);
        private readonly Color mauVien = Color.FromArgb(220, 227, 237);
        private TabControl tabDanhMuc;
        private TabPage tpHangSX;
        private TabPage tpLoai;
        private TabPage tpMauSac;
        private TabPage tpDungLuong;
        private TextBox txtTenHang;
        private TextBox txtGhiChu;
        private TextBox txtMaHang;
        private Button btnThoat;
        private Button btnLamLai;
        private DataGridView dgvHangSX;
        private Button btnXoa;
        private Label label3;
        private Button btnSua;
        private Label label2;
        private Button btnThem;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
        private Button button3;
        private Label label4;
        private Button button4;
        private Label label5;
        private Button button5;
        private Label label6;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Button button6;
        private Button button7;
        private DataGridView dataGridView2;
        private Button button8;
        private Label label7;
        private Button button9;
        private Label label8;
        private Button button10;
        private Label label9;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private Button button11;
        private Button button12;
        private DataGridView dataGridView3;
        private Button button13;
        private Label label10;
        private Button button14;
        private Label label11;
        private Button button15;
        private Label label12;
    }
}
