# Quản lý cửa hàng bán điện thoại (WinForms + SQL Server)

Bài tập lớn học phần **Lập trình trực quan** — giảng viên hướng dẫn: **TS. Cao Thị Luyến**.

Dự án kế thừa nguyên giao diện, tính năng và cách bố trí biểu mẫu của nhóm (12 biểu mẫu `Form1` – `Form12`
cộng `FormBaoCao`), đồng thời chuẩn hóa lại phần mã nguồn theo yêu cầu của học phần:

* kiến trúc **ba tầng** GUI – BUS – DAL rõ ràng;
* **100% truy vấn nằm trong thủ tục lưu trữ** (Stored Procedure), không còn câu SQL nào viết trong C#;
* đầy đủ yếu tố **lập trình hướng đối tượng**: lớp trừu tượng, kế thừa, giao diện, đa hình, kết tập;
* mọi biểu mẫu **mở được màn `[Design]`** của Visual Studio (mã dựng giao diện đã tách khỏi
  `InitializeComponent()` sang phương thức `TaoGiaoDien()`);
* có công cụ **kiểm tra tĩnh** để chứng minh các điều kiện trên.

## 1. Cấu trúc thư mục

```
├── Form1.cs … Form12.cs, FormBaoCao.cs      # 13 biểu mẫu (giữ nguyên như bản của nhóm)
├── Form1.Designer.cs …                      # khai báo control + InitializeComponent() chuẩn
├── BUS/                                     # tầng nghiệp vụ (9 lớp)
│   ├── DanhMucBUS.cs      HangHoaBUS.cs     HoaDonBanBUS.cs
│   ├── HoaDonNhapBUS.cs   KhachHangBUS.cs   NhaCungCapBUS.cs
│   └── NhanVienBUS.cs     ThongKeBUS.cs     BaoCaoBUS.cs
├── DAL/                                     # tầng truy cập dữ liệu (11 lớp)
│   ├── DatabaseAccess.cs  # mở kết nối, gọi thủ tục (không có câu SQL)
│   ├── ChiTietXml.cs      # đóng gói chi tiết hóa đơn thành XML cho thủ tục
│   ├── DanhMucDAL.cs      HangHoaDAL.cs     NhanVienDAL.cs
│   ├── KhachHangDAL.cs    NhaCungCapDAL.cs  HoaDonBanDAL.cs
│   └── HoaDonNhapDAL.cs   ThongKeDAL.cs     BaoCaoDAL.cs
├── DTO/                                     # lớp thực thể
│   ├── Nguoi.cs (abstract) → KhachHang, NhanVien
│   ├── SanPhamBase.cs (abstract) → HangHoa
│   ├── ChungTuBase.cs (abstract) → HoaDonBan, HoaDonNhap
│   ├── ChiTietHoaDonBan.cs, ChiTietHoaDonNhap.cs, LoaiDanhMuc.cs
├── Interfaces/                              # 6 giao diện
│   └── IHangHoa, IHoaDon, IHoaDonNhap, IKhachHang, INhaCungCap, INhanVien
├── Utilities/AppHelpers.cs                  # 14 class method dùng chung
├── Images/                                  # 61 ảnh sản phẩm
├── InitDb.sql                               # bước 1: tạo CSDL, 12 bảng và dữ liệu mẫu
├── StoredProcedures.sql                     # bước 2: 81 thủ tục lưu trữ
├── QLCuaHangBanDienThoai.sql                # bản gộp của hai tệp trên (chạy một lần là đủ)
├── tools/                                   # công cụ kiểm tra tĩnh và sinh tài liệu
└── BaoCao_BTL_*.docx, ThuyetTrinh_BTL_*.pptx/.pdf
```

## 2. Cài đặt cơ sở dữ liệu

1. Mở **SQL Server Management Studio**, kết nối tới `.\SQLEXPRESS` (hoặc instance tương ứng).
2. Chạy `QLCuaHangBanDienThoai.sql` — tệp này xóa và tạo lại cơ sở dữ liệu `QLCuaHangBanDienThoai`
   cùng 12 bảng, dữ liệu mẫu và 81 thủ tục lưu trữ.
   (Nếu muốn chạy tách hai bước: `InitDb.sql` rồi `StoredProcedures.sql`.)
3. Chuỗi kết nối nằm trong `DAL/DatabaseAccess.cs`; đổi `Server=...` nếu máy dùng tên instance khác.

## 3. Tài khoản thử

| Vai trò | Tài khoản | Mật khẩu | Ghi chú |
|---|---|---|---|
| Quản lý | `an` | `123456` | thấy đầy đủ menu, kể cả Nhân viên |
| Nhân viên | `binh` | `123456` | ẩn mục Nhân viên và nút Xóa nhân viên |
| Khách hàng | `mai.nguyen` | `123456` | mở Form12 để đặt hàng và thanh toán |

Khách hàng mới bấm **Đăng ký** ở màn hình đăng nhập (Form11); mã khách hàng do thủ tục
`sp_DangKyKhachHang` tự sinh.

## 4. Kiểm tra tĩnh

```bash
python tools/kiem_tra_tinh.py     # 0 lỗi cú pháp, 0 SQL trong C#, 0 vi phạm [Design]…
python tools/tach_designer.py     # (đã chạy) tách mã dựng giao diện khỏi InitializeComponent()
python tools/gop_sql.py           # sinh lại QLCuaHangBanDienThoai.sql từ InitDb + StoredProcedures
```

`tools/kiem_tra_tinh.py` đối chiếu: cú pháp C# (tree-sitter), trùng tên CS0101/CS0102, lời gọi BUS/DAL,
quan hệ kế thừa – giao diện, sự tồn tại của thủ tục mà DAL gọi, tên tham số, số bảng, sự đồng bộ giữa
ba tệp SQL và điều kiện mở màn `[Design]`.

## 5. Tài liệu

```bash
python make_doc.py                # sinh báo cáo Word
python make_ppt.py                # sinh slide thuyết trình (16 slide dạng card + KPI)
python tools/xuat_slide_pdf.py    # xuất slide ra PDF từ mô hình tai_lieu/slide_model.json
```
