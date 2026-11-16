namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Giao diện quy định tài khoản và quyền hạn của nhân viên.
    /// Lớp triển khai: <see cref="NhanVien"/>.
    /// </summary>
    public interface INhanVien
    {
        string MaNV { get; set; }
        string TenDangNhap { get; set; }
        string MatKhau { get; set; }
        string VaiTro { get; set; }

        /// <summary>Trả về true nếu nhân viên có quyền quản lý.</summary>
        bool KiemTraQuyenQuanLy();
    }
}
