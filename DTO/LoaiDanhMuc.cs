namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Bốn danh mục tra cứu của hệ thống. Tầng DAL/BUS dùng giá trị này để chọn
    /// đúng nhóm thủ tục lưu trữ tương ứng với từng bảng danh mục.
    /// </summary>
    public enum LoaiDanhMuc
    {
        HangSanXuat = 1,
        LoaiHang = 2,
        MauSac = 3,
        DungLuong = 4
    }
}
