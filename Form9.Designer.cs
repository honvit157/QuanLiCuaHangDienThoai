namespace QuanLyCuaHangDienThoai
{
    partial class Form9
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
            txtMatKhau = new TextBox();
            txtMaNhanVien = new TextBox();
            label3 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = false;
            label1.BackColor = UiTheme.The;
            label1.Font = UiTheme.TieuDe;
            label1.ForeColor = UiTheme.Chinh;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(640, 84);
            label1.TabIndex = 0;
            label1.Text = "CỬA HÀNG ĐIỆN THOẠI ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Font = UiTheme.TieuDeMuc;
            groupBox1.BackColor = UiTheme.The;
            groupBox1.Controls.Add(txtMatKhau);
            groupBox1.Controls.Add(txtMaNhanVien);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.ForeColor = UiTheme.Chinh;
            groupBox1.Location = new Point(60, 104);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(520, 176);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin đăng nhập ";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = UiTheme.Than;
            txtMatKhau.BackColor = UiTheme.The;
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhau.ForeColor = UiTheme.Chu;
            txtMatKhau.Location = new Point(140, 100);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(340, 27);
            txtMatKhau.TabIndex = 3;
            // 
            // txtMaNhanVien
            // 
            txtMaNhanVien.Font = UiTheme.Than;
            txtMaNhanVien.BackColor = UiTheme.The;
            txtMaNhanVien.BorderStyle = BorderStyle.FixedSingle;
            txtMaNhanVien.ForeColor = UiTheme.Chu;
            txtMaNhanVien.Location = new Point(140, 44);
            txtMaNhanVien.Name = "txtMaNhanVien";
            txtMaNhanVien.Size = new Size(340, 27);
            txtMaNhanVien.TabIndex = 2;
            // 
            // label3
            // 
            label3.Font = UiTheme.Than;
            label3.AutoSize = true;
            label3.ForeColor = UiTheme.Chu;
            label3.Location = new Point(30, 106);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 1;
            label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.Font = UiTheme.Than;
            label2.AutoSize = true;
            label2.ForeColor = UiTheme.Chu;
            label2.Location = new Point(30, 50);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã nhân viên ";
            // 
            // button1
            // 
            button1.BackColor = UiTheme.Chinh;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = UiTheme.ChinhDown;
            button1.FlatAppearance.MouseOverBackColor = UiTheme.ChinhHover;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = UiTheme.Nut;
            button1.ForeColor = Color.White;
            button1.Location = new Point(175, 312);
            button1.Name = "button1";
            button1.Size = new Size(150, 40);
            button1.TabIndex = 2;
            button1.Text = "&Đăng nhập";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = UiTheme.NutNhat;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = UiTheme.Vien;
            button2.FlatAppearance.MouseOverBackColor = UiTheme.NutNhatHover;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = UiTheme.Nut;
            button2.ForeColor = UiTheme.Chinh;
            button2.Location = new Point(345, 312);
            button2.Name = "button2";
            button2.Size = new Size(120, 40);
            button2.TabIndex = 3;
            button2.Text = "Th&oát";
            button2.UseVisualStyleBackColor = false;
            // 
            // Form9
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = UiTheme.Nen;
            ClientSize = new Size(640, 400);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Font = UiTheme.Than;
            ForeColor = UiTheme.Chu;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form9";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống ";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TextBox txtMatKhau;
        private TextBox txtMaNhanVien;
        private Label label3;
        private Label label2;
        private Button button1;
        private Button button2;
    }
}
