using System;
using System.Collections.Generic;
using System.Data;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng nghiệp vụ cho mặt hàng: kiểm tra dữ liệu rồi mới gọi xuống DAL.
    /// </summary>
    public class HangHoaBUS
    {
        private readonly HangHoaDAL dal = new HangHoaDAL();

        public DataTable LayDanhSach()
        {
            return dal.LayTatCa();
        }

        public List<string> LayDanhSachMa()
        {
            var ds = new List<string>();
            DataTable dt = dal.LayDanhSachMa();
            foreach (DataRow r in dt.Rows) ds.Add(r["MaHang"].ToString() ?? "");
            return ds;
        }

        /// <summary>Lấy một mặt hàng theo mã (dùng cho Form hóa đơn bán).</summary>
        public HangHoa? LayTheoMa(string maHang)
        {
            if (string.IsNullOrWhiteSpace(maHang)) return null;

            DataTable dt = dal.LayTheoMa(maHang.Trim());
            if (dt.Rows.Count == 0) return null;

            DataRow r = dt.Rows[0];
            return new HangHoa
            {
                MaHang = r["MaHang"].ToString() ?? "",
                TenHang = r["TenHang"].ToString() ?? "",
                GiaNhap = r["DonGiaNhap"] == DBNull.Value ? 0 : Convert.ToDecimal(r["DonGiaNhap"]),
                GiaBan = r["DonGiaBan"] == DBNull.Value ? 0 : Convert.ToDecimal(r["DonGiaBan"]),
                SoLuongTon = r["SoLuongTon"] == DBNull.Value ? 0 : Convert.ToInt32(r["SoLuongTon"]),
                TenAnh = dt.Columns.Contains("TenAnh") && r["TenAnh"] != DBNull.Value
                    ? r["TenAnh"].ToString()
                    : ""
            };
        }

        /// <summary>Kiểm tra dữ liệu chung cho cả thêm và sửa.</summary>
        private static bool KiemTra(HangHoa h, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(h.MaHang))
            {
                error = "Mã hàng không được để trống!";
                return false;
            }

            if (h.MaHang.Trim().Length > 20)
            {
                error = "Mã hàng không được vượt quá 20 ký tự!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(h.TenHang))
            {
                error = "Tên hàng không được để trống!";
                return false;
            }

            if (h.GiaNhap < 0 || h.GiaBan < 0)
            {
                error = "Giá nhập và giá bán phải là số không âm!";
                return false;
            }

            if (h.SoLuongTon < 0)
            {
                error = "Số lượng tồn phải là số nguyên không âm!";
                return false;
            }

            return true;
        }

        public bool Them(HangHoa h, out string error)
        {
            if (!KiemTra(h, out error)) return false;

            try
            {
                if (dal.KiemTraTonTai(h.MaHang.Trim()))
                {
                    error = $"Mã hàng '{h.MaHang}' đã tồn tại trong hệ thống!";
                    return false;
                }

                if (dal.Them(h) > 0)
                {
                    AppHelpers.GhiLog($"Thêm hàng hóa {h.MaHang} - {h.TenHang}");
                    return true;
                }

                error = "Không thể thêm mặt hàng. Vui lòng thử lại!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi thêm mặt hàng: " + ex.Message;
                return false;
            }
        }

        public bool Sua(HangHoa h, out string error)
        {
            if (!KiemTra(h, out error)) return false;

            try
            {
                if (!dal.KiemTraTonTai(h.MaHang.Trim()))
                {
                    error = "Mặt hàng không còn tồn tại trong cơ sở dữ liệu!";
                    return false;
                }

                if (dal.Sua(h) > 0)
                {
                    AppHelpers.GhiLog($"Cập nhật hàng hóa {h.MaHang}");
                    return true;
                }

                error = "Không có dữ liệu nào được cập nhật!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi cập nhật mặt hàng: " + ex.Message;
                return false;
            }
        }

        public bool Xoa(string maHang, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(maHang))
            {
                error = "Chưa chọn mặt hàng cần xóa!";
                return false;
            }

            try
            {
                if (dal.Xoa(maHang.Trim()) > 0)
                {
                    AppHelpers.GhiLog($"Xóa hàng hóa {maHang}");
                    return true;
                }

                error = "Không tìm thấy mặt hàng cần xóa!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Không thể xóa mặt hàng (có thể mặt hàng đã phát sinh hóa đơn): " + ex.Message;
                return false;
            }
        }

        /// <summary>Tìm kiếm đa tiêu chí; tham số null nghĩa là không lọc theo tiêu chí đó.</summary>
        public DataTable TimKiem(string? ten, string? hang, string? loai, string? mau,
                                 decimal? giaTu, decimal? giaDen)
        {
            return dal.TimKiem(
                AppHelpers.ChuanHoaChuoi(ten),
                hang,
                loai,
                mau,
                giaTu,
                giaDen);
        }
    }
}
