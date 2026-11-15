using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace QuanLyCuaHangDienThoai
{
    /// <summary>
    /// Form lập hóa đơn nhập hàng từ nhà cung cấp.
    /// Khi lưu, tầng DAL thực hiện một giao dịch: kiểm tra mã, thêm đầu hóa đơn,
    /// cộng tồn kho - cập nhật giá nhập và ghi chi tiết.
    /// </summary>
    public partial class Form8 : Form
    {
        private readonly HoaDonNhapBUS hoaDonNhapBus = new HoaDonNhapBUS();
        private readonly NhaCungCapBUS nhaCungCapBus = new NhaCungCapBUS();
        private readonly HangHoaBUS hangHoaBus = new HangHoaBUS();
        private readonly NhanVienBUS nhanVienBus = new NhanVienBUS();

        private readonly DataTable bangChiTiet = new DataTable();
        private bool hoaDonDaLuu = false;
        private bool dangNapDuLieu = false;

        public Form8()
        {
            InitializeComponent();
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

        private void NapDuLieuBanDau()
        {
            try
            {
                dangNapDuLieu = true;

                cboMaHang.Items.Clear();
                foreach (string ma in hangHoaBus.LayDanhSachMa()) cboMaHang.Items.Add(ma);

                cboNCC.Items.Clear();
                foreach (string ma in nhaCungCapBus.LayDanhSachMa()) cboNCC.Items.Add(ma);

                cboMaHDN.Items.Clear();
                DataTable dtHDN = hoaDonNhapBus.LayDanhSachMa();
                foreach (DataRow r in dtHDN.Rows) cboMaHDN.Items.Add(r["MaHDN"].ToString());

                // Nhân viên đang đăng nhập được điền sẵn vào hóa đơn nhập
                if (string.IsNullOrWhiteSpace(txtMaNV.Text) && !string.IsNullOrWhiteSpace(Form9.MaNVDangNhap))
                {
                    txtMaNV.Text = Form9.MaNVDangNhap;
                }

                if (!string.IsNullOrWhiteSpace(txtMaNV.Text))
                {
                    txtTenNV.Text = nhanVienBus.LayTen(txtMaNV.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu từ SQL Server. Hãy kiểm tra kết nối cơ sở dữ liệu.\n" + ex.Message,
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
                HangHoa? hang = hangHoaBus.LayTheoMa(cboMaHang.Text.Trim());

                if (hang == null)
                {
                    txtTenHang.Clear();
                    txtDonGiaNhap.Clear();
                }
                else
                {
                    txtTenHang.Text = hang.TenHang;
                    txtDonGiaNhap.Text = AppHelpers.DinhDangTien(hang.GiaNhap);
                }

                TinhThanhTien();
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không lấy được thông tin hàng: " + ex.Message);
            }
        }

        private void cboNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangNapDuLieu || string.IsNullOrWhiteSpace(cboNCC.Text)) return;

            try
            {
                NhaCungCap? ncc = nhaCungCapBus.LayThongTin(cboNCC.Text.Trim());

                if (ncc == null) return;

                txtMaNCC.Text = ncc.MaNCC;
                txtSDT.Text = ncc.SDT;
                txtDiaChi.Text = ncc.DiaChi;
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không lấy được thông tin nhà cung cấp: " + ex.Message);
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e) => TinhThanhTien();

        private void TinhThanhTien()
        {
            if (int.TryParse(txtSoLuong.Text.Trim(), out int sl) && sl > 0 &&
                AppHelpers.DocSoTien(txtDonGiaNhap.Text, out decimal gia) && gia > 0)
            {
                txtThanhTien.Text = AppHelpers.DinhDangTien(gia * sl);
            }
            else
            {
                txtThanhTien.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hoaDonDaLuu)
            {
                MessageBox.Show("Hóa đơn này đã lưu. Hãy bấm Thêm hóa đơn để tạo hóa đơn mới.");
                return;
            }

            string ma = cboMaHang.Text.Trim();

            if (ma == "")
            {
                MessageBox.Show("Bạn hãy chọn mã hàng.");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int sl) || sl <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên lớn hơn 0.");
                txtSoLuong.Focus();
                return;
            }

            if (!AppHelpers.DocSoTien(txtDonGiaNhap.Text, out decimal gia) || gia <= 0)
            {
                MessageBox.Show("Đơn giá nhập không hợp lệ.");
                return;
            }

            foreach (DataRow row in bangChiTiet.Rows)
            {
                if (row["MaHang"].ToString() == ma)
                {
                    int slMoi = Convert.ToInt32(row["SoLuong"]) + sl;
                    row["SoLuong"] = slMoi;
                    row["DonGiaNhap"] = gia;
                    row["ThanhTien"] = gia * slMoi;
                    CapNhatTongTien();
                    LamMoiNhapHang();
                    return;
                }
            }

            bangChiTiet.Rows.Add(ma, txtTenHang.Text.Trim(), gia, sl, gia * sl);
            CapNhatTongTien();
            LamMoiNhapHang();
        }

        private void CapNhatTongTien()
        {
            decimal tong = 0;
            foreach (DataRow row in bangChiTiet.Rows) tong += Convert.ToDecimal(row["ThanhTien"]);
            lblTongTien.Text = "Tổng tiền: " + AppHelpers.DinhDangTien(tong) + " VNĐ";
        }

        private void LamMoiNhapHang()
        {
            cboMaHang.SelectedIndex = -1;
            txtTenHang.Clear();
            txtSoLuong.Clear();
            txtDonGiaNhap.Clear();
            txtThanhTien.Clear();
        }

        private void TaoMaHoaDonMoi()
        {
            cboMaHDN.Text = HoaDonNhap.TaoMaMoi();
            hoaDonDaLuu = false;
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            if (!hoaDonDaLuu && bangChiTiet.Rows.Count > 0)
            {
                if (!AppHelpers.XacNhan("Hóa đơn hiện tại chưa lưu. Bạn muốn bỏ các dòng đang nhập và tạo hóa đơn mới?"))
                    return;
            }

            bangChiTiet.Clear();
            cboNCC.SelectedIndex = -1;
            txtMaNCC.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            dtpNgayNhap.Value = DateTime.Today;
            LamMoiNhapHang();
            CapNhatTongTien();
            TaoMaHoaDonMoi();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (hoaDonDaLuu)
            {
                MessageBox.Show("Hóa đơn này đã được lưu.");
                return;
            }

            string maHDN = cboMaHDN.Text.Trim();

            if (maHDN == "")
            {
                MessageBox.Show("Bạn hãy nhập mã hóa đơn.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Mã nhân viên không tồn tại trong cơ sở dữ liệu.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cboNCC.Text))
            {
                MessageBox.Show("Bạn hãy chọn nhà cung cấp.");
                return;
            }

            if (bangChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn chưa có mặt hàng.");
                return;
            }

            var hd = new HoaDonNhap
            {
                MaHDN = maHDN,
                MaNV = txtMaNV.Text.Trim(),
                MaNCC = cboNCC.Text.Trim(),
                NgayLap = dtpNgayNhap.Value
            };

            foreach (DataRow row in bangChiTiet.Rows)
            {
                hd.ChiTietList.Add(new ChiTietHoaDonNhap(
                    hd.MaHDN,
                    row["MaHang"].ToString() ?? "",
                    row["TenHang"].ToString() ?? "",
                    Convert.ToInt32(row["SoLuong"]),
                    Convert.ToDecimal(row["DonGiaNhap"])));
            }

            hd.TinhTongTien();

            if (hoaDonNhapBus.LuuHoaDon(hd, out string error))
            {
                hoaDonDaLuu = true;

                if (!cboMaHDN.Items.Contains(maHDN)) cboMaHDN.Items.Add(maHDN);

                MessageBox.Show("Lưu hóa đơn nhập thành công!\nMã hóa đơn: " + maHDN + "\n" + lblTongTien.Text,
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không lưu được hóa đơn. Dữ liệu đã được hoàn tác.\n" + error,
                    "Lỗi lưu hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (hoaDonDaLuu)
            {
                MessageBox.Show("Hóa đơn đã lưu vào cơ sở dữ liệu nên không thể hủy bằng nút này. " +
                                "Nếu cần xóa hóa đơn, phải có chức năng xóa riêng để hoàn tác tồn kho.");
                return;
            }

            if (!AppHelpers.XacNhan("Bạn có chắc muốn xóa các mặt hàng đang nhập?")) return;

            bangChiTiet.Clear();
            cboNCC.SelectedIndex = -1;
            txtMaNCC.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            LamMoiNhapHang();
            CapNhatTongTien();
            TaoMaHoaDonMoi();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string maHDN = cboMaHDN.Text.Trim();

            if (maHDN == "")
            {
                MessageBox.Show("Hãy nhập hoặc chọn mã hóa đơn cần tìm.");
                return;
            }

            try
            {
                DataTable hd = hoaDonNhapBus.LayHoaDon(maHDN);

                if (hd.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn có mã " + maHDN + ".");
                    return;
                }

                DataRow r = hd.Rows[0];

                txtMaNV.Text = r["MaNV"].ToString();
                txtTenNV.Text = r["TenNV"].ToString();

                string maNCC = r["MaNCC"].ToString() ?? "";
                cboNCC.SelectedItem = maNCC;
                if (cboNCC.SelectedIndex < 0) cboNCC.Text = maNCC;

                txtMaNCC.Text = maNCC;
                txtSDT.Text = r["SDT"] == DBNull.Value ? "" : r["SDT"].ToString() ?? "";
                txtDiaChi.Text = r["DiaChi"] == DBNull.Value ? "" : r["DiaChi"].ToString() ?? "";
                dtpNgayNhap.Value = Convert.ToDateTime(r["NgayNhap"]);

                bangChiTiet.Clear();

                DataTable dtChiTiet = hoaDonNhapBus.LayChiTiet(maHDN);
                foreach (DataRow row in dtChiTiet.Rows)
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
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Lỗi tìm hóa đơn: " + ex.Message);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (bangChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel.");
                return;
            }

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

                sheet.Cell(1, 1).Value = "HÓA ĐƠN NHẬP HÀNG";
                var titleRange = sheet.Range("A1:E1");
                titleRange.Merge();
                titleRange.Style.Font.Bold = true;
                titleRange.Style.Font.FontSize = 16;
                titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                sheet.Cell(3, 1).Value = "Mã hóa đơn:";
                sheet.Cell(3, 2).Value = cboMaHDN.Text;
                sheet.Cell(4, 1).Value = "Ngày nhập:";
                sheet.Cell(4, 2).Value = dtpNgayNhap.Value.ToString("dd/MM/yyyy");
                sheet.Cell(5, 1).Value = "Mã nhân viên:";
                sheet.Cell(5, 2).Value = txtMaNV.Text;
                sheet.Cell(6, 1).Value = "Tên nhân viên:";
                sheet.Cell(6, 2).Value = txtTenNV.Text;
                sheet.Cell(7, 1).Value = "Mã NCC:";
                sheet.Cell(7, 2).Value = txtMaNCC.Text;
                sheet.Cell(8, 1).Value = "Số điện thoại:";
                sheet.Cell(8, 2).Value = txtSDT.Text;
                sheet.Cell(9, 1).Value = "Địa chỉ:";
                sheet.Cell(9, 2).Value = txtDiaChi.Text;

                string[] headers = { "Mã hàng", "Tên hàng", "Đơn giá nhập", "Số lượng", "Thành tiền" };
                for (int i = 0; i < headers.Length; i++)
                {
                    var hcell = sheet.Cell(11, i + 1);
                    hcell.Value = headers[i];
                    hcell.Style.Font.Bold = true;
                    hcell.Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
                    hcell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }

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

                dong++;
                sheet.Cell(dong, 4).Value = "TỔNG TIỀN:";
                sheet.Cell(dong, 4).Style.Font.Bold = true;
                sheet.Cell(dong, 5).Value = tong;
                sheet.Cell(dong, 5).Style.Font.Bold = true;
                sheet.Cell(dong, 5).Style.NumberFormat.Format = "#,##0";

                sheet.Columns().AdjustToContents();
                wb.SaveAs(sfd.FileName);

                AppHelpers.GhiLog($"Xuất hóa đơn nhập Excel {cboMaHDN.Text}: {sfd.FileName}");
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

        private void btnThoat_Click(object sender, EventArgs e) => Close();

        // Hàm này được nối sẵn trong Form8.Designer.cs.
        private void label1_Click(object? sender, EventArgs e) { }
    }
}
