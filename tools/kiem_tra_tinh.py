"""
Kiểm tra tĩnh mã nguồn, kịch bản SQL và tài liệu của bài tập lớn.

Công cụ không cần .NET hay SQL Server: nó đọc mã nguồn C#, tệp .sql và hai tệp
.docx/.pptx để đối chiếu với yêu cầu của học phần.

Chạy:  python tools/kiem_tra_tinh.py
Mã thoát: 0 nếu tất cả điều kiện đạt, 1 nếu có lỗi.
"""

import glob
import os
import re
import sys

GOC = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
LOI = []
CANH_BAO = []


def doc(duong_dan):
    with open(duong_dan, encoding="utf-8-sig") as f:
        return f.read()


def bao_loi(noi_dung):
    LOI.append(noi_dung)


def canh_bao(noi_dung):
    CANH_BAO.append(noi_dung)


def kiem_tra_csproj():
    tep = glob.glob(os.path.join(GOC, "*.csproj"))
    if len(tep) != 1:
        bao_loi(f"Phải có đúng một tệp .csproj, hiện có {len(tep)}.")
        return

    noi_dung = doc(tep[0])
    if "EnableDefaultCompileItems" in noi_dung and "false" in noi_dung.lower():
        bao_loi("Tệp .csproj tắt chế độ tự động gom tệp .cs nhưng không liệt kê thủ công.")

    so_cs = len([p for p in glob.glob(os.path.join(GOC, "**", "*.cs"), recursive=True)])
    print(f"[csproj] {os.path.basename(tep[0])}: tự động gom {so_cs} tệp .cs (SDK-style).")

    if 'TargetFramework' in noi_dung:
        tf = re.search(r"<TargetFramework>(.*?)</TargetFramework>", noi_dung)
        print(f"[csproj] Nền tảng: {tf.group(1) if tf else '?'}")


def kiem_tra_giao_dien():
    ds = glob.glob(os.path.join(GOC, "Interfaces", "*.cs"))
    ten = [os.path.splitext(os.path.basename(p))[0] for p in ds]
    print(f"[interface] Tìm thấy {len(ten)} tệp: {', '.join(sorted(ten))}")
    if len(ten) < 5:
        bao_loi(f"Cần tối thiểu 5 giao diện, hiện có {len(ten)}.")


def kiem_tra_ke_thua():
    cac_interface = {"IHangHoa", "IKhachHang", "INhanVien", "INhaCungCap", "IHoaDon"}
    so_lop_ke_thua = []
    so_lop_trien_khai = []

    for tep in glob.glob(os.path.join(GOC, "**", "*.cs"), recursive=True):
        if tep.endswith(".Designer.cs"):
            continue
        noi_dung = doc(tep)

        for m in re.finditer(r"class\s+(\w+)\s*:\s*([^\{\n]+)", noi_dung):
            ten_lop = m.group(1)
            ds_goc = [x.strip() for x in m.group(2).split(",") if x.strip()]

            if any(g in cac_interface for g in ds_goc):
                so_lop_trien_khai.append(ten_lop)

            for g in ds_goc:
                if g not in cac_interface and g[0].isupper() and g not in ("object",) and "(" not in g:
                    so_lop_ke_thua.append((ten_lop, g))

    print(f"[kế thừa] {len(so_lop_ke_thua)} lớp kế thừa lớp khác: "
          + ", ".join(f"{a} : {b}" for a, b in so_lop_ke_thua))
    print(f"[triển khai] {len(so_lop_trien_khai)} lớp triển khai giao diện: {', '.join(so_lop_trien_khai)}")

    if len(so_lop_ke_thua) < 3:
        bao_loi(f"Cần tối thiểu 3 lớp kế thừa, hiện có {len(so_lop_ke_thua)}.")
    if len(so_lop_trien_khai) < 5:
        bao_loi(f"Cần tối thiểu 5 lớp triển khai giao diện, hiện có {len(so_lop_trien_khai)}.")


