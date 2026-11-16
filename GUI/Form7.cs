using System;
using System.Data;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4.GUI
{
    /// <summary>
    /// Form lập hóa đơn bán hàng.
    /// Toàn bộ truy vấn (nhân viên, khách hàng, hàng hóa, hóa đơn) đều đi qua tầng BUS;
    /// việc lưu hóa đơn (kiểm tra trùng mã, trừ tồn kho, ghi đầu hóa đơn và chi tiết)
    /// được thực hiện trong một giao dịch ở tầng DAL bằng thủ tục lưu trữ.
    /// </summary>
    public partial class Form7 : Form
    {
        private readonly HoaDonBanBUS hoaDonBus = new HoaDonBanBUS();
        private readonly NhanVienBUS nhanVienBus = new NhanVienBUS();
        private readonly KhachHangBUS khachHangBus = new KhachHangBUS();
        private readonly HangHoaBUS hangHoaBus = new HangHoaBUS();

        private readonly DataTable bangChiTiet = new DataTable();
        private bool hoaDonDaTonTai = false;

        public Form7()
        {
            InitializeComponent();

            // Bảng chi tiết hóa đơn đang lập
            bangChiTiet.Columns.Add("MaHang", typeof(string));
            bangChiTiet.Columns.Add("TenHang", typeof(string));
            bangChiTiet.Columns.Add("DonGia", typeof(decimal));
            bangChiTiet.Columns.Add("SoLuong", typeof(int));
            bangChiTiet.Columns.Add("GiamGia", typeof(decimal));
            bangChiTiet.Columns.Add("ThanhTien", typeof(decimal));

            dgvChiTiet.DataSource = bangChiTiet;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Các ô chỉ đọc
            txtTenHang.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtDiaChi.ReadOnly = true;

            // Cho phép nhập mã để tìm nhanh
            txtMaNV.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtMaNV.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtMaKH.ReadOnly = false;
            txtMaKH.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtMaKH.AutoCompleteSource = AutoCompleteSource.CustomSource;

            cboMaHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaHD.DropDownStyle = ComboBoxStyle.DropDown;

            // Gỡ trước khi gắn để tránh xử lý hai lần
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

        // ==================================================================
        // NẠP DỮ LIỆU QUA TẦNG BUS
        // ==================================================================

        private void NapDanhSachNhanVien()
        {
            try
            {
                var danhSach = new AutoCompleteStringCollection();
                foreach (string ma in nhanVienBus.LayDanhSachMa()) danhSach.Add(ma);
                txtMaNV.AutoCompleteCustomSource = danhSach;
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không tải được danh sách nhân viên:\n" + ex.Message);
            }
        }

        private void NapDanhSachKhachHang()
        {
            try
            {
                var danhSach = new AutoCompleteStringCollection();
                foreach (string ma in khachHangBus.LayDanhSachMa()) danhSach.Add(ma);
                txtMaKH.AutoCompleteCustomSource = danhSach;
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không tải được danh sách khách hàng:\n" + ex.Message);
            }
        }

        private void NapDanhSachHang()
        {
            try
            {
                cboMaHang.Items.Clear();
                foreach (string ma in hangHoaBus.LayDanhSachMa()) cboMaHang.Items.Add(ma);
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không tải được danh sách hàng hóa:\n" + ex.Message);
            }
        }

        private void NapDanhSachHoaDon()
        {
            try
            {
                cboMaHD.Items.Clear();
                DataTable dt = hoaDonBus.LayDanhSachMa();
                foreach (DataRow r in dt.Rows) cboMaHD.Items.Add(r["MaHDB"].ToString());
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không tải được danh sách hóa đơn:\n" + ex.Message);
            }
        }

        // ==================================================================
        // CHỌN NHÂN VIÊN / KHÁCH HÀNG / MẶT HÀNG
        // ==================================================================

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            txtTenNV.Text = nhanVienBus.LayTen(txtMaNV.Text);
        }

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
                KhachHang? kh = khachHangBus.LayThongTin(maKH);
                txtTenKH.Text = kh?.HoTen ?? "";
                txtSDT.Text = kh?.SDT ?? "";
                txtDiaChi.Text = kh?.DiaChi ?? "";
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không lấy được thông tin khách hàng:\n" + ex.Message);
            }
        }

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
                HangHoa? hang = hangHoaBus.LayTheoMa(maHang);
                txtTenHang.Text = hang?.TenHang ?? "";
                txtDonGia.Text = hang == null ? "" : AppHelpers.DinhDangTien(hang.GiaBan);
                TinhThanhTien();
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không lấy được thông tin hàng hóa:\n" + ex.Message);
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e) => TinhThanhTien();

        private void txtGiamGia_TextChanged(object sender, EventArgs e) => TinhThanhTien();

        private void TinhThanhTien()
        {
            if (AppHelpers.DocSoTien(txtDonGia.Text, out decimal donGia) &&
                int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) &&
                AppHelpers.DocSoTien(txtGiamGia.Text, out decimal giamGia) &&
                soLuong > 0 && giamGia >= 0 && giamGia <= 100)
            {
                decimal thanhTien = donGia * soLuong * (100 - giamGia) / 100m;
                txtThanhTien.Text = AppHelpers.DinhDangTien(thanhTien);
            }
            else
            {
                txtThanhTien.Clear();
            }
        }

        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (DataRow row in bangChiTiet.Rows)
                tongTien += Convert.ToDecimal(row["ThanhTien"]);

            lblTongTien.Text = "Tổng tiền: " + AppHelpers.DinhDangTien(tongTien) + " VNĐ";
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

        // ==================================================================
        // THÊM MẶT HÀNG VÀO HÓA ĐƠN ĐANG LẬP
        // ==================================================================

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            if (hoaDonDaTonTai)
            {
                MessageBox.Show("Đây là hóa đơn đã lưu. Hãy bấm Thêm hóa đơn để lập hóa đơn mới.");
                return;
            }

            string maHang = cboMaHang.Text.Trim();

            if (maHang == "" || txtTenHang.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn mã hàng!");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên lớn hơn 0!");
                return;
            }

            if (!AppHelpers.DocSoTien(txtGiamGia.Text, out decimal giamGia) || giamGia < 0 || giamGia > 100)
            {
                MessageBox.Show("Giảm giá phải từ 0 đến 100%!");
                return;
            }

            if (!AppHelpers.DocSoTien(txtDonGia.Text, out decimal donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return;
            }

            // Nếu mã hàng đã có trong hóa đơn thì cộng thêm số lượng
            foreach (DataRow row in bangChiTiet.Rows)
            {
                if (row["MaHang"].ToString() == maHang)
                {
                    decimal giamGiaCu = Convert.ToDecimal(row["GiamGia"]);

                    if (giamGia != giamGiaCu)
                    {
                        MessageBox.Show("Mặt hàng này đã có trong hóa đơn với mức giảm giá khác. " +
                                        "Hãy xóa dòng cũ trước khi thêm lại.");
                        return;
                    }

                    int soLuongMoi = Convert.ToInt32(row["SoLuong"]) + soLuong;
                    row["SoLuong"] = soLuongMoi;
                    row["ThanhTien"] = donGia * soLuongMoi * (100 - giamGia) / 100m;
                    TinhTongTien();
                    XoaThongTinHangDangChon();
                    return;
                }
            }

            decimal thanhTien = donGia * soLuong * (100 - giamGia) / 100m;

            bangChiTiet.Rows.Add(maHang, txtTenHang.Text, donGia, soLuong, giamGia, thanhTien);

            TinhTongTien();
            XoaThongTinHangDangChon();
        }

        // ==================================================================
        // HÓA ĐƠN MỚI / HỦY CÁC DÒNG ĐANG LẬP
        // ==================================================================

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            if (!AppHelpers.XacNhan("Tạo hóa đơn mới? Các mặt hàng chưa lưu hiện tại sẽ bị xóa."))
                return;

            bangChiTiet.Rows.Clear();

            txtMaNV.Clear();
            txtTenNV.Clear();
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();

            XoaThongTinHangDangChon();

            cboMaHD.Text = HoaDonBan.TaoMaMoi();
            dtpNgayLap.Value = DateTime.Now;

            hoaDonDaTonTai = false;
            TinhTongTien();

            MessageBox.Show("Đã tạo hóa đơn mới. Hãy chọn mã nhân viên, khách hàng (nếu có) và mặt hàng.");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (hoaDonDaTonTai)
            {
                MessageBox.Show("Đây là hóa đơn đã lưu. Chức năng này không xóa hóa đơn trong cơ sở dữ liệu.");
                return;
            }

            if (AppHelpers.XacNhan("Bạn có chắc muốn xóa tất cả mặt hàng đang lập?"))
            {
                bangChiTiet.Rows.Clear();
                TinhTongTien();
            }
        }

        // ==================================================================
        // LƯU HÓA ĐƠN
        // ==================================================================

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (hoaDonDaTonTai)
            {
                MessageBox.Show("Hóa đơn này đã được lưu. Hãy tạo hóa đơn mới nếu muốn lập hóa đơn khác.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cboMaHD.Text))
            {
                MessageBox.Show("Vui lòng tạo mã hóa đơn!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên hợp lệ!");
                txtMaNV.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtMaKH.Text) && string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Mã khách hàng không hợp lệ!");
                txtMaKH.Focus();
                return;
            }

            if (bangChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn chưa có mặt hàng!");
                return;
            }

            // Dựng đối tượng hóa đơn từ dữ liệu trên form
            var hd = new HoaDonBan
            {
                MaHD = cboMaHD.Text.Trim(),
                MaNV = txtMaNV.Text.Trim(),
                MaKH = txtMaKH.Text.Trim(),
                NgayLap = dtpNgayLap.Value
            };

            foreach (DataRow row in bangChiTiet.Rows)
            {
                var ct = new ChiTietHoaDonBan(
                    hd.MaHD,
                    row["MaHang"].ToString() ?? "",
                    row["TenHang"].ToString() ?? "",
                    Convert.ToInt32(row["SoLuong"]),
                    Convert.ToDecimal(row["DonGia"]),
                    Convert.ToDecimal(row["GiamGia"]));

                hd.ChiTietList.Add(ct);
            }

            hd.TinhTongTien();

            if (hoaDonBus.LuuHoaDon(hd, out string error))
            {
                hoaDonDaTonTai = true;
                NapDanhSachHoaDon();

                MessageBox.Show("Lưu hóa đơn thành công!\nTồn kho đã được cập nhật.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lưu hóa đơn thất bại:\n" + error,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================================================================
        // TÌM HÓA ĐƠN ĐÃ LƯU
        // ==================================================================

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
                DataTable dtHoaDon = hoaDonBus.LayHoaDon(maHD);

                if (dtHoaDon.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn này.");
                    return;
                }

                DataRow r = dtHoaDon.Rows[0];

                txtMaNV.Text = r["MaNV"].ToString();
                txtTenNV.Text = r["TenNV"].ToString();
                txtMaKH.Text = r["MaKH"] == DBNull.Value ? "" : r["MaKH"].ToString() ?? "";
                txtTenKH.Text = r["TenKH"] == DBNull.Value ? "" : r["TenKH"].ToString() ?? "";
                txtSDT.Text = r["SDT"] == DBNull.Value ? "" : r["SDT"].ToString() ?? "";
                txtDiaChi.Text = r["DiaChi"] == DBNull.Value ? "" : r["DiaChi"].ToString() ?? "";
                dtpNgayLap.Value = Convert.ToDateTime(r["NgayLap"]);

                bangChiTiet.Rows.Clear();

                DataTable dtChiTiet = hoaDonBus.LayChiTiet(maHD);
                foreach (DataRow row in dtChiTiet.Rows)
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
                MessageBox.Show("Không thể tìm hóa đơn:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================================================================
        // XÓA MỘT DÒNG CHI TIẾT
        // ==================================================================

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= bangChiTiet.Rows.Count) return;

            if (hoaDonDaTonTai)
            {
                MessageBox.Show("Đây là hóa đơn đã lưu. Không thể xóa dòng trực tiếp trên giao diện.");
                return;
            }

            if (AppHelpers.XacNhan("Bạn có muốn xóa mặt hàng này khỏi hóa đơn đang lập?"))
            {
                bangChiTiet.Rows.RemoveAt(e.RowIndex);
                TinhTongTien();
            }
        }

        // ==================================================================
        // XUẤT HÓA ĐƠN RA EXCEL
        // ==================================================================

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

                sheet.Cell(1, 1).Value = "HÓA ĐƠN BÁN HÀNG";
                var title = sheet.Range("A1:G1");
                title.Merge();
                title.Style.Font.Bold = true;
                title.Style.Font.FontSize = 16;
                title.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                sheet.Cell(3, 1).Value = "Mã hóa đơn:";
                sheet.Cell(3, 2).Value = maHD;
                sheet.Cell(4, 1).Value = "Ngày lập:";
                sheet.Cell(4, 2).Value = dtpNgayLap.Value.ToString("dd/MM/yyyy");
                sheet.Cell(5, 1).Value = "Mã nhân viên:";
                sheet.Cell(5, 2).Value = txtMaNV.Text;
                sheet.Cell(6, 1).Value = "Tên nhân viên:";
                sheet.Cell(6, 2).Value = txtTenNV.Text;
                sheet.Cell(5, 4).Value = "Mã khách hàng:";
                sheet.Cell(5, 5).Value = txtMaKH.Text;
                sheet.Cell(6, 4).Value = "Tên khách hàng:";
                sheet.Cell(6, 5).Value = txtTenKH.Text;
                sheet.Cell(7, 4).Value = "SĐT khách:";
                sheet.Cell(7, 5).Value = txtSDT.Text;
                sheet.Cell(8, 4).Value = "Địa chỉ:";
                sheet.Cell(8, 5).Value = txtDiaChi.Text;

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

                dong++;
                sheet.Cell(dong, 5).Value = "TỔNG TIỀN:";
                sheet.Cell(dong, 5).Style.Font.Bold = true;
                sheet.Cell(dong, 6).Value = tongTien;
                sheet.Cell(dong, 6).Style.Font.Bold = true;
                sheet.Cell(dong, 6).Style.NumberFormat.Format = "#,##0";

                sheet.Columns().AdjustToContents();
                wb.SaveAs(sfd.FileName);

                AppHelpers.GhiLog($"Xuất hóa đơn Excel {maHD}: {sfd.FileName}");
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
                MessageBox.Show("Xuất Excel thất bại:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e) => Close();

        // Hai hàm dưới đây được nối sẵn trong Form7.Designer.cs, giữ lại để tệp thiết kế biên dịch được.
        private void label1_Click(object? sender, EventArgs e) { }

        private void label13_Click(object? sender, EventArgs e) { }
    }
}
