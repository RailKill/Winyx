using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winyx
{
    class Category
    {
        public string CategoryName { get; set; }
        public Window MainWindow { get; set; }

        private List<Window> Windows = new List<Window>();

        public Category(string name, Window window, int capacity)
        {
            CategoryName = name;
            MainWindow = window;
            Windows.Capacity = capacity;
        }

        public Category(string name)
        {
            CategoryName = name;
        }

        public Category(string name, int capacity)
        {
            CategoryName = name;
            Windows.Capacity = capacity;
        }


        public bool AddWindow(Window window)
        {
            if (isFull() || hasWindow(window))
            {
                return false;
            }
            else
            {
                Windows.Add(window);
                return true;
            }
            
        }

        public bool AddtoFirst(Window window)
        {
            if (isFull() || hasWindow(window))
            {
                return false;
            }
            else
            {
                Windows.Reverse();
                Windows.Add(window);
                Windows.Reverse();
                return true;
            }
        }

        public void RemoveWindow(Window window)
        {
            //Windows.Remove(window);
            Windows.RemoveAll(w => w.Handle == window.Handle);
            if (isMainWindow(window)) { SetDefaultMainWindow(); }
        }

        public void RemoveAt(int index)
        {
            Window temp = Windows.ElementAt(index);
            Windows.RemoveAt(index);
            if (isMainWindow(temp)) { SetDefaultMainWindow(); }
        }

        public void SetDefaultMainWindow()
        {
            if (!isEmpty())
            {
                MainWindow = Windows.ElementAt(0);
            }
        }

        public void Clear()
        {
            Windows.Clear();
        }

        public bool isFull()
        {
            if (Windows.Count == Windows.Capacity) { return true; } else { return false; }
        }

        public bool isEmpty()
        {
            if (!Windows.Any()) { return true; } else { return false; }
        }

        public bool isMainWindow(Window window)
        {
            if (MainWindow == null) { return false; }
            if (window.Handle == MainWindow.Handle) { return true; }
            return false;
        }


        public bool hasWindow(Window window)
        {
            for (int i = 0; i < Windows.Count; i++)
            {
                if (Windows[i].Handle == window.Handle) { return true; }
            }
            return false;
        }

        public int numberofWindows()
        {
            return Windows.Count;
        }

        public Window GetWindowAt(int x)
        {
            return Windows.ElementAt(x);
        }


        public IntPtr GetHandleAt(int x)
        {
            return Windows.ElementAt(x).Handle;
        }

        public void SetCapacity(int c)
        {
            Windows.Capacity = c;
        }

        

    }
}
