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
_PARSER = None


def doc(duong_dan):
    with open(duong_dan, encoding="utf-8-sig") as f:
        return f.read()


def bao_loi(noi_dung):
    LOI.append(noi_dung)


def canh_bao(noi_dung):
    CANH_BAO.append(noi_dung)


def danh_sach_tep_cs():
    return sorted(
        p for p in glob.glob(os.path.join(GOC, "**", "*.cs"), recursive=True)
        if os.sep + "obj" + os.sep not in p and os.sep + "bin" + os.sep not in p
    )


def kiem_tra_csproj():
    tep = glob.glob(os.path.join(GOC, "*.csproj"))
    if len(tep) != 1:
        bao_loi(f"Phải có đúng một tệp .csproj, hiện có {len(tep)}.")
        return

    noi_dung = doc(tep[0])
    if "EnableDefaultCompileItems" in noi_dung and "false" in noi_dung.lower():
        bao_loi("Tệp .csproj tắt chế độ tự động gom tệp .cs nhưng không liệt kê thủ công.")

    so_cs = len(danh_sach_tep_cs())
    print(f"[csproj] {os.path.basename(tep[0])}: tự động gom {so_cs} tệp .cs (SDK-style).")

    if 'TargetFramework' in noi_dung:
        tf = re.search(r"<TargetFramework>(.*?)</TargetFramework>", noi_dung)
        print(f"[csproj] Nền tảng: {tf.group(1) if tf else '?'}")

    # Mọi đường dẫn tệp được nêu trong .csproj phải tồn tại (không tham chiếu tệp đã xóa).
    for duong_dan in re.findall(r'(?:Include|Update|Remove)="([^"]+\.(?:cs|resx|xsd|ico|png|jpg))"', noi_dung):
        that = os.path.join(GOC, duong_dan.replace("\\", os.sep))
        if not os.path.exists(that):
            bao_loi(f".csproj tham chiếu tệp không tồn tại: {duong_dan}")

    # RootNamespace phải khớp không gian tên của tài nguyên nhúng Properties/Resources.resx.
    rn = re.search(r"<RootNamespace>(.*?)</RootNamespace>", noi_dung)
    designer = os.path.join(GOC, "Properties", "Resources.Designer.cs")
    if rn and os.path.exists(designer):
        nguon = doc(designer)
        m = re.search(r'new global::System.Resources.ResourceManager\("([^"]+)"', nguon)
        can = rn.group(1).strip() + ".Properties.Resources"
        if m and m.group(1) != can:
            bao_loi(f"RootNamespace '{rn.group(1)}' không khớp tài nguyên nhúng '{m.group(1)}' "
                    f"(cần '{can}').")
        else:
            print(f"[csproj] RootNamespace khớp tài nguyên nhúng: {can}")

    # Mỗi biểu mẫu phải đủ bộ .cs + .Designer.cs (+ .resx nếu Designer có dùng resx).
    for tep_designer in glob.glob(os.path.join(GOC, "**", "*.Designer.cs"), recursive=True):
        # Properties/Resources.Designer.cs là lớp sinh cho tệp .resx, không phải biểu mẫu.
        if os.path.basename(tep_designer) == "Resources.Designer.cs":
            continue
        goc_form = tep_designer[: -len(".Designer.cs")]
        if not os.path.exists(goc_form + ".cs"):
            bao_loi(f"Thiếu mã lệnh cho biểu mẫu: {os.path.basename(goc_form)}.cs")
    for tep_resx in glob.glob(os.path.join(GOC, "*.resx")) + glob.glob(os.path.join(GOC, "**", "*.resx"), recursive=True):
        goc_resx = tep_resx[: -len(".resx")]
        if not (os.path.exists(goc_resx + ".Designer.cs") or os.path.exists(goc_resx + ".cs")):
            canh_bao(f"Tệp {os.path.relpath(tep_resx, GOC)} không có mã lệnh đi kèm.")
    print("[csproj] Mọi tệp biểu mẫu đều đủ bộ .cs/.Designer.cs/.resx.")

    # Ảnh mà Dashboard đọc từ thư mục Images phải có trong kho.
    form10 = os.path.join(GOC, "GUI", "Form10.cs")
    if os.path.exists(form10):
        for ten in set(re.findall(r'"([\w\-]+\.(?:jpg|jpeg|png|bmp|gif))"', doc(form10))):
            if not os.path.exists(os.path.join(GOC, "Images", ten)):
                bao_loi(f"Images/{ten} được Form10.cs dùng nhưng không có trong kho.")
            else:
                print(f"[Images] Có ảnh Dashboard dùng: Images/{ten}")


