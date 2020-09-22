using System;

namespace NProcess.Memory
{
    /// <summary>
    /// Class used to do some memory manipulation (read/write)
    /// </summary>
    public interface IMemoryReader
    {
        /// <summary>
        /// Read bytes from memory
        /// </summary>
        /// <param name="address">Address where bytes need to be read</param>
        /// <param name="length">Amount of byte to read</param>
        /// <returns>Bytes read</returns>
        byte[] Read(IntPtr address, int length);
    }
}