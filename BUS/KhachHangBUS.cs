using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng nghiệp vụ cho khách hàng: kiểm tra mã, số điện thoại, email
    /// và chặn xóa khách hàng đã phát sinh hóa đơn để bảo toàn lịch sử giao dịch.
    /// </summary>
    public class KhachHangBUS
    {
        private readonly KhachHangDAL dal = new KhachHangDAL();

        public DataTable LayDanhSach()
        {
            return dal.LayTatCa();
        }

        public List<string> LayDanhSachMa()
        {
            var ds = new List<string>();
            foreach (DataRow r in dal.LayDanhSachMa().Rows)
                ds.Add(r["MaKH"].ToString() ?? "");
            return ds;
        }

        /// <summary>Lấy thông tin khách hàng theo mã (dùng cho Form hóa đơn bán).</summary>
        public KhachHang? LayThongTin(string maKH)
        {
            if (string.IsNullOrWhiteSpace(maKH)) return null;

            DataTable dt = dal.LayThongTin(maKH.Trim());
            if (dt.Rows.Count == 0) return null;

            DataRow r = dt.Rows[0];
            return new KhachHang(
                r["MaKH"].ToString() ?? "",
                r["TenKH"].ToString() ?? "",
                r["SDT"] == DBNull.Value ? "" : r["SDT"].ToString() ?? "",
                r["DiaChi"] == DBNull.Value ? "" : r["DiaChi"].ToString() ?? "",
                r["Email"] == DBNull.Value ? "" : r["Email"].ToString() ?? "");
        }

        /// <summary>
        /// Thêm khách hàng mới ngay trên hóa đơn bán (Form7): chỉ bắt buộc tên và số điện thoại
        /// đúng 10 chữ số, địa chỉ không bắt buộc. Nếu số điện thoại đã có trong cơ sở dữ liệu
        /// thì thủ tục lưu trữ trả về mã khách hàng cũ thay vì tạo bản ghi trùng.
        /// </summary>
        public string? ThemKhachHangTuDong(string tenKH, string sdt, string diaChi,
            out bool laKhachMoi, out string error)
        {
            laKhachMoi = false;
            error = "";

            string tenChuan = AppHelpers.ChuanHoaChuoi(tenKH);
            string sdtChuan = (sdt ?? "").Trim();
            string diaChiChuan = AppHelpers.ChuanHoaChuoi(diaChi);

            if (tenChuan == "")
            {
                error = "Tên khách hàng không được để trống!";
                return null;
            }

            if (!AppHelpers.KiemTraSoDienThoai(sdtChuan))
            {
                error = "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng 0!";
                return null;
            }

            if (tenChuan.Length > 100)
            {
                error = "Tên khách hàng tối đa 100 ký tự!";
                return null;
            }

            if (diaChiChuan.Length > 200)
            {
                error = "Địa chỉ khách hàng tối đa 200 ký tự!";
                return null;
            }

            try
            {
                DataTable dt = dal.ThemKhachHangTuDong(tenChuan, sdtChuan, diaChiChuan);

                if (dt.Rows.Count == 0)
                {
                    error = "Không thêm được khách hàng mới!";
                    return null;
                }

                DataRow r = dt.Rows[0];
                string maKH = r["MaKH"].ToString() ?? "";
                laKhachMoi = r["LaKhachMoi"] != DBNull.Value
                    && Convert.ToInt32(r["LaKhachMoi"]) == 1;

                if (maKH == "")
                {
                    error = "Không xác định được mã khách hàng vừa thêm!";
                    return null;
                }

                AppHelpers.GhiLog(laKhachMoi
                    ? $"Thêm khách hàng mới {maKH} - {tenChuan} từ hóa đơn bán"
                    : $"Dùng lại khách hàng {maKH} theo số điện thoại {sdtChuan}");

                return maKH;
            }
            catch (Exception ex)
            {
                error = "Lỗi thêm khách hàng: " + ex.Message;
                return null;
            }
        }

        private static bool KiemTra(KhachHang kh, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(kh.MaKH))
            {
                error = "Mã khách hàng không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(kh.HoTen))
            {
                error = "Tên khách hàng không được để trống!";
                return false;
            }

            if (!AppHelpers.KiemTraSoDienThoai(kh.SDT))
            {
                error = "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng 0!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(kh.DiaChi))
            {
                error = "Địa chỉ không được để trống!";
                return false;
            }

            if (!AppHelpers.KiemTraEmail(kh.Email))
            {
                error = "Địa chỉ email không hợp lệ!";
                return false;
            }

            return true;
        }

        public bool Them(KhachHang kh, out string error)
        {
            if (!KiemTra(kh, out error)) return false;

            try
            {
                if (dal.KiemTraTonTai(kh.MaKH.Trim()))
                {
                    error = $"Mã khách hàng '{kh.MaKH}' đã tồn tại!";
                    return false;
                }

                if (dal.Them(kh) > 0)
                {
                    AppHelpers.GhiLog($"Thêm khách hàng {kh.MaKH} - {kh.HoTen}");
                    return true;
                }

                error = "Không thể thêm khách hàng!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi thêm khách hàng: " + ex.Message;
                return false;
            }
        }

        public bool Sua(KhachHang kh, out string error)
        {
            if (!KiemTra(kh, out error)) return false;

            try
            {
                if (!dal.KiemTraTonTai(kh.MaKH.Trim()))
                {
                    error = "Khách hàng không còn tồn tại trong cơ sở dữ liệu!";
                    return false;
                }

                if (dal.Sua(kh) > 0)
                {
                    AppHelpers.GhiLog($"Cập nhật khách hàng {kh.MaKH}");
                    return true;
                }

                error = "Không tìm thấy khách hàng cần sửa!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi cập nhật khách hàng: " + ex.Message;
                return false;
            }
        }

        public bool Xoa(string maKH, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(maKH))
            {
                error = "Chưa chọn khách hàng cần xóa!";
                return false;
            }

            try
            {
                // Kiểm tra khách hàng đã phát sinh hóa đơn chưa
                DataTable dtHoaDon = dal.LayHoaDonCuaKhachHang(maKH.Trim());

                if (dtHoaDon.Rows.Count > 0)
                {
                    string danhSachHoaDon = string.Join(", ",
                        dtHoaDon.AsEnumerable().Select(r => r["MaHDB"].ToString()));

                    error = $"Không thể xóa khách hàng {maKH} vì đã phát sinh hóa đơn.\n\n" +
                            $"Danh sách hóa đơn liên quan:\n{danhSachHoaDon}\n\n" +
                            "Để bảo vệ lịch sử giao dịch, khách hàng này không thể bị xóa.";
                    return false;
                }

                if (dal.Xoa(maKH.Trim()) > 0)
                {
                    AppHelpers.GhiLog($"Xóa khách hàng {maKH}");
                    return true;
                }

                error = "Không tìm thấy khách hàng cần xóa!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Không thể xóa khách hàng: " + ex.Message;
                return false;
            }
        }

        // ------------------------------------------------------------------
        // TÀI KHOẢN KHÁCH HÀNG: ĐĂNG KÝ - ĐĂNG NHẬP (FormDangKy, Form9)
        // ------------------------------------------------------------------

        /// <summary>
        /// Đăng ký tài khoản Khách hàng: kiểm tra dữ liệu rồi ghi thẳng hồ sơ
        /// (kèm tên đăng nhập và mật khẩu) vào tblKhachHang qua thủ tục lưu trữ.
        /// Khác với Nhân viên, khách hàng không cần hồ sơ trong tblNhanVien.
        /// </summary>
        public bool DangKy(KhachHang kh, out string maKH, out string error)
        {
            maKH = "";
            error = "";

            string tenChuan = AppHelpers.ChuanHoaChuoi(kh.HoTen);
            string sdtChuan = (kh.SDT ?? "").Trim();
            string emailChuan = (kh.Email ?? "").Trim();
            string diaChiChuan = AppHelpers.ChuanHoaChuoi(kh.DiaChi);
            string taiKhoanChuan = (kh.TaiKhoan ?? "").Trim();

            if (tenChuan == "")
            {
                error = "Vui lòng nhập họ và tên!";
                return false;
            }

            if (tenChuan.Length > 100)
            {
                error = "Họ và tên tối đa 100 ký tự!";
                return false;
            }

            if (!AppHelpers.KiemTraSoDienThoai(sdtChuan))
            {
                error = "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng 0!";
                return false;
            }

            if (emailChuan.Length > 150)
            {
                error = "Email tối đa 150 ký tự!";
                return false;
            }

            // Email không bắt buộc, nhưng nếu đã nhập thì phải đúng định dạng
            if (!AppHelpers.KiemTraEmail(emailChuan))
            {
                error = "Địa chỉ email không hợp lệ!";
                return false;
            }

            if (diaChiChuan.Length > 200)
            {
                error = "Địa chỉ tối đa 200 ký tự!";
                return false;
            }

            if (taiKhoanChuan.Length < 4)
            {
                error = "Tên đăng nhập phải có ít nhất 4 ký tự!";
                return false;
            }

            if (taiKhoanChuan.Length > 50)
            {
                error = "Tên đăng nhập tối đa 50 ký tự!";
                return false;
            }

            if (taiKhoanChuan.Contains(" "))
            {
                error = "Tên đăng nhập không được chứa khoảng trắng!";
                return false;
            }

            if ((kh.MatKhau ?? "").Length < 6)
            {
                error = "Mật khẩu phải có ít nhất 6 ký tự!";
                return false;
            }

            try
            {
                if (dal.KiemTraTaiKhoan(taiKhoanChuan))
                {
                    error = "Tên đăng nhập đã có người dùng. Vui lòng chọn tên khác!";
                    return false;
                }

                if (emailChuan != "" && dal.KiemTraEmail(emailChuan))
                {
                    error = "Email này đã được đăng ký!";
                    return false;
                }

                kh.HoTen = tenChuan;
                kh.SDT = sdtChuan;
                kh.Email = emailChuan;
                kh.DiaChi = diaChiChuan;
                kh.TaiKhoan = taiKhoanChuan;

                DataTable dt = dal.DangKy(kh);

                if (dt.Rows.Count == 0 || dt.Rows[0]["MaKH"] == DBNull.Value)
                {
                    error = "Đăng ký tài khoản không thành công. Vui lòng thử lại!";
                    return false;
                }

                maKH = dt.Rows[0]["MaKH"].ToString() ?? "";
                kh.MaKH = maKH;

                AppHelpers.GhiLog($"Đăng ký tài khoản Khách hàng {maKH} - {taiKhoanChuan}");
                return true;
            }
            catch (Exception ex)
            {
                error = "Lỗi đăng ký tài khoản: " + ex.Message;
                return false;
            }
        }

        /// <summary>Đăng nhập tài khoản Khách hàng; trả về hồ sơ khách hàng khi thành công.</summary>
        public bool DangNhap(string taiKhoan, string matKhau, out KhachHang? kh, out string error)
        {
            kh = null;
            error = "";

            string tk = (taiKhoan ?? "").Trim();

            if (tk == "" || string.IsNullOrWhiteSpace(matKhau))
            {
                error = "Vui lòng nhập tên đăng nhập và mật khẩu!";
                return false;
            }

            try
            {
                DataTable dt = dal.DangNhap(tk, matKhau);

                if (dt.Rows.Count == 0)
                {
                    error = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                    return false;
                }

                DataRow r = dt.Rows[0];

                kh = new KhachHang(
                    r["MaKH"].ToString() ?? "",
                    r["TenKH"].ToString() ?? "",
                    r["SDT"] == DBNull.Value ? "" : r["SDT"].ToString() ?? "",
                    r["DiaChi"] == DBNull.Value ? "" : r["DiaChi"].ToString() ?? "",
                    r["Email"] == DBNull.Value ? "" : r["Email"].ToString() ?? "")
                {
                    TaiKhoan = r["TaiKhoan"] == DBNull.Value ? tk : r["TaiKhoan"].ToString() ?? tk
                };

                AppHelpers.GhiLog($"Khách hàng {kh.MaKH} đăng nhập ({tk})");
                return true;
            }
            catch (Exception ex)
            {
                error = "Lỗi đăng nhập: " + ex.Message;
                return false;
            }
        }
    }
}