def kiem_tra_thu_muc_gui():
    """Biểu mẫu phải nằm gọn trong GUI/ và namespace phải khớp tên tài nguyên nhúng.

    Trong dự án SDK-style, tệp GUI/FormX.resx được nhúng dưới tên
    <RootNamespace>.GUI.FormX.resources. Nếu namespace của FormX khác <RootNamespace>.GUI thì
    ComponentResourceManager(typeof(FormX)) sẽ tìm sai tên và ném MissingManifestResourceException
    lúc chạy trên Windows.
    """
    noi_dung = doc(glob.glob(os.path.join(GOC, "*.csproj"))[0])
    rn = re.search(r"<RootNamespace>(.*?)</RootNamespace>", noi_dung)
    ten_goc = rn.group(1).strip() if rn else ""
    can = (ten_goc + ".GUI").strip(".")

    # Không còn tệp biểu mẫu nào ở thư mục gốc.
    con_o_goc = sorted(os.path.basename(p) for p in glob.glob(os.path.join(GOC, "Form*"))
                       if os.path.isfile(p))
    if con_o_goc:
        bao_loi("Còn tệp biểu mẫu ở thư mục gốc, phải chuyển vào GUI/: " + ", ".join(con_o_goc))

    ds_form = sorted(p for p in glob.glob(os.path.join(GOC, "GUI", "Form*.cs"))
                     if not p.endswith(".Designer.cs"))
    if not ds_form:
        bao_loi("Không tìm thấy biểu mẫu nào trong thư mục GUI/.")
        return

    so_sai = 0
    for tep in ds_form:
        ns = re.search(r"^\s*namespace\s+([\w\.]+)", doc(tep), re.M)
        ten_ns = ns.group(1) if ns else "?"
        if ten_ns != can:
            ten_form = os.path.splitext(os.path.basename(tep))[0]
            bao_loi(f"GUI/{os.path.basename(tep)} dùng namespace '{ten_ns}' nhưng tài nguyên nhúng "
                    f"của tệp là '{can}.{ten_form}.resources' — cần namespace '{can}' để tránh "
                    f"MissingManifestResourceException.")
            so_sai += 1

    print(f"[GUI] {len(ds_form)} biểu mẫu trong GUI/ dùng namespace '{can}': "
          f"{len(ds_form) - so_sai} đúng, {so_sai} sai.")


def kiem_tra_giao_dien():
    ds = glob.glob(os.path.join(GOC, "Interfaces", "*.cs"))
    ten = [os.path.splitext(os.path.basename(p))[0] for p in ds]
    print(f"[interface] Tìm thấy {len(ten)} tệp: {', '.join(sorted(ten))}")
    if len(ten) < 6:
        bao_loi(f"Cần tối thiểu 6 giao diện, hiện có {len(ten)}.")


