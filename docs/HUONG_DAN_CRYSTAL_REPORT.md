# Hướng dẫn chuyển chức năng báo cáo sang Crystal Report

Thang điểm bài tập lớn yêu cầu chức năng báo cáo dùng **Crystal Report**; nếu chỉ xuất tệp Excel thì bị trừ
0,5 điểm. Phiên bản hiện tại đã có đủ dữ liệu và giao diện cho ba báo cáo (doanh thu, tồn kho, top bán chạy)
nhưng phần hiển thị dùng `DataGridView` và xuất Excel bằng `ClosedXML`.

Tài liệu này mô tả các bước chuyển ba báo cáo đó sang Crystal Report. **Các bước dưới đây phải thực hiện trên
Windows có Visual Studio**, vì công cụ thiết kế `.rpt` và thư viện `CrystalDecisions.*` không chạy trên Linux.

---

## 1. Cài đặt công cụ

1. Cài **SAP Crystal Reports for Visual Studio** (bản dành cho VS 2022, gói `CRforVS`), chọn tích hợp vào
   Visual Studio trong quá trình cài.
2. Mở dự án `QuanLyCuaHangDienThoai.csproj`, thêm tham chiếu tới ba thư viện:
   - `CrystalDecisions.CrystalReports.Engine`
   - `CrystalDecisions.Shared`
   - `CrystalDecisions.Windows.Forms`
3. Trong hộp thoại *References*, đường dẫn thường là
   `C:\Program Files (x86)\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Common\SAP BusinessObjects Enterprise XI 4.0\win64_x64\dotnet\`.

## 2. Dùng tập dữ liệu đã chuẩn bị

Tệp `BaoCaoDataSet.xsd` trong thư mục gốc dự án đã khai báo ba bảng dữ liệu khớp chính xác với cột trả về của
ba thủ tục trong `StoredProcedures.sql`:

| Bảng trong DataSet | Thủ tục nguồn | Cột |
|--------------------|----------------|-----|
| `DoanhThu`   | `sp_BaoCaoDoanhThuTheoThang` | Nam, Thang, SoHoaDon, DoanhThu |
| `TonKho`     | `sp_BaoCaoTonKho`            | MaHang, TenHang, Hang, Loai, DonGiaBan, SoLuongTon, GiaTriTon |
| `TopBanChay` | `sp_BaoCaoTopBanChay`        | MaHang, TenHang, Hang, SoLuongBan, DoanhThu |

Cách đổ dữ liệu vào DataSet (đặt trong `BaoCaoBUS` hoặc một lớp mới `BaoCaoReportBUS`):

```csharp
public BaoCaoDataSet NapDuLieuBaoCao()
{
    var ds = new BaoCaoDataSet();

    // Mỗi thủ tục đã được gọi qua DAL, ở đây chỉ đổ vào DataSet
    ds.DoanhThu.Merge(baoCaoDal.DoanhThuTheoThang());
    ds.TonKho.Merge(baoCaoDal.TonKho());
    ds.TopBanChay.Merge(baoCaoDal.TopBanChay(10));

    return ds;
}
```

## 3. Tạo ba tệp .rpt

1. Chuột phải dự án → *Add* → *New Item* → *Crystal Report*, chọn *Using the Report Wizard*.
2. Ở bước *Data*, chọn *Project Data* → *ADO.NET DataSet* → `BaoCaoDataSet`.
3. Chọn bảng tương ứng (`DoanhThu`, `TonKho`, `TopBanChay`) và các cột cần in.
4. Kéo các trường vào vùng *Details*, thêm tiêu đề báo cáo, dòng tổng (`Insert` → `Summary`), định dạng số
   `#,##0` cho các cột tiền, đặt font Times New Roman 12.
5. Lưu thành `Reports/rptDoanhThu.rpt`, `Reports/rptTonKho.rpt`, `Reports/rptTopBanChay.rpt`.

## 4. Gắn báo cáo vào FormBaoCao

1. Mở `FormBaoCao` trong Form Designer, thêm một `CrystalReportViewer` (tên `crystalViewer`) và đặt
   `Dock = Fill` trong tab tương ứng.
2. Thay phần nạp `DataGridView` bằng đoạn mã sau:

```csharp
private void HienThiCrystalDoanhThu()
{
    var rpt = new Reports.rptDoanhThu();
    rpt.SetDataSource(baoCaoBus.NapDuLieuBaoCao());
    crystalViewer.ReportSource = rpt;
    crystalViewer.Refresh();
}
```

3. Gọi ba hàm tương ứng khi chuyển tab hoặc khi bấm nút *Làm mới*.
4. Giữ nguyên nút *Xuất Excel* nếu vẫn muốn có thêm đường xuất tệp; khi đã có Crystal Report thì có thể dùng
   `rpt.ExportToDisk(ExportFormatType.PortableDocFormat, "baocao.pdf")` để xuất PDF.

## 5. Kiểm tra trước khi nộp

- Ba tab báo cáo hiển thị đúng số liệu so với phần `DataGridView` cũ.
- Báo cáo in được ra máy in hoặc xuất PDF.
- Chạy lại `python tools/kiem_tra_tinh.py` (không bắt buộc với phần Crystal Report).
- Cập nhật mục 1.3.6 và 3.5.2 của báo cáo: khi đã có Crystal Report thì bỏ ghi chú "chưa thực hiện được".
