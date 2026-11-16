using System;
using System.Data;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form3 : Form
    {
        private readonly KhachHangBUS khachHangBus = new KhachHangBUS();
        private DataTable dtKH = new DataTable();
        private DataView dvKH = new DataView();

        public Form3()
        {
            InitializeComponent();

            TaoGiaoDien();

            Load += Form3_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamLai.Click += btnLamLai_Click;
            btnThoat.Click += (s, e) => Close();
            txtTim.TextChanged += (s, e) => TimKiem();
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;
        }

        private void Form3_Load(object? sender, EventArgs e)
        {
            dgvKhachHang.AutoGenerateColumns = false;
            colMaKH.DataPropertyName = "MaKH";
            colTenKH.DataPropertyName = "TenKH";
            colSDT.DataPropertyName = "SDT";
            colDiaChi.DataPropertyName = "DiaChi";
            if (colEmail != null) colEmail.DataPropertyName = "Email";

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
                dtKH = khachHangBus.LayDanhSach();
                dvKH = new DataView(dtKH);
                dgvKhachHang.DataSource = dvKH;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khách hàng: " + ex.Message);
            }
        }

        private void dgvKhachHang_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvKhachHang.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;

            txtMaKH.Text = r["MaKH"].ToString();
            txtMaKH.ReadOnly = true;
            txtTenKH.Text = r["TenKH"].ToString();
            txtSDT.Text = r["SDT"]?.ToString() ?? "";
            txtDiaChi.Text = r["DiaChi"]?.ToString() ?? "";
            txtEmail.Text = r["Email"]?.ToString() ?? "";
        }


        private KhachHang TaoDoiTuongKhachHang()
        {
            return new KhachHang(
                txtMaKH.Text.Trim(),
                txtTenKH.Text.Trim(),
                txtSDT.Text.Trim(),
                txtDiaChi.Text.Trim(),
                txtEmail.Text.Trim()
            );
        }


        private void btnThem_Click(object? sender, EventArgs e)
        {
            KhachHang kh = TaoDoiTuongKhachHang();

            // Thuc hien qua tang BUS
            if (khachHangBus.Them(kh, out string error))
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!txtMaKH.ReadOnly)
            {
                MessageBox.Show("Hãy chọn một khách hàng trong danh sách để sửa.");
                return;
            }

            KhachHang kh = TaoDoiTuongKhachHang();

            // Thuc hien qua tang BUS
            if (khachHangBus.Sua(kh, out string error))
            {
                MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                LamLai();
            }
            else
            {
                MessageBox.Show(error, "Lỗi sửa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!txtMaKH.ReadOnly || string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show(
                    "Hãy chọn một khách hàng trong danh sách cần xóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string ma = txtMaKH.Text.Trim();

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khách hàng {ma} không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            if (khachHangBus.Xoa(ma, out string error))
            {
                MessageBox.Show(
                    "Xóa khách hàng thành công!",
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
                    "Không thể xóa khách hàng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }


        private void btnLamLai_Click(object? sender, EventArgs e)
        {
            txtTim.Clear();
            if (dvKH != null) dvKH.RowFilter = "";
            LamLai();
        }

        private void LamLai()
        {
            txtMaKH.ReadOnly = false;
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            dgvKhachHang.ClearSelection();
            txtMaKH.Focus();
        }


        private void TimKiem()
        {
            if (dvKH == null) return;

            string tk = txtTim.Text.Trim().Replace("'", "''");

            if (tk.Length == 0)
            {
                dvKH.RowFilter = "";
                return;
            }

            dvKH.RowFilter =
                $"MaKH LIKE '%{tk}%' OR " +
                $"TenKH LIKE '%{tk}%' OR " +
                $"SDT LIKE '%{tk}%' OR " +
                $"Email LIKE '%{tk}%' OR " +
                $"DiaChi LIKE '%{tk}%'";
        }

        // =====================================================
        // DỰNG GIAO DIỆN
        // Tách khỏi InitializeComponent() để màn [Design] của Visual Studio
        // luôn mở được: trình thiết kế không đọc được vòng lặp và biến cục bộ.
        // =====================================================
        private void TaoGiaoDien()
        {
            // ====================================
            // KHAI BÁO CONTROL
            // ====================================
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
            // ====================================
            // BẢNG MÀU ĐỒNG BỘ TOÀN DỰ ÁN
            // ====================================
            Color navy = Color.FromArgb(20, 43, 74);
            Color blue = Color.FromArgb(36, 120, 212);
            Color background = Color.FromArgb(244, 247, 251);
            Color textColor = Color.FromArgb(35, 51, 72);
            Color muted = Color.FromArgb(112, 128, 150);
            Color border = Color.FromArgb(220, 228, 238);
            Font normalFont = new Font("Segoe UI", 9.5F);
            Font boldFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            // ====================================
            // FORM
            // ====================================
            BackColor = background;
            Font = normalFont;
            MinimumSize = new Size(850, 600);
            // ====================================
            // BỐ CỤC TỔNG THỂ
            // ====================================
            TableLayoutPanel root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(15),
                BackColor = background,
                Margin = Padding.Empty
            };
            root.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 285F));
            root.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 100F));
            root.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));
            // ====================================
            // 1. THÔNG TIN KHÁCH HÀNG + LƯU Ý
            // ====================================
            TableLayoutPanel top = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = background,
                Margin = Padding.Empty
            };
            top.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 70F));
            top.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 30F));
            // ====================================
            // GROUPBOX 1 - THÔNG TIN KHÁCH HÀNG
            // ====================================
            groupBox1.Text = "THÔNG TIN KHÁCH HÀNG";
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Margin = new Padding(0, 0, 10, 0);
            StyleGroup(groupBox1, navy, boldFont);
            TableLayoutPanel fields = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 3,
                Padding = new Padding(12, 12, 12, 12),
                BackColor = Color.White
            };
            fields.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 105F));
            fields.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50F));
            fields.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 85F));
            fields.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50F));
            fields.RowStyles.Add(
                new RowStyle(SizeType.Percent, 33.33F));
            fields.RowStyles.Add(
                new RowStyle(SizeType.Percent, 33.33F));
            fields.RowStyles.Add(
                new RowStyle(SizeType.Percent, 33.34F));
            // ====================================
            // LABEL
            // ====================================
            SetLabel(label1, "Mã khách hàng");
            SetLabel(label2, "Số điện thoại");
            SetLabel(label3, "Địa chỉ");
            SetLabel(label4, "Email");
            SetLabel(label5, "Tên khách hàng");
            // ====================================
            // TEXTBOX
            // ====================================
            StyleText(txtMaKH);
            StyleText(txtTenKH);
            StyleText(txtSDT);
            StyleText(txtEmail);
            StyleText(txtDiaChi);
            // ====================================
            // SẮP XẾP THÔNG TIN
            // ====================================
            AddField(fields, label1, txtMaKH, 0, 0);
            AddField(fields, label5, txtTenKH, 2, 0);
            AddField(fields, label2, txtSDT, 0, 1);
            AddField(fields, label4, txtEmail, 2, 1);
            fields.Controls.Add(label3, 0, 2);
            fields.Controls.Add(txtDiaChi, 1, 2);
            fields.SetColumnSpan(txtDiaChi, 3);
            groupBox1.Controls.Add(fields);
            // ====================================
            // GROUPBOX 2 - LƯU Ý
            // ====================================
            groupBox2.Text = "LƯU Ý";
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Margin = new Padding(0);
            StyleGroup(groupBox2, navy, boldFont);
            TableLayoutPanel noteLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(12),
                BackColor = Color.White
            };
            for (int i = 0; i < 4; i++)
            {
                noteLayout.RowStyles.Add(
                    new RowStyle(SizeType.Percent, 25F));
            }
            SetNote(label7,
                "• Số điện thoại là thông tin tra cứu chính.");
            SetNote(label9,
                "• Nhập SĐT trên hóa đơn để tìm khách hàng.");
            SetNote(label8,
                "• Khách mới sẽ được thêm tự động khi lập hóa đơn.");
            SetNote(label10,
                "• Tại đây có thể xem, sửa và xóa khách hàng.");
            noteLayout.Controls.Add(label7, 0, 0);
            noteLayout.Controls.Add(label9, 0, 1);
            noteLayout.Controls.Add(label8, 0, 2);
            noteLayout.Controls.Add(label10, 0, 3);
            groupBox2.Controls.Add(noteLayout);
            top.Controls.Add(groupBox1, 0, 0);
            top.Controls.Add(groupBox2, 1, 0);
            // ====================================
            // 2. CHỨC NĂNG VÀ TÌM KIẾM
            // ====================================
            TableLayoutPanel commandLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = background,
                Margin = new Padding(0, 5, 0, 5)
            };
            commandLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 68F));
            commandLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 32F));
            // ====================================
            // GROUPBOX 3 - CHỨC NĂNG
            // ====================================
            groupBox3.Text = "CHỨC NĂNG";
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Margin = new Padding(0, 0, 10, 0);
            StyleGroup(groupBox3, navy, boldFont);
            FlowLayoutPanel actions = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(5, 7, 5, 2),
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
                b.Size = new Size(88, 40);
                b.Margin = new Padding(3, 5, 3, 5);
                actions.Controls.Add(b);
            }
            groupBox3.Controls.Add(actions);
            // ====================================
            // GROUPBOX 5 - TÌM KIẾM
            // ====================================
            groupBox5.Text = "TÌM KIẾM KHÁCH HÀNG";
            groupBox5.Dock = DockStyle.Fill;
            groupBox5.Margin = new Padding(0);
            StyleGroup(groupBox5, navy, boldFont);
            TableLayoutPanel searchLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(8, 8, 8, 8),
                BackColor = Color.White
            };
            searchLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 65F));
            searchLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));
            label6.Text = "Từ khóa";
            label6.Dock = DockStyle.Fill;
            label6.TextAlign = ContentAlignment.MiddleLeft;
            label6.Font = normalFont;
            label6.ForeColor = textColor;
            StyleText(txtTim);
            txtTim.Dock = DockStyle.Fill;
            searchLayout.Controls.Add(label6, 0, 0);
            searchLayout.Controls.Add(txtTim, 1, 0);
            groupBox5.Controls.Add(searchLayout);
            commandLayout.Controls.Add(groupBox3, 0, 0);
            commandLayout.Controls.Add(groupBox5, 1, 0);
            // ====================================
            // 3. DANH SÁCH KHÁCH HÀNG
            // ====================================
            groupBox4.Text = "DANH SÁCH KHÁCH HÀNG";
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Margin = new Padding(0);
            StyleGroup(groupBox4, navy, boldFont);
            dgvKhachHang.Dock = DockStyle.Fill;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AllowUserToDeleteRows = false;
            dgvKhachHang.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.BackgroundColor = Color.White;
            dgvKhachHang.BorderStyle = BorderStyle.None;
            dgvKhachHang.EnableHeadersVisualStyles = false;
            dgvKhachHang.ColumnHeadersDefaultCellStyle.BackColor = navy;
            dgvKhachHang.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;
            dgvKhachHang.ColumnHeadersDefaultCellStyle.Font =
                boldFont;
            dgvKhachHang.DefaultCellStyle.Font = normalFont;
            dgvKhachHang.DefaultCellStyle.ForeColor = textColor;
            dgvKhachHang.DefaultCellStyle.BackColor = Color.White;
            dgvKhachHang.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 248, 252);
            dgvKhachHang.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(220, 235, 252);
            dgvKhachHang.DefaultCellStyle.SelectionForeColor = navy;
            dgvKhachHang.ColumnHeadersHeight = 42;
            dgvKhachHang.RowTemplate.Height = 36;
            dgvKhachHang.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.MultiSelect = false;
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersVisible = false;
            dgvKhachHang.GridColor = border;
            dgvKhachHang.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    colMaKH,
                    colTenKH,
                    colSDT,
                    colEmail,
                    colDiaChi
                });
            // ====================================
            // CẤU HÌNH CÁC CỘT
            // ====================================
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
            // ====================================
            // GHÉP GIAO DIỆN
            // ====================================
            root.Controls.Add(top, 0, 0);
            root.Controls.Add(commandLayout, 0, 1);
            root.Controls.Add(groupBox4, 0, 2);
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

            label.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);

            label.ForeColor =
                Color.FromArgb(35, 51, 72);

            label.Margin = new Padding(3);
        }

        private void SetNote(Label label, string text)
        {
            label.Text = text;
            label.Dock = DockStyle.Fill;

            label.TextAlign = ContentAlignment.MiddleLeft;

            label.Font = new Font("Segoe UI", 8.5F);

            label.ForeColor =
                Color.FromArgb(55, 72, 95);

            label.AutoEllipsis = true;
            label.Margin = new Padding(2);
        }

        private void StyleText(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 9.5F);

            txt.BackColor =
                Color.FromArgb(248, 250, 253);

            txt.ForeColor =
                Color.FromArgb(35, 51, 72);

            txt.BorderStyle = BorderStyle.FixedSingle;

            txt.Dock = DockStyle.Fill;

            txt.Margin = new Padding(5, 7, 8, 7);
        }

        private void StyleButton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.Font = new Font(
                "Segoe UI", 8.5F, FontStyle.Bold);

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
