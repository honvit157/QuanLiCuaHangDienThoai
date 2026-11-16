using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Form quản lý 4 danh mục tra cứu: hãng sản xuất, loại hàng, màu sắc, dung lượng.
    /// Bốn tab dùng chung một bộ xử lý nhưng gọi tầng BUS với <see cref="LoaiDanhMuc"/> khác nhau,
    /// nhờ vậy toàn bộ truy vấn vẫn nằm ở tầng DAL dưới dạng thủ tục lưu trữ.
    /// </summary>
    public partial class Form5 : Form
    {
        private readonly DanhMucBUS danhMucBus = new DanhMucBUS();

        public Form5()
        {
            InitializeComponent();

            // Bố cục co giãn + sự kiện lưới của 4 tab (trước đây nằm trong InitializeComponent)
            SetupTabLayout(tpHangSX, lblHeadingHangSX, pnlThongTinHangSX, lblMaTitleHangSX,
                txtMaHang, lblTenTitleHangSX, txtTenHang, lblChucNangHangSX, pnlButtonsHangSX,
                new[] { btnThem, btnSua, btnXoa, btnLamLai, btnThoat }, lblDanhSachHangSX, dgvHangSX,
                "Mã hãng sản xuất", "Tên hãng sản xuất");

            SetupTabLayout(tpLoai, lblHeadingLoai, pnlThongTinLoai, lblMaTitleLoai,
                textBox3, lblTenTitleLoai, textBox1, lblChucNangLoai, pnlButtonsLoai,
                new[] { button5, button4, button3, button2, button1 }, lblDanhSachLoai, dataGridView1,
                "Mã loại hàng", "Tên loại hàng");

            SetupTabLayout(tpMauSac, lblHeadingMauSac, pnlThongTinMauSac, lblMaTitleMauSac,
                textBox6, lblTenTitleMauSac, textBox4, lblChucNangMauSac, pnlButtonsMauSac,
                new[] { button10, button9, button8, button7, button6 }, lblDanhSachMauSac, dataGridView2,
                "Mã màu", "Tên màu");

            SetupTabLayout(tpDungLuong, lblHeadingDungLuong, pnlThongTinDungLuong, lblMaTitleDungLuong,
                textBox9, lblTenTitleDungLuong, textBox7, lblChucNangDungLuong, pnlButtonsDungLuong,
                new[] { button15, button14, button13, button12, button11 }, lblDanhSachDungLuong, dataGridView3,
                "Mã dung lượng", "Tên dung lượng");

            Load += Form5_Load;

            // TAB 1: HÃNG SẢN XUẤT
            btnThem.Click += (s, e) => ThaoTac(LoaiDanhMuc.HangSanXuat, txtMaHang, txtTenHang, LoadHangSX, "Them");
            btnSua.Click += (s, e) => ThaoTac(LoaiDanhMuc.HangSanXuat, txtMaHang, txtTenHang, LoadHangSX, "Sua");
            btnXoa.Click += (s, e) => ThaoTac(LoaiDanhMuc.HangSanXuat, txtMaHang, txtTenHang, LoadHangSX, "Xoa");
            btnLamLai.Click += (s, e) => LamLai(txtMaHang, txtTenHang);
            btnThoat.Click += (s, e) => Close();
            dgvHangSX.CellClick += (s, e) =>
                ChonDong(e, dgvHangSX, txtMaHang, txtTenHang, "MaHangSX", "TenHangSX");

            // TAB 2: LOẠI HÀNG - button5 = Thêm, button4 = Sửa, button3 = Xóa,
            //                        button2 = Làm lại, button1 = Thoát
            button5.Click += (s, e) => ThaoTac(LoaiDanhMuc.LoaiHang, textBox3, textBox1, LoadLoai, "Them");
            button4.Click += (s, e) => ThaoTac(LoaiDanhMuc.LoaiHang, textBox3, textBox1, LoadLoai, "Sua");
            button3.Click += (s, e) => ThaoTac(LoaiDanhMuc.LoaiHang, textBox3, textBox1, LoadLoai, "Xoa");
            button2.Click += (s, e) => LamLai(textBox3, textBox1);
            button1.Click += (s, e) => Close();
            dataGridView1.CellClick += (s, e) =>
                ChonDong(e, dataGridView1, textBox3, textBox1, "MaLoai", "TenLoai");

            // TAB 3: MÀU SẮC - button10 = Thêm, button9 = Sửa, button8 = Xóa,
            //                      button7 = Làm lại, button6 = Thoát
            button10.Click += (s, e) => ThaoTac(LoaiDanhMuc.MauSac, textBox6, textBox4, LoadMau, "Them");
            button9.Click += (s, e) => ThaoTac(LoaiDanhMuc.MauSac, textBox6, textBox4, LoadMau, "Sua");
            button8.Click += (s, e) => ThaoTac(LoaiDanhMuc.MauSac, textBox6, textBox4, LoadMau, "Xoa");
            button7.Click += (s, e) => LamLai(textBox6, textBox4);
            button6.Click += (s, e) => Close();
            dataGridView2.CellClick += (s, e) =>
                ChonDong(e, dataGridView2, textBox6, textBox4, "MaMau", "TenMau");

            // TAB 4: DUNG LƯỢNG - button15 = Thêm, button14 = Sửa, button13 = Xóa,
            //                        button12 = Làm lại, button11 = Thoát
            button15.Click += (s, e) => ThaoTac(LoaiDanhMuc.DungLuong, textBox9, textBox7, LoadDungLuong, "Them");
            button14.Click += (s, e) => ThaoTac(LoaiDanhMuc.DungLuong, textBox9, textBox7, LoadDungLuong, "Sua");
            button13.Click += (s, e) => ThaoTac(LoaiDanhMuc.DungLuong, textBox9, textBox7, LoadDungLuong, "Xoa");
            button12.Click += (s, e) => LamLai(textBox9, textBox7);
            button11.Click += (s, e) => Close();
            dataGridView3.CellClick += (s, e) =>
                ChonDong(e, dataGridView3, textBox9, textBox7, "MaDungLuong", "TenDungLuong");
        }

        // ------------------------------------------------------------------
        // BỐ CỤC CO GIÃN CỦA MỘT TAB DANH MỤC
        // ------------------------------------------------------------------
        /// <summary>
        /// Giữ đúng bố cục và sự kiện của từng tab như trước đây: tiêu đề, khung nhập,
        /// nhóm nút CRUD và lưới dữ liệu tự co giãn theo kích thước tab.
        /// </summary>
        private static void SetupTabLayout(
            TabPage page, Label lblHeading, Panel pnlThongTin,
            Label lblMaTitle, TextBox txtMa, Label lblTenTitle, TextBox txtTen,
            Label lblChucNang, Panel pnlButtons, Button[] buttons,
            Label lblDanhSach, DataGridView dgv,
            string tieuDeMa, string tieuDeTen)
        {
            dgv.DataBindingComplete += (sender, e) =>
            {
                if (dgv.Columns.Count >= 2)
                {
                    dgv.Columns[0].HeaderText = tieuDeMa;
                    dgv.Columns[1].HeaderText = tieuDeTen;

                    dgv.Columns[0].FillWeight = 40;
                    dgv.Columns[1].FillWeight = 60;
                }

                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersVisible = true;
                dgv.Refresh();
            };

            page.Resize += (sender, e) => LayoutTab(
                page, lblHeading, pnlThongTin, lblMaTitle, txtMa, lblTenTitle, txtTen,
                lblChucNang, pnlButtons, buttons, lblDanhSach, dgv);

            LayoutTab(page, lblHeading, pnlThongTin, lblMaTitle, txtMa, lblTenTitle, txtTen,
                lblChucNang, pnlButtons, buttons, lblDanhSach, dgv);
        }

        private static void LayoutTab(
            TabPage page, Label lblHeading, Panel pnlThongTin,
            Label lblMaTitle, TextBox txtMa, Label lblTenTitle, TextBox txtTen,
            Label lblChucNang, Panel pnlButtons, Button[] buttons,
            Label lblDanhSach, DataGridView dgv)
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

            // Tiêu đề chức năng
            lblChucNang.Location = new Point(margin + 2, 205);

            // Khung chứa các nút CRUD
            int buttonTop = 260;
            int buttonHeight = 78;

            pnlButtons.SetBounds(margin, buttonTop, contentWidth, buttonHeight);

            int[] buttonWidths = { 180, 180, 180, 195, 180 };
            int buttonGap = 17;
            int buttonX = 23;
            int buttonY = 15;

            for (int i = 0; i < buttons.Length && i < buttonWidths.Length; i++)
            {
                buttons[i].SetBounds(buttonX, buttonY, buttonWidths[i], 52);
                buttonX += buttonWidths[i] + buttonGap;
            }

            // Tiêu đề danh sách
            int listTop = 335;
            lblDanhSach.Location = new Point(margin + 2, listTop);

            // Bảng dữ liệu
            int gridTop = 390;
            int gridHeight = Math.Max(150, pageHeight - gridTop - 16);

            dgv.SetBounds(margin, gridTop, contentWidth, gridHeight);
        }

        // ------------------------------------------------------------------
        // KHỞI TẠO FORM
        // ------------------------------------------------------------------
        private void Form5_Load(object? sender, EventArgs e)
        {
            SetupDgv(dgvHangSX);
            SetupDgv(dataGridView1);
            SetupDgv(dataGridView2);
            SetupDgv(dataGridView3);

            // Cơ sở dữ liệu không có cột GhiChu: ẩn các ô ghi chú để tránh nhập mà không lưu được.
            txtGhiChu.Visible = false;
            label2.Visible = false;

            textBox2.Visible = false;
            label5.Visible = false;

            textBox5.Visible = false;
            label8.Visible = false;

            textBox8.Visible = false;
            label11.Visible = false;

            // Đặt lại tên nhãn cho từng tab
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

        private static void SetupDgv(DataGridView dgv)
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

        // ------------------------------------------------------------------
        // TẢI DỮ LIỆU TỪNG DANH MỤC QUA TẦNG BUS
        // ------------------------------------------------------------------
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

        // ------------------------------------------------------------------
        // CHỌN MỘT DÒNG TRÊN LƯỚI
        // ------------------------------------------------------------------
        private static void ChonDong(DataGridViewCellEventArgs e, DataGridView dgv,
                                     TextBox txtMa, TextBox txtTen, string cotMa, string cotTen)
        {
            if (e.RowIndex < 0) return;
            if (dgv.Rows[e.RowIndex].DataBoundItem is not System.Data.DataRowView r) return;

            txtMa.Text = r[cotMa]?.ToString() ?? "";
            txtTen.Text = r[cotTen]?.ToString() ?? "";
            txtMa.ReadOnly = true;
        }

        // ------------------------------------------------------------------
        // XỬ LÝ THÊM / SỬA / XÓA DÙNG CHUNG CHO 4 TAB
        // ------------------------------------------------------------------
        private void ThaoTac(LoaiDanhMuc loai, TextBox txtMa, TextBox txtTen, Action reload, string hanhDong)
        {
            string ma = txtMa.Text.Trim();
            string ten = txtTen.Text.Trim();
            string tenLoai = DanhMucBUS.LayTenDanhMuc(loai);

            switch (hanhDong)
            {
                case "Them":
                    if (txtMa.ReadOnly)
                    {
                        AppHelpers.HienCanhBao("Bạn đang chọn một danh mục có sẵn. Hãy bấm Làm lại trước khi thêm mới!");
                        return;
                    }

                    if (danhMucBus.Them(loai, ma, ten, out string loiThem))
                    {
                        AppHelpers.HienThongBao("Thêm danh mục thành công!");
                        reload();
                        LamLai(txtMa, txtTen);
                    }
                    else
                    {
                        AppHelpers.HienCanhBao(loiThem);
                    }
                    break;

                case "Sua":
                    if (!txtMa.ReadOnly || string.IsNullOrWhiteSpace(ma))
                    {
                        AppHelpers.HienCanhBao($"Vui lòng chọn {tenLoai} cần sửa trong danh sách!");
                        return;
                    }

                    if (danhMucBus.Sua(loai, ma, ten, out string loiSua))
                    {
                        AppHelpers.HienThongBao("Cập nhật danh mục thành công!");
                        reload();
                        LamLai(txtMa, txtTen);
                    }
                    else
                    {
                        AppHelpers.HienCanhBao(loiSua);
                    }
                    break;

                case "Xoa":
                    if (!txtMa.ReadOnly || string.IsNullOrWhiteSpace(ma))
                    {
                        AppHelpers.HienCanhBao($"Vui lòng chọn {tenLoai} cần xóa trong danh sách!");
                        return;
                    }

                    if (!AppHelpers.XacNhan($"Bạn có chắc chắn muốn xóa {tenLoai} {ma} không?")) return;

                    if (danhMucBus.Xoa(loai, ma, out string loiXoa))
                    {
                        AppHelpers.HienThongBao("Xóa danh mục thành công!");
                        reload();
                        LamLai(txtMa, txtTen);
                    }
                    else
                    {
                        AppHelpers.HienCanhBao(loiXoa);
                    }
                    break;
            }
        }

        private static void LamLai(TextBox txtMa, TextBox? txtTen)
        {
            txtMa.Clear();
            txtMa.ReadOnly = false;

            if (txtTen != null) txtTen.Clear();

            txtMa.Focus();
        }
    }
}
