using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winyx
{
    class Window
    {
        public IntPtr Handle { get; set; }
        public int xPos { get; set; }
        public int yPos { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Title { get; set; }

        public Window(IntPtr hWnd, string t, int x, int y, int w, int h)
        {
            Handle = hWnd;
            Title = t;
            xPos = x;
            yPos = y;
            Width = w;
            Height = h;
        }

    }
}
