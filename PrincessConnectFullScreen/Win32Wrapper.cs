using System;
using System.Runtime.InteropServices;

namespace Hwnd
{
    public class Win32Wrapper
    {
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref RECT rectangle);
        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hwnd, ref RECT rectangle);

        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int WS_BORDER = 0x00800000;
        private const int WS_DLGFRAME = 0x00400000;
        private const int WS_CAPTION = WS_BORDER | WS_DLGFRAME;
        private const int WS_MINIMIZE = 0x20000000;
        private const int WS_MAXIMIZE = 0x1000000;
        private const int WS_SYSMENU = 0x80000;

        private const int SW_MAXIMIZE = 3;
        private const int SW_RESTORE = 9;
        enum WindowLongFlags : int
        {
            GWL_EXSTYLE = -20,
            GWLP_HINSTANCE = -6,
            GWLP_HWNDPARENT = -8,
            GWL_ID = -12,
            GWL_STYLE = -16,
            GWL_USERDATA = -21,
            GWL_WNDPROC = -4,
            DWLP_USER = 0x8,
            DWLP_MSGRESULT = 0x0,
            DWLP_DLGPROC = 0x4
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        public IntPtr GetWindowHandle(string windowClass, string windowName)
        { 
            return FindWindow(windowClass, windowName);
        }

        public bool CheckWindowIsFullScreen(IntPtr windowHandle)
        {
            var winLong = GetWindowLong(windowHandle, (int)WindowLongFlags.GWL_STYLE);
            return ((int)winLong & WS_DLGFRAME) == 0;
        }

        public void FullScreenWindow(IntPtr windowHandle)
        {
            var winLong = GetWindowLong(windowHandle, (int)WindowLongFlags.GWL_STYLE);
            var newStyle = (int) winLong;
            newStyle &= ~(WS_DLGFRAME | WS_MINIMIZE | WS_MAXIMIZE | WS_SYSMENU);
            SetWindowLong(windowHandle, (int)WindowLongFlags.GWL_STYLE, newStyle);
            ShowWindow(windowHandle, SW_MAXIMIZE);
        }

        public void RestoreWindow(IntPtr windowHandle)
        {
            SetWindowMode(windowHandle);
            SetWindowPos(windowHandle, 0, 0, 0, 960, 570, SWP_NOZORDER | SWP_SHOWWINDOW);
        }

        public void ResizeWindow(IntPtr windowHandle, int width, int height)
        {
            SetWindowMode(windowHandle);
            ResizeClientArea(windowHandle, width, height);
        }

        private void SetWindowMode(IntPtr windowHandle)
        {
            var winLong = GetWindowLong(windowHandle, (int)WindowLongFlags.GWL_STYLE);
            var newStyle = (int)winLong;
            newStyle |= (WS_DLGFRAME | WS_MINIMIZE | WS_MAXIMIZE | WS_SYSMENU);
            SetWindowLong(windowHandle, (int)WindowLongFlags.GWL_STYLE, newStyle);
            ShowWindow(windowHandle, SW_RESTORE);
        }

        private void ResizeClientArea(IntPtr windowHandle, int width, int height)
        {
            var windowRect = new RECT();
            var clientRect = new RECT();
            var offset = new POINT();
            GetClientRect(windowHandle, ref clientRect);
            GetWindowRect(windowHandle, ref windowRect);
            offset.X = (windowRect.Right - windowRect.Left) - clientRect.Right;
            offset.Y = (windowRect.Bottom - windowRect.Top) - clientRect.Bottom;
            SetWindowPos(windowHandle, 0, windowRect.Left, windowRect.Top, width + offset.X, height + offset.Y,
                SWP_NOZORDER | SWP_SHOWWINDOW);
        }
    }
}