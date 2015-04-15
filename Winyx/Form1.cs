using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Winyx
{
    public partial class Form1 : Form
    {
        // WINYX - WINDOW MANAGEMENT TOOL 2014
        // Coded by: Nicholas Wong Wai Hong
        // This application is created as part of a disseration for
        // University of Greenwich's BSc. Computing programme.

        // DO NOT DISTRIBUTE WITHOUT PERMISSION

        // CREDITS:
        // Credits to Paul Dinham, Curtis Rutland, Bart De Smet and Jani Hartikainen for
        // providing online tutorials and solutions which were adapted and used in the
        // development of this application. Full credits were given and cited on their
        // corresponding code sections.

        // SPECIAL THANKS TO EVAN BROOKS
        // A deviantART user named 'brsev' for creating the Token icon set which was used
        // in this application, free for personal use under the Creative Commons License.
        //
        // Brooks, E. (2009). Token by brsev on deviantART.
        // Available at: http://brsev.deviantart.com/art/Token-128429570
        // [Accessed: 21 Jan 2014].

        // NOTES:
        // Prepare for messy code, no time to clean up, too busy developing.
        // Some functions belong in separate classes, do it next time, for reusability.


        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left, Top, Right, Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }

            public int X
            {
                get { return Left; }
                set { Right -= (Left - value); Left = value; }
            }

            public int Y
            {
                get { return Top; }
                set { Bottom -= (Top - value); Top = value; }
            }

            public int Height
            {
                get { return Bottom - Top; }
                set { Bottom = value + Top; }
            }

            public int Width
            {
                get { return Right - Left; }
                set { Right = value + Left; }
            }

            public System.Drawing.Point Location
            {
                get { return new System.Drawing.Point(Left, Top); }
                set { X = value.X; Y = value.Y; }
            }

            public System.Drawing.Size Size
            {
                get { return new System.Drawing.Size(Width, Height); }
                set { Width = value.Width; Height = value.Height; }
            }

            public static implicit operator System.Drawing.Rectangle(RECT r)
            {
                return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
            }

            public static implicit operator RECT(System.Drawing.Rectangle r)
            {
                return new RECT(r);
            }

            public static bool operator ==(RECT r1, RECT r2)
            {
                return r1.Equals(r2);
            }

            public static bool operator !=(RECT r1, RECT r2)
            {
                return !r1.Equals(r2);
            }

            public bool Equals(RECT r)
            {
                return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
            }

            public override bool Equals(object obj)
            {
                if (obj is RECT)
                    return Equals((RECT)obj);
                else if (obj is System.Drawing.Rectangle)
                    return Equals(new RECT((System.Drawing.Rectangle)obj));
                return false;
            }

            public override int GetHashCode()
            {
                return ((System.Drawing.Rectangle)this).GetHashCode();
            }

            public override string ToString()
            {
                return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        struct TITLEBARINFO
        {
            public const int CCHILDREN_TITLEBAR = 5;
            public uint cbSize;
            public RECT rcTitleBar;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CCHILDREN_TITLEBAR + 1)]
            public uint[] rgstate;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetTitleBarInfo(IntPtr hwnd, ref TITLEBARINFO ti);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int wFlags);
        const short SWP_NOMOVE = 0X2;
        const short SWP_NOSIZE = 1;
        const short SWP_NOZORDER = 0X4;
        const int SWP_SHOWWINDOW = 0x0040;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", ExactSpelling = true)]
        static extern IntPtr GetAncestor(IntPtr hwnd, uint gaFlags);
        const uint GA_PARENT = 1;
        const uint GA_ROOT = 2;
        const uint GA_ROOTOWNER = 3;

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetWindow(IntPtr hWnd, GetWindow_Cmd uCmd);

        enum GetWindow_Cmd : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetLastActivePopup(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref RECT rectangle);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int processId);

        [DllImport("dwmapi.dll", SetLastError = true)]
        static extern int DwmRegisterThumbnail(IntPtr dest, IntPtr src, out IntPtr thumb);

        [DllImport("dwmapi.dll")]
        static extern int DwmUnregisterThumbnail(IntPtr thumb);

        [DllImport("dwmapi.dll")]
        static extern int DwmUpdateThumbnailProperties(IntPtr hThumb, ref DWM_THUMBNAIL_PROPERTIES props);


        [StructLayout(LayoutKind.Sequential)]
        internal struct DWM_THUMBNAIL_PROPERTIES
        {
            public int dwFlags;
            public RECT rcDestination;
            public RECT rcSource;
            public byte opacity;
            public bool fVisible;
            public bool fSourceClientAreaOnly;
        }

        // GET ICON IMPORTS AND CONSTANTS //
        // This section is imported to be used as part of Hartikainen's (2007) code.
        // See GetIcon function for more.
        public const int GCL_HICONSM = -34;
        public const int GCL_HICON = -14;

        public const int ICON_SMALL = 0;
        public const int ICON_BIG = 1;
        public const int ICON_SMALL2 = 2;

        public const int WM_GETICON = 0x7F;

        public static IntPtr GetClassLongPtr(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size > 4)
                return GetClassLongPtr64(hWnd, nIndex);
            else
                return new IntPtr(GetClassLongPtr32(hWnd, nIndex));
        }

        [DllImport("user32.dll", EntryPoint = "GetClassLong")]
        public static extern uint GetClassLongPtr32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetClassLongPtr")]
        public static extern IntPtr GetClassLongPtr64(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        // ICON IMPORTS AND CONSTANTS END //

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        [DllImport("user32.dll", SetLastError = true)]
        static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);
        const int GWL_EXSTYLE = -0x14;
        const int WS_EX_TOOLWINDOW = 0x0080;
        const int STATE_SYSTEM_INVISIBLE = 0x8000;

        const UInt32 WM_CLOSE = 0x0010;

        const int SW_HIDE = 0;
        const int SW_MAXIMIZE = 3;
        const int SW_SHOW = 5;
        const int SW_RESTORE = 9;

        static readonly int DWM_TNP_VISIBLE = 0x8;
        static readonly int DWM_TNP_OPACITY = 0x4;
        static readonly int DWM_TNP_RECTDESTINATION = 0x1;

        const int CATEGORY_LIMIT = 9;
        const int LAYOUT_LIMIT = 4;

        int catIndex = 0;
        int currentcIndex = 0;
        int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
        int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
        Category[] windowGroups = new Category[CATEGORY_LIMIT];
        Category tempGroup = new Category("Temporary");
        Category hiddenGroup = new Category("Hidden");
        List<RadioButton> activeButtons = new List<RadioButton>();
       
        // General Keys //
        private Hotkey autoDockKey, dockUp, dockDown, dockLeft, dockRight,
            dockAltUp, dockAltDown, dockAltLeft, dockAltRight, swapMainKey, restoreKey;
        // Move Window Keys //
        private Hotkey moveLeftKey, moveDownKey, moveUpKey, moveRightKey;
        // Resize Window Keys //
        private Hotkey sizeUpKey, sizeDownKey;
        // Arrange Keys //
        private Hotkey arrangeKey;
        private Hotkey[] arrange = new Hotkey[9];
        // Add Category Keys //
        private Hotkey[] addCat = new Hotkey[9];
        // Close Keys //
        private Hotkey closeKey;
        private Hotkey[] close = new Hotkey[9];
        // Kill Keys //
        private Hotkey killKey;
        private Hotkey[] kill = new Hotkey[9];
        // Show Keys //
        private Hotkey showKey;
        private Hotkey[] show = new Hotkey[9];
        // Hide Keys
        private Hotkey hideKey;
        private Hotkey[] hide = new Hotkey[9];

        private IntPtr[] preview = { IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero };
        private bool autoDock = false;
        private Category[] adWindows = new Category[3];
        private DataHandler data;

        internal DataHandler Data
        {
            get { return data; }
            set { data = value; }
        }
        private Form2 settingsForm;


        public Form1()
        {
            InitializeComponent();
            LoadXML();
            settingsForm = new Form2(this);
            // Set Hidden Group Capacity
            hiddenGroup.SetCapacity(100);
            tempGroup.SetCapacity(100);
            AssignHotkeys();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegisterAllHotkeys();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterAllHotkeys();            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(2000);
            }
        }

        public void LoadXML()
        {
            try
            {
                data = new DataHandler(XDocument.Load("hotkeys.xml"));
            }
            catch (Exception e)
            {
                try
                {
                    DataHandler.InitializeData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex + "\n\nUnable to initialize hotkey data. Try running as Administrator.");
                    System.Environment.Exit(1);
                }
            }
            finally
            {
                if (data == null) { data = new DataHandler(XDocument.Load("hotkeys.xml")); }
            }
        }

        public void AssignHotkeys()
        {
            // Assign General Keys //
            autoDockKey = new Hotkey(data.GetMod("AutodockToggle"), data.GetKey("AutodockToggle"), this);
            dockUp = new Hotkey(data.GetMod("DockUp"), data.GetKey("DockUp"), this);
            dockDown = new Hotkey(data.GetMod("DockDown"), data.GetKey("DockDown"), this);
            dockLeft = new Hotkey(data.GetMod("DockLeft"), data.GetKey("DockLeft"), this);
            dockRight = new Hotkey(data.GetMod("DockRight"), data.GetKey("DockRight"), this);

            dockAltUp = new Hotkey(data.GetMod("DockAlt"), data.GetKey("DockUp"), this);
            dockAltDown = new Hotkey(data.GetMod("DockAlt"), data.GetKey("DockDown"), this);
            dockAltLeft = new Hotkey(data.GetMod("DockAlt"), data.GetKey("DockLeft"), this);
            dockAltRight = new Hotkey(data.GetMod("DockAlt"), data.GetKey("DockRight"), this);
            restoreKey = new Hotkey(data.GetMod("Restore"), data.GetKey("Restore"), this);

            // Assign Move Window Keys //
            moveUpKey = new Hotkey(data.GetMod("MoveUp"), data.GetKey("MoveUp"), this);
            moveDownKey = new Hotkey(data.GetMod("MoveDown"), data.GetKey("MoveDown"), this);
            moveLeftKey = new Hotkey(data.GetMod("MoveLeft"), data.GetKey("MoveLeft"), this);
            moveRightKey = new Hotkey(data.GetMod("MoveRight"), data.GetKey("MoveRight"), this);

            // Assign Size Keys //
            sizeUpKey = new Hotkey(data.GetMod("SizeUp"), data.GetKey("SizeUp"), this);
            sizeDownKey = new Hotkey(data.GetMod("SizeUp"), data.GetKey("SizeDown"), this);

            // Assign Other Keys //
            arrangeKey = new Hotkey(data.GetMod("ArrangeAll"), data.GetKey("ArrangeAll"), this);
            closeKey = new Hotkey(data.GetMod("CloseAll"), data.GetKey("CloseAll"), this);
            killKey = new Hotkey(data.GetMod("KillAll"), data.GetKey("KillAll"), this);
            swapMainKey = new Hotkey(data.GetMod("SwapMainWindow"), data.GetKey("SwapMainWindow"), this);
            showKey = new Hotkey(data.GetMod("ShowAll"), data.GetKey("ShowAll"), this);
            hideKey = new Hotkey(data.GetMod("HideAll"), data.GetKey("HideAll"), this);

            for (int i = 0; i < CATEGORY_LIMIT; i++)
            {
                int j = i + 1;
                arrange[i] = new Hotkey(data.GetMod("ArrangeCategory" + j), data.GetKey("ArrangeCategory" + j), this);
                addCat[i] = new Hotkey(data.GetMod("AddToCategory" + j), data.GetKey("AddToCategory" + j), this);
                close[i] = new Hotkey(data.GetMod("CloseCategory" + j), data.GetKey("CloseCategory" + j), this);
                kill[i] = new Hotkey(data.GetMod("KillCategory" + j), data.GetKey("KillCategory" + j), this);
                show[i] = new Hotkey(data.GetMod("ShowCategory" + j), data.GetKey("ShowCategory" + j), this);
                hide[i] = new Hotkey(data.GetMod("HideCategory" + j), data.GetKey("HideCategory" + j), this);
            } 
        }

        public void RegisterAllHotkeys()
        {
            // Register all the hotkeys
            autoDockKey.Register();

            restoreKey.Register();

            moveUpKey.Register();
            moveDownKey.Register();
            moveLeftKey.Register();
            moveRightKey.Register();
            sizeUpKey.Register();
            sizeDownKey.Register();

            arrangeKey.Register();
            closeKey.Register();
            killKey.Register();
            swapMainKey.Register();
            showKey.Register();
            hideKey.Register();

            for (int i = 0; i < CATEGORY_LIMIT; i++)
            {
                arrange[i].Register();
                addCat[i].Register();
                close[i].Register();
                kill[i].Register();
                show[i].Register();
                hide[i].Register();
            }          
        }

        public void UnregisterAllHotkeys()
        {
            // Unregister all the hotkeys
            autoDockKey.Unregister();
            restoreKey.Unregister();

            moveUpKey.Unregister();
            moveDownKey.Unregister();
            moveLeftKey.Unregister();
            moveRightKey.Unregister();
            sizeUpKey.Unregister();
            sizeDownKey.Unregister();

            arrangeKey.Unregister();
            closeKey.Unregister();
            killKey.Unregister();
            swapMainKey.Unregister();
            showKey.Unregister();
            hideKey.Unregister();

            for (int i = 0; i < CATEGORY_LIMIT; i++)
            {
                arrange[i].Unregister();
                addCat[i].Unregister();
                close[i].Unregister();
                kill[i].Unregister();
                show[i].Unregister();
                hide[i].Unregister();
            }

            if (autoDock)
            {
                dockUp.Unregister();
                dockDown.Unregister();
                dockLeft.Unregister();
                dockRight.Unregister();
                dockAltUp.Unregister();
                dockAltDown.Unregister();
                dockAltLeft.Unregister();
                dockAltRight.Unregister();
            }
        }

        private void Restore()
        {
            this.Show();
            this.WindowState = FormWindowState.Maximized;
            notifyIcon.Visible = false;
            RefreshTable(catIndex);
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Restore();
        }
        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restore();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close ALL windows?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if(result == DialogResult.OK)
            {
                this.WindowState = FormWindowState.Minimized;
                CloseAllWindows();
            }            
        }

        private void btnKillAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to kill ALL processes? Unsaved progress will be lost.", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.OK)
            {
                this.WindowState = FormWindowState.Minimized;
                KillAllWindows();
            }          
        }


        private bool IsAltTabWindow(IntPtr hwnd)
        {
            // Credits to Paul Dinham from Stack Overflow forums for providing C++ source.
            // Code was adapted to work in this particular C# application.

            // Dinham, P. (2011). c++ - Why does EnumWindows return more windows than I expected?, Stack Overflow.
            // Available at: http://stackoverflow.com/questions/7277366/why-does-enumwindows-return-more-windows-than-i-expected
            // [Accessed: 18 Dec 2013].

            TITLEBARINFO ti = new TITLEBARINFO();
            IntPtr hwndTry, hwndWalk = IntPtr.Zero;

            // If the window is hidden, it is not a real window.
            if (!IsWindowVisible(hwnd))
                return false;

            // If it's this application window, then just ignore it altogether.
            if (hwnd == this.Handle)
                return false;

            hwndTry = GetAncestor(hwnd, GA_ROOTOWNER);
            while (hwndTry != hwndWalk)
            {
                hwndWalk = hwndTry;
                hwndTry = GetLastActivePopup(hwndWalk);
                if (IsWindowVisible(hwndTry))
                    break;
            }
            if (hwndWalk != hwnd)
                return false;

            // the following removes some task tray programs and "Program Manager"
            ti.cbSize = (uint)Marshal.SizeOf(ti);
            GetTitleBarInfo(hwnd, ref ti);
            if ((ti.rgstate[0] & STATE_SYSTEM_INVISIBLE) != 0)
                return false;

            // Tool windows should not be displayed either, these do not appear in the
            // task bar.
            if ((GetWindowLong(hwnd, GWL_EXSTYLE) & WS_EX_TOOLWINDOW) != 0)
                return false;

            return true;
        }

        
 
        private void AutoArrange()
        {
            currentcIndex = 0;
            EnumWindows(new EnumWindowsProc(RearrangeWindow), IntPtr.Zero);
        }

        private void CloseAllWindows()
        {
            this.WindowState = FormWindowState.Minimized;
            EnumWindows(new EnumWindowsProc(CloseAll), IntPtr.Zero);
            RefreshTable(catIndex);
        }

        private void KillAllWindows()
        {
            EnumWindows(new EnumWindowsProc(KillAll), IntPtr.Zero);
            RefreshTable(catIndex);
        }

        private void ShowAllWindows()
        {
            this.WindowState = FormWindowState.Minimized;
            EnumWindows(new EnumWindowsProc(ShowAll), IntPtr.Zero);
        }

        private void HideAllWindows()
        {
            EnumWindows(new EnumWindowsProc(HideAll), IntPtr.Zero);
        }

        private bool ZOrderAdd(IntPtr hWnd, IntPtr lParam)
        {
            if (IsAltTabWindow(hWnd))
            {
                // Add windows to temporary group for determining z-order in auto-dock.
                tempGroup.AddWindow(CreateWindow(hWnd));
            }
            return true;
        }

        private bool CloseAll(IntPtr hWnd, IntPtr lParam)
        {
            Window temp = CreateWindow(hWnd);
            if (IsAltTabWindow(hWnd) || hiddenGroup.hasWindow(temp))
            { 
                SendMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                hiddenGroup.RemoveWindow(temp);
            }

            return true;
        }

        private bool KillAll(IntPtr hWnd, IntPtr lParam)
        {
            Window temp = CreateWindow(hWnd);
            if (IsAltTabWindow(hWnd) || hiddenGroup.hasWindow(temp)) 
            {
                int processID;
                GetWindowThreadProcessId(hWnd, out processID);
                hiddenGroup.RemoveWindow(temp);
                Process.GetProcessById(processID).Kill();
            }
            return true;
        }

        private void CloseCat(int index)
        {
            if (windowGroups[index] != null)
            {
                this.WindowState = FormWindowState.Minimized;
                for (int i = 0; i < windowGroups[index].numberofWindows(); i++)
                {
                    Window temp = CreateWindow(windowGroups[index].GetHandleAt(i));
                    SendMessage(temp.Handle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                    hiddenGroup.RemoveWindow(temp);
                }               
            }
            RefreshTable(catIndex);
        }

        private void KillCat(int index)
        {
            if (windowGroups[index] != null)
            {
                for (int i = 0; i < windowGroups[index].numberofWindows(); i++)
                {
                    Window temp = CreateWindow(windowGroups[index].GetHandleAt(i));
                    int processID;
                    GetWindowThreadProcessId(temp.Handle, out processID);
                    hiddenGroup.RemoveWindow(temp);
                    Process.GetProcessById(processID).Kill();
                }
            }
            RefreshTable(catIndex);
        }

        private bool ShowAll(IntPtr hWnd, IntPtr lParam)
        {
            Window temp = CreateWindow(hWnd);
            if (IsAltTabWindow(hWnd) || hiddenGroup.hasWindow(temp)) {
                hiddenGroup.RemoveWindow(temp);
                ShowWindow(hWnd, SW_RESTORE);
                ShowWindow(hWnd, SW_SHOW);
            }
            return true;
        }

        private void ShowCat(int index)
        {
            if (windowGroups[index] != null)
            {
                this.WindowState = FormWindowState.Minimized;
                for (int i = 0; i < windowGroups[index].numberofWindows(); i++)
                {
                    Window temp = CreateWindow(windowGroups[index].GetHandleAt(i));
                    hiddenGroup.RemoveWindow(temp);
                    ShowWindow(temp.Handle, SW_RESTORE);
                    ShowWindow(temp.Handle, SW_SHOW);
                }
            }
        }

        private bool HideAll(IntPtr hWnd, IntPtr lParam)
        {
            if (IsAltTabWindow(hWnd))
            {
                hiddenGroup.AddWindow(CreateWindow(hWnd));
                ShowWindow(hWnd, SW_HIDE);
            }
            return true;
        }

        private void HideCat(int index)
        {
            if (windowGroups[index] != null)
            {
                for (int i = 0; i < windowGroups[index].numberofWindows(); i++)
                {
                    Window temp = CreateWindow(windowGroups[index].GetHandleAt(i));
                    hiddenGroup.AddWindow(temp);
                    ShowWindow(temp.Handle, SW_HIDE);
                }
            }
        }


        private Window CreateWindow(IntPtr hWnd)
        {
            int size = GetWindowTextLength(hWnd) + 1;
            StringBuilder sb = new StringBuilder(size);
            GetWindowText(hWnd, sb, size);
            RECT windowRect = new RECT();
            GetWindowRect(hWnd, ref windowRect);

            Window window = new Window(hWnd, sb.ToString(), windowRect.X, windowRect.Y, windowRect.Width, windowRect.Height);
            return window;
        }


        private bool RearrangeWindow(IntPtr hWnd, IntPtr lParam)
        {
            // THIS FUNCTION IS FOR ARRANGING WINDOWS AND ADDING CATEGORIES
            if (IsAltTabWindow(hWnd))
            {
                Window currentWindow = CreateWindow(hWnd);
                bool alreadyExists = false;

                // Check if window already exists in any category.
                for (int i = 0; i < windowGroups.Length; i++ )
                {
                    if (windowGroups[i] == null)
                    {
                        continue;
                    }
                    else
                    {
                        if (windowGroups[i].hasWindow(currentWindow))
                        {
                            alreadyExists = true;
                        }
                    }
                }

                if (!alreadyExists)
                {
                    // CHECK IF FULL
                    while (windowGroups[currentcIndex] != null)
                    {
                        if (windowGroups[currentcIndex].isFull())
                        {
                            currentcIndex++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    // If the current category is NULL, make this window the main window in the new category.
                    if (windowGroups[currentcIndex] == null)
                    {
                        NewCategory(currentcIndex, currentWindow);
                    }
                    else
                    {                       
                        if (windowGroups[currentcIndex].MainWindow == null || windowGroups[currentcIndex].isEmpty())
                        {
                            // No main window! Assign this window as main window.
                            windowGroups[currentcIndex].MainWindow = currentWindow;
                        }                        
                    }

                    // Add current window to current category.
                    windowGroups[currentcIndex].AddWindow(currentWindow);
                    RearrangeCategory(currentcIndex);

                    // If current category is full, move on to the next.
                    if (windowGroups[currentcIndex].isFull())
                    {
                        currentcIndex++;
                    }
                }
            }

            return true;
        }

        private void RearrangeCategory(int index)
        {
            if (windowGroups[index] == null) { return; }
            UpdateCategories();
            int x = screenWidth / 2;
            int y = 0;
            int number = windowGroups[index].numberofWindows();

            switch (number)
            {
                case 1:
                    // set to cover the whole screen
                    SetWindowPos(windowGroups[index].GetHandleAt(0), IntPtr.Zero, 0, 0, screenWidth, screenHeight, SWP_NOZORDER);
                    break;
                case 2:
                    for (int i = 0; i < number; i++)
                    {
                        // dock to both halves of screen
                        IntPtr currentHandle = windowGroups[index].GetHandleAt(i);
                        if (currentHandle == windowGroups[index].MainWindow.Handle)
                        {
                            SetWindowPos(currentHandle, IntPtr.Zero, 0, 0, x, screenHeight, SWP_NOZORDER);
                        }
                        else
                        {
                            SetWindowPos(currentHandle, IntPtr.Zero, x, y, x, screenHeight, SWP_NOZORDER);
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < number; i++ )
                    {
                        // Dock 1 window left full height, 2 windows right with equally divided heights
                        IntPtr currentHandle = windowGroups[index].GetHandleAt(i);
                        if (currentHandle == windowGroups[index].MainWindow.Handle)
                        {
                            SetWindowPos(currentHandle, IntPtr.Zero, 0, 0, screenWidth / 2, screenHeight, SWP_NOZORDER);
                        }
                        else
                        {
                            SetWindowPos(currentHandle, IntPtr.Zero, x, y, x, screenHeight / 2, SWP_NOZORDER);
                            y += screenHeight / 2;
                        }
                    }
                    break;
                case 4:
                    // ==MAIN + 23:77 LAYOUT START== //
                    for (int i = 0; i < number; i++)
                    {
                        IntPtr currentHandle = windowGroups[index].GetHandleAt(i);
                        if (currentHandle == windowGroups[index].MainWindow.Handle)
                        {
                            SetWindowPos(currentHandle, IntPtr.Zero, 0, 0, screenWidth / 2, screenHeight, SWP_NOZORDER);
                        }
                        else if (y * 2 > screenHeight - y)
                        {
                            SetWindowPos(currentHandle, IntPtr.Zero, x, y, x, screenHeight - y, SWP_NOZORDER);
                        }
                        else
                        {
                            // Plenty of space, continue to place windows in 23:77 ratio.
                            double tempY = (((double)23 / (double)77) * x);
                            int newY = (int)Math.Ceiling(tempY);
                            SetWindowPos(currentHandle, IntPtr.Zero, x, y, x, newY, SWP_NOZORDER);
                            y = y + newY;
                        }
                    }
                    // ==MAIN + 23:77 LAYOUT END== //


                    /*
                    // ==GOLDEN SECTION LAYOUT START== //
                    // FOR TESTING AND CONTROL PURPOSES ONLY, DOES NOT FULLY WORK WITH OTHER FUNCTIONS //
                    double goldenRatio = ((double)1 + (double)Math.Sqrt(5)) / 2;
                    // Height of screen = 1
                    // Width of screen = Golden Ratio        
                    int a = (int)Math.Ceiling((double)screenWidth * (goldenRatio - 1));
                    int b = screenWidth - a;
                    int c = (int)Math.Ceiling((double)screenHeight * (goldenRatio - 1));
                    int d = screenHeight - c;
                    int e = (int)Math.Ceiling((double)b * (goldenRatio - 1));
                    for (int i = 0; i < number; i++)
                    {
                        IntPtr currentHandle = windowGroups[index].GetHandleAt(i);
                        switch (i)
                        {
                            case 0:
                                // 1st window
                                SetWindowPos(currentHandle, IntPtr.Zero, 0, 0, a, screenHeight, SWP_NOZORDER);
                                break;
                            case 1:
                                // 2nd window
                                SetWindowPos(currentHandle, IntPtr.Zero, a, 0, b, c, SWP_NOZORDER);
                                break;
                            case 2:
                                // 3rd window               
                                SetWindowPos(currentHandle, IntPtr.Zero, a + b - e, c, e, d, SWP_NOZORDER);
                                break;
                            case 3:
                                // 4th window
                                SetWindowPos(currentHandle, IntPtr.Zero, a, c, b - e, d, SWP_NOZORDER);
                                break;
                        }
                    }
                    // ==GOLDEN SECTION LAYOUT END== //
                    */

                    break;
                default:
                    break;
            }   
      
        }

        private void MoveActiveWindow(int direction)
        {
            // DIRECTION
            // 0 - Bottom
            // 1 - Right
            // 2 - Top
            // 3 - Left

            Window activeWindow = CreateWindow(GetForegroundWindow());
            if (IsAltTabWindow(activeWindow.Handle))
            {
                int movement = 50;
                switch (direction)
                {
                    case 0:
                        SetWindowPos(activeWindow.Handle, IntPtr.Zero, activeWindow.xPos, activeWindow.yPos + movement, 0, 0, SWP_NOSIZE);
                        break;
                    case 1:
                        SetWindowPos(activeWindow.Handle, IntPtr.Zero, activeWindow.xPos + movement, activeWindow.yPos, 0, 0, SWP_NOSIZE);
                        break;
                    case 2:
                        SetWindowPos(activeWindow.Handle, IntPtr.Zero, activeWindow.xPos, activeWindow.yPos - movement, 0, 0, SWP_NOSIZE);
                        break;
                    case 3:
                        SetWindowPos(activeWindow.Handle, IntPtr.Zero, activeWindow.xPos - movement, activeWindow.yPos, 0, 0, SWP_NOSIZE);
                        break;
                    default:
                        // Do nothing.
                        break;
                }
            }
            
            
        }

        private void ResizeActiveWindow(int x)
        {
            Window activeWindow = CreateWindow(GetForegroundWindow());
            if (IsAltTabWindow(activeWindow.Handle))
            {
                int movement = 50;
                switch (x)
                {
                    case 0:
                        SetWindowPos(activeWindow.Handle, IntPtr.Zero, activeWindow.xPos, activeWindow.yPos, activeWindow.Width + movement, activeWindow.Height + movement, SWP_NOZORDER);
                        break;
                    case 1:
                        SetWindowPos(activeWindow.Handle, IntPtr.Zero, activeWindow.xPos, activeWindow.yPos, activeWindow.Width - movement, activeWindow.Height - movement, SWP_NOZORDER);
                        break;
                    default:
                        // Do nothing.
                        break;
                }
            }   
        }

        private void AddtoGroup(Window window, int categoryIndex)
        {
            if (IsAltTabWindow(window.Handle))
            {
                UpdateCategories();
                if (windowGroups[categoryIndex] == null)
                {
                    NewCategory(categoryIndex, window);
                }

                if (windowGroups[categoryIndex].isEmpty())
                {
                    windowGroups[categoryIndex].MainWindow = window;
                }

                if (windowGroups[categoryIndex].AddWindow(window))
                {
                    // Remove from previous category, if exists.
                    for (int i = 0; i < windowGroups.Length; i++)
                    {
                        if (windowGroups[i] == null || i == categoryIndex)
                        {
                            continue;
                        }
                        else
                        {
                            if (windowGroups[i].hasWindow(window))
                            {
                                windowGroups[i].RemoveWindow(window);
                            }
                        }
                    }

                    UpdateCategories();
                    notifyIcon.ShowBalloonTip(2000, "Added window to category!", "'" + window.Title + "' has been added to " + windowGroups[categoryIndex].CategoryName, ToolTipIcon.None);
                    return;
                }
                else
                {
                    MessageBox.Show(new Form() { TopMost = true }, "Category is full or window already exists.", "Unable to Add Window", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            else
            {
                MessageBox.Show(new Form() { TopMost = true }, "Select a valid active window to be added to the category!", "Error: No Window Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NewCategory(int index, Window main)
        {
            windowGroups[index] = new Category("Category #" + (index + 1), main, LAYOUT_LIMIT);
            windowGroups[index].MainWindow = main;

            // Create CATEGORY button
            Button catButton = new Button();
            catButton.Text = windowGroups[index].CategoryName;
            catButton.Name = "btnCategory" + index;
            catButton.Width = 105;
            catButton.Height = 45;
            catButton.Font = new Font("Century Gothic", 10.0f, FontStyle.Bold);
            catButton.UseVisualStyleBackColor = true;
            catButton.Click += btnCategory_Click;
            toolTips.SetToolTip(catButton, "List all windows in this category.");

            // Create panel for category controls
            TableLayoutPanel catControl = new TableLayoutPanel();
            catControl.Name = "catControl" + index;
            catControl.AutoSize = true;
            catControl.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            catControl.Width = 25;
            catControl.Height = 45;
            catControl.Margin = Padding.Empty;

            // Rename button for category controls
            Button renameButton = new Button();
            renameButton.Name = "btnRenameCat" + index;
            renameButton.Image = Winyx.Properties.Resources.smalledit;
            renameButton.ImageAlign = ContentAlignment.MiddleCenter;
            renameButton.Width = 22;
            renameButton.Height = 22;
            renameButton.UseVisualStyleBackColor = true;
            renameButton.Margin = new Padding(0, 3, 0, 0);
            renameButton.Click += btnRenameCat_Click;
            toolTips.SetToolTip(renameButton, "Rename this category.");

            // Delete category button for category controls
            Button catDelButton = new Button();
            catDelButton.Name = "btnDeleteCat" + index;
            catDelButton.Image = Winyx.Properties.Resources.smalldelete;
            catDelButton.ImageAlign = ContentAlignment.MiddleCenter;
            catDelButton.Width = 22;
            catDelButton.Height = 22;
            catDelButton.UseVisualStyleBackColor = true;
            catDelButton.Margin = Padding.Empty;
            catDelButton.Click += btnDelCat_Click;
            toolTips.SetToolTip(catDelButton, "Delete this category.");

            // Add the controls in their respective places
            panelCategory.Controls.Add(catButton);
            panelCategory.Controls.SetChildIndex(catButton, (2 * index) + 3);
            catControl.Controls.Add(renameButton);
            catControl.Controls.Add(catDelButton);
            panelCategory.Controls.Add(catControl);
            panelCategory.Controls.SetChildIndex(catControl, panelCategory.Controls.GetChildIndex(catButton) + 1);
        }

        private void UpdateCategories()
        {
            // Loop through all categories.
            for (int i = 0; i < windowGroups.Length; i++)
            {
                if (windowGroups[i] != null)
                {
                    int counter = 0;
                    int limit = windowGroups[i].numberofWindows();
                    while (counter < limit)
                    {
                        Window currentWindow = CreateWindow(windowGroups[i].GetHandleAt(counter));
                        // Check if the window still exists.
                        if (!IsAltTabWindow(currentWindow.Handle) && !hiddenGroup.hasWindow(currentWindow))
                        {
                            windowGroups[i].RemoveAt(counter);
                            limit--;
                            // Everytime a window is removed, it automatically shifts the objects up the list.
                            // Don't increment counter because the next object will be shifted to the current index.                        
                        }
                        else
                        {
                            counter++;
                        }
                    }
                }
            }
        }

        private void RefreshTable(int showIndex)
        {            
            previewGrid.Controls.Clear();
            previewGrid.ColumnStyles.Clear();
            activeButtons.Clear();

            // Unregister all thumbnails
            for (int i = 0; i < preview.Length; i++)
            {
                if (preview[i] != IntPtr.Zero) { DwmUnregisterThumbnail(preview[i]); }
            }
            

            // Just another layer of handling for NullException. Maybe use try/catch next time?
            if (windowGroups[showIndex] != null)
            {
                UpdateCategories();
                lblCurrentCat.Text = windowGroups[showIndex].CategoryName;
                int number = windowGroups[showIndex].numberofWindows();

                // Prepare TableLayoutPanel
                for (int i = 0; i < number; i++)
                {
                    Window currentWindow = CreateWindow(windowGroups[showIndex].GetHandleAt(i));
                    FlowLayoutPanel section = new FlowLayoutPanel() { Width = previewGrid.Width / number, Height = (previewGrid.Height - 100) };
                    previewGrid.Controls.Add(section, i, 0);
                    FlowLayoutPanel controls = new FlowLayoutPanel() { Width = previewGrid.Width / number, Height = 100 };


                    Button windowIcon = new Button() { Width = 48, Height = 48, UseVisualStyleBackColor = true };
                    windowIcon.Name = "btnSwitchTo" + i;
                    try
                    {
                        windowIcon.Image = GetIcon(currentWindow.Handle).ToBitmap();
                    }
                    catch (Exception e)
                    {
                        // Null icon, simply leave it and don't assign.
                    }
                    windowIcon.ImageAlign = ContentAlignment.MiddleCenter;
                    windowIcon.Click += windowIcon_Click;
                    controls.Controls.Add(windowIcon);

                    Label tempLabel = new Label();
                    tempLabel.ForeColor = Color.Red;
                    int blah = (previewGrid.Width / number) - 200;
                    tempLabel.MaximumSize = new Size(blah, 0);
                    tempLabel.AutoSize = true;
                    tempLabel.Text = currentWindow.Title;
                    tempLabel.Margin = new Padding(0, 10, 0, 0);
                    controls.Controls.Add(tempLabel);

                    RadioButton makeActive = new RadioButton() { Width = 42, Height = 42, UseVisualStyleBackColor = true };
                    makeActive.Appearance = Appearance.Button;
                    makeActive.Name = "btnMakeActive" + i;
                    makeActive.Image = Winyx.Properties.Resources.blackactive;
                    makeActive.ImageAlign = ContentAlignment.MiddleCenter;
                    if (windowGroups[catIndex].GetHandleAt(i) == windowGroups[catIndex].MainWindow.Handle) { makeActive.Checked = true; }
                    makeActive.Click += btnMakeActive_Click;
                    activeButtons.Add(makeActive);
                    controls.Controls.Add(makeActive);
                   
                    Button closeThis = new Button() { Width = 42, Height = 42, UseVisualStyleBackColor = true };
                    closeThis.Name = "btnCloseThis" + i;
                    closeThis.Image = Winyx.Properties.Resources.blackcross;
                    closeThis.ImageAlign = ContentAlignment.MiddleCenter;
                    closeThis.Click += btnCloseThis_Click;
                    controls.Controls.Add(closeThis);

                    Button killThis = new Button() { Width = 42, Height = 42, UseVisualStyleBackColor = true };
                    killThis.Name = "btnKillThis" + i;
                    killThis.Image = Winyx.Properties.Resources.blackskull;
                    killThis.ImageAlign = ContentAlignment.MiddleCenter;
                    killThis.Click += btnKillThis_Click;
                    controls.Controls.Add(killThis);

                    previewGrid.Controls.Add(controls, i, 1);
                }

                for (int i = 0; i < number; i++)
                {
                    // Credits to Bart De Smet for a wonderful tutorial on DWM API and window previews.
                    // Codes from some parts of the tutorial were taken and modified
                    // to suit this application's purposes.

                    // De Smet, B. (2006). Programming the Windows Vista DWM in C#. [online] B# .NET Blog.
                    // Available at: http://bartdesmet.net/blogs/bart/archive/2006/10/05/4495.aspx
                    // [Accessed 22 Feb 2014].

                    IntPtr thumb;
                    DwmRegisterThumbnail(this.Handle, windowGroups[showIndex].GetHandleAt(i), out thumb);
                    preview[i] = thumb;

                    DWM_THUMBNAIL_PROPERTIES props = new DWM_THUMBNAIL_PROPERTIES();
                    props.dwFlags = DWM_TNP_VISIBLE | DWM_TNP_RECTDESTINATION | DWM_TNP_OPACITY;

                    props.fVisible = true;
                    props.opacity = 255;

                    Control control = previewGrid.GetControlFromPosition(i, 0);
                    // Set position of the window snapshot, with an offset based on the table's position.
                    props.rcDestination = new RECT(control.Left + previewGrid.Location.X, control.Top + previewGrid.Location.Y, control.Right, control.Bottom);

                    DwmUpdateThumbnailProperties(preview[i], ref props);
                }

                
            }             
                        
        }


        protected override void WndProc(ref Message m)
        {
            // Handles all the hotkeys
            if (m.Msg == HotkeyConstants.WM_HOTKEY_MSG_ID)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                int modifier = (int)m.LParam & 0xFFFF;
                if (modifier == arrangeKey.modifier && key == arrangeKey.key)
                {                    
                    AutoArrange();
                }
                else if ((modifier == restoreKey.modifier) && key == restoreKey.key)
                {
                    if (this.WindowState == FormWindowState.Maximized)
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }
                    else
                    {
                        Restore();
                    }                        
                }
                else if ((modifier == closeKey.modifier) && key == closeKey.key)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to close ALL windows?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.OK)
                    {
                        this.WindowState = FormWindowState.Minimized;
                        CloseAllWindows();
                    }  
                }
                else if ((modifier == killKey.modifier) && key == killKey.key)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to kill ALL processes? Unsaved progress will be lost.", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.OK)
                    {
                        this.WindowState = FormWindowState.Minimized;
                        KillAllWindows();
                    } 
                }
                else if ((modifier == moveUpKey.modifier) && key == moveUpKey.key)
                {
                    MoveActiveWindow(2);
                }
                else if ((modifier == moveRightKey.modifier) && key == moveRightKey.key)
                {
                    MoveActiveWindow(1);
                }
                else if ((modifier == moveDownKey.modifier) && key == moveDownKey.key)
                {
                    MoveActiveWindow(0);
                }
                else if ((modifier == moveLeftKey.modifier) && key == moveLeftKey.key)
                {
                    MoveActiveWindow(3);
                }
                else if ((modifier == sizeUpKey.modifier) && key == sizeUpKey.key)
                {
                    ResizeActiveWindow(0);
                }
                else if ((modifier == sizeDownKey.modifier) && key == sizeDownKey.key)
                {
                    ResizeActiveWindow(1);
                }
                else if ((modifier == showKey.modifier) && key == showKey.key)
                {
                    ShowAllWindows();
                }
                else if ((modifier == hideKey.modifier) && key == hideKey.key)
                {
                    HideAllWindows();
                }
                else if ((modifier == swapMainKey.modifier) && key == swapMainKey.key)
                {
                    Window newMain = CreateWindow(GetForegroundWindow());
                    bool alreadyExists = false;
                    int index = 0;

                    // Check if window already exists in any category.
                    for (int i = 0; i < windowGroups.Length; i++)
                    {
                        if (windowGroups[i] == null)
                        {
                            continue;
                        }
                        else
                        {
                            if (windowGroups[i].hasWindow(newMain))
                            {
                                alreadyExists = true;
                                index = i;
                            }
                        }
                    }
                    if (alreadyExists)
                    {                      
                        windowGroups[index].MainWindow = newMain;
                        RearrangeCategory(catIndex);
                    }
                    else { MessageBox.Show(new Form() { TopMost = true }, "The selected window does not exist in any category!"); }
                    
                }
                else if ((modifier == autoDockKey.modifier) && key == autoDockKey.key)
                {
                    if (autoDock)
                    {
                        // Switch off auto-dock.
                        autoDock = false;
                        dockUp.Unregister();
                        dockDown.Unregister();
                        dockLeft.Unregister();
                        dockRight.Unregister();
                        dockAltUp.Unregister();
                        dockAltDown.Unregister();
                        dockAltLeft.Unregister();
                        dockAltRight.Unregister();
                        adWindows[0].Clear();
                        adWindows[1].Clear();
                        adWindows[2].Clear();
                        lblADStatus.Text = "Off";
                        lblADStatus.ForeColor = Color.Red;
                        notifyIcon.ShowBalloonTip(2000, "Autodock is OFF!", "Windows are no longer affected.", ToolTipIcon.None);
                    }
                    else
                    {
                        // Switch on auto-dock.
                        autoDock = true;
                        adWindows[0] = new Category("Left", 8);
                        adWindows[1] = new Category("Middle", 8);
                        adWindows[2] = new Category("Right", 8);
                        dockUp.Register();
                        dockDown.Register();
                        dockLeft.Register();
                        dockRight.Register();
                        dockAltUp.Register();
                        dockAltDown.Register();
                        dockAltLeft.Register();
                        dockAltRight.Register();
                        lblADStatus.Text = "On";
                        lblADStatus.ForeColor = Color.Green;
                        notifyIcon.ShowBalloonTip(2000, "Autodock is ON!", "Windows can now be docked to different parts of the screen.", ToolTipIcon.None);
                    }
                }

                // Auto-dock processing.
                if (autoDock)
                {
                    if ((modifier == dockUp.modifier && key == dockUp.key) || 
                        (modifier == dockDown.modifier && key == dockDown.key) || 
                        (modifier == dockLeft.modifier && key == dockLeft.key) || 
                        (modifier == dockRight.modifier && key == dockRight.key) ||
                        (modifier == dockAltUp.modifier && key == dockAltUp.key) ||
                        (modifier == dockAltDown.modifier && key == dockAltDown.key) ||
                        (modifier == dockAltLeft.modifier && key == dockAltLeft.key) ||
                        (modifier == dockAltRight.modifier && key == dockAltRight.key))
                    {
                        int col = 1;
                        if (key == dockLeft.key)
                        {
                            col = 0;
                        }
                        else if (key == dockRight.key)
                        {
                            col = 2;
                        }

                        Window activeWindow = CreateWindow(GetForegroundWindow());
                        if (IsAltTabWindow(activeWindow.Handle))
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                // If this window already exists in any column, remove it.
                                if (adWindows[i].hasWindow(activeWindow)) { adWindows[i].RemoveWindow(activeWindow); }
                                // Remove non-existent windows from columns.
                                for (int j = 0; j < adWindows[i].numberofWindows(); j++)
                                {
                                    if (!IsAltTabWindow(adWindows[i].GetHandleAt(j))) { adWindows[i].RemoveWindow(adWindows[i].GetWindowAt(j)); }
                                }
                            }

                            // Add the window to the column.
                            if (key == dockUp.key) { adWindows[col].AddtoFirst(activeWindow); }
                            else { adWindows[col].AddWindow(activeWindow); }

                            int xmod = 2;
                            if (!adWindows[1].isEmpty()) { xmod = 3; }

                            // Update all columns.
                            for (int i = 0; i < 3; i++)
                            {
                                int number = adWindows[i].numberofWindows();
                                for (int j = 0; j < number; j++)
                                {
                                    int x = i;
                                    if (xmod == 2 && i == 2) { x = i - 1; }
                                    ShowWindow(adWindows[i].GetHandleAt(j), SW_RESTORE);
                                    SetWindowPos(adWindows[i].GetHandleAt(j), IntPtr.Zero, (screenWidth / xmod) * x, (screenHeight / number) * j, screenWidth / xmod, screenHeight / number, SWP_NOZORDER);
                                }
                            }


                            if (modifier == dockAltUp.modifier || modifier == dockAltDown.modifier || modifier == dockAltLeft.modifier || modifier == dockAltRight.modifier)
                            {
                                // SWITCH TO NEXT WINDOW //
                                EnumWindows(new EnumWindowsProc(ZOrderAdd), IntPtr.Zero);
                                bool isLastWindow = false;
                                IntPtr storedHandle = activeWindow.Handle;
                                IntPtr tempHandle = storedHandle;
                                int counter = 0;

                                // Loop up the Z-Order.
                                while (!isLastWindow)
                                {
                                    IntPtr nextHandle = GetWindow(tempHandle, GetWindow_Cmd.GW_HWNDPREV);

                                    // Is that a window in the group?
                                    if (tempGroup.hasWindow(CreateWindow(nextHandle)))
                                    {
                                        // Yes? Then switch to that window and continue, add to counter.
                                        counter++;
                                        tempHandle = nextHandle;
                                    }
                                    else
                                    {
                                        // No? Then check if it is the top of the Z-Order.
                                        if (nextHandle == null || nextHandle == IntPtr.Zero)
                                        {
                                            // If it is the end, then check if it is equal to the number of windows we have minus one.
                                            if (counter == (tempGroup.numberofWindows() - 1))
                                            {
                                                // If it is equal, it means all other windows are on top of this window, so this is the lowest of the group.                                            
                                                SetForegroundWindow(storedHandle);
                                                isLastWindow = true;
                                            }
                                            else
                                            {
                                                // If it is not equal, means there is still a window below. Loop down the Z-Order until a valid window is found.
                                                IntPtr switcher = GetWindow(storedHandle, GetWindow_Cmd.GW_HWNDNEXT);
                                                while (!tempGroup.hasWindow(CreateWindow(switcher)))
                                                {
                                                    switcher = GetWindow(switcher, GetWindow_Cmd.GW_HWNDNEXT);
                                                }
                                                // Loop exits when found a valid window. Now switch and start over.
                                                storedHandle = switcher;
                                                tempHandle = storedHandle;
                                                counter = 0;
                                            }

                                        }
                                        else
                                        {
                                            // Not the top of the Z-Order, switch and continue, do not add to counter.
                                            tempHandle = nextHandle;
                                        }
                                    }
                                }
                                // Clear the temporary group.
                                tempGroup.Clear();
                            }                           
                        }                                   
                    }
                }

                // Loop through category-based Hotkeys
                for (int i = 0; i < CATEGORY_LIMIT; i++)
                {
                    if (modifier == addCat[i].modifier && key == addCat[i].key)
                    {
                        Window activeWindow = CreateWindow(GetForegroundWindow());
                        AddtoGroup(activeWindow, i);
                        break;
                    }
                    if (modifier == arrange[i].modifier && key == arrange[i].key)
                    {
                        RearrangeCategory(i);
                        break;
                    }
                    if (modifier == show[i].modifier && key == show[i].key)
                    {
                        ShowCat(i);
                        break;
                    }
                    if (modifier == hide[i].modifier && key == hide[i].key)
                    {
                        HideCat(i);
                        break;
                    }
                    if (modifier == close[i].modifier && key == close[i].key)
                    {
                        if (windowGroups[i] == null) { return; }
                        if (windowGroups[i].isEmpty()) { return; }
                        DialogResult result = MessageBox.Show("Are you sure you want to close windows under '" + windowGroups[i].CategoryName + "'?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.OK)
                        {
                            CloseCat(i);
                        }
                        break;
                    }
                    if (modifier == kill[i].modifier && key == kill[i].key)
                    {
                        if (windowGroups[i] == null) { return; }
                        if (windowGroups[i].isEmpty()) { return; }
                        DialogResult result = MessageBox.Show("Are you sure you want to kill processes under '" + windowGroups[i].CategoryName + "'?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.OK)
                        {
                            KillCat(i);
                        }
                        break;
                    }
                }
            }                
            base.WndProc(ref m);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void btnCategory_Click(object sender, EventArgs e)
        {
            Button someButton = sender as Button;
            String s = someButton.Name;
            int groupIndex = (int)Char.GetNumericValue(s[11]);
            catIndex = groupIndex;
            RefreshTable(groupIndex);          
        }

        private void btnDelCat_Click(object sender, EventArgs e)
        {
            Button someButton = sender as Button;
            String s = someButton.Name;
            int groupIndex = (int)Char.GetNumericValue(s[12]);

            windowGroups[groupIndex] = null;

            foreach (Control item in panelCategory.Controls.OfType<TableLayoutPanel>())
            {
                if (item.Name == ("catControl" + groupIndex))
                    panelCategory.Controls.Remove(item);
            }

            foreach (Control item in panelCategory.Controls.OfType<Button>())
            {
                if (item.Name == ("btnCategory" + groupIndex))
                    panelCategory.Controls.Remove(item);
            }

        }

        private void btnRenameCat_Click(object sender, EventArgs e)
        {
            Button someButton = sender as Button;
            String s = someButton.Name;
            int groupIndex = (int)Char.GetNumericValue(s[12]);

            foreach (Control item in panelCategory.Controls.OfType<Button>())
            {
                if (item.Name == ("btnCategory" + groupIndex))
                {
                    TextBox renamer = new TextBox();
                    renamer.Name = "txtRenamer" + groupIndex;
                    renamer.Width = 130;
                    renamer.Text = item.Text;
                    renamer.MaxLength = 20;
                    renamer.KeyUp += Rename_KeyUp;
                    renamer.LostFocus += Rename_LostFocus;
                    panelCategory.Controls.Add(renamer);
                    panelCategory.Controls.SetChildIndex(renamer, panelCategory.Controls.GetChildIndex(item) + 2);
                    toolTips.SetToolTip(renamer, "Enter the name for this category.");
                    renamer.Focus();
                }

            }     
        }

        private void Rename_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox renamer = sender as TextBox;
            String s = renamer.Name;
            int groupIndex = (int)Char.GetNumericValue(s[10]);
            if (e.KeyCode == Keys.Enter)
            {
                foreach (Control item in panelCategory.Controls.OfType<Button>())
                {
                    if (item.Name == ("btnCategory" + groupIndex))
                    {
                        item.Text = renamer.Text;
                        windowGroups[groupIndex].CategoryName = renamer.Text;
                    }
                }
                if (catIndex == groupIndex) { lblCurrentCat.Text = windowGroups[catIndex].CategoryName; }
                panelCategory.Controls.Remove(renamer);
                e.Handled = true;
            }
        }

        private void Rename_LostFocus(object sender, EventArgs e)
        {
            TextBox renamer = sender as TextBox;
            panelCategory.Controls.Remove(renamer);
        }

        private void btnAutoArrange_Click(object sender, EventArgs e)
        {
            AutoArrange();
        }

        private void btnArrangeCat_Click(object sender, EventArgs e)
        {
            RearrangeCategory(catIndex);
        }

        private void btnCloseCat_Click(object sender, EventArgs e)
        {
            if (windowGroups[catIndex] == null) { return; }
            if (windowGroups[catIndex].isEmpty()) { return; }
            DialogResult result = MessageBox.Show("Are you sure you want to close windows under '" + windowGroups[catIndex].CategoryName + "'?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.OK)
            {
                CloseCat(catIndex);
            }
            
        }

        private void btnCloseThis_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            String s = button.Name;
            int groupIndex = (int)Char.GetNumericValue(s[12]);
            Window closingWindow = CreateWindow(windowGroups[catIndex].GetHandleAt(groupIndex));
            DialogResult result = MessageBox.Show("Are you sure you want to close '" + closingWindow.Title + "'?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.OK)
            {
                SendMessage(closingWindow.Handle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                RefreshTable(catIndex);
            }

        }

        private void btnKillThis_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            String s = button.Name;
            int groupIndex = (int)Char.GetNumericValue(s[11]);
            Window killingWindow = CreateWindow(windowGroups[catIndex].GetHandleAt(groupIndex));
            DialogResult result = MessageBox.Show("Are you sure you want to terminate '" + killingWindow.Title + "'? Unsaved progress will be lost.", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.OK)
            {
                int processID;
                GetWindowThreadProcessId(killingWindow.Handle, out processID);
                Process.GetProcessById(processID).Kill();
                RefreshTable(catIndex);
            }
        }

        private void btnKillCat_Click(object sender, EventArgs e)
        {
            if (windowGroups[catIndex] == null) { return; }
            if (windowGroups[catIndex].isEmpty()) { return; }
            DialogResult result = MessageBox.Show("Are you sure you want to kill processes under '" + windowGroups[catIndex].CategoryName + "'?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.OK)
            {
                KillCat(catIndex);
            }
        }

        private void btnMakeActive_Click(object sender, EventArgs e)
        {
            RadioButton button = sender as RadioButton;
            String s = button.Name;
            int groupIndex = (int)Char.GetNumericValue(s[13]);

            if (button.Checked)
            {
                foreach (RadioButton r in activeButtons)
                {
                    if (r == button)
                    {
                        continue;
                    }
                    r.Checked = false;
                }

                Window newMain = CreateWindow(windowGroups[catIndex].GetHandleAt(groupIndex));
                windowGroups[catIndex].MainWindow = newMain;               
                RearrangeCategory(catIndex);
            }
        }

        private void windowIcon_Click(object sender, EventArgs e)
        {
            Button someButton = sender as Button;
            String s = someButton.Name;
            int groupIndex = (int)Char.GetNumericValue(s[11]);
            this.WindowState = FormWindowState.Minimized;
            IntPtr targetHandle = windowGroups[catIndex].GetHandleAt(groupIndex);
            ShowWindow(targetHandle, SW_RESTORE);
            SetForegroundWindow(targetHandle);
            ShowWindow(targetHandle, SW_MAXIMIZE);            
        }


        public Icon GetIcon(IntPtr hwnd)
        {
            // Credits to Jani Hartikainen for ready-made source code on obtaining window icons.
            // It covers every possible method to obtain every possible icon. It is the best solution,
            // I don't think I can even adapt or improve it.

            // Hartikainen, J. (2007). Find an application’s icon with WinAPI. [online] CodeUtopia.
            // Available at: http://codeutopia.net/blog/2007/12/18/find-an-applications-icon-with-winapi/ 
            // [Accessed 22 Feb 2014].

            IntPtr iconHandle = SendMessage(hwnd, WM_GETICON, ICON_SMALL2, 0);
            if (iconHandle == IntPtr.Zero)
                iconHandle = SendMessage(hwnd, WM_GETICON, ICON_SMALL, 0);
            if (iconHandle == IntPtr.Zero)
                iconHandle = SendMessage(hwnd, WM_GETICON, ICON_BIG, 0);
            if (iconHandle == IntPtr.Zero)
                iconHandle = GetClassLongPtr(hwnd, GCL_HICON);
            if (iconHandle == IntPtr.Zero)
                iconHandle = GetClassLongPtr(hwnd, GCL_HICONSM);

            if (iconHandle == IntPtr.Zero)
                return null;

            Icon icn = Icon.FromHandle(iconHandle);

            return icn;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settingsForm.Hide();
            settingsForm.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm.Hide();
            settingsForm.Show();
        }

        private void btnVisible_Click(object sender, EventArgs e)
        {
            if (windowGroups[catIndex] == null) { return; }
            if (windowGroups[catIndex].isEmpty()) { return; }
            ShowCat(catIndex);
        }

        private void btnHidden_Click(object sender, EventArgs e)
        {
            if (windowGroups[catIndex] == null) { return; }
            if (windowGroups[catIndex].isEmpty()) { return; }
            HideCat(catIndex);
        }

        private void saveXML()
        {

        }
    }
}
