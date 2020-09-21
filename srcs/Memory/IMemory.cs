using System;

namespace NProcess.Memory
{
    /// <summary>
    /// Class used to do some memory manipulation (read/write)
    /// </summary>
    public interface IMemory
    {
        /// <summary>
        /// Read bytes from memory
        /// </summary>
        /// <param name="address">Address where bytes need to be read</param>
        /// <param name="length">Amount of byte to read</param>
        /// <returns>Bytes read</returns>
        byte[] Read(IntPtr address, int length);
        
        /// <summary>
        /// Read a specific type from memory
        /// </summary>
        /// <param name="address">Address where you want to read</param>
        /// <typeparam name="T">Type of value stored at this memory address</typeparam>
        /// <returns>Value found or default if none</returns>
        T Read<T>(IntPtr address);
        
        /// <summary>
        /// Read a specific type from memory at defined pointer
        /// </summary>
        /// <param name="address">Address where you want to read</param>
        /// <param name="offsets">Offsets to find address</param>
        /// <typeparam name="T">Type of value stored at this memory address</typeparam>
        /// <returns>Value found or default if none</returns>
        T Read<T>(IntPtr address, params byte[] offsets);
    }
}