namespace QuanLyCuaHangDienThoai
{
    partial class FormBaoCao
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControl1        = new System.Windows.Forms.TabControl();
            tabDoanhThu        = new System.Windows.Forms.TabPage();
            dgvDoanhThu        = new System.Windows.Forms.DataGridView();
            lblTongDoanhThu    = new System.Windows.Forms.Label();
            tabTonKho          = new System.Windows.Forms.TabPage();
            dgvTonKho          = new System.Windows.Forms.DataGridView();
            lblTongTonKho      = new System.Windows.Forms.Label();
            tabTopBanChay      = new System.Windows.Forms.TabPage();
            dgvTopBanChay      = new System.Windows.Forms.DataGridView();
            panelBottom        = new System.Windows.Forms.Panel();
            btnXuatExcel       = new System.Windows.Forms.Button();
            btnLamMoi          = new System.Windows.Forms.Button();
            btnDong            = new System.Windows.Forms.Button();
            lblTitle           = new System.Windows.Forms.Label();

            // tabControl1
            tabControl1.Controls.Add(tabDoanhThu);
            tabControl1.Controls.Add(tabTonKho);
            tabControl1.Controls.Add(tabTopBanChay);
            tabControl1.Dock      = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Font      = UiTheme.Than;
            tabControl1.ItemSize  = new System.Drawing.Size(180, 30);
            tabControl1.Padding   = new System.Drawing.Point(14, 5);

            // tabDoanhThu
            tabDoanhThu.BackColor = UiTheme.The;
            tabDoanhThu.Text = "📊 Doanh thu theo tháng";
            tabDoanhThu.Controls.Add(dgvDoanhThu);
            tabDoanhThu.Controls.Add(lblTongDoanhThu);
            tabDoanhThu.Padding = new System.Windows.Forms.Padding(8);

            dgvDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            UiTheme.TrangTriLuoi(dgvDoanhThu);

            lblTongDoanhThu.Dock      = System.Windows.Forms.DockStyle.Bottom;
            lblTongDoanhThu.Height    = 34;
            lblTongDoanhThu.Font      = UiTheme.NhanDam;
            lblTongDoanhThu.ForeColor = UiTheme.ThanhCong;
            lblTongDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblTongDoanhThu.Padding   = new System.Windows.Forms.Padding(6, 0, 0, 0);
            lblTongDoanhThu.Text      = "Đang tải...";

            // tabTonKho
            tabTonKho.BackColor = UiTheme.The;
            tabTonKho.Text = "📦 Tồn kho";
            tabTonKho.Controls.Add(dgvTonKho);
            tabTonKho.Controls.Add(lblTongTonKho);
            tabTonKho.Padding = new System.Windows.Forms.Padding(8);

            dgvTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            UiTheme.TrangTriLuoi(dgvTonKho);

            lblTongTonKho.Dock      = System.Windows.Forms.DockStyle.Bottom;
            lblTongTonKho.Height    = 34;
            lblTongTonKho.Font      = UiTheme.NhanDam;
            lblTongTonKho.ForeColor = UiTheme.Chinh;
            lblTongTonKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblTongTonKho.Padding   = new System.Windows.Forms.Padding(6, 0, 0, 0);
            lblTongTonKho.Text      = "Đang tải...";

            // tabTopBanChay
            tabTopBanChay.BackColor = UiTheme.The;
            tabTopBanChay.Text = "🏆 Top bán chạy";
            tabTopBanChay.Controls.Add(dgvTopBanChay);
            tabTopBanChay.Padding = new System.Windows.Forms.Padding(8);

            dgvTopBanChay.Dock = System.Windows.Forms.DockStyle.Fill;
            UiTheme.TrangTriLuoi(dgvTopBanChay);

            // panelBottom (buttons)
            panelBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Height    = 58;
            panelBottom.Padding   = new System.Windows.Forms.Padding(12, 10, 12, 10);
            panelBottom.BackColor = UiTheme.The;

            btnXuatExcel.Text      = "📄 Xuất Excel";
            btnXuatExcel.Size      = new System.Drawing.Size(140, 36);
            btnXuatExcel.Location  = new System.Drawing.Point(12, 10);
            UiTheme.TrangTriNut(btnXuatExcel, UiTheme.KieuNut.Chinh);

            btnLamMoi.Text      = "🔄 Làm mới";
            btnLamMoi.Size      = new System.Drawing.Size(120, 36);
            btnLamMoi.Location  = new System.Drawing.Point(162, 10);
            UiTheme.TrangTriNut(btnLamMoi, UiTheme.KieuNut.Nhat);

            btnDong.Text      = "✖ Đóng";
            btnDong.Size      = new System.Drawing.Size(110, 36);
            btnDong.Location  = new System.Drawing.Point(292, 10);
            UiTheme.TrangTriNut(btnDong, UiTheme.KieuNut.Nhat);

            // lblTitle
            lblTitle.Text      = "BÁO CÁO THỐNG KÊ CỬA HÀNG ĐIỆN THOẠI";
            lblTitle.Dock      = System.Windows.Forms.DockStyle.Top;
            lblTitle.Height    = 52;
            lblTitle.Font      = UiTheme.TieuDe;
            lblTitle.ForeColor = UiTheme.Chinh;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTitle.BackColor = UiTheme.The;

            // Form
            this.Controls.Add(tabControl1);
            this.Controls.Add(panelBottom);
            this.Controls.Add(lblTitle);
            this.BackColor = UiTheme.Nen;
            this.Font = UiTheme.Than;
            this.ForeColor = UiTheme.Chu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 620);
            this.Padding = new System.Windows.Forms.Padding(0);
        }

        private System.Windows.Forms.TabControl     tabControl1;
        private System.Windows.Forms.TabPage        tabDoanhThu;
        private System.Windows.Forms.TabPage        tabTonKho;
        private System.Windows.Forms.TabPage        tabTopBanChay;
        private System.Windows.Forms.DataGridView   dgvDoanhThu;
        private System.Windows.Forms.DataGridView   dgvTonKho;
        private System.Windows.Forms.DataGridView   dgvTopBanChay;
        private System.Windows.Forms.Label          lblTongDoanhThu;
        private System.Windows.Forms.Label          lblTongTonKho;
        private System.Windows.Forms.Panel          panelBottom;
        private System.Windows.Forms.Button         btnXuatExcel;
        private System.Windows.Forms.Button         btnLamMoi;
        private System.Windows.Forms.Button         btnDong;
        private System.Windows.Forms.Label          lblTitle;
    }
}
