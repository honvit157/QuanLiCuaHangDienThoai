"""Chuyển mã dựng giao diện ra khỏi InitializeComponent() để mọi Form mở được màn [Design].

Với mỗi FormX.Designer.cs:
  - InitializeComponent() chỉ còn các dòng chuẩn mà trình thiết kế đọc được
    (components, SuspendLayout, AutoScaleDimensions, AutoScaleMode, ClientSize, Name, Text,
    ResumeLayout);
  - toàn bộ mã dựng control (vòng lặp, biến cục bộ, lời gọi hàm tự viết) và các hàm phụ trợ
    được chuyển sang FormX.cs: phần dựng control nằm trong TaoGiaoDien(), được gọi ngay sau
    InitializeComponent() nên giao diện và hành vi giữ nguyên;
  - khai báo control vẫn nằm trong tệp Designer.

Chạy:  python tools/tach_designer.py
"""
import os
import re
import sys

import tree_sitter_c_sharp as tscs
from tree_sitter import Language, Parser

GOC = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
PARSER = Parser(Language(tscs.language()))

GIU_LAI_RE = [re.compile(p) for p in [
    r"^\s*components\s*=\s*new",
    r"^\s*SuspendLayout\(\)\s*;",
    r"^\s*ResumeLayout\(",
    r"^\s*AutoScaleDimensions\s*=",
    r"^\s*AutoScaleMode\s*=",
    r"^\s*ClientSize\s*=",
    r"^\s*Name\s*=",
    r"^\s*Text\s*=",
]]

BO_QUA = {"Form10.Designer.cs", "Form12.Designer.cs"}

DISPOSE_CHUAN = """        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }"""


def duyet(node):
    yield node
    for con in node.children:
        yield from duyet(con)


def doc_dong(duong_dan):
    with open(duong_dan, "rb") as f:
        return f.read().decode("utf-8-sig").replace("\r\n", "\n").split("\n")


def thut_le(ds_dong, so_khoang):
    """Gỡ thụt lề chung rồi thụt lại theo cấp mong muốn, giữ nguyên thụt lề tương đối."""
    noi_dung = [d for d in ds_dong if d.strip()]
    if not noi_dung:
        return []
    le = min(len(d) - len(d.lstrip()) for d in noi_dung)
    dau = " " * so_khoang
    return [dau + d[le:] if d.strip() else "" for d in ds_dong]


def gon_dong_trong(ds_dong):
    ket_qua = []
    for d in ds_dong:
        if d.strip() == "" and ket_qua and ket_qua[-1].strip() == "":
            continue
        ket_qua.append(d)
    while ket_qua and ket_qua[0].strip() == "":
        ket_qua.pop(0)
    while ket_qua and ket_qua[-1].strip() == "":
        ket_qua.pop()
    return ket_qua


