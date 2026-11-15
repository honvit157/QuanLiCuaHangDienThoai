namespace QuanLyCuaHangDienThoai
{
    partial class Form4
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
            btnThoat = new Button();
            groupBox5 = new GroupBox();
            button1 = new Button();
            txtTim = new TextBox();
            label6 = new Label();
            label8 = new Label();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            groupBox4 = new GroupBox();
            dgvKhachHang = new DataGridView();
            colMaNCC = new DataGridViewTextBoxColumn();
            colTenNCC = new DataGridViewTextBoxColumn();
            colSDT = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colDiaChi = new DataGridViewTextBoxColumn();
            colNguoiLH = new DataGridViewTextBoxColumn();
            btnLamLai = new Button();
            label7 = new Label();
            groupBox2 = new GroupBox();
            txtEmail = new TextBox();
            txtTenNCC = new TextBox();
            txtDiaChi = new TextBox();
            txtSDT = new TextBox();
            txtMaNCC = new TextBox();
            label3 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox3 = new GroupBox();
            groupBox1 = new GroupBox();
            txtNguoiLH = new TextBox();
            label11 = new Label();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(597, 34);
            btnThoat.Size = new Size(110, 38);
            btnThoat.BackColor = UiTheme.NutNhat;
            btnThoat.ForeColor = UiTheme.Chinh;
            btnThoat.Font = UiTheme.Nut;
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatAppearance.MouseOverBackColor = UiTheme.NutNhatHover;
            btnThoat.FlatAppearance.MouseDownBackColor = UiTheme.Vien;
            btnThoat.Name = "btnThoat";
            btnThoat.TabIndex = 0;
            btnThoat.Text = "Th&oát";
            // 
            // groupBox5
            // 
            groupBox5.Font = UiTheme.TieuDeMuc;
            groupBox5.BackColor = UiTheme.The;
            groupBox5.ForeColor = UiTheme.Chinh;
            groupBox5.Controls.Add(button1);
            groupBox5.Controls.Add(txtTim);
            groupBox5.Controls.Add(label6);
            groupBox5.Location = new Point(777, 272);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(339, 101);
            groupBox5.TabIndex = 9;
            groupBox5.TabStop = false;
            groupBox5.Text = "Tìm nhanh";
            // 
            // button1
            // 
            button1.Location = new Point(224, 38);
            button1.Size = new Size(96, 28);
            button1.BackColor = UiTheme.Nhan;
            button1.ForeColor = Color.White;
            button1.Font = UiTheme.Nut;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.UseVisualStyleBackColor = false;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = UiTheme.NhanHover;
            button1.FlatAppearance.MouseDownBackColor = UiTheme.NhanDown;
            button1.Name = "button1";
            button1.TabIndex = 2;
            button1.Text = "&Tìm";
            // 
            // txtTim
            // 
            txtTim.Font = UiTheme.Than;
            txtTim.Location = new Point(76, 40);
            txtTim.BackColor = UiTheme.The;
            txtTim.ForeColor = UiTheme.Chu;
            txtTim.BorderStyle = BorderStyle.FixedSingle;
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(140, 27);
            txtTim.TabIndex = 1;
            // 
            // label6
            // 
            label6.Font = UiTheme.Than;
            label6.Location = new Point(6, 43);
            label6.ForeColor = UiTheme.Chu;
            label6.AutoSize = true;
            label6.Name = "label6";
            label6.Size = new Size(39, 20);
            label6.TabIndex = 0;
            label6.Text = "SĐT:";
            // 
            // label8
            // 
            label8.Font = UiTheme.Than;
            label8.ForeColor = UiTheme.ChuPhu;
            label8.AutoSize = true;
            label8.Location = new Point(18, 125);
            label8.Name = "label8";
            label8.Size = new Size(304, 60);
            label8.TabIndex = 0;
            label8.Text = "Không cho xóa nhà cung cấp đã có hóa đơn \r\nnhập, hãy bắt lỗi khóa ngoại và báo bằng \r\nMessageBox.";
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(327, 34);
            btnXoa.Size = new Size(110, 38);
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
            btnXoa.TabIndex = 0;
            btnXoa.Text = "&Xóa";
            // 
            // btnSua
            // 
            btnSua.Location = new Point(192, 34);
            btnSua.Size = new Size(110, 38);
            btnSua.BackColor = UiTheme.Nhan;
            btnSua.ForeColor = Color.White;
            btnSua.Font = UiTheme.Nut;
            btnSua.Cursor = Cursors.Hand;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.UseVisualStyleBackColor = false;
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatAppearance.MouseOverBackColor = UiTheme.NhanHover;
            btnSua.FlatAppearance.MouseDownBackColor = UiTheme.NhanDown;
            btnSua.Name = "btnSua";
            btnSua.TabIndex = 0;
            btnSua.Text = "&Sửa";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(57, 34);
            btnThem.Size = new Size(110, 38);
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
            // groupBox4
            // 
            groupBox4.Font = UiTheme.TieuDeMuc;
            groupBox4.BackColor = UiTheme.The;
            groupBox4.ForeColor = UiTheme.Chinh;
            groupBox4.Controls.Add(dgvKhachHang);
            groupBox4.Location = new Point(6, 384);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1112, 240);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "Danh sách nhà cung cấp";
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.Font = UiTheme.Luoi;
            dgvKhachHang.BorderStyle = BorderStyle.None;
            dgvKhachHang.AlternatingRowsDefaultCellStyle.BackColor = UiTheme.DongXen;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.BackgroundColor = UiTheme.The;
            dgvKhachHang.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvKhachHang.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvKhachHang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvKhachHang.ColumnHeadersDefaultCellStyle.BackColor = UiTheme.Chinh;
            dgvKhachHang.ColumnHeadersDefaultCellStyle.Font = UiTheme.LuoiTieuDe;
            dgvKhachHang.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKhachHang.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            dgvKhachHang.ColumnHeadersDefaultCellStyle.SelectionBackColor = UiTheme.Chinh;
            dgvKhachHang.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvKhachHang.DefaultCellStyle.BackColor = UiTheme.The;
            dgvKhachHang.DefaultCellStyle.ForeColor = UiTheme.Chu;
            dgvKhachHang.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            dgvKhachHang.DefaultCellStyle.SelectionBackColor = UiTheme.ChonDong;
            dgvKhachHang.DefaultCellStyle.SelectionForeColor = UiTheme.Chinh;
            dgvKhachHang.GridColor = UiTheme.Vien;
            dgvKhachHang.RowHeadersVisible = false;
            dgvKhachHang.RowTemplate.Height = 30;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Columns.AddRange(new DataGridViewColumn[] { colMaNCC, colTenNCC, colSDT, colEmail, colDiaChi, colNguoiLH });
            dgvKhachHang.Location = new Point(6, 26);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersWidth = 51;
            dgvKhachHang.Size = new Size(1100, 208);
            dgvKhachHang.TabIndex = 0;
            // 
            // colMaNCC
            // 
            colMaNCC.HeaderText = "Mã NCC";
            colMaNCC.MinimumWidth = 6;
            colMaNCC.Name = "colMaNCC";
            colMaNCC.ReadOnly = true;
            // 
            // colTenNCC
            // 
            colTenNCC.HeaderText = "Tên NCC";
            colTenNCC.MinimumWidth = 6;
            colTenNCC.Name = "colTenNCC";
            colTenNCC.ReadOnly = true;
            // 
            // colSDT
            // 
            colSDT.HeaderText = "Số ĐT";
            colSDT.MinimumWidth = 6;
            colSDT.Name = "colSDT";
            colSDT.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colDiaChi
            // 
            colDiaChi.HeaderText = "Địa chỉ";
            colDiaChi.MinimumWidth = 6;
            colDiaChi.Name = "colDiaChi";
            colDiaChi.ReadOnly = true;
            // 
            // colNguoiLH
            // 
            colNguoiLH.HeaderText = "Người liên hệ";
            colNguoiLH.MinimumWidth = 6;
            colNguoiLH.Name = "colNguoiLH";
            colNguoiLH.ReadOnly = true;
            // 
            // btnLamLai
            // 
            btnLamLai.Location = new Point(462, 34);
            btnLamLai.Size = new Size(110, 38);
            btnLamLai.BackColor = UiTheme.NutNhat;
            btnLamLai.ForeColor = UiTheme.Chinh;
            btnLamLai.Font = UiTheme.Nut;
            btnLamLai.Cursor = Cursors.Hand;
            btnLamLai.FlatStyle = FlatStyle.Flat;
            btnLamLai.UseVisualStyleBackColor = false;
            btnLamLai.FlatAppearance.BorderSize = 0;
            btnLamLai.FlatAppearance.MouseOverBackColor = UiTheme.NutNhatHover;
            btnLamLai.FlatAppearance.MouseDownBackColor = UiTheme.Vien;
            btnLamLai.Name = "btnLamLai";
            btnLamLai.TabIndex = 0;
            btnLamLai.Text = "&Làm lại";
            // 
            // label7
            // 
            label7.Font = UiTheme.Than;
            label7.ForeColor = UiTheme.ChuPhu;
            label7.AutoSize = true;
            label7.Location = new Point(18, 48);
            label7.Name = "label7";
            label7.Size = new Size(324, 40);
            label7.TabIndex = 0;
            label7.Text = "Nhà cung cấp được chọn bằng ComboBox trên \r\nfrmHoaDonNhap.\r\n";
            // 
            // groupBox2
            // 
            groupBox2.Font = UiTheme.TieuDeMuc;
            groupBox2.BackColor = UiTheme.The;
            groupBox2.ForeColor = UiTheme.Chinh;
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(777, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(339, 250);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Lưu ý";
            // 
            // txtEmail
            // 
            txtEmail.Font = UiTheme.Than;
            txtEmail.BackColor = UiTheme.The;
            txtEmail.ForeColor = UiTheme.Chu;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(487, 96);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(255, 27);
            txtEmail.TabIndex = 1;
            // 
            // txtTenNCC
            // 
            txtTenNCC.Font = UiTheme.Than;
            txtTenNCC.BackColor = UiTheme.The;
            txtTenNCC.ForeColor = UiTheme.Chu;
            txtTenNCC.BorderStyle = BorderStyle.FixedSingle;
            txtTenNCC.Location = new Point(487, 51);
            txtTenNCC.Name = "txtTenNCC";
            txtTenNCC.Size = new Size(255, 27);
            txtTenNCC.TabIndex = 1;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = UiTheme.Than;
            txtDiaChi.BackColor = UiTheme.The;
            txtDiaChi.ForeColor = UiTheme.Chu;
            txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
            txtDiaChi.Location = new Point(135, 158);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(616, 27);
            txtDiaChi.TabIndex = 1;
            // 
            // txtSDT
            // 
            txtSDT.Font = UiTheme.Than;
            txtSDT.BackColor = UiTheme.The;
            txtSDT.ForeColor = UiTheme.Chu;
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.Location = new Point(135, 100);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(216, 27);
            txtSDT.TabIndex = 1;
            // 
            // txtMaNCC
            // 
            txtMaNCC.Font = UiTheme.Than;
            txtMaNCC.BackColor = UiTheme.The;
            txtMaNCC.ForeColor = UiTheme.Chu;
            txtMaNCC.BorderStyle = BorderStyle.FixedSingle;
            txtMaNCC.Location = new Point(135, 48);
            txtMaNCC.Name = "txtMaNCC";
            txtMaNCC.Size = new Size(216, 27);
            txtMaNCC.TabIndex = 1;
            // 
            // label3
            // 
            label3.Font = UiTheme.Than;
            label3.ForeColor = UiTheme.Chu;
            label3.AutoSize = true;
            label3.Location = new Point(30, 164);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 0;
            label3.Text = "Địa chỉ";
            // 
            // label5
            // 
            label5.Font = UiTheme.Than;
            label5.ForeColor = UiTheme.Chu;
            label5.AutoSize = true;
            label5.Location = new Point(383, 51);
            label5.Name = "label5";
            label5.Size = new Size(65, 20);
            label5.TabIndex = 0;
            label5.Text = "Tên NCC";
            // 
            // label4
            // 
            label4.Font = UiTheme.Than;
            label4.ForeColor = UiTheme.Chu;
            label4.AutoSize = true;
            label4.Location = new Point(383, 103);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 0;
            label4.Text = "Email";
            // 
            // label2
            // 
            label2.Font = UiTheme.Than;
            label2.ForeColor = UiTheme.Chu;
            label2.AutoSize = true;
            label2.Location = new Point(30, 107);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 0;
            label2.Text = "Số ĐT";
            // 
            // label1
            // 
            label1.Font = UiTheme.Than;
            label1.ForeColor = UiTheme.Chu;
            label1.AutoSize = true;
            label1.Location = new Point(30, 51);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã NCC";
            // 
            // groupBox3
            // 
            groupBox3.Font = UiTheme.TieuDeMuc;
            groupBox3.Location = new Point(6, 272);
            groupBox3.BackColor = UiTheme.The;
            groupBox3.ForeColor = UiTheme.Chinh;
            groupBox3.Controls.Add(btnThoat);
            groupBox3.Controls.Add(btnLamLai);
            groupBox3.Controls.Add(btnXoa);
            groupBox3.Controls.Add(btnSua);
            groupBox3.Controls.Add(btnThem);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(765, 101);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Chức năng ";
            // 
            // groupBox1
            // 
            groupBox1.Font = UiTheme.TieuDeMuc;
            groupBox1.BackColor = UiTheme.The;
            groupBox1.ForeColor = UiTheme.Chinh;
            groupBox1.Controls.Add(txtNguoiLH);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtTenNCC);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(txtSDT);
            groupBox1.Controls.Add(txtMaNCC);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(6, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(765, 250);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin nhà cung cấp";
            // 
            // txtNguoiLH
            // 
            txtNguoiLH.Font = UiTheme.Than;
            txtNguoiLH.BackColor = UiTheme.The;
            txtNguoiLH.ForeColor = UiTheme.Chu;
            txtNguoiLH.BorderStyle = BorderStyle.FixedSingle;
            txtNguoiLH.Location = new Point(135, 208);
            txtNguoiLH.Name = "txtNguoiLH";
            txtNguoiLH.Size = new Size(216, 27);
            txtNguoiLH.TabIndex = 3;
            // 
            // label11
            // 
            label11.Font = UiTheme.Than;
            label11.ForeColor = UiTheme.Chu;
            label11.AutoSize = true;
            label11.Location = new Point(30, 215);
            label11.Name = "label11";
            label11.Size = new Size(103, 20);
            label11.TabIndex = 2;
            label11.Text = "Người liên hệ ";
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 657);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            ForeColor = UiTheme.Chu;
            Font = UiTheme.Than;
            BackColor = UiTheme.Nen;
            Name = "Form4";
            Text = "Quản lí nhà cung cấp";
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnThoat;
        private GroupBox groupBox5;
        private TextBox txtTim;
        private Label label6;
        private Label label8;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private GroupBox groupBox4;
        private DataGridView dgvKhachHang;
        private Button btnLamLai;
        private Label label7;
        private GroupBox groupBox2;
        private TextBox txtEmail;
        private TextBox txtTenNCC;
        private TextBox txtDiaChi;
        private TextBox txtSDT;
        private TextBox txtMaNCC;
        private Label label3;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private GroupBox groupBox3;
        private GroupBox groupBox1;
        private TextBox txtNguoiLH;
        private Label label11;
        private Button button1;
        private DataGridViewTextBoxColumn colMaNCC;
        private DataGridViewTextBoxColumn colTenNCC;
        private DataGridViewTextBoxColumn colSDT;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colDiaChi;
        private DataGridViewTextBoxColumn colNguoiLH;
    }
}