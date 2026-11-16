using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form4 : Form
    {
        private readonly NhaCungCapBUS nhaCungCapBus = new NhaCungCapBUS();
        private DataTable dtNCC = new DataTable();
        private DataView dvNCC = new DataView();

        public Form4()
        {
            InitializeComponent();

            TaoGiaoDien();

            Load += Form4_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamLai.Click += btnLamLai_Click;
            btnThoat.Click += (s, e) => Close();
            txtTim.TextChanged += (s, e) => TimKiem();
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;
        }

        private void Form4_Load(object? sender, EventArgs e)
        {
            dgvKhachHang.AutoGenerateColumns = false;
            colMaNCC.DataPropertyName = "MaNCC";
            colTenNCC.DataPropertyName = "TenNCC";
            colSDT.DataPropertyName = "SDT";
            colDiaChi.DataPropertyName = "DiaChi";
            if (colEmail != null) colEmail.DataPropertyName = "Email";
            if (colNguoiLH != null) colNguoiLH.DataPropertyName = "NguoiLH";

            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.MultiSelect = false;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadData();
            LamLai();
        }

        private void LoadData()
        {
            try
            {
                // Goi qua tang BUS
                dtNCC = nhaCungCapBus.LayDanhSach();
                dvNCC = new DataView(dtNCC);
                dgvKhachHang.DataSource = dvNCC;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhà cung cấp: " + ex.Message);
            }
        }

        private void dgvKhachHang_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvKhachHang.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;

            txtMaNCC.Text = r["MaNCC"].ToString();
            txtMaNCC.ReadOnly = true;
            txtTenNCC.Text = r["TenNCC"].ToString();
            txtSDT.Text = r["SDT"]?.ToString() ?? "";
            txtDiaChi.Text = r["DiaChi"]?.ToString() ?? "";
            txtEmail.Text = r["Email"]?.ToString() ?? "";
            txtNguoiLH.Text = r["NguoiLH"]?.ToString() ?? "";
        }

        private NhaCungCap TaoDoiTuongNhaCungCap()
        {
            return new NhaCungCap(
                txtMaNCC.Text.Trim(),
                txtTenNCC.Text.Trim(),
                txtSDT.Text.Trim(),
                txtDiaChi.Text.Trim(),
                txtEmail.Text.Trim(),
                txtNguoiLH.Text.Trim()
            );
        }
        private void btnThem_Click(object? sender, EventArgs e)
        {
            NhaCungCap ncc = TaoDoiTuongNhaCungCap();

            // Thuc hien qua tang BUS
            if (nhaCungCapBus.Them(ncc, out string error))
            {
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                LamLai();
            }
            else
            {
                MessageBox.Show(error, "Lỗi thêm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (!txtMaNCC.ReadOnly || string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn nhà cung cấp cần sửa trong danh sách!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            NhaCungCap ncc = TaoDoiTuongNhaCungCap();

            if (MessageBox.Show(
                $"Bạn có chắc chắn muốn cập nhật thông tin nhà cung cấp {ncc.MaNCC} không?",
                "Xác nhận sửa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (nhaCungCapBus.Sua(ncc, out string error))
            {
                MessageBox.Show(
                    "Cập nhật nhà cung cấp thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
                LamLai();
            }
            else
            {
                MessageBox.Show(
                    error,
                    "Lỗi cập nhật",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }



        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!txtMaNCC.ReadOnly || string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn nhà cung cấp cần xóa trong danh sách!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string ma = txtMaNCC.Text.Trim();
            string ten = txtTenNCC.Text.Trim();

            DialogResult xacNhan = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa nhà cung cấp:\n\n" +
                $"Mã NCC: {ma}\n" +
                $"Tên NCC: {ten}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            if (nhaCungCapBus.Xoa(ma, out string error))
            {
                MessageBox.Show(
                    "Xóa nhà cung cấp thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
                LamLai();
            }
            else
            {
                MessageBox.Show(
                    error,
                    "Không thể xóa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }


        private void btnLamLai_Click(object? sender, EventArgs e)
        {
            txtTim.Clear();
            if (dvNCC != null) dvNCC.RowFilter = "";
            LamLai();
        }

        private void LamLai()
        {
            txtMaNCC.ReadOnly = false;
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtNguoiLH.Clear();
            dgvKhachHang.ClearSelection();
            txtMaNCC.Focus();
        }

        private void TimKiem()
        {
            string tk = txtTim.Text.Trim().Replace("'", "''");
            if (dvNCC == null) return;
            dvNCC.RowFilter = tk.Length == 0 ? "" : $"TenNCC LIKE '%{tk}%' OR MaNCC LIKE '%{tk}%' OR SDT LIKE '%{tk}%'";
        }

        // =====================================================
        // DỰNG GIAO DIỆN
        // Tách khỏi InitializeComponent() để màn [Design] của Visual Studio
        // luôn mở được: trình thiết kế không đọc được vòng lặp và biến cục bộ.
        // =====================================================
        private void TaoGiaoDien()
        {
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
                    Color navy = Color.FromArgb(20, 43, 74);
                    Color blue = Color.FromArgb(36, 120, 212);
                    Color background = Color.FromArgb(244, 247, 251);
                    Color textColor = Color.FromArgb(35, 51, 72);
                    Color muted = Color.FromArgb(112, 128, 150);
                    Color border = Color.FromArgb(220, 228, 238);
                    Font normalFont = new Font("Segoe UI", 9.5F);
                    Font boldFont = new Font("Segoe UI", 10F, FontStyle.Bold);
                    // FORM
                    BackColor = background;
                    ForeColor = textColor;
                    Font = normalFont;
                    MinimumSize = new Size(900, 650);
                    StartPosition = FormStartPosition.CenterScreen;
                    // BỐ CỤC TỔNG
                    TableLayoutPanel root = new TableLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        ColumnCount = 1,
                        RowCount = 4,
                        Padding = new Padding(16),
                        BackColor = background,
                        Margin = Padding.Empty
                    };
                    root.RowStyles.Add(new RowStyle(SizeType.Absolute, 245F));
                    root.RowStyles.Add(new RowStyle(SizeType.Absolute, 105F));
                    root.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
                    root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                    // 1. THÔNG TIN NHÀ CUNG CẤP
                    groupBox1.Text = "THÔNG TIN NHÀ CUNG CẤP";
                    StyleGroup(groupBox1, navy, boldFont);
                    groupBox1.Dock = DockStyle.Fill;
                    groupBox1.Margin = new Padding(0, 0, 0, 8);
                    TableLayoutPanel fields = new TableLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        ColumnCount = 4,
                        RowCount = 3,
                        Padding = new Padding(12, 10, 12, 10),
                        BackColor = Color.White
                    };
                    fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
                    fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                    fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
                    fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                    for (int i = 0; i < 3; i++)
                        fields.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
                    SetLabel(label1, "Mã nhà cung cấp");
                    SetLabel(label2, "Tên nhà cung cấp");
                    SetLabel(label3, "Số điện thoại");
                    SetLabel(label4, "Email");
                    SetLabel(label5, "Địa chỉ");
                    SetLabel(label11, "Người liên hệ");
                    StyleText(txtMaNCC);
                    StyleText(txtTenNCC);
                    StyleText(txtSDT);
                    StyleText(txtEmail);
                    StyleText(txtDiaChi);
                    StyleText(txtNguoiLH);
                    AddField(fields, label1, txtMaNCC, 0, 0);
                    AddField(fields, label2, txtTenNCC, 2, 0);
                    AddField(fields, label3, txtSDT, 0, 1);
                    AddField(fields, label4, txtEmail, 2, 1);
                    AddField(fields, label5, txtDiaChi, 0, 2);
                    AddField(fields, label11, txtNguoiLH, 2, 2);
                    groupBox1.Controls.Add(fields);
                    // 2. GHI CHÚ
                    groupBox2.Text = "GHI CHÚ";
                    StyleGroup(groupBox2, navy, boldFont);
                    groupBox2.Dock = DockStyle.Fill;
                    groupBox2.Margin = new Padding(0, 0, 0, 8);
                    TableLayoutPanel notes = new TableLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        ColumnCount = 1,
                        RowCount = 2,
                        Padding = new Padding(14, 12, 14, 8),
                        BackColor = Color.White
                    };
                    notes.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                    notes.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                    label7.Text = "• Nhập đầy đủ thông tin nhà cung cấp trước khi lưu.";
                    label8.Text = "• Kiểm tra số điện thoại và email để tránh sai sót.";
                    foreach (Label lbl in new[] { label7, label8 })
                    {
                        lbl.Dock = DockStyle.Fill;
                        lbl.TextAlign = ContentAlignment.MiddleLeft;
                        lbl.Font = normalFont;
                        lbl.ForeColor = muted;
                        lbl.AutoSize = false;
                    }
                    notes.Controls.Add(label7, 0, 0);
                    notes.Controls.Add(label8, 0, 1);
                    groupBox2.Controls.Add(notes);
                    // 3. CHỨC NĂNG
                    groupBox3.Text = "CHỨC NĂNG";
                    StyleGroup(groupBox3, navy, boldFont);
                    groupBox3.Dock = DockStyle.Fill;
                    groupBox3.Margin = new Padding(0, 0, 0, 8);
                    FlowLayoutPanel actions = new FlowLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        FlowDirection = FlowDirection.LeftToRight,
                        WrapContents = false,
                        Padding = new Padding(10, 5, 10, 2),
                        BackColor = Color.White
                    };
                    StyleButton(btnThem, blue);
                    StyleButton(btnSua, blue);
                    StyleButton(btnXoa, Color.FromArgb(210, 70, 70));
                    StyleButton(btnLamLai, muted);
                    StyleButton(btnThoat, navy);
                    btnThem.Text = "+ THÊM";
                    btnSua.Text = "SỬA";
                    btnXoa.Text = "XÓA";
                    btnLamLai.Text = "LÀM LẠI";
                    btnThoat.Text = "THOÁT";
                    foreach (Button b in new[]
                    {
                        btnThem, btnSua, btnXoa, btnLamLai, btnThoat
                    })
                    {
                        b.Size = new Size(130, 45);
                        b.Margin = new Padding(8, 5, 12, 5);
                        actions.Controls.Add(b);
                    }
                    groupBox3.Controls.Add(actions);
                    // 4. TÌM KIẾM
                    groupBox5.Text = "TÌM KIẾM NHÀ CUNG CẤP";
                    StyleGroup(groupBox5, navy, boldFont);
                    groupBox5.Dock = DockStyle.Fill;
                    groupBox5.Margin = new Padding(0, 0, 0, 8);
                    TableLayoutPanel searchLayout = new TableLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        ColumnCount = 3,
                        RowCount = 1,
                        Padding = new Padding(10, 4, 10, 4),
                        BackColor = Color.White
                    };
                    searchLayout.ColumnStyles.Add(
                        new ColumnStyle(SizeType.Absolute, 160F));
                    searchLayout.ColumnStyles.Add(
                        new ColumnStyle(SizeType.Percent, 100F));
                    searchLayout.ColumnStyles.Add(
                        new ColumnStyle(SizeType.Absolute, 120F));
                    label6.Text = "Tên hoặc mã NCC";
                    label6.Dock = DockStyle.Fill;
                    label6.TextAlign = ContentAlignment.MiddleLeft;
                    label6.Font = normalFont;
                    label6.ForeColor = textColor;
                    StyleText(txtTim);
                    txtTim.Dock = DockStyle.Fill;
                    txtTim.Margin = new Padding(5, 3, 10, 3);
                    button1.Text = "TÌM KIẾM";
                    button1.Dock = DockStyle.Fill;
                    StyleButton(button1, blue);
                    searchLayout.Controls.Add(label6, 0, 0);
                    searchLayout.Controls.Add(txtTim, 1, 0);
                    searchLayout.Controls.Add(button1, 2, 0);
                    groupBox5.Controls.Add(searchLayout);
                    // 5. DANH SÁCH NHÀ CUNG CẤP
                    groupBox4.Text = "DANH SÁCH NHÀ CUNG CẤP";
                    StyleGroup(groupBox4, navy, boldFont);
                    groupBox4.Dock = DockStyle.Fill;
                    groupBox4.Margin = new Padding(0);
                    dgvKhachHang.Dock = DockStyle.Fill;
                    dgvKhachHang.BackgroundColor = Color.White;
                    dgvKhachHang.BorderStyle = BorderStyle.None;
                    dgvKhachHang.EnableHeadersVisualStyles = false;
                    dgvKhachHang.ColumnHeadersDefaultCellStyle.BackColor = navy;
                    dgvKhachHang.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgvKhachHang.ColumnHeadersDefaultCellStyle.Font =
                        new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    dgvKhachHang.DefaultCellStyle.Font = normalFont;
                    dgvKhachHang.DefaultCellStyle.ForeColor = textColor;
                    dgvKhachHang.DefaultCellStyle.BackColor = Color.White;
                    dgvKhachHang.DefaultCellStyle.SelectionBackColor =
                        Color.FromArgb(220, 235, 252);
                    dgvKhachHang.DefaultCellStyle.SelectionForeColor = navy;
                    dgvKhachHang.AlternatingRowsDefaultCellStyle.BackColor =
                        Color.FromArgb(245, 248, 252);
                    dgvKhachHang.ColumnHeadersHeight = 42;
                    dgvKhachHang.RowTemplate.Height = 36;
                    dgvKhachHang.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;
                    dgvKhachHang.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;
                    dgvKhachHang.MultiSelect = false;
                    dgvKhachHang.ReadOnly = true;
                    dgvKhachHang.AllowUserToAddRows = false;
                    dgvKhachHang.RowHeadersVisible = false;
                    dgvKhachHang.GridColor = border;
                    // CẤU HÌNH CỘT DANH SÁCH NHÀ CUNG CẤP
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
                    dgvKhachHang.Columns.AddRange(new DataGridViewColumn[]
                    {
            colMaNCC,
            colTenNCC,
            colSDT,
            colDiaChi,
            colEmail,
            colNguoiLH
                    });
                    groupBox4.Controls.Add(dgvKhachHang);
                    // GHÉP GIAO DIỆN
                    TableLayoutPanel top = new TableLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        ColumnCount = 2,
                        RowCount = 1,
                        BackColor = background,
                        Margin = Padding.Empty
                    };
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
        }

        // =====================================================
        // CÁC HÀM HỖ TRỢ THIẾT KẾ
        // =====================================================
        private void StyleGroup(GroupBox group, Color titleColor, Font font)
        {
            group.BackColor = Color.White;
            group.ForeColor = titleColor;
            group.Font = font;
            group.Padding = new Padding(10);
        }

        private void SetLabel(Label label, string text)
        {
            label.Text = text;
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(35, 51, 72);
            label.Margin = new Padding(3);
        }

        private void StyleText(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 10F);
            txt.BackColor = Color.FromArgb(248, 250, 253);
            txt.ForeColor = Color.FromArgb(35, 51, 72);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Dock = DockStyle.Fill;
            txt.Margin = new Padding(5, 5, 8, 5);
        }

        private void StyleButton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }

        private void AddField(
            TableLayoutPanel table,
            Control label,
            Control input,
            int column,
            int row)
        {
            table.Controls.Add(label, column, row);
            table.Controls.Add(input, column + 1, row);
        }
    }
}
