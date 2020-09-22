using System;

namespace NProcess.Module
{
    /// <summary>
    /// Represent a process module
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Name of the module
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Base address of the module
        /// </summary>
        IntPtr Address { get; }
        
        /// <summary>
        /// Size of the module
        /// </summary>
        int Size { get; }
        
        IProcess Process { get; }
        
        /// <summary>
        /// Read a specific type from memory
        /// </summary>
        /// <param name="address">Address where you want to read</param>
        /// <typeparam name="T">Type of value stored at this memory address</typeparam>
        /// <returns>Value found or default if none</returns>
        T ReadMemory<T>(IntPtr address);

        /// <summary>
        /// Write a specific type to memory
        /// </summary>
        /// <param name="address">Address where you want to write</param>
        /// <param name="value">Value to write</param>
        /// <typeparam name="T">Value type</typeparam>
        void WriteMemory<T>(IntPtr address, T value);
        
        /// <summary>
        /// Get a pointer using static address and offset
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="offsets">Offsets</param>
        /// <returns>Pointer found or zero if none</returns>
        IntPtr GetPointer(IntPtr address, params byte[] offsets);
        
        /// <summary>
        /// Get a pointer using pattern and offsets
        /// </summary>
        /// <param name="pattern">Pattern</param>
        /// <param name="offsets">Offsets</param>
        /// <returns>Pointer found or zero if none</returns>
        IntPtr GetPointer(Pattern pattern, params byte[] offsets);
    }
}