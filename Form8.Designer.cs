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
            cboMaHDN = new ComboBox();
            txtMaNV = new TextBox();
            cboNCC = new ComboBox();
            txtSDT = new TextBox();
            dtpNgayNhap = new DateTimePicker();
            txtTenNV = new TextBox();
            txtMaNCC = new TextBox();
            txtDiaChi = new TextBox();
            cboMaHang = new ComboBox();
            txtTenHang = new TextBox();
            txtDonGiaNhap = new TextBox();
            txtSoLuong = new TextBox();
            txtThanhTien = new TextBox();
            btnTim = new Button();
            button1 = new Button();
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
            Font = new Font("Segoe UI", 10F);
            Name = "Form8";
            Text = "HÓA ĐƠN NHẬP HÀNG";
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
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 320F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 280F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));

            label1.Text = "HÓA ĐƠN NHẬP HÀNG";
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(20, 43, 74);
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Margin = new Padding(5, 0, 0, 4);
            label1.Click += label1_Click;

            tblMain.Controls.Add(label1, 0, 0);

            groupBox1.Text = "THÔNG TIN CHUNG";
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox1.BackColor = Color.White;
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Margin = new Padding(0, 0, 0, 7);
            groupBox1.Padding = new Padding(8, 12, 8, 5);

            tblThongTin = new TableLayoutPanel();

            tblThongTin.Dock = DockStyle.Fill;
            tblThongTin.ColumnCount = 3;
            tblThongTin.RowCount = 3;
            tblThongTin.BackColor = Color.White;
            tblThongTin.Margin = Padding.Empty;
            tblThongTin.Padding = Padding.Empty;
            tblThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tblThongTin.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tblThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tblThongTin.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tblThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tblThongTin.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));

            pnlMaHoaDonNhap = new Panel();

            pnlMaHoaDonNhap.Dock = DockStyle.Fill;
            pnlMaHoaDonNhap.BackColor = Color.White;
            pnlMaHoaDonNhap.Padding = new Padding(4, 2, 8, 2);
            pnlMaHoaDonNhap.Margin = new Padding(2);

            tblMaHoaDonNhap = new TableLayoutPanel();

            tblMaHoaDonNhap.Dock = DockStyle.Fill;
            tblMaHoaDonNhap.ColumnCount = 1;
            tblMaHoaDonNhap.RowCount = 2;
            tblMaHoaDonNhap.BackColor = Color.White;
            tblMaHoaDonNhap.Margin = Padding.Empty;
            tblMaHoaDonNhap.Padding = Padding.Empty;
            tblMaHoaDonNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMaHoaDonNhap.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tblMaHoaDonNhap.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label2.Text = "Mã hóa đơn nhập";
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(35, 51, 72);
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Margin = Padding.Empty;

            tblInputMaHoaDonNhap = new TableLayoutPanel();

            tblInputMaHoaDonNhap.Dock = DockStyle.Fill;
            tblInputMaHoaDonNhap.ColumnCount = 2;
            tblInputMaHoaDonNhap.RowCount = 1;
            tblInputMaHoaDonNhap.Margin = new Padding(0, 8, 0, 1);
            tblInputMaHoaDonNhap.Padding = Padding.Empty;
            tblInputMaHoaDonNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblInputMaHoaDonNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 65F));
            tblInputMaHoaDonNhap.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            cboMaHDN.Font = new Font("Segoe UI", 9.5F);
            cboMaHDN.ForeColor = Color.FromArgb(35, 51, 72);
            cboMaHDN.Dock = DockStyle.Fill;
            cboMaHDN.Margin = new Padding(0, 0, 4, 0);

            btnTim.Text = "⌕ Tìm";
            btnTim.BackColor = Color.FromArgb(36, 120, 212);
            btnTim.ForeColor = Color.White;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.FlatAppearance.BorderSize = 0;
            btnTim.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTim.Cursor = Cursors.Hand;
            btnTim.UseVisualStyleBackColor = false;
            btnTim.Dock = DockStyle.Fill;
            btnTim.Margin = Padding.Empty;
            btnTim.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            tblInputMaHoaDonNhap.Controls.Add(cboMaHDN, 0, 0);
            tblInputMaHoaDonNhap.Controls.Add(btnTim, 1, 0);

            tblMaHoaDonNhap.Controls.Add(label2, 0, 0);
            tblMaHoaDonNhap.Controls.Add(tblInputMaHoaDonNhap, 0, 1);

            pnlMaHoaDonNhap.Controls.Add(tblMaHoaDonNhap);

            tblThongTin.Controls.Add(pnlMaHoaDonNhap, 0, 0);

            pnlNgayNhap = new Panel();

            pnlNgayNhap.Dock = DockStyle.Fill;
            pnlNgayNhap.BackColor = Color.White;
            pnlNgayNhap.Padding = new Padding(4, 2, 8, 2);
            pnlNgayNhap.Margin = new Padding(2);

            tblNgayNhap = new TableLayoutPanel();

            tblNgayNhap.Dock = DockStyle.Fill;
            tblNgayNhap.ColumnCount = 1;
            tblNgayNhap.RowCount = 2;
            tblNgayNhap.BackColor = Color.White;
            tblNgayNhap.Margin = Padding.Empty;
            tblNgayNhap.Padding = Padding.Empty;
            tblNgayNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblNgayNhap.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tblNgayNhap.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label6.Text = "Ngày nhập";
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(35, 51, 72);
            label6.TextAlign = ContentAlignment.MiddleLeft;
            label6.Margin = Padding.Empty;

            dtpNgayNhap.Font = new Font("Segoe UI", 9.5F);
            dtpNgayNhap.ForeColor = Color.FromArgb(35, 51, 72);
            dtpNgayNhap.Dock = DockStyle.Fill;
            dtpNgayNhap.Margin = new Padding(0, 8, 0, 1);

            tblNgayNhap.Controls.Add(label6, 0, 0);
            tblNgayNhap.Controls.Add(dtpNgayNhap, 0, 1);

            pnlNgayNhap.Controls.Add(tblNgayNhap);

            tblThongTin.Controls.Add(pnlNgayNhap, 1, 0);

            pnlMaNhanVien = new Panel();

            pnlMaNhanVien.Dock = DockStyle.Fill;
            pnlMaNhanVien.BackColor = Color.White;
            pnlMaNhanVien.Padding = new Padding(4, 2, 8, 2);
            pnlMaNhanVien.Margin = new Padding(2);

            tblMaNhanVien = new TableLayoutPanel();

            tblMaNhanVien.Dock = DockStyle.Fill;
            tblMaNhanVien.ColumnCount = 1;
            tblMaNhanVien.RowCount = 2;
            tblMaNhanVien.BackColor = Color.White;
            tblMaNhanVien.Margin = Padding.Empty;
            tblMaNhanVien.Padding = Padding.Empty;
            tblMaNhanVien.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMaNhanVien.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
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
            txtMaNV.Margin = new Padding(0, 8, 0, 1);

            tblMaNhanVien.Controls.Add(label3, 0, 0);
            tblMaNhanVien.Controls.Add(txtMaNV, 0, 1);

            pnlMaNhanVien.Controls.Add(tblMaNhanVien);

            tblThongTin.Controls.Add(pnlMaNhanVien, 2, 0);

            pnlTenNhanVien = new Panel();

            pnlTenNhanVien.Dock = DockStyle.Fill;
            pnlTenNhanVien.BackColor = Color.White;
            pnlTenNhanVien.Padding = new Padding(4, 2, 8, 2);
            pnlTenNhanVien.Margin = new Padding(2);

            tblTenNhanVien = new TableLayoutPanel();

            tblTenNhanVien.Dock = DockStyle.Fill;
            tblTenNhanVien.ColumnCount = 1;
            tblTenNhanVien.RowCount = 2;
            tblTenNhanVien.BackColor = Color.White;
            tblTenNhanVien.Margin = Padding.Empty;
            tblTenNhanVien.Padding = Padding.Empty;
            tblTenNhanVien.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblTenNhanVien.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
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
            txtTenNV.Margin = new Padding(0, 8, 0, 1);

            tblTenNhanVien.Controls.Add(label7, 0, 0);
            tblTenNhanVien.Controls.Add(txtTenNV, 0, 1);

            pnlTenNhanVien.Controls.Add(tblTenNhanVien);

            tblThongTin.Controls.Add(pnlTenNhanVien, 0, 1);

            pnlNhaCungCap = new Panel();

            pnlNhaCungCap.Dock = DockStyle.Fill;
            pnlNhaCungCap.BackColor = Color.White;
            pnlNhaCungCap.Padding = new Padding(4, 2, 8, 2);
            pnlNhaCungCap.Margin = new Padding(2);

            tblNhaCungCap = new TableLayoutPanel();

            tblNhaCungCap.Dock = DockStyle.Fill;
            tblNhaCungCap.ColumnCount = 1;
            tblNhaCungCap.RowCount = 2;
            tblNhaCungCap.BackColor = Color.White;
            tblNhaCungCap.Margin = Padding.Empty;
            tblNhaCungCap.Padding = Padding.Empty;
            tblNhaCungCap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblNhaCungCap.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tblNhaCungCap.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label4.Text = "Nhà cung cấp";
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(35, 51, 72);
            label4.TextAlign = ContentAlignment.MiddleLeft;
            label4.Margin = Padding.Empty;

            cboNCC.Font = new Font("Segoe UI", 9.5F);
            cboNCC.ForeColor = Color.FromArgb(35, 51, 72);
            cboNCC.Dock = DockStyle.Fill;
            cboNCC.Margin = new Padding(0, 8, 0, 1);

            tblNhaCungCap.Controls.Add(label4, 0, 0);
            tblNhaCungCap.Controls.Add(cboNCC, 0, 1);

            pnlNhaCungCap.Controls.Add(tblNhaCungCap);

            tblThongTin.Controls.Add(pnlNhaCungCap, 1, 1);

            pnlSdtNhaCungCap = new Panel();

            pnlSdtNhaCungCap.Dock = DockStyle.Fill;
            pnlSdtNhaCungCap.BackColor = Color.White;
            pnlSdtNhaCungCap.Padding = new Padding(4, 2, 8, 2);
            pnlSdtNhaCungCap.Margin = new Padding(2);

            tblSdtNhaCungCap = new TableLayoutPanel();

            tblSdtNhaCungCap.Dock = DockStyle.Fill;
            tblSdtNhaCungCap.ColumnCount = 1;
            tblSdtNhaCungCap.RowCount = 2;
            tblSdtNhaCungCap.BackColor = Color.White;
            tblSdtNhaCungCap.Margin = Padding.Empty;
            tblSdtNhaCungCap.Padding = Padding.Empty;
            tblSdtNhaCungCap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblSdtNhaCungCap.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tblSdtNhaCungCap.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label5.Text = "SĐT nhà cung cấp";
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(35, 51, 72);
            label5.TextAlign = ContentAlignment.MiddleLeft;
            label5.Margin = Padding.Empty;

            txtSDT.Font = new Font("Segoe UI", 9.5F);
            txtSDT.ForeColor = Color.FromArgb(35, 51, 72);
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.BackColor = Color.FromArgb(250, 252, 255);
            txtSDT.Dock = DockStyle.Fill;
            txtSDT.Margin = new Padding(0, 8, 0, 1);

            tblSdtNhaCungCap.Controls.Add(label5, 0, 0);
            tblSdtNhaCungCap.Controls.Add(txtSDT, 0, 1);

            pnlSdtNhaCungCap.Controls.Add(tblSdtNhaCungCap);

            tblThongTin.Controls.Add(pnlSdtNhaCungCap, 2, 1);

            pnlMaNhaCungCap = new Panel();

            pnlMaNhaCungCap.Dock = DockStyle.Fill;
            pnlMaNhaCungCap.BackColor = Color.White;
            pnlMaNhaCungCap.Padding = new Padding(4, 2, 8, 2);
            pnlMaNhaCungCap.Margin = new Padding(2);

            tblMaNhaCungCap = new TableLayoutPanel();

            tblMaNhaCungCap.Dock = DockStyle.Fill;
            tblMaNhaCungCap.ColumnCount = 1;
            tblMaNhaCungCap.RowCount = 2;
            tblMaNhaCungCap.BackColor = Color.White;
            tblMaNhaCungCap.Margin = Padding.Empty;
            tblMaNhaCungCap.Padding = Padding.Empty;
            tblMaNhaCungCap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMaNhaCungCap.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tblMaNhaCungCap.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label8.Text = "Mã nhà cung cấp";
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(35, 51, 72);
            label8.TextAlign = ContentAlignment.MiddleLeft;
            label8.Margin = Padding.Empty;

            txtMaNCC.Font = new Font("Segoe UI", 9.5F);
            txtMaNCC.ForeColor = Color.FromArgb(35, 51, 72);
            txtMaNCC.BorderStyle = BorderStyle.FixedSingle;
            txtMaNCC.BackColor = Color.FromArgb(250, 252, 255);
            txtMaNCC.Dock = DockStyle.Fill;
            txtMaNCC.Margin = new Padding(0, 8, 0, 1);

            tblMaNhaCungCap.Controls.Add(label8, 0, 0);
            tblMaNhaCungCap.Controls.Add(txtMaNCC, 0, 1);

            pnlMaNhaCungCap.Controls.Add(tblMaNhaCungCap);

            tblThongTin.Controls.Add(pnlMaNhaCungCap, 0, 2);

            pnlDiaChi = new Panel();

            pnlDiaChi.Dock = DockStyle.Fill;
            pnlDiaChi.BackColor = Color.White;
            pnlDiaChi.Padding = new Padding(4, 2, 8, 2);
            pnlDiaChi.Margin = new Padding(2);

            tblDiaChi = new TableLayoutPanel();

            tblDiaChi.Dock = DockStyle.Fill;
            tblDiaChi.ColumnCount = 1;
            tblDiaChi.RowCount = 2;
            tblDiaChi.BackColor = Color.White;
            tblDiaChi.Margin = Padding.Empty;
            tblDiaChi.Padding = Padding.Empty;
            tblDiaChi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblDiaChi.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
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
            txtDiaChi.Margin = new Padding(0, 8, 0, 1);

            tblDiaChi.Controls.Add(label9, 0, 0);
            tblDiaChi.Controls.Add(txtDiaChi, 0, 1);

            pnlDiaChi.Controls.Add(tblDiaChi);

            tblThongTin.Controls.Add(pnlDiaChi, 1, 2);

            tblThongTin.SetColumnSpan(pnlDiaChi, 2);

            groupBox1.Controls.Add(tblThongTin);

            tblMain.Controls.Add(groupBox1, 0, 1);

            groupBox2.Text = "CHỌN MẶT HÀNG";
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox2.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox2.BackColor = Color.White;
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Margin = new Padding(0, 0, 0, 7);
            groupBox2.Padding = new Padding(8, 12, 8, 5);

            tblMatHang = new TableLayoutPanel();

            tblMatHang.Dock = DockStyle.Fill;
            tblMatHang.ColumnCount = 4;
            tblMatHang.RowCount = 2;
            tblMatHang.BackColor = Color.White;
            tblMatHang.Margin = Padding.Empty;
            tblMatHang.Padding = Padding.Empty;
            tblMatHang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
            tblMatHang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
            tblMatHang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
            tblMatHang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            tblMatHang.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMatHang.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            pnlMaHang = new Panel();

            pnlMaHang.Dock = DockStyle.Fill;
            pnlMaHang.BackColor = Color.White;
            pnlMaHang.Padding = new Padding(4, 2, 8, 2);
            pnlMaHang.Margin = new Padding(2);

            tblMaHang = new TableLayoutPanel();

            tblMaHang.Dock = DockStyle.Fill;
            tblMaHang.ColumnCount = 1;
            tblMaHang.RowCount = 2;
            tblMaHang.BackColor = Color.White;
            tblMaHang.Margin = Padding.Empty;
            tblMaHang.Padding = Padding.Empty;
            tblMaHang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMaHang.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
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
            cboMaHang.Margin = new Padding(0, 8, 0, 1);

            tblMaHang.Controls.Add(label10, 0, 0);
            tblMaHang.Controls.Add(cboMaHang, 0, 1);

            pnlMaHang.Controls.Add(tblMaHang);

            tblMatHang.Controls.Add(pnlMaHang, 0, 0);

            pnlTenHang = new Panel();

            pnlTenHang.Dock = DockStyle.Fill;
            pnlTenHang.BackColor = Color.White;
            pnlTenHang.Padding = new Padding(4, 2, 8, 2);
            pnlTenHang.Margin = new Padding(2);

            tblTenHang = new TableLayoutPanel();

            tblTenHang.Dock = DockStyle.Fill;
            tblTenHang.ColumnCount = 1;
            tblTenHang.RowCount = 2;
            tblTenHang.BackColor = Color.White;
            tblTenHang.Margin = Padding.Empty;
            tblTenHang.Padding = Padding.Empty;
            tblTenHang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblTenHang.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
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
            txtTenHang.Margin = new Padding(0, 8, 0, 1);

            tblTenHang.Controls.Add(label12, 0, 0);
            tblTenHang.Controls.Add(txtTenHang, 0, 1);

            pnlTenHang.Controls.Add(tblTenHang);

            tblMatHang.Controls.Add(pnlTenHang, 1, 0);

            pnlDonGiaNhap = new Panel();

            pnlDonGiaNhap.Dock = DockStyle.Fill;
            pnlDonGiaNhap.BackColor = Color.White;
            pnlDonGiaNhap.Padding = new Padding(4, 2, 8, 2);
            pnlDonGiaNhap.Margin = new Padding(2);

            tblDonGiaNhap = new TableLayoutPanel();

            tblDonGiaNhap.Dock = DockStyle.Fill;
            tblDonGiaNhap.ColumnCount = 1;
            tblDonGiaNhap.RowCount = 2;
            tblDonGiaNhap.BackColor = Color.White;
            tblDonGiaNhap.Margin = Padding.Empty;
            tblDonGiaNhap.Padding = Padding.Empty;
            tblDonGiaNhap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblDonGiaNhap.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tblDonGiaNhap.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label14.Text = "Đơn giá nhập";
            label14.Dock = DockStyle.Fill;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label14.ForeColor = Color.FromArgb(35, 51, 72);
            label14.TextAlign = ContentAlignment.MiddleLeft;
            label14.Margin = Padding.Empty;

            txtDonGiaNhap.Font = new Font("Segoe UI", 9.5F);
            txtDonGiaNhap.ForeColor = Color.FromArgb(35, 51, 72);
            txtDonGiaNhap.BorderStyle = BorderStyle.FixedSingle;
            txtDonGiaNhap.BackColor = Color.FromArgb(250, 252, 255);
            txtDonGiaNhap.Dock = DockStyle.Fill;
            txtDonGiaNhap.Margin = new Padding(0, 8, 0, 1);

            tblDonGiaNhap.Controls.Add(label14, 0, 0);
            tblDonGiaNhap.Controls.Add(txtDonGiaNhap, 0, 1);

            pnlDonGiaNhap.Controls.Add(tblDonGiaNhap);

            tblMatHang.Controls.Add(pnlDonGiaNhap, 2, 0);

            pnlSoLuong = new Panel();

            pnlSoLuong.Dock = DockStyle.Fill;
            pnlSoLuong.BackColor = Color.White;
            pnlSoLuong.Padding = new Padding(4, 2, 8, 2);
            pnlSoLuong.Margin = new Padding(2);

            tblSoLuong = new TableLayoutPanel();

            tblSoLuong.Dock = DockStyle.Fill;
            tblSoLuong.ColumnCount = 1;
            tblSoLuong.RowCount = 2;
            tblSoLuong.BackColor = Color.White;
            tblSoLuong.Margin = Padding.Empty;
            tblSoLuong.Padding = Padding.Empty;
            tblSoLuong.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblSoLuong.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
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
            txtSoLuong.Margin = new Padding(0, 8, 0, 1);

            tblSoLuong.Controls.Add(label11, 0, 0);
            tblSoLuong.Controls.Add(txtSoLuong, 0, 1);

            pnlSoLuong.Controls.Add(tblSoLuong);

            tblMatHang.Controls.Add(pnlSoLuong, 0, 1);

            pnlThanhTien = new Panel();

            pnlThanhTien.Dock = DockStyle.Fill;
            pnlThanhTien.BackColor = Color.White;
            pnlThanhTien.Padding = new Padding(4, 2, 8, 2);
            pnlThanhTien.Margin = new Padding(2);

            tblThanhTien = new TableLayoutPanel();

            tblThanhTien.Dock = DockStyle.Fill;
            tblThanhTien.ColumnCount = 1;
            tblThanhTien.RowCount = 2;
            tblThanhTien.BackColor = Color.White;
            tblThanhTien.Margin = Padding.Empty;
            tblThanhTien.Padding = Padding.Empty;
            tblThanhTien.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblThanhTien.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tblThanhTien.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label13.Text = "Thành tiền";
            label13.Dock = DockStyle.Fill;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label13.ForeColor = Color.FromArgb(35, 51, 72);
            label13.TextAlign = ContentAlignment.MiddleLeft;
            label13.Margin = Padding.Empty;

            txtThanhTien.Font = new Font("Segoe UI", 9.5F);
            txtThanhTien.ForeColor = Color.FromArgb(35, 51, 72);
            txtThanhTien.BorderStyle = BorderStyle.FixedSingle;
            txtThanhTien.BackColor = Color.FromArgb(250, 252, 255);
            txtThanhTien.Dock = DockStyle.Fill;
            txtThanhTien.Margin = new Padding(0, 8, 0, 1);

            tblThanhTien.Controls.Add(label13, 0, 0);
            tblThanhTien.Controls.Add(txtThanhTien, 0, 1);

            pnlThanhTien.Controls.Add(tblThanhTien);

            tblMatHang.Controls.Add(pnlThanhTien, 1, 1);

            tblMatHang.SetColumnSpan(pnlThanhTien, 2);

            button1.Text = "＋ Thêm hàng";
            button1.BackColor = Color.FromArgb(36, 155, 110);
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button1.Cursor = Cursors.Hand;
            button1.UseVisualStyleBackColor = false;
            button1.Dock = DockStyle.None;
            button1.Anchor = AnchorStyles.None;
            button1.Size = new Size(160, 42);
            button1.Margin = new Padding(5);

            tblMatHang.Controls.Add(button1, 3, 0);

            tblMatHang.SetRowSpan(button1, 2);

            groupBox2.Controls.Add(tblMatHang);

            tblMain.Controls.Add(groupBox2, 0, 2);

            groupBox3.Text = "CHI TIẾT HÓA ĐƠN NHẬP";
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox3.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox3.BackColor = Color.White;
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Margin = new Padding(0, 0, 0, 7);
            groupBox3.Padding = new Padding(8, 12, 8, 5);

            tblChiTiet = new TableLayoutPanel();

            tblChiTiet.Dock = DockStyle.Fill;
            tblChiTiet.ColumnCount = 1;
            tblChiTiet.RowCount = 2;
            tblChiTiet.BackColor = Color.White;
            tblChiTiet.Margin = Padding.Empty;
            tblChiTiet.Padding = Padding.Empty;
            tblChiTiet.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblChiTiet.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblChiTiet.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));

            dgvChiTiet.Dock = DockStyle.Fill;
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
            dgvChiTiet.RowTemplate.Height = 32;
            dgvChiTiet.ColumnHeadersHeight = 38;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.FromArgb(220, 75, 75);
            lblTongTien.Dock = DockStyle.Fill;
            lblTongTien.TextAlign = ContentAlignment.MiddleRight;
            lblTongTien.Margin = new Padding(0, 0, 8, 0);

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
            groupBox4.Padding = new Padding(8, 10, 8, 5);

            flpChucNang = new FlowLayoutPanel();

            flpChucNang.Dock = DockStyle.Fill;
            flpChucNang.FlowDirection = FlowDirection.LeftToRight;
            flpChucNang.WrapContents = false;
            flpChucNang.AutoScroll = true;
            flpChucNang.BackColor = Color.White;
            flpChucNang.Padding = new Padding(2, 5, 2, 2);
            flpChucNang.Margin = Padding.Empty;

            btnThemHD.Text = "＋ Thêm mới";
            btnThemHD.BackColor = Color.FromArgb(36, 120, 212);
            btnThemHD.ForeColor = Color.White;
            btnThemHD.FlatStyle = FlatStyle.Flat;
            btnThemHD.FlatAppearance.BorderSize = 0;
            btnThemHD.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThemHD.Cursor = Cursors.Hand;
            btnThemHD.UseVisualStyleBackColor = false;
            btnThemHD.Size = new Size(125, 38);

            btnLuu.Text = "✓ Lưu hóa đơn";
            btnLuu.BackColor = Color.FromArgb(36, 155, 110);
            btnLuu.ForeColor = Color.White;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLuu.Cursor = Cursors.Hand;
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Size = new Size(135, 38);

            btnHuy.Text = "✕ Hủy bỏ";
            btnHuy.BackColor = Color.FromArgb(220, 75, 75);
            btnHuy.ForeColor = Color.White;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnHuy.Cursor = Cursors.Hand;
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Size = new Size(125, 38);

            btnIn.Text = "▤ In hóa đơn";
            btnIn.BackColor = Color.FromArgb(105, 119, 139);
            btnIn.ForeColor = Color.White;
            btnIn.FlatStyle = FlatStyle.Flat;
            btnIn.FlatAppearance.BorderSize = 0;
            btnIn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnIn.Cursor = Cursors.Hand;
            btnIn.UseVisualStyleBackColor = false;
            btnIn.Size = new Size(140, 38);

            btnThoat.Text = "← Thoát";
            btnThoat.BackColor = Color.FromArgb(70, 82, 100);
            btnThoat.ForeColor = Color.White;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Size = new Size(115, 38);

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
        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblThongTin;
        private Panel pnlMaHoaDonNhap;
        private TableLayoutPanel tblMaHoaDonNhap;
        private TableLayoutPanel tblInputMaHoaDonNhap;
        private Panel pnlNgayNhap;
        private TableLayoutPanel tblNgayNhap;
        private Panel pnlMaNhanVien;
        private TableLayoutPanel tblMaNhanVien;
        private Panel pnlTenNhanVien;
        private TableLayoutPanel tblTenNhanVien;
        private Panel pnlNhaCungCap;
        private TableLayoutPanel tblNhaCungCap;
        private Panel pnlSdtNhaCungCap;
        private TableLayoutPanel tblSdtNhaCungCap;
        private Panel pnlMaNhaCungCap;
        private TableLayoutPanel tblMaNhaCungCap;
        private Panel pnlDiaChi;
        private TableLayoutPanel tblDiaChi;
        private TableLayoutPanel tblMatHang;
        private Panel pnlMaHang;
        private TableLayoutPanel tblMaHang;
        private Panel pnlTenHang;
        private TableLayoutPanel tblTenHang;
        private Panel pnlDonGiaNhap;
        private TableLayoutPanel tblDonGiaNhap;
        private Panel pnlSoLuong;
        private TableLayoutPanel tblSoLuong;
        private Panel pnlThanhTien;
        private TableLayoutPanel tblThanhTien;
        private TableLayoutPanel tblChiTiet;
        private FlowLayoutPanel flpChucNang;
    }
}
