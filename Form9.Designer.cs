using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form9
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
        /// Phần dựng control được tách sang TaoGiaoDien() trong Form9.cs
        /// để màn [Design] của Visual Studio luôn mở được.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(1000, 680);

            Name = "Form9";
            Text = "PHONE STORE - Đăng nhập";

            ResumeLayout(false);
        }

        private Panel panelHeader;
        private Panel panelContent;
        private Label label4;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox txtMatKhau;
        private TextBox txtMaNhanVien;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
