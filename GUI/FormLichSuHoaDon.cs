using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4.GUI
{
    /// <summary>
    /// Lịch sử hóa đơn bán: bảng trên liệt kê toàn bộ hóa đơn đã bán (lọc nhanh theo mã hóa đơn,
    /// số điện thoại hoặc tên khách), bảng dưới nạp chi tiết các mặt hàng của hóa đơn đang chọn.
    /// - Nhân viên: xem chi tiết, xuất Excel và hủy đơn (hoàn lại tồn kho).
    /// - Quản lý: mở ở chế độ chỉ xem, không hủy đơn.
    /// Toàn bộ truy vấn đi qua tầng BUS → DAL → Stored Procedure.
    /// </summary>
    public partial class FormLichSuHoaDon : Form
    {
        private readonly HoaDonBanBUS hoaDonBus = new HoaDonBanBUS();
        private readonly DataTable bangChiTiet = new DataTable();

        private readonly bool chiXem;
        private bool dangNap = false;
        private string maHoaDonDangChon = "";
        private DataRowView? dongDangChon;

        public FormLichSuHoaDon() : this(false)
        {
        }

        public FormLichSuHoaDon(bool chiXem)
        {
            InitializeComponent();

            this.chiXem = chiXem;

            CauHinhLuoi();
            GanSuKien();

            if (chiXem) ApDungCheDoChiXem();

            Load += FormLichSuHoaDon_Load;
        }

        // ==================================================================
        // KHỞI TẠO
        // ==================================================================

        private void CauHinhLuoi()
        {
            bangChiTiet.Columns.Add("MaHang", typeof(string));
            bangChiTiet.Columns.Add("TenHang", typeof(string));
            bangChiTiet.Columns.Add("DonGia", typeof(decimal));
            bangChiTiet.Columns.Add("SoLuong", typeof(int));
            bangChiTiet.Columns.Add("GiamGia", typeof(decimal));
            bangChiTiet.Columns.Add("ThanhTien", typeof(decimal));

            dgvChiTiet.AutoGenerateColumns = true;
            dgvChiTiet.DataSource = bangChiTiet;

            dgvChiTiet.Columns["MaHang"].HeaderText = "Mã hàng";
            dgvChiTiet.Columns["TenHang"].HeaderText = "Tên hàng";
            dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvChiTiet.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvChiTiet.Columns["GiamGia"].HeaderText = "Giảm giá (%)";
            dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành tiền";

            dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["GiamGia"].DefaultCellStyle.Format = "0.##";

            dgvChiTiet.Columns["MaHang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvChiTiet.Columns["TenHang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChiTiet.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiTiet.Columns["GiamGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            lblTongTien.Text = "Tổng tiền: 0 VNĐ";
        }

        private void GanSuKien()
        {
            btnTim.Click -= btnTim_Click;
            btnTim.Click += btnTim_Click;

            btnLamMoi.Click -= btnLamMoi_Click;
            btnLamMoi.Click += btnLamMoi_Click;

            btnXuatExcel.Click -= btnXuatExcel_Click;
            btnXuatExcel.Click += btnXuatExcel_Click;

            btnHuyDon.Click -= btnHuyDon_Click;
            btnHuyDon.Click += btnHuyDon_Click;

            btnThoat.Click -= btnThoat_Click;
            btnThoat.Click += btnThoat_Click;

            txtTuKhoa.KeyDown -= txtTuKhoa_KeyDown;
            txtTuKhoa.KeyDown += txtTuKhoa_KeyDown;

            dgvHoaDon.SelectionChanged -= dgvHoaDon_SelectionChanged;
            dgvHoaDon.SelectionChanged += dgvHoaDon_SelectionChanged;

            dgvHoaDon.CellClick -= dgvHoaDon_CellClick;
            dgvHoaDon.CellClick += dgvHoaDon_CellClick;
        }

        private void ApDungCheDoChiXem()
        {
            btnHuyDon.Visible = false;
            Text = "LỊCH SỬ HÓA ĐƠN BÁN (CHẾ ĐỘ CHỈ XEM)";
            label1.Text = "LỊCH SỬ HÓA ĐƠN BÁN (CHỈ XEM)";
        }

        private void FormLichSuHoaDon_Load(object? sender, EventArgs e)
        {
            TaiDanhSach("");
        }

        // ==================================================================
        // NẠP DANH SÁCH HÓA ĐƠN
        // ==================================================================

        private void TaiDanhSach(string tuKhoa)
        {
            dangNap = true;
            try
            {
                DataTable dt = hoaDonBus.TimHoaDon(tuKhoa);

                dgvHoaDon.DataSource = dt;
                DinhDangLuoiHoaDon();

                lblKetQua.Text = dt.Rows.Count == 0
                    ? "Không tìm thấy hóa đơn nào khớp từ khóa."
                    : "Tìm thấy " + dt.Rows.Count.ToString("N0") + " hóa đơn.";

                if (dt.Rows.Count > 0)
                {
                    dgvHoaDon.ClearSelection();
                    dgvHoaDon.Rows[0].Selected = true;
                    dgvHoaDon.CurrentCell = dgvHoaDon.Rows[0].Cells[0];
                }
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không tải được danh sách hóa đơn:\n" + ex.Message);
            }
            finally
            {
                dangNap = false;
            }

            if (dgvHoaDon.Rows.Count > 0)
                NapChiTiet(dgvHoaDon.Rows[0]);
            else
                XoaChiTiet();
        }

        /// <summary>Tiêu đề cột tiếng Việt + định dạng ngày, số tiền cho bảng danh sách hóa đơn.</summary>
        private void DinhDangLuoiHoaDon()
        {
            if (dgvHoaDon.Columns.Contains("MaHD"))
            {
                dgvHoaDon.Columns["MaHD"].HeaderText = "Mã hóa đơn";
                dgvHoaDon.Columns["MaHD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvHoaDon.Columns.Contains("NgayLap"))
            {
                dgvHoaDon.Columns["NgayLap"].HeaderText = "Ngày lập";
                dgvHoaDon.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvHoaDon.Columns["NgayLap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvHoaDon.Columns.Contains("MaNV"))
            {
                dgvHoaDon.Columns["MaNV"].HeaderText = "Mã NV";
                dgvHoaDon.Columns["MaNV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvHoaDon.Columns.Contains("TenNV"))
            {
                dgvHoaDon.Columns["TenNV"].HeaderText = "Nhân viên";
                dgvHoaDon.Columns["TenNV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvHoaDon.Columns.Contains("MaKH"))
            {
                dgvHoaDon.Columns["MaKH"].HeaderText = "Mã KH";
                dgvHoaDon.Columns["MaKH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvHoaDon.Columns.Contains("TenKH"))
            {
                dgvHoaDon.Columns["TenKH"].HeaderText = "Khách hàng";
                dgvHoaDon.Columns["TenKH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvHoaDon.Columns.Contains("SDT"))
            {
                dgvHoaDon.Columns["SDT"].HeaderText = "SĐT";
                dgvHoaDon.Columns["SDT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvHoaDon.Columns.Contains("TongTien"))
            {
                dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvHoaDon.Columns.Contains("TrangThaiThanhToan"))
            {
                dgvHoaDon.Columns["TrangThaiThanhToan"].HeaderText = "Trạng thái TT";
                dgvHoaDon.Columns["TrangThaiThanhToan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvHoaDon.Columns.Contains("PhuongThucThanhToan"))
            {
                dgvHoaDon.Columns["PhuongThucThanhToan"].HeaderText = "Phương thức TT";
                dgvHoaDon.Columns["PhuongThucThanhToan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // ==================================================================
        // CHI TIẾT HÓA ĐƠN ĐANG CHỌN
        // ==================================================================

        private DataRowView? LayDongDangChon()
        {
            if (dgvHoaDon.CurrentRow == null) return null;
            return dgvHoaDon.CurrentRow.DataBoundItem as DataRowView;
        }

        private string LayMaHoaDon(DataRowView dong)
        {
            return dong.Row.Table.Columns.Contains("MaHD")
                ? Convert.ToString(dong["MaHD"]) ?? ""
                : "";
        }

        private void NapChiTiet(DataGridViewRow dongLuoi)
        {
            DataRowView? dong = dongLuoi.DataBoundItem as DataRowView;

            if (dong == null)
            {
                XoaChiTiet();
                return;
            }

            string maHD = LayMaHoaDon(dong);

            if (maHD == "")
            {
                XoaChiTiet();
                return;
            }

            dongDangChon = dong;
            maHoaDonDangChon = maHD;

            try
            {
                bangChiTiet.Rows.Clear();

                decimal tongTien = 0;

                foreach (DataRow row in hoaDonBus.LayChiTiet(maHD).Rows)
                {
                    bangChiTiet.Rows.Add(
                        row["MaHang"],
                        row["TenHang"],
                        row["DonGia"],
                        row["SoLuong"],
                        row["GiamGia"],
                        row["ThanhTien"]);

                    tongTien += Convert.ToDecimal(row["ThanhTien"]);
                }

                lblTongTien.Text = "Tổng tiền: " + AppHelpers.DinhDangTien(tongTien) + " VNĐ";
                lblHoaDonDangChon.Text = TaoMoTaHoaDon(dong, bangChiTiet.Rows.Count);
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không tải được chi tiết hóa đơn " + maHD + ":\n" + ex.Message);
            }
        }

        private string TaoMoTaHoaDon(DataRowView dong, int soMatHang)
        {
            string maHD = Convert.ToString(dong["MaHD"]) ?? "";
            string tenKH = dong.Row.Table.Columns.Contains("TenKH")
                ? Convert.ToString(dong["TenKH"]) ?? ""
                : "";
            string ngayLap = dong.Row.Table.Columns.Contains("NgayLap") && dong["NgayLap"] != DBNull.Value
                ? Convert.ToDateTime(dong["NgayLap"]).ToString("dd/MM/yyyy")
                : "";

            string moTa = "Hóa đơn " + maHD;

            if (ngayLap != "") moTa += " • " + ngayLap;
            if (tenKH != "") moTa += " • " + tenKH;

            return moTa + " • " + soMatHang.ToString("N0") + " mặt hàng";
        }

        private void XoaChiTiet()
        {
            dongDangChon = null;
            maHoaDonDangChon = "";
            bangChiTiet.Rows.Clear();
            lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            lblHoaDonDangChon.Text = "Chọn một hóa đơn ở bảng trên để xem chi tiết.";
        }

        private void dgvHoaDon_SelectionChanged(object? sender, EventArgs e)
        {
            if (dangNap) return;

            DataRowView? dong = LayDongDangChon();

            if (dong == null)
            {
                XoaChiTiet();
                return;
            }

            if (LayMaHoaDon(dong) == maHoaDonDangChon && bangChiTiet.Rows.Count > 0) return;

            NapChiTiet(dgvHoaDon.CurrentRow);
        }

        private void dgvHoaDon_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvHoaDon.Rows.Count) return;

            NapChiTiet(dgvHoaDon.Rows[e.RowIndex]);
        }

        // ==================================================================
        // TÌM NHANH / TẢI LẠI
        // ==================================================================

        private void btnTim_Click(object? sender, EventArgs e)
        {
            TaiDanhSach(txtTuKhoa.Text);
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            txtTuKhoa.Clear();
            TaiDanhSach("");
        }

        private void txtTuKhoa_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TaiDanhSach(txtTuKhoa.Text);
            }
        }

        // ==================================================================
        // HỦY ĐƠN (HOÀN KHO)
        // ==================================================================

        private void btnHuyDon_Click(object? sender, EventArgs e)
        {
            if (chiXem)
            {
                AppHelpers.HienCanhBao("Tài khoản Quản lý chỉ được xem lịch sử hóa đơn, không hủy đơn.");
                return;
            }

            if (maHoaDonDangChon == "")
            {
                AppHelpers.HienCanhBao("Hãy chọn một hóa đơn ở bảng trên trước khi hủy.");
                return;
            }

            if (!AppHelpers.XacNhan("Hủy hóa đơn " + maHoaDonDangChon + "?\n" +
                                   "Các mặt hàng của hóa đơn sẽ được hoàn lại kho và hóa đơn bị xóa khỏi hệ thống."))
                return;

            if (!hoaDonBus.HuyHoaDon(maHoaDonDangChon, out string error))
            {
                AppHelpers.HienCanhBao("Hủy hóa đơn thất bại:\n" + error);
                return;
            }

            string maDaHuy = maHoaDonDangChon;

            AppHelpers.HienThongBao("Đã hủy hóa đơn " + maDaHuy + " và hoàn lại tồn kho.");
            TaiDanhSach(txtTuKhoa.Text);
        }

        // ==================================================================
        // XUẤT HÓA ĐƠN RA EXCEL
        // ==================================================================

        private void btnXuatExcel_Click(object? sender, EventArgs e)
        {
            if (maHoaDonDangChon == "" || dongDangChon == null)
            {
                AppHelpers.HienCanhBao("Hãy chọn một hóa đơn ở bảng trên trước khi xuất Excel.");
                return;
            }

            if (bangChiTiet.Rows.Count == 0)
            {
                AppHelpers.HienCanhBao("Hóa đơn này chưa có mặt hàng để xuất.");
                return;
            }

            string maHD = maHoaDonDangChon;

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
                sheet.Cell(4, 2).Value = LayChuoi(dongDangChon, "NgayLap", "dd/MM/yyyy");
                sheet.Cell(5, 1).Value = "Mã nhân viên:";
                sheet.Cell(5, 2).Value = LayChuoi(dongDangChon, "MaNV");
                sheet.Cell(6, 1).Value = "Tên nhân viên:";
                sheet.Cell(6, 2).Value = LayChuoi(dongDangChon, "TenNV");
                sheet.Cell(5, 4).Value = "Mã khách hàng:";
                sheet.Cell(5, 5).Value = LayChuoi(dongDangChon, "MaKH");
                sheet.Cell(6, 4).Value = "Tên khách hàng:";
                sheet.Cell(6, 5).Value = LayChuoi(dongDangChon, "TenKH");
                sheet.Cell(7, 4).Value = "SĐT khách:";
                sheet.Cell(7, 5).Value = LayChuoi(dongDangChon, "SDT");
                sheet.Cell(8, 4).Value = "Trạng thái TT:";
                sheet.Cell(8, 5).Value = LayChuoi(dongDangChon, "TrangThaiThanhToan");
                sheet.Cell(9, 4).Value = "Phương thức TT:";
                sheet.Cell(9, 5).Value = LayChuoi(dongDangChon, "PhuongThucThanhToan");

                int dongTieuDe = 11;
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

                AppHelpers.GhiLog($"Xuất Excel hóa đơn {maHD} từ lịch sử hóa đơn: {sfd.FileName}");
                AppHelpers.HienThongBao("Xuất hóa đơn Excel thành công!\n" + sfd.FileName);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = sfd.FileName,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Xuất Excel thất bại:\n" + ex.Message);
            }
        }

        /// <summary>Đọc một cột của dòng hóa đơn đang chọn dưới dạng chuỗi (rỗng nếu không có).</summary>
        private string LayChuoi(DataRowView? dong, string tenCot, string dinhDangNgay = "")
        {
            if (dong == null || !dong.Row.Table.Columns.Contains(tenCot)) return "";
            if (dong[tenCot] == DBNull.Value) return "";

            if (dinhDangNgay != "")
                return Convert.ToDateTime(dong[tenCot]).ToString(dinhDangNgay);

            return Convert.ToString(dong[tenCot]) ?? "";
        }

        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
