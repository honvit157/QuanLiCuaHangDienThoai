# QuanLyCuaHangDienThoai — Bài tập lớn Lập trình trực quan (C# WinForms)

Hệ thống quản lý cửa hàng bán điện thoại, xây dựng theo **mô hình 3 tầng (GUI – BUS – DAL)**,
toàn bộ truy vấn dữ liệu chạy bằng **Stored Procedure** trên SQL Server.

Giảng viên hướng dẫn: **TS. Cao Thị Luyến**

Kho này là bản nộp của **Nhóm 4**, gộp hai phần việc:

- **Giao diện Dashboard mới của nhóm** (commit `f816963` trên nhánh `main` của kho nhóm): `Form10`
  dựng hoàn toàn bằng mã với bố cục 3 cột, cùng `Form1`–`Form9` giữ nguyên theo bộ `*.Designer.cs`
  của nhóm và thư mục `Images/`.
- **Bản chuẩn hóa 3 tầng** (commit `545d1af` trên nhánh `hoan`): chuyển toàn bộ câu SQL viết trực
  tiếp trong C# sang Stored Procedure, bổ sung đầy đủ DAL/BUS cho mọi danh mục, thêm `ThongKeBUS`
  cho Dashboard, thêm lớp trừu tượng, giao diện và lớp tiện ích dùng chung.
- **Phần mới của Đạt & An** (gộp từ commit `ef7b95b`): bộ **61 ảnh sản phẩm** (`DT*.jpg`, `PK*.jpg`,
  `SP*.jpg`, `TB*.jpg`) trong `Images/`, cột `TenAnh` để lưu và hiển thị ảnh theo từng mặt hàng, và
  **trang Khách hàng `Form12`** (xem điện thoại, giỏ hàng, đặt mua, hóa đơn của tôi, thanh toán) cùng
  tài khoản đăng ký/đăng nhập của Khách hàng trong bảng `tblKhachHang`. Phần mã đó đã được chuyển
  sang đúng 3 tầng và Stored Procedure, giữ nguyên các quy ước của bản chuẩn hóa.

---

## 1. Công nghệ sử dụng

| Thành phần | Công nghệ |
|---|---|
| Giao diện | WinForms (.NET 10, `net10.0-windows`) |
| Truy cập dữ liệu | ADO.NET + `Microsoft.Data.SqlClient` |
| Cơ sở dữ liệu | SQL Server (`.\\SQLEXPRESS`) |
| Xuất báo cáo | `ClosedXML` (Excel `.xlsx`) |
| Kiến trúc | 3 tầng: GUI (`GUI/Form*.cs`) → BUS → DAL → Stored Procedure |

## 2. Cấu trúc thư mục

