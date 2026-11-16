using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Form tìm kiếm nâng cao: lọc hàng theo tên, hãng, loại, màu và khoảng giá;
    /// kết quả lấy từ thủ tục sp_TimKiemHang thông qua HangHoaBUS và có thể xuất ra Excel.
    /// </summary>
    public partial class Form6 : Form
    {
        private readonly HangHoaBUS hangHoaBus = new HangHoaBUS();
        private readonly DanhMucBUS danhMucBus = new DanhMucBUS();
        private DataTable dtKetQua = new DataTable();

        public Form6()
        {
            InitializeComponent();

            // Bố cục co giãn (trước đây gọi trong InitializeComponent)
            Resize += (s, e) => LayoutForm6();
            groupBox1.Resize += (s, e) => LayoutForm6();
            groupBox2.Resize += (s, e) => LayoutForm6();

            LayoutForm6();

            button1.Text = "Tìm kiếm";
            button2.Text = "Làm lại";
            button3.Text = "Xuất Excel";
            button4.Text = "Thoát";

            Load += Form6_Load;
            button1.Click += btnTimKiem_Click;
            button2.Click += btnLamLai_Click;
            button3.Click += btnXuatExcel_Click;
            button4.Click += (s, e) => Close();
        }

        private void Form6_Load(object? sender, EventArgs e)
        {
            NapCombo(cboHang, LoaiDanhMuc.HangSanXuat, "TenHangSX", "MaHangSX");
            NapCombo(cboLoai, LoaiDanhMuc.LoaiHang, "TenLoai", "MaLoai");
            NapCombo(cboMau, LoaiDanhMuc.MauSac, "TenMau", "MaMau");

            dgvKetQua.AutoGenerateColumns = false;
            ColMaHang.DataPropertyName = "MaHang";
            colTenHang.DataPropertyName = "TenHang";
            colHang.DataPropertyName = "Hang";
            colLoai.DataPropertyName = "Loai";
            colMau.DataPropertyName = "Mau";
            colDungLuong.DataPropertyName = "DungLuong";
            colGiaBan.DataPropertyName = "DonGiaBan";
            colSL.DataPropertyName = "SoLuongTon";

            dgvKetQua.ReadOnly = true;
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKetQua.MultiSelect = false;
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            colGiaBan.DefaultCellStyle.Format = "N0";
            colGiaBan.DefaultCellStyle.FormatProvider = AppHelpers.ViVn;

            ThucHienTimKiem();
        }

        /// <summary>Nạp ComboBox danh mục, thêm dòng "-- Tất cả --" ở đầu.</summary>
        private void NapCombo(ComboBox cbo, LoaiDanhMuc loai, string cotTen, string cotMa)
        {
            try
            {
                DataTable dt = danhMucBus.LayDanhSach(loai);

                DataRow dr = dt.NewRow();
                dr[cotTen] = "-- Tất cả --";
                dr[cotMa] = "";
                dt.Rows.InsertAt(dr, 0);

                cbo.DataSource = dt;
                cbo.DisplayMember = cotTen;
                cbo.ValueMember = cotMa;
                cbo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không tải được danh mục: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object? sender, EventArgs e) => ThucHienTimKiem();

        private void ThucHienTimKiem()
        {
            try
            {
                string? ten = string.IsNullOrWhiteSpace(txtTenHang.Text) ? null : txtTenHang.Text.Trim();
                string? hang = cboHang.SelectedIndex > 0 ? cboHang.SelectedValue?.ToString() : null;
                string? loai = cboLoai.SelectedIndex > 0 ? cboLoai.SelectedValue?.ToString() : null;
                string? mau = cboMau.SelectedIndex > 0 ? cboMau.SelectedValue?.ToString() : null;

                decimal? giaTu = null;
                if (AppHelpers.DocSoTien(txtGiaTu.Text, out decimal gt) && gt > 0) giaTu = gt;

                decimal? giaDen = null;
                if (AppHelpers.DocSoTien(txtGiaDen.Text, out decimal gd) && gd > 0) giaDen = gd;

                dtKetQua = hangHoaBus.TimKiem(ten, hang, loai, mau, giaTu, giaDen);
                dgvKetQua.DataSource = dtKetQua;

                label6.Text = $"Tìm thấy {dtKetQua.Rows.Count} sản phẩm";
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btnLamLai_Click(object? sender, EventArgs e)
        {
            txtTenHang.Clear();
            txtGiaTu.Clear();
            txtGiaDen.Clear();
            if (cboHang.Items.Count > 0) cboHang.SelectedIndex = 0;
            if (cboLoai.Items.Count > 0) cboLoai.SelectedIndex = 0;
            if (cboMau.Items.Count > 0) cboMau.SelectedIndex = 0;
            ThucHienTimKiem();
        }

        private void btnXuatExcel_Click(object? sender, EventArgs e)
        {
            if (dtKetQua.Rows.Count == 0)
            {
                AppHelpers.HienCanhBao("Không có dữ liệu để xuất Excel!");
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = $"BaoCao_SanPham_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                Title = "Lưu file Excel kết quả tìm kiếm"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("DanhSachSanPham");

                ws.Cell(1, 1).Value = "BÁO CÁO DANH SÁCH SẢN PHẨM";
                var titleRange = ws.Range("A1:I1");
                titleRange.Merge();
                titleRange.Style.Font.FontSize = 16;
                titleRange.Style.Font.Bold = true;
                titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                ws.Cell(2, 1).Value = $"Thời gian xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                ws.Cell(2, 1).Style.Font.Italic = true;

                string[] headers = { "STT", "Mã hàng", "Tên hàng", "Hãng", "Loại", "Màu", "Dung lượng", "Giá bán (VNĐ)", "Tồn kho" };
                for (int i = 0; i < headers.Length; i++)
                {
                    var cell = ws.Cell(4, i + 1);
                    cell.Value = headers[i];
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }

                int rowIdx = 5;
                for (int i = 0; i < dtKetQua.Rows.Count; i++)
                {
                    DataRow r = dtKetQua.Rows[i];
                    ws.Cell(rowIdx, 1).Value = i + 1;
                    ws.Cell(rowIdx, 2).Value = r["MaHang"]?.ToString();
                    ws.Cell(rowIdx, 3).Value = r["TenHang"]?.ToString();
                    ws.Cell(rowIdx, 4).Value = r["Hang"]?.ToString();
                    ws.Cell(rowIdx, 5).Value = r["Loai"]?.ToString();
                    ws.Cell(rowIdx, 6).Value = r["Mau"]?.ToString();
                    ws.Cell(rowIdx, 7).Value = r["DungLuong"]?.ToString();
                    ws.Cell(rowIdx, 8).Value = r["DonGiaBan"] == DBNull.Value ? 0 : Convert.ToDecimal(r["DonGiaBan"]);
                    ws.Cell(rowIdx, 8).Style.NumberFormat.Format = "#,##0";
                    ws.Cell(rowIdx, 9).Value = r["SoLuongTon"] == DBNull.Value ? 0 : Convert.ToInt32(r["SoLuongTon"]);
                    ws.Range(rowIdx, 1, rowIdx, 9).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    rowIdx++;
                }

                ws.Columns().AdjustToContents();
                wb.SaveAs(sfd.FileName);

                AppHelpers.GhiLog($"Xuất Excel danh sách sản phẩm: {sfd.FileName}");
                AppHelpers.HienThongBao("Xuất file Excel thành công!");

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = sfd.FileName,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Lỗi xuất Excel: " + ex.Message);
            }
        }

        // ------------------------------------------------------------------
        // BỐ CỤC CO GIÃN THEO KÍCH THƯỚC CỬA SỔ
        // (chuyển ra khỏi InitializeComponent để màn [Design] mở được)
        // ------------------------------------------------------------------
        private void LayoutForm6()
        {
            if (groupBox1 == null || groupBox2 == null || dgvKetQua == null)
                return;

            int margin = 18;
            int formWidth = ClientSize.Width;
            int formHeight = ClientSize.Height;

            int groupWidth = Math.Max(500, formWidth - margin * 2);

            // KHUNG TIÊU CHÍ
            groupBox1.SetBounds(margin, 15, groupWidth, 270);

            int innerWidth = groupBox1.ClientSize.Width - 40;
            int gap = 25;
            int colWidth = Math.Max(130, (innerWidth - gap * 2) / 3);

            int x1 = 20;
            int x2 = x1 + colWidth + gap;
            int x3 = x2 + colWidth + gap;

            int labelY1 = 35;
            int inputY1 = 61;
            int labelY2 = 112;
            int inputY2 = 138;

            // HÀNG 1
            label1.Location = new Point(x1, labelY1);
            txtTenHang.SetBounds(x1, inputY1, colWidth, 34);

            label3.Location = new Point(x2, labelY1);
            cboHang.SetBounds(x2, inputY1, colWidth, 34);

            label5.Location = new Point(x3, labelY1);
            cboLoai.SetBounds(x3, inputY1, colWidth, 34);

            // HÀNG 2
            label2.Location = new Point(x1, labelY2);
            cboMau.SetBounds(x1, inputY2, colWidth, 34);

            label7.Location = new Point(x2, labelY2);
            txtGiaTu.SetBounds(x2, inputY2, colWidth, 34);

            label4.Location = new Point(x3, labelY2);
            txtGiaDen.SetBounds(x3, inputY2, colWidth, 34);

            // NHÓM NÚT
            int buttonY = 198;
            int buttonWidth = 155;
            int buttonHeight = 48;
            int buttonGap = 15;
            int buttonX = 20;

            button1.SetBounds(buttonX, buttonY, buttonWidth, buttonHeight);
            buttonX += buttonWidth + buttonGap;

            button2.SetBounds(buttonX, buttonY, buttonWidth, buttonHeight);
            buttonX += buttonWidth + buttonGap;

            button3.SetBounds(buttonX, buttonY, buttonWidth, buttonHeight);
            buttonX += buttonWidth + buttonGap;

            button4.SetBounds(buttonX, buttonY, buttonWidth, buttonHeight);

            // KHUNG KẾT QUẢ
            int resultTop = 300;
            int resultHeight = Math.Max(200, formHeight - resultTop - margin);

            groupBox2.SetBounds(margin, resultTop, groupWidth, resultHeight);

            // DÒNG THỐNG KÊ
            label6.Location = new Point(18, 34);

            // BẢNG DỮ LIỆU
            int gridTop = 65;
            int gridLeft = 15;
            int gridWidth = Math.Max(300, groupBox2.ClientSize.Width - 30);
            int gridHeight = Math.Max(100, groupBox2.ClientSize.Height - gridTop - 15);

            dgvKetQua.SetBounds(gridLeft, gridTop, gridWidth, gridHeight);
        }
    }
}
