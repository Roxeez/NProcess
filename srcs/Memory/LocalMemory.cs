using System;
using System.ComponentModel;
using NProcess.Extension;
using NProcess.Interop;
using NProcess.Interop.Enum;

namespace NProcess.Memory
{
    public class LocalMemory : IMemory
    {
        private readonly IntPtr handle;

        public LocalMemory(IntPtr handle)
        {
            this.handle = handle;
        }

        public byte[] Read(IntPtr address, int length)
        {
            var bytes = new byte[length];
            unsafe
            {
                var pointer = (byte*)address;
                if (pointer == null)
                {
                    throw new Win32Exception($"Can't get pointer {address}");
                }

                for (int i = 0; i < length; i++)
                {
                    bytes[i] = pointer[i];
                }
            }

            return bytes;
        }

        public void Write(IntPtr address, byte[] bytes)
        {
            Kernel32.VirtualProtectEx(handle, address, bytes.GetMarshalSize(), MemoryProtection.ExecuteReadWrite, out MemoryProtection originalProtection);
            unsafe
            {
                var pointer = (byte*) address;
                if (pointer == null)
                {
                    throw new Win32Exception($"Can't get pointer {address}");
                }
                for (int i = 0; i < bytes.Length; i++)
                {
                    pointer[i] = bytes[i];
                }
            }
            Kernel32.VirtualProtectEx(handle, address, bytes.GetMarshalSize(), originalProtection, out MemoryProtection ignored);
        }
    }
}