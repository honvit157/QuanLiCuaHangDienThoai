using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class FormBaoCao
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Khởi tạo các thuộc tính cơ bản của biểu mẫu.
        /// Phần dựng control được tách sang TaoGiaoDien() trong FormBaoCao.cs
        /// để màn [Design] của Visual Studio luôn mở được.
        /// </summary>
        private void InitializeComponent()
        {

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
