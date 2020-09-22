using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NProcess.Extension;
using NProcess.Interop;
using NProcess.Interop.Enum;

namespace NProcess.Window.Keyboard
{
    public class NProcessKeyboard : IKeyboard
    {
        private readonly IntPtr handle;
        private readonly HashSet<Key> holdKeys;

        public NProcessKeyboard(IntPtr handle)
        {
            this.handle = handle;
            holdKeys = new HashSet<Key>();
        }

        public void PressKey(Key key)
        {
            User32.PostMessage(handle, WindowsMessage.KeyDown, new UIntPtr((uint)key), key.CreateLParam(false));
            User32.PostMessage(handle, WindowsMessage.KeyUp, new UIntPtr((uint)key), key.CreateLParam(true));
        }

        public void HoldKey(Key key)
        {
            if (holdKeys.Contains(key))
            {
                return;
            }

            holdKeys.Add(key);

            User32.PostMessage(handle, WindowsMessage.KeyDown, new UIntPtr((uint)key), key.CreateLParam(false));
        }

        public void HoldKey(Key key, TimeSpan time)
        {
            if (holdKeys.Contains(key))
            {
                return;
            }

            holdKeys.Add(key);

            User32.PostMessage(handle, WindowsMessage.KeyDown, new UIntPtr((uint)key), key.CreateLParam(false));

            Task.Delay(time).ContinueWith(x => { ReleaseKey(key); });
        }

        public void ReleaseKey(Key key)
        {
            if (!holdKeys.Contains(key))
            {
                return;
            }

            User32.PostMessage(handle, WindowsMessage.KeyUp, new UIntPtr((uint)key), key.CreateLParam(true));

            holdKeys.Remove(key);
        }
    }
}