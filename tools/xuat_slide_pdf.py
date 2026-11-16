"""Render a .pptx deck to a readable PDF (text only) without LibreOffice.

Dung khi may khong co PowerPoint/LibreOffice: moi slide ve lai thanh mot trang
anh 1600x900 roi gop thanh PDF de xem tren dien thoai.

Quy uoc ve lai:
  - Khoi nam trong dai tieu de (phia tren) duoc ve co lon, dam.
  - Cac khoi con lai ve than bai, tu dong xuong dong, khong lap lai bullet
    neu doan van da bat dau bang ky hieu bullet.
  - Bo qua o chi chua so trang.
"""
import io
import os
import re
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
EMU_PER_PX = 7620  # 914400 EMU/inch / 120 px/inch


def lines_of(frame):
    out = []
    for p in frame.paragraphs:
        t = "".join(r.text for r in p.runs).strip()
        if not t:
            continue
        out.append((p.level or 0, t))
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


def is_page_number(text):
    return bool(re.fullmatch(r"\d{1,3}", text.strip()))


def render():
    prs = Presentation(SRC)
    os.makedirs(TMP, exist_ok=True)
    paths = []

    for idx, slide in enumerate(prs.slides, 1):
        img = Image.new("RGB", (W, H), LIGHT)
        d = ImageDraw.Draw(img)

        d.rectangle([0, 0, W, 12], fill=NAVY)
        d.line([M, H - 70, W - M, H - 70], fill=(220, 226, 235), width=2)
        f_small = ImageFont.truetype(FONT_R, 24)
        d.text((W - M - 40, H - 58), f"{idx}", font=f_small, fill=GRAY)
        d.text((M, H - 58), "BTL Lập trình trực quan — Quản lý cửa hàng điện thoại",
               font=f_small, fill=GRAY)

        # Dán các hình ảnh (sơ đồ) vào đúng vị trí tương ứng trên slide
        for sh in slide.shapes:
            if sh.shape_type != 13:  # 13 = PICTURE
                continue
            try:
                anh = Image.open(io.BytesIO(sh.image.blob)).convert("RGB")
            except Exception:
                continue
            trai = (sh.left or 0) // EMU_PER_PX
            tren = (sh.top or 0) // EMU_PER_PX
            rong = (sh.width or 0) // EMU_PER_PX
            cao = (sh.height or 0) // EMU_PER_PX
            if rong <= 0 or cao <= 0:
                continue
            ti_le = min(rong / anh.width, cao / anh.height)
            moi = anh.resize((max(1, int(anh.width * ti_le)), max(1, int(anh.height * ti_le))))
            img.paste(moi, (trai, tren))

        blocks = []
        for sh in slide.shapes:
            if sh.shape_type == 13 or not sh.has_text_frame:
                continue
            ls = lines_of(sh.text_frame)
            if not ls:
                continue
            if len(ls) == 1 and is_page_number(ls[0][1]):
                continue
            blocks.append(((sh.top or 0) // EMU_PER_PX, (sh.left or 0) // EMU_PER_PX, ls))

        blocks.sort()

        co_dai_tieu_de = any(top < 130 for top, _left, _ls in blocks)
        y = 58 if co_dai_tieu_de else 250
        f_title = ImageFont.truetype(FONT_B, 36)
        f_sub = ImageFont.truetype(FONT_I, 21)

        for top, left, ls in blocks:
            in_header = top < 130
            if in_header:
                for j, (lvl, t) in enumerate(ls):
                    font = f_title if j == 0 else f_sub
                    colour = NAVY if j == 0 else ACCENT
                    step = 40 if j == 0 else 26
                    for ln in wrap(d, t, font, W - 2 * M):
                        if y > H - 120:
                            break
                        d.text((M, y), ln, font=font, fill=colour)
                        y += step
                y += 4
                d.line([M, y, M + 150, y], fill=ACCENT, width=5)
                y += 18
                continue

            # khối nội dung: giữ đúng vị trí ngang của hộp văn bản trên slide
            if not co_dai_tieu_de:
                # slide bìa / slide cảm ơn: canh giữa
                for j, (lvl, t) in enumerate(ls):
                    font = f_title if j == 0 else ImageFont.truetype(FONT_R, 26)
                    for ln in wrap(d, t, font, W - 2 * M):
                        w = d.textlength(ln, font=font)
                        d.text(((W - w) / 2, y), ln, font=font, fill=NAVY if j == 0 else DARK)
                        y += 56 if j == 0 else 38
                    y += 10
                continue

            x = max(150, left + 20)
            if x > W - 250:
                x = max(M, W - 250)
            maxw = W - x - 40
            if y < top:
                y = top
            co_body = 23 if maxw < 620 else 26
            f_body = ImageFont.truetype(FONT_R, co_body)
            f_body_b = ImageFont.truetype(FONT_B, co_body + 1)

            for j, (lvl, t) in enumerate(ls):
                if y > H - 120:
                    break
                font = f_body_b if (j == 0 and len(ls) > 1) else f_body
                indent = x + 24 * lvl
                text = t.lstrip("•–- ").strip()
                if not text:
                    continue
                for k, ln in enumerate(wrap(d, text, font, maxw - 24 * lvl - 26)):
                    if y > H - 120:
                        break
                    if k == 0:
                        d.text((indent, y), "•", font=f_body, fill=ACCENT)
                    d.text((indent + 24, y), ln, font=font, fill=DARK)
                    y += co_body + 8
                y += 4
            y += 10

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
