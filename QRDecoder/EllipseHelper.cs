using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace QRDecoder
{
    internal class EllipseHelper
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public static void SetEllipse<TControl>(TControl control, int ellipse) where TControl : Control
        {
            control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width + 1, control.Height + 1, ellipse, ellipse));
        }
    }
}