```
├── GUI/                          # Tầng giao diện (WinForms, namespace ..._Nhóm_4.GUI)
│   ├── Form1..Form10, FormBaoCao, FormDangKy, Form12   # mỗi biểu mẫu: .cs + .Designer.cs (+ .resx)
├── Program.cs                    # Điểm vào của ứng dụng, mở Form9 đăng nhập
├── BUS/                          # Tầng nghiệp vụ (Business Logic)
│   ├── HangHoaBUS.cs  KhachHangBUS.cs  NhaCungCapBUS.cs  NhanVienBUS.cs
│   ├── DanhMucBUS.cs  HoaDonBanBUS.cs  HoaDonNhapBUS.cs
│   ├── BaoCaoBUS.cs   ThongKeBUS.cs        # ThongKeBUS phục vụ Dashboard Form10
├── DAL/                          # Tầng truy cập dữ liệu
│   ├── DatabaseAccess.cs         # Kết nối + chạy Stored Procedure
│   ├── HangHoaDAL.cs  KhachHangDAL.cs  NhaCungCapDAL.cs  NhanVienDAL.cs
│   ├── DanhMucDAL.cs  HoaDonBanDAL.cs  HoaDonNhapDAL.cs
│   ├── BaoCaoDAL.cs   ThongKeDAL.cs
├── DTO/                          # Lớp thực thể (Entity)
│   ├── Nguoi.cs (abstract)  SanPhamBase.cs (abstract)  ChungTuBase.cs (abstract)
│   ├── HangHoa.cs  KhachHang.cs  NhanVien.cs  NhaCungCap.cs
│   ├── ChiTietHoaDonBan.cs (+ ChiTietHoaDonNhap)  LoaiDanhMuc.cs
├── Interfaces/                   # 6 giao diện (interface)
│   ├── IHangHoa.cs  IHoaDon.cs  IHoaDonNhap.cs
│   ├── IKhachHang.cs  INhaCungCap.cs  INhanVien.cs
├── Utilities/AppHelpers.cs       # 16 class method / thành viên tiện ích dùng chung
├── Images/                       # Banner khuyến mãi, ảnh nổi bật và 61 ảnh sản phẩm (DT/PK/SP/TB)
├── InitDb.sql                    # Bước 1: tạo CSDL, bảng, dữ liệu mẫu
├── StoredProcedures.sql          # Bước 2: tạo toàn bộ thủ tục lưu trữ
├── QLCuaHangBanDienThoai.sql     # Tệp gộp sẵn cả 2 bước (chạy 1 lần là đủ)
├── BaoCaoDataSet.xsd             # Tập dữ liệu 3 báo cáo (dùng nếu chuyển sang Crystal Report)
├── BaoCao_BTL_QuanLyCuaHangDienThoai.docx   # Báo cáo Word
├── ThuyetTrinh_BTL_QuanLyCuaHangDienThoai.pptx / .pdf   # Slide và bản PDF của slide
├── tai_lieu/, make_doc.py, make_ppt.py      # Mã nguồn Python dựng báo cáo và slide
├── tools/                        # Kiểm tra tĩnh, gộp tệp SQL, xuất PDF từ slide
└── docs/                         # Hướng dẫn Crystal Report, kết quả kiểm tra tĩnh
```

**Vì sao namespace của biểu mẫu là `..._Nhóm_4.GUI`:** trong dự án SDK-style, tệp
`GUI/FormX.resx` được nhúng dưới tên `<RootNamespace>.GUI.FormX.resources`; namespace của `FormX`
cũng là `..._Nhóm_4.GUI` nên `ComponentResourceManager(typeof(FormX))` luôn tìm đúng tài nguyên và
không ném `MissingManifestResourceException` khi chạy trên Windows. Đổi tên thư mục hoặc
namespace của biểu mẫu thì phải đổi cả hai cho khớp (kiểm tra tự động: `tools/kiem_tra_tinh.py`,
mục `[GUI]`).

## 3. Cài đặt cơ sở dữ liệu

1. Mở SQL Server Management Studio.
2. Mở **một trong hai** cách sau:
   - Chạy `QLCuaHangBanDienThoai.sql` (đã gộp sẵn tạo CSDL + dữ liệu + thủ tục), hoặc
   - Chạy lần lượt `InitDb.sql` rồi `StoredProcedures.sql`.
3. Kiểm tra chuỗi kết nối trong `DAL/DatabaseAccess.cs` cho khớp máy của bạn:

```csharp
public static string ChuoiKetNoi { get; set; } =
    Environment.GetEnvironmentVariable("QLCHD_CONNECTION")
    ?? @"Server=.\SQLEXPRESS;Database=QLCuaHangBanDienThoai;Integrated Security=True;TrustServerCertificate=True;";
```

Có thể đổi server mà không sửa code bằng biến môi trường `QLCHD_CONNECTION`.

## 4. Tài khoản đăng nhập mẫu

| Tài khoản | Mật khẩu | Chức vụ |
|---|---|---|
| `an` | `123456` | Quản lý |
| `binh` | `123456` | Nhân viên |
| `hoa` | `123456` | Quản lý |
| `mai.nguyen` | `123456` | Khách hàng (KH001) |
| `nam.tran` | `123456` | Khách hàng (KH002) |

Hai loại tài khoản được kiểm tra lần lượt trên `Form9`: tài khoản trong `tblNhanVien` mở `Form10`
(Dashboard quản trị), tài khoản trong `tblKhachHang` mở `Form12` (trang Khách hàng).

