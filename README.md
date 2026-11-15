# Quản lý cửa hàng điện thoại

Bài tập lớn học phần **Lập trình trực quan (C# WinForms)** - ứng dụng quản lý cửa hàng bán lẻ điện thoại,
xây dựng theo kiến trúc ba tầng **GUI - BUS - DAL** trên nền .NET 10, cơ sở dữ liệu **SQL Server**, toàn bộ
truy vấn nằm trong **70 thủ tục lưu trữ (Stored Procedure)**.

Giảng viên hướng dẫn: **TS. Cao Thị Luyến**

---

## 1. Chức năng chính

| Nhóm | Chức năng |
|------|-----------|
| Đăng nhập | Xác thực tài khoản, phân quyền Quản lý / Nhân viên |
| Danh mục | Hàng hóa, hãng sản xuất, loại hàng, màu sắc, dung lượng |
| Hồ sơ | Nhân viên, khách hàng, nhà cung cấp (kiểm tra SĐT, email) |
| Bán hàng | Lập hóa đơn, giảm giá, trừ tồn kho trong giao dịch, xuất Excel |
| Nhập hàng | Lập phiếu nhập, cộng tồn kho, cập nhật giá nhập, xuất Excel |
| Tìm kiếm | Theo tên, hãng, loại, màu và khoảng giá; xuất Excel |
| Báo cáo | Doanh thu theo tháng, tồn kho, top 10 bán chạy; xuất Excel 3 trang tính |

## 2. Cấu trúc thư mục

```
.
├── BUS/                         # Tầng nghiệp vụ (Business Logic)
│   ├── HangHoaBUS.cs  KhachHangBUS.cs  NhaCungCapBUS.cs  NhanVienBUS.cs
│   └── DanhMucBUS.cs  HoaDonBanBUS.cs  HoaDonNhapBUS.cs  BaoCaoBUS.cs
├── DAL/                         # Tầng truy cập dữ liệu (chỉ gọi stored procedure)
│   ├── DatabaseAccess.cs        # Kết nối + 4 hàm thực thi thủ tục dùng chung
│   ├── HangHoaDAL.cs  KhachHangDAL.cs  NhaCungCapDAL.cs  NhanVienDAL.cs
│   └── DanhMucDAL.cs  HoaDonBanDAL.cs  HoaDonNhapDAL.cs  BaoCaoDAL.cs
├── DTO/                         # Lớp đối tượng: Nguoi, SanPhamBase, ChungTuBase, HangHoa, ...
├── Interfaces/                  # 5 giao diện: IHangHoa, IKhachHang, INhanVien, INhaCungCap, IHoaDon
├── Utilities/AppHelpers.cs      # 14 phương thức tiện ích dùng chung
├── Form1..Form10, FormBaoCao    # 11 biểu mẫu WinForms (tệp .cs + .Designer.cs + .resx)
├── InitDb.sql                   # Bước 1: tạo CSDL, bảng, dữ liệu mẫu
├── StoredProcedures.sql         # Bước 2: 70 thủ tục lưu trữ
├── QLCuaHangBanDienThoai.sql    # Tệp gộp (sinh tự động) = InitDb.sql + StoredProcedures.sql
├── BaoCaoDataSet.xsd            # Tập dữ liệu cho báo cáo (chuẩn bị cho Crystal Report)
├── make_doc.py / make_ppt.py    # Sinh báo cáo Word và slide thuyết trình
├── tai_lieu/                    # Mã nguồn nội dung báo cáo, bộ dựng docx, sơ đồ (PNG)
├── docs/                        # Hướng dẫn chuyển báo cáo sang Crystal Report
└── tools/                       # Kiểm tra tĩnh, gộp kịch bản SQL
```

## 3. Yêu cầu môi trường

- Windows 10/11
- Visual Studio 2022 (hoặc `dotnet build` với .NET SDK 10) - dự án đích `net10.0-windows`
- SQL Server 2019 hoặc SQL Server Express (thực thể mặc định `.\SQLEXPRESS`)
- Python 3.10+ nếu muốn sinh lại tài liệu: `pip install -r requirements.txt`

## 4. Cài đặt và chạy

### Bước 1 - Tạo cơ sở dữ liệu

Mở SQL Server Management Studio và chạy **một trong hai** cách sau:

- Cách gọn: mở `QLCuaHangBanDienThoai.sql` và Execute (tạo CSDL + bảng + dữ liệu mẫu + 70 thủ tục).
- Cách tách bước: chạy `InitDb.sql` trước, sau đó chạy `StoredProcedures.sql`.

Lưu ý: `InitDb.sql` sẽ **xóa** cơ sở dữ liệu `QLCuaHangBanDienThoai` nếu đã tồn tại.

### Bước 2 - Cấu hình chuỗi kết nối

Mặc định trong `DAL/DatabaseAccess.cs`:

```csharp
Server=.\SQLEXPRESS;Database=QLCuaHangBanDienThoai;Integrated Security=True;TrustServerCertificate=True;
```

Nếu máy bạn dùng thực thể khác (ví dụ `.\SQLEXPRESS01`) hoặc xác thực SQL Server, **không cần sửa mã nguồn**:
đặt biến môi trường `QLCHD_CONNECTION` trước khi chạy.

```
setx QLCHD_CONNECTION "Server=.\SQLEXPRESS01;Database=QLCuaHangBanDienThoai;User Id=sa;Password=...;TrustServerCertificate=True;"
```

### Bước 3 - Build và chạy

Mở `QuanLyCuaHangDienThoai.slnx` bằng Visual Studio rồi nhấn F5, hoặc:

```
dotnet build
dotnet run
```

### Tài khoản dùng thử

| Tài khoản | Mật khẩu | Chức vụ |
|-----------|----------|---------|
| `an`    | `123456` | Quản lý |
| `binh`  | `123456` | Nhân viên |
| `hoa`   | `123456` | Quản lý |

## 5. Kiểm tra tĩnh

```
python tools/kiem_tra_tinh.py
```

Công cụ kiểm tra: số giao diện (≥ 5), số quan hệ kế thừa (≥ 3), số lớp triển khai giao diện (≥ 5),
số class method tiện ích (≥ 5), không còn câu SQL viết trực tiếp trong GUI/BUS/DTO/DAL, mọi tên thủ tục và
tên tham số trong DAL khớp với `StoredProcedures.sql`, 12 bảng trong `InitDb.sql` phủ hết bảng mà thủ tục
tham chiếu, tệp gộp SQL đồng bộ, độ dài ba chương của báo cáo, và các tên giảng viên / tên thành viên giả
trong tài liệu.

## 6. Sinh lại tài liệu

```
python tai_lieu/bieu_do.py     # vẽ lại 4 sơ đồ trong tai_lieu/hinh/
python make_doc.py             # BaoCao_BTL_QuanLyCuaHangDienThoai.docx
python make_ppt.py             # ThuyetTrinh_BTL_QuanLyCuaHangDienThoai.pptx
python tools/gop_sql.py        # gộp lại QLCuaHangBanDienThoai.sql từ hai tệp nguồn
```

Sau khi mở báo cáo bằng Word, bấm `Ctrl+A` rồi `F9` để Word dựng mục lục và số trang.

## 7. Những chỗ cần điền trước khi nộp

Trong báo cáo Word (trang bìa, bảng phân công) và slide, các giá trị sau còn để trong dấu ngoặc vuông:

- `Nhóm số`, `Khóa`, `Lớp`, `Mã sinh viên`
- Họ tên thành viên: `[Đặng Việt Hoàn]`, `[Họ và tên thành viên 2]`, `[Họ và tên thành viên 3]`, `[Họ và tên thành viên 4]`

Tên giảng viên đã ghi đúng: **TS. Cao Thị Luyến**.

## 8. Ghi chú về báo cáo

Yêu cầu của học phần là chức năng báo cáo dùng **Crystal Report** (nếu chỉ xuất Excel thì bị trừ 0,5 điểm).
Phiên bản này xuất báo cáo ra Excel bằng thư viện **ClosedXML** và đã chuẩn bị sẵn `BaoCaoDataSet.xsd`
cùng hướng dẫn chuyển đổi trong `docs/HUONG_DAN_CRYSTAL_REPORT.md`. Việc tạo tệp `.rpt` cần Visual Studio
trên Windows cùng SAP Crystal Reports nên chưa thực hiện được trong môi trường soạn mã nguồn.

## 9. Trạng thái kiểm thử

- Mã nguồn đã được kiểm tra **tĩnh** (cấu trúc tệp, tên lớp/phương thức, tên thủ tục, tên tham số, sự có mặt
  của SQL trong từng tầng) bằng `tools/kiem_tra_tinh.py`.
- Chưa **biên dịch và chạy thử** trong môi trường soạn mã (Linux, không có .NET SDK và SQL Server). Cần mở
  bằng Visual Studio trên Windows, chạy các kịch bản trong bảng 3.6 của báo cáo để xác nhận trước khi nộp.
