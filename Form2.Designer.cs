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

            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            txtMaNV = new TextBox();
            txtTenNV = new TextBox();
            txtDiaChi = new TextBox();
            txtMatKhau = new TextBox();
            txtSDT = new TextBox();
            txtTim = new TextBox();
            cboChucVu = new ComboBox();
            cboTrangThai = new ComboBox();
            dtpNgaySinh = new DateTimePicker();
            radNam = new RadioButton();
            radNu = new RadioButton();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamLai = new Button();
            btnThoat = new Button();
            btnTim = new Button();
            dgvNhanVien = new DataGridView();
            label1 = new Label();
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

            SuspendLayout();
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 251);
            Font = new Font("Segoe UI", 9.5F);
            ClientSize = new Size(1100, 760);
            MinimumSize = new Size(850, 600);
            Name = "Form2";
            Text = "PHONE STORE - Quản lý nhân viên";

            root = new TableLayoutPanel();

            root.Dock = DockStyle.Fill;
            root.ColumnCount = 1;
            root.RowCount = 4;
            root.Padding = new Padding(16);
            root.BackColor = Color.FromArgb(244, 247, 251);
            root.Margin = Padding.Empty;
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 310F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 105F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 105F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            top = new TableLayoutPanel();

            top.Dock = DockStyle.Fill;
            top.ColumnCount = 2;
            top.RowCount = 1;
            top.BackColor = Color.FromArgb(244, 247, 251);
            top.Margin = Padding.Empty;
            top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72F));
            top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));

            groupBox1.Text = "THÔNG TIN NHÂN VIÊN";
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Margin = new Padding(0, 0, 10, 0);
            groupBox1.BackColor = Color.White;
            groupBox1.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.Padding = new Padding(10);

            fields = new TableLayoutPanel();

            fields.Dock = DockStyle.Fill;
            fields.ColumnCount = 4;
            fields.RowCount = 5;
            fields.Padding = new Padding(12, 10, 12, 10);
            fields.BackColor = Color.White;
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));

            label1.Text = "Mã nhân viên";
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(35, 51, 72);
            label1.Margin = new Padding(3);

            label2.Text = "Ngày sinh";
            label2.Dock = DockStyle.Fill;
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(35, 51, 72);
            label2.Margin = new Padding(3);

            label3.Text = "Địa chỉ";
            label3.Dock = DockStyle.Fill;
            label3.TextAlign = ContentAlignment.MiddleLeft;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(35, 51, 72);
            label3.Margin = new Padding(3);

            label4.Text = "Số điện thoại";
            label4.Dock = DockStyle.Fill;
            label4.TextAlign = ContentAlignment.MiddleLeft;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(35, 51, 72);
            label4.Margin = new Padding(3);

            label5.Text = "Mật khẩu";
            label5.Dock = DockStyle.Fill;
            label5.TextAlign = ContentAlignment.MiddleLeft;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(35, 51, 72);
            label5.Margin = new Padding(3);

            label6.Text = "Họ tên";
            label6.Dock = DockStyle.Fill;
            label6.TextAlign = ContentAlignment.MiddleLeft;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(35, 51, 72);
            label6.Margin = new Padding(3);

            label7.Text = "Giới tính";
            label7.Dock = DockStyle.Fill;
            label7.TextAlign = ContentAlignment.MiddleLeft;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(35, 51, 72);
            label7.Margin = new Padding(3);

            label8.Text = "Chức vụ";
            label8.Dock = DockStyle.Fill;
            label8.TextAlign = ContentAlignment.MiddleLeft;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(35, 51, 72);
            label8.Margin = new Padding(3);

            label11.Text = "Trạng thái";
            label11.Dock = DockStyle.Fill;
            label11.TextAlign = ContentAlignment.MiddleLeft;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.ForeColor = Color.FromArgb(35, 51, 72);
            label11.Margin = new Padding(3);

            txtMaNV.Font = new Font("Segoe UI", 10F);
            txtMaNV.BackColor = Color.FromArgb(248, 250, 253);
            txtMaNV.ForeColor = Color.FromArgb(35, 51, 72);
            txtMaNV.BorderStyle = BorderStyle.FixedSingle;
            txtMaNV.Dock = DockStyle.Fill;
            txtMaNV.Margin = new Padding(5, 5, 8, 5);

            txtTenNV.Font = new Font("Segoe UI", 10F);
            txtTenNV.BackColor = Color.FromArgb(248, 250, 253);
            txtTenNV.ForeColor = Color.FromArgb(35, 51, 72);
            txtTenNV.BorderStyle = BorderStyle.FixedSingle;
            txtTenNV.Dock = DockStyle.Fill;
            txtTenNV.Margin = new Padding(5, 5, 8, 5);

            txtDiaChi.Font = new Font("Segoe UI", 10F);
            txtDiaChi.BackColor = Color.FromArgb(248, 250, 253);
            txtDiaChi.ForeColor = Color.FromArgb(35, 51, 72);
            txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
            txtDiaChi.Dock = DockStyle.Fill;
            txtDiaChi.Margin = new Padding(5, 5, 8, 5);

            txtMatKhau.Font = new Font("Segoe UI", 10F);
            txtMatKhau.BackColor = Color.FromArgb(248, 250, 253);
            txtMatKhau.ForeColor = Color.FromArgb(35, 51, 72);
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhau.Dock = DockStyle.Fill;
            txtMatKhau.Margin = new Padding(5, 5, 8, 5);

            txtSDT.Font = new Font("Segoe UI", 10F);
            txtSDT.BackColor = Color.FromArgb(248, 250, 253);
            txtSDT.ForeColor = Color.FromArgb(35, 51, 72);
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.Dock = DockStyle.Fill;
            txtSDT.Margin = new Padding(5, 5, 8, 5);

            cboChucVu.Font = new Font("Segoe UI", 9.5F);
            cboChucVu.BackColor = Color.FromArgb(248, 250, 253);
            cboChucVu.ForeColor = Color.FromArgb(35, 51, 72);
            cboChucVu.Dock = DockStyle.Fill;
            cboChucVu.Margin = new Padding(5, 5, 8, 5);

            cboTrangThai.Font = new Font("Segoe UI", 9.5F);
            cboTrangThai.BackColor = Color.FromArgb(248, 250, 253);
            cboTrangThai.ForeColor = Color.FromArgb(35, 51, 72);
            cboTrangThai.Dock = DockStyle.Fill;
            cboTrangThai.Margin = new Padding(5, 5, 8, 5);

            dtpNgaySinh.Dock = DockStyle.Fill;
            dtpNgaySinh.Font = new Font("Segoe UI", 9.5F);
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Margin = new Padding(5, 5, 8, 5);

            genderPanel = new FlowLayoutPanel();

            genderPanel.Dock = DockStyle.Fill;
            genderPanel.FlowDirection = FlowDirection.LeftToRight;
            genderPanel.WrapContents = false;
            genderPanel.BackColor = Color.White;
            genderPanel.Padding = new Padding(5, 5, 0, 0);

            radNam.Text = "Nam";

            radNu.Text = "Nữ";

            radNam.AutoSize = true;

            radNu.AutoSize = true;

            radNam.Font = new Font("Segoe UI", 9.5F);

            radNu.Font = new Font("Segoe UI", 9.5F);

            radNam.ForeColor = Color.FromArgb(35, 51, 72);

            radNu.ForeColor = Color.FromArgb(35, 51, 72);

            radNam.Margin = new Padding(3, 3, 20, 3);

            radNu.Margin = new Padding(3);

            genderPanel.Controls.Add(radNam);
            genderPanel.Controls.Add(radNu);

            fields.Controls.Add(label1, 0, 0);
            fields.Controls.Add(txtMaNV, 1, 0);
            fields.Controls.Add(label6, 2, 0);
            fields.Controls.Add(txtTenNV, 3, 0);
            fields.Controls.Add(label2, 0, 1);
            fields.Controls.Add(dtpNgaySinh, 1, 1);
            fields.Controls.Add(label7, 2, 1);
            fields.Controls.Add(genderPanel, 3, 1);
            fields.Controls.Add(label4, 0, 2);
            fields.Controls.Add(txtSDT, 1, 2);
            fields.Controls.Add(label8, 2, 2);
            fields.Controls.Add(cboChucVu, 3, 2);
            fields.Controls.Add(label3, 0, 3);
            fields.Controls.Add(txtDiaChi, 1, 3);

            fields.SetColumnSpan(txtDiaChi, 3);

            fields.Controls.Add(label5, 0, 4);
            fields.Controls.Add(txtMatKhau, 1, 4);
            fields.Controls.Add(label11, 2, 4);
            fields.Controls.Add(cboTrangThai, 3, 4);

            groupBox1.Controls.Add(fields);

            groupBox2.Text = "LƯU Ý";
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Margin = new Padding(0);
            groupBox2.BackColor = Color.White;
            groupBox2.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox2.Padding = new Padding(10);

            notePanel = new Panel();

            notePanel.Dock = DockStyle.Fill;
            notePanel.BackColor = Color.White;
            notePanel.Padding = new Padding(15);

            label9.AutoSize = false;
            label9.Dock = DockStyle.Top;
            label9.Height = 100;
            label9.Text = "TÀI KHOẢN ĐĂNG NHẬP\n\nTên đăng nhập: Mã nhân viên\n\nMật khẩu: Mật khẩu nhân viên";
            label9.Font = new Font("Segoe UI", 9.5F);
            label9.ForeColor = Color.FromArgb(35, 51, 72);
            label9.TextAlign = ContentAlignment.TopLeft;

            notePanel.Controls.Add(label9);

            groupBox2.Controls.Add(notePanel);

            top.Controls.Add(groupBox1, 0, 0);
            top.Controls.Add(groupBox2, 1, 0);

            groupBox3.Text = "CHỨC NĂNG";
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Margin = new Padding(0, 8, 0, 5);
            groupBox3.BackColor = Color.White;
            groupBox3.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox3.Padding = new Padding(10);

            actions = new FlowLayoutPanel();

            actions.Dock = DockStyle.Fill;
            actions.FlowDirection = FlowDirection.LeftToRight;
            actions.WrapContents = false;
            actions.Padding = new Padding(10, 5, 10, 2);
            actions.BackColor = Color.White;

            btnThem.BackColor = Color.FromArgb(36, 120, 212);
            btnThem.ForeColor = Color.White;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThem.Cursor = Cursors.Hand;
            btnThem.UseVisualStyleBackColor = false;

            btnSua.BackColor = Color.FromArgb(36, 120, 212);
            btnSua.ForeColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSua.Cursor = Cursors.Hand;
            btnSua.UseVisualStyleBackColor = false;

            btnXoa.BackColor = Color.FromArgb(210, 70, 70);
            btnXoa.ForeColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.UseVisualStyleBackColor = false;

            btnLamLai.BackColor = Color.FromArgb(112, 128, 150);
            btnLamLai.ForeColor = Color.White;
            btnLamLai.FlatStyle = FlatStyle.Flat;
            btnLamLai.FlatAppearance.BorderSize = 0;
            btnLamLai.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamLai.Cursor = Cursors.Hand;
            btnLamLai.UseVisualStyleBackColor = false;

            btnThoat.BackColor = Color.FromArgb(20, 43, 74);
            btnThoat.ForeColor = Color.White;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.UseVisualStyleBackColor = false;

            btnThem.Text = "+ THÊM";

            btnSua.Text = "SỬA";

            btnXoa.Text = "XÓA";

            btnLamLai.Text = "LÀM LẠI";

            btnThoat.Text = "THOÁT";

            btnThem.Size = new Size(130, 42);
            btnThem.Margin = new Padding(8, 5, 12, 5);

            actions.Controls.Add(btnThem);

            btnSua.Size = new Size(130, 42);
            btnSua.Margin = new Padding(8, 5, 12, 5);

            actions.Controls.Add(btnSua);

            btnXoa.Size = new Size(130, 42);
            btnXoa.Margin = new Padding(8, 5, 12, 5);

            actions.Controls.Add(btnXoa);

            btnLamLai.Size = new Size(130, 42);
            btnLamLai.Margin = new Padding(8, 5, 12, 5);

            actions.Controls.Add(btnLamLai);

            btnThoat.Size = new Size(130, 42);
            btnThoat.Margin = new Padding(8, 5, 12, 5);

            actions.Controls.Add(btnThoat);

            groupBox3.Controls.Add(actions);

            groupBox4.Text = "TÌM KIẾM NHÂN VIÊN";
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Margin = new Padding(0, 5, 0, 0);
            groupBox4.BackColor = Color.White;
            groupBox4.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox4.Padding = new Padding(10);

            searchLayout = new TableLayoutPanel();

            searchLayout.Dock = DockStyle.Fill;
            searchLayout.ColumnCount = 3;
            searchLayout.RowCount = 1;
            searchLayout.Padding = new Padding(12, 8, 12, 8);
            searchLayout.BackColor = Color.White;
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));

            label10.Text = "Tên hoặc mã nhân viên";
            label10.Dock = DockStyle.Fill;
            label10.TextAlign = ContentAlignment.MiddleLeft;
            label10.Font = new Font("Segoe UI", 9.5F);
            label10.ForeColor = Color.FromArgb(35, 51, 72);

            txtTim.Font = new Font("Segoe UI", 10F);
            txtTim.BackColor = Color.FromArgb(248, 250, 253);
            txtTim.ForeColor = Color.FromArgb(35, 51, 72);
            txtTim.BorderStyle = BorderStyle.FixedSingle;
            txtTim.Dock = DockStyle.Fill;
            txtTim.Margin = new Padding(5, 5, 8, 5);
            txtTim.Dock = DockStyle.Fill;

            btnTim.Text = "TÌM KIẾM";
            btnTim.Dock = DockStyle.Fill;
            btnTim.BackColor = Color.FromArgb(36, 120, 212);
            btnTim.ForeColor = Color.White;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.FlatAppearance.BorderSize = 0;
            btnTim.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTim.Cursor = Cursors.Hand;
            btnTim.UseVisualStyleBackColor = false;

            searchLayout.Controls.Add(label10, 0, 0);
            searchLayout.Controls.Add(txtTim, 1, 0);
            searchLayout.Controls.Add(btnTim, 2, 0);

            groupBox4.Controls.Add(searchLayout);

            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.BackgroundColor = Color.White;
            dgvNhanVien.BorderStyle = BorderStyle.None;
            dgvNhanVien.EnableHeadersVisualStyles = false;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 43, 74);
            dgvNhanVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvNhanVien.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvNhanVien.DefaultCellStyle.ForeColor = Color.FromArgb(35, 51, 72);
            dgvNhanVien.DefaultCellStyle.BackColor = Color.White;
            dgvNhanVien.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 252);
            dgvNhanVien.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 43, 74);
            dgvNhanVien.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 252);
            dgvNhanVien.ColumnHeadersHeight = 42;
            dgvNhanVien.RowTemplate.Height = 36;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.GridColor = Color.FromArgb(220, 228, 238);
            dgvNhanVien.Margin = new Padding(0, 5, 0, 0);

            root.Controls.Add(top, 0, 0);
            root.Controls.Add(groupBox3, 0, 1);
            root.Controls.Add(groupBox4, 0, 2);
            root.Controls.Add(dgvNhanVien, 0, 3);

            Controls.Add(root);

            ResumeLayout(false);
        }

        // KHAI BÁO CONTROL

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private TextBox txtMaNV;
        private TextBox txtTenNV;
        private TextBox txtDiaChi;
        private TextBox txtMatKhau;
        private TextBox txtSDT;
        private TextBox txtTim;
        private ComboBox cboChucVu;
        private ComboBox cboTrangThai;
        private DateTimePicker dtpNgaySinh;
        private RadioButton radNam;
        private RadioButton radNu;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamLai;
        private Button btnThoat;
        private Button btnTim;
        private DataGridView dgvNhanVien;
        private Label label1;
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
        private TableLayoutPanel root;
        private TableLayoutPanel top;
        private TableLayoutPanel fields;
        private FlowLayoutPanel genderPanel;
        private Panel notePanel;
        private FlowLayoutPanel actions;
        private TableLayoutPanel searchLayout;
    }
}
