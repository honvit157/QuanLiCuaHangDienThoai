"""Xuất slide PowerPoint ra PDF "y như trên màn hình" mà không cần PowerPoint/LibreOffice.

Cách làm: make_ppt.py ghi lại mô hình hình học của từng slide vào tai_lieu/slide_model.json
(hình chữ nhật, chữ, bảng, ảnh). Tệp này vẽ lại đúng mô hình đó bằng Pillow rồi gộp thành PDF,
nên bản PDF có cùng bố cục, màu sắc, ảnh và bảng như tệp .pptx.

Chạy:  python tools/xuat_slide_pdf.py
Kết quả: ThuyetTrinh_BTL_QuanLyCuaHangDienThoai.pdf
"""

import json
import os

import fitz
from PIL import Image, ImageDraw, ImageFont

GOC = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
MO_HINH = os.path.join(GOC, "tai_lieu", "slide_model.json")
OUT = os.path.join(GOC, "ThuyetTrinh_BTL_QuanLyCuaHangDienThoai.pdf")

PX = 120  # điểm ảnh trên mỗi inch
CARD = "FFFFFF"  # nền ô bảng xen kẽ
FONT_R = "/usr/share/fonts/truetype/liberation/LiberationSans-Regular.ttf"
FONT_B = "/usr/share/fonts/truetype/liberation/LiberationSans-Bold.ttf"

_font_cache = {}


def font(co, dam=False):
    khoa = (co, dam)
    if khoa not in _font_cache:
        _font_cache[khoa] = ImageFont.truetype(FONT_B if dam else FONT_R, co)
    return _font_cache[khoa]


def mau(hex_str, mac_dinh=(0, 0, 0)):
    if not hex_str:
        return mac_dinh
    return tuple(int(hex_str[i:i + 2], 16) for i in (0, 2, 4))


def ngat_dong(draw, chu, f, rong_px):
    """Ngắt dòng theo bề rộng cho trước."""
    ket_qua = []
    for doan in chu.split("\n"):
        if doan.strip() == "":
            ket_qua.append("")
            continue
        tu = doan.split(" ")
        dong = ""
        for t in tu:
            thu = (dong + " " + t).strip()
            if draw.textlength(thu, font=f) <= rong_px or not dong:
                dong = thu
            else:
                ket_qua.append(dong)
                dong = t
        ket_qua.append(dong)
    return ket_qua


def ve_chu(draw, it):
    co = max(8, int(round(it["size"] * PX / 72)))
    f = font(co, it["bold"])
    x, y = it["x"] * PX, it["y"] * PX
    w, h = it["w"] * PX, it["h"] * PX
    dong = ngat_dong(draw, it["t"], f, w)
    cao_dong = co * 1.28 + it["space"] * PX / 72
    tong_cao = cao_dong * len(dong)

    if it["valign"] == "m":
        y += max(0, (h - tong_cao) / 2)
    elif it["valign"] == "b":
        y += max(0, h - tong_cao)

    for d in dong:
        if it["align"] == "c":
            draw.text((x + w / 2, y), d, font=f, fill=mau(it["color"]), anchor="ma")
        elif it["align"] == "r":
            draw.text((x + w, y), d, font=f, fill=mau(it["color"]), anchor="ra")
        else:
            draw.text((x, y), d, font=f, fill=mau(it["color"]), anchor="la")
        y += cao_dong


def ve_bang(draw, it):
    x, y = it["x"] * PX, it["y"] * PX
    w, h = it["w"] * PX, it["h"] * PX
    so_cot = len(it["headers"])
    ti_le = it["ratios"] or [1] * so_cot
    tong = sum(ti_le)
    rong_cot = [w * t / tong for t in ti_le]
    so_hang = len(it["rows"]) + 1
    cao_hang = h / so_hang
    co = max(8, int(round(it["size"] * PX / 72)))
    f = font(co)
    fb = font(co, True)

    for i in range(so_hang):
        hang_y = y + i * cao_hang
        nen = it["head_fill"] if i == 0 else (CARD if i % 2 else it["zebra"])
        draw.rectangle([x, hang_y, x + w, hang_y + cao_hang],
                       fill=mau(nen, (255, 255, 255)), outline=mau("DCE4F0"), width=1)
        cx = x
        du_lieu = it["headers"] if i == 0 else it["rows"][i - 1]
        for j, chu in enumerate(du_lieu):
            chu = str(chu)
            f_dung = fb if i == 0 else f
            mau_chu = (255, 255, 255) if i == 0 else mau("1B2733")
            dong = ngat_dong(draw, chu, f_dung, rong_cot[j] - 16)
            ty = hang_y + (cao_hang - len(dong) * co * 1.25) / 2
            for d in dong:
                draw.text((cx + 8, ty), d, font=f_dung, fill=mau_chu, anchor="la")
                ty += co * 1.25
            cx += rong_cot[j]


def ve_anh(canvas, it):
    x, y = int(it["x"] * PX), int(it["y"] * PX)
    w, h = int(it["w"] * PX), int(it["h"] * PX)
    try:
        anh = Image.open(it["path"]).convert("RGB").resize((max(1, w), max(1, h)))
        canvas.paste(anh, (x, y))
    except Exception as loi:  # ảnh thiếu thì bỏ qua, không làm hỏng cả tệp
        print("  ! không vẽ được ảnh", it["path"], loi)


def ve_slide(ds):
    canvas = Image.new("RGB", (int(13.333 * PX), int(7.5 * PX)), (255, 255, 255))
    draw = ImageDraw.Draw(canvas)

    # nền và các khối màu trước
    for it in ds:
        if it["k"] == "rect":
            x, y = it["x"] * PX, it["y"] * PX
            w, h = it["w"] * PX, it["h"] * PX
            hop = [x, y, x + w, y + h]
            if it["fill"] or it["line"]:
                if it["round"]:
                    draw.rounded_rectangle(hop, radius=min(w, h) * min(0.5, it["round"] / max(0.01, min(it["w"], it["h"]))),
                                           fill=mau(it["fill"], (255, 255, 255)) if it["fill"] else None,
                                           outline=mau(it["line"], (220, 228, 240)) if it["line"] else None,
                                           width=max(1, int(it["lw"] * PX / 72)))
                else:
                    draw.rectangle(hop,
                                   fill=mau(it["fill"], (255, 255, 255)) if it["fill"] else None,
                                   outline=mau(it["line"], (220, 228, 240)) if it["line"] else None,
                                   width=max(1, int(it["lw"] * PX / 72)))
        elif it["k"] == "pic":
            ve_anh(canvas, it)

    for it in ds:
        if it["k"] == "text":
            ve_chu(draw, it)
        elif it["k"] == "table":
            ve_bang(draw, it)

    return canvas


def main():
    with open(MO_HINH, encoding="utf-8") as f:
        mo_hinh = json.load(f)

    tai_lieu = fitz.open()
    for i, ds in enumerate(mo_hinh["slides"], start=1):
        canvas = ve_slide(ds)
        tep_tam = os.path.join(GOC, f".slide_{i:02d}.png")
        canvas.save(tep_tam)
        trang = tai_lieu.new_page(width=13.333 * 72, height=7.5 * 72)
        trang.insert_image(trang.rect, filename=tep_tam)
        os.remove(tep_tam)
        print(f"  slide {i:02d}")

    tai_lieu.save(OUT, deflate=True)
    print("OK", os.path.basename(OUT), f"({len(mo_hinh['slides'])} trang)")


if __name__ == "__main__":
    main()
