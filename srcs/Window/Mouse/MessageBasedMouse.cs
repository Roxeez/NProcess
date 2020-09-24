using System;
using NProcess.Interop;
using NProcess.Interop.Enum;

namespace NProcess.Window.Mouse
{
    public class MessageBasedMouse : IMouse
    {
        private readonly IWindow window;

        public MessageBasedMouse(IWindow window)
        {
            this.window = window;
        }

        public void LeftClick(int x, int y)
        {
            User32.PostMessage(window.Handle, WindowsMessage.LeftButtonDown, new UIntPtr(0x00000001), CreateLParam(x, y));
            User32.PostMessage(window.Handle, WindowsMessage.LeftButtonUp, new UIntPtr(0x00000000), CreateLParam(x, y));
        }

        public void RightClick(int x, int y)
        {
            User32.PostMessage(window.Handle, WindowsMessage.RightButtonDown, new UIntPtr(0x00000001), CreateLParam(x, y));
            User32.PostMessage(window.Handle, WindowsMessage.RightButtonUp, new UIntPtr(0x00000000), CreateLParam(x, y));
        }

        public void MiddleClick(int x, int y)
        {
            User32.PostMessage(window.Handle, WindowsMessage.MiddleButtonDown, new UIntPtr(0x00000001), CreateLParam(x, y));
            User32.PostMessage(window.Handle, WindowsMessage.MiddleButtonUp, new UIntPtr(0x00000000), CreateLParam(x, y));
        }

        private static UIntPtr CreateLParam(int x, int y)
        {
            return new UIntPtr((uint)(y << 16 | x));
        }

        public void Dispose()
        {
            
        }
    }
}