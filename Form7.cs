using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form7 : Form
    {
        private readonly NhanVienBUS nhanVienBus = new NhanVienBUS();
        private readonly KhachHangBUS khachHangBus = new KhachHangBUS();
        private readonly HangHoaBUS hangHoaBus = new HangHoaBUS();
        private readonly HoaDonBanBUS hoaDonBanBus = new HoaDonBanBUS();

        private readonly DataTable bangChiTiet = new DataTable();
        private bool hoaDonDaTonTai = false;

        public Form7()
        {
            InitializeComponent();

            TaoGiaoDien();

            // Tao bang chi tiet hoa don
            bangChiTiet.Columns.Add("MaHang", typeof(string));
            bangChiTiet.Columns.Add("TenHang", typeof(string));
            bangChiTiet.Columns.Add("DonGia", typeof(decimal));
            bangChiTiet.Columns.Add("SoLuong", typeof(int));
            bangChiTiet.Columns.Add("GiamGia", typeof(decimal));
            bangChiTiet.Columns.Add("ThanhTien", typeof(decimal));

            dgvChiTiet.DataSource = bangChiTiet;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Cau hinh cac o chi doc
            txtTenHang.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtDiaChi.ReadOnly = true;

            // Cho phep nhap ma de tim nhanh
            txtMaNV.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtMaNV.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtMaKH.ReadOnly = false;
            txtMaKH.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtMaKH.AutoCompleteSource = AutoCompleteSource.CustomSource;

            cboMaHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaHD.DropDownStyle = ComboBoxStyle.DropDown;

            // Gan su kien: go bo truoc de tranh xu ly hai lan
            cboMaHang.SelectedIndexChanged -= cboMaHang_SelectedIndexChanged;
            cboMaHang.SelectedIndexChanged += cboMaHang_SelectedIndexChanged;

            txtSoLuong.TextChanged -= txtSoLuong_TextChanged;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;

            txtGiamGia.TextChanged -= txtGiamGia_TextChanged;
            txtGiamGia.TextChanged += txtGiamGia_TextChanged;

            txtMaNV.TextChanged -= txtMaNV_TextChanged;
            txtMaNV.TextChanged += txtMaNV_TextChanged;

            txtMaKH.TextChanged -= txtMaKH_TextChanged;
            txtMaKH.TextChanged += txtMaKH_TextChanged;

            btnThemHang.Click -= btnThemHang_Click;
            btnThemHang.Click += btnThemHang_Click;

            btnThemHD.Click -= btnThemHD_Click;
            btnThemHD.Click += btnThemHD_Click;

            btnHuy.Click -= btnHuy_Click;
            btnHuy.Click += btnHuy_Click;

            btnLuu.Click -= btnLuu_Click;
            btnLuu.Click += btnLuu_Click;

            btnTim.Click -= btnTim_Click;
            btnTim.Click += btnTim_Click;

            btnThoat.Click -= btnThoat_Click;
            btnThoat.Click += btnThoat_Click;

            btnIn.Click -= btnIn_Click;
            btnIn.Click += btnIn_Click;

            dgvChiTiet.CellClick -= dgvChiTiet_CellClick;
            dgvChiTiet.CellClick += dgvChiTiet_CellClick;

            dtpNgayLap.Value = DateTime.Today;
            lblTongTien.Text = "Tổng tiền: 0 VNĐ";

            NapDanhSachNhanVien();
            NapDanhSachKhachHang();
            NapDanhSachHang();
            NapDanhSachHoaDon();
        }

        // =========================
        // HAM KET NOI VA DOC DU LIEU
        // =========================

        private void NapDanhSachNhanVien()
        {
            try
            {
                AutoCompleteStringCollection danhSach =
                    new AutoCompleteStringCollection();

                DataTable dt = nhanVienBus.LayDanhSachMa();

                foreach (DataRow row in dt.Rows)
                {
                    danhSach.Add(row["MaNV"].ToString() ?? "");
                }

                txtMaNV.AutoCompleteCustomSource = danhSach;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách nhân viên:\n" + ex.Message);
            }
        }

        private void NapDanhSachKhachHang()
        {
            try
            {
                AutoCompleteStringCollection danhSach =
                    new AutoCompleteStringCollection();

                DataTable dt = khachHangBus.LayDanhSachMa();

                foreach (DataRow row in dt.Rows)
                {
                    danhSach.Add(row["MaKH"].ToString() ?? "");
                }

                txtMaKH.AutoCompleteCustomSource = danhSach;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách khách hàng:\n" + ex.Message);
            }
        }

        private void NapDanhSachHang()
        {
            try
            {
                DataTable dt = hangHoaBus.LayDanhSachMa();

                cboMaHang.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    cboMaHang.Items.Add(row["MaHang"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách hàng hóa:\n" + ex.Message);
            }
        }

        private void NapDanhSachHoaDon()
        {
            try
            {
                DataTable dt = hoaDonBanBus.LayDanhSachMa();

                cboMaHD.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    cboMaHD.Items.Add(row["MaHDB"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách hóa đơn:\n" + ex.Message);
            }
        }

        // =========================
        // CHON NHAN VIEN
        // =========================

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();

            if (maNV == "")
            {
                txtTenNV.Clear();
                return;
            }

            try
            {
                DataTable dt = nhanVienBus.LayTen(maNV);

                txtTenNV.Text = dt.Rows.Count == 0 || dt.Rows[0]["TenNV"] == DBNull.Value
                    ? ""
                    : dt.Rows[0]["TenNV"].ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không lấy được thông tin nhân viên:\n" + ex.Message);
            }
        }

        // =========================
        // CHON KHACH HANG
        // =========================

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();

            if (maKH == "")
            {
                txtTenKH.Clear();
                txtSDT.Clear();
                txtDiaChi.Clear();
                return;
            }

            try
            {
                DataTable dt = khachHangBus.LayThongTin(maKH);

                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];

                    txtTenKH.Text = r["TenKH"].ToString() ?? "";
                    txtSDT.Text = r["SDT"] == DBNull.Value ? "" : r["SDT"].ToString() ?? "";
                    txtDiaChi.Text = r["DiaChi"] == DBNull.Value ? "" : r["DiaChi"].ToString() ?? "";
                }
                else
                {
                    txtTenKH.Clear();
                    txtSDT.Clear();
                    txtDiaChi.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không lấy được thông tin khách hàng:\n" + ex.Message);
            }
        }

        // =========================
        // CHON HANG HOA
        // =========================

        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maHang = cboMaHang.Text.Trim();

            if (maHang == "")
            {
                txtTenHang.Clear();
                txtDonGia.Clear();
                txtThanhTien.Clear();
                return;
            }

            try
            {
                DataTable dt = hangHoaBus.LayThongTin(maHang);

                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];

                    txtTenHang.Text = r["TenHang"].ToString() ?? "";

                    decimal gia = Convert.ToDecimal(r["DonGiaBan"]);

                    txtDonGia.Text = gia.ToString("N0");
                }
                else
                {
                    txtTenHang.Clear();
                    txtDonGia.Clear();
                }

                TinhThanhTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không lấy được thông tin hàng hóa:\n" + ex.Message);
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        // Doc so tien, ho tro dinh dang hien thi co dau phan cach
        private bool DocSoTien(string chuoi, out decimal giaTri)
        {
            chuoi = chuoi.Trim();

            if (decimal.TryParse(
                chuoi,
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out giaTri))
            {
                return true;
            }

            return decimal.TryParse(
                chuoi,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out giaTri);
        }

        private void TinhThanhTien()
        {
            decimal donGia, giamGia;
            int soLuong;

            if (DocSoTien(txtDonGia.Text, out donGia) &&
                int.TryParse(txtSoLuong.Text, out soLuong) &&
                DocSoTien(txtGiamGia.Text, out giamGia) &&
                soLuong > 0 &&
                giamGia >= 0 &&
                giamGia <= 100)
            {
                decimal thanhTien =
                    donGia * soLuong * (100 - giamGia) / 100;

                txtThanhTien.Text = thanhTien.ToString("N0");
            }
            else
            {
                txtThanhTien.Clear();
            }
        }

        // =========================
        // THEM MAT HANG
        // =========================

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            if (hoaDonDaTonTai)
            {
                MessageBox.Show(
                    "Đây là hóa đơn đã lưu. Hãy bấm Thêm hóa đơn để lập hóa đơn mới.");
                return;
            }

            string maHang = cboMaHang.Text.Trim();

            if (maHang == "" || txtTenHang.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn mã hàng!");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) ||
                soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên lớn hơn 0!");
                return;
            }

            if (!DocSoTien(txtGiamGia.Text, out decimal giamGia) ||
                giamGia < 0 || giamGia > 100)
            {
                MessageBox.Show("Giảm giá phải từ 0 đến 100%!");
                return;
            }

            if (!DocSoTien(txtDonGia.Text, out decimal donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return;
            }

            // Neu ma hang da co thi cong them so luong
            foreach (DataRow row in bangChiTiet.Rows)
            {
                if (row["MaHang"].ToString() == maHang)
                {
                    int soLuongMoi =
                        Convert.ToInt32(row["SoLuong"]) + soLuong;

                    decimal giamGiaCu =
                        Convert.ToDecimal(row["GiamGia"]);

                    if (giamGia != giamGiaCu)
                    {
                        MessageBox.Show(
                            "Mặt hàng này đã có trong hóa đơn với mức giảm giá khác. " +
                            "Hãy xóa dòng cũ trước khi thêm lại.");
                        return;
                    }

                    row["SoLuong"] = soLuongMoi;
                    row["ThanhTien"] =
                        donGia * soLuongMoi * (100 - giamGia) / 100;

                    TinhTongTien();
                    XoaThongTinHangDangChon();
                    return;
                }
            }

            decimal thanhTien =
                donGia * soLuong * (100 - giamGia) / 100;

            bangChiTiet.Rows.Add(
                maHang,
                txtTenHang.Text,
                donGia,
                soLuong,
                giamGia,
                thanhTien);

            TinhTongTien();
            XoaThongTinHangDangChon();
        }

        private void XoaThongTinHangDangChon()
        {
            cboMaHang.SelectedIndex = -1;
            txtTenHang.Clear();
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtGiamGia.Clear();
            txtThanhTien.Clear();
        }

        private void TinhTongTien()
        {
            HoaDonBan hoaDon = new HoaDonBan(maHD, maNV, maKH, dtpNgayLap.Value);

            if (!hoaDonBanBus.LuuHoaDon(hoaDon, bangChiTiet, out string error))
            {
                MessageBox.Show(
                    "Lưu hóa đơn thất bại:\n" + error,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            hoaDonDaTonTai = true;
            NapDanhSachHoaDon();

            MessageBox.Show(
                "Lưu hóa đơn thành công!\nTồn kho đã được cập nhật.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        // =========================
        // TIM HOA DON DA LUU
        // =========================

        private void btnTim_Click(object sender, EventArgs e)
        {
            string maHD = cboMaHD.Text.Trim();

            if (maHD == "")
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn mã hóa đơn cần tìm!");
                return;
            }

            try
            {
                DataTable dtHoaDon = hoaDonBanBus.LayHoaDon(maHD);

                if (dtHoaDon.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn này.");
                    return;
                }

                DataRow hd = dtHoaDon.Rows[0];

                txtMaNV.Text = hd["MaNV"].ToString() ?? "";
                txtTenNV.Text = hd["TenNV"].ToString() ?? "";

                txtMaKH.Text = hd["MaKH"] == DBNull.Value ? "" : hd["MaKH"].ToString() ?? "";
                txtTenKH.Text = hd["TenKH"] == DBNull.Value ? "" : hd["TenKH"].ToString() ?? "";
                txtSDT.Text = hd["SDT"] == DBNull.Value ? "" : hd["SDT"].ToString() ?? "";
                txtDiaChi.Text = hd["DiaChi"] == DBNull.Value ? "" : hd["DiaChi"].ToString() ?? "";

                dtpNgayLap.Value = Convert.ToDateTime(hd["NgayLap"]);

                bangChiTiet.Rows.Clear();

                foreach (DataRow row in hoaDonBanBus.LayChiTiet(maHD).Rows)
                {
                    bangChiTiet.Rows.Add(
                        row["MaHang"],
                        row["TenHang"],
                        row["DonGia"],
                        row["SoLuong"],
                        row["GiamGia"],
                        row["ThanhTien"]);
                }

                cboMaHD.Text = maHD;
                hoaDonDaTonTai = true;
                TinhTongTien();

                MessageBox.Show("Tìm thấy hóa đơn!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tìm hóa đơn:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // XOA MOT DONG CHI TIET
        // =========================

        private void dgvChiTiet_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.RowIndex >= bangChiTiet.Rows.Count)
                return;

            if (hoaDonDaTonTai)
            {
                MessageBox.Show(
                    "Đây là hóa đơn đã lưu. Không thể xóa dòng trực tiếp trên giao diện.");
                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có muốn xóa mặt hàng này khỏi hóa đơn đang lập?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan == DialogResult.Yes)
            {
                bangChiTiet.Rows.RemoveAt(e.RowIndex);
                TinhTongTien();
            }
        }

        // =========================
        // IN HOA DON
        // =========================


        private void btnIn_Click(object sender, EventArgs e)
        {
            if (bangChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn chưa có mặt hàng để xuất!");
                return;
            }

            string maHD = cboMaHD.Text.Trim();

            if (maHD == "")
            {
                MessageBox.Show("Vui lòng tạo hoặc tìm hóa đơn trước!");
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = "HoaDon_" + maHD + ".xlsx",
                Title = "Lưu hóa đơn Excel"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var wb = new XLWorkbook();
                var sheet = wb.Worksheets.Add("HoaDonBan");

                // Tiêu đề
                sheet.Cell(1, 1).Value = "HÓA ĐƠN BÁN HÀNG";
                var title = sheet.Range("A1:G1");
                title.Merge();
                title.Style.Font.Bold = true;
                title.Style.Font.FontSize = 16;
                title.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Thông tin hóa đơn
                sheet.Cell(3, 1).Value = "Mã hóa đơn:"; sheet.Cell(3, 2).Value = maHD;
                sheet.Cell(4, 1).Value = "Ngày lập:";    sheet.Cell(4, 2).Value = dtpNgayLap.Value.ToString("dd/MM/yyyy");
                sheet.Cell(5, 1).Value = "Mã nhân viên:"; sheet.Cell(5, 2).Value = txtMaNV.Text;
                sheet.Cell(6, 1).Value = "Tên nhân viên:"; sheet.Cell(6, 2).Value = txtTenNV.Text;
                sheet.Cell(5, 4).Value = "Mã khách hàng:"; sheet.Cell(5, 5).Value = txtMaKH.Text;
                sheet.Cell(6, 4).Value = "Tên khách hàng:"; sheet.Cell(6, 5).Value = txtTenKH.Text;
                sheet.Cell(7, 4).Value = "SĐT khách:"; sheet.Cell(7, 5).Value = txtSDT.Text;
                sheet.Cell(8, 4).Value = "Địa chỉ:"; sheet.Cell(8, 5).Value = txtDiaChi.Text;

                // Header bảng
                int dongTieuDe = 10;
                string[] headers = { "Mã hàng", "Tên hàng", "Đơn giá", "Số lượng", "Giảm giá (%)", "Thành tiền" };
                for (int i = 0; i < headers.Length; i++)
                {
                    var hcell = sheet.Cell(dongTieuDe, i + 1);
                    hcell.Value = headers[i];
                    hcell.Style.Font.Bold = true;
                    hcell.Style.Fill.BackgroundColor = XLColor.LightGray;
                    hcell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }

                // Dữ liệu
                int dong = dongTieuDe + 1;
                decimal tongTien = 0;
                foreach (DataRow row in bangChiTiet.Rows)
                {
                    sheet.Cell(dong, 1).Value = row["MaHang"].ToString();
                    sheet.Cell(dong, 2).Value = row["TenHang"].ToString();
                    sheet.Cell(dong, 3).Value = Convert.ToDecimal(row["DonGia"]);
                    sheet.Cell(dong, 3).Style.NumberFormat.Format = "#,##0";
                    sheet.Cell(dong, 4).Value = Convert.ToInt32(row["SoLuong"]);
                    sheet.Cell(dong, 5).Value = Convert.ToDecimal(row["GiamGia"]);
                    sheet.Cell(dong, 6).Value = Convert.ToDecimal(row["ThanhTien"]);
                    sheet.Cell(dong, 6).Style.NumberFormat.Format = "#,##0";
                    sheet.Range(dong, 1, dong, 6).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    tongTien += Convert.ToDecimal(row["ThanhTien"]);
                    dong++;
                }

                // Tổng tiền
                dong++;
                sheet.Cell(dong, 5).Value = "TỔNG TIỀN:";
                sheet.Cell(dong, 5).Style.Font.Bold = true;
                sheet.Cell(dong, 6).Value = tongTien;
                sheet.Cell(dong, 6).Style.Font.Bold = true;
                sheet.Cell(dong, 6).Style.NumberFormat.Format = "#,##0";

                sheet.Columns().AdjustToContents();
                wb.SaveAs(sfd.FileName);

                MessageBox.Show("Xuất hóa đơn Excel thành công!\n" + sfd.FileName,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = sfd.FileName,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất Excel thất bại:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // =====================================================
        // DỰNG GIAO DIỆN
        // Tách khỏi InitializeComponent() để màn [Design] của Visual Studio
        // luôn mở được: trình thiết kế không đọc được vòng lặp và biến cục bộ.
        // =====================================================
        private void TaoGiaoDien()
        {
                   // Khởi tạo Control
                   label1 = new Label();
                   groupBox1 = new GroupBox();
                   groupBox2 = new GroupBox();
                   groupBox3 = new GroupBox();
                   groupBox4 = new GroupBox();
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
                   label12 = new Label();
                   label13 = new Label();
                   label14 = new Label();
                   label15 = new Label();
                   cboMaHD = new ComboBox();
                   txtMaNV = new TextBox();
                   txtSDT = new TextBox();
                   txtTenKH = new TextBox();
                   txtTenNV = new TextBox();
                   dtpNgayLap = new DateTimePicker();
                   txtMaKH = new TextBox();
                   txtDiaChi = new TextBox();
                   cboMaHang = new ComboBox();
                   txtSoLuong = new TextBox();
                   txtTenHang = new TextBox();
                   txtGiamGia = new TextBox();
                   txtDonGia = new TextBox();
                   txtThanhTien = new TextBox();
                   btnTim = new Button();
                   btnThemHang = new Button();
                   dgvChiTiet = new DataGridView();
                   lblTongTien = new Label();
                   btnThemHD = new Button();
                   btnLuu = new Button();
                   btnHuy = new Button();
                   btnIn = new Button();
                   btnThoat = new Button();
                   ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
                   // ==========================================
                   // FORM
                   // ==========================================
                   BackColor = mauNen;
                   Font = new Font("Segoe UI", 10F);
                   StartPosition = FormStartPosition.CenterScreen;
                   // Form con được Dock Fill trong Form10.
                   // Không đặt kích thước cố định hoặc WindowState Maximized.
                   Dock = DockStyle.Fill;
                   AutoScroll = false;
                   // ==========================================
                   // BỐ CỤC TỔNG
                   // ==========================================
                   TableLayoutPanel tblMain = new TableLayoutPanel
                   {
                       Dock = DockStyle.Fill,
                       ColumnCount = 1,
                       RowCount = 5,
                       BackColor = mauNen,
                       Padding = new Padding(8),
                       Margin = Padding.Empty
                   };
                   tblMain.RowStyles.Add(
            new RowStyle(SizeType.Absolute, 80F));
                   tblMain.RowStyles.Add(
                       new RowStyle(SizeType.Absolute, 320F));
                   tblMain.RowStyles.Add(
                       new RowStyle(SizeType.Absolute, 280F));
                   tblMain.RowStyles.Add(
                       new RowStyle(SizeType.Percent, 100F));
                   tblMain.RowStyles.Add(
                       new RowStyle(SizeType.Absolute, 110F));
                   // ==========================================
                   // TIÊU ĐỀ
                   // ==========================================
                   label1.Text = "HÓA ĐƠN BÁN HÀNG";
                   label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
                   label1.ForeColor = mauXanhDam;
                   label1.Dock = DockStyle.Fill;
                   label1.TextAlign = ContentAlignment.MiddleLeft;
                   label1.Margin = new Padding(5, 0, 0, 4);
                   label1.Click += label1_Click;
                   tblMain.Controls.Add(label1, 0, 0);
                   // ==========================================
                   // GROUPBOX 1 - THÔNG TIN CHUNG
                   // ==========================================
                   SetupGroupBox(groupBox1, "THÔNG TIN CHUNG");
                   groupBox1.Dock = DockStyle.Fill;
                   groupBox1.Margin = new Padding(0, 0, 0, 7);
                   groupBox1.Padding = new Padding(8, 12, 8, 5);
                   TableLayoutPanel tblThongTin = new TableLayoutPanel
                   {
                       Dock = DockStyle.Fill,
                       ColumnCount = 3,
                       RowCount = 3,
                       BackColor = Color.White,
                       Margin = Padding.Empty,
                       Padding = Padding.Empty
                   };
                   for (int i = 0; i < 3; i++)
                   {
                       tblThongTin.ColumnStyles.Add(
                           new ColumnStyle(SizeType.Percent, 33.33F));
                       tblThongTin.RowStyles.Add(
                           new RowStyle(SizeType.Percent, 33.33F));
                   }
                   // Hàng 1
                   Panel pnlMaHD = CreateFieldWithSearch(
                       label2, "Mã hóa đơn", cboMaHD, btnTim);
                   tblThongTin.Controls.Add(pnlMaHD, 0, 0);
                   tblThongTin.Controls.Add(
                       CreateField(label6, "Ngày lập", dtpNgayLap), 1, 0);
                   tblThongTin.Controls.Add(
                       CreateField(label3, "Mã nhân viên", txtMaNV), 2, 0);
                   // Hàng 2
                   tblThongTin.Controls.Add(
                       CreateField(label7, "Tên nhân viên", txtTenNV), 0, 1);
                   tblThongTin.Controls.Add(
                       CreateField(label8, "Mã khách hàng", txtMaKH), 1, 1);
                   tblThongTin.Controls.Add(
                       CreateField(label4, "SĐT khách", txtSDT), 2, 1);
                   // Hàng 3
                   tblThongTin.Controls.Add(
                       CreateField(label5, "Tên khách", txtTenKH), 0, 2);
                   Panel pnlDiaChi = CreateField(label9, "Địa chỉ", txtDiaChi);
                   tblThongTin.Controls.Add(pnlDiaChi, 1, 2);
                   tblThongTin.SetColumnSpan(pnlDiaChi, 2);
                   groupBox1.Controls.Add(tblThongTin);
                   tblMain.Controls.Add(groupBox1, 0, 1);
                   // ==========================================
                   // GROUPBOX 2 - CHỌN MẶT HÀNG
                   // ==========================================
                   SetupGroupBox(groupBox2, "CHỌN MẶT HÀNG");
                   groupBox2.Dock = DockStyle.Fill;
                   groupBox2.Margin = new Padding(0, 0, 0, 7);
                   groupBox2.Padding = new Padding(8, 12, 8, 5);
                   groupBox2.Location = new Point(18, 320);
                   TableLayoutPanel tblMatHang = new TableLayoutPanel
                   {
                       Dock = DockStyle.Fill,
                       ColumnCount = 4,
                       RowCount = 2,
                       BackColor = Color.White,
                       Margin = Padding.Empty,
                       Padding = Padding.Empty
                   };
                   tblMatHang.ColumnStyles.Add(
                       new ColumnStyle(SizeType.Percent, 24F));
                   tblMatHang.ColumnStyles.Add(
                       new ColumnStyle(SizeType.Percent, 24F));
                   tblMatHang.ColumnStyles.Add(
                       new ColumnStyle(SizeType.Percent, 24F));
                   tblMatHang.ColumnStyles.Add(
                       new ColumnStyle(SizeType.Percent, 28F));
                   tblMatHang.RowStyles.Add(
                       new RowStyle(SizeType.Percent, 50F));
                   tblMatHang.RowStyles.Add(
                       new RowStyle(SizeType.Percent, 50F));
                   // Hàng 1
                   tblMatHang.Controls.Add(
                       CreateField(label10, "Mã hàng", cboMaHang), 0, 0);
                   tblMatHang.Controls.Add(
                       CreateField(label12, "Tên hàng", txtTenHang), 1, 0);
                   tblMatHang.Controls.Add(
                       CreateField(label14, "Đơn giá", txtDonGia), 2, 0);
                   // Hàng 2
                   tblMatHang.Controls.Add(
                       CreateField(label11, "Số lượng", txtSoLuong), 0, 1);
                   tblMatHang.Controls.Add(
                       CreateField(label13, "Giảm giá (%)", txtGiamGia), 1, 1);
                   tblMatHang.Controls.Add(
                       CreateField(label15, "Thành tiền", txtThanhTien), 2, 1);
                   label13.Click += label13_Click;
                   // Nút thêm hàng
                   btnThemHang.Text = "＋  Thêm hàng";
                   StyleButton(btnThemHang, mauXanhLa, Color.White);
                   btnThemHang.Dock = DockStyle.None;
                   btnThemHang.Anchor = AnchorStyles.None;
                   btnThemHang.Size = new Size(150, 42);
                   btnThemHang.Margin = new Padding(5);
                   tblMatHang.Controls.Add(btnThemHang, 3, 0);
                   tblMatHang.SetRowSpan(btnThemHang, 2);
                   groupBox2.Controls.Add(tblMatHang);
                   tblMain.Controls.Add(groupBox2, 0, 2);
                   // ==========================================
                   // GROUPBOX 3 - CHI TIẾT HÓA ĐƠN
                   // ==========================================
                   SetupGroupBox(groupBox3, "CHI TIẾT HÓA ĐƠN");
                   groupBox3.Dock = DockStyle.Fill;
                   groupBox3.Margin = new Padding(0, 0, 0, 7);
                   groupBox3.Padding = new Padding(8, 12, 8, 5);
                   TableLayoutPanel tblChiTiet = new TableLayoutPanel
                   {
                       Dock = DockStyle.Fill,
                       ColumnCount = 1,
                       RowCount = 2,
                       BackColor = Color.White,
                       Margin = Padding.Empty,
                       Padding = Padding.Empty
                   };
                   tblChiTiet.ColumnStyles.Add(
                       new ColumnStyle(SizeType.Percent, 100F));
                   tblChiTiet.RowStyles.Add(
                       new RowStyle(SizeType.Percent, 100F));
                   tblChiTiet.RowStyles.Add(
                       new RowStyle(SizeType.Absolute, 38F));
                   // DataGridView
                   dgvChiTiet.Dock = DockStyle.Fill;
                   dgvChiTiet.BackgroundColor = Color.White;
                   dgvChiTiet.BorderStyle = BorderStyle.None;
                   dgvChiTiet.GridColor = mauVien;
                   dgvChiTiet.EnableHeadersVisualStyles = false;
                   dgvChiTiet.ColumnHeadersDefaultCellStyle.BackColor = mauXanhDam;
                   dgvChiTiet.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                   dgvChiTiet.ColumnHeadersDefaultCellStyle.Font =
                       new Font("Segoe UI", 10F, FontStyle.Bold);
                   dgvChiTiet.ColumnHeadersDefaultCellStyle.Alignment =
                       DataGridViewContentAlignment.MiddleCenter;
                   dgvChiTiet.DefaultCellStyle.Font =
                       new Font("Segoe UI", 9.5F);
                   dgvChiTiet.DefaultCellStyle.ForeColor = mauChu;
                   dgvChiTiet.DefaultCellStyle.BackColor = Color.White;
                   dgvChiTiet.DefaultCellStyle.SelectionBackColor =
                       Color.FromArgb(218, 232, 250);
                   dgvChiTiet.DefaultCellStyle.SelectionForeColor = mauChu;
                   dgvChiTiet.AlternatingRowsDefaultCellStyle.BackColor =
                       Color.FromArgb(244, 248, 253);
                   dgvChiTiet.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.Fill;
                   dgvChiTiet.SelectionMode =
                       DataGridViewSelectionMode.FullRowSelect;
                   dgvChiTiet.MultiSelect = false;
                   dgvChiTiet.ReadOnly = true;
                   dgvChiTiet.AllowUserToAddRows = false;
                   dgvChiTiet.AllowUserToDeleteRows = false;
                   dgvChiTiet.RowHeadersVisible = false;
                   dgvChiTiet.RowTemplate.Height = 32;
                   dgvChiTiet.ColumnHeadersHeight = 38;
                   dgvChiTiet.ColumnHeadersHeightSizeMode =
                       DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                   // Tổng tiền
                   lblTongTien.Text = "Tổng tiền: 0 VNĐ";
                   lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                   lblTongTien.ForeColor = mauDo;
                   lblTongTien.Dock = DockStyle.Fill;
                   lblTongTien.TextAlign = ContentAlignment.MiddleRight;
                   lblTongTien.Margin = new Padding(0, 0, 8, 0);
                   tblChiTiet.Controls.Add(dgvChiTiet, 0, 0);
                   tblChiTiet.Controls.Add(lblTongTien, 0, 1);
                   groupBox3.Controls.Add(tblChiTiet);
                   tblMain.Controls.Add(groupBox3, 0, 3);
                   // ==========================================
                   // GROUPBOX 4 - CHỨC NĂNG
                   // ==========================================
                   SetupGroupBox(groupBox4, "CHỨC NĂNG");
                   groupBox4.Dock = DockStyle.Fill;
                   groupBox4.Margin = Padding.Empty;
                   groupBox4.Padding = new Padding(8, 10, 8, 5);
                   FlowLayoutPanel flpChucNang = new FlowLayoutPanel
                   {
                       Dock = DockStyle.Fill,
                       FlowDirection = FlowDirection.LeftToRight,
                       WrapContents = false,
                       AutoScroll = true,
                       BackColor = Color.White,
                       Padding = new Padding(2, 5, 2, 2),
                       Margin = Padding.Empty
                   };
                   // Thêm hóa đơn
                   btnThemHD.Text = "＋  Thêm mới";
                   StyleButton(btnThemHD, mauXanh, Color.White);
                   btnThemHD.Size = new Size(125, 38);
                   // Lưu
                   btnLuu.Text = "✓  Lưu hóa đơn";
                   StyleButton(btnLuu, mauXanhLa, Color.White);
                   btnLuu.Size = new Size(135, 38);
                   // Hủy
                   btnHuy.Text = "✕  Hủy bỏ";
                   StyleButton(btnHuy, mauDo, Color.White);
                   btnHuy.Size = new Size(125, 38);
                   // In hóa đơn
                   btnIn.Text = "▤  In hóa đơn";
                   StyleButton(btnIn, mauXam, Color.White);
                   btnIn.Size = new Size(140, 38);
                   // Thoát
                   btnThoat.Text = "←  Thoát";
                   StyleButton(btnThoat, Color.FromArgb(70, 82, 100), Color.White);
                   btnThoat.Size = new Size(115, 38);
                   flpChucNang.Controls.AddRange(new Control[]
                   {
                       btnThemHD,
                       btnLuu,
                       btnHuy,
                       btnIn,
                       btnThoat
                   });
                   groupBox4.Controls.Add(flpChucNang);
                   tblMain.Controls.Add(groupBox4, 0, 4);
                   // ==========================================
                   // HOÀN TẤT
                   // ==========================================
                   Controls.Add(tblMain);
                   ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
        }

        // =====================================================
        // CÁC HÀM HỖ TRỢ THIẾT KẾ
        // =====================================================
            private Panel CreateField(
                Label lbl,
                string title,
                Control input)
            {
                Panel pnl = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.White,
                    Padding = new Padding(4, 2, 8, 2),
                    Margin = new Padding(2)
                };

                TableLayoutPanel tbl = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 1,
                    RowCount = 2,
                    BackColor = Color.White,
                    Margin = Padding.Empty,
                    Padding = Padding.Empty
                };

                tbl.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 100F));

                tbl.RowStyles.Add(
        new RowStyle(SizeType.Absolute, 30F));

                tbl.RowStyles.Add(
                    new RowStyle(SizeType.Percent, 100F));

                lbl.Text = title;
                lbl.Dock = DockStyle.Fill;
                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                lbl.ForeColor = mauChu;
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                lbl.Margin = Padding.Empty;

                StyleInput(input);

                input.Dock = DockStyle.Fill;
                input.Margin = new Padding(0, 8, 0, 1);

                tbl.Controls.Add(lbl, 0, 0);
                tbl.Controls.Add(input, 0, 1);

                pnl.Controls.Add(tbl);

                return pnl;
            }

            private Panel CreateFieldWithSearch(
                Label lbl,
                string title,
                ComboBox cbo,
                Button btn)
            {
                Panel pnl = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.White,
                    Padding = new Padding(4, 2, 8, 2),
                    Margin = new Padding(2)
                };

                TableLayoutPanel tbl = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 1,
                    RowCount = 2,
                    BackColor = Color.White,
                    Margin = Padding.Empty,
                    Padding = Padding.Empty
                };

                tbl.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 100F));

                tbl.RowStyles.Add(
        new RowStyle(SizeType.Absolute, 30F));

                tbl.RowStyles.Add(
                    new RowStyle(SizeType.Percent, 100F));

                lbl.Text = title;
                lbl.Dock = DockStyle.Fill;
                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                lbl.ForeColor = mauChu;
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                lbl.Margin = Padding.Empty;

                TableLayoutPanel tblInput = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 2,
                    RowCount = 1,
                    Margin = new Padding(0, 8, 0, 1),
                    Padding = Padding.Empty
                };

                tblInput.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 100F));

                tblInput.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Absolute, 65F));

                tblInput.RowStyles.Add(
                    new RowStyle(SizeType.Percent, 100F));

                StyleInput(cbo);
                cbo.Dock = DockStyle.Fill;
                cbo.Margin = new Padding(0, 0, 4, 0);

                btn.Text = "⌕ Tìm";
                StyleButton(btn, mauXanh, Color.White);
                btn.Dock = DockStyle.Fill;
                btn.Margin = Padding.Empty;
                btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                tblInput.Controls.Add(cbo, 0, 0);
                tblInput.Controls.Add(btn, 1, 0);

                tbl.Controls.Add(lbl, 0, 0);
                tbl.Controls.Add(tblInput, 0, 1);

                pnl.Controls.Add(tbl);

                return pnl;
            }

        private void StyleInput(Control input)
        {
            input.Font = new Font("Segoe UI", 9.5F);
            input.ForeColor = mauChu;

            if (input is TextBox txt)
            {
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.BackColor = Color.FromArgb(250, 252, 255);
            }
            else if (input is ComboBox cbo)
            {
                cbo.DropDownStyle = ComboBoxStyle.DropDownList;
                cbo.FlatStyle = FlatStyle.Flat;
                cbo.BackColor = Color.White;
            }
            else if (input is DateTimePicker dtp)
            {
                dtp.Format = DateTimePickerFormat.Custom;
                dtp.CustomFormat = "dd/MM/yyyy";
            }
        }

        private void SetupGroupBox(GroupBox gb, string title)
        {
            gb.Text = title;
            gb.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gb.ForeColor = mauXanhDam;
            gb.BackColor = Color.White;
        }

        private void StyleButton(
            Button btn,
            Color backColor,
            Color foreColor)
        {
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }
    }
}
