using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4.GUI
{
    partial class Form5
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

            tabDanhMuc = new TabControl();
            tpHangSX = new TabPage();
            tpLoai = new TabPage();
            tpMauSac = new TabPage();
            tpDungLuong = new TabPage();
            txtMaHang = new TextBox();
            txtTenHang = new TextBox();
            txtGhiChu = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamLai = new Button();
            btnThoat = new Button();
            dgvHangSX = new DataGridView();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label5 = new Label();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            textBox6 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label9 = new Label();
            label7 = new Label();
            label8 = new Label();
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            dataGridView2 = new DataGridView();
            textBox9 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            label12 = new Label();
            label10 = new Label();
            label11 = new Label();
            button15 = new Button();
            button14 = new Button();
            button13 = new Button();
            button12 = new Button();
            button11 = new Button();
            dataGridView3 = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(dgvHangSX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView3)).BeginInit();
            SuspendLayout();
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 252);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1000, 650);
            ClientSize = new Size(1400, 850);
            Name = "Form5";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUẢN LÝ DANH MỤC";
            WindowState = FormWindowState.Maximized;

            tabDanhMuc.Dock = DockStyle.Fill;
            tabDanhMuc.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            tabDanhMuc.Padding = new Point(18, 8);
            tabDanhMuc.SizeMode = TabSizeMode.Normal;

            tpHangSX.Text = "Hãng sản xuất";
            tpHangSX.BackColor = Color.FromArgb(244, 247, 252);
            tpHangSX.Padding = new Padding(12);
            tpHangSX.UseVisualStyleBackColor = false;

            tpLoai.Text = "Loại hàng";
            tpLoai.BackColor = Color.FromArgb(244, 247, 252);
            tpLoai.Padding = new Padding(12);
            tpLoai.UseVisualStyleBackColor = false;

            tpMauSac.Text = "Màu sắc";
            tpMauSac.BackColor = Color.FromArgb(244, 247, 252);
            tpMauSac.Padding = new Padding(12);
            tpMauSac.UseVisualStyleBackColor = false;

            tpDungLuong.Text = "Dung lượng";
            tpDungLuong.BackColor = Color.FromArgb(244, 247, 252);
            tpDungLuong.Padding = new Padding(12);
            tpDungLuong.UseVisualStyleBackColor = false;

            lblHeadingHangSX = new Label();

            lblHeadingHangSX.Text = "THÔNG TIN HÃNG SẢN XUẤT";
            lblHeadingHangSX.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeadingHangSX.ForeColor = Color.FromArgb(35, 48, 68);
            lblHeadingHangSX.AutoSize = true;
            lblHeadingHangSX.Location = new Point(20, 14);

            pnlThongTinHangSX = new Panel();

            pnlThongTinHangSX.BackColor = Color.White;
            pnlThongTinHangSX.BorderStyle = BorderStyle.FixedSingle;

            lblMaTitleHangSX = new Label();

            lblMaTitleHangSX.Text = "Mã hãng sản xuất";
            lblMaTitleHangSX.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMaTitleHangSX.ForeColor = Color.FromArgb(35, 48, 68);
            lblMaTitleHangSX.AutoSize = true;

            lblTenTitleHangSX = new Label();

            lblTenTitleHangSX.Text = "Tên hãng sản xuất";
            lblTenTitleHangSX.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTenTitleHangSX.ForeColor = Color.FromArgb(35, 48, 68);
            lblTenTitleHangSX.AutoSize = true;

            txtMaHang.Font = new Font("Segoe UI", 11F);
            txtMaHang.ForeColor = Color.FromArgb(35, 48, 68);
            txtMaHang.BackColor = Color.FromArgb(250, 252, 255);
            txtMaHang.BorderStyle = BorderStyle.FixedSingle;

            txtTenHang.Font = new Font("Segoe UI", 11F);
            txtTenHang.ForeColor = Color.FromArgb(35, 48, 68);
            txtTenHang.BackColor = Color.FromArgb(250, 252, 255);
            txtTenHang.BorderStyle = BorderStyle.FixedSingle;

            label1.Visible = false;

            label3.Visible = false;

            label2.Visible = false;

            txtGhiChu.Visible = false;

            pnlThongTinHangSX.Controls.Add(lblMaTitleHangSX);
            pnlThongTinHangSX.Controls.Add(txtMaHang);
            pnlThongTinHangSX.Controls.Add(lblTenTitleHangSX);
            pnlThongTinHangSX.Controls.Add(txtTenHang);

            lblChucNangHangSX = new Label();

            lblChucNangHangSX.Text = "CHỨC NĂNG";
            lblChucNangHangSX.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblChucNangHangSX.ForeColor = Color.FromArgb(35, 48, 68);
            lblChucNangHangSX.AutoSize = true;
            lblChucNangHangSX.UseCompatibleTextRendering = true;

            pnlButtonsHangSX = new Panel();

            pnlButtonsHangSX.BackColor = Color.White;
            pnlButtonsHangSX.BorderStyle = BorderStyle.FixedSingle;

            btnThem.BackColor = Color.FromArgb(41, 98, 170);
            btnThem.ForeColor = Color.White;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThem.Cursor = Cursors.Hand;
            btnThem.UseVisualStyleBackColor = false;

            btnSua.BackColor = Color.FromArgb(36, 155, 110);
            btnSua.ForeColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSua.Cursor = Cursors.Hand;
            btnSua.UseVisualStyleBackColor = false;

            btnXoa.BackColor = Color.FromArgb(220, 75, 75);
            btnXoa.ForeColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.UseVisualStyleBackColor = false;

            btnLamLai.BackColor = Color.FromArgb(105, 119, 139);
            btnLamLai.ForeColor = Color.White;
            btnLamLai.FlatStyle = FlatStyle.Flat;
            btnLamLai.FlatAppearance.BorderSize = 0;
            btnLamLai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLamLai.Cursor = Cursors.Hand;
            btnLamLai.UseVisualStyleBackColor = false;

            btnThoat.BackColor = Color.FromArgb(70, 82, 100);
            btnThoat.ForeColor = Color.White;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.UseVisualStyleBackColor = false;

            pnlButtonsHangSX.Controls.Add(btnThem);
            pnlButtonsHangSX.Controls.Add(btnSua);
            pnlButtonsHangSX.Controls.Add(btnXoa);
            pnlButtonsHangSX.Controls.Add(btnLamLai);
            pnlButtonsHangSX.Controls.Add(btnThoat);

            lblDanhSachHangSX = new Label();

            lblDanhSachHangSX.Text = "DANH SÁCH DỮ LIỆU";
            lblDanhSachHangSX.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblDanhSachHangSX.ForeColor = Color.FromArgb(35, 48, 68);
            lblDanhSachHangSX.AutoSize = true;

            dgvHangSX.BackgroundColor = Color.White;
            dgvHangSX.BorderStyle = BorderStyle.FixedSingle;
            dgvHangSX.GridColor = Color.FromArgb(220, 227, 237);
            dgvHangSX.EnableHeadersVisualStyles = false;
            dgvHangSX.ColumnHeadersVisible = true;
            dgvHangSX.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 75, 135);
            dgvHangSX.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHangSX.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvHangSX.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHangSX.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvHangSX.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHangSX.ColumnHeadersHeight = 42;
            dgvHangSX.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvHangSX.DefaultCellStyle.ForeColor = Color.FromArgb(35, 48, 68);
            dgvHangSX.DefaultCellStyle.BackColor = Color.White;
            dgvHangSX.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 232, 250);
            dgvHangSX.DefaultCellStyle.SelectionForeColor = Color.FromArgb(35, 48, 68);
            dgvHangSX.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 248, 253);
            dgvHangSX.RowTemplate.Height = 36;
            dgvHangSX.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHangSX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHangSX.MultiSelect = false;
            dgvHangSX.ReadOnly = true;
            dgvHangSX.AllowUserToAddRows = false;
            dgvHangSX.AllowUserToDeleteRows = false;
            dgvHangSX.RowHeadersVisible = false;
            dgvHangSX.ScrollBars = ScrollBars.Both;

            tpHangSX.Controls.Add(lblHeadingHangSX);
            tpHangSX.Controls.Add(pnlThongTinHangSX);
            tpHangSX.Controls.Add(lblChucNangHangSX);
            tpHangSX.Controls.Add(pnlButtonsHangSX);
            tpHangSX.Controls.Add(lblDanhSachHangSX);
            tpHangSX.Controls.Add(dgvHangSX);

            btnThem.Text = "＋ Thêm";

            btnSua.Text = "✎ Sửa";

            btnXoa.Text = "✕ Xóa";

            btnLamLai.Text = "↻ Làm lại";

            btnThoat.Text = "← Thoát";

            lblHeadingLoai = new Label();

            lblHeadingLoai.Text = "THÔNG TIN LOẠI HÀNG";
            lblHeadingLoai.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeadingLoai.ForeColor = Color.FromArgb(35, 48, 68);
            lblHeadingLoai.AutoSize = true;
            lblHeadingLoai.Location = new Point(20, 14);

            pnlThongTinLoai = new Panel();

            pnlThongTinLoai.BackColor = Color.White;
            pnlThongTinLoai.BorderStyle = BorderStyle.FixedSingle;

            lblMaTitleLoai = new Label();

            lblMaTitleLoai.Text = "Mã loại hàng";
            lblMaTitleLoai.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMaTitleLoai.ForeColor = Color.FromArgb(35, 48, 68);
            lblMaTitleLoai.AutoSize = true;

            lblTenTitleLoai = new Label();

            lblTenTitleLoai.Text = "Tên loại hàng";
            lblTenTitleLoai.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTenTitleLoai.ForeColor = Color.FromArgb(35, 48, 68);
            lblTenTitleLoai.AutoSize = true;

            textBox3.Font = new Font("Segoe UI", 11F);
            textBox3.ForeColor = Color.FromArgb(35, 48, 68);
            textBox3.BackColor = Color.FromArgb(250, 252, 255);
            textBox3.BorderStyle = BorderStyle.FixedSingle;

            textBox1.Font = new Font("Segoe UI", 11F);
            textBox1.ForeColor = Color.FromArgb(35, 48, 68);
            textBox1.BackColor = Color.FromArgb(250, 252, 255);
            textBox1.BorderStyle = BorderStyle.FixedSingle;

            label6.Visible = false;

            label4.Visible = false;

            label5.Visible = false;

            textBox2.Visible = false;

            pnlThongTinLoai.Controls.Add(lblMaTitleLoai);
            pnlThongTinLoai.Controls.Add(textBox3);
            pnlThongTinLoai.Controls.Add(lblTenTitleLoai);
            pnlThongTinLoai.Controls.Add(textBox1);

            lblChucNangLoai = new Label();

            lblChucNangLoai.Text = "CHỨC NĂNG";
            lblChucNangLoai.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblChucNangLoai.ForeColor = Color.FromArgb(35, 48, 68);
            lblChucNangLoai.AutoSize = true;
            lblChucNangLoai.UseCompatibleTextRendering = true;

            pnlButtonsLoai = new Panel();

            pnlButtonsLoai.BackColor = Color.White;
            pnlButtonsLoai.BorderStyle = BorderStyle.FixedSingle;

            button5.BackColor = Color.FromArgb(41, 98, 170);
            button5.ForeColor = Color.White;
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;
            button5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button5.Cursor = Cursors.Hand;
            button5.UseVisualStyleBackColor = false;

            button4.BackColor = Color.FromArgb(36, 155, 110);
            button4.ForeColor = Color.White;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button4.Cursor = Cursors.Hand;
            button4.UseVisualStyleBackColor = false;

            button3.BackColor = Color.FromArgb(220, 75, 75);
            button3.ForeColor = Color.White;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button3.Cursor = Cursors.Hand;
            button3.UseVisualStyleBackColor = false;

            button2.BackColor = Color.FromArgb(105, 119, 139);
            button2.ForeColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button2.Cursor = Cursors.Hand;
            button2.UseVisualStyleBackColor = false;

            button1.BackColor = Color.FromArgb(70, 82, 100);
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.Cursor = Cursors.Hand;
            button1.UseVisualStyleBackColor = false;

            pnlButtonsLoai.Controls.Add(button5);
            pnlButtonsLoai.Controls.Add(button4);
            pnlButtonsLoai.Controls.Add(button3);
            pnlButtonsLoai.Controls.Add(button2);
            pnlButtonsLoai.Controls.Add(button1);

            lblDanhSachLoai = new Label();

            lblDanhSachLoai.Text = "DANH SÁCH DỮ LIỆU";
            lblDanhSachLoai.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblDanhSachLoai.ForeColor = Color.FromArgb(35, 48, 68);
            lblDanhSachLoai.AutoSize = true;

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            dataGridView1.GridColor = Color.FromArgb(220, 227, 237);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 75, 135);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeight = 42;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(35, 48, 68);
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 232, 250);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(35, 48, 68);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 248, 253);
            dataGridView1.RowTemplate.Height = 36;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ScrollBars = ScrollBars.Both;

            tpLoai.Controls.Add(lblHeadingLoai);
            tpLoai.Controls.Add(pnlThongTinLoai);
            tpLoai.Controls.Add(lblChucNangLoai);
            tpLoai.Controls.Add(pnlButtonsLoai);
            tpLoai.Controls.Add(lblDanhSachLoai);
            tpLoai.Controls.Add(dataGridView1);

            button5.Text = "＋ Thêm";

            button4.Text = "✎ Sửa";

            button3.Text = "✕ Xóa";

            button2.Text = "↻ Làm lại";

            button1.Text = "← Thoát";

            lblHeadingMauSac = new Label();

            lblHeadingMauSac.Text = "THÔNG TIN MÀU SẮC";
            lblHeadingMauSac.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeadingMauSac.ForeColor = Color.FromArgb(35, 48, 68);
            lblHeadingMauSac.AutoSize = true;
            lblHeadingMauSac.Location = new Point(20, 14);

            pnlThongTinMauSac = new Panel();

            pnlThongTinMauSac.BackColor = Color.White;
            pnlThongTinMauSac.BorderStyle = BorderStyle.FixedSingle;

            lblMaTitleMauSac = new Label();

            lblMaTitleMauSac.Text = "Mã màu";
            lblMaTitleMauSac.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMaTitleMauSac.ForeColor = Color.FromArgb(35, 48, 68);
            lblMaTitleMauSac.AutoSize = true;

            lblTenTitleMauSac = new Label();

            lblTenTitleMauSac.Text = "Tên màu";
            lblTenTitleMauSac.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTenTitleMauSac.ForeColor = Color.FromArgb(35, 48, 68);
            lblTenTitleMauSac.AutoSize = true;

            textBox6.Font = new Font("Segoe UI", 11F);
            textBox6.ForeColor = Color.FromArgb(35, 48, 68);
            textBox6.BackColor = Color.FromArgb(250, 252, 255);
            textBox6.BorderStyle = BorderStyle.FixedSingle;

            textBox4.Font = new Font("Segoe UI", 11F);
            textBox4.ForeColor = Color.FromArgb(35, 48, 68);
            textBox4.BackColor = Color.FromArgb(250, 252, 255);
            textBox4.BorderStyle = BorderStyle.FixedSingle;

            label9.Visible = false;

            label7.Visible = false;

            label8.Visible = false;

            textBox5.Visible = false;

            pnlThongTinMauSac.Controls.Add(lblMaTitleMauSac);
            pnlThongTinMauSac.Controls.Add(textBox6);
            pnlThongTinMauSac.Controls.Add(lblTenTitleMauSac);
            pnlThongTinMauSac.Controls.Add(textBox4);

            lblChucNangMauSac = new Label();

            lblChucNangMauSac.Text = "CHỨC NĂNG";
            lblChucNangMauSac.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblChucNangMauSac.ForeColor = Color.FromArgb(35, 48, 68);
            lblChucNangMauSac.AutoSize = true;
            lblChucNangMauSac.UseCompatibleTextRendering = true;

            pnlButtonsMauSac = new Panel();

            pnlButtonsMauSac.BackColor = Color.White;
            pnlButtonsMauSac.BorderStyle = BorderStyle.FixedSingle;

            button10.BackColor = Color.FromArgb(41, 98, 170);
            button10.ForeColor = Color.White;
            button10.FlatStyle = FlatStyle.Flat;
            button10.FlatAppearance.BorderSize = 0;
            button10.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button10.Cursor = Cursors.Hand;
            button10.UseVisualStyleBackColor = false;

            button9.BackColor = Color.FromArgb(36, 155, 110);
            button9.ForeColor = Color.White;
            button9.FlatStyle = FlatStyle.Flat;
            button9.FlatAppearance.BorderSize = 0;
            button9.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button9.Cursor = Cursors.Hand;
            button9.UseVisualStyleBackColor = false;

            button8.BackColor = Color.FromArgb(220, 75, 75);
            button8.ForeColor = Color.White;
            button8.FlatStyle = FlatStyle.Flat;
            button8.FlatAppearance.BorderSize = 0;
            button8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button8.Cursor = Cursors.Hand;
            button8.UseVisualStyleBackColor = false;

            button7.BackColor = Color.FromArgb(105, 119, 139);
            button7.ForeColor = Color.White;
            button7.FlatStyle = FlatStyle.Flat;
            button7.FlatAppearance.BorderSize = 0;
            button7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button7.Cursor = Cursors.Hand;
            button7.UseVisualStyleBackColor = false;

            button6.BackColor = Color.FromArgb(70, 82, 100);
            button6.ForeColor = Color.White;
            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 0;
            button6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button6.Cursor = Cursors.Hand;
            button6.UseVisualStyleBackColor = false;

            pnlButtonsMauSac.Controls.Add(button10);
            pnlButtonsMauSac.Controls.Add(button9);
            pnlButtonsMauSac.Controls.Add(button8);
            pnlButtonsMauSac.Controls.Add(button7);
            pnlButtonsMauSac.Controls.Add(button6);

            lblDanhSachMauSac = new Label();

            lblDanhSachMauSac.Text = "DANH SÁCH DỮ LIỆU";
            lblDanhSachMauSac.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblDanhSachMauSac.ForeColor = Color.FromArgb(35, 48, 68);
            lblDanhSachMauSac.AutoSize = true;

            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.BorderStyle = BorderStyle.FixedSingle;
            dataGridView2.GridColor = Color.FromArgb(220, 227, 237);
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersVisible = true;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 75, 135);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView2.ColumnHeadersHeight = 42;
            dataGridView2.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dataGridView2.DefaultCellStyle.ForeColor = Color.FromArgb(35, 48, 68);
            dataGridView2.DefaultCellStyle.BackColor = Color.White;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 232, 250);
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.FromArgb(35, 48, 68);
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 248, 253);
            dataGridView2.RowTemplate.Height = 36;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.ScrollBars = ScrollBars.Both;

            tpMauSac.Controls.Add(lblHeadingMauSac);
            tpMauSac.Controls.Add(pnlThongTinMauSac);
            tpMauSac.Controls.Add(lblChucNangMauSac);
            tpMauSac.Controls.Add(pnlButtonsMauSac);
            tpMauSac.Controls.Add(lblDanhSachMauSac);
            tpMauSac.Controls.Add(dataGridView2);

            button10.Text = "＋ Thêm";

            button9.Text = "✎ Sửa";

            button8.Text = "✕ Xóa";

            button7.Text = "↻ Làm lại";

            button6.Text = "← Thoát";

            lblHeadingDungLuong = new Label();

            lblHeadingDungLuong.Text = "THÔNG TIN DUNG LƯỢNG";
            lblHeadingDungLuong.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeadingDungLuong.ForeColor = Color.FromArgb(35, 48, 68);
            lblHeadingDungLuong.AutoSize = true;
            lblHeadingDungLuong.Location = new Point(20, 14);

            pnlThongTinDungLuong = new Panel();

            pnlThongTinDungLuong.BackColor = Color.White;
            pnlThongTinDungLuong.BorderStyle = BorderStyle.FixedSingle;

            lblMaTitleDungLuong = new Label();

            lblMaTitleDungLuong.Text = "Mã dung lượng";
            lblMaTitleDungLuong.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMaTitleDungLuong.ForeColor = Color.FromArgb(35, 48, 68);
            lblMaTitleDungLuong.AutoSize = true;

            lblTenTitleDungLuong = new Label();

            lblTenTitleDungLuong.Text = "Tên dung lượng";
            lblTenTitleDungLuong.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTenTitleDungLuong.ForeColor = Color.FromArgb(35, 48, 68);
            lblTenTitleDungLuong.AutoSize = true;

            textBox9.Font = new Font("Segoe UI", 11F);
            textBox9.ForeColor = Color.FromArgb(35, 48, 68);
            textBox9.BackColor = Color.FromArgb(250, 252, 255);
            textBox9.BorderStyle = BorderStyle.FixedSingle;

            textBox7.Font = new Font("Segoe UI", 11F);
            textBox7.ForeColor = Color.FromArgb(35, 48, 68);
            textBox7.BackColor = Color.FromArgb(250, 252, 255);
            textBox7.BorderStyle = BorderStyle.FixedSingle;

            label12.Visible = false;

            label10.Visible = false;

            label11.Visible = false;

            textBox8.Visible = false;

            pnlThongTinDungLuong.Controls.Add(lblMaTitleDungLuong);
            pnlThongTinDungLuong.Controls.Add(textBox9);
            pnlThongTinDungLuong.Controls.Add(lblTenTitleDungLuong);
            pnlThongTinDungLuong.Controls.Add(textBox7);

            lblChucNangDungLuong = new Label();

            lblChucNangDungLuong.Text = "CHỨC NĂNG";
            lblChucNangDungLuong.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblChucNangDungLuong.ForeColor = Color.FromArgb(35, 48, 68);
            lblChucNangDungLuong.AutoSize = true;
            lblChucNangDungLuong.UseCompatibleTextRendering = true;

            pnlButtonsDungLuong = new Panel();

            pnlButtonsDungLuong.BackColor = Color.White;
            pnlButtonsDungLuong.BorderStyle = BorderStyle.FixedSingle;

            button15.BackColor = Color.FromArgb(41, 98, 170);
            button15.ForeColor = Color.White;
            button15.FlatStyle = FlatStyle.Flat;
            button15.FlatAppearance.BorderSize = 0;
            button15.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button15.Cursor = Cursors.Hand;
            button15.UseVisualStyleBackColor = false;

            button14.BackColor = Color.FromArgb(36, 155, 110);
            button14.ForeColor = Color.White;
            button14.FlatStyle = FlatStyle.Flat;
            button14.FlatAppearance.BorderSize = 0;
            button14.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button14.Cursor = Cursors.Hand;
            button14.UseVisualStyleBackColor = false;

            button13.BackColor = Color.FromArgb(220, 75, 75);
            button13.ForeColor = Color.White;
            button13.FlatStyle = FlatStyle.Flat;
            button13.FlatAppearance.BorderSize = 0;
            button13.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button13.Cursor = Cursors.Hand;
            button13.UseVisualStyleBackColor = false;

            button12.BackColor = Color.FromArgb(105, 119, 139);
            button12.ForeColor = Color.White;
            button12.FlatStyle = FlatStyle.Flat;
            button12.FlatAppearance.BorderSize = 0;
            button12.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button12.Cursor = Cursors.Hand;
            button12.UseVisualStyleBackColor = false;

            button11.BackColor = Color.FromArgb(70, 82, 100);
            button11.ForeColor = Color.White;
            button11.FlatStyle = FlatStyle.Flat;
            button11.FlatAppearance.BorderSize = 0;
            button11.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button11.Cursor = Cursors.Hand;
            button11.UseVisualStyleBackColor = false;

            pnlButtonsDungLuong.Controls.Add(button15);
            pnlButtonsDungLuong.Controls.Add(button14);
            pnlButtonsDungLuong.Controls.Add(button13);
            pnlButtonsDungLuong.Controls.Add(button12);
            pnlButtonsDungLuong.Controls.Add(button11);

            lblDanhSachDungLuong = new Label();

            lblDanhSachDungLuong.Text = "DANH SÁCH DỮ LIỆU";
            lblDanhSachDungLuong.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblDanhSachDungLuong.ForeColor = Color.FromArgb(35, 48, 68);
            lblDanhSachDungLuong.AutoSize = true;

            dataGridView3.BackgroundColor = Color.White;
            dataGridView3.BorderStyle = BorderStyle.FixedSingle;
            dataGridView3.GridColor = Color.FromArgb(220, 227, 237);
            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersVisible = true;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 75, 135);
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView3.ColumnHeadersHeight = 42;
            dataGridView3.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dataGridView3.DefaultCellStyle.ForeColor = Color.FromArgb(35, 48, 68);
            dataGridView3.DefaultCellStyle.BackColor = Color.White;
            dataGridView3.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 232, 250);
            dataGridView3.DefaultCellStyle.SelectionForeColor = Color.FromArgb(35, 48, 68);
            dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 248, 253);
            dataGridView3.RowTemplate.Height = 36;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.MultiSelect = false;
            dataGridView3.ReadOnly = true;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.ScrollBars = ScrollBars.Both;

            tpDungLuong.Controls.Add(lblHeadingDungLuong);
            tpDungLuong.Controls.Add(pnlThongTinDungLuong);
            tpDungLuong.Controls.Add(lblChucNangDungLuong);
            tpDungLuong.Controls.Add(pnlButtonsDungLuong);
            tpDungLuong.Controls.Add(lblDanhSachDungLuong);
            tpDungLuong.Controls.Add(dataGridView3);

            button15.Text = "＋ Thêm";

            button14.Text = "✎ Sửa";

            button13.Text = "✕ Xóa";

            button12.Text = "↻ Làm lại";

            button11.Text = "← Thoát";

            tabDanhMuc.Controls.Add(tpHangSX);
            tabDanhMuc.Controls.Add(tpLoai);
            tabDanhMuc.Controls.Add(tpMauSac);
            tabDanhMuc.Controls.Add(tpDungLuong);

            Controls.Add(tabDanhMuc);

            ((System.ComponentModel.ISupportInitialize)(dgvHangSX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView3)).EndInit();

            // ------------------------------------------
            // VỊ TRÍ Ở MÀN [Design] - lúc chạy, hàm LayoutTab()
            // trong Form5.cs sẽ tính lại theo kích thước thật
            // ------------------------------------------

            // tpHangSX
            lblHeadingHangSX.Location = new Point(18, 12);
            pnlThongTinHangSX.Location = new Point(18, 62);
            pnlThongTinHangSX.Size = new Size(1356, 140);
            lblMaTitleHangSX.Location = new Point(22, 18);
            txtMaHang.Location = new Point(22, 52);
            txtMaHang.Size = new Size(641, 34);
            lblTenTitleHangSX.Location = new Point(693, 18);
            txtTenHang.Location = new Point(693, 52);
            txtTenHang.Size = new Size(641, 34);
            lblChucNangHangSX.Location = new Point(20, 205);
            pnlButtonsHangSX.Location = new Point(18, 260);
            pnlButtonsHangSX.Size = new Size(1356, 78);
            btnThem.Location = new Point(23, 15);
            btnThem.Size = new Size(180, 52);
            btnSua.Location = new Point(220, 15);
            btnSua.Size = new Size(180, 52);
            btnXoa.Location = new Point(417, 15);
            btnXoa.Size = new Size(180, 52);
            btnLamLai.Location = new Point(614, 15);
            btnLamLai.Size = new Size(195, 52);
            btnThoat.Location = new Point(826, 15);
            btnThoat.Size = new Size(180, 52);
            lblDanhSachHangSX.Location = new Point(20, 335);
            dgvHangSX.Location = new Point(18, 390);
            dgvHangSX.Size = new Size(1356, 384);

            // tpLoai
            lblHeadingLoai.Location = new Point(18, 12);
            pnlThongTinLoai.Location = new Point(18, 62);
            pnlThongTinLoai.Size = new Size(1356, 140);
            lblMaTitleLoai.Location = new Point(22, 18);
            textBox3.Location = new Point(22, 52);
            textBox3.Size = new Size(641, 34);
            lblTenTitleLoai.Location = new Point(693, 18);
            textBox1.Location = new Point(693, 52);
            textBox1.Size = new Size(641, 34);
            lblChucNangLoai.Location = new Point(20, 205);
            pnlButtonsLoai.Location = new Point(18, 260);
            pnlButtonsLoai.Size = new Size(1356, 78);
            button5.Location = new Point(23, 15);
            button5.Size = new Size(180, 52);
            button4.Location = new Point(220, 15);
            button4.Size = new Size(180, 52);
            button3.Location = new Point(417, 15);
            button3.Size = new Size(180, 52);
            button2.Location = new Point(614, 15);
            button2.Size = new Size(195, 52);
            button1.Location = new Point(826, 15);
            button1.Size = new Size(180, 52);
            lblDanhSachLoai.Location = new Point(20, 335);
            dataGridView1.Location = new Point(18, 390);
            dataGridView1.Size = new Size(1356, 384);

            // tpMauSac
            lblHeadingMauSac.Location = new Point(18, 12);
            pnlThongTinMauSac.Location = new Point(18, 62);
            pnlThongTinMauSac.Size = new Size(1356, 140);
            lblMaTitleMauSac.Location = new Point(22, 18);
            textBox6.Location = new Point(22, 52);
            textBox6.Size = new Size(641, 34);
            lblTenTitleMauSac.Location = new Point(693, 18);
            textBox4.Location = new Point(693, 52);
            textBox4.Size = new Size(641, 34);
            lblChucNangMauSac.Location = new Point(20, 205);
            pnlButtonsMauSac.Location = new Point(18, 260);
            pnlButtonsMauSac.Size = new Size(1356, 78);
            button10.Location = new Point(23, 15);
            button10.Size = new Size(180, 52);
            button9.Location = new Point(220, 15);
            button9.Size = new Size(180, 52);
            button8.Location = new Point(417, 15);
            button8.Size = new Size(180, 52);
            button7.Location = new Point(614, 15);
            button7.Size = new Size(195, 52);
            button6.Location = new Point(826, 15);
            button6.Size = new Size(180, 52);
            lblDanhSachMauSac.Location = new Point(20, 335);
            dataGridView2.Location = new Point(18, 390);
            dataGridView2.Size = new Size(1356, 384);

            // tpDungLuong
            lblHeadingDungLuong.Location = new Point(18, 12);
            pnlThongTinDungLuong.Location = new Point(18, 62);
            pnlThongTinDungLuong.Size = new Size(1356, 140);
            lblMaTitleDungLuong.Location = new Point(22, 18);
            textBox9.Location = new Point(22, 52);
            textBox9.Size = new Size(641, 34);
            lblTenTitleDungLuong.Location = new Point(693, 18);
            textBox7.Location = new Point(693, 52);
            textBox7.Size = new Size(641, 34);
            lblChucNangDungLuong.Location = new Point(20, 205);
            pnlButtonsDungLuong.Location = new Point(18, 260);
            pnlButtonsDungLuong.Size = new Size(1356, 78);
            button15.Location = new Point(23, 15);
            button15.Size = new Size(180, 52);
            button14.Location = new Point(220, 15);
            button14.Size = new Size(180, 52);
            button13.Location = new Point(417, 15);
            button13.Size = new Size(180, 52);
            button12.Location = new Point(614, 15);
            button12.Size = new Size(195, 52);
            button11.Location = new Point(826, 15);
            button11.Size = new Size(180, 52);
            lblDanhSachDungLuong.Location = new Point(20, 335);
            dataGridView3.Location = new Point(18, 390);
            dataGridView3.Size = new Size(1356, 384);

            ResumeLayout(false);
        }

        // KHAI BÁO CONTROL

        private TabControl tabDanhMuc;
        private TabPage tpHangSX;
        private TabPage tpLoai;
        private TabPage tpMauSac;
        private TabPage tpDungLuong;
        private TextBox txtMaHang;
        private TextBox txtTenHang;
        private TextBox txtGhiChu;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamLai;
        private Button btnThoat;
        private DataGridView dgvHangSX;
        private TextBox textBox3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label6;
        private Label label4;
        private Label label5;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private DataGridView dataGridView1;
        private TextBox textBox6;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label9;
        private Label label7;
        private Label label8;
        private Button button10;
        private Button button9;
        private Button button8;
        private Button button7;
        private Button button6;
        private DataGridView dataGridView2;
        private TextBox textBox9;
        private TextBox textBox7;
        private TextBox textBox8;
        private Label label12;
        private Label label10;
        private Label label11;
        private Button button15;
        private Button button14;
        private Button button13;
        private Button button12;
        private Button button11;
        private DataGridView dataGridView3;
        private Label lblHeadingHangSX;
        private Panel pnlThongTinHangSX;
        private Label lblMaTitleHangSX;
        private Label lblTenTitleHangSX;
        private Label lblChucNangHangSX;
        private Panel pnlButtonsHangSX;
        private Label lblDanhSachHangSX;
        private Label lblHeadingLoai;
        private Panel pnlThongTinLoai;
        private Label lblMaTitleLoai;
        private Label lblTenTitleLoai;
        private Label lblChucNangLoai;
        private Panel pnlButtonsLoai;
        private Label lblDanhSachLoai;
        private Label lblHeadingMauSac;
        private Panel pnlThongTinMauSac;
        private Label lblMaTitleMauSac;
        private Label lblTenTitleMauSac;
        private Label lblChucNangMauSac;
        private Panel pnlButtonsMauSac;
        private Label lblDanhSachMauSac;
        private Label lblHeadingDungLuong;
        private Panel pnlThongTinDungLuong;
        private Label lblMaTitleDungLuong;
        private Label lblTenTitleDungLuong;
        private Label lblChucNangDungLuong;
        private Panel pnlButtonsDungLuong;
        private Label lblDanhSachDungLuong;
    }
}
