"""
Bộ công cụ dựng tài liệu Word (python-docx) cho báo cáo bài tập lớn.

Cung cấp lớp DocBuilder với các hàm tiện dụng: tiêu đề chương/mục, đoạn văn,
bảng biểu có tên bảng đặt phía trên, hình vẽ có tên hình đặt phía dưới,
khối mã nguồn, ngắt trang, mục lục tự động và đánh số trang ở chân trang.
"""

from docx import Document
from docx.enum.section import WD_SECTION
from docx.enum.table import WD_TABLE_ALIGNMENT
from docx.enum.text import WD_ALIGN_PARAGRAPH, WD_BREAK
from docx.oxml import OxmlElement
from docx.oxml.ns import qn, nsdecls
from docx.shared import Cm, Pt, RGBColor
from docx.oxml import parse_xml

FONT = "Times New Roman"
MAU_TIEU_DE = RGBColor(0x1F, 0x3B, 0x63)
MAU_PHU = RGBColor(0x1F, 0x4E, 0x79)


def _dat_font(run, ten=FONT, co=13, dam=False, nghieng=False, mau=None):
    run.font.name = ten
    run.font.size = Pt(co)
    run.font.bold = dam
    run.font.italic = nghieng
    if mau is not None:
        run.font.color.rgb = mau
    # Ép font cho cả ký tự châu Á (giữ nguyên dấu tiếng Việt)
    rpr = run._element.get_or_add_rPr()
    rfonts = rpr.find(qn("w:rFonts"))
    if rfonts is None:
        rfonts = OxmlElement("w:rFonts")
        rpr.append(rfonts)
    rfonts.set(qn("w:ascii"), ten)
    rfonts.set(qn("w:hAnsi"), ten)
    rfonts.set(qn("w:cs"), ten)


def _to_mau_o(cell, ma_mau):
    shd = parse_xml(f'<w:shd {nsdecls("w")} w:fill="{ma_mau}"/>')
    cell._tc.get_or_add_tcPr().append(shd)


def _vien_bang(table):
    tbl = table._tbl
    tblPr = tbl.tblPr
    borders = OxmlElement("w:tblBorders")
    for canh in ("top", "left", "bottom", "right", "insideH", "insideV"):
        el = OxmlElement(f"w:{canh}")
        el.set(qn("w:val"), "single")
        el.set(qn("w:sz"), "4")
        el.set(qn("w:space"), "0")
        el.set(qn("w:color"), "808080")
        borders.append(el)
    tblPr.append(borders)


