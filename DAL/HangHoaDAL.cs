using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng truy cập dữ liệu cho bảng hàng hóa (tblHang).
    /// Mọi thao tác đều gọi thủ tục lưu trữ trong StoredProcedures.sql.
    /// </summary>
    public class HangHoaDAL
    {
        /// <summary>Lấy danh sách hàng kèm tên hãng, loại, màu, dung lượng.</summary>
        public DataTable LayTatCa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachHang");
        }

        /// <summary>Thêm một mặt hàng mới; trả về số dòng đã thêm.</summary>
        public int Them(HangHoa h)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@MaHang", h.MaHang),
                DatabaseAccess.ThamSo("@TenHang", h.TenHang),
                DatabaseAccess.ThamSo("@MaHangSX", h.MaHangSX),
                DatabaseAccess.ThamSo("@MaLoai", h.MaLoai),
                DatabaseAccess.ThamSo("@MaMau", h.MaMau),
                DatabaseAccess.ThamSo("@MaDungLuong", h.MaDungLuong),
                DatabaseAccess.ThamSo("@DonGiaNhap", h.GiaNhap),
                DatabaseAccess.ThamSo("@DonGiaBan", h.GiaBan),
                DatabaseAccess.ThamSo("@SoLuongTon", h.SoLuongTon),
                DatabaseAccess.ThamSo("@TenAnh", string.IsNullOrWhiteSpace(h.TenAnh) ? null : h.TenAnh)
            };

            return DatabaseAccess.ThucThiProcLayMaTraVe("sp_ThemHang", pars);
        }

        /// <summary>Cập nhật thông tin mặt hàng; trả về số dòng đã sửa.</summary>
        public int Sua(HangHoa h)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@MaHang", h.MaHang),
                DatabaseAccess.ThamSo("@TenHang", h.TenHang),
                DatabaseAccess.ThamSo("@MaHangSX", h.MaHangSX),
                DatabaseAccess.ThamSo("@MaLoai", h.MaLoai),
                DatabaseAccess.ThamSo("@MaMau", h.MaMau),
                DatabaseAccess.ThamSo("@MaDungLuong", h.MaDungLuong),
                DatabaseAccess.ThamSo("@DonGiaNhap", h.GiaNhap),
                DatabaseAccess.ThamSo("@DonGiaBan", h.GiaBan),
                DatabaseAccess.ThamSo("@SoLuongTon", h.SoLuongTon),
                DatabaseAccess.ThamSo("@TenAnh", string.IsNullOrWhiteSpace(h.TenAnh) ? null : h.TenAnh)
            };

            return DatabaseAccess.ThucThiProcLayMaTraVe("sp_CapNhatHang", pars);
        }

        /// <summary>Xóa mặt hàng; trả về số dòng đã xóa.</summary>
        public int Xoa(string maHang)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@MaHang", maHang)
            };

            return DatabaseAccess.ThucThiProcLayMaTraVe("sp_XoaHang", pars);
        }

        /// <summary>Tìm kiếm hàng hóa theo nhiều tiêu chí (tham số rỗng được bỏ qua).</summary>
        public DataTable TimKiem(string? ten, string? hang, string? loai,
                                 string? mau, decimal? giaTu, decimal? giaDen)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@TenHang", string.IsNullOrWhiteSpace(ten) ? null : ten),
                DatabaseAccess.ThamSo("@MaHangSX", string.IsNullOrWhiteSpace(hang) ? null : hang),
                DatabaseAccess.ThamSo("@MaLoai", string.IsNullOrWhiteSpace(loai) ? null : loai),
                DatabaseAccess.ThamSo("@MaMau", string.IsNullOrWhiteSpace(mau) ? null : mau),
                DatabaseAccess.ThamSo("@GiaTu", giaTu.HasValue ? (object)giaTu.Value : null),
                DatabaseAccess.ThamSo("@GiaDen", giaDen.HasValue ? (object)giaDen.Value : null)
            };

            return DatabaseAccess.DocBangProc("sp_TimKiemHang", pars);
        }

        public bool KiemTraTonTai(string maHang)
        {
            return DatabaseAccess.DemBanGhi("sp_KiemTraHangTonTai",
                new[] { DatabaseAccess.ThamSo("@Ma", maHang) }) > 0;
        }

        /// <summary>Danh sách mã hàng để nạp ComboBox / AutoComplete.</summary>
        public DataTable LayDanhSachMa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachMaHang");
        }

        /// <summary>Thông tin một mặt hàng (tên, giá nhập, giá bán, tồn kho).</summary>
        public DataTable LayThongTin(string maHang)
        {
            return DatabaseAccess.DocBangProc("sp_LayThongTinHang",
                new[] { DatabaseAccess.ThamSo("@MaHang", maHang) });
        }
    }
}
