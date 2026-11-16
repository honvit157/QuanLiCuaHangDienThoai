using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form2 : Form
    {
        private readonly NhanVienBUS nhanVienBus = new NhanVienBUS();
        private DataTable dtNV = new DataTable();
        private DataView dvNV = new DataView();

        public Form2()
        {
            InitializeComponent();

            TaoGiaoDien();

            Load += Form2_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamLai.Click += btnLamLai_Click;
            btnThoat.Click += (s, e) => Close();
            btnTim.Click += btnTim_Click;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
        }


        private void Form2_Load(object? sender, EventArgs e)
        {
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.MaxDate = DateTime.Today;

            txtMatKhau.UseSystemPasswordChar = true;

            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucVu.Items.Clear();
            cboChucVu.Items.AddRange(new object[]
            {
        "Quản lý", "Nhân viên", "Bán hàng", "Thu ngân", "Kho"
            });

            // Cấu hình bảng nhân viên
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cấu hình trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[]
            {
        "Đang làm việc",
        "Đã nghỉ việc"
            });
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Enabled =
    Form9.VaiTroDangNhap == "Quản lý" ||
    Form9.VaiTroDangNhap == "Quan ly" ||
    Form9.VaiTroDangNhap == "Admin";
            cboTrangThai.SelectedIndex = 0;

           
            bool laQuanLy =
    Form9.VaiTroDangNhap == "Quản lý" ||
    Form9.VaiTroDangNhap == "Quan ly" ||
    Form9.VaiTroDangNhap == "Admin";

            btnXoa.Visible = laQuanLy;
            btnXoa.Enabled = laQuanLy;
            LoadData();
            LamLai();
        }


        private void LoadData()
        {
            try
            {
                // Lấy danh sách nhân viên từ BUS
                dtNV = nhanVienBus.LayDanhSach();
                dvNV = new DataView(dtNV);
                dgvNhanVien.DataSource = dvNV;

                var tieuDe = new Dictionary<string, string>
                {
                    ["MaNV"] = "Mã NV",
                    ["TenNV"] = "Họ tên",
                    ["GioiTinh"] = "Giới tính",
                    ["NgaySinh"] = "Ngày sinh",
                    ["SDT"] = "Số ĐT",
                    ["DiaChi"] = "Địa chỉ",
                    ["ChucVu"] = "Chức vụ",
                    ["TrangThai"] = "Trạng thái"
                };

                foreach (var kv in tieuDe)
                {
                    if (dgvNhanVien.Columns.Contains(kv.Key))
                        dgvNhanVien.Columns[kv.Key]!.HeaderText = kv.Value;
                }

                // Định dạng ngày sinh
                if (dgvNhanVien.Columns.Contains("NgaySinh"))
                    dgvNhanVien.Columns["NgaySinh"]!.DefaultCellStyle.Format = "dd/MM/yyyy";

                // Ẩn các cột không cần hiển thị
                if (dgvNhanVien.Columns.Contains("MatKhau"))
                    dgvNhanVien.Columns["MatKhau"]!.Visible = false;

                if (dgvNhanVien.Columns.Contains("TenDangNhap"))
                    dgvNhanVien.Columns["TenDangNhap"]!.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message);
            }
        }


        private void dgvNhanVien_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvNhanVien.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;

            txtMaNV.Text = r["MaNV"].ToString();
            txtMaNV.ReadOnly = true;
            txtTenNV.Text = r["TenNV"].ToString();

            if (r["NgaySinh"] != DBNull.Value && r["NgaySinh"] is DateTime ns)
            {
                dtpNgaySinh.Value =
                    ns <= dtpNgaySinh.MaxDate && ns >= dtpNgaySinh.MinDate
                    ? ns
                    : dtpNgaySinh.MaxDate;
            }
            else
            {
                dtpNgaySinh.Value = DateTime.Today;
            }

            string gt = r["GioiTinh"] == DBNull.Value
                ? "Nam"
                : r["GioiTinh"].ToString() ?? "Nam";

            radNu.Checked = gt.Equals("Nữ", StringComparison.OrdinalIgnoreCase);
            radNam.Checked = !radNu.Checked;

            txtSDT.Text = r["SDT"]?.ToString() ?? "";
            txtDiaChi.Text = r["DiaChi"]?.ToString() ?? "";

            string chucVu = r["ChucVu"]?.ToString() ?? "";
            cboChucVu.SelectedIndex = cboChucVu.FindStringExact(chucVu);

            txtMatKhau.Text = r["MatKhau"]?.ToString() ?? "";

            // Hiển thị trạng thái nhân viên
            string trangThai = r["TrangThai"] == DBNull.Value
                ? "Đang làm việc"
                : r["TrangThai"].ToString() ?? "Đang làm việc";

            cboTrangThai.Text = trangThai;
        }



        private NhanVien TaoDoiTuongNhanVien()
        {
            return new NhanVien(
                txtMaNV.Text.Trim(),
                txtTenNV.Text.Trim(),
                radNu.Checked ? "Nữ" : "Nam",
                dtpNgaySinh.Value.Date,
                txtSDT.Text.Trim(),
                txtDiaChi.Text.Trim(),
                txtMaNV.Text.Trim().ToLower(),
                txtMatKhau.Text.Trim(),
                cboChucVu.Text
            )
            {
                TrangThai = cboTrangThai.Text
            };
        }


        private void btnThem_Click(object? sender, EventArgs e)
        {
            NhanVien nv = TaoDoiTuongNhanVien();

            // Thuc hien qua tang BUS
            if (nhanVienBus.Them(nv, out string error))
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!txtMaNV.ReadOnly)
            {
                MessageBox.Show("Hãy chọn một nhân viên trong danh sách để sửa.");
                return;
            }

            bool laQuanLy =
                Form9.VaiTroDangNhap == "Quản lý" ||
                Form9.VaiTroDangNhap == "Quan ly" ||
                Form9.VaiTroDangNhap == "Admin";

            NhanVien nv = TaoDoiTuongNhanVien();

            // Nếu không phải quản lý, giữ nguyên trạng thái cũ
            if (!laQuanLy)
            {
                DataRowView? dongChon =
                    dgvNhanVien.CurrentRow?.DataBoundItem as DataRowView;

                if (dongChon != null)
                    nv.TrangThai = dongChon["TrangThai"]?.ToString()
                                   ?? "Đang làm việc";
            }

            if (nhanVienBus.Sua(nv, out string error))
            {
                MessageBox.Show(
                    "Cập nhật nhân viên thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadData();
                LamLai();
            }
            else
            {
                MessageBox.Show(
                    error,
                    "Lỗi sửa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!Form9.VaiTroDangNhap.Equals("Quản lý",
                    StringComparison.OrdinalIgnoreCase) &&
                !Form9.VaiTroDangNhap.Equals("Quan ly",
                    StringComparison.OrdinalIgnoreCase) &&
                !Form9.VaiTroDangNhap.Equals("Admin",
                    StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Chỉ quản lý mới có quyền xóa nhân viên!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa nhân viên này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            if (nhanVienBus.Xoa(txtMaNV.Text.Trim(), out string error))
            {
                MessageBox.Show("Xóa nhân viên thành công!");
                LoadData();
                LamLai();
            }
            else
            {
                MessageBox.Show(
                    error,
                    "Không thể xóa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }


        private void btnLamLai_Click(object? sender, EventArgs e)
        {
            txtTim.Clear();
            if (dvNV != null) dvNV.RowFilter = "";
            LamLai();
        }

        private void LamLai()
        {
            txtMaNV.ReadOnly = false;
            txtMaNV.Clear();
            txtTenNV.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            radNam.Checked = true;
            radNu.Checked = false;
            txtSDT.Clear();
            txtDiaChi.Clear();
            cboChucVu.SelectedIndex = -1;
            txtMatKhau.Clear();
            dgvNhanVien.ClearSelection();
            txtMaNV.Focus();
        }

        private void btnTim_Click(object? sender, EventArgs e)
        {
            string tk = txtTim.Text.Trim().Replace("'", "''");
            if (dvNV == null) return;
            dvNV.RowFilter = tk.Length == 0 ? "" : $"TenNV LIKE '%{tk}%' OR MaNV LIKE '%{tk}%' OR SDT LIKE '%{tk}%'";
            if (dvNV.Count == 0)
                MessageBox.Show("Không tìm thấy nhân viên nào phù hợp.");
        }

        // =====================================================
        // DỰNG GIAO DIỆN
        // Tách khỏi InitializeComponent() để màn [Design] của Visual Studio
        // luôn mở được: trình thiết kế không đọc được vòng lặp và biến cục bộ.
        // =====================================================
        private void TaoGiaoDien()
        {
                       // ==============================
                       // KHAI BÁO CONTROL
                       // ==============================
                       groupBox1 = new GroupBox();
                       groupBox2 = new GroupBox();
                       groupBox3 = new GroupBox();
                       groupBox4 = new GroupBox();
                       txtMaNV = new TextBox();
                       txtTenNV = new TextBox();
                       txtDiaChi = new TextBox();
                       txtMatKhau = new TextBox();
                       txtSDT = new TextBox();
                       txtTim = new TextBox();
                       cboChucVu = new ComboBox();
                       cboTrangThai = new ComboBox();
                       dtpNgaySinh = new DateTimePicker();
                       radNam = new RadioButton();
                       radNu = new RadioButton();
                       btnThem = new Button();
                       btnSua = new Button();
                       btnXoa = new Button();
                       btnLamLai = new Button();
                       btnThoat = new Button();
                       btnTim = new Button();
                       dgvNhanVien = new DataGridView();
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
                       label11 = new Label();
                       // ==============================
                       // BẢNG MÀU CHUNG
                       // ==============================
                       Color navy = Color.FromArgb(20, 43, 74);
                       Color blue = Color.FromArgb(36, 120, 212);
                       Color background = Color.FromArgb(244, 247, 251);
                       Color textColor = Color.FromArgb(35, 51, 72);
                       Color muted = Color.FromArgb(112, 128, 150);
                       Color border = Color.FromArgb(220, 228, 238);
                       Font normalFont = new Font("Segoe UI", 9.5F);
                       Font boldFont = new Font("Segoe UI", 10F, FontStyle.Bold);
                       // ==============================
                       // FORM
                       // ==============================
                       BackColor = background;
                       Font = normalFont;
                       MinimumSize = new Size(850, 600);
                       // ==============================
                       // BỐ CỤC TỔNG
                       // ==============================
                       TableLayoutPanel root = new TableLayoutPanel
                       {
                           Dock = DockStyle.Fill,
                           ColumnCount = 1,
                           RowCount = 4,
                           Padding = new Padding(16),
                           BackColor = background,
                           Margin = Padding.Empty
                       };
                       root.RowStyles.Add(
            new RowStyle(SizeType.Absolute, 310F)); // Thông tin điện thoại
                       root.RowStyles.Add(
                           new RowStyle(SizeType.Absolute, 105F)); // Chức năng
                       root.RowStyles.Add(
                           new RowStyle(SizeType.Absolute, 105F)); // Tìm kiếm
                       root.RowStyles.Add(
                           new RowStyle(SizeType.Percent, 100F)); // Danh sách
                       root.RowStyles.Add(
                           new RowStyle(SizeType.Percent, 100F));
                       // ==============================
                       // 1. KHU VỰC THÔNG TIN
                       // ==============================
                       TableLayoutPanel top = new TableLayoutPanel
                       {
                           Dock = DockStyle.Fill,
                           ColumnCount = 2,
                           RowCount = 1,
                           BackColor = background,
                           Margin = Padding.Empty
                       };
                       top.ColumnStyles.Add(
                           new ColumnStyle(SizeType.Percent, 72F));
                       top.ColumnStyles.Add(
                           new ColumnStyle(SizeType.Percent, 28F));
                       // ==============================
                       // GROUPBOX THÔNG TIN NHÂN VIÊN
                       // ==============================
                       groupBox1.Text = "THÔNG TIN NHÂN VIÊN";
                       groupBox1.Dock = DockStyle.Fill;
                       groupBox1.Margin = new Padding(0, 0, 10, 0);
                       StyleGroup(groupBox1, navy, boldFont);
                       TableLayoutPanel fields = new TableLayoutPanel
                       {
                           Dock = DockStyle.Fill,
                           ColumnCount = 4,
                           RowCount = 5,
                           Padding = new Padding(12, 10, 12, 10),
                           BackColor = Color.White
                       };
                       fields.ColumnStyles.Add(
                           new ColumnStyle(SizeType.Absolute, 105F));
                       fields.ColumnStyles.Add(
                           new ColumnStyle(SizeType.Percent, 50F));
                       fields.ColumnStyles.Add(
                           new ColumnStyle(SizeType.Absolute, 105F));
                       fields.ColumnStyles.Add(
                           new ColumnStyle(SizeType.Percent, 50F));
                       for (int i = 0; i < 5; i++)
                       {
                           fields.RowStyles.Add(
                               new RowStyle(SizeType.Percent, 20F));
                       }
                       // ==============================
                       // LABEL
                       // ==============================
                       SetLabel(label1, "Mã nhân viên");
                       SetLabel(label2, "Ngày sinh");
                       SetLabel(label3, "Địa chỉ");
                       SetLabel(label4, "Số điện thoại");
                       SetLabel(label5, "Mật khẩu");
                       SetLabel(label6, "Họ tên");
                       SetLabel(label7, "Giới tính");
                       SetLabel(label8, "Chức vụ");
                       SetLabel(label11, "Trạng thái");
                       // ==============================
                       // TEXTBOX
                       // ==============================
                       StyleText(txtMaNV);
                       StyleText(txtTenNV);
                       StyleText(txtDiaChi);
                       StyleText(txtMatKhau);
                       StyleText(txtSDT);
                       // ==============================
                       // COMBOBOX
                       // ==============================
                       StyleCombo(cboChucVu);
                       StyleCombo(cboTrangThai);
                       // ==============================
                       // DATE TIME PICKER
                       // ==============================
                       dtpNgaySinh.Dock = DockStyle.Fill;
                       dtpNgaySinh.Font = normalFont;
                       dtpNgaySinh.Format = DateTimePickerFormat.Short;
                       dtpNgaySinh.Margin = new Padding(5, 5, 8, 5);
                       // ==============================
                       // GIỚI TÍNH
                       // ==============================
                       FlowLayoutPanel genderPanel = new FlowLayoutPanel
                       {
                           Dock = DockStyle.Fill,
                           FlowDirection = FlowDirection.LeftToRight,
                           WrapContents = false,
                           BackColor = Color.White,
                           Padding = new Padding(5, 5, 0, 0)
                       };
                       radNam.Text = "Nam";
                       radNu.Text = "Nữ";
                       radNam.AutoSize = true;
                       radNu.AutoSize = true;
                       radNam.Font = normalFont;
                       radNu.Font = normalFont;
                       radNam.ForeColor = textColor;
                       radNu.ForeColor = textColor;
                       radNam.Margin = new Padding(3, 3, 20, 3);
                       radNu.Margin = new Padding(3);
                       genderPanel.Controls.Add(radNam);
                       genderPanel.Controls.Add(radNu);
                       // ==============================
                       // ĐƯA THÔNG TIN VÀO BẢNG
                       // ==============================
                       AddField(fields, label1, txtMaNV, 0, 0);
                       AddField(fields, label6, txtTenNV, 2, 0);
                       AddField(fields, label2, dtpNgaySinh, 0, 1);
                       AddField(fields, label7, genderPanel, 2, 1);
                       AddField(fields, label4, txtSDT, 0, 2);
                       AddField(fields, label8, cboChucVu, 2, 2);
                       fields.Controls.Add(label3, 0, 3);
                       fields.Controls.Add(txtDiaChi, 1, 3);
                       fields.SetColumnSpan(txtDiaChi, 3);
                       AddField(fields, label5, txtMatKhau, 0, 4);
                       AddField(fields, label11, cboTrangThai, 2, 4);
                       groupBox1.Controls.Add(fields);
                       // ==============================
                       // 2. GROUPBOX LƯU Ý
                       // ==============================
                       groupBox2.Text = "LƯU Ý";
                       groupBox2.Dock = DockStyle.Fill;
                       groupBox2.Margin = new Padding(0);
                       StyleGroup(groupBox2, navy, boldFont);
                       Panel notePanel = new Panel
                       {
                           Dock = DockStyle.Fill,
                           BackColor = Color.White,
                           Padding = new Padding(15)
                       };
                       label9.AutoSize = false;
                       label9.Dock = DockStyle.Top;
                       label9.Height = 100;
                       label9.Text =
                           "TÀI KHOẢN ĐĂNG NHẬP\n\n" +
                           "Tên đăng nhập: Mã nhân viên\n\n" +
                           "Mật khẩu: Mật khẩu nhân viên";
                       label9.Font = normalFont;
                       label9.ForeColor = textColor;
                       label9.TextAlign = ContentAlignment.TopLeft;
                       notePanel.Controls.Add(label9);
                       groupBox2.Controls.Add(notePanel);
                       top.Controls.Add(groupBox1, 0, 0);
                       top.Controls.Add(groupBox2, 1, 0);
                       // ==============================
                       // 3. CHỨC NĂNG
                       // ==============================
                       groupBox3.Text = "CHỨC NĂNG";
                       groupBox3.Dock = DockStyle.Fill;
                       groupBox3.Margin = new Padding(0, 8, 0, 5);
                       StyleGroup(groupBox3, navy, boldFont);
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
                           b.Size = new Size(130, 42);
                           b.Margin = new Padding(8, 5, 12, 5);
                           actions.Controls.Add(b);
                       }
                       groupBox3.Controls.Add(actions);
                       // ==============================
                       // 4. TÌM KIẾM NHÂN VIÊN
                       // ==============================
                       groupBox4.Text = "TÌM KIẾM NHÂN VIÊN";
                       groupBox4.Dock = DockStyle.Fill;
                       groupBox4.Margin = new Padding(0, 5, 0, 0);
                       StyleGroup(groupBox4, navy, boldFont);
                       TableLayoutPanel searchLayout = new TableLayoutPanel
                       {
                           Dock = DockStyle.Fill,
                           ColumnCount = 3,
                           RowCount = 1,
                           Padding = new Padding(12, 8, 12, 8),
                           BackColor = Color.White
                       };
                       searchLayout.ColumnStyles.Add(
                           new ColumnStyle(SizeType.Absolute, 170F));
                       searchLayout.ColumnStyles.Add(
                           new ColumnStyle(SizeType.Percent, 100F));
                       searchLayout.ColumnStyles.Add(
                           new ColumnStyle(SizeType.Absolute, 125F));
                       label10.Text = "Tên hoặc mã nhân viên";
                       label10.Dock = DockStyle.Fill;
                       label10.TextAlign = ContentAlignment.MiddleLeft;
                       label10.Font = normalFont;
                       label10.ForeColor = textColor;
                       StyleText(txtTim);
                       txtTim.Dock = DockStyle.Fill;
                       btnTim.Text = "TÌM KIẾM";
                       btnTim.Dock = DockStyle.Fill;
                       StyleButton(btnTim, blue);
                       searchLayout.Controls.Add(label10, 0, 0);
                       searchLayout.Controls.Add(txtTim, 1, 0);
                       searchLayout.Controls.Add(btnTim, 2, 0);
                       groupBox4.Controls.Add(searchLayout);
                       // ==============================
                       // 5. DANH SÁCH NHÂN VIÊN
                       // ==============================
                       dgvNhanVien.Dock = DockStyle.Fill;
                       dgvNhanVien.BackgroundColor = Color.White;
                       dgvNhanVien.BorderStyle = BorderStyle.None;
                       dgvNhanVien.EnableHeadersVisualStyles = false;
                       dgvNhanVien.ColumnHeadersDefaultCellStyle.BackColor = navy;
                       dgvNhanVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                       dgvNhanVien.ColumnHeadersDefaultCellStyle.Font =
                           new Font("Segoe UI", 9.5F, FontStyle.Bold);
                       dgvNhanVien.DefaultCellStyle.Font = normalFont;
                       dgvNhanVien.DefaultCellStyle.ForeColor = textColor;
                       dgvNhanVien.DefaultCellStyle.BackColor = Color.White;
                       dgvNhanVien.DefaultCellStyle.SelectionBackColor =
                           Color.FromArgb(220, 235, 252);
                       dgvNhanVien.DefaultCellStyle.SelectionForeColor = navy;
                       dgvNhanVien.AlternatingRowsDefaultCellStyle.BackColor =
                           Color.FromArgb(245, 248, 252);
                       dgvNhanVien.ColumnHeadersHeight = 42;
                       dgvNhanVien.RowTemplate.Height = 36;
                       dgvNhanVien.AutoSizeColumnsMode =
                           DataGridViewAutoSizeColumnsMode.Fill;
                       dgvNhanVien.SelectionMode =
                           DataGridViewSelectionMode.FullRowSelect;
                       dgvNhanVien.MultiSelect = false;
                       dgvNhanVien.ReadOnly = true;
                       dgvNhanVien.AllowUserToAddRows = false;
                       dgvNhanVien.RowHeadersVisible = false;
                       dgvNhanVien.GridColor = border;
                       dgvNhanVien.Margin = new Padding(0, 5, 0, 0);
                       // ==============================
                       // GHÉP TOÀN BỘ GIAO DIỆN
                       // ==============================
                       root.Controls.Add(top, 0, 0);
                       root.Controls.Add(groupBox3, 0, 1);
                       root.Controls.Add(groupBox4, 0, 2);
                       root.Controls.Add(dgvNhanVien, 0, 3);
                       Controls.Add(root);
        }

        // =====================================================
        // CÁC HÀM HỖ TRỢ THIẾT KẾ
        // =====================================================
        private void StyleGroup(
            GroupBox group,
            Color titleColor,
            Font font)
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

            label.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            label.ForeColor =
                Color.FromArgb(35, 51, 72);

            label.Margin = new Padding(3);
        }

        private void StyleText(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 10F);

            txt.BackColor =
                Color.FromArgb(248, 250, 253);

            txt.ForeColor =
                Color.FromArgb(35, 51, 72);

            txt.BorderStyle = BorderStyle.FixedSingle;

            txt.Dock = DockStyle.Fill;

            txt.Margin = new Padding(5, 5, 8, 5);
        }

        private void StyleCombo(ComboBox cbo)
        {
            cbo.Font = new Font("Segoe UI", 9.5F);

            cbo.BackColor =
                Color.FromArgb(248, 250, 253);

            cbo.ForeColor =
                Color.FromArgb(35, 51, 72);

            cbo.Dock = DockStyle.Fill;

            cbo.Margin = new Padding(5, 5, 8, 5);
        }

        private void StyleButton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

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