def xu_ly(ten_tep):
    duong_dan = os.path.join(GOC, ten_tep)
    dong = doc_dong(duong_dan)

    with open(duong_dan, "rb") as f:
        du_lieu = f.read()
    cay = PARSER.parse(du_lieu)

    if any(n.type == "ERROR" or n.is_missing for n in duyet(cay.root_node)):
        print(f"  !! {ten_tep}: lỗi cú pháp, bỏ qua")
        return False

    lop = [n for n in duyet(cay.root_node) if n.type == "class_declaration"][0]
    ten_lop = lop.child_by_field_name("name").text.decode()

    ns = re.search(r"namespace\s+([\w\.]+)", du_lieu.decode("utf-8-sig"))
    ten_ns = ns.group(1) if ns else ""

    khoi_tao = None
    for nut in duyet(cay.root_node):
        if nut.type != "method_declaration":
            continue
        ten = nut.child_by_field_name("name")
        if ten is not None and ten.text.decode() == "InitializeComponent":
            khoi_tao = nut
            break
    if khoi_tao is None:
        print(f"  !! {ten_tep}: không tìm thấy InitializeComponent")
        return False

    than = khoi_tao.child_by_field_name("body")
    dong_dau = than.start_point[0]
    dong_cuoi = than.end_point[0]

    # Bỏ dòng chứa ngoặc mở/đóng của thân phương thức
    bat_dau, ket_thuc = dong_dau + 1, dong_cuoi
    if dong[dong_dau].strip() == "{":
        bat_dau = dong_dau + 1
    if dong[dong_cuoi].strip() == "}":
        ket_thuc = dong_cuoi

    than_dong = dong[bat_dau:ket_thuc]

    giu, chuyen = [], []
    for d in than_dong:
        if d.strip() == "":
            giu.append("")
        elif any(rx.match(d) for rx in GIU_LAI_RE):
            giu.append(d.strip())
        else:
            chuyen.append(d)

    # Khai báo control giữ lại trong tệp Designer
    khai_bao = []
    for nut in lop.child_by_field_name("body").children:
        if nut.type != "field_declaration":
            continue
        doan = dong[nut.start_point[0]: nut.end_point[0] + 1]
        if any("components" in d for d in doan):
            continue
        khai_bao.append("\n".join(thut_le(doan, 8)))

    # Hàm phụ trợ trong tệp Designer -> chuyển sang .cs
    ham_phu = []
    for nut in duyet(cay.root_node):
        if nut.type != "method_declaration":
            continue
        ten = nut.child_by_field_name("name")
        ten = ten.text.decode() if ten is not None else ""
        if ten in ("InitializeComponent", "Dispose"):
            continue
        doan = dong[nut.start_point[0]: nut.end_point[0] + 1]
        ham_phu.append("\n".join(thut_le(doan, 8)))

    usings = []
    for d in dong:
        if d.startswith("using "):
            usings.append(d.strip())
    for can in ("using System;", "using System.Drawing;", "using System.Windows.Forms;"):
        if can not in usings:
            usings.append(can)

    giu = gon_dong_trong([("            " + d if d.strip() else "") for d in giu])

    noi_dung_designer = "\n".join(usings) + f"""

namespace {ten_ns}
{{
    partial class {ten_lop}
    {{
        private System.ComponentModel.IContainer components = null;

{DISPOSE_CHUAN}

        /// <summary>
        /// Khởi tạo các thuộc tính cơ bản của biểu mẫu.
        /// Phần dựng control được tách sang TaoGiaoDien() trong {ten_lop}.cs
        /// để màn [Design] của Visual Studio luôn mở được.
        /// </summary>
        private void InitializeComponent()
        {{
{chr(10).join(giu)}
        }}

{chr(10).join(khai_bao)}
    }}
}}
"""
    with open(duong_dan, "w", encoding="utf-8") as f:
        f.write(noi_dung_designer)

    # Ghi phần dựng giao diện sang FormX.cs
    tep_cs = duong_dan[: -len(".Designer.cs")] + ".cs"
    ma_cs = open(tep_cs, encoding="utf-8-sig").read().replace("\r\n", "\n")

    khoi_dung = thut_le(chuyen, 12)
    thanh_vien_ma = "\n\n".join(ham_phu)

    them_vao = f"""
        // =====================================================
        // DỰNG GIAO DIỆN
        // Tách khỏi InitializeComponent() để màn [Design] của Visual Studio
        // luôn mở được: trình thiết kế không đọc được vòng lặp và biến cục bộ.
        // =====================================================
        private void TaoGiaoDien()
        {{
{chr(10).join(khoi_dung)}
        }}

        // =====================================================
        // CÁC HÀM HỖ TRỢ THIẾT KẾ
        // =====================================================
{thanh_vien_ma}
"""

    vi_tri_dong = ma_cs.rstrip().rfind("\n    }")
    if vi_tri_dong < 0:
        print(f"  !! không tìm thấy cuối lớp trong {os.path.basename(tep_cs)}")
        return False
    ma_cs = ma_cs.rstrip()[:vi_tri_dong].rstrip() + "\n" + them_vao + "    }\n}\n"

    if "TaoGiaoDien();" not in ma_cs:
        ma_cs = ma_cs.replace(
            "InitializeComponent();",
            "InitializeComponent();\n\n            TaoGiaoDien();",
            1,
        )

    with open(tep_cs, "w", encoding="utf-8") as f:
        f.write(ma_cs)

    for kiem in (duong_dan, tep_cs):
        with open(kiem, "rb") as f:
            cay_moi = PARSER.parse(f.read())
        loi = [n for n in duyet(cay_moi.root_node) if n.type == "ERROR" or n.is_missing]
        if loi:
            print(f"  !! {os.path.basename(kiem)} còn {len(loi)} lỗi cú pháp sau khi sửa")
            return False

    print(f"  {ten_tep}: {len(chuyen)} dòng dựng giao diện + {len(ham_phu)} hàm phụ trợ "
          f"-> {os.path.basename(tep_cs)}")
    return True


def main():
    ds = sorted(
        p for p in os.listdir(GOC)
        if p.startswith("Form") and p.endswith(".Designer.cs") and p not in BO_QUA
    )
    if not ds:
        print("Không có tệp Designer nào cần xử lý.")
        return 0

    for ten in ds:
        print(ten)
        if not xu_ly(ten):
            return 1
    return 0


if __name__ == "__main__":
    sys.exit(main())