def kiem_tra_ke_thua():
    cac_interface = {os.path.splitext(os.path.basename(p))[0]
                     for p in glob.glob(os.path.join(GOC, "Interfaces", "*.cs"))}
    so_lop_ke_thua = []
    so_lop_trien_khai = []
    lop_truu_tuong = set()

    for tep in glob.glob(os.path.join(GOC, "**", "*.cs"), recursive=True):
        if tep.endswith(".Designer.cs"):
            continue
        lop_truu_tuong.update(re.findall(r"abstract\s+class\s+(\w+)", doc(tep)))

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
                if g in lop_truu_tuong:
                    so_lop_ke_thua.append((ten_lop, g))

    print(f"[trừu tượng] {len(lop_truu_tuong)} lớp trừu tượng: {', '.join(sorted(lop_truu_tuong))}")
    print(f"[kế thừa] {len(so_lop_ke_thua)} lớp kế thừa lớp cơ sở trừu tượng: "
          + ", ".join(f"{a} : {b}" for a, b in so_lop_ke_thua))
    print(f"[triển khai] {len(so_lop_trien_khai)} lớp triển khai giao diện: {', '.join(so_lop_trien_khai)}")

    if len(lop_truu_tuong) < 3:
        bao_loi(f"Cần tối thiểu 3 lớp trừu tượng, hiện có {len(lop_truu_tuong)}.")
    if len(so_lop_ke_thua) < 5:
        bao_loi(f"Cần tối thiểu 5 lớp kế thừa, hiện có {len(so_lop_ke_thua)}.")
    if len(so_lop_trien_khai) < 6:
        bao_loi(f"Cần tối thiểu 6 lớp triển khai giao diện, hiện có {len(so_lop_trien_khai)}.")


def _bo_phan_tich():
    """Trả về bộ phân tích cú pháp C# của tree-sitter (khởi tạo một lần)."""
    global _PARSER
    if _PARSER is None:
        import tree_sitter_c_sharp as tscs
        from tree_sitter import Language, Parser

        _PARSER = Parser(Language(tscs.language()))
    return _PARSER


def _cay_cu_phap(duong_dan):
    with open(duong_dan, "rb") as f:
        return _bo_phan_tich().parse(f.read())


def _duyet(node):
    yield node
    for con in node.children:
        yield from _duyet(con)


def kiem_tra_cu_phap():
    ds_tep = danh_sach_tep_cs()
    so_loi = 0

    for tep in ds_tep:
        cay = _cay_cu_phap(tep)
        for nut in _duyet(cay.root_node):
            if nut.type == "ERROR" or nut.is_missing:
                dong = nut.start_point[0] + 1
                trich = nut.text.decode("utf-8", "replace").splitlines()[0][:60]
                bao_loi(f"{os.path.relpath(tep, GOC)}:{dong} lỗi cú pháp: {trich}")
                so_loi += 1

    if so_loi:
        print(f"[cú pháp] tree-sitter C#: {so_loi} lỗi cú pháp trong {len(ds_tep)} tệp .cs.")
    else:
        print(f"[cú pháp] tree-sitter C#: 0 lỗi cú pháp trong {len(ds_tep)} tệp .cs.")


KIEU_KHAI_BAO = {
    "class_declaration",
    "struct_declaration",
    "interface_declaration",
    "enum_declaration",
    "record_declaration",
    "delegate_declaration",
}

THANH_VIEN = {
    "method_declaration": "phương thức",
    "constructor_declaration": "hàm dựng",
    "property_declaration": "thuộc tính",
    "field_declaration": "trường",
    "event_field_declaration": "sự kiện",
}


def _ten_thanh_vien(nut):
    """Trả về (khóa định danh thành viên, tên hiển thị) của một khai báo trong thân lớp."""
    loai = THANH_VIEN.get(nut.type)
    if loai is None:
        return None

    if nut.type in ("field_declaration", "event_field_declaration"):
        khai_bao = next((c for c in nut.children if c.type == "variable_declaration"), None)
        if khai_bao is None:
            return None
        for con in khai_bao.children:
            if con.type == "variable_declarator":
                ten = con.child_by_field_name("name")
                if ten is not None:
                    return (ten.text.decode() + " [" + loai + "]", ten.text.decode())
        return None

    ten = nut.child_by_field_name("name")
    if ten is None:
        return None
    ten = ten.text.decode()

    tham_so = nut.child_by_field_name("parameters")
    if tham_so is not None:
        so_tham_so = sum(1 for c in tham_so.children if c.type == "parameter")
        return (f"{ten}({so_tham_so} tham số) [{loai}]", f"{ten}({so_tham_so})")
    return (f"{ten} [{loai}]", ten)


