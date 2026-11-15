namespace QuanLyCuaHangDienThoai
{
    partial class Form8
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            txtDiaChi = new TextBox();
            cboNCC = new ComboBox();
            txtTenNV = new TextBox();
            dtpNgayNhap = new DateTimePicker();
            txtSDT = new TextBox();
            txtMaNCC = new TextBox();
            txtMaNV = new TextBox();
            cboMaHDN = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            btnTim = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            txtDonGiaNhap = new TextBox();
            txtThanhTien = new TextBox();
            txtTenHang = new TextBox();
            txtSoLuong = new TextBox();
            cboMaHang = new ComboBox();
            button1 = new Button();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            groupBox3 = new GroupBox();
            lblTongTien = new Label();
            dgvChiTiet = new DataGridView();
            groupBox4 = new GroupBox();
            btnThoat = new Button();
            btnIn = new Button();
            btnHuy = new Button();
            btnLuu = new Button();
            btnThemHD = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = false;
            label1.Location = new Point(0, 4);
            label1.Size = new Size(983, 28);
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.ForeColor = UiTheme.Chinh;
            label1.Font = UiTheme.TieuDe;
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.TabIndex = 0;
            label1.Text = "HÓA ĐƠN NHẬP HÀNG";
            label1.Click += label1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Font = UiTheme.TieuDeMuc;
            groupBox1.BackColor = UiTheme.The;
            groupBox1.ForeColor = UiTheme.Chinh;
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(cboNCC);
            groupBox1.Controls.Add(txtTenNV);
            groupBox1.Controls.Add(dtpNgayNhap);
            groupBox1.Controls.Add(txtSDT);
            groupBox1.Controls.Add(txtMaNCC);
            groupBox1.Controls.Add(txtMaNV);
            groupBox1.Controls.Add(cboMaHDN);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(btnTim);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(10, 34);
            groupBox1.Margin = new Padding(2, 2, 2, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 2, 2, 2);
            groupBox1.Size = new Size(953, 160);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin chung";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDiaChi.Font = UiTheme.Than;
            txtDiaChi.BackColor = UiTheme.The;
            txtDiaChi.ForeColor = UiTheme.Chu;
            txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
            txtDiaChi.Location = new Point(731, 118);
            txtDiaChi.Margin = new Padding(2, 2, 2, 2);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(121, 27);
            txtDiaChi.TabIndex = 6;
            // 
            // cboNCC
            // 
            cboNCC.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            cboNCC.Font = UiTheme.Than;
            cboNCC.BackColor = UiTheme.The;
            cboNCC.ForeColor = UiTheme.Chu;
            cboNCC.FormattingEnabled = true;
            cboNCC.Location = new Point(121, 86);
            cboNCC.Margin = new Padding(2, 2, 2, 2);
            cboNCC.Name = "cboNCC";
            cboNCC.Size = new Size(238, 28);
            cboNCC.TabIndex = 15;
            // 
            // txtTenNV
            // 
            txtTenNV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTenNV.Font = UiTheme.Than;
            txtTenNV.BackColor = UiTheme.The;
            txtTenNV.ForeColor = UiTheme.Chu;
            txtTenNV.BorderStyle = BorderStyle.FixedSingle;
            txtTenNV.Location = new Point(731, 54);
            txtTenNV.Margin = new Padding(2, 2, 2, 2);
            txtTenNV.Name = "txtTenNV";
            txtTenNV.Size = new Size(121, 27);
            txtTenNV.TabIndex = 14;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpNgayNhap.Font = UiTheme.Than;
            dtpNgayNhap.ForeColor = UiTheme.Chu;
            dtpNgayNhap.Location = new Point(731, 24);
            dtpNgayNhap.Margin = new Padding(2, 2, 2, 2);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(207, 27);
            dtpNgayNhap.TabIndex = 13;
            // 
            // txtSDT
            // 
            txtSDT.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtSDT.Font = UiTheme.Than;
            txtSDT.BackColor = UiTheme.The;
            txtSDT.ForeColor = UiTheme.Chu;
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.Location = new Point(121, 118);
            txtSDT.Margin = new Padding(2, 2, 2, 2);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(157, 27);
            txtSDT.TabIndex = 12;
            // 
            // txtMaNCC
            // 
            txtMaNCC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtMaNCC.Font = UiTheme.Than;
            txtMaNCC.BackColor = UiTheme.The;
            txtMaNCC.ForeColor = UiTheme.Chu;
            txtMaNCC.BorderStyle = BorderStyle.FixedSingle;
            txtMaNCC.Location = new Point(731, 82);
            txtMaNCC.Margin = new Padding(2, 2, 2, 2);
            txtMaNCC.Name = "txtMaNCC";
            txtMaNCC.Size = new Size(192, 27);
            txtMaNCC.TabIndex = 11;
            // 
            // txtMaNV
            // 
            txtMaNV.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtMaNV.Font = UiTheme.Than;
            txtMaNV.BackColor = UiTheme.The;
            txtMaNV.ForeColor = UiTheme.Chu;
            txtMaNV.BorderStyle = BorderStyle.FixedSingle;
            txtMaNV.Location = new Point(121, 54);
            txtMaNV.Margin = new Padding(2, 2, 2, 2);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(238, 27);
            txtMaNV.TabIndex = 10;
            // 
            // cboMaHDN
            // 
            cboMaHDN.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            cboMaHDN.Font = UiTheme.Than;
            cboMaHDN.BackColor = UiTheme.The;
            cboMaHDN.ForeColor = UiTheme.Chu;
            cboMaHDN.FormattingEnabled = true;
            cboMaHDN.Location = new Point(121, 22);
            cboMaHDN.Margin = new Padding(2, 2, 2, 2);
            cboMaHDN.Name = "cboMaHDN";
            cboMaHDN.Size = new Size(238, 28);
            cboMaHDN.TabIndex = 9;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.Font = UiTheme.Than;
            label9.ForeColor = UiTheme.Chu;
            label9.AutoSize = true;
            label9.Location = new Point(647, 118);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(55, 20);
            label9.TabIndex = 8;
            label9.Text = "Địa chỉ";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.Font = UiTheme.Than;
            label8.ForeColor = UiTheme.Chu;
            label8.AutoSize = true;
            label8.Location = new Point(647, 85);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(63, 20);
            label8.TabIndex = 7;
            label8.Text = "Mã NCC";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.Font = UiTheme.Than;
            label7.ForeColor = UiTheme.Chu;
            label7.AutoSize = true;
            label7.Location = new Point(647, 54);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(56, 20);
            label7.TabIndex = 6;
            label7.Text = "Tên NV";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.Font = UiTheme.Than;
            label6.ForeColor = UiTheme.Chu;
            label6.AutoSize = true;
            label6.Location = new Point(647, 26);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(81, 20);
            label6.TabIndex = 5;
            label6.Text = "Ngày nhập";
            // 
            // btnTim
            // 
            btnTim.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnTim.Location = new Point(396, 21);
            btnTim.Size = new Size(96, 28);
            btnTim.BackColor = UiTheme.Chinh;
            btnTim.ForeColor = Color.White;
            btnTim.Font = UiTheme.Nut;
            btnTim.Cursor = Cursors.Hand;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.UseVisualStyleBackColor = false;
            btnTim.FlatAppearance.BorderSize = 0;
            btnTim.FlatAppearance.MouseOverBackColor = UiTheme.ChinhHover;
            btnTim.FlatAppearance.MouseDownBackColor = UiTheme.ChinhDown;
            btnTim.Margin = new Padding(2, 2, 2, 2);
            btnTim.Name = "btnTim";
            btnTim.TabIndex = 4;
            btnTim.Text = "&Tìm";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label5.Font = UiTheme.Than;
            label5.ForeColor = UiTheme.Chu;
            label5.AutoSize = true;
            label5.Location = new Point(14, 118);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 3;
            label5.Text = "SĐT NCC";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label4.Font = UiTheme.Than;
            label4.ForeColor = UiTheme.Chu;
            label4.AutoSize = true;
            label4.Location = new Point(14, 85);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 2;
            label4.Text = "Nhà cung cấp";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label3.Font = UiTheme.Than;
            label3.ForeColor = UiTheme.Chu;
            label3.AutoSize = true;
            label3.Location = new Point(14, 54);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 1;
            label3.Text = "Mã NV";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label2.Font = UiTheme.Than;
            label2.ForeColor = UiTheme.Chu;
            label2.AutoSize = true;
            label2.Location = new Point(14, 22);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã hóa đơn";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Font = UiTheme.TieuDeMuc;
            groupBox2.BackColor = UiTheme.The;
            groupBox2.ForeColor = UiTheme.Chinh;
            groupBox2.Controls.Add(txtDonGiaNhap);
            groupBox2.Controls.Add(txtThanhTien);
            groupBox2.Controls.Add(txtTenHang);
            groupBox2.Controls.Add(txtSoLuong);
            groupBox2.Controls.Add(cboMaHang);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label10);
            groupBox2.Location = new Point(10, 204);
            groupBox2.Margin = new Padding(2, 2, 2, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2, 2, 2, 2);
            groupBox2.Size = new Size(953, 97);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chọn hàng";
            // 
            // txtDonGiaNhap
            // 
            txtDonGiaNhap.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtDonGiaNhap.Font = UiTheme.Than;
            txtDonGiaNhap.BackColor = UiTheme.The;
            txtDonGiaNhap.ForeColor = UiTheme.Chu;
            txtDonGiaNhap.BorderStyle = BorderStyle.FixedSingle;
            txtDonGiaNhap.Location = new Point(652, 24);
            txtDonGiaNhap.Margin = new Padding(2, 2, 2, 2);
            txtDonGiaNhap.Name = "txtDonGiaNhap";
            txtDonGiaNhap.Size = new Size(121, 27);
            txtDonGiaNhap.TabIndex = 10;
            // 
            // txtThanhTien
            // 
            txtThanhTien.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtThanhTien.Font = UiTheme.Than;
            txtThanhTien.BackColor = UiTheme.The;
            txtThanhTien.ForeColor = UiTheme.Chu;
            txtThanhTien.BorderStyle = BorderStyle.FixedSingle;
            txtThanhTien.Location = new Point(369, 54);
            txtThanhTien.Margin = new Padding(2, 2, 2, 2);
            txtThanhTien.Name = "txtThanhTien";
            txtThanhTien.Size = new Size(121, 27);
            txtThanhTien.TabIndex = 9;
            // 
            // txtTenHang
            // 
            txtTenHang.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtTenHang.Font = UiTheme.Than;
            txtTenHang.BackColor = UiTheme.The;
            txtTenHang.ForeColor = UiTheme.Chu;
            txtTenHang.BorderStyle = BorderStyle.FixedSingle;
            txtTenHang.Location = new Point(369, 24);
            txtTenHang.Margin = new Padding(2, 2, 2, 2);
            txtTenHang.Name = "txtTenHang";
            txtTenHang.Size = new Size(121, 27);
            txtTenHang.TabIndex = 8;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtSoLuong.Font = UiTheme.Than;
            txtSoLuong.BackColor = UiTheme.The;
            txtSoLuong.ForeColor = UiTheme.Chu;
            txtSoLuong.BorderStyle = BorderStyle.FixedSingle;
            txtSoLuong.Location = new Point(84, 54);
            txtSoLuong.Margin = new Padding(2, 2, 2, 2);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(146, 27);
            txtSoLuong.TabIndex = 7;
            // 
            // cboMaHang
            // 
            cboMaHang.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            cboMaHang.Font = UiTheme.Than;
            cboMaHang.BackColor = UiTheme.The;
            cboMaHang.ForeColor = UiTheme.Chu;
            cboMaHang.FormattingEnabled = true;
            cboMaHang.Location = new Point(84, 24);
            cboMaHang.Margin = new Padding(2, 2, 2, 2);
            cboMaHang.Name = "cboMaHang";
            cboMaHang.Size = new Size(146, 28);
            cboMaHang.TabIndex = 6;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(620, 54);
            button1.Size = new Size(240, 30);
            button1.BackColor = UiTheme.Chinh;
            button1.ForeColor = Color.White;
            button1.Font = UiTheme.Nut;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.UseVisualStyleBackColor = false;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = UiTheme.ChinhHover;
            button1.FlatAppearance.MouseDownBackColor = UiTheme.ChinhDown;
            button1.Margin = new Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.TabIndex = 5;
            button1.Text = "Thêm mặt hàng vào HĐ";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label14.Font = UiTheme.Than;
            label14.ForeColor = UiTheme.Chu;
            label14.AutoSize = true;
            label14.Location = new Point(546, 26);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(99, 20);
            label14.TabIndex = 4;
            label14.Text = "Đơn giá nhập";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label13.Font = UiTheme.Than;
            label13.ForeColor = UiTheme.Chu;
            label13.AutoSize = true;
            label13.Location = new Point(291, 56);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(78, 20);
            label13.TabIndex = 3;
            label13.Text = "Thành tiền";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label12.Font = UiTheme.Than;
            label12.ForeColor = UiTheme.Chu;
            label12.AutoSize = true;
            label12.Location = new Point(291, 26);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(69, 20);
            label12.TabIndex = 2;
            label12.Text = "Tên hàng";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label11.Font = UiTheme.Than;
            label11.ForeColor = UiTheme.Chu;
            label11.AutoSize = true;
            label11.Location = new Point(14, 56);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(69, 20);
            label11.TabIndex = 1;
            label11.Text = "Số lượng";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label10.Font = UiTheme.Than;
            label10.ForeColor = UiTheme.Chu;
            label10.AutoSize = true;
            label10.Location = new Point(14, 26);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(67, 20);
            label10.TabIndex = 0;
            label10.Text = "Mã hàng";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Font = UiTheme.TieuDeMuc;
            groupBox3.BackColor = UiTheme.The;
            groupBox3.ForeColor = UiTheme.Chinh;
            groupBox3.Controls.Add(lblTongTien);
            groupBox3.Controls.Add(dgvChiTiet);
            groupBox3.Location = new Point(10, 311);
            groupBox3.Margin = new Padding(2, 2, 2, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(2, 2, 2, 2);
            groupBox3.Size = new Size(953, 164);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Chi tiết hóa đơn nhập";
            // 
            // lblTongTien
            // 
            lblTongTien.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTongTien.ForeColor = UiTheme.NguyHiem;
            lblTongTien.Font = UiTheme.TieuDeNho;
            lblTongTien.AutoSize = false;
            lblTongTien.Location = new Point(40, 130);
            lblTongTien.Margin = new Padding(2, 0, 2, 0);
            lblTongTien.TextAlign = ContentAlignment.MiddleRight;
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(900, 26);
            lblTongTien.TabIndex = 1;
            lblTongTien.Text = "Tổng tiền:";
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChiTiet.Font = UiTheme.Luoi;
            dgvChiTiet.BorderStyle = BorderStyle.None;
            dgvChiTiet.AlternatingRowsDefaultCellStyle.BackColor = UiTheme.DongXen;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.BackgroundColor = UiTheme.The;
            dgvChiTiet.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvChiTiet.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.BackColor = UiTheme.Chinh;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.Font = UiTheme.LuoiTieuDe;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            dgvChiTiet.ColumnHeadersDefaultCellStyle.SelectionBackColor = UiTheme.Chinh;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvChiTiet.DefaultCellStyle.BackColor = UiTheme.The;
            dgvChiTiet.DefaultCellStyle.ForeColor = UiTheme.Chu;
            dgvChiTiet.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            dgvChiTiet.DefaultCellStyle.SelectionBackColor = UiTheme.ChonDong;
            dgvChiTiet.DefaultCellStyle.SelectionForeColor = UiTheme.Chinh;
            dgvChiTiet.GridColor = UiTheme.Vien;
            dgvChiTiet.RowHeadersVisible = false;
            dgvChiTiet.RowTemplate.Height = 30;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Location = new Point(14, 24);
            dgvChiTiet.Margin = new Padding(2, 2, 2, 2);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.RowHeadersWidth = 62;
            dgvChiTiet.Size = new Size(924, 106);
            dgvChiTiet.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Font = UiTheme.TieuDeMuc;
            groupBox4.BackColor = UiTheme.The;
            groupBox4.ForeColor = UiTheme.Chinh;
            groupBox4.Controls.Add(btnThoat);
            groupBox4.Controls.Add(btnIn);
            groupBox4.Controls.Add(btnHuy);
            groupBox4.Controls.Add(btnLuu);
            groupBox4.Controls.Add(btnThemHD);
            groupBox4.Location = new Point(10, 485);
            groupBox4.Margin = new Padding(2, 2, 2, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(2, 2, 2, 2);
            groupBox4.Size = new Size(953, 106);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Chức năng";
            // 
            // btnThoat
            // 
            btnThoat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnThoat.Location = new Point(728, 38);
            btnThoat.Size = new Size(100, 32);
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
            btnThoat.Margin = new Padding(2, 2, 2, 2);
            btnThoat.Name = "btnThoat";
            btnThoat.TabIndex = 4;
            btnThoat.Text = "Th&oát";
            // 
            // btnIn
            // 
            btnIn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnIn.Location = new Point(550, 38);
            btnIn.Size = new Size(160, 32);
            btnIn.BackColor = UiTheme.Chinh;
            btnIn.ForeColor = Color.White;
            btnIn.Font = UiTheme.Nut;
            btnIn.Cursor = Cursors.Hand;
            btnIn.FlatStyle = FlatStyle.Flat;
            btnIn.UseVisualStyleBackColor = false;
            btnIn.FlatAppearance.BorderSize = 0;
            btnIn.FlatAppearance.MouseOverBackColor = UiTheme.ChinhHover;
            btnIn.FlatAppearance.MouseDownBackColor = UiTheme.ChinhDown;
            btnIn.Margin = new Padding(2, 2, 2, 2);
            btnIn.Name = "btnIn";
            btnIn.TabIndex = 3;
            btnIn.Text = "&In hóa đơn (excel)";
            // 
            // btnHuy
            // 
            btnHuy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnHuy.Location = new Point(414, 38);
            btnHuy.Size = new Size(118, 32);
            btnHuy.BackColor = UiTheme.The;
            btnHuy.FlatAppearance.BorderColor = UiTheme.Vien;
            btnHuy.ForeColor = UiTheme.Chinh;
            btnHuy.Font = UiTheme.Nut;
            btnHuy.Cursor = Cursors.Hand;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.FlatAppearance.BorderSize = 1;
            btnHuy.FlatAppearance.MouseOverBackColor = UiTheme.NutNhat;
            btnHuy.FlatAppearance.MouseDownBackColor = UiTheme.NutNhatHover;
            btnHuy.Margin = new Padding(2, 2, 2, 2);
            btnHuy.Name = "btnHuy";
            btnHuy.TabIndex = 2;
            btnHuy.Text = "&Hủy hóa đơn";
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLuu.Location = new Point(278, 38);
            btnLuu.Size = new Size(118, 32);
            btnLuu.BackColor = UiTheme.Chinh;
            btnLuu.ForeColor = Color.White;
            btnLuu.Font = UiTheme.Nut;
            btnLuu.Cursor = Cursors.Hand;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatAppearance.MouseOverBackColor = UiTheme.ChinhHover;
            btnLuu.FlatAppearance.MouseDownBackColor = UiTheme.ChinhDown;
            btnLuu.Margin = new Padding(2, 2, 2, 2);
            btnLuu.Name = "btnLuu";
            btnLuu.TabIndex = 1;
            btnLuu.Text = "&Lưu hóa đơn";
            // 
            // btnThemHD
            // 
            btnThemHD.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnThemHD.Location = new Point(142, 38);
            btnThemHD.Size = new Size(118, 32);
            btnThemHD.BackColor = UiTheme.Chinh;
            btnThemHD.ForeColor = Color.White;
            btnThemHD.Font = UiTheme.Nut;
            btnThemHD.Cursor = Cursors.Hand;
            btnThemHD.FlatStyle = FlatStyle.Flat;
            btnThemHD.UseVisualStyleBackColor = false;
            btnThemHD.FlatAppearance.BorderSize = 0;
            btnThemHD.FlatAppearance.MouseOverBackColor = UiTheme.ChinhHover;
            btnThemHD.FlatAppearance.MouseDownBackColor = UiTheme.ChinhDown;
            btnThemHD.Margin = new Padding(2, 2, 2, 2);
            btnThemHD.Name = "btnThemHD";
            btnThemHD.TabIndex = 0;
            btnThemHD.Text = "&Thêm hóa đơn";
            // 
            // Form8
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 600);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Text = "Hóa đơn nhập hàng";
            ForeColor = UiTheme.Chu;
            Font = UiTheme.Than;
            BackColor = UiTheme.Nen;
            Name = "Form8";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Button btnTim;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Button button1;
        private Label label14;
        private Button btnLuu;
        private Button btnThemHD;
        private Label lblTongTien;
        private DataGridView dgvChiTiet;
        private Button btnThoat;
        private Button btnIn;
        private Button btnHuy;
        private DateTimePicker dtpNgayNhap;
        private TextBox txtSDT;
        private TextBox txtMaNCC;
        private TextBox txtMaNV;
        private ComboBox cboMaHDN;
        private TextBox txtDiaChi;
        private ComboBox cboNCC;
        private TextBox txtTenNV;
        private TextBox txtTenHang;
        private TextBox txtSoLuong;
        private ComboBox cboMaHang;
        private TextBox txtDonGiaNhap;
        private TextBox txtThanhTien;
    }
}