def kiem_tra_tien_ich():
    tep = os.path.join(GOC, "Utilities", "AppHelpers.cs")
    if not os.path.exists(tep):
        bao_loi("Không tìm thấy Utilities/AppHelpers.cs.")
        return

    noi_dung = doc(tep)
    ds_phuong_thuc = re.findall(r"public\s+static\s+[\w\<\>\?\[\]]+\s+(\w+)\s*\(", noi_dung)
    print(f"[tiện ích] {len(ds_phuong_thuc)} class method: {', '.join(ds_phuong_thuc)}")
    if len(ds_phuong_thuc) < 5:
        bao_loi(f"Cần tối thiểu 5 class method, hiện có {len(ds_phuong_thuc)}.")


def bo_chu_thich(noi_dung):
    """Bỏ chú thích // và /* */ để tránh báo lỗi giả khi chú thích nhắc tới SELECT."""
    noi_dung = re.sub(r"/\*.*?\*/", "", noi_dung, flags=re.S)
    return re.sub(r"//[^\n]*", "", noi_dung)


def kiem_tra_inline_sql():
    mau = [
        (r"CommandType\.Text", "dùng CommandType.Text"),
        (r"\bSELECT\s+[\w\*\[]", "có câu SELECT"),
        (r"\bINSERT\s+INTO\b", "có câu INSERT INTO"),
        (r"\bUPDATE\s+tbl", "có câu UPDATE tbl..."),
        (r"\bDELETE\s+FROM\s+tbl", "có câu DELETE FROM tbl..."),
        (r"new\s+SqlCommand\s*\(\s*\$?\"", "tạo SqlCommand từ chuỗi"),
    ]

    tep_kiem_tra = glob.glob(os.path.join(GOC, "*.cs"))
    tep_kiem_tra += glob.glob(os.path.join(GOC, "BUS", "*.cs"))
    tep_kiem_tra += glob.glob(os.path.join(GOC, "DAL", "*.cs"))
    tep_kiem_tra += glob.glob(os.path.join(GOC, "DTO", "*.cs"))

    so_loi = 0
    for tep in tep_kiem_tra:
        noi_dung = bo_chu_thich(doc(tep))
        for bieu_thuc, mo_ta in mau:
            for m in re.finditer(bieu_thuc, noi_dung):
                dong = noi_dung[:m.start()].count("\n") + 1
                bao_loi(f"{os.path.relpath(tep, GOC)}:{dong} {mo_ta}")
                so_loi += 1

    if so_loi == 0:
        print("[SQL] Không có câu lệnh SQL viết trực tiếp trong tầng GUI, BUS, DTO, DAL.")
    else:
        print(f"[SQL] Phát hiện {so_loi} chỗ nghi vấn viết SQL trực tiếp.")


def danh_sach_thu_tuc_sql():
    tep = os.path.join(GOC, "StoredProcedures.sql")
    noi_dung = doc(tep)
    ds = {}
    for m in re.finditer(r"CREATE\s+OR\s+ALTER\s+PROCEDURE\s+(\w+)([^;]*?)AS\b", noi_dung, re.S):
        ten = m.group(1)
        tham_so = re.findall(r"@(\w+)", m.group(2))
        ds[ten] = tham_so
    print(f"[SQL] StoredProcedures.sql định nghĩa {len(ds)} thủ tục lưu trữ.")
    return ds


def tach_method(noi_dung):
    """Tách nội dung tệp C# thành các đoạn theo khai báo phương thức public."""
    vi_tri = [m.start() for m in re.finditer(r"\n\s*public\s+", noi_dung)]
    if not vi_tri:
        return [(0, noi_dung)]
    ket_qua = []
    for i, v in enumerate(vi_tri):
        cuoi = vi_tri[i + 1] if i + 1 < len(vi_tri) else len(noi_dung)
        ket_qua.append((v, noi_dung[v:cuoi]))
    return ket_qua


