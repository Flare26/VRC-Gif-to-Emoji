using System;
using System.Net;
using System.Windows.Forms;

namespace VRC_Gif_Maker
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // .NET Framework 4.7.2 honors OS defaults, but pin TLS 1.2 so URL imports work on older Windows builds too.
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
