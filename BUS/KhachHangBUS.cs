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
    }
}