class DocBuilder:
    """Đối tượng dựng báo cáo, giữ số thứ tự bảng và hình theo chương."""

    def __init__(self, so_chuong_hien_tai=0):
        self.doc = Document()
        self.chuong = so_chuong_hien_tai
        self.ds_bang = []
        self.ds_hinh = []
        self.tat_ca_bang = []
        self.tat_ca_hinh = []
        self._chuan_bi_trang()
        self._chuan_bi_style()

    # ------------------------------------------------------------------
    # Thiết lập chung
    # ------------------------------------------------------------------
    def _chuan_bi_trang(self):
        for sec in self.doc.sections:
            sec.page_width = Cm(21)
            sec.page_height = Cm(29.7)
            sec.top_margin = Cm(2)
            sec.bottom_margin = Cm(2)
            sec.left_margin = Cm(3)
            sec.right_margin = Cm(2)

    def _chuan_bi_style(self):
        st = self.doc.styles["Normal"]
        st.font.name = FONT
        st.font.size = Pt(13)
        st.element.rPr.rFonts.set(qn("w:eastAsia"), FONT)

        for ten, co, dam, nghieng, mau in (
            ("Heading 1", 16, True, False, MAU_TIEU_DE),
            ("Heading 2", 14, True, False, MAU_PHU),
            ("Heading 3", 13, True, True, MAU_PHU),
        ):
            s = self.doc.styles[ten]
            s.font.name = FONT
            s.font.size = Pt(co)
            s.font.bold = dam
            s.font.italic = nghieng
            s.font.color.rgb = mau
            s.paragraph_format.space_before = Pt(12 if ten == "Heading 1" else 8)
            s.paragraph_format.space_after = Pt(6)
            s.paragraph_format.keep_with_next = True

    # ------------------------------------------------------------------
    # Chân trang: số trang
    # ------------------------------------------------------------------
    def danh_so_trang(self):
        for sec in self.doc.sections:
            footer = sec.footer
            p = footer.paragraphs[0]
            p.alignment = WD_ALIGN_PARAGRAPH.CENTER
            run = p.add_run()
            _dat_font(run, co=11)
            fld1 = OxmlElement("w:fldChar")
            fld1.set(qn("w:fldCharType"), "begin")
            instr = OxmlElement("w:instrText")
            instr.set(qn("xml:space"), "preserve")
            instr.text = " PAGE "
            fld2 = OxmlElement("w:fldChar")
            fld2.set(qn("w:fldCharType"), "end")
            run._r.append(fld1)
            run._r.append(instr)
            run._r.append(fld2)

    # ------------------------------------------------------------------
    # Tiêu đề, đoạn văn
    # ------------------------------------------------------------------
    def chuong_moi(self, so, ten):
        self.chuong = so
        self.ds_bang = []
        self.ds_hinh = []
        self.doc.add_heading(f"CHƯƠNG {so}. {ten}", level=1)

    def h(self, cap, text):
        self.doc.add_heading(text, level=cap)

    def p(self, text, dam=False, nghieng=False, canh=WD_ALIGN_PARAGRAPH.JUSTIFY,
          thut_dau=True, co=13, cach_doan=None):
        par = self.doc.add_paragraph()
        par.alignment = canh
        pf = par.paragraph_format
        pf.line_spacing = 1.3
        pf.space_after = Pt(6 if cach_doan is None else cach_doan)
        if thut_dau:
            pf.first_line_indent = Cm(1)
        run = par.add_run(text)
        _dat_font(run, co=co, dam=dam, nghieng=nghieng)
        return par

    def p_gach(self, text, cap=1):
        """Đoạn văn có gạch đầu dòng mức 1."""
        par = self.doc.add_paragraph(style="List Bullet")
        par.paragraph_format.line_spacing = 1.3
        par.paragraph_format.space_after = Pt(3)
        par.paragraph_format.left_indent = Cm(0.8 + 0.6 * (cap - 1))
        run = par.add_run(text)
        _dat_font(run, co=13)
        return par

    def ghi_chu(self, text):
        par = self.doc.add_paragraph()
        par.alignment = WD_ALIGN_PARAGRAPH.JUSTIFY
        par.paragraph_format.line_spacing = 1.2
        par.paragraph_format.left_indent = Cm(1)
        par.paragraph_format.space_after = Pt(6)
        run = par.add_run(text)
        _dat_font(run, co=11.5, nghieng=True)
        return par

    def ma_nguon(self, text):
        par = self.doc.add_paragraph()
        par.paragraph_format.line_spacing = 1.0
        par.paragraph_format.left_indent = Cm(0.6)
        par.paragraph_format.space_before = Pt(4)
        par.paragraph_format.space_after = Pt(6)
        par.paragraph_format.first_line_indent = Cm(0)
        run = par.add_run(text)
        _dat_font(run, ten="Consolas", co=9.5)
        return par

    # ------------------------------------------------------------------
    # Bảng biểu: tên bảng đặt TRÊN bảng
    # ------------------------------------------------------------------
    def bang(self, ten, tieu_de, du_lieu, do_rong=None, co=11, canh_giua=None, co_caption=True):
        if co_caption:
            nhan = f"Bảng {self.chuong}.{len(self.ds_bang) + 1}"
            self.ds_bang.append((nhan, ten))
            self.tat_ca_bang.append((nhan, ten))

            cap = self.doc.add_paragraph()
            cap.alignment = WD_ALIGN_PARAGRAPH.CENTER
            cap.paragraph_format.space_before = Pt(8)
            cap.paragraph_format.space_after = Pt(3)
            cap.paragraph_format.keep_with_next = True
            run = cap.add_run(f"Bảng {self.chuong}.{len(self.ds_bang)}. {ten}")
            _dat_font(run, co=11.5, dam=True, nghieng=True)
        else:
            cap = self.doc.add_paragraph()
            cap.alignment = WD_ALIGN_PARAGRAPH.CENTER
            cap.paragraph_format.space_before = Pt(8)
            cap.paragraph_format.space_after = Pt(3)
            cap.paragraph_format.keep_with_next = True
            run = cap.add_run(ten)
            _dat_font(run, co=11.5, dam=True, nghieng=True)

        table = self.doc.add_table(rows=1, cols=len(tieu_de))
        table.style = "Table Grid"
        table.alignment = WD_TABLE_ALIGNMENT.CENTER
        _vien_bang(table)

        for j, ten_cot in enumerate(tieu_de):
            o = table.rows[0].cells[j]
            o.text = ""
            par = o.paragraphs[0]
            par.alignment = WD_ALIGN_PARAGRAPH.CENTER
            par.paragraph_format.space_after = Pt(0)
            r = par.add_run(str(ten_cot))
            _dat_font(r, co=co, dam=True)
            _to_mau_o(o, "DCE6F1")

        for dong in du_lieu:
            cells = table.add_row().cells
            for j, gia_tri in enumerate(dong):
                cells[j].text = ""
                par = cells[j].paragraphs[0]
                par.paragraph_format.space_after = Pt(0)
                par.paragraph_format.line_spacing = 1.1
                if canh_giua and j in canh_giua:
                    par.alignment = WD_ALIGN_PARAGRAPH.CENTER
                r = par.add_run("" if gia_tri is None else str(gia_tri))
                _dat_font(r, co=co)

        if do_rong:
            # Bề rộng khả dụng của trang A4 với lề 3 cm / 2 cm là 16 cm:
            # nếu tổng bề rộng vượt quá thì thu nhỏ theo tỉ lệ để bảng không tràn lề.
            tong_rong = sum(do_rong)
            if tong_rong > 16.0:
                do_rong = [rong * 16.0 / tong_rong for rong in do_rong]
            for j, rong in enumerate(do_rong):
                for hang in table.rows:
                    hang.cells[j].width = Cm(rong)

        self.doc.add_paragraph().paragraph_format.space_after = Pt(2)
        return table

    # ------------------------------------------------------------------
    # Hình vẽ: tên hình đặt DƯỚI hình
    # ------------------------------------------------------------------
    def hinh(self, ten, duong_dan, rong_cm=15.5):
        nhan = f"Hình {self.chuong}.{len(self.ds_hinh) + 1}"
        self.ds_hinh.append((nhan, ten))
        self.tat_ca_hinh.append((nhan, ten))

        par = self.doc.add_paragraph()
        par.alignment = WD_ALIGN_PARAGRAPH.CENTER
        par.paragraph_format.space_before = Pt(6)
        par.paragraph_format.space_after = Pt(2)
        par.paragraph_format.keep_with_next = True
        par.add_run().add_picture(duong_dan, width=Cm(rong_cm))

        cap = self.doc.add_paragraph()
        cap.alignment = WD_ALIGN_PARAGRAPH.CENTER
        cap.paragraph_format.space_after = Pt(10)
        run = cap.add_run(f"Hình {self.chuong}.{len(self.ds_hinh)}. {ten}")
        _dat_font(run, co=11.5, dam=True, nghieng=True)

    # ------------------------------------------------------------------
    # Trang, mục lục
    # ------------------------------------------------------------------
    def ngat_trang(self):
        self.doc.add_paragraph().add_run().add_break(WD_BREAK.PAGE)

    def muc_luc(self):
        par = self.doc.add_paragraph()
        run = par.add_run()
        fld_begin = OxmlElement("w:fldChar")
        fld_begin.set(qn("w:fldCharType"), "begin")
        instr = OxmlElement("w:instrText")
        instr.set(qn("xml:space"), "preserve")
        instr.text = ' TOC \\o "1-2" \\h \\z \\u '
        fld_sep = OxmlElement("w:fldChar")
        fld_sep.set(qn("w:fldCharType"), "separate")
        noi_dung = OxmlElement("w:t")
        noi_dung.text = "Nhấn chuột phải vào đây và chọn Update Field (hoặc F9) để dựng mục lục."
        fld_end = OxmlElement("w:fldChar")
        fld_end.set(qn("w:fldCharType"), "end")
        for el in (fld_begin, instr, fld_sep, noi_dung, fld_end):
            run._r.append(el)

    def tai_lieu(self, text):
        """Một dòng trong danh mục sách tham khảo (thụt dòng treo)."""
        par = self.doc.add_paragraph()
        par.alignment = WD_ALIGN_PARAGRAPH.JUSTIFY
        par.paragraph_format.line_spacing = 1.25
        par.paragraph_format.left_indent = Cm(0.9)
        par.paragraph_format.first_line_indent = Cm(-0.9)
        par.paragraph_format.space_after = Pt(4)
        run = par.add_run(text)
        _dat_font(run, co=12)
        return par

    def cap_nhat_truong_khi_mo(self):
        settings = self.doc.settings.element
        el = OxmlElement("w:updateFields")
        el.set(qn("w:val"), "true")
        settings.append(el)

    def luu(self, duong_dan):
        self.doc.save(duong_dan)
