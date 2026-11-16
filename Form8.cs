using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form8 : Form
    {
        private readonly NhanVienBUS nhanVienBus = new NhanVienBUS();
        private readonly HangHoaBUS hangHoaBus = new HangHoaBUS();
        private readonly NhaCungCapBUS nhaCungCapBus = new NhaCungCapBUS();
        private readonly HoaDonNhapBUS hoaDonNhapBus = new HoaDonNhapBUS();

        private readonly DataTable bangChiTiet = new DataTable();
        private bool hoaDonDaLuu = false;
        private bool dangNapDuLieu = false;

        public Form8()
        {
            InitializeComponent();

            TaoGiaoDien();
            KhoiTaoBangChiTiet();
            CauHinhGiaoDien();
            GanSuKien();
            NapDuLieuBanDau();
            TaoMaHoaDonMoi();
        }

        private void KhoiTaoBangChiTiet()
        {
            bangChiTiet.Columns.Add("MaHang", typeof(string));
            bangChiTiet.Columns.Add("TenHang", typeof(string));
            bangChiTiet.Columns.Add("DonGiaNhap", typeof(decimal));
            bangChiTiet.Columns.Add("SoLuong", typeof(int));
            bangChiTiet.Columns.Add("ThanhTien", typeof(decimal));

            dgvChiTiet.DataSource = bangChiTiet;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.Columns["MaHang"].HeaderText = "Mã hàng";
            dgvChiTiet.Columns["TenHang"].HeaderText = "Tên hàng";
            dgvChiTiet.Columns["DonGiaNhap"].HeaderText = "Đơn giá nhập";
            dgvChiTiet.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgvChiTiet.Columns["DonGiaNhap"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        private void CauHinhGiaoDien()
        {
            txtTenNV.ReadOnly = true;
            txtMaNCC.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtDonGiaNhap.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            cboMaHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNCC.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaHDN.DropDownStyle = ComboBoxStyle.DropDown;
            dtpNgayNhap.Value = DateTime.Today;
        }

        private void GanSuKien()
        {
            cboMaHang.SelectedIndexChanged -= cboMaHang_SelectedIndexChanged;
            cboMaHang.SelectedIndexChanged += cboMaHang_SelectedIndexChanged;
            cboNCC.SelectedIndexChanged -= cboNCC_SelectedIndexChanged;
            cboNCC.SelectedIndexChanged += cboNCC_SelectedIndexChanged;
            txtSoLuong.TextChanged -= txtSoLuong_TextChanged;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;
            txtMaNV.TextChanged -= txtMaNV_TextChanged;
            txtMaNV.TextChanged += txtMaNV_TextChanged;

            button1.Click -= button1_Click;
            button1.Click += button1_Click;
            btnThemHD.Click -= btnThemHD_Click;
            btnThemHD.Click += btnThemHD_Click;
            btnLuu.Click -= btnLuu_Click;
            btnLuu.Click += btnLuu_Click;
            btnHuy.Click -= btnHuy_Click;
            btnHuy.Click += btnHuy_Click;
            btnTim.Click -= btnTim_Click;
            btnTim.Click += btnTim_Click;
            btnThoat.Click -= btnThoat_Click;
            btnThoat.Click += btnThoat_Click;
            btnIn.Click -= btnIn_Click;
            btnIn.Click += btnIn_Click;
        }
        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();

            if (string.IsNullOrWhiteSpace(maNV))
            {
                txtTenNV.Clear();
                return;
            }

            try
            {
                txtTenNV.Text = LayTenNhanVien(maNV);
            }
            catch (Exception ex)
            {
                txtTenNV.Clear();

                MessageBox.Show(
                    "Không thể lấy thông tin nhân viên: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>Lấy tên nhân viên theo mã qua tầng nghiệp vụ.</summary>
        private string LayTenNhanVien(string maNV)
        {
            DataTable dt = nhanVienBus.LayTen(maNV);

            return dt.Rows.Count == 0 || dt.Rows[0]["TenNV"] == DBNull.Value
                ? ""
                : dt.Rows[0]["TenNV"].ToString() ?? "";
        }

        private void NapDuLieuBanDau()
        {
            try
            {
                dangNapDuLieu = true;

                cboMaHang.Items.Clear();
                foreach (DataRow row in hangHoaBus.LayDanhSachMa().Rows)
                    cboMaHang.Items.Add(row["MaHang"].ToString());

                cboNCC.Items.Clear();
                foreach (DataRow row in nhaCungCapBus.LayDanhSachMa().Rows)
                    cboNCC.Items.Add(row["MaNCC"].ToString());

                cboMaHDN.Items.Clear();
                foreach (DataRow row in hoaDonNhapBus.LayDanhSachMa().Rows)
                    cboMaHDN.Items.Add(row["MaHDN"].ToString());

                if (!string.IsNullOrWhiteSpace(txtMaNV.Text))
                    txtTenNV.Text = LayTenNhanVien(txtMaNV.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu từ SQL Server. Hãy kiểm tra kết nối CSDL.\n" + ex.Message,
                    "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dangNapDuLieu = false;
            }
        }

        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangNapDuLieu || string.IsNullOrWhiteSpace(cboMaHang.Text)) return;

            try
            {
                DataTable dt = hangHoaBus.LayThongTin(cboMaHang.Text.Trim());

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtTenHang.Text = row["TenHang"].ToString() ?? "";
                    txtDonGiaNhap.Text = Convert.ToDecimal(row["DonGiaNhap"]).ToString("N0");
                }
                else
                {
                    txtTenHang.Clear();
                    txtDonGiaNhap.Clear();
                }

                TinhThanhTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không lấy được thông tin hàng: " + ex.Message);
            }
        }

        private void cboNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangNapDuLieu || string.IsNullOrWhiteSpace(cboNCC.Text)) return;

            try
            {
                DataTable dt = nhaCungCapBus.LayThongTin(cboNCC.Text.Trim());

                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];

                    txtMaNCC.Text = r["MaNCC"].ToString() ?? "";
                    txtSDT.Text = r["SDT"] == DBNull.Value ? "" : r["SDT"].ToString() ?? "";
                    txtDiaChi.Text = r["DiaChi"] == DBNull.Value ? "" : r["DiaChi"].ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không lấy được thông tin nhà cung cấp: " + ex.Message);
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e) { TinhThanhTien(); }

        private decimal DocDonGia()
        {
            decimal gia;
            string s = txtDonGiaNhap.Text.Trim().Replace(",", "").Replace(".", "");
            if (!decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out gia))
                decimal.TryParse(txtDonGiaNhap.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out gia);
            return gia;
        }

        private void TinhThanhTien()
        {
            int sl;
            decimal gia = DocDonGia();
            if (int.TryParse(txtSoLuong.Text.Trim(), out sl) && sl > 0 && gia > 0)
                txtThanhTien.Text = (gia * sl).ToString("N0");
            else txtThanhTien.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hoaDonDaLuu) { MessageBox.Show("Hóa đơn này đã lưu. Hãy bấm Thêm hóa đơn để tạo hóa đơn mới."); return; }
            string ma = cboMaHang.Text.Trim();
            int sl;
            decimal gia = DocDonGia();
            if (ma == "") { MessageBox.Show("Bạn hãy chọn mã hàng."); return; }
            if (!int.TryParse(txtSoLuong.Text.Trim(), out sl) || sl <= 0)
            { MessageBox.Show("Số lượng phải là số nguyên lớn hơn 0."); txtSoLuong.Focus(); return; }
            if (gia <= 0) { MessageBox.Show("Đơn giá nhập không hợp lệ."); return; }

            foreach (DataRow row in bangChiTiet.Rows)
            {
                if (row["MaHang"].ToString() == ma)
                {
                    int slMoi = Convert.ToInt32(row["SoLuong"]) + sl;
                    row["SoLuong"] = slMoi;
                    row["DonGiaNhap"] = gia;
                    row["ThanhTien"] = gia * slMoi;
                    CapNhatTongTien(); LamMoiNhapHang(); return;
                }
            }
            bangChiTiet.Rows.Add(ma, txtTenHang.Text.Trim(), gia, sl, gia * sl);
            CapNhatTongTien();
            LamMoiNhapHang();
        }

        private void CapNhatTongTien()
        {
            HoaDonNhap hoaDon = new HoaDonNhap(maHDN, maNV, maNCC, dtpNgayNhap.Value);

            if (!hoaDonNhapBus.LuuHoaDon(hoaDon, bangChiTiet, out string error))
            {
                MessageBox.Show("Không lưu được hóa đơn. Dữ liệu đã được hoàn tác.\n" + error,
                    "Lỗi lưu hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            hoaDonDaLuu = true;
            if (!cboMaHDN.Items.Contains(maHDN)) cboMaHDN.Items.Add(maHDN);

            MessageBox.Show("Lưu hóa đơn nhập thành công!\nMã hóa đơn: " + maHDN + "\n" + lblTongTien.Text,
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (hoaDonDaLuu)
            {
                MessageBox.Show("Hóa đơn đã lưu vào CSDL nên không thể hủy bằng nút này. Nếu cần xóa hóa đơn, phải có chức năng xóa riêng để hoàn tác tồn kho.");
                return;
            }
            DialogResult kq = MessageBox.Show("Bạn có chắc muốn xóa các mặt hàng đang nhập?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                bangChiTiet.Clear(); cboNCC.SelectedIndex = -1;
                txtMaNCC.Clear(); txtSDT.Clear(); txtDiaChi.Clear();
                LamMoiNhapHang(); CapNhatTongTien(); TaoMaHoaDonMoi();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string maHDN = cboMaHDN.Text.Trim();
            if (maHDN == "") { MessageBox.Show("Hãy nhập hoặc chọn mã hóa đơn cần tìm."); return; }

            try
            {
                DataTable hd = hoaDonNhapBus.LayHoaDon(maHDN);

                if (hd.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn có mã " + maHDN + ".");
                    return;
                }

                DataRow r = hd.Rows[0];

                txtMaNV.Text = r["MaNV"].ToString() ?? "";
                txtTenNV.Text = r["TenNV"].ToString() ?? "";

                cboNCC.SelectedItem = r["MaNCC"].ToString();
                if (cboNCC.SelectedIndex < 0) cboNCC.Text = r["MaNCC"].ToString();

                txtMaNCC.Text = r["MaNCC"].ToString() ?? "";
                txtSDT.Text = r["SDT"] == DBNull.Value ? "" : r["SDT"].ToString() ?? "";
                txtDiaChi.Text = r["DiaChi"] == DBNull.Value ? "" : r["DiaChi"].ToString() ?? "";
                dtpNgayNhap.Value = Convert.ToDateTime(r["NgayNhap"]);

                bangChiTiet.Clear();

                foreach (DataRow row in hoaDonNhapBus.LayChiTiet(maHDN).Rows)
                {
                    bangChiTiet.Rows.Add(
                        row["MaHang"].ToString(),
                        row["TenHang"].ToString(),
                        Convert.ToDecimal(row["DonGiaNhap"]),
                        Convert.ToInt32(row["SoLuong"]),
                        Convert.ToDecimal(row["ThanhTien"]));
                }

                CapNhatTongTien();
                hoaDonDaLuu = true;

                MessageBox.Show("Đã tải hóa đơn " + maHDN + ".");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tìm hóa đơn: " + ex.Message); }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (bangChiTiet.Rows.Count == 0) { MessageBox.Show("Không có dữ liệu để xuất Excel."); return; }

            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = "HoaDonNhap_" + cboMaHDN.Text + ".xlsx"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var wb = new XLWorkbook();
                var sheet = wb.Worksheets.Add("HoaDonNhap");

                // Tiêu đề
                sheet.Cell(1, 1).Value = "HÓA ĐƠN NHẬP HÀNG";
                var titleRange = sheet.Range("A1:E1");
                titleRange.Merge();
                titleRange.Style.Font.Bold = true;
                titleRange.Style.Font.FontSize = 16;
                titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Thông tin
                sheet.Cell(3, 1).Value = "Mã hóa đơn:";   sheet.Cell(3, 2).Value = cboMaHDN.Text;
                sheet.Cell(4, 1).Value = "Ngày nhập:";     sheet.Cell(4, 2).Value = dtpNgayNhap.Value.ToString("dd/MM/yyyy");
                sheet.Cell(5, 1).Value = "Mã nhân viên:";  sheet.Cell(5, 2).Value = txtMaNV.Text;
                sheet.Cell(6, 1).Value = "Tên nhân viên:"; sheet.Cell(6, 2).Value = txtTenNV.Text;
                sheet.Cell(7, 1).Value = "Mã NCC:";        sheet.Cell(7, 2).Value = txtMaNCC.Text;
                sheet.Cell(8, 1).Value = "Số điện thoại:"; sheet.Cell(8, 2).Value = txtSDT.Text;
                sheet.Cell(9, 1).Value = "Địa chỉ:";       sheet.Cell(9, 2).Value = txtDiaChi.Text;

                // Header bảng
                string[] headers = { "Mã hàng", "Tên hàng", "Đơn giá nhập", "Số lượng", "Thành tiền" };
                for (int i = 0; i < headers.Length; i++)
                {
                    var hcell = sheet.Cell(11, i + 1);
                    hcell.Value = headers[i];
                    hcell.Style.Font.Bold = true;
                    hcell.Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
                    hcell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }

                // Dữ liệu
                int dong = 12;
                decimal tong = 0;
                foreach (DataRow row in bangChiTiet.Rows)
                {
                    sheet.Cell(dong, 1).Value = row["MaHang"].ToString();
                    sheet.Cell(dong, 2).Value = row["TenHang"].ToString();
                    sheet.Cell(dong, 3).Value = Convert.ToDecimal(row["DonGiaNhap"]);
                    sheet.Cell(dong, 3).Style.NumberFormat.Format = "#,##0";
                    sheet.Cell(dong, 4).Value = Convert.ToInt32(row["SoLuong"]);
                    sheet.Cell(dong, 5).Value = Convert.ToDecimal(row["ThanhTien"]);
                    sheet.Cell(dong, 5).Style.NumberFormat.Format = "#,##0";
                    sheet.Range(dong, 1, dong, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    tong += Convert.ToDecimal(row["ThanhTien"]);
                    dong++;
                }

                // Tổng tiền
                dong++;
                sheet.Cell(dong, 4).Value = "TỔNG TIỀN:";
                sheet.Cell(dong, 4).Style.Font.Bold = true;
                sheet.Cell(dong, 5).Value = tong;
                sheet.Cell(dong, 5).Style.Font.Bold = true;
                sheet.Cell(dong, 5).Style.NumberFormat.Format = "#,##0";

                sheet.Columns().AdjustToContents();
                wb.SaveAs(sfd.FileName);

                MessageBox.Show("Xuất Excel thành công: " + sfd.FileName);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = sfd.FileName,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xuất được Excel.\n" + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e) { Close(); }

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
            // ==========================================
            // KHỞI TẠO CONTROL
            // ==========================================
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
            cboMaHDN = new ComboBox();
            txtMaNV = new TextBox();
            cboNCC = new ComboBox();
            txtSDT = new TextBox();
            dtpNgayNhap = new DateTimePicker();
            txtTenNV = new TextBox();
            txtMaNCC = new TextBox();
            txtDiaChi = new TextBox();
            cboMaHang = new ComboBox();
            txtTenHang = new TextBox();
            txtDonGiaNhap = new TextBox();
            txtSoLuong = new TextBox();
            txtThanhTien = new TextBox();
            btnTim = new Button();
            button1 = new Button();
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
            tblMain.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));
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
            label1.Text = "HÓA ĐƠN NHẬP HÀNG";
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
            tblThongTin.Controls.Add(
                CreateFieldWithSearch(
                    label2, "Mã hóa đơn nhập", cboMaHDN, btnTim),
                0, 0);
            tblThongTin.Controls.Add(
                CreateField(label6, "Ngày nhập", dtpNgayNhap),
                1, 0);
            tblThongTin.Controls.Add(
                CreateField(label3, "Mã nhân viên", txtMaNV),
                2, 0);
            // Hàng 2
            tblThongTin.Controls.Add(
                CreateField(label7, "Tên nhân viên", txtTenNV),
                0, 1);
            tblThongTin.Controls.Add(
                CreateField(label4, "Nhà cung cấp", cboNCC),
                1, 1);
            tblThongTin.Controls.Add(
                CreateField(label5, "SĐT nhà cung cấp", txtSDT),
                2, 1);
            // Hàng 3
            tblThongTin.Controls.Add(
                CreateField(label8, "Mã nhà cung cấp", txtMaNCC),
                0, 2);
            Panel pnlDiaChi = CreateField(
                label9, "Địa chỉ", txtDiaChi);
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
                CreateField(label10, "Mã hàng", cboMaHang),
                0, 0);
            tblMatHang.Controls.Add(
                CreateField(label12, "Tên hàng", txtTenHang),
                1, 0);
            tblMatHang.Controls.Add(
                CreateField(label14, "Đơn giá nhập", txtDonGiaNhap),
                2, 0);
            // Hàng 2
            tblMatHang.Controls.Add(
                CreateField(label11, "Số lượng", txtSoLuong),
                0, 1);
            Panel pnlThanhTien = CreateField(
                label13, "Thành tiền", txtThanhTien);
            tblMatHang.Controls.Add(pnlThanhTien, 1, 1);
            tblMatHang.SetColumnSpan(pnlThanhTien, 2);
            // Nút thêm mặt hàng
            button1.Text = "＋  Thêm hàng";
            StyleButton(button1, mauXanhLa, Color.White);
            button1.Dock = DockStyle.None;
            button1.Anchor = AnchorStyles.None;
            button1.Size = new Size(160, 42);
            button1.Margin = new Padding(5);
            tblMatHang.Controls.Add(button1, 3, 0);
            tblMatHang.SetRowSpan(button1, 2);
            groupBox2.Controls.Add(tblMatHang);
            tblMain.Controls.Add(groupBox2, 0, 2);
            // ==========================================
            // GROUPBOX 3 - CHI TIẾT HÓA ĐƠN
            // ==========================================
            SetupGroupBox(groupBox3, "CHI TIẾT HÓA ĐƠN NHẬP");
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
            dgvChiTiet.ColumnHeadersDefaultCellStyle.BackColor =
                mauXanhDam;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;
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
            lblTongTien.Font =
                new Font("Segoe UI", 12F, FontStyle.Bold);
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
            StyleButton(
                btnThoat,
                Color.FromArgb(70, 82, 100),
                Color.White);
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
