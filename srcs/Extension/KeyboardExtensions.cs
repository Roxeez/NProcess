using System;
using NProcess.Interop;
using NProcess.Interop.Enum;

namespace NProcess.Extension
{
    public static class KeyboardExtensions
    {
        internal static UIntPtr CreateLParam(this Key key, bool keyUp)
        {
            return CreateLParam(key, keyUp, keyUp, 1, false, false);
        }

        private static int Map(this Key key, KeyTranslationType translationType)
        {
            return User32.MapVirtualKey((int)key, translationType);
        }

        internal static UIntPtr CreateLParam(Key key, bool keyUp, bool fRepeat, int cRepeat, bool altDown, bool fExtended)
        {
            uint result = (uint)cRepeat;
            result |= (uint)key.Map(KeyTranslationType.VirtualKeyToScanCode) << 16;
            if (fExtended)
            {
                result |= 0x1000000;
            }

            if (altDown)
            {
                result |= 0x20000000;
            }

            if (fRepeat)
            {
                result |= 0x40000000;
            }

            if (keyUp)
            {
                result |= 0x80000000;
            }

            Console.WriteLine(result);
            return new UIntPtr(result);
        }
    }
}