def kiem_tra_thu_tuc(ds_sql):
    da_dung = set()
    sai_tham_so = []

    for tep in glob.glob(os.path.join(GOC, "DAL", "*.cs")):
        noi_dung = doc(tep)
        ten_tep = os.path.basename(tep)

        for _, than_method in tach_method(noi_dung):
            ds_thu_tuc = set(re.findall(r'"(sp_\w+)"', than_method))
            if not ds_thu_tuc:
                continue

            tham_so_method = set(re.findall(r'ThamSo\("@(\w+)"', than_method))
            da_dung.update(ds_thu_tuc)

            for ten in ds_thu_tuc:
                if ten not in ds_sql:
                    bao_loi(f"{ten_tep}: gọi thủ tục {ten} chưa được định nghĩa trong StoredProcedures.sql.")
                    continue

                tham_so_sql = set(ds_sql[ten])

                if len(ds_thu_tuc) == 1:
                    thua = tham_so_method - tham_so_sql
                    thieu = tham_so_sql - tham_so_method
                    if thua or thieu:
                        sai_tham_so.append(f"{ten}: thừa {sorted(thua) or '—'}, thiếu {sorted(thieu) or '—'}")
                else:
                    # Một phương thức dùng nhiều thủ tục (ví dụ giao dịch lưu hóa đơn):
                    # chỉ kiểm tra thủ tục không dùng tham số nào ngoài tập tham số của phương thức.
                    thieu = tham_so_sql - tham_so_method
                    if thieu:
                        sai_tham_so.append(f"{ten}: thiếu {sorted(thieu)}")

        # Tên thủ tục danh mục được ghép động: "sp_" + hành động + hậu tố
        hau_to = re.findall(r'LoaiDanhMuc\.\w+\s*=>\s*"(\w+)"', noi_dung)
        for ht in hau_to:
            for ten in ([f"sp_LayDanhSach{ht}", f"sp_Them{ht}", f"sp_CapNhat{ht}", f"sp_Xoa{ht}",
                         f"sp_KiemTra{ht}TonTai"]):
                if ten in ds_sql:
                    da_dung.add(ten)
                else:
                    bao_loi(f"{ten_tep}: thủ tục ghép động {ten} chưa được định nghĩa trong SQL.")

    if sai_tham_so:
        for dong in sai_tham_so:
            bao_loi(f"Lệch tham số - {dong}")
    else:
        print(f"[SQL] Đối chiếu tham số: mọi lời gọi khớp tên tham số với thủ tục.")

    print(f"[SQL] {len(da_dung)}/{len(ds_sql)} thủ tục được sử dụng từ tầng DAL.")
    khong_dung = sorted(set(ds_sql) - da_dung)
    if khong_dung:
        canh_bao(f"{len(khong_dung)} thủ tục chưa được gọi: {', '.join(khong_dung)}")


def kiem_tra_bang_csdl():
    init = doc(os.path.join(GOC, "InitDb.sql"))
    bang = re.findall(r"CREATE\s+TABLE\s+dbo\.(\w+)", init)
    print(f"[CSDL] InitDb.sql tạo {len(bang)} bảng: {', '.join(bang)}")
    if len(bang) < 12:
        bao_loi("Số bảng trong InitDb.sql ít hơn 12.")

    # Bảng dùng trong thủ tục nhưng không được tạo
    sql = doc(os.path.join(GOC, "StoredProcedures.sql"))
    dung = set(re.findall(r"dbo\.(tbl\w+)", sql)) | set(re.findall(r"FROM\s+(tbl\w+)", sql))
    thieu = sorted(dung - set(bang))
    if thieu:
        bao_loi(f"Thủ tục tham chiếu bảng chưa được tạo: {', '.join(thieu)}")
    else:
        print("[CSDL] Mọi bảng mà thủ tục tham chiếu đều có trong InitDb.sql.")

    # Tệp gộp phải chứa toàn bộ thủ tục của StoredProcedures.sql
    gop = doc(os.path.join(GOC, "QLCuaHangBanDienThoai.sql"))
    so_gop = len(re.findall(r"CREATE\s+OR\s+ALTER\s+PROCEDURE", gop))
    so_sql = len(re.findall(r"CREATE\s+OR\s+ALTER\s+PROCEDURE", sql))
    if so_gop != so_sql:
        bao_loi(f"Tệp gộp có {so_gop} thủ tục, StoredProcedures.sql có {so_sql}. Hãy chạy tools/gop_sql.py.")
    else:
        print(f"[CSDL] Tệp gộp QLCuaHangBanDienThoai.sql đồng bộ: {so_gop} thủ tục.")


