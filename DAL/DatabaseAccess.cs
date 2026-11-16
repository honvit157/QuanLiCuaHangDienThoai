using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Lớp tiện ích kết nối SQL Server của tầng DAL.
    /// Toàn bộ truy vấn của ứng dụng đều được thực thi ở chế độ
    /// <see cref="CommandType.StoredProcedure"/> - không có câu lệnh SQL viết trực tiếp trong C#.
    /// </summary>
    public static class DatabaseAccess
    {
        /// <summary>
        /// Chuỗi kết nối mặc định tới SQL Server cài trên máy.
        /// Có thể đổi bằng biến môi trường QLCHD_CONNECTION khi chạy trên máy khác.
        /// </summary>
        public static string ChuoiKetNoi { get; set; } =
            Environment.GetEnvironmentVariable("QLCHD_CONNECTION")
            ?? @"Server=.\SQLEXPRESS;Database=QLCuaHangBanDienThoai;Integrated Security=True;TrustServerCertificate=True;";

        /// <summary>Mở một kết nối mới tới cơ sở dữ liệu.</summary>
        public static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(ChuoiKetNoi);
        }

        /// <summary>Tạo tham số, tự chuyển giá trị null thành DBNull.</summary>
        public static SqlParameter ThamSo(string ten, object? giaTri)
        {
            return new SqlParameter(ten, giaTri ?? DBNull.Value);
        }

        // ------------------------------------------------------------------
        // Các hàm dùng kết nối tự mở/đóng
        // ------------------------------------------------------------------

        /// <summary>Chạy thủ tục trả về tập bản ghi (SELECT) và đổ vào DataTable.</summary>
        public static DataTable DocBangProc(string tenThuTuc, SqlParameter[]? thamSo = null)
        {
            using SqlConnection conn = TaoKetNoi();
            return DocBangProc(conn, null, tenThuTuc, thamSo);
        }

        /// <summary>Chạy thủ tục thêm/sửa/xóa, trả về số dòng bị tác động.</summary>
        public static int ThucThiProc(string tenThuTuc, SqlParameter[]? thamSo = null)
        {
            using SqlConnection conn = TaoKetNoi();
            return ThucThiProc(conn, null, tenThuTuc, thamSo);
        }

        /// <summary>Chạy thủ tục trả về một giá trị duy nhất (COUNT, SUM, MAX...).</summary>
        public static object? GiaTriProc(string tenThuTuc, SqlParameter[]? thamSo = null)
        {
            using SqlConnection conn = TaoKetNoi();
            return GiaTriProc(conn, null, tenThuTuc, thamSo);
        }

        /// <summary>Đếm số bản ghi trả về của thủ tục kiểm tra tồn tại.</summary>
        public static int DemBanGhi(string tenThuTuc, SqlParameter[]? thamSo = null)
        {
            object? kq = GiaTriProc(tenThuTuc, thamSo);
            return kq == null || kq == DBNull.Value ? 0 : Convert.ToInt32(kq);
        }

        // ------------------------------------------------------------------
        // Các hàm dùng chung kết nối (phục vụ giao dịch nhiều bước)
        // ------------------------------------------------------------------

        /// <summary>Chạy thủ tục SELECT trên một kết nối có sẵn (có thể kèm transaction).</summary>
        public static DataTable DocBangProc(SqlConnection conn, SqlTransaction? tran,
                                            string tenThuTuc, SqlParameter[]? thamSo = null)
        {
            var dt = new DataTable();
            using SqlCommand cmd = TaoLenh(conn, tran, tenThuTuc, thamSo);
            using SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        /// <summary>Chạy thủ tục thêm/sửa/xóa trên một kết nối có sẵn.</summary>
        public static int ThucThiProc(SqlConnection conn, SqlTransaction? tran,
                                      string tenThuTuc, SqlParameter[]? thamSo = null)
        {
            if (conn.State != ConnectionState.Open) conn.Open();
            using SqlCommand cmd = TaoLenh(conn, tran, tenThuTuc, thamSo);
            return cmd.ExecuteNonQuery();
        }

        /// <summary>Chạy thủ tục trả về một giá trị trên một kết nối có sẵn.</summary>
        public static object? GiaTriProc(SqlConnection conn, SqlTransaction? tran,
                                         string tenThuTuc, SqlParameter[]? thamSo = null)
        {
            if (conn.State != ConnectionState.Open) conn.Open();
            using SqlCommand cmd = TaoLenh(conn, tran, tenThuTuc, thamSo);
            return cmd.ExecuteScalar();
        }

        private static SqlCommand TaoLenh(SqlConnection conn, SqlTransaction? tran,
                                          string tenThuTuc, SqlParameter[]? thamSo)
        {
            var cmd = new SqlCommand(tenThuTuc, conn)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 60
            };

            if (tran != null) cmd.Transaction = tran;

            if (thamSo != null && thamSo.Length > 0)
            {
                cmd.Parameters.AddRange(thamSo);
            }

            return cmd;
        }
    }
}
