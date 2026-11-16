using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4.GUI
{
    partial class FormDangKy
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
            panelHeader = new Panel();
            label1 = new Label();
            panelContent = new Panel();
            groupBox1 = new GroupBox();
            labelThongTin = new Label();
            labelHoTen = new Label();
            txtHoTen = new TextBox();
            labelSDT = new Label();
            txtSDT = new TextBox();
            labelTenDN = new Label();
            txtTenDN = new TextBox();
            labelMatKhau = new Label();
            txtMatKhau = new TextBox();
            labelNhapLaiMK = new Label();
            txtNhapLaiMK = new TextBox();
            labelEmail = new Label();
            txtEmail = new TextBox();
            labelVaiTro = new Label();
            cboVaiTro = new ComboBox();
            btnDangKy = new Button();
            btnHuy = new Button();

            panelHeader.SuspendLayout();

            panelContent.SuspendLayout();

            groupBox1.SuspendLayout();

            SuspendLayout();
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 246, 252);
            ClientSize = new Size(720, 777);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Name = "FormDangKy";
            Text = "PHONE STORE - Đăng ký tài khoản";
            Font = new Font("Segoe UI", 10F);

            panelHeader.BackColor = Color.FromArgb(11, 46, 77);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 85;

            label1.AutoSize = false;
            label1.Text = "HỆ THỐNG QUẢN LÝ CỬA HÀNG | PHONE STORE";
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleCenter;

            panelHeader.Controls.Add(label1);

            panelContent.Dock = DockStyle.Fill;
            panelContent.BackColor = Color.FromArgb(241, 246, 252);

            groupBox1.BackColor = Color.White;
            groupBox1.ForeColor = Color.FromArgb(11, 46, 77);
            groupBox1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBox1.Text = "ĐĂNG KÝ TÀI KHOẢN";
            groupBox1.Location = new Point(70, 20);
            groupBox1.Size = new Size(580, 642);
            groupBox1.TabStop = false;
            groupBox1.Padding = new Padding(20);

            labelThongTin.AutoSize = false;
            labelThongTin.Location = new Point(35, 45);
            labelThongTin.Size = new Size(500, 30);
            labelThongTin.Text = "Điền thông tin bên dưới và chọn vai trò: Khách hàng hoặc Nhân viên";
            labelThongTin.Font = new Font("Segoe UI", 10F);
            labelThongTin.ForeColor = Color.FromArgb(110, 125, 145);

            labelHoTen.AutoSize = true;
            labelHoTen.Location = new Point(38, 85);
            labelHoTen.Text = "HỌ VÀ TÊN";
            labelHoTen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelHoTen.ForeColor = Color.FromArgb(45, 65, 85);

            txtHoTen.Location = new Point(40, 110);
            txtHoTen.Size = new Size(490, 32);
            txtHoTen.Font = new Font("Segoe UI", 12F);
            txtHoTen.BorderStyle = BorderStyle.FixedSingle;
            txtHoTen.BackColor = Color.FromArgb(248, 250, 253);
            txtHoTen.Name = "txtHoTen";

            labelSDT.AutoSize = true;
            labelSDT.Location = new Point(38, 152);
            labelSDT.Text = "SỐ ĐIỆN THOẠI";
            labelSDT.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelSDT.ForeColor = Color.FromArgb(45, 65, 85);

            txtSDT.Location = new Point(40, 177);
            txtSDT.Size = new Size(490, 32);
            txtSDT.Font = new Font("Segoe UI", 12F);
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.BackColor = Color.FromArgb(248, 250, 253);
            txtSDT.Name = "txtSDT";

            labelTenDN.AutoSize = true;
            labelTenDN.Location = new Point(38, 219);
            labelTenDN.Text = "TÊN ĐĂNG NHẬP";
            labelTenDN.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTenDN.ForeColor = Color.FromArgb(45, 65, 85);

            txtTenDN.Location = new Point(40, 244);
            txtTenDN.Size = new Size(490, 32);
            txtTenDN.Font = new Font("Segoe UI", 12F);
            txtTenDN.BorderStyle = BorderStyle.FixedSingle;
            txtTenDN.BackColor = Color.FromArgb(248, 250, 253);
            txtTenDN.Name = "txtTenDN";

            labelMatKhau.AutoSize = true;
            labelMatKhau.Location = new Point(38, 286);
            labelMatKhau.Text = "MẬT KHẨU";
            labelMatKhau.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelMatKhau.ForeColor = Color.FromArgb(45, 65, 85);

            txtMatKhau.Location = new Point(40, 311);
            txtMatKhau.Size = new Size(490, 32);
            txtMatKhau.Font = new Font("Segoe UI", 12F);
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhau.BackColor = Color.FromArgb(248, 250, 253);
            txtMatKhau.UseSystemPasswordChar = true;
            txtMatKhau.Name = "txtMatKhau";

            labelNhapLaiMK.AutoSize = true;
            labelNhapLaiMK.Location = new Point(38, 353);
            labelNhapLaiMK.Text = "NHẬP LẠI MẬT KHẨU";
            labelNhapLaiMK.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelNhapLaiMK.ForeColor = Color.FromArgb(45, 65, 85);

            txtNhapLaiMK.Location = new Point(40, 378);
            txtNhapLaiMK.Size = new Size(490, 32);
            txtNhapLaiMK.Font = new Font("Segoe UI", 12F);
            txtNhapLaiMK.BorderStyle = BorderStyle.FixedSingle;
            txtNhapLaiMK.BackColor = Color.FromArgb(248, 250, 253);
            txtNhapLaiMK.UseSystemPasswordChar = true;
            txtNhapLaiMK.Name = "txtNhapLaiMK";

            labelVaiTro.AutoSize = true;
            labelVaiTro.Location = new Point(38, 491);
            labelVaiTro.Text = "VAI TRÒ";
            labelVaiTro.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelVaiTro.ForeColor = Color.FromArgb(45, 65, 85);

            cboVaiTro.Location = new Point(40, 516);
            cboVaiTro.Size = new Size(490, 34);
            cboVaiTro.Font = new Font("Segoe UI", 12F);
            cboVaiTro.BackColor = Color.FromArgb(248, 250, 253);
            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVaiTro.Items.AddRange(new object[] { "Khách hàng", "Nhân viên" });
            cboVaiTro.Name = "cboVaiTro";

            btnDangKy.Location = new Point(40, 572);
            btnDangKy.Size = new Size(240, 46);
            btnDangKy.Text = "ĐĂNG KÝ";
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDangKy.ForeColor = Color.White;
            btnDangKy.BackColor = Color.FromArgb(8, 120, 209);
            btnDangKy.FlatStyle = FlatStyle.Flat;
            btnDangKy.FlatAppearance.BorderSize = 0;
            btnDangKy.Cursor = Cursors.Hand;
            btnDangKy.UseVisualStyleBackColor = false;

            btnHuy.Location = new Point(300, 572);
            btnHuy.Size = new Size(230, 46);
            btnHuy.Text = "HỦY / QUAY LẠI";
            btnHuy.Name = "btnHuy";
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuy.ForeColor = Color.FromArgb(60, 75, 90);
            btnHuy.BackColor = Color.FromArgb(231, 237, 245);
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.Cursor = Cursors.Hand;
            btnHuy.UseVisualStyleBackColor = false;

            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(38, 424);
            labelEmail.Text = "EMAIL (không bắt buộc)";
            labelEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelEmail.ForeColor = Color.FromArgb(45, 65, 85);

            txtEmail.Location = new Point(40, 449);
            txtEmail.Size = new Size(490, 32);
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.BackColor = Color.FromArgb(248, 250, 253);
            txtEmail.Name = "txtEmail";

            groupBox1.Controls.Add(labelEmail);
            groupBox1.Controls.Add(txtEmail);

            groupBox1.Controls.Add(labelThongTin);
            groupBox1.Controls.Add(labelHoTen);
            groupBox1.Controls.Add(txtHoTen);
            groupBox1.Controls.Add(labelSDT);
            groupBox1.Controls.Add(txtSDT);
            groupBox1.Controls.Add(labelTenDN);
            groupBox1.Controls.Add(txtTenDN);
            groupBox1.Controls.Add(labelMatKhau);
            groupBox1.Controls.Add(txtMatKhau);
            groupBox1.Controls.Add(labelNhapLaiMK);
            groupBox1.Controls.Add(txtNhapLaiMK);
            groupBox1.Controls.Add(labelVaiTro);
            groupBox1.Controls.Add(cboVaiTro);
            groupBox1.Controls.Add(btnDangKy);
            groupBox1.Controls.Add(btnHuy);

            panelContent.Controls.Add(groupBox1);

            Controls.Add(panelContent);
            Controls.Add(panelHeader);

            panelHeader.ResumeLayout(false);

            panelContent.ResumeLayout(false);

            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();

            ResumeLayout(false);
        }

        // KHAI BÁO CONTROL

        private Panel panelHeader;
        private Label label1;
        private Panel panelContent;
        private GroupBox groupBox1;
        private Label labelThongTin;
        private Label labelHoTen;
        private TextBox txtHoTen;
        private Label labelSDT;
        private TextBox txtSDT;
        private Label labelTenDN;
        private TextBox txtTenDN;
        private Label labelMatKhau;
        private TextBox txtMatKhau;
        private Label labelNhapLaiMK;
        private TextBox txtNhapLaiMK;
        private Label labelEmail;
        private TextBox txtEmail;
        private Label labelVaiTro;
        private ComboBox cboVaiTro;
        private Button btnDangKy;
        private Button btnHuy;
    }
}
