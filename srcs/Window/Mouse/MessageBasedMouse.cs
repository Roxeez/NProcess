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
        
        public void LeftClick(Position position)
        {
            User32.PostMessage(handle, WindowsMessage.LeftButtonDown, new UIntPtr(0x00000001), CreateLParam(position.X, position.Y));
            User32.PostMessage(handle, WindowsMessage.LeftButtonUp, new UIntPtr(0x00000000), CreateLParam(position.X, position.Y));
;        }

        public void RightClick(Position position)
        {
            User32.PostMessage(handle, WindowsMessage.RightButtonDown, new UIntPtr(0x00000001), CreateLParam(position.X, position.Y));
            User32.PostMessage(handle, WindowsMessage.RightButtonUp, new UIntPtr(0x00000000), CreateLParam(position.X, position.Y));
        }

        public void MiddleClick(Position position)
        {
            User32.PostMessage(handle, WindowsMessage.MiddleButtonDown, new UIntPtr(0x00000001), CreateLParam(position.X, position.Y));
            User32.PostMessage(handle, WindowsMessage.MiddleButtonUp, new UIntPtr(0x00000000), CreateLParam(position.X, position.Y));
        }
        
        private static UIntPtr CreateLParam(int x, int y)
        {
            return new UIntPtr((uint)((y << 16) | x));
        }
    }
}