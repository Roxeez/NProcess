using System;
using System.ComponentModel;

namespace NProcess.Memory.Local
{
    public class LocalMemoryReader : IMemoryReader
    {
        public byte[] Read(IntPtr address, int length)
        {
            var output = new byte[length];
            unsafe
            {
                var bytes = (byte*) address;
                if (bytes == null)
                {
                    throw new Win32Exception();
                }
                
                for (int i = 0; i < length; i++)
                {
                    output[i] = bytes[i];
                }
            }

            return output;
        }
    }
}