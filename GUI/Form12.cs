using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4.GUI
{
    /// <summary>
    /// Trang Khách hàng (dành cho tài khoản đăng ký trong tblKhachHang):
    /// - Xem điện thoại: danh sách thẻ sản phẩm kèm ảnh (cột TenAnh), giá bán và tồn kho.
    /// - Giỏ hàng / Mua hàng: thêm, sửa số lượng, xóa và đặt mua.
    /// - Hóa đơn của tôi: lịch sử hóa đơn kèm trạng thái thanh toán.
    /// - Thanh toán: chọn Tiền mặt khi nhận hàng hoặc Chuyển khoản ngân hàng.
    /// Mọi truy vấn đều đi qua tầng BUS → DAL → Stored Procedure, không có SQL viết trực tiếp.
    /// </summary>
    public partial class Form12 : Form
    {
        // ================= MÀU SẮC =================

        private readonly Color mauNavy = Color.FromArgb(20, 43, 74);
        private readonly Color mauBlue = Color.FromArgb(36, 120, 212);
        private readonly Color mauNen = Color.FromArgb(244, 247, 251);
        private readonly Color mauChu = Color.FromArgb(35, 51, 72);
        private readonly Color mauPhu = Color.FromArgb(112, 128, 150);

        // ================= PANEL =================

        private Panel pnlSidebar;
        private Panel pnlHeader;
        private Panel pnlNoiDung;
        private Panel pnlRightSidebar;

        private Label lblTieuDe;
        private Label lblTaiKhoan;

        private TableLayoutPanel tblBoCuc;
        private ToolTip toolTip;

        private Form? formDangHienThi;

        private readonly HangHoaBUS hangHoaBus = new HangHoaBUS();
        private readonly HoaDonBanBUS hoaDonBanBus = new HoaDonBanBUS();
        private readonly NhanVienBUS nhanVienBus = new NhanVienBUS();

        private DataTable dtDienThoai = new DataTable();

        // ================= GIỎ HÀNG =================

        private class GioHangItem
        {
            public string MaHang { get; set; } = "";
            public string TenHang { get; set; } = "";
            public int SoLuong { get; set; }
            public decimal DonGia { get; set; }

            public decimal ThanhTien => SoLuong * DonGia;
        }

        private readonly Dictionary<string, GioHangItem> gioHang =
            new Dictionary<string, GioHangItem>(
                StringComparer.OrdinalIgnoreCase);

        /// <summary>Nhân viên được ghi nhận là người lập hóa đơn cho đơn khách tự đặt.</summary>
        private string maNhanVienLapHoaDon = "";

        /// <summary>Mã hóa đơn vừa được tạo từ giỏ hàng (để trang Thanh toán chọn sẵn).</summary>
        private string maHoaDonVuaTao = "";

        // ================= THÔNG TIN CHUYỂN KHOẢN =================

        // Thay các giá trị này bằng thông tin tài khoản ngân hàng thật của cửa hàng.
        private const string TEN_NGAN_HANG = "Tên ngân hàng";
        private const string SO_TAI_KHOAN = "Số tài khoản";
        private const string TEN_CHU_TAI_KHOAN = "Tên chủ tài khoản";

        private string ThuMucAnh => AppHelpers.ThuMucAnh;

        // ================= KHÁCH HÀNG =================

        private string tenNguoiDung = "";
        private string maKhachHang = "";
        private string vaiTro = "Khách hàng";

        public Form12()
        {
            InitializeComponent();

            Text = "PHONE STORE - KHÁCH HÀNG";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(1100, 700);
            BackColor = mauNen;
            Font = new Font("Segoe UI", 10F);

            tenNguoiDung = string.IsNullOrWhiteSpace(Form9.TenKHDangNhap)
                ? "Khách hàng"
                : Form9.TenKHDangNhap.Trim();

            maKhachHang = (Form9.MaKHDangNhap ?? "").Trim();

            toolTip = new ToolTip();

            TaoGiaoDien();

            Load += Form12_Load;
        }

        // =====================================================
        //                    GIAO DIỆN TỔNG
        // =====================================================

        private void TaoGiaoDien()
        {
            pnlSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 500,
                BackColor = mauNavy
            };

            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 110,
                BackColor = Color.White,
                Padding = new Padding(24, 0, 24, 0)
            };

            pnlNoiDung = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = mauNen,
                Padding = Padding.Empty
            };

            TaoSidebar();
            TaoHeader();

            tblBoCuc = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                ColumnCount = 3,
                RowCount = 2,
                BackColor = mauNen
            };

            tblBoCuc.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 500F));

            tblBoCuc.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            tblBoCuc.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 400F));

            tblBoCuc.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 110F));

            tblBoCuc.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            pnlSidebar.Dock = DockStyle.Fill;
            pnlHeader.Dock = DockStyle.Fill;
            pnlNoiDung.Dock = DockStyle.Fill;

            pnlRightSidebar = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(12),
                AutoScroll = true
            };

            TaoRightSidebar();

            tblBoCuc.Controls.Add(pnlSidebar, 0, 0);
            tblBoCuc.SetRowSpan(pnlSidebar, 2);

            tblBoCuc.Controls.Add(pnlHeader, 1, 0);
            tblBoCuc.SetColumnSpan(pnlHeader, 2);

            tblBoCuc.Controls.Add(pnlNoiDung, 1, 1);
            tblBoCuc.Controls.Add(pnlRightSidebar, 2, 1);

            Controls.Clear();
            Controls.Add(tblBoCuc);
        }

        // =====================================================
        //                    SIDEBAR PHẢI
        // =====================================================

        private void TaoRightSidebar()
        {
            TableLayoutPanel tblRight = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = Color.White,
                Margin = Padding.Empty,
                Padding = new Padding(8)
            };

            tblRight.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            tblRight.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 42F));

            tblRight.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            tblRight.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 115F));

            Label lblTieuDeRight = new Label
            {
                Text = "THÔNG TIN NỔI BẬT",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(23, 43, 77),
                TextAlign = ContentAlignment.MiddleCenter
            };

            TableLayoutPanel tblAnh = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.White,
                Margin = Padding.Empty
            };

            tblAnh.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            tblAnh.RowStyles.Add(
                new RowStyle(SizeType.Percent, 50F));

            tblAnh.RowStyles.Add(
                new RowStyle(SizeType.Percent, 50F));

            Panel pnlKhuyenMai = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(3)
            };

            Label lblKhuyenMai = new Label
            {
                Text = "KHUYẾN MÃI HOT",
                Dock = DockStyle.Top,
                Height = 30,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(23, 43, 77)
            };

            PictureBox picBanner =
                TaoPictureBoxChuan("banner_khuyenmai.jpg", 340, 200);

            picBanner.Dock = DockStyle.Fill;

            pnlKhuyenMai.Controls.Add(picBanner);
            pnlKhuyenMai.Controls.Add(lblKhuyenMai);

            Panel pnlDienThoai = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(3)
            };

            Label lblDienThoai = new Label
            {
                Text = "ĐIỆN THOẠI NỔI BẬT",
                Dock = DockStyle.Top,
                Height = 30,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(23, 43, 77)
            };

            Label lblTenDienThoai = new Label
            {
                Text = "iPhone 18",
                Dock = DockStyle.Bottom,
                Height = 28,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(23, 43, 77),
                TextAlign = ContentAlignment.MiddleCenter
            };

            PictureBox picDienThoai =
                TaoPictureBoxChuan("iphone18.jpg", 340, 200);

            picDienThoai.Dock = DockStyle.Fill;

            pnlDienThoai.Controls.Add(picDienThoai);
            pnlDienThoai.Controls.Add(lblTenDienThoai);
            pnlDienThoai.Controls.Add(lblDienThoai);

            tblAnh.Controls.Add(pnlKhuyenMai, 0, 0);
            tblAnh.Controls.Add(pnlDienThoai, 0, 1);

            Panel pnlThongTin = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 248, 252),
                Padding = new Padding(8),
                Margin = new Padding(0, 5, 0, 0)
            };

            Label lblTieuDeThongTin = new Label
            {
                Text = "THÔNG TIN CỬA HÀNG",
                Dock = DockStyle.Top,
                Height = 30,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(23, 43, 77)
            };

            Label lblLienHe = new Label
            {
                Text = "Hotline: 1900 xxxx\n" +
                       "Hỗ trợ khách hàng 24/7\n" +
                       "Chính sách bảo hành và đổi trả uy tín",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(80, 90, 105)
            };

            pnlThongTin.Controls.Add(lblLienHe);
            pnlThongTin.Controls.Add(lblTieuDeThongTin);

            tblRight.Controls.Add(lblTieuDeRight, 0, 0);
            tblRight.Controls.Add(tblAnh, 0, 1);
            tblRight.Controls.Add(pnlThongTin, 0, 2);

            pnlRightSidebar.Controls.Clear();
            pnlRightSidebar.Controls.Add(tblRight);
        }

        /// <summary>Nạp ảnh trong thư mục Images/; thiếu tệp thì để trống, không chặn giao diện.</summary>
        private PictureBox TaoPictureBoxChuan(
            string tenAnh, int chieuRong, int chieuCao)
        {
            PictureBox pic = new PictureBox
            {
                Width = chieuRong,
                Height = chieuCao,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.White,
                Margin = new Padding(0, 5, 0, 10)
            };

            Image? anh = DocAnh(tenAnh);
            if (anh != null) pic.Image = anh;

            return pic;
        }

        /// <summary>Đọc một tệp ảnh trong thư mục Images/ theo tên tệp đã lưu trong cột TenAnh.</summary>
        private Image? DocAnh(string? tenAnh)
        {
            if (string.IsNullOrWhiteSpace(tenAnh)) return null;

            try
            {
                string duongDan = Path.Combine(
                    ThuMucAnh, Path.GetFileName(tenAnh.Trim()));

                if (!File.Exists(duongDan)) return null;

                using Image goc = Image.FromFile(duongDan);
                return new Bitmap(goc);
            }
            catch
            {
                // Ảnh hỏng hoặc không đọc được: bỏ qua để trang vẫn hiển thị bình thường.
                return null;
            }
        }

        // =====================================================
        //                    SIDEBAR TRÁI
        // =====================================================

        private void TaoSidebar()
        {
            Panel pnlLogo = new Panel
            {
                Dock = DockStyle.Top,
                Height = 105,
                BackColor = mauNavy,
                Padding = new Padding(20, 18, 10, 10)
            };

            Label lblLogo = new Label
            {
                Text = "▣  PHONE STORE",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 17F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(18, 22)
            };

            Label lblPhu = new Label
            {
                Text = "CUSTOMER SYSTEM",
                ForeColor = Color.FromArgb(175, 195, 220),
                Font = new Font("Segoe UI", 8.5F),
                AutoSize = true,
                Location = new Point(21, 56)
            };

            pnlLogo.Controls.Add(lblLogo);
            pnlLogo.Controls.Add(lblPhu);

            FlowLayoutPanel flpMenu = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                BackColor = mauNavy,
                Padding = new Padding(12)
            };

            flpMenu.Controls.Add(TaoNhomMenu("MUA SẮM"));

            flpMenu.Controls.Add(TaoNutMenu("▣", "Xem điện thoại",
                HienThiDienThoai));

            flpMenu.Controls.Add(TaoNutMenu("🛒", "Giỏ hàng / Mua hàng",
                HienThiGioHang));

            flpMenu.Controls.Add(TaoNhomMenu("GIAO DỊCH"));

            flpMenu.Controls.Add(TaoNutMenu("▤", "Hóa đơn của tôi",
                HienThiHoaDon));

            flpMenu.Controls.Add(TaoNutMenu("▱", "Thanh toán",
                HienThiThanhToan));

            Panel pnlDangXuat = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 65,
                BackColor = mauNavy,
                Padding = new Padding(12, 8, 12, 8)
            };

            Button btnDangXuat = TaoNutMenu("⇥", "Đăng xuất", () =>
            {
                if (MessageBox.Show(
                    "Bạn có muốn đăng xuất khỏi hệ thống?",
                    "Xác nhận đăng xuất",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Close();
                }
            });

            btnDangXuat.Dock = DockStyle.Fill;
            pnlDangXuat.Controls.Add(btnDangXuat);

            pnlSidebar.Controls.Add(flpMenu);
            pnlSidebar.Controls.Add(pnlDangXuat);
            pnlSidebar.Controls.Add(pnlLogo);
        }

        // =====================================================
        //                       HEADER
        // =====================================================

        private void TaoHeader()
        {
            lblTieuDe = new Label
            {
                Text = "Xem điện thoại",
                AutoSize = true,
                Font = new Font("Segoe UI", 17F, FontStyle.Bold),
                ForeColor = mauChu,
                Location = new Point(24, 21)
            };

            lblTaiKhoan = new Label
            {
                Text = tenNguoiDung + "  |  " + vaiTro,
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = mauNavy,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Controls.Add(lblTaiKhoan);

            pnlHeader.Resize += (s, e) =>
            {
                lblTaiKhoan.Location = new Point(
                    pnlHeader.ClientSize.Width - lblTaiKhoan.Width - 28,
                    28);
            };
        }

        private Label TaoNhomMenu(string text)
        {
            return new Label
            {
                Text = text,
                Width = 440,
                Height = 34,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.FromArgb(151, 174, 202),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Margin = new Padding(4, 13, 4, 3),
                Padding = new Padding(8, 0, 0, 0)
            };
        }

        private Button TaoNutMenu(
            string icon, string text, Action hanhDong)
        {
            Button btn = new Button
            {
                Text = "  " + icon + "     " + text,
                Width = 440,
                Height = 45,
                FlatStyle = FlatStyle.Flat,
                BackColor = mauNavy,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F),
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand,
                Margin = new Padding(3),
                Padding = new Padding(8, 0, 0, 0)
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(39, 72, 111);

            btn.Click += (s, e) => hanhDong();

            return btn;
        }

        // =====================================================
        //                    FORM LOAD
        // =====================================================

        private void Form12_Load(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maKhachHang))
            {
                MessageBox.Show(
                    "Không tìm thấy mã khách hàng đăng nhập. Vui lòng đăng nhập lại.",
                    "Lỗi tài khoản",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                Close();
                return;
            }

            XacDinhNhanVienLapHoaDon();
            HienThiDienThoai();
        }

        /// <summary>
        /// Hóa đơn do khách tự đặt vẫn phải ghi nhận một nhân viên lập:
        /// ưu tiên nhân viên đang đăng nhập, sau đó NV001, cuối cùng là nhân viên đầu tiên trong bảng.
        /// </summary>
        private void XacDinhNhanVienLapHoaDon()
        {
            maNhanVienLapHoaDon = "";

            try
            {
                if (!string.IsNullOrWhiteSpace(Form9.MaNVDangNhap))
                {
                    maNhanVienLapHoaDon = Form9.MaNVDangNhap.Trim();
                    return;
                }

                if (!string.IsNullOrWhiteSpace(nhanVienBus.LayTen("NV001")))
                {
                    maNhanVienLapHoaDon = "NV001";
                    return;
                }

                List<string> dsMaNV = nhanVienBus.LayDanhSachMa();
                if (dsMaNV.Count > 0) maNhanVienLapHoaDon = dsMaNV[0];
            }
            catch
            {
                maNhanVienLapHoaDon = "";
            }
        }

        private void TaoTrangNoiDung(string tieuDe)
        {
            DongFormDangHienThi();

            lblTieuDe.Text = tieuDe;
            pnlNoiDung.Controls.Clear();
        }

        private Label TaoLabel(
            string noiDung, int coChu, bool dam,
            Color mau, Point viTri)
        {
            return new Label
            {
                Text = noiDung,
                Font = new Font(
                    "Segoe UI", coChu,
                    dam ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = mau,
                AutoSize = true,
                Location = viTri
            };
        }

        // =====================================================
        //                    XEM ĐIỆN THOẠI
        // =====================================================

        private void HienThiDienThoai()
        {
            DongFormDangHienThi();

            lblTieuDe.Text = "Xem điện thoại";
            pnlNoiDung.Controls.Clear();

            Panel pnlTrang = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = mauNen,
                Padding = new Padding(15),
                AutoScroll = true
            };

            Label lblDanhSach = new Label
            {
                Text = "DANH SÁCH ĐIỆN THOẠI",
                Dock = DockStyle.Top,
                Height = 60,
                Font = new Font("Segoe UI", 17F, FontStyle.Bold),
                ForeColor = mauNavy
            };

            Panel pnlTimKiem = new Panel
            {
                Dock = DockStyle.Top,
                Height = 48,
                BackColor = mauNen
            };

            TextBox txtTimKiem = new TextBox
            {
                Location = new Point(0, 5),
                Width = 280,
                Height = 30,
                Font = new Font("Segoe UI", 10F)
            };

            Button btnTim = new Button
            {
                Text = "TÌM",
                Location = new Point(290, 3),
                Size = new Size(90, 32),
                BackColor = mauBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnTim.FlatAppearance.BorderSize = 0;

            pnlTimKiem.Controls.Add(txtTimKiem);
            pnlTimKiem.Controls.Add(btnTim);

            FlowLayoutPanel flpSanPham = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = mauNen,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(5)
            };

            pnlTrang.Controls.Add(flpSanPham);
            pnlTrang.Controls.Add(pnlTimKiem);
            pnlTrang.Controls.Add(lblDanhSach);

            pnlNoiDung.Controls.Add(pnlTrang);

            try
            {
                dtDienThoai = hangHoaBus.LayDanhSach();
                HienThiTheSanPham(flpSanPham, "");

                btnTim.Click += (s, e) =>
                    HienThiTheSanPham(flpSanPham, txtTimKiem.Text.Trim());

                txtTimKiem.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        HienThiTheSanPham(
                            flpSanPham, txtTimKiem.Text.Trim());
                        e.SuppressKeyPress = true;
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách điện thoại:\n" + ex.Message,
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void HienThiTheSanPham(
            FlowLayoutPanel flp, string tuKhoa)
        {
            flp.SuspendLayout();
            flp.Controls.Clear();

            if (dtDienThoai == null || dtDienThoai.Rows.Count == 0)
            {
                flp.Controls.Add(new Label
                {
                    Text = "Hiện chưa có điện thoại trong cửa hàng.",
                    AutoSize = true,
                    ForeColor = mauPhu,
                    Margin = new Padding(15)
                });

                flp.ResumeLayout();
                return;
            }

            foreach (DataRow row in dtDienThoai.Rows)
            {
                string maHang = row["MaHang"]?.ToString() ?? "";
                string tenHang = row["TenHang"]?.ToString() ?? "";
                string hang = row["Hang"]?.ToString() ?? "";
                string mau = row["Mau"]?.ToString() ?? "";
                string dungLuong = row["DungLuong"]?.ToString() ?? "";
                string tenAnh = row.Table.Columns.Contains("TenAnh") &&
                                row["TenAnh"] != DBNull.Value
                    ? row["TenAnh"].ToString() ?? ""
                    : "";

                decimal giaBan = row["GiaBan"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(row["GiaBan"]);

                int soLuong = row["SoLuong"] == DBNull.Value
                    ? 0
                    : Convert.ToInt32(row["SoLuong"]);

                string noiDungTim = maHang + " " + tenHang + " " + hang;

                if (!string.IsNullOrWhiteSpace(tuKhoa) &&
                    !noiDungTim.Contains(
                        tuKhoa, StringComparison.OrdinalIgnoreCase))
                    continue;

                Panel pnlThe = new Panel
                {
                    Width = 205,
                    Height = 400,
                    BackColor = Color.White,
                    Margin = new Padding(7),
                    Padding = new Padding(9)
                };

                toolTip.SetToolTip(pnlThe, tenHang + " - " + hang);

                PictureBox pic = new PictureBox
                {
                    Dock = DockStyle.Top,
                    Height = 165,
                    BackColor = Color.White,
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                Image? anh = DocAnh(tenAnh);
                if (anh != null) pic.Image = anh;

                Label lblTen = new Label
                {
                    Text = tenHang,
                    Dock = DockStyle.Top,
                    Height = 45,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = mauChu
                };

                Label lblThongTin = new Label
                {
                    Text = hang + "\n" + mau + " - " + dungLuong,
                    Dock = DockStyle.Top,
                    Height = 40,
                    Font = new Font("Segoe UI", 8.5F),
                    ForeColor = mauPhu
                };

                Label lblGia = new Label
                {
                    Text = AppHelpers.DinhDangTienVnd(giaBan),
                    Dock = DockStyle.Top,
                    Height = 45,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(220, 35, 45)
                };

                Label lblSoLuong = new Label
                {
                    Text = soLuong > 0
                        ? "Còn hàng: " + soLuong
                        : "Tạm hết hàng",
                    Dock = DockStyle.Top,
                    Height = 40,
                    ForeColor = soLuong > 0
                        ? Color.ForestGreen : Color.Red
                };

                Button btnMua = new Button
                {
                    Text = "THÊM VÀO GIỎ",
                    Dock = DockStyle.Bottom,
                    Height = 35,
                    BackColor = mauBlue,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Cursor = Cursors.Hand,
                    Enabled = soLuong > 0
                };

                btnMua.FlatAppearance.BorderSize = 0;

                btnMua.Click += (s, e) =>
                {
                    ThemVaoGio(maHang, tenHang, giaBan, soLuong);
                };

                pnlThe.Controls.Add(btnMua);
                pnlThe.Controls.Add(lblSoLuong);
                pnlThe.Controls.Add(lblGia);
                pnlThe.Controls.Add(lblThongTin);
                pnlThe.Controls.Add(lblTen);
                pnlThe.Controls.Add(pic);

                flp.Controls.Add(pnlThe);
            }

            if (flp.Controls.Count == 0)
            {
                flp.Controls.Add(new Label
                {
                    Text = "Không tìm thấy sản phẩm phù hợp.",
                    AutoSize = true,
                    ForeColor = mauPhu,
                    Margin = new Padding(15)
                });
            }

            flp.ResumeLayout();
        }

        // =====================================================
        //                    THÊM VÀO GIỎ
        // =====================================================

        private void ThemVaoGio(
            string maHang, string tenHang,
            decimal donGia, int tonKho)
        {
            if (tonKho <= 0)
            {
                MessageBox.Show("Sản phẩm hiện đã hết hàng.");
                return;
            }

            if (gioHang.ContainsKey(maHang))
            {
                if (gioHang[maHang].SoLuong >= tonKho)
                {
                    MessageBox.Show(
                        "Số lượng trong giỏ đã đạt số lượng tồn kho.");
                    return;
                }

                gioHang[maHang].SoLuong++;
            }
            else
            {
                gioHang.Add(maHang, new GioHangItem
                {
                    MaHang = maHang,
                    TenHang = tenHang,
                    DonGia = donGia,
                    SoLuong = 1
                });
            }

            MessageBox.Show(
                "Đã thêm " + tenHang + " vào giỏ hàng.",
                "Thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =====================================================
        //                    HIỂN THỊ GIỎ HÀNG
        // =====================================================

        private void HienThiGioHang()
        {
            TaoTrangNoiDung("Giỏ hàng / Mua hàng");

            Panel pnl = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = mauNen,
                Padding = new Padding(20),
                AutoScroll = true,
                AutoScrollMinSize = new Size(1150, 830)
            };

            Label lblTieuDeTrang = TaoLabel(
                "GIỎ HÀNG CỦA BẠN",
                16, true, mauNavy, new Point(20, 15));

            DataGridView dgvGioHang = TaoBangDuLieu();
            dgvGioHang.ReadOnly = false;
            dgvGioHang.Location = new Point(22, 90);
            dgvGioHang.Size = new Size(1100, 600);
            dgvGioHang.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            dgvGioHang.Columns.Add("MaDT", "Mã điện thoại");
            dgvGioHang.Columns.Add("TenDT", "Tên điện thoại");
            dgvGioHang.Columns.Add("SoLuong", "Số lượng");
            dgvGioHang.Columns.Add("DonGia", "Đơn giá");
            dgvGioHang.Columns.Add("ThanhTien", "Thành tiền");

            dgvGioHang.Columns["MaDT"].ReadOnly = true;
            dgvGioHang.Columns["TenDT"].ReadOnly = true;
            dgvGioHang.Columns["DonGia"].ReadOnly = true;
            dgvGioHang.Columns["ThanhTien"].ReadOnly = true;
            dgvGioHang.Columns["SoLuong"].ReadOnly = false;

            Label lblTongTien = TaoLabel(
                "Tổng tiền: 0 đ",
                14, true, mauNavy, new Point(22, 710));

            // NÚT CẬP NHẬT SỐ LƯỢNG
            Button btnCapNhat = new Button
            {
                Text = "CẬP NHẬT SỐ LƯỢNG",
                Location = new Point(22, 755),
                Size = new Size(180, 45),
                BackColor = mauNavy,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            // NÚT XÓA SẢN PHẨM
            Button btnXoa = new Button
            {
                Text = "XÓA SẢN PHẨM",
                Location = new Point(212, 755),
                Size = new Size(150, 45),
                BackColor = Color.FromArgb(200, 55, 55),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            // NÚT CHUYỂN SANG THANH TOÁN
            Button btnChuyenThanhToan = new Button
            {
                Text = "CHUYỂN SANG THANH TOÁN",
                Location = new Point(372, 755),
                Size = new Size(270, 45),
                BackColor = Color.FromArgb(22, 163, 74),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            btnCapNhat.FlatAppearance.BorderSize = 0;
            btnXoa.FlatAppearance.BorderSize = 0;
            btnChuyenThanhToan.FlatAppearance.BorderSize = 0;

            // NẠP DỮ LIỆU GIỎ HÀNG
            void NapGioHang()
            {
                dgvGioHang.Rows.Clear();

                decimal tongTien = 0;

                foreach (GioHangItem sp in gioHang.Values)
                {
                    int index = dgvGioHang.Rows.Add(
                        sp.MaHang,
                        sp.TenHang,
                        sp.SoLuong,
                        sp.DonGia.ToString("N0", AppHelpers.ViVn),
                        sp.ThanhTien.ToString("N0", AppHelpers.ViVn));

                    dgvGioHang.Rows[index].Tag = sp.MaHang;

                    tongTien += sp.ThanhTien;
                }

                lblTongTien.Text =
                    "Tổng tiền: " + AppHelpers.DinhDangTienVnd(tongTien);
            }

            // CẬP NHẬT SỐ LƯỢNG
            bool CapNhatSoLuong()
            {
                dgvGioHang.EndEdit();

                foreach (DataGridViewRow row in dgvGioHang.Rows)
                {
                    string maHang = row.Tag?.ToString() ?? "";

                    if (!gioHang.ContainsKey(maHang))
                        continue;

                    int soLuong;

                    if (!int.TryParse(
                        row.Cells["SoLuong"].Value?.ToString(),
                        out soLuong) || soLuong <= 0)
                    {
                        MessageBox.Show(
                            "Số lượng phải là số nguyên lớn hơn 0.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        NapGioHang();
                        return false;
                    }

                    gioHang[maHang].SoLuong = soLuong;
                }

                NapGioHang();
                return true;
            }

            btnCapNhat.Click += (s, e) =>
            {
                CapNhatSoLuong();
            };

            // XÓA SẢN PHẨM
            btnXoa.Click += (s, e) =>
            {
                if (dgvGioHang.CurrentRow == null)
                {
                    MessageBox.Show("Bạn hãy chọn sản phẩm cần xóa.");
                    return;
                }

                string maHang =
                    dgvGioHang.CurrentRow.Tag?.ToString() ?? "";

                if (gioHang.ContainsKey(maHang))
                {
                    gioHang.Remove(maHang);
                    NapGioHang();
                }
            };

            // CHUYỂN GIỎ HÀNG SANG THANH TOÁN
            btnChuyenThanhToan.Click += (s, e) =>
            {
                if (gioHang.Count == 0)
                {
                    MessageBox.Show(
                        "Giỏ hàng đang trống! Vui lòng thêm sản phẩm.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Lưu số lượng mới nhất người dùng vừa chỉnh sửa
                if (!CapNhatSoLuong())
                    return;

                // Tạo hóa đơn và chuyển sang giao diện thanh toán
                DatMuaVaTaoHoaDon();
            };

            // THÊM CÁC ĐIỀU KHIỂN VÀO TRANG
            pnl.Controls.Add(lblTieuDeTrang);
            pnl.Controls.Add(dgvGioHang);
            pnl.Controls.Add(lblTongTien);
            pnl.Controls.Add(btnCapNhat);
            pnl.Controls.Add(btnXoa);
            pnl.Controls.Add(btnChuyenThanhToan);

            btnChuyenThanhToan.BringToFront();

            pnlNoiDung.Controls.Add(pnl);

            NapGioHang();
        }

        private decimal TinhTongTien()
        {
            return gioHang.Values.Sum(x => x.ThanhTien);
        }

        // =====================================================
        //               ĐẶT MUA VÀ TẠO HÓA ĐƠN
        // =====================================================

        private void DatMuaVaTaoHoaDon()
        {
            if (string.IsNullOrWhiteSpace(maKhachHang))
            {
                MessageBox.Show("Không xác định được khách hàng.");
                return;
            }

            if (gioHang.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống.");
                return;
            }

            if (string.IsNullOrWhiteSpace(maNhanVienLapHoaDon))
            {
                MessageBox.Show(
                    "Chưa xác định được nhân viên lập hóa đơn trong hệ thống.\n" +
                    "Vui lòng liên hệ cửa hàng để được hỗ trợ.",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            decimal tongTienDuKien = TinhTongTien();

            DialogResult xacNhan = MessageBox.Show(
                "Bạn xác nhận đặt mua đơn hàng?\n\n" +
                "Tổng tiền dự kiến: " +
                AppHelpers.DinhDangTienVnd(tongTienDuKien),
                "Xác nhận đặt hàng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            string maHoaDon = "HD" +
                Guid.NewGuid().ToString("N").Substring(0, 8)
                    .ToUpperInvariant();

            try
            {
                // Đơn khách tự đặt: lập hóa đơn qua HoaDonBanBUS → DAL → thủ tục lưu trữ
                // (kiểm tra trùng mã, trừ tồn kho có điều kiện, ghi đầu hóa đơn và chi tiết
                // trong cùng một giao dịch).
                var hoaDon = new HoaDonBan(
                    maHoaDon, maNhanVienLapHoaDon, maKhachHang, DateTime.Now);

                foreach (GioHangItem item in gioHang.Values)
                {
                    HangHoa? hang = hangHoaBus.LayTheoMa(item.MaHang);

                    if (hang == null)
                    {
                        MessageBox.Show(
                            "Sản phẩm " + item.TenHang + " không còn tồn tại.",
                            "Lỗi đặt hàng",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    if (hang.SoLuongTon < item.SoLuong)
                    {
                        MessageBox.Show(
                            "Sản phẩm " + item.TenHang + " không đủ hàng.\n" +
                            "Tồn kho hiện tại: " + hang.SoLuongTon + "\n" +
                            "Số lượng cần mua: " + item.SoLuong,
                            "Lỗi đặt hàng",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    // Dùng giá bán hiện tại trong cơ sở dữ liệu, không dùng giá đã lưu trong giỏ
                    hoaDon.ChiTietList.Add(new ChiTietHoaDonBan(
                        maHoaDon, item.MaHang, item.TenHang,
                        item.SoLuong, hang.GiaBan, 0));
                }

                if (!hoaDonBanBus.LuuHoaDon(hoaDon, out string error))
                {
                    MessageBox.Show(
                        "Không thể đặt mua:\n" + error,
                        "Lỗi đặt hàng",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Đặt mua thành công: xóa giỏ hàng và ghi nhớ hóa đơn vừa tạo
                gioHang.Clear();
                maHoaDonVuaTao = maHoaDon;

                MessageBox.Show(
                    "ĐẶT HÀNG THÀNH CÔNG!\n\n" +
                    "Mã hóa đơn: " + maHoaDon + "\n" +
                    "Tổng tiền: " + AppHelpers.DinhDangTienVnd(hoaDon.TongTien) + "\n\n" +
                    "Hệ thống sẽ chuyển bạn đến mục Thanh toán.",
                    "Đặt hàng thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                HienThiThanhToan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể đặt mua:\n" + ex.Message,
                    "Lỗi đặt hàng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        //               PHƯƠNG THỨC THANH TOÁN
        // =====================================================

        private void ChonPhuongThucThanhToan(
            string maHD, decimal tongTien)
        {
            using (Form frm = new Form())
            {
                frm.Text = "Chọn phương thức thanh toán";
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Size = new Size(520, 430);
                frm.FormBorderStyle = FormBorderStyle.FixedDialog;
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.BackColor = Color.White;
                frm.Font = new Font("Segoe UI", 10F);

                Label lblTieuDeForm = new Label
                {
                    Text = "THANH TOÁN ĐƠN HÀNG",
                    Location = new Point(25, 20),
                    Size = new Size(450, 35),
                    Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                    ForeColor = mauNavy,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Label lblHoaDon = new Label
                {
                    Text = "Mã hóa đơn: " + maHD,
                    Location = new Point(35, 70),
                    AutoSize = true,
                    ForeColor = mauChu
                };

                Label lblTongTien = new Label
                {
                    Text = "Tổng thanh toán: " + AppHelpers.DinhDangTienVnd(tongTien),
                    Location = new Point(35, 100),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(220, 45, 45)
                };

                GroupBox grpPhuongThuc = new GroupBox
                {
                    Text = "PHƯƠNG THỨC THANH TOÁN",
                    Location = new Point(20, 140),
                    Size = new Size(465, 90),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = mauNavy
                };

                RadioButton radTienMat = new RadioButton
                {
                    Text = "TIỀN MẶT KHI NHẬN HÀNG",
                    Location = new Point(18, 36),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = mauChu
                };

                RadioButton radChuyenKhoan = new RadioButton
                {
                    Text = "CHUYỂN KHOẢN NGÂN HÀNG",
                    Location = new Point(240, 36),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = mauChu
                };

                grpPhuongThuc.Controls.Add(radTienMat);
                grpPhuongThuc.Controls.Add(radChuyenKhoan);

                Label lblHuongDan = new Label
                {
                    Location = new Point(35, 245),
                    Size = new Size(440, 60),
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = mauPhu,
                    Text = "Tiền mặt: thanh toán khi nhận hàng.\n" +
                           "Chuyển khoản: hệ thống hiển thị thông tin tài khoản " +
                           "để bạn thực hiện chuyển tiền."
                };

                Button btnXacNhan = new Button
                {
                    Text = "XÁC NHẬN PHƯƠNG THỨC",
                    Location = new Point(35, 320),
                    Size = new Size(270, 42),
                    BackColor = mauBlue,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                };

                Button btnDong = new Button
                {
                    Text = "ĐỂ SAU",
                    Location = new Point(320, 320),
                    Size = new Size(145, 42),
                    BackColor = Color.FromArgb(230, 235, 242),
                    ForeColor = mauChu,
                    FlatStyle = FlatStyle.Flat
                };

                btnXacNhan.FlatAppearance.BorderSize = 0;
                btnDong.FlatAppearance.BorderSize = 0;

                btnXacNhan.Click += (s, e) =>
                {
                    if (!radTienMat.Checked && !radChuyenKhoan.Checked)
                    {
                        MessageBox.Show("Bạn hãy chọn phương thức thanh toán.");
                        return;
                    }

                    string phuongThuc = radTienMat.Checked
                        ? "Tiền mặt"
                        : "Chuyển khoản";

                    if (LuuPhuongThucThanhToan(maHD, phuongThuc))
                    {
                        frm.DialogResult = DialogResult.OK;
                        frm.Close();

                        if (phuongThuc == "Tiền mặt")
                        {
                            MessageBox.Show(
                                "Đã chọn thanh toán tiền mặt khi nhận hàng.\n\n" +
                                "Mã hóa đơn: " + maHD + "\n" +
                                "Trạng thái: Chưa thanh toán",
                                "Đặt phương thức thành công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            HienThiThongTinChuyenKhoan(maHD, tongTien);
                        }
                    }
                };

                btnDong.Click += (s, e) =>
                {
                    frm.Close();
                };

                frm.Controls.Add(lblTieuDeForm);
                frm.Controls.Add(lblHoaDon);
                frm.Controls.Add(lblTongTien);
                frm.Controls.Add(grpPhuongThuc);
                frm.Controls.Add(lblHuongDan);
                frm.Controls.Add(btnXacNhan);
                frm.Controls.Add(btnDong);

                frm.AcceptButton = btnXacNhan;
                frm.CancelButton = btnDong;

                frm.ShowDialog(this);
            }
        }

        /// <summary>Lưu phương thức thanh toán của hóa đơn thuộc khách hàng đang đăng nhập.</summary>
        private bool LuuPhuongThucThanhToan(
            string maHD, string phuongThuc)
        {
            if (hoaDonBanBus.CapNhatPhuongThucThanhToan(
                    maHD, maKhachHang, phuongThuc, out string error))
                return true;

            MessageBox.Show(
                error,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return false;
        }

        private void HienThiThongTinChuyenKhoan(
            string maHD, decimal tongTien)
        {
            string noiDungChuyenKhoan = maHD;

            MessageBox.Show(
                "THÔNG TIN CHUYỂN KHOẢN\n\n" +
                "Ngân hàng: " + TEN_NGAN_HANG + "\n" +
                "Số tài khoản: " + SO_TAI_KHOAN + "\n" +
                "Chủ tài khoản: " + TEN_CHU_TAI_KHOAN + "\n\n" +
                "Số tiền: " + AppHelpers.DinhDangTienVnd(tongTien) + "\n" +
                "Nội dung chuyển khoản: " + noiDungChuyenKhoan + "\n\n" +
                "Sau khi chuyển khoản, cửa hàng cần kiểm tra giao dịch " +
                "và xác nhận đã nhận tiền.\n" +
                "Hóa đơn hiện đang ở trạng thái: Chờ xác nhận chuyển khoản.",
                "Thông tin chuyển khoản",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =====================================================
        //                  HÓA ĐƠN CỦA TÔI
        // =====================================================

        private void HienThiHoaDon()
        {
            TaoTrangNoiDung("Hóa đơn của tôi");

            Panel pnl = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = mauNen,
                Padding = new Padding(20),
                AutoScroll = true
            };

            Label lblTieuDeTrang = TaoLabel(
                "LỊCH SỬ HÓA ĐƠN",
                16, true, mauNavy, new Point(20, 15));

            Label lblMoTa = TaoLabel(
                "Chọn hóa đơn để xem và thực hiện thanh toán.",
                9, false, mauPhu, new Point(22, 48));

            DataGridView dgvHoaDon = TaoBangDuLieu();

            dgvHoaDon.Location = new Point(22, 90);
            dgvHoaDon.Size = new Size(650, 350);
            dgvHoaDon.Anchor =
                AnchorStyles.Top | AnchorStyles.Bottom |
                AnchorStyles.Left | AnchorStyles.Right;

            Button btnTaiLai = new Button
            {
                Text = "TẢI LẠI",
                Location = new Point(22, 465),
                Size = new Size(120, 42),
                BackColor = mauNavy,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            Button btnThanhToan = new Button
            {
                Text = "CHỌN PHƯƠNG THỨC",
                Location = new Point(155, 465),
                Size = new Size(220, 42),
                BackColor = mauBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };

            btnTaiLai.FlatAppearance.BorderSize = 0;
            btnThanhToan.FlatAppearance.BorderSize = 0;

            void NapHoaDon()
            {
                try
                {
                    DataTable dt = hoaDonBanBus.LayHoaDonKhachHang(
                        maKhachHang, false);

                    dgvHoaDon.DataSource = dt;
                    DinhDangBangHoaDon(dgvHoaDon, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Không thể tải hóa đơn:\n" + ex.Message);
                }
            }

            btnTaiLai.Click += (s, e) => NapHoaDon();

            btnThanhToan.Click += (s, e) =>
            {
                if (dgvHoaDon.CurrentRow == null)
                {
                    MessageBox.Show("Bạn hãy chọn hóa đơn cần thanh toán.");
                    return;
                }

                string maHD =
                    dgvHoaDon.CurrentRow.Cells["MaHD"].Value?.ToString() ?? "";

                string trangThai =
                    dgvHoaDon.CurrentRow.Cells["TrangThaiThanhToan"]
                        .Value?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(maHD))
                {
                    MessageBox.Show("Không xác định được mã hóa đơn.");
                    return;
                }

                if (trangThai == "Đã thanh toán")
                {
                    MessageBox.Show("Hóa đơn này đã được thanh toán.");
                    return;
                }

                ThanhToanHoaDon(maHD);
                NapHoaDon();
            };

            pnl.Controls.Add(lblTieuDeTrang);
            pnl.Controls.Add(lblMoTa);
            pnl.Controls.Add(dgvHoaDon);
            pnl.Controls.Add(btnTaiLai);
            pnl.Controls.Add(btnThanhToan);

            pnlNoiDung.Controls.Add(pnl);

            NapHoaDon();
        }

        /// <summary>Đặt tiêu đề cột, định dạng ngày và tiền cho bảng hóa đơn của khách hàng.</summary>
        private static void DinhDangBangHoaDon(DataGridView dgv, bool hienPhuongThuc)
        {
            if (dgv.Columns.Contains("MaHD"))
                dgv.Columns["MaHD"].HeaderText = "Mã hóa đơn";

            if (dgv.Columns.Contains("NgayLap"))
            {
                dgv.Columns["NgayLap"].HeaderText = "Ngày lập";
                dgv.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            if (dgv.Columns.Contains("TongTien"))
            {
                dgv.Columns["TongTien"].HeaderText = "Tổng tiền";
                dgv.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            }

            if (dgv.Columns.Contains("PhuongThucThanhToan"))
            {
                dgv.Columns["PhuongThucThanhToan"].HeaderText =
                    hienPhuongThuc ? "Phương thức thanh toán" : "Phương thức";
            }

            if (dgv.Columns.Contains("TrangThaiThanhToan"))
                dgv.Columns["TrangThaiThanhToan"].HeaderText =
                    hienPhuongThuc ? "Trạng thái thanh toán" : "Trạng thái";
        }

        private void ThanhToanHoaDon(string maHD)
        {
            try
            {
                DataTable dt = hoaDonBanBus.LayHoaDonKhachHangTheoMa(
                    maHD, maKhachHang);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn.");
                    return;
                }

                decimal tongTien =
                    Convert.ToDecimal(dt.Rows[0]["TongTien"]);

                ChonPhuongThucThanhToan(maHD, tongTien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở thanh toán:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        //                     THANH TOÁN
        // =====================================================

        private void HienThiThanhToan()
        {
            TaoTrangNoiDung("Thanh toán");

            Panel pnlTrang = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = mauNen,
                Padding = new Padding(18),
                AutoScroll = true,
                AutoScrollMinSize = new Size(1200, 1500)
            };

            Label lblTieuDeTrang = new Label
            {
                Text = "THANH TOÁN ĐƠN HÀNG",
                Location = new Point(20, 12),
                Size = new Size(600, 80),
                Font = new Font("Segoe UI", 17F, FontStyle.Bold),
                ForeColor = mauNavy
            };

            // ================= DANH SÁCH HÓA ĐƠN =================

            GroupBox grpHoaDon = new GroupBox
            {
                Text = "1. HÓA ĐƠN CHƯA THANH TOÁN",
                Location = new Point(20, 120),
                Size = new Size(1140, 600),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = mauNavy
            };

            DataGridView dgvHoaDon = TaoBangDuLieu();

            dgvHoaDon.Location = new Point(18, 45);
            dgvHoaDon.Size = new Size(1100, 530);
            dgvHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            grpHoaDon.Controls.Add(dgvHoaDon);

            // ================= THÔNG TIN HÓA ĐƠN =================

            GroupBox grpChiTiet = new GroupBox
            {
                Text = "2. THÔNG TIN ĐƠN HÀNG",
                Location = new Point(20, 740),
                Size = new Size(1140, 170),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = mauNavy
            };

            Label lblMaHD = new Label
            {
                Text = "Mã hóa đơn: Chưa chọn",
                Location = new Point(25, 38),
                AutoSize = true,
                Font = new Font("Segoe UI", 11F),
                ForeColor = mauChu
            };

            Label lblNgayLap = new Label
            {
                Text = "Ngày lập: --",
                Location = new Point(25, 78),
                AutoSize = true,
                Font = new Font("Segoe UI", 11F),
                ForeColor = mauChu
            };

            Label lblTrangThai = new Label
            {
                Text = "Trạng thái: --",
                Location = new Point(25, 118),
                AutoSize = true,
                Font = new Font("Segoe UI", 11F),
                ForeColor = mauChu
            };

            Label lblTongTien = new Label
            {
                Text = "0 đ",
                Location = new Point(650, 55),
                Size = new Size(450, 85),
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 45, 45),
                TextAlign = ContentAlignment.MiddleRight
            };

            grpChiTiet.Controls.Add(lblMaHD);
            grpChiTiet.Controls.Add(lblNgayLap);
            grpChiTiet.Controls.Add(lblTrangThai);
            grpChiTiet.Controls.Add(lblTongTien);

            // ================= PHƯƠNG THỨC THANH TOÁN =================

            GroupBox grpPhuongThuc = new GroupBox
            {
                Text = "3. PHƯƠNG THỨC THANH TOÁN",
                Location = new Point(20, 930),
                Size = new Size(1140, 115),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = mauNavy
            };

            RadioButton radTienMat = new RadioButton
            {
                Text = "TIỀN MẶT KHI NHẬN HÀNG",
                Location = new Point(30, 42),
                AutoSize = true,
                Font = new Font("Segoe UI", 11F),
                ForeColor = mauChu
            };

            RadioButton radChuyenKhoan = new RadioButton
            {
                Text = "CHUYỂN KHOẢN NGÂN HÀNG",
                Location = new Point(550, 42),
                AutoSize = true,
                Font = new Font("Segoe UI", 11F),
                ForeColor = mauChu
            };

            grpPhuongThuc.Controls.Add(radTienMat);
            grpPhuongThuc.Controls.Add(radChuyenKhoan);

            // ================= THÔNG TIN CHUYỂN KHOẢN =================

            GroupBox grpNganHang = new GroupBox
            {
                Text = "4. THÔNG TIN CHUYỂN KHOẢN",
                Location = new Point(20, 1065),
                Size = new Size(1140, 210),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = mauNavy
            };

            Label lblNganHang = new Label
            {
                Text = "Ngân hàng: " + TEN_NGAN_HANG,
                Location = new Point(25, 45),
                AutoSize = true,
                Font = new Font("Segoe UI", 11F),
                ForeColor = mauChu
            };

            Label lblSoTaiKhoan = new Label
            {
                Text = "Số tài khoản: " + SO_TAI_KHOAN,
                Location = new Point(25, 95),
                AutoSize = true,
                Font = new Font("Segoe UI", 11F),
                ForeColor = mauChu
            };

            Label lblChuTaiKhoan = new Label
            {
                Text = "Chủ tài khoản: " + TEN_CHU_TAI_KHOAN,
                Location = new Point(580, 45),
                AutoSize = true,
                Font = new Font("Segoe UI", 11F),
                ForeColor = mauChu
            };

            Label lblNoiDungCK = new Label
            {
                Text = "Nội dung chuyển khoản: Chọn hóa đơn trước",
                Location = new Point(580, 95),
                AutoSize = true,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = mauBlue
            };

            grpNganHang.Controls.Add(lblNganHang);
            grpNganHang.Controls.Add(lblSoTaiKhoan);
            grpNganHang.Controls.Add(lblChuTaiKhoan);
            grpNganHang.Controls.Add(lblNoiDungCK);

            // ================= NÚT CHỨC NĂNG =================

            Button btnTaiLai = new Button
            {
                Text = "TẢI LẠI HÓA ĐƠN",
                Location = new Point(20, 1390),
                Size = new Size(220, 48),
                BackColor = mauNavy,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            Button btnXacNhan = new Button
            {
                Text = "XÁC NHẬN PHƯƠNG THỨC",
                Location = new Point(255, 1390),
                Size = new Size(280, 48),
                BackColor = mauBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Enabled = false
            };

            btnTaiLai.FlatAppearance.BorderSize = 0;
            btnXacNhan.FlatAppearance.BorderSize = 0;

            string maHDDangChon = "";
            decimal tongTienDangChon = 0;
            string trangThaiDangChon = "";

            // ================= HIỂN THỊ CHI TIẾT =================

            void CapNhatChiTiet()
            {
                if (dgvHoaDon.CurrentRow == null ||
                    !dgvHoaDon.Columns.Contains("MaHD"))
                    return;

                DataGridViewRow row = dgvHoaDon.CurrentRow;

                maHDDangChon =
                    row.Cells["MaHD"].Value?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(maHDDangChon))
                    return;

                tongTienDangChon = Convert.ToDecimal(
                    row.Cells["TongTien"].Value);

                trangThaiDangChon =
                    row.Cells["TrangThaiThanhToan"].Value?.ToString() ?? "";

                lblMaHD.Text = "Mã hóa đơn: " + maHDDangChon;

                object? ngay = row.Cells["NgayLap"].Value;

                lblNgayLap.Text = "Ngày lập: " +
                    (ngay == null || ngay == DBNull.Value
                        ? "--"
                        : Convert.ToDateTime(ngay).ToString("dd/MM/yyyy HH:mm"));

                lblTrangThai.Text = "Trạng thái: " + trangThaiDangChon;

                lblTongTien.Text =
                    AppHelpers.DinhDangTienVnd(tongTienDangChon);

                lblNoiDungCK.Text =
                    "Nội dung chuyển khoản: " + maHDDangChon;

                btnXacNhan.Enabled =
                    trangThaiDangChon != "Đã thanh toán";

                radTienMat.Checked = false;
                radChuyenKhoan.Checked = false;

                if (dgvHoaDon.Columns.Contains("PhuongThucThanhToan"))
                {
                    string pt = row.Cells["PhuongThucThanhToan"]
                        .Value?.ToString() ?? "";

                    radTienMat.Checked = pt == "Tiền mặt";
                    radChuyenKhoan.Checked = pt == "Chuyển khoản";
                }
            }

            // ================= NẠP DANH SÁCH =================

            void NapDanhSach()
            {
                try
                {
                    DataTable dt = hoaDonBanBus.LayHoaDonKhachHang(
                        maKhachHang, true);

                    dgvHoaDon.DataSource = dt;
                    DinhDangBangHoaDon(dgvHoaDon, false);

                    if (dt.Rows.Count > 0)
                    {
                        // Mặc định chọn hóa đơn đầu tiên, hoặc đúng hóa đơn vừa tạo từ giỏ hàng
                        int dongDuocChon = 0;

                        if (!string.IsNullOrWhiteSpace(maHoaDonVuaTao))
                        {
                            for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
                            {
                                string maHDTrongBang =
                                    dgvHoaDon.Rows[i].Cells["MaHD"].Value?.ToString() ?? "";

                                if (maHDTrongBang.Equals(
                                    maHoaDonVuaTao,
                                    StringComparison.OrdinalIgnoreCase))
                                {
                                    dongDuocChon = i;
                                    break;
                                }
                            }
                        }

                        dgvHoaDon.ClearSelection();
                        dgvHoaDon.Rows[dongDuocChon].Selected = true;
                        dgvHoaDon.CurrentCell =
                            dgvHoaDon.Rows[dongDuocChon].Cells["MaHD"];

                        CapNhatChiTiet();
                    }
                    else
                    {
                        maHDDangChon = "";
                        tongTienDangChon = 0;

                        lblMaHD.Text = "Mã hóa đơn: Chưa có hóa đơn";
                        lblNgayLap.Text = "Ngày lập: --";
                        lblTrangThai.Text = "Trạng thái: --";
                        lblTongTien.Text = "0 đ";
                        lblNoiDungCK.Text =
                            "Nội dung chuyển khoản: Chọn hóa đơn trước";

                        radTienMat.Checked = false;
                        radChuyenKhoan.Checked = false;
                        btnXacNhan.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Không thể tải hóa đơn:\n" + ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            dgvHoaDon.SelectionChanged += (s, e) =>
                CapNhatChiTiet();

            radTienMat.CheckedChanged += (s, e) =>
            {
                if (radTienMat.Checked)
                    lblNoiDungCK.Text =
                        "Phương thức: Thanh toán tiền mặt khi nhận hàng";
            };

            radChuyenKhoan.CheckedChanged += (s, e) =>
            {
                if (radChuyenKhoan.Checked)
                    lblNoiDungCK.Text =
                        "Nội dung chuyển khoản: " +
                        (string.IsNullOrWhiteSpace(maHDDangChon)
                            ? "Chọn hóa đơn trước"
                            : maHDDangChon);
            };

            btnTaiLai.Click += (s, e) => NapDanhSach();

            btnXacNhan.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(maHDDangChon))
                {
                    MessageBox.Show("Bạn hãy chọn hóa đơn cần thanh toán.");
                    return;
                }

                if (!radTienMat.Checked && !radChuyenKhoan.Checked)
                {
                    MessageBox.Show("Bạn hãy chọn phương thức thanh toán.");
                    return;
                }

                string phuongThuc = radTienMat.Checked
                    ? "Tiền mặt"
                    : "Chuyển khoản";

                if (LuuPhuongThucThanhToan(maHDDangChon, phuongThuc))
                {
                    if (phuongThuc == "Chuyển khoản")
                    {
                        HienThiThongTinChuyenKhoan(
                            maHDDangChon, tongTienDangChon);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Đã lưu phương thức thanh toán tiền mặt.\n" +
                            "Bạn sẽ thanh toán khi nhận hàng.",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    NapDanhSach();
                }
            };

            pnlTrang.Controls.Add(lblTieuDeTrang);

            pnlTrang.Controls.Add(grpHoaDon);
            pnlTrang.Controls.Add(grpChiTiet);
            pnlTrang.Controls.Add(grpPhuongThuc);
            pnlTrang.Controls.Add(grpNganHang);
            pnlTrang.Controls.Add(btnTaiLai);
            pnlTrang.Controls.Add(btnXacNhan);

            pnlNoiDung.Controls.Add(pnlTrang);

            NapDanhSach();
        }

        // =====================================================
        //                DATAGRIDVIEW DÙNG CHUNG
        // =====================================================

        private DataGridView TaoBangDuLieu()
        {
            DataGridView dgv = new DataGridView
            {
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                MultiSelect = false,
                SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                EnableHeadersVisualStyles = false,
                Font = new Font("Segoe UI", 9F),
                GridColor = Color.FromArgb(230, 235, 242)
            };

            dgv.ColumnHeadersDefaultCellStyle.BackColor = mauNavy;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(220, 235, 250);

            dgv.DefaultCellStyle.SelectionForeColor = mauChu;
            dgv.RowTemplate.Height = 35;

            return dgv;
        }

        // =====================================================
        //                 ĐÓNG FORM ĐANG HIỂN THỊ
        // =====================================================

        private void MoForm(Form f, string tieuDe)
        {
            DongFormDangHienThi();

            lblTieuDe.Text = tieuDe;

            pnlNoiDung.SuspendLayout();
            pnlNoiDung.Controls.Clear();

            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.StartPosition = FormStartPosition.Manual;
            f.Margin = Padding.Empty;
            f.Dock = DockStyle.Fill;

            pnlNoiDung.Controls.Add(f);

            f.Show();
            f.BringToFront();

            formDangHienThi = f;

            pnlNoiDung.ResumeLayout(true);
        }

        private void DongFormDangHienThi()
        {
            if (formDangHienThi != null)
            {
                formDangHienThi.Close();
                formDangHienThi.Dispose();
                formDangHienThi = null;
            }
        }
    }
}