Ngay trên `Form9` có liên kết **“Chưa có tài khoản? Đăng ký ngay”** để mở `FormDangKy`
(Họ tên, Số điện thoại, Tên đăng nhập, Mật khẩu, Nhập lại mật khẩu, Email (không bắt buộc),
**Vai trò**). Ô **Vai trò** là `ComboBox` chỉ cho chọn hai giá trị **Khách hàng** (mặc định) hoặc
**Nhân viên**.

- **Vai trò Khách hàng:** ghi thẳng hồ sơ + tài khoản vào `tblKhachHang` bằng `KhachHangBUS.DangKy`
  → `sp_DangKyKhachHang` (tự sinh mã `KH011`, `KH012`, ...), không tạo hồ sơ nhân viên. Tên đăng nhập
  kiểm tra trùng qua `sp_KiemTraTaiKhoanKhachHang`, email (nếu nhập) kiểm tra qua
  `sp_KiemTraEmailKhachHang`. Đăng nhập bằng tài khoản này sẽ mở **`Form12`**.
- **Vai trò Nhân viên:** ghi vào `tblNhanVien` bằng `sp_DangKyNhanVien` như trước; mã tài khoản do SQL
  tự sinh (`NV009`, `NV010`, ...), tên đăng nhập kiểm tra trùng qua `sp_KiemTraTenDangNhapTonTai`,
  trạng thái luôn là **Đang làm việc**.

Tham số `@VaiTro` của `sp_DangKyNhanVien` chỉ nhận `N'Nhân viên'` hoặc `N'Khách hàng'`; mọi giá trị
khác (kể cả `N'Quản lý'`) đều bị **ép về `N'Nhân viên'`**, nên không ai tự nâng quyền khi đăng ký.
`NhanVienBUS.ChuanHoaVaiTro` kiểm tra lại lần nữa ở tầng nghiệp vụ.

Đăng ký xong, tên đăng nhập được điền sẵn lại `Form9`.

### Ba mức phân quyền khi đăng nhập

| Mục trên Dashboard (`Form10`) | Quản lý | Nhân viên | Khách hàng |
|---|:--:|:--:|:--:|
| Tổng quan | ✓ (4 thẻ + biểu đồ doanh thu) | ✓ (4 thẻ + biểu đồ doanh thu) | ✓ (2 thẻ, không có doanh thu) |
| Điện thoại | ✓ thêm/sửa/xóa | ✓ thêm/sửa/xóa | ✓ **chỉ xem** (khóa Thêm/Sửa/Xóa, ô nhập chỉ đọc) |
| Tìm kiếm | ✓ | ✓ | ✓ |
| Danh mục | ✓ | ✓ | — |
| Nhân viên | ✓ | — | — |
| Khách hàng | ✓ | ✓ | — |
| Nhà cung cấp | ✓ | ✓ | — |
| Hóa đơn bán | ✓ **chỉ xem**: xem chi tiết hóa đơn đã bán + **In hóa đơn** (Excel), khóa/ẩn nút Thêm mới, Lưu, Hủy, Thêm hàng và ô nhập mặt hàng | ✓ **lập đơn đầy đủ** (tự điền nhân viên, thêm khách mới tại chỗ) | — |
| Hóa đơn nhập | ✓ | — | — |
| Báo cáo | ✓ | ✓ | — |

Menu của tài khoản **Khách hàng** chỉ còn nhóm *TỔNG QUAN* và *CỬA HÀNG* (Điện thoại, Tìm kiếm) cùng
nút *Đăng xuất*; các nhóm quản trị nội bộ không được dựng nên không để lại khoảng trống trên sidebar.
Dashboard của Khách hàng chỉ có 2 thẻ *Tổng sản phẩm* / *Khách hàng* thay cho 4 thẻ và biểu đồ doanh
thu, và `Form1` bị khóa toàn bộ nút Thêm/Sửa/Xóa cùng các ô nhập.

Dữ liệu mẫu đã có sẵn 10 tài khoản Khách hàng (`mai.nguyen`, `nam.tran`, ... — mật khẩu `123456`)
gắn với hồ sơ `KH001`–`KH010`. Tài khoản Khách hàng đăng nhập sẽ mở **`Form12`** (trang Khách hàng)
chứ không mở `Form10`; cột *Khách hàng* trong bảng trên chỉ còn áp dụng cho tài khoản cũ có
`ChucVu = N'Khách hàng'` trong `tblNhanVien`.

