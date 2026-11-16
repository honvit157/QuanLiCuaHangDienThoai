using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4.GUI
{
    partial class FormBaoCao
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        // ==========================================
        // MÃ DO DESIGNER SINH - CHỈ SỬA QUA MÀN [Design]
        // ==========================================

        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabDoanhThu = new TabPage();
            dgvDoanhThu = new DataGridView();
            lblTongDoanhThu = new Label();
            tabTonKho = new TabPage();
            dgvTonKho = new DataGridView();
            lblTongTonKho = new Label();
            tabTopBanChay = new TabPage();
            dgvTopBanChay = new DataGridView();
            panelBottom = new Panel();
            btnXuatExcel = new Button();
            btnLamMoi = new Button();
            btnDong = new Button();
            lblTitle = new Label();

            tabControl1.Controls.Add(tabDoanhThu);
            tabControl1.Controls.Add(tabTonKho);
            tabControl1.Controls.Add(tabTopBanChay);

            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Font = new System.Drawing.Font("Segoe UI", 10f);
            tabControl1.ItemSize = new System.Drawing.Size(160, 32);

            tabDoanhThu.Text = "📊 Doanh thu theo tháng";

            tabDoanhThu.Controls.Add(dgvDoanhThu);
            tabDoanhThu.Controls.Add(lblTongDoanhThu);

            tabDoanhThu.Padding = new System.Windows.Forms.Padding(5);

            dgvDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvDoanhThu.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            lblTongDoanhThu.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblTongDoanhThu.Height = 30;
            lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            lblTongDoanhThu.ForeColor = System.Drawing.Color.DarkGreen;
            lblTongDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblTongDoanhThu.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            lblTongDoanhThu.Text = "Đang tải...";

            tabTonKho.Text = "📦 Tồn kho";

            tabTonKho.Controls.Add(dgvTonKho);
            tabTonKho.Controls.Add(lblTongTonKho);

            tabTonKho.Padding = new System.Windows.Forms.Padding(5);

            dgvTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvTonKho.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            lblTongTonKho.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblTongTonKho.Height = 30;
            lblTongTonKho.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            lblTongTonKho.ForeColor = System.Drawing.Color.DarkBlue;
            lblTongTonKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblTongTonKho.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            lblTongTonKho.Text = "Đang tải...";

            tabTopBanChay.Text = "🏆 Top bán chạy";

            tabTopBanChay.Controls.Add(dgvTopBanChay);

            tabTopBanChay.Padding = new System.Windows.Forms.Padding(5);

            dgvTopBanChay.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvTopBanChay.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Height = 55;
            panelBottom.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            panelBottom.BackColor = System.Drawing.Color.WhiteSmoke;

            panelBottom.Controls.Add(btnDong);
            panelBottom.Controls.Add(btnLamMoi);
            panelBottom.Controls.Add(btnXuatExcel);

            btnXuatExcel.Text = "📄 Xuất Excel";
            btnXuatExcel.Size = new System.Drawing.Size(140, 36);
            btnXuatExcel.Location = new System.Drawing.Point(10, 9);
            btnXuatExcel.BackColor = System.Drawing.Color.ForestGreen;
            btnXuatExcel.ForeColor = System.Drawing.Color.White;
            btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            btnXuatExcel.Click += btnXuatExcel_Click;

            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.Size = new System.Drawing.Size(120, 36);
            btnLamMoi.Location = new System.Drawing.Point(160, 9);
            btnLamMoi.BackColor = System.Drawing.Color.SteelBlue;
            btnLamMoi.ForeColor = System.Drawing.Color.White;
            btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10f);
            btnLamMoi.Click += btnLamMoi_Click;

            btnDong.Text = "✖ Đóng";
            btnDong.Size = new System.Drawing.Size(100, 36);
            btnDong.Location = new System.Drawing.Point(290, 9);
            btnDong.BackColor = System.Drawing.Color.Crimson;
            btnDong.ForeColor = System.Drawing.Color.White;
            btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDong.Font = new System.Drawing.Font("Segoe UI", 10f);
            btnDong.Click += btnDong_Click;

            lblTitle.Text = "BÁO CÁO THỐNG KÊ CỬA HÀNG ĐIỆN THOẠI";
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Height = 50;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 15f, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTitle.BackColor = System.Drawing.Color.AliceBlue;

            Controls.Add(tabControl1);
            Controls.Add(panelBottom);
            Controls.Add(lblTitle);

            this.BackColor = System.Drawing.Color.White;
        }

        // KHAI BÁO CONTROL

        private TabControl tabControl1;
        private TabPage tabDoanhThu;
        private DataGridView dgvDoanhThu;
        private Label lblTongDoanhThu;
        private TabPage tabTonKho;
        private DataGridView dgvTonKho;
        private Label lblTongTonKho;
        private TabPage tabTopBanChay;
        private DataGridView dgvTopBanChay;
        private Panel panelBottom;
        private Button btnXuatExcel;
        private Button btnLamMoi;
        private Button btnDong;
        private Label lblTitle;
    }
}
