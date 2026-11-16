using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4.GUI
{
    partial class Form6
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
            cboLoai = new ComboBox();
            cboHang = new ComboBox();
            cboMau = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            txtGiaDen = new TextBox();
            txtGiaTu = new TextBox();
            txtTenHang = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label6 = new Label();
            dgvKetQua = new DataGridView();
            ColMaHang = new DataGridViewTextBoxColumn();
            colTenHang = new DataGridViewTextBoxColumn();
            colHang = new DataGridViewTextBoxColumn();
            colLoai = new DataGridViewTextBoxColumn();
            colMau = new DataGridViewTextBoxColumn();
            colDungLuong = new DataGridViewTextBoxColumn();
            colGiaBan = new DataGridViewTextBoxColumn();
            colSL = new DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(dgvKetQua)).BeginInit();

            groupBox1.SuspendLayout();

            groupBox2.SuspendLayout();

            SuspendLayout();
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 252);
            Font = new Font("Segoe UI", 10F);
            ClientSize = new Size(1400, 850);
            MinimumSize = new Size(1000, 700);
            Name = "Form6";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TÌM KIẾM ĐIỆN THOẠI";
            WindowState = FormWindowState.Maximized;

            groupBox1.Text = "TIÊU CHÍ TÌM KIẾM";
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(35, 48, 68);
            groupBox1.BackColor = Color.White;
            groupBox1.Padding = new Padding(15);
            groupBox1.Location = new Point(18, 15);
            groupBox1.Size = new Size(1364, 270);
            groupBox1.Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right);

            label1.Text = "Tên hàng";
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(35, 48, 68);
            label1.AutoSize = true;

            label3.Text = "Hãng sản xuất";
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(35, 48, 68);
            label3.AutoSize = true;

            label5.Text = "Loại hàng";
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(35, 48, 68);
            label5.AutoSize = true;

            label2.Text = "Màu sắc";
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(35, 48, 68);
            label2.AutoSize = true;

            label7.Text = "Giá từ";
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(35, 48, 68);
            label7.AutoSize = true;

            label4.Text = "Giá đến";
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(35, 48, 68);
            label4.AutoSize = true;

            txtTenHang.Font = new Font("Segoe UI", 10F);
            txtTenHang.ForeColor = Color.FromArgb(35, 48, 68);
            txtTenHang.BackColor = Color.FromArgb(250, 252, 255);
            txtTenHang.BorderStyle = BorderStyle.FixedSingle;

            txtGiaTu.Font = new Font("Segoe UI", 10F);
            txtGiaTu.ForeColor = Color.FromArgb(35, 48, 68);
            txtGiaTu.BackColor = Color.FromArgb(250, 252, 255);
            txtGiaTu.BorderStyle = BorderStyle.FixedSingle;

            txtGiaDen.Font = new Font("Segoe UI", 10F);
            txtGiaDen.ForeColor = Color.FromArgb(35, 48, 68);
            txtGiaDen.BackColor = Color.FromArgb(250, 252, 255);
            txtGiaDen.BorderStyle = BorderStyle.FixedSingle;

            cboHang.Font = new Font("Segoe UI", 10F);
            cboHang.ForeColor = Color.FromArgb(35, 48, 68);
            cboHang.BackColor = Color.White;
            cboHang.DropDownStyle = ComboBoxStyle.DropDownList;

            cboLoai.Font = new Font("Segoe UI", 10F);
            cboLoai.ForeColor = Color.FromArgb(35, 48, 68);
            cboLoai.BackColor = Color.White;
            cboLoai.DropDownStyle = ComboBoxStyle.DropDownList;

            cboMau.Font = new Font("Segoe UI", 10F);
            cboMau.ForeColor = Color.FromArgb(35, 48, 68);
            cboMau.BackColor = Color.White;
            cboMau.DropDownStyle = ComboBoxStyle.DropDownList;

            button1.Text = "⌕ Tìm kiếm";

            button2.Text = "↻ Làm mới";

            button3.Text = "✕ Xóa lọc";

            button4.Text = "← Thoát";

            button1.BackColor = Color.FromArgb(41, 98, 170);
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.Cursor = Cursors.Hand;
            button1.UseVisualStyleBackColor = false;

            button2.BackColor = Color.FromArgb(36, 155, 110);
            button2.ForeColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button2.Cursor = Cursors.Hand;
            button2.UseVisualStyleBackColor = false;

            button3.BackColor = Color.FromArgb(105, 119, 139);
            button3.ForeColor = Color.White;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button3.Cursor = Cursors.Hand;
            button3.UseVisualStyleBackColor = false;

            button4.BackColor = Color.FromArgb(70, 82, 100);
            button4.ForeColor = Color.White;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button4.Cursor = Cursors.Hand;
            button4.UseVisualStyleBackColor = false;

            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtTenHang);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cboHang);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cboLoai);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cboMau);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtGiaTu);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtGiaDen);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button4);

            groupBox2.Text = "KẾT QUẢ TÌM KIẾM";
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox2.ForeColor = Color.FromArgb(35, 48, 68);
            groupBox2.BackColor = Color.White;
            groupBox2.Padding = new Padding(12);
            groupBox2.Location = new Point(18, 300);
            groupBox2.Size = new Size(1364, 532);
            groupBox2.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right);

            label6.Text = "Tìm thấy:";
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(41, 98, 170);
            label6.AutoSize = true;
            label6.Location = new Point(18, 35);

            dgvKetQua.BackgroundColor = Color.White;
            dgvKetQua.BorderStyle = BorderStyle.None;
            dgvKetQua.GridColor = Color.FromArgb(220, 227, 237);
            dgvKetQua.EnableHeadersVisualStyles = false;
            dgvKetQua.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 75, 135);
            dgvKetQua.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKetQua.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvKetQua.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKetQua.ColumnHeadersHeight = 45;
            dgvKetQua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvKetQua.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvKetQua.DefaultCellStyle.ForeColor = Color.FromArgb(35, 48, 68);
            dgvKetQua.DefaultCellStyle.BackColor = Color.White;
            dgvKetQua.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 232, 250);
            dgvKetQua.DefaultCellStyle.SelectionForeColor = Color.FromArgb(35, 48, 68);
            dgvKetQua.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 248, 253);
            dgvKetQua.RowTemplate.Height = 38;
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKetQua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKetQua.MultiSelect = false;
            dgvKetQua.ReadOnly = true;
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.AllowUserToDeleteRows = false;
            dgvKetQua.RowHeadersVisible = false;

            ColMaHang.HeaderText = "Mã hàng";
            ColMaHang.Name = "ColMaHang";
            ColMaHang.MinimumWidth = 90;
            ColMaHang.FillWeight = 85;

            colTenHang.HeaderText = "Tên hàng";
            colTenHang.Name = "colTenHang";
            colTenHang.MinimumWidth = 130;
            colTenHang.FillWeight = 150;

            colHang.HeaderText = "Hãng sản xuất";
            colHang.Name = "colHang";
            colHang.MinimumWidth = 110;
            colHang.FillWeight = 110;

            colLoai.HeaderText = "Loại hàng";
            colLoai.Name = "colLoai";
            colLoai.MinimumWidth = 90;
            colLoai.FillWeight = 95;

            colMau.HeaderText = "Màu sắc";
            colMau.Name = "colMau";
            colMau.MinimumWidth = 85;
            colMau.FillWeight = 90;

            colDungLuong.HeaderText = "Dung lượng";
            colDungLuong.Name = "colDungLuong";
            colDungLuong.MinimumWidth = 100;
            colDungLuong.FillWeight = 95;

            colGiaBan.HeaderText = "Giá bán";
            colGiaBan.Name = "colGiaBan";
            colGiaBan.MinimumWidth = 110;
            colGiaBan.FillWeight = 110;

            colSL.HeaderText = "Số lượng";
            colSL.Name = "colSL";
            colSL.MinimumWidth = 80;
            colSL.FillWeight = 80;

            dgvKetQua.Columns.AddRange(new DataGridViewColumn[] { ColMaHang, colTenHang, colHang, colLoai, colMau, colDungLuong, colGiaBan, colSL });
            dgvKetQua.AutoGenerateColumns = false;

            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(dgvKetQua);

            Controls.Add(groupBox2);
            Controls.Add(groupBox1);

            ((System.ComponentModel.ISupportInitialize)(dgvKetQua)).EndInit();

            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();

            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();


            // ------------------------------------------
            // VỊ TRÍ Ở MÀN [Design] - lúc chạy, hàm LayoutForm6()
            // trong Form6.cs sẽ tính lại theo kích thước thật
            // ------------------------------------------

            label1.Location = new Point(20, 35);
            txtTenHang.Location = new Point(20, 61);
            txtTenHang.Size = new Size(422, 34);
            label3.Location = new Point(467, 35);
            cboHang.Location = new Point(467, 61);
            cboHang.Size = new Size(422, 34);
            label5.Location = new Point(914, 35);
            cboLoai.Location = new Point(914, 61);
            cboLoai.Size = new Size(422, 34);
            label2.Location = new Point(20, 112);
            cboMau.Location = new Point(20, 138);
            cboMau.Size = new Size(422, 34);
            label7.Location = new Point(467, 112);
            txtGiaTu.Location = new Point(467, 138);
            txtGiaTu.Size = new Size(422, 34);
            label4.Location = new Point(914, 112);
            txtGiaDen.Location = new Point(914, 138);
            txtGiaDen.Size = new Size(422, 34);
            button1.Location = new Point(20, 198);
            button1.Size = new Size(155, 48);
            button2.Location = new Point(190, 198);
            button2.Size = new Size(155, 48);
            button3.Location = new Point(360, 198);
            button3.Size = new Size(155, 48);
            button4.Location = new Point(530, 198);
            button4.Size = new Size(155, 48);
            label6.Location = new Point(18, 34);
            dgvKetQua.Location = new Point(15, 65);
            dgvKetQua.Size = new Size(1328, 428);

            ResumeLayout(false);
        }

        // KHAI BÁO CONTROL

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ComboBox cboLoai;
        private ComboBox cboHang;
        private ComboBox cboMau;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox txtGiaDen;
        private TextBox txtGiaTu;
        private TextBox txtTenHang;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
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
