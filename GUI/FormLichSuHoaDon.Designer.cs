using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4.GUI
{
    partial class FormLichSuHoaDon
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
            txtTuKhoa = new TextBox();
            btnTim = new Button();
            btnLamMoi = new Button();
            lblKetQua = new Label();
            dgvHoaDon = new DataGridView();
            dgvChiTiet = new DataGridView();
            lblHoaDonDangChon = new Label();
            lblTongTien = new Label();
            pnlVachKe = new Panel();
            btnXuatExcel = new Button();
            btnHuyDon = new Button();
            btnThoat = new Button();

            ((System.ComponentModel.ISupportInitialize)(dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dgvChiTiet)).BeginInit();
            SuspendLayout();
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 251);
            ClientSize = new Size(1100, 720);
            Font = new Font("Segoe UI", 10F);
            Name = "FormLichSuHoaDon";
            Text = "LỊCH SỬ HÓA ĐƠN BÁN";
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
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 52F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 48F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));

            label1.Text = "LỊCH SỬ HÓA ĐƠN BÁN";
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(20, 43, 74);
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Margin = new Padding(5, 0, 0, 2);

            tblMain.Controls.Add(label1, 0, 0);

            groupBox1.Text = "TÌM NHANH HÓA ĐƠN";
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox1.BackColor = Color.White;
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Margin = new Padding(0, 0, 0, 7);
            groupBox1.Padding = new Padding(8, 6, 8, 4);

            tblTim = new TableLayoutPanel();

            tblTim.Dock = DockStyle.Fill;
            tblTim.ColumnCount = 3;
            tblTim.RowCount = 2;
            tblTim.BackColor = Color.White;
            tblTim.Margin = Padding.Empty;
            tblTim.Padding = Padding.Empty;
            tblTim.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblTim.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tblTim.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tblTim.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tblTim.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            txtTuKhoa.Font = new Font("Segoe UI", 9.5F);
            txtTuKhoa.ForeColor = Color.FromArgb(35, 51, 72);
            txtTuKhoa.BorderStyle = BorderStyle.FixedSingle;
            txtTuKhoa.BackColor = Color.FromArgb(250, 252, 255);
            txtTuKhoa.PlaceholderText = "Nhập mã hóa đơn, số điện thoại hoặc tên khách cần tìm...";
            txtTuKhoa.Dock = DockStyle.Fill;
            txtTuKhoa.Margin = new Padding(0, 1, 6, 1);

            btnTim.Text = "⌕ Tìm";
            btnTim.BackColor = Color.FromArgb(36, 120, 212);
            btnTim.ForeColor = Color.White;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.FlatAppearance.BorderSize = 0;
            btnTim.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTim.Cursor = Cursors.Hand;
            btnTim.UseVisualStyleBackColor = false;
            btnTim.Dock = DockStyle.Fill;
            btnTim.Margin = new Padding(0, 1, 4, 1);

            btnLamMoi.Text = "↻ Tải lại";
            btnLamMoi.BackColor = Color.FromArgb(105, 119, 139);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Dock = DockStyle.Fill;
            btnLamMoi.Margin = new Padding(0, 1, 0, 1);

            lblKetQua.Text = "Chưa chọn hóa đơn nào.";
            lblKetQua.Font = new Font("Segoe UI", 9F);
            lblKetQua.ForeColor = Color.FromArgb(112, 128, 150);
            lblKetQua.Dock = DockStyle.Fill;
            lblKetQua.TextAlign = ContentAlignment.MiddleLeft;
            lblKetQua.Margin = new Padding(0, 2, 0, 0);

            tblTim.Controls.Add(txtTuKhoa, 0, 0);
            tblTim.Controls.Add(btnTim, 1, 0);
            tblTim.Controls.Add(btnLamMoi, 2, 0);
            tblTim.Controls.Add(lblKetQua, 0, 1);
            tblTim.SetColumnSpan(lblKetQua, 3);

            groupBox1.Controls.Add(tblTim);

            tblMain.Controls.Add(groupBox1, 0, 1);

            groupBox2.Text = "DANH SÁCH HÓA ĐƠN ĐÃ BÁN";
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox2.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox2.BackColor = Color.White;
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Margin = new Padding(0, 0, 0, 6);
            groupBox2.Padding = new Padding(8, 6, 8, 4);

            tblDanhSach = new TableLayoutPanel();

            tblDanhSach.Dock = DockStyle.Fill;
            tblDanhSach.ColumnCount = 1;
            tblDanhSach.RowCount = 1;
            tblDanhSach.BackColor = Color.White;
            tblDanhSach.Margin = Padding.Empty;
            tblDanhSach.Padding = Padding.Empty;
            tblDanhSach.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblDanhSach.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            dgvHoaDon.Dock = DockStyle.Fill;
            dgvHoaDon.Margin = Padding.Empty;
            dgvHoaDon.BackgroundColor = Color.White;
            dgvHoaDon.BorderStyle = BorderStyle.None;
            dgvHoaDon.GridColor = Color.FromArgb(220, 227, 237);
            dgvHoaDon.EnableHeadersVisualStyles = false;
            dgvHoaDon.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 43, 74);
            dgvHoaDon.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHoaDon.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvHoaDon.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDon.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvHoaDon.DefaultCellStyle.ForeColor = Color.FromArgb(35, 51, 72);
            dgvHoaDon.DefaultCellStyle.BackColor = Color.White;
            dgvHoaDon.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 232, 250);
            dgvHoaDon.DefaultCellStyle.SelectionForeColor = Color.FromArgb(35, 51, 72);
            dgvHoaDon.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 248, 253);
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.MultiSelect = false;
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.RowHeadersVisible = false;
            dgvHoaDon.RowTemplate.Height = 30;
            dgvHoaDon.ColumnHeadersHeight = 36;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHoaDon.MinimumSize = new Size(0, 110);

            tblDanhSach.Controls.Add(dgvHoaDon, 0, 0);

            groupBox2.Controls.Add(tblDanhSach);

            tblMain.Controls.Add(groupBox2, 0, 2);

            groupBox3.Text = "CHI TIẾT HÓA ĐƠN ĐANG CHỌN";
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox3.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox3.BackColor = Color.White;
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Margin = new Padding(0, 0, 0, 6);
            groupBox3.Padding = new Padding(8, 6, 8, 4);

            tblChiTiet = new TableLayoutPanel();

            tblChiTiet.Dock = DockStyle.Fill;
            tblChiTiet.ColumnCount = 1;
            tblChiTiet.RowCount = 3;
            tblChiTiet.BackColor = Color.White;
            tblChiTiet.Margin = Padding.Empty;
            tblChiTiet.Padding = Padding.Empty;
            tblChiTiet.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblChiTiet.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblChiTiet.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
            tblChiTiet.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));

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
            dgvChiTiet.MinimumSize = new Size(0, 60);

            pnlVachKe.Dock = DockStyle.Fill;
            pnlVachKe.BackColor = Color.FromArgb(226, 232, 240);
            pnlVachKe.Margin = Padding.Empty;

            tblFooter = new TableLayoutPanel();

            tblFooter.Dock = DockStyle.Fill;
            tblFooter.ColumnCount = 2;
            tblFooter.RowCount = 1;
            tblFooter.BackColor = Color.White;
            tblFooter.Margin = Padding.Empty;
            tblFooter.Padding = Padding.Empty;
            tblFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 340F));
            tblFooter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            lblHoaDonDangChon.Text = "Chọn một hóa đơn ở bảng trên để xem chi tiết.";
            lblHoaDonDangChon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblHoaDonDangChon.ForeColor = Color.FromArgb(35, 51, 72);
            lblHoaDonDangChon.Dock = DockStyle.Fill;
            lblHoaDonDangChon.TextAlign = ContentAlignment.MiddleLeft;
            lblHoaDonDangChon.AutoEllipsis = true;
            lblHoaDonDangChon.Margin = new Padding(2, 0, 0, 0);

            lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.FromArgb(220, 75, 75);
            lblTongTien.BackColor = Color.White;
            lblTongTien.AutoSize = false;
            lblTongTien.Dock = DockStyle.Fill;
            lblTongTien.TextAlign = ContentAlignment.MiddleRight;
            lblTongTien.Margin = new Padding(0, 0, 10, 0);

            tblFooter.Controls.Add(lblHoaDonDangChon, 0, 0);
            tblFooter.Controls.Add(lblTongTien, 1, 0);

            tblChiTiet.Controls.Add(dgvChiTiet, 0, 0);
            tblChiTiet.Controls.Add(pnlVachKe, 0, 1);
            tblChiTiet.Controls.Add(tblFooter, 0, 2);

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

            btnXuatExcel.Text = "▤ Xuất Excel hóa đơn";
            btnXuatExcel.BackColor = Color.FromArgb(36, 155, 110);
            btnXuatExcel.ForeColor = Color.White;
            btnXuatExcel.FlatStyle = FlatStyle.Flat;
            btnXuatExcel.FlatAppearance.BorderSize = 0;
            btnXuatExcel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXuatExcel.Cursor = Cursors.Hand;
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Size = new Size(172, 32);
            btnXuatExcel.Margin = new Padding(3);

            btnHuyDon.Text = "✕ Hủy đơn & hoàn kho";
            btnHuyDon.BackColor = Color.FromArgb(220, 75, 75);
            btnHuyDon.ForeColor = Color.White;
            btnHuyDon.FlatStyle = FlatStyle.Flat;
            btnHuyDon.FlatAppearance.BorderSize = 0;
            btnHuyDon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnHuyDon.Cursor = Cursors.Hand;
            btnHuyDon.UseVisualStyleBackColor = false;
            btnHuyDon.Size = new Size(176, 32);
            btnHuyDon.Margin = new Padding(3);

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

            flpChucNang.Controls.Add(btnXuatExcel);
            flpChucNang.Controls.Add(btnHuyDon);
            flpChucNang.Controls.Add(btnThoat);

            groupBox4.Controls.Add(flpChucNang);

            tblMain.Controls.Add(groupBox4, 0, 4);

            Controls.Add(tblMain);

            ((System.ComponentModel.ISupportInitialize)(dgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dgvChiTiet)).EndInit();
            ResumeLayout(false);
        }

        // KHAI BÁO CONTROL

        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private TextBox txtTuKhoa;
        private Button btnTim;
        private Button btnLamMoi;
        private Label lblKetQua;
        private DataGridView dgvHoaDon;
        private DataGridView dgvChiTiet;
        private Label lblHoaDonDangChon;
        private Label lblTongTien;
        private Panel pnlVachKe;
        private Button btnXuatExcel;
        private Button btnHuyDon;
        private Button btnThoat;
        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblTim;
        private TableLayoutPanel tblDanhSach;
        private TableLayoutPanel tblChiTiet;
        private TableLayoutPanel tblFooter;
        private FlowLayoutPanel flpChucNang;
    }
}