def kiem_tra_trung_ten():
    """Kiểm tra CS0101 (trùng tên kiểu) và CS0102 (trùng tên thành viên trong cùng lớp)."""
    kieu = {}
    thanh_vien_lop = {}

    for tep in danh_sach_tep_cs():
        tuong_doi = os.path.relpath(tep, GOC)
        cay = _cay_cu_phap(tep)

        for nut in _duyet(cay.root_node):
            if nut.type not in KIEU_KHAI_BAO:
                continue

            nut_ten = nut.child_by_field_name("name")
            if nut_ten is None:
                continue
            ten_kieu = nut_ten.text.decode()
            dong = nut.start_point[0] + 1

            dau = nut.text.decode("utf-8", "replace").split("{")[0]
            la_partial = "partial" in dau
            if not la_partial and nut.type in ("class_declaration", "struct_declaration", "record_declaration"):
                kieu.setdefault(ten_kieu, []).append(f"{tuong_doi}:{dong}")

            than = nut.child_by_field_name("body")
            if than is None:
                continue
            noi_luu = thanh_vien_lop.setdefault(ten_kieu, {})
            for con in than.children:
                khoa = _ten_thanh_vien(con)
                if khoa is None:
                    continue
                noi_luu.setdefault(khoa[0], []).append(f"{tuong_doi}:{con.start_point[0] + 1}")

    so_trung = 0
    for ten_kieu, vi_tri in sorted(kieu.items()):
        if len(vi_tri) > 1:
            bao_loi(f"CS0101 trùng tên kiểu '{ten_kieu}': {', '.join(vi_tri)}")
            so_trung += 1

    for ten_kieu, ds_thanh_vien in sorted(thanh_vien_lop.items()):
        for khoa, vi_tri in sorted(ds_thanh_vien.items()):
            if len(vi_tri) > 1:
                bao_loi(f"CS0102 lớp '{ten_kieu}' khai báo trùng {khoa}: {', '.join(vi_tri)}")
                so_trung += 1

    print(f"[trùng tên] {len(kieu)} kiểu dữ liệu, {sum(len(v) for v in thanh_vien_lop.values())} "
          f"thành viên trong các lớp: {so_trung} chỗ trùng tên (CS0101/CS0102).")


def _thanh_vien_va_co_so():
    """Trả về (thành viên của từng lớp/giao diện, cạnh kế thừa) đọc từ cây cú pháp."""
    thanh_vien = {}
    co_so = {}

    for tep in danh_sach_tep_cs():
        cay = _cay_cu_phap(tep)
        for nut in _duyet(cay.root_node):
            if nut.type not in ("class_declaration", "interface_declaration"):
                continue
            ten = nut.child_by_field_name("name")
            if ten is None:
                continue
            ten = ten.text.decode()

            ds_co_so = []
            goc = nut.child_by_field_name("bases")
            if goc is not None:
                for con in goc.children:
                    if con.type in ("identifier", "qualified_name", "generic_name"):
                        ds_co_so.append(con.text.decode().split(".")[-1].split("<")[0])
            co_so.setdefault(ten, set()).update(ds_co_so)

            than = nut.child_by_field_name("body")
            tap = thanh_vien.setdefault(ten, set())
            if than is None:
                continue
            for con in than.children:
                khoa = _ten_thanh_vien(con)
                if khoa is not None:
                    tap.add(khoa[1].split("(")[0])

    return thanh_vien, co_so


def kiem_tra_giao_dien_trien_khai():
    """Lớp khai báo triển khai giao diện phải có đủ thành viên (kể cả thành viên thừa kế từ lớp cơ sở)."""
    thanh_vien, co_so = _thanh_vien_va_co_so()
    giao_dien = {t for t, cs in co_so.items() if t.startswith("I") and len(t) > 1 and t[1].isupper()
                 and t not in {"IImage", "IEnumerable", "IComparable"}}
    giao_dien = {g for g in giao_dien if g in thanh_vien and g in co_so}

    def tat_ca_thanh_vien(ten, da_xet=None):
        da_xet = da_xet or set()
        if ten in da_xet:
            return set()
        da_xet.add(ten)
        tap = set(thanh_vien.get(ten, set()))
        for c in co_so.get(ten, set()):
            tap |= tat_ca_thanh_vien(c, da_xet)
        return tap

    so_loi = 0
    for ten, ds_co_so in sorted(co_so.items()):
        if ten in giao_dien:
            continue
        ds_giao_dien = [g for g in ds_co_so if g in giao_dien]
        if not ds_giao_dien:
            continue
        co_san = tat_ca_thanh_vien(ten)
        for g in ds_giao_dien:
            thieu = thanh_vien[g] - co_san
            if thieu:
                bao_loi(f"Lớp {ten} thiếu thành viên của {g}: {', '.join(sorted(thieu))}")
                so_loi += 1
    print(f"[giao diện] Đối chiếu {len(giao_dien)} giao diện với lớp triển khai: "
          f"{so_loi} lớp thiếu thành viên.")


