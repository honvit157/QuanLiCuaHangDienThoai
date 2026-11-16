using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4.GUI
{
    partial class Form7
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
            components = new System.ComponentModel.Container();

            label1 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            cboMaHD = new ComboBox();
            txtMaNV = new TextBox();
            txtSDT = new TextBox();
            txtTenKH = new TextBox();
            txtTenNV = new TextBox();
            dtpNgayLap = new DateTimePicker();
            cboKhachHang = new ComboBox();
            txtDiaChi = new TextBox();
            cboMaHang = new ComboBox();
            txtSoLuong = new TextBox();
            txtTenHang = new TextBox();
            txtGiamGia = new TextBox();
            txtDonGia = new TextBox();
            txtThanhTien = new TextBox();
            btnTim = new Button();
            btnThemHang = new Button();
            dgvChiTiet = new DataGridView();
            lblTongTien = new Label();
            btnThemHD = new Button();
            btnLuu = new Button();
            btnHuy = new Button();
            btnIn = new Button();
            btnThoat = new Button();

            ((System.ComponentModel.ISupportInitialize)(dgvChiTiet)).BeginInit();
            SuspendLayout();
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 251);
            ClientSize = new Size(1100, 720);
            Font = new Font("Segoe UI", 10F);
            Name = "Form7";
            Text = "HÓA ĐƠN BÁN HÀNG";
            StartPosition = FormStartPosition.CenterScreen;
            Dock = DockStyle.Fill;
            AutoScroll = false;

            tblMain = new TableLayoutPanel();

            tblMain.Dock = DockStyle.Fill;
            tblMain.ColumnCount = 1;
            tblMain.RowCount = 5;
            tblMain.BackColor = Color.FromArgb(244, 247, 251);
            tblMain.Padding = new Padding(8);
            tblMain.Margin = Padding.Empty;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 192F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 142F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));

            label1.Text = "HÓA ĐƠN BÁN HÀNG";
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(20, 43, 74);
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Margin = new Padding(5, 0, 0, 2);

            tblMain.Controls.Add(label1, 0, 0);

            groupBox1.Text = "THÔNG TIN CHUNG";
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox1.BackColor = Color.White;
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Margin = new Padding(0, 0, 0, 7);
            groupBox1.Padding = new Padding(8, 10, 8, 4);

            tblThongTin = new TableLayoutPanel();

            tblThongTin.Dock = DockStyle.Fill;
            tblThongTin.ColumnCount = 4;
            tblThongTin.RowCount = 3;
            tblThongTin.BackColor = Color.White;
            tblThongTin.Margin = Padding.Empty;
            tblThongTin.Padding = Padding.Empty;
            tblThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblThongTin.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tblThongTin.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tblThongTin.RowStyles.Add(new RowStyle(SizeType.Percent, 33.34F));

            pnlMaHoaDon = new Panel();

            pnlMaHoaDon.Dock = DockStyle.Fill;
            pnlMaHoaDon.BackColor = Color.White;
            pnlMaHoaDon.Padding = new Padding(4, 2, 6, 1);
            pnlMaHoaDon.Margin = new Padding(2);

            tblMaHoaDon = new TableLayoutPanel();

            tblMaHoaDon.Dock = DockStyle.Fill;
            tblMaHoaDon.ColumnCount = 1;
            tblMaHoaDon.RowCount = 2;
            tblMaHoaDon.BackColor = Color.White;
            tblMaHoaDon.Margin = Padding.Empty;
            tblMaHoaDon.Padding = Padding.Empty;
            tblMaHoaDon.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMaHoaDon.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tblMaHoaDon.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label2.Text = "Mã hóa đơn";
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(35, 51, 72);
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Margin = Padding.Empty;

            tblInputMaHoaDon = new TableLayoutPanel();

            tblInputMaHoaDon.Dock = DockStyle.Fill;
            tblInputMaHoaDon.ColumnCount = 2;
            tblInputMaHoaDon.RowCount = 1;
            tblInputMaHoaDon.Margin = Padding.Empty;
            tblInputMaHoaDon.Padding = Padding.Empty;
            tblInputMaHoaDon.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblInputMaHoaDon.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 64F));
            tblInputMaHoaDon.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            cboMaHD.Font = new Font("Segoe UI", 9.5F);
            cboMaHD.ForeColor = Color.FromArgb(35, 51, 72);
            cboMaHD.Dock = DockStyle.Fill;
            cboMaHD.Margin = new Padding(0, 1, 4, 1);
            cboMaHD.IntegralHeight = false;

            btnTim.Text = "⌕ Tìm";
            btnTim.BackColor = Color.FromArgb(36, 120, 212);
            btnTim.ForeColor = Color.White;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.FlatAppearance.BorderSize = 0;
            btnTim.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTim.Cursor = Cursors.Hand;
            btnTim.UseVisualStyleBackColor = false;
            btnTim.Dock = DockStyle.Fill;
            btnTim.Margin = new Padding(0, 1, 0, 1);

            tblInputMaHoaDon.Controls.Add(cboMaHD, 0, 0);
            tblInputMaHoaDon.Controls.Add(btnTim, 1, 0);

            tblMaHoaDon.Controls.Add(label2, 0, 0);
            tblMaHoaDon.Controls.Add(tblInputMaHoaDon, 0, 1);

            pnlMaHoaDon.Controls.Add(tblMaHoaDon);

            tblThongTin.Controls.Add(pnlMaHoaDon, 0, 0);
            tblThongTin.SetColumnSpan(pnlMaHoaDon, 2);

            pnlNgayLap = new Panel();

            pnlNgayLap.Dock = DockStyle.Fill;
            pnlNgayLap.BackColor = Color.White;
            pnlNgayLap.Padding = new Padding(4, 2, 6, 1);
            pnlNgayLap.Margin = new Padding(2);

            tblNgayLap = new TableLayoutPanel();

            tblNgayLap.Dock = DockStyle.Fill;
            tblNgayLap.ColumnCount = 1;
            tblNgayLap.RowCount = 2;
            tblNgayLap.BackColor = Color.White;
            tblNgayLap.Margin = Padding.Empty;
            tblNgayLap.Padding = Padding.Empty;
            tblNgayLap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblNgayLap.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tblNgayLap.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label6.Text = "Ngày lập";
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(35, 51, 72);
            label6.TextAlign = ContentAlignment.MiddleLeft;
            label6.Margin = Padding.Empty;

            dtpNgayLap.Font = new Font("Segoe UI", 9.5F);
            dtpNgayLap.ForeColor = Color.FromArgb(35, 51, 72);
            dtpNgayLap.Format = DateTimePickerFormat.Short;
            dtpNgayLap.Dock = DockStyle.Fill;
            dtpNgayLap.Margin = new Padding(0, 1, 0, 1);

            tblNgayLap.Controls.Add(label6, 0, 0);
            tblNgayLap.Controls.Add(dtpNgayLap, 0, 1);

            pnlNgayLap.Controls.Add(tblNgayLap);

            tblThongTin.Controls.Add(pnlNgayLap, 2, 0);

            pnlMaNhanVien = new Panel();

            pnlMaNhanVien.Dock = DockStyle.Fill;
            pnlMaNhanVien.BackColor = Color.White;
            pnlMaNhanVien.Padding = new Padding(4, 2, 6, 1);
            pnlMaNhanVien.Margin = new Padding(2);

            tblMaNhanVien = new TableLayoutPanel();

            tblMaNhanVien.Dock = DockStyle.Fill;
            tblMaNhanVien.ColumnCount = 1;
            tblMaNhanVien.RowCount = 2;
            tblMaNhanVien.BackColor = Color.White;
            tblMaNhanVien.Margin = Padding.Empty;
            tblMaNhanVien.Padding = Padding.Empty;
            tblMaNhanVien.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMaNhanVien.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tblMaNhanVien.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label3.Text = "Mã nhân viên";
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(35, 51, 72);
            label3.TextAlign = ContentAlignment.MiddleLeft;
            label3.Margin = Padding.Empty;

            txtMaNV.Font = new Font("Segoe UI", 9.5F);
            txtMaNV.ForeColor = Color.FromArgb(35, 51, 72);
            txtMaNV.BorderStyle = BorderStyle.FixedSingle;
            txtMaNV.BackColor = Color.FromArgb(250, 252, 255);
            txtMaNV.Dock = DockStyle.Fill;
            txtMaNV.Margin = new Padding(0, 1, 0, 1);

            tblMaNhanVien.Controls.Add(label3, 0, 0);
            tblMaNhanVien.Controls.Add(txtMaNV, 0, 1);

            pnlMaNhanVien.Controls.Add(tblMaNhanVien);

            tblThongTin.Controls.Add(pnlMaNhanVien, 3, 0);

            pnlTenNhanVien = new Panel();

            pnlTenNhanVien.Dock = DockStyle.Fill;
            pnlTenNhanVien.BackColor = Color.White;
            pnlTenNhanVien.Padding = new Padding(4, 2, 6, 1);
            pnlTenNhanVien.Margin = new Padding(2);

            tblTenNhanVien = new TableLayoutPanel();

            tblTenNhanVien.Dock = DockStyle.Fill;
            tblTenNhanVien.ColumnCount = 1;
            tblTenNhanVien.RowCount = 2;
            tblTenNhanVien.BackColor = Color.White;
            tblTenNhanVien.Margin = Padding.Empty;
            tblTenNhanVien.Padding = Padding.Empty;
            tblTenNhanVien.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblTenNhanVien.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tblTenNhanVien.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label7.Text = "Tên nhân viên";
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(35, 51, 72);
            label7.TextAlign = ContentAlignment.MiddleLeft;
            label7.Margin = Padding.Empty;

            txtTenNV.Font = new Font("Segoe UI", 9.5F);
            txtTenNV.ForeColor = Color.FromArgb(35, 51, 72);
            txtTenNV.BorderStyle = BorderStyle.FixedSingle;
            txtTenNV.BackColor = Color.FromArgb(250, 252, 255);
            txtTenNV.Dock = DockStyle.Fill;
            txtTenNV.Margin = new Padding(0, 1, 0, 1);

            tblTenNhanVien.Controls.Add(label7, 0, 0);
            tblTenNhanVien.Controls.Add(txtTenNV, 0, 1);

            pnlTenNhanVien.Controls.Add(tblTenNhanVien);

            tblThongTin.Controls.Add(pnlTenNhanVien, 0, 1);

            pnlKhachHang = new Panel();

            pnlKhachHang.Dock = DockStyle.Fill;
            pnlKhachHang.BackColor = Color.White;
            pnlKhachHang.Padding = new Padding(4, 2, 6, 1);
            pnlKhachHang.Margin = new Padding(2);

            tblKhachHang = new TableLayoutPanel();

            tblKhachHang.Dock = DockStyle.Fill;
            tblKhachHang.ColumnCount = 1;
            tblKhachHang.RowCount = 2;
            tblKhachHang.BackColor = Color.White;
            tblKhachHang.Margin = Padding.Empty;
            tblKhachHang.Padding = Padding.Empty;
            tblKhachHang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblKhachHang.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tblKhachHang.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label8.Text = "Khách hàng (có sẵn / khách mới)";
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(35, 51, 72);
            label8.TextAlign = ContentAlignment.MiddleLeft;
            label8.Margin = Padding.Empty;
            label8.AutoEllipsis = true;

            cboKhachHang.Font = new Font("Segoe UI", 9.5F);
            cboKhachHang.ForeColor = Color.FromArgb(35, 51, 72);
            cboKhachHang.Dock = DockStyle.Fill;
            cboKhachHang.Margin = new Padding(0, 1, 0, 1);
            cboKhachHang.IntegralHeight = false;

            tblKhachHang.Controls.Add(label8, 0, 0);
            tblKhachHang.Controls.Add(cboKhachHang, 0, 1);

            pnlKhachHang.Controls.Add(tblKhachHang);

            tblThongTin.Controls.Add(pnlKhachHang, 1, 1);
            tblThongTin.SetColumnSpan(pnlKhachHang, 2);

            pnlSdtKhach = new Panel();

            pnlSdtKhach.Dock = DockStyle.Fill;
            pnlSdtKhach.BackColor = Color.White;
            pnlSdtKhach.Padding = new Padding(4, 2, 6, 1);
            pnlSdtKhach.Margin = new Padding(2);

            tblSdtKhach = new TableLayoutPanel();

            tblSdtKhach.Dock = DockStyle.Fill;
            tblSdtKhach.ColumnCount = 1;
            tblSdtKhach.RowCount = 2;
            tblSdtKhach.BackColor = Color.White;
            tblSdtKhach.Margin = Padding.Empty;
            tblSdtKhach.Padding = Padding.Empty;
            tblSdtKhach.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblSdtKhach.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tblSdtKhach.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label4.Text = "SĐT khách";
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(35, 51, 72);
            label4.TextAlign = ContentAlignment.MiddleLeft;
            label4.Margin = Padding.Empty;

            txtSDT.Font = new Font("Segoe UI", 9.5F);
            txtSDT.ForeColor = Color.FromArgb(35, 51, 72);
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.BackColor = Color.FromArgb(250, 252, 255);
            txtSDT.Dock = DockStyle.Fill;
            txtSDT.Margin = new Padding(0, 1, 0, 1);
            txtSDT.MaxLength = 12;

            tblSdtKhach.Controls.Add(label4, 0, 0);
            tblSdtKhach.Controls.Add(txtSDT, 0, 1);

            pnlSdtKhach.Controls.Add(tblSdtKhach);

            tblThongTin.Controls.Add(pnlSdtKhach, 3, 1);

            pnlTenKhach = new Panel();

            pnlTenKhach.Dock = DockStyle.Fill;
            pnlTenKhach.BackColor = Color.White;
            pnlTenKhach.Padding = new Padding(4, 2, 6, 1);
            pnlTenKhach.Margin = new Padding(2);

            tblTenKhach = new TableLayoutPanel();

            tblTenKhach.Dock = DockStyle.Fill;
            tblTenKhach.ColumnCount = 1;
            tblTenKhach.RowCount = 2;
            tblTenKhach.BackColor = Color.White;
            tblTenKhach.Margin = Padding.Empty;
            tblTenKhach.Padding = Padding.Empty;
            tblTenKhach.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblTenKhach.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tblTenKhach.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label5.Text = "Tên khách";
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(35, 51, 72);
            label5.TextAlign = ContentAlignment.MiddleLeft;
            label5.Margin = Padding.Empty;

            txtTenKH.Font = new Font("Segoe UI", 9.5F);
            txtTenKH.ForeColor = Color.FromArgb(35, 51, 72);
            txtTenKH.BorderStyle = BorderStyle.FixedSingle;
            txtTenKH.BackColor = Color.FromArgb(250, 252, 255);
            txtTenKH.Dock = DockStyle.Fill;
            txtTenKH.Margin = new Padding(0, 1, 0, 1);
            txtTenKH.MaxLength = 100;

            tblTenKhach.Controls.Add(label5, 0, 0);
            tblTenKhach.Controls.Add(txtTenKH, 0, 1);

            pnlTenKhach.Controls.Add(tblTenKhach);

            tblThongTin.Controls.Add(pnlTenKhach, 0, 2);
            tblThongTin.SetColumnSpan(pnlTenKhach, 2);

            pnlDiaChi = new Panel();

            pnlDiaChi.Dock = DockStyle.Fill;
            pnlDiaChi.BackColor = Color.White;
            pnlDiaChi.Padding = new Padding(4, 2, 6, 1);
            pnlDiaChi.Margin = new Padding(2);

            tblDiaChi = new TableLayoutPanel();

            tblDiaChi.Dock = DockStyle.Fill;
            tblDiaChi.ColumnCount = 1;
            tblDiaChi.RowCount = 2;
            tblDiaChi.BackColor = Color.White;
            tblDiaChi.Margin = Padding.Empty;
            tblDiaChi.Padding = Padding.Empty;
            tblDiaChi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblDiaChi.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tblDiaChi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label9.Text = "Địa chỉ";
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(35, 51, 72);
            label9.TextAlign = ContentAlignment.MiddleLeft;
            label9.Margin = Padding.Empty;

            txtDiaChi.Font = new Font("Segoe UI", 9.5F);
            txtDiaChi.ForeColor = Color.FromArgb(35, 51, 72);
            txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
            txtDiaChi.BackColor = Color.FromArgb(250, 252, 255);
            txtDiaChi.Dock = DockStyle.Fill;
            txtDiaChi.Margin = new Padding(0, 1, 0, 1);
            txtDiaChi.MaxLength = 200;

            tblDiaChi.Controls.Add(label9, 0, 0);
            tblDiaChi.Controls.Add(txtDiaChi, 0, 1);

            pnlDiaChi.Controls.Add(tblDiaChi);

            tblThongTin.Controls.Add(pnlDiaChi, 2, 2);
            tblThongTin.SetColumnSpan(pnlDiaChi, 2);

            groupBox1.Controls.Add(tblThongTin);

            tblMain.Controls.Add(groupBox1, 0, 1);

            groupBox2.Text = "CHỌN MẶT HÀNG";
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox2.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox2.BackColor = Color.White;
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Margin = new Padding(0, 0, 0, 7);
            groupBox2.Padding = new Padding(8, 10, 8, 4);

            tblMatHang = new TableLayoutPanel();

            tblMatHang.Dock = DockStyle.Fill;
            tblMatHang.ColumnCount = 4;
            tblMatHang.RowCount = 2;
            tblMatHang.BackColor = Color.White;
            tblMatHang.Margin = Padding.Empty;
            tblMatHang.Padding = Padding.Empty;
            tblMatHang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblMatHang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblMatHang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblMatHang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblMatHang.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMatHang.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            pnlMaHang = new Panel();

            pnlMaHang.Dock = DockStyle.Fill;
            pnlMaHang.BackColor = Color.White;
            pnlMaHang.Padding = new Padding(4, 2, 6, 1);
            pnlMaHang.Margin = new Padding(2);

            tblMaHang = new TableLayoutPanel();

            tblMaHang.Dock = DockStyle.Fill;
            tblMaHang.ColumnCount = 1;
            tblMaHang.RowCount = 2;
            tblMaHang.BackColor = Color.White;
            tblMaHang.Margin = Padding.Empty;
            tblMaHang.Padding = Padding.Empty;
            tblMaHang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMaHang.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tblMaHang.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label10.Text = "Mã hàng";
            label10.Dock = DockStyle.Fill;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.ForeColor = Color.FromArgb(35, 51, 72);
            label10.TextAlign = ContentAlignment.MiddleLeft;
            label10.Margin = Padding.Empty;

            cboMaHang.Font = new Font("Segoe UI", 9.5F);
            cboMaHang.ForeColor = Color.FromArgb(35, 51, 72);
            cboMaHang.Dock = DockStyle.Fill;
            cboMaHang.Margin = new Padding(0, 1, 0, 1);
            cboMaHang.IntegralHeight = false;

            tblMaHang.Controls.Add(label10, 0, 0);
            tblMaHang.Controls.Add(cboMaHang, 0, 1);

            pnlMaHang.Controls.Add(tblMaHang);

            tblMatHang.Controls.Add(pnlMaHang, 0, 0);

            pnlTenHang = new Panel();

            pnlTenHang.Dock = DockStyle.Fill;
            pnlTenHang.BackColor = Color.White;
            pnlTenHang.Padding = new Padding(4, 2, 6, 1);
            pnlTenHang.Margin = new Padding(2);

            tblTenHang = new TableLayoutPanel();

            tblTenHang.Dock = DockStyle.Fill;
            tblTenHang.ColumnCount = 1;
            tblTenHang.RowCount = 2;
            tblTenHang.BackColor = Color.White;
            tblTenHang.Margin = Padding.Empty;
            tblTenHang.Padding = Padding.Empty;
            tblTenHang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblTenHang.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tblTenHang.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label12.Text = "Tên hàng";
            label12.Dock = DockStyle.Fill;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(35, 51, 72);
            label12.TextAlign = ContentAlignment.MiddleLeft;
            label12.Margin = Padding.Empty;

            txtTenHang.Font = new Font("Segoe UI", 9.5F);
            txtTenHang.ForeColor = Color.FromArgb(35, 51, 72);
            txtTenHang.BorderStyle = BorderStyle.FixedSingle;
            txtTenHang.BackColor = Color.FromArgb(250, 252, 255);
            txtTenHang.Dock = DockStyle.Fill;
            txtTenHang.Margin = new Padding(0, 1, 0, 1);

            tblTenHang.Controls.Add(label12, 0, 0);
            tblTenHang.Controls.Add(txtTenHang, 0, 1);

            pnlTenHang.Controls.Add(tblTenHang);

            tblMatHang.Controls.Add(pnlTenHang, 1, 0);

            pnlDonGia = new Panel();

            pnlDonGia.Dock = DockStyle.Fill;
            pnlDonGia.BackColor = Color.White;
            pnlDonGia.Padding = new Padding(4, 2, 6, 1);
            pnlDonGia.Margin = new Padding(2);

            tblDonGia = new TableLayoutPanel();

            tblDonGia.Dock = DockStyle.Fill;
            tblDonGia.ColumnCount = 1;
            tblDonGia.RowCount = 2;
            tblDonGia.BackColor = Color.White;
            tblDonGia.Margin = Padding.Empty;
            tblDonGia.Padding = Padding.Empty;
            tblDonGia.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblDonGia.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tblDonGia.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label14.Text = "Đơn giá";
            label14.Dock = DockStyle.Fill;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label14.ForeColor = Color.FromArgb(35, 51, 72);
            label14.TextAlign = ContentAlignment.MiddleLeft;
            label14.Margin = Padding.Empty;

            txtDonGia.Font = new Font("Segoe UI", 9.5F);
            txtDonGia.ForeColor = Color.FromArgb(35, 51, 72);
            txtDonGia.BorderStyle = BorderStyle.FixedSingle;
            txtDonGia.BackColor = Color.FromArgb(250, 252, 255);
            txtDonGia.Dock = DockStyle.Fill;
            txtDonGia.Margin = new Padding(0, 1, 0, 1);

            tblDonGia.Controls.Add(label14, 0, 0);
            tblDonGia.Controls.Add(txtDonGia, 0, 1);

            pnlDonGia.Controls.Add(tblDonGia);

            tblMatHang.Controls.Add(pnlDonGia, 2, 0);

            pnlSoLuong = new Panel();

            pnlSoLuong.Dock = DockStyle.Fill;
            pnlSoLuong.BackColor = Color.White;
            pnlSoLuong.Padding = new Padding(4, 2, 6, 1);
            pnlSoLuong.Margin = new Padding(2);

            tblSoLuong = new TableLayoutPanel();

            tblSoLuong.Dock = DockStyle.Fill;
            tblSoLuong.ColumnCount = 1;
            tblSoLuong.RowCount = 2;
            tblSoLuong.BackColor = Color.White;
            tblSoLuong.Margin = Padding.Empty;
            tblSoLuong.Padding = Padding.Empty;
            tblSoLuong.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblSoLuong.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tblSoLuong.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label11.Text = "Số lượng";
            label11.Dock = DockStyle.Fill;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.ForeColor = Color.FromArgb(35, 51, 72);
            label11.TextAlign = ContentAlignment.MiddleLeft;
            label11.Margin = Padding.Empty;

            txtSoLuong.Font = new Font("Segoe UI", 9.5F);
            txtSoLuong.ForeColor = Color.FromArgb(35, 51, 72);
            txtSoLuong.BorderStyle = BorderStyle.FixedSingle;
            txtSoLuong.BackColor = Color.FromArgb(250, 252, 255);
            txtSoLuong.Dock = DockStyle.Fill;
            txtSoLuong.Margin = new Padding(0, 1, 0, 1);
            txtSoLuong.MaxLength = 6;

            tblSoLuong.Controls.Add(label11, 0, 0);
            tblSoLuong.Controls.Add(txtSoLuong, 0, 1);

            pnlSoLuong.Controls.Add(tblSoLuong);

            tblMatHang.Controls.Add(pnlSoLuong, 0, 1);

            pnlGiamGia = new Panel();

            pnlGiamGia.Dock = DockStyle.Fill;
            pnlGiamGia.BackColor = Color.White;
            pnlGiamGia.Padding = new Padding(4, 2, 6, 1);
            pnlGiamGia.Margin = new Padding(2);

            tblGiamGia = new TableLayoutPanel();

            tblGiamGia.Dock = DockStyle.Fill;
            tblGiamGia.ColumnCount = 1;
            tblGiamGia.RowCount = 2;
            tblGiamGia.BackColor = Color.White;
            tblGiamGia.Margin = Padding.Empty;
            tblGiamGia.Padding = Padding.Empty;
            tblGiamGia.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblGiamGia.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tblGiamGia.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label13.Text = "Giảm giá (%)";
            label13.Dock = DockStyle.Fill;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label13.ForeColor = Color.FromArgb(35, 51, 72);
            label13.TextAlign = ContentAlignment.MiddleLeft;
            label13.Margin = Padding.Empty;

            txtGiamGia.Font = new Font("Segoe UI", 9.5F);
            txtGiamGia.ForeColor = Color.FromArgb(35, 51, 72);
            txtGiamGia.BorderStyle = BorderStyle.FixedSingle;
            txtGiamGia.BackColor = Color.FromArgb(250, 252, 255);
            txtGiamGia.Dock = DockStyle.Fill;
            txtGiamGia.Margin = new Padding(0, 1, 0, 1);
            txtGiamGia.MaxLength = 5;

            tblGiamGia.Controls.Add(label13, 0, 0);
            tblGiamGia.Controls.Add(txtGiamGia, 0, 1);

            pnlGiamGia.Controls.Add(tblGiamGia);

            tblMatHang.Controls.Add(pnlGiamGia, 1, 1);

            pnlThanhTien = new Panel();

            pnlThanhTien.Dock = DockStyle.Fill;
            pnlThanhTien.BackColor = Color.White;
            pnlThanhTien.Padding = new Padding(4, 2, 6, 1);
            pnlThanhTien.Margin = new Padding(2);

            tblThanhTien = new TableLayoutPanel();

            tblThanhTien.Dock = DockStyle.Fill;
            tblThanhTien.ColumnCount = 1;
            tblThanhTien.RowCount = 2;
            tblThanhTien.BackColor = Color.White;
            tblThanhTien.Margin = Padding.Empty;
            tblThanhTien.Padding = Padding.Empty;
            tblThanhTien.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblThanhTien.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tblThanhTien.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label15.Text = "Thành tiền";
            label15.Dock = DockStyle.Fill;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label15.ForeColor = Color.FromArgb(35, 51, 72);
            label15.TextAlign = ContentAlignment.MiddleLeft;
            label15.Margin = Padding.Empty;

            txtThanhTien.Font = new Font("Segoe UI", 9.5F);
            txtThanhTien.ForeColor = Color.FromArgb(35, 51, 72);
            txtThanhTien.BorderStyle = BorderStyle.FixedSingle;
            txtThanhTien.BackColor = Color.FromArgb(250, 252, 255);
            txtThanhTien.Dock = DockStyle.Fill;
            txtThanhTien.Margin = new Padding(0, 1, 0, 1);

            tblThanhTien.Controls.Add(label15, 0, 0);
            tblThanhTien.Controls.Add(txtThanhTien, 0, 1);

            pnlThanhTien.Controls.Add(tblThanhTien);

            tblMatHang.Controls.Add(pnlThanhTien, 2, 1);

            btnThemHang.Text = "＋ Thêm hàng";
            btnThemHang.BackColor = Color.FromArgb(36, 155, 110);
            btnThemHang.ForeColor = Color.White;
            btnThemHang.FlatStyle = FlatStyle.Flat;
            btnThemHang.FlatAppearance.BorderSize = 0;
            btnThemHang.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThemHang.Cursor = Cursors.Hand;
            btnThemHang.UseVisualStyleBackColor = false;
            btnThemHang.Dock = DockStyle.Fill;
            btnThemHang.Margin = new Padding(4, 20, 4, 20);

            tblMatHang.Controls.Add(btnThemHang, 3, 0);
            tblMatHang.SetRowSpan(btnThemHang, 2);

            groupBox2.Controls.Add(tblMatHang);

            tblMain.Controls.Add(groupBox2, 0, 2);

            groupBox3.Text = "CHI TIẾT HÓA ĐƠN";
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox3.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox3.BackColor = Color.White;
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Margin = new Padding(0, 0, 0, 7);
            groupBox3.Padding = new Padding(8, 10, 8, 4);

            tblChiTiet = new TableLayoutPanel();

            tblChiTiet.Dock = DockStyle.Fill;
            tblChiTiet.ColumnCount = 1;
            tblChiTiet.RowCount = 2;
            tblChiTiet.BackColor = Color.White;
            tblChiTiet.Margin = Padding.Empty;
            tblChiTiet.Padding = Padding.Empty;
            tblChiTiet.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblChiTiet.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblChiTiet.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

            dgvChiTiet.Dock = DockStyle.Fill;
            dgvChiTiet.Margin = Padding.Empty;
            dgvChiTiet.BackgroundColor = Color.White;
            dgvChiTiet.BorderStyle = BorderStyle.None;
            dgvChiTiet.GridColor = Color.FromArgb(220, 227, 237);
            dgvChiTiet.EnableHeadersVisualStyles = false;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 43, 74);
            dgvChiTiet.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvChiTiet.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiTiet.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvChiTiet.DefaultCellStyle.ForeColor = Color.FromArgb(35, 51, 72);
            dgvChiTiet.DefaultCellStyle.BackColor = Color.White;
            dgvChiTiet.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 232, 250);
            dgvChiTiet.DefaultCellStyle.SelectionForeColor = Color.FromArgb(35, 51, 72);
            dgvChiTiet.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 248, 253);
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.MultiSelect = false;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.RowHeadersVisible = false;
            dgvChiTiet.RowTemplate.Height = 30;
            dgvChiTiet.ColumnHeadersHeight = 36;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvChiTiet.MinimumSize = new Size(0, 120);

            lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.FromArgb(220, 75, 75);
            lblTongTien.Dock = DockStyle.Fill;
            lblTongTien.TextAlign = ContentAlignment.MiddleRight;
            lblTongTien.Margin = new Padding(0, 2, 8, 0);

            tblChiTiet.Controls.Add(dgvChiTiet, 0, 0);
            tblChiTiet.Controls.Add(lblTongTien, 0, 1);

            groupBox3.Controls.Add(tblChiTiet);

            tblMain.Controls.Add(groupBox3, 0, 3);

            groupBox4.Text = "CHỨC NĂNG";
            groupBox4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox4.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox4.BackColor = Color.White;
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Margin = Padding.Empty;
            groupBox4.Padding = new Padding(8, 4, 8, 3);

            flpChucNang = new FlowLayoutPanel();

            flpChucNang.Dock = DockStyle.Fill;
            flpChucNang.FlowDirection = FlowDirection.LeftToRight;
            flpChucNang.WrapContents = false;
            flpChucNang.AutoScroll = true;
            flpChucNang.BackColor = Color.White;
            flpChucNang.Padding = new Padding(2, 0, 2, 0);
            flpChucNang.Margin = Padding.Empty;

            btnThemHD.Text = "＋ Thêm mới";
            btnThemHD.BackColor = Color.FromArgb(36, 120, 212);
            btnThemHD.ForeColor = Color.White;
            btnThemHD.FlatStyle = FlatStyle.Flat;
            btnThemHD.FlatAppearance.BorderSize = 0;
            btnThemHD.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThemHD.Cursor = Cursors.Hand;
            btnThemHD.UseVisualStyleBackColor = false;
            btnThemHD.Size = new Size(112, 32);
            btnThemHD.Margin = new Padding(3);

            btnLuu.Text = "✓ Lưu hóa đơn";
            btnLuu.BackColor = Color.FromArgb(36, 155, 110);
            btnLuu.ForeColor = Color.White;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLuu.Cursor = Cursors.Hand;
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Size = new Size(122, 32);
            btnLuu.Margin = new Padding(3);

            btnHuy.Text = "✕ Hủy bỏ";
            btnHuy.BackColor = Color.FromArgb(220, 75, 75);
            btnHuy.ForeColor = Color.White;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnHuy.Cursor = Cursors.Hand;
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Size = new Size(100, 32);
            btnHuy.Margin = new Padding(3);

            btnIn.Text = "▤ In hóa đơn";
            btnIn.BackColor = Color.FromArgb(105, 119, 139);
            btnIn.ForeColor = Color.White;
            btnIn.FlatStyle = FlatStyle.Flat;
            btnIn.FlatAppearance.BorderSize = 0;
            btnIn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnIn.Cursor = Cursors.Hand;
            btnIn.UseVisualStyleBackColor = false;
            btnIn.Size = new Size(126, 32);
            btnIn.Margin = new Padding(3);

            btnThoat.Text = "← Thoát";
            btnThoat.BackColor = Color.FromArgb(70, 82, 100);
            btnThoat.ForeColor = Color.White;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Size = new Size(92, 32);
            btnThoat.Margin = new Padding(3);

            flpChucNang.Controls.Add(btnThemHD);
            flpChucNang.Controls.Add(btnLuu);
            flpChucNang.Controls.Add(btnHuy);
            flpChucNang.Controls.Add(btnIn);
            flpChucNang.Controls.Add(btnThoat);

            groupBox4.Controls.Add(flpChucNang);

            tblMain.Controls.Add(groupBox4, 0, 4);

            Controls.Add(tblMain);

            ((System.ComponentModel.ISupportInitialize)(dgvChiTiet)).EndInit();
            ResumeLayout(false);
        }

        // KHAI BÁO CONTROL

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
        private Label label15;
        private ComboBox cboMaHD;
        private TextBox txtMaNV;
        private TextBox txtSDT;
        private TextBox txtTenKH;
        private TextBox txtTenNV;
        private DateTimePicker dtpNgayLap;
        private ComboBox cboKhachHang;
        private TextBox txtDiaChi;
        private ComboBox cboMaHang;
        private TextBox txtSoLuong;
        private TextBox txtTenHang;
        private TextBox txtGiamGia;
        private TextBox txtDonGia;
        private TextBox txtThanhTien;
        private Button btnTim;
        private Button btnThemHang;
        private DataGridView dgvChiTiet;
        private Label lblTongTien;
        private Button btnThemHD;
        private Button btnLuu;
        private Button btnHuy;
        private Button btnIn;
        private Button btnThoat;
        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblThongTin;
        private Panel pnlMaHoaDon;
        private TableLayoutPanel tblMaHoaDon;
        private TableLayoutPanel tblInputMaHoaDon;
        private Panel pnlNgayLap;
        private TableLayoutPanel tblNgayLap;
        private Panel pnlMaNhanVien;
        private TableLayoutPanel tblMaNhanVien;
        private Panel pnlTenNhanVien;
        private TableLayoutPanel tblTenNhanVien;
        private Panel pnlKhachHang;
        private TableLayoutPanel tblKhachHang;
        private Panel pnlSdtKhach;
        private TableLayoutPanel tblSdtKhach;
        private Panel pnlTenKhach;
        private TableLayoutPanel tblTenKhach;
        private Panel pnlDiaChi;
        private TableLayoutPanel tblDiaChi;
        private TableLayoutPanel tblMatHang;
        private Panel pnlMaHang;
        private TableLayoutPanel tblMaHang;
        private Panel pnlTenHang;
        private TableLayoutPanel tblTenHang;
        private Panel pnlDonGia;
        private TableLayoutPanel tblDonGia;
        private Panel pnlSoLuong;
        private TableLayoutPanel tblSoLuong;
        private Panel pnlGiamGia;
        private TableLayoutPanel tblGiamGia;
        private Panel pnlThanhTien;
        private TableLayoutPanel tblThanhTien;
        private TableLayoutPanel tblChiTiet;
        private FlowLayoutPanel flpChucNang;
    }
}
