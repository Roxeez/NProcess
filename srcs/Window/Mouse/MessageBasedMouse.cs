using System;
using NProcess.Interop;
using NProcess.Interop.Enum;

namespace NProcess.Window.Mouse
{
    public class MessageBasedMouse : IMouse
    {
        private readonly IntPtr handle;

        public MessageBasedMouse(IntPtr handle)
        {
            this.handle = handle;
        }
        
        public void LeftClick(Position point)
        {
            User32.PostMessage(handle, WindowsMessage.LeftButtonDown, new UIntPtr(0x00000001), CreateLParam(point.X, point.Y));
            User32.PostMessage(handle, WindowsMessage.LeftButtonUp, new UIntPtr(0x00000000), CreateLParam(point.X, point.Y));
;        }

        public void RightClick(Position point)
        {
            User32.PostMessage(handle, WindowsMessage.RightButtonDown, new UIntPtr(0x00000001), CreateLParam(point.X, point.Y));
            User32.PostMessage(handle, WindowsMessage.RightButtonUp, new UIntPtr(0x00000000), CreateLParam(point.X, point.Y));
        }

        public void MiddleClick(Position point)
        {
            User32.PostMessage(handle, WindowsMessage.MiddleButtonDown, new UIntPtr(0x00000001), CreateLParam(point.X, point.Y));
            User32.PostMessage(handle, WindowsMessage.MiddleButtonUp, new UIntPtr(0x00000000), CreateLParam(point.X, point.Y));
        }
        
        private static UIntPtr CreateLParam(int x, int y)
        {
            return new UIntPtr((uint)((y << 16) | x));
        }
    }
}