def kiem_tra_loi_goi_bus_dal():
    """Mọi thành viên gọi qua biến BUS/DAL/tiện ích phải được khai báo trong lớp tương ứng."""
    thanh_vien, _ = _thanh_vien_va_co_so()
    so_goi = 0
    so_loi = 0

    for tep in danh_sach_tep_cs():
        if tep.endswith("Designer.cs"):
            continue
        noi_dung = bo_chu_thich(doc(tep))
        bien = {}
        for m in re.finditer(r"(?:private|public|internal)\s+(?:static\s+)?(?:readonly\s+)?"
                             r"([\w\.]+(?:BUS|Bus|DAL|Dal))\s+(\w+)\s*(?:=|;)", noi_dung):
            bien[m.group(2)] = m.group(1)
        for m in re.finditer(r"\b(\w+)\s*\.\s*(\w+)\s*\(", noi_dung):
            doi_tuong, ham = m.group(1), m.group(2)
            lop = bien.get(doi_tuong)
            if lop is None:
                continue
            so_goi += 1
            if lop not in thanh_vien:
                bao_loi(f"{os.path.basename(tep)}: không tìm thấy lớp {lop}")
                so_loi += 1
            elif ham not in thanh_vien[lop]:
                bao_loi(f"{os.path.basename(tep)}: gọi {lop}.{ham}() nhưng {lop} không khai báo thành viên này")
                so_loi += 1

    print(f"[lời gọi] Đối chiếu {so_goi} lời gọi BUS/DAL với khai báo lớp: {so_loi} lời gọi không khớp.")


def kiem_tra_tien_ich():
    tep = os.path.join(GOC, "Utilities", "AppHelpers.cs")
    if not os.path.exists(tep):
        bao_loi("Không tìm thấy Utilities/AppHelpers.cs.")
        return

    noi_dung = doc(tep)
    ds_phuong_thuc = re.findall(r"public\s+static\s+[\w\<\>\?\[\]]+\s+(\w+)\s*\(", noi_dung)
    ds_thuoc_tinh = re.findall(r"public\s+static\s+[\w\<\>\?\[\]]+\s+(\w+)\s*=>", noi_dung)
    ds_truong = re.findall(r"public\s+static\s+(?:readonly\s+)?[\w\<\>\?\[\]]+\s+(\w+)\s*=(?!>)", noi_dung)
    tong = len(ds_phuong_thuc) + len(ds_thuoc_tinh) + len(ds_truong)
    print(f"[tiện ích] {len(ds_phuong_thuc)} phương thức static: {', '.join(ds_phuong_thuc)}")
    print(f"[tiện ích] {len(ds_thuoc_tinh)} thuộc tính ({', '.join(ds_thuoc_tinh) if ds_thuoc_tinh else '—'}), "
          f"{len(ds_truong)} trường static ({', '.join(ds_truong) if ds_truong else '—'}) "
          f"→ tổng {tong} class method/thành viên dùng chung.")
    if tong < 16:
        bao_loi(f"Cần tối thiểu 16 class method/thành viên tiện ích, hiện có {tong}.")


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
    tep_kiem_tra += glob.glob(os.path.join(GOC, "GUI", "*.cs"))
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
    kiem_tra_thu_muc_gui()
    kiem_tra_cu_phap()
    kiem_tra_trung_ten()
    kiem_tra_loi_goi_bus_dal()
    kiem_tra_giao_dien()
    kiem_tra_ke_thua()
    kiem_tra_giao_dien_trien_khai()
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
