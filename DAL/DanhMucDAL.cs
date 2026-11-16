using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Tầng truy cập dữ liệu cho bốn bảng danh mục tra cứu:
    /// tblHangSX, tblLoai, tblMau, tblDungLuong.
    /// Mỗi danh mục có bộ thủ tục lưu trữ riêng, được chọn theo <see cref="LoaiDanhMuc"/>.
    /// </summary>
    public class DanhMucDAL
    {
        /// <summary>Ghép tên thủ tục lưu trữ theo danh mục và hành động.</summary>
        private static string TenThuTuc(LoaiDanhMuc loai, string hanhDong)
        {
            string duoi = loai switch
            {
                LoaiDanhMuc.HangSanXuat => "HangSX",
                LoaiDanhMuc.LoaiHang => "Loai",
                LoaiDanhMuc.MauSac => "Mau",
                LoaiDanhMuc.DungLuong => "DungLuong",
                _ => throw new ArgumentOutOfRangeException(nameof(loai))
            };

            return hanhDong == "KiemTraTonTai"
                ? $"sp_KiemTra{duoi}TonTai"
                : $"sp_{hanhDong}{duoi}";
        }

        /// <summary>Lấy toàn bộ danh mục (mã, tên).</summary>
        /// <param name="theoTen">true: sắp xếp theo tên; false: theo mã.</param>
        public DataTable LayTatCa(LoaiDanhMuc loai, bool theoTen = false)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@TheoTen", theoTen)
            };

            return DatabaseAccess.DocBangProc(TenThuTuc(loai, "LayDanhSach"), pars);
        }

        public int Them(LoaiDanhMuc loai, string ma, string ten)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@Ma", ma),
                DatabaseAccess.ThamSo("@Ten", ten)
            };

            return DatabaseAccess.ThucThiProc(TenThuTuc(loai, "Them"), pars);
        }

        public int Sua(LoaiDanhMuc loai, string ma, string ten)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@Ma", ma),
                DatabaseAccess.ThamSo("@Ten", ten)
            };

            return DatabaseAccess.ThucThiProc(TenThuTuc(loai, "CapNhat"), pars);
        }

        public int Xoa(LoaiDanhMuc loai, string ma)
        {
            SqlParameter[] pars =
            {
                DatabaseAccess.ThamSo("@Ma", ma)
            };

            return DatabaseAccess.ThucThiProc(TenThuTuc(loai, "Xoa"), pars);
        }

        public bool KiemTraTonTai(LoaiDanhMuc loai, string ma)
        {
            return DatabaseAccess.DemBanGhi(TenThuTuc(loai, "KiemTraTonTai"),
                new[] { DatabaseAccess.ThamSo("@Ma", ma) }) > 0;
        }
    }
}