def kiem_tra_tai_lieu():
    ten_sai = ["Nguyễn Văn Nam", "Trần Anh Đức", "Lê Minh Hoàng", "Phạm Quốc Tuấn"]

    try:
        import docx
        import pptx
    except ImportError:
        canh_bao("Không có python-docx/python-pptx nên bỏ qua kiểm tra tài liệu.")
        return

    tep_docx = os.path.join(GOC, "BaoCao_BTL_QuanLyCuaHangDienThoai.docx")
    tep_pptx = os.path.join(GOC, "ThuyetTrinh_BTL_QuanLyCuaHangDienThoai.pptx")

    for tep in (tep_docx, tep_pptx):
        if not os.path.exists(tep):
            bao_loi(f"Thiếu tệp tài liệu {os.path.basename(tep)}.")

    if os.path.exists(tep_docx):
        d = docx.Document(tep_docx)
        toan_bo = "\n".join(p.text for p in d.paragraphs)
        for bang in d.tables:
            for hang in bang.rows:
                for o in hang.cells:
                    toan_bo += "\n" + o.text

        if "CAO THỊ LUYẾN" not in toan_bo:
            bao_loi("Báo cáo Word chưa ghi tên giảng viên TS. Cao Thị Luyến.")
        for ten in ten_sai:
            if ten in toan_bo:
                bao_loi(f"Báo cáo Word còn tên không có thật: {ten}")
        if re.search(r"\b10/10\b", toan_bo):
            bao_loi("Báo cáo Word còn dòng tự chấm điểm 10/10.")

        chuong = {}
        hien_tai = ""
        for p in d.paragraphs:
            if p.style is not None and p.style.name == "Heading 1" and p.text.startswith("CHƯƠNG "):
                hien_tai = p.text.split(".")[0]
            chuong[hien_tai] = chuong.get(hien_tai, 0) + len(p.text.split())

        for k, toi_thieu in (("CHƯƠNG 1", 3), ("CHƯƠNG 2", 7), ("CHƯƠNG 3", 7)):
            so_tu = chuong.get(k, 0)
            so_trang = so_tu / 470
            print(f"[Word] {k}: {so_tu} từ ≈ {so_trang:.1f} trang")
            if so_trang < toi_thieu:
                canh_bao(f"{k} có thể chưa đạt {toi_thieu} trang (ước lượng {so_trang:.1f}).")

        print(f"[Word] Số bảng: {len(d.tables)}, số hình: {len(d.inline_shapes)}")

    if os.path.exists(tep_pptx):
        prs = pptx.Presentation(tep_pptx)
        toan_bo = ""
        for s in prs.slides:
            for sh in s.shapes:
                if sh.has_text_frame:
                    toan_bo += "\n" + sh.text_frame.text

        if "CAO THỊ LUYẾN" not in toan_bo:
            bao_loi("Slide chưa ghi tên giảng viên TS. Cao Thị Luyến.")
        for ten in ten_sai:
            if ten in toan_bo:
                bao_loi(f"Slide còn tên không có thật: {ten}")
        if "Interop" in toan_bo:
            bao_loi("Slide còn ghi thư viện Microsoft.Office.Interop.Excel không dùng trong dự án.")
        if re.search(r"\b10/10\b", toan_bo):
            bao_loi("Slide còn dòng tự chấm điểm 10/10.")
        print(f"[PowerPoint] {len(prs.slides._sldIdLst)} slide.")


def main():
    print("=" * 70)
    print("KIỂM TRA TĨNH BÀI TẬP LỚN - QUẢN LÝ CỬA HÀNG ĐIỆN THOẠI")
    print("=" * 70)

    kiem_tra_csproj()
    kiem_tra_giao_dien()
    kiem_tra_ke_thua()
    kiem_tra_tien_ich()
    kiem_tra_inline_sql()
    ds_sql = danh_sach_thu_tuc_sql()
    kiem_tra_thu_tuc(ds_sql)
    kiem_tra_bang_csdl()
    kiem_tra_tai_lieu()

    print("-" * 70)
    if CANH_BAO:
        print(f"{len(CANH_BAO)} cảnh báo:")
        for c in CANH_BAO:
            print("  ! " + c)

    if LOI:
        print(f"{len(LOI)} LỖI:")
        for l in LOI:
            print("  x " + l)
        print("KẾT QUẢ: CHƯA ĐẠT")
        return 1

    print("KẾT QUẢ: ĐẠT TẤT CẢ ĐIỀU KIỆN KIỂM TRA TĨNH")
    return 0


if __name__ == "__main__":
    sys.exit(main())
