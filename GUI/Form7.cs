using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4.GUI
{
    /// <summary>
    /// Form lập hóa đơn bán hàng.
    /// - Nhân viên: form tự sinh mã HDB mới, tự điền nhân viên đang đăng nhập, chọn khách hàng
    ///   có sẵn trong danh sách hoặc nhập khách hàng mới ngay trên hóa đơn.
    /// - Quản lý: mở ở chế độ chỉ xem, nạp sẵn danh sách hóa đơn đã bán để tra cứu và in Excel.
    /// Toàn bộ truy vấn đi qua tầng BUS; khách hàng mới được thêm bằng thủ tục lưu trữ
    /// sp_ThemKhachHangTuDong trước khi lưu hóa đơn.
    /// </summary>
    public partial class Form7 : Form
    {
        private const string NhanKhachHangMoi = "-- Khách hàng mới (nhập trực tiếp) --";

        private readonly HoaDonBanBUS hoaDonBus = new HoaDonBanBUS();
        private readonly NhanVienBUS nhanVienBus = new NhanVienBUS();
        private readonly KhachHangBUS khachHangBus = new KhachHangBUS();
        private readonly HangHoaBUS hangHoaBus = new HangHoaBUS();

        private readonly DataTable bangChiTiet = new DataTable();

        private readonly bool chiXem;
        private bool hoaDonDaTonTai = false;
        private bool dangNapKhachHang = false;
        private bool dangNapHoaDon = false;
        private bool daNapDuLieu = false;
        private string maKhachHangDangChon = "";

        /// <summary>Một dòng trong ComboBox chọn khách hàng: mã khách hàng + chuỗi hiển thị.</summary>
        private sealed class MucKhachHang
        {
            public string MaKH { get; }
            public string HienThi { get; }

            public MucKhachHang(string maKH, string hienThi)
            {
                MaKH = maKH;
                HienThi = hienThi;
            }

            public override string ToString()
            {
                return HienThi;
            }
        }

        /// <summary>Form ở chế độ lập đơn đầy đủ (dùng cho Nhân viên).</summary>
        public Form7() : this(false)
        {
        }

        /// <summary>Form ở chế độ chỉ xem danh sách hóa đơn đã bán (dùng cho Quản lý).</summary>
        public Form7(bool chiXem)
        {
            InitializeComponent();

            this.chiXem = chiXem;

            CauHinhBangChiTiet();
            CauHinhDieuKhien();

            Load += Form7_Load;
        }

        // ==================================================================
        // KHỞI TẠO GIAO DIỆN VÀ NẠP DỮ LIỆU
        // ==================================================================

        private void CauHinhBangChiTiet()
        {
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
        }

        private void CauHinhDieuKhien()
        {
            // Các ô luôn chỉ đọc: nhân viên lập đơn tự điền, các ô tính toán tự cập nhật
            txtMaNV.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;

            cboMaHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhachHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaHD.DropDownStyle = chiXem ? ComboBoxStyle.DropDownList : ComboBoxStyle.DropDown;

            // Gỡ trước khi gắn để tránh xử lý hai lần
            cboMaHang.SelectedIndexChanged -= cboMaHang_SelectedIndexChanged;
            cboMaHang.SelectedIndexChanged += cboMaHang_SelectedIndexChanged;

            cboKhachHang.SelectedIndexChanged -= cboKhachHang_SelectedIndexChanged;
            cboKhachHang.SelectedIndexChanged += cboKhachHang_SelectedIndexChanged;

            cboMaHD.SelectedIndexChanged -= cboMaHD_SelectedIndexChanged;
            cboMaHD.SelectedIndexChanged += cboMaHD_SelectedIndexChanged;

            txtSoLuong.TextChanged -= txtSoLuong_TextChanged;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;

            txtGiamGia.TextChanged -= txtGiamGia_TextChanged;
            txtGiamGia.TextChanged += txtGiamGia_TextChanged;

            txtMaNV.TextChanged -= txtMaNV_TextChanged;
            txtMaNV.TextChanged += txtMaNV_TextChanged;

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

            if (chiXem) ApDungCheDoChiXem();
        }

        /// <summary>Ẩn/khóa toàn bộ cụm lập đơn, chỉ giữ tra cứu và in hóa đơn.</summary>
        private void ApDungCheDoChiXem()
        {
            btnThemHD.Visible = false;
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnThemHang.Visible = false;

            groupBox2.Visible = false;
            tblMain.RowStyles[2].Height = 0F;

            dtpNgayLap.Enabled = false;
            cboKhachHang.Enabled = false;
            txtTenKH.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtDiaChi.ReadOnly = true;

            Text = "HÓA ĐƠN BÁN HÀNG (CHẾ ĐỘ CHỈ XEM)";
        }

        private void Form7_Load(object? sender, EventArgs e)
        {
            if (daNapDuLieu) return;
            daNapDuLieu = true;

            try
            {
                NapDanhSachKhachHang();
                NapDanhSachHang();
                NapDanhSachHoaDon();

                if (chiXem) ChuanBiCheDoChiXem();
                else ChuanBiHoaDonMoi(false);
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không tải được dữ liệu hóa đơn:\n" + ex.Message);
            }
        }

        private void NapDanhSachKhachHang()
        {
            string maDangChon = maKhachHangDangChon;

            dangNapKhachHang = true;
            try
            {
                cboKhachHang.Items.Clear();
                cboKhachHang.Items.Add(new MucKhachHang("", NhanKhachHangMoi));

                foreach (DataRow r in khachHangBus.LayDanhSach().Rows)
                {
                    string maKH = r["MaKH"].ToString() ?? "";
                    string tenKH = r["TenKH"].ToString() ?? "";
                    string sdt = r["SDT"] == DBNull.Value ? "" : r["SDT"].ToString() ?? "";

                    cboKhachHang.Items.Add(new MucKhachHang(maKH, TaoChuoiKhachHang(maKH, tenKH, sdt)));
                }

                cboKhachHang.SelectedIndex = 0;

                // Giữ lại đúng khách hàng đang chọn sau khi nạp lại danh sách
                if (maDangChon != "") ChonKhachHangTheoMa(maDangChon);
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không tải được danh sách khách hàng:\n" + ex.Message);
            }
            finally
            {
                dangNapKhachHang = false;
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
            dangNapHoaDon = true;
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
            finally
            {
                dangNapHoaDon = false;
            }
        }

        /// <summary>Chế độ Quản lý: chọn sẵn hóa đơn mới nhất trong danh sách để xem chi tiết.</summary>
        private void ChuanBiCheDoChiXem()
        {
            if (cboMaHD.Items.Count == 0)
            {
                cboMaHD.Text = "";
                lblTongTien.Text = "Chưa có hóa đơn nào để xem";
                return;
            }

            string maHD = Convert.ToString(cboMaHD.Items[cboMaHD.Items.Count - 1]) ?? "";

            dangNapHoaDon = true;
            cboMaHD.SelectedIndex = cboMaHD.Items.Count - 1;
            dangNapHoaDon = false;

            try
            {
                HienThiHoaDon(maHD, false);
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không xem được hóa đơn " + maHD + ":\n" + ex.Message);
            }
        }

        /// <summary>Chế độ Nhân viên: sẵn sàng một hóa đơn mới với nhân viên đang đăng nhập.</summary>
        private void ChuanBiHoaDonMoi(bool hoiXacNhan)
        {
            if (hoiXacNhan && !AppHelpers.XacNhan("Tạo hóa đơn mới? Các mặt hàng chưa lưu hiện tại sẽ bị xóa."))
                return;

            bangChiTiet.Rows.Clear();
            XoaThongTinHangDangChon();

            cboMaHD.Text = HoaDonBan.TaoMaMoi();
            dtpNgayLap.Value = DateTime.Now;

            // Tự điền nhân viên đang đăng nhập, không bắt nhân viên gõ tay mã của mình
            txtMaNV.Text = Form9.MaNVDangNhap;
            txtTenNV.Text = Form9.TenNVDangNhap;

            maKhachHangDangChon = "";
            dangNapKhachHang = true;
            cboKhachHang.SelectedIndex = cboKhachHang.Items.Count > 0 ? 0 : -1;
            dangNapKhachHang = false;

            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();

            hoaDonDaTonTai = false;
            TinhTongTien();
            CapNhatOTKhachHang();

            if (hoiXacNhan)
                AppHelpers.HienThongBao("Đã tạo hóa đơn mới. Chọn khách hàng (hoặc nhập khách mới) và mặt hàng.");
        }

        // ==================================================================
        // CHỌN NHÂN VIÊN / KHÁCH HÀNG / MẶT HÀNG
        // ==================================================================

        private void txtMaNV_TextChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text)) return;
            txtTenNV.Text = nhanVienBus.LayTen(txtMaNV.Text);
        }

        private void cboKhachHang_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (dangNapKhachHang) return;

            MucKhachHang? muc = cboKhachHang.SelectedItem as MucKhachHang;

            if (muc == null || muc.MaKH == "")
            {
                maKhachHangDangChon = "";
                txtTenKH.Clear();
                txtSDT.Clear();
                txtDiaChi.Clear();
            }
            else
            {
                maKhachHangDangChon = muc.MaKH;
                NapThongTinKhachHang(muc.MaKH);
            }

            CapNhatOTKhachHang();
        }

        private void NapThongTinKhachHang(string maKH)
        {
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

        /// <summary>Chỉ cho sửa tên/SĐT/địa chỉ khi đang nhập khách hàng mới.</summary>
        private void CapNhatOTKhachHang()
        {
            bool choNhap = !chiXem && !hoaDonDaTonTai && maKhachHangDangChon == "";

            txtTenKH.ReadOnly = !choNhap;
            txtSDT.ReadOnly = !choNhap;
            txtDiaChi.ReadOnly = !choNhap;

            txtTenKH.BackColor = choNhap ? Color.White : Color.FromArgb(250, 252, 255);
            txtSDT.BackColor = choNhap ? Color.White : Color.FromArgb(250, 252, 255);
            txtDiaChi.BackColor = choNhap ? Color.White : Color.FromArgb(250, 252, 255);
        }

        private string TaoChuoiKhachHang(string maKH, string tenKH, string sdt)
        {
            return sdt == "" ? maKH + " - " + tenKH : maKH + " - " + tenKH + " - " + sdt;
        }

        private bool ChonKhachHangTheoMa(string maKH)
        {
            for (int i = 0; i < cboKhachHang.Items.Count; i++)
            {
                MucKhachHang? muc = cboKhachHang.Items[i] as MucKhachHang;
                if (muc != null && muc.MaKH == maKH)
                {
                    cboKhachHang.SelectedIndex = i;
                    return true;
                }
            }

            return false;
        }

        private void cboMaHD_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!chiXem || dangNapHoaDon) return;

            string maHD = cboMaHD.Text.Trim();
            if (maHD == "") return;

            try
            {
                HienThiHoaDon(maHD, false);
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không xem được hóa đơn " + maHD + ":\n" + ex.Message);
            }
        }

        private void cboMaHang_SelectedIndexChanged(object? sender, EventArgs e)
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

        private void txtSoLuong_TextChanged(object? sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void txtGiamGia_TextChanged(object? sender, EventArgs e)
        {
            TinhThanhTien();
        }

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

        private void btnThemHang_Click(object? sender, EventArgs e)
        {
            if (chiXem) return;

            if (hoaDonDaTonTai)
            {
                AppHelpers.HienCanhBao("Đây là hóa đơn đã lưu. Hãy bấm Thêm mới để lập hóa đơn khác.");
                return;
            }

            string maHang = cboMaHang.Text.Trim();

            if (maHang == "" || txtTenHang.Text.Trim() == "")
            {
                AppHelpers.HienCanhBao("Vui lòng chọn mã hàng!");
                cboMaHang.Focus();
                return;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                AppHelpers.HienCanhBao("Số lượng phải là số nguyên lớn hơn 0!");
                txtSoLuong.Focus();
                return;
            }

            if (!AppHelpers.DocSoTien(txtGiamGia.Text, out decimal giamGia) || giamGia < 0 || giamGia > 100)
            {
                AppHelpers.HienCanhBao("Giảm giá phải từ 0 đến 100%!");
                txtGiamGia.Focus();
                return;
            }

            if (!AppHelpers.DocSoTien(txtDonGia.Text, out decimal donGia))
            {
                AppHelpers.HienCanhBao("Đơn giá không hợp lệ!");
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
                        AppHelpers.HienCanhBao("Mặt hàng này đã có trong hóa đơn với mức giảm giá khác. " +
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

        private void btnThemHD_Click(object? sender, EventArgs e)
        {
            if (chiXem) return;
            ChuanBiHoaDonMoi(true);
        }

        private void btnHuy_Click(object? sender, EventArgs e)
        {
            if (chiXem) return;

            if (hoaDonDaTonTai)
            {
                AppHelpers.HienCanhBao("Đây là hóa đơn đã lưu. Chức năng này không xóa hóa đơn trong cơ sở dữ liệu.");
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

        private void btnLuu_Click(object? sender, EventArgs e)
        {
            if (chiXem)
            {
                AppHelpers.HienCanhBao("Tài khoản Quản lý chỉ được xem hóa đơn, không lập hóa đơn mới.");
                return;
            }

            if (hoaDonDaTonTai)
            {
                AppHelpers.HienCanhBao("Hóa đơn này đã được lưu. Hãy bấm Thêm mới nếu muốn lập hóa đơn khác.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cboMaHD.Text))
            {
                AppHelpers.HienCanhBao("Vui lòng tạo mã hóa đơn!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                AppHelpers.HienCanhBao("Vui lòng đăng nhập lại để xác định nhân viên lập hóa đơn!");
                return;
            }

            if (bangChiTiet.Rows.Count == 0)
            {
                AppHelpers.HienCanhBao("Hóa đơn chưa có mặt hàng!");
                return;
            }

            // --- Khách hàng: có sẵn trong danh sách, khách mới nhập tại chỗ, hoặc khách lẻ ---
            string maKH = maKhachHangDangChon;
            string tenKH = AppHelpers.ChuanHoaChuoi(txtTenKH.Text);
            string sdt = txtSDT.Text.Trim();
            string diaChi = AppHelpers.ChuanHoaChuoi(txtDiaChi.Text);
            bool vuaThemKhach = false;

            if (maKH == "" && (tenKH != "" || sdt != "" || diaChi != ""))
            {
                if (tenKH == "")
                {
                    AppHelpers.HienCanhBao("Vui lòng nhập tên khách hàng mới!");
                    txtTenKH.Focus();
                    return;
                }

                if (!AppHelpers.KiemTraSoDienThoai(sdt))
                {
                    AppHelpers.HienCanhBao("Số điện thoại khách hàng phải gồm 10 chữ số và bắt đầu bằng 0!");
                    txtSDT.Focus();
                    return;
                }

                string? maKhachMoi = khachHangBus.ThemKhachHangTuDong(tenKH, sdt, diaChi,
                    out bool laKhachMoi, out string loiKhachHang);

                if (maKhachMoi == null)
                {
                    AppHelpers.HienCanhBao("Không thể thêm khách hàng mới:\n" + loiKhachHang);
                    return;
                }

                maKH = maKhachMoi;
                vuaThemKhach = laKhachMoi;
                maKhachHangDangChon = maKH;
            }

            // Dựng đối tượng hóa đơn từ dữ liệu trên form
            var hd = new HoaDonBan
            {
                MaHD = cboMaHD.Text.Trim(),
                MaNV = txtMaNV.Text.Trim(),
                MaKH = maKH,
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

            if (!hoaDonBus.LuuHoaDon(hd, out string error))
            {
                AppHelpers.HienCanhBao("Lưu hóa đơn thất bại:\n" + error);
                return;
            }

            hoaDonDaTonTai = true;
            NapDanhSachHoaDon();
            NapDanhSachKhachHang();
            cboMaHD.Text = hd.MaHD;
            CapNhatOTKhachHang();

            string thongDiep = "Lưu hóa đơn " + hd.MaHD + " thành công!\n" +
                               "Tổng tiền: " + AppHelpers.DinhDangTien(hd.TongTien) + " VNĐ.\n" +
                               "Tồn kho đã được cập nhật.";

            if (maKH != "")
            {
                thongDiep += vuaThemKhach
                    ? "\nĐã thêm khách hàng mới: " + maKH + " - " + tenKH + "."
                    : "\nDùng lại khách hàng có sẵn theo số điện thoại: " + maKH + ".";
            }

            AppHelpers.HienThongBao(thongDiep);
        }

        // ==================================================================
        // TÌM HÓA ĐƠN ĐÃ LƯU
        // ==================================================================

        private void btnTim_Click(object? sender, EventArgs e)
        {
            string maHD = cboMaHD.Text.Trim();

            if (maHD == "")
            {
                AppHelpers.HienCanhBao("Vui lòng nhập hoặc chọn mã hóa đơn cần tìm!");
                return;
            }

            try
            {
                HienThiHoaDon(maHD, true);
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không thể tìm hóa đơn:\n" + ex.Message);
            }
        }

        /// <summary>Nạp một hóa đơn đã lưu lên form (dùng cho nút Tìm và chế độ chỉ xem).</summary>
        private bool HienThiHoaDon(string maHD, bool thongBao)
        {
            DataTable dtHoaDon = hoaDonBus.LayHoaDon(maHD);

            if (dtHoaDon.Rows.Count == 0)
            {
                if (thongBao) AppHelpers.HienCanhBao("Không tìm thấy hóa đơn này.");
                return false;
            }

            DataRow r = dtHoaDon.Rows[0];

            txtMaNV.Text = r["MaNV"].ToString();
            txtTenNV.Text = r["TenNV"] == DBNull.Value ? "" : r["TenNV"].ToString() ?? "";
            dtpNgayLap.Value = Convert.ToDateTime(r["NgayLap"]);

            string maKH = r["MaKH"] == DBNull.Value ? "" : r["MaKH"].ToString() ?? "";
            string tenKH = r["TenKH"] == DBNull.Value ? "" : r["TenKH"].ToString() ?? "";
            string sdt = r["SDT"] == DBNull.Value ? "" : r["SDT"].ToString() ?? "";
            string diaChi = r["DiaChi"] == DBNull.Value ? "" : r["DiaChi"].ToString() ?? "";

            dangNapKhachHang = true;
            if (maKH == "")
            {
                cboKhachHang.SelectedIndex = cboKhachHang.Items.Count > 0 ? 0 : -1;
            }
            else if (!ChonKhachHangTheoMa(maKH))
            {
                cboKhachHang.Items.Add(new MucKhachHang(maKH, TaoChuoiKhachHang(maKH, tenKH, sdt)));
                cboKhachHang.SelectedIndex = cboKhachHang.Items.Count - 1;
            }
            dangNapKhachHang = false;

            maKhachHangDangChon = maKH;
            txtTenKH.Text = tenKH;
            txtSDT.Text = sdt;
            txtDiaChi.Text = diaChi;

            bangChiTiet.Rows.Clear();

            foreach (DataRow row in hoaDonBus.LayChiTiet(maHD).Rows)
            {
                bangChiTiet.Rows.Add(
                    row["MaHang"],
                    row["TenHang"],
                    row["DonGia"],
                    row["SoLuong"],
                    row["GiamGia"],
                    row["ThanhTien"]);
            }

            dangNapHoaDon = true;
            cboMaHD.Text = maHD;
            dangNapHoaDon = false;

            hoaDonDaTonTai = true;
            TinhTongTien();
            CapNhatOTKhachHang();

            if (thongBao)
            {
                AppHelpers.HienThongBao("Đã nạp hóa đơn " + maHD + " (" +
                                        bangChiTiet.Rows.Count + " mặt hàng).");
            }

            return true;
        }

        // ==================================================================
        // XÓA MỘT DÒNG CHI TIẾT
        // ==================================================================

        private void dgvChiTiet_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (chiXem) return;
            if (e.RowIndex < 0 || e.RowIndex >= bangChiTiet.Rows.Count) return;

            if (hoaDonDaTonTai)
            {
                AppHelpers.HienCanhBao("Đây là hóa đơn đã lưu. Không thể xóa dòng trực tiếp trên giao diện.");
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

        private void btnIn_Click(object? sender, EventArgs e)
        {
            if (bangChiTiet.Rows.Count == 0)
            {
                AppHelpers.HienCanhBao("Hóa đơn chưa có mặt hàng để xuất!");
                return;
            }

            string maHD = cboMaHD.Text.Trim();

            if (maHD == "")
            {
                AppHelpers.HienCanhBao("Vui lòng chọn hóa đơn đã lưu trước khi in!");
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
                sheet.Cell(5, 5).Value = maKhachHangDangChon;
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

        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
