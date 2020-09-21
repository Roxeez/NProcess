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

        /// <summary>
        /// Find a pattern in current module
        /// </summary>
        /// <param name="pattern">Pattern</param>
        /// <param name="offset"></param>
        /// <returns></returns>
        IntPtr FindPattern(string pattern, int offset = 0);
    }
}