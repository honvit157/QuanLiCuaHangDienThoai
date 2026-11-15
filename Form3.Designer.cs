namespace QuanLyCuaHangDienThoai
{
    partial class Form3
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
            groupBox1 = new GroupBox();
            txtEmail = new TextBox();
            txtTenKH = new TextBox();
            txtDiaChi = new TextBox();
            txtSDT = new TextBox();
            txtMaKH = new TextBox();
            label3 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label9 = new Label();
            label10 = new Label();
            label8 = new Label();
            label7 = new Label();
            groupBox3 = new GroupBox();
            btnThoat = new Button();
            btnLamLai = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            groupBox4 = new GroupBox();
            dgvKhachHang = new DataGridView();
            colMaKH = new DataGridViewTextBoxColumn();
            colTenKH = new DataGridViewTextBoxColumn();
            colSDT = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colDiaChi = new DataGridViewTextBoxColumn();
            groupBox5 = new GroupBox();
            txtTim = new TextBox();
            label6 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Font = UiTheme.TieuDeMuc;
            groupBox1.BackColor = UiTheme.The;
            groupBox1.ForeColor = UiTheme.Chinh;
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtTenKH);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(txtSDT);
            groupBox1.Controls.Add(txtMaKH);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(765, 250);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin khách hàng ";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEmail.Font = UiTheme.Than;
            txtEmail.BackColor = UiTheme.The;
            txtEmail.ForeColor = UiTheme.Chu;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(487, 96);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(255, 27);
            txtEmail.TabIndex = 1;
            // 
            // txtTenKH
            // 
            txtTenKH.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTenKH.Font = UiTheme.Than;
            txtTenKH.BackColor = UiTheme.The;
            txtTenKH.ForeColor = UiTheme.Chu;
            txtTenKH.BorderStyle = BorderStyle.FixedSingle;
            txtTenKH.Location = new Point(487, 51);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.Size = new Size(255, 27);
            txtTenKH.TabIndex = 1;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDiaChi.Font = UiTheme.Than;
            txtDiaChi.BackColor = UiTheme.The;
            txtDiaChi.ForeColor = UiTheme.Chu;
            txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
            txtDiaChi.Location = new Point(126, 157);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(616, 27);
            txtDiaChi.TabIndex = 1;
            // 
            // txtSDT
            // 
            txtSDT.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtSDT.Font = UiTheme.Than;
            txtSDT.BackColor = UiTheme.The;
            txtSDT.ForeColor = UiTheme.Chu;
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.Location = new Point(126, 100);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(216, 27);
            txtSDT.TabIndex = 1;
            // 
            // txtMaKH
            // 
            txtMaKH.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtMaKH.Font = UiTheme.Than;
            txtMaKH.BackColor = UiTheme.The;
            txtMaKH.ForeColor = UiTheme.Chu;
            txtMaKH.BorderStyle = BorderStyle.FixedSingle;
            txtMaKH.Location = new Point(126, 45);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(216, 27);
            txtMaKH.TabIndex = 1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left;
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
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.Font = UiTheme.Than;
            label5.ForeColor = UiTheme.Chu;
            label5.AutoSize = true;
            label5.Location = new Point(383, 51);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 0;
            label5.Text = "Tên KH";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left;
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
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label1.Font = UiTheme.Than;
            label1.ForeColor = UiTheme.Chu;
            label1.AutoSize = true;
            label1.Location = new Point(30, 51);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã KH ";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.Font = UiTheme.TieuDeMuc;
            groupBox2.BackColor = UiTheme.The;
            groupBox2.ForeColor = UiTheme.Chinh;
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(792, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(339, 250);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Lưu ý";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label9.Font = UiTheme.Than;
            label9.ForeColor = UiTheme.ChuPhu;
            label9.AutoSize = true;
            label9.Location = new Point(23, 65);
            label9.Name = "label9";
            label9.Size = new Size(296, 80);
            label9.TabIndex = 0;
            label9.Text = "nhập SĐT trên frmHoaDonBan thì hiện tên, \r\nmã địa chỉ\r\n\r\n\r\n";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label10.Font = UiTheme.Than;
            label10.ForeColor = UiTheme.ChuPhu;
            label10.AutoSize = true;
            label10.Location = new Point(23, 215);
            label10.Name = "label10";
            label10.Size = new Size(267, 20);
            label10.TabIndex = 0;
            label10.Text = "Form này dùng để xem, sửa, xóa khách.";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label8.Font = UiTheme.Than;
            label8.ForeColor = UiTheme.ChuPhu;
            label8.AutoSize = true;
            label8.Location = new Point(23, 145);
            label8.Name = "label8";
            label8.Size = new Size(313, 40);
            label8.TabIndex = 0;
            label8.Text = "Khách chưa có trong CSDL (lần đầu đến mua) \r\nsẽ được thêm tự động khi lập hóa đơn.";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label7.Font = UiTheme.Than;
            label7.ForeColor = UiTheme.ChuPhu;
            label7.AutoSize = true;
            label7.Location = new Point(23, 45);
            label7.Name = "label7";
            label7.Size = new Size(284, 20);
            label7.TabIndex = 0;
            label7.Text = "Số ĐT là cách tra cứu chính khi bán hàng: ";
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
            groupBox3.Location = new Point(12, 272);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(765, 101);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Chức năng ";
            // 
            // btnThoat
            // 
            btnThoat.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnThoat.Location = new Point(597, 34);
            btnThoat.Size = new Size(110, 38);
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
            btnThoat.TabIndex = 0;
            btnThoat.Text = "Th&oát";
            // 
            // btnLamLai
            // 
            btnLamLai.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnLamLai.Location = new Point(462, 34);
            btnLamLai.Size = new Size(110, 38);
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
            btnLamLai.TabIndex = 0;
            btnLamLai.Text = "&Làm lại";
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Left;
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
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnSua.Location = new Point(192, 34);
            btnSua.Size = new Size(110, 38);
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
            btnSua.TabIndex = 0;
            btnSua.Text = "&Sửa";
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Left;
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
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Font = UiTheme.TieuDeMuc;
            groupBox4.BackColor = UiTheme.The;
            groupBox4.ForeColor = UiTheme.Chinh;
            groupBox4.Controls.Add(dgvKhachHang);
            groupBox4.Location = new Point(12, 384);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1119, 240);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Danh sách khách hàng";
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            dgvKhachHang.Columns.AddRange(new DataGridViewColumn[] { colMaKH, colTenKH, colSDT, colEmail, colDiaChi });
            dgvKhachHang.Location = new Point(6, 26);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersWidth = 51;
            dgvKhachHang.Size = new Size(1107, 208);
            dgvKhachHang.TabIndex = 0;
            // 
            // colMaKH
            // 
            colMaKH.HeaderText = "Mã KH";
            colMaKH.MinimumWidth = 6;
            colMaKH.Name = "colMaKH";
            colMaKH.ReadOnly = true;
            // 
            // colTenKH
            // 
            colTenKH.HeaderText = "Tên KH";
            colTenKH.MinimumWidth = 6;
            colTenKH.Name = "colTenKH";
            colTenKH.ReadOnly = true;
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
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox5.Font = UiTheme.TieuDeMuc;
            groupBox5.BackColor = UiTheme.The;
            groupBox5.ForeColor = UiTheme.Chinh;
            groupBox5.Controls.Add(txtTim);
            groupBox5.Controls.Add(label6);
            groupBox5.Location = new Point(792, 272);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(339, 101);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "Tìm nhanh";
            // 
            // txtTim
            // 
            txtTim.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtTim.Font = UiTheme.Than;
            txtTim.Location = new Point(76, 40);
            txtTim.BackColor = UiTheme.The;
            txtTim.ForeColor = UiTheme.Chu;
            txtTim.BorderStyle = BorderStyle.FixedSingle;
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(153, 27);
            txtTim.TabIndex = 1;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label6.Font = UiTheme.Than;
            label6.Location = new Point(6, 43);
            label6.ForeColor = UiTheme.Chu;
            label6.AutoSize = true;
            label6.Name = "label6";
            label6.Size = new Size(39, 20);
            label6.TabIndex = 0;
            label6.Text = "Từ khóa:";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 659);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            ForeColor = UiTheme.Chu;
            Font = UiTheme.Than;
            BackColor = UiTheme.Nen;
            Name = "Form3";
            Text = "Quản lí khách hàng ";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private TextBox txtEmail;
        private TextBox txtTenKH;
        private TextBox txtSDT;
        private TextBox txtMaKH;
        private Label label3;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private TextBox txtDiaChi;
        private Button btnSua;
        private Button btnThem;
        private Label label9;
        private Label label8;
        private Label label7;
        private Button btnLamLai;
        private Button btnXoa;
        private Button button5;
        private TextBox txtTim;
        private Label label6;
        private Button btnThoat;
        private Label label10;
        private DataGridView dgvKhachHang;
        private DataGridViewTextBoxColumn colMaKH;
        private DataGridViewTextBoxColumn colTenKH;
        private DataGridViewTextBoxColumn colSDT;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colDiaChi;
    }
}