using System;

namespace NProcess.Memory
{
    /// <summary>
    ///     Class used to read/write into memory
    /// </summary>
    public interface IMemory
    {
        /// <summary>
        ///     Read bytes from memory
        /// </summary>
        /// <param name="address">Address where bytes need to be read</param>
        /// <param name="length">Amount of byte to read</param>
        /// <returns>Bytes read</returns>
        byte[] Read(IntPtr address, int length);

        /// <summary>
        ///     Write bytes to memory
        /// </summary>
        /// <param name="address">Address where bytes need to be write</param>
        /// <param name="bytes">Bytes to write</param>
        void Write(IntPtr address, byte[] bytes);
    }
}