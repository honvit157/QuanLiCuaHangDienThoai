using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4.GUI
{
    partial class Form3
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
            groupBox5 = new GroupBox();
            txtEmail = new TextBox();
            txtTenKH = new TextBox();
            txtDiaChi = new TextBox();
            txtSDT = new TextBox();
            txtMaKH = new TextBox();
            txtTim = new TextBox();
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
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamLai = new Button();
            btnThoat = new Button();
            dgvKhachHang = new DataGridView();
            colMaKH = new DataGridViewTextBoxColumn();
            colTenKH = new DataGridViewTextBoxColumn();
            colSDT = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colDiaChi = new DataGridViewTextBoxColumn();

            SuspendLayout();
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 251);
            Font = new Font("Segoe UI", 9.5F);
            ClientSize = new Size(1100, 760);
            MinimumSize = new Size(850, 600);
            Name = "Form3";
            Text = "PHONE STORE - Quản lý khách hàng";

            root = new TableLayoutPanel();

            root.Dock = DockStyle.Fill;
            root.ColumnCount = 1;
            root.RowCount = 3;
            root.Padding = new Padding(15);
            root.BackColor = Color.FromArgb(244, 247, 251);
            root.Margin = Padding.Empty;
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 285F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            top = new TableLayoutPanel();

            top.Dock = DockStyle.Fill;
            top.ColumnCount = 2;
            top.RowCount = 1;
            top.BackColor = Color.FromArgb(244, 247, 251);
            top.Margin = Padding.Empty;
            top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));

            groupBox1.Text = "THÔNG TIN KHÁCH HÀNG";
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Margin = new Padding(0, 0, 10, 0);
            groupBox1.BackColor = Color.White;
            groupBox1.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.Padding = new Padding(10);

            fields = new TableLayoutPanel();

            fields.Dock = DockStyle.Fill;
            fields.ColumnCount = 4;
            fields.RowCount = 3;
            fields.Padding = new Padding(12, 12, 12, 12);
            fields.BackColor = Color.White;
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 33.34F));

            label1.Text = "Mã khách hàng";
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(35, 51, 72);
            label1.Margin = new Padding(3);

            label2.Text = "Số điện thoại";
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

            label4.Text = "Email";
            label4.Dock = DockStyle.Fill;
            label4.TextAlign = ContentAlignment.MiddleLeft;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(35, 51, 72);
            label4.Margin = new Padding(3);

            label5.Text = "Tên khách hàng";
            label5.Dock = DockStyle.Fill;
            label5.TextAlign = ContentAlignment.MiddleLeft;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(35, 51, 72);
            label5.Margin = new Padding(3);

            txtMaKH.Font = new Font("Segoe UI", 9.5F);
            txtMaKH.BackColor = Color.FromArgb(248, 250, 253);
            txtMaKH.ForeColor = Color.FromArgb(35, 51, 72);
            txtMaKH.BorderStyle = BorderStyle.FixedSingle;
            txtMaKH.Dock = DockStyle.Fill;
            txtMaKH.Margin = new Padding(5, 7, 8, 7);

            txtTenKH.Font = new Font("Segoe UI", 9.5F);
            txtTenKH.BackColor = Color.FromArgb(248, 250, 253);
            txtTenKH.ForeColor = Color.FromArgb(35, 51, 72);
            txtTenKH.BorderStyle = BorderStyle.FixedSingle;
            txtTenKH.Dock = DockStyle.Fill;
            txtTenKH.Margin = new Padding(5, 7, 8, 7);

            txtSDT.Font = new Font("Segoe UI", 9.5F);
            txtSDT.BackColor = Color.FromArgb(248, 250, 253);
            txtSDT.ForeColor = Color.FromArgb(35, 51, 72);
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.Dock = DockStyle.Fill;
            txtSDT.Margin = new Padding(5, 7, 8, 7);

            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.BackColor = Color.FromArgb(248, 250, 253);
            txtEmail.ForeColor = Color.FromArgb(35, 51, 72);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Margin = new Padding(5, 7, 8, 7);

            txtDiaChi.Font = new Font("Segoe UI", 9.5F);
            txtDiaChi.BackColor = Color.FromArgb(248, 250, 253);
            txtDiaChi.ForeColor = Color.FromArgb(35, 51, 72);
            txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
            txtDiaChi.Dock = DockStyle.Fill;
            txtDiaChi.Margin = new Padding(5, 7, 8, 7);

            fields.Controls.Add(label1, 0, 0);
            fields.Controls.Add(txtMaKH, 1, 0);
            fields.Controls.Add(label5, 2, 0);
            fields.Controls.Add(txtTenKH, 3, 0);
            fields.Controls.Add(label2, 0, 1);
            fields.Controls.Add(txtSDT, 1, 1);
            fields.Controls.Add(label4, 2, 1);
            fields.Controls.Add(txtEmail, 3, 1);
            fields.Controls.Add(label3, 0, 2);
            fields.Controls.Add(txtDiaChi, 1, 2);

            fields.SetColumnSpan(txtDiaChi, 3);

            groupBox1.Controls.Add(fields);

            groupBox2.Text = "LƯU Ý";
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Margin = new Padding(0);
            groupBox2.BackColor = Color.White;
            groupBox2.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox2.Padding = new Padding(10);

            noteLayout = new TableLayoutPanel();

            noteLayout.Dock = DockStyle.Fill;
            noteLayout.ColumnCount = 1;
            noteLayout.RowCount = 4;
            noteLayout.Padding = new Padding(12);
            noteLayout.BackColor = Color.White;
            noteLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            noteLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            noteLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            noteLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));

            label7.Text = "• Số điện thoại là thông tin tra cứu chính.";
            label7.Dock = DockStyle.Fill;
            label7.TextAlign = ContentAlignment.MiddleLeft;
            label7.Font = new Font("Segoe UI", 8.5F);
            label7.ForeColor = Color.FromArgb(55, 72, 95);
            label7.AutoEllipsis = true;
            label7.Margin = new Padding(2);

            label9.Text = "• Nhập SĐT trên hóa đơn để tìm khách hàng.";
            label9.Dock = DockStyle.Fill;
            label9.TextAlign = ContentAlignment.MiddleLeft;
            label9.Font = new Font("Segoe UI", 8.5F);
            label9.ForeColor = Color.FromArgb(55, 72, 95);
            label9.AutoEllipsis = true;
            label9.Margin = new Padding(2);

            label8.Text = "• Khách mới sẽ được thêm tự động khi lập hóa đơn.";
            label8.Dock = DockStyle.Fill;
            label8.TextAlign = ContentAlignment.MiddleLeft;
            label8.Font = new Font("Segoe UI", 8.5F);
            label8.ForeColor = Color.FromArgb(55, 72, 95);
            label8.AutoEllipsis = true;
            label8.Margin = new Padding(2);

            label10.Text = "• Tại đây có thể xem, sửa và xóa khách hàng.";
            label10.Dock = DockStyle.Fill;
            label10.TextAlign = ContentAlignment.MiddleLeft;
            label10.Font = new Font("Segoe UI", 8.5F);
            label10.ForeColor = Color.FromArgb(55, 72, 95);
            label10.AutoEllipsis = true;
            label10.Margin = new Padding(2);

            noteLayout.Controls.Add(label7, 0, 0);
            noteLayout.Controls.Add(label9, 0, 1);
            noteLayout.Controls.Add(label8, 0, 2);
            noteLayout.Controls.Add(label10, 0, 3);

            groupBox2.Controls.Add(noteLayout);

            top.Controls.Add(groupBox1, 0, 0);
            top.Controls.Add(groupBox2, 1, 0);

            commandLayout = new TableLayoutPanel();

            commandLayout.Dock = DockStyle.Fill;
            commandLayout.ColumnCount = 2;
            commandLayout.RowCount = 1;
            commandLayout.BackColor = Color.FromArgb(244, 247, 251);
            commandLayout.Margin = new Padding(0, 5, 0, 5);
            commandLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68F));
            commandLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));

            groupBox3.Text = "CHỨC NĂNG";
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Margin = new Padding(0, 0, 10, 0);
            groupBox3.BackColor = Color.White;
            groupBox3.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox3.Padding = new Padding(10);

            actions = new FlowLayoutPanel();

            actions.Dock = DockStyle.Fill;
            actions.FlowDirection = FlowDirection.LeftToRight;
            actions.WrapContents = false;
            actions.Padding = new Padding(5, 7, 5, 2);
            actions.BackColor = Color.White;

            btnThem.BackColor = Color.FromArgb(36, 120, 212);
            btnThem.ForeColor = Color.White;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnThem.Cursor = Cursors.Hand;
            btnThem.UseVisualStyleBackColor = false;

            btnSua.BackColor = Color.FromArgb(36, 120, 212);
            btnSua.ForeColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnSua.Cursor = Cursors.Hand;
            btnSua.UseVisualStyleBackColor = false;

            btnXoa.BackColor = Color.FromArgb(210, 70, 70);
            btnXoa.ForeColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.UseVisualStyleBackColor = false;

            btnLamLai.BackColor = Color.FromArgb(112, 128, 150);
            btnLamLai.ForeColor = Color.White;
            btnLamLai.FlatStyle = FlatStyle.Flat;
            btnLamLai.FlatAppearance.BorderSize = 0;
            btnLamLai.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnLamLai.Cursor = Cursors.Hand;
            btnLamLai.UseVisualStyleBackColor = false;

            btnThoat.BackColor = Color.FromArgb(20, 43, 74);
            btnThoat.ForeColor = Color.White;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.UseVisualStyleBackColor = false;

            btnThem.Text = "+ THÊM";

            btnSua.Text = "SỬA";

            btnXoa.Text = "XÓA";

            btnLamLai.Text = "LÀM LẠI";

            btnThoat.Text = "THOÁT";

            btnThem.Size = new Size(88, 40);
            btnThem.Margin = new Padding(3, 5, 3, 5);

            actions.Controls.Add(btnThem);

            btnSua.Size = new Size(88, 40);
            btnSua.Margin = new Padding(3, 5, 3, 5);

            actions.Controls.Add(btnSua);

            btnXoa.Size = new Size(88, 40);
            btnXoa.Margin = new Padding(3, 5, 3, 5);

            actions.Controls.Add(btnXoa);

            btnLamLai.Size = new Size(88, 40);
            btnLamLai.Margin = new Padding(3, 5, 3, 5);

            actions.Controls.Add(btnLamLai);

            btnThoat.Size = new Size(88, 40);
            btnThoat.Margin = new Padding(3, 5, 3, 5);

            actions.Controls.Add(btnThoat);

            groupBox3.Controls.Add(actions);

            groupBox5.Text = "TÌM KIẾM KHÁCH HÀNG";
            groupBox5.Dock = DockStyle.Fill;
            groupBox5.Margin = new Padding(0);
            groupBox5.BackColor = Color.White;
            groupBox5.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox5.Padding = new Padding(10);

            searchLayout = new TableLayoutPanel();

            searchLayout.Dock = DockStyle.Fill;
            searchLayout.ColumnCount = 2;
            searchLayout.RowCount = 1;
            searchLayout.Padding = new Padding(8, 8, 8, 8);
            searchLayout.BackColor = Color.White;
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 65F));
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            label6.Text = "Từ khóa";
            label6.Dock = DockStyle.Fill;
            label6.TextAlign = ContentAlignment.MiddleLeft;
            label6.Font = new Font("Segoe UI", 9.5F);
            label6.ForeColor = Color.FromArgb(35, 51, 72);

            txtTim.Font = new Font("Segoe UI", 9.5F);
            txtTim.BackColor = Color.FromArgb(248, 250, 253);
            txtTim.ForeColor = Color.FromArgb(35, 51, 72);
            txtTim.BorderStyle = BorderStyle.FixedSingle;
            txtTim.Dock = DockStyle.Fill;
            txtTim.Margin = new Padding(5, 7, 8, 7);
            txtTim.Dock = DockStyle.Fill;

            searchLayout.Controls.Add(label6, 0, 0);
            searchLayout.Controls.Add(txtTim, 1, 0);

            groupBox5.Controls.Add(searchLayout);

            commandLayout.Controls.Add(groupBox3, 0, 0);
            commandLayout.Controls.Add(groupBox5, 1, 0);

            groupBox4.Text = "DANH SÁCH KHÁCH HÀNG";
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Margin = new Padding(0);
            groupBox4.BackColor = Color.White;
            groupBox4.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox4.Padding = new Padding(10);

            dgvKhachHang.Dock = DockStyle.Fill;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AllowUserToDeleteRows = false;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.BackgroundColor = Color.White;
            dgvKhachHang.BorderStyle = BorderStyle.None;
            dgvKhachHang.EnableHeadersVisualStyles = false;
            dgvKhachHang.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 43, 74);
            dgvKhachHang.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKhachHang.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvKhachHang.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvKhachHang.DefaultCellStyle.ForeColor = Color.FromArgb(35, 51, 72);
            dgvKhachHang.DefaultCellStyle.BackColor = Color.White;
            dgvKhachHang.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 252);
            dgvKhachHang.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 252);
            dgvKhachHang.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 43, 74);
            dgvKhachHang.ColumnHeadersHeight = 42;
            dgvKhachHang.RowTemplate.Height = 36;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.MultiSelect = false;
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersVisible = false;
            dgvKhachHang.GridColor = Color.FromArgb(220, 228, 238);
            dgvKhachHang.Columns.AddRange(new DataGridViewColumn[] { colMaKH, colTenKH, colSDT, colEmail, colDiaChi });

            colMaKH.Name = "colMaKH";
            colMaKH.HeaderText = "Mã khách hàng";
            colMaKH.ReadOnly = true;
            colMaKH.FillWeight = 85;

            colTenKH.Name = "colTenKH";
            colTenKH.HeaderText = "Tên khách hàng";
            colTenKH.ReadOnly = true;
            colTenKH.FillWeight = 130;

            colSDT.Name = "colSDT";
            colSDT.HeaderText = "Số điện thoại";
            colSDT.ReadOnly = true;
            colSDT.FillWeight = 100;

            colEmail.Name = "colEmail";
            colEmail.HeaderText = "Email";
            colEmail.ReadOnly = true;
            colEmail.FillWeight = 130;

            colDiaChi.Name = "colDiaChi";
            colDiaChi.HeaderText = "Địa chỉ";
            colDiaChi.ReadOnly = true;
            colDiaChi.FillWeight = 160;

            groupBox4.Padding = new Padding(10);

            groupBox4.Controls.Add(dgvKhachHang);

            root.Controls.Add(top, 0, 0);
            root.Controls.Add(commandLayout, 0, 1);
            root.Controls.Add(groupBox4, 0, 2);

            Controls.Add(root);

            ResumeLayout(false);
        }

        // KHAI BÁO CONTROL

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private TextBox txtEmail;
        private TextBox txtTenKH;
        private TextBox txtDiaChi;
        private TextBox txtSDT;
        private TextBox txtMaKH;
        private TextBox txtTim;
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
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamLai;
        private Button btnThoat;
        private DataGridView dgvKhachHang;
        private DataGridViewTextBoxColumn colMaKH;
        private DataGridViewTextBoxColumn colTenKH;
        private DataGridViewTextBoxColumn colSDT;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colDiaChi;
        private TableLayoutPanel root;
        private TableLayoutPanel top;
        private TableLayoutPanel fields;
        private TableLayoutPanel noteLayout;
        private TableLayoutPanel commandLayout;
        private FlowLayoutPanel actions;
        private TableLayoutPanel searchLayout;
    }
}
