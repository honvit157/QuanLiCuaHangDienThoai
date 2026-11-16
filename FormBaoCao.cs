using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Form báo cáo thống kê: Doanh thu, Tồn kho, Top bán chạy
    /// </summary>
    public partial class FormBaoCao : Form
    {
        private readonly CultureInfo vn = new CultureInfo("vi-VN");
        private readonly BaoCaoBUS baoCaoBus = new BaoCaoBUS();
        private DataTable dtDoanhThu   = new DataTable();
        private DataTable dtTonKho     = new DataTable();
        private DataTable dtTopBanChay = new DataTable();

        public FormBaoCao()
        {
            InitializeComponent();

            TaoGiaoDien();
            this.Text = "BÁO CÁO THỐNG KÊ";
            this.Size = new Size(900, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 500);

            Load += FormBaoCao_Load;
        }

        private void FormBaoCao_Load(object? sender, EventArgs e)
        {
            NapDuLieu();
        }

        private void NapDuLieu()
        {
            try
            {
                // ---- Tab 1: Doanh thu theo thang ----
                dtDoanhThu = baoCaoBus.DoanhThuTheoThang();

                dgvDoanhThu.DataSource = dtDoanhThu;
                CauHinhGrid(dgvDoanhThu);
                if (dgvDoanhThu.Columns.Contains("Nam"))       dgvDoanhThu.Columns["Nam"].HeaderText       = "Năm";
                if (dgvDoanhThu.Columns.Contains("Thang"))     dgvDoanhThu.Columns["Thang"].HeaderText     = "Tháng";
                if (dgvDoanhThu.Columns.Contains("SoHoaDon"))  dgvDoanhThu.Columns["SoHoaDon"].HeaderText  = "Số hóa đơn";
                if (dgvDoanhThu.Columns.Contains("DoanhThu"))
                {
                    dgvDoanhThu.Columns["DoanhThu"].HeaderText = "Doanh thu (VNĐ)";
                    dgvDoanhThu.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
                    dgvDoanhThu.Columns["DoanhThu"].DefaultCellStyle.FormatProvider = vn;
                    dgvDoanhThu.Columns["DoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // Tổng doanh thu
                decimal tongDT = baoCaoBus.TongDoanhThu(dtDoanhThu);
                lblTongDoanhThu.Text = $"Tổng doanh thu: {tongDT.ToString("N0", vn)} VNĐ";

                // ---- Tab 2: Tồn kho ----
                dtTonKho = baoCaoBus.TonKho();

                dgvTonKho.DataSource = dtTonKho;
                CauHinhGrid(dgvTonKho);
                if (dgvTonKho.Columns.Contains("MaHang"))    dgvTonKho.Columns["MaHang"].HeaderText    = "Mã hàng";
                if (dgvTonKho.Columns.Contains("TenHang"))   dgvTonKho.Columns["TenHang"].HeaderText   = "Tên hàng";
                if (dgvTonKho.Columns.Contains("Hang"))      dgvTonKho.Columns["Hang"].HeaderText      = "Hãng";
                if (dgvTonKho.Columns.Contains("Loai"))      dgvTonKho.Columns["Loai"].HeaderText      = "Loại";
                if (dgvTonKho.Columns.Contains("DonGiaBan"))
                {
                    dgvTonKho.Columns["DonGiaBan"].HeaderText = "Giá bán (VNĐ)";
                    dgvTonKho.Columns["DonGiaBan"].DefaultCellStyle.Format = "N0";
                    dgvTonKho.Columns["DonGiaBan"].DefaultCellStyle.FormatProvider = vn;
                    dgvTonKho.Columns["DonGiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvTonKho.Columns.Contains("SoLuongTon")) dgvTonKho.Columns["SoLuongTon"].HeaderText = "Tồn kho";
                if (dgvTonKho.Columns.Contains("GiaTriTon"))
                {
                    dgvTonKho.Columns["GiaTriTon"].HeaderText = "Giá trị tồn (VNĐ)";
                    dgvTonKho.Columns["GiaTriTon"].DefaultCellStyle.Format = "N0";
                    dgvTonKho.Columns["GiaTriTon"].DefaultCellStyle.FormatProvider = vn;
                    dgvTonKho.Columns["GiaTriTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                decimal tongGiaTri = baoCaoBus.TongGiaTriTon(dtTonKho);
                lblTongTonKho.Text = $"Tổng giá trị tồn kho: {tongGiaTri.ToString("N0", vn)} VNĐ   |   " +
                                     $"Tổng {dtTonKho.Rows.Count} mặt hàng";

                // ---- Tab 3: Top bán chạy ----
                dtTopBanChay = baoCaoBus.TopBanChay(10);

                dgvTopBanChay.DataSource = dtTopBanChay;
                CauHinhGrid(dgvTopBanChay);
                if (dgvTopBanChay.Columns.Contains("MaHang"))     dgvTopBanChay.Columns["MaHang"].HeaderText     = "Mã hàng";
                if (dgvTopBanChay.Columns.Contains("TenHang"))    dgvTopBanChay.Columns["TenHang"].HeaderText    = "Tên hàng";
                if (dgvTopBanChay.Columns.Contains("Hang"))       dgvTopBanChay.Columns["Hang"].HeaderText       = "Hãng";
                if (dgvTopBanChay.Columns.Contains("SoLuongBan")) dgvTopBanChay.Columns["SoLuongBan"].HeaderText = "Số lượng bán";
                if (dgvTopBanChay.Columns.Contains("DoanhThu"))
                {
                    dgvTopBanChay.Columns["DoanhThu"].HeaderText = "Doanh thu (VNĐ)";
                    dgvTopBanChay.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
                    dgvTopBanChay.Columns["DoanhThu"].DefaultCellStyle.FormatProvider = vn;
                    dgvTopBanChay.Columns["DoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CauHinhGrid(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.EnableHeadersVisualStyles = false;
        }

        // ============================================================
        // XUẤT EXCEL
        // ============================================================

        private void btnXuatExcel_Click(object? sender, EventArgs e)
        {
            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = $"BaoCao_QuanLyCuaHang_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                Title = "Lưu file báo cáo Excel"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var wb = new XLWorkbook();

                // ---- Sheet 1: Doanh thu ----
                var ws1 = wb.Worksheets.Add("DoanhThu");
                ws1.Cell(1, 1).Value = "BÁO CÁO DOANH THU THEO THÁNG";
                ws1.Range("A1:D1").Merge().Style.Font.Bold = true;
                ws1.Range("A1:D1").Style.Font.FontSize = 14;
                ws1.Range("A1:D1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws1.Cell(2, 1).Value = $"Xuất lúc: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                ws1.Cell(2, 1).Style.Font.Italic = true;

                string[] h1 = { "Năm", "Tháng", "Số hóa đơn", "Doanh thu (VNĐ)" };
                for (int i = 0; i < h1.Length; i++)
                {
                    var c = ws1.Cell(4, i + 1);
                    c.Value = h1[i];
                    c.Style.Font.Bold = true;
                    c.Style.Fill.BackgroundColor = XLColor.SteelBlue;
                    c.Style.Font.FontColor = XLColor.White;
                    c.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    c.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                }
                int row = 5;
                decimal tong = 0;
                foreach (DataRow r in dtDoanhThu.Rows)
                {
                    ws1.Cell(row, 1).Value = Convert.ToInt32(r["Nam"]);
                    ws1.Cell(row, 2).Value = Convert.ToInt32(r["Thang"]);
                    ws1.Cell(row, 3).Value = Convert.ToInt32(r["SoHoaDon"]);
                    ws1.Cell(row, 4).Value = Convert.ToDecimal(r["DoanhThu"]);
                    ws1.Cell(row, 4).Style.NumberFormat.Format = "#,##0";
                    ws1.Range(row, 1, row, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    tong += Convert.ToDecimal(r["DoanhThu"]);
                    row++;
                }
                ws1.Cell(row, 3).Value = "TỔNG:";
                ws1.Cell(row, 3).Style.Font.Bold = true;
                ws1.Cell(row, 4).Value = tong;
                ws1.Cell(row, 4).Style.Font.Bold = true;
                ws1.Cell(row, 4).Style.NumberFormat.Format = "#,##0";
                ws1.Columns().AdjustToContents();

                // ---- Sheet 2: Tồn kho ----
                var ws2 = wb.Worksheets.Add("TonKho");
                ws2.Cell(1, 1).Value = "BÁO CÁO TỒN KHO";
                ws2.Range("A1:G1").Merge().Style.Font.Bold = true;
                ws2.Range("A1:G1").Style.Font.FontSize = 14;
                ws2.Range("A1:G1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                string[] h2 = { "Mã hàng", "Tên hàng", "Hãng", "Loại", "Giá bán (VNĐ)", "Tồn kho", "Giá trị tồn (VNĐ)" };
                for (int i = 0; i < h2.Length; i++)
                {
                    var c = ws2.Cell(3, i + 1);
                    c.Value = h2[i];
                    c.Style.Font.Bold = true;
                    c.Style.Fill.BackgroundColor = XLColor.SteelBlue;
                    c.Style.Font.FontColor = XLColor.White;
                    c.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }
                int row2 = 4;
                decimal tongGT = 0;
                foreach (DataRow r in dtTonKho.Rows)
                {
                    ws2.Cell(row2, 1).Value = r["MaHang"].ToString();
                    ws2.Cell(row2, 2).Value = r["TenHang"].ToString();
                    ws2.Cell(row2, 3).Value = r["Hang"].ToString();
                    ws2.Cell(row2, 4).Value = r["Loai"].ToString();
                    ws2.Cell(row2, 5).Value = Convert.ToDecimal(r["DonGiaBan"]);
                    ws2.Cell(row2, 5).Style.NumberFormat.Format = "#,##0";
                    ws2.Cell(row2, 6).Value = Convert.ToInt32(r["SoLuongTon"]);
                    ws2.Cell(row2, 7).Value = Convert.ToDecimal(r["GiaTriTon"]);
                    ws2.Cell(row2, 7).Style.NumberFormat.Format = "#,##0";
                    ws2.Range(row2, 1, row2, 7).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    tongGT += Convert.ToDecimal(r["GiaTriTon"]);
                    row2++;
                }
                ws2.Cell(row2, 6).Value = "TỔNG GIÁ TRỊ:";
                ws2.Cell(row2, 6).Style.Font.Bold = true;
                ws2.Cell(row2, 7).Value = tongGT;
                ws2.Cell(row2, 7).Style.Font.Bold = true;
                ws2.Cell(row2, 7).Style.NumberFormat.Format = "#,##0";
                ws2.Columns().AdjustToContents();

                // ---- Sheet 3: Top bán chạy ----
                var ws3 = wb.Worksheets.Add("TopBanChay");
                ws3.Cell(1, 1).Value = "TOP 10 SẢN PHẨM BÁN CHẠY";
                ws3.Range("A1:E1").Merge().Style.Font.Bold = true;
                ws3.Range("A1:E1").Style.Font.FontSize = 14;
                ws3.Range("A1:E1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                string[] h3 = { "Mã hàng", "Tên hàng", "Hãng", "Số lượng bán", "Doanh thu (VNĐ)" };
                for (int i = 0; i < h3.Length; i++)
                {
                    var c = ws3.Cell(3, i + 1);
                    c.Value = h3[i];
                    c.Style.Font.Bold = true;
                    c.Style.Fill.BackgroundColor = XLColor.SteelBlue;
                    c.Style.Font.FontColor = XLColor.White;
                    c.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }
                int row3 = 4, stt = 1;
                foreach (DataRow r in dtTopBanChay.Rows)
                {
                    ws3.Cell(row3, 1).Value = r["MaHang"].ToString();
                    ws3.Cell(row3, 2).Value = r["TenHang"].ToString();
                    ws3.Cell(row3, 3).Value = r["Hang"].ToString();
                    ws3.Cell(row3, 4).Value = Convert.ToInt32(r["SoLuongBan"]);
                    ws3.Cell(row3, 5).Value = Convert.ToDecimal(r["DoanhThu"]);
                    ws3.Cell(row3, 5).Style.NumberFormat.Format = "#,##0";
                    ws3.Range(row3, 1, row3, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    // Tô màu Top 3
                    if (stt <= 3)
                        ws3.Range(row3, 1, row3, 5).Style.Fill.BackgroundColor = XLColor.Gold;
                    row3++; stt++;
                }
                ws3.Columns().AdjustToContents();

                wb.SaveAs(sfd.FileName);

                MessageBox.Show("Xuất báo cáo Excel thành công!\n" + sfd.FileName,
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = sfd.FileName,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object? sender, EventArgs e) => NapDuLieu();

        private void btnDong_Click(object? sender, EventArgs e) => Close();

        // =====================================================
        // DỰNG GIAO DIỆN
        // Tách khỏi InitializeComponent() để màn [Design] của Visual Studio
        // luôn mở được: trình thiết kế không đọc được vòng lặp và biến cục bộ.
        // =====================================================
        private void TaoGiaoDien()
        {
            tabControl1        = new System.Windows.Forms.TabControl();
            tabDoanhThu        = new System.Windows.Forms.TabPage();
            dgvDoanhThu        = new System.Windows.Forms.DataGridView();
            lblTongDoanhThu    = new System.Windows.Forms.Label();
            tabTonKho          = new System.Windows.Forms.TabPage();
            dgvTonKho          = new System.Windows.Forms.DataGridView();
            lblTongTonKho      = new System.Windows.Forms.Label();
            tabTopBanChay      = new System.Windows.Forms.TabPage();
            dgvTopBanChay      = new System.Windows.Forms.DataGridView();
            panelBottom        = new System.Windows.Forms.Panel();
            btnXuatExcel       = new System.Windows.Forms.Button();
            btnLamMoi          = new System.Windows.Forms.Button();
            btnDong            = new System.Windows.Forms.Button();
            lblTitle           = new System.Windows.Forms.Label();
            // tabControl1
            tabControl1.Controls.Add(tabDoanhThu);
            tabControl1.Controls.Add(tabTonKho);
            tabControl1.Controls.Add(tabTopBanChay);
            tabControl1.Dock      = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Font      = new System.Drawing.Font("Segoe UI", 10f);
            tabControl1.ItemSize  = new System.Drawing.Size(160, 32);
            // tabDoanhThu
            tabDoanhThu.Text = "📊 Doanh thu theo tháng";
            tabDoanhThu.Controls.Add(dgvDoanhThu);
            tabDoanhThu.Controls.Add(lblTongDoanhThu);
            tabDoanhThu.Padding = new System.Windows.Forms.Padding(5);
            dgvDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvDoanhThu.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            lblTongDoanhThu.Dock      = System.Windows.Forms.DockStyle.Bottom;
            lblTongDoanhThu.Height    = 30;
            lblTongDoanhThu.Font      = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            lblTongDoanhThu.ForeColor = System.Drawing.Color.DarkGreen;
            lblTongDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblTongDoanhThu.Padding   = new System.Windows.Forms.Padding(5, 0, 0, 0);
            lblTongDoanhThu.Text      = "Đang tải...";
            // tabTonKho
            tabTonKho.Text = "📦 Tồn kho";
            tabTonKho.Controls.Add(dgvTonKho);
            tabTonKho.Controls.Add(lblTongTonKho);
            tabTonKho.Padding = new System.Windows.Forms.Padding(5);
            dgvTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvTonKho.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            lblTongTonKho.Dock      = System.Windows.Forms.DockStyle.Bottom;
            lblTongTonKho.Height    = 30;
            lblTongTonKho.Font      = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            lblTongTonKho.ForeColor = System.Drawing.Color.DarkBlue;
            lblTongTonKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblTongTonKho.Padding   = new System.Windows.Forms.Padding(5, 0, 0, 0);
            lblTongTonKho.Text      = "Đang tải...";
            // tabTopBanChay
            tabTopBanChay.Text = "🏆 Top bán chạy";
            tabTopBanChay.Controls.Add(dgvTopBanChay);
            tabTopBanChay.Padding = new System.Windows.Forms.Padding(5);
            dgvTopBanChay.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvTopBanChay.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            // panelBottom (buttons)
            panelBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Height    = 55;
            panelBottom.Padding   = new System.Windows.Forms.Padding(10, 8, 10, 8);
            panelBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            panelBottom.Controls.Add(btnDong);
            panelBottom.Controls.Add(btnLamMoi);
            panelBottom.Controls.Add(btnXuatExcel);
            btnXuatExcel.Text      = "📄 Xuất Excel";
            btnXuatExcel.Size      = new System.Drawing.Size(140, 36);
            btnXuatExcel.Location  = new System.Drawing.Point(10, 9);
            btnXuatExcel.BackColor = System.Drawing.Color.ForestGreen;
            btnXuatExcel.ForeColor = System.Drawing.Color.White;
            btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnXuatExcel.Font      = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            btnXuatExcel.Click    += btnXuatExcel_Click;
            btnLamMoi.Text      = "🔄 Làm mới";
            btnLamMoi.Size      = new System.Drawing.Size(120, 36);
            btnLamMoi.Location  = new System.Drawing.Point(160, 9);
            btnLamMoi.BackColor = System.Drawing.Color.SteelBlue;
            btnLamMoi.ForeColor = System.Drawing.Color.White;
            btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLamMoi.Font      = new System.Drawing.Font("Segoe UI", 10f);
            btnLamMoi.Click    += btnLamMoi_Click;
            btnDong.Text      = "✖ Đóng";
            btnDong.Size      = new System.Drawing.Size(100, 36);
            btnDong.Location  = new System.Drawing.Point(290, 9);
            btnDong.BackColor = System.Drawing.Color.Crimson;
            btnDong.ForeColor = System.Drawing.Color.White;
            btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDong.Font      = new System.Drawing.Font("Segoe UI", 10f);
            btnDong.Click    += btnDong_Click;
            // lblTitle
            lblTitle.Text      = "BÁO CÁO THỐNG KÊ CỬA HÀNG ĐIỆN THOẠI";
            lblTitle.Dock      = System.Windows.Forms.DockStyle.Top;
            lblTitle.Height    = 50;
            lblTitle.Font      = new System.Drawing.Font("Segoe UI", 15f, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTitle.BackColor = System.Drawing.Color.AliceBlue;
            // Form
            this.Controls.Add(tabControl1);
            this.Controls.Add(panelBottom);
            this.Controls.Add(lblTitle);
            this.BackColor = System.Drawing.Color.White;
        }

        // =====================================================
        // CÁC HÀM HỖ TRỢ THIẾT KẾ
        // =====================================================

    }
}
