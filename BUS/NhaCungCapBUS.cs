using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng nghiệp vụ cho nhà cung cấp.
    /// </summary>
    public class NhaCungCapBUS
    {
        private readonly NhaCungCapDAL dal = new NhaCungCapDAL();

        public DataTable LayDanhSach()
        {
            return dal.LayTatCa();
        }

        public List<string> LayDanhSachMa()
        {
            var ds = new List<string>();
            foreach (DataRow r in dal.LayDanhSachMa().Rows)
                ds.Add(r["MaNCC"].ToString() ?? "");
            return ds;
        }

        /// <summary>Lấy thông tin nhà cung cấp theo mã (dùng cho Form hóa đơn nhập).</summary>
        public NhaCungCap? LayThongTin(string maNCC)
        {
            if (string.IsNullOrWhiteSpace(maNCC)) return null;

            DataTable dt = dal.LayThongTin(maNCC.Trim());
            if (dt.Rows.Count == 0) return null;

            DataRow r = dt.Rows[0];
            return new NhaCungCap(
                r["MaNCC"].ToString() ?? "",
                r["TenNCC"].ToString() ?? "",
                r["SDT"] == DBNull.Value ? "" : r["SDT"].ToString() ?? "",
                r["DiaChi"] == DBNull.Value ? "" : r["DiaChi"].ToString() ?? "",
                r["Email"] == DBNull.Value ? "" : r["Email"].ToString() ?? "",
                r["NguoiLH"] == DBNull.Value ? "" : r["NguoiLH"].ToString() ?? "");
        }

        private static bool KiemTraThongTin(NhaCungCap ncc, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(ncc.MaNCC))
            {
                error = "Mã nhà cung cấp không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(ncc.TenNCC))
            {
                error = "Tên nhà cung cấp không được để trống!";
                return false;
            }

            if (!AppHelpers.KiemTraSoDienThoai(ncc.SDT))
            {
                error = "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(ncc.DiaChi))
            {
                error = "Địa chỉ không được để trống!";
                return false;
            }

            if (!AppHelpers.KiemTraEmail(ncc.Email))
            {
                error = "Địa chỉ email không hợp lệ!";
                return false;
            }

            if (ncc.Email?.Length > 255)
            {
                error = "Email không được vượt quá 255 ký tự!";
                return false;
            }

            if (ncc.NguoiLH?.Length > 100)
            {
                error = "Tên người liên hệ không được vượt quá 100 ký tự!";
                return false;
            }

            return true;
        }

        public bool Them(NhaCungCap ncc, out string error)
        {
            if (!KiemTraThongTin(ncc, out error)) return false;

            try
            {
                if (dal.KiemTraTonTai(ncc.MaNCC.Trim()))
                {
                    error = $"Mã nhà cung cấp '{ncc.MaNCC}' đã tồn tại!";
                    return false;
                }

                if (dal.Them(ncc) > 0)
                {
                    AppHelpers.GhiLog($"Thêm nhà cung cấp {ncc.MaNCC} - {ncc.TenNCC}");
                    return true;
                }

                error = "Thêm nhà cung cấp không thành công!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi thêm nhà cung cấp: " + ex.Message;
                return false;
            }
        }

        public bool Sua(NhaCungCap ncc, out string error)
        {
            if (!KiemTraThongTin(ncc, out error)) return false;

            try
            {
                if (!dal.KiemTraTonTai(ncc.MaNCC.Trim()))
                {
                    error = "Nhà cung cấp không còn tồn tại trong cơ sở dữ liệu!";
                    return false;
                }

                if (dal.Sua(ncc) > 0)
                {
                    AppHelpers.GhiLog($"Cập nhật nhà cung cấp {ncc.MaNCC}");
                    return true;
                }

                error = "Không có dữ liệu nào được cập nhật!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi cập nhật nhà cung cấp: " + ex.Message;
                return false;
            }
        }

        public bool Xoa(string maNCC, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(maNCC))
            {
                error = "Chưa chọn nhà cung cấp cần xóa!";
                return false;
            }

            try
            {
                if (!dal.KiemTraTonTai(maNCC.Trim()))
                {
                    error = "Nhà cung cấp không còn tồn tại trong cơ sở dữ liệu!";
                    return false;
                }

                if (dal.Xoa(maNCC.Trim()) > 0)
                {
                    AppHelpers.GhiLog($"Xóa nhà cung cấp {maNCC}");
                    return true;
                }

                error = "Không tìm thấy nhà cung cấp cần xóa!";
                return false;
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                error = "Không thể xóa nhà cung cấp này vì đã có hóa đơn nhập liên quan!\n\n" +
                        "Hãy giữ lại nhà cung cấp để bảo toàn lịch sử hóa đơn.";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi xóa nhà cung cấp: " + ex.Message;
                return false;
            }
        }
    }
}
