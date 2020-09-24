using System;
using NProcess.Interop;
using NProcess.Interop.Enum;
using NProcess.Utility;
using NProcess.Window.Keyboard;
using NProcess.Window.Mouse;

namespace NProcess.Window
{
    public class ProcessWindow : IWindow
    {
        public ProcessWindow(IProcess process, IntPtr handle)
        {
            Process = process;
            Handle = handle;
            Keyboard = new MessageBasedKeyboard(this);
            Mouse = new MessageBasedMouse(this);
        }

        public string Title
        {
            get => WindowUtility.GetWindowTitle(Handle);
            set => User32.SetWindowText(Handle, value);
        }

        public bool IsMainWindow => Process.Window == this;
        public IntPtr Handle { get; }
        public IProcess Process { get; }
        public bool IsFocused => User32.GetForegroundWindow() == Handle;
        public IKeyboard Keyboard { get; }
        public IMouse Mouse { get; }

        public void Focus()
        {
            if (IsFocused)
            {
                return;
            }

            /*
             * Just calling SetForegroundWindow won't work in some case according to
             * https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setforegroundwindow
             * that's why we need to minimize and restore to make it work
             */

            User32.ShowWindow(Handle, WindowState.Minimize);
            User32.ShowWindow(Handle, WindowState.Restore);

            User32.SetForegroundWindow(Handle);
        }

        public void Hide()
        {
            User32.ShowWindow(Handle, WindowState.Hide);
        }

        public void Show()
        {
            User32.ShowWindow(Handle, WindowState.Show);
        }

        public void Minimize()
        {
            User32.ShowWindow(Handle, WindowState.Minimize);
        }

        public void Maximize()
        {
            User32.ShowWindow(Handle, WindowState.Maximize);
        }

        public void Restore()
        {
            User32.ShowWindow(Handle, WindowState.Restore);
        }

        public void Dispose()
        {
            Keyboard.Dispose();
            Mouse.Dispose();
        }
    }
}