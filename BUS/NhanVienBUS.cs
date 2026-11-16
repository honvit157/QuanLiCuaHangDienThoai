using System;
using System.Collections.Generic;
using System.Data;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng nghiệp vụ cho nhân viên: đăng nhập, phân quyền, quản lý hồ sơ nhân viên.
    /// </summary>
    public class NhanVienBUS
    {
        /// <summary>Ba mức phân quyền dùng chung cho đăng nhập, đăng ký và Dashboard.</summary>
        public const string VaiTroQuanLy = "Quản lý";
        public const string VaiTroNhanVien = "Nhân viên";
        public const string VaiTroKhachHang = "Khách hàng";

        private readonly NhanVienDAL dal = new NhanVienDAL();

        /// <summary>Xác thực đăng nhập, trả về đối tượng nhân viên nếu thành công.</summary>
        public bool DangNhap(string taiKhoan, string matKhau, out NhanVien? nv, out string error)
        {
            nv = null;
            error = "";

            if (string.IsNullOrWhiteSpace(taiKhoan) || string.IsNullOrWhiteSpace(matKhau))
            {
                error = "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!";
                return false;
            }

            try
            {
                DataTable dt = dal.KiemTraDangNhap(taiKhoan.Trim(), matKhau.Trim());

                if (dt.Rows.Count == 0)
                {
                    error = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                    return false;
                }

                DataRow r = dt.Rows[0];
                nv = new NhanVien
                {
                    MaNV = r["MaNV"].ToString() ?? "",
                    HoTen = r["TenNV"].ToString() ?? "",
                    TenDangNhap = taiKhoan.Trim(),
                    VaiTro = r["VaiTro"] == DBNull.Value ? "Nhân viên" : r["VaiTro"].ToString() ?? "Nhân viên"
                };

                AppHelpers.GhiLog($"Đăng nhập thành công: {nv.MaNV} - {nv.HoTen}");
                return true;
            }
            catch (Exception ex)
            {
                error = "Lỗi kết nối cơ sở dữ liệu: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Đăng ký tài khoản mới từ biểu mẫu FormDangKy theo vai trò người đăng ký chọn:
        /// "Khách hàng" hoặc "Nhân viên". Kiểm tra họ tên, số điện thoại (10 số), tên đăng nhập
        /// chưa trùng, mật khẩu khớp nhau; vai trò lạ luôn bị đưa về "Nhân viên" và không thể
        /// tự đăng ký thành "Quản lý" (BUS và Stored Procedure đều chặn).
        /// </summary>
        public bool DangKy(string hoTen, string sdt, string tenDangNhap,
                           string matKhau, string nhapLaiMatKhau, string vaiTro,
                           out string maNV, out string error)
        {
            maNV = "";
            error = "";

            string ten = tenDangNhap.Trim();
            string mk = matKhau.Trim();
            string mkNhapLai = nhapLaiMatKhau.Trim();
            string vaiTroChuan = ChuanHoaVaiTro(vaiTro);

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                error = "Họ tên không được để trống!";
                return false;
            }

            if (!AppHelpers.KiemTraSoDienThoai(sdt?.Trim()))
            {
                error = "Số điện thoại phải có 10 chữ số bắt đầu bằng 0!";
                return false;
            }

            if (ten.Length < 3)
            {
                error = "Tên đăng nhập phải có ít nhất 3 ký tự!";
                return false;
            }

            if (ten.Contains(" "))
            {
                error = "Tên đăng nhập không được chứa khoảng trắng!";
                return false;
            }

            if (mk.Length < 6)
            {
                error = "Mật khẩu phải có ít nhất 6 ký tự!";
                return false;
            }

            if (!string.Equals(mk, mkNhapLai, StringComparison.Ordinal))
            {
                error = "Mật khẩu nhập lại không khớp!";
                return false;
            }

            try
            {
                if (dal.KiemTraTenDangNhapTonTai(ten))
                {
                    error = $"Tên đăng nhập '{ten}' đã có người dùng, vui lòng chọn tên khác!";
                    return false;
                }

                maNV = dal.DangKy(hoTen.Trim(), sdt.Trim(), ten, mk, vaiTroChuan);

                if (string.IsNullOrEmpty(maNV))
                {
                    error = "Không tạo được tài khoản, vui lòng thử lại!";
                    return false;
                }

                AppHelpers.GhiLog($"Đăng ký tài khoản mới: {maNV} - {hoTen.Trim()} ({ten}) - vai trò {vaiTroChuan}");
                return true;
            }
            catch (Exception ex)
            {
                error = "Lỗi đăng ký tài khoản: " + ex.Message;
                return false;
            }
        }

        public DataTable LayDanhSach()
        {
            return dal.LayTatCa();
        }

        /// <summary>
        /// Chuẩn hóa vai trò tự đăng ký: chỉ nhận "Khách hàng", mọi giá trị khác
        /// (kể cả để trống) trở thành "Nhân viên"; "Quản lý" không bao giờ được trả về.
        /// </summary>
        public static string ChuanHoaVaiTro(string vaiTro)
        {
            string giaTri = (vaiTro ?? "").Trim();

            return string.Equals(giaTri, VaiTroKhachHang, StringComparison.OrdinalIgnoreCase)
                   || string.Equals(giaTri, "Khach hang", StringComparison.OrdinalIgnoreCase)
                ? VaiTroKhachHang
                : VaiTroNhanVien;
        }

        public List<string> LayDanhSachMa()
        {
            var ds = new List<string>();
            foreach (DataRow r in dal.LayDanhSachMa().Rows)
                ds.Add(r["MaNV"].ToString() ?? "");
            return ds;
        }

        /// <summary>Lấy họ tên nhân viên theo mã (dùng cho Form hóa đơn).</summary>
        public string LayTen(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV)) return "";
            try
            {
                return dal.LayTen(maNV.Trim());
            }
            catch
            {
                return "";
            }
        }

        public bool CapNhatTrangThai(string maNV, string trangThai)
        {
            if (string.IsNullOrWhiteSpace(maNV)) return false;
            if (trangThai != "Đang làm việc" && trangThai != "Đã nghỉ việc") return false;

            try
            {
                return dal.CapNhatTrangThai(maNV.Trim(), trangThai) > 0;
            }
            catch (Exception ex)
            {
                AppHelpers.HienCanhBao("Lỗi cập nhật trạng thái: " + ex.Message);
                return false;
            }
        }

        private static bool KiemTra(NhanVien nv, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(nv.MaNV))
            {
                error = "Mã nhân viên không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(nv.HoTen))
            {
                error = "Tên nhân viên không được để trống!";
                return false;
            }

            if (!AppHelpers.KiemTraSoDienThoai(nv.SDT))
            {
                error = "Số điện thoại phải có 10 chữ số bắt đầu bằng 0!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(nv.DiaChi))
            {
                error = "Địa chỉ không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(nv.MatKhau))
            {
                error = "Mật khẩu không được để trống!";
                return false;
            }

            if (nv.NgaySinh.Date > DateTime.Today)
            {
                error = "Ngày sinh không được lớn hơn ngày hiện tại!";
                return false;
            }

            return true;
        }

        public bool Them(NhanVien nv, out string error)
        {
            if (!KiemTra(nv, out error)) return false;

            try
            {
                if (dal.KiemTraTonTai(nv.MaNV.Trim()))
                {
                    error = $"Mã nhân viên '{nv.MaNV}' đã tồn tại!";
                    return false;
                }

                if (dal.Them(nv) > 0)
                {
                    AppHelpers.GhiLog($"Thêm nhân viên {nv.MaNV} - {nv.HoTen}");
                    return true;
                }

                error = "Không thể thêm nhân viên!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi thêm nhân viên: " + ex.Message;
                return false;
            }
        }

        public bool Sua(NhanVien nv, out string error)
        {
            if (!KiemTra(nv, out error)) return false;

            try
            {
                if (!dal.KiemTraTonTai(nv.MaNV.Trim()))
                {
                    error = "Nhân viên không còn tồn tại trong cơ sở dữ liệu!";
                    return false;
                }

                if (dal.Sua(nv) > 0)
                {
                    AppHelpers.GhiLog($"Cập nhật nhân viên {nv.MaNV}");
                    return true;
                }

                error = "Không có dữ liệu nào được cập nhật!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi cập nhật nhân viên: " + ex.Message;
                return false;
            }
        }

        public bool Xoa(string maNV, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(maNV))
            {
                error = "Chưa chọn nhân viên cần xóa!";
                return false;
            }

            try
            {
                if (dal.Xoa(maNV.Trim()) > 0)
                {
                    AppHelpers.GhiLog($"Xóa nhân viên {maNV}");
                    return true;
                }

                error = "Không tìm thấy nhân viên cần xóa!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Không thể xóa nhân viên (có thể nhân viên đã lập hóa đơn): " + ex.Message;
                return false;
            }
        }
    }
}
