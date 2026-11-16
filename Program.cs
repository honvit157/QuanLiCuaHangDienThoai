using System;
using System.Windows.Forms;
using Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4.GUI;   // Các biểu mẫu nằm trong thư mục GUI/

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form9());
        }
    }
}