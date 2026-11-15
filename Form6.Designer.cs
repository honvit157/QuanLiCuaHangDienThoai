namespace QuanLyCuaHangDienThoai
{
    partial class Form6
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
            groupBox2 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            txtTenHang = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtGiaTu = new TextBox();
            label5 = new Label();
            txtGiaDen = new TextBox();
            label6 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label7 = new Label();
            cboMau = new ComboBox();
            cboHang = new ComboBox();
            cboLoai = new ComboBox();
            dgvKetQua = new DataGridView();
            ColMaHang = new DataGridViewTextBoxColumn();
            colTenHang = new DataGridViewTextBoxColumn();
            colHang = new DataGridViewTextBoxColumn();
            colLoai = new DataGridViewTextBoxColumn();
            colMau = new DataGridViewTextBoxColumn();
            colDungLuong = new DataGridViewTextBoxColumn();
            colGiaBan = new DataGridViewTextBoxColumn();
            colSL = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Font = UiTheme.TieuDeMuc;
            groupBox1.BackColor = UiTheme.The;
            groupBox1.ForeColor = UiTheme.Chinh;
            groupBox1.Controls.Add(cboLoai);
            groupBox1.Controls.Add(cboHang);
            groupBox1.Controls.Add(cboMau);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(txtGiaDen);
            groupBox1.Controls.Add(txtGiaTu);
            groupBox1.Controls.Add(txtTenHang);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1093, 196);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tiêu chí tìm kiếm ";
            // 
            // groupBox2
            // 
            groupBox2.Font = UiTheme.TieuDeMuc;
            groupBox2.BackColor = UiTheme.The;
            groupBox2.ForeColor = UiTheme.Chinh;
            groupBox2.Controls.Add(dgvKetQua);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new Point(12, 218);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1093, 496);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Kết quả tìm kiếm";
            // 
            // label1
            // 
            label1.Font = UiTheme.Than;
            label1.ForeColor = UiTheme.Chu;
            label1.AutoSize = true;
            label1.Location = new Point(21, 37);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên hàng ";
            // 
            // label2
            // 
            label2.Font = UiTheme.Than;
            label2.ForeColor = UiTheme.Chu;
            label2.AutoSize = true;
            label2.Location = new Point(21, 90);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 0;
            label2.Text = "Màu sắc";
            // 
            // txtTenHang
            // 
            txtTenHang.Font = UiTheme.Than;
            txtTenHang.BackColor = UiTheme.The;
            txtTenHang.ForeColor = UiTheme.Chu;
            txtTenHang.BorderStyle = BorderStyle.FixedSingle;
            txtTenHang.Location = new Point(110, 37);
            txtTenHang.Name = "txtTenHang";
            txtTenHang.Size = new Size(219, 27);
            txtTenHang.TabIndex = 1;
            // 
            // label3
            // 
            label3.Font = UiTheme.Than;
            label3.ForeColor = UiTheme.Chu;
            label3.AutoSize = true;
            label3.Location = new Point(368, 44);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 0;
            label3.Text = "Hãng SX";
            // 
            // label4
            // 
            label4.Font = UiTheme.Than;
            label4.ForeColor = UiTheme.Chu;
            label4.AutoSize = true;
            label4.Location = new Point(729, 97);
            label4.Name = "label4";
            label4.Size = new Size(60, 20);
            label4.TabIndex = 0;
            label4.Text = "Giá đến";
            // 
            // txtGiaTu
            // 
            txtGiaTu.Font = UiTheme.Than;
            txtGiaTu.BackColor = UiTheme.The;
            txtGiaTu.ForeColor = UiTheme.Chu;
            txtGiaTu.BorderStyle = BorderStyle.FixedSingle;
            txtGiaTu.Location = new Point(448, 86);
            txtGiaTu.Name = "txtGiaTu";
            txtGiaTu.Size = new Size(232, 27);
            txtGiaTu.TabIndex = 1;
            // 
            // label5
            // 
            label5.Font = UiTheme.Than;
            label5.ForeColor = UiTheme.Chu;
            label5.AutoSize = true;
            label5.Location = new Point(729, 43);
            label5.Name = "label5";
            label5.Size = new Size(37, 20);
            label5.TabIndex = 0;
            label5.Text = "Loại";
            // 
            // txtGiaDen
            // 
            txtGiaDen.Font = UiTheme.Than;
            txtGiaDen.BackColor = UiTheme.The;
            txtGiaDen.ForeColor = UiTheme.Chu;
            txtGiaDen.BorderStyle = BorderStyle.FixedSingle;
            txtGiaDen.Location = new Point(832, 90);
            txtGiaDen.Name = "txtGiaDen";
            txtGiaDen.Size = new Size(227, 27);
            txtGiaDen.TabIndex = 1;
            // 
            // label6
            // 
            label6.ForeColor = UiTheme.Nhan;
            label6.Font = UiTheme.Nhan;
            label6.AutoSize = true;
            label6.Location = new Point(21, 34);
            label6.Name = "label6";
            label6.Size = new Size(69, 20);
            label6.TabIndex = 0;
            label6.Text = "Tìm thấy:";
            // 
            // button1
            // 
            button1.Location = new Point(270, 140);
            button1.Size = new Size(120, 34);
            button1.BackColor = UiTheme.Chinh;
            button1.ForeColor = Color.White;
            button1.Font = UiTheme.Nut;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.UseVisualStyleBackColor = false;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = UiTheme.ChinhHover;
            button1.FlatAppearance.MouseDownBackColor = UiTheme.ChinhDown;
            button1.Name = "button1";
            button1.TabIndex = 2;
            button1.Text = "button1";
            // 
            // button2
            // 
            button2.Location = new Point(414, 140);
            button2.Size = new Size(120, 34);
            button2.BackColor = UiTheme.NutNhat;
            button2.ForeColor = UiTheme.Chinh;
            button2.Font = UiTheme.Nut;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Flat;
            button2.UseVisualStyleBackColor = false;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = UiTheme.NutNhatHover;
            button2.FlatAppearance.MouseDownBackColor = UiTheme.Vien;
            button2.Name = "button2";
            button2.TabIndex = 2;
            button2.Text = "button1";
            // 
            // button3
            // 
            button3.Location = new Point(558, 140);
            button3.Size = new Size(120, 34);
            button3.BackColor = UiTheme.ThanhCong;
            button3.ForeColor = Color.White;
            button3.Font = UiTheme.Nut;
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Flat;
            button3.UseVisualStyleBackColor = false;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = UiTheme.ThanhCongHover;
            button3.FlatAppearance.MouseDownBackColor = UiTheme.ThanhCongDown;
            button3.Name = "button3";
            button3.TabIndex = 2;
            button3.Text = "button1";
            // 
            // button4
            // 
            button4.Location = new Point(702, 140);
            button4.Size = new Size(120, 34);
            button4.BackColor = UiTheme.NutNhat;
            button4.ForeColor = UiTheme.Chinh;
            button4.Font = UiTheme.Nut;
            button4.Cursor = Cursors.Hand;
            button4.FlatStyle = FlatStyle.Flat;
            button4.UseVisualStyleBackColor = false;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseOverBackColor = UiTheme.NutNhatHover;
            button4.FlatAppearance.MouseDownBackColor = UiTheme.Vien;
            button4.Name = "button4";
            button4.TabIndex = 2;
            button4.Text = "button1";
            // 
            // label7
            // 
            label7.Font = UiTheme.Than;
            label7.ForeColor = UiTheme.Chu;
            label7.AutoSize = true;
            label7.Location = new Point(368, 93);
            label7.Name = "label7";
            label7.Size = new Size(49, 20);
            label7.TabIndex = 0;
            label7.Text = "Giá từ";
            // 
            // cboMau
            // 
            cboMau.Font = UiTheme.Than;
            cboMau.BackColor = UiTheme.The;
            cboMau.ForeColor = UiTheme.Chu;
            cboMau.FormattingEnabled = true;
            cboMau.Location = new Point(110, 86);
            cboMau.Name = "cboMau";
            cboMau.Size = new Size(219, 28);
            cboMau.TabIndex = 3;
            // 
            // cboHang
            // 
            cboHang.Font = UiTheme.Than;
            cboHang.BackColor = UiTheme.The;
            cboHang.ForeColor = UiTheme.Chu;
            cboHang.FormattingEnabled = true;
            cboHang.Location = new Point(448, 40);
            cboHang.Name = "cboHang";
            cboHang.Size = new Size(232, 28);
            cboHang.TabIndex = 3;
            // 
            // cboLoai
            // 
            cboLoai.Font = UiTheme.Than;
            cboLoai.BackColor = UiTheme.The;
            cboLoai.ForeColor = UiTheme.Chu;
            cboLoai.FormattingEnabled = true;
            cboLoai.Location = new Point(832, 44);
            cboLoai.Name = "cboLoai";
            cboLoai.Size = new Size(227, 28);
            cboLoai.TabIndex = 3;
            // 
            // dgvKetQua
            // 
            dgvKetQua.Font = UiTheme.Luoi;
            dgvKetQua.BorderStyle = BorderStyle.None;
            dgvKetQua.AlternatingRowsDefaultCellStyle.BackColor = UiTheme.DongXen;
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKetQua.BackgroundColor = UiTheme.The;
            dgvKetQua.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvKetQua.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvKetQua.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvKetQua.ColumnHeadersDefaultCellStyle.BackColor = UiTheme.Chinh;
            dgvKetQua.ColumnHeadersDefaultCellStyle.Font = UiTheme.LuoiTieuDe;
            dgvKetQua.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKetQua.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            dgvKetQua.ColumnHeadersDefaultCellStyle.SelectionBackColor = UiTheme.Chinh;
            dgvKetQua.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvKetQua.DefaultCellStyle.BackColor = UiTheme.The;
            dgvKetQua.DefaultCellStyle.ForeColor = UiTheme.Chu;
            dgvKetQua.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            dgvKetQua.DefaultCellStyle.SelectionBackColor = UiTheme.ChonDong;
            dgvKetQua.DefaultCellStyle.SelectionForeColor = UiTheme.Chinh;
            dgvKetQua.GridColor = UiTheme.Vien;
            dgvKetQua.RowHeadersVisible = false;
            dgvKetQua.RowTemplate.Height = 30;
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKetQua.Columns.AddRange(new DataGridViewColumn[] { ColMaHang, colTenHang, colHang, colLoai, colMau, colDungLuong, colGiaBan, colSL });
            dgvKetQua.Location = new Point(8, 67);
            dgvKetQua.Name = "dgvKetQua";
            dgvKetQua.RowHeadersWidth = 51;
            dgvKetQua.Size = new Size(1079, 427);
            dgvKetQua.TabIndex = 1;
            // 
            // ColMaHang
            // 
            ColMaHang.HeaderText = "Mã hàng";
            ColMaHang.MinimumWidth = 6;
            ColMaHang.Name = "ColMaHang";
            // 
            // colTenHang
            // 
            colTenHang.HeaderText = "Tên hàng ";
            colTenHang.MinimumWidth = 6;
            colTenHang.Name = "colTenHang";
            // 
            // colHang
            // 
            colHang.HeaderText = "Hãng";
            colHang.MinimumWidth = 6;
            colHang.Name = "colHang";
            // 
            // colLoai
            // 
            colLoai.HeaderText = "Loại";
            colLoai.MinimumWidth = 6;
            colLoai.Name = "colLoai";
            // 
            // colMau
            // 
            colMau.HeaderText = "Màu";
            colMau.MinimumWidth = 6;
            colMau.Name = "colMau";
            // 
            // colDungLuong
            // 
            colDungLuong.HeaderText = "Dung lượng";
            colDungLuong.MinimumWidth = 6;
            colDungLuong.Name = "colDungLuong";
            // 
            // colGiaBan
            // 
            colGiaBan.HeaderText = "Giá bán";
            colGiaBan.MinimumWidth = 6;
            colGiaBan.Name = "colGiaBan";
            // 
            // colSL
            // 
            colSL.HeaderText = "SL";
            colSL.MinimumWidth = 6;
            colSL.Name = "colSL";
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1117, 722);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Text = "Tìm kiếm điện thoại";
            ForeColor = UiTheme.Chu;
            Font = UiTheme.Than;
            BackColor = UiTheme.Nen;
            Name = "Form6";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtTenHang;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label label1;
        private GroupBox groupBox2;
        private TextBox txtGiaDen;
        private TextBox txtGiaTu;
        private Label label5;
        private ComboBox cboLoai;
        private ComboBox cboHang;
        private ComboBox cboMau;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label7;
        private Label label6;
        private DataGridView dgvKetQua;
        private DataGridViewTextBoxColumn ColMaHang;
        private DataGridViewTextBoxColumn colTenHang;
        private DataGridViewTextBoxColumn colHang;
        private DataGridViewTextBoxColumn colLoai;
        private DataGridViewTextBoxColumn colMau;
        private DataGridViewTextBoxColumn colDungLuong;
        private DataGridViewTextBoxColumn colGiaBan;
        private DataGridViewTextBoxColumn colSL;
    }
}