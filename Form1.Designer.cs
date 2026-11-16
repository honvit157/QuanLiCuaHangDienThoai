using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form1
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
            txtMaHang = new TextBox();
            txtTenHang = new TextBox();
            txtGiaNhap = new TextBox();
            txtGiaBan = new TextBox();
            txtSoLuong = new TextBox();
            txtTim = new TextBox();
            cboHang = new ComboBox();
            cboLoai = new ComboBox();
            cboMau = new ComboBox();
            cboDungLuong = new ComboBox();
            picAnh = new PictureBox();
            lblTenAnh = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamLai = new Button();
            btnThoat = new Button();
            btnChonAnh = new Button();
            btnTim = new Button();
            dgvHang = new DataGridView();
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

            SuspendLayout();
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 251);
            Font = new Font("Segoe UI", 9.5F);
            ClientSize = new Size(1100, 760);
            MinimumSize = new Size(850, 600);
            Name = "Form1";
            Text = "PHONE STORE - Quản lý điện thoại";

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

            top = new TableLayoutPanel();

            top.Dock = DockStyle.Fill;
            top.ColumnCount = 2;
            top.RowCount = 1;
            top.BackColor = Color.FromArgb(244, 247, 251);
            top.Margin = Padding.Empty;
            top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68F));
            top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));

            groupBox1.Text = "THÔNG TIN ĐIỆN THOẠI";
            groupBox1.BackColor = Color.White;
            groupBox1.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.Padding = new Padding(10);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Margin = new Padding(0, 0, 10, 0);

            fields = new TableLayoutPanel();

            fields.Dock = DockStyle.Fill;
            fields.ColumnCount = 4;
            fields.RowCount = 5;
            fields.Padding = new Padding(12, 10, 12, 10);
            fields.BackColor = Color.White;
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));

            label1.Text = "Mã hàng";
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(35, 51, 72);
            label1.Margin = new Padding(3);

            label6.Text = "Tên hàng";
            label6.Dock = DockStyle.Fill;
            label6.TextAlign = ContentAlignment.MiddleLeft;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(35, 51, 72);
            label6.Margin = new Padding(3);

            label2.Text = "Hãng SX";
            label2.Dock = DockStyle.Fill;
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(35, 51, 72);
            label2.Margin = new Padding(3);

            label7.Text = "Loại";
            label7.Dock = DockStyle.Fill;
            label7.TextAlign = ContentAlignment.MiddleLeft;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(35, 51, 72);
            label7.Margin = new Padding(3);

            label4.Text = "Màu sắc";
            label4.Dock = DockStyle.Fill;
            label4.TextAlign = ContentAlignment.MiddleLeft;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(35, 51, 72);
            label4.Margin = new Padding(3);

            label8.Text = "Dung lượng";
            label8.Dock = DockStyle.Fill;
            label8.TextAlign = ContentAlignment.MiddleLeft;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(35, 51, 72);
            label8.Margin = new Padding(3);

            label3.Text = "Giá nhập";
            label3.Dock = DockStyle.Fill;
            label3.TextAlign = ContentAlignment.MiddleLeft;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(35, 51, 72);
            label3.Margin = new Padding(3);

            label9.Text = "Giá bán";
            label9.Dock = DockStyle.Fill;
            label9.TextAlign = ContentAlignment.MiddleLeft;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(35, 51, 72);
            label9.Margin = new Padding(3);

            label5.Text = "Số lượng tồn";
            label5.Dock = DockStyle.Fill;
            label5.TextAlign = ContentAlignment.MiddleLeft;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(35, 51, 72);
            label5.Margin = new Padding(3);

            txtMaHang.Font = new Font("Segoe UI", 10F);
            txtMaHang.BackColor = Color.FromArgb(248, 250, 253);
            txtMaHang.ForeColor = Color.FromArgb(35, 51, 72);
            txtMaHang.BorderStyle = BorderStyle.FixedSingle;
            txtMaHang.Dock = DockStyle.Fill;
            txtMaHang.Margin = new Padding(5, 5, 8, 5);

            txtTenHang.Font = new Font("Segoe UI", 10F);
            txtTenHang.BackColor = Color.FromArgb(248, 250, 253);
            txtTenHang.ForeColor = Color.FromArgb(35, 51, 72);
            txtTenHang.BorderStyle = BorderStyle.FixedSingle;
            txtTenHang.Dock = DockStyle.Fill;
            txtTenHang.Margin = new Padding(5, 5, 8, 5);

            txtGiaNhap.Font = new Font("Segoe UI", 10F);
            txtGiaNhap.BackColor = Color.FromArgb(248, 250, 253);
            txtGiaNhap.ForeColor = Color.FromArgb(35, 51, 72);
            txtGiaNhap.BorderStyle = BorderStyle.FixedSingle;
            txtGiaNhap.Dock = DockStyle.Fill;
            txtGiaNhap.Margin = new Padding(5, 5, 8, 5);

            txtGiaBan.Font = new Font("Segoe UI", 10F);
            txtGiaBan.BackColor = Color.FromArgb(248, 250, 253);
            txtGiaBan.ForeColor = Color.FromArgb(35, 51, 72);
            txtGiaBan.BorderStyle = BorderStyle.FixedSingle;
            txtGiaBan.Dock = DockStyle.Fill;
            txtGiaBan.Margin = new Padding(5, 5, 8, 5);

            txtSoLuong.Font = new Font("Segoe UI", 10F);
            txtSoLuong.BackColor = Color.FromArgb(248, 250, 253);
            txtSoLuong.ForeColor = Color.FromArgb(35, 51, 72);
            txtSoLuong.BorderStyle = BorderStyle.FixedSingle;
            txtSoLuong.Dock = DockStyle.Fill;
            txtSoLuong.Margin = new Padding(5, 5, 8, 5);

            cboHang.Font = new Font("Segoe UI", 9.5F);
            cboHang.BackColor = Color.FromArgb(248, 250, 253);
            cboHang.ForeColor = Color.FromArgb(35, 51, 72);
            cboHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHang.Dock = DockStyle.Fill;
            cboHang.Margin = new Padding(5, 5, 8, 5);

            cboLoai.Font = new Font("Segoe UI", 9.5F);
            cboLoai.BackColor = Color.FromArgb(248, 250, 253);
            cboLoai.ForeColor = Color.FromArgb(35, 51, 72);
            cboLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoai.Dock = DockStyle.Fill;
            cboLoai.Margin = new Padding(5, 5, 8, 5);

            cboMau.Font = new Font("Segoe UI", 9.5F);
            cboMau.BackColor = Color.FromArgb(248, 250, 253);
            cboMau.ForeColor = Color.FromArgb(35, 51, 72);
            cboMau.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMau.Dock = DockStyle.Fill;
            cboMau.Margin = new Padding(5, 5, 8, 5);

            cboDungLuong.Font = new Font("Segoe UI", 9.5F);
            cboDungLuong.BackColor = Color.FromArgb(248, 250, 253);
            cboDungLuong.ForeColor = Color.FromArgb(35, 51, 72);
            cboDungLuong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDungLuong.Dock = DockStyle.Fill;
            cboDungLuong.Margin = new Padding(5, 5, 8, 5);

            fields.Controls.Add(label1, 0, 0);
            fields.Controls.Add(txtMaHang, 1, 0);
            fields.Controls.Add(label6, 2, 0);
            fields.Controls.Add(txtTenHang, 3, 0);
            fields.Controls.Add(label2, 0, 1);
            fields.Controls.Add(cboHang, 1, 1);
            fields.Controls.Add(label7, 2, 1);
            fields.Controls.Add(cboLoai, 3, 1);
            fields.Controls.Add(label4, 0, 2);
            fields.Controls.Add(cboMau, 1, 2);
            fields.Controls.Add(label8, 2, 2);
            fields.Controls.Add(cboDungLuong, 3, 2);
            fields.Controls.Add(label3, 0, 3);
            fields.Controls.Add(txtGiaNhap, 1, 3);
            fields.Controls.Add(label9, 2, 3);
            fields.Controls.Add(txtGiaBan, 3, 3);
            fields.Controls.Add(label5, 0, 4);
            fields.Controls.Add(txtSoLuong, 1, 4);

            groupBox1.Controls.Add(fields);

            groupBox2.Text = "ẢNH ĐẠI DIỆN";
            groupBox2.BackColor = Color.White;
            groupBox2.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox2.Padding = new Padding(10);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Margin = new Padding(0);

            imageLayout = new TableLayoutPanel();

            imageLayout.Dock = DockStyle.Fill;
            imageLayout.ColumnCount = 1;
            imageLayout.RowCount = 3;
            imageLayout.Padding = new Padding(12);
            imageLayout.BackColor = Color.White;
            imageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            imageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            imageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));

            picAnh.Dock = DockStyle.Fill;
            picAnh.BackColor = Color.FromArgb(244, 247, 251);
            picAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picAnh.Margin = new Padding(0, 0, 0, 8);

            btnChonAnh.Text = "CHỌN ẢNH";
            btnChonAnh.Dock = DockStyle.Fill;
            btnChonAnh.BackColor = Color.FromArgb(36, 120, 212);
            btnChonAnh.ForeColor = Color.White;
            btnChonAnh.FlatStyle = FlatStyle.Flat;
            btnChonAnh.FlatAppearance.BorderSize = 0;
            btnChonAnh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnChonAnh.Cursor = Cursors.Hand;
            btnChonAnh.UseVisualStyleBackColor = false;

            lblTenAnh.Text = "Chưa chọn ảnh";
            lblTenAnh.Dock = DockStyle.Fill;
            lblTenAnh.TextAlign = ContentAlignment.MiddleCenter;
            lblTenAnh.ForeColor = Color.FromArgb(112, 128, 150);
            lblTenAnh.AutoEllipsis = true;
            lblTenAnh.Font = new Font("Segoe UI", 9.5F);

            imageLayout.Controls.Add(picAnh, 0, 0);
            imageLayout.Controls.Add(btnChonAnh, 0, 1);
            imageLayout.Controls.Add(lblTenAnh, 0, 2);

            groupBox2.Controls.Add(imageLayout);

            top.Controls.Add(groupBox1, 0, 0);
            top.Controls.Add(groupBox2, 1, 0);

            groupBox3.Text = "CHỨC NĂNG";
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Margin = new Padding(0, 6, 0, 5);
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

            btnThem.Size = new Size(130, 45);
            btnThem.Margin = new Padding(8, 5, 12, 5);

            actions.Controls.Add(btnThem);

            btnSua.Size = new Size(130, 45);
            btnSua.Margin = new Padding(8, 5, 12, 5);

            actions.Controls.Add(btnSua);

            btnXoa.Size = new Size(130, 45);
            btnXoa.Margin = new Padding(8, 5, 12, 5);

            actions.Controls.Add(btnXoa);

            btnLamLai.Size = new Size(130, 45);
            btnLamLai.Margin = new Padding(8, 5, 12, 5);

            actions.Controls.Add(btnLamLai);

            btnThoat.Size = new Size(130, 45);
            btnThoat.Margin = new Padding(8, 5, 12, 5);

            actions.Controls.Add(btnThoat);

            groupBox3.Controls.Add(actions);

            groupBox4.Text = "TÌM KIẾM MẶT HÀNG";
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Margin = new Padding(0, 6, 0, 0);
            groupBox4.BackColor = Color.White;
            groupBox4.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox4.Padding = new Padding(10);

            searchLayout = new TableLayoutPanel();

            searchLayout.Dock = DockStyle.Fill;
            searchLayout.ColumnCount = 3;
            searchLayout.RowCount = 1;
            searchLayout.Padding = new Padding(10, 4, 10, 4);
            searchLayout.BackColor = Color.White;
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115F));

            label10.Text = "Tên hoặc mã hàng";
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
            txtTim.Margin = new Padding(5, 3, 10, 3);

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

            dgvHang.Dock = DockStyle.Fill;
            dgvHang.BackgroundColor = Color.White;
            dgvHang.BorderStyle = BorderStyle.None;
            dgvHang.EnableHeadersVisualStyles = false;
            dgvHang.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 43, 74);
            dgvHang.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHang.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvHang.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvHang.DefaultCellStyle.ForeColor = Color.FromArgb(35, 51, 72);
            dgvHang.DefaultCellStyle.BackColor = Color.White;
            dgvHang.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 252);
            dgvHang.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 43, 74);
            dgvHang.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 252);
            dgvHang.ColumnHeadersHeight = 42;
            dgvHang.RowTemplate.Height = 36;
            dgvHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHang.MultiSelect = false;
            dgvHang.ReadOnly = true;
            dgvHang.AllowUserToAddRows = false;
            dgvHang.RowHeadersVisible = false;
            dgvHang.GridColor = Color.FromArgb(220, 228, 238);
            dgvHang.Margin = new Padding(0, 5, 0, 0);

            root.Controls.Add(top, 0, 0);
            root.Controls.Add(groupBox3, 0, 1);
            root.Controls.Add(groupBox4, 0, 2);
            root.Controls.Add(dgvHang, 0, 3);

            Controls.Add(root);

            ResumeLayout(false);
        }

        // KHAI BÁO CONTROL

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private TextBox txtMaHang;
        private TextBox txtTenHang;
        private TextBox txtGiaNhap;
        private TextBox txtGiaBan;
        private TextBox txtSoLuong;
        private TextBox txtTim;
        private ComboBox cboHang;
        private ComboBox cboLoai;
        private ComboBox cboMau;
        private ComboBox cboDungLuong;
        private PictureBox picAnh;
        private Label lblTenAnh;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamLai;
        private Button btnThoat;
        private Button btnChonAnh;
        private Button btnTim;
        private DataGridView dgvHang;
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
        private TableLayoutPanel root;
        private TableLayoutPanel top;
        private TableLayoutPanel fields;
        private TableLayoutPanel imageLayout;
        private FlowLayoutPanel actions;
        private TableLayoutPanel searchLayout;
    }
}
