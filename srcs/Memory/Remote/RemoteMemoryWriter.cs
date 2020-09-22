using System;

namespace NProcess.Memory.Remote
{
    public class RemoteMemoryWriter : IMemoryWriter
    {
        private readonly IntPtr handle;

        public RemoteMemoryWriter(IntPtr handle)
        {
            this.handle = handle;
        }
    }
}