using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form4
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
            txtMaNCC = new TextBox();
            txtTenNCC = new TextBox();
            txtSDT = new TextBox();
            txtDiaChi = new TextBox();
            txtEmail = new TextBox();
            txtNguoiLH = new TextBox();
            txtTim = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamLai = new Button();
            btnThoat = new Button();
            button1 = new Button();
            dgvKhachHang = new DataGridView();
            colMaNCC = new DataGridViewTextBoxColumn();
            colTenNCC = new DataGridViewTextBoxColumn();
            colSDT = new DataGridViewTextBoxColumn();
            colDiaChi = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colNguoiLH = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label11 = new Label();

            SuspendLayout();
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 251);
            ForeColor = Color.FromArgb(35, 51, 72);
            Font = new Font("Segoe UI", 9.5F);
            ClientSize = new Size(1100, 760);
            MinimumSize = new Size(900, 650);
            Name = "Form4";
            Text = "PHONE STORE - Quản lý nhà cung cấp";
            StartPosition = FormStartPosition.CenterScreen;

            root = new TableLayoutPanel();

            root.Dock = DockStyle.Fill;
            root.ColumnCount = 1;
            root.RowCount = 4;
            root.Padding = new Padding(16);
            root.BackColor = Color.FromArgb(244, 247, 251);
            root.Margin = Padding.Empty;
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 245F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 105F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            groupBox1.Text = "THÔNG TIN NHÀ CUNG CẤP";
            groupBox1.BackColor = Color.White;
            groupBox1.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.Padding = new Padding(10);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Margin = new Padding(0, 0, 0, 8);

            fields = new TableLayoutPanel();

            fields.Dock = DockStyle.Fill;
            fields.ColumnCount = 4;
            fields.RowCount = 3;
            fields.Padding = new Padding(12, 10, 12, 10);
            fields.BackColor = Color.White;
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));

            label1.Text = "Mã nhà cung cấp";
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(35, 51, 72);
            label1.Margin = new Padding(3);

            label2.Text = "Tên nhà cung cấp";
            label2.Dock = DockStyle.Fill;
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(35, 51, 72);
            label2.Margin = new Padding(3);

            label3.Text = "Số điện thoại";
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

            label5.Text = "Địa chỉ";
            label5.Dock = DockStyle.Fill;
            label5.TextAlign = ContentAlignment.MiddleLeft;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(35, 51, 72);
            label5.Margin = new Padding(3);

            label11.Text = "Người liên hệ";
            label11.Dock = DockStyle.Fill;
            label11.TextAlign = ContentAlignment.MiddleLeft;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.ForeColor = Color.FromArgb(35, 51, 72);
            label11.Margin = new Padding(3);

            txtMaNCC.Font = new Font("Segoe UI", 10F);
            txtMaNCC.BackColor = Color.FromArgb(248, 250, 253);
            txtMaNCC.ForeColor = Color.FromArgb(35, 51, 72);
            txtMaNCC.BorderStyle = BorderStyle.FixedSingle;
            txtMaNCC.Dock = DockStyle.Fill;
            txtMaNCC.Margin = new Padding(5, 5, 8, 5);

            txtTenNCC.Font = new Font("Segoe UI", 10F);
            txtTenNCC.BackColor = Color.FromArgb(248, 250, 253);
            txtTenNCC.ForeColor = Color.FromArgb(35, 51, 72);
            txtTenNCC.BorderStyle = BorderStyle.FixedSingle;
            txtTenNCC.Dock = DockStyle.Fill;
            txtTenNCC.Margin = new Padding(5, 5, 8, 5);

            txtSDT.Font = new Font("Segoe UI", 10F);
            txtSDT.BackColor = Color.FromArgb(248, 250, 253);
            txtSDT.ForeColor = Color.FromArgb(35, 51, 72);
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.Dock = DockStyle.Fill;
            txtSDT.Margin = new Padding(5, 5, 8, 5);

            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.BackColor = Color.FromArgb(248, 250, 253);
            txtEmail.ForeColor = Color.FromArgb(35, 51, 72);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Margin = new Padding(5, 5, 8, 5);

            txtDiaChi.Font = new Font("Segoe UI", 10F);
            txtDiaChi.BackColor = Color.FromArgb(248, 250, 253);
            txtDiaChi.ForeColor = Color.FromArgb(35, 51, 72);
            txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
            txtDiaChi.Dock = DockStyle.Fill;
            txtDiaChi.Margin = new Padding(5, 5, 8, 5);

            txtNguoiLH.Font = new Font("Segoe UI", 10F);
            txtNguoiLH.BackColor = Color.FromArgb(248, 250, 253);
            txtNguoiLH.ForeColor = Color.FromArgb(35, 51, 72);
            txtNguoiLH.BorderStyle = BorderStyle.FixedSingle;
            txtNguoiLH.Dock = DockStyle.Fill;
            txtNguoiLH.Margin = new Padding(5, 5, 8, 5);

            fields.Controls.Add(label1, 0, 0);
            fields.Controls.Add(txtMaNCC, 1, 0);
            fields.Controls.Add(label2, 2, 0);
            fields.Controls.Add(txtTenNCC, 3, 0);
            fields.Controls.Add(label3, 0, 1);
            fields.Controls.Add(txtSDT, 1, 1);
            fields.Controls.Add(label4, 2, 1);
            fields.Controls.Add(txtEmail, 3, 1);
            fields.Controls.Add(label5, 0, 2);
            fields.Controls.Add(txtDiaChi, 1, 2);
            fields.Controls.Add(label11, 2, 2);
            fields.Controls.Add(txtNguoiLH, 3, 2);

            groupBox1.Controls.Add(fields);

            groupBox2.Text = "GHI CHÚ";
            groupBox2.BackColor = Color.White;
            groupBox2.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox2.Padding = new Padding(10);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Margin = new Padding(0, 0, 0, 8);

            notes = new TableLayoutPanel();

            notes.Dock = DockStyle.Fill;
            notes.ColumnCount = 1;
            notes.RowCount = 2;
            notes.Padding = new Padding(14, 12, 14, 8);
            notes.BackColor = Color.White;
            notes.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            notes.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            label7.Text = "• Nhập đầy đủ thông tin nhà cung cấp trước khi lưu.";

            label8.Text = "• Kiểm tra số điện thoại và email để tránh sai sót.";

            label7.Dock = DockStyle.Fill;
            label7.TextAlign = ContentAlignment.MiddleLeft;
            label7.Font = new Font("Segoe UI", 9.5F);
            label7.ForeColor = Color.FromArgb(112, 128, 150);
            label7.AutoSize = false;

            label8.Dock = DockStyle.Fill;
            label8.TextAlign = ContentAlignment.MiddleLeft;
            label8.Font = new Font("Segoe UI", 9.5F);
            label8.ForeColor = Color.FromArgb(112, 128, 150);
            label8.AutoSize = false;

            notes.Controls.Add(label7, 0, 0);
            notes.Controls.Add(label8, 0, 1);

            groupBox2.Controls.Add(notes);

            groupBox3.Text = "CHỨC NĂNG";
            groupBox3.BackColor = Color.White;
            groupBox3.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox3.Padding = new Padding(10);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Margin = new Padding(0, 0, 0, 8);

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

            groupBox5.Text = "TÌM KIẾM NHÀ CUNG CẤP";
            groupBox5.BackColor = Color.White;
            groupBox5.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox5.Padding = new Padding(10);
            groupBox5.Dock = DockStyle.Fill;
            groupBox5.Margin = new Padding(0, 0, 0, 8);

            searchLayout = new TableLayoutPanel();

            searchLayout.Dock = DockStyle.Fill;
            searchLayout.ColumnCount = 3;
            searchLayout.RowCount = 1;
            searchLayout.Padding = new Padding(10, 4, 10, 4);
            searchLayout.BackColor = Color.White;
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));

            label6.Text = "Tên hoặc mã NCC";
            label6.Dock = DockStyle.Fill;
            label6.TextAlign = ContentAlignment.MiddleLeft;
            label6.Font = new Font("Segoe UI", 9.5F);
            label6.ForeColor = Color.FromArgb(35, 51, 72);

            txtTim.Font = new Font("Segoe UI", 10F);
            txtTim.BackColor = Color.FromArgb(248, 250, 253);
            txtTim.ForeColor = Color.FromArgb(35, 51, 72);
            txtTim.BorderStyle = BorderStyle.FixedSingle;
            txtTim.Dock = DockStyle.Fill;
            txtTim.Margin = new Padding(5, 5, 8, 5);
            txtTim.Dock = DockStyle.Fill;
            txtTim.Margin = new Padding(5, 3, 10, 3);

            button1.Text = "TÌM KIẾM";
            button1.Dock = DockStyle.Fill;
            button1.BackColor = Color.FromArgb(36, 120, 212);
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.Cursor = Cursors.Hand;
            button1.UseVisualStyleBackColor = false;

            searchLayout.Controls.Add(label6, 0, 0);
            searchLayout.Controls.Add(txtTim, 1, 0);
            searchLayout.Controls.Add(button1, 2, 0);

            groupBox5.Controls.Add(searchLayout);

            groupBox4.Text = "DANH SÁCH NHÀ CUNG CẤP";
            groupBox4.BackColor = Color.White;
            groupBox4.ForeColor = Color.FromArgb(20, 43, 74);
            groupBox4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox4.Padding = new Padding(10);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Margin = new Padding(0);

            dgvKhachHang.Dock = DockStyle.Fill;
            dgvKhachHang.BackgroundColor = Color.White;
            dgvKhachHang.BorderStyle = BorderStyle.None;
            dgvKhachHang.EnableHeadersVisualStyles = false;
            dgvKhachHang.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 43, 74);
            dgvKhachHang.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKhachHang.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvKhachHang.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvKhachHang.DefaultCellStyle.ForeColor = Color.FromArgb(35, 51, 72);
            dgvKhachHang.DefaultCellStyle.BackColor = Color.White;
            dgvKhachHang.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 252);
            dgvKhachHang.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 43, 74);
            dgvKhachHang.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 252);
            dgvKhachHang.ColumnHeadersHeight = 42;
            dgvKhachHang.RowTemplate.Height = 36;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.MultiSelect = false;
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.RowHeadersVisible = false;
            dgvKhachHang.GridColor = Color.FromArgb(220, 228, 238);

            colMaNCC.Name = "colMaNCC";
            colMaNCC.HeaderText = "Mã NCC";
            colMaNCC.DataPropertyName = "MaNCC";

            colTenNCC.Name = "colTenNCC";
            colTenNCC.HeaderText = "Tên nhà cung cấp";
            colTenNCC.DataPropertyName = "TenNCC";

            colSDT.Name = "colSDT";
            colSDT.HeaderText = "Số điện thoại";
            colSDT.DataPropertyName = "SDT";

            colDiaChi.Name = "colDiaChi";
            colDiaChi.HeaderText = "Địa chỉ";
            colDiaChi.DataPropertyName = "DiaChi";

            colEmail.Name = "colEmail";
            colEmail.HeaderText = "Email";
            colEmail.DataPropertyName = "Email";

            colNguoiLH.Name = "colNguoiLH";
            colNguoiLH.HeaderText = "Người liên hệ";
            colNguoiLH.DataPropertyName = "NguoiLH";

            dgvKhachHang.Columns.AddRange(new DataGridViewColumn[] { colMaNCC, colTenNCC, colSDT, colDiaChi, colEmail, colNguoiLH });

            groupBox4.Controls.Add(dgvKhachHang);

            top = new TableLayoutPanel();

            top.Dock = DockStyle.Fill;
            top.ColumnCount = 2;
            top.RowCount = 1;
            top.BackColor = Color.FromArgb(244, 247, 251);
            top.Margin = Padding.Empty;
            top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));

            groupBox1.Margin = new Padding(0, 0, 10, 0);

            groupBox2.Margin = new Padding(0);

            top.Controls.Add(groupBox1, 0, 0);
            top.Controls.Add(groupBox2, 1, 0);

            root.Controls.Add(top, 0, 0);
            root.Controls.Add(groupBox3, 0, 1);
            root.Controls.Add(groupBox5, 0, 2);
            root.Controls.Add(groupBox4, 0, 3);

            Controls.Add(root);

            ResumeLayout(false);
        }

        // KHAI BÁO CONTROL

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private TextBox txtMaNCC;
        private TextBox txtTenNCC;
        private TextBox txtSDT;
        private TextBox txtDiaChi;
        private TextBox txtEmail;
        private TextBox txtNguoiLH;
        private TextBox txtTim;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamLai;
        private Button btnThoat;
        private Button button1;
        private DataGridView dgvKhachHang;
        private DataGridViewTextBoxColumn colMaNCC;
        private DataGridViewTextBoxColumn colTenNCC;
        private DataGridViewTextBoxColumn colSDT;
        private DataGridViewTextBoxColumn colDiaChi;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colNguoiLH;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label11;
        private TableLayoutPanel root;
        private TableLayoutPanel fields;
        private TableLayoutPanel notes;
        private FlowLayoutPanel actions;
        private TableLayoutPanel searchLayout;
        private TableLayoutPanel top;
    }
}
