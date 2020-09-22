using System;
using System.Collections.Generic;
using System.Diagnostics;
using NProcess.Extension;
using NProcess.Memory;
using NProcess.Module;

namespace NProcess
{
    /// <summary>
    /// Represent a process
    /// </summary>
    public interface IProcess : IDisposable
    {
        /// <summary>
        /// Id of the process
        /// </summary>
        int Id { get; }
        
        /// <summary>
        /// Name of the process
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Main module of the process
        /// </summary>
        IModule MainModule { get; }
        
        /// <summary>
        /// Get a module using module name
        /// </summary>
        /// <param name="name"></param>
        IModule this[string name] { get; }
        
        /// <summary>
        /// Process memory reader
        /// </summary>
        IMemoryReader MemoryReader { get; }
        
        /// <summary>
        /// Process memory writer
        /// </summary>
        IMemoryWriter MemoryWriter { get; }
    }
}