### Trang Khách hàng (`Form12`)

Mở khi đăng nhập bằng tài khoản trong `tblKhachHang`. Bốn mục ở sidebar trái:

- **Xem điện thoại:** thẻ sản phẩm ảnh + tên + hãng/màu/dung lượng + giá bán + tồn kho, tìm nhanh theo
  mã/tên/hãng, nút **THÊM VÀO GIỎ** (tự tắt khi hết hàng). Ảnh lấy theo cột `TenAnh` của `tblHang`
  trong thư mục `Images/`.
- **Giỏ hàng / Mua hàng:** sửa số lượng, xóa dòng, xem tổng tiền, **CHUYỂN SANG THANH TOÁN**.
- **Hóa đơn của tôi:** toàn bộ hóa đơn của khách kèm ngày lập, tổng tiền, phương thức và trạng thái
  thanh toán.
- **Thanh toán:** danh sách hóa đơn chưa thanh toán / chờ xác nhận chuyển khoản, chọn **Tiền mặt khi
  nhận hàng** hoặc **Chuyển khoản ngân hàng**, kèm khung thông tin chuyển khoản.

Đặt mua đi qua `HoaDonBanBUS.LuuHoaDon`: kiểm tra giá bán và tồn kho hiện tại của từng mặt hàng, rồi
lưu đầu hóa đơn + chi tiết + trừ tồn kho trong **một transaction** (`sp_ThemHoaDonBan`,
`sp_ThemChiTietHoaDonBan`, `sp_TruTonKho`). Hóa đơn mới có `TrangThaiThanhToan = N'Chưa thanh toán'`;
khi khách chọn phương thức, `sp_CapNhatPhuongThucThanhToan` cập nhật `PhuongThucThanhToan` và đưa trạng
thái thành `N'Chờ xác nhận chuyển khoản'` (chuyển khoản) hoặc giữ `N'Chưa thanh toán'` (tiền mặt).
Hóa đơn ghi nhận nhân viên lập là người đang đăng nhập, nếu không có thì `NV001` hoặc nhân viên đầu
tiên trong bảng.

### Luồng hóa đơn bán (`Form7`)

**Nhân viên — lập đơn:** khi mở form, `Form7` tự sinh mã `HDB_...` mới, điền ngày hôm nay và tự điền
**Mã nhân viên** + **Tên nhân viên** của người đang đăng nhập (`Form9.MaNVDangNhap` / `TenNVDangNhap`),
nên nhân viên chỉ cần chọn khách hàng và thêm mặt hàng. Vẫn tra cứu lại hóa đơn cũ bằng cách chọn mã
ở `cboMaHD` rồi bấm **⌕ Tìm**.

- **Khách hàng có sẵn:** `ComboBox` “Khách hàng” hiển thị dạng `MaKH - TenKH - SDT`; chọn một dòng thì
  tên, số điện thoại và địa chỉ tự điền và được khóa lại (sửa khách hàng thì dùng `Form3`).
- **Khách hàng mới ngay tại chỗ:** chọn dòng `-- Khách hàng mới (nhập trực tiếp) --` rồi gõ thẳng
  Tên khách, SĐT, Địa chỉ. Khi bấm **✓ Lưu hóa đơn**, tầng BUS kiểm tra tên không rỗng và SĐT đúng
  10 chữ số (`AppHelpers.KiemTraSoDienThoai`), rồi gọi thủ tục `sp_ThemKhachHangTuDong`: thủ tục tự
  sinh mã kế tiếp (`KH011`, `KH012`, ...), và **nếu số điện thoại đã có thì dùng lại mã khách cũ** thay
  vì tạo bản ghi trùng. Sau khi có `MaKH`, hóa đơn mới được lưu như bình thường.
- **Khách lẻ:** để trống cả tên và SĐT thì hóa đơn lưu với `MaKH = NULL` (không tạo hồ sơ khách hàng).

