
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form1 : Form
    {
        private readonly CultureInfo vn = new CultureInfo("vi-VN");

        private readonly HangHoaBUS hangHoaBus = new HangHoaBUS();
        private readonly DanhMucBUS danhMucBus = new DanhMucBUS();

        private DataTable dtHang = new DataTable();
        private DataView dvHang = new DataView();

        private string tenAnh = "";

        // Thư mục Images nằm trong thư mục chạy chương trình
        private string ThuMucAnh =>
            Path.Combine(Application.StartupPath, "Images");

        public Form1()
        {
            InitializeComponent();

            TaoGiaoDien();

            Load += Form1_Load;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamLai.Click += btnLamLai_Click;
            btnThoat.Click += (s, e) => Close();
            btnChonAnh.Click += btnChonAnh_Click;
            btnTim.Click += btnTim_Click;

            dgvHang.CellClick += dgvHang_CellClick;
        }

        // =====================================================
        // 1. KHỞI TẠO FORM
        // =====================================================

        private void Form1_Load(object? sender, EventArgs e)
        {
            NapCombo(
                cboHang,
                LoaiDanhMuc.HangSanXuat,
                "TenHangSX",
                "MaHangSX"
            );

            NapCombo(
                cboLoai,
                LoaiDanhMuc.LoaiHang,
                "TenLoai",
                "MaLoai"
            );

            NapCombo(
                cboMau,
                LoaiDanhMuc.MauSac,
                "TenMau",
                "MaMau"
            );

            NapCombo(
                cboDungLuong,
                LoaiDanhMuc.DungLuong,
                "TenDungLuong",
                "MaDungLuong"
            );

            dgvHang.ReadOnly = true;
            dgvHang.AllowUserToAddRows = false;
            dgvHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHang.MultiSelect = false;
            dgvHang.RowHeadersVisible = false;
            dgvHang.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            LoadData();
            LamLai();
        }

        // =====================================================
        // 2. NẠP COMBOBOX
        // =====================================================

        private void NapCombo(
            ComboBox cbo,
            LoaiDanhMuc loai,
            string display,
            string value)
        {
            try
            {
                DataTable dt = danhMucBus.LayDanhSach(loai, theoTen: true);

                cbo.DataSource = dt;
                cbo.DisplayMember = display;
                cbo.ValueMember = value;
                cbo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh mục: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // 3. TẢI DANH SÁCH HÀNG HÓA
        // =====================================================

        private void LoadData()
        {
            try
            {
                // Lấy dữ liệu từ Stored Procedure
                dtHang = hangHoaBus.LayDanhSach();

                if (dtHang == null)
                {
                    throw new Exception(
                        "Không nhận được dữ liệu từ HangHoaBUS."
                    );
                }

                // Kiểm tra các cột bắt buộc
                string[] cotBatBuoc =
                {
                    "MaHang",
                    "TenHang",
                    "MaHangSX",
                    "MaLoai",
                    "MaMau",
                    "MaDungLuong",
                    "Hang",
                    "Loai",
                    "Mau",
                    "DungLuong",
                    "DonGiaNhap",
                    "DonGiaBan",
                    "SoLuongTon",
                    "TenAnh"
                };

                foreach (string cot in cotBatBuoc)
                {
                    if (!dtHang.Columns.Contains(cot))
                    {
                        throw new Exception(
                            "Dữ liệu trả về không có cột: " + cot +
                            ". Hãy kiểm tra Stored Procedure sp_LayDanhSachHang."
                        );
                    }
                }

                dvHang = new DataView(dtHang);
                dgvHang.DataSource = dvHang;

                // Đặt tên hiển thị cho các cột
                var tieuDe = new Dictionary<string, string>
                {
                    ["MaHang"] = "Mã hàng",
                    ["TenHang"] = "Tên điện thoại",
                    ["Hang"] = "Hãng sản xuất",
                    ["Loai"] = "Loại",
                    ["Mau"] = "Màu",
                    ["DungLuong"] = "Dung lượng",
                    ["DonGiaNhap"] = "Giá nhập",
                    ["DonGiaBan"] = "Giá bán",
                    ["SoLuongTon"] = "Số lượng tồn"
                };

                foreach (var kv in tieuDe)
                {
                    if (dgvHang.Columns.Contains(kv.Key))
                    {
                        dgvHang.Columns[kv.Key]!.HeaderText = kv.Value;
                    }
                }

                // Ẩn các cột mã danh mục và ảnh
                string[] cotAn =
                {
                    "MaHangSX",
                    "MaLoai",
                    "MaMau",
                    "MaDungLuong",
                    "TenAnh",
                    "MoTa"
                };

                foreach (string cot in cotAn)
                {
                    if (dgvHang.Columns.Contains(cot))
                    {
                        dgvHang.Columns[cot]!.Visible = false;
                    }
                }

                // Định dạng tiền
                foreach (string cot in new[]
                {
                    "DonGiaNhap",
                    "DonGiaBan"
                })
                {
                    if (dgvHang.Columns.Contains(cot))
                    {
                        dgvHang.Columns[cot]!.DefaultCellStyle.Format = "N0";

                        dgvHang.Columns[cot]!.DefaultCellStyle.FormatProvider = vn;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải dữ liệu hàng hóa:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // 4. CHỌN MỘT SẢN PHẨM TRÊN DATAGRIDVIEW
        // =====================================================

        private void dgvHang_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvHang.Rows[e.RowIndex].DataBoundItem
                is not DataRowView r)
                return;

            txtMaHang.Text = r["MaHang"]?.ToString() ?? "";

            txtMaHang.ReadOnly = true;

            txtTenHang.Text = r["TenHang"]?.ToString() ?? "";

            // Hãng sản xuất
            if (r["MaHangSX"] != DBNull.Value)
                cboHang.SelectedValue = r["MaHangSX"].ToString();
            else
                cboHang.SelectedIndex = -1;

            // Loại điện thoại
            if (r["MaLoai"] != DBNull.Value)
                cboLoai.SelectedValue = r["MaLoai"].ToString();
            else
                cboLoai.SelectedIndex = -1;

            // Màu sắc
            if (r["MaMau"] != DBNull.Value)
                cboMau.SelectedValue = r["MaMau"].ToString();
            else
                cboMau.SelectedIndex = -1;

            // Dung lượng
            if (r["MaDungLuong"] != DBNull.Value)
                cboDungLuong.SelectedValue = r["MaDungLuong"].ToString();
            else
                cboDungLuong.SelectedIndex = -1;

            // Giá nhập
            if (r["DonGiaNhap"] != DBNull.Value)
            {
                decimal gn = Convert.ToDecimal(r["DonGiaNhap"]);

                txtGiaNhap.Text = gn.ToString("N0", vn);
            }
            else
            {
                txtGiaNhap.Clear();
            }

            // Giá bán
            if (r["DonGiaBan"] != DBNull.Value)
            {
                decimal gb = Convert.ToDecimal(r["DonGiaBan"]);

                txtGiaBan.Text = gb.ToString("N0", vn);
            }
            else
            {
                txtGiaBan.Clear();
            }

            // Số lượng tồn
            txtSoLuong.Text = r["SoLuongTon"] == DBNull.Value
                ? "0"
                : r["SoLuongTon"].ToString();

            // Tên ảnh
            tenAnh = r["TenAnh"] == DBNull.Value
                ? ""
                : r["TenAnh"].ToString() ?? "";

            lblTenAnh.Text = tenAnh;

            HienAnh(tenAnh);
        }

        // =====================================================
        // 5. CHỌN ẢNH ĐIỆN THOẠI
        // =====================================================

        private void btnChonAnh_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Chọn ảnh điện thoại",
                Filter = "Ảnh điện thoại|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                Directory.CreateDirectory(ThuMucAnh);

                string ten = Path.GetFileName(ofd.FileName);

                string dich = Path.Combine(ThuMucAnh, ten);

                if (!string.Equals(
                    Path.GetFullPath(ofd.FileName),
                    Path.GetFullPath(dich),
                    StringComparison.OrdinalIgnoreCase))
                {
                    File.Copy(ofd.FileName, dich, true);
                }

                tenAnh = ten;

                lblTenAnh.Text = ten;

                HienAnh(ten);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải ảnh: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // 6. HIỂN THỊ ẢNH
        // =====================================================

        private void HienAnh(string ten)
        {
            picAnh.Image?.Dispose();
            picAnh.Image = null;

            if (string.IsNullOrWhiteSpace(ten))
                return;

            string tenFile = Path.GetFileName(ten.Trim());

            string duongDan = Path.Combine(ThuMucAnh, tenFile);

            if (!File.Exists(duongDan))
                return;

            try
            {
                using Bitmap bmp = new Bitmap(duongDan);

                picAnh.Image = new Bitmap(bmp);

                picAnh.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể hiển thị ảnh:\n" +
                    duongDan +
                    "\n\n" + ex.Message,
                    "Lỗi ảnh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // =====================================================
        // 7. ĐỌC GIÁ TIỀN
        // =====================================================

        private bool DocTien(string s, out decimal tien)
        {
            return decimal.TryParse(
                s.Trim(),
                NumberStyles.Number,
                vn,
                out tien
            ) && tien >= 0;
        }

        // =====================================================
        // 8. HIỂN THỊ THÔNG BÁO LỖI
        // =====================================================

        private static void Loi(string thongBao, Control ctrl)
        {
            MessageBox.Show(
                thongBao,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            ctrl.Focus();
        }

        // =====================================================
        // 9. TẠO ĐỐI TƯỢNG HÀNG HÓA
        // =====================================================

        private bool TaoDoiTuongHang(out HangHoa? hang)
        {
            hang = null;

            if (string.IsNullOrWhiteSpace(txtMaHang.Text))
            {
                Loi("Chưa nhập mã hàng.", txtMaHang);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenHang.Text))
            {
                Loi("Chưa nhập tên hàng.", txtTenHang);
                return false;
            }

            if (cboHang.SelectedIndex < 0)
            {
                Loi("Chưa chọn hãng sản xuất.", cboHang);
                return false;
            }

            if (cboLoai.SelectedIndex < 0)
            {
                Loi("Chưa chọn loại hàng.", cboLoai);
                return false;
            }

            if (cboMau.SelectedIndex < 0)
            {
                Loi("Chưa chọn màu sắc.", cboMau);
                return false;
            }

            if (!DocTien(txtGiaNhap.Text, out decimal gn))
            {
                Loi("Giá nhập phải là số không âm.", txtGiaNhap);
                return false;
            }

            if (!DocTien(txtGiaBan.Text, out decimal gb))
            {
                Loi("Giá bán phải là số không âm.", txtGiaBan);
                return false;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int sl) || sl < 0)
            {
                Loi(
                    "Số lượng tồn phải là số nguyên không âm.",
                    txtSoLuong
                );

                return false;
            }

            hang = new HangHoa(
                txtMaHang.Text.Trim(),
                txtTenHang.Text.Trim(),
                cboHang.SelectedValue?.ToString(),
                cboLoai.SelectedValue?.ToString(),
                cboMau.SelectedValue?.ToString(),
                cboDungLuong.SelectedValue?.ToString(),
                gn,
                gb,
                sl
            );

            hang.TenAnh = tenAnh;

            return true;
        }

        // =====================================================
        // 10. THÊM HÀNG HÓA
        // =====================================================

        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (!TaoDoiTuongHang(out HangHoa? hang) || hang == null)
                return;

            if (hangHoaBus.Them(hang, out string error))
            {
                MessageBox.Show(
                    "Thêm mặt hàng thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadData();
                LamLai();
            }
            else
            {
                MessageBox.Show(
                    error,
                    "Lỗi thêm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // =====================================================
        // 11. SỬA HÀNG HÓA
        // =====================================================


        private void btnSua_Click(object? sender, EventArgs e)
        {
            // Kiểm tra đã chọn sản phẩm cần sửa chưa
            if (!txtMaHang.ReadOnly)
            {
                MessageBox.Show(
                    "Hãy chọn một dòng trong danh sách để sửa."
                );
                return;
            }

            // Lấy thông tin sản phẩm từ các ô nhập
            if (!TaoDoiTuongHang(out HangHoa? hang) || hang == null)
                return;

            // Đảm bảo tên ảnh mới được lưu vào đối tượng
            hang.TenAnh = tenAnh;

            // Cập nhật sản phẩm xuống SQL Server
            if (hangHoaBus.Sua(hang, out string error))
            {
                MessageBox.Show(
                    "Cập nhật sản phẩm thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadData();
                LamLai();
            }
            else
            {
                MessageBox.Show(
                    string.IsNullOrWhiteSpace(error)
                        ? "Cập nhật sản phẩm thất bại!"
                        : error,
                    "Lỗi cập nhật",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // =====================================================
        // 12. XÓA HÀNG HÓA
        // =====================================================

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!txtMaHang.ReadOnly)
            {
                MessageBox.Show(
                    "Hãy chọn một dòng trong danh sách để xóa."
                );

                return;
            }

            string ma = txtMaHang.Text.Trim();

            if (MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa mặt hàng {ma}?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            ) != DialogResult.Yes)
            {
                return;
            }

            if (hangHoaBus.Xoa(ma, out string error))
            {
                MessageBox.Show(
                    "Đã xóa mặt hàng!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadData();
                LamLai();
            }
            else
            {
                MessageBox.Show(
                    error,
                    "Lỗi xóa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // =====================================================
        // 13. LÀM LẠI FORM
        // =====================================================

        private void btnLamLai_Click(object? sender, EventArgs e)
        {
            txtTim.Clear();

            if (dvHang != null)
                dvHang.RowFilter = "";

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

        // =====================================================
        // 14. TÌM KIẾM HÀNG HÓA
        // =====================================================

        private void btnTim_Click(object? sender, EventArgs e)
        {
            string tk = txtTim.Text.Trim().Replace("'", "''");

            if (dvHang == null)
                return;

            if (tk.Length == 0)
            {
                dvHang.RowFilter = "";
                return;
            }

            dvHang.RowFilter =
                $"TenHang LIKE '%{tk}%' OR MaHang LIKE '%{tk}%'";

            if (dvHang.Count == 0)
            {
                MessageBox.Show(
                    "Không tìm thấy mặt hàng nào phù hợp.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        // =====================================================
        // DỰNG GIAO DIỆN
        // Tách khỏi InitializeComponent() để màn [Design] của Visual Studio
        // luôn mở được: trình thiết kế không đọc được vòng lặp và biến cục bộ.
        // =====================================================
        private void TaoGiaoDien()
        {
               // Controls
               groupBox1 = new GroupBox();
               groupBox2 = new GroupBox();
               groupBox3 = new GroupBox();
               groupBox4 = new GroupBox();
               txtMaHang = new TextBox();
               txtTenHang = new TextBox();
               txtGiaNhap = new TextBox();
               txtGiaBan = new TextBox();
               txtSoLuong = new TextBox();
               txtTim = new TextBox();
               cboHang = new ComboBox();
               cboLoai = new ComboBox();
               cboMau = new ComboBox();
               cboDungLuong = new ComboBox();
               picAnh = new PictureBox();
               lblTenAnh = new Label();
               btnThem = new Button();
               btnSua = new Button();
               btnXoa = new Button();
               btnLamLai = new Button();
               btnThoat = new Button();
               btnChonAnh = new Button();
               btnTim = new Button();
               dgvHang = new DataGridView();
               label1 = new Label();
               label2 = new Label();
               label3 = new Label();
               label4 = new Label();
               label5 = new Label();
               label6 = new Label();
               label7 = new Label();
               label8 = new Label();
               label9 = new Label();
               label10 = new Label();
               // Colors
               Color navy = Color.FromArgb(20, 43, 74);
               Color blue = Color.FromArgb(36, 120, 212);
               Color background = Color.FromArgb(244, 247, 251);
               Color textColor = Color.FromArgb(35, 51, 72);
               Color muted = Color.FromArgb(112, 128, 150);
               Color border = Color.FromArgb(220, 228, 238);
               Font normalFont = new Font("Segoe UI", 9.5F);
               Font boldFont = new Font("Segoe UI", 10F, FontStyle.Bold);
               // ==============================
               // FORM
               // ==============================
               BackColor = background;
               Font = normalFont;
               MinimumSize = new Size(850, 600);
               // ==============================
               // BỐ CỤC TỔNG
               // ==============================
               TableLayoutPanel root = new TableLayoutPanel
               {
                   Dock = DockStyle.Fill,
                   ColumnCount = 1,
                   RowCount = 4,
                   Padding = new Padding(16),
                   BackColor = background,
                   Margin = Padding.Empty
               };
               root.RowStyles.Add(
            new RowStyle(SizeType.Absolute, 310F)); // Thông tin điện thoại
               root.RowStyles.Add(
                   new RowStyle(SizeType.Absolute, 105F)); // Chức năng
               root.RowStyles.Add(
                   new RowStyle(SizeType.Absolute, 105F)); // Tìm kiếm
               root.RowStyles.Add(
                   new RowStyle(SizeType.Percent, 100F)); // Danh sách
               // ==============================
               // 1. THÔNG TIN SẢN PHẨM
               // ==============================
               TableLayoutPanel top = new TableLayoutPanel
               {
                   Dock = DockStyle.Fill,
                   ColumnCount = 2,
                   RowCount = 1,
                   BackColor = background,
                   Margin = Padding.Empty
               };
               top.ColumnStyles.Add(
                   new ColumnStyle(SizeType.Percent, 68F));
               top.ColumnStyles.Add(
                   new ColumnStyle(SizeType.Percent, 32F));
               groupBox1.Text = "THÔNG TIN ĐIỆN THOẠI";
               StyleGroup(groupBox1, navy, border, boldFont);
               groupBox1.Dock = DockStyle.Fill;
               groupBox1.Margin = new Padding(0, 0, 10, 0);
               TableLayoutPanel fields = new TableLayoutPanel
               {
                   Dock = DockStyle.Fill,
                   ColumnCount = 4,
                   RowCount = 5,
                   Padding = new Padding(12, 10, 12, 10),
                   BackColor = Color.White
               };
               fields.ColumnStyles.Add(
                   new ColumnStyle(SizeType.Absolute, 100F));
               fields.ColumnStyles.Add(
                   new ColumnStyle(SizeType.Percent, 50F));
               fields.ColumnStyles.Add(
                   new ColumnStyle(SizeType.Absolute, 100F));
               fields.ColumnStyles.Add(
                   new ColumnStyle(SizeType.Percent, 50F));
               for (int i = 0; i < 5; i++)
               {
                   fields.RowStyles.Add(
                       new RowStyle(SizeType.Percent, 20F));
               }
               // Labels
               SetLabel(label1, "Mã hàng");
               SetLabel(label6, "Tên hàng");
               SetLabel(label2, "Hãng SX");
               SetLabel(label7, "Loại");
               SetLabel(label4, "Màu sắc");
               SetLabel(label8, "Dung lượng");
               SetLabel(label3, "Giá nhập");
               SetLabel(label9, "Giá bán");
               SetLabel(label5, "Số lượng tồn");
               // Inputs
               StyleText(txtMaHang);
               StyleText(txtTenHang);
               StyleText(txtGiaNhap);
               StyleText(txtGiaBan);
               StyleText(txtSoLuong);
               StyleCombo(cboHang);
               StyleCombo(cboLoai);
               StyleCombo(cboMau);
               StyleCombo(cboDungLuong);
               AddField(fields, label1, txtMaHang, 0, 0);
               AddField(fields, label6, txtTenHang, 2, 0);
               AddField(fields, label2, cboHang, 0, 1);
               AddField(fields, label7, cboLoai, 2, 1);
               AddField(fields, label4, cboMau, 0, 2);
               AddField(fields, label8, cboDungLuong, 2, 2);
               AddField(fields, label3, txtGiaNhap, 0, 3);
               AddField(fields, label9, txtGiaBan, 2, 3);
               fields.Controls.Add(label5, 0, 4);
               fields.Controls.Add(txtSoLuong, 1, 4);
               groupBox1.Controls.Add(fields);
               // ==============================
               // 2. ẢNH SẢN PHẨM
               // ==============================
               groupBox2.Text = "ẢNH ĐẠI DIỆN";
               StyleGroup(groupBox2, navy, border, boldFont);
               groupBox2.Dock = DockStyle.Fill;
               groupBox2.Margin = new Padding(0);
               TableLayoutPanel imageLayout = new TableLayoutPanel
               {
                   Dock = DockStyle.Fill,
                   ColumnCount = 1,
                   RowCount = 3,
                   Padding = new Padding(12),
                   BackColor = Color.White
               };
               imageLayout.RowStyles.Add(
                   new RowStyle(SizeType.Percent, 100F));
               imageLayout.RowStyles.Add(
                   new RowStyle(SizeType.Absolute, 42F));
               imageLayout.RowStyles.Add(
                   new RowStyle(SizeType.Absolute, 25F));
               picAnh.Dock = DockStyle.Fill;
               picAnh.BackColor = background;
               picAnh.SizeMode = PictureBoxSizeMode.Zoom;
               picAnh.Margin = new Padding(0, 0, 0, 8);
               btnChonAnh.Text = "CHỌN ẢNH";
               btnChonAnh.Dock = DockStyle.Fill;
               StyleButton(btnChonAnh, blue);
               lblTenAnh.Text = "Chưa chọn ảnh";
               lblTenAnh.Dock = DockStyle.Fill;
               lblTenAnh.TextAlign = ContentAlignment.MiddleCenter;
               lblTenAnh.ForeColor = muted;
               lblTenAnh.AutoEllipsis = true;
               lblTenAnh.Font = normalFont;
               imageLayout.Controls.Add(picAnh, 0, 0);
               imageLayout.Controls.Add(btnChonAnh, 0, 1);
               imageLayout.Controls.Add(lblTenAnh, 0, 2);
               groupBox2.Controls.Add(imageLayout);
               top.Controls.Add(groupBox1, 0, 0);
               top.Controls.Add(groupBox2, 1, 0);
               // ==============================
               // 3. NÚT CHỨC NĂNG
               // ==============================
               groupBox3.Text = "CHỨC NĂNG";
               groupBox3.Dock = DockStyle.Fill;
               groupBox3.Margin = new Padding(0, 6, 0, 5);
               StyleGroup(groupBox3, navy, border, boldFont);
               FlowLayoutPanel actions = new FlowLayoutPanel
               {
                   Dock = DockStyle.Fill,
                   FlowDirection = FlowDirection.LeftToRight,
                   WrapContents = false,
                   Padding = new Padding(10, 5, 10, 2),
                   BackColor = Color.White
               };
               StyleButton(btnThem, blue);
               StyleButton(btnSua, blue);
               StyleButton(btnXoa, Color.FromArgb(210, 70, 70));
               StyleButton(btnLamLai, Color.FromArgb(112, 128, 150));
               StyleButton(btnThoat, navy);
               btnThem.Text = "+ THÊM";
               btnSua.Text = "SỬA";
               btnXoa.Text = "XÓA";
               btnLamLai.Text = "LÀM LẠI";
               btnThoat.Text = "THOÁT";
               foreach (Button b in new[]
               {
                   btnThem, btnSua, btnXoa, btnLamLai, btnThoat
               })
               {
                   b.Size = new Size(130, 45);
                   b.Margin = new Padding(8, 5, 12, 5);
                   actions.Controls.Add(b);
               }
               groupBox3.Controls.Add(actions);
               // ==============================
               // 4. TÌM KIẾM
               // ==============================
               groupBox4.Text = "TÌM KIẾM MẶT HÀNG";
               groupBox4.Dock = DockStyle.Fill;
               groupBox4.Margin = new Padding(0, 6, 0, 0);
               StyleGroup(groupBox4, navy, border, boldFont);
               TableLayoutPanel searchLayout = new TableLayoutPanel
               {
                   Dock = DockStyle.Fill,
                   ColumnCount = 3,
                   RowCount = 1,
                   Padding = new Padding(10, 4, 10, 4),
                   BackColor = Color.White
               };
               searchLayout.ColumnStyles.Add(
                   new ColumnStyle(SizeType.Absolute, 170F));
               searchLayout.ColumnStyles.Add(
                   new ColumnStyle(SizeType.Percent, 100F));
               searchLayout.ColumnStyles.Add(
                   new ColumnStyle(SizeType.Absolute, 115F));
               label10.Text = "Tên hoặc mã hàng";
               label10.Dock = DockStyle.Fill;
               label10.TextAlign = ContentAlignment.MiddleLeft;
               label10.Font = normalFont;
               label10.ForeColor = textColor;
               StyleText(txtTim);
               txtTim.Dock = DockStyle.Fill;
               txtTim.Margin = new Padding(5, 3, 10, 3);
               btnTim.Text = "TÌM KIẾM";
               btnTim.Dock = DockStyle.Fill;
               StyleButton(btnTim, blue);
               searchLayout.Controls.Add(label10, 0, 0);
               searchLayout.Controls.Add(txtTim, 1, 0);
               searchLayout.Controls.Add(btnTim, 2, 0);
               groupBox4.Controls.Add(searchLayout);
               // ==============================
               // 5. BẢNG DANH SÁCH
               // ==============================
               dgvHang.Dock = DockStyle.Fill;
               dgvHang.BackgroundColor = Color.White;
               dgvHang.BorderStyle = BorderStyle.None;
               dgvHang.EnableHeadersVisualStyles = false;
               dgvHang.ColumnHeadersDefaultCellStyle.BackColor = navy;
               dgvHang.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
               dgvHang.ColumnHeadersDefaultCellStyle.Font =
                   new Font("Segoe UI", 9.5F, FontStyle.Bold);
               dgvHang.DefaultCellStyle.Font = normalFont;
               dgvHang.DefaultCellStyle.ForeColor = textColor;
               dgvHang.DefaultCellStyle.BackColor = Color.White;
               dgvHang.DefaultCellStyle.SelectionBackColor =
                   Color.FromArgb(220, 235, 252);
               dgvHang.DefaultCellStyle.SelectionForeColor = navy;
               dgvHang.AlternatingRowsDefaultCellStyle.BackColor =
                   Color.FromArgb(245, 248, 252);
               dgvHang.ColumnHeadersHeight = 42;
               dgvHang.RowTemplate.Height = 36;
               dgvHang.AutoSizeColumnsMode =
                   DataGridViewAutoSizeColumnsMode.Fill;
               dgvHang.SelectionMode =
                   DataGridViewSelectionMode.FullRowSelect;
               dgvHang.MultiSelect = false;
               dgvHang.ReadOnly = true;
               dgvHang.AllowUserToAddRows = false;
               dgvHang.RowHeadersVisible = false;
               dgvHang.GridColor = border;
               dgvHang.Margin = new Padding(0, 5, 0, 0);
               // ==============================
               // GHÉP GIAO DIỆN
               // ==============================
               root.Controls.Add(top, 0, 0);
               root.Controls.Add(groupBox3, 0, 1);
               root.Controls.Add(groupBox4, 0, 2);
               root.Controls.Add(dgvHang, 0, 3);
               Controls.Add(root);
        }

        // =====================================================
        // CÁC HÀM HỖ TRỢ THIẾT KẾ
        // =====================================================
        private void StyleGroup(
            GroupBox group,
            Color titleColor,
            Color lineColor,
            Font font)
        {
            group.BackColor = Color.White;
            group.ForeColor = titleColor;
            group.Font = font;
            group.Padding = new Padding(10);
        }

        private void SetLabel(Label label, string text)
        {
            label.Text = text;
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(35, 51, 72);
            label.Margin = new Padding(3);
        }

        private void StyleText(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 10F);
            txt.BackColor = Color.FromArgb(248, 250, 253);
            txt.ForeColor = Color.FromArgb(35, 51, 72);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Dock = DockStyle.Fill;
            txt.Margin = new Padding(5, 5, 8, 5);
        }

        private void StyleCombo(ComboBox cbo)
        {
            cbo.Font = new Font("Segoe UI", 9.5F);
            cbo.BackColor = Color.FromArgb(248, 250, 253);
            cbo.ForeColor = Color.FromArgb(35, 51, 72);
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.Dock = DockStyle.Fill;
            cbo.Margin = new Padding(5, 5, 8, 5);
        }

        private void StyleButton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }

        private void AddField(
            TableLayoutPanel table,
            Control label,
            Control input,
            int column,
            int row)
        {
            table.Controls.Add(label, column, row);
            table.Controls.Add(input, column + 1, row);
        }
    }
}
