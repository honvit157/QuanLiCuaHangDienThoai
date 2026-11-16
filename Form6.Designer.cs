using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form6
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
        /// Phần dựng control được tách sang TaoGiaoDien() trong Form6.cs
        /// để màn [Design] của Visual Studio luôn mở được.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            SuspendLayout();

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 850);
            Name = "Form6";
            Text = "TÌM KIẾM ĐIỆN THOẠI";

            ResumeLayout(false);
        }

        private readonly Color mauNen = Color.FromArgb(244, 247, 252);
        private readonly Color mauChu = Color.FromArgb(35, 48, 68);
        private readonly Color mauXanh = Color.FromArgb(41, 98, 170);
        private readonly Color mauXanhDam = Color.FromArgb(30, 75, 135);
        private readonly Color mauDo = Color.FromArgb(220, 75, 75);
        private readonly Color mauXam = Color.FromArgb(105, 119, 139);
        private readonly Color mauVien = Color.FromArgb(220, 227, 237);
        private GroupBox groupBox1;
        private ComboBox cboLoai;
        private ComboBox cboHang;
        private ComboBox cboMau;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private TextBox txtGiaDen;
        private TextBox txtGiaTu;
        private TextBox txtTenHang;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label7;
        private Label label3;
        private Label label1;
        private GroupBox groupBox2;
        private DataGridView dgvKetQua;
        private DataGridViewTextBoxColumn ColMaHang;
        private DataGridViewTextBoxColumn colTenHang;
        private DataGridViewTextBoxColumn colHang;
        private DataGridViewTextBoxColumn colLoai;
        private DataGridViewTextBoxColumn colMau;
        private DataGridViewTextBoxColumn colDungLuong;
        private DataGridViewTextBoxColumn colGiaBan;
        private DataGridViewTextBoxColumn colSL;
        private Label label6;
    }
}
