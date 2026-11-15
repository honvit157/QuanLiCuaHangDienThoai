namespace QuanLyCuaHangDienThoai
{
    /// <summary>
    /// Bốn danh mục tra cứu của hệ thống. Dùng để tầng DAL/BUS chọn đúng
    /// nhóm thủ tục lưu trữ (Stored Procedure) tương ứng.
    /// </summary>
    public enum LoaiDanhMuc
    {
        HangSanXuat = 1,
        LoaiHang = 2,
        MauSac = 3,
        DungLuong = 4
    }
}
