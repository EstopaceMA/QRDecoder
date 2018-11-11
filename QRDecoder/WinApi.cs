using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QRDecoder
{
    public class WinApi
    {

        //Animates the window from left to right
        public const int AW_HOR_POSITIVE = 0x1;

        //Animates the window from right to left
        public const int AW_HOR_NEGATIVE = 0x2;

        //Animates the window from top to bottom
        public const int AW_VER_POSITIVE = 0x4;

        //Animates the window from bottom to top
        public const int AW_VER_NEGATIVE = 0x8;

        public const int AW_CENTER = 0x10;

        public const int AW_HIDE = 0x10000;

        public const int AW_ACTIVATE = 0x20000;

        public const int AW_SLIDE = 0x40000;

        public const int AW_BLEND = 0x80000;


        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        public static extern int AnimateWindow(IntPtr hwand, int dwTime, int dwFlags);
    }
}
