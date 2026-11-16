using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Lớp truy cập dữ liệu dùng chung (Data Access helper).
    /// Toàn bộ thao tác với SQL Server đều đi qua Stored Procedure:
    /// lớp này chỉ mở kết nối, gắn tham số và gọi thủ tục — không chứa câu lệnh SQL nào.
    /// </summary>
    public static class DatabaseAccess
    {
        /// <summary>Chuỗi kết nối tới SQL Server cục bộ.</summary>
        public static string ChuoiKetNoi =
            @"Server=.\SQLEXPRESS;Database=QLCuaHangBanDienThoai;Integrated Security=True;TrustServerCertificate=True;";

        /// <summary>Mở một kết nối mới tới cơ sở dữ liệu.</summary>
        public static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(ChuoiKetNoi);
        }

        /// <summary>Tạo tham số, tự chuyển giá trị rỗng thành NULL.</summary>
        public static SqlParameter ThamSo(string ten, object? giaTri)
        {
            return new SqlParameter(ten, giaTri ?? DBNull.Value);
        }

        /// <summary>Tạo tham số đầu ra kiểu số nguyên (dùng cho mã tự sinh).</summary>
        public static SqlParameter ThamSoRa(string ten, SqlDbType kieu, int doDai = 0)
        {
            SqlParameter p = new SqlParameter(ten, kieu)
            {
                Direction = ParameterDirection.Output
            };

            if (doDai > 0)
                p.Size = doDai;

            return p;
        }

        /// <summary>Lấy về một bảng dữ liệu từ thủ tục lưu trữ.</summary>
        public static DataTable DocBangProc(string tenThuTuc, SqlParameter[]? thamSo = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(tenThuTuc, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (thamSo != null && thamSo.Length > 0)
                    cmd.Parameters.AddRange(thamSo);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        /// <summary>Thực thi thủ tục và trả về số dòng bị tác động.</summary>
        public static int ThucThiProc(string tenThuTuc, SqlParameter[]? thamSo = null)
        {
            using (SqlConnection conn = TaoKetNoi())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(tenThuTuc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (thamSo != null && thamSo.Length > 0)
                        cmd.Parameters.AddRange(thamSo);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Thực thi thủ tục trả về mã RETURN (quy ước: số dòng đã xử lý).
        /// Dùng cho các thủ tục thêm/sửa/xóa hàng hóa.
        /// </summary>
        public static int ThucThiProcLayMaTraVe(string tenThuTuc, SqlParameter[]? thamSo = null)
        {
            using (SqlConnection conn = TaoKetNoi())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(tenThuTuc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (thamSo != null && thamSo.Length > 0)
                        cmd.Parameters.AddRange(thamSo);

                    SqlParameter maTraVe = new SqlParameter
                    {
                        Direction = ParameterDirection.ReturnValue,
                        SqlDbType = SqlDbType.Int
                    };

                    cmd.Parameters.Add(maTraVe);
                    cmd.ExecuteNonQuery();

                    return Convert.ToInt32(maTraVe.Value);
                }
            }
        }

        /// <summary>Đếm số bản ghi mà thủ tục trả về (thủ tục dùng SELECT COUNT(*)).</summary>
        public static int DemBanGhi(string tenThuTuc, SqlParameter[]? thamSo = null)
        {
            object? ketQua = LayGiaTri(tenThuTuc, thamSo);
            return ketQua == null || ketQua == DBNull.Value
                ? 0
                : Convert.ToInt32(ketQua);
        }

        /// <summary>Lấy một giá trị đơn (COUNT, SUM...) từ thủ tục lưu trữ.</summary>
        public static object? LayGiaTri(string tenThuTuc, SqlParameter[]? thamSo = null)
        {
            using (SqlConnection conn = TaoKetNoi())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(tenThuTuc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (thamSo != null && thamSo.Length > 0)
                        cmd.Parameters.AddRange(thamSo);

                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>Lấy số thực (DECIMAL) từ thủ tục lưu trữ, mặc định 0 nếu rỗng.</summary>
        public static decimal LaySoThuc(string tenThuTuc, SqlParameter[]? thamSo = null)
        {
            object? ketQua = LayGiaTri(tenThuTuc, thamSo);
            return ketQua == null || ketQua == DBNull.Value
                ? 0m
                : Convert.ToDecimal(ketQua);
        }
    }
}
