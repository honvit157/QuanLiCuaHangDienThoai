using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai
{
    /// <summary>
    /// Form quản lý mặt hàng (điện thoại): xem danh sách, thêm - sửa - xóa,
    /// chọn ảnh minh họa và tìm nhanh theo mã hoặc tên.
    /// Tầng GUI chỉ giao tiếp với tầng nghiệp vụ (HangHoaBUS, DanhMucBUS).
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly HangHoaBUS hangHoaBus = new HangHoaBUS();
        private readonly DanhMucBUS danhMucBus = new DanhMucBUS();

        private DataTable dtHang = new DataTable();
        private DataView dvHang = new DataView();
        private string tenAnh = "";

        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamLai.Click += btnLamLai_Click;
            btnThoat.Click += (s, e) => Close();
            btnChonAnh.Click += btnChonAnh_Click;
            btnTim.Click += btnTim_Click;
            dgvHang.CellClick += dgvHang_CellClick;
            txtTim.TextChanged += (s, e) => TimKiem();
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            NapCombo(cboHang, LoaiDanhMuc.HangSanXuat, "TenHangSX", "MaHangSX");
            NapCombo(cboLoai, LoaiDanhMuc.LoaiHang, "TenLoai", "MaLoai");
            NapCombo(cboMau, LoaiDanhMuc.MauSac, "TenMau", "MaMau");
            NapCombo(cboDungLuong, LoaiDanhMuc.DungLuong, "TenDungLuong", "MaDungLuong");

            dgvHang.ReadOnly = true;
            dgvHang.AllowUserToAddRows = false;
            dgvHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHang.MultiSelect = false;
            dgvHang.RowHeadersVisible = false;
            dgvHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadData();
            LamLai();
        }

        /// <summary>Nạp dữ liệu cho ComboBox danh mục thông qua tầng BUS.</summary>
        private void NapCombo(ComboBox cbo, LoaiDanhMuc loai, string cotTen, string cotMa)
        {
            try
            {
                DataTable dt = danhMucBus.LayDanhSach(loai);
                cbo.DataSource = dt;
                cbo.DisplayMember = cotTen;
                cbo.ValueMember = cotMa;
                cbo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không tải được danh mục: " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                dtHang = hangHoaBus.LayDanhSach();
                dvHang = new DataView(dtHang);
                dgvHang.DataSource = dvHang;

                var tieuDe = new Dictionary<string, string>
                {
                    ["MaHang"] = "Mã hàng",
                    ["TenHang"] = "Tên hàng",
                    ["Hang"] = "Hãng",
                    ["Loai"] = "Loại",
                    ["Mau"] = "Màu",
                    ["DungLuong"] = "Dung lượng",
                    ["GiaNhap"] = "Giá nhập",
                    ["GiaBan"] = "Giá bán",
                    ["SoLuong"] = "Số lượng tồn"
                };

                foreach (var kv in tieuDe)
                {
                    if (dgvHang.Columns.Contains(kv.Key))
                        dgvHang.Columns[kv.Key]!.HeaderText = kv.Value;
                }

                foreach (var col in new[] { "MaHangSX", "MaLoai", "MaMau", "MaDungLuong", "MoTa", "DonGiaNhap", "DonGiaBan", "SoLuongTon" })
                {
                    if (dgvHang.Columns.Contains(col))
                        dgvHang.Columns[col]!.Visible = false;
                }

                foreach (var cot in new[] { "GiaNhap", "GiaBan" })
                {
                    if (dgvHang.Columns.Contains(cot))
                    {
                        dgvHang.Columns[cot]!.DefaultCellStyle.Format = "N0";
                        dgvHang.Columns[cot]!.DefaultCellStyle.FormatProvider = AppHelpers.ViVn;
                    }
                }
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void dgvHang_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvHang.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;

            txtMaHang.Text = r["MaHang"].ToString();
            txtMaHang.ReadOnly = true;
            txtTenHang.Text = r["TenHang"].ToString();

            if (r["MaHangSX"] != DBNull.Value) cboHang.SelectedValue = r["MaHangSX"].ToString();
            else cboHang.SelectedIndex = -1;

            if (r["MaLoai"] != DBNull.Value) cboLoai.SelectedValue = r["MaLoai"].ToString();
            else cboLoai.SelectedIndex = -1;

            if (r["MaMau"] != DBNull.Value) cboMau.SelectedValue = r["MaMau"].ToString();
            else cboMau.SelectedIndex = -1;

            if (r["MaDungLuong"] != DBNull.Value) cboDungLuong.SelectedValue = r["MaDungLuong"].ToString();
            else cboDungLuong.SelectedIndex = -1;

            if (decimal.TryParse(r["GiaNhap"].ToString(), out decimal gn))
                txtGiaNhap.Text = AppHelpers.DinhDangTien(gn);
            if (decimal.TryParse(r["GiaBan"].ToString(), out decimal gb))
                txtGiaBan.Text = AppHelpers.DinhDangTien(gb);

            txtSoLuong.Text = r["SoLuong"].ToString();

            tenAnh = "";
            lblTenAnh.Text = "";
            HienAnh("");
        }

        private void btnChonAnh_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Chọn ảnh điện thoại",
                Filter = "Ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                tenAnh = AppHelpers.SaoChepAnh(ofd.FileName);
                lblTenAnh.Text = tenAnh;
                HienAnh(tenAnh);
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Không thể tải ảnh: " + ex.Message);
            }
        }

        private void HienAnh(string ten)
        {
            picAnh.Image?.Dispose();
            picAnh.Image = null;

            if (string.IsNullOrEmpty(ten)) return;

            string duongDan = Path.Combine(AppHelpers.ThuMucAnh, ten);
            if (!File.Exists(duongDan)) return;

            using var bmp = new Bitmap(duongDan);
            picAnh.Image = new Bitmap(bmp);
            picAnh.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private static void Loi(string thongBao, Control ctrl)
        {
            MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ctrl.Focus();
        }

        /// <summary>
        /// Đọc dữ liệu trên form và tạo đối tượng HangHoa.
        /// Trả về false nếu dữ liệu chưa hợp lệ (đã hiển thị thông báo lỗi).
        /// </summary>
        private bool TaoDoiTuongHang(out HangHoa? hang)
        {
            hang = null;

            if (string.IsNullOrWhiteSpace(txtMaHang.Text)) { Loi("Chưa nhập mã hàng.", txtMaHang); return false; }
            if (string.IsNullOrWhiteSpace(txtTenHang.Text)) { Loi("Chưa nhập tên hàng.", txtTenHang); return false; }
            if (cboHang.SelectedIndex < 0) { Loi("Chưa chọn hãng sản xuất.", cboHang); return false; }
            if (cboLoai.SelectedIndex < 0) { Loi("Chưa chọn loại hàng.", cboLoai); return false; }
            if (cboMau.SelectedIndex < 0) { Loi("Chưa chọn màu sắc.", cboMau); return false; }
            if (!AppHelpers.DocSoTien(txtGiaNhap.Text, out decimal gn)) { Loi("Giá nhập phải là số không âm.", txtGiaNhap); return false; }
            if (!AppHelpers.DocSoTien(txtGiaBan.Text, out decimal gb)) { Loi("Giá bán phải là số không âm.", txtGiaBan); return false; }
            if (!AppHelpers.KiemTraSoNguyenKhongAm(txtSoLuong.Text, out int sl))
            {
                Loi("Số lượng tồn phải là số nguyên không âm.", txtSoLuong);
                return false;
            }

            hang = new HangHoa(
                txtMaHang.Text.Trim(),
                txtTenHang.Text.Trim(),
                cboHang.SelectedValue?.ToString(),
                cboLoai.SelectedValue?.ToString(),
                cboMau.SelectedValue?.ToString(),
                cboDungLuong.SelectedValue?.ToString(),
                gn, gb, sl);

            return true;
        }

        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (!TaoDoiTuongHang(out HangHoa? hang) || hang == null) return;

            if (hangHoaBus.Them(hang, out string error))
            {
                AppHelpers.HienThongBao("Thêm mặt hàng thành công!");
                LoadData();
                LamLai();
            }
            else
            {
                AppHelpers.HienCanhBao(error);
            }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (!txtMaHang.ReadOnly)
            {
                MessageBox.Show("Hãy chọn một dòng trong danh sách để sửa.");
                return;
            }

            if (!TaoDoiTuongHang(out HangHoa? hang) || hang == null) return;

            if (hangHoaBus.Sua(hang, out string error))
            {
                AppHelpers.HienThongBao("Cập nhật mặt hàng thành công!");
                LoadData();
                LamLai();
            }
            else
            {
                AppHelpers.HienCanhBao(error);
            }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!txtMaHang.ReadOnly)
            {
                MessageBox.Show("Hãy chọn một dòng trong danh sách để xóa.");
                return;
            }

            string ma = txtMaHang.Text.Trim();
            if (!AppHelpers.XacNhan($"Bạn có chắc chắn muốn xóa mặt hàng {ma}?")) return;

            if (hangHoaBus.Xoa(ma, out string error))
            {
                AppHelpers.HienThongBao("Đã xóa mặt hàng!");
                LoadData();
                LamLai();
            }
            else
            {
                AppHelpers.HienCanhBao(error);
            }
        }

        private void btnLamLai_Click(object? sender, EventArgs e)
        {
            txtTim.Clear();
            if (dvHang?.Table != null) dvHang.RowFilter = "";
            LamLai();
        }

        private void LamLai()
        {
            txtMaHang.ReadOnly = false;
            txtMaHang.Clear();
            txtTenHang.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            cboHang.SelectedIndex = -1;
            cboLoai.SelectedIndex = -1;
            cboMau.SelectedIndex = -1;
            cboDungLuong.SelectedIndex = -1;
            tenAnh = "";
            lblTenAnh.Text = "";
            HienAnh("");
            dgvHang.ClearSelection();
            txtMaHang.Focus();
        }

        private void btnTim_Click(object? sender, EventArgs e) => TimKiem();

        private void TimKiem()
        {
            if (dvHang?.Table == null) return;

            string tk = AppHelpers.TaoTuKhoaTimKiem(txtTim.Text);
            dvHang.RowFilter = tk.Length == 0
                ? ""
                : $"TenHang LIKE '%{tk}%' OR MaHang LIKE '%{tk}%'";
        }
    }
}
