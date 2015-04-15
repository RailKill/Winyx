// Credits to Curtis Rutland for this Hotkey class from a tutorial forum post.

// Rutland, C. (2010). Global Hotkeys - C# Tutorials. [online] Dream.In.Code.
// Available at: http://www.dreamincode.net/forums/topic/180436-global-hotkeys/
// [Accessed 3 Mar 2014].

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Winyx
{
    class Hotkey
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public int modifier { get; set; }
        public Keys key { get; set; }
        private IntPtr hWnd;
        private int id;

        public Hotkey(int modifier, Keys key, Form form)
        {
            this.modifier = modifier;
            this.key = key;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        public override int GetHashCode()
        {
            // Generates a unique ID for the hotkey
            return modifier ^ (int)key ^ hWnd.ToInt32();
        }

        public bool Register()
        {
            // Register as global hotkey
            return RegisterHotKey(hWnd, id, modifier, (int)key);
        }

        public bool Unregister()
        {
            // Unregister
            return UnregisterHotKey(hWnd, id);
        }


    }

     public static class HotkeyConstants
    {
        //modifiers
        public const int NOMOD = 0x0000;
        public const int ALT = 0x0001;
        public const int CTRL = 0x0002;
        public const int SHIFT = 0x0004;
        public const int WIN = 0x0008;

        //windows message id for hotkey
        public const int WM_HOTKEY_MSG_ID = 0x0312;
    }

}
