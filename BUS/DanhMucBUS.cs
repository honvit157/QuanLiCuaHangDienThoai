using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng nghiệp vụ cho bốn danh mục tra cứu (hãng sản xuất, loại hàng,
    /// màu sắc, dung lượng). Dùng chung một lớp, chỉ khác nhau ở <see cref="LoaiDanhMuc"/>.
    /// </summary>
    public class DanhMucBUS
    {
        private readonly DanhMucDAL dal = new DanhMucDAL();

        /// <summary>Lấy danh sách danh mục; theoTen = true để sắp xếp theo tên.</summary>
        public DataTable LayDanhSach(LoaiDanhMuc loai, bool theoTen = false)
        {
            return dal.LayTatCa(loai, theoTen);
        }

        /// <summary>Tên tiếng Việt của danh mục, dùng trong thông báo.</summary>
        public static string LayTenDanhMuc(LoaiDanhMuc loai)
        {
            return loai switch
            {
                LoaiDanhMuc.HangSanXuat => "hãng sản xuất",
                LoaiDanhMuc.LoaiHang => "loại hàng",
                LoaiDanhMuc.MauSac => "màu sắc",
                LoaiDanhMuc.DungLuong => "dung lượng",
                _ => "danh mục"
            };
        }

        private static bool KiemTra(string ma, string ten, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(ma))
            {
                error = "Mã danh mục không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(ten))
            {
                error = "Tên danh mục không được để trống!";
                return false;
            }

            if (ma.Trim().Length > 20)
            {
                error = "Mã danh mục không được vượt quá 20 ký tự!";
                return false;
            }

            return true;
        }

        public bool Them(LoaiDanhMuc loai, string ma, string ten, out string error)
        {
            if (!KiemTra(ma, ten, out error)) return false;

            try
            {
                if (dal.KiemTraTonTai(loai, ma.Trim()))
                {
                    error = $"Mã {LayTenDanhMuc(loai)} '{ma}' đã tồn tại!";
                    return false;
                }

                if (dal.Them(loai, ma.Trim(), ten.Trim()) > 0)
                {
                    AppHelpers.GhiLog($"Thêm {LayTenDanhMuc(loai)} {ma} - {ten}");
                    return true;
                }

                error = "Không thể thêm danh mục!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi thêm danh mục: " + ex.Message;
                return false;
            }
        }

        public bool Sua(LoaiDanhMuc loai, string ma, string ten, out string error)
        {
            if (!KiemTra(ma, ten, out error)) return false;

            try
            {
                if (!dal.KiemTraTonTai(loai, ma.Trim()))
                {
                    error = "Danh mục không còn tồn tại trong cơ sở dữ liệu!";
                    return false;
                }

                if (dal.Sua(loai, ma.Trim(), ten.Trim()) > 0)
                {
                    AppHelpers.GhiLog($"Cập nhật {LayTenDanhMuc(loai)} {ma}");
                    return true;
                }

                error = "Không có dữ liệu nào được cập nhật!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi sửa danh mục: " + ex.Message;
                return false;
            }
        }

        public bool Xoa(LoaiDanhMuc loai, string ma, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(ma))
            {
                error = "Chưa chọn danh mục cần xóa!";
                return false;
            }

            try
            {
                if (dal.Xoa(loai, ma.Trim()) > 0)
                {
                    AppHelpers.GhiLog($"Xóa {LayTenDanhMuc(loai)} {ma}");
                    return true;
                }

                error = "Không tìm thấy danh mục cần xóa!";
                return false;
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                error = $"Không thể xóa {LayTenDanhMuc(loai)} này vì đang được dùng trong danh sách sản phẩm.\n\n" +
                        "Hãy cập nhật sản phẩm liên quan trước khi xóa.";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi xóa danh mục: " + ex.Message;
                return false;
            }
        }
    }
}