**Quản lý — chỉ xem:** `Form10` mở `Form7` bằng `new Form7(chiXem: true)`. Form nạp sẵn danh sách hóa
đơn đã bán và mở hóa đơn mới nhất; đổi lựa chọn ở `cboMaHD` là xem ngay chi tiết hóa đơn đó. Cụm lập
đơn bị ẩn/khóa (ô `CHỌN MẶT HÀNG` được ẩn hẳn và nhường chỗ cho bảng chi tiết), chỉ còn **Tìm** và
**▤ In hóa đơn** (xuất Excel).

Bố cục `Form7` đặt bảng **CHI TIẾT HÓA ĐƠN** ở hàng co giãn (`SizeType.Percent`) với chiều cao tối
thiểu 120px cho `dgvChiTiet`, dòng **Tổng tiền** có hàng riêng 40px nên không bị cắt, và các
`ComboBox` `cboMaHD`, `cboKhachHang`, `cboMaHang` được nới rộng trong lưới 4 cột của form.

Mật khẩu dùng chung ở mức đủ cho bài tập lớn (lưu thẳng trong `tblNhanVien` như dữ liệu mẫu),
chưa băm mật khẩu.

## 5. Quy ước tầng

- **GUI** chỉ đọc dữ liệu từ control, kiểm tra định dạng cơ bản, gọi BUS và hiển thị kết quả.
  Không có `SqlConnection`, `SqlCommand` hay chuỗi SQL nào trong các `GUI/Form*.cs`.
- **BUS** kiểm tra nghiệp vụ (trùng mã, số điện thoại, email, tồn kho, chặn xóa dữ liệu đã
  phát sinh hóa đơn), ghi nhật ký thao tác, rồi mới gọi DAL. Dashboard `Form10` cũng đi qua
  `ThongKeBUS` chứ không gọi thẳng tầng DAL.
- **DAL** chỉ gọi Stored Procedure qua `DatabaseAccess` với `CommandType.StoredProcedure`.
  Việc lưu hóa đơn (nhiều bước) được thực hiện trong một transaction tại `HoaDonBanDAL` /
  `HoaDonNhapDAL`.
- **SQL** chứa toàn bộ truy vấn: **88 thủ tục lưu trữ**, chia theo nhóm hàng hóa, danh mục,
  khách hàng, nhà cung cấp, nhân viên, hóa đơn bán, hóa đơn nhập, báo cáo và thống kê Dashboard.

## 6. Yêu cầu hướng đối tượng của học phần

| Yêu cầu | Hiện thực trong mã nguồn |
|---|---|
| Tối thiểu 5 giao diện | **6 interface**: `IHangHoa`, `IHoaDon`, `IHoaDonNhap`, `IKhachHang`, `INhaCungCap`, `INhanVien`; 6 lớp DTO triển khai |
| Tối thiểu 3 lớp kế thừa | **5 lớp kế thừa** trên **3 lớp trừu tượng**: `HangHoa : SanPhamBase`, `KhachHang`/`NhanVien : Nguoi`, `HoaDonBan`/`HoaDonNhap : ChungTuBase` |
| Đa hình | Các lớp dẫn xuất ghi đè phương thức ảo (`HienThi`, `KiemTraHopLe`, …) của lớp cơ sở |
| Class method tiện ích | **16 class method / thành viên** trong `Utilities/AppHelpers.cs`: 14 phương thức `public static` + thuộc tính `ThuMucAnh` + trường `ViVn` |

## 7. Chức năng chính

| Nhóm | Chức năng |
|---|---|
| Đăng nhập | Đăng nhập bằng tài khoản (`Form9`): nhân viên/quản lý mở `Form10`, khách hàng mở `Form12`; đăng ký tài khoản mới với vai trò **Khách hàng** hoặc **Nhân viên** (`FormDangKy`) |
| Khách hàng | Trang Khách hàng `Form12`: xem điện thoại kèm ảnh theo `TenAnh`, giỏ hàng, đặt mua, hóa đơn của tôi, chọn phương thức thanh toán |
| Tổng quan | Dashboard 3 cột: menu phân quyền theo 3 vai trò, thẻ thống kê, biểu đồ doanh thu 7 ngày, sidebar ảnh |
| Quản lý cửa hàng | Điện thoại (CRUD + ảnh + tìm nhanh), Danh mục (hãng/loại/màu/dung lượng), Nhân viên, Khách hàng, Nhà cung cấp |
| Giao dịch | Hóa đơn bán (tự điền nhân viên, chọn khách có sẵn hoặc thêm khách mới tại chỗ, trừ tồn kho, giảm giá, xuất Excel; Quản lý chỉ xem + in), Hóa đơn nhập (cộng tồn kho, cập nhật giá nhập, xuất Excel) |
| Thống kê | Báo cáo doanh thu theo tháng, tồn kho, top bán chạy; xuất Excel 3 sheet |

