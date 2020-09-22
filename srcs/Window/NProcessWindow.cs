using System;
using NProcess.Interop;
using NProcess.Interop.Enum;
using NProcess.Utility;

namespace NProcess.Window
{
    public class NProcessWindow : IWindow
    {
        private readonly IntPtr handle;

        public NProcessWindow(IntPtr handle)
        {
            this.handle = handle;
        }

        public string Title
        {
            get => WindowUtility.GetWindowTitle(handle);
            set => User32.SetWindowText(handle, value);
        }
        

        public void Focus()
        {
            if (User32.GetForegroundWindow() == handle)
            {
                return;
            }
            
            /*
             * Just calling SetForegroundWindow won't work in some case according to
             * https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setforegroundwindow
             * that's why we need to minimize and restore to make it work
             */

            User32.ShowWindow(handle, WindowState.Minimize);
            User32.ShowWindow(handle, WindowState.Restore);

            User32.SetForegroundWindow(handle);
        }

        public void Hide()
        {
            User32.ShowWindow(handle, WindowState.Hide);
        }

        public void Show()
        {
            User32.ShowWindow(handle, WindowState.Show);
        }

        public void Minimize()
        {
            User32.ShowWindow(handle, WindowState.Minimize);
        }

        public void Maximize()
        {
            User32.ShowWindow(handle, WindowState.Maximize);
        }

        public void Restore()
        {
            User32.ShowWindow(handle, WindowState.Restore);
        }
    }
}