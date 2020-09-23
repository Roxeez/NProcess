using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NProcess.Extension;
using NProcess.Interop;
using NProcess.Interop.Enum;

namespace NProcess.Window.Keyboard
{
    public class MessageBasedKeyboard : IKeyboard
    {
        private readonly IntPtr handle;
        private readonly HashSet<Key> holdKeys;

        public MessageBasedKeyboard(IntPtr handle)
        {
            this.handle = handle;
            holdKeys = new HashSet<Key>();
        }

        public void Send(Key key)
        {
            User32.PostMessage(handle, WindowsMessage.KeyDown, new UIntPtr((uint)key), key.CreateLParam(false));
            User32.PostMessage(handle, WindowsMessage.KeyUp, new UIntPtr((uint)key), key.CreateLParam(true));
        }

        public void Hold(Key key)
        {
            if (holdKeys.Contains(key))
            {
                return;
            }

            holdKeys.Add(key);

            User32.PostMessage(handle, WindowsMessage.KeyDown, new UIntPtr((uint)key), key.CreateLParam(false));
        }

        public void Hold(Key key, TimeSpan time)
        {
            if (holdKeys.Contains(key))
            {
                return;
            }

            holdKeys.Add(key);

            User32.PostMessage(handle, WindowsMessage.KeyDown, new UIntPtr((uint)key), key.CreateLParam(false));

            Task.Delay(time).ContinueWith(x => { Release(key); });
        }

        public void Release(Key key)
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