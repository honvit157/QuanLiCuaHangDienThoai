
namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4.GUI
{
    /// <summary>
    /// Trang Khách hàng (Dashboard khách hàng): xem điện thoại, giỏ hàng, đặt mua,
    /// hóa đơn của tôi và thanh toán.
    /// Toàn bộ giao diện được dựng bằng mã lệnh trong Form12.cs (sidebar, header, thẻ sản phẩm...)
    /// nên phần Designer chỉ giữ khung rỗng chuẩn [Design].
    /// </summary>
    partial class Form12
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        // ==========================================
        // MÃ DO DESIGNER SINH - CHỈ SỬA QUA MÀN [Design]
        // ==========================================

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            SuspendLayout();
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1280, 780);
            Name = "Form12";
            Text = "PHONE STORE - KHÁCH HÀNG";
            ResumeLayout(false);
        }
    }
}
