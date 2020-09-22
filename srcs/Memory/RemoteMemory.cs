using System;
using System.ComponentModel;
using NProcess.Interop;

namespace NProcess.Memory
{
    public class RemoteMemory : IMemory
    {
        private readonly IntPtr handle;

        public RemoteMemory(IntPtr handle)
        {
            this.handle = handle;
        }

        public byte[] Read(IntPtr address, int length)
        {
            var bytes = new byte[length];
            if (!Kernel32.ReadProcessMemory(handle, address, bytes, bytes.Length, out int count) || count != length)
            {
                throw new Win32Exception($"Failed to read memory {address}");
            }

            return bytes;
        }

        public void Write(IntPtr address, byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}