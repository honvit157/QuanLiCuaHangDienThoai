"""Gộp InitDb.sql và StoredProcedures.sql thành một tệp cài đặt duy nhất
QLCuaHangBanDienThoai.sql, để hai tệp nguồn luôn đồng bộ với nhau.

Cách dùng:  python tools/gop_sql.py
"""
import os

GOC = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))

with open(os.path.join(GOC, "InitDb.sql"), encoding="utf-8-sig") as f:
    init_db = f.read()

with open(os.path.join(GOC, "StoredProcedures.sql"), encoding="utf-8-sig") as f:
    stored = f.read()

# Bỏ phần "USE ..." trùng lặp ở đầu tệp thủ tục vì tệp gộp đã tạo CSDL ở trên.
stored = stored.replace("USE [QLCuaHangBanDienThoai];\nGO\n", "", 1)

noi_dung = (
    "-- ============================================================================\n"
    "--  HỆ THỐNG QUẢN LÝ CỬA HÀNG ĐIỆN THOẠI - TỆP CÀI ĐẶT DUY NHẤT\n"
    "--  Học phần: Lập trình trực quan (C# WinForms) - Bài tập lớn\n"
    "--  Giảng viên hướng dẫn: TS. Cao Thị Luyến\n"
    "--  ---------------------------------------------------------------------------\n"
    "--  Tệp này được sinh tự động từ InitDb.sql + StoredProcedures.sql\n"
    "--  bằng công cụ tools/gop_sql.py. Không sửa trực tiếp tệp này.\n"
    "-- ============================================================================\n\n"
    + init_db.strip()
    + "\n\n"
    + "-- ============================================================================\n"
    + "--  PHẦN THỦ TỤC LƯU TRỮ (từ StoredProcedures.sql)\n"
    + "-- ============================================================================\n\n"
    + stored.strip()
    + "\n"
)

with open(os.path.join(GOC, "QLCuaHangBanDienThoai.sql"), "w", encoding="utf-8") as f:
    f.write(noi_dung)

print("Đã sinh QLCuaHangBanDienThoai.sql:", len(noi_dung), "ký tự")
