namespace QuanLyCuaHangDienThoai
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTim = new TextBox();
            label10 = new Label();
            btnThoat = new Button();
            btnLamLai = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            txtTenNV = new TextBox();
            btnTim = new Button();
            txtMatKhau = new TextBox();
            txtMaNV = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label4 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label6 = new Label();
            label1 = new Label();
            groupBox4 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox2 = new GroupBox();
            label9 = new Label();
            txtDiaChi = new TextBox();
            groupBox1 = new GroupBox();
            cboTrangThai = new ComboBox();
            label11 = new Label();
            cboChucVu = new ComboBox();
            dtpNgaySinh = new DateTimePicker();
            radNu = new RadioButton();
            radNam = new RadioButton();
            txtSDT = new TextBox();
            dgvNhanVien = new DataGridView();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // txtTim
            // 
            txtTim.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtTim.Font = UiTheme.Than;
            txtTim.BackColor = UiTheme.The;
            txtTim.ForeColor = UiTheme.Chu;
            txtTim.BorderStyle = BorderStyle.FixedSingle;
            txtTim.Location = new Point(103, 40);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(170, 23);
            txtTim.TabIndex = 3;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label10.Font = UiTheme.Than;
            label10.Location = new Point(18, 41);
            label10.ForeColor = UiTheme.Chu;
            label10.AutoSize = true;
            label10.Name = "label10";
            label10.Size = new Size(34, 19);
            label10.TabIndex = 0;
            label10.Text = "Tên:";
            // 
            // btnThoat
            // 
            btnThoat.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnThoat.Location = new Point(518, 34);
            btnThoat.Size = new Size(104, 32);
            btnThoat.BackColor = UiTheme.The;
            btnThoat.FlatAppearance.BorderColor = UiTheme.Vien;
            btnThoat.ForeColor = UiTheme.Chinh;
            btnThoat.Font = UiTheme.Nut;
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.FlatAppearance.BorderSize = 1;
            btnThoat.FlatAppearance.MouseOverBackColor = UiTheme.NutNhat;
            btnThoat.FlatAppearance.MouseDownBackColor = UiTheme.NutNhatHover;
            btnThoat.Name = "btnThoat";
            btnThoat.TabIndex = 4;
            btnThoat.Text = "Th&oát";
            // 
            // btnLamLai
            // 
            btnLamLai.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnLamLai.Location = new Point(394, 34);
            btnLamLai.Size = new Size(104, 32);
            btnLamLai.BackColor = UiTheme.The;
            btnLamLai.FlatAppearance.BorderColor = UiTheme.Vien;
            btnLamLai.ForeColor = UiTheme.Chinh;
            btnLamLai.Font = UiTheme.Nut;
            btnLamLai.Cursor = Cursors.Hand;
            btnLamLai.FlatStyle = FlatStyle.Flat;
            btnLamLai.UseVisualStyleBackColor = false;
            btnLamLai.FlatAppearance.BorderSize = 1;
            btnLamLai.FlatAppearance.MouseOverBackColor = UiTheme.NutNhat;
            btnLamLai.FlatAppearance.MouseDownBackColor = UiTheme.NutNhatHover;
            btnLamLai.Name = "btnLamLai";
            btnLamLai.TabIndex = 3;
            btnLamLai.Text = "&Làm lại";
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnXoa.Location = new Point(270, 34);
            btnXoa.Size = new Size(104, 32);
            btnXoa.BackColor = UiTheme.NguyHiem;
            btnXoa.ForeColor = Color.White;
            btnXoa.Font = UiTheme.Nut;
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatAppearance.MouseOverBackColor = UiTheme.NguyHiemHover;
            btnXoa.FlatAppearance.MouseDownBackColor = UiTheme.NguyHiemDown;
            btnXoa.Name = "btnXoa";
            btnXoa.TabIndex = 2;
            btnXoa.Text = "&Xóa";
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnSua.Location = new Point(146, 34);
            btnSua.Size = new Size(104, 32);
            btnSua.BackColor = UiTheme.Chinh;
            btnSua.ForeColor = Color.White;
            btnSua.Font = UiTheme.Nut;
            btnSua.Cursor = Cursors.Hand;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.UseVisualStyleBackColor = false;
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatAppearance.MouseOverBackColor = UiTheme.ChinhHover;
            btnSua.FlatAppearance.MouseDownBackColor = UiTheme.ChinhDown;
            btnSua.Name = "btnSua";
            btnSua.TabIndex = 1;
            btnSua.Text = "&Sửa";
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnThem.Location = new Point(22, 34);
            btnThem.Size = new Size(104, 32);
            btnThem.BackColor = UiTheme.Chinh;
            btnThem.ForeColor = Color.White;
            btnThem.Font = UiTheme.Nut;
            btnThem.Cursor = Cursors.Hand;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.UseVisualStyleBackColor = false;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatAppearance.MouseOverBackColor = UiTheme.ChinhHover;
            btnThem.FlatAppearance.MouseDownBackColor = UiTheme.ChinhDown;
            btnThem.Name = "btnThem";
            btnThem.TabIndex = 0;
            btnThem.Text = "&Thêm";
            // 
            // txtTenNV
            // 
            txtTenNV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTenNV.Font = UiTheme.Than;
            txtTenNV.BackColor = UiTheme.The;
            txtTenNV.ForeColor = UiTheme.Chu;
            txtTenNV.BorderStyle = BorderStyle.FixedSingle;
            txtTenNV.Location = new Point(454, 29);
            txtTenNV.Name = "txtTenNV";
            txtTenNV.Size = new Size(154, 23);
            txtTenNV.TabIndex = 7;
            // 
            // btnTim
            // 
            btnTim.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTim.Location = new Point(283, 36);
            btnTim.Size = new Size(104, 30);
            btnTim.BackColor = UiTheme.Chinh;
            btnTim.ForeColor = Color.White;
            btnTim.Font = UiTheme.Nut;
            btnTim.Cursor = Cursors.Hand;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.UseVisualStyleBackColor = false;
            btnTim.FlatAppearance.BorderSize = 0;
            btnTim.FlatAppearance.MouseOverBackColor = UiTheme.ChinhHover;
            btnTim.FlatAppearance.MouseDownBackColor = UiTheme.ChinhDown;
            btnTim.Name = "btnTim";
            btnTim.TabIndex = 2;
            btnTim.Text = "T&ìm";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtMatKhau.Font = UiTheme.Than;
            txtMatKhau.BackColor = UiTheme.The;
            txtMatKhau.ForeColor = UiTheme.Chu;
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhau.Location = new Point(106, 200);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(154, 23);
            txtMatKhau.TabIndex = 6;
            // 
            // txtMaNV
            // 
            txtMaNV.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtMaNV.Font = UiTheme.Than;
            txtMaNV.BackColor = UiTheme.The;
            txtMaNV.ForeColor = UiTheme.Chu;
            txtMaNV.BorderStyle = BorderStyle.FixedSingle;
            txtMaNV.Location = new Point(106, 29);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(154, 23);
            txtMaNV.TabIndex = 4;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.Font = UiTheme.Than;
            label8.ForeColor = UiTheme.Chu;
            label8.AutoSize = true;
            label8.Location = new Point(370, 118);
            label8.Name = "label8";
            label8.Size = new Size(61, 19);
            label8.TabIndex = 2;
            label8.Text = "Chức vụ";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.Font = UiTheme.Than;
            label7.ForeColor = UiTheme.Chu;
            label7.AutoSize = true;
            label7.Location = new Point(370, 73);
            label7.Name = "label7";
            label7.Size = new Size(63, 19);
            label7.TabIndex = 1;
            label7.Text = "Giới tính";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label4.Font = UiTheme.Than;
            label4.ForeColor = UiTheme.Chu;
            label4.AutoSize = true;
            label4.Location = new Point(11, 118);
            label4.Name = "label4";
            label4.Size = new Size(94, 19);
            label4.TabIndex = 0;
            label4.Text = "Số điện thoại";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label5.Font = UiTheme.Than;
            label5.ForeColor = UiTheme.Chu;
            label5.AutoSize = true;
            label5.Location = new Point(11, 200);
            label5.Name = "label5";
            label5.Size = new Size(69, 19);
            label5.TabIndex = 0;
            label5.Text = "Mật khẩu";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label3.Font = UiTheme.Than;
            label3.ForeColor = UiTheme.Chu;
            label3.AutoSize = true;
            label3.Location = new Point(11, 162);
            label3.Name = "label3";
            label3.Size = new Size(52, 19);
            label3.TabIndex = 0;
            label3.Text = "Địa chỉ";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label2.Font = UiTheme.Than;
            label2.ForeColor = UiTheme.Chu;
            label2.AutoSize = true;
            label2.Location = new Point(11, 73);
            label2.Name = "label2";
            label2.Size = new Size(73, 19);
            label2.TabIndex = 0;
            label2.Text = "Ngày sinh";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.Font = UiTheme.Than;
            label6.ForeColor = UiTheme.Chu;
            label6.AutoSize = true;
            label6.Location = new Point(370, 34);
            label6.Name = "label6";
            label6.Size = new Size(52, 19);
            label6.TabIndex = 0;
            label6.Text = "Họ tên";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label1.Font = UiTheme.Than;
            label1.ForeColor = UiTheme.Chu;
            label1.AutoSize = true;
            label1.Location = new Point(11, 34);
            label1.Name = "label1";
            label1.Size = new Size(53, 19);
            label1.TabIndex = 0;
            label1.Text = "Mã NV";
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox4.Font = UiTheme.TieuDeMuc;
            groupBox4.BackColor = UiTheme.The;
            groupBox4.ForeColor = UiTheme.Chinh;
            groupBox4.Controls.Add(txtTim);
            groupBox4.Controls.Add(btnTim);
            groupBox4.Controls.Add(label10);
            groupBox4.Location = new Point(686, 291);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(434, 98);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "Tìm nhanh";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Font = UiTheme.TieuDeMuc;
            groupBox3.BackColor = UiTheme.The;
            groupBox3.ForeColor = UiTheme.Chinh;
            groupBox3.Controls.Add(btnThoat);
            groupBox3.Controls.Add(btnLamLai);
            groupBox3.Controls.Add(btnXoa);
            groupBox3.Controls.Add(btnSua);
            groupBox3.Controls.Add(btnThem);
            groupBox3.Location = new Point(26, 291);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(644, 98);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Chức năng";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.Font = UiTheme.TieuDeMuc;
            groupBox2.BackColor = UiTheme.The;
            groupBox2.ForeColor = UiTheme.Chinh;
            groupBox2.Controls.Add(label9);
            groupBox2.Location = new Point(685, 16);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(436, 250);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Lưu ý";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label9.Font = UiTheme.Than;
            label9.ForeColor = UiTheme.ChuPhu;
            label9.AutoSize = true;
            label9.Location = new Point(29, 44);
            label9.Name = "label9";
            label9.Size = new Size(365, 19);
            label9.TabIndex = 2;
            label9.Text = "Tài khoản đăng nhập: User = Mã NV ; Pass = Mật khẩu";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDiaChi.Font = UiTheme.Than;
            txtDiaChi.BackColor = UiTheme.The;
            txtDiaChi.ForeColor = UiTheme.Chu;
            txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
            txtDiaChi.Location = new Point(106, 158);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(502, 23);
            txtDiaChi.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Font = UiTheme.TieuDeMuc;
            groupBox1.BackColor = UiTheme.The;
            groupBox1.ForeColor = UiTheme.Chinh;
            groupBox1.Controls.Add(cboTrangThai);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(cboChucVu);
            groupBox1.Controls.Add(dtpNgaySinh);
            groupBox1.Controls.Add(radNu);
            groupBox1.Controls.Add(radNam);
            groupBox1.Controls.Add(txtSDT);
            groupBox1.Controls.Add(txtTenNV);
            groupBox1.Controls.Add(txtMatKhau);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(txtMaNV);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(26, 31);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(644, 248);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin nhân viên";
            // 
            // cboTrangThai
            // 
            cboTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboTrangThai.Font = UiTheme.Than;
            cboTrangThai.BackColor = UiTheme.The;
            cboTrangThai.ForeColor = UiTheme.Chu;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(454, 196);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(154, 24);
            cboTrangThai.TabIndex = 19;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label11.Font = UiTheme.Than;
            label11.ForeColor = UiTheme.Chu;
            label11.AutoSize = true;
            label11.Location = new Point(370, 200);
            label11.Name = "label11";
            label11.Size = new Size(75, 19);
            label11.TabIndex = 18;
            label11.Text = "Trạng thái";
            // 
            // cboChucVu
            // 
            cboChucVu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboChucVu.Font = UiTheme.Than;
            cboChucVu.BackColor = UiTheme.The;
            cboChucVu.ForeColor = UiTheme.Chu;
            cboChucVu.FormattingEnabled = true;
            cboChucVu.Location = new Point(454, 113);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(154, 24);
            cboChucVu.TabIndex = 17;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            dtpNgaySinh.Font = UiTheme.Than;
            dtpNgaySinh.ForeColor = UiTheme.Chu;
            dtpNgaySinh.Location = new Point(106, 69);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(154, 23);
            dtpNgaySinh.TabIndex = 16;
            // 
            // radNu
            // 
            radNu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            radNu.Font = UiTheme.Than;
            radNu.ForeColor = UiTheme.Chu;
            radNu.Cursor = Cursors.Hand;
            radNu.AutoSize = true;
            radNu.Location = new Point(546, 71);
            radNu.Name = "radNu";
            radNu.Size = new Size(46, 22);
            radNu.TabIndex = 15;
            radNu.TabStop = true;
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;
            // 
            // radNam
            // 
            radNam.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            radNam.Font = UiTheme.Than;
            radNam.ForeColor = UiTheme.Chu;
            radNam.Cursor = Cursors.Hand;
            radNam.AutoSize = true;
            radNam.Location = new Point(454, 71);
            radNam.Name = "radNam";
            radNam.Size = new Size(62, 22);
            radNam.TabIndex = 14;
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;
            // 
            // txtSDT
            // 
            txtSDT.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtSDT.Font = UiTheme.Than;
            txtSDT.BackColor = UiTheme.The;
            txtSDT.ForeColor = UiTheme.Chu;
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.Location = new Point(106, 113);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(154, 23);
            txtSDT.TabIndex = 13;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNhanVien.Font = UiTheme.Luoi;
            dgvNhanVien.BorderStyle = BorderStyle.None;
            dgvNhanVien.AlternatingRowsDefaultCellStyle.BackColor = UiTheme.DongXen;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.BackgroundColor = UiTheme.The;
            dgvNhanVien.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvNhanVien.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.BackColor = UiTheme.Chinh;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Font = UiTheme.LuoiTieuDe;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            dgvNhanVien.ColumnHeadersDefaultCellStyle.SelectionBackColor = UiTheme.Chinh;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvNhanVien.DefaultCellStyle.BackColor = UiTheme.The;
            dgvNhanVien.DefaultCellStyle.ForeColor = UiTheme.Chu;
            dgvNhanVien.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            dgvNhanVien.DefaultCellStyle.SelectionBackColor = UiTheme.ChonDong;
            dgvNhanVien.DefaultCellStyle.SelectionForeColor = UiTheme.Chinh;
            dgvNhanVien.GridColor = UiTheme.Vien;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.RowTemplate.Height = 30;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Location = new Point(28, 409);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 49;
            dgvNhanVien.Size = new Size(1093, 280);
            dgvNhanVien.TabIndex = 9;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 722);
            Controls.Add(dgvNhanVien);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Text = "Quản lý nhân viên";
            ForeColor = UiTheme.Chu;
            Font = UiTheme.Than;
            BackColor = UiTheme.Nen;
            Name = "Form2";
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtTim;
        private Label label10;
        private Button btnThoat;
        private Button btnLamLai;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private ListBox listBox4;
        private ListBox listBox1;
        private TextBox txtTenNV;
        private Button btnTim;
        private TextBox txtMatKhau;
        private TextBox txtMaNV;
        private Label label8;
        private Label label7;
        private Label label4;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label6;
        private Label label1;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private TextBox txtDiaChi;
        private GroupBox groupBox1;
        private RadioButton radNu;
        private RadioButton radNam;
        private Label label9;
      
        private TextBox txtSDT;
        private DateTimePicker dtpNgaySinh;
        private ComboBox cboChucVu;
        private DataGridView dgvNhanVien;
        private ComboBox cboTrangThai;
        private Label label11;
    }
}