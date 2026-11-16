
using System;
using System.Data;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form5 : Form
    {
        private readonly DanhMucBUS danhMucBus = new DanhMucBUS();

        public Form5()
        {
            InitializeComponent();

            TaoGiaoDien();

            Load += Form5_Load;

            // TAB 1: HANG SAN XUAT
            btnThem.Click += (s, e) =>
                ThemDanhMuc(LoaiDanhMuc.HangSanXuat,
                    txtMaHang, txtTenHang, LoadHangSX);

            btnSua.Click += (s, e) =>
                SuaDanhMuc(LoaiDanhMuc.HangSanXuat,
                    txtMaHang, txtTenHang, LoadHangSX);

            btnXoa.Click += (s, e) =>
                XoaDanhMuc(LoaiDanhMuc.HangSanXuat,
                    txtMaHang, LoadHangSX);

            btnLamLai.Click += (s, e) =>
                LamLai(txtMaHang, txtTenHang);

            btnThoat.Click += (s, e) => Close();

            dgvHangSX.CellClick += (s, e) =>
                ChonDong(e, dgvHangSX, txtMaHang, txtTenHang, "MaHangSX", "TenHangSX");


            // TAB 2: LOAI HANG
            // button5 = Them, button4 = Sua, button3 = Xoa
            // button2 = Lam lai, button1 = Thoat

            button5.Click += (s, e) =>
                ThemDanhMuc(LoaiDanhMuc.LoaiHang,
                    textBox3, textBox1, LoadLoai);

            button4.Click += (s, e) =>
                SuaDanhMuc(LoaiDanhMuc.LoaiHang,
                    textBox3, textBox1, LoadLoai);

            button3.Click += (s, e) =>
                XoaDanhMuc(LoaiDanhMuc.LoaiHang,
                    textBox3, LoadLoai);

            button2.Click += (s, e) =>
                LamLai(textBox3, textBox1);

            button1.Click += (s, e) => Close();

            dataGridView1.CellClick += (s, e) =>
                ChonDong(e, dataGridView1, textBox3, textBox1, "MaLoai", "TenLoai");


            // TAB 3: MAU SAC
            // button10 = Them, button9 = Sua, button8 = Xoa
            // button7 = Lam lai, button6 = Thoat

            button10.Click += (s, e) =>
                ThemDanhMuc(LoaiDanhMuc.MauSac,
                    textBox6, textBox4, LoadMau);

            button9.Click += (s, e) =>
                SuaDanhMuc(LoaiDanhMuc.MauSac,
                    textBox6, textBox4, LoadMau);

            button8.Click += (s, e) =>
                XoaDanhMuc(LoaiDanhMuc.MauSac,
                    textBox6, LoadMau);

            button7.Click += (s, e) =>
                LamLai(textBox6, textBox4);

            button6.Click += (s, e) => Close();

            dataGridView2.CellClick += (s, e) =>
                ChonDong(e, dataGridView2, textBox6, textBox4, "MaMau", "TenMau");


            // TAB 4: DUNG LUONG
            // button15 = Them, button14 = Sua, button13 = Xoa
            // button12 = Lam lai, button11 = Thoat

            button15.Click += (s, e) =>
                ThemDanhMuc(LoaiDanhMuc.DungLuong,
                    textBox9, textBox7, LoadDungLuong);

            button14.Click += (s, e) =>
                SuaDanhMuc(LoaiDanhMuc.DungLuong,
                    textBox9, textBox7, LoadDungLuong);

            button13.Click += (s, e) =>
                XoaDanhMuc(LoaiDanhMuc.DungLuong,
                    textBox9, LoadDungLuong);

            button12.Click += (s, e) =>
                LamLai(textBox9, textBox7);

            button11.Click += (s, e) => Close();

            dataGridView3.CellClick += (s, e) =>
                ChonDong(e, dataGridView3, textBox9, textBox7,
                    "MaDungLuong", "TenDungLuong");
        }


        // KHOI TAO FORM
        private void Form5_Load(object? sender, EventArgs e)
        {
            SetupDgv(dgvHangSX);
            SetupDgv(dataGridView1);
            SetupDgv(dataGridView2);
            SetupDgv(dataGridView3);

            // Database hien tai khong co cot GhiChu.
            // An cac o ghi chu de tranh nhap lieu nhung khong duoc luu.

            txtGhiChu.Visible = false;
            label2.Visible = false;

            textBox2.Visible = false;
            label5.Visible = false;

            textBox5.Visible = false;
            label8.Visible = false;

            textBox8.Visible = false;
            label11.Visible = false;

            // Dat lai ten nhan cho tung tab
            label1.Text = "Mã hãng SX";
            label3.Text = "Tên hãng SX";

            label6.Text = "Mã loại";
            label4.Text = "Tên loại";

            label9.Text = "Mã màu";
            label7.Text = "Tên màu";

            label12.Text = "Mã dung lượng";
            label10.Text = "Tên dung lượng";

            LoadHangSX();
            LoadLoai();
            LoadMau();
            LoadDungLuong();
        }


        // CAU HINH DATAGRIDVIEW
        private void SetupDgv(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = true;

            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
        }


        // TAI DU LIEU
        private void LoadHangSX()
        {
            dgvHangSX.DataSource = danhMucBus.LayDanhSach(LoaiDanhMuc.HangSanXuat);

            if (dgvHangSX.Columns.Contains("MaHangSX"))
                dgvHangSX.Columns["MaHangSX"].HeaderText = "Mã hãng SX";

            if (dgvHangSX.Columns.Contains("TenHangSX"))
                dgvHangSX.Columns["TenHangSX"].HeaderText = "Tên hãng SX";
        }


        private void LoadLoai()
        {
            dataGridView1.DataSource = danhMucBus.LayDanhSach(LoaiDanhMuc.LoaiHang);

            if (dataGridView1.Columns.Contains("MaLoai"))
                dataGridView1.Columns["MaLoai"].HeaderText = "Mã loại";

            if (dataGridView1.Columns.Contains("TenLoai"))
                dataGridView1.Columns["TenLoai"].HeaderText = "Tên loại";
        }


        private void LoadMau()
        {
            dataGridView2.DataSource = danhMucBus.LayDanhSach(LoaiDanhMuc.MauSac);

            if (dataGridView2.Columns.Contains("MaMau"))
                dataGridView2.Columns["MaMau"].HeaderText = "Mã màu";

            if (dataGridView2.Columns.Contains("TenMau"))
                dataGridView2.Columns["TenMau"].HeaderText = "Tên màu";
        }


        private void LoadDungLuong()
        {
            dataGridView3.DataSource = danhMucBus.LayDanhSach(LoaiDanhMuc.DungLuong);

            if (dataGridView3.Columns.Contains("MaDungLuong"))
                dataGridView3.Columns["MaDungLuong"].HeaderText = "Mã dung lượng";

            if (dataGridView3.Columns.Contains("TenDungLuong"))
                dataGridView3.Columns["TenDungLuong"].HeaderText = "Tên dung lượng";
        }


        // CHON MOT DONG TREN DATAGRIDVIEW
        private void ChonDong(
            DataGridViewCellEventArgs e,
            DataGridView dgv,
            TextBox txtMa,
            TextBox txtTen,
            string cotMa,
            string cotTen)
        {
            if (e.RowIndex < 0)
                return;

            if (dgv.Rows[e.RowIndex].DataBoundItem is DataRowView r)
            {
                txtMa.Text = r[cotMa]?.ToString() ?? "";
                txtTen.Text = r[cotTen]?.ToString() ?? "";

                txtMa.ReadOnly = true;
            }
        }


        // THEM DANH MUC
        private void ThemDanhMuc(
            LoaiDanhMuc loai,
            TextBox txtMa,
            TextBox txtTen,
            Action reload)
        {
            string ma = txtMa.Text.Trim();
            string ten = txtTen.Text.Trim();

            if (txtMa.ReadOnly)
            {
                MessageBox.Show(
                    "Bạn đang chọn một danh mục có sẵn. Hãy bấm Làm lại trước khi thêm mới!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ma) ||
                string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ mã và tên danh mục!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!danhMucBus.Them(loai, ma, ten, out string error))
            {
                MessageBox.Show(
                    error,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(
                "Thêm danh mục thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            reload();
            LamLai(txtMa, txtTen);
        }


        // SUA DANH MUC
        private void SuaDanhMuc(
            LoaiDanhMuc loai,
            TextBox txtMa,
            TextBox txtTen,
            Action reload)
        {
            string ma = txtMa.Text.Trim();
            string ten = txtTen.Text.Trim();

            if (!txtMa.ReadOnly || string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show(
                    "Vui lòng chọn danh mục cần sửa trong danh sách!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show(
                    "Tên danh mục không được để trống!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!danhMucBus.Sua(loai, ma, ten, out string error))
            {
                MessageBox.Show(
                    error,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(
                "Cập nhật danh mục thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            reload();
            LamLai(txtMa, txtTen);
        }


        // XOA DANH MUC
        private void XoaDanhMuc(
            LoaiDanhMuc loai,
            TextBox txtMa,
            Action reload)
        {
            string ma = txtMa.Text.Trim();

            if (!txtMa.ReadOnly || string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show(
                    "Vui lòng chọn danh mục cần xóa trong danh sách!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa danh mục {ma} không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            if (!danhMucBus.Xoa(loai, ma, out string error))
            {
                MessageBox.Show(
                    error,
                    "Không thể xóa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(
                "Xóa danh mục thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            reload();
            LamLai(txtMa, null);
        }


        // LAM LAI CAC O NHAP
        private void LamLai(TextBox txtMa, TextBox? txtTen)
        {
            txtMa.Clear();
            txtMa.ReadOnly = false;

            if (txtTen != null)
                txtTen.Clear();

            txtMa.Focus();
        }

        // =====================================================
        // DỰNG GIAO DIỆN
        // Tách khỏi InitializeComponent() để màn [Design] của Visual Studio
        // luôn mở được: trình thiết kế không đọc được vòng lặp và biến cục bộ.
        // =====================================================
        private void TaoGiaoDien()
        {
            tabDanhMuc = new TabControl();
            tpHangSX = new TabPage();
            tpLoai = new TabPage();
            tpMauSac = new TabPage();
            tpDungLuong = new TabPage();
            // TAB 1 - HANG SAN XUAT
            txtMaHang = new TextBox();
            txtTenHang = new TextBox();
            txtGhiChu = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamLai = new Button();
            btnThoat = new Button();
            dgvHangSX = new DataGridView();
            // TAB 2 - LOAI HANG
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label5 = new Label();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            // TAB 3 - MAU SAC
            textBox6 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label9 = new Label();
            label7 = new Label();
            label8 = new Label();
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            dataGridView2 = new DataGridView();
            // TAB 4 - DUNG LUONG
            textBox9 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            label12 = new Label();
            label10 = new Label();
            label11 = new Label();
            button15 = new Button();
            button14 = new Button();
            button13 = new Button();
            button12 = new Button();
            button11 = new Button();
            dataGridView3 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvHangSX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            // FORM
            BackColor = mauNen;
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1000, 650);
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            // TAB CONTROL
            tabDanhMuc.Dock = DockStyle.Fill;
            tabDanhMuc.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            tabDanhMuc.Padding = new Point(18, 8);
            tabDanhMuc.SizeMode = TabSizeMode.Normal;
            SetupPage(tpHangSX, "Hãng sản xuất");
            SetupPage(tpLoai, "Loại hàng");
            SetupPage(tpMauSac, "Màu sắc");
            SetupPage(tpDungLuong, "Dung lượng");
            // TAB 1
            BuildTab(
                tpHangSX,
                "THÔNG TIN HÃNG SẢN XUẤT",
                label1, txtMaHang, "Mã hãng sản xuất",
                label3, txtTenHang, "Tên hãng sản xuất",
                label2, txtGhiChu,
                btnThem, btnSua, btnXoa, btnLamLai, btnThoat,
                dgvHangSX
            );
            btnThem.Text = "＋  Thêm";
            btnSua.Text = "✎  Sửa";
            btnXoa.Text = "✕  Xóa";
            btnLamLai.Text = "↻  Làm lại";
            btnThoat.Text = "←  Thoát";
            // TAB 2
            BuildTab(
                tpLoai,
                "THÔNG TIN LOẠI HÀNG",
                label6, textBox3, "Mã loại hàng",
                label4, textBox1, "Tên loại hàng",
                label5, textBox2,
                button5, button4, button3, button2, button1,
                dataGridView1
            );
            button5.Text = "＋  Thêm";
            button4.Text = "✎  Sửa";
            button3.Text = "✕  Xóa";
            button2.Text = "↻  Làm lại";
            button1.Text = "←  Thoát";
            // TAB 3
            BuildTab(
                tpMauSac,
                "THÔNG TIN MÀU SẮC",
                label9, textBox6, "Mã màu",
                label7, textBox4, "Tên màu",
                label8, textBox5,
                button10, button9, button8, button7, button6,
                dataGridView2
            );
            button10.Text = "＋  Thêm";
            button9.Text = "✎  Sửa";
            button8.Text = "✕  Xóa";
            button7.Text = "↻  Làm lại";
            button6.Text = "←  Thoát";
            // TAB 4
            BuildTab(
                tpDungLuong,
                "THÔNG TIN DUNG LƯỢNG",
                label12, textBox9, "Mã dung lượng",
                label10, textBox7, "Tên dung lượng",
                label11, textBox8,
                button15, button14, button13, button12, button11,
                dataGridView3
            );
            button15.Text = "＋  Thêm";
            button14.Text = "✎  Sửa";
            button13.Text = "✕  Xóa";
            button12.Text = "↻  Làm lại";
            button11.Text = "←  Thoát";
            tabDanhMuc.Controls.AddRange(new Control[]
            {
                tpHangSX,
                tpLoai,
                tpMauSac,
                tpDungLuong
            });
            Controls.Add(tabDanhMuc);
            ((System.ComponentModel.ISupportInitialize)dgvHangSX).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
        }

        // =====================================================
        // CÁC HÀM HỖ TRỢ THIẾT KẾ
        // =====================================================
        private void SetupPage(TabPage page, string title)
        {
            page.Text = title;
            page.BackColor = mauNen;
            page.Padding = new Padding(12);
            page.UseVisualStyleBackColor = false;
        }

                private void BuildTab(
               TabPage page,
               string heading,
               Label labelMa, TextBox txtMa, string placeholderMa,
               Label labelTen, TextBox txtTen, string placeholderTen,
               Label labelGhiChu, TextBox txtGhiChuTab,
               Button btnThemTab, Button btnSuaTab, Button btnXoaTab,
               Button btnLamLaiTab, Button btnThoatTab,
               DataGridView dgv)
                {
                    // TIÊU ĐỀ
                    Label lblHeading = new Label();
                    lblHeading.Text = heading;
                    lblHeading.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
                    lblHeading.ForeColor = mauChu;
                    lblHeading.AutoSize = true;
                    lblHeading.Location = new Point(20, 14);

                    // KHUNG THÔNG TIN
                    Panel pnlThongTin = new Panel();
                    pnlThongTin.BackColor = Color.White;
                    pnlThongTin.BorderStyle = BorderStyle.FixedSingle;

                    Label lblMaTitle = new Label();
                    lblMaTitle.Text = placeholderMa;
                    lblMaTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    lblMaTitle.ForeColor = mauChu;
                    lblMaTitle.AutoSize = true;

                    Label lblTenTitle = new Label();
                    lblTenTitle.Text = placeholderTen;
                    lblTenTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    lblTenTitle.ForeColor = mauChu;
                    lblTenTitle.AutoSize = true;

                    StyleTextBox(txtMa);
                    StyleTextBox(txtTen);

                    labelMa.Visible = false;
                    labelTen.Visible = false;
                    labelGhiChu.Visible = false;
                    txtGhiChuTab.Visible = false;

                    pnlThongTin.Controls.AddRange(new Control[]
                    {
                lblMaTitle,
                txtMa,
                lblTenTitle,
                txtTen
                    });
                    // TIÊU ĐỀ CHỨC NĂNG
                    Label lblChucNang = new Label();
                    lblChucNang.Text = "CHỨC NĂNG";
                    lblChucNang.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                    lblChucNang.ForeColor = mauChu;
                    lblChucNang.AutoSize = true;
                    lblChucNang.UseCompatibleTextRendering = true;
                    // NHÓM NÚT
                    Panel pnlButtons = new Panel();
                    pnlButtons.BackColor = Color.White;
                    pnlButtons.BorderStyle = BorderStyle.FixedSingle;

                    StyleButton(btnThemTab, mauXanh, Color.White);
                    StyleButton(btnSuaTab, Color.FromArgb(36, 155, 110), Color.White);
                    StyleButton(btnXoaTab, mauDo, Color.White);
                    StyleButton(btnLamLaiTab, mauXam, Color.White);
                    StyleButton(btnThoatTab, Color.FromArgb(70, 82, 100), Color.White);

                    pnlButtons.Controls.AddRange(new Control[]
                    {
                btnThemTab,
                btnSuaTab,
                btnXoaTab,
                btnLamLaiTab,
                btnThoatTab
                    });

                    // TIÊU ĐỀ DANH SÁCH
                    Label lblDanhSach = new Label();
                    lblDanhSach.Text = "DANH SÁCH DỮ LIỆU";
                    lblDanhSach.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
                    lblDanhSach.ForeColor = mauChu;
                    lblDanhSach.AutoSize = true;

                    // BẢNG DỮ LIỆU
                    StyleGrid(dgv);

                    // ĐẶT LẠI TIÊU ĐỀ CỘT SAU KHI NẠP DỮ LIỆU
                    dgv.DataBindingComplete += (sender, e) =>
                    {
                        if (dgv.Columns.Count >= 2)
                        {
                            dgv.Columns[0].HeaderText = placeholderMa;
                            dgv.Columns[1].HeaderText = placeholderTen;

                            dgv.Columns[0].FillWeight = 40;
                            dgv.Columns[1].FillWeight = 60;
                        }

                        dgv.EnableHeadersVisualStyles = false;
                        dgv.ColumnHeadersVisible = true;
                        dgv.Refresh();
                    };

                    page.Controls.AddRange(new Control[]
        {
            lblHeading,
            pnlThongTin,
            lblChucNang,
            pnlButtons,
            lblDanhSach,
            dgv
        });

                    // TỰ ĐỘNG BỐ TRÍ LẠI KHI ĐỔI KÍCH THƯỚC
                    Action layout = () =>
                    {
                        int pageWidth = page.ClientSize.Width;
                        int pageHeight = page.ClientSize.Height;

                        int margin = 18;
                        int contentWidth = Math.Max(300, pageWidth - margin * 2);

                        lblHeading.Location = new Point(margin, 12);

                        // Khung nhập liệu
                        int infoTop = 62;
                        int infoHeight = 140;

                        pnlThongTin.SetBounds(margin, infoTop, contentWidth, infoHeight);

                        int left = 22;
                        int gap = 30;
                        int availableWidth = Math.Max(300, contentWidth - 44);
                        int fieldWidth = Math.Max(180, (availableWidth - gap) / 2);

                        lblMaTitle.Location = new Point(left, 18);
                        txtMa.SetBounds(left, 52, fieldWidth, 34);

                        int secondX = left + fieldWidth + gap;

                        lblTenTitle.Location = new Point(secondX, 18);
                        txtTen.SetBounds(secondX, 52, Math.Max(180, availableWidth - fieldWidth - gap), 34);


                        // TIÊU ĐỀ CHỨC NĂNG
                        lblChucNang.Location = new Point(margin + 2, 205);

                        // KHUNG CHỨA CÁC NÚT CRUD
                        int buttonTop = 260;
                        int buttonHeight = 78;

                        pnlButtons.SetBounds(
                            margin,
                            buttonTop,
                            contentWidth,
                            buttonHeight
                        );

                        // TĂNG KÍCH THƯỚC NÚT
                        int buttonGap = 17;
                        int buttonX = 23;
                        int buttonY = 15;

                        int buttonWidth = 180;

                        btnThemTab.SetBounds(buttonX, buttonY, buttonWidth, 52);
                        buttonX += buttonWidth + buttonGap;

                        btnSuaTab.SetBounds(buttonX, buttonY, buttonWidth, 52);
                        buttonX += buttonWidth + buttonGap;

                        btnXoaTab.SetBounds(buttonX, buttonY, buttonWidth, 52);
                        buttonX += buttonWidth + buttonGap;

                        btnLamLaiTab.SetBounds(buttonX, buttonY, 195, 52);
                        buttonX += 195 + buttonGap;

                        btnThoatTab.SetBounds(buttonX, buttonY, buttonWidth, 52);

                        // TIÊU ĐỀ DANH SÁCH
                        int listTop = 335;
                        lblDanhSach.Location = new Point(margin + 2, listTop);

                        // BẢNG DỮ LIỆU
                        int gridTop = 390;
                        int gridHeight = Math.Max(150, pageHeight - gridTop - 16);

                        dgv.SetBounds(
                            margin,
                            gridTop,
                            contentWidth,
                            gridHeight
                        );

                    };

                    page.Resize += (sender, e) => layout();
                    layout();
                }

        private void StyleTextBox(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 11F);
            txt.ForeColor = mauChu;
            txt.BackColor = Color.FromArgb(250, 252, 255);
            txt.BorderStyle = BorderStyle.FixedSingle;
        }

        private void StyleButton(Button btn, Color backColor, Color foreColor)
        {
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }

        private void StyleGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.GridColor = mauVien;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersVisible = true;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = mauXanhDam;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);

            dgv.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv.ColumnHeadersDefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

            dgv.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.ColumnHeadersHeight = 42;

            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgv.DefaultCellStyle.ForeColor = mauChu;
            dgv.DefaultCellStyle.BackColor = Color.White;

            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(218, 232, 250);

            dgv.DefaultCellStyle.SelectionForeColor = mauChu;

            dgv.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(244, 248, 253);

            dgv.RowTemplate.Height = 36;

            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgv.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.ScrollBars = ScrollBars.Both;
        }
    }
}
