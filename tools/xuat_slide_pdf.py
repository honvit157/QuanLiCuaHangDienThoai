"""Render a .pptx deck to a readable PDF (text only) without LibreOffice.

Dung khi may khong co PowerPoint/LibreOffice: moi slide ve lai thanh mot trang
anh 1600x900 roi gop thanh PDF de xem tren dien thoai.
"""
import os
import textwrap
from PIL import Image, ImageDraw, ImageFont
from pptx import Presentation
import fitz  # PyMuPDF

SRC = "ThuyetTrinh_BTL_QuanLyCuaHangDienThoai.pptx"
OUT_PDF = "ThuyetTrinh_BTL_QuanLyCuaHangDienThoai.pdf"
TMP = "build/slides_png"

FONT_R = "/usr/share/fonts/truetype/liberation/LiberationSans-Regular.ttf"
FONT_B = "/usr/share/fonts/truetype/liberation/LiberationSans-Bold.ttf"
FONT_I = "/usr/share/fonts/truetype/liberation/LiberationSans-Italic.ttf"

NAVY = (31, 58, 95)
LIGHT = (245, 247, 250)
DARK = (34, 49, 63)
GRAY = (107, 124, 147)
ACCENT = (46, 134, 222)

W, H = 1600, 900
M = 90


def lines_of(frame):
    out = []
    for p in frame.paragraphs:
        t = "".join(r.text for r in p.runs).strip()
        lvl = p.level or 0
        if not t:
            continue
        out.append((lvl, t))
    return out


def wrap(draw, text, font, maxw):
    words = text.split()
    lines, cur = [], ""
    for w in words:
        trial = (cur + " " + w).strip()
        if draw.textlength(trial, font=font) <= maxw:
            cur = trial
        else:
            if cur:
                lines.append(cur)
            cur = w
    if cur:
        lines.append(cur)
    return lines


def render():
    prs = Presentation(SRC)
    os.makedirs(TMP, exist_ok=True)
    paths = []
    for idx, slide in enumerate(prs.slides, 1):
        img = Image.new("RGB", (W, H), LIGHT)
        d = ImageDraw.Draw(img)
        # top band
        d.rectangle([0, 0, W, 12], fill=NAVY)
        # footer
        d.line([M, H - 70, W - M, H - 70], fill=(220, 226, 235), width=2)
        f_page = ImageFont.truetype(FONT_R, 24)
        d.text((W - M - 60, H - 58), f"{idx}", font=f_page, fill=GRAY)
        d.text((M, H - 58), "BTL Lập trình trực quan — Quản lý cửa hàng điện thoại", font=f_page, fill=GRAY)

        blocks = []
        for sh in slide.shapes:
            if not sh.has_text_frame:
                continue
            ls = lines_of(sh.text_frame)
            if ls:
                blocks.append((sh.top or 0, sh.left or 0, ls))

        blocks.sort()
        y = M + 10
        first = True
        for top, left, ls in blocks:
            if y > H - 130:
                break
            if first:
                # Title block
                title_lines = []
                for lvl, t in ls:
                    for ln in wrap(d, t, ImageFont.truetype(FONT_B, 46), W - 2 * M):
                        title_lines.append(ln)
                f = ImageFont.truetype(FONT_B, 46)
                for ln in title_lines[:3]:
                    d.text((M, y), ln, font=f, fill=NAVY)
                    y += 58
                # subtitle: rest of the same block
                rest = ls[1:] if len(ls) > 1 else []
                if rest:
                    fsub = ImageFont.truetype(FONT_I, 28)
                    for lvl, t in rest:
                        for ln in wrap(d, t, fsub, W - 2 * M):
                            d.text((M, y), ln, font=fsub, fill=ACCENT)
                            y += 38
                y += 18
                d.line([M, y, M + 160, y], fill=ACCENT, width=5)
                y += 28
                first = False
                continue
            # body block
            f = ImageFont.truetype(FONT_R, 30)
            fb = ImageFont.truetype(FONT_B, 30)
            for lvl, t in ls:
                if y > H - 130:
                    break
                indent = M + 30 * lvl
                maxw = W - M - indent - 20
                bullet = "•" if lvl == 0 else "–"
                wl = wrap(d, t, f, maxw - 34)
                d.text((indent, y), bullet, font=f, fill=ACCENT)
                for j, ln in enumerate(wl):
                    if y > H - 130:
                        break
                    d.text((indent + 34, y), ln, font=f, fill=DARK)
                    y += 40
                y += 6
            y += 12

        img.thumbnail((1280, 720))
        p = os.path.join(TMP, f"slide-{idx:02d}.jpg")
        img.save(p, quality=78, optimize=True)
        paths.append(p)

    doc = fitz.open()
    for p in paths:
        page = doc.new_page(width=960, height=540)
        page.insert_image(page.rect, filename=p)
    doc.save(OUT_PDF, deflate=True, garbage=4)
    doc.close()
    print(f"OK {OUT_PDF} ({len(paths)} trang)")


if __name__ == "__main__":
    render()