## 8. Báo cáo và điểm cần lưu ý về Crystal Report

Chức năng báo cáo hiện **xuất tệp Excel bằng thư viện `ClosedXML`**, hiển thị trên `DataGridView`
của `FormBaoCao`; **chưa dùng Crystal Report** như thang điểm của học phần yêu cầu, nên phần này
chỉ đạt mức điểm thấp hơn. Điều này được ghi trung thực ở phần hạn chế trong báo cáo Word, trong
slide thuyết trình và trong `docs/HUONG_DAN_CRYSTAL_REPORT.md` (hướng dẫn chuyển ba báo cáo sang
Crystal Report trên máy Windows có Visual Studio, dùng `BaoCaoDataSet.xsd` đã khai báo sẵn).

## 9. Tài liệu đi kèm

| Tệp | Nội dung |
|---|---|
| `BaoCao_BTL_QuanLyCuaHangDienThoai.docx` | Báo cáo Word theo mẫu của giảng viên: trang bìa để trống các ô cho nhóm/khóa/lớp/mã SV, mục lục tự động, Chương 1–3, kết luận, danh mục sách tham khảo |
| `ThuyetTrinh_BTL_QuanLyCuaHangDienThoai.pptx` | 15 slide thuyết trình, mỗi slide có ghi chú (Notes) để đọc khi trình bày |
| `ThuyetTrinh_BTL_QuanLyCuaHangDienThoai.pdf` | Bản PDF của bộ slide để xem trên điện thoại |

Mở báo cáo Word rồi nhấn `Ctrl+A` và `F9` để cập nhật mục lục và số trang.

Dựng lại tài liệu (cần Python 3 và các gói trong `requirements.txt`):

```
python tai_lieu/bieu_do.py       # vẽ lại 5 sơ đồ trong tai_lieu/hinh
python make_doc.py               # sinh lại báo cáo Word
python make_ppt.py               # sinh lại slide
python tools/xuat_slide_pdf.py   # sinh lại PDF từ slide
```

## 10. Kiểm tra tĩnh

```
python tools/kiem_tra_tinh.py
```

Công cụ không cần .NET hay SQL Server: nó kiểm tra cú pháp toàn bộ tệp `.cs` bằng tree-sitter C#,
kiểm tra trùng tên kiểu/thành viên, kiểm tra không còn câu SQL viết trực tiếp, đối chiếu tên và
tham số thủ tục giữa C# với hai tệp SQL, kiểm tra tính đồng bộ của tệp SQL gộp, kiểm tra tệp
`.csproj` và các tệp tài liệu. Kết quả lần chạy gần nhất lưu ở `docs/ket-qua-kiem-tra-tinh.txt`.

## 11. Ghi chú khi chạy trên máy khác

- Cần cài **.NET 10 SDK** và **SQL Server** (bản Express là đủ).
- Nếu tên instance khác `.\\SQLEXPRESS`, sửa `ChuoiKetNoi` hoặc đặt biến môi trường.
- Thư mục `Images/` được `.csproj` chép sang thư mục chạy khi build
  (`Images\**\*` → `CopyToOutputDirectory=PreserveNewest`), nên Dashboard, `Form1` và `Form12` hiển thị
  được banner khuyến mãi và 61 ảnh sản phẩm; ảnh người dùng thêm khi chạy sẽ được chép vào cùng
  thư mục này.
- Bản trong kho được đóng gói và kiểm tra trên Linux (không cài Visual Studio, SQL Server),
  nên **chưa build và chưa chạy thử giao diện** trên Windows; phần kiểm chứng chỉ là kiểm tra
  tĩnh như mục 10.
