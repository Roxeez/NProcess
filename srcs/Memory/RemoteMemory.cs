﻿using System;
using System.ComponentModel;
using NProcess.Interop;

namespace NProcess.Memory
{
    public sealed class RemoteMemory : MemoryBase
    {
        private readonly IntPtr handle;
        
        public RemoteMemory(IntPtr handle)
        {
            this.handle = handle;
        }
        
        public override byte[] Read(IntPtr address, int length)
        {
            var bytes = new byte[length];
            if (!Kernel32.ReadProcessMemory(handle, address, bytes, bytes.Length, out int count))
            {
                throw new Win32Exception($"Failed to read memory {address}");
            }

            return bytes;
        }
    }
}