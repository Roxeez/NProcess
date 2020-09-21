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
    public interface IProcess
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
        /// Get a new memory object to interact with process memory
        /// </summary>
        /// <returns>Memory object created</returns>
        IMemory Memory { get; }
    }
}